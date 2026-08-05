using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using HotFix;
using HotFix.Sources.ThirdParty.SDKs.Android;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.Tips;

public class YYTXSDK : BaseAndroidSDK
{
	private class RoleInfo
	{
		public string role_id;

		public string role_name;

		public string server_id;

		public string server_name;

		public int role_level;
	}

	private class InitResultData
	{
		public int ErrorCode;
	}

	private class PayResultData
	{
		public int ErrorCode;

		public string Message;
	}

	private class LoginResultData
	{
		public int ErrorCode;

		public int Type;

		public string UserId;

		public string UserName;

		public string Token;

		public string ChannelCode;
	}

	private const int LoginType_UserLogin = 1001;

	private const int LoginType_SwitchAccount = 1002;

	public YYTXSDK()
		: base("com.gubulin.il.yytx.AndroidUnityBridge")
	{
		MethodMap = new Dictionary<string, Action<string>>
		{
			{ "Init", Init },
			{ "Pay", Pay },
			{ "Login", Login },
			{ "Logout", Logout },
			{ "SwitchAccount", SwitchAccount },
			{ "InitResult", InitResult },
			{ "PayResult", PayResult },
			{ "LoginResult", LoginResult }
		};
		SharedMessenger.AddListener<User>("NEW_USER_REGISTERED", OnNewUserRegistered);
		SharedMessenger.AddListener<int>("USER_LEVEL_UP", OnUserLevelUp);
	}

	private void OnNewUserRegistered(User user)
	{
		RoleInfo obj = new RoleInfo
		{
			role_id = user.UserId.ToString(),
			role_name = user.Nickname,
			server_id = user.ServerId.ToString(),
			server_name = user.ServerName
		};
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "CreateRole:" + JsonHelper.ToJson(obj));
	}

	private void OnUserLevelUp(int newLevel)
	{
		User value = GameController.Contexts.gameState.user.value;
		RoleInfo obj = new RoleInfo
		{
			role_id = value.UserId.ToString(),
			role_name = value.Nickname,
			server_id = value.ServerId.ToString(),
			server_name = value.ServerName,
			role_level = newLevel
		};
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "UpdateRole:" + JsonHelper.ToJson(obj));
	}

	public void Login(string info = null)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Login:{}");
	}

	public void Logout(string info = null)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Logout:{}");
	}

	public void SwitchAccount(string info)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "SwitchAccount:{}");
	}

	public void Pay(string info)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "YYTXPay:" + info);
	}

	public void Init(string appid = null)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "Init:{}");
	}

	public void InitResult(string val)
	{
		InitResultData initResultData = JsonHelper.ToObject<InitResultData>(val);
		if (initResultData.ErrorCode == 0)
		{
			Login();
		}
		else
		{
			Init();
		}
	}

	public void PayResult(string val)
	{
		List<string> list = new List<string>();
		PayResultData payResultData = JsonHelper.ToObject<PayResultData>(val);
		if (payResultData.ErrorCode == 0)
		{
			list.Add(LanguagesManager.GetDesc("CsharpCodeZhTcText712"));
			GameManagers.Instance.StockController.NeedSyncProduce = true;
		}
		else if (payResultData.ErrorCode == 1)
		{
			list.Add(LanguagesManager.GetDesc("CsharpCodeZhTcText715") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText716"));
			GameController.Contexts.Service<IUiService>().ClosePanel(UI_TakeItems.Name);
		}
		if (list.Count > 0)
		{
			SharedMessenger.Broadcast("SHOW_TIPS", list, 1, arg3: false);
		}
	}

	public void LoginResult(string val)
	{
		LoginResultData loginResultData = JsonHelper.ToObject<LoginResultData>(val);
		loginResultData.ChannelCode = HotUpdateProcess.ChannelCode;
		if (loginResultData.ErrorCode == 0)
		{
			List<string> arg = new List<string> { loginResultData.UserId + " " + LanguagesManager.GetDesc("CsharpCodeZhTcText720") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			if (loginResultData.Type == 1001)
			{
				GameController.Contexts.Service<INetworkService>().AuthenticateByPlatform(JsonHelper.ToJson(loginResultData), SDKManager.eSDKName.YYTX.ToString(), HotUpdateProcess.ChannelCode);
			}
			else
			{
				SharedMessenger.Broadcast("SWITCH_ACCOUNT");
			}
		}
		else
		{
			List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText67") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
			Login();
		}
	}
}
