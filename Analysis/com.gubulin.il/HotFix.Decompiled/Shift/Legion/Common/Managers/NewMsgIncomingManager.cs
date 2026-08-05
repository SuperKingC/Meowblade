using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameDataEditor;
using HotFix;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public sealed class NewMsgIncomingManager : Manager
{
	private Dictionary<string, Dictionary<string, int>> soldierPotentialUpgradeStockReq = new Dictionary<string, Dictionary<string, int>>();

	private Dictionary<string, Dictionary<string, int>> soldierEvoStockReq = new Dictionary<string, Dictionary<string, int>>();

	private Dictionary<string, Dictionary<string, int>> soldierEvoLevelReq = new Dictionary<string, Dictionary<string, int>>();

	private Dictionary<string, List<string>> soldierEvoReqToSoldiersDict = new Dictionary<string, List<string>>();

	private Dictionary<string, List<string>> soldierPotentialUpgradeReqToSoldiersDict = new Dictionary<string, List<string>>();

	private Dictionary<string, KeyValuePair<string, int>> piecesToUnlockDict = new Dictionary<string, KeyValuePair<string, int>>();

	private const string NewMsgIncomingRecordsKey = "NewMsgIncomingRecords";

	private Config<NewMsgIncomingConfig> _newMsgIncomingRecords;

	public List<string> NewUnlockedSoldiers = new List<string>();

	public List<string> SoldiersCanEvolute = new List<string>();

	public List<string> SoldiersCanUpgradePotential = new List<string>();

	public List<string> SoldiersCanUnlock = new List<string>();

	public Dictionary<AchievementCat, List<string>> PendingToClaimAchievements = new Dictionary<AchievementCat, List<string>>();

	private Dictionary<string, int> _cache_Stock = new Dictionary<string, int>();

	private bool _CacheDirty_AnySoldierHasNewPotentialProgress = true;

	private bool _Cache_AnySoldierHasNewPotentialProgress = false;

	private readonly List<Activity> _buffer = new List<Activity>();

	private bool _RedPoint_LegionsBtn = false;

	public Config<NewMsgIncomingConfig> NewMsgIncomingRecords
	{
		get
		{
			if (_newMsgIncomingRecords == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("NewMsgIncomingRecords"))
				{
					DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
					userArchiveManager.SetConfigValue("NewMsgIncomingRecords", new NewMsgIncomingConfig(dailyRefreshTime));
				}
				_newMsgIncomingRecords = userArchiveManager.GetConfig<NewMsgIncomingConfig>("NewMsgIncomingRecords");
			}
			return _newMsgIncomingRecords;
		}
	}

	public NewMsgIncomingManager(GameManagers managers)
		: base(managers)
	{
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		Managers.Messenger.AddListener<string, int>("ITEM_UPGRADE", OnItemEvo);
		Managers.Messenger.AddListener<string>("SOLDIER_UNLOCKED", OnSoldierUnlock);
		Managers.Messenger.AddListener<string, int>("SOLDIER_POTENTIAL_UPGRADED", OnSoldierPotentialUpgrade);
		Managers.Messenger.AddListener<string, int>("SOLDIER_EVOLUTED", OnSoldierEvolute);
		Managers.Messenger.AddListener<List<Achievement>>("ACHIEVEMENT_COMPLETE", OnAchievementsComplete);
		Managers.Messenger.AddListener<string>("ACHIEVEMENT_BONUS_CLAIMED", OnAchievementBonusClaimed);
		Managers.Messenger.AddListener<Mission>("MISSION_COMPLETE", OnMissionComplete);
		Managers.Messenger.AddListener<Order>("NEW_ORDER_STATS", OnOrderStats);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		Managers.Messenger.RemoveListener<string, int>("ITEM_UPGRADE", OnItemEvo);
		Managers.Messenger.RemoveListener<string>("SOLDIER_UNLOCKED", OnSoldierUnlock);
		Managers.Messenger.RemoveListener<string, int>("SOLDIER_POTENTIAL_UPGRADED", OnSoldierPotentialUpgrade);
		Managers.Messenger.RemoveListener<string, int>("SOLDIER_EVOLUTED", OnSoldierEvolute);
		Managers.Messenger.RemoveListener<List<Achievement>>("ACHIEVEMENT_COMPLETE", OnAchievementsComplete);
		Managers.Messenger.RemoveListener<string>("ACHIEVEMENT_BONUS_CLAIMED", OnAchievementBonusClaimed);
		Managers.Messenger.RemoveListener<Mission>("MISSION_COMPLETE", OnMissionComplete);
	}

	public override Task Init()
	{
		_cache_Stock = new Dictionary<string, int>();
		foreach (string unlockedSoldier in Managers.UserArchiveManager.GetUnlockedSoldiers())
		{
			Soldier soldier = Managers.SoldierManager.Get(unlockedSoldier);
			CheckSoldierCanEvolute(soldier, use_cache: true);
			CheckSoldierCanUpgradePotential(soldier, use_cache: true);
		}
		ClearCache_Stock();
		InitSoldierPiecesInfo();
		InitAchievementsInfo();
		CheckActivitiesHaveAnyNewMsg();
		EnsureCheckDate();
		return null;
	}

	private void ClearCache_Stock()
	{
		_cache_Stock.Clear();
	}

	private void CheckSoldierCanEvolute(Soldier soldier, bool use_cache = false)
	{
		Dictionary<string, int> evoRequirement = soldier.EvoRequirement;
		if (evoRequirement == null)
		{
			return;
		}
		bool canEvolute = true;
		foreach (KeyValuePair<string, int> item in evoRequirement)
		{
			if (!soldierEvoReqToSoldiersDict.ContainsKey(item.Key))
			{
				soldierEvoReqToSoldiersDict.Add(item.Key, new List<string>());
			}
			if (!soldierEvoReqToSoldiersDict[item.Key].Contains(soldier.Id))
			{
				soldierEvoReqToSoldiersDict[item.Key].Add(soldier.Id);
			}
			if (!soldierEvoStockReq.ContainsKey(soldier.Id))
			{
				soldierEvoStockReq.Add(soldier.Id, new Dictionary<string, int>());
			}
			if (!soldierEvoStockReq[soldier.Id].ContainsKey(item.Key))
			{
				soldierEvoStockReq[soldier.Id].Add(item.Key, 0);
			}
			int num = 0;
			if (use_cache)
			{
				if (!_cache_Stock.ContainsKey(item.Key))
				{
					_cache_Stock.Add(item.Key, Managers.StockController.GetStock(item.Key));
				}
				num = _cache_Stock[item.Key];
			}
			else
			{
				num = Managers.StockController.GetStock(item.Key);
			}
			if (item.Value > num)
			{
				canEvolute = false;
				soldierEvoStockReq[soldier.Id][item.Key] = item.Value - num;
			}
			else
			{
				soldierEvoStockReq[soldier.Id][item.Key] = 0;
			}
			if (Item.ItemType(item.Key) != 2)
			{
				continue;
			}
			int num2 = soldier.EvoLevel * 10 + 1;
			if (soldier.EvoLevel > 4)
			{
				num2 += (soldier.EvoLevel - 4) * 10;
			}
			if (Item.Level(Managers, item.Key) < num2)
			{
				canEvolute = false;
				if (!soldierEvoLevelReq.ContainsKey(soldier.Id))
				{
					soldierEvoLevelReq.Add(soldier.Id, new Dictionary<string, int>());
				}
				if (!soldierEvoLevelReq[soldier.Id].ContainsKey(item.Key))
				{
					soldierEvoLevelReq[soldier.Id].Add(item.Key, num2);
				}
				else
				{
					soldierEvoLevelReq[soldier.Id][item.Key] = num2;
				}
			}
		}
		UpdateSoldierCanEvolute(soldier.Id, canEvolute, clearChecked: true);
	}

	private void CheckSoldierCanUpgradePotential(Soldier soldier, bool use_cache = false)
	{
		Dictionary<string, int> dictionary = soldier.NextLevelPotential?.Requirements(Managers);
		if (dictionary == null)
		{
			return;
		}
		bool canUpgrade = true;
		foreach (KeyValuePair<string, int> item in dictionary)
		{
			if (!soldierPotentialUpgradeReqToSoldiersDict.ContainsKey(item.Key))
			{
				soldierPotentialUpgradeReqToSoldiersDict.Add(item.Key, new List<string>());
			}
			if (!soldierPotentialUpgradeReqToSoldiersDict[item.Key].Contains(soldier.Id))
			{
				soldierPotentialUpgradeReqToSoldiersDict[item.Key].Add(soldier.Id);
			}
			if (!soldierPotentialUpgradeStockReq.ContainsKey(soldier.Id))
			{
				soldierPotentialUpgradeStockReq.Add(soldier.Id, new Dictionary<string, int>());
			}
			if (!soldierPotentialUpgradeStockReq[soldier.Id].ContainsKey(item.Key))
			{
				soldierPotentialUpgradeStockReq[soldier.Id].Add(item.Key, 0);
			}
			int num = 0;
			if (use_cache)
			{
				if (!_cache_Stock.ContainsKey(item.Key))
				{
					_cache_Stock.Add(item.Key, Managers.StockController.GetStock(item.Key));
				}
				num = _cache_Stock[item.Key];
			}
			else
			{
				num = Managers.StockController.GetStock(item.Key);
			}
			if (item.Value > num)
			{
				canUpgrade = false;
				soldierPotentialUpgradeStockReq[soldier.Id][item.Key] = item.Value - num;
			}
			else
			{
				soldierPotentialUpgradeStockReq[soldier.Id][item.Key] = 0;
			}
		}
		UpdateSoldierCanUpgradePotential(soldier.Id, canUpgrade, clearChecked: true);
	}

	private void InitSoldierPiecesInfo()
	{
		IEnumerable<GDEPiecesData> allItems = GDMgr.GetAllItems<GDEPiecesData>();
		List<string> list = new List<string>();
		foreach (GDEPiecesData item in allItems)
		{
			list.Add(item.Key);
		}
		if (list == null || list.Count == 0)
		{
			return;
		}
		List<string> unlockedSoldiers = Managers.UserArchiveManager.GetUnlockedSoldiers();
		foreach (Pieces item2 in ConfigDataManager.GetPiecesDataByType(PiecesType.SoldierPieces))
		{
			if (unlockedSoldiers.Contains(item2.RelativeContext))
			{
				piecesToUnlockDict.Remove(item2.ItemId);
			}
			else if (!piecesToUnlockDict.ContainsKey(item2.ItemId))
			{
				if (Managers.StockController.GetStock(item2.ItemId) < item2.CompositeRequirement)
				{
					piecesToUnlockDict.Add(item2.ItemId, new KeyValuePair<string, int>(item2.RelativeContext, item2.CompositeRequirement));
				}
				else
				{
					SoldiersCanUnlock.Add(item2.RelativeContext);
				}
			}
		}
	}

	private void InitAchievementsInfo()
	{
		foreach (Achievement value in AchievementManager.Achievements.Values)
		{
			if (value.Category > AchievementCat.Unknown && value.Status(Managers, use_cache: true) == AchievementStatus.PendingToClaim)
			{
				if (!PendingToClaimAchievements.ContainsKey(value.Category))
				{
					PendingToClaimAchievements.Add(value.Category, new List<string>());
				}
				if (!PendingToClaimAchievements[value.Category].Contains(value.AchievementId))
				{
					PendingToClaimAchievements[value.Category].Add(value.AchievementId);
				}
			}
		}
		Achievement.ClearCache_AchievementValue();
	}

	private void CheckActivitiesHaveAnyNewMsg()
	{
		if (_newMsgIncomingRecords == null)
		{
			return;
		}
		foreach (Activity value in ActivityManager.Activities.Values)
		{
			foreach (KeyValuePair<string, ActivityContentPayload> item in value.ContentPayload(Managers))
			{
				if (item.Value is MissionSerialActivityPayload)
				{
					((MissionSerialActivityPayload)item.Value).FlushCache();
					CheckActivityContent(value.ActivityId, item.Key);
				}
			}
		}
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) contextTuple)
	{
		if (soldierEvoReqToSoldiersDict.TryGetValue(itemId, out var value))
		{
			foreach (string item in value)
			{
				if (incr < 0)
				{
					Soldier soldier = Managers.SoldierManager.Get(item);
					CheckSoldierCanEvolute(soldier);
					continue;
				}
				bool flag = true;
				if (soldierEvoStockReq.TryGetValue(item, out var value2))
				{
					value2[itemId] -= incr;
					flag = isStockEnough(value2);
				}
				if (soldierEvoLevelReq.TryGetValue(item, out var value3))
				{
					UpdateSoldierCanEvolute(item, flag && isLevelMatched(value3));
				}
			}
		}
		if (soldierPotentialUpgradeReqToSoldiersDict.TryGetValue(itemId, out var value4))
		{
			foreach (string item2 in value4)
			{
				if (incr < 0)
				{
					Soldier soldier2 = Managers.SoldierManager.Get(item2);
					CheckSoldierCanUpgradePotential(soldier2);
					continue;
				}
				bool canUpgrade = true;
				if (soldierPotentialUpgradeStockReq.TryGetValue(item2, out var value5))
				{
					value5[itemId] -= incr;
					canUpgrade = isStockEnough(value5);
				}
				UpdateSoldierCanUpgradePotential(item2, canUpgrade);
			}
		}
		UpdateSoldierPieces(itemId, Managers.StockController.GetStock(itemId));
	}

	private void OnMissionComplete(Mission _)
	{
		CheckActivitiesHaveAnyNewMsg();
	}

	private void OnOrderStats(Order order)
	{
		foreach (Activity value in ActivityManager.Activities.Values)
		{
			foreach (KeyValuePair<string, ActivityContentPayload> item in value.ContentPayload(Managers))
			{
				if (!(item.Value is MissionSerialActivityPayload missionSerialActivityPayload))
				{
					continue;
				}
				foreach (KeyValuePair<int, List<Shift.Legion.Common.Models.Store.StoreItem>> allBonusStoreItem in missionSerialActivityPayload.GetAllBonusStoreItems(Managers))
				{
					if (allBonusStoreItem.Key > missionSerialActivityPayload.TotalCompletedMissions(Managers))
					{
						continue;
					}
					using List<Shift.Legion.Common.Models.Store.StoreItem>.Enumerator enumerator4 = allBonusStoreItem.Value.GetEnumerator();
					if (enumerator4.MoveNext())
					{
						Shift.Legion.Common.Models.Store.StoreItem current3 = enumerator4.Current;
						missionSerialActivityPayload.FlushCache();
					}
				}
			}
		}
	}

	private void OnItemEvo(string itemId, int level)
	{
		if (!soldierEvoReqToSoldiersDict.TryGetValue(itemId, out var value))
		{
			return;
		}
		foreach (string item in value)
		{
			bool flag = true;
			if (soldierEvoLevelReq.TryGetValue(item, out var value2) && value2.TryGetValue(itemId, out var value3))
			{
				if (level >= value3)
				{
					value2.Remove(itemId);
				}
				flag = isLevelMatched(value2);
			}
			UpdateSoldierCanEvolute(item, flag && (!soldierEvoStockReq.TryGetValue(item, out var value4) || isStockEnough(value4)), clearChecked: true);
		}
	}

	private void OnSoldierUnlock(string soldierId)
	{
		Soldier soldier = Managers.SoldierManager.Get(soldierId);
		CheckSoldierCanEvolute(soldier);
		CheckSoldierCanUpgradePotential(soldier);
		UpdateNewUnlockedSoldiers(soldierId);
	}

	private void OnSoldierEvolute(string soldierId, int evoLevel)
	{
		Soldier soldier = Managers.SoldierManager.Get(soldierId);
		CheckSoldierCanEvolute(soldier);
	}

	private void OnSoldierPotentialUpgrade(string soldierId, int potentialLevel)
	{
		Soldier soldier = Managers.SoldierManager.Get(soldierId);
		CheckSoldierCanUpgradePotential(soldier);
	}

	private void OnAchievementsComplete(List<Achievement> achievements)
	{
		if (_newMsgIncomingRecords == null)
		{
			return;
		}
		Dictionary<AchievementCat, List<string>> pendingToClaimAchievements = PendingToClaimAchievements;
		foreach (Achievement achievement in achievements)
		{
			if (achievement.Status(Managers) == AchievementStatus.PendingToClaim)
			{
				if (!pendingToClaimAchievements.ContainsKey(achievement.Category))
				{
					pendingToClaimAchievements.Add(achievement.Category, new List<string>());
				}
				if (!pendingToClaimAchievements[achievement.Category].Contains(achievement.AchievementId))
				{
					pendingToClaimAchievements[achievement.Category].Add(achievement.AchievementId);
				}
			}
		}
	}

	private void OnAchievementBonusClaimed(string achievementId)
	{
		if (_newMsgIncomingRecords != null)
		{
			Dictionary<AchievementCat, List<string>> pendingToClaimAchievements = PendingToClaimAchievements;
			if (AchievementManager.Achievements.TryGetValue(achievementId, out var value) && pendingToClaimAchievements.TryGetValue(value.Category, out var value2))
			{
				value2.Remove(achievementId);
			}
		}
	}

	private bool isStockEnough(Dictionary<string, int> requirements)
	{
		foreach (KeyValuePair<string, int> requirement in requirements)
		{
			if (requirement.Value <= 0)
			{
				continue;
			}
			return false;
		}
		return true;
	}

	private bool isLevelMatched(Dictionary<string, int> requirements)
	{
		return requirements.Count <= 0;
	}

	private void UpdateNewUnlockedSoldiers(string soldierId)
	{
		if (!NewUnlockedSoldiers.Contains(soldierId))
		{
			NewUnlockedSoldiers.Add(soldierId);
		}
		SoldiersCanUnlock.Remove(soldierId);
		NewMsgIncomingRecords.GetValue().SoldiersCanUnlockChecked.Remove(soldierId);
	}

	private void UpdateSoldierPieces(string pieceId, int piecesStock)
	{
		if (piecesToUnlockDict.TryGetValue(pieceId, out var value))
		{
			if (piecesStock < value.Value)
			{
				SoldiersCanUnlock.Remove(value.Key);
				NewMsgIncomingRecords.GetValue().SoldiersCanUnlockChecked.Remove(value.Key);
			}
			else if (!SoldiersCanUnlock.Contains(value.Key))
			{
				SoldiersCanUnlock.Add(value.Key);
			}
		}
	}

	private void UpdateSoldierCanEvolute(string soldierId, bool canEvolute, bool clearChecked = false)
	{
		NewMsgIncomingConfig value = NewMsgIncomingRecords.GetValue();
		List<string> soldiersCanEvolute = SoldiersCanEvolute;
		if (canEvolute)
		{
			if (!soldiersCanEvolute.Contains(soldierId))
			{
				soldiersCanEvolute.Add(soldierId);
			}
			if (clearChecked && value.SoldiersCanEvoluteChecked.Contains(soldierId))
			{
				value.SoldiersCanEvoluteChecked.Remove(soldierId);
			}
		}
		else if (soldiersCanEvolute.Contains(soldierId))
		{
			soldiersCanEvolute.Remove(soldierId);
			value.SoldiersCanEvoluteChecked.Remove(soldierId);
		}
	}

	private void UpdateSoldierCanUpgradePotential(string soldierId, bool canUpgrade, bool clearChecked = false)
	{
		List<string> soldiersCanUpgradePotential = SoldiersCanUpgradePotential;
		NewMsgIncomingConfig value = NewMsgIncomingRecords.GetValue();
		if (canUpgrade)
		{
			if (!soldiersCanUpgradePotential.Contains(soldierId))
			{
				soldiersCanUpgradePotential.Add(soldierId);
			}
			if (clearChecked && value.SoldiersCanUpgradePotentialChecked.Contains(soldierId))
			{
				value.SoldiersCanUpgradePotentialChecked.Remove(soldierId);
			}
		}
		else if (soldiersCanUpgradePotential.Contains(soldierId))
		{
			soldiersCanUpgradePotential.Remove(soldierId);
			value.SoldiersCanUpgradePotentialChecked.Remove(soldierId);
		}
	}

	public bool AnySoldierHasNewMsg(bool flush = false)
	{
		NewMsgIncomingConfig value = NewMsgIncomingRecords.GetValue();
		if (flush)
		{
			FlushCache_AnySoldierHasNewPotentialProgress();
		}
		if (_CacheDirty_AnySoldierHasNewPotentialProgress)
		{
			_CacheDirty_AnySoldierHasNewPotentialProgress = false;
			_Cache_AnySoldierHasNewPotentialProgress = CheckAllSoldierHasNewPotentialProgress().Count > 0;
		}
		return NewUnlockedSoldiers.Count > 0 || SoldiersCanEvolute.Count > value.SoldiersCanEvoluteChecked.Count || SoldiersCanUpgradePotential.Count > value.SoldiersCanUpgradePotentialChecked.Count || _Cache_AnySoldierHasNewPotentialProgress;
	}

	public void FlushCache_AnySoldierHasNewPotentialProgress()
	{
		_CacheDirty_AnySoldierHasNewPotentialProgress = true;
	}

	public bool AnySoldierPieceHasNewMsg()
	{
		NewMsgIncomingConfig value = NewMsgIncomingRecords.GetValue();
		return SoldiersCanUnlock.Count > value.SoldiersCanUnlockChecked.Count;
	}

	public List<string> CheckAllSoldierHasNewPotentialProgress()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, int> ownedSoldier in Managers.StockController.GetOwnedSoldiers())
		{
			Soldier soldier = Managers.SoldierManager.Get(ownedSoldier.Key);
			if (soldier.HasNewPotentialProgress(flush: true))
			{
				list.Add(soldier.Id);
			}
		}
		return list;
	}

	public bool SoldierIsNewUnlocked(string soldierId)
	{
		return NewUnlockedSoldiers.Contains(soldierId);
	}

	public bool SoldierHasNewMsg(string soldierId)
	{
		NewMsgIncomingConfig value = NewMsgIncomingRecords.GetValue();
		return (SoldiersCanEvolute.Contains(soldierId) && !value.SoldiersCanEvoluteChecked.Contains(soldierId)) || (SoldiersCanUpgradePotential.Contains(soldierId) && !value.SoldiersCanUpgradePotentialChecked.Contains(soldierId)) || Managers.SoldierManager.Get(soldierId).HasNewPotentialProgress();
	}

	public bool SoldierPieceHasNewMsg(string soldierId)
	{
		NewMsgIncomingConfig value = NewMsgIncomingRecords.GetValue();
		return SoldiersCanUnlock.Contains(soldierId) && !value.SoldiersCanUnlockChecked.Contains(soldierId);
	}

	public void SoldierChecked(string soldierId)
	{
		NewUnlockedSoldiers.Remove(soldierId);
		NewMsgIncomingConfig value = NewMsgIncomingRecords.GetValue();
		if (SoldiersCanEvolute.Contains(soldierId) && !value.SoldiersCanEvoluteChecked.Contains(soldierId))
		{
			value.SoldiersCanEvoluteChecked.Add(soldierId);
		}
		if (SoldiersCanUpgradePotential.Contains(soldierId) && !value.SoldiersCanUpgradePotentialChecked.Contains(soldierId))
		{
			value.SoldiersCanUpgradePotentialChecked.Add(soldierId);
		}
	}

	public void SoldierPieceChecked(string soldierId)
	{
		NewMsgIncomingConfig value = NewMsgIncomingRecords.GetValue();
		if (SoldiersCanUnlock.Contains(soldierId) && !value.SoldiersCanUnlockChecked.Contains(soldierId))
		{
			value.SoldiersCanUnlockChecked.Add(soldierId);
		}
	}

	public bool HasAnyAchievementToClaim()
	{
		foreach (KeyValuePair<AchievementCat, List<string>> pendingToClaimAchievement in PendingToClaimAchievements)
		{
			if (pendingToClaimAchievement.Key == AchievementCat.Unknown || pendingToClaimAchievement.Value.Count <= 0)
			{
				continue;
			}
			return true;
		}
		return false;
	}

	public bool HasAchievementsPendingToClaimByCategory(AchievementCat category)
	{
		List<string> value;
		return PendingToClaimAchievements.TryGetValue(category, out value) && value.Count > 0;
	}

	public bool BuildingTipCanRepair(string buildingType)
	{
		Building buildingByType = Managers.BuildingManager.GetBuildingByType(buildingType);
		if (buildingByType == null)
		{
			return false;
		}
		return buildingByType.Level == 0 && buildingByType.CanUpgrade() && !NewMsgIncomingRecords.GetValue().BuildingChecked.Contains(buildingType);
	}

	public bool HasAnyBuildingsToAccept()
	{
		foreach (Building value in Managers.BuildingManager.Buildings.Values)
		{
			if (value.Status == BuildingStatus.Ready)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasAnyBuildingToUpgrade()
	{
		foreach (Building value in Managers.BuildingManager.Buildings.Values)
		{
			if (value.CanUpgrade())
			{
				return true;
			}
		}
		return false;
	}

	public bool HasAnyBlackMarketActivityWithNewMsg()
	{
		List<Activity> list = new List<Activity>();
		List<Activity> activitiesByType = Managers.ActivityManager.GetActivitiesByType(ActivityType.Lottery, _buffer);
		if (activitiesByType != null)
		{
			list.AddRange(activitiesByType);
		}
		List<Activity> activitiesByType2 = Managers.ActivityManager.GetActivitiesByType(ActivityType.BlackMarket, _buffer);
		if (activitiesByType2 != null)
		{
			list.AddRange(activitiesByType2);
		}
		foreach (Activity item in list)
		{
			if (item.HasAnyNewMsg(Managers))
			{
				return true;
			}
		}
		return false;
	}

	public bool HasAnyHomePageActivityWithNewMsg()
	{
		List<Activity> activitiesByType = Managers.ActivityManager.GetActivitiesByType(ActivityType.HomePageActivity, _buffer);
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			activitiesByType.AddRange(GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.IntlRechargeStatsSubstitute));
		}
		string text = HotUpdateProcess.Instance.Configs["SpecialActivities"];
		if (activitiesByType == null)
		{
			return false;
		}
		foreach (Activity item in activitiesByType)
		{
			if ((!GameManagers.Instance.UserArchiveManager.IsForeignNewGuideMode() || !(item.ActivityId == "MissionsOf7Days1")) && !text.Contains(item.ActivityId) && item.HasAnyNewMsg(Managers))
			{
				return true;
			}
		}
		return false;
	}

	public bool HasNewTechPoint()
	{
		return Managers.StockController.GetStock("TechPoint") > NewMsgIncomingRecords.GetValue().LastCheckTechPoint;
	}

	public void CheckNewTechPoint()
	{
		NewMsgIncomingRecords.GetValue().LastCheckTechPoint = Managers.StockController.GetStock("TechPoint");
		NewMsgIncomingRecords.Save();
	}

	public void EnsureCheckDate()
	{
		NewMsgIncomingConfig value = NewMsgIncomingRecords.GetValue();
		DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
		if (dailyRefreshTime.CompareTo(value.LastCheckDate) == 1)
		{
			value.NewUnlockedSoldiers.Clear();
			value.SoldiersCanEvoluteChecked.Clear();
			value.SoldiersCanUpgradePotentialChecked.Clear();
			value.SoldiersCanUnlockChecked.Clear();
			value.RegionHasStrongholdWithoutOccupantChecked.Clear();
			value.BuildingChecked.Clear();
			value.ActivityContentChecked.Clear();
			value.LastCheckDate = dailyRefreshTime;
			NewMsgIncomingRecords.Save();
			Managers.Messenger.Broadcast("NEW_MSG_INCOMING_CLEAR_CHECKED");
		}
	}

	public bool HasAnyNewUnlockedRegion()
	{
		Dictionary<string, Region> regions = WorldMapManager.Regions;
		foreach (Region value in regions.Values)
		{
			if (value.Status(Managers) == RegionStatus.Unlocked)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasAnyRegionWithNewMsg()
	{
		Dictionary<string, Region> regions = WorldMapManager.Regions;
		foreach (Region value in regions.Values)
		{
			if (value.Status(Managers) == RegionStatus.Unlocked || HasAnyRegionWithoutStrongholdOccupant(value.RegionId))
			{
				return true;
			}
		}
		return false;
	}

	public bool HasAnyRegionWithoutStrongholdOccupant(string regionId)
	{
		Dictionary<string, Region> regions = WorldMapManager.Regions;
		if (!regions.TryGetValue(regionId, out var value))
		{
			return false;
		}
		if (value.Status(Managers) != RegionStatus.Occupied)
		{
			return false;
		}
		foreach (Stronghold stronghold in value.Strongholds)
		{
			if (!stronghold.IsOccupied(Managers))
			{
				return true;
			}
		}
		return false;
	}

	public void CheckRegion(string regionId)
	{
		NewMsgIncomingConfig value = NewMsgIncomingRecords.GetValue();
		if (!value.RegionHasStrongholdWithoutOccupantChecked.Contains(regionId))
		{
			value.RegionHasStrongholdWithoutOccupantChecked.Add(regionId);
		}
		NewMsgIncomingRecords.Save();
	}

	public void CheckBuilding(string buildingType)
	{
		Building buildingByType = Managers.BuildingManager.GetBuildingByType(buildingType);
		if (buildingByType != null && buildingByType.HasAnyInform())
		{
			NewMsgIncomingConfig value = NewMsgIncomingRecords.GetValue();
			if (!value.BuildingChecked.Contains(buildingType))
			{
				value.BuildingChecked.Add(buildingType);
			}
			if (!value.BuildingMaxLevelChecked.ContainsKey(buildingType))
			{
				value.BuildingMaxLevelChecked.Add(buildingType, Managers.UserArchiveManager.GetBuildingMaxLevel(buildingType));
			}
			else
			{
				value.BuildingMaxLevelChecked[buildingType] = Managers.UserArchiveManager.GetBuildingMaxLevel(buildingType);
			}
			NewMsgIncomingRecords.Save();
		}
	}

	public void CheckActivityContent(string activityId, string pageName)
	{
		if (!ActivityManager.Activities.TryGetValue(activityId, out var value) || !value.ContentPayload(Managers).TryGetValue(pageName, out var value2))
		{
			return;
		}
		if (value.ActivityProgress(Managers).IsNew)
		{
			value.ActivityProgress(Managers).IsNew = false;
			Managers.UserArchiveManager.SetActivityProgress(value.ActivityProgress(Managers));
		}
		if (!value2.HasAnyNewMsg(Managers))
		{
			return;
		}
		bool flag = false;
		NewMsgIncomingConfig value3 = NewMsgIncomingRecords.GetValue();
		if (!value3.ActivityContentChecked.ContainsKey(activityId))
		{
			value3.ActivityContentChecked.Add(activityId, new List<string>());
			flag = true;
		}
		if (!value3.ActivityContentChecked[activityId].Contains(pageName))
		{
			value3.ActivityContentChecked[activityId].Add(pageName);
			flag = true;
		}
		if (value2 is StoreActivityPayload storeActivityPayload)
		{
			if (!value3.LastCheckStoreItemList.ContainsKey(activityId))
			{
				value3.LastCheckStoreItemList.Add(activityId, new Dictionary<string, List<string>>());
			}
			if (!value3.LastCheckStoreItemList[activityId].ContainsKey(pageName))
			{
				value3.LastCheckStoreItemList[activityId].Add(pageName, new List<string>());
			}
			value3.LastCheckStoreItemList[activityId][pageName].Clear();
			value3.LastCheckStoreItemList[activityId][pageName].AddRange(storeActivityPayload.StoreItems(Managers).Keys);
			flag = true;
		}
		if (flag)
		{
			NewMsgIncomingRecords.Save();
		}
	}

	public void TurnOn_LegionsBtn()
	{
		_RedPoint_LegionsBtn = true;
	}

	public void TurnOff_LegionsBtn()
	{
		_RedPoint_LegionsBtn = false;
	}

	public bool GetLegionsBtn()
	{
		return _RedPoint_LegionsBtn;
	}
}
