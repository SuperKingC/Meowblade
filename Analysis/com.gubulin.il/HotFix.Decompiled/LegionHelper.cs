using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyGUI;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;

public class LegionHelper
{
	public static int GetPlayerMaxPossibleCombatPower(GameManagers managers, int formationNum = 5)
	{
		return (from combatPower in managers.StockController.GetOwnedSoldiers(onlyUnlocked: true).Keys.Select(delegate(string soldierId)
			{
				Soldier soldier = managers.SoldierManager.Get(soldierId);
				return soldier.CombatPower * Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldier.Id, soldier.Level);
			})
			orderby combatPower descending
			select combatPower).Take(formationNum).Sum();
	}

	public static void PlayerOwnedSoldiersCombatPowerInit(GameManagers managers)
	{
		ILRequestHelper<GetAllSoldiersCombatPowerResponse>.Request((EventContext)null, (Func<Task<GetAllSoldiersCombatPowerResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetAllSoldiersCombatPower(-1L)), (Action<GetAllSoldiersCombatPowerResponse>)delegate(GetAllSoldiersCombatPowerResponse response)
		{
			if (!response.Result)
			{
				if (response.ErrorCode != 90000000)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
			}
			else if (!string.IsNullOrEmpty(response.AllSoldiersCombatPower))
			{
				Dictionary<string, int> dictionary = JsonHelper.ToObject<Dictionary<string, int>>(response.AllSoldiersCombatPower);
				foreach (KeyValuePair<string, int> ownedSoldier in managers.StockController.GetOwnedSoldiers(onlyUnlocked: true))
				{
					Soldier soldier = managers.SoldierManager.Get(ownedSoldier.Key);
					if (dictionary.ContainsKey(soldier.Id))
					{
						soldier.SetSoldierCombatPower(dictionary[soldier.Id]);
					}
				}
			}
		});
	}

	public static string GetPlayerMaxPowerSoldierToBattle(GameManagers managers, List<string> currentSoldiers)
	{
		Dictionary<Soldier, int> dictionary = new Dictionary<Soldier, int>();
		foreach (KeyValuePair<string, int> ownedSoldier in managers.StockController.GetOwnedSoldiers(onlyUnlocked: true))
		{
			Soldier soldier = managers.SoldierManager.Get(ownedSoldier.Key);
			int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(ownedSoldier.Key, soldier.Level);
			if (!currentSoldiers.Contains(soldier.Id))
			{
				dictionary.Add(soldier, soldierFormationNumber);
			}
		}
		return (dictionary.OrderByDescending((KeyValuePair<Soldier, int> formationKv) => formationKv.Key.CombatPower * formationKv.Value)?.ToDictionary((KeyValuePair<Soldier, int> formationKv) => formationKv.Key, (KeyValuePair<Soldier, int> formationKv) => formationKv.Value))?.ToList()?[0].Key?.Id;
	}

	public static Dictionary<Soldier, int> GetPlayerMaxPowerfulLegion(GameManagers managers, int formationNum = 5)
	{
		Dictionary<Soldier, int> dictionary = new Dictionary<Soldier, int>();
		foreach (KeyValuePair<string, int> ownedSoldier in managers.StockController.GetOwnedSoldiers(onlyUnlocked: true))
		{
			Soldier soldier = managers.SoldierManager.Get(ownedSoldier.Key);
			int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(ownedSoldier.Key, soldier.Level);
			dictionary.Add(soldier, soldierFormationNumber);
		}
		return dictionary.OrderByDescending((KeyValuePair<Soldier, int> formationKv) => formationKv.Key.CombatPower * formationKv.Value).Take(formationNum).ToDictionary((KeyValuePair<Soldier, int> formationKv) => formationKv.Key, (KeyValuePair<Soldier, int> formationKv) => formationKv.Value);
	}

	public static List<int> GetPlayerMaxPowerfulLegionLevelsInfo(GameManagers managers)
	{
		Dictionary<Soldier, int> playerMaxPowerfulLegion = GetPlayerMaxPowerfulLegion(managers, 12);
		bool flag = false;
		if (playerMaxPowerfulLegion.Count < 5)
		{
			flag = true;
			foreach (KeyValuePair<Soldier, int> item in playerMaxPowerfulLegion)
			{
				string id = item.Key.Id;
				if (managers.UserArchiveManager.GetSoldierLevel(id) > 10)
				{
					flag = false;
					break;
				}
			}
		}
		List<int> list = new List<int>();
		IEnumerable<int> collection;
		if (!flag)
		{
			collection = playerMaxPowerfulLegion.Keys.Select((Soldier soldier) => managers.UserArchiveManager.GetSoldierLevel(soldier.Id));
		}
		else
		{
			IEnumerable<int> enumerable = new int[5] { 4, 3, 3, 3, 3 };
			collection = enumerable;
		}
		list.AddRange(collection);
		return list;
	}
}
