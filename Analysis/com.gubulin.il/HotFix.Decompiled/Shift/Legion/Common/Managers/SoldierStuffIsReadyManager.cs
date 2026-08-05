using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataEditor;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;

namespace Shift.Legion.Common.Managers;

public class SoldierStuffIsReadyManager : Manager
{
	private readonly Dictionary<int, bool> producingSoldierStates = new Dictionary<int, bool>();

	private readonly Dictionary<int, string> _stuffStringBuffer = new Dictionary<int, string>();

	private readonly Dictionary<int, string> _numberStringBuffer = new Dictionary<int, string>();

	private readonly Dictionary<string, string> _lowerValues = new Dictionary<string, string>();

	public List<bool> SoldierIsReady => producingSoldierStates.Values.ToList();

	public SoldierStuffIsReadyManager(GameManagers managers)
		: base(managers)
	{
		for (int i = 1; i <= 5; i++)
		{
			_stuffStringBuffer.Add(i, "Stuff" + i);
			_numberStringBuffer.Add(i, "Number" + i);
		}
	}

	public override Task Init()
	{
		UpdateProducingSoldierStates();
		return null;
	}

	private string GetLower(string value)
	{
		if (!_lowerValues.TryGetValue(value, out var value2))
		{
			value2 = value.ToLower();
			_lowerValues[value] = value2;
		}
		return value2;
	}

	public void CheckSoldierIsReady()
	{
		if (!Contexts.sharedInstance.Service<BaseSceneService>().get_EnableMaincity_Monobehaviour())
		{
			return;
		}
		foreach (KeyValuePair<int, string> item in Managers.UserArchiveManager.GetCampProducingQueue())
		{
			int key = item.Key;
			string value = item.Value;
			if (string.IsNullOrEmpty(value) || GetLower(value) == "lock" || GetLower(value) == "unlock")
			{
				producingSoldierStates[key] = false;
				continue;
			}
			GDESoldierProductData soldierProductData = Singleton<SoldierProductManager>.Instance.GetSoldierProductData(value);
			if (soldierProductData == null || soldierProductData.StuffNumber <= 0)
			{
				producingSoldierStates[key] = false;
				continue;
			}
			int soldierEvolutionLevel = Managers.UserArchiveManager.GetSoldierEvolutionLevel(value);
			bool value2 = true;
			for (int i = 1; i <= soldierProductData.StuffNumber; i++)
			{
				object obj = soldierProductData.GetType().GetProperty(_stuffStringBuffer[i])?.GetValue(soldierProductData);
				object obj2 = soldierProductData.GetType().GetProperty(_numberStringBuffer[i])?.GetValue(soldierProductData);
				if (obj2 == null || obj == null)
				{
					value2 = false;
					break;
				}
				string itemId = obj.ToString();
				int num = Convert.ToInt32(obj2);
				if (Managers.StockController.GetStock(itemId) < num || Managers.UserArchiveManager.GetWeaponEvoLevel(itemId) < soldierEvolutionLevel)
				{
					value2 = false;
					break;
				}
			}
			producingSoldierStates[key] = value2;
		}
	}

	public void UpdateProducingSoldierStates()
	{
		producingSoldierStates.Clear();
		foreach (KeyValuePair<int, string> item in Managers.UserArchiveManager.GetCampProducingQueue())
		{
			producingSoldierStates.Add(item.Key, value: false);
		}
	}
}
