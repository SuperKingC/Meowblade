using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ProfileChangeMedalRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(999)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string ChangeContext { get; set; }

	public int PacketId => PacketIds.USER_ACTION_PROFILE_CHANGE_GVGMEDAL;
}
