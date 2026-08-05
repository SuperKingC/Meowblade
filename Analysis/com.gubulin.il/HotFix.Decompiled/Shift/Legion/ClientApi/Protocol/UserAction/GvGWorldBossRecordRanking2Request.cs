using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGWorldBossRecordRanking2Request : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string IZId { get; set; }

	[ProtoMember(2)]
	public string WBId { get; set; }

	[ProtoMember(3)]
	public string Key { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVG_WORLDBOSS_RECORD_RANKING2;
}
