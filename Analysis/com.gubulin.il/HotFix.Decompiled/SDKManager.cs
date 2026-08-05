using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Managers;
using HotFix;
using HotFix.Sources.Base.Scripts.Managers;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Enums.Sources;
using HotFix.Sources.ThirdParty.SDKs.Android;
using HotFix.Sources.ThirdParty.SDKs.PC;
using UnityEngine;

public class SDKManager
{
	public enum eSDKName
	{
		Default,
		WeChatSDK,
		RestarterSDK,
		YYTX,
		Xinxin,
		toutiao_official,
		PVP_test_official,
		GoogleSDK,
		TapTapSDK,
		TapIntlSDK,
		FacebookSDK,
		Twitter,
		iOS,
		ByteDance,
		GDT,
		Lenovo,
		BiliBiliSDK,
		XiPuSDK
	}

	private static SDKManager _Instance;

	public readonly Dictionary<eSDKName, BaseAndroidSDK> SDKMap;

	public readonly Dictionary<eSDKName, BaseIOSSDK> SDKMap_IOS;

	public readonly Dictionary<eSDKName, BasePCSDK> SDKMapPC;

	public static SDKManager Instance
	{
		get
		{
			if (_Instance == null)
			{
				_Instance = new SDKManager();
			}
			return _Instance;
		}
	}

	private SDKManager()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between I4 and Unknown
		string text = Application.version.Replace(".", "");
		if (8 == (int)Application.platform)
		{
			SDKMap_IOS = new Dictionary<eSDKName, BaseIOSSDK>();
			SDKMap_IOS.Add(eSDKName.iOS, new BaseIOSSDK());
			return;
		}
		SDKMap = new Dictionary<eSDKName, BaseAndroidSDK>();
		if (SDKHelper.GetSdkType() == eSDKName.YYTX)
		{
			SDKMap.Add(eSDKName.YYTX, new YYTXSDK());
		}
		else
		{
			if (SDKHelper.GetSdkType() == eSDKName.PVP_test_official)
			{
				return;
			}
			if (SDKHelper.GetSdkType() == eSDKName.GoogleSDK)
			{
				SDKMap.Add(eSDKName.GoogleSDK, new GoogleSDK());
				SDKMap.Add(eSDKName.FacebookSDK, new FacebookSDK());
			}
			else if (SDKHelper.GetSdkType() == eSDKName.TapIntlSDK)
			{
				SDKMap.Add(eSDKName.TapIntlSDK, new TapTapIntlSDK());
			}
			else if (SDKHelper.GetSdkType() == eSDKName.TapTapSDK)
			{
				SDKMap.Add(eSDKName.WeChatSDK, new WeChatSDK());
				if (!text.StartsWith("203") && !text.StartsWith("204") && !text.StartsWith("210") && !text.StartsWith("211"))
				{
					SDKMap.Add(eSDKName.TapTapSDK, new TapTapSDK());
				}
			}
			else if (SDKHelper.GetSdkType() == eSDKName.ByteDance)
			{
				SDKMap.Add(eSDKName.ByteDance, new ByteDanceSDK());
				SDKMap.Add(eSDKName.TapTapSDK, new TapTapSDK());
				SDKMap.Add(eSDKName.WeChatSDK, new WeChatSDK());
			}
			else if (SDKHelper.GetSdkType() == eSDKName.GDT)
			{
				SDKMap.Add(eSDKName.GDT, new GDTSDK());
				SDKMap.Add(eSDKName.WeChatSDK, new WeChatSDK());
			}
			else if (SDKHelper.GetSdkType() == eSDKName.BiliBiliSDK)
			{
				SDKMap.Add(eSDKName.BiliBiliSDK, new BiliBiliSDK());
			}
			else if (SDKHelper.GetSdkType() == eSDKName.XiPuSDK)
			{
				SDKMap.Add(eSDKName.XiPuSDK, new XiPuSDK());
			}
			else
			{
				SDKMap.Add(eSDKName.WeChatSDK, new WeChatSDK());
			}
		}
	}

	public void Logout()
	{
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Invalid comparison between Unknown and I4
		if (SDKHelper.GetSdkType() == eSDKName.YYTX)
		{
			((YYTXSDK)Instance.SDKMap[eSDKName.YYTX]).Logout();
		}
		if (FGUIManager.IsTapTap && FGUIManager.TapTapInitFinished)
		{
			if (HotUpdateProcess.ChannelCode == "toutiao-android")
			{
				TapTapSdkManager.Instance.TapTapLogout();
			}
			else
			{
				string text = Application.version.Replace(".", "");
				if (text.StartsWith("203") || text.StartsWith("204") || text.StartsWith("210") || text.StartsWith("211"))
				{
					TapTapSdkManager.Instance.TapTapLogout();
				}
				else
				{
					((TapTapSDK)Instance.SDKMap[eSDKName.TapTapSDK]).Logout();
				}
			}
		}
		if (SDKHelper.GetSdkType() == eSDKName.GoogleSDK)
		{
			((GoogleSDK)Instance.SDKMap[eSDKName.GoogleSDK]).Logout();
			((FacebookSDK)Instance.SDKMap[eSDKName.FacebookSDK]).Logout();
		}
		else if (SDKHelper.GetSdkType() == eSDKName.TapIntlSDK)
		{
			((TapTapIntlSDK)Instance.SDKMap[eSDKName.TapIntlSDK]).Logout();
		}
		else if (SDKHelper.GetSdkType() == eSDKName.Twitter)
		{
			((TwitterSDK)Instance.SDKMap[eSDKName.Twitter]).Logout();
		}
		else if (SDKHelper.GetSdkType() == eSDKName.BiliBiliSDK)
		{
			((BiliBiliSDK)Instance.SDKMap[eSDKName.BiliBiliSDK]).Logout();
		}
		else if (SDKHelper.GetSdkType() == eSDKName.XiPuSDK)
		{
			((XiPuSDK)Instance.SDKMap[eSDKName.XiPuSDK]).Logout();
		}
		if ((int)Application.platform == 8 && HotUpdateProcess.Instance.IsRegionOutCN)
		{
			Instance.SDKMap_IOS[eSDKName.iOS].FacebookLogout();
		}
	}

	public static bool IsReady()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between I4 and Unknown
		if (8 == (int)Application.platform)
		{
			return Instance.SDKMap_IOS[eSDKName.iOS].IsReady;
		}
		return true;
	}

	public static bool IsClientValid(PlatformType platformType)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between I4 and Unknown
		if (8 == (int)Application.platform)
		{
			return BaseIOSSDK.ValidPlatform.Contains(platformType);
		}
		return true;
	}

	public static bool CheckVersion()
	{
		Dictionary<string, string> configs = HotUpdateProcess.Instance.Configs;
		if (configs.ContainsKey("NewWechatAuth"))
		{
			return true;
		}
		return false;
	}

	public void OnGetScreenShots_Intl(int sortingOrder, Action action)
	{
		string path = CaptureScreenshotManager.Instance.CaptureScreenshot();
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FindScreenShot_Intl(path, sortingOrder, action));
	}

	public void OpenSomeChange(int sortingOrder, Action action)
	{
		string path = CaptureScreenshotManager.Instance.CaptureScreenshot();
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FindScreenShot(path, sortingOrder, action));
	}

	private IEnumerator FindScreenShot_Intl(string _path, int sortingOrder, Action action)
	{
		int second = 0;
		bool isExists = false;
		while (second <= 3 && !isExists)
		{
			second++;
			if (File.Exists(_path))
			{
				isExists = true;
			}
			yield return (object)new WaitForSeconds(1f);
		}
		if (!isExists)
		{
			List<string> tipList = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText65") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText66") };
			SharedMessenger.Broadcast("SHOW_TIPS", tipList, sortingOrder, arg3: false);
		}
		FGUIManager.Instance.SetScreenOrientationAutoRotation(action);
	}

	private IEnumerator FindScreenShot(string _path, int sortingOrder, Action action)
	{
		int second = 0;
		bool isExists = false;
		while (second <= 3 && !isExists)
		{
			second++;
			if (File.Exists(_path))
			{
				isExists = true;
			}
			yield return (object)new WaitForSeconds(1f);
		}
		if (isExists)
		{
			if (8 == (int)Application.platform)
			{
				Instance.SDKMap_IOS[eSDKName.iOS].InitializeWechat("wxa6206f99c0f8caaf");
				Instance.SDKMap_IOS[eSDKName.iOS].SharePicToWechat(_path);
			}
			else
			{
				((WeChatSDK)Instance.SDKMap[eSDKName.WeChatSDK]).SharePic(_path);
			}
		}
		else
		{
			List<string> tipList = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText65") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText66") };
			SharedMessenger.Broadcast("SHOW_TIPS", tipList, sortingOrder, arg3: false);
		}
		FGUIManager.Instance.SetScreenOrientationAutoRotation(action);
	}
}
