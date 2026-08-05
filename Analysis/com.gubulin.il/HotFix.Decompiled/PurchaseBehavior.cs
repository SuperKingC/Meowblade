using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.Managers;
using HotFix.Sources.ThirdParty.SDKs.Android;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.RPC.Api;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;
using UI.PaymentOptions;
using UI.Tips;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Purchasing;

public class PurchaseBehavior : MonoBehaviour
{
	private class AliPayRetData
	{
		public AliPayResponse alipay_trade_app_pay_response;

		public string sign;

		public string sign_type;
	}

	private class AliPayResponse
	{
		public string code;

		public string msg;

		public string app_id;

		public string auth_app_id;

		public string charset;

		public string timestamp;

		public string out_trade_no;

		public string total_amount;

		public string trade_no;

		public string seller_id;
	}

	public static PurchaseBehavior Instance;

	public ConcurrentDictionary<string, ProductLocalInfo> ProductLocalInfoDictionary;

	public ConcurrentDictionary<string, ProductDetails> TapIntlProductLocalInfoDictionary;

	public ConcurrentDictionary<string, ProductDetailV4> TapIntlProductLocalInfoDictionaryV4;

	private const string richToPlainRegexPattern = "\\[[^\\]]*\\]";

	private StoreController m_StoreController;

	private TaskCompletionSource<bool> _purchaseInitTaskCompletionSource;

	private string receiptsPath;

	private AndroidJavaObject _androidJavaBridge;

	private PurchaseBehavior_IStoreListener StoreListener;

	private void Awake()
	{
		Instance = this;
		receiptsPath = Application.persistentDataPath + "//receipts.json";
		StoreListener = new PurchaseBehavior_IStoreListener();
		StoreListener.lastPendingOrderId = 0;
		StoreListener.CheckOrderAction = CheckOrder;
		ProductLocalInfoDictionary = new ConcurrentDictionary<string, ProductLocalInfo>();
		TapIntlProductLocalInfoDictionary = new ConcurrentDictionary<string, ProductDetails>();
		TapIntlProductLocalInfoDictionaryV4 = new ConcurrentDictionary<string, ProductDetailV4>();
	}

	private void Start()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		if ((int)Application.platform == 11 && !HotUpdateProcess.Instance.IsRegionOutCN && SDKHelper.GetSdkType() != SDKManager.eSDKName.PVP_test_official && SDKHelper.GetSdkType() != SDKManager.eSDKName.BiliBiliSDK && SDKHelper.GetSdkType() != SDKManager.eSDKName.XiPuSDK)
		{
			_androidJavaBridge = new AndroidJavaObject("com.gubulin.alipay.AliSDKActivity", Array.Empty<object>());
		}
	}

	public virtual async Task<bool> InitUnityPurchasing()
	{
		if ((int)Application.platform == 8)
		{
			string iOSProductIdsStr = Addressables.LoadAssetAsync<TextAsset>((object)"iOSProductIds").WaitForCompletion().text;
			if (string.IsNullOrEmpty(iOSProductIdsStr))
			{
				iOSProductIdsStr = "[]";
			}
			List<string> iOSProductIds = JsonHelper.ToObject<List<string>>(iOSProductIdsStr);
			Stopwatch sw = Stopwatch.StartNew();
			List<ProductDefinition> initialProductsToFetch = new List<ProductDefinition>();
			foreach (string productId in iOSProductIds)
			{
				initialProductsToFetch.Add(new ProductDefinition(productId, (ProductType)0));
			}
			sw.Stop();
			SentrySdk.AddBreadcrumb($"PurchaseBehavior Prepare Products Definitions Cost {sw.ElapsedMilliseconds}ms");
			sw.Restart();
			try
			{
				m_StoreController = UnityIAPServices.StoreController("AppleAppStore");
				StoreListener = new PurchaseBehavior_IStoreListener();
				StoreListener.lastPendingOrderId = 0;
				StoreListener.CheckOrderAction = CheckOrder;
				StoreListener.RegistStoreListener(m_StoreController);
				await m_StoreController.Connect();
				m_StoreController.FetchProducts(initialProductsToFetch, (IRetryPolicy)null);
				m_StoreController.FetchPurchases();
			}
			catch (Exception ex)
			{
				ILRuntimeDebug.LogError("PurchaseBehavior Initialize UnityPurchasing Catch Error: " + ex.Message);
			}
			sw.Stop();
			ILRuntimeDebug.LogError($"PurchaseBehavior Initialize UnityPurchasing Costs {sw.ElapsedMilliseconds}ms");
		}
		return true;
	}

	private IEnumerator FetchProductsAsync(List<ProductDefinition> prodDefList)
	{
		List<ProductDefinition> prodDefContainer = new List<ProductDefinition>();
		foreach (ProductDefinition prodDef in prodDefList)
		{
			prodDefContainer.Clear();
			prodDefContainer.Add(prodDef);
			m_StoreController.FetchProductsWithNoRetries(prodDefContainer);
			SentrySdk.AddBreadcrumb("PurchaseBehavior StoreController.FetchProducts For " + prodDef.id);
			yield return null;
		}
	}

	public virtual void GetPurchases()
	{
	}

	public void CallAliPay(string orderInfo)
	{
		_androidJavaBridge.Call("AliPay", new object[3] { orderInfo, "HotFixManager", "AliPayResult" });
		GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
	}

	public void AliPayResult(string resultStr)
	{
		GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
		AliPayRetData aliPayRetData = null;
		if (string.IsNullOrEmpty(resultStr))
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText57") }, 121, arg3: false);
			GameController.Contexts.Service<IUiService>().ClosePanel(UI_TakeItems.Name);
			return;
		}
		try
		{
			aliPayRetData = JsonHelper.ToObject<AliPayRetData>(resultStr);
		}
		catch
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText57") + " " + LanguagesManager.GetDesc("CsharpCodeZhTcText58") }, 121, arg3: false);
			GameController.Contexts.Service<IUiService>().ClosePanel(UI_TakeItems.Name);
			return;
		}
		if (aliPayRetData.alipay_trade_app_pay_response.code == "10000")
		{
			GameManagers.Instance.StockController.NeedSyncProduce = true;
			return;
		}
		SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText57") + " " + LanguagesManager.GetDesc("CsharpCodeZhTcText59") + aliPayRetData.alipay_trade_app_pay_response.code }, 121, arg3: false);
		GameController.Contexts.Service<IUiService>().ClosePanel(UI_TakeItems.Name);
	}

	public void CallWechatPay(string Remark)
	{
		((WeChatSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.WeChatSDK]).Pay(Remark);
		GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
	}

	public void WechatPayResult(string result)
	{
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

	public void ConfirmPendingPurchase(string orderId, string transactionId, string productId, string receipt)
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

	public void UnityIAPInvokePurchase(Order orderInfo)
	{
		StoreListener.lastPendingOrderId = orderInfo.OrderId;
		m_StoreController.PurchaseProduct(orderInfo.ReferenceId);
	}

	public virtual async void CheckOrder(string orderId, string productId, string transactionId, string orderMsg = "", int RetryMax = 5)
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
				if (retryCnt++ < RetryMax)
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
				else if ((int)Application.platform == 2)
				{
					ConfirmPendingPurchase(orderId, transactionId, productId, orderMsg);
				}
				return;
			}
			if ((int)Application.platform == 8)
			{
				ConfirmPendingPurchase(orderId, transactionId, productId, orderMsg);
			}
			else if ((int)Application.platform == 2)
			{
				ConfirmPendingPurchase(orderId, transactionId, productId, orderMsg);
			}
			Order orderInfo = shipOrderResponse.Order;
			if (orderInfo == null)
			{
				return;
			}
			GameManagers.Instance.StoreManager.ClaimStoreItem(orderInfo.StoreItemId);
			if (orderInfo.Payload != null)
			{
				Dictionary<string, string> payload = JsonHelper.ToObject<Dictionary<string, string>>(orderInfo.Payload);
				if (payload.ContainsKey("Money"))
				{
					GameManagers.Instance.StoreManager.GetStoreItemBonus(orderInfo.StoreItemId, out var baseBonusDict, out var _);
					int storeItemMoney = 0;
					if (baseBonusDict.ContainsKey("Money"))
					{
						storeItemMoney = baseBonusDict["Money"];
					}
					int payloadMoney = int.Parse(payload["Money"]);
					if (payloadMoney > storeItemMoney)
					{
						Dictionary<string, int> stockChange = new Dictionary<string, int> { 
						{
							"Money",
							payloadMoney - storeItemMoney
						} };
						StockChangeRecord[] stockChangeRecords = stockChange.ToStockChangeRecords(StockInContext.Unknown);
						StockChangeRecord[] array = stockChangeRecords;
						foreach (StockChangeRecord bonus in array)
						{
							SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { $"{SchemaIndexHelper.GetNameById(GameManagers.Instance, bonus.ItemId)}+{bonus.Offset}" }, 999, arg3: false);
						}
						GameManagers.Instance.StockController.ReadStockChangeRecords(stockChangeRecords);
					}
				}
			}
			bool isFirstTime = GameManagers.Instance.UserArchiveManager.IsRechargeFirstTime();
			float deltaRechargeTotal = shipOrderResponse.RechargeTotal - GameManagers.Instance.UserArchiveManager.GetTotalRecharge();
			if (deltaRechargeTotal > float.Epsilon)
			{
				GameManagers.Instance.UserArchiveManager.SetTotalRecharge(shipOrderResponse.RechargeTotal);
				SharedMessenger.Broadcast("ON_RECHARGE", deltaRechargeTotal);
				if (isFirstTime)
				{
					if ((int)Application.platform == 8)
					{
						AndroidBasicPlugInManager.Instance.GetIp(delegate
						{
							OceanEngineEventManager.Instance.InvokeAction(OceanEngineEventManager.eventType.Pay, orderInfo.StoreItemId, 1, orderInfo.Payment, orderInfo.Currency, orderInfo.PaidTotal);
							TapTapEventManager.Instance.InvokeAction_IOS(TapTapEventManager.TapTapEventType.Pay, deltaRechargeTotal * 100f);
							BiliBiliEventManager.Instance.InvokeAction(BiliBiliEventManager.BiliBiliEventType.USER_COST);
						});
					}
					else if ((int)Application.platform == 11)
					{
						AndroidBasicPlugInManager.Instance.GetIp(delegate
						{
							if (HotUpdateProcess.ChannelCode == "taptap" || HotUpdateProcess.ChannelCode == "tapplay")
							{
								TapTapEventManager.Instance.InvokeAction(TapTapEventManager.TapTapEventType.Pay, deltaRechargeTotal * 100f);
							}
							else if (HotUpdateProcess.ChannelCode == "bilibili")
							{
								BiliBiliEventManager.Instance.InvokeAction(BiliBiliEventManager.BiliBiliEventType.USER_COST);
							}
							else if (HotUpdateProcess.ChannelCode == "toutiao-android")
							{
								OceanEngineEventManager.Instance.InvokeAction(OceanEngineEventManager.eventType.Pay, orderInfo.StoreItemId, 1, orderInfo.Payment, orderInfo.Currency, orderInfo.PaidTotal);
							}
							else if (HotUpdateProcess.ChannelCode == "gdt-android")
							{
								((GDTSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.GDT]).OnPurchase(orderInfo.StoreItemId, 1, orderInfo.Payment, (int)(orderInfo.PaidTotal * 100f));
							}
						});
					}
				}
			}
			ThinkingDataHelper.Instance.OrderFinishedTrack(orderInfo.OrderId, orderInfo.StoreItemId, "RMB", orderInfo.PaidTotal, orderInfo.Payment);
			FGUIManager.Instance.Stats_Dynamic_SignInParallel(orderInfo.PaidTotal);
		}
		catch (Exception ex)
		{
			Exception e = ex;
			ILRuntimeDebug.LogException(e);
			ConfirmPendingPurchase(orderId, transactionId, productId, orderMsg);
		}
	}

	public virtual async Task PlaceOrder(string storeItemId, string paymentType, List<string> costItems = null, int _quantity = 1, ProductLocalInfo productLocalInfo = null)
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
			int _priceIndex = -1;
			if (costItems != null)
			{
				_priceIndex = storeItem.Price.IndexOf(costDict);
			}
			string payParams = "";
			if (HotUpdateProcess.ChannelCode == "bilibili")
			{
				BiliBiliSDK sdk = (BiliBiliSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.BiliBiliSDK];
				string plainName = Regex.Replace(storeItem.Name, "\\[[^\\]]*\\]", "");
				string plainDesc = Regex.Replace(storeItem.Desc, "\\[[^\\]]*\\]", "");
				payParams = JsonHelper.ToJson(new Dictionary<string, string>
				{
					{
						"uid",
						sdk.UserProfile.uid
					},
					{
						"username",
						sdk.UserProfile.username
					},
					{
						"role",
						GameController.Contexts.gameState.user.value.Nickname
					},
					{ "subject", plainName },
					{ "body", plainDesc },
					{ "extension_info", storeItemId }
				});
			}
			PlaceOrderResponse placeOrderResponse = await GameController.Contexts.Service<INetworkService>().PlaceOrder(storeItemId, paymentType, _priceIndex, _quantity, payParams);
			Order orderInfo = placeOrderResponse.Order;
			if (placeOrderResponse.Result)
			{
				Debug.Log((object)("PurchaseBehavior PlaceOrder: " + JsonHelper.ToJson(orderInfo)));
				if (!string.IsNullOrEmpty(orderInfo.ReferenceId))
				{
					ThinkingDataHelper.Instance.OrderInitTrack(orderInfo.OrderId, orderInfo.StoreItemId, "RMB", orderInfo.PaidTotal);
					switch (paymentType)
					{
					case "iosiap":
						PaymentType_Handler_ios(orderInfo, "AppleAppStore");
						break;
					case "alipay":
						if ((int)Application.platform == 11)
						{
							GameController.List_OrderID.Add(orderInfo.OrderId);
							CallAliPay(orderInfo.ReferenceId);
						}
						break;
					case "wechat":
						if ((int)Application.platform == 11)
						{
							GameController.List_OrderID.Add(orderInfo.OrderId);
							CallWechatPay(orderInfo.Remark);
						}
						break;
					case "yytx":
						((YYTXSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.YYTX]).Pay(orderInfo.ReferenceId);
						break;
					case "bilibili":
					{
						BiliBiliSDK sdk3 = (BiliBiliSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.BiliBiliSDK];
						BiliBiliSDK.BiliBiliOrderRemark orderRemarkInfo2 = BiliBiliSDK.ParseOrderRemark(orderInfo.Remark);
						string plainName2 = Regex.Replace(storeItem.Name, "\\[[^\\]]*\\]", "");
						string plainDesc2 = Regex.Replace(storeItem.Desc, "\\[[^\\]]*\\]", "");
						Dictionary<string, object> purchaseInfoDict2 = new Dictionary<string, object>
						{
							{
								"uid",
								sdk3.UserProfile.uid
							},
							{
								"username",
								sdk3.UserProfile.username
							},
							{
								"nickname",
								GameController.Contexts.gameState.user.value.Nickname
							},
							{ "order_id", orderRemarkInfo2.out_trade_no },
							{ "store_item_name", plainName2 },
							{ "desc", plainDesc2 },
							{ "extra_info", storeItemId },
							{ "notify_url", orderRemarkInfo2.notify_url },
							{ "sign", orderRemarkInfo2.order_sign },
							{
								"game_money",
								int.Parse(orderRemarkInfo2.game_money)
							},
							{
								"paid_total",
								int.Parse(orderRemarkInfo2.total_fee)
							}
						};
						sdk3.Purchase(JsonHelper.ToJson(purchaseInfoDict2));
						break;
					}
					case "xipu":
					{
						XiPuSDK sdk2 = (XiPuSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.XiPuSDK];
						XiPuSDK.XiPuOrderRemark orderRemarkInfo = XiPuSDK.ParseOrderRemark(orderInfo.Remark);
						Dictionary<string, object> purchaseInfoDict = new Dictionary<string, object>
						{
							{ "callback_info", orderRemarkInfo.CallbackInfo },
							{ "notify_url", orderRemarkInfo.NotifyUrl },
							{
								"paid_total",
								(int)(orderInfo.PaidTotal * 100f)
							}
						};
						sdk2.Purchase(JsonHelper.ToJson(purchaseInfoDict), orderInfo.OrderId);
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
							bool isFirstTime = GameManagers.Instance.UserArchiveManager.IsRechargeFirstTime();
							GameManagers.Instance.UserArchiveManager.IncrTotalRecharge(costKv.Value);
							SharedMessenger.Broadcast("ON_RECHARGE", costKv.Value);
							if (!isFirstTime || !(costKv.Value > float.Epsilon))
							{
								continue;
							}
							if ((int)Application.platform == 8)
							{
								AndroidBasicPlugInManager.Instance.GetIp(delegate
								{
									OceanEngineEventManager.Instance.InvokeAction(OceanEngineEventManager.eventType.Pay, orderInfo.StoreItemId, 1, orderInfo.Payment, orderInfo.Currency, orderInfo.PaidTotal);
									TapTapEventManager.Instance.InvokeAction_IOS(TapTapEventManager.TapTapEventType.Pay, costKv.Value * 100f);
									BiliBiliEventManager.Instance.InvokeAction(BiliBiliEventManager.BiliBiliEventType.USER_COST);
								});
							}
							else
							{
								if ((int)Application.platform != 11)
								{
									continue;
								}
								AndroidBasicPlugInManager.Instance.GetIp(delegate
								{
									if (HotUpdateProcess.ChannelCode == "taptap" || HotUpdateProcess.ChannelCode == "tapplay")
									{
										TapTapEventManager.Instance.InvokeAction(TapTapEventManager.TapTapEventType.Pay, costKv.Value * 100f);
									}
									else if (HotUpdateProcess.ChannelCode == "toutiao-android")
									{
										OceanEngineEventManager.Instance.InvokeAction(OceanEngineEventManager.eventType.Pay, orderInfo.StoreItemId, 1, orderInfo.Payment, orderInfo.Currency, orderInfo.PaidTotal);
									}
									else if (HotUpdateProcess.ChannelCode == "gdt-android")
									{
										((GDTSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.GDT]).OnPurchase(orderInfo.StoreItemId, 1, orderInfo.Payment, (int)(orderInfo.PaidTotal * 100f));
									}
									else if (HotUpdateProcess.ChannelCode == "bilibili")
									{
										BiliBiliEventManager.Instance.InvokeAction(BiliBiliEventManager.BiliBiliEventType.USER_COST);
									}
								});
							}
						}
						else
						{
							stockChangeRecord.ItemId = costKv.Key;
							stockChangeRecord.Offset = (int)(0f - costKv.Value) * _quantity;
							stockChangeRecord.Context = 12;
							stockChangeRecord.ContextValue = storeItemId;
							stockChangeRecord.Type = 1;
							ThinkingDataHelper.Instance.OrderInitTrack(orderInfo.OrderId, orderInfo.StoreItemId, costKv.Key, costKv.Value);
							ThinkingDataHelper.Instance.OrderFinishedTrack(orderInfo.OrderId, orderInfo.StoreItemId, costKv.Key, costKv.Value, orderInfo.Payment);
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
		catch (Exception ex)
		{
			ILRuntimeDebug.LogError("Error On Place Order:" + ex.Message);
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

	public virtual void InvokePurchase(Shift.Legion.Common.Models.Store.StoreItem storeItem, ProductLocalInfo productLocalInfo = null, int qty = 1, Action cb = null, bool doubleCheck = false)
	{
		if (UiHelper.LoginTypeStr == UserLoginCredentialsType.Guest.ToString())
		{
			UiHelper.GuestsAccessRestrictTip();
			return;
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PaymentOptionsDialog.Name, new Dictionary<string, object>
		{
			{ "StoreItemId", storeItem.StoreItemId },
			{ "DoubleCheck", doubleCheck },
			{ "Quantity", qty }
		}, multiMode: false, ignoreQueue: false, null, cb);
	}

	public virtual void InvokePurchase(Shift.Legion.Common.Models.Store.StoreItem storeItem, ProductLocalInfo productLocalInfo, int qty, string UseCurrency, bool doubleCheck = false)
	{
		if (UiHelper.LoginTypeStr == UserLoginCredentialsType.Guest.ToString())
		{
			UiHelper.GuestsAccessRestrictTip();
			return;
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PaymentOptionsDialog.Name, new Dictionary<string, object>
		{
			{ "StoreItemId", storeItem.StoreItemId },
			{ "DoubleCheck", doubleCheck },
			{ "Quantity", qty },
			{ "UseCurrency", UseCurrency }
		});
	}
}
