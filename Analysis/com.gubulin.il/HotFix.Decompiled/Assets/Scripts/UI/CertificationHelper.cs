using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.Managers;
using HotFix.Sources.ThirdParty.SDKs.Android;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.RPC.Api;
using Shift.Legion.Common.Services;
using UI.Certification;
using UnityEngine;

namespace Assets.Scripts.UI;

public static class CertificationHelper
{
	private static bool certificationTipShowed;

	private static bool certificationDialogShowed;

	public static string RealNameText = "";

	public static string IdCardNumberText = "";

	public static int GetFsm()
	{
		string fSM = GameController.FSM;
		int num = -1;
		return fSM switch
		{
			"0" => 0, 
			"1" => 1, 
			"2" => 2, 
			_ => -1, 
		};
	}

	public static void ShowCertificationDialogOnLoginSuccess()
	{
		int _fsm = GetFsm();
		if (_fsm == 0)
		{
			return;
		}
		User value = GameController.Contexts.gameState.user.value;
		if (value.Verified != 0 && value.Verified != 3 && value.Verified != 2)
		{
			return;
		}
		if (HotUpdateProcess.ChannelCode == "bilibili")
		{
			UserVerify_BiliBili();
			return;
		}
		if (HotUpdateProcess.ChannelCode == "xipu")
		{
			UserVerify_Xipu();
			return;
		}
		UserVerify(delegate
		{
			OpenCertificationMainPanel(_fsm);
		});
	}

	public static void OpenCertificationMainPanel(int fsmCode)
	{
		int num = 0;
		switch (fsmCode)
		{
		case 2:
		{
			num = 1;
			Dictionary<string, object> parameters2 = new Dictionary<string, object> { { "Type", num } };
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_CertificationMainPanel.Name, parameters2);
			break;
		}
		default:
			if (fsmCode != -1)
			{
				break;
			}
			goto case 1;
		case 1:
		{
			int todayPlayTime = GetTodayPlayTime();
			if (todayPlayTime >= 3600)
			{
				num = 1;
				Dictionary<string, object> parameters = new Dictionary<string, object> { { "Type", num } };
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_CertificationMainPanel.Name, parameters);
			}
			break;
		}
		}
	}

	public static void UserVerify(Action action)
	{
		if (!FGUIManager.IsTapTap || !FGUIManager.TapTapInitFinished)
		{
			action?.Invoke();
			return;
		}
		if (UiHelper.LoginTypeStr != UserLoginCredentialsType.TapTap.ToString())
		{
			action?.Invoke();
			return;
		}
		string text = Application.version.Replace(".", "");
		if (text.StartsWith("203") || text.StartsWith("204") || text.StartsWith("210") || text.StartsWith("211"))
		{
			TapTapSdkManager.Instance.GetAntiAddictionCurrentToken(action);
		}
		else if (SDKManager.Instance.SDKMap.ContainsKey(SDKManager.eSDKName.TapTapSDK))
		{
			((TapTapSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.TapTapSDK]).UserVerify();
		}
		else
		{
			TapTapSdkManager.Instance.GetAntiAddictionCurrentToken(action);
		}
	}

	public static async void UserVerify_BiliBili()
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		try
		{
			BiliBiliSDK sdk = (BiliBiliSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.BiliBiliSDK];
			VerifyIdentityBilibiliResponse verifyResult = await GameController.Contexts.Service<INetworkService>().VerifyIdentityBiliBili(sdk.UserProfile.access_token);
			if (verifyResult.ErrorCode == 0)
			{
				SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText149") }, 5000, arg3: false);
				ThinkingDataHelper.Instance.Track("realname_verify");
				User user = GameController.Contexts.gameState.user.value;
				user.Verified = 1;
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				return;
			}
			User user2 = GameController.Contexts.gameState.user.value;
			user2.Verified = 0;
			string errMsg = LanguagesManager.GetErrorMessage(verifyResult.ErrorCode);
			errMsg.ToConfirmPopup(async delegate
			{
				sdk.Logout();
				while (sdk.IsLoggedIn)
				{
					await Task.Delay(100);
				}
				GameController.Contexts.Service<INetworkService>().Logout();
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			}, null, (AlignType)1, 40, mirrorBtns: false, needCancelButton: false);
		}
		catch (Exception ex)
		{
			Exception e = ex;
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			ILRuntimeDebug.LogException(e);
			throw;
		}
	}

	private static async void UserVerify_Xipu()
	{
		Task<VerifyIdentityXipuResponse> task = GameController.Contexts.Service<INetworkService>().VerifyIdentityXipu();
		VerifyIdentityXipuResponse result = await task;
		if (result.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(result.ErrorCode);
			return;
		}
		User user = GameController.Contexts.gameState.user.value;
		user.Verified = 1;
	}

	public static int GetTodayPlayTime(bool isInit = false)
	{
		if (isInit)
		{
			string text = GameLocalDataManager.GetString("LastLoginTime");
			int num = 0;
			if (!string.IsNullOrEmpty(text))
			{
				num = int.Parse(text);
			}
			int num2 = (int)GameController.Instance.GetServerTime();
			DateTime dateTime = new DateTime(1970, 1, 1).ToLocalTime();
			long ticks = long.Parse(num2 + "0000000");
			TimeSpan value = new TimeSpan(ticks);
			DateTime dateTime2 = dateTime.Add(value);
			DateTime time = new DateTime(dateTime2.Year, dateTime2.Month, dateTime2.Day, 6, 0, 0);
			int timeStamp = DateTimeHelper.GetTimeStamp(time);
			if (num < timeStamp)
			{
				GameLocalDataManager.SetString("TodayPlayTime", "0");
			}
		}
		string text2 = GameLocalDataManager.GetString("TodayPlayTime");
		int result = 0;
		if (!string.IsNullOrWhiteSpace(text2))
		{
			result = int.Parse(text2);
		}
		return result;
	}

	public static void ShowCertificationTip()
	{
		if (!certificationTipShowed && GameController.Contexts.gameState.hasUser)
		{
			certificationTipShowed = true;
			User value = GameController.Contexts.gameState.user.value;
			if (value.Verified == 0 || value.Verified == 3 || value.Verified == 2)
			{
				Dictionary<string, object> parameters = new Dictionary<string, object> { { "Type", 0 } };
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_CertificationTipPopup.Name, parameters);
			}
		}
	}

	public static void ShowCertificationDialogOnExperienceEnding()
	{
		if (certificationDialogShowed)
		{
			return;
		}
		certificationDialogShowed = true;
		if (GameController.Contexts.gameState.hasUser)
		{
			User value = GameController.Contexts.gameState.user.value;
			if (value.Verified == 0 || value.Verified == 3 || value.Verified == 2)
			{
				Dictionary<string, object> parameters = new Dictionary<string, object> { { "Type", 1 } };
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_CertificationTipPopup.Name, parameters);
			}
		}
	}

	public static DateTime GetUserBirthdayDateTime(string idCardNumber)
	{
		if (string.IsNullOrEmpty(idCardNumber))
		{
			return DateTime.MinValue;
		}
		int year = 1980;
		int month = 1;
		int day = 1;
		if (idCardNumber.Length == 18)
		{
			year = int.Parse(idCardNumber.Substring(6, 4));
			month = int.Parse(idCardNumber.Substring(10, 2));
			day = int.Parse(idCardNumber.Substring(12, 2));
		}
		if (idCardNumber.Length == 15)
		{
			year = int.Parse("19" + idCardNumber.Substring(6, 2));
			month = int.Parse(idCardNumber.Substring(8, 2));
			day = int.Parse(idCardNumber.Substring(10, 2));
		}
		return new DateTime(year, month, day, 0, 0, 0);
	}
}
