using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using GvG2.Common.Models;
using Shift.Legion.ClientApi;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.Networking;

namespace GvG2;

internal static class ProfileHelper
{
	private class Cache
	{
		public string CacheVersion { get; set; }

		public List<string> UserCacheKeys { get; set; }
	}

	private const string CACHE_KEY = "ProfileHelperCache";

	private static Cache _Cache;

	private static Dictionary<int, UserProfile> UserProfiles;

	private static CoroutineQueue CoroutineQueue;

	public static void GetUserProfile(string cacheVersion, int userId, Action<UserProfile> callback)
	{
		if (UserProfiles == null)
		{
			UserProfiles = new Dictionary<int, UserProfile>();
		}
		if (UserProfiles.TryGetValue(userId, out var value) && callback != null)
		{
			callback(value);
			return;
		}
		if (CoroutineQueue == null)
		{
			CoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)FGUIManager.Instance);
		}
		CoroutineQueue.AddCoroutine(GetUserProfileCoroutine(cacheVersion, userId, callback));
	}

	public static void StopRquesting()
	{
		CoroutineQueue?.Clear();
	}

	private static IEnumerator GetUserProfileCoroutine(string cacheVersion, int userId, Action<UserProfile> callback)
	{
		if (!UserProfiles.TryGetValue(userId, out var profile))
		{
			profile = null;
			if (_Cache == null)
			{
				string json = PlayerPrefs.GetString("ProfileHelperCache");
				if (!string.IsNullOrWhiteSpace(json))
				{
					_Cache = JsonHelper.ToObject<Cache>(json);
					yield return null;
				}
				else
				{
					_Cache = new Cache
					{
						CacheVersion = "",
						UserCacheKeys = new List<string>()
					};
				}
			}
			if (cacheVersion != _Cache.CacheVersion)
			{
				_Cache.CacheVersion = cacheVersion;
				foreach (string key in _Cache.UserCacheKeys)
				{
					PlayerPrefs.DeleteKey(key);
				}
				_Cache.UserCacheKeys.Clear();
			}
			string profileKey = $"PROFILE_CACHE_{userId}";
			string profileJson = PlayerPrefs.GetString(profileKey);
			if (string.IsNullOrEmpty(profileJson))
			{
				string profile_url = UiHelper.GetUserProfileHttpsUrl(userId);
				UnityWebRequest uwr_profile = UnityWebRequest.Get(profile_url);
				try
				{
					uwr_profile.timeout = 3;
					yield return uwr_profile.SendWebRequest();
					if (!uwr_profile.isNetworkError && !uwr_profile.isHttpError && uwr_profile.isDone)
					{
						profile = uwr_profile.downloadHandler.data.Deserialize<UserProfile>();
						if (profile != null)
						{
							PlayerPrefs.SetString(profileKey, JsonHelper.ToJson(profile));
							_Cache.UserCacheKeys.Add(profileKey);
						}
					}
				}
				finally
				{
					((IDisposable)uwr_profile)?.Dispose();
				}
			}
			else
			{
				profile = JsonHelper.ToObject<UserProfile>(profileJson);
			}
			if (profile != null)
			{
				UserProfiles.Add(userId, profile);
				SaveCache();
				yield return null;
			}
		}
		if (profile != null && callback != null)
		{
			callback(profile);
		}
	}

	public static void SaveCache()
	{
		if (_Cache != null && _Cache.UserCacheKeys != null && _Cache.UserCacheKeys.Count != 0)
		{
			PlayerPrefs.SetString("ProfileHelperCache", JsonHelper.ToJson(_Cache));
		}
	}
}
