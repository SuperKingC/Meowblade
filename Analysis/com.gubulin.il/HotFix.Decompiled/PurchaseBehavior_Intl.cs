using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using GameDataEditor;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.Managers;
using HotFix.Sources.ThirdParty.SDKs.Android;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.RPC.Api;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.Tips;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Purchasing;

public class PurchaseBehavior_Intl : PurchaseBehavior
{
	public enum PricePaddingPosition
	{
		Left,
		Right
	}

	public new static PurchaseBehavior_Intl Instance;

	private static Dictionary<string, string> _currencyCodeToSymbolMap;

	private StoreController m_StoreController;

	private TaskCompletionSource<bool> _purchaseInitTaskCompletionSource;

	private string receiptsPath;

	private AndroidJavaObject _androidJavaBridge;

	private PurchaseBehavior_IStoreListener_Intl StoreListener;

	public static Dictionary<string, string> CurrencyCodeToSymbolMap
	{
		get
		{
			if (_currencyCodeToSymbolMap == null)
			{
				_currencyCodeToSymbolMap = new Dictionary<string, string>();
				CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
				foreach (CultureInfo cultureInfo in cultures)
				{
					RegionInfo regionInfo = new RegionInfo(cultureInfo.LCID);
					_currencyCodeToSymbolMap[regionInfo.ISOCurrencySymbol] = regionInfo.CurrencySymbol;
				}
			}
			return _currencyCodeToSymbolMap;
		}
	}

	private void Awake()
	{
		Instance = this;
		receiptsPath = Application.persistentDataPath + "//receipts.json";
		ProductLocalInfoDictionary = new ConcurrentDictionary<string, ProductLocalInfo>();
		TapIntlProductLocalInfoDictionary = new ConcurrentDictionary<string, ProductDetails>();
		TapIntlProductLocalInfoDictionaryV4 = new ConcurrentDictionary<string, ProductDetailV4>();
	}

	private void Start()
	{
	}

	public override async Task<bool> InitUnityPurchasing()
	{
		return await LoadChannelRegisteredProducts();
	}

	public override void GetPurchases()
	{
		try
		{
			if (!(HotUpdateProcess.ChannelCode == "Google"))
			{
			}
		}
		catch (Exception exception)
		{
			ILRuntimeDebug.LogException(exception);
		}
	}

	private async Task<bool> LoadChannelRegisteredProducts()
	{
		bool result = false;
		if ((int)Application.platform == 8)
		{
			string iOSProductIdsStr = Addressables.LoadAssetAsync<TextAsset>((object)"iOSProductIds").WaitForCompletion().text;
			if (string.IsNullOrEmpty(iOSProductIdsStr))
			{
				iOSProductIdsStr = "[]";
			}
			List<string> iOSProductIds = JsonHelper.ToObject<List<string>>(iOSProductIdsStr);
			if (iOSProductIds.Count > 0)
			{
				result = await _loadIOSChannelProducts(iOSProductIds);
			}
		}
		else if ((int)Application.platform == 11)
		{
			string channelCode = HotUpdateProcess.ChannelCode;
			string text = channelCode;
			result = ((!(text == "TapIntl")) ? (await _loadGooglePlayChannelProducts()) : (await _loadTapIntlChannelProducts()));
		}
		return result;
	}

	private static async Task<bool> _loadGooglePlayChannelProducts()
	{
		string googleProductIdsStr = Addressables.LoadAssetAsync<TextAsset>((object)"GoogleProductIds").WaitForCompletion().text;
		if (string.IsNullOrEmpty(googleProductIdsStr))
		{
			googleProductIdsStr = "[]";
		}
		List<string> googleProductIds = JsonHelper.ToObject<List<string>>(googleProductIdsStr);
		TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
		GoogleSDK.GetProductsDetails(googleProductIds, taskCompletionSource);
		await taskCompletionSource.Task;
		return taskCompletionSource.Task.Result;
	}

	private static async Task<bool> _loadTapIntlChannelProducts()
	{
		string tapIntlProductIdsStr = Addressables.LoadAssetAsync<TextAsset>((object)"TapTapIntlProductIds").WaitForCompletion().text;
		if (string.IsNullOrEmpty(tapIntlProductIdsStr))
		{
			tapIntlProductIdsStr = "[]";
		}
		List<string> tapIntlProductIds = JsonHelper.ToObject<List<string>>(tapIntlProductIdsStr);
		int totalIdsCnt = tapIntlProductIds.Count;
		int pageSize = 10;
		int pagesCnt = Mathf.CeilToInt((float)totalIdsCnt / (float)pageSize);
		int i = 0;
		List<string> pageIds = new List<string>();
		bool result = true;
		for (; i < pagesCnt; i++)
		{
			pageIds.Clear();
			for (int j = 0; j < pageSize; j++)
			{
				int _idIdx = i * pageSize + j;
				if (_idIdx >= totalIdsCnt)
				{
					break;
				}
				pageIds.Add(tapIntlProductIds[_idIdx]);
			}
			TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
			TapTapIntlSDK.QueryProduct(pageIds, taskCompletionSource);
			await taskCompletionSource.Task;
			result = result && taskCompletionSource.Task.Result;
		}
		return result;
	}

	private async Task<bool> _loadIOSChannelProducts(List<string> iOSProductIds)
	{
		Stopwatch sw = Stopwatch.StartNew();
		List<ProductDefinition> initialProductsToFetch = new List<ProductDefinition>();
		foreach (string productId in iOSProductIds)
		{
			initialProductsToFetch.Add(new ProductDefinition(productId, (ProductType)0));
		}
		sw.Stop();
		sw.Restart();
		m_StoreController = UnityIAPServices.StoreController("AppleAppStore");
		StoreListener = new PurchaseBehavior_IStoreListener_Intl();
		StoreListener.lastPendingOrderId = 0;
		StoreListener.CheckOrderAction = CheckOrder;
		StoreListener.RegistStoreListener(m_StoreController);
		await m_StoreController.Connect();
		m_StoreController.FetchProducts(initialProductsToFetch, (IRetryPolicy)null);
		bool fetchProdResult = await StoreListener._purchaseInitTaskCompletionSource.Task;
		if (fetchProdResult)
		{
			_iOS_LoadProductsLocalInfo();
			m_StoreController.FetchPurchases();
		}
		sw.Stop();
		return fetchProdResult;
	}

	private void _iOS_LoadProductsLocalInfo()
	{
		ReadOnlyObservableCollection<Product> products = m_StoreController.GetProducts();
		if (products.Count < 1)
		{
			return;
		}
		foreach (Product item in products)
		{
			string id = item.definition.id;
			ProductLocalInfo productLocalInfo = new ProductLocalInfo
			{
				ReferenceId = id,
				Price = (float)item.metadata.localizedPrice,
				FormattedPrice = item.metadata.localizedPriceString,
				CurrencyCode = item.metadata.isoCurrencyCode
			};
			if (!string.IsNullOrEmpty(productLocalInfo.CurrencyCode) && CurrencyCodeToSymbolMap.TryGetValue(productLocalInfo.CurrencyCode, out var value))
			{
				productLocalInfo.CurrencySymbol = value;
			}
			PurchaseManager.Instance.ProductLocalInfoDictionary[id] = productLocalInfo;
		}
	}

	private async void SaveReceipts(Dictionary<string, Dictionary<string, string>> receiptsDict)
	{
		if (!File.Exists(receiptsPath))
		{
			File.Create(receiptsPath).Dispose();
		}
		int retryCnt = 0;
		StreamWriter writer = new StreamWriter(receiptsPath, append: false, Encoding.UTF8);
		while (true)
		{
			try
			{
				writer.Write(JsonHelper.ToJson(receiptsDict));
				writer.Close();
			}
			catch (Exception)
			{
				if (retryCnt++ < 6)
				{
					await Task.Delay(500);
					continue;
				}
			}
			break;
		}
	}

	private Dictionary<string, Dictionary<string, string>> ReadReceipts()
	{
		if (!File.Exists(receiptsPath))
		{
			File.Create(receiptsPath).Dispose();
		}
		StreamReader streamReader = new StreamReader(receiptsPath, Encoding.UTF8);
		try
		{
			string json = streamReader.ReadToEnd();
			streamReader.Close();
			return JsonHelper.ToObject<Dictionary<string, Dictionary<string, string>>>(json);
		}
		catch (Exception)
		{
			return new Dictionary<string, Dictionary<string, string>>();
		}
	}

	public new void ConfirmPendingPurchase(string orderId, string transactionId, string productId, string receipt)
	{
		try
		{
			m_StoreController.ConfirmPurchase(StoreListener.LastPendingOrder);
		}
		catch (Exception exception)
		{
			ILRuntimeDebug.LogException(exception);
		}
		finally
		{
			StoreListener.lastPendingOrderId = 0;
			StoreListener.LastPendingOrder = null;
			GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
		}
	}

	public new void UnityIAPInvokePurchase(Order orderInfo)
	{
		StoreListener.lastPendingOrderId = orderInfo.OrderId;
		m_StoreController.PurchaseProduct(orderInfo.ReferenceId);
	}

	public override async void CheckOrder(string orderId, string productId, string transactionId, string orderMsg = "", int RetryMax = 5)
	{
		try
		{
			int retryCnt = 0;
			CheckOrderResponse shipOrderResponse;
			while (true)
			{
				shipOrderResponse = await GameController.Contexts.Service<INetworkService>().CheckOrder(orderId, transactionId, orderMsg);
				if (shipOrderResponse.ErrorCode == 4002002 || shipOrderResponse.ErrorCode == 4002001 || shipOrderResponse.ErrorCode == 4002003 || shipOrderResponse.ErrorCode == 4002004 || shipOrderResponse.ErrorCode == 4002005)
				{
					ConfirmPendingPurchase(orderId, transactionId, productId, orderMsg);
					ILRequestHelper.ShowErrorCode(shipOrderResponse.ErrorCode);
					GameController.Contexts.Service<IUiService>().ClosePanel(UI_TakeItems.Name);
					return;
				}
				bool needRetry = false;
				if (!shipOrderResponse.Result)
				{
					needRetry = true;
				}
				else if (shipOrderResponse.Order != null)
				{
					int orderStatus = shipOrderResponse.Order.Status;
					if (orderStatus != 2 && orderStatus != 3)
					{
						needRetry = true;
					}
				}
				if (!needRetry)
				{
					break;
				}
				if (retryCnt++ < 5)
				{
					int retryWaitingTime = 1000 * retryCnt;
					if ((int)Application.platform == 8)
					{
						retryWaitingTime *= 2;
					}
					await Task.Delay(retryWaitingTime);
					continue;
				}
				ILRequestHelper.ShowErrorCode(shipOrderResponse.ErrorCode);
				GameController.Contexts.Service<IUiService>().ClosePanel(UI_TakeItems.Name);
				if ((int)Application.platform == 8)
				{
					ConfirmPendingPurchase(orderId, transactionId, productId, orderMsg);
				}
				return;
			}
			if ((int)Application.platform == 8)
			{
				ConfirmPendingPurchase(orderId, transactionId, productId, orderMsg);
			}
			Order orderInfo = shipOrderResponse.Order;
			if (orderInfo != null)
			{
				GameManagers.Instance.StoreManager.ClaimStoreItem(orderInfo.StoreItemId);
				GameManagers.Instance.UserArchiveManager.IsRechargeFirstTime();
				float deltaRechargeTotal = shipOrderResponse.RechargeTotal - GameManagers.Instance.UserArchiveManager.GetTotalRecharge();
				if (deltaRechargeTotal > float.Epsilon)
				{
					GameManagers.Instance.UserArchiveManager.SetTotalRecharge(shipOrderResponse.RechargeTotal);
					SharedMessenger.Broadcast("ON_RECHARGE", deltaRechargeTotal);
					EventManager.LogSpecificStoreItemsForFacebook(orderInfo.StoreItemId);
				}
				float paidTotal = 0f;
				GDEStoreContentConfigData storeItemData = GDMgr.Get<GDEStoreContentConfigData>(orderInfo.StoreItemId);
				if (storeItemData != null && !string.IsNullOrEmpty(storeItemData.InternationalPrice))
				{
					List<Dictionary<string, int>> internationalPriceInfo = JsonHelper.ToObject<List<Dictionary<string, int>>>(storeItemData.InternationalPrice);
					Dictionary<string, int> internationalPrice = internationalPriceInfo[0];
					paidTotal = internationalPrice.Values.First();
				}
				ThinkingDataHelper.Instance.OrderFinishedTrack(orderInfo.OrderId, orderInfo.StoreItemId, "USD", paidTotal, orderInfo.Payment);
				EventManager.LogPurchase(orderInfo, 1, paidTotal);
				FGUIManager.Instance.Stats_Dynamic_SignInParallel(paidTotal);
			}
		}
		catch (Exception ex)
		{
			Exception e = ex;
			ILRuntimeDebug.LogException(e);
			ConfirmPendingPurchase(orderId, transactionId, productId, orderMsg);
		}
	}

	public override async Task PlaceOrder(string storeItemId, string paymentType, List<string> costItems = null, int _quantity = 1, ProductLocalInfo productLocalInfo = null)
	{
		Shift.Legion.Common.Models.Store.StoreItem storeItem = new Shift.Legion.Common.Models.Store.StoreItem(GameManagers.Instance, storeItemId);
		Dictionary<string, float> costDict = new Dictionary<string, float>();
		if (!storeItem.CanRedeem(costItems, out costDict))
		{
			return;
		}
		if (GameController.List_OrderID == null)
		{
			GameController.List_OrderID = new List<int>();
		}
		GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: true);
		try
		{
			if (!(paymentType == "google"))
			{
			}
		}
		catch (Exception exception)
		{
			ILRuntimeDebug.LogException(exception);
		}
		try
		{
			int _priceIndex = -1;
			if (costItems != null)
			{
				_priceIndex = storeItem.Price.IndexOf(costDict);
			}
			PlaceOrderResponse placeOrderResponse = await GameController.Contexts.Service<INetworkService>().PlaceOrder(storeItemId, paymentType, _priceIndex, _quantity);
			Order orderInfo = placeOrderResponse.Order;
			if (placeOrderResponse.Result)
			{
				if (!string.IsNullOrEmpty(orderInfo.ReferenceId))
				{
					float paidTotal = 0f;
					GDEStoreContentConfigData storeItemData = GDMgr.Get<GDEStoreContentConfigData>(orderInfo.StoreItemId);
					if (storeItemData != null && !string.IsNullOrEmpty(storeItemData.InternationalPrice))
					{
						List<Dictionary<string, int>> internationalPriceInfo = JsonHelper.ToObject<List<Dictionary<string, int>>>(storeItemData.InternationalPrice);
						Dictionary<string, int> internationalPrice = internationalPriceInfo[0];
						paidTotal = internationalPrice.Values.First();
					}
					ThinkingDataHelper.Instance?.OrderInitTrack(orderInfo.OrderId, orderInfo.StoreItemId, "USD", paidTotal);
					EventManager.LogPlaceOrder(orderInfo, _quantity, paidTotal);
					switch (paymentType)
					{
					case "iosiap":
						PaymentType_Handler_ios(orderInfo, "AppleAppStore");
						break;
					case "google":
					{
						Dictionary<string, string> _msg2 = new Dictionary<string, string>
						{
							["OrderId"] = orderInfo.OrderId.ToString(),
							["ProductId"] = productLocalInfo.ReferenceId
						};
						((GoogleSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.GoogleSDK]).Pay(JsonHelper.ToJson(_msg2));
						break;
					}
					case "taptapintl":
					{
						ProductDetailV4 tapIntlProductInfo = PurchaseManager.Instance.TapIntlProductLocalInfoDictionaryV4[productLocalInfo.ReferenceId];
						Dictionary<string, object> _msg = new Dictionary<string, object>
						{
							["ProductType"] = tapIntlProductInfo.productType,
							["ProductId"] = tapIntlProductInfo.productId,
							["Name"] = tapIntlProductInfo.name,
							["Description"] = tapIntlProductInfo.description,
							["RegionId"] = tapIntlProductInfo.regionId,
							["FormatterPrice"] = tapIntlProductInfo.oneTimePurchaseOfferDetails.formatterPrice,
							["PriceAmountMicros"] = tapIntlProductInfo.oneTimePurchaseOfferDetails.priceAmountMicros,
							["PriceCurrencyCode"] = tapIntlProductInfo.oneTimePurchaseOfferDetails.priceCurrencyCode,
							["Icon"] = tapIntlProductInfo.icon,
							["Extra"] = orderInfo.OrderId.ToString()
						};
						((TapTapIntlSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.TapIntlSDK]).Purchase(JsonHelper.ToJson(_msg));
						break;
					}
					}
				}
				else
				{
					StockChangeRecord[] stockChangeRecords = new StockChangeRecord[costDict.Count];
					int _changeRecordIndex = 0;
					foreach (KeyValuePair<string, float> costKv in costDict)
					{
						StockChangeRecord stockChangeRecord = new StockChangeRecord();
						stockChangeRecords[_changeRecordIndex++] = stockChangeRecord;
						if (costKv.Key == "RMB")
						{
							GameManagers.Instance.UserArchiveManager.IsRechargeFirstTime();
							GameManagers.Instance.UserArchiveManager.IncrTotalRecharge(costKv.Value);
							SharedMessenger.Broadcast("ON_RECHARGE", costKv.Value);
							EventManager.LogSpecificStoreItemsForFacebook(orderInfo.StoreItemId);
						}
						else
						{
							stockChangeRecord.ItemId = costKv.Key;
							stockChangeRecord.Offset = (int)(0f - costKv.Value) * _quantity;
							stockChangeRecord.Context = 12;
							stockChangeRecord.ContextValue = storeItemId;
							stockChangeRecord.Type = 1;
							ThinkingDataHelper.Instance?.OrderInitTrack(orderInfo.OrderId, orderInfo.StoreItemId, costKv.Key, costKv.Value);
							ThinkingDataHelper.Instance?.OrderFinishedTrack(orderInfo.OrderId, orderInfo.StoreItemId, costKv.Key, costKv.Value, orderInfo.Payment);
						}
					}
					GameManagers.Instance.StockController.ReadStockChangeRecords(stockChangeRecords);
					GameManagers.Instance.StoreManager.ClaimStoreItem(storeItemId, _quantity);
					GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
				}
				if (placeOrderResponse.Order.Status == 3)
				{
					GameManagers.Instance.Messenger.Broadcast("NEW_ORDER_STATS", orderInfo);
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(placeOrderResponse.JumpContext))
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(placeOrderResponse.JumpContext, null);
				}
				else
				{
					string message = LanguagesManager.GetErrorMessage(placeOrderResponse.ErrorCode);
					SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { message }, 121, arg3: false);
				}
				GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
			}
		}
		catch (Exception exception2)
		{
			ILRuntimeDebug.LogException(exception2);
			GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
		}
	}

	private void PaymentType_Handler_ios(Order orderInfo, string storeName)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		Product productById = m_StoreController.GetProductById(orderInfo.ReferenceId);
		if (productById == null)
		{
			ProductDefinition item = new ProductDefinition(orderInfo.ReferenceId, (ProductType)0);
			m_StoreController.FetchProducts(new List<ProductDefinition> { item }, (IRetryPolicy)null);
		}
		UnityIAPInvokePurchase(orderInfo);
	}

	public override void InvokePurchase(Shift.Legion.Common.Models.Store.StoreItem storeItem, ProductLocalInfo productLocalInfo = null, int qty = 1, Action cb = null, bool doubleCheck = false)
	{
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Invalid comparison between Unknown and I4
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Invalid comparison between Unknown and I4
		if (UiHelper.LoginTypeStr == UserLoginCredentialsType.Guest.ToString())
		{
			UiHelper.GuestsAccessRestrictTip();
			return;
		}
		bool flag = true;
		string text = null;
		Dictionary<string, float> dictionary = null;
		foreach (Dictionary<string, float> item in storeItem.Price)
		{
			text = item.Keys.First();
			float num = item.Values.First();
			if (!text.Equals("RMB"))
			{
				if (text == "Gem")
				{
					flag = false;
					dictionary = item;
					break;
				}
				float num2 = GameManagers.Instance.StockController.GetStock(text);
				if (num <= num2)
				{
					flag = false;
					break;
				}
			}
			else if (Mathf.Abs(num - 0f) < float.Epsilon)
			{
				flag = false;
				break;
			}
		}
		if (dictionary != null)
		{
			KeyValuePair<string, float> keyValuePair = dictionary.First();
			float num3 = GameManagers.Instance.StockController.GetStock(text);
			if (keyValuePair.Value > num3)
			{
				string.Format(LanguagesManager.GetDesc("NotEnoughCurrencyTip"), Item.Name(GameManagers.Instance, keyValuePair.Key)).ToTip();
				return;
			}
		}
		if (flag && (string.IsNullOrEmpty(storeItem.ReferenceId) || productLocalInfo == null))
		{
			ILRuntimeDebug.LogError("Invalid StoreItem Info, StoreItemId=" + storeItem.StoreItemId + ", ReferenceId=" + storeItem.ReferenceId + ", Price=" + JsonHelper.ToJson(storeItem.Price));
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("TipLoadStoreItemFailed") }, 121, arg3: false);
		}
		else if (!flag)
		{
			if (doubleCheck)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
				{
					{
						"TipTextAlign",
						(object)(AlignType)1
					},
					{
						"Content",
						LanguagesManager.GetDesc("CsharpCodeZhTcText98") + "？"
					},
					{
						"Buttons",
						new Dictionary<string, Action>
						{
							{
								"Confirm",
								delegate
								{
									PurchaseManager.Instance.PlaceOrder(storeItem.StoreItemId, "Default", null, qty)?.GetAwaiter().OnCompleted(delegate
									{
										cb?.Invoke();
									});
								}
							},
							{ "Cancel", null }
						}
					},
					{ "PageIndex", 0 },
					{ "FontSize", 44 },
					{ "Order", 999999 }
				});
			}
			else
			{
				PurchaseManager.Instance.PlaceOrder(storeItem.StoreItemId, "Default", null, qty)?.GetAwaiter().OnCompleted(delegate
				{
					cb?.Invoke();
				});
			}
		}
		else if ((int)Application.platform == 11)
		{
			string channelCode = HotUpdateProcess.ChannelCode;
			string text2 = channelCode;
			if (text2 == "TapIntl")
			{
				PlaceOrder(storeItem.StoreItemId, "taptapintl", null, qty, productLocalInfo).GetAwaiter().OnCompleted(delegate
				{
					cb?.Invoke();
				});
			}
			else
			{
				PlaceOrder(storeItem.StoreItemId, "google", null, qty, productLocalInfo).GetAwaiter().OnCompleted(delegate
				{
					cb?.Invoke();
				});
			}
		}
		else if ((int)Application.platform == 8)
		{
			PlaceOrder(storeItem.StoreItemId, "iosiap", null, qty, productLocalInfo).GetAwaiter().OnCompleted(delegate
			{
				cb?.Invoke();
			});
		}
		else
		{
			PlaceOrder(storeItem.StoreItemId, "test", null, qty, productLocalInfo).GetAwaiter().OnCompleted(delegate
			{
				cb?.Invoke();
			});
		}
	}
}
