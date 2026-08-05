using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;

[ProtoContract]
public class BE_SignUpDataModel_ToProtocol2
{
	[ProtoMember(1)]
	public int UserId;

	[ProtoMember(2)]
	public int ShipRace;

	[ProtoMember(3)]
	public int BattleStrategy;

	[ProtoMember(4)]
	public int ZoneId;
}
