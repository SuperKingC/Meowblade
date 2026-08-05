using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataEditor;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class ConfigDataManager : Manager
{
	public static class LevelBonuses
	{
		public static bool Bonuses_TryGetValue(string key, out string config)
		{
			if (_levelBonuses == null)
			{
				_levelBonuses = new Dictionary<string, string>();
			}
			if (!_levelBonuses.ContainsKey(key))
			{
				GDELevelAssistanceData gDELevelAssistanceData = null;
				if (GDMgr.Has<GDELevelAssistanceData>("LevelAssistance_" + key) && GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
				{
					gDELevelAssistanceData = GDMgr.Get<GDELevelAssistanceData>("LevelAssistance_" + key);
				}
				if (gDELevelAssistanceData != null)
				{
					if (!string.IsNullOrEmpty(gDELevelAssistanceData.Unlock))
					{
						_levelBonuses[key] = gDELevelAssistanceData.Unlock;
					}
					if (!string.IsNullOrEmpty(gDELevelAssistanceData.Bonus))
					{
						_levelBonuses[key] = gDELevelAssistanceData.Bonus;
					}
				}
				else
				{
					GDELevelBonusData gDELevelBonusData = GDMgr.Get<GDELevelBonusData>("LBONUS_" + key);
					if (!string.IsNullOrEmpty(gDELevelBonusData.Unlock))
					{
						_levelBonuses[key] = gDELevelBonusData.Unlock;
					}
					if (!string.IsNullOrEmpty(gDELevelBonusData.Bonus))
					{
						_levelBonuses[key] = gDELevelBonusData.Bonus;
					}
				}
			}
			config = _levelBonuses[key];
			return true;
		}

		public static bool RepeatBonuses_TryGetValue(string key, out string config)
		{
			if (_levelRepeatBonuses == null)
			{
				_levelRepeatBonuses = new Dictionary<string, string>();
			}
			if (!_levelRepeatBonuses.ContainsKey(key))
			{
				GDELevelAssistanceData gDELevelAssistanceData = null;
				if (GDMgr.Has<GDELevelAssistanceData>("LevelAssistance_" + key) && GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
				{
					gDELevelAssistanceData = GDMgr.Get<GDELevelAssistanceData>("LevelAssistance_" + key);
				}
				if (gDELevelAssistanceData != null && !string.IsNullOrEmpty(gDELevelAssistanceData.RepeatBonus))
				{
					_levelRepeatBonuses[key] = gDELevelAssistanceData.RepeatBonus;
				}
				else
				{
					GDELevelBonusData gDELevelBonusData = GDMgr.Get<GDELevelBonusData>("LBONUS_" + key);
					if (string.IsNullOrEmpty(gDELevelBonusData.RepeatBonus))
					{
						config = null;
						return false;
					}
					_levelRepeatBonuses[gDELevelBonusData.LevelId] = gDELevelBonusData.RepeatBonus;
				}
			}
			config = _levelRepeatBonuses[key];
			return true;
		}

		public static bool Lottery_TryGetValue(string key, out string config)
		{
			if (_levelLottery == null)
			{
				_levelLottery = new Dictionary<string, string>();
			}
			if (!_levelLottery.ContainsKey(key))
			{
				GDELevelAssistanceData gDELevelAssistanceData = null;
				if (GDMgr.Has<GDELevelAssistanceData>("LevelAssistance_" + key) && GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
				{
					gDELevelAssistanceData = GDMgr.Get<GDELevelAssistanceData>("LevelAssistance_" + key);
				}
				if (gDELevelAssistanceData != null && !string.IsNullOrEmpty(gDELevelAssistanceData.Lottery))
				{
					_levelLottery[key] = gDELevelAssistanceData.Lottery;
				}
				else
				{
					GDELevelBonusData gDELevelBonusData = GDMgr.Get<GDELevelBonusData>("LBONUS_" + key);
					if (string.IsNullOrEmpty(gDELevelBonusData.Lottery))
					{
						config = null;
						return false;
					}
					_levelLottery[gDELevelBonusData.LevelId] = gDELevelBonusData.Lottery;
				}
			}
			config = _levelLottery[key];
			return true;
		}

		public static bool RepeatLottery_TryGetValue(string key, out string config)
		{
			if (_levelRepeatLottery == null)
			{
				_levelRepeatLottery = new Dictionary<string, string>();
			}
			if (!_levelRepeatLottery.ContainsKey(key))
			{
				GDELevelAssistanceData gDELevelAssistanceData = null;
				string key2 = "LevelAssistance_" + key;
				if (GDMgr.Has<GDELevelAssistanceData>(key2) && GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
				{
					gDELevelAssistanceData = GDMgr.Get<GDELevelAssistanceData>(key2);
				}
				if (gDELevelAssistanceData != null && !string.IsNullOrEmpty(gDELevelAssistanceData.RepeatLottery))
				{
					_levelRepeatLottery[key] = gDELevelAssistanceData.RepeatLottery;
				}
				else
				{
					GDELevelBonusData gDELevelBonusData = GDMgr.Get<GDELevelBonusData>("LBONUS_" + key);
					if (string.IsNullOrEmpty(gDELevelBonusData.RepeatLottery))
					{
						config = null;
						return false;
					}
					_levelRepeatLottery[gDELevelBonusData.LevelId] = gDELevelBonusData.RepeatLottery;
				}
			}
			config = _levelRepeatLottery[key];
			return true;
		}
	}

	private static Dictionary<string, EnemyTemplatePool> _enemyTemplatePools;

	private static Dictionary<ItemType, List<string>> _itemsByType;

	private static Dictionary<PiecesType, List<Pieces>> _piecesDataByType;

	private static Dictionary<string, Pieces> _soldierPiecesData;

	private static Dictionary<string, Dictionary<int, SoldierPotentialData>> _soldierPotentialDataDict;

	private static Dictionary<string, Dictionary<int, SoldierEvoData>> _soldierEvoData;

	private Dictionary<int, UserExpData> m_userExpData;

	private Dictionary<int, DungeonExpData> m_dungeonExpData;

	private Dictionary<string, Dictionary<int, int>> buildingMaxLevelRequiredUserLevelDict;

	private Dictionary<string, Dictionary<int, int>> itemMaxLevelRequiredUserLevelDict;

	private Dictionary<int, int> soldierMaxEvoLevelRequiredUserLevelDict;

	private Dictionary<int, int> soldierMaxBreakthroughLevelRequiredUserLevelDict;

	private Dictionary<int, int> formationSlotUnlockRequiredUserLevelDict;

	private Dictionary<int, int> invitingSlotUnlockRequiredUserLevelDict;

	private static Dictionary<string, ProductEvoData> _productEvoData;

	private static Dictionary<string, string> _levelBonuses;

	private static Dictionary<string, string> _levelRepeatBonuses;

	private static Dictionary<string, string> _levelLottery;

	private static Dictionary<string, string> _levelRepeatLottery;

	private const string VolunteersOnSoldierUnlockKey = "VOLUNTEERS_ON_SOLDIER_UNLOCK";

	private static int _volunteersOnSoldierUnlock = -1;

	public static Dictionary<string, EnemyTemplatePool> EnemyTemplatePools
	{
		get
		{
			if (_enemyTemplatePools == null)
			{
				_enemyTemplatePools = new Dictionary<string, EnemyTemplatePool>();
				foreach (GDEEnemyTemplatePoolData allItem in GDMgr.GetAllItems<GDEEnemyTemplatePoolData>())
				{
					if (!_enemyTemplatePools.TryGetValue(allItem.PoolId, out var value))
					{
						value = new EnemyTemplatePool
						{
							PoolId = allItem.PoolId
						};
						_enemyTemplatePools.Add(value.PoolId, value);
					}
					value.AddTemplate(allItem);
				}
			}
			return _enemyTemplatePools;
		}
	}

	public static Dictionary<ItemType, List<string>> ItemsByType
	{
		get
		{
			if (_itemsByType == null)
			{
				_itemsByType = new Dictionary<ItemType, List<string>>();
				foreach (GDEItemData allItem in GDMgr.GetAllItems<GDEItemData>())
				{
					ItemType itemType = (ItemType)allItem.ItemType;
					if (!_itemsByType.ContainsKey(itemType))
					{
						_itemsByType.Add(itemType, new List<string>());
					}
					_itemsByType[itemType].Add(allItem.Key);
				}
			}
			return _itemsByType;
		}
	}

	public static Dictionary<PiecesType, List<Pieces>> PiecesDataByType
	{
		get
		{
			if (_piecesDataByType == null)
			{
				EnsurePiecesData();
			}
			return _piecesDataByType;
		}
	}

	public static Dictionary<string, Pieces> SoldierPiecesData
	{
		get
		{
			if (_soldierPiecesData == null)
			{
				EnsurePiecesData();
			}
			return _soldierPiecesData;
		}
	}

	public static Dictionary<string, Dictionary<int, SoldierPotentialData>> SoldierPotentialDataDict
	{
		get
		{
			if (_soldierPotentialDataDict == null)
			{
				_soldierPotentialDataDict = new Dictionary<string, Dictionary<int, SoldierPotentialData>>();
				foreach (GDESoldierPotentialData allItem in GDMgr.GetAllItems<GDESoldierPotentialData>())
				{
					SoldierPotentialData soldierPotentialData = new SoldierPotentialData(allItem);
					if (!_soldierPotentialDataDict.ContainsKey(soldierPotentialData.SoldierId))
					{
						_soldierPotentialDataDict.Add(soldierPotentialData.SoldierId, new Dictionary<int, SoldierPotentialData>());
					}
					_soldierPotentialDataDict[soldierPotentialData.SoldierId].Add(soldierPotentialData.Level, soldierPotentialData);
				}
			}
			return _soldierPotentialDataDict;
		}
	}

	public static Dictionary<string, Dictionary<int, SoldierEvoData>> SoldierEvoData
	{
		get
		{
			if (_soldierEvoData == null)
			{
				_soldierEvoData = new Dictionary<string, Dictionary<int, SoldierEvoData>>();
				foreach (GDESoldierEvoData allItem in GDMgr.GetAllItems<GDESoldierEvoData>())
				{
					SoldierEvoData soldierEvoData = new SoldierEvoData(allItem);
					if (!_soldierEvoData.ContainsKey(soldierEvoData.SoldierId))
					{
						_soldierEvoData.Add(soldierEvoData.SoldierId, new Dictionary<int, SoldierEvoData>());
					}
					_soldierEvoData[soldierEvoData.SoldierId].Add(soldierEvoData.Level, soldierEvoData);
				}
			}
			return _soldierEvoData;
		}
	}

	public Dictionary<string, Dictionary<int, int>> BuildingMaxLevelRequiredUserLevelDict
	{
		get
		{
			if (buildingMaxLevelRequiredUserLevelDict == null)
			{
				EnsureUserExpData();
			}
			return buildingMaxLevelRequiredUserLevelDict;
		}
	}

	public Dictionary<string, Dictionary<int, int>> ItemMaxLevelRequiredUserLevelDict
	{
		get
		{
			if (itemMaxLevelRequiredUserLevelDict == null)
			{
				EnsureUserExpData();
			}
			return itemMaxLevelRequiredUserLevelDict;
		}
	}

	public Dictionary<int, int> SoldierMaxBreakthroughLevelRequiredUserLevelDict
	{
		get
		{
			if (soldierMaxBreakthroughLevelRequiredUserLevelDict == null)
			{
				EnsureUserExpData();
			}
			return soldierMaxBreakthroughLevelRequiredUserLevelDict;
		}
	}

	public Dictionary<int, int> SoldierMaxEvoLevelRequiredUserLevelDict
	{
		get
		{
			if (soldierMaxEvoLevelRequiredUserLevelDict == null)
			{
				EnsureUserExpData();
			}
			return soldierMaxEvoLevelRequiredUserLevelDict;
		}
	}

	public Dictionary<int, int> FormationSlotUnlockRequiredUserLevelDict
	{
		get
		{
			if (formationSlotUnlockRequiredUserLevelDict == null)
			{
				EnsureUserExpData();
			}
			return formationSlotUnlockRequiredUserLevelDict;
		}
	}

	public Dictionary<int, int> InvitingSlotUnlockRequiredUserLevelDict
	{
		get
		{
			if (invitingSlotUnlockRequiredUserLevelDict == null)
			{
				EnsureUserExpData();
			}
			return invitingSlotUnlockRequiredUserLevelDict;
		}
	}

	public Dictionary<int, UserExpData> UserExpData
	{
		get
		{
			if (m_userExpData == null)
			{
				EnsureUserExpData();
			}
			return m_userExpData;
		}
	}

	public Dictionary<int, DungeonExpData> DungeonExpData
	{
		get
		{
			if (m_dungeonExpData == null)
			{
				EnsureDungeonExpData();
			}
			return m_dungeonExpData;
		}
	}

	public static Dictionary<string, ProductEvoData> ProductEvoData
	{
		get
		{
			if (_productEvoData == null)
			{
				IEnumerable<GDEProductEvoData> allItems = GDMgr.GetAllItems<GDEProductEvoData>();
				_productEvoData = new Dictionary<string, ProductEvoData>();
				foreach (GDEProductEvoData item in allItems)
				{
					ProductEvoData productEvoData = new ProductEvoData(item.Key);
					_productEvoData.Add(productEvoData.ItemId, productEvoData);
				}
			}
			return _productEvoData;
		}
	}

	public static int VolunteersOnSoldierUnlock
	{
		get
		{
			if (_volunteersOnSoldierUnlock == -1 && !int.TryParse(GDMgr.Get<GDEConfigurationData>("VOLUNTEERS_ON_SOLDIER_UNLOCK").Config, out _volunteersOnSoldierUnlock))
			{
				_volunteersOnSoldierUnlock = 10;
			}
			return _volunteersOnSoldierUnlock;
		}
	}

	private static void EnsurePiecesData()
	{
		_piecesDataByType = new Dictionary<PiecesType, List<Pieces>>();
		_soldierPiecesData = new Dictionary<string, Pieces>();
		foreach (GDEPiecesData allItem in GDMgr.GetAllItems<GDEPiecesData>())
		{
			Pieces pieces = new Pieces(allItem);
			if (!_piecesDataByType.ContainsKey(pieces.Type))
			{
				_piecesDataByType.Add(pieces.Type, new List<Pieces>());
			}
			_piecesDataByType[pieces.Type].Add(pieces);
			if (pieces.Type == PiecesType.SoldierPieces && SchemaIndexHelper.GetSchemaById(pieces.RelativeContext) == "Soldier")
			{
				_soldierPiecesData.Add(pieces.RelativeContext, pieces);
			}
		}
	}

	public static List<Pieces> GetPiecesDataByType(PiecesType type)
	{
		if (!PiecesDataByType.TryGetValue(type, out var value))
		{
			return new List<Pieces>();
		}
		return value;
	}

	public static Dictionary<int, SoldierPotentialData> GetSoldierPotentials(string soldierId)
	{
		if (SoldierPotentialDataDict.TryGetValue(soldierId, out var value))
		{
			return value;
		}
		return null;
	}

	public static SoldierPotentialData GetSoldierPotential(string soldierId, int potentialLevel)
	{
		if (SoldierPotentialDataDict.TryGetValue(soldierId, out var value) && value.TryGetValue(potentialLevel, out var value2))
		{
			return value2;
		}
		return null;
	}

	public ConfigDataManager(GameManagers managers)
		: base(managers)
	{
	}

	public override Task Init()
	{
		EnsureUserExpData();
		EnsureDungeonExpData();
		return null;
	}

	private void EnsureUserExpData()
	{
		m_userExpData = new Dictionary<int, UserExpData>();
		buildingMaxLevelRequiredUserLevelDict = new Dictionary<string, Dictionary<int, int>>();
		itemMaxLevelRequiredUserLevelDict = new Dictionary<string, Dictionary<int, int>>();
		soldierMaxEvoLevelRequiredUserLevelDict = new Dictionary<int, int>();
		soldierMaxBreakthroughLevelRequiredUserLevelDict = new Dictionary<int, int>();
		formationSlotUnlockRequiredUserLevelDict = new Dictionary<int, int>();
		invitingSlotUnlockRequiredUserLevelDict = new Dictionary<int, int>();
		foreach (GDEUserExperienceData allItem in GDMgr.GetAllItems<GDEUserExperienceData>())
		{
			UserExpData userExpData = new UserExpData(Managers, allItem);
			int level = allItem.Level;
			m_userExpData.Add(level, userExpData);
			if (userExpData.BuildingMaxLevel != null)
			{
				foreach (KeyValuePair<string, int> item in userExpData.BuildingMaxLevel)
				{
					if (!buildingMaxLevelRequiredUserLevelDict.ContainsKey(item.Key))
					{
						buildingMaxLevelRequiredUserLevelDict.Add(item.Key, new Dictionary<int, int>());
					}
					if (!buildingMaxLevelRequiredUserLevelDict[item.Key].ContainsKey(item.Value))
					{
						buildingMaxLevelRequiredUserLevelDict[item.Key].Add(item.Value, level);
					}
				}
			}
			if (userExpData.ItemMaxLevel != null)
			{
				foreach (KeyValuePair<string, int> item2 in userExpData.ItemMaxLevel)
				{
					if (!itemMaxLevelRequiredUserLevelDict.ContainsKey(item2.Key))
					{
						itemMaxLevelRequiredUserLevelDict.Add(item2.Key, new Dictionary<int, int>());
					}
					if (!itemMaxLevelRequiredUserLevelDict[item2.Key].ContainsKey(item2.Value))
					{
						itemMaxLevelRequiredUserLevelDict[item2.Key].Add(item2.Value, level);
					}
				}
			}
			if (userExpData.SoldierMaxEvoLevel > 0 && !soldierMaxEvoLevelRequiredUserLevelDict.ContainsKey(userExpData.SoldierMaxEvoLevel))
			{
				soldierMaxEvoLevelRequiredUserLevelDict.Add(userExpData.SoldierMaxEvoLevel, level);
			}
			if (userExpData.SoldierMaxStars > 0 && !soldierMaxBreakthroughLevelRequiredUserLevelDict.ContainsKey(userExpData.SoldierMaxStars))
			{
				soldierMaxBreakthroughLevelRequiredUserLevelDict.Add(userExpData.SoldierMaxStars, level);
			}
			if (userExpData.FormationSlots > 0 && !formationSlotUnlockRequiredUserLevelDict.ContainsKey(userExpData.FormationSlots))
			{
				formationSlotUnlockRequiredUserLevelDict.Add(userExpData.FormationSlots, level);
			}
			if (userExpData.InvitingSlots > 0 && !invitingSlotUnlockRequiredUserLevelDict.ContainsKey(userExpData.InvitingSlots))
			{
				invitingSlotUnlockRequiredUserLevelDict.Add(userExpData.InvitingSlots, level);
			}
		}
		CheckUserEvoData();
	}

	private void EnsureDungeonExpData()
	{
		m_dungeonExpData = new Dictionary<int, DungeonExpData>();
		foreach (GDEDungeonExperienceData allItem in GDMgr.GetAllItems<GDEDungeonExperienceData>())
		{
			DungeonExpData value = new DungeonExpData(Managers, allItem);
			m_dungeonExpData.Add(allItem.Level, value);
		}
		CheckDungeonEvoData();
	}

	public int GetUserLevelRequiredForBuildingUpgrade(string buildingType, int buildingLevel)
	{
		if (!BuildingMaxLevelRequiredUserLevelDict.ContainsKey(buildingType))
		{
			return 0;
		}
		int num = buildingLevel + 1;
		int result = 0;
		foreach (KeyValuePair<int, int> item in BuildingMaxLevelRequiredUserLevelDict[buildingType])
		{
			if (item.Key >= num)
			{
				result = item.Value;
				break;
			}
		}
		return result;
	}

	public int GetUserLevelRequiredForItemUpgrade(string itemId, int currentItemLevel)
	{
		if (!ItemMaxLevelRequiredUserLevelDict.ContainsKey(itemId))
		{
			return 0;
		}
		int num = currentItemLevel + 1;
		int result = 0;
		foreach (KeyValuePair<int, int> item in ItemMaxLevelRequiredUserLevelDict[itemId])
		{
			if (item.Key >= num)
			{
				result = item.Value;
				break;
			}
		}
		return result;
	}

	public int GetUserLevelRequiredForSoldierEvoLevel(int soldierEvoLevel)
	{
		int result = 0;
		foreach (KeyValuePair<int, int> item in SoldierMaxEvoLevelRequiredUserLevelDict)
		{
			if (item.Key >= soldierEvoLevel)
			{
				result = item.Value;
				break;
			}
		}
		return result;
	}

	public int GetUserLevelRequiredForSoldierBreakthrough(int soldierStars)
	{
		int result = 0;
		foreach (KeyValuePair<int, int> item in SoldierMaxBreakthroughLevelRequiredUserLevelDict)
		{
			if (item.Key >= soldierStars)
			{
				result = item.Value;
				break;
			}
		}
		return result;
	}

	public int GetUserLevelRequiredForFormationSlotUnlock(int slotNum)
	{
		int result = 0;
		foreach (KeyValuePair<int, int> item in FormationSlotUnlockRequiredUserLevelDict)
		{
			if (item.Key >= slotNum)
			{
				result = item.Value;
				break;
			}
		}
		return result;
	}

	public int GetUserNextLevelExp()
	{
		int key = Managers.UserArchiveManager.GetUserLevel() + 1;
		if (UserExpData.ContainsKey(key))
		{
			return UserExpData[key].Exp;
		}
		return int.MaxValue;
	}

	public int GetUserCurLevelExp()
	{
		int userLevel = Managers.UserArchiveManager.GetUserLevel();
		if (UserExpData.ContainsKey(userLevel))
		{
			return UserExpData[userLevel].Exp;
		}
		return int.MaxValue;
	}

	public int GetDungeonNextLevelSoldierStockIncrement(string soldierId)
	{
		if (string.IsNullOrEmpty(soldierId))
		{
			return 0;
		}
		int dungeonLevel = Managers.UserArchiveManager.GetDungeonLevel();
		int key = dungeonLevel + 1;
		if (!DungeonExpData.TryGetValue(key, out var value))
		{
			return 0;
		}
		int num = 0;
		List<Modifier> modifierList = value.ModifierList;
		for (int i = 0; i < modifierList.Count; i++)
		{
			if (!(modifierList[i].ModifierId != "StockLimit") && modifierList[i].PayloadDictionary.TryGetValue("Payload", out var value2))
			{
				num = int.Parse(value2.ToString().TrimEnd('%')) / 100;
			}
		}
		if (!DungeonExpData.TryGetValue(dungeonLevel, out var value3))
		{
			return 0;
		}
		int num2 = 0;
		List<Modifier> modifierList2 = value3.ModifierList;
		for (int j = 0; j < modifierList2.Count; j++)
		{
			if (!(modifierList2[j].ModifierId != "StockLimit") && modifierList2[j].PayloadDictionary.TryGetValue("Payload", out var value4))
			{
				num2 = int.Parse(value4.ToString().TrimEnd('%')) / 100;
			}
		}
		return (num - num2) * StockController.GetOriginLimit(soldierId);
	}

	public int GetDungeonNextLevelExp()
	{
		int key = Managers.UserArchiveManager.GetDungeonLevel() + 1;
		if (DungeonExpData.ContainsKey(key))
		{
			return DungeonExpData[key].Exp;
		}
		return int.MaxValue;
	}

	public int GetDungeonCurLevelExp()
	{
		int dungeonLevel = Managers.UserArchiveManager.GetDungeonLevel();
		if (DungeonExpData.ContainsKey(dungeonLevel))
		{
			return DungeonExpData[dungeonLevel].Exp;
		}
		return int.MaxValue;
	}

	private static void EnsureLevelBonuses()
	{
		if (_levelBonuses == null)
		{
			_levelBonuses = new Dictionary<string, string>();
		}
		else
		{
			_levelBonuses.Clear();
		}
		if (_levelRepeatBonuses == null)
		{
			_levelRepeatBonuses = new Dictionary<string, string>();
		}
		else
		{
			_levelRepeatBonuses.Clear();
		}
		if (_levelLottery == null)
		{
			_levelLottery = new Dictionary<string, string>();
		}
		else
		{
			_levelLottery.Clear();
		}
		if (_levelRepeatLottery == null)
		{
			_levelRepeatLottery = new Dictionary<string, string>();
		}
		else
		{
			_levelRepeatLottery.Clear();
		}
	}

	public void CheckDungeonEvoData()
	{
		int dungeonLevel = Managers.UserArchiveManager.GetDungeonLevel();
		DungeonExpData dungeonExpData = null;
		for (int i = 0; i <= dungeonLevel; i++)
		{
			DungeonExpData.TryGetValue(i, out var value);
			if (dungeonExpData != null)
			{
				List<Modifier> modifierList = dungeonExpData.ModifierList;
				if (modifierList != null)
				{
					foreach (Modifier item in modifierList)
					{
						if (!(item.ModifierId == "Bonus") && !(item.ModifierId == "TimeMachine") && !(item.ModifierId == "OfflineYieldTimeLimit"))
						{
							Managers.ModifierManager.ReadFromModifier(item, -1);
						}
					}
				}
			}
			if (value != null)
			{
				List<Modifier> modifierList2 = value.ModifierList;
				if (modifierList2 != null)
				{
					foreach (Modifier item2 in modifierList2)
					{
						if (item2.ModifierId == "Bonus")
						{
							if (item2.PayloadDictionary.TryGetValue("Unlock", out var value2))
							{
								Modifier modifier = new Modifier(Managers, "Unlock", new Dictionary<string, object> { { "Unlock", value2 } });
								Managers.ModifierManager.ReadFromModifier(modifier);
							}
						}
						else if (!(item2.ModifierId == "TimeMachine") && !(item2.ModifierId == "OfflineYieldTimeLimit"))
						{
							Managers.ModifierManager.ReadFromModifier(item2);
						}
					}
				}
				if (value.BuildingMaxLevel.Count > 0)
				{
					foreach (KeyValuePair<string, int> item3 in value.BuildingMaxLevel)
					{
						string key = item3.Key;
						int value3 = item3.Value;
						if (Managers.UserArchiveManager.GetBuildingMaxLevel(key) < value3)
						{
							Managers.UserArchiveManager.SetBuildingMaxLevel(key, value3);
						}
					}
				}
				if (value.ItemMaxLevel.Count > 0)
				{
					foreach (KeyValuePair<string, int> item4 in value.ItemMaxLevel)
					{
						string key2 = item4.Key;
						int value4 = item4.Value;
						if (Managers.UserArchiveManager.GetItemMaxLevel(key2) < value4)
						{
							Managers.UserArchiveManager.SetItemMaxLevel(key2, value4);
						}
					}
				}
			}
			dungeonExpData = value;
		}
	}

	public void CheckUserEvoData()
	{
		int userLevel = Managers.UserArchiveManager.GetUserLevel();
		UserExpData userExpData = null;
		for (int i = 0; i <= userLevel; i++)
		{
			UserExpData.TryGetValue(i, out var value);
			if (userExpData != null)
			{
				List<Modifier> modifierList = userExpData.ModifierList;
				if (modifierList != null)
				{
					foreach (Modifier item in modifierList)
					{
						if (!(item.ModifierId == "Bonus") && !(item.ModifierId == "TimeMachine") && !(item.ModifierId == "OfflineYieldTimeLimit"))
						{
							Managers.ModifierManager.ReadFromModifier(item, -1);
						}
					}
				}
			}
			if (value != null)
			{
				List<Modifier> modifierList2 = value.ModifierList;
				if (modifierList2 != null)
				{
					foreach (Modifier item2 in modifierList2)
					{
						if (item2.ModifierId == "Bonus")
						{
							if (item2.PayloadDictionary.TryGetValue("Unlock", out var value2))
							{
								Modifier modifier = new Modifier(Managers, "Unlock", new Dictionary<string, object> { { "Unlock", value2 } });
								Managers.ModifierManager.ReadFromModifier(modifier);
							}
						}
						else if (!(item2.ModifierId == "TimeMachine") && !(item2.ModifierId == "OfflineYieldTimeLimit"))
						{
							Managers.ModifierManager.ReadFromModifier(item2);
						}
					}
				}
				if (value.BuildingMaxLevel.Count > 0)
				{
					foreach (KeyValuePair<string, int> item3 in value.BuildingMaxLevel)
					{
						string key = item3.Key;
						int value3 = item3.Value;
						if (Managers.UserArchiveManager.GetBuildingMaxLevel(key) < value3)
						{
							Managers.UserArchiveManager.SetBuildingMaxLevel(key, value3);
						}
					}
				}
				if (value.ItemMaxLevel.Count > 0)
				{
					foreach (KeyValuePair<string, int> item4 in value.ItemMaxLevel)
					{
						string key2 = item4.Key;
						int value4 = item4.Value;
						if (Managers.UserArchiveManager.GetItemMaxLevel(key2) < value4)
						{
							Managers.UserArchiveManager.SetItemMaxLevel(key2, value4);
						}
					}
				}
				if (Managers.UserArchiveManager.GetInvitingSlots() < value.InvitingSlots)
				{
					Managers.UserArchiveManager.SetInvitingSlots(value.InvitingSlots);
				}
				if (value.FormationSlots > 0)
				{
					string text = ChapterType.StoryMain.ToString();
					string text2 = BattleMode.RushMode.ToString();
					List<string> list = Managers.UserArchiveManager.GetBattleFormation(text, text2).Values.ToList();
					for (int j = 0; j < value.FormationSlots; j++)
					{
						if (list[j] == "Lock")
						{
							Managers.FormationUnitsManager.ChangeFormationUnit(text, text2, j, "Unlock");
						}
					}
				}
			}
			userExpData = value;
		}
	}
}
