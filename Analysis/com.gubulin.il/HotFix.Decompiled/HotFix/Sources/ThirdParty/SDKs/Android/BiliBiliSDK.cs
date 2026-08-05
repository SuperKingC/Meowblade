using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.RPC.Api;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UnityEngine;

namespace HotFix.Sources.ThirdParty.SDKs.Android;

internal class BiliBiliSDK : BaseAndroidSDK
{
	private class BiliBiliSDKMsg
	{
		public int ErrorCode;

		public string Message;
	}

	public class BiliBiliUserProfile
	{
		public string uid;

		public string username;

		public string nickname;

		public string avatar;

		public string access_token;

		public string refresh_token;

		public string expire_times;
	}

	private class BiliBiliOnLoginMsg
	{
		public int ErrorCode;

		public string Message;

		public string UserId;

		public string UserName;

		public string Nickname;

		public string Avatar;

		public string AccessToken;

		public string ExpireTimes;

		public string RefreshToken;
	}

	private class BiliBiliOnPurchaseMsg
	{
		public int ErrorCode;

		public string Message;

		public string OrderId;

		public string BiliBiliOrderId;
	}

	public class BiliBiliOrderRemark
	{
		public string uid;

		public string username;

		public string role;

		public string subject;

		public string body;

		public string extension_info;

		public string serverId;

		public string total_fee;

		public string game_money;

		public string out_trade_no;

		public string notify_url;

		public string order_sign;
	}

	private static int ERRCODE_OK = 0;

	private static int ERRCODE_INIT_FAILED = -1;

	private static int ERRCODE_ACCOUNT_INVALID = -2;

	private static int ERRCODE_NEED_EXIT = -10;

	public BiliBiliUserProfile UserProfile;

	public bool Initializing = false;

	public bool IsLoggedIn = false;

	public BiliBiliSDK()
		: base("com.gubulin.il.bilibili.AndroidUnityBridge")
	{
		MethodMap = new Dictionary<string, Action<string>>
		{
			{ "OnInit", OnInit },
			{ "OnLogin", OnLogin },
			{ "OnLogout", OnLogout },
			{ "OnPurchase", OnPurchase },
			{ "OnGetUserInfo", OnGetUserInfo }
		};
	}

	public void Init()
	{
		if (!Initializing)
		{
			Initializing = true;
			SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Init:{}");
		}
	}

	public void NotifyZone()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, $"NotifyZone:{{\"role_id\":\"{GameController.Contexts.gameState.user.value.UserId}\",\"role_name\":\"{GameController.Contexts.gameState.user.value.Nickname}\"}}");
	}

	public void CreateRole()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, $"CreateRole:{{\"role_id\":\"{GameController.Contexts.gameState.user.value.UserId}\",\"role_name\":\"{GameController.Contexts.gameState.user.value.Nickname}\"}}");
	}

	public void Login()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Login:{}");
	}

	public void Logout()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Logout:{}");
	}

	public void IsLogin()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "IsLogin:{}");
	}

	public void GetUserInfo()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "GetUserInfo:{}");
	}

	public void StartHeart()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "StartHeart:{}");
	}

	public void StopHeart()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "StopHeart:{}");
	}

	public void Purchase(string jsonVal)
	{
		GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
		"目前无法支付".ToConfirmPopup(null, null, (AlignType)1, 40, mirrorBtns: false, needCancelButton: false);
	}

	private void OnInit(string val)
	{
		Initializing = false;
		BiliBiliSDKMsg biliBiliSDKMsg = JsonHelper.ToObject<BiliBiliSDKMsg>(val);
		if (biliBiliSDKMsg.ErrorCode != ERRCODE_OK)
		{
			if (biliBiliSDKMsg.ErrorCode == ERRCODE_NEED_EXIT)
			{
				GameController.Quit();
				return;
			}
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("SdkInitFailedTip", HotUpdateProcess.ChannelCode) }, 121, arg3: false);
		}
	}

	private void OnLogin(string val)
	{
		BiliBiliOnLoginMsg biliBiliOnLoginMsg = JsonHelper.ToObject<BiliBiliOnLoginMsg>(val);
		if (biliBiliOnLoginMsg.ErrorCode == ERRCODE_OK)
		{
			IsLoggedIn = true;
			GetUserInfo();
		}
		else
		{
			SharedMessenger.Broadcast("LOGIN_FAIL", string.Format("{0}({1}):{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText67"), biliBiliOnLoginMsg.ErrorCode, biliBiliOnLoginMsg.Message));
		}
	}

	private void OnLogout(string val)
	{
		IsLoggedIn = false;
	}

	private void OnGetUserInfo(string val)
	{
		try
		{
			BiliBiliOnLoginMsg biliBiliOnLoginMsg = JsonHelper.ToObject<BiliBiliOnLoginMsg>(val);
			if (biliBiliOnLoginMsg.ErrorCode == ERRCODE_OK)
			{
				UserProfile = new BiliBiliUserProfile
				{
					uid = biliBiliOnLoginMsg.UserId,
					username = biliBiliOnLoginMsg.UserName,
					nickname = biliBiliOnLoginMsg.Nickname,
					avatar = biliBiliOnLoginMsg.Avatar,
					access_token = biliBiliOnLoginMsg.AccessToken,
					refresh_token = biliBiliOnLoginMsg.RefreshToken,
					expire_times = biliBiliOnLoginMsg.ExpireTimes
				};
				AuthenticateByBiliBili();
			}
			else
			{
				SharedMessenger.Broadcast("LOGIN_FAIL", string.Format("{0}({1}):{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText67"), biliBiliOnLoginMsg.ErrorCode, biliBiliOnLoginMsg.Message));
			}
		}
		catch (Exception arg)
		{
			SharedMessenger.Broadcast("LOGIN_FAIL", LanguagesManager.GetDesc("CsharpCodeZhTcText67") ?? "");
			SentrySdk.AddBreadcrumb("OnGetUserInfo Exception: " + val);
			ILRuntimeDebug.LogError($"[BiliBiliSDK]OnGetUserInfo Exception: {arg}");
		}
		finally
		{
			GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
		}
	}

	private async void AuthenticateByBiliBili()
	{
		Dictionary<string, object> jsonUserInfo = new Dictionary<string, object>
		{
			{ "UId", UserProfile.uid },
			{ "AccessToken", UserProfile.access_token },
			{ "UserName", UserProfile.username },
			{ "Avatar", UserProfile.avatar },
			{
				"ChannelCode",
				HotUpdateProcess.ChannelCode
			}
		};
		await GameController.Contexts.Service<INetworkService>().AuthenticateByPlatform(JsonHelper.ToJson(jsonUserInfo), UserLoginCredentialsType.BiliBili.ToString(), HotUpdateProcess.ChannelCode);
		await GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { 
		{
			"LoginType",
			UserLoginCredentialsType.BiliBili.ToString()
		} });
	}

	private void OnPurchase(string val)
	{
		try
		{
			BiliBiliOnPurchaseMsg biliBiliOnPurchaseMsg = JsonHelper.ToObject<BiliBiliOnPurchaseMsg>(val);
			if (biliBiliOnPurchaseMsg.ErrorCode == ERRCODE_OK)
			{
				string orderMsg = JsonHelper.ToJson(new Dictionary<string, string>
				{
					{ "UId", UserProfile.uid },
					{ "OrderNo", biliBiliOnPurchaseMsg.BiliBiliOrderId }
				});
				PurchaseManager.Instance.CheckOrder(biliBiliOnPurchaseMsg.OrderId, "", biliBiliOnPurchaseMsg.BiliBiliOrderId, orderMsg);
			}
			else
			{
				SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("{0}({1}): {2}", LanguagesManager.GetDesc("CsharpCodeZhTcText57"), biliBiliOnPurchaseMsg.ErrorCode, biliBiliOnPurchaseMsg.Message) }, 1, arg3: false);
			}
		}
		catch (Exception arg)
		{
			SentrySdk.AddBreadcrumb("OnPurchase Exception: " + val);
			ILRuntimeDebug.LogError($"[BiliBiliSDK]OnPurchase Exception: {arg}");
		}
		finally
		{
			GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
		}
	}

	public static BiliBiliOrderRemark ParseOrderRemark(string orderRemarkStr)
	{
		return JsonHelper.ToObject<BiliBiliOrderRemark>(orderRemarkStr);
	}
}
