using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using HotFix;
using HotFix.Sources.ThirdParty.SDKs.Android;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UnityEngine;

public class GoogleSDK : BaseAndroidSDK
{
	private class InitialResultData
	{
		public int ErrorCode;
	}

	private class PurchaseResultData
	{
		public string BillingResult;

		public string List;
	}

	private class PurchaseInfo
	{
		public string zza;

		public string zzb;

		public KeyValuePair<string, Purchase> zzc;
	}

	private class Purchase
	{
		public int purchaseState;

		public int quatity;

		public long purchaseTime;

		public string purchaseToken;

		public string obfuscatedAccountId;

		public string orderId;

		public string packageName;

		public bool acknowledged;

		public string productId;
	}

	private class ConsumeResult
	{
		public string BillingResult;

		public string PurchaseToken;
	}

	private class LoginResultData
	{
		public string Code;

		public string GoogleId;

		public int ErrorCode;
	}

	private enum BillingResultResponseCode
	{
		SUCCESS = 0,
		NETWORK_ERROR = 12,
		SERVICE_TIMEOUT = -3,
		SERVICE_DISCONNECTED = -1,
		SERVICE_UNAVAILABLE = 2,
		BILLING_UNAVAILABLE = 3,
		ERROR = 6,
		ITEM_ALREADY_OWNED = 7,
		ITEM_NOT_OWNED = 8
	}

	private class BillingResult
	{
		public int zza;

		public string zzb;

		public int ResponseCode => zza;

		public string DebugMessage => zzb;
	}

	private class ProductDetails
	{
		public string productId;

		public string type;

		public string title;

		public string name;

		public string description;

		public string skuDetailsToken;

		public OneTimePurchaseOfferDetails oneTimePurchaseOfferDetails;

		public int limitedQuantityInfo;

		public List<string> localizedIn;
	}

	private class ProductDetailV7
	{
		public string productId { get; set; }

		public string type { get; set; }

		public string title { get; set; }

		public string name { get; set; }

		public string description { get; set; }

		public List<string> localizedIn { get; set; }

		public string skuDetailsToken { get; set; }

		public OneTimePurchaseOfferDetailsV7 oneTimePurchaseOfferDetails { get; set; }
	}

	private class OneTimePurchaseOfferDetailsV7
	{
		public long priceAmountMicros { get; set; }

		public string priceCurrencyCode { get; set; }

		public string formattedPrice { get; set; }

		public string offerIdToken { get; set; }
	}

	private class ProductDetailsKv
	{
		public string productId;

		public string type;

		public string title;

		public string name;

		public string description;

		public string skuDetailsToken;

		public KeyValuePair<string, OneTimePurchaseOfferDetails> oneTimePurchaseOfferDetails;

		public int limitedQuantityInfo;

		public List<string> localizedIn;
	}

	private class OneTimePurchaseOfferDetails
	{
		public string formattedPrice;

		public long priceAmountMicros;

		public string priceCurrencyCode;

		public string offerIdToken;

		public string offerId;

		public int offerType;

		public List<string> offerTags;
	}

	private class ProductDetailsInfo
	{
		public string zza;

		public string zzc;
	}

	private class OneTimePurchaseOffers
	{
		public string zza;

		public long zzb;

		public string zzc;

		public string zzd;

		public string zze;

		public List<object> zzf;
	}

	private class ProductDetailResult
	{
		public string BillingResult;

		public string List;
	}

	private class OnErrorResult
	{
		public string Message;
	}

	private static TaskCompletionSource<bool> _taskGetProductDetails;

	public GoogleSDK()
		: base("com.gubulin.il.googlesdk.AndroidUnityBridge")
	{
		MethodMap = new Dictionary<string, Action<string>>
		{
			{ "Init", Init },
			{ "Login", Login },
			{ "Logout", Logout },
			{ "SetUserId", SetUserId },
			{ "SetUserProperty", SetUserProperty },
			{ "LogStandardEvent", LogStandardEvent },
			{ "LogEvent", LogEvent },
			{ "JumpGooglePlay", JumpGooglePlay },
			{ "OnGetProducts", OnGetProducts },
			{ "OnProcessPurchase", OnProcessPurchase },
			{ "OnConsume", OnConsume },
			{ "OnLogin", OnLogin },
			{ "OnInitial", OnInitial },
			{ "OnError", OnError }
		};
	}

	public void JumpGooglePlay(string obj)
	{
		Dictionary<string, string> obj2 = new Dictionary<string, string>
		{
			{
				"Uri",
				"https://play.google.com/store/apps/details?id=" + obj
			},
			{ "Package", "com.android.vending" }
		};
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "jumpgoogleplay:" + JsonHelper.ToJson(obj2));
	}

	public void LogEvent(string obj)
	{
		Dictionary<string, string> obj2 = new Dictionary<string, string> { { "EventName", obj } };
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "logevent:" + JsonHelper.ToJson(obj2));
	}

	public void LogStandardEvent(string obj)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "logstandardevent:" + obj);
	}

	public void SetUserProperty(string obj)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "SetUserProperty:" + obj);
	}

	public void SetUserId(string obj)
	{
		Dictionary<string, string> obj2 = new Dictionary<string, string> { { "UserId", obj } };
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "SetUserId:" + JsonHelper.ToJson(obj2));
	}

	public void Login(string info = null)
	{
		Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: true);
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Login:{}");
	}

	public void Logout(string info = null)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Signout:{}");
	}

	public void Pay(string info)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Purchase:" + info);
	}

	public void Init(string appid = null)
	{
		string paramInfo = "Initial:{}";
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, paramInfo);
	}

	public static void GetProductsDetails(List<string> referenceIds, TaskCompletionSource<bool> taskCompletionSource)
	{
		_taskGetProductDetails?.TrySetResult(result: true);
		_taskGetProductDetails = taskCompletionSource;
		SDKHelper.CallAndroid(((GoogleSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.GoogleSDK]).AndroidPlatformJavaBridge, "GetProductsDetail:" + JsonHelper.ToJson(referenceIds));
	}

	private void OnInitial(string val)
	{
		InitialResultData initialResultData = JsonHelper.ToObject<InitialResultData>(val);
		if (initialResultData.ErrorCode != 0)
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("GooglePay{0} ErrorCode={1}", LanguagesManager.GetDesc("CsharpCodeZhTcText714"), initialResultData.ErrorCode) }, 1, arg3: false);
		}
	}

	private void OnProcessPurchase(string val)
	{
		try
		{
			int num = 0;
			int num2 = 100;
			while (true)
			{
				int num3 = num * num2;
				if (val.Length - num3 <= num2)
				{
					break;
				}
				num++;
			}
			PurchaseResultData purchaseResultData = JsonHelper.ToObject<PurchaseResultData>(val);
			BillingResult billingResult = JsonHelper.ToObject<BillingResult>(purchaseResultData.BillingResult);
			List<PurchaseInfo> list = JsonHelper.ToObject<List<PurchaseInfo>>(purchaseResultData.List);
			if (list == null)
			{
				return;
			}
			foreach (PurchaseInfo item in list)
			{
				Purchase purchase = JsonHelper.ToObject<Purchase>(item.zza);
				PurchaseManager.Instance.CheckOrder(purchase.obfuscatedAccountId, purchase.productId, purchase.orderId, item.zza);
			}
		}
		catch (Exception exception)
		{
			ILRuntimeDebug.LogException(exception);
			throw;
		}
		finally
		{
			GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
		}
	}

	private void OnConsume(string val)
	{
		ConsumeResult consumeResult = JsonHelper.ToObject<ConsumeResult>(val);
		BillingResult billingResult = JsonHelper.ToObject<BillingResult>(consumeResult.BillingResult);
		string purchaseToken = consumeResult.PurchaseToken;
	}

	private void OnLogin(string val)
	{
		Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
		LoginResultData loginResultData = JsonHelper.ToObject<LoginResultData>(val);
		if (loginResultData.ErrorCode == 0)
		{
			Dictionary<string, string> obj = new Dictionary<string, string>
			{
				{ "ServerAuthCode", loginResultData.Code },
				{ "GoogleId", loginResultData.GoogleId },
				{
					"ChannelCode",
					HotUpdateProcess.ChannelCode
				}
			};
			GameController.Contexts.Service<INetworkService>().AuthenticateByPlatform(JsonHelper.ToJson(obj), "Google", HotUpdateProcess.ChannelCode);
			GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { { "LoginType", "Google" } });
		}
		else
		{
			SharedMessenger.Broadcast("LOGIN_FAIL", string.Format("{0}{1}{2} {3}", LanguagesManager.GetDesc("CsharpCodeZhTcText718"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText719"), loginResultData.ErrorCode));
		}
	}

	private void OnGetProducts(string val)
	{
		ProductDetailResult productDetailResult = JsonHelper.ToObject<ProductDetailResult>(val);
		BillingResult billingResult = JsonHelper.ToObject<BillingResult>(productDetailResult.BillingResult);
		List<ProductDetailsInfo> list = JsonHelper.ToObject<List<ProductDetailsInfo>>(productDetailResult.List);
		if (list != null && list.Count > 0)
		{
			foreach (ProductDetailsInfo item in list)
			{
				if (Application.version.StartsWith("1001") && int.Parse(Application.version.Replace(".", "").Substring(0, 6)) > 100160)
				{
					ProductDetailV7 productDetailV = JsonHelper.ToObject<ProductDetailV7>(item.zza);
					ProductLocalInfo productLocalInfo = new ProductLocalInfo
					{
						ReferenceId = productDetailV.productId,
						Price = (float)productDetailV.oneTimePurchaseOfferDetails.priceAmountMicros / 1000000f,
						FormattedPrice = productDetailV.oneTimePurchaseOfferDetails.formattedPrice,
						CurrencyCode = productDetailV.oneTimePurchaseOfferDetails.priceCurrencyCode
					};
					if (!string.IsNullOrEmpty(productLocalInfo.CurrencyCode) && PurchaseBehavior_Intl.CurrencyCodeToSymbolMap.TryGetValue(productLocalInfo.CurrencyCode, out var value))
					{
						productLocalInfo.CurrencySymbol = value;
					}
					PurchaseManager.Instance.ProductLocalInfoDictionary[productDetailV.productId] = productLocalInfo;
				}
				else
				{
					ProductDetails productDetails = JsonHelper.ToObject<ProductDetails>(item.zza);
					ProductLocalInfo productLocalInfo2 = new ProductLocalInfo
					{
						ReferenceId = productDetails.productId,
						Price = (float)productDetails.oneTimePurchaseOfferDetails.priceAmountMicros / 1000000f,
						FormattedPrice = productDetails.oneTimePurchaseOfferDetails.formattedPrice,
						CurrencyCode = productDetails.oneTimePurchaseOfferDetails.priceCurrencyCode
					};
					if (!string.IsNullOrEmpty(productLocalInfo2.CurrencyCode) && PurchaseBehavior_Intl.CurrencyCodeToSymbolMap.TryGetValue(productLocalInfo2.CurrencyCode, out var value2))
					{
						productLocalInfo2.CurrencySymbol = value2;
					}
					PurchaseManager.Instance.ProductLocalInfoDictionary[productDetails.productId] = productLocalInfo2;
				}
			}
		}
		_taskGetProductDetails?.TrySetResult(result: true);
	}

	private void OnError(string val)
	{
		OnErrorResult onErrorResult = JsonHelper.ToObject<OnErrorResult>(val);
		SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { onErrorResult.Message }, 9999, arg3: false);
	}
}
