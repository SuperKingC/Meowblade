using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using GameDataEditor;
using ObservableClasses;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Sources.Enums;
using UI.WorldMap;

namespace Shift.Legion.Common.Managers;

public class TriggerManager : Manager
{
	private static readonly string[] CommonCases = new string[2] { "LevelId", "UserLevel" };

	private Dictionary<string, List<string>> _triggersDictionary;

	private static readonly ConcurrentDictionary<string, Trigger> Triggers = new ConcurrentDictionary<string, Trigger>();

	private readonly Dictionary<string, string> _triggerId2Type = new Dictionary<string, string>();

	public static Func<Level> GetCurrentLevel;

	private readonly Dictionary<string, Action<Dictionary<string, object>>> _triggerOnFilterPayloadChanged = new Dictionary<string, Action<Dictionary<string, object>>>();

	private readonly Dictionary<string, Dictionary<string, object>> _triggerFilterPayload = new Dictionary<string, Dictionary<string, object>>();

	private readonly Dictionary<string, Dictionary<string, object>> _triggerCustomActions = new Dictionary<string, Dictionary<string, object>>();

	private readonly Dictionary<string, Action> _triggerCallbackActions = new Dictionary<string, Action>();

	private readonly Dictionary<string, Dictionary<string, object>> _triggerProgressFilterCases = new Dictionary<string, Dictionary<string, object>>();

	public Dictionary<string, List<string>> TriggersDictionary
	{
		get
		{
			if (_triggersDictionary == null)
			{
				_triggersDictionary = new Dictionary<string, List<string>>();
			}
			return _triggersDictionary;
		}
	}

	public static Trigger GetTrigger(string type)
	{
		Trigger value;
		do
		{
			if (Triggers.TryGetValue(type, out value))
			{
				return value;
			}
			value = new Trigger(type);
		}
		while (!Triggers.TryAdd(type, value));
		return value;
	}

	public string CreateTrigger(string type)
	{
		string text = Guid.NewGuid().ToString();
		_triggerId2Type.Add(text, type);
		Trigger trigger = GetTrigger(type);
		SetFilterPayload(text, trigger.DetailCases);
		return text;
	}

	public Trigger GetTriggerById(string triggerId)
	{
		return GetTrigger(_triggerId2Type[triggerId]);
	}

	public void OnTriggerFilterPayloadChanged(string triggerId, Dictionary<string, object> filterPayload)
	{
		if (_triggerOnFilterPayloadChanged.TryGetValue(triggerId, out var value))
		{
			value(filterPayload);
		}
	}

	public TriggerManager(GameManagers managers)
		: base(managers)
	{
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener("GAME_ENTER", OnGameEnter);
		Managers.Messenger.AddListener<string, int>("TECH_UPGRADED", OnTechUpgraded);
		Managers.Messenger.AddListener<string, int>("ITEM_UPGRADE", OnItemEvelated);
		Managers.Messenger.AddListener<string>("BUILDING_CONSTRUCTING_COMPLETE", OnBuildingConstructingComplete);
		Managers.Messenger.AddListener<string, int>("BUILDING_UPGRADED", OnBuildingUpgraded);
		Managers.Messenger.AddListener<string, int>("BUILDING_UPGRADED_USE_ITEM", OnBuildingUpgraded);
		Managers.Messenger.AddListener<string>("SOLDIER_UNLOCKED", OnSoldierUnlocked);
		Managers.Messenger.AddListener<string, int>("SOLDIER_EVOLUTED", OnSoldierEvoluted);
		Managers.Messenger.AddListener<string, int, int>("SOLDIER_LEVEL_CHANGED", OnSoldierLevelChanged);
		Managers.Messenger.AddListener<string, int>("SOLDIER_BREAKTHROUGH", OnSoldierBreakthrough);
		Managers.Messenger.AddListener<string, int, Dictionary<string, int>>("SOLDIER_SUMMONING", OnSoldierSummoning);
		Managers.Messenger.AddListener<Level>("BATTLE_START", OnLevelStarted);
		Managers.Messenger.AddListener<Level, Team>("BEFORE_LEVEL_COMPLETED", OnBeforeLevelCompleted);
		Managers.Messenger.AddListener<string, Level, Team, bool>("LEVEL_COMPLETED", OnLevelCompleted);
		Managers.Messenger.AddListener<Level>("LEVEL_BONUS_CLAIMED", OnLevelBonusClaimed);
		Managers.Messenger.AddListener<List<Bonus>>("ON_BONUS_CARDS_POPUP", OnBonusCardsPopup);
		Managers.Messenger.AddListener<string>("ON_BONUS_CARDS_SELECT", OnBonusCardsSelect);
		Managers.Messenger.AddListener<Bonus>("ON_BONUS_CARDS_CONFIRM", OnBonusCardsConfirm);
		Managers.Messenger.AddListener("ON_LEVEL_BONUS_SETTLEMENT_POPUP", OnLevelBonusSettlementPopup);
		Managers.Messenger.AddListener<string>("STOCK_IS_FULL", OnStockIsFull);
		Managers.Messenger.AddListener<string, string>("MORE_RESOURCE_REQUIRED", OnMoreResourceRequired);
		Managers.Messenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		Managers.Messenger.AddListener<string, int, (StockInContext, string)>("CONFIRM_STOCK_CHANGE", OnConfirmStockChange);
		SharedMessenger.AddListener<string, Dictionary<string, object>>("OPEN_UI", OnOpenUI);
		SharedMessenger.AddListener<string>("CLOSE_UI", OnCloseUI);
		Managers.Messenger.AddListener<string>("TRIGGER_ACTIVATED", OnTriggerActivated);
		Managers.Messenger.AddListener<Mission>("MISSION_COMPLETE", OnMissionComplete);
		Managers.Messenger.AddListener<Mission>("MISSION_PROGRESS_CHANGED", OnMissionProgressChanged);
		Managers.Messenger.AddListener<Mission>("MISSION_CLAIMED", OnMissionClaimed);
		Managers.Messenger.AddListener<int>("USER_LEVEL_UP", OnUserLevelUp);
		Managers.Messenger.AddListener<Region>("WOLRDMAP_ON_FOCUS_REGION", OnRegionFocused);
		Managers.Messenger.AddListener<Region>("WOLRDMAP_ON_STRONGHOLD_SHOWUP", OnStrongholdShowUp);
		Managers.Messenger.AddListener<string>("FORMATION_UNLOCKED", OnFormationUnlocked);
		Managers.Messenger.AddListener<string, DateTimeOffset>("LEASEHOLD_REGISTERD", OnLeaseholdRegistered);
		Managers.Messenger.AddListener<string>("LEASEHOLD_UNREGISTERD", OnLeaseholdUnregistered);
		Managers.Messenger.AddListener<string, DateTimeOffset>("LIMIT_TIME_MERCHANDISE_ENABLED", OnLimitTimeMerchandiseEnabled);
		Managers.Messenger.AddListener<string>("LIMIT_TIME_MERCHANDISE_EXPIRED", OnLimitTimeMerchandiseExpired);
		Managers.Messenger.AddListener<string>("MAIN_CITY_COM_UNLOCKED", OnMainCityComUnlocked);
		Managers.Messenger.AddListener<Pieces, int, Dictionary<string, int>, List<KeyValuePair<Bonus, int>>>("PIECES_COMPOUND", OnCompound);
		Managers.Messenger.AddListener<List<Achievement>>("ACHIEVEMENT_COMPLETE", OnAchievementComplete);
		Managers.Messenger.AddListener<int>("ON_DAILY_LOGIN_STATS", OnDailyLoginStats);
		Managers.Messenger.AddListener<Activity, bool>("ACTIVITY_RESET", OnActivityReset);
		Managers.Messenger.AddListener("PVP_RANK_SCORE_CLAIMED", OnPvPRankScoreClaimed);
		Managers.Messenger.AddListener("WATCHING_REPLAY", OnWatchingReplay);
		Managers.Messenger.AddListener("WATCHING_PVP_RANK_REPLAY", OnWatchingPvPRankReplay);
		Managers.Messenger.AddListener("WATCHING_STORY_MAIN_REPLAY", OnWatchingStoryMainReplay);
		Managers.Messenger.AddListener("PVP_RANK_BATTLE_START", OnPvPRankBattleStart);
		Managers.Messenger.AddListener<Order>("NEW_ORDER_STATS", OnOrderStats);
		Managers.Messenger.AddListener<LegendItem>("LEGEND_ITEM_ENHANCED", OnLegendItemEnhanced);
		Managers.Messenger.AddListener<LegendItem>("LEGEND_ITEM_CHANGED_PROPS", OnLegendItemChangedProps);
		Managers.Messenger.AddListener<LegendItem>("LEGEND_ITEM_REFORGED", OnLegendItemReforged);
		Managers.Messenger.AddListener("ATTACK_INSTANCE_CLAIMED_FINAL_PRIZE", OnAttackInstanceClaimedFinalPrize);
		Managers.Messenger.AddListener<Level>("AFTER_LEVEL_BONUS_CLAIMED", AfterLevelBonusClaimed);
		Managers.Messenger.AddListener<string>("STORY_END", OnStoryEnd);
		Managers.Messenger.AddListener<string>("NEW_GUIDE_PANEL_SHOW", OnNewGuidePanelShow);
		Managers.Messenger.AddListener<string>("NEW_GUIDE_MISSION_UNDERGOING", OnNewGuideMissionUndergoing);
		Managers.Messenger.AddListener("NEW_BIE_CARDS_SHOW", OnNewbieCardsShow);
		Managers.Messenger.AddListener("GVG2_ENTER_ISLAND", OnGvG2EnterIsland);
		Managers.Messenger.AddListener("ON_GVG_ISLAND_PANEL_SHOW", OnGvGIslandPanelShow);
		Managers.Messenger.AddListener("ON_GVG_LORDOFDREAM_PANEL_SHOW", OnLordOfDreamPanelShow);
		Managers.Messenger.AddListener<int>("PVP_RANK_UPDATE_PROGRESS", OnPvPRankUpdate);
		Managers.Messenger.AddListener<int>("DRAW_CARD", OnDrawCard);
		Managers.Messenger.AddListener<int>("DRAW_LEGEND_ITEM", OnDrawLegendItem);
		Managers.Messenger.AddListener<int>("ON_LEGENDITEM_UPDATE", OnLegendItemUpdate);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener("GAME_ENTER", OnGameEnter);
		Managers.Messenger.RemoveListener<string, int>("TECH_UPGRADED", OnTechUpgraded);
		Managers.Messenger.RemoveListener<string, int>("ITEM_UPGRADE", OnItemEvelated);
		Managers.Messenger.RemoveListener<string>("BUILDING_CONSTRUCTING_COMPLETE", OnBuildingConstructingComplete);
		Managers.Messenger.RemoveListener<string, int>("BUILDING_UPGRADED", OnBuildingUpgraded);
		Managers.Messenger.RemoveListener<string, int>("BUILDING_UPGRADED_USE_ITEM", OnBuildingUpgraded);
		Managers.Messenger.RemoveListener<string>("SOLDIER_UNLOCKED", OnSoldierUnlocked);
		Managers.Messenger.RemoveListener<string, int>("SOLDIER_EVOLUTED", OnSoldierEvoluted);
		Managers.Messenger.RemoveListener<string, int, int>("SOLDIER_LEVEL_CHANGED", OnSoldierLevelChanged);
		Managers.Messenger.RemoveListener<string, int>("SOLDIER_BREAKTHROUGH", OnSoldierBreakthrough);
		Managers.Messenger.RemoveListener<string, int, Dictionary<string, int>>("SOLDIER_SUMMONING", OnSoldierSummoning);
		Managers.Messenger.RemoveListener<Level>("BATTLE_START", OnLevelStarted);
		Managers.Messenger.RemoveListener<Level, Team>("BEFORE_LEVEL_COMPLETED", OnBeforeLevelCompleted);
		Managers.Messenger.RemoveListener<string, Level, Team, bool>("LEVEL_COMPLETED", OnLevelCompleted);
		Managers.Messenger.RemoveListener<Level>("LEVEL_BONUS_CLAIMED", OnLevelBonusClaimed);
		Managers.Messenger.RemoveListener<List<Bonus>>("ON_BONUS_CARDS_POPUP", OnBonusCardsPopup);
		Managers.Messenger.RemoveListener<string>("ON_BONUS_CARDS_SELECT", OnBonusCardsSelect);
		Managers.Messenger.RemoveListener<Bonus>("ON_BONUS_CARDS_CONFIRM", OnBonusCardsConfirm);
		Managers.Messenger.RemoveListener("ON_LEVEL_BONUS_SETTLEMENT_POPUP", OnLevelBonusSettlementPopup);
		Managers.Messenger.RemoveListener<string>("STOCK_IS_FULL", OnStockIsFull);
		Managers.Messenger.RemoveListener<string, string>("MORE_RESOURCE_REQUIRED", OnMoreResourceRequired);
		Managers.Messenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		Managers.Messenger.RemoveListener<string, int, (StockInContext, string)>("CONFIRM_STOCK_CHANGE", OnConfirmStockChange);
		SharedMessenger.RemoveListener<string, Dictionary<string, object>>("OPEN_UI", OnOpenUI);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnCloseUI);
		Managers.Messenger.RemoveListener<string>("TRIGGER_ACTIVATED", OnTriggerActivated);
		Managers.Messenger.RemoveListener<Mission>("MISSION_COMPLETE", OnMissionComplete);
		Managers.Messenger.RemoveListener<Mission>("MISSION_PROGRESS_CHANGED", OnMissionProgressChanged);
		Managers.Messenger.RemoveListener<Mission>("MISSION_CLAIMED", OnMissionClaimed);
		Managers.Messenger.RemoveListener<int>("USER_LEVEL_UP", OnUserLevelUp);
		Managers.Messenger.RemoveListener<Region>("WOLRDMAP_ON_FOCUS_REGION", OnRegionFocused);
		Managers.Messenger.RemoveListener<Region>("WOLRDMAP_ON_STRONGHOLD_SHOWUP", OnStrongholdShowUp);
		Managers.Messenger.RemoveListener<string>("FORMATION_UNLOCKED", OnFormationUnlocked);
		Managers.Messenger.RemoveListener<string, DateTimeOffset>("LEASEHOLD_REGISTERD", OnLeaseholdRegistered);
		Managers.Messenger.RemoveListener<string>("LEASEHOLD_UNREGISTERD", OnLeaseholdUnregistered);
		Managers.Messenger.RemoveListener<string, DateTimeOffset>("LIMIT_TIME_MERCHANDISE_ENABLED", OnLimitTimeMerchandiseEnabled);
		Managers.Messenger.RemoveListener<string>("LIMIT_TIME_MERCHANDISE_EXPIRED", OnLimitTimeMerchandiseExpired);
		Managers.Messenger.RemoveListener<string>("MAIN_CITY_COM_UNLOCKED", OnMainCityComUnlocked);
		Managers.Messenger.RemoveListener<Pieces, int, Dictionary<string, int>, List<KeyValuePair<Bonus, int>>>("PIECES_COMPOUND", OnCompound);
		Managers.Messenger.RemoveListener<List<Achievement>>("ACHIEVEMENT_COMPLETE", OnAchievementComplete);
		Managers.Messenger.RemoveListener<int>("ON_DAILY_LOGIN_STATS", OnDailyLoginStats);
		Managers.Messenger.RemoveListener<Activity, bool>("ACTIVITY_RESET", OnActivityReset);
		Managers.Messenger.RemoveListener("PVP_RANK_SCORE_CLAIMED", OnPvPRankScoreClaimed);
		Managers.Messenger.RemoveListener("WATCHING_REPLAY", OnWatchingReplay);
		Managers.Messenger.RemoveListener("WATCHING_PVP_RANK_REPLAY", OnWatchingPvPRankReplay);
		Managers.Messenger.RemoveListener("WATCHING_STORY_MAIN_REPLAY", OnWatchingStoryMainReplay);
		Managers.Messenger.RemoveListener("PVP_RANK_BATTLE_START", OnPvPRankBattleStart);
		Managers.Messenger.RemoveListener<Order>("NEW_ORDER_STATS", OnOrderStats);
		Managers.Messenger.RemoveListener<LegendItem>("LEGEND_ITEM_ENHANCED", OnLegendItemEnhanced);
		Managers.Messenger.RemoveListener<LegendItem>("LEGEND_ITEM_CHANGED_PROPS", OnLegendItemChangedProps);
		Managers.Messenger.RemoveListener<LegendItem>("LEGEND_ITEM_REFORGED", OnLegendItemReforged);
		Managers.Messenger.RemoveListener("ATTACK_INSTANCE_CLAIMED_FINAL_PRIZE", OnAttackInstanceClaimedFinalPrize);
		Managers.Messenger.RemoveListener<Level>("AFTER_LEVEL_BONUS_CLAIMED", AfterLevelBonusClaimed);
		Managers.Messenger.RemoveListener<string>("STORY_END", OnStoryEnd);
		Managers.Messenger.RemoveListener<string>("NEW_GUIDE_PANEL_SHOW", OnNewGuidePanelShow);
		Managers.Messenger.RemoveListener<string>("NEW_GUIDE_MISSION_UNDERGOING", OnNewGuideMissionUndergoing);
		Managers.Messenger.RemoveListener("NEW_BIE_CARDS_SHOW", OnNewbieCardsShow);
		Managers.Messenger.RemoveListener("GVG2_ENTER_ISLAND", OnGvG2EnterIsland);
		Managers.Messenger.RemoveListener("ON_GVG_ISLAND_PANEL_SHOW", OnGvGIslandPanelShow);
		Managers.Messenger.RemoveListener("ON_GVG_LORDOFDREAM_PANEL_SHOW", OnLordOfDreamPanelShow);
		Managers.Messenger.RemoveListener<int>("PVP_RANK_UPDATE_PROGRESS", OnPvPRankUpdate);
		Managers.Messenger.RemoveListener<int>("DRAW_CARD", OnDrawCard);
		Managers.Messenger.RemoveListener<int>("DRAW_LEGEND_ITEM", OnDrawLegendItem);
		Managers.Messenger.RemoveListener<int>("ON_LEGENDITEM_UPDATE", OnLegendItemUpdate);
	}

	private void TryActivateTriggers(string triggerType, Dictionary<string, object> filters = null, bool isWorldMapShowUp = false)
	{
		if (isWorldMapShowUp && TriggersDictionary.TryGetValue(triggerType, out var value) && value.Count > 0)
		{
			UI_WorldMapPanel.WorldMapPanel?.SetBtnEnabled(btnEnabled: false);
		}
		else
		{
			UI_WorldMapPanel.WorldMapPanel?.SetBtnEnabled(btnEnabled: true);
		}
		if (!TriggersDictionary.TryGetValue(triggerType, out var value2) || value2.Count <= 0)
		{
			return;
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object> { 
		{
			"UserLevel",
			Managers.UserArchiveManager.GetUserLevel()
		} };
		Level level = GetCurrentLevel();
		if (level != null)
		{
			dictionary.Add("LevelId", level.LevelId);
		}
		if (filters != null)
		{
			foreach (KeyValuePair<string, object> filter in filters)
			{
				if (dictionary.ContainsKey(filter.Key))
				{
					dictionary[filter.Key] = filter.Value;
				}
				else
				{
					dictionary.Add(filter.Key, filter.Value);
				}
			}
		}
		if (dictionary.TryGetValue("LevelId", out var value3) && ChapterManager.Levels.TryGetValue(value3.ToString(), out var level2) && ChapterManager.Chapters.TryGetValue(level2.ChapterId, out var value4))
		{
			if (dictionary.ContainsKey("ChapterType"))
			{
				dictionary["ChapterType"] = (int)value4.Type;
			}
			else
			{
				dictionary.Add("ChapterType", (int)value4.Type);
			}
			if (dictionary.ContainsKey("ChapterId"))
			{
				dictionary["ChapterId"] = value4.ChapterId;
			}
			else
			{
				dictionary.Add("ChapterId", value4.ChapterId);
			}
		}
		List<string> list = new List<string>();
		for (int i = 0; i < value2.Count; i++)
		{
			string text = value2[i];
			if (!CheckFilterCases(text))
			{
				continue;
			}
			Trigger trigger = GetTrigger(_triggerId2Type[text]);
			if (trigger.CallbackFilter == null || trigger.CallbackFilter(Managers, text, dictionary))
			{
				RunCallback(text);
				if (trigger.DestroyAfterRunSuccess)
				{
					list.Add(text);
				}
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		foreach (string item in list)
		{
			RemoveTrigger(item);
		}
	}

	private void OnGameEnter()
	{
		TryActivateTriggers("OnEnterGame");
	}

	private void OnTechUpgraded(string techId, int level)
	{
		TryActivateTriggers("OnTechnologyUpgrade", new Dictionary<string, object>
		{
			{ "TechnologyId", techId },
			{ "Level", level }
		});
	}

	private void OnItemEvelated(string itemId, int level)
	{
		TryActivateTriggers("OnWeaponUpgrade", new Dictionary<string, object>
		{
			{ "ItemId", itemId },
			{ "Level", level }
		});
	}

	private void OnBuildingUpgraded(string buildingType, int level)
	{
		TryActivateTriggers("OnBuildingUpgrade", new Dictionary<string, object>
		{
			{ "BuildingType", buildingType },
			{ "Level", level }
		});
	}

	private void OnBuildingConstructingComplete(string buildingType)
	{
		TryActivateTriggers("OnBuildingConstructingComplete", new Dictionary<string, object> { { "BuildingType", buildingType } });
	}

	private void OnSoldierUnlocked(string soldierId)
	{
		TryActivateTriggers("OnSoldierUnlock", new Dictionary<string, object> { { "SoldierId", soldierId } });
	}

	private void OnSoldierEvoluted(string soldierId, int evoLevel)
	{
		TryActivateTriggers("OnSoldierEvolute", new Dictionary<string, object>
		{
			{ "SoldierId", soldierId },
			{ "EvoLevel", evoLevel }
		});
	}

	private void OnSoldierLevelChanged(string soldierId, int beforeLevel, int afterLevel)
	{
		TryActivateTriggers("OnSoldierLevelUp", new Dictionary<string, object>
		{
			{ "SoldierId", soldierId },
			{ "BeforeLevel", beforeLevel },
			{ "Level", afterLevel }
		});
	}

	private void OnSoldierBreakthrough(string soldierId, int breakthroughLevel)
	{
		TryActivateTriggers("OnSoldierBreakthrough", new Dictionary<string, object>
		{
			{ "SoldierId", soldierId },
			{ "BreakthroughLevel", breakthroughLevel }
		});
	}

	private void OnSoldierSummoning(string soldierId, int potentialLevelChanged, Dictionary<string, int> convertBonus)
	{
		if (potentialLevelChanged > 0)
		{
			int soldierPotentialLevel = Managers.UserArchiveManager.GetSoldierPotentialLevel(soldierId);
			TryActivateTriggers("OnSoldierPotentialUpgrade", new Dictionary<string, object>
			{
				{ "SoldierId", soldierId },
				{ "PotentialLevel", soldierPotentialLevel }
			});
		}
	}

	private void OnEnterLevel(GDELevelData levelData, InsertOrder insertOrder)
	{
		TryActivateTriggers("OnEnterLevel", new Dictionary<string, object> { { "LevelId", levelData.Key } });
	}

	private void OnLevelStarted(Level level)
	{
		TryActivateTriggers("OnLevelStart", new Dictionary<string, object> { { "LevelId", level.LevelId } });
	}

	private void OnBeforeLevelCompleted(Level level, Team winner)
	{
		TryActivateTriggers("OnBeforeLevelComplete", new Dictionary<string, object>
		{
			{ "LevelId", level.LevelId },
			{
				"Winner",
				(int)winner
			}
		});
	}

	private void OnLevelCompleted(string battleId, Level level, Team winner, bool newCompleteFlag)
	{
		if (string.IsNullOrEmpty(level.Data.ParentLevelId))
		{
			TryActivateTriggers("OnLevelComplete", new Dictionary<string, object>
			{
				{ "LevelId", level.LevelId },
				{ "Winner", winner }
			});
			TryActivateTriggers("OnLevelCompleteCalc", new Dictionary<string, object>
			{
				{ "LevelId", level.LevelId },
				{ "Winner", winner }
			});
		}
	}

	private void OnLevelBonusClaimed(Level level)
	{
		TryActivateTriggers("OnLevelBonusClaimed", new Dictionary<string, object> { { "LevelId", level.LevelId } });
	}

	private void OnStoryEnd(string storyId)
	{
		TryActivateTriggers("OnStoryEnd", new Dictionary<string, object> { { "StoryId", storyId } });
	}

	private void OnNewGuidePanelShow(string missionId)
	{
		TryActivateTriggers("OnNewGuidePanelShow", new Dictionary<string, object> { { "MissionId", missionId } });
	}

	private void OnNewGuideMissionUndergoing(string missionId)
	{
		TryActivateTriggers("OnNewGuideMissionUndergoing", new Dictionary<string, object> { { "MissionId", missionId } });
	}

	private void AfterLevelBonusClaimed(Level level)
	{
		TryActivateTriggers("AfterLevelBonusClaimed", new Dictionary<string, object> { { "LevelId", level.LevelId } });
	}

	private void OnBonusCardsPopup(List<Bonus> cards)
	{
		TryActivateTriggers("OnBonusCardsPopup");
	}

	private void OnNewbieCardsShow()
	{
		TryActivateTriggers("OnNewbieCardsShow");
	}

	private void OnGvG2EnterIsland()
	{
		TryActivateTriggers("OnGvG2EnterIsland");
	}

	private void OnGvGIslandPanelShow()
	{
		TryActivateTriggers("OnGvGIslandPanelShow");
	}

	private void OnLordOfDreamPanelShow()
	{
		TryActivateTriggers("OnLordOfDreamPanelShow");
	}

	private void OnBonusCardsSelect(string levelId)
	{
		TryActivateTriggers("OnBonusCardsSelect", new Dictionary<string, object> { { "LevelId", levelId } });
	}

	private void OnBonusCardsConfirm(Bonus bonus)
	{
		TryActivateTriggers("OnBonusCardsConfirm");
	}

	private void OnLevelBonusSettlementPopup()
	{
		TryActivateTriggers("OnLevelBonusSettlementPopup");
	}

	private void OnOpenUI(string uiId, Dictionary<string, object> parameters)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		if (parameters != null)
		{
			foreach (KeyValuePair<string, object> parameter in parameters)
			{
				dictionary.Add(parameter.Key, parameter.Value);
			}
			if (!dictionary.ContainsKey("BuildingType") && parameters.TryGetValue("Building", out var value) && value is Building building)
			{
				dictionary.Add("BuildingType", building.BuildingType);
			}
			if (dictionary.TryGetValue("BuildingType", out var value2))
			{
				dictionary.Add("BuildingLevel", Managers.UserArchiveManager.GetBuildingLevel(value2.ToString()));
			}
		}
		if (dictionary.ContainsKey("UI"))
		{
			dictionary["UI"] = uiId;
		}
		else
		{
			dictionary.Add("UI", uiId);
		}
		if (!dictionary.ContainsKey("Tab"))
		{
			switch (uiId)
			{
			case "UI_LegionPanel":
				dictionary.Add("Tab", 2);
				break;
			case "UI_SoldierCultivate":
				dictionary.Add("Tab", 0);
				break;
			case "UI_WarehousePanel":
				dictionary.Add("Tab", 0);
				break;
			case "UI_Technology":
				dictionary.Add("Tab", 0);
				break;
			}
		}
		TryActivateTriggers("OnOpenUI", dictionary);
	}

	private void OnCloseUI(string uiId)
	{
		TryActivateTriggers("OnCloseUI", new Dictionary<string, object> { { "UI", uiId } });
	}

	private void OnMoreResourceRequired(string resourceId, string targetId)
	{
		TryActivateTriggers("OnMoreResourceRequired", new Dictionary<string, object>
		{
			{ "ResourceId", resourceId },
			{ "TargetId", targetId }
		});
	}

	private void OnStockIsFull(string itemId)
	{
		TryActivateTriggers("OnStockIsFull", new Dictionary<string, object> { { "ItemId", itemId } });
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) contextTuple)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			{ "ItemId", itemId },
			{
				"Qty",
				Math.Abs(incr)
			},
			{
				"Stock",
				Managers.StockController.GetStock(itemId)
			},
			{ "Context", contextTuple }
		};
		if (contextTuple.Item1 != StockInContext.Refund)
		{
			if (incr > 0)
			{
				TryActivateTriggers("OnProd", dictionary);
			}
			else if (incr < 0)
			{
				TryActivateTriggers("OnCost", dictionary);
			}
		}
		Dictionary<string, object> dictionary2 = DictionaryExtensions.DeepCopy<string, object>(dictionary);
		dictionary2["Qty"] = incr;
		TryActivateTriggers("OnStock", dictionary2);
	}

	private void OnConfirmStockChange(string itemId, int incr, (StockInContext, string) contextTuple)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			{ "ItemId", itemId },
			{
				"Qty",
				Math.Abs(incr)
			},
			{
				"Stock",
				Managers.StockController.GetStock(itemId)
			},
			{ "Context", contextTuple }
		};
		if (contextTuple.Item1 != StockInContext.Refund)
		{
			if (incr > 0)
			{
				TryActivateTriggers("OnProd", dictionary);
			}
			else if (incr < 0)
			{
				TryActivateTriggers("OnCost", dictionary);
			}
		}
		Dictionary<string, object> dictionary2 = DictionaryExtensions.DeepCopy<string, object>(dictionary);
		dictionary2["Qty"] = incr;
		TryActivateTriggers("OnStock", dictionary2);
	}

	private void OnGameEntityDead(Team team, string soldierId)
	{
	}

	private void OnMissionComplete(Mission mission)
	{
		TryActivateTriggers("OnMissionComplete", new Dictionary<string, object> { { "MissionId", mission.Id } });
	}

	private void OnMissionProgressChanged(Mission mission)
	{
		TryActivateTriggers("OnMissionProgressChanged", new Dictionary<string, object> { { "MissionId", mission.Id } });
	}

	private void OnMissionClaimed(Mission mission)
	{
		TryActivateTriggers("OnMissionClaimed", new Dictionary<string, object> { { "MissionId", mission.Id } });
	}

	private void OnUserLevelUp(int level)
	{
		TryActivateTriggers("OnUserLevelUp", new Dictionary<string, object> { { "UserLevel", level } });
	}

	private void OnRegionFocused(Region region)
	{
		TryActivateTriggers("OnFocusRegion", new Dictionary<string, object>
		{
			{ "Region", region.RegionId },
			{
				"Status",
				(int)region.Status(Managers)
			}
		});
	}

	private void OnStrongholdShowUp(Region region)
	{
		TryActivateTriggers("OnStrongholdShowUp", new Dictionary<string, object>
		{
			{ "Region", region.RegionId },
			{
				"Status",
				(int)region.Status(Managers)
			}
		}, isWorldMapShowUp: true);
	}

	private void OnFormationUnlocked(string formationId)
	{
		TryActivateTriggers("OnFormationUnlocked", new Dictionary<string, object> { { "FormationId", formationId } });
	}

	private void OnLeaseholdRegistered(string itemId, DateTimeOffset expireAt)
	{
		TryActivateTriggers("OnLeaseholdRegistered", new Dictionary<string, object> { { "Item", itemId } });
	}

	private void OnLeaseholdUnregistered(string itemId)
	{
		TryActivateTriggers("OnLeaseholdUnregister", new Dictionary<string, object> { { "Item", itemId } });
	}

	private void OnLimitTimeMerchandiseEnabled(string itemId, DateTimeOffset expiredAt)
	{
		TryActivateTriggers("OnLimitTimeMerchandiseRegister", new Dictionary<string, object> { { "ItemId", itemId } });
	}

	private void OnLimitTimeMerchandiseExpired(string itemId)
	{
		TryActivateTriggers("OnLimitTimeMerchandiseExpired", new Dictionary<string, object> { { "ItemId", itemId } });
	}

	private void OnMainCityComUnlocked(string componentId)
	{
		TryActivateTriggers("OnMainCityComUnlocked", new Dictionary<string, object> { { "Component", componentId } });
	}

	private void OnCompound(Pieces piecesData, int compoundCnt, Dictionary<string, int> compoundResult, List<KeyValuePair<Bonus, int>> bonusInfoList)
	{
		TryActivateTriggers("OnCompound", new Dictionary<string, object>
		{
			{ "PiecesItemId", piecesData.ItemId },
			{ "Result", compoundResult }
		});
		TryActivateTriggers("OnCompoundCalc", new Dictionary<string, object>
		{
			{ "PiecesItemId", piecesData.ItemId },
			{ "Result", compoundResult },
			{ "Count", compoundCnt }
		});
	}

	private void OnLegendItemEnhanced(LegendItem legendItem)
	{
		TryActivateTriggers("LegendItemEnhanced", new Dictionary<string, object> { { "LegendItem", legendItem } });
	}

	private void OnLegendItemChangedProps(LegendItem legendItem)
	{
		TryActivateTriggers("LegendItemChangedProps", new Dictionary<string, object> { { "LegendItem", legendItem } });
	}

	private void OnLegendItemReforged(LegendItem legendItem)
	{
		TryActivateTriggers("LegendItemReforged", new Dictionary<string, object> { { "LegendItem", legendItem } });
	}

	private void OnAttackInstanceClaimedFinalPrize()
	{
		TryActivateTriggers("AttackInstanceClaimedFinalPrize");
	}

	private void OnOrderStats(Order order)
	{
		TryActivateTriggers("NewOrderStats", new Dictionary<string, object> { { "StoreItemId", order.StoreItemId } });
	}

	private void OnWatchingReplay()
	{
		TryActivateTriggers("WatchingReplay");
	}

	private void OnWatchingPvPRankReplay()
	{
		TryActivateTriggers("WatchingPvPRankReplay");
	}

	private void OnWatchingStoryMainReplay()
	{
		TryActivateTriggers("WatchingStoryMainReplay");
	}

	private void OnPvPRankBattleStart()
	{
		TryActivateTriggers("PvPRankBattleStart");
	}

	private void OnPvPRankScoreClaimed()
	{
		TryActivateTriggers("PvPRankScoreClaimed");
	}

	private void OnActivityReset(Activity activity, bool isAutoReset)
	{
		if (!isAutoReset)
		{
			TryActivateTriggers("ActivityReset", new Dictionary<string, object> { { "Activity", activity } });
		}
	}

	private void OnAchievementComplete(List<Achievement> completeAchievements)
	{
		TryActivateTriggers("OnAchievement", new Dictionary<string, object> { { "Achievements", completeAchievements } });
		TryActivateTriggers("TypeForFunds2", new Dictionary<string, object> { { "Achievements", completeAchievements } });
	}

	private void OnDailyLoginStats(int totalLoginCnt)
	{
		TryActivateTriggers("OnDailyLoginCalc");
		TryActivateTriggers("TypeForFunds1");
	}

	private void OnTriggerActivated(string activatedTrigger)
	{
		TryActivateTriggers("OnActivate");
	}

	public void SetupTrigger(string triggerId)
	{
		Trigger triggerById = GetTriggerById(triggerId);
		string type = triggerById.Type;
		string text = type;
		if (text == "OnColliding" || !(text == "OnTimeout"))
		{
		}
		AddToTriggersDictionary(triggerId);
		Managers.Messenger.Broadcast("TRIGGER_ACTIVATED", triggerId);
	}

	public void RemoveTrigger(string triggerId)
	{
		RemoveFromTriggersDictionary(triggerId);
	}

	private void AddToTriggersDictionary(string triggerId)
	{
		Trigger triggerById = GetTriggerById(triggerId);
		if (!TriggersDictionary.ContainsKey(triggerById.Type))
		{
			TriggersDictionary.Add(triggerById.Type, new List<string>());
		}
		TriggersDictionary[triggerById.Type].Add(triggerId);
	}

	private void RemoveFromTriggersDictionary(string triggerId)
	{
		Trigger triggerById = GetTriggerById(triggerId);
		if (TriggersDictionary.ContainsKey(triggerById.Type))
		{
			TriggersDictionary[triggerById.Type].Remove(triggerId);
		}
	}

	public void AddCustomAction(string triggerId, string storyKey, string startTrigger, string actionName, string actionPayload, string nextTrigger)
	{
		_triggerCustomActions[triggerId] = new Dictionary<string, object>
		{
			{ "Key", storyKey },
			{ "StartTrigger", startTrigger },
			{ "ActionName", actionName },
			{ "ActionPayload", actionPayload },
			{ "NextTrigger", nextTrigger }
		};
	}

	public void SetCallback(string triggerId, Action action)
	{
		_triggerCallbackActions[triggerId] = action;
	}

	public void RunCallback(string triggerId)
	{
		if (!_triggerCustomActions.TryGetValue(triggerId, out var value) || value.Count == 0)
		{
			_triggerCallbackActions[triggerId]();
			return;
		}
		value.TryGetValue("Key", out var value2);
		if (value2 != null)
		{
			StoryManager.PlayStoryByLineKey(Managers, value2.ToString());
		}
	}

	public void SetFilterPayload(string triggerId, Dictionary<string, object> detailCases)
	{
		if (detailCases == null || detailCases.Count <= 0)
		{
			return;
		}
		ObservableDictionary<string, object> val = new ObservableDictionary<string, object>();
		foreach (KeyValuePair<string, object> detailCase in detailCases)
		{
			val.Add(detailCase.Key, detailCase.Value);
		}
		val.OnChanged = (Action<Dictionary<string, object>>)Delegate.Combine(val.OnChanged, (Action<Dictionary<string, object>>)delegate(Dictionary<string, object> payload)
		{
			OnTriggerFilterPayloadChanged(triggerId, payload);
		});
		_triggerFilterPayload[triggerId] = (Dictionary<string, object>)(object)val;
	}

	public Dictionary<string, object> GetFilterPayload(string triggerId)
	{
		_triggerFilterPayload.TryGetValue(triggerId, out var value);
		return value;
	}

	public void SetProgressFilterCases(string triggerId, Dictionary<string, object> detailCases)
	{
		if (detailCases == null || detailCases.Count <= 0)
		{
			return;
		}
		ObservableDictionary<string, object> val = new ObservableDictionary<string, object>();
		foreach (KeyValuePair<string, object> detailCase in detailCases)
		{
			val.Add(detailCase.Key, detailCase.Value);
		}
		_triggerProgressFilterCases[triggerId] = (Dictionary<string, object>)(object)val;
	}

	public bool CheckFilterCases(string triggerId)
	{
		_triggerProgressFilterCases.TryGetValue(triggerId, out var value);
		if (value != null && value.TryGetValue("ProgressFilter_MissionClaimed", out var value2))
		{
			foreach (string item in (List<string>)value2)
			{
				if (!MissionManager.Missions.TryGetValue(item, out var value3) || value3.MissionState(Managers).Status != MissionStatus.Claimed)
				{
					return false;
				}
			}
		}
		return true;
	}

	public void SetOnFilterPayloadChanged(string triggerId, Action<Dictionary<string, object>> action)
	{
		_triggerOnFilterPayloadChanged[triggerId] = action;
	}

	private void OnPvPRankUpdate(int topRank)
	{
		TryActivateTriggers("OnRankUpdate", new Dictionary<string, object> { { "TopRank", topRank } });
	}

	private void OnDrawCard(int cnt)
	{
		TryActivateTriggers("OnDrawCard", new Dictionary<string, object> { { "Cnt", cnt } });
	}

	private void OnDrawLegendItem(int cnt)
	{
		TryActivateTriggers("OnDrawLegendItem", new Dictionary<string, object> { { "Cnt", cnt } });
	}

	private void OnLegendItemUpdate(int cnt)
	{
		TryActivateTriggers("OnLegendItemSet", new Dictionary<string, object> { { "Cnt", cnt } });
	}
}
