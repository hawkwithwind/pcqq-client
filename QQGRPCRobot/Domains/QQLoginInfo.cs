using Newtonsoft.Json;

namespace QQGRPCRobot.Domains
{
    public class QQLoginInfo {
	[JsonProperty("qqNumber")]
	public long QQNumber  { get; set; }

	[JsonProperty("password")]
	public string Password  { get; set; }
    }
}
