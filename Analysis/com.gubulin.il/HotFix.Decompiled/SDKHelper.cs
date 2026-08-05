using System.Collections.Generic;
using HotFix;
using HotFix.Sources.Base.Scripts.Managers;
using Shift.Legion.Helpers;
using UnityEngine;

public class SDKHelper
{
	private class AndroidRetData
	{
		public string SDKName;

		public string MethodName;

		public string data;
	}

	private class IOSRetData
	{
		public string SDKName;

		public string MethodName;

		public string data;
	}

	public static Dictionary<string, SDKManager.eSDKName> ChannelCodeToSdkName = new Dictionary<string, SDKManager.eSDKName>
	{
		{
			"1001",
			SDKManager.eSDKName.YYTX
		},
		{
			"1002",
			SDKManager.eSDKName.Xinxin
		},
		{
			"101",
			SDKManager.eSDKName.toutiao_official
		},
		{
			"10",
			SDKManager.eSDKName.PVP_test_official
		},
		{
			"Google",
			SDKManager.eSDKName.GoogleSDK
		},
		{
			"TapIntl",
			SDKManager.eSDKName.TapIntlSDK
		},
		{
			"taptap",
			SDKManager.eSDKName.TapTapSDK
		},
		{
			"tapplay",
			SDKManager.eSDKName.TapTapSDK
		},
		{
			"toutiao-android",
			SDKManager.eSDKName.ByteDance
		},
		{
			"gdt-android",
			SDKManager.eSDKName.GDT
		},
		{
			"lenovo-android",
			SDKManager.eSDKName.Lenovo
		},
		{
			"bilibili",
			SDKManager.eSDKName.BiliBiliSDK
		},
		{
			"xipu",
			SDKManager.eSDKName.XiPuSDK
		}
	};

	public static void CallAndroid(AndroidJavaClass bridge, string paramInfo)
	{
		((AndroidJavaObject)bridge).CallStatic("InvokeFromUnity", new object[1] { paramInfo });
	}

	public static void InvokedFromAndroid(string paramInfo)
	{
		if (string.IsNullOrEmpty(paramInfo))
		{
			ILRuntimeDebug.LogError("Error , Invoked From Android is null");
			return;
		}
		AndroidRetData androidRetData = JsonHelper.ToObject<AndroidRetData>(paramInfo);
		if (androidRetData.SDKName == "MsaSDK")
		{
			AndroidBasicPlugInManager.Instance.SetOAIDValue(androidRetData.data);
			return;
		}
		SDKManager.eSDKName key = SDKManager.eSDKName.Default;
		if (androidRetData.SDKName == SDKManager.eSDKName.WeChatSDK.ToString())
		{
			key = SDKManager.eSDKName.WeChatSDK;
		}
		else if (androidRetData.SDKName == SDKManager.eSDKName.RestarterSDK.ToString())
		{
			key = SDKManager.eSDKName.RestarterSDK;
		}
		else if (androidRetData.SDKName == SDKManager.eSDKName.YYTX.ToString())
		{
			key = SDKManager.eSDKName.YYTX;
		}
		else if (androidRetData.SDKName == SDKManager.eSDKName.Xinxin.ToString())
		{
			key = SDKManager.eSDKName.Xinxin;
		}
		else if (androidRetData.SDKName == SDKManager.eSDKName.GoogleSDK.ToString())
		{
			key = SDKManager.eSDKName.GoogleSDK;
		}
		else if (androidRetData.SDKName == SDKManager.eSDKName.TapIntlSDK.ToString())
		{
			key = SDKManager.eSDKName.TapIntlSDK;
		}
		else if (androidRetData.SDKName == SDKManager.eSDKName.FacebookSDK.ToString())
		{
			key = SDKManager.eSDKName.FacebookSDK;
		}
		else if (androidRetData.SDKName == SDKManager.eSDKName.TapTapSDK.ToString())
		{
			key = SDKManager.eSDKName.TapTapSDK;
		}
		else if (androidRetData.SDKName == SDKManager.eSDKName.BiliBiliSDK.ToString())
		{
			key = SDKManager.eSDKName.BiliBiliSDK;
		}
		else if (androidRetData.SDKName == SDKManager.eSDKName.XiPuSDK.ToString())
		{
			key = SDKManager.eSDKName.XiPuSDK;
		}
		if (!SDKManager.Instance.SDKMap.ContainsKey(key))
		{
			ILRuntimeDebug.LogError("Error , SDKMap has not {0}", androidRetData.SDKName);
		}
		else if (!SDKManager.Instance.SDKMap[key].MethodMap.ContainsKey(androidRetData.MethodName))
		{
			ILRuntimeDebug.LogError("Error , SDKMap[{0}].MethodMap has not {1}", androidRetData.SDKName, androidRetData.MethodName);
		}
		else
		{
			SDKManager.Instance.SDKMap[key].MethodMap[androidRetData.MethodName](androidRetData.data);
		}
	}

	public static void InvokedFromIOS(string paramInfo)
	{
		if (string.IsNullOrEmpty(paramInfo))
		{
			ILRuntimeDebug.LogError("Error , Invoked From iOS is null");
			return;
		}
		IOSRetData iOSRetData = JsonHelper.ToObject<IOSRetData>(paramInfo);
		SDKManager.eSDKName key = SDKManager.eSDKName.iOS;
		if (!SDKManager.Instance.SDKMap_IOS.ContainsKey(key))
		{
			ILRuntimeDebug.LogError("Error , SDKMap has not {0}", iOSRetData.SDKName);
		}
		else if (!SDKManager.Instance.SDKMap_IOS[key].MethodMap.ContainsKey(iOSRetData.MethodName))
		{
			ILRuntimeDebug.LogError("Error , SDKMap[{0}].MethodMap has not {1}", iOSRetData.SDKName, iOSRetData.MethodName);
		}
		else
		{
			SDKManager.Instance.SDKMap_IOS[key].MethodMap[iOSRetData.MethodName](iOSRetData.data);
		}
	}

	public static SDKManager.eSDKName GetSdkType()
	{
		if (ChannelCodeToSdkName.TryGetValue(HotUpdateProcess.ChannelCode, out var value))
		{
			return value;
		}
		return SDKManager.eSDKName.Default;
	}
}
