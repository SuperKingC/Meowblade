using System.Runtime.Serialization;

namespace Shift.Legion.GvG.Common.Models.GvGMode3.ObserverStat;

public enum eObserverStatKey
{
	[EnumMember(Value = "1")]
	FillupSoldier = 1,
	[EnumMember(Value = "2")]
	KillSoldier = 2,
	[EnumMember(Value = "3")]
	JoinBattle = 3,
	[EnumMember(Value = "4")]
	Collecting = 4,
	[EnumMember(Value = "5")]
	CreatePlayerCommand = 5,
	[EnumMember(Value = "6")]
	TalentLevel = 6,
	[EnumMember(Value = "7")]
	GetBattleReward = 7,
	[EnumMember(Value = "8")]
	Purification = 8,
	[EnumMember(Value = "9")]
	JoinRandomEvent = 9,
	[EnumMember(Value = "10")]
	CostFood = 10,
	[EnumMember(Value = "11")]
	ForgeAmplifier = 11,
	[EnumMember(Value = "12")]
	ForgeCriticalAmplifier = 12,
	[EnumMember(Value = "13")]
	SubmitOEM = 13,
	[EnumMember(Value = "14")]
	ForgeLegendAmplifier = 14,
	[EnumMember(Value = "15")]
	ExtraCollectingByTalent = 15,
	[EnumMember(Value = "16")]
	ShareCollectingModel = 16,
	[EnumMember(Value = "17")]
	ShareIsland = 17,
	[EnumMember(Value = "20")]
	BestKillShip = 20,
	[EnumMember(Value = "21")]
	LossSoldier = 21,
	[EnumMember(Value = "22")]
	TopBossDamage = 22,
	[EnumMember(Value = "23")]
	CommonStoneCost = 23,
	[EnumMember(Value = "24")]
	RareStoneCost = 24,
	[EnumMember(Value = "25")]
	SweepCount = 25,
	[EnumMember(Value = "26")]
	RefillSweepCountByPurchase = 26
}
