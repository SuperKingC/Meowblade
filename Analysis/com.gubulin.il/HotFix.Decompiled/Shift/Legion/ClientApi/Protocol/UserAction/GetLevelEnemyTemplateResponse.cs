using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetLevelEnemyTemplateResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(3)]
	public string Message;

	[ProtoMember(4)]
	public EnemyTemplate EnemyTemplate;

	public int PacketId => PacketIds.USER_ACTION_GET_LEVEL_ENEMY_TEMPLATE_REQUEST;
}
