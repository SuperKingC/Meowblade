using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models;

[ProtoContract]
public class ShipSummaryUnitInfo
{
	[ProtoMember(1)]
	public string SoldierId;

	[ProtoMember(2)]
	public int PotentialLevel;

	[ProtoMember(3)]
	public int PerTeamMemberCnt;

	[ProtoMember(4)]
	public int Total;

	[ProtoMember(5)]
	public int CurCnt;

	[ProtoMember(6)]
	public int[] EquippedItems;

	[ProtoMember(7)]
	public int SoldierLevel;
}
