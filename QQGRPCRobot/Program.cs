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
    public static class Program
    {

	private static RobotConfig LoadConfig(String path) {
	    using (StreamReader r = new StreamReader(path)) {
		string text = r.ReadToEnd();
		return JsonConvert.DeserializeObject<RobotConfig>(text);
	    }
	}

	public class QQBotClient
	{
	    readonly ChatBotHub.ChatBotHubClient client;

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
		this.client = client;
	    }

	    IEnumerable<EventRequest> SendPing(int seconds)
	    {
		while (true)
		{
		    EventRequest request = new EventRequest() {
			EventType = "PING",
			Body="",
			Txid="1"
		    };
		    yield return request;
		    System.Threading.Thread.Sleep(seconds * 1000);
		}
	    }
	    
	    public async Task ListenTunnel() {
		try
		{
		    Log("BEGIN LISTEN");
		    using (var tunnel = client.EventTunnel())
		    {

			var responseTask = Task.Run(async () =>
			{
			    while (await tunnel.ResponseStream.MoveNext(CancellationToken.None))
			    {
				var response = tunnel.ResponseStream.Current;
				Log($"GOT MESSAGE {response.EventType} {response.Body} {response.Txid}");

				if(response.EventType == "LOGIN") {
				    QQLoginInfo qqinfo = JsonConvert.DeserializeObject<QQLoginInfo>(response.Body);
				    var user = new QQUser(qqinfo.QQNumber, qqinfo.Password);
				    var socketServer = new SocketServiceImpl(user);
				    var transponder = new Transponder();
				    var sendService = new SendMessageServiceImpl(socketServer, user);

				    var manage = new MessageManage(socketServer, user, transponder);
				    var robot = new GRPCRobot(sendService, transponder, user);
	    
				    manage.Init();
				}
			    }
			});
			
			EventRequest req = new EventRequest{
			    EventType = "MESSAGE",
			    Body = "HELLO",
			    Txid = "1"};			
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
	
        private static void Main(string[] args)
        {
	    RobotConfig config = LoadConfig("./config.json");
	    GRPCServer server = config.GrpcServer;
	    
	    Channel channel = new Channel(String.Format("{0}:{1}", server.Host, server.Port)
					  , ChannelCredentials.Insecure);
	    var client = new QQBotClient(new ChatBotHub.ChatBotHubClient(channel));
	    client.ListenTunnel().Wait();
	    
	    
	    channel.ShutdownAsync().Wait();
	    Console.WriteLine("Tunnel stopped; program exit.");
        }
    }
}
