using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Shift.Legion.ClientApi.Sources.Extensions;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.Networking;

namespace HotFix.Sources.Base.Scripts.Managers;

public class AndroidBasicPlugInManager
{
	private class GetOaidCertTextResult
	{
		public int ErrorCode;

		public string Key;
	}

	private class GetTapIpAddressResult
	{
		public int ErrorCode;

		public string IPv4;

		public string IPv6;
	}

	public static string GetOAIDLogStacks = "";

	private const string AndroidPackagePrefix = "com.gubulin.il.BasicPlugin.AndroidUnityBridge";

	private const string AndroidPackagePrefix_Intl = "com.gubulin.il.BasicPluginIntl.AndroidUnityBridge";

	public const string MsaSdkName = "MsaSDK";

	private AndroidJavaClass unityPlayer;

	private AndroidJavaClass androidPlatformJavaBridge;

	private AndroidJavaObject currentUnityActivity;

	private AndroidJavaObject androidBasicPlugIn;

	private string oaidValue = "";

	private bool isOaidInit = false;

	private static AndroidBasicPlugInManager _Instance = null;

	public string Ipv4Address { get; set; }

	public string Ipv6Address { get; set; }

	public static AndroidBasicPlugInManager Instance
	{
		get
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Invalid comparison between Unknown and I4
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Expected O, but got Unknown
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Invalid comparison between Unknown and I4
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Invalid comparison between Unknown and I4
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Expected O, but got Unknown
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			if (_Instance == null)
			{
				_Instance = new AndroidBasicPlugInManager();
				if ((int)Application.platform == 11)
				{
					_Instance.unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
					_Instance.currentUnityActivity = ((AndroidJavaObject)_Instance.unityPlayer).GetStatic<AndroidJavaObject>("currentActivity");
				}
				if (!HotUpdateProcess.Instance.IsRegionOutCN)
				{
					if ((int)Application.platform == 11)
					{
						_Instance.androidPlatformJavaBridge = new AndroidJavaClass("com.gubulin.il.BasicPlugin.AndroidUnityBridge");
						_Instance.androidBasicPlugIn = ((AndroidJavaObject)_Instance.androidPlatformJavaBridge).CallStatic<AndroidJavaObject>("instance", new object[1] { _Instance.currentUnityActivity });
					}
				}
				else if ((int)Application.platform == 11)
				{
					_Instance.androidBasicPlugIn = (AndroidJavaObject)new AndroidJavaClass("com.gubulin.il.BasicPluginIntl.AndroidUnityBridge");
				}
			}
			return _Instance;
		}
	}

	private static string CreateMD5(string input)
	{
		using MD5 mD = MD5.Create();
		byte[] bytes = Encoding.ASCII.GetBytes(input);
		byte[] array = mD.ComputeHash(bytes);
		string text = BitConverter.ToString(array);
		return text.Replace("-", "").ToLower();
	}

	public string GetAndroidID()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		if ((int)Application.platform == 11)
		{
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				return androidBasicPlugIn.Call<string>("GetAndroidId", Array.Empty<object>());
			}
			if (CanGetAndroidId())
			{
				AndroidJavaObject val = currentUnityActivity.Call<AndroidJavaObject>("getContentResolver", Array.Empty<object>());
				AndroidJavaClass val2 = new AndroidJavaClass("android.provider.Settings$System");
				string input = ((AndroidJavaObject)val2).CallStatic<string>("getString", new object[2] { val, "android_id" });
				return CreateMD5(input);
			}
		}
		return string.Empty;
	}

	public string GetAndroidUserAgent()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 11)
		{
			if (androidBasicPlugIn == null)
			{
				return string.Empty;
			}
			return androidBasicPlugIn.Call<string>("getUserAgent", Array.Empty<object>());
		}
		return string.Empty;
	}

	public long GetMemoryUsage()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 11)
		{
			if (androidBasicPlugIn == null)
			{
				return -1L;
			}
			return androidBasicPlugIn.Call<long>("GetMemoryUsage", Array.Empty<object>());
		}
		return -2L;
	}

	public bool IsInstalledByZYT()
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		bool result = false;
		try
		{
			if ((int)Application.platform == 11)
			{
				result = androidBasicPlugIn != null && androidBasicPlugIn.Call<bool>("IsInstalledByZYT", Array.Empty<object>());
			}
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	private int GetAndroidApiLevel()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 11)
		{
			if (androidBasicPlugIn == null)
			{
				return 0;
			}
			return androidBasicPlugIn.Call<int>("getAndroidVersion", Array.Empty<object>());
		}
		return 0;
	}

	private bool CanGetAndroidId()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 11)
		{
			int androidApiLevel = GetAndroidApiLevel();
			return androidApiLevel < 26;
		}
		return false;
	}

	public string GetAndroidOAID()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 11)
		{
			return oaidValue;
		}
		return "";
	}

	public void SetOAIDValue(string _oaid)
	{
		isOaidInit = true;
		oaidValue = _oaid;
		GetOAIDLogStacks = GetOAIDLogStacks + "SetOAIDValue :" + oaidValue + Environment.NewLine;
		HotUpdateProcess.ReportActivateForAndroid();
	}

	public void GetIp(Action action = null)
	{
		((MonoBehaviour)HotUpdateProcess.Instance).StartCoroutine(Instance.GetIPAddressHttpPost((MonoBehaviour)(object)HotUpdateProcess.Instance, HotUpdateProcess.Instance.Configs["AuthServerUrl"], action));
	}

	public void PrefetchOAID(long timestamp, string baseAddress)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Invalid comparison between Unknown and I4
		if (!HotUpdateProcess.Instance.IsRegionOutCN && (int)Application.platform == 11 && (!(HotUpdateProcess.ChannelCode != "taptap") || !(HotUpdateProcess.ChannelCode != "tapplay") || !(HotUpdateProcess.ChannelCode != "toutiao-android") || !(HotUpdateProcess.ChannelCode != "bilibili")))
		{
			GetOAIDLogStacks = GetOAIDLogStacks + HotUpdateProcess.ChannelCode + " PrefetchOAID" + Environment.NewLine;
			((MonoBehaviour)HotUpdateProcess.Instance).StartCoroutine(Instance.PrefetchOAIDWaitToHttpPost((MonoBehaviour)(object)HotUpdateProcess.Instance, timestamp, baseAddress));
		}
	}

	private IEnumerator PrefetchOAIDWaitToHttpPost(MonoBehaviour hotupdateProcess, long timestamp, string _baseAddress)
	{
		if (!string.IsNullOrEmpty(oaidValue))
		{
			yield break;
		}
		if (CanGetAndroidId())
		{
			GetOAIDLogStacks = GetOAIDLogStacks + "Android api level < 26 ,can not get OAID" + Environment.NewLine;
			yield break;
		}
		Random rd = new Random();
		int _randomInt = rd.Next(0, (int)timestamp);
		string _key = $"deviceUniqueIdentifier={SystemInfo.deviceUniqueIdentifier}&RandomInt={_randomInt}&Timestamp={timestamp}&Key=wU3dWX2E1rbPJrUM";
		WWWForm form = new WWWForm();
		form.AddField("deviceUniqueIdentifier", SystemInfo.deviceUniqueIdentifier);
		form.AddField("RandomInt", _randomInt.ToString());
		form.AddField("Timestamp", timestamp.ToString());
		form.AddField("Key", HotFix_Utils.CreateMD5(_key));
		string _url = _baseAddress + "GetOAIDKey";
		if (HotUpdateProcess.ChannelCode == "bilibili")
		{
			form.AddField("PackageId", Application.identifier);
			_url = _baseAddress + "GetOAIDKeyByPackageId";
		}
		CoroutineWithData cd = new CoroutineWithData(hotupdateProcess, HttpPost(_url, form));
		yield return cd.Coroutine;
		if (cd.Result == null)
		{
			GetOAIDLogStacks = GetOAIDLogStacks + "Request OAID Pem Failed, url:" + _url + Environment.NewLine;
			yield break;
		}
		GetOaidCertTextResult _result = (GetOaidCertTextResult)cd.Result;
		if (_result.ErrorCode != 0)
		{
			GetOAIDLogStacks += $"Request OAID Pem Failed, ErrorCode {_result.ErrorCode}, url:{_url}{Environment.NewLine}";
			yield break;
		}
		byte[] bytes = Convert.FromBase64String(_result.Key);
		MsgSecurityClient.DoForOAIDCert(MsgSecurityAction.Decryption, ref bytes);
		string OAIDCertPemFileBase64Value = Encoding.UTF8.GetString(bytes);
		GetOAIDLogStacks = GetOAIDLogStacks + "Request OAID Pem Success, PemMD5:" + CreateMD5(OAIDCertPemFileBase64Value) + Environment.NewLine;
		hotupdateProcess.StartCoroutine(WaitOAIDFromAndroid());
		AndroidJavaObject obj = androidBasicPlugIn;
		if (obj != null)
		{
			obj.Call("GetOAIDValue", new object[1] { OAIDCertPemFileBase64Value });
		}
	}

	public IEnumerator GetTapInfoHttp(MonoBehaviour hotupdateProcess, long timestamp, string _baseAddress, Action action = null)
	{
		yield return GetIPAddressHttpPost(hotupdateProcess, _baseAddress);
		yield return null;
		action?.Invoke();
	}

	public IEnumerator GetIPAddressHttpPost(MonoBehaviour hotupdateProcess, string _baseAddress, Action action = null)
	{
		if (!string.IsNullOrEmpty(Ipv4Address) && !string.IsNullOrEmpty(Ipv6Address))
		{
			action?.Invoke();
			yield break;
		}
		string _url = _baseAddress + "GetIPAddress";
		CoroutineWithData cd = new CoroutineWithData(hotupdateProcess, HttpGet(_url));
		yield return cd.Coroutine;
		if (cd.Result == null)
		{
			action?.Invoke();
			yield break;
		}
		GetTapIpAddressResult _result = (GetTapIpAddressResult)cd.Result;
		if (_result.ErrorCode != 0)
		{
			action?.Invoke();
			yield break;
		}
		Ipv4Address = _result.IPv4;
		Ipv6Address = _result.IPv6;
		action?.Invoke();
	}

	private IEnumerator HttpPost(string url, WWWForm form)
	{
		UnityWebRequest www = UnityWebRequest.Post(url, form);
		www.chunkedTransfer = false;
		www.SetRequestHeader("Accept", "application/json");
		yield return www.SendWebRequest();
		if (www.isNetworkError || www.isHttpError)
		{
			yield return null;
			yield break;
		}
		if (string.IsNullOrEmpty(www.downloadHandler.text))
		{
			yield return null;
			yield break;
		}
		Dictionary<string, object> ResultUserCredentials = JsonHelper.ToObject<Dictionary<string, object>>(www.downloadHandler.text);
		object codeValue;
		if (ResultUserCredentials.TryGetValue("ErrorCode", out var code) && ResultUserCredentials.TryGetValue("Key", out var keyValue))
		{
			yield return new GetOaidCertTextResult
			{
				ErrorCode = int.Parse(code.ToString()),
				Key = keyValue.ToString()
			};
		}
		else if (ResultUserCredentials.TryGetValue("ErrorCode", out codeValue))
		{
			yield return new GetOaidCertTextResult
			{
				ErrorCode = int.Parse(codeValue.ToString()),
				Key = ""
			};
		}
		else
		{
			yield return new GetOaidCertTextResult
			{
				ErrorCode = -1
			};
		}
	}

	private IEnumerator HttpGet(string url)
	{
		UnityWebRequest uwr = UnityWebRequest.Get(url);
		yield return uwr.SendWebRequest();
		if (uwr.isNetworkError || uwr.isHttpError)
		{
			Debug.LogError((object)uwr.error);
			yield return null;
		}
		if (string.IsNullOrEmpty(uwr.downloadHandler.text))
		{
			yield return null;
			yield break;
		}
		Dictionary<string, object> ResultUserCredentials = JsonHelper.ToObject<Dictionary<string, object>>(uwr.downloadHandler.text);
		object codeValue;
		if (ResultUserCredentials.TryGetValue("ErrorCode", out var code) && ResultUserCredentials.TryGetValue("IPv4", out var ipv4KeyValue) && ResultUserCredentials.TryGetValue("IPv6", out var ipv6KeyValue))
		{
			yield return new GetTapIpAddressResult
			{
				ErrorCode = int.Parse(code.ToString()),
				IPv4 = ipv4KeyValue.ToString(),
				IPv6 = ipv6KeyValue.ToString()
			};
		}
		else if (ResultUserCredentials.TryGetValue("ErrorCode", out codeValue))
		{
			yield return new GetTapIpAddressResult
			{
				ErrorCode = int.Parse(codeValue.ToString()),
				IPv4 = "",
				IPv6 = ""
			};
		}
		else
		{
			yield return new GetTapIpAddressResult
			{
				ErrorCode = -1
			};
		}
	}

	private IEnumerator WaitOAIDFromAndroid(Action action = null)
	{
		bool errLogged = false;
		float _waitingTime = 0f;
		while (!isOaidInit)
		{
			yield return (object)new WaitForSeconds(0.1f);
			_waitingTime += 0.1f;
			if (!errLogged && _waitingTime > 3f)
			{
				errLogged = true;
				GetOAIDLogStacks = GetOAIDLogStacks + "WaitOAIDFromAndroid Timeout" + Environment.NewLine;
			}
		}
		action?.Invoke();
		SharedMessenger.Broadcast("ANDROID_OAID_AUTHED");
	}
}
