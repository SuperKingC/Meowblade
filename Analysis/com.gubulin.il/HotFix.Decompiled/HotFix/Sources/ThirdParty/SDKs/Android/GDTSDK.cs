using System;
using System.Collections.Generic;
using UnityEngine;

namespace HotFix.Sources.ThirdParty.SDKs.Android;

internal class GDTSDK : BaseAndroidSDK
{
	public static string SubChannel;

	public GDTSDK()
		: base("com.gubulin.il.gdt.AndroidUnityBridge")
	{
		MethodMap = new Dictionary<string, Action<string>>();
	}

	public void Init()
	{
		string text = "{\"channelId\":\"gdt-android\"}";
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "init:" + text);
		SubChannel = ((AndroidJavaObject)AndroidPlatformJavaBridge).CallStatic<string>("GetChannel", Array.Empty<object>());
	}

	public void OnRegister(string regType)
	{
		string text = "{\"method\":\"" + regType + "\"}";
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "onregister:" + text);
	}

	public void OnPurchase(string itemId, int qty, string payment, int totalPaid)
	{
		string text = $"{{\"id\":\"{itemId}\",\"number\":{qty},\"channel\":\"{payment}\", \"value\":{totalPaid}}}";
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "onpurchase:" + text);
	}
}
