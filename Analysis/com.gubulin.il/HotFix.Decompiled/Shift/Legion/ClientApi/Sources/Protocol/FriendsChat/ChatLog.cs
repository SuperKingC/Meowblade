using ILRuntime_LitJson;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Sources.Protocol.FriendsChat;

[ProtoContract]
public class ChatLog
{
	[ProtoMember(1)]
	public string Guid { get; set; }

	[ProtoMember(2)]
	public int Sender { get; set; }

	[ProtoMember(3)]
	public int Receiver { get; set; }

	[ProtoMember(5)]
	public int ChatType { get; set; }

	[ProtoMember(7)]
	public int MsgType { get; set; }

	[ProtoMember(9)]
	public string Content { get; set; }

	[ProtoMember(10)]
	public int MsgStatus { get; set; }

	[ProtoMember(11)]
	public long Timestamp { get; set; }

	[ProtoIgnore]
	[JsonIgnore]
	public eMsgStatus Status => (eMsgStatus)MsgStatus;
}
