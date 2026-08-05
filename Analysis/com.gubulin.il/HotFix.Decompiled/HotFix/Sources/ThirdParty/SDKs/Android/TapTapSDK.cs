using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UnityEngine;

namespace HotFix.Sources.ThirdParty.SDKs.Android;

internal class TapTapSDK : BaseAndroidSDK
{
	private class TapTapSDKMsg
	{
		public int ErrorCode;

		public string ErrorMsg;

		public string Data;
	}

	public class TapTapUserProfile
	{
		public string name;

		public string avatar;

		public string openid;

		public string unionid;
	}

	private const string TapTapPlatform = "TapTap";

	private const string ClientIDValue = "QOyO7viWTWE3WkXslZ";

	private const string ClientTokenValue = "eQR3fks6LtM27WPYIivuJBh9QRtOm8kBIudeD1ok";

	private static TaskCompletionSource<bool> _taskGetProductDetails;

	public TapTapUserProfile UserProfile;

	public bool IsInited = false;

	private Action _insteadAuthenticate = null;

	private string _updateAddress;

	public TapTapSDK()
		: base("com.gubulin.il.tapsdk.AndroidUnityBridge")
	{
		MethodMap = new Dictionary<string, Action<string>>
		{
			{ "OnInit", OnInit },
			{ "OnLoginSuccess", OnLoginSuccess },
			{ "OnLoginCancel", OnLoginCancel },
			{ "OnLoginError", OnLoginError },
			{ "OnCheckLoginState", OnCheckLoginState },
			{ "OnCancelForceUpdate", OnCancelForceUpdate },
			{ "OnUserVerify", OnUserVerify }
		};
	}

	public void Init()
	{
		string text = "{\"ClientID\":\"QOyO7viWTWE3WkXslZ\",\"ClientToken\":\"eQR3fks6LtM27WPYIivuJBh9QRtOm8kBIudeD1ok\"}";
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Init:" + text);
		FGUIManager.TapTapInitFinished = true;
	}

	public IEnumerator InitAndWaitResult()
	{
		Init();
		while (!FGUIManager.TapTapInitFinished)
		{
			yield return null;
		}
	}

	public void EnsureLoginState(Action insteadAuthenticate = null)
	{
		_insteadAuthenticate = insteadAuthenticate;
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "CheckLoginState:{}");
	}

	public void CheckLoginState()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "CheckLoginState:{}");
	}

	public void Login()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Login:{}");
	}

	public void Logout()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Logout:{}");
	}

	public void UserVerify()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, $"UserVerify:{{\"UserId\":{GameController.Contexts.gameState.user.value.UserId}}}");
	}

	public void OpenReview()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "OpenReview:{}");
	}

	private async void AuthenticateByTapTap(TapTapUserProfile profile)
	{
		Dictionary<string, object> jsonUserInfo = new Dictionary<string, object>
		{
			{ "name", profile.name },
			{ "avatar", profile.avatar },
			{ "openid", profile.openid },
			{ "unionid", profile.unionid },
			{
				"ChannelCode",
				HotUpdateProcess.ChannelCode
			}
		};
		await GameController.Contexts.Service<INetworkService>().AuthenticateByPlatform(JsonHelper.ToJson(jsonUserInfo), "TapTap", HotUpdateProcess.ChannelCode);
		await GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { { "LoginType", "TapTap" } });
	}

	private void OnInit(string val)
	{
		IsInited = true;
	}

	private void OnLoginSuccess(string val)
	{
		TapTapSDKMsg tapTapSDKMsg = JsonHelper.ToObject<TapTapSDKMsg>(val);
		if (tapTapSDKMsg.ErrorCode == 0)
		{
			UserProfile = JsonHelper.ToObject<TapTapUserProfile>(tapTapSDKMsg.Data);
			if (_insteadAuthenticate != null)
			{
				_insteadAuthenticate();
			}
			else
			{
				AuthenticateByTapTap(UserProfile);
			}
		}
		else
		{
			_insteadAuthenticate = null;
			SharedMessenger.Broadcast("LOGIN_FAIL", LanguagesManager.GetDesc("CsharpCodeZhTcText67") + ":" + tapTapSDKMsg.ErrorMsg);
		}
	}

	private void OnLoginError(string val)
	{
		_insteadAuthenticate = null;
		TapTapSDKMsg tapTapSDKMsg = JsonHelper.ToObject<TapTapSDKMsg>(val);
		SharedMessenger.Broadcast("LOGIN_FAIL", string.Format("{0}:[{1}]{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText67"), tapTapSDKMsg.ErrorCode, tapTapSDKMsg.ErrorMsg));
	}

	private void OnLoginCancel(string val)
	{
		_insteadAuthenticate = null;
		SharedMessenger.Broadcast("LOGIN_FAIL", LanguagesManager.GetDesc("CsharpCodeZhTcText68") ?? "");
	}

	private void OnCheckLoginState(string val)
	{
		TapTapSDKMsg tapTapSDKMsg = JsonHelper.ToObject<TapTapSDKMsg>(val);
		if (tapTapSDKMsg.ErrorCode == 0)
		{
			UserProfile = JsonHelper.ToObject<TapTapUserProfile>(tapTapSDKMsg.Data);
			if (_insteadAuthenticate != null)
			{
				_insteadAuthenticate();
			}
			else
			{
				AuthenticateByTapTap(UserProfile);
			}
		}
		else
		{
			Login();
		}
	}

	private void OnUserVerify(string val)
	{
		TapTapSDKMsg tapTapSDKMsg = JsonHelper.ToObject<TapTapSDKMsg>(val);
		bool flag = false;
		switch (tapTapSDKMsg.ErrorCode)
		{
		case 500:
			flag = true;
			SyncUserVerifyInfo();
			break;
		case 1000:
		case 1001:
		case 9002:
			GameController.OnSwitchAccount();
			break;
		case 1100:
			GameController.Contexts.Service<INetworkService>().Logout();
			break;
		case 1200:
			CertificationHelper.OpenCertificationMainPanel(CertificationHelper.GetFsm());
			break;
		}
	}

	private async Task SyncUserVerifyInfo()
	{
		VerifyIdentityTapTapV4Response verifyTapResult = await GameController.Contexts.Service<INetworkService>().VerifyIdentityTapTapV4();
		if (verifyTapResult.Result)
		{
			GameController.Contexts.gameState.user.value.Verified = verifyTapResult.Verified;
		}
		else
		{
			CertificationHelper.OpenCertificationMainPanel(CertificationHelper.GetFsm());
		}
	}

	public void ForceUpdate(string updateAddr = null)
	{
		if (string.IsNullOrEmpty(updateAddr))
		{
			_updateAddress = "https://" + HotUpdateProcess.Instance.RegionModel.Zone.url.domain;
		}
		else
		{
			_updateAddress = updateAddr;
		}
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "ForceUpdate:{}");
	}

	private void OnCancelForceUpdate(string val)
	{
		UiHelper.OpenUrl(_updateAddress);
	}

	public void CreateShortcut()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "CreateShortcut:{}");
	}
}
