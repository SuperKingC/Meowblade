using System.Runtime.Serialization;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

public enum eLeaderboardType
{
	[EnumMember(Value = "0")]
	远征总贡献榜_阵营 = 0,
	[EnumMember(Value = "1")]
	战斗贡献榜_全副本 = 1,
	[EnumMember(Value = "2")]
	采集贡献榜_全副本 = 2,
	[EnumMember(Value = "3")]
	制造贡献榜_全副本 = 3,
	[EnumMember(Value = "5")]
	BOSS输出榜_全副本 = 5,
	[EnumMember(Value = "6")]
	阴影之石捐献榜_全副本 = 6,
	[EnumMember(Value = "7")]
	BOSS总输出榜_阵营 = 7,
	[EnumMember(Value = "8")]
	BOSS单日最高输出榜_全副本 = 8,
	[EnumMember(Value = "9")]
	乱斗永夜个人积分榜 = 9,
	[EnumMember(Value = "10")]
	乱斗永夜个人获胜榜 = 10,
	[EnumMember(Value = "11")]
	乱斗永夜阵营获胜榜 = 11,
	[EnumMember(Value = "20")]
	增幅器回收 = 20
}
