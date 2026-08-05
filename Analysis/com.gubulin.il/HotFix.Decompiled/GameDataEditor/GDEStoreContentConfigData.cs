using System.Collections.Generic;
using ProtoBuf;

namespace GameDataEditor;

[ProtoContract]
public class GDEStoreContentConfigData
{
	[ProtoMember(1)]
	public string Key;

	[ProtoMember(2)]
	public string IOSProductID_International;

	[ProtoMember(3)]
	public string GoogleProductID;

	[ProtoMember(4)]
	public string IOSProductID;

	[ProtoMember(5)]
	public string Name;

	[ProtoMember(6)]
	public string Icon;

	[ProtoMember(7)]
	public int Category;

	[ProtoMember(8)]
	public string Desc;

	[ProtoMember(9)]
	public string SubDesc;

	[ProtoMember(10)]
	public int Qty;

	[ProtoMember(11)]
	public string OriginPrice;

	[ProtoMember(12)]
	public string Price;

	[ProtoMember(13)]
	public string InternationalPrice;

	[ProtoMember(14)]
	public string Content;

	[ProtoMember(15)]
	public string DisplayContent;

	[ProtoMember(16)]
	public bool DoubleAtFirst;

	[ProtoMember(17)]
	public string BonusAtFirst;

	[ProtoMember(18)]
	public bool IsExpo;

	[ProtoMember(19)]
	public List<string> Tags = new List<string>();

	[ProtoMember(20)]
	public int Rarity;

	[ProtoMember(21)]
	public float Discount;

	[ProtoMember(22)]
	public int Limit;

	[ProtoMember(23)]
	public int LimitPeriod;

	[ProtoMember(24)]
	public int ValidTime;

	[ProtoMember(25)]
	public bool IsResident;

	[ProtoMember(26)]
	public string Substitution;

	[ProtoMember(27)]
	public string GameLevelFilter;

	[ProtoMember(28)]
	public int UserLevelFilter;

	[ProtoMember(29)]
	public int DungeonLevelFilter;

	[ProtoMember(30)]
	public string OwnedItemFilter;

	[ProtoMember(31)]
	public string PurchaseFilter;

	[ProtoMember(32)]
	public string MissionFilter;

	[ProtoMember(33)]
	public List<string> WeekDayFilter = new List<string>();

	[ProtoMember(34)]
	public int SortOrder;

	[ProtoMember(35)]
	public string KickOffAt;

	[ProtoMember(36)]
	public string ExpireAt;

	[ProtoMember(37)]
	public int PlatformMask;

	[ProtoMember(38)]
	public float InternationalDiscount;

	[ProtoMember(39)]
	public string TapTapIntlProductID;

	[ProtoMember(40)]
	public string SteamProductID;
}
