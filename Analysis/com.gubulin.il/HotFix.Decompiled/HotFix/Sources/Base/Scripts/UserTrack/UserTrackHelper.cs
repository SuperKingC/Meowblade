using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.Networking;

namespace HotFix.Sources.Base.Scripts.UserTrack;

public class UserTrackHelper : MonoBehaviour
{
	private class TrackData
	{
		public TrackDataPayload payload;

		public Action callback;
	}

	private class TrackDataPayload
	{
		public int msg_idx;

		public string identifier;

		public int account_id;

		public string device_id;

		public string os;

		public long timestamp_ms;

		public string event_name;

		public string properties;
	}

	public static UserTrackHelper Instance;

	private const string _identityCharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

	private string _authServerUrl;

	private Uri _baseAddress;

	private int _userId;

	private ConcurrentQueue<TrackData> _uploadQueue;

	private Coroutine _uploadCoroutine;

	private bool _startUploading;

	private int _trackLevel;

	private int _trackEventIdx;

	private string _identityKey;

	private static Dictionary<UserTrackEvent, UserTrackLevel> TrackLevelMap = new Dictionary<UserTrackEvent, UserTrackLevel>
	{
		{
			UserTrackEvent.PrivacyStatement,
			UserTrackLevel.level_5
		},
		{
			UserTrackEvent.SentryInit,
			UserTrackLevel.level_2
		},
		{
			UserTrackEvent.NeedForceUpdate,
			UserTrackLevel.level_2
		},
		{
			UserTrackEvent.FirstInstall,
			UserTrackLevel.level_5
		},
		{
			UserTrackEvent.FirstUnzipResult,
			UserTrackLevel.level_5
		},
		{
			UserTrackEvent.ShowPrivacy,
			UserTrackLevel.level_5
		},
		{
			UserTrackEvent.ResourcesDiff,
			UserTrackLevel.level_2
		},
		{
			UserTrackEvent.ResourcesUpdate,
			UserTrackLevel.level_2
		},
		{
			UserTrackEvent.CodeVersionDiff,
			UserTrackLevel.level_2
		},
		{
			UserTrackEvent.CodeVersionUpdate,
			UserTrackLevel.level_2
		},
		{
			UserTrackEvent.NeedHotUpdate,
			UserTrackLevel.level_2
		},
		{
			UserTrackEvent.HotUpdateResult,
			UserTrackLevel.level_2
		},
		{
			UserTrackEvent.BaseResourcesDoubleCheckSuccess,
			UserTrackLevel.level_2
		},
		{
			UserTrackEvent.BaseResourcesDoubleCheckFailed,
			UserTrackLevel.level_5
		},
		{
			UserTrackEvent.TrackAdvertisement,
			UserTrackLevel.level_4
		},
		{
			UserTrackEvent.RestartAfterHotUpdate,
			UserTrackLevel.level_2
		},
		{
			UserTrackEvent.InitGameAfterHotUpdate,
			UserTrackLevel.level_2
		},
		{
			UserTrackEvent.TrackUserFirstInstallAndRegist,
			UserTrackLevel.level_4
		}
	};

	private void Awake()
	{
		_authServerUrl = string.Empty;
		_baseAddress = null;
		_uploadQueue = new ConcurrentQueue<TrackData>();
		_userId = -1;
		_trackLevel = int.MaxValue;
		_trackEventIdx = 0;
		_startUploading = false;
		_uploadCoroutine = null;
		int millisecond = DateTimeHelper.Now.Millisecond;
		_identityKey = $"{millisecond:0000}";
		Random random = new Random();
		for (int i = 0; i < 4; i++)
		{
			_identityKey += "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"[random.Next(62)];
		}
		Instance = this;
	}

	private void Start()
	{
		StartSend();
	}

	private void Update()
	{
		if (_startUploading && _uploadCoroutine == null)
		{
			_uploadCoroutine = ((MonoBehaviour)this).StartCoroutine(_sendTrackEvent());
		}
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	public void SetTrackUrl(string url)
	{
		_authServerUrl = url;
		_baseAddress = new Uri(_authServerUrl);
	}

	public void SetUserId(int userId)
	{
		_userId = userId;
	}

	public void SetTrackLevel(UserTrackLevel level)
	{
		_trackLevel = (int)level;
	}

	public void TrackEvent(UserTrackEvent eventName, UserTrackData eventData = null, Action callback = null)
	{
		if (!TrackLevelMap.TryGetValue(eventName, out var value))
		{
			ILRuntimeDebug.LogError($"{eventName} find no trackLevel");
		}
		else if ((int)value >= _trackLevel)
		{
			_trackEvent(eventInfo: (eventData != null) ? JsonHelper.ToJson(eventData) : "{}", eventName: eventName.ToString(), callback: callback);
		}
	}

	private void _trackEvent(string eventName, string eventInfo, Action callback = null)
	{
		TrackData item = new TrackData
		{
			payload = new TrackDataPayload
			{
				msg_idx = _trackEventIdx++,
				identifier = _identityKey,
				device_id = SystemInfo.deviceUniqueIdentifier,
				account_id = _userId,
				os = SystemInfo.operatingSystem,
				timestamp_ms = DateTimeHelper.Now_Milliseconds,
				event_name = eventName,
				properties = eventInfo
			},
			callback = callback
		};
		_uploadQueue.Enqueue(item);
	}

	private IEnumerator _sendTrackEvent()
	{
		TrackData trackData;
		if (_uploadQueue.Count < 1)
		{
			yield return (object)new WaitForSeconds(1f);
		}
		else if (_uploadQueue.TryDequeue(out trackData))
		{
			string trackDataStr = JsonHelper.ToJson(trackData.payload);
			Action callback = trackData.callback;
			Uri uri = new Uri(_baseAddress?.ToString() + "trackevent");
			UnityWebRequest uwr = new UnityWebRequest(uri, "POST");
			try
			{
				uwr.SetRequestHeader("Content-Type", "application/json;charset=utf-8");
				uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(Encoding.UTF8.GetBytes(trackDataStr));
				uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
				yield return uwr.SendWebRequest();
			}
			finally
			{
				((IDisposable)uwr)?.Dispose();
			}
			callback?.Invoke();
			yield return (object)new WaitForEndOfFrame();
		}
		_uploadCoroutine = null;
	}

	public void StartSend()
	{
		if (_uploadCoroutine != null)
		{
			((MonoBehaviour)this).StopCoroutine(_uploadCoroutine);
		}
		_uploadCoroutine = null;
		_startUploading = true;
	}

	public void StopSend()
	{
		_startUploading = false;
		_uploadCoroutine = null;
	}
}
