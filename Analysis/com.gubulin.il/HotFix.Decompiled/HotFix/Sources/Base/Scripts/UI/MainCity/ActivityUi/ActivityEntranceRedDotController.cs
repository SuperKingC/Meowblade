using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using UI.Certification;
using UI.GameActivity;
using UI.WeekActivityPass;

namespace HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi;

public class ActivityEntranceRedDotController
{
	private static readonly Dictionary<string, IActivityRedDotIndicator> _indicators = new Dictionary<string, IActivityRedDotIndicator>();

	private static readonly HashSet<string> _cacheRedDots = new HashSet<string>
	{
		UI_OrcActivityPanel.Name,
		"UI_FirstTimeRewardPanel",
		UI_CumulativeCostPanel_New.Name,
		UI_main_DeparturePresent.Name,
		UI_CertificationPanel.Name
	};

	private static void EnsureIndicators()
	{
		if (_indicators.Count <= 0)
		{
			HashSet<string> allActivityUi = ActivityEntranceStatic.GetAllActivityUi();
			CreateActivityIndicators(allActivityUi);
			CreateOtherIndicators(allActivityUi);
		}
	}

	private static void CreateActivityIndicators(HashSet<string> uis)
	{
		List<Activity> checkedActivities = ActivityEntranceStatic.GetCheckedActivities();
		foreach (Activity item in checkedActivities)
		{
			if (item.GetStatus(GameManagers.Instance) != ActivityStatus.Disabled && uis.Contains(item.UiName))
			{
				if (_cacheRedDots.Contains(item.UiName))
				{
					_indicators[item.UiName] = GetRedDotCacheIndicator(item.UiName);
				}
				else
				{
					_indicators[item.UiName] = GetRedDotActivityIndicator(item);
				}
			}
		}
	}

	private static void CreateOtherIndicators(HashSet<string> uis)
	{
		foreach (string ui in uis)
		{
			if (_indicators.ContainsKey(ui))
			{
				continue;
			}
			if (ui == UI_com_SecretTreasury.Name)
			{
				_indicators[ui] = new FunctionRedDotIndicator(IsSecretTreasuryNoteVisible);
				continue;
			}
			if (ui == UI_com_SpinWeekSpin.Name)
			{
				_indicators[ui] = new FunctionRedDotIndicator(IsSpinWeekSpinNoteVisible);
				continue;
			}
			if (ui == UI_main_WeekActivityPass.Name)
			{
				_indicators[ui] = new FunctionRedDotIndicator(IsWeekActPassNoteVisible);
				continue;
			}
			IActivityRedDotIndicator redDotCacheIndicator = GetRedDotCacheIndicator(ui);
			if (redDotCacheIndicator != null)
			{
				_indicators[ui] = redDotCacheIndicator;
			}
		}
	}

	public void GetEntranceRedDotVisible(ActivityEntranceMode mode, Action<bool> callback, bool useCache = false)
	{
		EnsureIndicators();
		ActivityEntranceStatic.CheckActivities(delegate
		{
			List<string> actUis = ActivityEntranceStatic.EntranceUis[mode];
			callback(GetActivitiesRedDotVisible(actUis));
		}, useCache);
	}

	private static bool GetActivitiesRedDotVisible(List<string> actUis)
	{
		foreach (string actUi in actUis)
		{
			if (!_indicators.TryGetValue(actUi, out var value) || !value.DisplayRedDot())
			{
				continue;
			}
			return true;
		}
		return false;
	}

	private static IActivityRedDotIndicator GetRedDotCacheIndicator(string uiName)
	{
		Func<bool> indicateRedDot;
		switch (uiName)
		{
		case "UI_OrcActivityPanel":
			indicateRedDot = () => CacheManager.Instance.Get<Cache_OrcActivityRedDot>().IsShowRedDot;
			break;
		case "UI_FirstTimeRewardPanel":
			indicateRedDot = () => CacheManager.Instance.Get<Cache_NoviceRechargeRedDot>().IsShowRedDot;
			break;
		case "UI_CumulativeCostPanel_New":
			indicateRedDot = () => CacheManager.Instance.Get<Cache_BlackMarketTreasureRedDot>().IsShowRedDot;
			break;
		case "UI_main_DeparturePresent":
			indicateRedDot = () => CacheManager.Instance.Get<Cache_DeparturePresentRedDot>().IsShowRedDot;
			break;
		case "UI_CertificationPanel":
			indicateRedDot = () => CacheManager.Instance.Get<Cache_CertificationRedDot>().IsShowRedDot;
			break;
		default:
			return null;
		}
		return new ActivityRedDotCacheIndicator(indicateRedDot);
	}

	private static IActivityRedDotIndicator GetRedDotActivityIndicator(Activity activity)
	{
		switch (activity.Type)
		{
		case ActivityType.HomePageActivity:
		case ActivityType.IntlRechargeStatsSubstitute:
			return new HomePageActivityRedDotIndicator(activity);
		case ActivityType.Funds:
			return new FundsActivityRedDotIndicator(activity);
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public static bool IsSecretTreasuryNoteVisible()
	{
		return ActivityEntranceController.IsSecretTreasuryVisible() && FGUIManager.Instance.DynamicSecretTreasury.HasAnyInform();
	}

	public static bool IsSpinWeekSpinNoteVisible()
	{
		return ActivityEntranceController.IsSpinWeekSpinVisible() && ActivityManager.SpinWeekActivity.HasAnyInform();
	}

	public static bool IsWeekActPassNoteVisible()
	{
		if (!ActivityEntranceController.IsWeekActPassVisible())
		{
			return false;
		}
		return HasUnclaimedWeekActPassReward();
	}

	public static bool HasUnclaimedWeekActPassReward()
	{
		foreach (Activity weekActPass in ActivityManager.WeekActPasses)
		{
			BattlePassActivityPayload battlePassActivityPayload = (BattlePassActivityPayload)weekActPass.AllContentPayload().First().Value;
			int stock = GameManagers.Instance.StockController.GetStock(battlePassActivityPayload.ScoreItem);
			if (!string.IsNullOrEmpty(battlePassActivityPayload.PaidCert) && GameManagers.Instance.StockController.GetStock(battlePassActivityPayload.PaidCert) <= 0)
			{
				continue;
			}
			List<float> list = weekActPass.ClaimProgress(GameManagers.Instance);
			foreach (int key in battlePassActivityPayload.BonusConfig.Keys)
			{
				if (key > stock || list.Contains(key))
				{
					continue;
				}
				return true;
			}
		}
		return false;
	}

	public static bool IsShadowDemonGiftNoteVisible()
	{
		if (!ActivityEntranceController.IsShadowDemonGiftVisible())
		{
			return false;
		}
		Dictionary<string, ActivityContentPayload> dict = ActivityManager.ShadowDemonGift.ContentPayload(GameManagers.Instance);
		SoliderDevelopPayload soliderDevelopPayload = (SoliderDevelopPayload)dict.First().Value;
		return soliderDevelopPayload.HasAnyNewMsg(GameManagers.Instance);
	}
}
