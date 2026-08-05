using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using GameMaths;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_User
{
	private const string ExpKey = "USER_EXP";

	private const string LevelKey = "USER_LEVEL";

	private const string InvitingSlotsKey = "InvitingSlots";

	private const string InvitedFromKey = "InvitedFrom";

	private const string FriendsLimitKey = "FriendsLimit";

	private const string OfflineYieldTimeLimitKey = "OFFLINE_YIELD_TIME_LIMIT";

	private const string OfflineYieldTimeOffsetKey = "OFFLINE_YIELD_TIME_OFFSET";

	public const string OfflineSecondsKey = "OFFLINE_SECONDS";

	public const string DailyLoginStatsKey = "DailyLoginStats";

	public const string DailyAtCreateAccount = "DailyAtCreateAccount";

	private const string GvGShipPlanSoldierStockChangeInfoKey = "GvGShipPlanSoldierStockChangeInfo";

	private const string GvGSoldierStockLimitIncreaseKey = "GvGSoldierStockLimitIncrease";

	public static int GetGvGShipPlanSoldiersStockLimitOccupiedValue(this UserArchiveManager manager)
	{
		GvGShipPlanSoldierStockChangeInfo gvGShipPlanSoldierStockChangeInfo = manager.GetGvGShipPlanSoldierStockChangeInfo();
		List<int> values = gvGShipPlanSoldierStockChangeInfo.Info.Values.ToList();
		return GetMin();
		int GetMin()
		{
			if (values.Count <= 0)
			{
				return 0;
			}
			int num = values[0];
			foreach (int item in values)
			{
				if (item < num)
				{
					num = item;
				}
			}
			return num;
		}
	}

	public static void ClearPeriodSoldiersLimitOccupied(this UserArchiveManager manager, List<string> occupied)
	{
		if (occupied == null)
		{
			return;
		}
		GvGShipPlanSoldierStockChangeInfo gvGShipPlanSoldierStockChangeInfo = manager.GetGvGShipPlanSoldierStockChangeInfo();
		HashSet<string> hashSet = new HashSet<string>();
		foreach (KeyValuePair<string, int> item in gvGShipPlanSoldierStockChangeInfo.Info)
		{
			if (item.Value != 0 && !occupied.Contains(item.Key))
			{
				hashSet.Add(item.Key);
			}
		}
		foreach (string item2 in hashSet)
		{
			gvGShipPlanSoldierStockChangeInfo.Info[item2] = 0;
		}
		manager.SetGvGShipPlanSoldierStockChangeInfo(gvGShipPlanSoldierStockChangeInfo);
	}

	public static void ClearGvGShipPlanSoldierStockChangeInfos(this UserArchiveManager manager)
	{
		GvGShipPlanSoldierStockChangeInfo gvGShipPlanSoldierStockChangeInfo = manager.GetGvGShipPlanSoldierStockChangeInfo();
		gvGShipPlanSoldierStockChangeInfo.Info.Clear();
		manager.SetGvGShipPlanSoldierStockChangeInfo(gvGShipPlanSoldierStockChangeInfo);
	}

	public static void SetGvGShipPlanSoldierStockChangeInfo(this UserArchiveManager manager, string soldierId, int occupiedLimit)
	{
		GvGShipPlanSoldierStockChangeInfo gvGShipPlanSoldierStockChangeInfo = manager.GetGvGShipPlanSoldierStockChangeInfo();
		gvGShipPlanSoldierStockChangeInfo.Info[soldierId] = occupiedLimit;
		manager.SetGvGShipPlanSoldierStockChangeInfo(gvGShipPlanSoldierStockChangeInfo);
	}

	public static void ClearGvGShipPlanSoldierStockChangeInfo(this UserArchiveManager manager, string soldierId)
	{
		GvGShipPlanSoldierStockChangeInfo gvGShipPlanSoldierStockChangeInfo = manager.GetGvGShipPlanSoldierStockChangeInfo();
		gvGShipPlanSoldierStockChangeInfo.Info[soldierId] = 0;
		manager.SetGvGShipPlanSoldierStockChangeInfo(gvGShipPlanSoldierStockChangeInfo);
	}

	private static GvGShipPlanSoldierStockChangeInfo GetGvGShipPlanSoldierStockChangeInfo(this UserArchiveManager manager)
	{
		if (!manager.TryGetConfigValue<GvGShipPlanSoldierStockChangeInfo>("GvGShipPlanSoldierStockChangeInfo", out var val))
		{
			val = new GvGShipPlanSoldierStockChangeInfo
			{
				Info = new Dictionary<string, int>()
			};
			manager.SetGvGShipPlanSoldierStockChangeInfo(val);
		}
		return val;
	}

	private static void SetGvGShipPlanSoldierStockChangeInfo(this UserArchiveManager manager, GvGShipPlanSoldierStockChangeInfo data)
	{
		manager.SetConfigValue("GvGShipPlanSoldierStockChangeInfo", data);
	}

	public static GvGSoldierStockLimitIncrease GetGvGSoldierStockLimit战时扩编Increment(this UserArchiveManager manager)
	{
		if (!manager.TryGetConfigValue<GvGSoldierStockLimitIncrease>("GvGSoldierStockLimitIncrease", out var val))
		{
			val = new GvGSoldierStockLimitIncrease
			{
				LimitIncrease = 0
			};
			manager.SetGvGSoldierStockLimitIncrement(val);
		}
		return val;
	}

	public static void SetGvGSoldierStockLimitIncrement(this UserArchiveManager manager, GvGSoldierStockLimitIncrease data)
	{
		manager.SetConfigValue("GvGSoldierStockLimitIncrease", data);
	}

	public static void SetDailyLoginStats(this UserArchiveManager manager, int loginCnt)
	{
		manager.SetConfigValue("DailyLoginStats", loginCnt);
	}

	public static int GetDailyLoginStats(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<int>("DailyLoginStats");
	}

	public static int GetUserLevel(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<int>("USER_LEVEL");
	}

	public static int GetInvitingSlots(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<int>("InvitingSlots");
	}

	public static int GetInvitedFrom(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<int>("InvitedFrom");
	}

	public static int GetFriendsLimit(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<int>("FriendsLimit");
	}

	internal static void SetUserLevel(this UserArchiveManager manager, int value)
	{
		manager.SetConfigValue("USER_LEVEL", value);
	}

	public static int GetUserExp(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<int>("USER_EXP");
	}

	private static void SetUserExp(this UserArchiveManager manager, int value)
	{
		manager.SetConfigValue("USER_EXP", value);
	}

	public static void SetInvitingSlots(this UserArchiveManager manager, int slots)
	{
		manager.SetConfigValue("InvitingSlots", slots);
	}

	public static void SetInvitedFrom(this UserArchiveManager manager, int userId)
	{
		manager.SetConfigValue("InvitedFrom", userId);
	}

	public static void SetFriendsLimit(this UserArchiveManager manager, int limit)
	{
		manager.SetConfigValue("FriendsLimit", limit);
	}

	public static Action UserGainExp(this UserArchiveManager manager, int exp, bool broadcastInform = true)
	{
		exp = Mathf.RoundToInt((float)exp * (1f + manager.Managers.ModifierManager.GetPercentFloatPayload("UserExpGain")));
		int num = manager.GetUserExp() + exp;
		manager.SetUserExp(num);
		Action action = delegate
		{
			manager.Managers.Messenger.Broadcast("USER_GAIN_EXP", exp);
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("{0}+{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText812"), exp) }, 121, arg3: false);
		};
		if (broadcastInform)
		{
			action();
		}
		int userLevel = manager.GetUserLevel();
		int num2 = userLevel;
		while (num >= manager.Managers.ConfigDataManager.GetUserNextLevelExp())
		{
			num2 = manager.GetUserLevel() + 1;
			manager.SetUserLevel(num2);
			UserExpData.LevelUpTo(manager.Managers, num2);
		}
		if (num2 > userLevel)
		{
			GameManagers.Instance.ConfigDataManager.CheckUserEvoData();
			manager.Managers.Messenger.Broadcast("USER_LEVEL_UP", num2);
		}
		return action;
	}

	public static float GetOfflineYieldTimeLimit(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<float>("OFFLINE_YIELD_TIME_LIMIT");
	}

	public static void SetOfflineYieldTimeLimit(this UserArchiveManager manager, float hours)
	{
		manager.SetConfigValue("OFFLINE_YIELD_TIME_LIMIT", hours);
	}

	public static int GetOfflineYieldTimeOffset(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<int>("OFFLINE_YIELD_TIME_OFFSET");
	}

	public static int GetOfflineSeconds(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<int>("OFFLINE_SECONDS");
	}

	public static int GetDailyAtCreateAccount(this UserArchiveManager manager)
	{
		if (!manager.TryGetConfigValue<int>("DailyAtCreateAccount", out var val))
		{
			val = 0;
			manager.SetDailyAtCreateAccount(val);
		}
		return val;
	}

	public static void SetDailyAtCreateAccount(this UserArchiveManager manager, int stamp)
	{
		manager.SetConfigValue("DailyAtCreateAccount", stamp);
	}
}
