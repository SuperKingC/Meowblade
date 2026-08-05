using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class CardDrawConfig
{
	public Dictionary<string, Dictionary<string, Dictionary<string, int>>> CostStats;

	public Dictionary<string, Dictionary<string, int>> DrawCntStats;

	public Dictionary<string, Dictionary<string, Dictionary<string, int>>> LotteryResultStats;

	public Dictionary<string, int> LotteryCaseStats;

	public Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, int>>>> LotteryResultCache;

	public Dictionary<string, Dictionary<string, Dictionary<string, int>>> DrawCntCache;

	public CardDrawConfig()
	{
		CostStats = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
		DrawCntStats = new Dictionary<string, Dictionary<string, int>>();
		LotteryCaseStats = new Dictionary<string, int>();
		LotteryResultStats = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
		LotteryResultCache = new Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, int>>>>();
		DrawCntCache = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
	}
}
