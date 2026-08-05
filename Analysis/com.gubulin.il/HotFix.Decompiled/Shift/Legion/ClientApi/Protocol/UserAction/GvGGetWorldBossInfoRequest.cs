using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGGetWorldBossInfoRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int ProcessType { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVG_GET_WORLDBOSS_INFO;
}
