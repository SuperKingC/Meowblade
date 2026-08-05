using System;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Models;

public class Dungeon
{
	private readonly GameManagers _managers;

	public Dictionary<string, Building> Buildings => _managers.BuildingManager.Buildings;

	public int LegionSizeLimit
	{
		get
		{
			List<string> unlockedSoldiers = _managers.UserArchiveManager.GetUnlockedSoldiers();
			return (unlockedSoldiers.Count != 0) ? _managers.StockController.GetLimit(unlockedSoldiers[0]) : 0;
		}
	}

	public GameManagers Managers => _managers;

	public Dungeon(GameManagers managers)
	{
		_managers = managers;
	}

	public static int GetFreeManPower(GameManagers managers)
	{
		int totalManPower = GetTotalManPower(managers);
		int num = totalManPower;
		Dictionary<string, Building> buildings = managers.BuildingManager.Buildings;
		foreach (Building value in buildings.Values)
		{
			if (value.BuildingType == "12")
			{
				continue;
			}
			if (value.Feature == "Mine" || value.Feature == "WorkShop" || value.Feature == "MoltenCore")
			{
				foreach (ProductionConfig value2 in ((WorkShop)value).ProductionConfigs.Values)
				{
					num -= value2.Workers;
				}
			}
			if (value.Status == BuildingStatus.Ready || value.Status == BuildingStatus.Constructing)
			{
				int num2 = value.ConstructingConfig?.Workers ?? 0;
				num -= num2;
			}
		}
		int num3 = num;
		GvGMode3ObserverRecord gvGMode3ObserverRecord = managers.UserArchiveManager.LoadGvGMode3Record();
		int num4 = 0;
		if (gvGMode3ObserverRecord?.Ships != null)
		{
			num4 = gvGMode3ObserverRecord.Ships.Sum((GvGMode3ShipModel _ship) => _ship.PermanentData.ManPower);
		}
		num -= num4;
		if (num < 0)
		{
			num4 = 0;
		}
		return num;
	}

	public static int GetTotalManPower(GameManagers managers)
	{
		Dictionary<int, Tuple<int, string, int>> value = managers.FriendsManager.InvitingSlotsConfig.GetValue();
		Dictionary<int, InvitedWorker> invitedWorkers = managers.FriendsManager.InvitedWorkers;
		int num = managers.StockController.GetStock("ManPower");
		foreach (Tuple<int, string, int> value3 in value.Values)
		{
			if (value3.Item1 > 0 && invitedWorkers.TryGetValue(value3.Item1, out var value2) && value2.Status == InvitedWorkerActivateStatus.Activated)
			{
				num++;
			}
		}
		return num;
	}

	public Dictionary<Building, Dictionary<string, Dictionary<string, ProductionConfig>>> GetManPowerAllocation()
	{
		Dictionary<Building, Dictionary<string, Dictionary<string, ProductionConfig>>> dictionary = new Dictionary<Building, Dictionary<string, Dictionary<string, ProductionConfig>>>();
		foreach (Building value2 in _managers.BuildingManager.Buildings.Values)
		{
			if (!(value2 is WorkShop workShop) || value2.Status == BuildingStatus.Abandoned || value2.Status == BuildingStatus.Banned || value2.Status == BuildingStatus.Disabled)
			{
				continue;
			}
			Dictionary<string, Dictionary<string, ProductionConfig>> dictionary2 = new Dictionary<string, Dictionary<string, ProductionConfig>>();
			foreach (KeyValuePair<string, ProductionConfig> productionConfig in workShop.ProductionConfigs)
			{
				string key = productionConfig.Key;
				ProductionConfig value = productionConfig.Value;
				if (value.ProductList != null && value.ProductList.Count >= 1 && value.Workers >= 1)
				{
					string key2 = value.ProductList.First();
					if (!dictionary2.ContainsKey(key2))
					{
						dictionary2.Add(key2, new Dictionary<string, ProductionConfig>());
					}
					dictionary2[key2].Add(key, value);
				}
			}
			if (dictionary2.Count >= 1)
			{
				dictionary.Add(workShop, dictionary2);
			}
		}
		return dictionary;
	}

	public void AssignManPower(string buildingType, int workbenchIndex, List<string> targetProducts, int deltaNum)
	{
		Building buildingByType = _managers.BuildingManager.GetBuildingByType(buildingType);
		WorkShop workshop = buildingByType as WorkShop;
		if (workshop == null)
		{
			return;
		}
		workshop.GetProductionConfigAt(workbenchIndex);
		Dictionary<string, ProductionConfig> newProductionConfigs = DictionaryExtensions.DeepCopy<string, ProductionConfig>(workshop.ProductionConfigs);
		List<string> productionConfigsIndexList = newProductionConfigs.Keys.ToList();
		ProductionConfig productionConfig = newProductionConfigs[workbenchIndex.ToString()];
		productionConfig.ProductList = targetProducts;
		productionConfig.Workers += deltaNum;
		if (productionConfig.Workers < 0)
		{
			productionConfig.Workers = 0;
		}
		ILRequestHelper<ChangeWorkshopProduceConfigResponse>.Request(null, delegate
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			Dictionary<int, List<string>> dictionary2 = new Dictionary<int, List<string>>();
			for (int i = 0; i < productionConfigsIndexList.Count; i++)
			{
				int key = int.Parse(productionConfigsIndexList[i]);
				ProductionConfig productionConfig2 = newProductionConfigs[productionConfigsIndexList[i]];
				dictionary.Add(key, productionConfig2.Workers);
				dictionary2.Add(key, productionConfig2.ProductList);
			}
			return Contexts.sharedInstance.Service<INetworkService>().ChangeWorkshopProduceConfig(1L, buildingType, dictionary, dictionary2);
		}, delegate(ChangeWorkshopProduceConfigResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				_managers.Messenger.Broadcast("PRODUCTION_CONFIG_CHANGED", (Building)workshop, DictionaryExtensions.DeepCopy<string, ProductionConfig>(newProductionConfigs));
				_managers.Messenger.Broadcast("WORKERS_ALLOCATION_DISPLAY_CHANGED", (Building)workshop);
			}
		}, 1f);
	}
}
