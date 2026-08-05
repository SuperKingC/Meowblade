using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Managers;

public class LegendItemManager : Manager
{
	private static Dictionary<string, GDELegendItemData> _legendItemTemplates;

	private static Dictionary<string, SuitData> _suitDatas;

	private static Dictionary<string, Dictionary<int, GDELegendItemEnhancementData>> _legendItemEnhancementDataDict;

	private static Dictionary<string, Dictionary<int, LegendItemEnhancementConfig>> _legendItemEnhancementConfigs;

	public static Dictionary<string, Dictionary<int, int>> LegendItemNextUnlockEnhanceLevel = new Dictionary<string, Dictionary<int, int>>();

	public static Dictionary<string, List<Dictionary<string, int>>> _legendItemChangePropertyCosts;

	public static Dictionary<string, List<Dictionary<string, int>>> _legendItemReforgeCosts;

	public static Dictionary<string, List<Dictionary<string, int>>> _legendItemReforgeLockCosts;

	private static Dictionary<string, AttrCheckConf> _itemEntryEnableFilters;

	public static Dictionary<string, GDELegendItemData> LegendItemTemplates
	{
		get
		{
			if (_legendItemTemplates == null)
			{
				_legendItemTemplates = new Dictionary<string, GDELegendItemData>();
				foreach (GDELegendItemData allItem in GDMgr.GetAllItems<GDELegendItemData>())
				{
					_legendItemTemplates.Add(allItem.Key, allItem);
				}
			}
			return _legendItemTemplates;
		}
	}

	public static Dictionary<string, SuitData> SuitDatas
	{
		get
		{
			if (_suitDatas == null)
			{
				_suitDatas = new Dictionary<string, SuitData>();
				foreach (GDELegendItemSetData allItem in GDMgr.GetAllItems<GDELegendItemSetData>())
				{
					_suitDatas.Add(allItem.Key, new SuitData(allItem));
				}
			}
			return _suitDatas;
		}
	}

	public static Dictionary<string, Dictionary<int, GDELegendItemEnhancementData>> LegendItemEnhancementDataDict
	{
		get
		{
			if (_legendItemEnhancementDataDict == null)
			{
				_legendItemEnhancementDataDict = new Dictionary<string, Dictionary<int, GDELegendItemEnhancementData>>();
				foreach (GDELegendItemEnhancementData allItem in GDMgr.GetAllItems<GDELegendItemEnhancementData>())
				{
					if (!_legendItemEnhancementDataDict.TryGetValue(allItem.EnhanceConfigId, out var value))
					{
						value = new Dictionary<int, GDELegendItemEnhancementData>();
						_legendItemEnhancementDataDict.Add(allItem.EnhanceConfigId, value);
					}
					value.Add(allItem.EnhanceLevel, allItem);
				}
			}
			return _legendItemEnhancementDataDict;
		}
	}

	public static Dictionary<string, Dictionary<int, LegendItemEnhancementConfig>> LegendItemEnhancementConfigs
	{
		get
		{
			if (_legendItemEnhancementConfigs == null)
			{
				_legendItemEnhancementConfigs = new Dictionary<string, Dictionary<int, LegendItemEnhancementConfig>>();
				foreach (KeyValuePair<string, Dictionary<int, GDELegendItemEnhancementData>> item in LegendItemEnhancementDataDict)
				{
					string key = item.Key;
					Dictionary<int, GDELegendItemEnhancementData> value = item.Value;
					Dictionary<int, int> dictionary = new Dictionary<int, int>();
					if (!LegendItemEnhancementConfigs.TryGetValue(key, out var value2))
					{
						value2 = new Dictionary<int, LegendItemEnhancementConfig>();
						LegendItemEnhancementConfigs.Add(key, value2);
					}
					foreach (KeyValuePair<int, GDELegendItemEnhancementData> item2 in value)
					{
						int key2 = item2.Key;
						GDELegendItemEnhancementData value3 = item2.Value;
						if (!value2.ContainsKey(key2))
						{
							LegendItemEnhancementConfig legendItemEnhancementConfig = new LegendItemEnhancementConfig(value3);
							value2.Add(key2, legendItemEnhancementConfig);
							if (!dictionary.ContainsKey(legendItemEnhancementConfig.UnlockedSubEntries))
							{
								dictionary.Add(legendItemEnhancementConfig.UnlockedSubEntries, key2);
							}
						}
					}
					LegendItemNextUnlockEnhanceLevel.Add(key, dictionary);
				}
			}
			return _legendItemEnhancementConfigs;
		}
	}

	public static Dictionary<string, List<Dictionary<string, int>>> LegendItemChangePropertyCosts
	{
		get
		{
			if (_legendItemChangePropertyCosts == null)
			{
				_legendItemChangePropertyCosts = new Dictionary<string, List<Dictionary<string, int>>>();
				foreach (GDELegendItemData value in LegendItemTemplates.Values)
				{
					_legendItemChangePropertyCosts.Add(value.Key, new List<Dictionary<string, int>>());
					if (!string.IsNullOrEmpty(value.ChangePropertyCost))
					{
						_legendItemChangePropertyCosts[value.Key].AddRange(JsonHelper.ToObject<List<Dictionary<string, int>>>(value.ChangePropertyCost));
					}
				}
			}
			return _legendItemChangePropertyCosts;
		}
	}

	public static Dictionary<string, List<Dictionary<string, int>>> LegendItemReforgeCosts
	{
		get
		{
			if (_legendItemReforgeCosts == null)
			{
				_legendItemReforgeCosts = new Dictionary<string, List<Dictionary<string, int>>>();
				foreach (GDELegendItemData value in LegendItemTemplates.Values)
				{
					_legendItemReforgeCosts.Add(value.Key, new List<Dictionary<string, int>>());
					if (!string.IsNullOrEmpty(value.ReforgeCost))
					{
						_legendItemReforgeCosts[value.Key].AddRange(JsonHelper.ToObject<List<Dictionary<string, int>>>(value.ReforgeCost));
					}
				}
			}
			return _legendItemReforgeCosts;
		}
	}

	public static Dictionary<string, List<Dictionary<string, int>>> LegendItemReforgeLockCosts
	{
		get
		{
			if (_legendItemReforgeLockCosts == null)
			{
				_legendItemReforgeLockCosts = new Dictionary<string, List<Dictionary<string, int>>>();
				foreach (GDELegendItemData value in LegendItemTemplates.Values)
				{
					_legendItemReforgeLockCosts.Add(value.Key, new List<Dictionary<string, int>>());
					if (!string.IsNullOrEmpty(value.ReforgeLockCost))
					{
						_legendItemReforgeLockCosts[value.Key].AddRange(JsonHelper.ToObject<List<Dictionary<string, int>>>(value.ReforgeLockCost));
					}
				}
			}
			return _legendItemReforgeLockCosts;
		}
	}

	public static Dictionary<string, AttrCheckConf> ItemEntryEnableFilters
	{
		get
		{
			if (_itemEntryEnableFilters == null)
			{
				_itemEntryEnableFilters = new Dictionary<string, AttrCheckConf>();
				foreach (GDELegendItemPropertyData allItem in GDMgr.GetAllItems<GDELegendItemPropertyData>())
				{
					if (!string.IsNullOrEmpty(allItem.EnableFilters))
					{
						_itemEntryEnableFilters.Add(allItem.Key, JsonHelper.ToObject<AttrCheckConf>(allItem.EnableFilters));
					}
				}
			}
			return _itemEntryEnableFilters;
		}
	}

	public LegendItemManager(GameManagers managers)
		: base(managers)
	{
	}

	public override Task Init()
	{
		SharedMessenger.AddListener<PushItem>("ON_PING_PUSH_ITEM", OnPushItem);
		return null;
	}

	public static Dictionary<string, HashSet<string>> CountSetPieces(List<LegendItem> items)
	{
		Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();
		foreach (LegendItem item in items)
		{
			if (item == null || !LegendItemTemplates.TryGetValue(item.ItemId, out var value))
			{
				continue;
			}
			bool flag = !string.IsNullOrEmpty(item.SetAlias);
			if (string.IsNullOrEmpty(value.SetId) && !flag)
			{
				continue;
			}
			if (!string.IsNullOrEmpty(value.SetId))
			{
				if (!dictionary.TryGetValue(value.SetId, out var value2))
				{
					value2 = new HashSet<string>();
					dictionary[value.SetId] = value2;
				}
				value2.Add(value.Identity);
			}
			if (flag)
			{
				LegendItemsHelper.LegendItemSetMap.TryGetValue(item.SetAlias, out var value3);
				if (!dictionary.TryGetValue(value3.Key, out var value4))
				{
					value4 = new HashSet<string>();
					dictionary[value3.Key] = value4;
				}
				value4.Add(item.SetAlias);
			}
		}
		return dictionary;
	}

	public static int GetLegendItemSetInstanceCount()
	{
		if (LegendItemsHelper.LegendItems == null)
		{
			return 0;
		}
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		foreach (LegendItemUi legendItem in LegendItemsHelper.LegendItems)
		{
			if (!LegendItemTemplates.TryGetValue(legendItem.LegendItemData.ItemId, out var value) || string.IsNullOrEmpty(value.SetId))
			{
				continue;
			}
			string setId = value.SetId;
			if (dictionary.ContainsKey(setId))
			{
				List<string> list = dictionary[setId];
				if (!list.Contains(value.Name))
				{
					list.Add(value.Name);
					dictionary[setId] = list;
				}
			}
			else
			{
				dictionary.Add(setId, new List<string> { value.Name });
			}
		}
		int num = -1;
		foreach (KeyValuePair<string, List<string>> item in dictionary)
		{
			int count = item.Value.Count;
			if (count > num)
			{
				num = count;
			}
		}
		return num;
	}

	private void OnPushItem(PushItem item)
	{
		if (item.PacketId == PacketIds.PUSH_UNLOCK_LEGENDITEM)
		{
			Managers.UserArchiveManager.UnlockMainCityCom("MainCity.LegendItems");
		}
	}
}
