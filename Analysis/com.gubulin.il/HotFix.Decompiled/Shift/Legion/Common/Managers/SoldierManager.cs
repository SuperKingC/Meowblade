using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameDataEditor;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public class SoldierManager : Manager
{
	private const string LegionPowerKey = "LegionPower";

	public const string CurrentMaxLegionPowerKey = "CurrentMaxLegionPower";

	private Config<LegionPowerConfig> _legionPowerConfig;

	private Config<int> _currentMaxLegionPower;

	private Dictionary<string, Soldier> _playerSoldiers;

	private static List<string> __list;

	public static Action<string, List<string>> CreateUnlockSoldierCommand;

	public Config<LegionPowerConfig> LegionPowerConfig
	{
		get
		{
			if (_legionPowerConfig == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("LegionPower"))
				{
					DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
					LegionPowerConfig legionPowerConfig = new LegionPowerConfig(LegionHelper.GetPlayerMaxPossibleCombatPower(Managers), dailyRefreshTime);
					foreach (KeyValuePair<Soldier, int> item in LegionHelper.GetPlayerMaxPowerfulLegion(Managers))
					{
						Soldier key = item.Key;
						legionPowerConfig.FormationInfo.Add(key.Id, key.Level);
					}
					userArchiveManager.SetConfigValue("LegionPower", legionPowerConfig);
				}
				_legionPowerConfig = userArchiveManager.GetConfig<LegionPowerConfig>("LegionPower");
			}
			return _legionPowerConfig;
		}
	}

	public Config<int> CurrentMaxLegionPower
	{
		get
		{
			if (_currentMaxLegionPower == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("CurrentMaxLegionPower"))
				{
					userArchiveManager.SetConfigValue("CurrentMaxLegionPower", LegionHelper.GetPlayerMaxPossibleCombatPower(Managers));
				}
				_currentMaxLegionPower = userArchiveManager.GetConfig<int>("CurrentMaxLegionPower");
			}
			return _currentMaxLegionPower;
		}
	}

	public Dictionary<string, Soldier> PlayerSoldiers
	{
		get
		{
			if (_playerSoldiers == null)
			{
				_playerSoldiers = new Dictionary<string, Soldier>();
				__list = new List<string>
				{
					"S001", "S002", "S003", "S004", "S005", "S006", "S007", "S008", "S009", "S010",
					"S011", "S012", "S013", "S014", "S015", "S016", "S017", "S018", "S019", "S020",
					"S021", "S022", "S023", "S024", "S025", "S026", "S027", "S028", "S029", "S030",
					"S034", "S035", "S036", "S037", "S038", "S039", "S040", "S041", "S042", "S043",
					"S044"
				};
				int num = GameController.Instance.GetServerTimestamp();
				if (num == 0)
				{
					num = DateTimeHelper.TimeStamp;
					ILRuntimeDebug.LogError($"[SoldierDebug]Not Sync Time From Server Yet, Using Local Time: {num}");
				}
				if (num >= 1770933600)
				{
					__list.Add("S045");
				}
				GDMgr.Prewarm_MultiMode<GDESoldierData>(__list);
				foreach (string item in __list)
				{
					GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(item);
					if (gDESoldierData != null)
					{
						_playerSoldiers.Add(item, new Soldier(Managers, gDESoldierData));
					}
				}
			}
			return _playerSoldiers;
		}
	}

	public SoldierManager(GameManagers managers)
		: base(managers)
	{
	}

	public override Task Init()
	{
		_ = CurrentMaxLegionPower;
		return base.Init();
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<string>("SOLDIER_UNLOCKED", OnSoldierUnlocked);
		Managers.Messenger.AddListener<string, int>("SOLDIER_EVOLUTED", OnSoldierEvoluted);
		Managers.Messenger.AddListener<string, int, int>("SOLDIER_LEVEL_CHANGED", OnSoldierLevelChanged);
		Managers.Messenger.AddListener<string, int>("SOLDIER_BREAKTHROUGH", OnSoldierBreakthrough);
		Managers.Messenger.AddListener<string, int, Dictionary<string, int>>("SOLDIER_SUMMONING", OnSoldierSummoning);
		Managers.Messenger.AddListener<string, int>("TECH_UPGRADED", OnTechUpgrade);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener<string>("SOLDIER_UNLOCKED", OnSoldierUnlocked);
		Managers.Messenger.RemoveListener<string, int>("SOLDIER_EVOLUTED", OnSoldierEvoluted);
		Managers.Messenger.RemoveListener<string, int, int>("SOLDIER_LEVEL_CHANGED", OnSoldierLevelChanged);
		Managers.Messenger.RemoveListener<string, int>("SOLDIER_BREAKTHROUGH", OnSoldierBreakthrough);
		Managers.Messenger.RemoveListener<string, int, Dictionary<string, int>>("SOLDIER_SUMMONING", OnSoldierSummoning);
		Managers.Messenger.RemoveListener<string, int>("TECH_UPGRADED", OnTechUpgrade);
	}

	public Soldier Get(string soldierId, bool useCache = true)
	{
		if (soldierId == "S0018")
		{
			int num = GameController.Instance.GetServerTimestamp();
			if (num == 0)
			{
				num = DateTimeHelper.TimeStamp;
				ILRuntimeDebug.LogError($"[SoldierDebug]SoldierManager.Get Not Sync Time From Server Yet, Using Local Time: {num}");
			}
			if (num < 1737928800)
			{
				useCache = false;
			}
		}
		if (!useCache)
		{
			GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(soldierId);
			if (gDESoldierData == null)
			{
				return null;
			}
			return new Soldier(Managers, soldierId);
		}
		if (!PlayerSoldiers.TryGetValue(soldierId, out var value))
		{
			GDESoldierData gDESoldierData2 = GDMgr.Get<GDESoldierData>(soldierId);
			if (gDESoldierData2 == null)
			{
				return null;
			}
			value = new Soldier(Managers, soldierId);
			if (gDESoldierData2.IsPlayer)
			{
				PlayerSoldiers.Add(soldierId, value);
			}
		}
		return value;
	}

	public List<Soldier> GetPlayerSoldiersByOccupation(SoldierOccupation occupation)
	{
		List<Soldier> list = new List<Soldier>();
		foreach (Soldier value in PlayerSoldiers.Values)
		{
			if (value.Occupation == occupation)
			{
				list.Add(value);
			}
		}
		return list;
	}

	public int GetSoldierFxSize(string soldierId)
	{
		return Get(soldierId)?.Data.FxSize ?? 0;
	}

	public Action Unlock(string soldierId, int potentialLevel = 0, int getVolunteers = -1, bool broadcastInform = true)
	{
		if (!Managers.UserArchiveManager.UnlockSoldier(soldierId, potentialLevel, getVolunteers))
		{
			return null;
		}
		string text = $"skin{(potentialLevel + 2) / 2}";
		if (potentialLevel == 9)
		{
			text = "skin6";
		}
		string soldierSkin = Managers.UserArchiveManager.GetSoldierSkin(soldierId);
		if (soldierSkin != text)
		{
			Managers.UserArchiveManager.SetSoldierSkin(soldierId, text);
		}
		Dictionary<string, float>.KeyCollection keys = Singleton<SoldierProductManager>.Instance.GetSoldierProductRequirements(soldierId).Keys;
		List<string> list = new List<string>();
		List<string> newUnlockList = new List<string>();
		List<string> unlockedProducts = Managers.UserArchiveManager.GetUnlockedProducts();
		foreach (string item in keys)
		{
			string text2 = "P" + item.Substring(1);
			list.Add(text2);
			if (!BuildingManager.ProductRequirements.TryGetValue(text2, out var value))
			{
				continue;
			}
			foreach (string key in value.Keys)
			{
				list.Add("P" + key.Substring(1));
			}
		}
		foreach (string item2 in list)
		{
			if (!unlockedProducts.Contains(item2) && !newUnlockList.Contains(item2))
			{
				Managers.UserArchiveManager.UnlockProduct(item2, broadcastInform: false);
				newUnlockList.Add(item2);
			}
		}
		Managers.FormationUnitsManager.OnSoldierUnlocked(soldierId);
		Managers.Messenger.Broadcast("SOLDIER_UNLOCKED", soldierId);
		if (broadcastInform)
		{
			UnlockInform();
		}
		return UnlockInform;
		void UnlockInform()
		{
			CreateUnlockSoldierCommand(soldierId, newUnlockList);
		}
	}

	private void OnSoldierUnlocked(string soldierId)
	{
		CurrentMaxLegionPower.SetValue(LegionHelper.GetPlayerMaxPossibleCombatPower(Managers));
	}

	private void OnSoldierEvoluted(string soldierId, int evoLevel)
	{
		CurrentMaxLegionPower.SetValue(LegionHelper.GetPlayerMaxPossibleCombatPower(Managers));
	}

	private void OnSoldierLevelChanged(string soldierId, int beforeLevel, int afterLevel)
	{
		CurrentMaxLegionPower.SetValue(LegionHelper.GetPlayerMaxPossibleCombatPower(Managers));
	}

	private void OnSoldierBreakthrough(string soldierId, int breakthroughLevel)
	{
		CurrentMaxLegionPower.SetValue(LegionHelper.GetPlayerMaxPossibleCombatPower(Managers));
	}

	private void OnSoldierSummoning(string soldierId, int potentialLevelChanged, Dictionary<string, int> convertBonus)
	{
		CurrentMaxLegionPower.SetValue(LegionHelper.GetPlayerMaxPossibleCombatPower(Managers));
	}

	private void OnTechUpgrade(string techId, int techLevel)
	{
		foreach (string key in GameManagers.Instance.StockController.GetOwnedSoldiers(onlyUnlocked: true).Keys)
		{
			Soldier soldier = Get(key);
			soldier.EnsureAttr();
		}
		CurrentMaxLegionPower.SetValue(LegionHelper.GetPlayerMaxPossibleCombatPower(Managers));
	}

	public static string GetRootIdForSoldier(string soldierId)
	{
		GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(soldierId);
		if (!string.IsNullOrEmpty(gDESoldierData.ParentSoldierId))
		{
			return GetRootIdForSoldier(gDESoldierData.ParentSoldierId);
		}
		return gDESoldierData.Key;
	}
}
