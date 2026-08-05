using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetLevelReplaysResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(10, TypeName = "Shift.Legion.ClientApi.Models.LevelBattleReplay")]
	public List<LevelBattleReplay> Replays;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_LEVEL_REPLAYS_REQUEST;
}
