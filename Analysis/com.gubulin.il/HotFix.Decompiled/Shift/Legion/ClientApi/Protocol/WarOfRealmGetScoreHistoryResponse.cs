using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WarOfRealmGetScoreHistoryResponse : IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_WAROFREALM_GET_SCOREHISTORY;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Protocol.WeekScoreRecord")]
	public List<WeekScoreRecord> ScoreRecords { get; set; }

	[ProtoMember(2)]
	public int TotalScore { get; set; }
}
