using System;
using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class MissionSerialActivityPayload : ActivityContentPayload
{
	public readonly string PageName;

	private readonly HashSet<Mission> UnclaimedMissions = new HashSet<Mission>();

	private bool IsExtraBonusClaimable = false;

	private List<Mission> _missions = null;

	public readonly Dictionary<string, string> DisplayBonus;

	public readonly int DayNum;

	private readonly GDEMissionSerialData _data;

	private readonly Dictionary<string, object> _initData;

	private bool _isCacheDirty = true;

	public List<Mission> Missions(GameManagers managers)
	{
		if (_missions == null)
		{
			_missions = new List<Mission>();
			foreach (string mission in _data.Missions)
			{
				if (MissionManager.Missions.TryGetValue(mission, out var value))
				{
					value.ParentActivityPayload = this;
					_missions.Add(value);
				}
			}
		}
		PickupMissions(managers);
		return _missions;
	}

	private void PickupMissions(GameManagers managers)
	{
		ActivityStatus status = Activity.GetStatus(managers);
		foreach (Mission mission in _missions)
		{
			if (status == ActivityStatus.Enabled && mission.MissionState(managers).Status == MissionStatus.Pending)
			{
				mission.Pickup(managers);
			}
		}
	}

	public Mission SpecialMission(GameManagers managers)
	{
		if (_initData.TryGetValue("Special", out var value))
		{
			string key = value.ToString();
			if (!managers.MissionManager.PickedMissions.TryGetValue(key, out var value2))
			{
				value2 = MissionManager.Missions[key];
			}
			if (Activity.GetStatus(managers) == ActivityStatus.Enabled)
			{
				value2.Pickup(managers);
			}
			return value2;
		}
		return null;
	}

	public Dictionary<int, List<StoreItem>> ProgressBonus(GameManagers managers)
	{
		string key = "ProgressBonus:" + _data.Key;
		if (managers.CacheData.TryGetValue(key, out var value) && value is Dictionary<int, List<StoreItem>> result)
		{
			return result;
		}
		Dictionary<int, List<StoreItem>> dictionary = new Dictionary<int, List<StoreItem>>();
		if (!string.IsNullOrEmpty(_data.ProgressBonus))
		{
			Dictionary<int, List<string>> dictionary2 = JsonHelper.ToObject<Dictionary<int, List<string>>>(_data.ProgressBonus);
			foreach (KeyValuePair<int, List<string>> item2 in dictionary2)
			{
				int key2 = item2.Key;
				dictionary.Add(key2, new List<StoreItem>());
				foreach (string item3 in item2.Value)
				{
					StoreItem item = StoreItem.Get(managers, item3);
					dictionary[key2].Add(item);
				}
			}
		}
		managers.CacheData[key] = dictionary;
		return dictionary;
	}

	public int TotalCompletedMissions(GameManagers managers)
	{
		int num = 0;
		foreach (Mission item in Missions(managers))
		{
			if (item.MissionState(managers).Status == MissionStatus.Completed || item.MissionState(managers).Status == MissionStatus.Claimed)
			{
				num++;
			}
		}
		return num;
	}

	public MissionSerialActivityPayload(int payloadIndex, string pageName, Dictionary<string, object> data, Activity activity)
		: base(data)
	{
		if (!data.TryGetValue("MissionSerial", out var value))
		{
			return;
		}
		ContentIndex = payloadIndex;
		PageName = pageName;
		Activity = activity;
		_initData = data;
		_data = GDMgr.Get<GDEMissionSerialData>(value.ToString());
		if (_data != null)
		{
			if (!string.IsNullOrEmpty(_data.DisplayBonus))
			{
				DisplayBonus = JsonHelper.ToObject<Dictionary<string, string>>(_data.DisplayBonus);
			}
			else
			{
				DisplayBonus = new Dictionary<string, string>();
			}
			if (data.TryGetValue("Day", out var value2))
			{
				DayNum = Convert.ToInt32(value2);
			}
		}
	}

	public Dictionary<int, List<StoreItem>> GetAllBonusStoreItems(GameManagers managers)
	{
		Dictionary<int, List<StoreItem>> dictionary = new Dictionary<int, List<StoreItem>>();
		Dictionary<string, DateTimeOffset> activityLimitTimeMerchandise = managers.StoreManager.GetActivityLimitTimeMerchandise(Activity.ActivityId);
		foreach (KeyValuePair<int, List<StoreItem>> item in ProgressBonus(managers))
		{
			int key = item.Key;
			dictionary.Add(key, new List<StoreItem>());
			for (int i = 0; i < item.Value.Count; i++)
			{
				StoreItem storeItem = item.Value[i];
				while (dictionary[key].Find((StoreItem existedStoreItem) => existedStoreItem.StoreItemId == storeItem.StoreItemId) == null)
				{
					if (activityLimitTimeMerchandise.ContainsKey(storeItem.StoreItemId))
					{
						storeItem.ExpireAt = activityLimitTimeMerchandise[storeItem.StoreItemId];
						storeItem.ExpireTimestamp = DateTimeHelper.GetTimeStamp(storeItem.ExpireAt);
					}
					else if (storeItem.ValidTime > 0 && storeItem.IsPassedFilters && !storeItem.IsSoldOut && storeItem.IsKickedOff && !storeItem.IsExpired && !activityLimitTimeMerchandise.ContainsKey(storeItem.StoreItemId))
					{
						DateTimeOffset expireAt = DateTimeHelper.Now.AddSeconds(storeItem.ValidTime);
						storeItem.ExpireAt = expireAt;
						storeItem.ExpireTimestamp = DateTimeHelper.GetTimeStamp(storeItem.ExpireAt);
						managers.StoreManager.SetLimitTimeMerchandise(Activity.ActivityId, storeItem.StoreItemId, expireAt);
					}
					if ((storeItem.IsSoldOut || storeItem.IsExpired) && !string.IsNullOrEmpty(storeItem.Substitution))
					{
						storeItem = StoreItem.Get(managers, storeItem.Substitution);
						continue;
					}
					dictionary[key].Add(storeItem);
					break;
				}
			}
		}
		return dictionary;
	}

	public bool HasPendingBonus(GameManagers managers)
	{
		foreach (Mission item in Missions(managers))
		{
			if (item.MissionState(managers).Status == MissionStatus.Completed)
			{
				return true;
			}
		}
		int num = TotalCompletedMissions(managers);
		foreach (KeyValuePair<int, List<StoreItem>> allBonusStoreItem in GetAllBonusStoreItems(managers))
		{
			if (allBonusStoreItem.Key > num)
			{
				break;
			}
			foreach (StoreItem item2 in allBonusStoreItem.Value)
			{
				if (item2.IsFree && !item2.IsSoldOut && !item2.IsExpired && item2.IsKickedOff && item2.IsPassedFilters)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool AllBonusClaimed(GameManagers managers)
	{
		foreach (Mission item in Missions(managers))
		{
			if (item.MissionState(managers).Status != MissionStatus.Claimed)
			{
				return false;
			}
		}
		int num = TotalCompletedMissions(managers);
		foreach (KeyValuePair<int, List<StoreItem>> allBonusStoreItem in GetAllBonusStoreItems(managers))
		{
			if (allBonusStoreItem.Key > num)
			{
				break;
			}
			foreach (StoreItem item2 in allBonusStoreItem.Value)
			{
				if (!item2.IsSoldOut && !item2.IsExpired && item2.IsKickedOff && item2.IsPassedFilters)
				{
					return false;
				}
			}
		}
		return true;
	}

	public override void OnFinish(GameManagers managers)
	{
		base.OnFinish(managers);
		MissionManager missionManager = managers.MissionManager;
		Dictionary<string, Mission> pickedMissions = missionManager.PickedMissions;
		Dictionary<string, MissionConfig> value = missionManager.PickedMissionRecords.GetValue();
		foreach (Mission item in Missions(managers))
		{
			pickedMissions.Remove(item.Id);
			value.Remove(item.Id);
		}
		missionManager.PickedMissionRecords.Save();
	}

	public override void OnContentChanged(object content)
	{
		Mission item = (Mission)content;
		UnclaimedMissions.Remove(item);
	}

	public void FlushCache()
	{
		_isCacheDirty = true;
	}

	public override bool HasAnyNewMsg(GameManagers managers)
	{
		DateTimeOffset dateTimeOffset = Activity.CurBeginTime(managers, DateTimeHelper.Now);
		if (dateTimeOffset != default(DateTimeOffset))
		{
			dateTimeOffset -= DateTimeHelper.RefreshHours;
			DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
			if (DayNum > (dailyRefreshTime - dateTimeOffset).Days + 1)
			{
				return false;
			}
		}
		if (!_isCacheDirty)
		{
			return UnclaimedMissions.Count > 0 || IsExtraBonusClaimable;
		}
		_isCacheDirty = false;
		UnclaimedMissions.Clear();
		foreach (Mission item in Missions(managers))
		{
			if (item.MissionState(managers).Status == MissionStatus.Completed)
			{
				UnclaimedMissions.Add(item);
			}
		}
		IsExtraBonusClaimable = false;
		foreach (KeyValuePair<int, List<StoreItem>> allBonusStoreItem in GetAllBonusStoreItems(managers))
		{
			if (allBonusStoreItem.Key > TotalCompletedMissions(managers))
			{
				continue;
			}
			foreach (StoreItem item2 in allBonusStoreItem.Value)
			{
				if (!item2.IsSoldOut && item2.IsFree && !item2.IsExpired && item2.IsKickedOff && item2.IsPassedFilters)
				{
					IsExtraBonusClaimable = true;
					break;
				}
			}
		}
		return UnclaimedMissions.Count > 0 || IsExtraBonusClaimable;
	}
}
