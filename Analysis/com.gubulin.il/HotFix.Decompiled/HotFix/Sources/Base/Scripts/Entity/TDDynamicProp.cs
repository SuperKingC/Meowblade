using System;
using System.Collections.Generic;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using ThinkingData.Analytics;

namespace HotFix.Sources.Base.Scripts.Entity;

public class TDDynamicProp : TDDynamicSuperPropertiesHandler
{
	public Dictionary<string, object> GetDynamicSuperProperties()
	{
		string value = GameManagers.Instance.UserArchiveManager.GetCurrentLevelId();
		if (string.IsNullOrEmpty(value))
		{
			value = "city";
		}
		return new Dictionary<string, object>
		{
			{
				"KEY_DYNAMIC_Time",
				DateTime.Now
			},
			{
				"level",
				GameManagers.Instance.UserArchiveManager.GetUserLevel()
			},
			{ "mainline_underway", value },
			{
				"total_revenue",
				GameManagers.Instance.UserArchiveManager.GetTotalRecharge()
			},
			{
				"total_revenue_times",
				GameManagers.Instance.UserArchiveManager.GetRechargeOrderCnt()
			},
			{
				"diamond_hold",
				GameManagers.Instance.StockController.GetStock("Gem")
			},
			{
				"gold_hold",
				GameManagers.Instance.StockController.GetStock("Money")
			},
			{
				"card_hold",
				GameManagers.Instance.StockController.GetOwnedSoldiers(onlyUnlocked: true).Count
			},
			{
				"farmer_hold",
				Dungeon.GetFreeManPower(GameManagers.Instance)
			},
			{
				"legendItems_exchangeCount",
				ThinkingDataHelper.Instance.GetLegendItemFromBlackMarketStats()
			}
		};
	}
}
