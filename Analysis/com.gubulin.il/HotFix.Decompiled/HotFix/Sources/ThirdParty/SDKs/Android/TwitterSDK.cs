using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;

namespace HotFix.Sources.ThirdParty.SDKs.Android;

internal class TwitterSDK : BaseAndroidSDK
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

	private class BaseResult
	{
		public int ErrorCode;
	}

	private static TaskCompletionSource<bool> _taskGetProductDetails;

	public TwitterSDK()
		: base("com.gooplin.il.twittersdk.AndroidUnityBridge")
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
			{ "OnQueryProducts", OnQueryProducts },
			{ "Purchase", Purchase },
			{ "OnPurchase", OnPurchase },
			{ "QueryOrder", QueryOrder },
			{ "OnQueryOrder", OnQueryOrder },
			{ "VerifyOrder", VerifyOrder },
			{ "OnVerifyOrder", OnVerifyOrder }
		};
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
			PurchaseResult purchaseResult = JsonHelper.ToObject<PurchaseResult>(val);
			if (purchaseResult.ErrorCode == 0)
			{
				TapIntlOrder tapIntlOrder = JsonHelper.ToObject<TapIntlOrder>(purchaseResult.Order);
				string extra = tapIntlOrder.extra;
				string itemId = tapIntlOrder.itemId;
				string id = tapIntlOrder.id;
				QueryOrder(id);
				PurchaseManager.Instance.CheckOrder(extra, itemId, id, purchaseResult.Order);
			}
			else
			{
				SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("TapPay{0} ErrorCode={1}", LanguagesManager.GetDesc("CsharpCodeZhTcText57"), purchaseResult.ErrorCode) }, 1, arg3: false);
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
		SDKHelper.CallAndroid(((TwitterSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.TapIntlSDK]).AndroidPlatformJavaBridge, "queryproductdefaultlang:" + JsonHelper.ToJson(obj));
	}

	private void OnQueryProducts(string val)
	{
		_taskGetProductDetails?.TrySetResult(result: true);
		QueryProductResult queryProductResult = JsonHelper.ToObject<QueryProductResult>(val);
		if (queryProductResult.ErrorCode != 0)
		{
			return;
		}
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
		List<Product> list = JsonHelper.ToObject<List<Product>>(queryProductResult.Items);
		if (list == null)
		{
			return;
		}
		foreach (Product item in list)
		{
			ProductLocalInfo productLocalInfo = new ProductLocalInfo
			{
				ReferenceId = item.id,
				Price = (float)item.price,
				FormattedPrice = item.currency + item.price,
				CurrencyCode = item.currency
			};
			if (!string.IsNullOrEmpty(item.currency) && PurchaseBehavior_Intl.CurrencyCodeToSymbolMap.TryGetValue(item.currency, out var value))
			{
				productLocalInfo.CurrencySymbol = value;
				productLocalInfo.FormattedPrice = $"{value}{(float)item.price}";
			}
			PurchaseManager.Instance.ProductLocalInfoDictionary[item.id] = productLocalInfo;
		}
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

	public void Init(string obj = null)
	{
		string value = "cwbr3dqtplqkwwh5qq";
		string value2 = "To8rYEBYICwE9fAIp2EEWSuapwinzEQHkYgRamON";
		Dictionary<string, string> obj2 = new Dictionary<string, string>
		{
			{ "ClientId", value },
			{ "ClientToken", value2 }
		};
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "init:" + JsonHelper.ToJson(obj2));
	}

	public void OnInitial(string val)
	{
		BaseResult baseResult = JsonHelper.ToObject<BaseResult>(val);
		if (baseResult.ErrorCode == 0)
		{
		}
	}
}
