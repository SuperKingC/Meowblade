using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class UserIslandEntityBattleRecordSummary
{
	[ProtoMember(1)]
	public int SummaryId;

	[ProtoMember(2)]
	public int IZId;

	[ProtoMember(3)]
	public int IslandInstanceId;

	[ProtoMember(4)]
	public int ShipDeadCnt;

	public int UserId;

	[ProtoMember(5)]
	public int TotalLoss;

	[ProtoMember(6)]
	public int TotalKill;

	[ProtoMember(7)]
	public int EnemyUserId;

	public List<GvGMode2BattleReportBattleRecord> Records = new List<GvGMode2BattleReportBattleRecord>();

	public SummaryType SummaryType = SummaryType.RecordSummary;
}
