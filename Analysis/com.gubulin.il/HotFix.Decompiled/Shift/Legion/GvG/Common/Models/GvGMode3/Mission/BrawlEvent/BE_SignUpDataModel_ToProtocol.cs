using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;

[ProtoContract]
public class BE_SignUpDataModel_ToProtocol
{
	[ProtoMember(1)]
	public int UserId;

	[ProtoMember(2)]
	public string ShipId;

	[ProtoMember(3)]
	public int ShipRace;

	[ProtoMember(4)]
	public int IslandId;

	[ProtoMember(5)]
	public int BattleStrategy;

	[ProtoMember(6)]
	public int ZoneId;

	[ProtoMember(7)]
	public string ShipName;
}
