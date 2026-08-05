using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class RunningBattleLogItem
{
	[ProtoMember(1)]
	public string BattleLogKey;

	[ProtoMember(2)]
	public int UserId;
}
