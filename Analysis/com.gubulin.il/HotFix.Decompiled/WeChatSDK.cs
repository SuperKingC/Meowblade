using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using HotFix;
using HotFix.Sources.ThirdParty.SDKs.Android;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using Shift.Legion.Server.Common.Helpers;
using UI.LoginAndName;
using UI.Tips;
using UnityEngine;

public class WeChatSDK : BaseAndroidSDK
{
	private class PayResultData
	{
		public string errStr;

		public int errCode;
	}

	private class ShareResultData
	{
		public int errCode;

		public string errStr;

		public string transaction;

		public string openId;
	}

	private class LoginResultData
	{
		public string errStr;

		public int errCode;

		public string code;

		public string state;

		public string lang;

		public string country;
	}

	private class OnGotQrcodeData
	{
		public string imgBase64;

		public string imgPath;
	}

	private enum QrCodeAuthErrorCode
	{
		OK = 0,
		NormalErr = -1,
		NetworkErr = -2,
		JsonDecodeErr = -3,
		Cancel = -4,
		Timeout = -5,
		Auth_Stopped = -6
	}

	private class OnQrcodeAuthFinishData
	{
		public int errCode;

		public string authCode;
	}

	public const string STATE = "Legion_Wechat_Login";

	private UI_popup_QrCodeDialog currentQrCodeDialog = null;

	private string lastQrCodeBase64;

	private int lastQrCodeRequestAt;

	public WeChatSDK()
		: base("com.gubulin.il.wxapi.AndroidUnityBridge")
	{
		MethodMap = new Dictionary<string, Action<string>>
		{
			{ "Init", Init },
			{ "Pay", Pay },
			{ "InitLogin", InitLogin },
			{ "Login", Login },
			{ "SharePic", SharePic },
			{ "PayResult", PayResult },
			{ "ShareResult", ShareResult },
			{ "LoginResult", LoginResult },
			{ "GetWechatLoginQRCode", GetWechatLoginQRCode },
			{ "OnGotQrcode", OnGotQrcode },
			{ "OnQrcodeScanned", OnQrcodeScanned },
			{ "OnQrcodeAuthFinish", OnQrcodeAuthFinish }
		};
	}

	public void SharePic(string filePath)
	{
		string paramInfo = "SharePic:{\"scene\": 0,\"imagePath\":\"" + filePath + "\"}";
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, paramInfo);
	}

	public void Login(string info = null)
	{
		string paramInfo = "Login:{\"scope\":\"snsapi_userinfo\",\"state\":\"Legion_Wechat_Login\"}";
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, paramInfo);
	}

	public void Pay(string info)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "WechatPay:" + info);
	}

	public void Init(string appid)
	{
		string paramInfo = "WechatPayInit:{\"appId\":\"" + appid + "\"}";
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, paramInfo);
	}

	public void InitLogin(string appid)
	{
		string paramInfo = "WechatLoginInit:{\"appId\":\"" + appid + "\"}";
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, paramInfo);
	}

	public void PayResult(string val)
	{
		List<string> list = new List<string>();
		PayResultData payResultData = JsonHelper.ToObject<PayResultData>(val);
		if (payResultData.errCode == 0)
		{
			list.Add(LanguagesManager.GetDesc("CsharpCodeZhTcText712"));
			GameManagers.Instance.StockController.NeedSyncProduce = true;
		}
		else if (payResultData.errCode == -1)
		{
			list.Add(LanguagesManager.GetDesc("CsharpCodeZhTcText715") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText716"));
			GameController.Contexts.Service<IUiService>().ClosePanel(UI_TakeItems.Name);
		}
		else if (payResultData.errCode == -2)
		{
			list.Add(LanguagesManager.GetDesc("CsharpCodeZhTcText713"));
			GameController.Contexts.Service<IUiService>().ClosePanel(UI_TakeItems.Name);
		}
		else
		{
			list.Add(LanguagesManager.GetDesc("CsharpCodeZhTcText715") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText717"));
			GameController.Contexts.Service<IUiService>().ClosePanel(UI_TakeItems.Name);
		}
		if (list.Count > 0)
		{
			SharedMessenger.Broadcast("SHOW_TIPS", list, 1, arg3: false);
		}
	}

	public void ShareResult(string val)
	{
		Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
		ShareResultData shareResultData = JsonHelper.ToObject<ShareResultData>(val);
		if (shareResultData.errCode != 0)
		{
		}
	}

	public void LoginResult(string val)
	{
		Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
		LoginResultData loginResultData = JsonHelper.ToObject<LoginResultData>(val);
		if (loginResultData.errCode == 0 && "Legion_Wechat_Login".Equals(loginResultData.state))
		{
			GameController.Contexts.Service<INetworkService>().WechatLoginByCode(loginResultData.code, HotUpdateProcess.ChannelCode);
			GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { { "LoginType", "Wechat" } });
			return;
		}
		string arg = string.Format("{0}{1}{2}({3})", LanguagesManager.GetDesc("CsharpCodeZhTcText718"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText719"), loginResultData.errCode);
		SharedMessenger.Broadcast("LOGIN_FAIL", arg);
	}

	public void GetWechatLoginQRCode(string val = null)
	{
		int timeStamp = DateTimeHelper.TimeStamp;
		if (!string.IsNullOrEmpty(lastQrCodeBase64) && timeStamp - lastQrCodeRequestAt < 60)
		{
			OpenQrCodeDialog(lastQrCodeBase64);
			return;
		}
		Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: true);
		string nonceStr = StringHelper.GenerateRandom(16);
		string timestamp = DateTimeHelper.TimeStamp.ToString();
		Task<string> getSignatureTask = GameController.Contexts.Service<INetworkService>().GetWechatQRCodeSignature(nonceStr, timestamp);
		getSignatureTask.GetAwaiter().OnCompleted(delegate
		{
			string result = getSignatureTask.Result;
			if (!string.IsNullOrEmpty(result))
			{
				string paramInfo = "ShowWechatLoginQRCode:{\"noncestr\":\"" + nonceStr + "\",\"timestamp\":\"" + timestamp + "\",\"signature\":\"" + result + "\"}";
				SDKHelper.CallAndroid(AndroidPlatformJavaBridge, paramInfo);
			}
			else
			{
				string arg = LanguagesManager.GetDesc("CsharpCodeZhTcText718") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText719");
				SharedMessenger.Broadcast("LOGIN_FAIL", arg);
			}
		});
	}

	private void CloseQrCodeDialog()
	{
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)currentQrCodeDialog, true);
		currentQrCodeDialog = null;
	}

	private void OpenQrCodeDialog(string imgBase64)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		try
		{
			byte[] array = Convert.FromBase64String(imgBase64);
			Texture2D val = new Texture2D(280, 280);
			ImageConversion.LoadImage(val, array);
			NTexture texture = new NTexture((Texture)(object)val);
			currentQrCodeDialog = UI_popup_QrCodeDialog.CreateInstance_ILRuntime();
			currentQrCodeDialog.QrCode.texture = texture;
			((GObject)currentQrCodeDialog).onClick.Add((EventCallback0)delegate
			{
				SharedMessenger.Broadcast("LOGIN_FAIL", string.Empty);
				CloseQrCodeDialog();
			});
			((GComponent)GRoot.inst).AddChild((GObject)(object)currentQrCodeDialog);
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)currentQrCodeDialog);
			FGUIManager.SetToFullScreen((GObject)(object)currentQrCodeDialog);
		}
		catch (Exception exception)
		{
			ILRuntimeDebug.LogException(exception);
			throw;
		}
	}

	public void OnGotQrcode(string val)
	{
		OnGotQrcodeData onGotQrcodeData = JsonHelper.ToObject<OnGotQrcodeData>(val);
		string imgBase = (lastQrCodeBase64 = onGotQrcodeData.imgBase64);
		lastQrCodeRequestAt = DateTimeHelper.TimeStamp;
		OpenQrCodeDialog(imgBase);
		Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
	}

	public void OnQrcodeScanned(string val)
	{
		Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: true);
	}

	public void OnQrcodeAuthFinish(string val)
	{
		Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
		CloseQrCodeDialog();
		OnQrcodeAuthFinishData onQrcodeAuthFinishData = JsonHelper.ToObject<OnQrcodeAuthFinishData>(val);
		if (onQrcodeAuthFinishData.errCode == 0)
		{
			lastQrCodeBase64 = null;
			lastQrCodeRequestAt = 0;
			GameController.Contexts.Service<INetworkService>().WechatLoginByCode(onQrcodeAuthFinishData.authCode, HotUpdateProcess.ChannelCode);
			GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { { "LoginType", "Wechat" } });
		}
		else
		{
			string arg = string.Format("{0}{1}{2}({3})", LanguagesManager.GetDesc("CsharpCodeZhTcText718"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText719"), onQrcodeAuthFinishData.errCode);
			SharedMessenger.Broadcast("LOGIN_FAIL", arg);
		}
	}
}
