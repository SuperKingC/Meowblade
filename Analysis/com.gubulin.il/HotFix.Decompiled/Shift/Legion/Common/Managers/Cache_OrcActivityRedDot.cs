using System.Collections;
using System.Collections.Generic;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class Cache_OrcActivityRedDot : CacheBaseBehavior
{
	public static string ON_REDDOT_CHANGE = typeof(Cache_OrcActivityRedDot).Name;

	public static string ON_PAGE_REDDOT_CHANGE = typeof(Cache_OrcActivityRedDot).Name + "Page";

	private Dictionary<string, List<Mission>> PageMissions;

	private Dictionary<string, List<StoreItem>> PageStoreItems;

	private Dictionary<string, bool> PageRedDots;

	private Dictionary<string, bool> PageClaimed;

	private Dictionary<string, bool> MissionDic;

	private bool _IsShowRedDot;

	private bool _IsActivityInit;

	public bool IsShowRedDot
	{
		get
		{
			return _IsShowRedDot;
		}
		set
		{
			if (value != _IsShowRedDot)
			{
				_IsShowRedDot = value;
				SharedMessenger.Broadcast(ON_REDDOT_CHANGE, this);
			}
		}
	}

	public override IEnumerator Init()
	{
		PageMissions = new Dictionary<string, List<Mission>>();
		PageStoreItems = new Dictionary<string, List<StoreItem>>();
		MissionDic = new Dictionary<string, bool>();
		PageRedDots = new Dictionary<string, bool>();
		PageClaimed = new Dictionary<string, bool>();
		base.DelayUpdateFromNow = 2f;
		TimeInterval = 2f;
		_IsShowRedDot = false;
		_IsActivityInit = false;
		yield return null;
		Activity activity = ActivityManager.Activities["OrcTaskActivity"];
		if (activity.GetStatus(GameManagers.Instance) != ActivityStatus.Enabled)
		{
			yield break;
		}
		_IsActivityInit = true;
		foreach (KeyValuePair<string, ActivityContentPayload> item in activity.ContentPayload(GameManagers.Instance))
		{
			StoreMissionActivityPayload payload = (StoreMissionActivityPayload)item.Value;
			List<Mission> missionList = new List<Mission>();
			List<StoreItem> storeItemList = new List<StoreItem>();
			foreach (string mid in payload.Missions)
			{
				MissionManager.Missions.TryGetValue(mid, out var mission);
				if (mission != null)
				{
					missionList.Add(mission);
					MissionDic.Add(mid, value: true);
				}
				mission = null;
			}
			storeItemList.AddRange(payload.StoreItems(GameManagers.Instance).Values);
			PageMissions.Add(item.Key, missionList);
			PageStoreItems.Add(item.Key, storeItemList);
			PageRedDots.Add(item.Key, value: false);
			PageClaimed.Add(item.Key, value: false);
			yield return null;
		}
	}

	public override void DeferredUpdate()
	{
		bool isShowRedDot = false;
		bool flag = false;
		foreach (KeyValuePair<string, List<Mission>> pageMission in PageMissions)
		{
			bool flag2 = false;
			bool flag3 = true;
			foreach (Mission item in pageMission.Value)
			{
				MissionStatus status = item.MissionState(GameManagers.Instance).Status;
				if (status != MissionStatus.Claimed)
				{
					flag3 = false;
					if (status == MissionStatus.Completed)
					{
						isShowRedDot = true;
						flag2 = true;
						break;
					}
				}
			}
			if (flag3)
			{
				List<StoreItem> list = PageStoreItems[pageMission.Key];
				foreach (StoreItem item2 in list)
				{
					int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(item2.StoreItemId);
					int num = item2.PurchaseLimit - purchaseCntAtLimitPeriod;
					if (num > 0)
					{
						flag3 = false;
					}
				}
			}
			if (PageRedDots[pageMission.Key] != flag2 || PageClaimed[pageMission.Key] != flag3)
			{
				PageRedDots[pageMission.Key] = flag2;
				PageClaimed[pageMission.Key] = flag3;
				flag = true;
			}
		}
		IsShowRedDot = isShowRedDot;
		IsUpdateEnabled = false;
		if (flag)
		{
			SharedMessenger.Broadcast(ON_PAGE_REDDOT_CHANGE, this);
		}
	}

	public override void OnAllCachesInit()
	{
		SharedMessenger.AddListener<Mission>("MISSION_COMPLETE", OnMissionChanged);
		SharedMessenger.AddListener<Mission>("MISSION_CLAIMED", OnMissionChanged);
		SharedMessenger.AddListener<Level>("LEVEL_BONUS_CLAIMED", OnLevelBonusClaimed);
	}

	private void OnLevelBonusClaimed(Level level)
	{
		if (_IsActivityInit)
		{
			return;
		}
		Activity activity = ActivityManager.Activities["OrcTaskActivity"];
		if (activity.LevelCase == null || !activity.LevelCase.Contains(level.LevelId) || activity.GetStatus(GameManagers.Instance) != ActivityStatus.Enabled)
		{
			return;
		}
		_IsActivityInit = true;
		foreach (KeyValuePair<string, ActivityContentPayload> item in activity.ContentPayload(GameManagers.Instance))
		{
			StoreMissionActivityPayload storeMissionActivityPayload = (StoreMissionActivityPayload)item.Value;
			List<Mission> list = new List<Mission>();
			List<StoreItem> list2 = new List<StoreItem>();
			foreach (string mission in storeMissionActivityPayload.Missions)
			{
				MissionManager.Missions.TryGetValue(mission, out var value);
				if (value != null)
				{
					list.Add(value);
					MissionDic.Add(mission, value: true);
				}
			}
			list2.AddRange(storeMissionActivityPayload.StoreItems(GameManagers.Instance).Values);
			PageMissions.Add(item.Key, list);
			PageStoreItems.Add(item.Key, list2);
			PageRedDots.Add(item.Key, value: false);
			PageClaimed.Add(item.Key, value: false);
		}
	}

	private void OnMissionChanged(Mission mission)
	{
		if (MissionDic.ContainsKey(mission.Id))
		{
			IsUpdateEnabled = true;
			base.DelayUpdateFromNow = 0.5f;
		}
	}

	public bool HasPageRedDot(string pageName)
	{
		if (PageRedDots.TryGetValue(pageName, out var value))
		{
			return value;
		}
		return false;
	}

	public bool IsPageClaimed(string pageName)
	{
		if (PageClaimed.TryGetValue(pageName, out var value))
		{
			return value;
		}
		return false;
	}

	public void SetPageClaimState(string pageName, bool state)
	{
		if (PageClaimed.ContainsKey(pageName))
		{
			PageClaimed[pageName] = state;
		}
	}
}
