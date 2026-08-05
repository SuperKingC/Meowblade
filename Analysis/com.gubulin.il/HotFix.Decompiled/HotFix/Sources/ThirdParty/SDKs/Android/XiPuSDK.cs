using System;
using System.Collections.Generic;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.RPC.Api;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UnityEngine;

namespace HotFix.Sources.ThirdParty.SDKs.Android;

internal class XiPuSDK : BaseAndroidSDK
{
	public class XiPuUserProfile
	{
		public string sign;

		public string openid;

		public string timestamp;
	}

	private class XiPuOnLoginSuccessMsg
	{
		public string sign;

		public string openid;

		public string timestamp;
	}

	public class XiPuPayFailureMsg
	{
		public string errMsg;
	}

	public class XiPuOrderRemark
	{
		public string CallbackInfo;

		public string NotifyUrl;
	}

	public XiPuUserProfile UserProfile;

	public bool Initializing = false;

	public bool IsLoggedIn = false;

	private static int _lastOrderId = -1;

	public XiPuSDK()
		: base("com.gubulin.il.xipu.AndroidUnityBridge")
	{
		MethodMap = new Dictionary<string, Action<string>>
		{
			{ "OnLoginSuccess", OnLoginSuccess },
			{ "OnChangeAccount", OnChangeAccount },
			{ "OnPaySuccess", OnPaySuccess },
			{ "OnPayFailure", OnPayFailure },
			{ "OnBackPressed", OnBackPressed }
		};
	}

	public void Init()
	{
		if (!Initializing)
		{
			Initializing = true;
			SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Init:{}");
			Initializing = false;
			SharedMessenger.AddListener<int>("USER_LEVEL_UP", OnUserLevelUp);
		}
	}

	public void Login()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Login:{}");
	}

	public void Logout()
	{
		if (IsLoggedIn)
		{
			IsLoggedIn = false;
			SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Logout:{}");
		}
	}

	public void CreateRole()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, $"CreateRole:{{\"role_id\":\"{GameController.Contexts.gameState.user.value.UserId}\",\"role_name\":\"{GameController.Contexts.gameState.user.value.Nickname}\"}}");
	}

	public void LoginRole()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, $"LoginRole:{{\"role_id\":\"{GameController.Contexts.gameState.user.value.UserId}\",\"role_name\":\"{GameController.Contexts.gameState.user.value.Nickname}\",\"role_level\":\"{GameManagers.Instance.UserArchiveManager.GetUserLevel()}\"}}");
	}

	public void UpgradeRole()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, $"UpgradeRole:{{\"role_level\":\"{GameManagers.Instance.UserArchiveManager.GetUserLevel()}\"}}");
	}

	public void Purchase(string jsonVal, int orderId)
	{
		_lastOrderId = orderId;
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Purchase:" + jsonVal);
	}

	public void Exit()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Exit:{}");
	}

	public void ShowBallMenu()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "ShowBallMenu:{}");
	}

	public void HideBallMenu()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "HideBallMenu:{}");
	}

	private void OnLoginSuccess(string val)
	{
		XiPuOnLoginSuccessMsg xiPuOnLoginSuccessMsg = JsonHelper.ToObject<XiPuOnLoginSuccessMsg>(val);
		IsLoggedIn = true;
		UserProfile = new XiPuUserProfile
		{
			sign = xiPuOnLoginSuccessMsg.sign,
			openid = xiPuOnLoginSuccessMsg.openid,
			timestamp = xiPuOnLoginSuccessMsg.timestamp
		};
		AuthenticateByXiPu();
	}

	private void OnUserLevelUp(int newLevel)
	{
		UpgradeRole();
	}

	private async void AuthenticateByXiPu()
	{
		Dictionary<string, object> jsonUserInfo = new Dictionary<string, object>
		{
			{ "OpenId", UserProfile.openid },
			{ "Timestamp", UserProfile.timestamp },
			{ "Sign", UserProfile.sign },
			{
				"ChannelCode",
				HotUpdateProcess.ChannelCode
			}
		};
		await GameController.Contexts.Service<INetworkService>().AuthenticateByPlatform(JsonHelper.ToJson(jsonUserInfo), UserLoginCredentialsType.Xipu.ToString(), HotUpdateProcess.ChannelCode);
		await GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { 
		{
			"LoginType",
			UserLoginCredentialsType.Xipu.ToString()
		} });
	}

	private void OnChangeAccount(string val)
	{
		if (IsLoggedIn)
		{
			IsLoggedIn = false;
			SharedMessenger.Broadcast("SWITCH_ACCOUNT");
		}
	}

	private void OnPaySuccess(string val)
	{
		string text = _lastOrderId.ToString();
		_lastOrderId = -1;
		PurchaseManager.Instance.CheckOrder(text, "", "__XIPU__" + text);
		GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
	}

	public static void OnPayFailure(string val)
	{
		_lastOrderId = -1;
		XiPuPayFailureMsg xiPuPayFailureMsg = JsonHelper.ToObject<XiPuPayFailureMsg>(val);
		if (!string.IsNullOrEmpty(xiPuPayFailureMsg.errMsg))
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { xiPuPayFailureMsg.errMsg }, 1, arg3: false);
		}
		GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
	}

	public static XiPuOrderRemark ParseOrderRemark(string orderRemarkStr)
	{
		return JsonHelper.ToObject<XiPuOrderRemark>(orderRemarkStr);
	}

	public static void OnBackPressed(string val)
	{
		XiPuSDK xiPuSDK = (XiPuSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.XiPuSDK];
		SDKHelper.CallAndroid(xiPuSDK.AndroidPlatformJavaBridge, "Exit:{}");
	}
}
