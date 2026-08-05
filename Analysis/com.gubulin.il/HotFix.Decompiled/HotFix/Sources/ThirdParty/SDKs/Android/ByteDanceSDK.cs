using System;
using System.Collections.Generic;
using Shift.Legion.Helpers;

namespace HotFix.Sources.ThirdParty.SDKs.Android;

internal class ByteDanceSDK : BaseAndroidSDK
{
	public ByteDanceSDK()
		: base("com.gubulin.il.bytedance.AndroidUnityBridge")
	{
		MethodMap = new Dictionary<string, Action<string>>();
	}

	public void InitOceanEngineTrack()
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "initOceanEngineTrack");
	}

	public void ReportPayEventBySdk(string itemType, string itemName, string itemId, int qty, string payment, string currency, int centsPrice)
	{
		string text = $"{{ \"itemType\":\"{itemType}\", \"itemName\":\"{itemName}\", \"itemId\":\"{itemId}\", \"qty\":{qty}, \"payment\":\"{payment}\", \"currency\":\"{currency}\", \"centsPrice\":{centsPrice} }}";
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "reportPurchase:" + text);
	}

	public void ReportRegistEventBySdk(string regType)
	{
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "reportRegister:" + regType);
	}

	public void ReportCustomEvent(string eventName, string jsonParams)
	{
		Dictionary<string, object> dictionary = ((!string.IsNullOrEmpty(jsonParams)) ? JsonHelper.ToObject<Dictionary<string, object>>(jsonParams) : new Dictionary<string, object>());
		dictionary.Add("eventName", eventName);
		SDKHelper.CallAndroid(AndroidPlatformJavaBridge, "reportCustomEvent:" + JsonHelper.ToJson(dictionary));
	}

	public void Init()
	{
		SharedMessenger.AddListener("ANDROID_OAID_AUTHED", InitOceanEngineTrack);
	}
}
