using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.Certification;
using UI.GameActivity;
using UI.WeekActivityPass;

namespace HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi;

public static class ActivityEntranceStatic
{
	private const string MISSIONS_OF_7DAYS1 = "MissionsOf7Days1";

	public static readonly Dictionary<ActivityEntranceMode, List<string>> EntranceUis = new Dictionary<ActivityEntranceMode, List<string>>
	{
		{
			ActivityEntranceMode.Rewards,
			new List<string>
			{
				UI_com_SpinWeekSpin.Name,
				UI_main_WeekActivityPass.Name,
				UI_com_SecretTreasury.Name,
				UI_OrcActivityPanel.Name,
				UI_DailySignPanel.Name,
				UI_CumulativeCostPanel_New.Name,
				UI_CumulativeCostPanel.Name,
				UI_GemFundPanel.Name,
				UI_ChipFundPanel.Name,
				UI_GrowthFundPanel.Name,
				UI_LegendItemFundPanel.Name,
				UI_PatronPanel.Name,
				UI_CertificationPanel.Name
			}
		},
		{
			ActivityEntranceMode.NewcomerSpecial,
			new List<string>
			{
				UI_SignInPanel.Name,
				UI_com_ShadowDemonGift.Name,
				UI_main_DeparturePresent.Name,
				"UI_SevenDaysMissionPanel",
				"UI_FirstTimeRewardPanel",
				UI_LegionCultivateFundPanel.Name
			}
		},
		{
			ActivityEntranceMode.NewGuideModeRewards,
			new List<string>
			{
				UI_com_SpinWeekSpin.Name,
				UI_main_WeekActivityPass.Name,
				UI_com_ShadowDemonGift.Name,
				UI_com_SecretTreasury.Name,
				UI_OrcActivityPanel.Name,
				"UI_FirstTimeRewardPanel",
				"UI_SevenDaysMissionPanel",
				UI_SignInPanel.Name,
				UI_CumulativeCostPanel.Name,
				UI_CumulativeCostPanel_New.Name,
				UI_DailySignPanel.Name,
				UI_ChipFundPanel.Name,
				UI_GemFundPanel.Name,
				UI_GrowthFundPanel.Name,
				UI_LegendItemFundPanel.Name,
				UI_PatronPanel.Name,
				UI_CertificationPanel.Name
			}
		},
		{
			ActivityEntranceMode.NewForeignRewards,
			new List<string>
			{
				UI_com_SecretTreasury.Name,
				UI_OrcActivityPanel.Name,
				UI_DailySignPanel.Name,
				UI_CumulativeCostPanel_New.Name,
				UI_CumulativeCostPanel.Name,
				UI_GemFundPanel.Name,
				UI_ChipFundPanel.Name,
				UI_GrowthFundPanel.Name,
				UI_LegendItemFundPanel.Name,
				UI_PatronPanel.Name
			}
		},
		{
			ActivityEntranceMode.NewForeignNewcomerSpecial,
			new List<string>
			{
				UI_SignInPanel.Name,
				"UI_FirstTimeRewardPanel",
				UI_main_DeparturePresent.Name,
				UI_com_ShadowDemonGift.Name,
				UI_LegionCultivateFundPanel.Name,
				UI_com_SpinWeekSpin.Name,
				UI_main_WeekActivityPass.Name
			}
		},
		{
			ActivityEntranceMode.SpinWeek,
			new List<string>
			{
				UI_com_SpinWeekSpin.Name,
				UI_main_WeekActivityPass.Name
			}
		}
	};

	private static Action _onChecked;

	private static readonly List<ActivityType> _activityTypes = new List<ActivityType>
	{
		ActivityType.HomePageActivity,
		ActivityType.Funds,
		ActivityType.IntlRechargeStatsSubstitute
	};

	public static HashSet<string> GetAllActivityUi()
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (KeyValuePair<ActivityEntranceMode, List<string>> entranceUi in EntranceUis)
		{
			foreach (string item in entranceUi.Value)
			{
				hashSet.Add(item);
			}
		}
		return hashSet;
	}

	public static void CheckActivities(Action onChecked = null, bool useCache = false)
	{
		if (useCache)
		{
			onChecked?.Invoke();
			return;
		}
		bool flag = _onChecked != null;
		_onChecked = (Action)Delegate.Combine(_onChecked, onChecked);
		if (!flag)
		{
			GameManagers.Instance.ActivityManager.CheckActivities(null, _activityTypes, delegate
			{
				_onChecked?.Invoke();
				_onChecked = null;
			});
		}
	}

	public static async Task GetSpinWeekActivity()
	{
		GetWeeklyActivityResponse activity = await GameController.Contexts.Service<INetworkService>().GetWeeklyActivity();
		if (activity.ErrorCode == 0)
		{
			if (activity.ActivityProgress.NewPeroid)
			{
				GameManagers.Instance.StoreManager.PurchaseStat.GetValue().ClearSpinWeekPurchaseStat();
			}
			ActivityManager.SpinWeekActivity = activity;
		}
		else
		{
			ActivityManager.SpinWeekActivity = null;
		}
	}

	public static List<Activity> GetCheckedActivities()
	{
		List<Activity> activitiesByType = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.HomePageActivity);
		activitiesByType.AddRange(GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.Funds));
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			activitiesByType.AddRange(GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.IntlRechargeStatsSubstitute));
			for (int num = activitiesByType.Count - 1; num >= 0; num--)
			{
				Activity activity = activitiesByType[num];
				if (GameManagers.Instance.UserArchiveManager.IsForeignNewGuideMode() && activity.ActivityId == "MissionsOf7Days1")
				{
					activitiesByType.RemoveAt(num);
				}
			}
		}
		return activitiesByType;
	}
}
