using Newtonsoft.Json;

namespace QQGRPCRobot.Domains
{
    public class GRPCServer {
	[JsonProperty("host")]
	public string Host  { get; set; }

	[JsonProperty("port")]
	public int Port { get; set; }
    }
}
