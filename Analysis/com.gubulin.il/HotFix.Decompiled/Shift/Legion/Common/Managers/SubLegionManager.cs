using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Enums.Sources;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class SubLegionManager : Manager
{
	private const string SubLegionsKey = "SubLegions";

	private Config<Dictionary<SubLegionType, Dictionary<string, SubLegionConfig>>> _subLegions;

	public Config<Dictionary<SubLegionType, Dictionary<string, SubLegionConfig>>> SubLegions
	{
		get
		{
			if (_subLegions == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (userArchiveManager.Contains("SubLegions"))
				{
					_subLegions = userArchiveManager.GetConfig<Dictionary<SubLegionType, Dictionary<string, SubLegionConfig>>>("SubLegions");
				}
				else
				{
					userArchiveManager.SetConfigValue("SubLegions", new Dictionary<SubLegionType, Dictionary<string, SubLegionConfig>>());
					_subLegions = userArchiveManager.GetConfig<Dictionary<SubLegionType, Dictionary<string, SubLegionConfig>>>("SubLegions");
				}
			}
			return _subLegions;
		}
	}

	public SubLegionManager(GameManagers managers)
		: base(managers)
	{
	}

	public override Task Init()
	{
		AddEventListener();
		return null;
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<Activity>("ACTIVITY_RESET", OnActivityReset);
	}

	private void OnActivityReset(Activity activity)
	{
		if (activity.Type == ActivityType.TreasureHunt && SubLegions.GetValue().TryGetValue(SubLegionType.TreasureHunt, out var value) && value.TryGetValue(activity.ActivityId, out var value2))
		{
			RetreatSubLegion(value2);
		}
	}

	public SubLegionConfig GetSubLegion(SubLegionType type, string ctxId)
	{
		return null;
	}

	public bool SetSubLegion(SubLegionConfig subLegionConfig)
	{
		Dictionary<SubLegionType, Dictionary<string, SubLegionConfig>> value = SubLegions.GetValue();
		if (!value.TryGetValue(subLegionConfig.Type, out var value2))
		{
			value2 = new Dictionary<string, SubLegionConfig>();
			value.Add(subLegionConfig.Type, value2);
		}
		if (value2.ContainsKey(subLegionConfig.ContextId))
		{
			return false;
		}
		if (CanSetSubLegion(subLegionConfig))
		{
			subLegionConfig.ExpireAt = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddDays(1.0);
			value2.Add(subLegionConfig.ContextId, subLegionConfig);
			SubLegions.Save();
			return true;
		}
		return false;
	}

	public bool CanSetSubLegion(SubLegionConfig subLegionConfig)
	{
		if (subLegionConfig.Type == SubLegionType.TreasureHunt)
		{
			if (subLegionConfig.ExpireAt <= DateTimeHelper.Now)
			{
				return false;
			}
			if (subLegionConfig.SoldierStocks.Count > 15)
			{
				return false;
			}
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (KeyValuePair<string, int> soldierStock in subLegionConfig.SoldierStocks)
			{
				string key = soldierStock.Key;
				if (!dictionary.ContainsKey(key))
				{
					int soldierLevel = Managers.UserArchiveManager.GetSoldierLevel(key);
					int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(key, soldierLevel);
					dictionary.Add(key, soldierFormationNumber * 3);
				}
				int value = soldierStock.Value;
				if (dictionary[key] < value)
				{
					return false;
				}
				dictionary[key] -= value;
			}
		}
		return true;
	}

	public void UpdateSubLegion()
	{
	}

	public void IncreaseSubLegionStock()
	{
	}

	public void DecreaseSubLegionStock(SubLegionType type, string ctxId, string itemId, int qty)
	{
		if (qty > 0)
		{
			IncrStock(type, ctxId, itemId, -qty);
		}
	}

	private void IncrStock(SubLegionType type, string ctxId, string itemId, int qty)
	{
		Dictionary<SubLegionType, Dictionary<string, SubLegionConfig>> value = SubLegions.GetValue();
		if (!value.TryGetValue(type, out var value2) || !value2.TryGetValue(ctxId, out var value3))
		{
			return;
		}
		int num = qty;
		for (int num2 = value3.SoldierStocks.Count - 1; num2 >= 0; num2--)
		{
			KeyValuePair<string, int> keyValuePair = value3.SoldierStocks[num2];
			if (keyValuePair.Key == itemId)
			{
				if (num + keyValuePair.Value >= 0)
				{
					value3.SoldierStocks[num2] = new KeyValuePair<string, int>(itemId, num + keyValuePair.Value);
					break;
				}
				num += keyValuePair.Value;
				value3.SoldierStocks[num2] = new KeyValuePair<string, int>(itemId, 0);
			}
			if (Math.Abs(num) == 0)
			{
				break;
			}
		}
		SubLegions.Save();
	}

	public void RetreatSubLegion(SubLegionConfig subLegionConfig)
	{
		foreach (KeyValuePair<string, int> soldierStock in subLegionConfig.SoldierStocks)
		{
			string key = soldierStock.Key;
			int value = soldierStock.Value;
			Managers.StockController.IncrStock(key, value, StockInContext.SubLegionDispatch, subLegionConfig.ContextId);
		}
		SubLegions.GetValue()?[subLegionConfig.Type]?.Remove(subLegionConfig.ContextId);
		SubLegions.Save();
	}
}
