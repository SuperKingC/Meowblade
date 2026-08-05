using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public class RecycleManager : Manager
{
	public const string AutoEnableMultiplayerAtKey = "AutoEnableMultiplayerAt";

	public const string RebateRateKey = "RebateRate";

	private Config<int> _recycleExportTo;

	private Config<bool> _recycleEnableMultiplayer;

	private Config<string> _autoEnableMultiplayerAt;

	private static Dictionary<string, List<RecycleProduct>> _recycleProductsByItemId;

	private static Dictionary<string, RecycleProduct> _recycleProducts;

	public static Func<int, Task<GetRecycleProductsResponse>> SendGetRecycleProductsRequest;

	public float RebateRate
	{
		get
		{
			float num = Managers.BuildingManager.GetBuildingByType<MoltenCore>("17")?.BaseRebateRate ?? 0.01f;
			return num * (1f + Managers.ModifierManager.GetPercentFloatPayload("RecycleRebate")) + Managers.ModifierManager.GetFixedFloatPayload("RecycleRebate");
		}
	}

	public Config<int> RecycleExportTo
	{
		get
		{
			UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
			userArchiveManager.EnsureDailyAttributesExpireAt();
			if (_recycleExportTo == null)
			{
				if (!userArchiveManager.Contains("RecycleExportTo"))
				{
					userArchiveManager.SetConfigValue("RecycleExportTo", Managers.Archive.UserId);
				}
				_recycleExportTo = userArchiveManager.GetConfig<int>("RecycleExportTo");
			}
			return _recycleExportTo;
		}
	}

	public Config<bool> RecycleEnableMultiplayer
	{
		get
		{
			UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
			userArchiveManager.EnsureDailyAttributesExpireAt();
			if (_recycleEnableMultiplayer == null)
			{
				if (!userArchiveManager.Contains("RecycleEnableMultiplayer"))
				{
					userArchiveManager.SetConfigValue("RecycleEnableMultiplayer", value: false);
				}
				_recycleEnableMultiplayer = userArchiveManager.GetConfig<bool>("RecycleEnableMultiplayer");
			}
			return _recycleEnableMultiplayer;
		}
	}

	public Config<string> AutoEnableMultiplayerAt
	{
		get
		{
			if (_autoEnableMultiplayerAt == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (!userArchiveManager.Contains("AutoEnableMultiplayerAt"))
				{
					userArchiveManager.SetConfigValue("AutoEnableMultiplayerAt", "P420");
				}
				_autoEnableMultiplayerAt = userArchiveManager.GetConfig<string>("AutoEnableMultiplayerAt");
			}
			return _autoEnableMultiplayerAt;
		}
	}

	public static Dictionary<string, List<RecycleProduct>> RecycleProductsByItemId
	{
		get
		{
			if (_recycleProductsByItemId == null)
			{
				_recycleProductsByItemId = new Dictionary<string, List<RecycleProduct>>();
				foreach (RecycleProduct value in RecycleProducts.Values)
				{
					string key = value.Requirements.First().Key;
					if (!_recycleProductsByItemId.ContainsKey(key))
					{
						_recycleProductsByItemId.Add(key, new List<RecycleProduct>());
					}
					_recycleProductsByItemId[key].Add(value);
				}
			}
			return _recycleProductsByItemId;
		}
	}

	public static Dictionary<string, RecycleProduct> RecycleProducts
	{
		get
		{
			if (_recycleProducts == null)
			{
				_recycleProducts = new Dictionary<string, RecycleProduct>();
				IEnumerable<GDERecycleProductData> allItems = GDMgr.GetAllItems<GDERecycleProductData>();
				foreach (GDERecycleProductData item in allItems)
				{
					_recycleProducts.Add(item.Key, new RecycleProduct(item));
				}
			}
			return _recycleProducts;
		}
	}

	public List<RecycleProduct> CurrentRecyclingProducts { get; set; } = new List<RecycleProduct>();

	public RecycleManager(GameManagers managers)
		: base(managers)
	{
	}

	public override Task Init()
	{
		return null;
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<string, Level, Team, bool>("LEVEL_COMPLETED", OnLevelCompleted);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener<string, Level, Team, bool>("LEVEL_COMPLETED", OnLevelCompleted);
	}

	private void OnLevelCompleted(string battleId, Level level, Team winner, bool newCompleteFlag)
	{
		if (!(level.LevelId == AutoEnableMultiplayerAt.GetValue()))
		{
		}
	}

	public List<RecycleProduct> RandomRecycleProducts(List<string> randomRange, int total = 5)
	{
		List<RecycleProduct> list = new List<RecycleProduct>();
		List<string> list2 = RecycleProductsByItemId.Keys.Intersect(randomRange).ToList();
		string[] array = new string[total];
		List<string>[] array2 = Managers.UserArchiveManager.GetLevelProgress().Values.ToArray();
		int buildingLevel = Managers.UserArchiveManager.GetBuildingLevel("17");
		for (int i = 0; i < total; i++)
		{
			if (list2.Count < 1)
			{
				break;
			}
			int index = Managers.RandomManager.Int(0, list2.Count);
			string key = (array[i] = list2[index]);
			list2.RemoveAt(index);
			int num = 0;
			Dictionary<RecycleProduct, int> dictionary = new Dictionary<RecycleProduct, int>();
			foreach (RecycleProduct item in RecycleProductsByItemId[key])
			{
				if (!string.IsNullOrEmpty(item.LevelFilter))
				{
					bool flag = false;
					List<string>[] array3 = array2;
					foreach (List<string> list3 in array3)
					{
						if (list3.Contains(item.LevelFilter))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						continue;
					}
				}
				int num2 = 0;
				num2 = buildingLevel switch
				{
					5 => item.Data.Level5Weight, 
					4 => item.Data.Level4Weight, 
					3 => item.Data.Level3Weight, 
					2 => item.Data.Level2Weight, 
					_ => item.Data.Level1Weight, 
				};
				num += num2;
				dictionary.Add(item, num2);
			}
			int num3 = 0;
			int num4 = 0;
			int num5 = Managers.RandomManager.Int(0, num);
			foreach (KeyValuePair<RecycleProduct, int> item2 in dictionary)
			{
				RecycleProduct key2 = item2.Key;
				int value = item2.Value;
				num3 += value;
				if (num5 >= num4 && num5 < num3)
				{
					list.Add(key2);
					break;
				}
				num4 = num3;
			}
		}
		return list;
	}

	public async Task GetCurrentRecyclingProducts(Action action = null)
	{
		CustomTaskCompletionSource<bool> taskCompletionSource = new CustomTaskCompletionSource<bool>();
		taskCompletionSource.IsAsync = true;
		ILRequestHelper<GetRecycleProductsResponse>.Request(null, () => SendGetRecycleProductsRequest(-1), delegate(GetRecycleProductsResponse response)
		{
			if (response.Result && response.Products != null)
			{
				CurrentRecyclingProducts.Clear();
				foreach (string product in response.Products)
				{
					if (RecycleProducts.TryGetValue(product, out var value))
					{
						CurrentRecyclingProducts.Add(value);
					}
				}
				Managers.RecycleManager.RecycleExportTo.SetValue(response.RecycleExportTo);
				taskCompletionSource.TrySetResult(result: true);
				action?.Invoke();
			}
			else
			{
				taskCompletionSource.TrySetResult(result: false);
			}
		}, 1f);
		await taskCompletionSource.Task;
	}
}
