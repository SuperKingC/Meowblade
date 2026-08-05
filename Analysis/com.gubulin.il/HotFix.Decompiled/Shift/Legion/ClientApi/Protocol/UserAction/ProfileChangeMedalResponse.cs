using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ProfileChangeMedalResponse : IPacketBody
{
	[ProtoMember(99)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_PROFILE_CHANGE_GVGMEDAL;
}
