using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataEditor;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public class BuildingManager : Manager
{
	public const int SingleProductionCapacity = 10;

	public const float BaseDoubleChance = 0f;

	public const float BaseFreeProduceChance = 0f;

	public const float BaseCloneSoldierChance = 0f;

	private static List<string> _buildingTypes;

	private static List<string> _productIDs;

	private static Dictionary<string, Dictionary<int, BuildingEvoData>> _buildingEvoDataDictionary;

	private static Dictionary<string, GDEProductData> _products = new Dictionary<string, GDEProductData>();

	private Dictionary<string, Building> _buildings = new Dictionary<string, Building>();

	private static readonly Dictionary<string, GDEProductData> _itemIdToProductDict = new Dictionary<string, GDEProductData>();

	private static Dictionary<string, Dictionary<string, GDEProductData>> _buildingProducts = new Dictionary<string, Dictionary<string, GDEProductData>>();

	private static readonly Dictionary<string, Dictionary<string, int>> _productRequirements = new Dictionary<string, Dictionary<string, int>>();

	public readonly List<Building> ConstructingBuildings = new List<Building>();

	private static readonly string[] MineBuildingTypes = new string[3] { "1", "2", "3" };

	private static readonly string[] WorkshopBuildingTypes = new string[5] { "4", "5", "6", "8", "13" };

	public static List<string> BuildingTypes
	{
		get
		{
			if (_buildingTypes == null)
			{
				_buildingTypes = new List<string>();
				foreach (GDEBuildingData allItem in GDMgr.GetAllItems<GDEBuildingData>())
				{
					string key = allItem.Key;
					if (!string.IsNullOrEmpty(key) && !_buildingTypes.Contains(key))
					{
						_buildingTypes.Add(key);
					}
				}
			}
			return _buildingTypes;
		}
	}

	public static List<string> ProductIDs
	{
		get
		{
			if (_productIDs == null)
			{
				_productIDs = new List<string>();
				foreach (GDEProductData allItem in GDMgr.GetAllItems<GDEProductData>())
				{
					string key = allItem.Key;
					List<string> buildType = allItem.BuildType;
					if (string.IsNullOrEmpty(key) || buildType.Count < 1 || ProductIDs.Contains(key))
					{
						continue;
					}
					_productIDs.Add(key);
					_products.Add(key, allItem);
					if (!_itemIdToProductDict.ContainsKey(allItem.ItemId))
					{
						_itemIdToProductDict.Add(allItem.ItemId, allItem);
					}
					foreach (string item in buildType)
					{
						if (!_buildingProducts.ContainsKey(item))
						{
							_buildingProducts.Add(item, new Dictionary<string, GDEProductData>());
						}
						_buildingProducts[item].Add(key, allItem);
					}
					Dictionary<string, int> dictionary = new Dictionary<string, int>();
					if (allItem.Number1 > 0)
					{
						dictionary.Add(allItem.Stuff1, allItem.Number1);
					}
					if (allItem.Number2 > 0)
					{
						dictionary.Add(allItem.Stuff2, allItem.Number2);
					}
					if (allItem.Number3 > 0)
					{
						dictionary.Add(allItem.Stuff3, allItem.Number3);
					}
					if (allItem.Number4 > 0)
					{
						dictionary.Add(allItem.Stuff4, allItem.Number4);
					}
					if (allItem.Number5 > 0)
					{
						dictionary.Add(allItem.Stuff5, allItem.Number5);
					}
					_productRequirements.Add(key, dictionary);
				}
			}
			return _productIDs;
		}
	}

	public static Dictionary<string, Dictionary<int, BuildingEvoData>> BuildingEvoDataDictionary
	{
		get
		{
			if (_buildingEvoDataDictionary == null)
			{
				_buildingEvoDataDictionary = new Dictionary<string, Dictionary<int, BuildingEvoData>>();
				foreach (GDEBuildingEvoData allItem in GDMgr.GetAllItems<GDEBuildingEvoData>())
				{
					if (!string.IsNullOrEmpty(allItem.BuildingType))
					{
						if (!_buildingEvoDataDictionary.ContainsKey(allItem.BuildingType))
						{
							_buildingEvoDataDictionary.Add(allItem.BuildingType, new Dictionary<int, BuildingEvoData>());
						}
						_buildingEvoDataDictionary[allItem.BuildingType].Add(allItem.EvoLevel, new BuildingEvoData(allItem));
					}
				}
			}
			return _buildingEvoDataDictionary;
		}
	}

	public static Dictionary<string, Dictionary<string, int>> ProductRequirements => _productRequirements;

	public static Dictionary<string, GDEProductData> Products => _products;

	public static Dictionary<string, GDEProductData> ItemIdToProductDict => _itemIdToProductDict;

	public Dictionary<string, Building> Buildings => _buildings;

	public static Dictionary<int, BuildingEvoData> GetEvoData(string buildingType)
	{
		return BuildingEvoDataDictionary.ContainsKey(buildingType) ? BuildingEvoDataDictionary[buildingType] : null;
	}

	public static BuildingEvoData GetEvoData(string buildingType, int level)
	{
		Dictionary<int, BuildingEvoData> evoData = GetEvoData(buildingType);
		if (evoData == null || !evoData.ContainsKey(level))
		{
			return null;
		}
		return evoData[level];
	}

	public BuildingManager(GameManagers managers)
		: base(managers)
	{
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", OnBuildingStartUpgrading);
		Managers.Messenger.AddListener<string>("BUILDING_CONSTRUCTING_COMPLETE", OnBuildingConstructingComplete);
		Managers.Messenger.AddListener<string, int>("BUILDING_MAX_LEVEL_CHANGED", OnBuildingMaxLevelChanged);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", OnBuildingStartUpgrading);
		Managers.Messenger.RemoveListener<string>("BUILDING_CONSTRUCTING_COMPLETE", OnBuildingConstructingComplete);
		Managers.Messenger.RemoveListener<string, int>("BUILDING_MAX_LEVEL_CHANGED", OnBuildingMaxLevelChanged);
	}

	public override Task Init()
	{
		_buildings.Clear();
		foreach (GDEBuildingData allItem in GDMgr.GetAllItems<GDEBuildingData>())
		{
			string key = allItem.Key;
			if (string.IsNullOrEmpty(key))
			{
				continue;
			}
			Building building;
			switch (allItem.Feature)
			{
			case "Mine":
			case "WorkShop":
			case "MoltenCore":
			{
				string key2 = "BUILDING" + key;
				if (!Managers.UserArchiveManager.Contains(key2))
				{
					Managers.UserArchiveManager.SetConfigValue(key2, new WorkShopConfig
					{
						BuildingType = key
					});
				}
				Config<WorkShopConfig> config = Managers.UserArchiveManager.GetConfig<WorkShopConfig>(key2);
				building = ((allItem.Feature == "MoltenCore") ? new MoltenCore(Managers, config) : new WorkShop(Managers, config));
				break;
			}
			case "Camp":
				building = new Camp(Managers);
				break;
			case "Storehouse":
				building = new Storehouse(Managers);
				break;
			case "Throne":
				building = new Throne(Managers);
				break;
			case "MilitaryIntelligence7":
				building = new MilitaryIntelligence(Managers);
				break;
			case "BlackMarketer":
				building = new BlackMarket(Managers);
				break;
			case "PVPEntrance":
				building = new PVPEntrance(Managers);
				break;
			case "GvGExpeditionHallEntrance":
				building = new GvGExpeditionHallEntrance(Managers);
				break;
			default:
				building = new Building(Managers, allItem.Key);
				break;
			}
			_buildings.Add(key, building);
			building.CheckEvoData(1, 0, checkOnly: true);
			if (building.Status == BuildingStatus.Constructing)
			{
				if (building.ConstructingConfig.EndTime <= DateTimeHelper.Ticks)
				{
					building.Status = BuildingStatus.Ready;
				}
				else
				{
					ConstructingBuildings.Add(building);
				}
			}
		}
		return null;
	}

	public void RegisterUiObjects()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("MainCity.PortalEarth", GetBuildingByType("1").GameObject);
		instance.Register("MainCity.Storehouse", GetBuildingByType("11").GameObject);
		instance.Register("MainCity.Camp", GetBuildingByType("10").GameObject);
		instance.Register("MainCity.HallOfWar", GetBuildingByType("13").GameObject);
		instance.Register("MainCity.Forge", GetBuildingByType("4").GameObject);
		instance.Register("MainCity.Throne", GetBuildingByType("15").GameObject);
		instance.Register("MainCity.BlackMarket", GetBuildingByType("16").GameObject);
		instance.Register("MainCity.MilitaryIntelligence", GetBuildingByType("14").GameObject);
		instance.Register("MainCity.PVPEntrance", GetBuildingByType("18").GameObject);
	}

	private void OnBuildingStartUpgrading(string buildingType, BuildingConstructingConfig config)
	{
		Building buildingByType = GetBuildingByType(buildingType);
		if (buildingByType != null && !ConstructingBuildings.Contains(buildingByType))
		{
			ConstructingBuildings.Add(buildingByType);
		}
	}

	private void OnBuildingConstructingComplete(string buildingType)
	{
		Building buildingByType = GetBuildingByType(buildingType);
		if (ConstructingBuildings.Contains(buildingByType))
		{
			ConstructingBuildings.Remove(buildingByType);
		}
	}

	private void OnBuildingMaxLevelChanged(string buildingType, int level)
	{
		Building buildingByType = GetBuildingByType(buildingType);
		if (level > 0 && buildingByType != null && buildingByType.Status == BuildingStatus.Disabled)
		{
			buildingByType.Status = BuildingStatus.Abandoned;
		}
	}

	public Building GetBuildingByType(string type)
	{
		if (_buildings.TryGetValue(type, out var value))
		{
			return value;
		}
		return null;
	}

	public T GetBuildingByType<T>(string type) where T : Building
	{
		return GetBuildingByType(type) as T;
	}

	public List<Building> GetBuildingsByFeature(string buildingFeature)
	{
		List<Building> list = new List<Building>();
		foreach (Building value in _buildings.Values)
		{
			if (value.Feature == buildingFeature)
			{
				list.Add(value);
			}
		}
		return list;
	}

	public Dictionary<string, GDEProductData> GetAllProducts(string buildingType)
	{
		if (!_buildingProducts.ContainsKey(buildingType))
		{
			return null;
		}
		return _buildingProducts[buildingType];
	}

	public GDEProductData GetProductByItemId(string itemId)
	{
		ItemIdToProductDict.TryGetValue(itemId, out var value);
		return value;
	}

	public bool IsMineBuilding(string typeOrFeature)
	{
		return typeOrFeature == "Mine" || MineBuildingTypes.Contains(typeOrFeature);
	}

	public bool IsWorkshopBuilding(string typeOfFeature)
	{
		return typeOfFeature == "WorkShop" || WorkshopBuildingTypes.Contains(typeOfFeature);
	}

	public bool IsCampBuilding(string typeOrFeature)
	{
		return typeOrFeature == "10" || typeOrFeature == "Camp";
	}

	public bool IsRecyclingBuilding(string typeOrFeature)
	{
		return typeOrFeature == "17" || typeOrFeature == "MoltenCore";
	}
}
