using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetLevelEnemyTemplateRequest : IPacketBody, IRequestPacket
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public string LevelId;

	[ProtoMember(3)]
	public string ActivityId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_LEVEL_ENEMY_TEMPLATE_REQUEST;
}
