using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using GameDataEditor;
using GameMaths;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class StockController : Manager
{
	public Dictionary<string, int> AllRegionProductionSyncTime = new Dictionary<string, int>();

	private static Dictionary<string, GDEStorehouseData> _storehouseDataDictionary;

	private Dictionary<string, Config<StockConfig>> _stockConfigDictionary;

	private Dictionary<int, List<StockConfig>> _Cache_Stock_By_Category = new Dictionary<int, List<StockConfig>>();

	private static Dictionary<int, List<GDEStorehouseData>> _categorizedStorehouseData;

	private List<StockConfig> cache_BlackMarketLegendItem;

	private static readonly ConcurrentDictionary<string, string> _keyBuffer = new ConcurrentDictionary<string, string>();

	private static readonly ConcurrentDictionary<string, string> _categoryBuffer = new ConcurrentDictionary<string, string>();

	private bool _needSyncProduce;

	private bool _needGetAllProduceStatus;

	private readonly Dictionary<string, int> _pendingConsumedStock = new Dictionary<string, int>();

	public static Dictionary<string, GDEStorehouseData> StorehouseDataDictionary
	{
		get
		{
			if (_storehouseDataDictionary == null)
			{
				_storehouseDataDictionary = new Dictionary<string, GDEStorehouseData>();
				foreach (GDEStorehouseData allItem in GDMgr.GetAllItems<GDEStorehouseData>())
				{
					_storehouseDataDictionary.Add(allItem.Key, allItem);
				}
			}
			return _storehouseDataDictionary;
		}
	}

	private Dictionary<string, Config<StockConfig>> StockConfigDictionary
	{
		get
		{
			if (_stockConfigDictionary == null)
			{
				_stockConfigDictionary = new Dictionary<string, Config<StockConfig>>();
				foreach (GDEStorehouseData allItem in GDMgr.GetAllItems<GDEStorehouseData>())
				{
					Config<StockConfig> config = Managers.UserArchiveManager.GetConfig<StockConfig>(allItem.Key);
					if (config.GetValue() == null)
					{
						StockConfig value = new StockConfig
						{
							ItemId = allItem.ItemId,
							Key = allItem.Key,
							Stock = StorehouseDataDictionary[allItem.Key].Stock,
							Progress = 0f,
							type = (ItemType)Item.ItemType(allItem.ItemId)
						};
						config.SetValue(value);
					}
					StockConfig value2 = config.GetValue();
					int category = StorehouseDataDictionary[allItem.Key].Category;
					value2.ItemId = allItem.ItemId;
					value2.Key = allItem.Key;
					value2.Category = category;
					value2.type = (ItemType)Item.ItemType(allItem.ItemId);
					_stockConfigDictionary.Add(allItem.Key, config);
					if (!_Cache_Stock_By_Category.ContainsKey(category))
					{
						_Cache_Stock_By_Category.Add(category, new List<StockConfig>());
					}
					_Cache_Stock_By_Category[category].Add(value2);
				}
			}
			return _stockConfigDictionary;
		}
	}

	public static Dictionary<int, List<GDEStorehouseData>> CategorizedStorehouseData
	{
		get
		{
			if (_categorizedStorehouseData == null)
			{
				_categorizedStorehouseData = new Dictionary<int, List<GDEStorehouseData>>();
				foreach (GDEStorehouseData value in StorehouseDataDictionary.Values)
				{
					if (!_categorizedStorehouseData.ContainsKey(value.Category))
					{
						_categorizedStorehouseData.Add(value.Category, new List<GDEStorehouseData>());
					}
					_categorizedStorehouseData[value.Category].Add(value);
				}
			}
			return _categorizedStorehouseData;
		}
		set
		{
			_categorizedStorehouseData = value;
		}
	}

	public bool NeedSyncProduce
	{
		get
		{
			return _needSyncProduce;
		}
		set
		{
			_needSyncProduce = value;
		}
	}

	public bool NeedGetAllProduceStatus
	{
		get
		{
			return _needGetAllProduceStatus;
		}
		set
		{
			_needGetAllProduceStatus = value;
		}
	}

	public List<float> GetStockPercentByCategory(int _Category, int Top)
	{
		List<float> list = new List<float>();
		_Cache_Stock_By_Category.TryGetValue(_Category, out var value);
		if (value == null)
		{
			return list;
		}
		if (_Category == 13)
		{
			if (cache_BlackMarketLegendItem == null)
			{
				cache_BlackMarketLegendItem = new List<StockConfig>();
				foreach (StockConfig item in value)
				{
					if (item.type == ItemType.BlackMarketLegendItem || item.type == ItemType.AutoIdentifyLegendItem)
					{
						cache_BlackMarketLegendItem.Add(item);
					}
				}
			}
			foreach (StockConfig item2 in cache_BlackMarketLegendItem)
			{
				if (item2.Stock > 0)
				{
					LegendItemsHelper.BlackMarketLegendItemInStorage(item2.ItemId, item2.Stock);
					item2.Stock = 0;
				}
			}
		}
		value.OrderByDescending((StockConfig o) => o.Stock).ToList();
		int num = 0;
		int limit = GetLimit(value[0].ItemId);
		int count = value.Count;
		int num2 = Math.Min(Top, count);
		for (int num3 = 0; num3 < num2; num3++)
		{
			list.Add(1f * (float)value[num3].Stock / (float)limit);
		}
		return list;
	}

	private int _SortStockConfig(StockConfig a, StockConfig b)
	{
		if (a.Stock > b.Stock)
		{
			return -1;
		}
		if (a.Stock < b.Stock)
		{
			return 1;
		}
		return 0;
	}

	public StockController(GameManagers managers)
		: base(managers)
	{
	}

	public override Task Init()
	{
		AddEventListener();
		return null;
	}

	private new void AddEventListener()
	{
	}

	private static string GetItemKey(string value)
	{
		if (!_keyBuffer.TryGetValue(value, out var value2))
		{
			value2 = "SH_" + value;
			_keyBuffer[value] = value2;
		}
		return value2;
	}

	private static string GetCategoryKey(string value)
	{
		if (!_categoryBuffer.TryGetValue(value, out var value2))
		{
			value2 = "Category" + value;
			_categoryBuffer[value] = value2;
		}
		return value2;
	}

	public static GDEStorehouseData GetStorehouseData(string itemId)
	{
		string itemKey = GetItemKey(itemId);
		if (!StorehouseDataDictionary.TryGetValue(itemKey, out var value))
		{
		}
		return value;
	}

	public Config<StockConfig> GetStockConfig(string itemId)
	{
		string itemKey = GetItemKey(itemId);
		if (!StockConfigDictionary.TryGetValue(itemKey, out var value))
		{
			value = Managers.UserArchiveManager.GetConfig<StockConfig>(itemKey);
			int num = -1;
			if (value.GetValue() == null)
			{
				int stock = 0;
				if (StorehouseDataDictionary.TryGetValue(itemKey, out var value2))
				{
					stock = value2.Stock;
					num = value2.Category;
				}
				StockConfig value3 = new StockConfig
				{
					ItemId = itemId,
					Key = itemKey,
					Stock = stock,
					Progress = 0f,
					Category = num
				};
				value.SetValue(value3);
			}
			value.GetValue().type = (ItemType)Item.ItemType(itemId);
			StockConfigDictionary.Add(itemKey, value);
			if (!_Cache_Stock_By_Category.ContainsKey(num))
			{
				_Cache_Stock_By_Category.Add(num, new List<StockConfig>());
			}
			_Cache_Stock_By_Category[num].Add(value.GetValue());
		}
		return value;
	}

	public bool IsFull(string itemId)
	{
		StockConfig value = GetStockConfig(itemId).GetValue();
		return value.Stock - GetPendingConsumedStock(itemId) >= GetLimit(itemId);
	}

	public bool IsEnough(string itemId, int requireQty)
	{
		StockConfig value = GetStockConfig(itemId).GetValue();
		return value.Stock - GetPendingConsumedStock(itemId) >= requireQty;
	}

	public int GetLimit(string itemId, StockCategory category = StockCategory.Unknown)
	{
		string value2;
		int num;
		if (category == StockCategory.Unknown && StorehouseDataDictionary.TryGetValue(GetItemKey(itemId), out var value))
		{
			value2 = value.Category.ToString();
			num = value.Category;
		}
		else
		{
			num = (int)category;
			value2 = num.ToString();
		}
		int num2 = ((num == 2) ? GameManagers.Instance.UserArchiveManager.GetIslandComeAgainSoldierStockLimitIncrement() : 0);
		int num3 = ((num == 2) ? Managers.UserArchiveManager.GetGvGSoldierStockLimit战时扩编Increment().LimitIncrease : 0);
		int num4 = ((num == 2) ? Managers.UserArchiveManager.GetGvGShipPlanSoldiersStockLimitOccupiedValue() : 0);
		string[] subKeys = new string[2]
		{
			GetItemKey(itemId),
			GetCategoryKey(value2)
		};
		return (int)((float)GetOriginLimit(itemId) * (1f + Managers.ModifierManager.GetPercentFloatPayload("StockLimit", subKeys)) + (float)num2 + (float)num3 + (float)num4 + Managers.ModifierManager.GetFixedFloatPayload("StockLimit", subKeys));
	}

	public int GetLimit(StockCategory category)
	{
		if (CategorizedStorehouseData.TryGetValue((int)category, out var value) && value.Count > 0)
		{
			GDEStorehouseData gDEStorehouseData = value[0];
			return GetLimit(gDEStorehouseData.ItemId, category);
		}
		return 0;
	}

	public static int GetOriginLimit(string itemId)
	{
		string itemKey = GetItemKey(itemId);
		if (StorehouseDataDictionary.TryGetValue(itemKey, out var value))
		{
			return value.StockSpace;
		}
		return 0;
	}

	public static int GetGvgSupplyOriginLimit()
	{
		return GDMgr.Get<GDEStorehouseData>("SH_I63113").StockSpace;
	}

	public int GetStock(string itemId)
	{
		int stock = GetStockConfig(itemId).GetValue().Stock;
		return stock - GetPendingConsumedStock(itemId);
	}

	public int AddStock(string itemId, int qty, StockInContext context, string contextValue = null, bool sendStockChangeEvent = true, bool changeFromServer = false)
	{
		Config<StockConfig> stockConfig = GetStockConfig(itemId);
		StockConfig value = stockConfig.GetValue();
		int stock = value.Stock;
		int pendingConsumedStock = GetPendingConsumedStock(itemId);
		int limit = GetLimit(itemId);
		bool flag = stock - pendingConsumedStock >= limit;
		int num = stock;
		if (flag)
		{
			if (qty < 0)
			{
				num += qty;
			}
		}
		else
		{
			num = Math.Min(limit + pendingConsumedStock, stock + qty);
		}
		if (stock != num)
		{
			NeedSyncProduce = true;
		}
		if (stock != value.Stock && sendStockChangeEvent)
		{
			Managers.Messenger.Broadcast("ON_STOCK_CHANGE", itemId, value.Stock - stock, (context, contextValue));
		}
		if (flag)
		{
			Managers.Messenger.Broadcast("STOCK_IS_FULL", itemId);
		}
		return value.Stock;
	}

	public int IncrStock(string itemId, int incrBy, StockInContext context, string contextValue = null, bool sendStockChangeEvent = true, bool changeFromServer = false)
	{
		Config<StockConfig> stockConfig = GetStockConfig(itemId);
		StockConfig value = stockConfig.GetValue();
		if (incrBy != 0)
		{
			NeedSyncProduce = true;
		}
		return value.Stock;
	}

	public Dictionary<string, int> GetPendingStocks()
	{
		return _pendingConsumedStock;
	}

	public int GetPendingConsumedStock(string itemId)
	{
		if (_pendingConsumedStock.TryGetValue(itemId, out var value))
		{
			return value;
		}
		return 0;
	}

	public void SyncPendingConsumedStock(Dictionary<string, int> newPendingStocks)
	{
		_pendingConsumedStock.Clear();
		foreach (KeyValuePair<string, int> newPendingStock in newPendingStocks)
		{
			_pendingConsumedStock.Add(newPendingStock.Key, newPendingStock.Value);
		}
	}

	public Dictionary<string, int> GetStocksByType(ItemType type, bool onlyUnlocked = false, bool includeEmptyStock = true)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		if (!CategorizedStorehouseData.TryGetValue((int)type, out var value))
		{
			return dictionary;
		}
		foreach (GDEStorehouseData item in value)
		{
			StockConfig value2 = StockConfigDictionary[item.Key].GetValue();
			bool flag = (type != ItemType.Weapon && type != ItemType.CollectableResource) || Managers.UserArchiveManager.GetItemLevel(item.Key) > 0;
			if ((!onlyUnlocked || flag) && (value2.Stock >= 1 || includeEmptyStock))
			{
				dictionary.Add(item.ItemId, value2.Stock);
			}
		}
		return dictionary;
	}

	public void ReadStockChangeRecords(IEnumerable<StockChangeRecord> stockChangeRecords)
	{
		if (stockChangeRecords == null)
		{
			return;
		}
		int value = (int)GameController.Instance.GetServerTime();
		bool flag = false;
		bool flag2 = false;
		int num = 0;
		List<string> list = new List<string>();
		bool isShowDetail = false;
		foreach (StockChangeRecord stockChangeRecord in stockChangeRecords)
		{
			if (!string.IsNullOrEmpty(stockChangeRecord.ItemId) && stockChangeRecord.Offset != 0)
			{
				Config<StockConfig> stockConfig = GetStockConfig(stockChangeRecord.ItemId);
				string itemKey = GetItemKey(stockChangeRecord.ItemId);
				if (!flag && Item.ItemType(stockChangeRecord.ItemId) == 3)
				{
					flag = true;
					GameManagers.Instance.NewMsgIncomingManager.FlushCache_AnySoldierHasNewPotentialProgress();
				}
				StockConfig value2 = stockConfig.GetValue();
				value2.Stock += stockChangeRecord.Offset;
				stockConfig.SetValue(value2);
				if (stockChangeRecord.ItemId == "TechPoint" && stockChangeRecord.Offset > 0)
				{
					num += stockChangeRecord.Offset;
					flag2 = true;
				}
				if (!AllRegionProductionSyncTime.ContainsKey(stockChangeRecord.ItemId))
				{
					AllRegionProductionSyncTime.Add(stockChangeRecord.ItemId, 0);
				}
				AllRegionProductionSyncTime[stockChangeRecord.ItemId] = value;
				Managers.Messenger.Broadcast("ON_STOCK_CHANGE", stockChangeRecord.ItemId, stockChangeRecord.Offset, ((StockInContext)stockChangeRecord.Context, stockChangeRecord.ContextValue));
				if (Item.ItemType(stockChangeRecord.ItemId) == 17 || Item.ItemType(stockChangeRecord.ItemId) == 20)
				{
					list.Add(stockChangeRecord.ItemId);
				}
				isShowDetail = Item.ItemType(stockChangeRecord.ItemId) == 20;
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			if (i == 0)
			{
				LegendItemsHelper.BlackMarketLegendItemInStorage(list[i], 1, showSfx: true, isShowDetail);
			}
			else
			{
				LegendItemsHelper.BlackMarketLegendItemInStorage(list[i], 1);
			}
		}
		if (!flag2)
		{
		}
	}

	public int AddStock(string itemId, float floatQty, StockInContext context, string contextValue = null)
	{
		return AddStock(itemId, ProcessFloatStock(itemId, floatQty), context, contextValue);
	}

	public int IncrStock(string itemId, float floatIncrBy, StockInContext context, string contextValue = null)
	{
		return IncrStock(itemId, ProcessFloatStock(itemId, floatIncrBy), context, contextValue);
	}

	private int ProcessFloatStock(string itemId, float floatQty)
	{
		Config<StockConfig> stockConfig = GetStockConfig(itemId);
		StockConfig value = stockConfig.GetValue();
		float num = value.Progress + floatQty;
		int num2 = Mathf.FloorToInt(num);
		value.Progress = num - (float)num2;
		stockConfig.SetValue(value);
		return num2;
	}

	public void SetStock(string itemId, int num, StockInContext context, string contextValue = null, bool sendStockChangeEvent = true)
	{
		Config<StockConfig> stockConfig = GetStockConfig(itemId);
		StockConfig value = stockConfig.GetValue();
		int stock = value.Stock;
		int arg = num - stock;
		value.Stock = num;
		if (sendStockChangeEvent)
		{
			Managers.Messenger.Broadcast("ON_STOCK_CHANGE", itemId, arg, (context, contextValue));
		}
	}

	public void ChangeStock(string itemId, int num, StockInContext context, string contextValue = null, bool sendStockChangeEvent = true)
	{
		Config<StockConfig> stockConfig = GetStockConfig(itemId);
		StockConfig value = stockConfig.GetValue();
		int stock = value.Stock;
		int num2 = num - stock;
		if (num2 != 0)
		{
			NeedSyncProduce = true;
		}
		Managers.Messenger.Broadcast("ON_STOCK_CHANGE", itemId, num2, (context, contextValue));
	}

	public List<GDEStorehouseData> GetAllStockData(StockCategory category = StockCategory.Unknown, bool filterEmpty = true)
	{
		if (category != StockCategory.Unknown)
		{
			List<GDEStorehouseData> list = new List<GDEStorehouseData>();
			foreach (GDEStorehouseData value2 in StorehouseDataDictionary.Values)
			{
				StockConfig value = StockConfigDictionary[value2.Key].GetValue();
				if ((!filterEmpty || value.Stock > 0) && value2.Category == (int)category)
				{
					list.Add(value2);
				}
			}
			return list;
		}
		return new List<GDEStorehouseData>(StorehouseDataDictionary.Values);
	}

	public static string GetJumpContext(string itemId)
	{
		GDEStorehouseData storehouseData = GetStorehouseData(itemId);
		return string.IsNullOrEmpty(storehouseData?.JumpContext) ? null : storehouseData.JumpContext;
	}

	public Dictionary<string, int> GetOwnedSoldiers(bool onlyUnlocked = false, bool includeEmptyStock = true)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		List<string> unlockedSoldiers = Managers.UserArchiveManager.GetUnlockedSoldiers();
		foreach (GDEStorehouseData item in CategorizedStorehouseData[2])
		{
			StockConfig value = StockConfigDictionary[item.Key].GetValue();
			bool flag = unlockedSoldiers.Contains(item.ItemId);
			if ((!onlyUnlocked || flag) && (value.Stock >= 1 || ((!flag || includeEmptyStock) && flag)))
			{
				dictionary.Add(item.ItemId, value.Stock);
			}
		}
		return dictionary;
	}
}
