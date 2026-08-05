using System;
using System.Collections;
using System.Text;
using HotFix.Sources.ThirdParty.SDKs.Android;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.Networking;

namespace HotFix.Sources.Base.Scripts.Managers;

public class BiliBiliEventManager : MonoBehaviour
{
	public enum BiliBiliEventType
	{
		APP_FIRST_ACTIVE,
		USER_REGISTER,
		USER_COST
	}

	private static BiliBiliEventManager _Instance;

	private const string EventUrl = "https://track.gubulin.com";

	private const string EventPath = "/api/BiliBiliData/submitresult";

	public static BiliBiliEventManager Instance
	{
		get
		{
			if ((Object)(object)_Instance == (Object)null)
			{
				_Instance = new BiliBiliEventManager();
			}
			return _Instance;
		}
	}

	public void InvokeAction(BiliBiliEventType eventType)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 8)
		{
			((MonoBehaviour)HotUpdateProcess.Instance).StartCoroutine(WaitForIDFVAndIDFAThenDoCallback(delegate
			{
				SendEvent(eventType);
			}));
		}
		else
		{
			((MonoBehaviour)HotUpdateProcess.Instance).StartCoroutine(WaitForOAIDAndAndroidIdThenDoCallback(delegate
			{
				SendEvent(eventType);
			}));
		}
	}

	private static IEnumerator WaitForIOSUserAgentThenDoCallback(Action callback = null)
	{
		SentrySdk.AddBreadcrumb("[iOS BiliBili] WaitForIOSUserAgentThenDoCallback start");
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
			ILRuntimeDebug.LogError($"[iOS BiliBili]Get UA Failed, delayTotal={delayTotal}");
		}
		else
		{
			ILRuntimeDebug.LogError($"[iOS BiliBili]GetUA Success, delayTotal={delayTotal}, UA={BaseIOSSDK.UA}");
		}
		callback?.Invoke();
	}

	private static IEnumerator WaitForIDFVAndIDFAThenDoCallback(Action callback = null)
	{
		float delayTotal = 0f;
		while (string.IsNullOrEmpty(BaseIOSSDK.IDFV) || string.IsNullOrEmpty(OceanEngineEventManager.IDFA))
		{
			yield return (object)new WaitForSeconds(0.1f);
			delayTotal += 0.1f;
			if (delayTotal > 3f)
			{
				ILRuntimeDebug.LogError($"[iOS BiliBili] WaitForIDFV&IDFA Failed! delayTotal={delayTotal}, idfv={BaseIOSSDK.IDFV}, idfa={OceanEngineEventManager.IDFA}");
				yield break;
			}
		}
		yield return null;
		callback?.Invoke();
	}

	private static IEnumerator WaitForOAIDAndAndroidIdThenDoCallback(Action callback = null)
	{
		float delayTotal = 0f;
		while (string.IsNullOrEmpty(AndroidBasicPlugInManager.Instance.GetAndroidOAID()) && string.IsNullOrEmpty(AndroidBasicPlugInManager.Instance.GetAndroidID()))
		{
			yield return (object)new WaitForSeconds(0.1f);
			delayTotal += 0.1f;
			if (delayTotal > 3f)
			{
				ILRuntimeDebug.LogError($"[BiliBili] WaitForOAID&AndroidId Failed! delayTotal={delayTotal}");
				yield break;
			}
		}
		yield return null;
		callback?.Invoke();
	}

	private void SendEvent(BiliBiliEventType convType)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Invalid comparison between Unknown and I4
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Invalid comparison between Unknown and I4
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		BilibiliEventData eventData = new BilibiliEventData
		{
			IMEI = "",
			ConvertTime = DateTimeHelper.Now_Milliseconds,
			EventType = (int)convType,
			MatchType = 0,
			Ip = AndroidBasicPlugInManager.Instance.Ipv4Address,
			Model = SystemInfo.deviceModel,
			IosVersion = "",
			DeviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier,
			UserId = (GameController.Contexts.gameState.hasUser ? GameController.Contexts.gameState.user.value.UserId : 0)
		};
		if ((int)Application.platform == 8)
		{
			eventData.Os = 1;
			eventData.IDFV = BaseIOSSDK.IDFV;
			eventData.IDFA = OceanEngineEventManager.IDFA;
			if (string.IsNullOrEmpty(eventData.IDFA) && string.IsNullOrEmpty(eventData.IDFV))
			{
				ILRuntimeDebug.LogError($"BiliBili SendEvent {convType} With No IDFA & IDFV");
			}
			HotFixManager.GetUA().Then((Action<string>)delegate
			{
				((MonoBehaviour)HotUpdateProcess.Instance).StartCoroutine(WaitForIOSUserAgentThenDoCallback(delegate
				{
					//IL_001c: Unknown result type (might be due to invalid IL or missing references)
					//IL_0022: Expected O, but got Unknown
					//IL_003a: Unknown result type (might be due to invalid IL or missing references)
					//IL_0044: Expected O, but got Unknown
					//IL_0046: Unknown result type (might be due to invalid IL or missing references)
					//IL_0050: Expected O, but got Unknown
					eventData.Ua = BaseIOSSDK.UA;
					UnityWebRequest val2 = new UnityWebRequest("https://track.gubulin.com/api/BiliBiliData/submitresult", "POST");
					byte[] bytes2 = Encoding.UTF8.GetBytes(JsonHelper.ToJson(eventData));
					val2.uploadHandler = (UploadHandler)new UploadHandlerRaw(bytes2);
					val2.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
					val2.SetRequestHeader("Content-Type", "application/json");
					val2.SetRequestHeader("Accept", "application/json");
					val2.SendWebRequest();
					Debug.Log((object)("[BiliBiliEventManager] Bilibili iOS SendEvent " + JsonHelper.ToJson(eventData)));
				}));
			}).Catch((Action<Exception>)delegate(Exception ex)
			{
				ILRuntimeDebug.LogError("[BiliBiliEventManager] Bilibili iOS Register Get UA Error: " + ex.Message);
			});
		}
		else if ((int)Application.platform == 11)
		{
			eventData.Os = 0;
			eventData.Ua = AndroidBasicPlugInManager.Instance.GetAndroidUserAgent();
			eventData.OAID = AndroidBasicPlugInManager.Instance.GetAndroidOAID();
			eventData.ANDROID_ID = AndroidBasicPlugInManager.Instance.GetAndroidID();
			BiliBiliSDK biliBiliSDK = (BiliBiliSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.BiliBiliSDK];
			if (biliBiliSDK.IsLoggedIn)
			{
				eventData.AccountId = biliBiliSDK.UserProfile.uid;
			}
			if (string.IsNullOrEmpty(eventData.OAID) && string.IsNullOrEmpty(eventData.ANDROID_ID))
			{
				ILRuntimeDebug.LogError($"BiliBili SendEvent {convType} With No OAID & ANDROID_ID: {Environment.NewLine}{AndroidBasicPlugInManager.GetOAIDLogStacks}");
			}
			UnityWebRequest val = new UnityWebRequest("https://track.gubulin.com/api/BiliBiliData/submitresult", "POST");
			byte[] bytes = Encoding.UTF8.GetBytes(JsonHelper.ToJson(eventData));
			val.uploadHandler = (UploadHandler)new UploadHandlerRaw(bytes);
			val.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
			val.SetRequestHeader("Content-Type", "application/json");
			val.SetRequestHeader("Accept", "application/json");
			val.SendWebRequest();
			Debug.Log((object)("[BiliBiliEventManager] Bilibili SendEvent " + JsonHelper.ToJson(eventData)));
		}
	}
}
