using ProtoBuf;

namespace GameDataEditor;

[ProtoContract]
public class GDELevelData
{
	[ProtoMember(1)]
	public string Key;

	[ProtoMember(2)]
	public string ChapterId;

	[ProtoMember(3)]
	public string Context;

	[ProtoMember(4)]
	public int Difficult;

	[ProtoMember(5)]
	public float EnemyPowerModifier;

	[ProtoMember(6)]
	public string LevelFilters;

	[ProtoMember(7)]
	public string SoldierFilters;

	[ProtoMember(8)]
	public string ParentLevelId;

	[ProtoMember(9)]
	public string SubLevels;

	[ProtoMember(10)]
	public string Name;

	[ProtoMember(11)]
	public string Desc;

	[ProtoMember(12)]
	public string Icon;

	[ProtoMember(13)]
	public float Refresh;

	[ProtoMember(14)]
	public int UpperLimit;

	[ProtoMember(15)]
	public bool Staging;

	[ProtoMember(16)]
	public int RedTeamBattleMode;

	[ProtoMember(17)]
	public int BlueTeamBattleMode;

	[ProtoMember(18)]
	public string RedTeamBoss;

	[ProtoMember(19)]
	public string BlueTeamBoss;

	[ProtoMember(20)]
	public string RedTeamCampImage;

	[ProtoMember(21)]
	public string BlueTeamCampImage;

	[ProtoMember(22)]
	public bool DynamicEnemy;

	[ProtoMember(23)]
	public string FromEnemyTemplatePool;

	[ProtoMember(24)]
	public string Enemy1;

	[ProtoMember(25)]
	public int Number1;

	[ProtoMember(26)]
	public int ExpGain1;

	[ProtoMember(27)]
	public int TechGain1;

	[ProtoMember(28)]
	public string Enemy2;

	[ProtoMember(29)]
	public int Number2;

	[ProtoMember(30)]
	public int ExpGain2;

	[ProtoMember(31)]
	public int TechGain2;

	[ProtoMember(32)]
	public string Enemy3;

	[ProtoMember(33)]
	public int Number3;

	[ProtoMember(34)]
	public int ExpGain3;

	[ProtoMember(35)]
	public int TechGain3;

	[ProtoMember(36)]
	public string Enemy4;

	[ProtoMember(37)]
	public int Number4;

	[ProtoMember(38)]
	public int ExpGain4;

	[ProtoMember(39)]
	public int TechGain4;

	[ProtoMember(40)]
	public string Enemy5;

	[ProtoMember(41)]
	public int Number5;

	[ProtoMember(42)]
	public string Enemy6;

	[ProtoMember(43)]
	public int Number6;

	[ProtoMember(44)]
	public string Enemy7;

	[ProtoMember(45)]
	public int Number7;

	[ProtoMember(46)]
	public string Enemy8;

	[ProtoMember(47)]
	public int Number8;

	[ProtoMember(48)]
	public string Enemy9;

	[ProtoMember(49)]
	public int Number9;

	[ProtoMember(50)]
	public string Enemy10;

	[ProtoMember(51)]
	public int Number10;

	[ProtoMember(52)]
	public string Enemy11;

	[ProtoMember(53)]
	public int Number11;

	[ProtoMember(54)]
	public string Enemy12;

	[ProtoMember(55)]
	public int Number12;

	[ProtoMember(56)]
	public string RedFormationId;

	[ProtoMember(57)]
	public string BlueFormationId;

	[ProtoMember(58)]
	public float Length;

	[ProtoMember(59)]
	public string Obstacles;

	[ProtoMember(60)]
	public float PositionX;

	[ProtoMember(61)]
	public string AutoProduceBonus;

	[ProtoMember(62)]
	public bool AutoLottery;

	[ProtoMember(63)]
	public string TitleBonus;

	[ProtoMember(64)]
	public string BonusDesc;

	[ProtoMember(65)]
	public string LevelModifier;

	[ProtoMember(66)]
	public string UnlockChapter;

	[ProtoMember(67)]
	public string MapIdentifier;

	[ProtoMember(68)]
	public string PlayAfterClaim;

	[ProtoMember(69)]
	public string PlayAfterComplete;

	[ProtoMember(70)]
	public string PlayAfterComplete_GuideForeign;
}
