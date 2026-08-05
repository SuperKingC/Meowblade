using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.Networking;

namespace HotFix.Sources.Base.Scripts.Managers;

public class TapTapEventManager
{
	public enum TapTapEventType
	{
		Activation = 1,
		Register,
		Pay
	}

	private static TapTapEventManager _Instance = null;

	public static Dictionary<TapTapEventType, Action<object[]>> EventActionMap = new Dictionary<TapTapEventType, Action<object[]>>
	{
		{
			TapTapEventType.Activation,
			ActivationEvent_Android
		},
		{
			TapTapEventType.Register,
			RegisterEvent_Android
		},
		{
			TapTapEventType.Pay,
			PayEvent_Android
		}
	};

	public static Dictionary<TapTapEventType, Action<object[]>> EventActionMap_IOS = new Dictionary<TapTapEventType, Action<object[]>>
	{
		{
			TapTapEventType.Activation,
			ActivationEvent_IOS
		},
		{
			TapTapEventType.Register,
			RegisterEvent_IOS
		},
		{
			TapTapEventType.Pay,
			PayEvent_IOS
		}
	};

	public static TapTapEventManager Instance
	{
		get
		{
			if (_Instance == null)
			{
				_Instance = new TapTapEventManager();
			}
			return _Instance;
		}
	}

	private static string BaseAddress { get; set; }

	private static bool ActivationEventHappened { get; set; }

	private static long ActivateEventTimestamp { get; set; }

	private static string IDFA { get; set; }

	private static void ActivationEvent_Android(object[] _params)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 11 && ActivationEventHappened)
		{
			((MonoBehaviour)HotUpdateProcess.Instance).StartCoroutine(AndroidBasicPlugInManager.Instance.GetTapInfoHttp((MonoBehaviour)(object)HotUpdateProcess.Instance, ActivateEventTimestamp, BaseAddress, delegate
			{
				TapTapHttpPost(TapTapEventType.Activation);
			}));
		}
	}

	private static void ActivationEvent_IOS(object[] _params)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)Application.platform != 8 || !ActivationEventHappened)
		{
			return;
		}
		HotFixManager.GetIDFA().Then((Action<string>)delegate(string idfa)
		{
			IDFA = idfa;
		}).Finally((Action)delegate
		{
			AndroidBasicPlugInManager.Instance.GetIp(delegate
			{
				TapTapHttpPost_IOS(TapTapEventType.Activation);
			});
		});
	}

	private static void PayEvent_Android(object[] _params)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 11)
		{
			int amount = ((_params != null) ? ((int)_params[0]) : 0);
			TapTapHttpPost(TapTapEventType.Pay, amount);
		}
	}

	private static void PayEvent_IOS(object[] _params)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 8)
		{
			int payAmount = ((_params != null) ? ((int)_params[0]) : 0);
			HotFixManager.GetIDFA().Then((Action<string>)delegate(string idfa)
			{
				IDFA = idfa;
			}).Finally((Action)delegate
			{
				TapTapHttpPost_IOS(TapTapEventType.Pay, payAmount);
			});
		}
	}

	private static void RegisterEvent_Android(object[] _params)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 11)
		{
			TapTapHttpPost(TapTapEventType.Register);
		}
	}

	private static void RegisterEvent_IOS(object[] _params)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 8)
		{
			HotFixManager.GetIDFA().Then((Action<string>)delegate(string idfa)
			{
				IDFA = idfa;
			}).Finally((Action)delegate
			{
				TapTapHttpPost_IOS(TapTapEventType.Register);
			});
		}
	}

	public void RecordActivation(long activateEventTimestamp, string baseAddress)
	{
		ActivationEventHappened = true;
		ActivateEventTimestamp = activateEventTimestamp;
		BaseAddress = baseAddress;
	}

	private static void TapTapHttpPost(TapTapEventType eventType, int amount = 0)
	{
		string ip = ((!string.IsNullOrEmpty(AndroidBasicPlugInManager.Instance.Ipv4Address)) ? AndroidBasicPlugInManager.Instance.Ipv4Address : "");
		string ipv = ((!string.IsNullOrEmpty(AndroidBasicPlugInManager.Instance.Ipv6Address)) ? AndroidBasicPlugInManager.Instance.Ipv6Address : "");
		string url = "https://track.gubulin.com/TapTapConversionData/SubmitResult";
		TapTapEventData tapTapEventData = new TapTapEventData
		{
			UserId = ((eventType != TapTapEventType.Activation) ? GameController.Contexts.gameState.user.value.UserId : 0),
			EventType = (int)eventType,
			EventTimestamp = ((eventType == TapTapEventType.Activation) ? ActivateEventTimestamp : GameController.Instance.GetServerTime()),
			AndroidId = AndroidBasicPlugInManager.Instance.GetAndroidID(),
			Oaid = AndroidBasicPlugInManager.Instance.GetAndroidOAID(),
			Ip = ip,
			Ipv6 = ipv,
			Model = SystemInfo.deviceModel,
			Ua = AndroidBasicPlugInManager.Instance.GetAndroidUserAgent(),
			Device = "0",
			Amount = ((eventType == TapTapEventType.Pay) ? amount : 0),
			DeviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier
		};
		if (string.IsNullOrEmpty(tapTapEventData.Oaid) && string.IsNullOrEmpty(tapTapEventData.AndroidId))
		{
			ILRuntimeDebug.LogError($"Tap SendEvent {eventType} With No Oaid & AndroidId: {Environment.NewLine}{AndroidBasicPlugInManager.GetOAIDLogStacks}");
		}
		if (eventType == TapTapEventType.Activation)
		{
			((MonoBehaviour)HotUpdateProcess.Instance).StartCoroutine(WaitToHttpPost(url, JsonHelper.ToJson(tapTapEventData)));
		}
		else
		{
			FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.WaitToHttpPost(url, JsonHelper.ToJson(tapTapEventData)));
		}
	}

	private static void TapTapHttpPost_IOS(TapTapEventType eventType, int amount = 0)
	{
		string ip = ((!string.IsNullOrEmpty(AndroidBasicPlugInManager.Instance.Ipv4Address)) ? AndroidBasicPlugInManager.Instance.Ipv4Address : "");
		string ipv = ((!string.IsNullOrEmpty(AndroidBasicPlugInManager.Instance.Ipv6Address)) ? AndroidBasicPlugInManager.Instance.Ipv6Address : "");
		string url = "https://track.gubulin.com/TapTapConversionData/SubmitResult_IOS";
		TapTapEventData_IOS obj = new TapTapEventData_IOS
		{
			UserId = ((eventType != TapTapEventType.Activation) ? GameController.Contexts.gameState.user.value.UserId : 0),
			EventType = (int)eventType,
			EventTimestamp = ((eventType == TapTapEventType.Activation) ? ActivateEventTimestamp : GameController.Instance.GetServerTime()),
			Ip = ip,
			Ipv6 = ipv,
			Model = SystemInfo.deviceModel,
			Device = "1",
			Amount = ((eventType == TapTapEventType.Pay) ? amount : 0),
			IDFA = IDFA,
			DeviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier
		};
		if (eventType == TapTapEventType.Activation)
		{
			((MonoBehaviour)HotUpdateProcess.Instance).StartCoroutine(WaitToHttpPost(url, JsonHelper.ToJson(obj)));
		}
		else
		{
			FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.WaitToHttpPost(url, JsonHelper.ToJson(obj)));
		}
	}

	public void InvokeAction(TapTapEventType _eventType, params object[] _params)
	{
		if (EventActionMap.ContainsKey(_eventType))
		{
			EventActionMap[_eventType](_params);
		}
	}

	public void InvokeAction_IOS(TapTapEventType _eventType, params object[] _params)
	{
		if (EventActionMap_IOS.ContainsKey(_eventType))
		{
			EventActionMap_IOS[_eventType](_params);
		}
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
					ILRuntimeDebug.LogException(exception);
				}
			}
		}
		return null;
	}

	private static IPAddress GetExternalIpv6()
	{
		using (WebClient webClient = new WebClient())
		{
			List<string> list = new List<string>();
			list.Add("https://icanhazip.com");
			list.Add("https://wtfismyip.com/text");
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
