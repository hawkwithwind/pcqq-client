using System;
using Newtonsoft.Json;

using QQ.Framework;
using QQ.Framework.Domains;
using QQ.Framework.Utils;

using Chatbothub;

namespace QQGRPCRobot.Robots
{
    public class GRPCRobot : CustomRobot
    {
	private QQBotClient _botclient;

	public class QQMessage {
	    public long FromNumber;
	    public string Type;
	    public Richtext Content;
	}
	
        public GRPCRobot(ISendMessageService service, IServerMessageSubject transponder, QQUser user, QQBotClient botclient) : base(service, transponder, user)
        {
	    this._botclient = botclient;
        }

        public override void ReceiveFriendMessage(long friendNumber, Richtext content)
        {
            Console.WriteLine($"机器人收到来自{friendNumber}的消息{content}");
            this._botclient.SendEvent(new EventRequest() {
		    EventType = "MESSAGE",
		    Body=JsonConvert.SerializeObject(new QQMessage() {
			    FromNumber=friendNumber,
			    Type="FromFriend",
			    Content=content
			}),
		    ClientId=this._botclient.clientId,
		    ClientType=this._botclient.clientType
		}).Wait();
        }

        public override void ReceiveGroupMessage(long groupNumber, long fromNumber, Richtext content)
        {
            Console.WriteLine($"机器人收到来自{groupNumber}的{fromNumber}的消息{content}");
	    this._botclient.SendEvent(new EventRequest() {
		    EventType = "MESSAGE",
		    Body=JsonConvert.SerializeObject(new QQMessage() {
			    FromNumber=groupNumber,
			    Type="FromGroup",
			    Content=content
			}),
		    ClientId=this._botclient.clientId,
		    ClientType=this._botclient.clientType
		}).Wait();
        }
    }
}
