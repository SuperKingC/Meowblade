using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UnityEngine;

namespace HotFix.Sources.ThirdParty.SDKs.Android;

internal class TapTapIntlSDK : BaseAndroidSDK
{
	private class QueryOrderResult
	{
		public int ErrorCode;

		public string Order;
	}

	public class PurchaseParam
	{
		public string ItemId;

		public string Extra;

		public int Quantity;
	}

	public class PurchaseProduct
	{
		public string ProductType;

		public string ProductId;

		public string Name;

		public string Description;

		public string RegionId;

		public string FormatterPrice;

		public string PriceAmountMicros;

		public string PriceCurrencyCode;

		public string Extra;
	}

	private class PurchaseResult
	{
		public int ErrorCode;

		public string Order;

		public string Msg;
	}

	private class TapIntlOrder
	{
		public string itemId;

		public decimal price;

		public decimal tax;

		public string currency;

		public int quantity;

		public string extra;

		public string id;

		public string token;

		public string state;

		public string channel;

		public decimal fee;

		public string clientId;

		public string userId;

		public string regionId;
	}

	private enum State
	{
		UNKNOWN = 0,
		PAYMENT_PENDING = 2,
		PAID = 3,
		COMPLETED = 4,
		PAYMENT_TIMEOUT = 5,
		REFUNDING = 20,
		REFUNDED = 21,
		REFUND_FAILED = 22,
		REFUND_REJECTED = 23
	}

	private class PurchaseModel
	{
		public string extra;

		public string orderId;

		public int purchaseState;

		public string productId;

		public int quantity;

		public string orderToken;

		public string purchaseToken;

		public bool isAcknowledged;
	}

	private class PurchaseResultV4
	{
		public int ErrorCode;

		public string Order;
	}

	private class PurchaseV4
	{
		public string obfuscatedAccountId;

		public string orderId;

		public int purchaseState;

		public string productId;

		public int quantity;

		public string orderToken;

		public string purchaseToken;

		public long purchaseTime;

		public bool acknowledged;
	}

	private class QueryProductResult
	{
		public int ErrorCode;

		public string Items;
	}

	private class Product
	{
		public int type;

		public string id;

		public string name;

		public string description;

		public decimal price;

		public string currency;

		public string regionId;

		public string languageId;
	}

	private class QueryProductResultV4
	{
		public int ErrorCode;

		public string Items;

		public string UnavailableId;

		public string TapPaymentResult;
	}

	private class ProfileResult
	{
		public int ErrorCode;

		public string Profile;
	}

	private class Profile
	{
		public string name;

		public string avatar;

		public string openid;

		public string unionid;

		public string email;

		public bool email_verified;
	}

	private class LoginResult
	{
		public int ErrorCode;

		public string Token;
	}

	private class AccessToken
	{
		public string kid;

		public string access_token;

		public string token_type;

		public string mac_key;

		public string mac_algorithm;

		public string scope;
	}

	private class LoginResultV4
	{
		public int ErrorCode;

		public string Account;
	}

	private class AccountV4
	{
		public AccessTokenV4 accessToken;

		public string avatar;

		public string email;

		public string name;

		public string openId;

		public string unionId;
	}

	private class AccessTokenV4
	{
		public string kid;

		public string macAlgorithm;

		public string macKey;

		public List<string> scopes;

		public string tokenType;
	}

	private class BaseResult
	{
		public int ErrorCode;
	}

	private static TaskCompletionSource<bool> _taskGetProductDetails;

	public TapTapIntlSDK()
		: base("com.gooplin.il.taptapintlsdk.AndroidUnityBridge")
	{
		MethodMap = new Dictionary<string, Action<string>>
		{
			{ "Init", Init },
			{ "OnInitial", OnInitial },
			{ "Login", Login },
			{ "OnLogin", OnLogin },
			{ "GetProfile", GetProfile },
			{ "OnGetProfile", OnGetProfile },
			{ "Logout", Logout },
			{ "OnLogout", OnLogout },
			{ "JumpTapTap", JumpTapTap },
			{ "OnQueryProducts", OnQueryProducts },
			{ "Purchase", Purchase },
			{ "OnPurchase", OnPurchase },
			{ "QueryOrder", QueryOrder },
			{ "OnQueryOrder", OnQueryOrder },
			{ "VerifyOrder", VerifyOrder },
			{ "OnVerifyOrder", OnVerifyOrder }
		};
	}

	public void JumpTapTap(string obj)
	{
		Dictionary<string, string> obj2 = new Dictionary<string, string> { { "AppId", "280291" } };
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "jumptaptap:" + JsonHelper.ToJson(obj2));
	}

	private void VerifyOrder(string obj)
	{
		string value = obj.Split(':')[0];
		string value2 = obj.Split(':')[1];
		Dictionary<string, string> obj2 = new Dictionary<string, string>
		{
			{ "OrderId", value },
			{ "OrderToken", value2 }
		};
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "verifyorder:" + JsonHelper.ToJson(obj2));
	}

	public void OnVerifyOrder(string val)
	{
	}

	private void QueryOrder(string obj)
	{
		Dictionary<string, string> obj2 = new Dictionary<string, string> { { "OrderId", obj } };
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "queryorder:" + JsonHelper.ToJson(obj2));
	}

	public void OnQueryOrder(string val)
	{
		QueryOrderResult queryOrderResult = JsonHelper.ToObject<QueryOrderResult>(val);
		if (queryOrderResult.ErrorCode == 0)
		{
			TapIntlOrder tapIntlOrder = JsonHelper.ToObject<TapIntlOrder>(queryOrderResult.Order);
		}
	}

	public void Purchase(string obj)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "purchase:" + obj);
	}

	private void OnPurchase(string val)
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
			if (HighVersionV4())
			{
				PurchaseResultV4 purchaseResultV = JsonHelper.ToObject<PurchaseResultV4>(val);
				if (purchaseResultV.ErrorCode == 0 && purchaseResultV.Order != "null")
				{
					PurchaseV4 purchaseV = JsonHelper.ToObject<PurchaseV4>(purchaseResultV.Order);
					string obfuscatedAccountId = purchaseV.obfuscatedAccountId;
					string productId = purchaseV.productId;
					string orderId = purchaseV.orderId;
					PurchaseManager.Instance.CheckOrder(obfuscatedAccountId, productId, orderId, purchaseResultV.Order);
				}
				else
				{
					SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("TapPay{0} ErrorCode={1}", LanguagesManager.GetDesc("CsharpCodeZhTcText57"), purchaseResultV.ErrorCode) }, 1, arg3: false);
				}
			}
			else
			{
				PurchaseResult purchaseResult = JsonHelper.ToObject<PurchaseResult>(val);
				if (purchaseResult.ErrorCode == 0 && purchaseResult.Order != "null")
				{
					PurchaseModel purchaseModel = JsonHelper.ToObject<PurchaseModel>(purchaseResult.Order);
					string extra = purchaseModel.extra;
					string productId2 = purchaseModel.productId;
					string orderId2 = purchaseModel.orderId;
					PurchaseManager.Instance.CheckOrder(extra, productId2, orderId2, purchaseResult.Order);
				}
				else
				{
					SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("TapPay{0} ErrorCode={1}", LanguagesManager.GetDesc("CsharpCodeZhTcText57"), purchaseResult.ErrorCode) }, 1, arg3: false);
				}
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

	public static void QueryProduct(List<string> items, TaskCompletionSource<bool> taskCompletionSource)
	{
		_taskGetProductDetails?.TrySetResult(result: true);
		_taskGetProductDetails = taskCompletionSource;
		Dictionary<string, object> obj = new Dictionary<string, object> { { "Items", items } };
		if (HighVersionV4())
		{
			SDKHelper.CallAndroid(((TapTapIntlSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.TapIntlSDK]).AndroidPlatformJavaBridge, "queryproduct:" + JsonHelper.ToJson(obj));
		}
		else
		{
			SDKHelper.CallAndroid(((TapTapIntlSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.TapIntlSDK]).AndroidPlatformJavaBridge, "queryproductdefaultlang:" + JsonHelper.ToJson(obj));
		}
	}

	private void OnQueryProducts(string val)
	{
		if (HighVersionV4())
		{
			_taskGetProductDetails?.TrySetResult(result: true);
			QueryProductResultV4 queryProductResultV = JsonHelper.ToObject<QueryProductResultV4>(val);
			if (queryProductResultV.ErrorCode == 0)
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
				List<ProductDetailV4> list = JsonHelper.ToObject<List<ProductDetailV4>>(queryProductResultV.Items);
				if (list == null)
				{
					return;
				}
				{
					foreach (ProductDetailV4 item in list)
					{
						ProductLocalInfo productLocalInfo = new ProductLocalInfo
						{
							ReferenceId = item.productId,
							Price = (float)item.oneTimePurchaseOfferDetails.priceAmountMicros / 1000000f,
							FormattedPrice = item.oneTimePurchaseOfferDetails.formatterPrice,
							CurrencyCode = item.oneTimePurchaseOfferDetails.priceCurrencyCode
						};
						if (!string.IsNullOrEmpty(item.oneTimePurchaseOfferDetails.priceCurrencyCode) && PurchaseBehavior_Intl.CurrencyCodeToSymbolMap.TryGetValue(item.oneTimePurchaseOfferDetails.priceCurrencyCode, out var value))
						{
							productLocalInfo.CurrencySymbol = value;
							productLocalInfo.FormattedPrice = item.oneTimePurchaseOfferDetails.formatterPrice ?? "";
						}
						PurchaseManager.Instance.ProductLocalInfoDictionary[item.productId] = productLocalInfo;
						PurchaseManager.Instance.TapIntlProductLocalInfoDictionaryV4[item.productId] = item;
					}
					return;
				}
			}
			ILRuntimeDebug.LogError("[TapTapIntlSDK] Get Product Failed: " + val);
			return;
		}
		_taskGetProductDetails?.TrySetResult(result: true);
		QueryProductResult queryProductResult = JsonHelper.ToObject<QueryProductResult>(val);
		if (queryProductResult.ErrorCode == 0)
		{
			int num4 = 0;
			int num5 = 100;
			while (true)
			{
				int num6 = num4 * num5;
				if (val.Length - num6 <= num5)
				{
					break;
				}
				num4++;
			}
			List<ProductDetails> list2 = JsonHelper.ToObject<List<ProductDetails>>(queryProductResult.Items);
			if (list2 == null)
			{
				return;
			}
			{
				foreach (ProductDetails item2 in list2)
				{
					ProductLocalInfo productLocalInfo2 = new ProductLocalInfo
					{
						ReferenceId = item2.productId,
						Price = (float)item2.priceAmountMicros / 1000000f,
						FormattedPrice = item2.formatterPrice,
						CurrencyCode = item2.priceCurrencyCode
					};
					if (!string.IsNullOrEmpty(item2.priceCurrencyCode) && PurchaseBehavior_Intl.CurrencyCodeToSymbolMap.TryGetValue(item2.priceCurrencyCode, out var value2))
					{
						productLocalInfo2.CurrencySymbol = value2;
						productLocalInfo2.FormattedPrice = item2.formatterPrice ?? "";
					}
					PurchaseManager.Instance.ProductLocalInfoDictionary[item2.productId] = productLocalInfo2;
					PurchaseManager.Instance.TapIntlProductLocalInfoDictionary[item2.productId] = item2;
				}
				return;
			}
		}
		ILRuntimeDebug.LogError("[TapTapIntlSDK] Get Product Failed: " + val);
	}

	public void Logout(string obj = null)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "logout:{}");
	}

	public void OnLogout(string val)
	{
		BaseResult baseResult = JsonHelper.ToObject<BaseResult>(val);
		if (baseResult.ErrorCode == 0)
		{
		}
	}

	private void GetProfile(string obj = null)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "getprofile:{}");
	}

	public void OnGetProfile(string val)
	{
		ProfileResult profileResult = JsonHelper.ToObject<ProfileResult>(val);
		if (profileResult.ErrorCode == 0)
		{
			Profile profile = JsonHelper.ToObject<Profile>(profileResult.Profile);
			Dictionary<string, object> obj = new Dictionary<string, object>
			{
				{ "name", profile.name },
				{ "avatar", profile.avatar },
				{ "openid", profile.openid },
				{ "unionid", profile.unionid },
				{ "email", profile.email },
				{
					"ChannelCode",
					HotUpdateProcess.ChannelCode
				}
			};
			GameController.Contexts.Service<INetworkService>().AuthenticateByPlatform(JsonHelper.ToJson(obj), "TapTapIntl", HotUpdateProcess.ChannelCode);
		}
		else
		{
			SharedMessenger.Broadcast("LOGIN_FAIL", string.Format("{0}{1}{2} [GetProfile]{3}", LanguagesManager.GetDesc("CsharpCodeZhTcText718"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText719"), profileResult.ErrorCode));
		}
	}

	public void Login(string obj)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "login:{}");
	}

	public void OnLogin(string val)
	{
		if (HighVersionV4())
		{
			LoginResultV4 loginResultV = JsonHelper.ToObject<LoginResultV4>(val);
			if (loginResultV.ErrorCode == 0)
			{
				AccountV4 accountV = JsonHelper.ToObject<AccountV4>(loginResultV.Account);
				Dictionary<string, object> obj = new Dictionary<string, object>
				{
					{ "name", accountV.name },
					{ "avatar", accountV.avatar },
					{ "openid", accountV.openId },
					{ "unionid", accountV.unionId },
					{ "email", accountV.email },
					{
						"ChannelCode",
						HotUpdateProcess.ChannelCode
					}
				};
				GameController.Contexts.Service<INetworkService>().AuthenticateByPlatform(JsonHelper.ToJson(obj), "TapTapIntl", HotUpdateProcess.ChannelCode);
			}
			else
			{
				SharedMessenger.Broadcast("LOGIN_FAIL", string.Format("{0}{1}{2} [Login]{3}", LanguagesManager.GetDesc("CsharpCodeZhTcText718"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText719"), loginResultV.ErrorCode));
			}
			Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
		}
		else
		{
			LoginResult loginResult = JsonHelper.ToObject<LoginResult>(val);
			if (loginResult.ErrorCode == 0)
			{
				GetProfile();
			}
			else
			{
				SharedMessenger.Broadcast("LOGIN_FAIL", string.Format("{0}{1}{2} [Login]{3}", LanguagesManager.GetDesc("CsharpCodeZhTcText718"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText719"), loginResult.ErrorCode));
			}
			Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
		}
	}

	public void Init(string obj = null)
	{
		string value = "cwbr3dqtplqkwwh5qq";
		string value2 = "To8rYEBYICwE9fAIp2EEWSuapwinzEQHkYgRamON";
		if (HighVersionV4())
		{
			Dictionary<string, object> obj2 = new Dictionary<string, object>
			{
				{ "ClientId", value },
				{ "ClientToken", value2 },
				{ "EnableLog", false }
			};
			SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "init:" + JsonHelper.ToJson(obj2));
		}
		else
		{
			Dictionary<string, string> obj3 = new Dictionary<string, string>
			{
				{ "ClientId", value },
				{ "ClientToken", value2 }
			};
			SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "init:" + JsonHelper.ToJson(obj3));
		}
	}

	public void OnInitial(string val)
	{
		BaseResult baseResult = JsonHelper.ToObject<BaseResult>(val);
		if (baseResult.ErrorCode == 0)
		{
		}
	}

	public static bool HighVersionV4()
	{
		int num = int.Parse(Application.version.Replace(".", "").Substring(0, 6));
		if (num <= 100163)
		{
			return false;
		}
		return true;
	}
}
