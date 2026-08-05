using System.Collections.Generic;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.Model;

public static class SweepConfigExtensions
{
	public static BuySweepCountConfig GetBuySweepConfigByBuyCount(this SweepConfig config, int buyCount)
	{
		return config.BuySweepCountConfig.Find((BuySweepCountConfig countConfig) => FindConfigByBuyCount(countConfig, buyCount));
	}

	private static bool FindConfigByBuyCount(BuySweepCountConfig countConfig, int buyCount)
	{
		int[] range = countConfig.Range;
		return range[0] <= buyCount && buyCount <= range[1];
	}

	public static void CheckBuySweepConfigCost(this BuySweepCountConfig buySweepCountConfig)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (KeyValuePair<string, int> item in buySweepCountConfig.Cost)
		{
			dictionary.Add(item.Key, -Mathf.Abs(item.Value));
		}
		buySweepCountConfig.Cost = dictionary;
	}
}
