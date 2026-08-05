using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetBBSKeyResponse : IPacketBody
{
	[ProtoMember(99)]
	public bool Result { get; set; }

	[ProtoMember(1)]
	public int UserId { get; set; }

	[ProtoMember(2)]
	public int Timestamp { get; set; }

	[ProtoMember(3)]
	public string BBSKey { get; set; }

	[ProtoMember(4)]
	public string BBSURL { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_BBS_KEY;
}
