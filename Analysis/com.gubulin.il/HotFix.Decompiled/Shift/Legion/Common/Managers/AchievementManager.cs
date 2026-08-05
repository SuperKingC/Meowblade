using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataEditor;
using HotFix.Sources.Utils;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class AchievementManager : Manager
{
	private const string IdentifiedLegendItemsKey = "IdentifiedLegendItems";

	private const string LegendItemChangePropertyStatsKey = "LegendItemChangePropertyStats";

	private const string LegendItemReforgeStatsKey = "LegendItemReforgeStats";

	private const string LegendItemFromBlackMarketStatsKey = "LegendItemFromBlackMarketStats";

	private const string LegendItemEnhanceLevelStatsKey = "LegendItemEnhanceLevelStats";

	private const string LegendItemRarityStatsKey = "LegendItemRarityStats";

	private const string ActivatedLegendItemSetStatsKey = "ActivatedLegendItemSetStats";

	private const string IdentifiedLegendItemsRarityStatsKey = "IdentifiedLegendItemsRarityStatsKey";

	private static Dictionary<AchievementCat, List<Achievement>> _achievementSummaries;

	private static Dictionary<AchievementType, List<Achievement>> _typifiedAchievements;

	private static Dictionary<AchievementCat, List<Achievement>> _categorizedAchievements;

	private static Dictionary<string, Achievement> _achievements;

	private Config<Dictionary<string, int>> _identifiedLegendItems;

	private Config<Dictionary<int, int>> _identifiedLegendItemsRarityStat;

	private Config<int> _legendItemChangePropertyStats;

	private Config<int> _legendItemReforgeStats;

	private Config<Dictionary<string, int>> _legendItemFromBlackMarketStats;

	private Config<Dictionary<int, int>> _legendItemEnhanceLevelStats;

	private Config<Dictionary<int, int>> _legendItemRarityStats;

	private Config<List<string>> _activatedLegendItemSets;

	private readonly Lazy<BindableProperty<bool>> _hasGiftOfLord = new Lazy<BindableProperty<bool>>(() => new BindableProperty<bool>
	{
		Value = false
	});

	private readonly AchievementType[] _giftOfLordLegendItemTypes = new AchievementType[2]
	{
		AchievementType.LegendItemIdentifiedRarity,
		AchievementType.LegendItemEnhanceLevelVariety
	};

	private readonly string[] _rareStones = new string[3] { "I62100", "I62099", "I62101" };

	public Config<Dictionary<string, int>> IdentifiedLegendItems
	{
		get
		{
			if (_identifiedLegendItems == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("IdentifiedLegendItems"))
				{
					userArchiveManager.SetConfigValue("IdentifiedLegendItems", new Dictionary<string, int>());
				}
				_identifiedLegendItems = userArchiveManager.GetConfig<Dictionary<string, int>>("IdentifiedLegendItems");
			}
			return _identifiedLegendItems;
		}
	}

	public Config<Dictionary<int, int>> IdentifiedLegendItemsRarityStat
	{
		get
		{
			if (_identifiedLegendItemsRarityStat == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("IdentifiedLegendItemsRarityStatsKey"))
				{
					Dictionary<string, int> value = Managers.AchievementManager.IdentifiedLegendItems.GetValue();
					if (value == null || value.Count == 0)
					{
						userArchiveManager.SetConfigValue("IdentifiedLegendItemsRarityStatsKey", new Dictionary<int, int>());
					}
					else
					{
						Dictionary<int, int> dictionary = new Dictionary<int, int>();
						foreach (KeyValuePair<string, int> item in value)
						{
							GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(item.Key);
							if (dictionary.ContainsKey(gDEItemData.Rarity))
							{
								dictionary[gDEItemData.Rarity] += item.Value;
							}
							else
							{
								dictionary.Add(gDEItemData.Rarity, item.Value);
							}
							userArchiveManager.SetConfigValue("IdentifiedLegendItemsRarityStatsKey", dictionary);
						}
					}
				}
				_identifiedLegendItemsRarityStat = userArchiveManager.GetConfig<Dictionary<int, int>>("IdentifiedLegendItemsRarityStatsKey");
			}
			return _identifiedLegendItemsRarityStat;
		}
	}

	public Config<int> LegendItemChangePropertyStats
	{
		get
		{
			if (_legendItemChangePropertyStats == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("LegendItemChangePropertyStats"))
				{
					userArchiveManager.SetConfigValue("LegendItemChangePropertyStats", 0);
				}
				_legendItemChangePropertyStats = userArchiveManager.GetConfig<int>("LegendItemChangePropertyStats");
			}
			return _legendItemChangePropertyStats;
		}
	}

	public Config<int> LegendItemReforgeStats
	{
		get
		{
			if (_legendItemReforgeStats == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("LegendItemReforgeStats"))
				{
					userArchiveManager.SetConfigValue("LegendItemReforgeStats", 0);
				}
				_legendItemReforgeStats = userArchiveManager.GetConfig<int>("LegendItemReforgeStats");
			}
			return _legendItemReforgeStats;
		}
	}

	public Config<Dictionary<string, int>> LegendItemFromBlackMarketStats
	{
		get
		{
			if (_legendItemFromBlackMarketStats == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("LegendItemFromBlackMarketStats"))
				{
					userArchiveManager.SetConfigValue("LegendItemFromBlackMarketStats", new Dictionary<string, int>());
				}
				_legendItemFromBlackMarketStats = userArchiveManager.GetConfig<Dictionary<string, int>>("LegendItemFromBlackMarketStats");
			}
			return _legendItemFromBlackMarketStats;
		}
	}

	public Config<Dictionary<int, int>> LegendItemEnhanceLevelStats
	{
		get
		{
			if (_legendItemEnhanceLevelStats == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("LegendItemEnhanceLevelStats"))
				{
					userArchiveManager.SetConfigValue("LegendItemEnhanceLevelStats", new Dictionary<int, int>());
				}
				_legendItemEnhanceLevelStats = userArchiveManager.GetConfig<Dictionary<int, int>>("LegendItemEnhanceLevelStats");
			}
			return _legendItemEnhanceLevelStats;
		}
	}

	public Config<Dictionary<int, int>> LegendItemRarityStats
	{
		get
		{
			if (_legendItemRarityStats == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("LegendItemRarityStats"))
				{
					userArchiveManager.SetConfigValue("LegendItemRarityStats", new Dictionary<int, int>());
				}
				_legendItemRarityStats = userArchiveManager.GetConfig<Dictionary<int, int>>("LegendItemRarityStats");
			}
			return _legendItemRarityStats;
		}
	}

	public Config<List<string>> ActivatedLegendItemSets
	{
		get
		{
			if (_activatedLegendItemSets == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("ActivatedLegendItemSetStats"))
				{
					userArchiveManager.SetConfigValue("ActivatedLegendItemSetStats", new List<string>());
				}
				_activatedLegendItemSets = userArchiveManager.GetConfig<List<string>>("ActivatedLegendItemSetStats");
			}
			return _activatedLegendItemSets;
		}
	}

	public static Dictionary<string, Achievement> Achievements
	{
		get
		{
			if (_achievements == null)
			{
				_achievements = new Dictionary<string, Achievement>();
				_typifiedAchievements = new Dictionary<AchievementType, List<Achievement>>();
				_categorizedAchievements = new Dictionary<AchievementCat, List<Achievement>>();
				_achievementSummaries = new Dictionary<AchievementCat, List<Achievement>>();
				foreach (GDEAchievementData allItem in GDMgr.GetAllItems<GDEAchievementData>())
				{
					Achievement achievement = new Achievement(allItem);
					_achievements.Add(allItem.Key, achievement);
					if (achievement.Type == AchievementType.Summary)
					{
						if (!_achievementSummaries.ContainsKey(achievement.Category))
						{
							_achievementSummaries.Add(achievement.Category, new List<Achievement>());
						}
						_achievementSummaries[achievement.Category].Add(achievement);
						continue;
					}
					if (!_categorizedAchievements.ContainsKey(achievement.Category))
					{
						_categorizedAchievements.Add(achievement.Category, new List<Achievement>());
					}
					_categorizedAchievements[achievement.Category].Add(achievement);
					if (!_typifiedAchievements.ContainsKey(achievement.Type))
					{
						_typifiedAchievements.Add(achievement.Type, new List<Achievement>());
					}
					_typifiedAchievements[achievement.Type].Add(achievement);
				}
				foreach (List<Achievement> value in _achievementSummaries.Values)
				{
					value.Sort((Achievement achievement2, Achievement achievement3) => (achievement2.Target.Value > achievement3.Target.Value) ? 1 : (-1));
				}
			}
			return _achievements;
		}
	}

	public AchievementManager(GameManagers managers)
		: base(managers)
	{
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener("SOLDIER_UNLOCKED", delegate(string soldierId)
		{
			CheckSoldierUnlock(soldierId);
			CheckSoldierPotential(soldierId, 0);
		});
		Managers.Messenger.AddListener<string, int>("SOLDIER_EVOLUTED", CheckSoldierEvo);
		Managers.Messenger.AddListener<string, int>("SOLDIER_BREAKTHROUGH", CheckSoldierBreakthrough);
		Managers.Messenger.AddListener<string, int, int>("SOLDIER_LEVEL_CHANGED", CheckSoldierLevel);
		Managers.Messenger.AddListener<string, int>("SOLDIER_POTENTIAL_UPGRADED", CheckSoldierPotential);
		Managers.Messenger.AddListener<string, int>("SOLDIER_LEGEND_ITEM_SLOT_UNLOCKED", CheckSoldierSecondLegendItemSlot);
		Managers.Messenger.AddListener<string, int>("TECH_UPGRADED", CheckTechLevel);
		Managers.Messenger.AddListener<int>("USER_LEVEL_UP", CheckUserLevel);
		Managers.Messenger.AddListener<string, string>("GAME_PROGRESS_UPDATED", CheckLevelProgress);
		Managers.Messenger.AddListener<string, string>("STRONGHOLD_ASSIGNED_OCCUPANT", CheckStrongholdOccupant);
		Managers.Messenger.AddListener<int>("DUNGEON_LEVEL_UP", CheckDungeonLevel);
		Managers.Messenger.AddListener<float>("ON_RECHARGE", CheckTotalRecharge);
		Managers.Messenger.AddListener<string, int>("BUILDING_UPGRADED", CheckBuildings);
		Managers.Messenger.AddListener<string, int>("BUILDING_UPGRADED_USE_ITEM", CheckBuildings);
		Managers.Messenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", CheckStock);
		Managers.Messenger.AddListener<string, int>("ITEM_UPGRADE", CheckItemLevel);
		Managers.Messenger.AddListener<int>("LEGEND_ITEMS_CHANGED", CheckLegendItems);
		Managers.Messenger.AddListener<Mission>("MISSION_COMPLETE", CheckNewbieMissionsStatus);
		Managers.Messenger.AddListener<string>("FORMATION_UNLOCKED", CheckUnlockFormations);
		Managers.Messenger.AddListener<string>("FORMATION_LOCKED", CheckUnlockFormations);
		Managers.Messenger.AddListener("ON_GVG3_IZ_COMPLETED", CheckGiftOfLordAchievementsOnGvg3IzClose);
		Managers.Messenger.AddListener<int>("LEGEND_ITEMS_CHANGED", CheckGiftOfLordAchievementsOnLegendItemsChange);
		Managers.Messenger.AddListener("ON_BLUEPRINTS_CHANGE", CheckGiftOfLordAchievementsBlueprintsChange);
		Managers.Messenger.AddListener("ON_BLUEPRINTS_IDENTIFY", CheckGiftOfLordAchievementsBlueprintsIdentify);
		Managers.Messenger.AddListener<int>("PVP_RANK_UPDATE_PROGRESS", CheckGiftOfLordAchievementsTopRankChange);
		Managers.Messenger.AddListener("ON_GVG_STORE_REFRESH_ITEMS", CheckGiftOfLordAchievementsGvGStoreItemsRefresh);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener("SOLDIER_UNLOCKED", delegate(string soldierId)
		{
			CheckSoldierUnlock(soldierId);
			CheckSoldierPotential(soldierId, 0);
		});
		Managers.Messenger.RemoveListener<string, int>("SOLDIER_EVOLUTED", CheckSoldierEvo);
		Managers.Messenger.RemoveListener<string, int>("SOLDIER_BREAKTHROUGH", CheckSoldierBreakthrough);
		Managers.Messenger.RemoveListener<string, int, int>("SOLDIER_LEVEL_CHANGED", CheckSoldierLevel);
		Managers.Messenger.RemoveListener<string, int>("SOLDIER_POTENTIAL_UPGRADED", CheckSoldierPotential);
		Managers.Messenger.RemoveListener<string, int>("SOLDIER_LEGEND_ITEM_SLOT_UNLOCKED", CheckSoldierSecondLegendItemSlot);
		Managers.Messenger.RemoveListener<string, int>("TECH_UPGRADED", CheckTechLevel);
		Managers.Messenger.RemoveListener<int>("USER_LEVEL_UP", CheckUserLevel);
		Managers.Messenger.RemoveListener<string, string>("GAME_PROGRESS_UPDATED", CheckLevelProgress);
		Managers.Messenger.RemoveListener<string, string>("STRONGHOLD_ASSIGNED_OCCUPANT", CheckStrongholdOccupant);
		Managers.Messenger.RemoveListener<int>("DUNGEON_LEVEL_UP", CheckDungeonLevel);
		Managers.Messenger.RemoveListener<float>("ON_RECHARGE", CheckTotalRecharge);
		Managers.Messenger.RemoveListener<string, int>("BUILDING_UPGRADED", CheckBuildings);
		Managers.Messenger.RemoveListener<string, int>("BUILDING_UPGRADED_USE_ITEM", CheckBuildings);
		Managers.Messenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", CheckStock);
		Managers.Messenger.RemoveListener<string, int>("ITEM_UPGRADE", CheckItemLevel);
		Managers.Messenger.RemoveListener<int>("LEGEND_ITEMS_CHANGED", CheckLegendItems);
		Managers.Messenger.RemoveListener<Mission>("MISSION_COMPLETE", CheckNewbieMissionsStatus);
		Managers.Messenger.RemoveListener<string>("FORMATION_UNLOCKED", CheckUnlockFormations);
		Managers.Messenger.RemoveListener<string>("FORMATION_LOCKED", CheckUnlockFormations);
		Managers.Messenger.RemoveListener("ON_GVG3_IZ_COMPLETED", CheckGiftOfLordAchievementsOnGvg3IzClose);
		Managers.Messenger.RemoveListener<int>("LEGEND_ITEMS_CHANGED", CheckGiftOfLordAchievementsOnLegendItemsChange);
		Managers.Messenger.RemoveListener("ON_BLUEPRINTS_CHANGE", CheckGiftOfLordAchievementsBlueprintsChange);
		Managers.Messenger.RemoveListener("ON_BLUEPRINTS_IDENTIFY", CheckGiftOfLordAchievementsBlueprintsIdentify);
		Managers.Messenger.RemoveListener<int>("PVP_RANK_UPDATE_PROGRESS", CheckGiftOfLordAchievementsTopRankChange);
		Managers.Messenger.RemoveListener("ON_GVG_STORE_REFRESH_ITEMS", CheckGiftOfLordAchievementsGvGStoreItemsRefresh);
	}

	private void CheckAchievementsStatus(IEnumerable<Achievement> achievements, bool use_cache = false)
	{
		List<Achievement> list = new List<Achievement>();
		List<AchievementCat> list2 = new List<AchievementCat>();
		foreach (Achievement achievement in achievements)
		{
			if (achievement.Status(Managers, use_cache) == AchievementStatus.PendingToClaim)
			{
				list.Add(achievement);
				if (!list2.Contains(achievement.Category))
				{
					list2.Add(achievement.Category);
				}
			}
		}
		if (use_cache)
		{
			Achievement.ClearCache_AchievementValue();
		}
		foreach (AchievementCat item in list2)
		{
			List<Achievement> achievementSummary = GetAchievementSummary(item);
			if (achievementSummary == null)
			{
				continue;
			}
			foreach (Achievement item2 in achievementSummary)
			{
				if (item2 != null && item2.Status(Managers) == AchievementStatus.PendingToClaim)
				{
					list.Add(item2);
				}
			}
		}
		if (list.Count > 0)
		{
			Managers.Messenger.Broadcast("ACHIEVEMENT_COMPLETE", list);
		}
	}

	public void AddActionOnGiftOfLordRewardsStatusChange(Action<bool> onChange)
	{
		_hasGiftOfLord.Value.AddAction(onChange);
	}

	public void RemoveActionOnGiftOfLordRewardsStatusChange(Action<bool> onChange)
	{
		_hasGiftOfLord.Value.RemoveAction(onChange);
	}

	public bool HasAnyPendingToClaimRewards()
	{
		List<Achievement> achievementsByCategory = GetAchievementsByCategory(AchievementCat.GiftOfLord);
		bool flag = HasPendingToClaimRewards(achievementsByCategory);
		UpdateGiftOfLordRewardsStatus(flag);
		return flag;
	}

	public void UpdateGiftOfLordEntranceRedDotOnClaimReward(AchievementType type)
	{
		switch (type)
		{
		case AchievementType.GvGJoined:
		case AchievementType.GvGCompleted:
			CheckGiftOfLordAchievementsOnGvg3IzClose();
			break;
		case AchievementType.LegendItemEnhanceLevelVariety:
		case AchievementType.LegendItemIdentifiedRarity:
			CheckGiftOfLordAchievementsStatus();
			break;
		case AchievementType.ArmsVariety:
			CheckGiftOfLordAchievementsOnSoldierUnlock();
			break;
		case AchievementType.OwnedBluePrint:
			CheckGiftOfLordAchievementsBlueprintsChange();
			break;
		case AchievementType.IdentifiedBluePrint:
			CheckGiftOfLordAchievementsBlueprintsIdentify();
			break;
		case AchievementType.PvPRank:
			CheckGiftOfLordAchievementsTopRankChange(0);
			break;
		case AchievementType.GvGStoreItemsRefresh:
			CheckGiftOfLordAchievementsGvGStoreItemsRefresh();
			break;
		case AchievementType.GvGRareStone:
			CheckGiftOfLordAchievementsGvGRareStone();
			break;
		}
	}

	private void CheckGiftOfLordAchievementsGvGRareStone()
	{
		List<Achievement> achievementsByType = GetAchievementsByType(AchievementType.GvGRareStone);
		CheckAchievementsStatus(achievementsByType);
		CheckGiftOfLordAchievementsStatus();
	}

	private void CheckGiftOfLordAchievementsGvGStoreItemsRefresh()
	{
		List<Achievement> achievementsByType = GetAchievementsByType(AchievementType.GvGStoreItemsRefresh);
		CheckAchievementsStatus(achievementsByType);
		CheckGiftOfLordAchievementsStatus();
	}

	private void CheckGiftOfLordAchievementsOnGvg3IzClose()
	{
		List<Achievement> achievementsByType = GetAchievementsByType(AchievementType.GvGJoined, AchievementType.GvGCompleted);
		CheckAchievementsStatus(achievementsByType);
		CheckGiftOfLordAchievementsStatus();
	}

	private void CheckGiftOfLordAchievementsOnLegendItemsChange(int type)
	{
		if (_giftOfLordLegendItemTypes.Contains((AchievementType)type))
		{
			CheckGiftOfLordAchievementsStatus();
		}
	}

	private void CheckGiftOfLordAchievementsOnSoldierUnlock()
	{
		CheckGiftOfLordAchievementsStatus();
	}

	private void CheckGiftOfLordAchievementsBlueprintsChange()
	{
		List<Achievement> achievementsByType = GetAchievementsByType(AchievementType.OwnedBluePrint);
		CheckAchievementsStatus(achievementsByType);
		CheckGiftOfLordAchievementsStatus();
	}

	private void CheckGiftOfLordAchievementsBlueprintsIdentify()
	{
		List<Achievement> achievementsByType = GetAchievementsByType(AchievementType.IdentifiedBluePrint);
		CheckAchievementsStatus(achievementsByType);
		CheckGiftOfLordAchievementsStatus();
	}

	private void CheckGiftOfLordAchievementsTopRankChange(int rank)
	{
		List<Achievement> achievementsByType = GetAchievementsByType(AchievementType.PvPRank);
		CheckAchievementsStatus(achievementsByType);
		CheckGiftOfLordAchievementsStatus();
	}

	private void CheckGiftOfLordAchievementsStatus()
	{
		List<Achievement> achievementsByCategory = GetAchievementsByCategory(AchievementCat.GiftOfLord);
		bool hasRewards = HasPendingToClaimRewards(achievementsByCategory);
		UpdateGiftOfLordRewardsStatus(hasRewards);
	}

	private bool HasPendingToClaimRewards(IEnumerable<Achievement> achievements)
	{
		return achievements.Any((Achievement achievement) => achievement.Status(Managers) == AchievementStatus.PendingToClaim);
	}

	private void UpdateGiftOfLordRewardsStatus(bool hasRewards)
	{
		_hasGiftOfLord.Value.Value = hasRewards;
	}

	private void CheckLevelProgress(string chapterId, string levelId)
	{
		CheckAchievementsStatus(GetAchievementsByType(AchievementType.RegionSize));
	}

	private void CheckStrongholdOccupant(string strongholdId, string soldierId)
	{
		CheckAchievementsStatus(GetAchievementsByType(AchievementType.AllStrongholdOccupiedByRegion));
	}

	private void CheckUserLevel(int level)
	{
		CheckAchievementsStatus(GetAchievementsByType(AchievementType.UserLevel));
	}

	private void CheckDungeonLevel(int level)
	{
		CheckAchievementsStatus(GetAchievementsByType(AchievementType.DungeonLevel));
	}

	private void CheckTechLevel(string techId, int level)
	{
		CheckAchievementsStatus(GetAchievementsByType(AchievementType.ArtifactPieces, AchievementType.DoomArtifactLevel, AchievementType.SlaveryArtifactLevel, AchievementType.DominionArtifactLevel, AchievementType.ArtifactPiecesUnlocked));
	}

	private void CheckSoldierLevel(string soldierId, int beforeLevel, int afterLevel)
	{
		CheckAchievementsStatus(GetAchievementsByType(AchievementType.SoldierLevel, AchievementType.SoldierLevelVariety));
	}

	private void CheckSoldierBreakthrough(string soldierId, int breakthroughLevel)
	{
		CheckAchievementsStatus(GetAchievementsByType(AchievementType.SoldierStars, AchievementType.SoldierStarsVariety));
	}

	private void CheckSoldierEvo(string soldierId, int evoLevel)
	{
		CheckAchievementsStatus(GetAchievementsByType(AchievementType.SoldierEvo, AchievementType.SoldierEvoVariety));
	}

	private void CheckSoldierPotential(string soldierId, int potentialLevel)
	{
		CheckAchievementsStatus(GetAchievementsByType(AchievementType.SoldierPotential, AchievementType.SoldierPotentialVariety));
	}

	private void CheckSoldierSecondLegendItemSlot(string soldierId, int slotIndex)
	{
		CheckAchievementsStatus(GetAchievementsByType(AchievementType.SoldierSecondLegendItemSlotUnlocked));
	}

	private void CheckSoldierUnlock(string soldierId)
	{
		CheckAchievementsStatus(GetAchievementsByType(AchievementType.SoldierUnlock, AchievementType.ArmsVariety));
		CheckGiftOfLordAchievementsOnSoldierUnlock();
	}

	private void CheckTotalRecharge(float rechargeCnt)
	{
		CheckAchievementsStatus(GetAchievementsByType(AchievementType.TotalRecharge, AchievementType.IntlTotalRecharge));
	}

	private void CheckBuildings(string buildingType, int level)
	{
		CheckAchievementsStatus(GetAchievementsByType(AchievementType.BuildingUnlocked, AchievementType.BuildingLevel, AchievementType.BuildingLevelVariety));
	}

	private void CheckStock(string itemId, int incr, (StockInContext, string) contextTuple)
	{
		if ("ManPower" == itemId)
		{
			CheckAchievementsStatus(GetAchievementsByType(AchievementType.Workers));
		}
		if (_rareStones.Contains(itemId) && incr > 0)
		{
			Managers.UserArchiveManager.AddGvGRareStone(incr);
			CheckGiftOfLordAchievementsGvGRareStone();
		}
	}

	private void CheckItemLevel(string itemId, int level)
	{
		CheckAchievementsStatus(GetAchievementsByType(AchievementType.WeaponLevel, AchievementType.WeaponLevelVariety));
	}

	private void CheckLegendItems(int type)
	{
		CheckAchievementsStatus(GetAchievementsByType((AchievementType)type));
	}

	public void CheckAchievementsByType(AchievementType type)
	{
		CheckAchievementsStatus(GetAchievementsByType(type));
	}

	private void CheckNewbieMissionsStatus(Mission mission)
	{
		AchievementType achievementType = (GameManagers.Instance.UserArchiveManager.IsForeignNewGuideMode() ? AchievementType.ForeignGuideMissionSummary : AchievementType.GuideMissionSummary);
		CheckAchievementsStatus(GetAchievementsByType(achievementType));
	}

	private void CheckUnlockFormations(string formationId)
	{
		CheckAchievementsStatus(GetAchievementsByType(AchievementType.FormationsUnlock));
	}

	public override Task Init()
	{
		CheckAchievementsStatus(Achievements.Values, use_cache: true);
		return null;
	}

	public static List<Achievement> GetAchievementsByCategory(params AchievementCat[] filterCategories)
	{
		List<Achievement> list = new List<Achievement>();
		foreach (AchievementCat key in filterCategories)
		{
			if (_categorizedAchievements.TryGetValue(key, out var value))
			{
				list.AddRange(value);
			}
		}
		return list;
	}

	public static List<Achievement> GetAchievementsByType(params AchievementType[] filterTypes)
	{
		List<Achievement> list = new List<Achievement>();
		foreach (AchievementType key in filterTypes)
		{
			if (_typifiedAchievements.TryGetValue(key, out var value))
			{
				list.AddRange(value);
			}
		}
		return list;
	}

	public static List<Achievement> GetAchievementSummary(AchievementCat category)
	{
		if (_achievementSummaries.TryGetValue(category, out var value))
		{
			return value;
		}
		return null;
	}
}
