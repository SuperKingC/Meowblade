using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;

namespace HotFix.Sources.ThirdParty.SDKs.Android;

internal class FacebookSDK : BaseAndroidSDK
{
	private class ProfileResult
	{
		public int ErrorCode;

		public string Profile;
	}

	private class Profile
	{
		public string id;

		public string firstName;

		public string lastName;

		public string middleName;

		public string name;
	}

	private class LoginResult
	{
		public int ErrorCode;

		public string AccessToken;
	}

	private class AccessToken
	{
		public string token;

		public string applicationId;

		public string userId;
	}

	private class BaseResult
	{
		public int ErrorCode;
	}

	private static TaskCompletionSource<bool> _taskGetProductDetails;

	public FacebookSDK()
		: base("com.gooplin.il.facebooksdk.AndroidUnityBridge")
	{
		MethodMap = new Dictionary<string, Action<string>>
		{
			{ "Login", Login },
			{ "OnLogin", OnLogin },
			{ "GetProfile", GetProfile },
			{ "OnGetProfile", OnGetProfile },
			{ "Logout", Logout },
			{ "OnLogout", OnLogout },
			{ "LogEvent", LogEvent },
			{ "LogEventAndParams", LogEventAndParams },
			{ "LogStandardEvent", LogStandardEvent },
			{ "LogInitialCheckout", LogInitialCheckout },
			{ "LogPurchase", LogPurchase }
		};
	}

	public void LogInitialCheckout(string obj = null)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "loginitialcheckout:" + obj);
	}

	public void LogPurchase(string obj = null)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "logpurchase:" + obj);
	}

	public void LogStandardEvent(string obj = null)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "logstandardevent:" + obj);
	}

	public void LogEventAndParams(string obj = null)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "logeventandparams:" + obj);
	}

	public void LogEvent(string obj = null)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "logevent:" + obj);
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
		int num = 0;
		if (profileResult.ErrorCode == 0)
		{
			Profile profile = JsonHelper.ToObject<Profile>(profileResult.Profile);
			Dictionary<string, object> obj = new Dictionary<string, object>
			{
				{ "UserId", profile.id },
				{ "FirstName", profile.firstName },
				{ "MiddleName", profile.middleName },
				{ "Name", profile.name },
				{ "LinkUrl", "" },
				{ "ImageUrl", "" },
				{ "Email", "" },
				{ "Birthday", "" },
				{
					"ChannelCode",
					HotUpdateProcess.ChannelCode
				}
			};
			GameController.Contexts.Service<INetworkService>().AuthenticateByPlatform(JsonHelper.ToJson(obj), "Facebook", HotUpdateProcess.ChannelCode);
			num = 0;
		}
		else if (profileResult.Profile == null && num++ < 3)
		{
			Task task = Task.Delay(500);
			task.GetAwaiter().OnCompleted(delegate
			{
				GetProfile();
			});
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
		AccessToken accessToken = JsonHelper.ToObject<AccessToken>(loginResult.AccessToken);
		if (loginResult.ErrorCode == 0)
		{
			Task task = Task.Delay(500);
			task.GetAwaiter().OnCompleted(delegate
			{
				GetProfile();
			});
		}
		else
		{
			SharedMessenger.Broadcast("LOGIN_FAIL", string.Format("{0}{1}{2} [Login]{3}", LanguagesManager.GetDesc("CsharpCodeZhTcText718"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText719"), loginResult.ErrorCode));
		}
		Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
	}
}
