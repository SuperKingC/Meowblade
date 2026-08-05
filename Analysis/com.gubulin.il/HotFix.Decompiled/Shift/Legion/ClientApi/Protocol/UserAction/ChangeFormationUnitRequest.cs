using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ChangeFormationUnitRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public string Context;

	[ProtoMember(3)]
	public string Mode;

	[ProtoMember(4)]
	public int PortalId;

	[ProtoMember(5)]
	public string UnitId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CHANGE_FORMATION_UNIT_REQUEST;
}
