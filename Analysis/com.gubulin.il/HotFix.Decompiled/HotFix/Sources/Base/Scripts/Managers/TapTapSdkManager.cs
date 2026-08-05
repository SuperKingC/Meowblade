using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using TapTap.Common;
using TapTap.Login;
using UI.Tips;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Managers;

public class TapTapSdkManager
{
	private static TapTapSdkManager _Instance;

	private const string TapTapPlatform = "TapTap";

	private const string ClientIDValue = "QOyO7viWTWE3WkXslZ";

	private const string ClientTokenValue = "eQR3fks6LtM27WPYIivuJBh9QRtOm8kBIudeD1ok";

	private const string TapTapGubulinServerUrl = "https://taptap-login.gubulin.com";

	public static TapTapSdkManager Instance
	{
		get
		{
			if (_Instance == null)
			{
				_Instance = new TapTapSdkManager();
			}
			return _Instance;
		}
	}

	public static bool IsTapTap { get; set; }

	private string OpenId { get; set; }

	private bool IsUnderAge { get; set; }

	public void TapTapSdkInit(string channelCode)
	{
		int isTapTap;
		switch (channelCode)
		{
		default:
			isTapTap = ((channelCode == "gubulin-android") ? 1 : 0);
			break;
		case "taptap":
		case "tapplay":
		case "toutiao-android":
			isTapTap = 1;
			break;
		}
		IsTapTap = (byte)isTapTap != 0;
		if (IsTapTap)
		{
			TapLogin.Init("QOyO7viWTWE3WkXslZ");
		}
	}

	public IEnumerator TapTapSdkInitIEnumerator(string channelCode)
	{
		int isTapTap;
		switch (channelCode)
		{
		default:
			isTapTap = ((channelCode == "gubulin-android") ? 1 : 0);
			break;
		case "taptap":
		case "tapplay":
		case "toutiao-android":
			isTapTap = 1;
			break;
		}
		IsTapTap = (byte)isTapTap != 0;
		if (IsTapTap)
		{
			ThinkingDataHelper.Instance.TrackTapTapInitBegin();
			TapLogin.Init("QOyO7viWTWE3WkXslZ");
			ThinkingDataHelper.Instance.TrackTapTapInitFinish();
			FGUIManager.TapTapInitFinished = true;
		}
		yield break;
	}

	public async Task GetTapTapLoginState()
	{
		if (IsTapTap)
		{
			try
			{
				await TapLogin.GetAccessToken();
				AuthenticateByTapTap(await TapLogin.FetchProfile());
			}
			catch (Exception)
			{
				await TapTapLogin();
			}
		}
	}

	public async Task TapTapLogin()
	{
		if (!IsTapTap)
		{
			return;
		}
		try
		{
			await TapLogin.Login();
		}
		catch (Exception ex)
		{
			Exception e = ex;
			string _tip = "TapTap" + LanguagesManager.GetDesc("CsharpCodeZhTcText67");
			TapException tapError = (TapException)(object)((e is TapException) ? e : null);
			if (tapError != null && tapError.code == 80002)
			{
				_tip = "TapTap" + LanguagesManager.GetDesc("CsharpCodeZhTcText68");
			}
			SharedMessenger.Broadcast("LOGIN_FAIL", _tip);
			return;
		}
		AuthenticateByTapTap(await TapLogin.FetchProfile());
	}

	private async void AuthenticateByTapTap(Profile profile)
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
		OpenId = profile.openid;
		await GameController.Contexts.Service<INetworkService>().AuthenticateByPlatform(JsonHelper.ToJson(jsonUserInfo), "TapTap", HotUpdateProcess.ChannelCode);
		await GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { { "LoginType", "TapTap" } });
	}

	public void TapTapLogout()
	{
		if (IsTapTap)
		{
			TapLogin.Logout();
		}
	}

	public async void GetAntiAddictionCurrentToken(Action action)
	{
		MethodInfo antiAddictionUIKitInitMethod = ((object)HotFixManager.Instance).GetType().GetMethod("TapAntiAddictionUIKitInit");
		MethodInfo antiAddictionUIKitStartupMethod = ((object)HotFixManager.Instance).GetType().GetMethod("TapTapAntiAddictionUIKitStartup");
		if ((object)antiAddictionUIKitInitMethod == null || (object)antiAddictionUIKitStartupMethod == null)
		{
			action?.Invoke();
			return;
		}
		Action<string> tapUserVerify = delegate(string s)
		{
			TapUserVerify(s, action);
		};
		antiAddictionUIKitInitMethod.Invoke(HotFixManager.Instance, new object[3] { "QOyO7viWTWE3WkXslZ", tapUserVerify, action });
		if (string.IsNullOrEmpty(OpenId))
		{
			OpenId = (await TapLogin.FetchProfile()).openid;
		}
		string userIdentifier = $"{GameController.Contexts.gameState.user.value.UserId}_{OpenId}";
		antiAddictionUIKitStartupMethod.Invoke(HotFixManager.Instance, new object[1] { userIdentifier });
	}

	private async void TapUserVerify(string tapVerifyToken, Action action)
	{
		if (string.IsNullOrEmpty(tapVerifyToken))
		{
			action?.Invoke();
			return;
		}
		VerifyIdentityTapTapResponse verifyTapResult = await GameController.Contexts.Service<INetworkService>().VerifyIdentityTapTap(tapVerifyToken);
		if (!verifyTapResult.Result)
		{
			UnityUiService.Instance.OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{ "Content", verifyTapResult.VerifyMessage },
				{
					"Buttons",
					new Dictionary<string, Action> { 
					{
						"Confirm",
						GameController.Quit
					} }
				},
				{ "PageIndex", 4 },
				{ "ClickSound", "Confirm" },
				{ "Order", 999999 }
			});
		}
		else if (verifyTapResult.Verified == 1)
		{
			User user = GameController.Contexts.gameState.user.value;
			user.Verified = 1;
		}
		else
		{
			action?.Invoke();
		}
	}
}
