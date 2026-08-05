using ProtoBuf;

namespace GameDataEditor;

[ProtoContract]
public class GDELevelBonusData
{
	[ProtoMember(1)]
	public string Key;

	[ProtoMember(2)]
	public string LevelId;

	[ProtoMember(3)]
	public string Unlock;

	[ProtoMember(4)]
	public string Lottery;

	[ProtoMember(5)]
	public string Bonus;

	[ProtoMember(6)]
	public string RepeatBonus;

	[ProtoMember(7)]
	public string RepeatLottery;
}
