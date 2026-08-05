using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyGUI;
using GameDataEditor;
using GameMaths;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.Sources.Protocol;
using Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;

public class GvG3StoreManager : Singleton<GvG3StoreManager>
{
	public class GvGStoreConfigData
	{
		public GetGvGStoreItemsResponse Response;

		public bool HasRedDot => !GameLocalDataManager.GetGvGStoreHasCheck();

		public int NextUpdateTime => GameLocalDataManager.GetGvGStoreNextUpdateTimestamp();
	}

	public class GuaranteedTicketConfig
	{
		public int RefreshCountCost;

		public string Reward;
	}

	public class SoulKeyStoreConfigData
	{
		public const string FreeCurrencyId = "I32100";

		public const string PaidCurrencyId = "I32101";

		public const string SoulkeyMerchantId_Free = "SoulkeyMerchant1";

		public const string SoulkeyMerchantId_Paid = "SoulkeyMerchant2";

		public Activity FreeActivity;

		public Activity PaidActivity;

		public List<StoreItem_Ex> FreeItemList = new List<StoreItem_Ex>();

		public List<StoreItem_Ex> PaidItemList = new List<StoreItem_Ex>();

		public List<StoreItem_Ex> FreeItemList_Sorted;

		public List<StoreItem_Ex> PaidItemList_Sorted;
	}

	public class StoreItem_Ex : global::Shift.Legion.Common.Models.Store.StoreItem
	{
		public int Price_Cached = -1;

		public StoreItem_Ex(GameManagers managers, string storeItemId)
			: base(managers, storeItemId)
		{
		}
	}

	public enum eStellarKeyType
	{
		I63133,
		I63134,
		I63135
	}

	public enum eStellarStorePage
	{
		I63133,
		I63134,
		Special
	}

	public class StellarKeyStoreConfigData
	{
		public static readonly string[] FormulaIds = new string[2] { "starkeys_1", "starkeys_2" };

		public Dictionary<string, StellarKeyStorePageData> Page_Dict = new Dictionary<string, StellarKeyStorePageData>();

		public Dictionary<string, JsonActivityData> Activity_Dict = new Dictionary<string, JsonActivityData>();
	}

	public class StellarKeyStorePageData
	{
		public string ActivityId;

		public List<Product> Product_List;
	}

	private GvGStoreConfigData GvGStoreData = null;

	private bool _hasGvGStoreNotice = false;

	public Action OnChangeGvGStoreNotice = delegate
	{
	};

	private GetGvGStoreGuaranteedItemsResponse _cacheGuaranteedItems;

	private GetGvGStoreInfoResponse _cacheStoreInfo;

	private Action<GetGvGStoreInfoResponse> _onGetStoreInfoComplete;

	private GuaranteedTicketConfig _ticketConfig;

	public Action EOnCurrentExchangeScoreChange = delegate
	{
	};

	private StoreActivateMode _lastReturnStatus;

	private SoulKeyStoreConfigData SoulKeyStoreData = null;

	private bool IsSoulKeyStoreLoadingStarted = false;

	private Action<SoulKeyStoreConfigData> OnSoulKeyStoreDataLoaded = delegate
	{
	};

	private bool _hasSoulKeyStoreNotice_Free = false;

	private bool _hasSoulKeyStoreNotice_Paid = false;

	public Action OnChangeSoulKeyStoreNotice = delegate
	{
	};

	private StellarKeyStoreConfigData StellarKeyStoreData = null;

	private bool _hasStellarKeyStoreNotice = false;

	private bool _isStellarKeyStoreActive = false;

	public Action OnChangeStellarKeyStoreNotice = delegate
	{
	};

	public GuaranteedTicketConfig TicketConfig
	{
		get
		{
			if (_ticketConfig == null)
			{
				GDEConfigurationData gDEConfigurationData = GDMgr.Get<GDEConfigurationData>("GvGStoreGetGuaranteedTicketConfig");
				_ticketConfig = JsonHelper.ToObject<GuaranteedTicketConfig>(gDEConfigurationData.Config);
			}
			return _ticketConfig;
		}
	}

	public bool HasGvGStoreNotice => _hasGvGStoreNotice;

	public int CurrentExchangeScore => _cacheStoreInfo.RemainingExchangeableRefreshCount;

	public int NotSilentTimestamp => _cacheStoreInfo.NotSilentTimestamp;

	public bool HasSoulKeyStoreNotice_Free => _hasSoulKeyStoreNotice_Free;

	public bool HasSoulKeyStoreNotice_Paid => _hasSoulKeyStoreNotice_Paid;

	public bool HasStellarKeyStoreNotice => _hasStellarKeyStoreNotice;

	public bool IsStellarKeyStoreActive => _isStellarKeyStoreActive;

	public void GetGvGStoreData(Action<GvGStoreConfigData> onLoaded = null, bool manual = false, bool forceRefresh = false)
	{
		Singleton<GvGMode3RoomManager>.Instance.GetGSObserverRecord(delegate
		{
			GetIzGvGStoreActivatedAsync(delegate
			{
				if (GvGStoreData != null && GvGStoreData.NextUpdateTime > (int)GameController.Instance.GetServerTime() && !manual && !forceRefresh)
				{
					onLoaded?.Invoke(GvGStoreData);
				}
				else
				{
					GameManagers.Instance.UserArchiveManager.GetGvGStoreItems(delegate(GetGvGStoreItemsResponse res)
					{
						int gvGStoreNextUpdateTimestamp = GameLocalDataManager.GetGvGStoreNextUpdateTimestamp();
						if (gvGStoreNextUpdateTimestamp != res.NextUpdateTime)
						{
							GameLocalDataManager.SetGvGStoreNextUpdateTimestamp(res.NextUpdateTime);
							GameLocalDataManager.SetGvGStoreHasCheck(manual);
						}
						GvGStoreData = new GvGStoreConfigData
						{
							Response = res
						};
						_cacheStoreInfo.NotSilentTimestamp = res.NotSilentTimestamp;
						_cacheStoreInfo.RemainingExchangeableRefreshCount = res.RemainingExchangeableRefreshCount;
						UpdateTotalRefreshCount(res.TotalRefreshCount);
						GameManagers.Instance.UserArchiveManager.UpdateGvGStoreTotalDrawCount(res.TotalRefreshCount);
						SharedMessenger.Broadcast("ON_GVG_STORE_REFRESH_ITEMS");
						EOnCurrentExchangeScoreChange?.Invoke();
						onLoaded?.Invoke(GvGStoreData);
					}, manual);
				}
			});
		});
	}

	public void GetIzGvGStoreActivatedAsync(Action<StoreActivateMode> callback)
	{
		GetGvgStoreInfoWithCacheAsync(delegate(GetGvGStoreInfoResponse response)
		{
			StoreActivateMode activateMode = (StoreActivateMode)response.ActivateMode;
			if (_lastReturnStatus != activateMode)
			{
				GvGStoreData = null;
			}
			_lastReturnStatus = activateMode;
			callback(activateMode);
		}, forceRefresh: true);
	}

	public void GetHasAttendedAnyIzConfigIdAsync(Action<bool> callback)
	{
		bool forceRefresh = _cacheStoreInfo != null && !_cacheStoreInfo.HasAttended;
		GetGvgStoreInfoWithCacheAsync(delegate(GetGvGStoreInfoResponse response)
		{
			callback(response.HasAttended);
		}, forceRefresh);
	}

	private void GetGvgStoreInfoWithCacheAsync(Action<GetGvGStoreInfoResponse> callback, bool forceRefresh)
	{
		if (_cacheStoreInfo == null || forceRefresh)
		{
			Task<GetGvGStoreInfoResponse> task = GameController.Contexts.Service<INetworkService>().GetGvGStoreInfo();
			task.GetAwaiter().OnCompleted(delegate
			{
				GetGvGStoreInfoResponse result = task.Result;
				if (!result.Result)
				{
					ILRequestHelper.ShowErrorCode(result.ErrorCode);
					_onGetStoreInfoComplete = null;
				}
				else
				{
					_cacheStoreInfo = result;
					callback(_cacheStoreInfo);
				}
			});
		}
		else
		{
			callback(_cacheStoreInfo);
		}
	}

	public void GetGvGStoreGuaranteedItemsAsync(Action<GetGvGStoreGuaranteedItemsResponse> callback, bool forceRefresh = false)
	{
		if (forceRefresh)
		{
			RequestNewGvGStoreGuaranteedItems(callback);
		}
		else if (_cacheGuaranteedItems == null)
		{
			RequestNewGvGStoreGuaranteedItems(callback);
		}
		else
		{
			callback(_cacheGuaranteedItems);
		}
	}

	private void RequestNewGvGStoreGuaranteedItems(Action<GetGvGStoreGuaranteedItemsResponse> callback)
	{
		Task<GetGvGStoreGuaranteedItemsResponse> task = GameController.Contexts.Service<INetworkService>().GetGvGStoreGuaranteedItems();
		task.GetAwaiter().OnCompleted(delegate
		{
			GetGvGStoreGuaranteedItemsResponse result = task.Result;
			if (!result.Result)
			{
				ILRequestHelper.ShowErrorCode(result.ErrorCode);
			}
			else
			{
				_cacheGuaranteedItems = result;
				callback(_cacheGuaranteedItems);
			}
		});
	}

	public void UpdateGuaranteedItemPurchasedCount(string formulaId)
	{
		if (_cacheGuaranteedItems == null)
		{
			return;
		}
		foreach (List<GvGStoreGuaranteedItem> value in _cacheGuaranteedItems.GuaranteedItemDict.Values)
		{
			foreach (GvGStoreGuaranteedItem item in value)
			{
				if (!(item.FormulaId != formulaId) && item.RemainingBuyCount >= 0)
				{
					item.RemainingBuyCount = Mathf.Max(item.RemainingBuyCount - 1, 0);
				}
			}
		}
	}

	public void UpdateTotalRefreshCount(int total)
	{
		if (_cacheGuaranteedItems != null)
		{
			_cacheGuaranteedItems.TotalRefreshCount = total;
		}
	}

	public void ExchangeGvGStoreGuaranteedTicket(Action onSuccess)
	{
		Task<ExchangeGvGStoreGuaranteedTicketResponse> task = GameController.Contexts.Service<INetworkService>().ExchangeGvGStoreGuaranteedTicket();
		task.GetAwaiter().OnCompleted(delegate
		{
			ExchangeGvGStoreGuaranteedTicketResponse result = task.Result;
			if (!result.Result)
			{
				ILRequestHelper.ShowErrorCode(result.ErrorCode);
			}
			else
			{
				_cacheStoreInfo.RemainingExchangeableRefreshCount = result.RemainingExchangeableRefreshCount;
				GameManagers.Instance.StockController.ReadStockChangeRecords(result.StockChangeRecords);
				onSuccess?.Invoke();
			}
		});
	}

	public void AddRemainingExchangeableRefreshCount(int addCount)
	{
		if (_cacheStoreInfo != null)
		{
			_cacheStoreInfo.RemainingExchangeableRefreshCount += addCount;
		}
	}

	public void CheckGvGStoreNotice()
	{
		GetGvGStoreData(delegate(GvGStoreConfigData data)
		{
			bool hasRedDot = data.HasRedDot;
			if (hasRedDot != _hasGvGStoreNotice)
			{
				_hasGvGStoreNotice = hasRedDot;
				OnChangeGvGStoreNotice?.Invoke();
			}
		});
	}

	public void CheckGvGStorePanel()
	{
		GameLocalDataManager.SetGvGStoreHasCheck(b: true);
		CheckGvGStoreNotice();
	}

	public void GetSoulKeyStoreData(Action<SoulKeyStoreConfigData> onLoaded = null)
	{
		if (SoulKeyStoreData != null)
		{
			onLoaded?.Invoke(SoulKeyStoreData);
			return;
		}
		if (onLoaded != null)
		{
			OnSoulKeyStoreDataLoaded = (Action<SoulKeyStoreConfigData>)Delegate.Combine(OnSoulKeyStoreDataLoaded, onLoaded);
		}
		if (!IsSoulKeyStoreLoadingStarted)
		{
			IsSoulKeyStoreLoadingStarted = true;
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(LoadSoulKeyStoreData());
		}
	}

	private IEnumerator LoadSoulKeyStoreData()
	{
		SoulKeyStoreConfigData data = new SoulKeyStoreConfigData();
		List<Activity> activities = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.SoulKeyStore, null, isSort: false);
		for (int j = activities.Count - 1; j >= 0; j--)
		{
			if (activities[j].GetStatus(GameManagers.Instance) == ActivityStatus.Enabled)
			{
				if (activities[j].ActivityId == "SoulkeyMerchant1")
				{
					data.FreeActivity = activities[j];
				}
				else if (activities[j].ActivityId == "SoulkeyMerchant2")
				{
					data.PaidActivity = activities[j];
				}
			}
		}
		yield return null;
		yield return LoadStoreItems(data.FreeActivity, data.FreeItemList, 0);
		yield return LoadStoreItems(data.PaidActivity, data.PaidItemList, 1);
		yield return null;
		data.FreeItemList_Sorted = data.FreeItemList.ToList();
		data.FreeItemList_Sorted.Sort(StoreItemSortComparer);
		yield return null;
		data.PaidItemList_Sorted = data.PaidItemList.ToList();
		data.PaidItemList_Sorted.Sort(StoreItemSortComparer);
		yield return null;
		SoulKeyStoreData = data;
		OnSoulKeyStoreDataLoaded(data);
		OnSoulKeyStoreDataLoaded = null;
		IsSoulKeyStoreLoadingStarted = false;
	}

	private IEnumerator LoadStoreItems(Activity storeItemsActivity, List<StoreItem_Ex> storeItems, int PriceIdx)
	{
		if (storeItemsActivity == null)
		{
			yield break;
		}
		int yieldCount = 2;
		Dictionary<string, ActivityContentPayload> contentPayload = storeItemsActivity.ContentPayload(GameManagers.Instance);
		foreach (string _key in contentPayload.Keys)
		{
			Task<GetStoreActivityItemsResponse> task = GameController.Contexts.Service<INetworkService>().GetStoreActivityItems(storeItemsActivity.ActivityId, _key);
			while (!task.IsCompleted)
			{
				yield return null;
			}
			GetStoreActivityItemsResponse storeItemsResponse = task.Result;
			if (!storeItemsResponse.Result)
			{
				ILRequestHelper.ShowErrorCode(storeItemsResponse.ErrorCode);
				continue;
			}
			global::Shift.Legion.ClientApi.Protocol.Store.StoreItem[] incomingStoreItems = storeItemsResponse.StoreItems;
			if (incomingStoreItems == null)
			{
				continue;
			}
			global::Shift.Legion.ClientApi.Protocol.Store.StoreItem[] array = incomingStoreItems;
			foreach (global::Shift.Legion.ClientApi.Protocol.Store.StoreItem incomingStoreItemData in array)
			{
				Dictionary<string, float> price = incomingStoreItemData.Price[PriceIdx];
				StoreItem_Ex storeItem = new StoreItem_Ex(GameManagers.Instance, incomingStoreItemData.StoreItemId)
				{
					Icon = incomingStoreItemData.Icon,
					Rarity = incomingStoreItemData.Rarity,
					Category = (StoreCategory)incomingStoreItemData.Category,
					DoubleAtFirst = incomingStoreItemData.DoubleAtFirst,
					BonusAtFirst = incomingStoreItemData.BonusAtFirst,
					Tags = incomingStoreItemData.Tags,
					ValidTime = incomingStoreItemData.ValidTime,
					Content = incomingStoreItemData.Content,
					DisplayContent = incomingStoreItemData.DisplayContent,
					OriginPrice = incomingStoreItemData.OriginPrice,
					Price = new List<Dictionary<string, float>> { price },
					Discount = incomingStoreItemData.Discount,
					PurchaseLimit = incomingStoreItemData.PurchaseLimit,
					PurchaseLimitPeriod = (PurchaseLimitType)incomingStoreItemData.PurchaseLimitPeriod,
					Substitution = incomingStoreItemData.Substitution,
					Price_Cached = Convert.ToInt32(price.Values.First())
				};
				storeItems.Add(storeItem);
				int num = yieldCount - 1;
				yieldCount = num;
				if (num == 0)
				{
					yieldCount = 2;
					yield return null;
				}
			}
		}
	}

	public void CheckSoulKeyStoreNotice()
	{
		GetSoulKeyStoreData(delegate(SoulKeyStoreConfigData data)
		{
			bool flag = false;
			bool flag2 = CheckCanBuy(data.FreeItemList_Sorted, "I32100");
			if (flag2 != _hasSoulKeyStoreNotice_Free)
			{
				_hasSoulKeyStoreNotice_Free = flag2;
				flag = true;
			}
			flag2 = CheckCanBuy(data.PaidItemList_Sorted, "I32101");
			if (flag2 != _hasSoulKeyStoreNotice_Paid)
			{
				_hasSoulKeyStoreNotice_Paid = flag2;
				flag = true;
			}
			if (flag)
			{
				OnChangeSoulKeyStoreNotice?.Invoke();
			}
		});
	}

	private static bool CheckCanBuy(List<StoreItem_Ex> sortedItems, string currency)
	{
		int stock = GameManagers.Instance.StockController.GetStock(currency);
		foreach (StoreItem_Ex sortedItem in sortedItems)
		{
			if (stock < sortedItem.Price_Cached)
			{
				break;
			}
			if (!sortedItem.IsSoldOut)
			{
				return true;
			}
		}
		return false;
	}

	private int StoreItemSortComparer(StoreItem_Ex a, StoreItem_Ex b)
	{
		return a.Price_Cached - b.Price_Cached;
	}

	public bool NeedRefreshStellarKeyStoreCache()
	{
		if (StellarKeyStoreData == null)
		{
			return true;
		}
		if (StellarKeyStoreData.Activity_Dict == null || StellarKeyStoreData.Activity_Dict.Count == 0)
		{
			return true;
		}
		int num = (int)GameController.Instance.GetServerTime();
		foreach (KeyValuePair<string, JsonActivityData> item in StellarKeyStoreData.Activity_Dict)
		{
			if (item.Value.EndTime < num)
			{
				return true;
			}
		}
		return false;
	}

	public void GetStellarKeyStoreData(Action<StellarKeyStoreConfigData> onLoaded = null)
	{
		if (!NeedRefreshStellarKeyStoreCache())
		{
			onLoaded?.Invoke(StellarKeyStoreData);
			return;
		}
		ILRequestHelper<GetDynamicStarKeyStoreResponse>.Request((EventContext)null, (Func<Task<GetDynamicStarKeyStoreResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetDynamicStarKeyStore()), (Action<GetDynamicStarKeyStoreResponse>)delegate(GetDynamicStarKeyStoreResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				StellarKeyStoreConfigData stellarKeyStoreConfigData = new StellarKeyStoreConfigData();
				foreach (JsonActivityData jsonActivityData in response.JsonActivityDatas)
				{
					if (stellarKeyStoreConfigData.Activity_Dict.ContainsKey(jsonActivityData.ActivityId))
					{
						ILRuntimeDebug.LogError("[GetStellarKeyStoreData] 出现重复 ActivityId=" + jsonActivityData.ActivityId);
					}
					else
					{
						stellarKeyStoreConfigData.Activity_Dict.Add(jsonActivityData.ActivityId, jsonActivityData);
						foreach (KeyValuePair<string, List<Product>> pageContent in jsonActivityData.PageContents)
						{
							if (stellarKeyStoreConfigData.Page_Dict.ContainsKey(pageContent.Key))
							{
								ILRuntimeDebug.LogError("[GetStellarKeyStoreData] ActivityId=" + jsonActivityData.ActivityId + " 出现重复页签 page=" + pageContent.Key);
							}
							else
							{
								stellarKeyStoreConfigData.Page_Dict.Add(pageContent.Key, new StellarKeyStorePageData
								{
									ActivityId = jsonActivityData.ActivityId,
									Product_List = (pageContent.Value ?? new List<Product>())
								});
							}
						}
					}
				}
				foreach (KeyValuePair<string, StellarKeyStorePageData> item in stellarKeyStoreConfigData.Page_Dict)
				{
					string key = item.Key;
					StellarKeyStorePageData value = item.Value;
					foreach (Product product_ in value.Product_List)
					{
						if (string.IsNullOrEmpty(product_.Currency))
						{
							product_.Currency = key;
						}
					}
				}
				StellarKeyStoreData = stellarKeyStoreConfigData;
				onLoaded(stellarKeyStoreConfigData);
			}
		});
	}

	public void CheckStellarKeyStoreNotice()
	{
		ILRequestHelper<GetDynamicStarKeyStoreIsNewPeriodResponse>.Request((EventContext)null, (Func<Task<GetDynamicStarKeyStoreIsNewPeriodResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetDynamicStarKeyStoreIsNewPeriod()), (Action<GetDynamicStarKeyStoreIsNewPeriodResponse>)delegate(GetDynamicStarKeyStoreIsNewPeriodResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				bool flag = false;
				bool flag2 = response.IsActive && response.IsNew;
				if (flag2 != _hasStellarKeyStoreNotice)
				{
					_hasStellarKeyStoreNotice = flag2;
					flag = true;
				}
				if (response.IsActive != _isStellarKeyStoreActive)
				{
					_isStellarKeyStoreActive = response.IsActive;
					flag = true;
				}
				if (flag)
				{
					OnChangeStellarKeyStoreNotice?.Invoke();
				}
			}
		});
	}

	public void StellarKeyBuy(string itemId, string activityId, Action<bool> onFinished)
	{
		ILRequestHelper<GetDynamicStarKeyStoreExchangeBonusWithKeyResponse>.Request((EventContext)null, (Func<Task<GetDynamicStarKeyStoreExchangeBonusWithKeyResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetDynamicStarKeyStoreExchangeBonusWithKey(itemId, activityId)), (Action<GetDynamicStarKeyStoreExchangeBonusWithKeyResponse>)delegate(GetDynamicStarKeyStoreExchangeBonusWithKeyResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke(obj: false);
			}
			else
			{
				if (response.StockChangeRecords != null)
				{
					GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				}
				if (!StellarKeyStoreData.Activity_Dict.TryGetValue(activityId, out var value))
				{
					onFinished?.Invoke(obj: false);
					ILRuntimeDebug.LogError("[StellarKeyBuy] activityId=" + activityId + " 不在缓存的StellarKeyStoreData.Activities活动数据中");
				}
				else
				{
					if (!value.ActivityConfig.Progress.TryGetValue(itemId, out var value2))
					{
						value.ActivityConfig.Progress.Add(itemId, 0);
					}
					int num = ((value2 != null) ? ((int)value2) : 0);
					value.ActivityConfig.Progress[itemId] = num + 1;
					onFinished?.Invoke(obj: true);
				}
			}
		});
	}

	public void StellarKeyCraft(string formulaId, Action<bool> onFinished)
	{
		ILRequestHelper<GetDynamicStarKeyStoreExchangeKeyResponse>.Request((EventContext)null, (Func<Task<GetDynamicStarKeyStoreExchangeKeyResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetDynamicStarKeyStoreExchangeKey(formulaId)), (Action<GetDynamicStarKeyStoreExchangeKeyResponse>)delegate(GetDynamicStarKeyStoreExchangeKeyResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke(obj: false);
			}
			else
			{
				if (response.StockChangeRecords != null)
				{
					GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				}
				onFinished?.Invoke(obj: true);
			}
		});
	}

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OnOrderShipSuccess);
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OnOrderShipSuccess);
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (itemId == "I32100" || itemId == "I32101")
		{
			CheckSoulKeyStoreNotice();
		}
		if (itemId == $"{eStellarKeyType.I63133}" || itemId == $"{eStellarKeyType.I63134}" || itemId == $"{eStellarKeyType.I63135}")
		{
			CheckStellarKeyStoreNotice();
		}
	}

	private void OnOrderShipSuccess(List<Bonus> result, List<Bonus> bonuses)
	{
		CheckSoulKeyStoreNotice();
	}
}
