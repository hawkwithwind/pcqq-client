using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using QQ.Framework;
using QQ.Framework.Domains;
using QQ.Framework.Sockets;
using QQGRPCRobot.Robots;
using QQGRPCRobot.Domains;
using Grpc.Core;
using Chatbothub;
using Newtonsoft.Json;

namespace QQGRPCRobot
{
    public class QQBotClient
    {
	readonly ChatBotHub.ChatBotHubClient _client;
	private AsyncDuplexStreamingCall<Chatbothub.EventRequest, Chatbothub.EventReply> _tunnel;

	readonly public string clientId;
	readonly public string clientType;
	    
	private void Log(string str)
	{
	    Console.WriteLine($"{DateTime.Now.ToString()}--{str}");
	}

	private void Log(string str, params object[] args)
	{
	    Console.WriteLine(String.Format($"{DateTime.Now.ToString()}--{str}", args));
	}
	    
	public QQBotClient(ChatBotHub.ChatBotHubClient client)
	{
	    this.clientId = Guid.NewGuid().ToString();
	    this.clientType = "QQBOT";
	    this._client = client;
	}

	public async Task SendEvent(EventRequest eventRequest) {
	    await _tunnel.RequestStream.WriteAsync(eventRequest);
	}

	private IEnumerable<EventRequest> SendPing(int seconds)
	{
	    while (true)
	    {
		EventRequest request = new EventRequest() {
		    EventType = "PING",
		    Body="",
		    ClientId=this.clientId,
		    ClientType=this.clientType
		};
		yield return request;
		System.Threading.Thread.Sleep(seconds * 1000);
	    }
	}
	    
	public async Task ListenTunnel() {
	    try
	    {
		Log("BEGIN LISTEN");
		using (var tunnel = _client.EventTunnel())
		{
		    this._tunnel = tunnel;
		    var responseTask = Task.Run(async () => {
			    while (await tunnel.ResponseStream.MoveNext(CancellationToken.None))
			    {
				var response = tunnel.ResponseStream.Current;
				Log($"GOT MESSAGE {response.EventType} {response.Body}");

				if(response.EventType == "LOGIN") {				    
				    QQLoginInfo qqinfo = JsonConvert.DeserializeObject<QQLoginInfo>(response.Body);
				    var user = new QQUser(qqinfo.QQNumber, qqinfo.Password);
				    var socketServer = new GRPCSocketServiceImpl(user, this);
				    var transponder = new Transponder();
				    var sendService = new GRPCSendMessageServiceImpl(socketServer, user);

				    var manage = new MessageManage(socketServer, user, transponder);
				    var robot = new GRPCRobot(sendService, transponder, user, this);
	    
				    manage.Init();
				}
			    }
			});
			
		    EventRequest req = new EventRequest{
			EventType = "REGISTER",
			Body = "HELLO",
			ClientId=this.clientId,
			ClientType=this.clientType};
		    await tunnel.RequestStream.WriteAsync(req);

		    foreach(EventRequest ping in SendPing(10))
		    {
			await tunnel.RequestStream.WriteAsync(ping);
		    }
		    await tunnel.RequestStream.CompleteAsync();

		    await responseTask;
		    Log("Tunnel ended");
		}	    
	    }
	    catch (RpcException e)
	    {
		Log("RPC failed", e);
		throw;
	    }
	}
    }
}
