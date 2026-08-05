using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

[ProtoContract]
public class ReviewTotal
{
	[ProtoMember(1)]
	public int CampId;

	[ProtoMember(2)]
	public int FightingShipCount;

	[ProtoMember(3)]
	public int WinnerIsland;
}
