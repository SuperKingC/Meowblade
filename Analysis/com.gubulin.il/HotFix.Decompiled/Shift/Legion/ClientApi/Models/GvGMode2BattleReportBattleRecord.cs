using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class GvGMode2BattleReportBattleRecord
{
	[ProtoMember(1)]
	public int RedUserId;

	[ProtoMember(2)]
	public int BlueUserId;

	[ProtoMember(3)]
	public string BattleId;

	[ProtoMember(4)]
	public int Winner;
}
