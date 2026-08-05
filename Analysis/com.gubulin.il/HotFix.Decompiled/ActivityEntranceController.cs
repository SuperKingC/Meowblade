using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using UnityEngine;

public class ActivityEntranceController : MonoBehaviour
{
	public static ActivityEntranceController Instance;

	public GameObject worker;

	public GameObject notise;

	public GameObject notise2;

	public GameObject bg;

	private List<string> activityId;

	private Dictionary<string, Activity> allActivities;

	public BoxCollider boxCollider;

	private void Awake()
	{
		Instance = this;
		notise = ((Component)((Component)this).transform.Find("notisebubble")).gameObject;
		notise2 = ((Component)((Component)this).transform.Find("notisebubble2")).gameObject;
		bg = ((Component)((Component)this).transform.Find("pic_maincity_springfestival")).gameObject;
		worker = ((Component)((Component)this).transform.Find("workerSpine")).gameObject;
		allActivities = new Dictionary<string, Activity>();
		((Component)this).gameObject.SetActive(false);
	}

	private void GetActivitiesNote()
	{
		bool flag = RankDataHelper.HasAnyInform();
		bool flag2 = SignInActivitiesHasAnyInform();
		bool flag3 = RechargeActivityHasAnyInform();
		bool flag4 = SecretTreasuryHasAnyInform();
		if (flag || flag2 || flag3 || flag4)
		{
			GameObject obj = notise;
			if (obj != null)
			{
				obj.SetActive(false);
			}
			GameObject obj2 = notise2;
			if (obj2 != null)
			{
				obj2.SetActive(true);
			}
		}
		else
		{
			GameObject obj3 = notise;
			if (obj3 != null)
			{
				obj3.SetActive(true);
			}
			GameObject obj4 = notise2;
			if (obj4 != null)
			{
				obj4.SetActive(false);
			}
		}
	}

	public async void UpdateNotise(Action onGetSuccess = null)
	{
		GetActivitiesNote();
		if (FGUIManager.Instance.LimitedTimeTotalRechargeCurrentActivity != null)
		{
			await FGUIManager.Instance.GetDynamicLimitedTimeTotalRecharge(delegate
			{
				GetActivitiesNote();
				onGetSuccess?.Invoke();
			}, mustUpdateData: true);
		}
	}

	private bool SignInActivitiesHasAnyInform()
	{
		if (FGUIManager.Instance.SimpleDynamicSigninActivities == null || FGUIManager.Instance.SimpleDynamicSigninActivities.Count <= 0)
		{
			return false;
		}
		for (int i = 0; i < FGUIManager.Instance.SimpleDynamicSigninActivities.Count; i++)
		{
			if (FGUIManager.Instance.SimpleDynamicSigninActivities[i].CanSignIn)
			{
				return true;
			}
		}
		return false;
	}

	private static bool SecretTreasuryHasAnyInform()
	{
		return FGUIManager.Instance.DynamicSecretTreasury?.HasAnyInform() ?? false;
	}

	private bool RechargeActivityHasAnyInform()
	{
		if (FGUIManager.Instance.LimitedTimeTotalRechargeCurrentActivity == null)
		{
			return false;
		}
		return FGUIManager.Instance.LimitedTimeTotalRechargeCurrentActivity.HasAnyInform();
	}

	private void GetActivityId()
	{
		if (GameController.Configs.TryGetValue("SpecialActivities", out var value))
		{
			activityId = value.Split(',').ToList();
		}
		if (activityId == null)
		{
			activityId = new List<string>();
		}
	}

	private void GetAllActivities()
	{
		if (allActivities.Count > 0)
		{
			return;
		}
		List<Activity> specialActivities = FGUIManager.Instance.GetSpecialActivities(new List<ActivityType> { ActivityType.HomePageActivity });
		for (int num = specialActivities.Count - 1; num >= 0; num--)
		{
			if (!activityId.Contains(specialActivities[num].ActivityId))
			{
				specialActivities.RemoveAt(num);
			}
		}
		for (int i = 0; i < specialActivities.Count; i++)
		{
			allActivities.Add(specialActivities[i].ActivityId, specialActivities[i]);
		}
	}

	public bool CanEnter()
	{
		bool flag = false;
		using (Dictionary<string, Activity>.Enumerator enumerator = allActivities.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				string item = enumerator.Current.Value.LevelCase?.First();
				flag = GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1001").Contains(item);
			}
		}
		if (!flag)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText13") + "1-20" + LanguagesManager.GetDesc("CsharpCodeZhTcText14") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
		return flag;
	}

	public async void ShowSpecialActivityEntrance()
	{
		if (GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1001").Contains("P120"))
		{
			await FGUIManager.Instance.GetSimpleDynamicPromotionActivity(null, mustUpdateData: true);
			await FGUIManager.Instance.GetSimpleDynamicSigninActivity(null);
			await FGUIManager.Instance.GetDynamicLimitedTimeTotalRecharge(null);
			await FGUIManager.Instance.GetSimpleDynamicCardPool(null);
			await FGUIManager.Instance.GetWorldBossActivities(null);
			await FGUIManager.Instance.GetIslandComeAgainActivities(null);
			await FGUIManager.Instance.GetPlayerReturnActivity(null);
			await FGUIManager.Instance.GetNeutralDungeonActivity(forceUpdate: true, getAdInfo: true);
			DateTimeOffset now = DateTimeHelper.ServerNow;
			if ((FGUIManager.Instance.SimpleDynamicPromotionActivities == null || FGUIManager.Instance.SimpleDynamicPromotionActivities.Count <= 0) && (FGUIManager.Instance.SimpleDynamicSigninActivities == null || FGUIManager.Instance.SimpleDynamicSigninActivities.Count <= 0) && (FGUIManager.Instance.SimpleDynamicCardPoolActivities == null || FGUIManager.Instance.SimpleDynamicCardPoolActivities.Count <= 0) && (FGUIManager.Instance.WorldBossActivities == null || FGUIManager.Instance.WorldBossActivities.Count <= 0) && (FGUIManager.Instance.IslandComeAgainActivities == null || FGUIManager.Instance.IslandComeAgainActivities.Count <= 0) && FGUIManager.Instance.LimitedTimeTotalRechargeCurrentActivity == null && (FGUIManager.Instance.NeutralDungeonData == null || FGUIManager.Instance.NeutralDungeonData.AdBeginTime.CompareTo(now) != -1 || FGUIManager.Instance.NeutralDungeonData.AdEndTime.CompareTo(now) != 1) && (FGUIManager.Instance.PlayerReturnActivity == null || !FGUIManager.Instance.PlayerReturnActivity.Activity.IsAvailable))
			{
				((Component)this).gameObject.SetActive(false);
				return;
			}
			UpdateNotise();
			((Component)this).gameObject.SetActive(true);
		}
	}

	private int GetCurServerTime()
	{
		return (int)GameController.Instance.GetServerTime();
	}

	public bool SpecialActivityEnable(List<DateTimeOffset> _beginTime, List<DateTimeOffset> _endTime)
	{
		int curServerTime = GetCurServerTime();
		bool result = false;
		for (int i = 0; i < _endTime.Count; i++)
		{
			long? num = _beginTime?[i].ToUnixTimeSeconds();
			long? num2 = _endTime?[i].ToUnixTimeSeconds();
			if (num < curServerTime && num2 > curServerTime)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public bool ShowSpecialActivityExpireTip(List<DateTimeOffset> _endTime)
	{
		int curServerTime = GetCurServerTime();
		bool result = false;
		for (int i = 0; i < _endTime.Count; i++)
		{
			long num = _endTime[i].ToUnixTimeSeconds();
			long num2 = curServerTime - num;
			if (curServerTime > num && num2 <= 259200)
			{
				result = true;
				break;
			}
		}
		return result;
	}
}
