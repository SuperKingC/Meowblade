using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WarOfRealmGetStageBattleRecordRequest : IRequestPacket, IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_GET_WAROFREALM_STAGEBATTLERECORD;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int StageStatus { get; set; }

	[ProtoMember(2)]
	public int GroupId { get; set; }
}
