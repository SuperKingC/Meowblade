using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class GvGMode3BestKill
{
	public int EntityId;

	[ProtoMember(1)]
	public int UserId;

	[ProtoMember(2)]
	public int KillCount;

	[ProtoMember(3)]
	public int CampId;

	[ProtoMember(4)]
	public bool IsLastBestKillIsKilled;

	[ProtoMember(5)]
	public int ShipRace;

	[ProtoMember(6)]
	public int ShipSkin;
}
