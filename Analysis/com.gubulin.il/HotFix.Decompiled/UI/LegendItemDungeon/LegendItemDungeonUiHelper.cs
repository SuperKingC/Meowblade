using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using GameDataEditor;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

namespace UI.LegendItemDungeon;

public static class LegendItemDungeonUiHelper
{
	private static List<TreasureHuntLevelInfo> _levels = new List<TreasureHuntLevelInfo>();

	public static Dictionary<string, List<TreasureHuntLevelInfo>> LegendItemDungeonLevels = new Dictionary<string, List<TreasureHuntLevelInfo>>();

	public static Dictionary<string, string> FloorName = new Dictionary<string, string>();

	public static Dictionary<string, int> LegendItemDungeonLevelStatus = new Dictionary<string, int>();

	public static Dictionary<string, int> SoldierNumLimit = new Dictionary<string, int>();

	public const string BossLevelKey = "BOSS";

	public const string InitLevelKey = "InitLevel";

	private const int SoldierNumMultiple = 3;

	private static Activity activity;

	public static int MaxLegionSize;

	public static string BossLevelId;

	public static string DetectorSkinName;

	public static Dictionary<string, int> BonusStats = new Dictionary<string, int>();

	public static string CurLevelId;

	public static int ExpireAt;

	public static int MaxDifficult;

	public static List<KeyValuePair<string, int>> CurSoldiers = new List<KeyValuePair<string, int>>();

	public static int ScoreToBoss;

	public static int CurFinishedLevelNum = -1;

	private static string InitFloorName => LanguagesManager.GetDesc("CsharpCodeZhTcText0");

	public static void OpenLegendItemDungeonPanel(Action action)
	{
		if (_levels.Count <= 0 || CurSoldiers.Count <= 0 || !string.IsNullOrWhiteSpace(CurLevelId) || BonusStats.Count <= 0 || MaxLegionSize <= 0)
		{
			ILRequestHelper<GetTreasureHuntActivityProgressResponse>.Request((EventContext)null, (Func<Task<GetTreasureHuntActivityProgressResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetTreasureHuntActivityProgress()), (Action<GetTreasureHuntActivityProgressResponse>)delegate(GetTreasureHuntActivityProgressResponse response)
			{
				if (response != null)
				{
					if (!response.Result)
					{
						ILRequestHelper.ShowErrorCode(response.ErrorCode);
					}
					else
					{
						GetLegendItemDungeonData(response.Soldiers, response.LevelsStatus, response.BossLevelsStatus, response.ScoreToBoss, response.ExpireAt, response.MaxDifficulty, response.BonusStats, response.MaxLegionSize);
						action();
					}
				}
			});
		}
		else
		{
			action();
		}
	}

	public static void GetTreasureHuntActivityProgress(GetTreasureHuntActivityProgressResponse _activityProgressResponse)
	{
		GetLegendItemDungeonData(_activityProgressResponse.Soldiers, _activityProgressResponse.LevelsStatus, _activityProgressResponse.BossLevelsStatus, _activityProgressResponse.ScoreToBoss, _activityProgressResponse.ExpireAt, _activityProgressResponse.MaxDifficulty, _activityProgressResponse.BonusStats, _activityProgressResponse.MaxLegionSize);
		GameManagers.Instance.StockController.NeedGetAllProduceStatus = true;
	}

	public static void AssignSubLegion(Action action, List<KeyValuePair<string, int>> selectedSoldiers)
	{
		ILRequestHelper<AssignSoldierToTreasureHuntActivityResponse>.Request((EventContext)null, (Func<Task<AssignSoldierToTreasureHuntActivityResponse>>)(() => GameController.Contexts.Service<INetworkService>().AssignSoldierToTreasureHuntActivity(selectedSoldiers)), (Action<AssignSoldierToTreasureHuntActivityResponse>)delegate(AssignSoldierToTreasureHuntActivityResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				CurSoldiers = selectedSoldiers;
				if (CurSoldiers != null)
				{
					List<string> list = new List<string>();
					for (int i = 0; i < CurSoldiers.Count; i++)
					{
						list.Add(CurSoldiers[i].Key);
					}
					GameLocalDataManager.SetLegendExplorationSoldiers(list);
				}
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				action();
			}
		});
	}

	public static int GetSoldierCurNum(string soldierId)
	{
		if (CurSoldiers == null || CurSoldiers.Count <= 0)
		{
			return 0;
		}
		int result = 0;
		for (int i = 0; i < CurSoldiers.Count; i++)
		{
			if (CurSoldiers[i].Key == soldierId)
			{
				result = CurSoldiers[i].Value;
				break;
			}
		}
		return result;
	}

	public static string GetFloorKey(int floorIndex)
	{
		string text = "";
		if (floorIndex == 0)
		{
			return "InitLevel";
		}
		if (floorIndex == LegendItemDungeonLevels.Count - 1)
		{
			return "BOSS";
		}
		return $"{floorIndex}";
	}

	public static string GetFloorName(int floorIndex)
	{
		string floorKey = GetFloorKey(floorIndex);
		return string.IsNullOrWhiteSpace(FloorName[floorKey]) ? $"{floorIndex}" : FloorName[floorKey];
	}

	private static int GetSoldierNumLimit(string soldierId)
	{
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
		return Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldierId, soldier.Level) * 3;
	}

	public static int GetSoldierLimitNum(string soldierId)
	{
		return GetSoldierNumLimit(soldierId);
	}

	public static int GetSoldierNum(string soldierId)
	{
		int soldierLimitNum = GetSoldierLimitNum(soldierId);
		int stock = GameManagers.Instance.StockController.GetStock(soldierId);
		return (stock > soldierLimitNum) ? soldierLimitNum : stock;
	}

	private static Level GetDungeonLevel(TreasureHuntLevelInfo treasureHuntLevelInfo)
	{
		GDELevelData data = GDMgr.Get<GDELevelData>(treasureHuntLevelInfo.LevelId);
		Level level = new Level(data)
		{
			EnemyTemplate = treasureHuntLevelInfo.EnemyTemplate
		};
		level.FromUi = UI_LegendItemDungeonPanel.Name;
		level.FromUiParams = new Dictionary<string, object> { { "Activity", activity } };
		LegendItemDungeonLevelStatus.Add(treasureHuntLevelInfo.LevelId, treasureHuntLevelInfo.Status);
		return level;
	}

	public static Level GetDungeonLevelForUi(TreasureHuntLevelInfo treasureHuntLevelInfo)
	{
		GDELevelData data = GDMgr.Get<GDELevelData>(treasureHuntLevelInfo.LevelId);
		Level level = new Level(data)
		{
			EnemyTemplate = treasureHuntLevelInfo.EnemyTemplate
		};
		level.FromUi = UI_LegendItemDungeonPanel.Name;
		level.FromUiParams = new Dictionary<string, object> { { "Activity", activity } };
		return level;
	}

	public static void ClearDungeonData()
	{
		activity = null;
		_levels?.Clear();
		CurSoldiers?.Clear();
		BonusStats?.Clear();
		CurLevelId = null;
		MaxLegionSize = 0;
		LegendItemDungeonLevelStatus?.Clear();
		LegendItemDungeonLevels?.Clear();
		FloorName?.Clear();
		SoldierNumLimit?.Clear();
	}

	private static void GetLegendItemDungeonData(List<KeyValuePair<string, int>> curSoldiers, List<TreasureHuntLevelInfo> levelsStatus, List<TreasureHuntLevelInfo> bossLevelsInfo, int scoreToBoss, int expireAt, int maxDifficult, Dictionary<string, int> bonusStats, int maxLegionSize)
	{
		if (activity == null)
		{
			activity = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.TreasureHunt)?.First();
		}
		_levels.Clear();
		LegendItemDungeonLevelStatus.Clear();
		if (levelsStatus != null)
		{
			for (int i = 0; i < levelsStatus.Count; i++)
			{
				_levels.Add(levelsStatus[i]);
				LegendItemDungeonLevelStatus.Add(levelsStatus[i].LevelId, levelsStatus[i].Status);
			}
		}
		bool flag = false;
		List<TreasureHuntLevelInfo> list = new List<TreasureHuntLevelInfo>();
		if (bossLevelsInfo != null)
		{
			for (int j = 0; j < bossLevelsInfo.Count; j++)
			{
				TreasureHuntLevelInfo treasureHuntLevelInfo = bossLevelsInfo[j];
				list.Add(treasureHuntLevelInfo);
				LegendItemDungeonLevelStatus.Add(treasureHuntLevelInfo.LevelId, treasureHuntLevelInfo.Status);
				if (treasureHuntLevelInfo.Status == 2)
				{
					flag = true;
				}
			}
		}
		LegendItemDungeonLevels.Clear();
		LegendItemDungeonLevels.Add("InitLevel", null);
		for (int k = 0; k < _levels.Count; k++)
		{
			string dungeonLevelDifficultText = GetDungeonLevelDifficultText(_levels[k].LevelId);
			if (LegendItemDungeonLevels.ContainsKey(dungeonLevelDifficultText))
			{
				LegendItemDungeonLevels[dungeonLevelDifficultText].Add(_levels[k]);
				continue;
			}
			LegendItemDungeonLevels.Add(dungeonLevelDifficultText, new List<TreasureHuntLevelInfo> { _levels[k] });
		}
		if (list.Count <= 0)
		{
			list.Add(_levels[0]);
			LegendItemDungeonLevels["BOSS"] = list;
		}
		else
		{
			LegendItemDungeonLevels["BOSS"] = list;
		}
		BossLevelId = LegendItemDungeonLevels["BOSS"]?[0]?.LevelId;
		FloorName.Clear();
		int num = 0;
		foreach (KeyValuePair<string, List<TreasureHuntLevelInfo>> legendItemDungeonLevel in LegendItemDungeonLevels)
		{
			string text = "";
			text = ((num != 0) ? GetFloorName(legendItemDungeonLevel.Value.First().LevelId) : InitFloorName);
			FloorName.Add(legendItemDungeonLevel.Key, text);
			num++;
		}
		if (curSoldiers == null)
		{
			CurSoldiers.Clear();
		}
		else
		{
			CurSoldiers = curSoldiers;
		}
		if (bonusStats == null)
		{
			BonusStats.Clear();
		}
		else
		{
			BonusStats = bonusStats;
		}
		ScoreToBoss = scoreToBoss;
		MaxDifficult = maxDifficult + 1;
		ExpireAt = expireAt;
		MaxLegionSize = maxLegionSize;
		SetCurFinishedLevelNum();
		if (string.IsNullOrWhiteSpace(CurLevelId))
		{
			return;
		}
		List<TreasureHuntLevelInfo> list2 = new List<TreasureHuntLevelInfo>();
		list2.AddRange(bossLevelsInfo);
		list2.AddRange(levelsStatus);
		for (int l = 0; l < list2.Count; l++)
		{
			if (list2[l].LevelId == CurLevelId)
			{
				LegendItemDungeonLevelStatus[CurLevelId] = list2[l].Status;
				break;
			}
		}
	}

	private static string GetFloorName(string levelId)
	{
		if (string.IsNullOrEmpty(levelId))
		{
			return "";
		}
		if (levelId.Contains("TreasureHuntBoss"))
		{
			return LanguagesManager.GetDesc("CsharpCodeZhTcText1");
		}
		return GetDungeonLevelDifficult(levelId) switch
		{
			1 => LanguagesManager.GetDesc("CsharpCodeZhTcText2"), 
			2 => LanguagesManager.GetDesc("CsharpCodeZhTcText3"), 
			3 => LanguagesManager.GetDesc("CsharpCodeZhTcText4"), 
			4 => LanguagesManager.GetDesc("CsharpCodeZhTcText5"), 
			5 => LanguagesManager.GetDesc("CsharpCodeZhTcText6"), 
			6 => LanguagesManager.GetDesc("CsharpCodeZhTcText7"), 
			7 => LanguagesManager.GetDesc("CsharpCodeZhTcText8"), 
			8 => LanguagesManager.GetDesc("CsharpCodeZhTcText9"), 
			9 => LanguagesManager.GetDesc("TreasureFloor9"), 
			10 => LanguagesManager.GetDesc("TreasureFloor10"), 
			_ => LanguagesManager.GetDesc("CsharpCodeZhTcText10"), 
		};
	}

	private static int GetDungeonLevelDifficult(string levelId)
	{
		if (string.IsNullOrEmpty(levelId))
		{
			return 0;
		}
		GDELevelData gDELevelData = GDMgr.Get<GDELevelData>(levelId);
		return gDELevelData.Difficult;
	}

	private static string GetDungeonLevelDifficultText(string levelId)
	{
		if (string.IsNullOrEmpty(levelId))
		{
			return "";
		}
		GDELevelData gDELevelData = GDMgr.Get<GDELevelData>(levelId);
		return gDELevelData.Difficult.ToString();
	}

	public static string GetCurFloorMapIconUrl(string floorName)
	{
		if (floorName == "InitLevel")
		{
			return "ui://LegendItemDungeon/pic_quest_treasure_map_1";
		}
		if (floorName == "BOSS")
		{
			return "ui://LegendItemDungeon/pic_quest_treasure_map_3";
		}
		return "ui://LegendItemDungeon/pic_quest_treasure_map_2";
	}

	public static string GetCountDownTimeText()
	{
		if (ExpireAt == 0)
		{
			return "XX" + LanguagesManager.GetDesc("CsharpCodeZhTcText11") + "XX" + LanguagesManager.GetDesc("CsharpCodeZhTcText12");
		}
		DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp(ExpireAt);
		TimeSpan timeSpan = dateTimeOffset - DateTimeHelper.Now;
		return string.Format("{0}{1}{2}{3}", timeSpan.Hours, LanguagesManager.GetDesc("CsharpCodeZhTcText11"), timeSpan.Minutes, LanguagesManager.GetDesc("CsharpCodeZhTcText12"));
	}

	private static void SetCurFinishedLevelNum()
	{
		if (_levels.Count <= 0)
		{
			return;
		}
		CurFinishedLevelNum = 0;
		for (int i = 0; i < _levels.Count; i++)
		{
			if (LegendItemDungeonLevelStatus.TryGetValue(_levels[i].LevelId, out var value) && value == 2)
			{
				CurFinishedLevelNum++;
			}
		}
	}

	public static void SaveCurFloor(int _index)
	{
		GameLocalDataManager.SetLastLegendExplorationFloorIndex(_index);
	}

	public static int GetLastFloorIndex(bool enable)
	{
		int num = GameLocalDataManager.GetLastLegendExplorationIndex();
		if (num <= 0)
		{
			num = 1;
			GameLocalDataManager.SetLastLegendExplorationFloorIndex(num);
		}
		int num2 = LegendItemDungeonLevels.Count - 1;
		if (enable)
		{
			return num2;
		}
		if (CurFinishedLevelNum >= ScoreToBoss)
		{
			return (num2 < num) ? num2 : num;
		}
		return (MaxDifficult < num) ? MaxDifficult : num;
	}

	public static float SetLastLevelOffsetX(int floorIndex, float leftLimit, float rightLimit, float curX)
	{
		float num = GameLocalDataManager.GetLastLegendExplorationLevelOffsetX();
		if (floorIndex == 0 || floorIndex == UI_LegendItemDungeonPanel.LegendItemDungeonLevels.Count - 1)
		{
			num = curX;
		}
		else if (num < rightLimit)
		{
			num = rightLimit;
		}
		else if (num > leftLimit)
		{
			num = leftLimit;
		}
		return num;
	}

	public static string GetCurAvailableTickets()
	{
		List<TreasureHuntLevelInfo> list = LegendItemDungeonLevels["BOSS"];
		int count = list.Count;
		int num = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (LegendItemDungeonLevelStatus[list[i].LevelId] != 2)
			{
				num++;
			}
		}
		string arg = "#FFFFFF";
		if (num == 0)
		{
			arg = "#DC143C";
		}
		return $"[color={arg}]{num}/{count}[/color]";
	}
}
