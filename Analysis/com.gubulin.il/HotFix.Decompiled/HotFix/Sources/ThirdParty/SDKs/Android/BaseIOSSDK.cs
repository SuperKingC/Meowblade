using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using HotFix.Sources.Base.Scripts.AdReport;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Enums.Sources;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.Networking;

namespace HotFix.Sources.ThirdParty.SDKs.Android;

public class BaseIOSSDK
{
	public class RateResult
	{
		public int ErrorCode { get; set; }
	}

	public class AppleRate
	{
		public string Title { get; set; }

		public string Message { get; set; }

		public string RateNow { get; set; }

		public string RateLate { get; set; }
	}

	public class OnGetIDFVResult
	{
		public int ErrorCode { get; set; }

		public string Idfv { get; set; }
	}

	public class OnGetClickIdResult
	{
		public int ErrorCode { get; set; }

		public string ClickId { get; set; }
	}

	public class OnGetUAResult
	{
		public int ErrorCode { get; set; }

		public string UserAgent { get; set; }
	}

	public class AppleAdToken
	{
		public int ErrorCode;

		public string Token;

		public string Version;
	}

	private class GoogleLogoutResult
	{
		public int ErrorCode;
	}

	public class GoogleLoginResult
	{
		public int ErrorCode;

		public string UserId;

		public string AccessToken;

		public string RefreshToken;

		public string IdToken;

		public string EmailAddress;

		public string Name;

		public string GivenName;

		public string FamilyName;

		public string ProfilePic;
	}

	private class FacebookProfileResult
	{
		public int ErrorCode;

		public string UserId;

		public string FirstName;

		public string MiddleName;

		public string Name;

		public string LinkUrl;

		public string ImageUrl;

		public string Email;

		public string Birthday;

		public Address Hometown;

		public Address Location;

		public string Gender;
	}

	private class Address
	{
		public string Id;

		public string Name;
	}

	private class FacebookCheckResult
	{
		public int ErrorCode;

		public int Email;

		public int PublicProfile;
	}

	private class FacebookLogoutResult
	{
		public int ErrorCode;
	}

	private class FacebookLoginResult
	{
		public int ErrorCode;

		public string ErrorMessage;

		public string UserId;

		public string TokenString;

		public string AppId;
	}

	private class InitializeAppleResult
	{
		public int ErrorCode;
	}

	private class SignInWithAppleResult
	{
		public int ErrorCode;

		public string Message;

		public string UserId;

		public string IdentityToken;

		public string AuthorizationCode;

		public string Email;

		public FullName FullName;

		public int RealUserStatus;
	}

	private class FullName
	{
		public string familyName;

		public string givenName;
	}

	private class InitializeWechatResult
	{
		public int ErrorCode;
	}

	private class WechatInstalledResult
	{
		public int ErrorCode;
	}

	private class SignInWithWechatResult
	{
		public string ErrStr;

		public int ErrCode;

		public string Code;

		public string State;

		public string Lang;

		public string Country;
	}

	private class ShareToWechatResult
	{
		public string ErrStr;

		public int ErrCode;
	}

	private class HaveWxURL
	{
		public int ErrorCode;
	}

	private static MethodInfo _bridgeCommunicateMethod;

	private static Dictionary<TaskCompletionSource<bool>, List<string>> _taskCompletionSourcesForProductDetails;

	public Dictionary<string, Action<string>> MethodMap;

	private string _userId;

	public const string STATE = "Legion_Wechat_Login";

	public static List<PlatformType> ValidPlatform = new List<PlatformType>();

	public static bool Ready = true;

	public static string IDFV = "";

	public static string UA = "";

	private static MethodInfo BridgeCommunicateMethod
	{
		get
		{
			if (_bridgeCommunicateMethod == null)
			{
				_bridgeCommunicateMethod = ((object)HotFixManager.Instance).GetType().GetMethod("InvokedFromUnity");
			}
			return _bridgeCommunicateMethod;
		}
	}

	public bool IsReady
	{
		get
		{
			return Ready;
		}
		set
		{
			Ready = value;
		}
	}

	private static void InvokeFromUnity(string msg)
	{
		BridgeCommunicateMethod.Invoke(HotFixManager.Instance, new object[1] { msg });
	}

	public BaseIOSSDK()
	{
		MethodMap = new Dictionary<string, Action<string>>
		{
			{ "InitializeApple", InitializeApple },
			{ "SignInWithApple", SignInWithApple },
			{ "InitializeWechat", InitializeWechat },
			{ "IsWxAppInstalled", IsWxAppInstalled },
			{ "SignInWithWechat", SignInWithWechat },
			{ "SharePicToWechat", SharePicToWechat },
			{ "havewxurl", IsHaveWxURL },
			{ "FacebookLogin", FacebookLogin },
			{ "FacebookLogout", FacebookLogout },
			{ "FacebookCheck", FacebookCheck },
			{ "FacebookProfile", FacebookProfile },
			{ "FacebookLogEvent", FacebookLogEvent },
			{ "FacebookLogStandardEvent", FacebookLogStandardEvent },
			{ "FacebookLogEventAndParams", FacebookLogEventAndParams },
			{ "FacebookSetAdEnable", FacebookSetAdEnable },
			{ "GoogleLogin", GoogleLogin },
			{ "GoogleLogout", GoogleLogout },
			{ "GetAdToken", GetAdToken },
			{ "Rate", Rate },
			{ "EnableIDFA", EnableIDFA },
			{ "DisabledIDFA", DisabledIDFA },
			{ "EnableDelayUpload", EnableDelayUpload },
			{ "StartSendingEvent", StartSendingEvent },
			{ "BDARegister", BDARegister },
			{ "BDAPurchase", BDAPurchase },
			{ "BDACustomEvent", BDACustomEvent },
			{ "BDAOptionalData", BDAOptionalData },
			{ "BDAGetClickId", BDAGetClickId },
			{ "BDAGetIDFV", BDAGetIDFV },
			{ "OnInitialApple", OnInitializeApple },
			{ "OnSignInWithApple", OnSignInWithApple },
			{ "OnInitialWechat", OnInitializeWechat },
			{ "OnWechatInstalled", OnWechatInstalled },
			{ "OnSignInWithWechat", OnSignInWithWechat },
			{ "OnShareToWechat", OnShareToWechat },
			{ "OnHaveWxURL", OnHaveWxURL },
			{ "OnFacebookLogin", OnFacebookLogin },
			{ "OnFacebookLogout", OnFacebookLogout },
			{ "OnFacebookCheck", OnFacebookCheck },
			{ "OnFacebookProfile", OnFacebookProfile },
			{ "OnGoogleLogin", OnGoogleLogin },
			{ "OnGoogleLogout", OnGoogleLogout },
			{ "OnAppleAdReport", OnAppleAdReport },
			{ "OnAppleAdReqport", OnAppleAdReport },
			{ "OnRate", OnRate },
			{ "OnGetIdfv", OnGetIDFV },
			{ "OnGetClickId", OnGetClickId },
			{ "OnGetUA", OnGetUA }
		};
		_taskCompletionSourcesForProductDetails = new Dictionary<TaskCompletionSource<bool>, List<string>>();
	}

	private void OnRate(string obj)
	{
		RateResult rateResult = JsonHelper.ToObject<RateResult>(obj);
		if (rateResult.ErrorCode != 0)
		{
		}
	}

	public void Rate(string obj)
	{
		InvokeFromUnity("rate:" + obj);
	}

	private void OnGetIDFV(string obj)
	{
		OnGetIDFVResult onGetIDFVResult = JsonHelper.ToObject<OnGetIDFVResult>(obj);
		if (onGetIDFVResult.ErrorCode == 0)
		{
			string idfv = onGetIDFVResult.Idfv;
			IDFV = idfv;
		}
		else
		{
			ILRuntimeDebug.LogError($"[BaseIOSSDK]OnGetIDFV ErrorCode={onGetIDFVResult.ErrorCode}");
		}
	}

	private void OnGetClickId(string obj)
	{
		OnGetClickIdResult onGetClickIdResult = JsonHelper.ToObject<OnGetClickIdResult>(obj);
		if (onGetClickIdResult.ErrorCode == 0)
		{
			string clickId = onGetClickIdResult.ClickId;
		}
	}

	private void OnGetUA(string obj)
	{
		OnGetUAResult onGetUAResult = JsonHelper.ToObject<OnGetUAResult>(obj);
		if (onGetUAResult.ErrorCode == 0)
		{
			UA = onGetUAResult.UserAgent;
		}
		else
		{
			ILRuntimeDebug.LogError($"[BaseIOSSDK]OnGetUA Failed ErrorCode={onGetUAResult.ErrorCode}");
		}
	}

	public void BDAGetIDFV(string obj)
	{
		InvokeFromUnity("bdagetidfv:{}");
	}

	public void BDAGetClickId(string obj)
	{
		InvokeFromUnity("bdagetclickid:{}");
	}

	public void BDAOptionalData(string obj)
	{
		InvokeFromUnity("bdaoptionaldata:" + obj);
	}

	public void BDACustomEvent(string obj)
	{
		InvokeFromUnity("bdacustomevent:" + obj);
	}

	public void BDAPurchase(string obj)
	{
		InvokeFromUnity("bdapurchase:" + obj);
	}

	public void BDARegister(string obj)
	{
		InvokeFromUnity("bdaregister:" + obj);
	}

	public void StartSendingEvent(string obj = null)
	{
		InvokeFromUnity("startsendingevent:{}");
	}

	public void EnableDelayUpload(string obj = null)
	{
		InvokeFromUnity("enabledelayupload:{}");
	}

	private void DisabledIDFA(string obj = null)
	{
		InvokeFromUnity("disabledidfa:{}");
	}

	private void EnableIDFA(string obj = null)
	{
		InvokeFromUnity("enableidfa:{}");
	}

	private void OnAppleAdReport(string obj)
	{
		((MonoBehaviour)GameController.Instance).StartCoroutine(UploadInfo(obj));
	}

	private IEnumerator UploadInfo(string obj)
	{
		AppleAdToken result = JsonHelper.ToObject<AppleAdToken>(obj);
		int userId = (string.IsNullOrEmpty(_userId) ? (-1) : int.Parse(_userId));
		Dictionary<string, object> payload;
		if (result.ErrorCode == 0)
		{
			if (!string.IsNullOrEmpty(result.Token))
			{
				payload = new Dictionary<string, object>
				{
					{ "Token", result.Token },
					{ "Result", "Success" }
				};
				GameLocalDataManager.MarkUserReportedAppleAd(userId);
			}
			else
			{
				payload = new Dictionary<string, object>
				{
					{
						"Token",
						string.Empty
					},
					{ "Result", "TokenUnavailable" }
				};
			}
		}
		else
		{
			payload = new Dictionary<string, object>
			{
				{ "Token", result.Token },
				{ "Result", "LowVersion" }
			};
		}
		string apiUrl = HotUpdateProcess.Instance.Configs["AuthServerUrl"];
		AdReportInfo trackData = new AdReportInfo
		{
			DeviceId = SystemInfo.deviceUniqueIdentifier,
			AdOrigin = "ASA",
			ChannelCode = HotUpdateProcess.ChannelCode,
			Payload = JsonHelper.ToJson(payload),
			UserId = userId
		};
		string trackDataStr = JsonHelper.ToJson(trackData);
		Uri uri = new Uri(apiUrl + "reportad");
		UnityWebRequest uwr = new UnityWebRequest(uri, "POST");
		try
		{
			uwr.SetRequestHeader("Content-Type", "application/json;charset=utf-8");
			uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(Encoding.UTF8.GetBytes(trackDataStr));
			yield return uwr.SendWebRequest();
		}
		finally
		{
			((IDisposable)uwr)?.Dispose();
		}
	}

	public void GetAdToken(string obj)
	{
		InvokeFromUnity("getadtoken:{}");
	}

	public void LogEvent(string obj)
	{
		Dictionary<string, string> obj2 = new Dictionary<string, string> { { "EventName", obj } };
		InvokeFromUnity("logevent:" + JsonHelper.ToJson(obj2));
	}

	public void LogStandardEvent(string obj)
	{
		InvokeFromUnity("logstandardevent:" + obj);
	}

	public void SetUserProperty(string obj)
	{
		InvokeFromUnity("SetUserProperty:" + obj);
	}

	public void SetUserId(string userId)
	{
		_userId = userId;
		Dictionary<string, string> obj = new Dictionary<string, string> { { "UserId", userId } };
		InvokeFromUnity("SetUserId:" + JsonHelper.ToJson(obj));
	}

	private void OnGoogleLogout(string obj)
	{
		GoogleLogoutResult googleLogoutResult = JsonHelper.ToObject<GoogleLogoutResult>(obj);
	}

	private void OnGoogleLogin(string obj)
	{
		GoogleLoginResult googleLoginResult = JsonHelper.ToObject<GoogleLoginResult>(obj);
		if (googleLoginResult.ErrorCode == 0)
		{
			Dictionary<string, object> obj2 = new Dictionary<string, object>
			{
				{ "GoogleId", googleLoginResult.UserId },
				{ "AccessToken", googleLoginResult.AccessToken },
				{ "RefreshToken", googleLoginResult.RefreshToken },
				{ "IdToken", googleLoginResult.IdToken },
				{ "EmailAddress", googleLoginResult.EmailAddress },
				{ "Name", googleLoginResult.Name },
				{ "GivenName", googleLoginResult.GivenName },
				{ "FamilyName", googleLoginResult.FamilyName },
				{ "ProfilePic", googleLoginResult.ProfilePic },
				{
					"ChannelCode",
					HotUpdateProcess.ChannelCode
				}
			};
			GameController.Contexts.Service<INetworkService>().AuthenticateByPlatform(JsonHelper.ToJson(obj2), "Google", HotUpdateProcess.ChannelCode);
			GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { { "LoginType", "Google" } });
		}
		else
		{
			SharedMessenger.Broadcast("LOGIN_FAIL", string.Format("{0}{1}{2}：{3}", LanguagesManager.GetDesc("CsharpCodeZhTcText718"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText719"), googleLoginResult.ErrorCode));
		}
	}

	public void GoogleLogout(string obj)
	{
		InvokeFromUnity("googlelogout:{}");
	}

	public void GoogleLogin(string obj)
	{
		InvokeFromUnity("googlelogin:{}");
	}

	public void FacebookSetAdEnable(string obj)
	{
		InvokeFromUnity("setadenable:" + obj);
	}

	public void FacebookLogEventAndParams(string obj)
	{
		InvokeFromUnity("facebooklogeventandparams:" + obj);
	}

	public void FacebookLogPurchase(string obj)
	{
		InvokeFromUnity("facebooklogpurchase:" + obj);
	}

	public void FacebookLogCheckOut(string obj)
	{
		InvokeFromUnity("facebooklogcheckout:" + obj);
	}

	public void FacebookLogStandardEvent(string obj)
	{
		InvokeFromUnity("facebooklogstandardevent:" + obj);
	}

	public void FacebookLogEvent(string obj = null)
	{
		InvokeFromUnity("facebookevent:" + obj);
	}

	public void FacebookProfile(string obj = null)
	{
		InvokeFromUnity("facebookprofile:{}");
	}

	public void FacebookCheck(string obj = null)
	{
		InvokeFromUnity("facebookcheck:{}");
	}

	public void FacebookLogout(string obj = null)
	{
		InvokeFromUnity("facebooklogout:{}");
	}

	public void FacebookLogin(string obj = null)
	{
		InvokeFromUnity("facebooklogin:{}");
	}

	public void OnFacebookProfile(string obj)
	{
		FacebookProfileResult facebookProfileResult = JsonHelper.ToObject<FacebookProfileResult>(obj);
		if (facebookProfileResult.ErrorCode == 0)
		{
			Dictionary<string, object> obj2 = new Dictionary<string, object>
			{
				{ "UserId", facebookProfileResult.UserId },
				{ "FirstName", facebookProfileResult.FirstName },
				{ "MiddleName", facebookProfileResult.MiddleName },
				{ "Name", facebookProfileResult.Name },
				{ "LinkUrl", facebookProfileResult.LinkUrl },
				{ "ImageUrl", facebookProfileResult.ImageUrl },
				{ "Email", facebookProfileResult.Email },
				{ "Birthday", facebookProfileResult.Birthday },
				{ "Hometown", facebookProfileResult.Hometown },
				{ "Location", facebookProfileResult.Location },
				{ "Gender", facebookProfileResult.Gender },
				{
					"ChannelCode",
					HotUpdateProcess.ChannelCode
				}
			};
			GameController.Contexts.Service<INetworkService>().AuthenticateByPlatform(JsonHelper.ToJson(obj2), "Facebook", HotUpdateProcess.ChannelCode);
			GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { { "LoginType", "Facebook" } });
		}
		else
		{
			SharedMessenger.Broadcast("LOGIN_FAIL", string.Format("{0}{1}{2}：{3}", LanguagesManager.GetDesc("CsharpCodeZhTcText718"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText719"), facebookProfileResult.ErrorCode));
		}
	}

	public void OnFacebookCheck(string obj)
	{
		FacebookLogoutResult facebookLogoutResult = JsonHelper.ToObject<FacebookLogoutResult>(obj);
	}

	public void OnFacebookLogout(string obj)
	{
		FacebookLogoutResult facebookLogoutResult = JsonHelper.ToObject<FacebookLogoutResult>(obj);
	}

	public void OnFacebookLogin(string obj)
	{
		FacebookLoginResult facebookLoginResult = JsonHelper.ToObject<FacebookLoginResult>(obj);
		if (facebookLoginResult.ErrorCode == 0)
		{
			FacebookProfile();
			return;
		}
		SharedMessenger.Broadcast("LOGIN_FAIL", string.Format("{0}{1}{2}：{3}, {4}", LanguagesManager.GetDesc("CsharpCodeZhTcText718"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText719"), facebookLoginResult.ErrorCode, facebookLoginResult.ErrorMessage));
	}

	public void InitializeApple(string info = "")
	{
		InvokeFromUnity("initializeapple:{}");
	}

	public void SignInWithApple(string info = "")
	{
		InvokeFromUnity("signinwithapple:{}");
	}

	public void InitializeWechat(string appId)
	{
		InvokeFromUnity("initializewechat:{\"AppID\":\"" + appId + "\",\"UniversalLink\":\"https://il.gubulin.com/app/\"}");
	}

	public void IsWxAppInstalled(string info = "")
	{
		InvokeFromUnity("iswxappinstalled:{}");
	}

	public void SignInWithWechat(string info = "")
	{
		InvokeFromUnity("signinwithwechat:{\"State\":\"Legion_Wechat_Login\"}");
	}

	public void SharePicToWechat(string filePath)
	{
		InvokeFromUnity("SharePic:{\"scene\": \"0\",\"imagePath\":\"" + filePath + "\"}");
	}

	public void IsHaveWxURL(string info = "")
	{
		Ready = false;
		InvokeFromUnity("havewxurl:{}");
	}

	private void OnInitializeApple(string info)
	{
		InitializeAppleResult initializeAppleResult = JsonHelper.ToObject<InitializeAppleResult>(info);
		if (initializeAppleResult.ErrorCode == 0)
		{
			SignInWithApple();
		}
	}

	private void OnSignInWithApple(string info = "")
	{
		SignInWithAppleResult signInWithAppleResult = JsonHelper.ToObject<SignInWithAppleResult>(info);
		if (signInWithAppleResult.ErrorCode == 0)
		{
			Dictionary<string, object> obj = new Dictionary<string, object>
			{
				{ "identityToken", signInWithAppleResult.IdentityToken },
				{
					"ChannelCode",
					HotUpdateProcess.ChannelCode
				},
				{ "authorizationCode", signInWithAppleResult.AuthorizationCode },
				{ "user", signInWithAppleResult.UserId },
				{
					"realUserStatus",
					signInWithAppleResult.RealUserStatus.ToString()
				},
				{ "fullName", signInWithAppleResult.FullName },
				{ "email", signInWithAppleResult.Email }
			};
			GameController.Contexts.Service<INetworkService>().AuthenticateByPlatform(JsonHelper.ToJson(obj), "AppleOriginal", HotUpdateProcess.ChannelCode);
			GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { { "LoginType", "Apple" } });
		}
		else
		{
			SharedMessenger.Broadcast("LOGIN_FAIL", string.Format("{0}{1}{2}：{3}, {4}", LanguagesManager.GetDesc("CsharpCodeZhTcText718"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText719"), signInWithAppleResult.ErrorCode, signInWithAppleResult.Message));
		}
	}

	public void OnInitializeWechat(string info = "")
	{
		InitializeWechatResult initializeWechatResult = JsonHelper.ToObject<InitializeWechatResult>(info);
	}

	private void OnWechatInstalled(string info = "")
	{
		WechatInstalledResult wechatInstalledResult = JsonHelper.ToObject<WechatInstalledResult>(info);
	}

	private void OnSignInWithWechat(string info = "")
	{
		SignInWithWechatResult signInWithWechatResult = JsonHelper.ToObject<SignInWithWechatResult>(info);
		if (signInWithWechatResult.ErrCode == 0 && "Legion_Wechat_Login".Equals(signInWithWechatResult.State))
		{
			GameController.Contexts.Service<INetworkService>().WechatLoginByCode(signInWithWechatResult.Code, HotUpdateProcess.ChannelCode);
			GameController.Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.Login, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { { "LoginType", "Wechat" } });
			SharedMessenger.Broadcast("IOS_WECHAT_LOGIN_SUCCESS");
		}
		else
		{
			SharedMessenger.Broadcast("LOGIN_FAIL", string.Format("{0}{1}{2}：{3}, {4}", LanguagesManager.GetDesc("CsharpCodeZhTcText718"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText719"), signInWithWechatResult.ErrCode, signInWithWechatResult.ErrStr));
		}
	}

	private void OnShareToWechat(string info = "")
	{
		ShareToWechatResult shareToWechatResult = JsonHelper.ToObject<ShareToWechatResult>(info);
	}

	private void OnHaveWxURL(string info = "")
	{
		HaveWxURL haveWxURL = JsonHelper.ToObject<HaveWxURL>(info);
		if (haveWxURL.ErrorCode == 0)
		{
			ValidPlatform.Add(PlatformType.WeChat);
		}
		else
		{
			ValidPlatform.Remove(PlatformType.WeChat);
		}
		Ready = true;
	}
}
