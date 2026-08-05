using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;
using Shift.Legion.Common.Models;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BrawlUi;

public class BrawlSettleUiInfo : IBrawlSettleUiInfo
{
	public const int FINAL_STEP_MIN_INDEX = 100;

	public IBrawlIslandUiInfo IslandInfo { get; private set; }

	public Dictionary<BrawlRankType, IBrawlRankUiInfo> RankUiInfos { get; private set; }

	public Dictionary<BrawlSettleBonusUiType, IBrawlBonusUiInfo> Bonuses { get; private set; }

	public int Progress { get; private set; }

	public int IslandId { get; private set; }

	public int UserRank { get; private set; }

	public BrawlSettleUiInfo(BrawlEventSettleInfo info, int stepIdx)
	{
		bool flag = stepIdx >= 100;
		int progress = (flag ? 1 : 0);
		IslandInfo = ReadIslandUiInfo(info, flag);
		RankUiInfos = ReadRankUiInfos(info, progress);
		Bonuses = ReadBonuses(info);
		ReadOtherUiInfo(info, progress);
	}

	private static BrawlSettleIslandUiInfo ReadIslandUiInfo(BrawlEventSettleInfo info, bool isFinal)
	{
		return new BrawlSettleIslandUiInfo(info, isFinal);
	}

	private static Dictionary<BrawlRankType, IBrawlRankUiInfo> ReadRankUiInfos(BrawlEventSettleInfo info, int progress)
	{
		return new Dictionary<BrawlRankType, IBrawlRankUiInfo>(2)
		{
			{
				BrawlRankType.User,
				new BrawlUserRankUiInfo(info, progress)
			},
			{
				BrawlRankType.Camp,
				new BrawlCampRankUiInfo(info, progress)
			}
		};
	}

	private static Dictionary<BrawlSettleBonusUiType, IBrawlBonusUiInfo> ReadBonuses(BrawlEventSettleInfo info)
	{
		Dictionary<BrawlSettleBonusUiType, IBrawlBonusUiInfo> dictionary = new Dictionary<BrawlSettleBonusUiType, IBrawlBonusUiInfo>(6);
		string text = 0.ToString();
		foreach (KeyValuePair<string, BrawlEventSettleInfoBonus> item in info.Reward)
		{
			if (item.Key == text)
			{
				int contributionType = 49;
				int num = item.Value.Bonuses.FindIndex((RItem item) => Item.ItemType(item.ItemId) == contributionType);
				if (num == -1)
				{
					dictionary.Add(BrawlSettleBonusUiType.Self, new BrawlSettleBonusUiInfo(item.Value, BrawlSettleBonusUiType.Self, info.HasExtraScorePar));
					continue;
				}
				List<RItem> list = item.Value.Bonuses.Clone();
				BrawlEventSettleInfoBonus bonus = new BrawlEventSettleInfoBonus
				{
					Bonuses = new List<RItem> { list[num] }.Clone(),
					TalentSrcList = new List<int>()
				};
				dictionary.Add(BrawlSettleBonusUiType.SelfContribution, new BrawlSettleBonusUiInfo(bonus, BrawlSettleBonusUiType.SelfContribution, info.HasExtraScorePar));
				list.RemoveAt(num);
				BrawlEventSettleInfoBonus bonus2 = new BrawlEventSettleInfoBonus
				{
					Bonuses = list,
					TalentSrcList = item.Value.TalentSrcList
				};
				dictionary.Add(BrawlSettleBonusUiType.Self, new BrawlSettleBonusUiInfo(bonus2, BrawlSettleBonusUiType.Self, info.HasExtraScorePar));
			}
			else
			{
				eBrawlEventSettleInfoType type = (eBrawlEventSettleInfoType)Enum.Parse(typeof(eBrawlEventSettleInfoType), item.Key);
				BrawlSettleBonusUiType brawlSettleBonusUiType = ConvertType(type);
				List<RItem> bonuses = item.Value.Bonuses;
				if (bonuses == null || bonuses.Count > 0)
				{
					dictionary.Add(brawlSettleBonusUiType, new BrawlSettleBonusUiInfo(item.Value, brawlSettleBonusUiType, info.HasExtraScorePar));
				}
			}
		}
		return dictionary;
	}

	private static BrawlSettleBonusUiType ConvertType(eBrawlEventSettleInfoType type, int itemType = 0)
	{
		switch (type)
		{
		case eBrawlEventSettleInfoType.Self:
			return (itemType != 49) ? BrawlSettleBonusUiType.Self : BrawlSettleBonusUiType.SelfContribution;
		case eBrawlEventSettleInfoType.SelfExtra:
			return BrawlSettleBonusUiType.SelfExtra;
		case eBrawlEventSettleInfoType.Camp:
			return BrawlSettleBonusUiType.Camp;
		case eBrawlEventSettleInfoType.CampExtra:
			return BrawlSettleBonusUiType.CampExtra;
		case eBrawlEventSettleInfoType.FinalSelf:
		case eBrawlEventSettleInfoType.FinalCamp:
			return BrawlSettleBonusUiType.Final;
		default:
			return BrawlSettleBonusUiType.Invalid;
		}
	}

	private void ReadOtherUiInfo(BrawlEventSettleInfo info, int progress)
	{
		Progress = progress;
		IslandId = info.IslandId;
		UserRank = info.UserRank;
	}
}
