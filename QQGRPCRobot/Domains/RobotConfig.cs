using Newtonsoft.Json;

namespace QQGRPCRobot.Domains
{
    public class RobotConfig
    {
	[JsonProperty("grpcServer")]
	public GRPCServer GrpcServer { get; set; }
    }
}
