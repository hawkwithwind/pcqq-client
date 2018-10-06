using System;
using System.Text;
using System.IO;
using System.Threading;
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

	public static void MessageLog(string str)
        {
            Console.WriteLine($"{DateTime.Now.ToString()}--{str}");
        }
	
        private static void Main(string[] args)
        {
	    RobotConfig config = LoadConfig("./config.json");
	    GRPCServer server = config.GrpcServer;
	    
	    Channel channel = new Channel(String.Format("{0}:{1}", server.Host, server.Port)
					  , ChannelCredentials.Insecure);

	    var client = new ChatBotHub.ChatBotHubClient(channel);
	    
	    using (var tunnel = client.EventTunnel())
	    {
		MessageLog("BEFORE MESSAGE");
		EventRequest req = new EventRequest();
		req.EventType = "MESSAGE";
		req.Body = "HELLO";
		req.Txid = "1";
		tunnel.RequestStream.WriteAsync(req).Wait();
		MessageLog("SEND MESSAGE");
	    }

	    QQLoginInfo qqinfo = config.QQLoginInfo;

	    MessageLog($" login with {qqinfo.QQNumber} {qqinfo.Password}");
            var user = new QQUser(qqinfo.QQNumber, qqinfo.Password);
            var socketServer = new SocketServiceImpl(user);
            var transponder = new Transponder();
            var sendService = new SendMessageServiceImpl(socketServer, user);

            var manage = new MessageManage(socketServer, user, transponder);
            var robot = new GRPCRobot(sendService, transponder, user);

            manage.Init();

	    MessageLog("sleep ...");
	    Thread.Sleep(60*60*1000);
	    MessageLog("awake 1hour later, force close");
        }
    }
}
