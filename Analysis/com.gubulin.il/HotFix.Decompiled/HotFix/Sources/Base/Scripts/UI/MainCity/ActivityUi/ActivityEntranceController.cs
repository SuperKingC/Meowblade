using System;
using System.Collections.Generic;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using UI.Certification;
using UI.GameActivity;
using UI.WeekActivityPass;

namespace HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi;

public class ActivityEntranceController
{
	private Dictionary<string, bool> _activitiesCompleted = new Dictionary<string, bool>();

	public List<string> GetActivityTabFilter(ActivityEntranceMode mode)
	{
		EntranceIsVisible(mode, out var displayUis);
		return displayUis;
	}

	public void CheckEntranceVisible(Action<ActivityEntranceVisible> callback)
	{
		ActivityEntranceStatic.CheckActivities(delegate
		{
			_activitiesCompleted = CheckActivitiesCompleted(ActivityEntranceStatic.GetCheckedActivities());
			callback(GetVisibleResult());
		}, useCache: true);
	}

	private ActivityEntranceVisible GetVisibleResult()
	{
		Dictionary<ActivityEntranceMode, bool> dictionary = new Dictionary<ActivityEntranceMode, bool>();
		Dictionary<ActivityEntranceMode, List<string>> dictionary2 = new Dictionary<ActivityEntranceMode, List<string>>();
		bool value = EntranceIsVisible(ActivityEntranceMode.Rewards, out var displayUis);
		dictionary[ActivityEntranceMode.Rewards] = value;
		dictionary2[ActivityEntranceMode.Rewards] = displayUis;
		value = EntranceIsVisible(ActivityEntranceMode.NewcomerSpecial, out displayUis);
		dictionary[ActivityEntranceMode.NewcomerSpecial] = value;
		dictionary2[ActivityEntranceMode.NewcomerSpecial] = displayUis;
		value = EntranceIsVisible(ActivityEntranceMode.NewForeignRewards, out displayUis);
		dictionary[ActivityEntranceMode.NewForeignRewards] = value;
		dictionary2[ActivityEntranceMode.NewForeignRewards] = displayUis;
		value = EntranceIsVisible(ActivityEntranceMode.NewForeignNewcomerSpecial, out displayUis);
		dictionary[ActivityEntranceMode.NewForeignNewcomerSpecial] = value;
		dictionary2[ActivityEntranceMode.NewForeignNewcomerSpecial] = displayUis;
		value = EntranceIsVisible(ActivityEntranceMode.SpinWeek, out displayUis);
		dictionary[ActivityEntranceMode.SpinWeek] = value;
		dictionary2[ActivityEntranceMode.SpinWeek] = displayUis;
		return new ActivityEntranceVisible
		{
			Visible = dictionary,
			OriginData = dictionary2
		};
	}

	private bool EntranceIsVisible(ActivityEntranceMode mode, out List<string> displayUis)
	{
		displayUis = new List<string>();
		foreach (string item in ActivityEntranceStatic.EntranceUis[mode])
		{
			if (_activitiesCompleted.TryGetValue(item, out var value) && !value)
			{
				displayUis.Add(item);
			}
			if (item == UI_com_SecretTreasury.Name && IsSecretTreasuryVisible())
			{
				displayUis.Add(item);
			}
			if (item == UI_com_SpinWeekSpin.Name && IsSpinWeekSpinVisible())
			{
				displayUis.Add(item);
			}
			if (item == UI_main_WeekActivityPass.Name && IsWeekActPassVisible())
			{
				displayUis.Add(item);
			}
			if (item == UI_com_ShadowDemonGift.Name && IsShadowDemonGiftVisible())
			{
				displayUis.Add(item);
			}
		}
		return displayUis.Count > 0;
	}

	private static Dictionary<string, bool> CheckActivitiesCompleted(List<Activity> activities)
	{
		Dictionary<string, bool> dictionary = new Dictionary<string, bool>(15);
		HashSet<string> allActivityUi = ActivityEntranceStatic.GetAllActivityUi();
		foreach (Activity activity in activities)
		{
			if (allActivityUi.Contains(activity.UiName))
			{
				dictionary[activity.UiName] = ((!dictionary.TryGetValue(activity.UiName, out var value)) ? activity.IsCompleted() : (value && activity.IsCompleted()));
			}
		}
		return SecondaryCheckActivitiesCompleted(dictionary);
	}

	private static Dictionary<string, bool> SecondaryCheckActivitiesCompleted(Dictionary<string, bool> firstChecked)
	{
		if (!firstChecked.ContainsKey(UI_main_DeparturePresent.Name))
		{
			firstChecked[UI_main_DeparturePresent.Name] = !UI_main_DeparturePresent.UiVisible();
		}
		if (!firstChecked.ContainsKey(UI_PatronPanel.Name))
		{
			firstChecked[UI_PatronPanel.Name] = !PatronPanelVisible();
		}
		if (!firstChecked.ContainsKey(UI_CertificationPanel.Name))
		{
			firstChecked[UI_CertificationPanel.Name] = !CertificationVisible();
		}
		return firstChecked;
		static bool CertificationVisible()
		{
			if (HotUpdateProcess.ChannelCode == "bilibili")
			{
				return false;
			}
			if (HotUpdateProcess.ChannelCode == "xipu")
			{
				return false;
			}
			User value = GameController.Contexts.gameState.user.value;
			return value.Verified != 4 && value.Verified != 5 && value.Verified != 2 && !HotUpdateProcess.Instance.IsRegionOutCN;
		}
		static bool PatronPanelVisible()
		{
			string value;
			return !GameController.Configs.TryGetValue("PatP", out value) || value != "0";
		}
	}

	public static bool IsSecretTreasuryVisible()
	{
		return FGUIManager.Instance.DynamicSecretTreasury != null && FGUIManager.Instance.DynamicSecretTreasury.IsEnable();
	}

	public static bool IsSpinWeekSpinVisible()
	{
		GetWeeklyActivityResponse spinWeekActivity = ActivityManager.SpinWeekActivity;
		if (spinWeekActivity == null || spinWeekActivity.ErrorCode != 0)
		{
			return false;
		}
		GetWeeklyActivityResponse.SpinWeekType activityType = spinWeekActivity.ActivityType;
		if (activityType == GetWeeklyActivityResponse.SpinWeekType.Empty)
		{
			return false;
		}
		long serverTime = GameController.Instance.GetServerTime();
		if (serverTime < spinWeekActivity.ActivityConfig.BeginTime || serverTime > spinWeekActivity.ActivityConfig.EndTime)
		{
			return false;
		}
		return true;
	}

	public static bool IsWeekActPassVisible()
	{
		List<Activity> weekActPasses = ActivityManager.WeekActPasses;
		if (weekActPasses != null && weekActPasses.Count > 0)
		{
			bool result = true;
			foreach (Activity item in weekActPasses)
			{
				if (item.GetStatus(GameManagers.Instance) != ActivityStatus.Enabled)
				{
					result = false;
					break;
				}
			}
			return result;
		}
		return false;
	}

	public static bool IsShadowDemonGiftVisible()
	{
		ShadowDemonGiftOpenInfo shadowDemonGiftOpenInfo = GetShadowDemonGiftOpenInfo();
		return shadowDemonGiftOpenInfo.IsOpen;
	}

	public static ShadowDemonGiftOpenInfo GetShadowDemonGiftOpenInfo()
	{
		ShadowDemonGiftOpenInfo shadowDemonGiftOpenInfo = new ShadowDemonGiftOpenInfo
		{
			IsOpen = false,
			EndTime = 0L
		};
		if (ActivityManager.ShadowDemonGift == null)
		{
			return shadowDemonGiftOpenInfo;
		}
		Activity shadowDemonGift = ActivityManager.ShadowDemonGift;
		shadowDemonGift.CheckStatus(GameManagers.Instance, out var newStatus, sendEvent: false);
		if (newStatus != ActivityStatus.Enabled)
		{
			return shadowDemonGiftOpenInfo;
		}
		ActivityConfig activityConfig = shadowDemonGift.ActivityProgress(GameManagers.Instance);
		shadowDemonGiftOpenInfo.IsOpen = true;
		shadowDemonGiftOpenInfo.EndTime = activityConfig.EndAt.ToUnixTimeSeconds();
		return shadowDemonGiftOpenInfo;
	}
}
