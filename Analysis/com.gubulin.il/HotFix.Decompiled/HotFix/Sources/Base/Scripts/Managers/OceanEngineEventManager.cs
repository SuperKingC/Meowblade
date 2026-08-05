using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using HotFix.Sources.ThirdParty.SDKs.Android;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.Networking;

namespace HotFix.Sources.Base.Scripts.Managers;

public class OceanEngineEventManager
{
	public enum eventType
	{
		Activation,
		Register,
		Pay
	}

	private static OceanEngineEventManager _Instance = null;

	public static Dictionary<eventType, Action<object[]>> EventActionMap = new Dictionary<eventType, Action<object[]>>
	{
		{
			eventType.Activation,
			ActivationEvent
		},
		{
			eventType.Register,
			RegisterEvent
		},
		{
			eventType.Pay,
			PayEvent
		}
	};

	public static string IDFA;

	public static string UA;

	public static string OAID;

	private const string TrackActivateUrl = "https://ad.oceanengine.com/track/activate/";

	public static OceanEngineEventManager Instance
	{
		get
		{
			if (_Instance == null)
			{
				_Instance = new OceanEngineEventManager();
			}
			return _Instance;
		}
	}

	private static void GetAndroidIdentifier(OceanEngineConversionData convertData)
	{
		convertData.IMEI = Get_IMEI();
		convertData.OAID = Get_OAID();
		convertData.ANDROID_ID = SystemInfo.deviceUniqueIdentifier;
	}

	public static string Get_IMEI()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		string text = "";
		string text2 = "";
		string text3 = "";
		AndroidJavaClass val = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject val2 = ((AndroidJavaObject)val).GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject val3 = val2.Call<AndroidJavaObject>("getSystemService", new object[1] { "phone" });
		text = val3.Call<string>("getImei", new object[1] { 0 });
		text2 = val3.Call<string>("getImei", new object[1] { 1 });
		text3 = val3.Call<string>("getMeid", Array.Empty<object>());
		return text;
	}

	private static string Get_OAID()
	{
		return "";
	}

	private static string Get_IDFA()
	{
		if (string.IsNullOrEmpty(IDFA))
		{
			return "";
		}
		return IDFA;
	}

	private static string GET_IDFV()
	{
		string iDFV = BaseIOSSDK.IDFV;
		if (string.IsNullOrEmpty(iDFV))
		{
			ILRuntimeDebug.LogError("iOS Get IDFV Error...");
		}
		return iDFV;
	}

	private static IEnumerator WaitForIDFVAndDoCallback(Action callback = null)
	{
		float delayTotal = 0f;
		while (string.IsNullOrEmpty(BaseIOSSDK.IDFV))
		{
			yield return (object)new WaitForSeconds(0.1f);
			delayTotal += 0.1f;
			if (delayTotal > 3f)
			{
				ILRuntimeDebug.LogError($"[iOS OceanEngine] WaitForIDFV Failed! delayTotal={delayTotal}");
				yield break;
			}
		}
		yield return null;
		callback();
	}

	private static string Get_UA()
	{
		if (string.IsNullOrEmpty(UA))
		{
			return "";
		}
		return UA;
	}

	private static IEnumerator WaitForIOSUserAgentThenDoCallback(Action callback = null)
	{
		SentrySdk.AddBreadcrumb("[OceanEngineEventManager] WaitForIOSUserAgentThenDoCallback start");
		float delayTotal = 0f;
		while (string.IsNullOrEmpty(BaseIOSSDK.UA))
		{
			yield return (object)new WaitForSeconds(0.1f);
			delayTotal += 0.1f;
			if (delayTotal > 3f)
			{
				break;
			}
		}
		yield return null;
		if (string.IsNullOrEmpty(BaseIOSSDK.UA))
		{
			ILRuntimeDebug.LogError($"[OceanEngineEventManager]Get UA Failed, delayTotal={delayTotal}");
		}
		else
		{
			ILRuntimeDebug.LogError($"[OceanEngineEventManager]GetUA Success, delayTotal={delayTotal}, UA={BaseIOSSDK.UA}");
		}
		callback?.Invoke();
	}

	private static void RegisterEvent(object[] _params)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 8 && string.IsNullOrEmpty(UA))
		{
			HotFixManager.GetUA().Then((Action<string>)delegate
			{
				((MonoBehaviour)HotUpdateProcess.Instance).StartCoroutine(WaitForIOSUserAgentThenDoCallback(delegate
				{
					UA = BaseIOSSDK.UA;
					TouTiaoHttpPost(eventType.Register);
				}));
			}).Catch((Action<Exception>)delegate(Exception ex)
			{
				TouTiaoHttpPost(eventType.Register);
				ILRuntimeDebug.LogError("iOS Register Get UA Error..." + ex.Message);
			});
		}
		else if ((int)Application.platform == 11)
		{
			((ByteDanceSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.ByteDance]).ReportRegistEventBySdk(GameController.Contexts.gameState.user.value.LastLoginType);
			TouTiaoHttpPost(eventType.Register);
		}
		else
		{
			TouTiaoHttpPost(eventType.Register);
		}
	}

	private static void TouTiaoHttpPost(eventType _type, params object[] _params)
	{
		((MonoBehaviour)HotUpdateProcess.Instance).StartCoroutine(WaitForIDFVAndDoCallback(delegate
		{
			_TouTiaoHttpPost(_type, _params);
		}));
	}

	private static void _TouTiaoHttpPost(eventType _type, params object[] _params)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Invalid comparison between Unknown and I4
		string ip = ((!string.IsNullOrEmpty(AndroidBasicPlugInManager.Instance.Ipv4Address)) ? AndroidBasicPlugInManager.Instance.Ipv4Address : "");
		string url = "https://track.gubulin.com/OceanEngineData/SubmitResult";
		OceanEngineConversionData oceanEngineConversionData = new OceanEngineConversionData();
		oceanEngineConversionData.Ip = ip;
		oceanEngineConversionData.Model = SystemInfo.deviceModel;
		oceanEngineConversionData.Os = 3;
		if ((int)Application.platform == 11)
		{
			oceanEngineConversionData.Os = 0;
			oceanEngineConversionData.OAID = AndroidBasicPlugInManager.Instance.GetAndroidOAID();
			oceanEngineConversionData.ANDROID_ID = AndroidBasicPlugInManager.Instance.GetAndroidID();
			oceanEngineConversionData.Ua = AndroidBasicPlugInManager.Instance.GetAndroidUserAgent();
			if (string.IsNullOrEmpty(oceanEngineConversionData.OAID) && string.IsNullOrEmpty(oceanEngineConversionData.ANDROID_ID))
			{
				ILRuntimeDebug.LogError($"OceanEngine SendEvent {_type} With No OAID & ANDROID_ID: {Environment.NewLine}{AndroidBasicPlugInManager.GetOAIDLogStacks}");
			}
		}
		else if ((int)Application.platform == 8)
		{
			oceanEngineConversionData.Os = 1;
			oceanEngineConversionData.IDFA = Get_IDFA();
			oceanEngineConversionData.IDFV = GET_IDFV();
			oceanEngineConversionData.Ua = Get_UA();
			oceanEngineConversionData.IosVersion = OsVersionFormat(SystemInfo.operatingSystem);
		}
		if (_type == eventType.Pay)
		{
			oceanEngineConversionData.ProductId = _params[0].ToString();
			oceanEngineConversionData.PayAmount = (int)_params[2];
		}
		oceanEngineConversionData.DeviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
		oceanEngineConversionData.EventType = (int)_type;
		oceanEngineConversionData.MatchType = 0;
		if (_type == eventType.Activation)
		{
			((MonoBehaviour)HotUpdateProcess.Instance).StartCoroutine(WaitToHttpPost(url, JsonHelper.ToJson(oceanEngineConversionData)));
			return;
		}
		oceanEngineConversionData.ConvertTime = GameController.Instance.GetServerTime();
		oceanEngineConversionData.UserId = GameController.Contexts.gameState.user.value.UserId;
		FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.WaitToHttpPost(url, JsonHelper.ToJson(oceanEngineConversionData)));
	}

	private static string OsVersionFormat(string _iosVersion)
	{
		if (string.IsNullOrEmpty(_iosVersion))
		{
			return "";
		}
		_iosVersion = _iosVersion.Split(' ')[1];
		_iosVersion = _iosVersion.Replace('.', '_');
		return _iosVersion;
	}

	private static IPAddress GetExternalIpv4()
	{
		using (WebClient webClient = new WebClient())
		{
			List<string> list = new List<string>();
			list.Add("https://api.ipify.org");
			list.Add("https://ipinfo.io/ip");
			list.Add("https://checkip.amazonaws.com/");
			list.Add("https://ipecho.net/plain");
			foreach (string item in list)
			{
				try
				{
					string text = webClient.DownloadString(item);
					text = text.Replace("\n", "");
					return IPAddress.Parse(text);
				}
				catch (Exception exception)
				{
					ILRuntimeDebug.Log(exception);
				}
			}
		}
		return null;
	}

	private static void ActivationEvent(object[] _params)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)Application.platform != 8)
		{
			return;
		}
		SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].BDAGetIDFV(null);
		HotFixManager.GetIDFA().Then((Action<string>)delegate(string idfa)
		{
			IDFA = idfa;
		}).Finally((Action)delegate
		{
			HotFixManager.GetUA().Then((Action<string>)delegate(string ua)
			{
				UA = ua;
			}).Finally((Action)delegate
			{
				AndroidBasicPlugInManager.Instance.GetIp(delegate
				{
					TouTiaoHttpPost(eventType.Activation);
				});
			});
		});
	}

	private static void PayEvent(object[] _params)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Invalid comparison between Unknown and I4
		string itemId = _params[0].ToString();
		string itemName = _params[0].ToString();
		int qty = (int)_params[1];
		string payment = _params[2].ToString();
		string currency = _params[3].ToString();
		int centPrice = (int)((float)_params[4] * 100f);
		if ((int)Application.platform == 8 && string.IsNullOrEmpty(UA))
		{
			HotFixManager.GetUA().Then((Action<string>)delegate
			{
				((MonoBehaviour)HotUpdateProcess.Instance).StartCoroutine(WaitForIOSUserAgentThenDoCallback(delegate
				{
					UA = BaseIOSSDK.UA;
					TouTiaoHttpPost(eventType.Pay, itemId, payment, centPrice);
				}));
			}).Catch((Action<Exception>)delegate(Exception ex)
			{
				TouTiaoHttpPost(eventType.Pay, itemId, payment, centPrice);
				ILRuntimeDebug.LogError("iOS Pay Get UA Error..." + ex.Message);
			});
		}
		else if ((int)Application.platform == 11)
		{
			((ByteDanceSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.ByteDance]).ReportPayEventBySdk("Consumable", itemName, itemId, qty, payment, currency, centPrice);
			TouTiaoHttpPost(eventType.Pay, itemId, payment, centPrice);
		}
		else
		{
			TouTiaoHttpPost(eventType.Pay, itemId, payment, centPrice);
		}
	}

	private OceanEngineEventManager()
	{
	}

	public void InvokeAction(eventType _eventType, params object[] _params)
	{
		if (EventActionMap.ContainsKey(_eventType))
		{
			EventActionMap[_eventType](_params);
		}
	}

	private static IEnumerator WaitToHttpPost(string _url, string postData)
	{
		CoroutineWithData cd = new CoroutineWithData((MonoBehaviour)(object)HotUpdateProcess.Instance, HttpPost(_url, postData));
		yield return cd.Coroutine;
		if (cd.Result != null)
		{
		}
	}

	private static IEnumerator HttpPost(string url, string postData)
	{
		byte[] postDataBytes = Encoding.UTF8.GetBytes(postData);
		UnityWebRequest www = new UnityWebRequest(url, "POST");
		www.chunkedTransfer = false;
		www.uploadHandler = (UploadHandler)new UploadHandlerRaw(postDataBytes);
		www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
		www.SetRequestHeader("Content-Type", "application/json");
		www.SetRequestHeader("Accept", "application/json");
		yield return www.SendWebRequest();
		if (www.isNetworkError || www.isHttpError)
		{
			yield break;
		}
		if (!string.IsNullOrEmpty(www.downloadHandler.text))
		{
		}
		if (www.downloadHandler.data != null && www.downloadHandler.data.Length != 0)
		{
			string _data = "";
			for (int i = 0; i < www.downloadHandler.data.Length; i++)
			{
				_data += www.downloadHandler.data[i];
			}
		}
		yield return www.downloadHandler;
	}
}
