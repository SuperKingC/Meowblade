using System;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class StoreMissionActivityPayload : ActivityContentPayload
{
	public readonly string PageName;

	public readonly List<string> StoreItemsConfig;

	public readonly List<string> Missions;

	public readonly List<List<string>> MoreStoreItems;

	public StoreMissionActivityPayload(int payloadIndex, string pageName, Dictionary<string, object> data, Activity activity)
		: base(data)
	{
		ContentIndex = payloadIndex;
		PageName = pageName;
		StoreItemsConfig = new List<string>();
		MoreStoreItems = new List<List<string>>();
		Missions = new List<string>();
		Activity = activity;
		if (data.TryGetValue("StoreItems", out var value))
		{
			for (int i = 0; i < ((ArrayList)value).Count; i++)
			{
				StoreItemsConfig.Add((string)((ArrayList)value)[i]);
			}
		}
		if (data.TryGetValue("Missions", out var value2))
		{
			for (int j = 0; j < ((ArrayList)value2).Count; j++)
			{
				Missions.Add((string)((ArrayList)value2)[j]);
			}
		}
		if (data.TryGetValue("MoreStoreItems", out var value3))
		{
			ArrayList arrayList = (ArrayList)value3;
			for (int k = 0; k < arrayList.Count; k++)
			{
				object obj = arrayList[k];
				MoreStoreItems.Add(JsonHelper.ToObject<List<string>>(obj.ToJson()));
			}
		}
	}

	private void CheckIncludedMissions(GameManagers managers)
	{
		if (Missions == null || Missions.Count <= 0)
		{
			return;
		}
		ActivityStatus status = Activity.GetStatus(managers);
		foreach (string mission in Missions)
		{
			if (MissionManager.Missions.TryGetValue(mission, out var value) && status == ActivityStatus.Enabled)
			{
				value.Pickup(managers);
			}
		}
	}

	public Dictionary<string, StoreItem> StoreItems(GameManagers managers)
	{
		CheckIncludedMissions(managers);
		return GetStoreItems(managers);
	}

	private Dictionary<string, StoreItem> GetStoreItems(GameManagers managers)
	{
		Dictionary<string, StoreItem> dictionary = new Dictionary<string, StoreItem>();
		foreach (string item in StoreItemsConfig)
		{
			dictionary.Add(item, new StoreItem(managers, item)
			{
				IsDisableFilterForUI = true
			});
		}
		Dictionary<string, DateTimeOffset> activityLimitTimeMerchandise = managers.StoreManager.GetActivityLimitTimeMerchandise(Activity.ActivityId);
		foreach (KeyValuePair<string, DateTimeOffset> item2 in activityLimitTimeMerchandise)
		{
			string key = item2.Key;
			GDEStoreContentConfigData gDEStoreContentConfigData = GDMgr.Get<GDEStoreContentConfigData>(key);
			if (gDEStoreContentConfigData != null)
			{
				DateTimeOffset value = item2.Value;
				if (dictionary.TryGetValue(key, out var value2))
				{
					value2.ExpireAt = value;
					continue;
				}
				dictionary.Add(key, new StoreItem(managers, key)
				{
					ExpireAt = value
				});
			}
		}
		List<string> list = new List<string>();
		List<StoreItem> list2 = new List<StoreItem>();
		Dictionary<string, StoreItem> dictionary2 = new Dictionary<string, StoreItem>();
		foreach (KeyValuePair<string, StoreItem> item3 in dictionary)
		{
			StoreItem storeItem = item3.Value;
			while (!list.Contains(storeItem.StoreItemId))
			{
				bool isPassedFilters = storeItem.IsPassedFilters;
				bool isKickedOff = storeItem.IsKickedOff;
				bool isExpired = storeItem.IsExpired;
				bool isSoldOut = storeItem.IsSoldOut;
				if (!isPassedFilters || !isKickedOff || isExpired || isSoldOut)
				{
					if (storeItem.IsResident && isPassedFilters && isKickedOff && !isExpired)
					{
						list.Add(storeItem.StoreItemId);
						if (storeItem.ValidTime > 0)
						{
							dictionary2.Add(storeItem.StoreItemId, storeItem);
						}
						else
						{
							list2.Add(storeItem);
						}
					}
					if (!string.IsNullOrEmpty(storeItem.Substitution) && isSoldOut)
					{
						storeItem = new StoreItem(managers, storeItem.Substitution);
						continue;
					}
					break;
				}
				if (storeItem.ValidTime > 0)
				{
					if (!activityLimitTimeMerchandise.ContainsKey(storeItem.StoreItemId))
					{
						DateTimeOffset expireAt = (storeItem.ExpireAt = DateTimeHelper.Now.AddSeconds(storeItem.ValidTime));
						managers.StoreManager.SetLimitTimeMerchandise(Activity.ActivityId, storeItem.StoreItemId, expireAt);
					}
					dictionary2.Add(storeItem.StoreItemId, storeItem);
				}
				else
				{
					list2.Add(storeItem);
				}
				list.Add(storeItem.StoreItemId);
				break;
			}
		}
		Dictionary<string, StoreItem> dictionary3 = new Dictionary<string, StoreItem>();
		activityLimitTimeMerchandise = managers.StoreManager.GetActivityLimitTimeMerchandise(Activity.ActivityId);
		foreach (string key2 in activityLimitTimeMerchandise.Keys)
		{
			if (dictionary2.ContainsKey(key2))
			{
				dictionary3.Add(key2, dictionary2[key2]);
			}
		}
		foreach (StoreItem item4 in list2)
		{
			dictionary3.Add(item4.StoreItemId, item4);
		}
		return dictionary3;
	}

	public override bool HasAnyNewMsg(GameManagers managers)
	{
		NewMsgIncomingConfig value = managers.NewMsgIncomingManager.NewMsgIncomingRecords.GetValue();
		if (!value.LastCheckStoreItemList.ContainsKey(Activity.ActivityId) || !value.LastCheckStoreItemList[Activity.ActivityId].ContainsKey(PageName))
		{
			return true;
		}
		Dictionary<string, StoreItem> dictionary = StoreItems(managers);
		foreach (StoreItem value2 in dictionary.Values)
		{
			foreach (KeyValuePair<string, int> leaseholdItem in value2.LeaseholdItems)
			{
				if (managers.LeaseholdManager.CanClaimDailyBonus(leaseholdItem.Key))
				{
					return true;
				}
			}
			if (!value.LastCheckStoreItemList[Activity.ActivityId][PageName].Contains(value2.StoreItemId))
			{
				return true;
			}
		}
		return false;
	}
}
