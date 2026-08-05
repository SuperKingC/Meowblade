using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class CardDrawCase
{
	public GDELotteryCaseData Data;

	public Dictionary<string, int> TotalCost;

	public List<string> CheckingBonusList;

	private GameManagers _managers;

	public string CaseId => Data.Key;

	public LotteryCaseType CaseType => (LotteryCaseType)Data.CaseType;

	public int TotalDraw => Data.TotalDraw;

	public string ActivityId => Data.ActivityId;

	public string DrawOption => Data.DrawOption;

	public int MinBonusQty => Data.MinBonusQty;

	public int TotalEffects => Data.TotalEffects;

	public string PrizePoolCombo => Data.PrizePoolCombo;

	public int Priority => Data.Priority;

	public bool IsFinalCase => Data.IsFinalCase;

	public CardDrawCase(GameManagers managers, GDELotteryCaseData data)
	{
		_managers = managers;
		Data = data;
		if (!string.IsNullOrEmpty(data.TotalCost))
		{
			TotalCost = JsonHelper.ToObject<Dictionary<string, int>>(data.TotalCost);
		}
		if (!string.IsNullOrEmpty(data.MinBonusItems) && data.MinBonusQty > 0)
		{
			CheckingBonusList = JsonHelper.ToObject<List<string>>(data.MinBonusItems);
		}
	}

	public bool JudgeCase(string activityId = null, string drawOption = null)
	{
		if (!string.IsNullOrEmpty(DrawOption) && !string.IsNullOrEmpty(drawOption) && DrawOption != drawOption)
		{
			return false;
		}
		bool flag = false;
		switch (CaseType)
		{
		case LotteryCaseType.DrawCnt:
			flag = JudgeDrawCnt();
			if (!flag)
			{
			}
			break;
		case LotteryCaseType.MinPrizes:
			flag = JudgeMinPrizes();
			if (!flag)
			{
			}
			break;
		case LotteryCaseType.DrawCost:
			flag = JudgeDrawCost();
			if (!flag)
			{
			}
			break;
		}
		return flag;
	}

	private bool JudgeHit(out int totalHit)
	{
		totalHit = _managers.LotteryManager.GetCaseHitCnt(CaseId);
		if (TotalEffects > 0)
		{
			return totalHit < TotalEffects;
		}
		return true;
	}

	private bool JudgeMinPrizes()
	{
		if (CheckingBonusList == null || CheckingBonusList.Count < 1)
		{
			return false;
		}
		if (!JudgeHit(out var _))
		{
			return false;
		}
		Dictionary<string, int> caseLotteryResultCache = _managers.LotteryManager.GetCaseLotteryResultCache(CaseId, ActivityId, DrawOption);
		int num = 0;
		if (caseLotteryResultCache != null)
		{
			foreach (string checkingBonus in CheckingBonusList)
			{
				if (caseLotteryResultCache.TryGetValue(checkingBonus, out var value))
				{
					num += value;
					if (num >= MinBonusQty)
					{
						_managers.LotteryManager.ResetCaseLotteryCache(CaseId);
						return false;
					}
				}
			}
		}
		if (TotalDraw <= _managers.LotteryManager.GetCaseDrawCntCache(CaseId, ActivityId, DrawOption))
		{
			_managers.LotteryManager.ResetCaseLotteryCache(CaseId);
			return true;
		}
		return false;
	}

	private bool JudgeDrawCost()
	{
		if (!JudgeHit(out var totalHit))
		{
			return false;
		}
		Dictionary<string, int> totalDrawCost = _managers.LotteryManager.GetTotalDrawCost(ActivityId, DrawOption);
		if (totalDrawCost != null)
		{
			foreach (KeyValuePair<string, int> item in TotalCost)
			{
				if (!totalDrawCost.TryGetValue(item.Key, out var value))
				{
					value = 0;
				}
				if (value < item.Value * (totalHit + 1))
				{
					return false;
				}
			}
		}
		return true;
	}

	private bool JudgeDrawCnt()
	{
		if (!JudgeHit(out var totalHit))
		{
			return false;
		}
		return _managers.LotteryManager.GetTotalDrawCnt(ActivityId, DrawOption) >= TotalDraw * (totalHit + 1);
	}
}
