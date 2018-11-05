using Newtonsoft.Json;

namespace QQGRPCRobot.Domains
{
    public class RobotConfig
    {
	[JsonProperty("grpcServer")]
	public GRPCServer GrpcServer { get; set; }

	[JsonProperty("clientId")]
	public string ClientId { get; set; }
    }
}
