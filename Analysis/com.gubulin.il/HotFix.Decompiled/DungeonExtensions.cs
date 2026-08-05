using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

public static class DungeonExtensions
{
	public static void AssignManPower(this Dungeon dungeon, string buildingType, int workbenchIndex, List<string> targetProducts, int deltaNum)
	{
		Building buildingByType = dungeon.Managers.BuildingManager.GetBuildingByType(buildingType);
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
				dungeon.Managers.Messenger.Broadcast("PRODUCTION_CONFIG_CHANGED", (Building)workshop, DictionaryExtensions.DeepCopy<string, ProductionConfig>(newProductionConfigs));
				dungeon.Managers.Messenger.Broadcast("WORKERS_ALLOCATION_DISPLAY_CHANGED", (Building)workshop);
			}
		}, 1f);
	}
}
