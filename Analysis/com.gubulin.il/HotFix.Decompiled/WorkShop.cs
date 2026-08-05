using System;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using GameMaths;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

public class WorkShop : Building
{
	public Config<WorkShopConfig> Config;

	public object Controller;

	private float addOnRate = -1f;

	private float extraProdRate = -1f;

	private ResourcePortalInfoEvo _portalInfo;

	private string _position;

	public override string Name
	{
		get
		{
			InfoEvo infoEvo = new InfoEvo("BuildingName" + BuildingType);
			if (infoEvo.NameList.Count > 0 && Level > 0 && infoEvo.NameList.Count >= Level)
			{
				return infoEvo.NameList[Level - 1];
			}
			return _name;
		}
	}

	public float AddOnRate
	{
		get
		{
			if (addOnRate < 0f)
			{
				if (FeatureConfig != null && FeatureConfig.TryGetValue("AddOnRate", out var value))
				{
					addOnRate = Convert.ToSingle(value);
				}
				else
				{
					addOnRate = 0f;
				}
			}
			return addOnRate;
		}
	}

	public float ExtraProdRate
	{
		get
		{
			if (extraProdRate < 0f)
			{
				if (FeatureConfig != null && FeatureConfig.TryGetValue("ExtraProdRate", out var value))
				{
					extraProdRate = Convert.ToSingle(value);
				}
				else
				{
					extraProdRate = 0f;
				}
			}
			return extraProdRate;
		}
	}

	public string ProductClass
	{
		get
		{
			if (FeatureConfig != null && FeatureConfig.ContainsKey("ProductionClass"))
			{
				return FeatureConfig["ProductionClass"].ToString();
			}
			return "";
		}
	}

	public float CommuteTime
	{
		get
		{
			if (FeatureConfig != null && FeatureConfig.TryGetValue("CommuteTime", out var value))
			{
				return Convert.ToSingle(value);
			}
			return 0f;
		}
	}

	public int ManPower
	{
		get
		{
			int num = 0;
			foreach (ProductionConfig value in ProductionConfigs.Values)
			{
				num += value.Workers;
			}
			return num;
		}
	}

	public int MaxWorkers
	{
		get
		{
			return Config.GetValue().MaxWorkers;
		}
		set
		{
			WorkShopConfig value2 = Config.GetValue();
			value2.MaxWorkers = value;
			Config.SetValue(value2);
		}
	}

	public Dictionary<string, ProductionConfig> ProductionConfigs
	{
		get
		{
			return Config?.GetValue().ProductionConfigs;
		}
		set
		{
			WorkShopConfig value2 = Config.GetValue();
			value2.ProductionConfigs = value;
			Config.SetValue(value2);
		}
	}

	public string Position
	{
		get
		{
			if (_position == null)
			{
				decimal num = decimal.Parse(BuildingType);
				_position = Math.Ceiling(num / 3m).ToString() + ((num - 1m) % 3m + 1m);
			}
			return _position;
		}
		set
		{
			_position = value;
		}
	}

	public WorkShop(GameManagers managers, Config<WorkShopConfig> config)
		: base(managers, config.GetValue().BuildingType)
	{
		WorkShopConfig value = config.GetValue();
		if (value == null)
		{
			value = new WorkShopConfig();
			config.SetValue(value);
		}
		Config = config;
	}

	public ProductionConfig GetProductionConfigAt(int index)
	{
		if (ProductionConfigs == null)
		{
			ProductionConfigs = new Dictionary<string, ProductionConfig>();
		}
		if (index < ProductionConfigs.Count)
		{
			return ProductionConfigs[index.ToString()];
		}
		for (int i = ProductionConfigs.Count; i <= index; i++)
		{
			ProductionConfigs.Add(i.ToString(), new ProductionConfig
			{
				Workers = 0
			});
		}
		if (BuildingType == "12")
		{
			GvGMode3ObserverRecord gvGMode3ObserverRecord = GameManagers.Instance.UserArchiveManager.LoadGvGMode3Record();
			int num = 0;
			if (gvGMode3ObserverRecord.Ships != null)
			{
				num = gvGMode3ObserverRecord.Ships.Sum((GvGMode3ShipModel _ship) => _ship.PermanentData.ManPower);
			}
			if (index <= num)
			{
				ProductionConfigs[index.ToString()].Workers = 1;
			}
		}
		return ProductionConfigs[index.ToString()];
	}

	public override Dictionary<string, int> GetNextLevelRequirements(bool ignoreModifier = false)
	{
		if (base.EvoData == null || !base.EvoData.ContainsKey(base.NextLevel))
		{
			return null;
		}
		if (ignoreModifier)
		{
			return base.EvoData[base.NextLevel].EvoRequire;
		}
		float percentFloatPayload = Managers.ModifierManager.GetPercentFloatPayload("BuildingUpgradeCost", new string[2]
		{
			"BuildingType" + BuildingType,
			"WorkShop" + Position
		});
		Dictionary<string, int> dictionary;
		if (Math.Abs(percentFloatPayload) > float.Epsilon)
		{
			dictionary = new Dictionary<string, int>();
			percentFloatPayload += 1f;
			foreach (KeyValuePair<string, int> item in base.EvoData[base.NextLevel].EvoRequire)
			{
				dictionary.Add(item.Key, Mathf.RoundToInt((float)item.Value * percentFloatPayload));
			}
		}
		else
		{
			dictionary = base.EvoData[base.NextLevel].EvoRequire;
		}
		return dictionary;
	}

	private bool FilterProductData(GDEProductData data, ProductFilter filter)
	{
		return filter switch
		{
			ProductFilter.Normal => !data.AddOn, 
			ProductFilter.AddOn => data.AddOn, 
			ProductFilter.ShowUp => !data.Hide, 
			ProductFilter.Hide => data.Hide, 
			_ => true, 
		};
	}

	public Dictionary<string, int> GetProductStates(bool includeLocked, params ProductFilter[] filters)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		Dictionary<string, GDEProductData> allProducts = Managers.BuildingManager.GetAllProducts(BuildingType);
		if (allProducts == null)
		{
			return dictionary;
		}
		List<string> unlockedProducts = Managers.UserArchiveManager.GetUnlockedProducts();
		foreach (KeyValuePair<string, GDEProductData> productKv in allProducts)
		{
			if (filters.All((ProductFilter filter) => FilterProductData(productKv.Value, filter)))
			{
				dictionary.Add(productKv.Key, (unlockedProducts.Contains(productKv.Key) || includeLocked) ? productKv.Value.Weight : 0);
			}
		}
		return dictionary;
	}

	public ResourcePortalInfoEvo GetPortalInfo()
	{
		if (string.IsNullOrEmpty(ProductClass))
		{
			return null;
		}
		if (_portalInfo == null)
		{
			_portalInfo = new ResourcePortalInfoEvo(ProductClass);
		}
		if (_portalInfo.NameList.Count <= 0)
		{
			return null;
		}
		return _portalInfo;
	}

	public override ActionResult FinishUpgrade()
	{
		ActionResult result = base.FinishUpgrade();
		if (result.Result)
		{
			MaxWorkers = base.EvoData[Level].Slot;
		}
		return result;
	}

	public int GetAssignedWorkers(string productId)
	{
		int num = 0;
		foreach (ProductionConfig value in ProductionConfigs.Values)
		{
			if (value.ProductList.Contains(productId))
			{
				num += value.Workers;
			}
		}
		return num;
	}

	public bool CheckNewProductionConfigsChange(Dictionary<string, ProductionConfig> newConfigs)
	{
		if (newConfigs == null || ProductionConfigs == null)
		{
			return false;
		}
		Dictionary<string, ProductionConfig> productionConfigs = ProductionConfigs;
		int num = Math.Max(newConfigs.Count, productionConfigs.Count);
		bool result = false;
		for (int i = 0; i < num; i++)
		{
			if (!productionConfigs.TryGetValue(i.ToString(), out var value))
			{
				value = new ProductionConfig
				{
					ProductList = new List<string>(),
					Workers = 0
				};
			}
			if (!newConfigs.TryGetValue(i.ToString(), out var value2))
			{
				value2 = new ProductionConfig
				{
					ProductList = new List<string>(),
					Workers = 0
				};
			}
			List<string> list = value.ProductList;
			List<string> list2 = value2.ProductList;
			if (list == null)
			{
				list = (value.ProductList = new List<string>());
			}
			if (list2 == null)
			{
				list2 = (value2.ProductList = new List<string>());
			}
			bool flag = list.Count < 1;
			bool flag2 = list2.Count < 1;
			if (flag && flag2)
			{
				value.Workers = 0;
				value2.Workers = 0;
			}
			else if (value.Workers != value2.Workers || list.Count != list2.Count || list.Intersect(list2).Count() != list.Count)
			{
				result = true;
			}
		}
		return result;
	}
}
