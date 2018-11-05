using System;
using System.Text;
using System.IO;
using System.Threading;
using Grpc.Core;
using Chatbothub;
using Newtonsoft.Json;

using QQGRPCRobot.Domains;

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
	
        private static void Main(string[] args)
        {
	    RobotConfig config = LoadConfig("./config.json");
	    GRPCServer server = config.GrpcServer;
	    
	    Channel channel = new Channel(String.Format("{0}:{1}", server.Host, server.Port)
					  , ChannelCredentials.Insecure);
	    var client = new QQBotClient(new ChatBotHub.ChatBotHubClient(channel), config.ClientId);
	    while(true) {
		client.ListenTunnel().Wait();
		Thread.Sleep(10 * 1000);
		Console.WriteLine("retry connect GRPC ...");
	    }
	    
	    channel.ShutdownAsync().Wait();
	    Console.WriteLine("Tunnel stopped; program exit.");
        }
    }
}
