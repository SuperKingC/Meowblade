using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.UI;
using GvG2.Common.Models;
using HotFix;
using Shift.Legion.ClientApi;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.Networking;

namespace GvG2;

internal static class AvatarHelper
{
	private class Cache
	{
		public string CacheVersion { get; set; }

		public List<string> UserCacheKeys { get; set; }
	}

	private const string CACHE_KEY = "AvatarHelperCache";

	private static Cache _Cache;

	private static Dictionary<int, Sprite> UserSprites;

	private static CoroutineQueue CoroutineQueue;

	public static void GetUserAvatarSprite(string cacheVersion, int userId, Action<Sprite> callback)
	{
		if (UserSprites == null)
		{
			UserSprites = new Dictionary<int, Sprite>();
		}
		if (UserSprites.TryGetValue(userId, out var value) && callback != null)
		{
			callback(value);
			return;
		}
		if (CoroutineQueue == null)
		{
			CoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)FGUIManager.Instance);
		}
		CoroutineQueue.AddCoroutine(GetUserAvatarSpriteCoroutine(cacheVersion, userId, callback));
	}

	public static void StopRquesting()
	{
		CoroutineQueue?.Clear();
	}

	private static IEnumerator GetUserAvatarSpriteCoroutine(string cacheVersion, int userId, Action<Sprite> callback)
	{
		if (!UserSprites.TryGetValue(userId, out var sprite))
		{
			sprite = null;
			if (_Cache == null)
			{
				string json = PlayerPrefs.GetString("AvatarHelperCache");
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
			string avatarKey = $"AVATAR_CACHE_{userId}";
			string png_path = PlayerPrefs.GetString(avatarKey);
			if (string.IsNullOrEmpty(png_path))
			{
				string avatar_url = UiHelper.GetUserAvatarHttpsUrl(userId);
				UnityWebRequest uwr_avatar = UnityWebRequest.Get(avatar_url);
				try
				{
					uwr_avatar.timeout = 3;
					yield return uwr_avatar.SendWebRequest();
					if (!uwr_avatar.isNetworkError && !uwr_avatar.isHttpError && uwr_avatar.isDone && uwr_avatar.downloadHandler.data != null)
					{
						UserProfileAvatar userProfile_avatar = uwr_avatar.downloadHandler.data.Deserialize<UserProfileAvatar>();
						png_path = UiHelper.GetUserAvatarLocalPath(userId.ToString());
						File.WriteAllBytes(png_path, userProfile_avatar.AvatarData);
						PlayerPrefs.SetString(avatarKey, png_path);
						_Cache.UserCacheKeys.Add(avatarKey);
						yield return null;
					}
				}
				finally
				{
					((IDisposable)uwr_avatar)?.Dispose();
				}
			}
			if (!string.IsNullOrEmpty(png_path))
			{
				CoroutineWithData cd = new CoroutineWithData((MonoBehaviour)(object)FGUIManager.Instance, HotFix_Utils.getTextureByPath(png_path));
				yield return cd.Coroutine;
				Texture2D tex = new Texture2D(132, 132);
				if (cd.Result != null)
				{
					tex = (Texture2D)cd.Result;
				}
				sprite = Sprite.Create(tex, new Rect(0f, 0f, (float)((Texture)tex).width, (float)((Texture)tex).height), new Vector2(0.5f, 0.5f), 100f, 1u, (SpriteMeshType)0);
				UserSprites.Add(userId, sprite);
				SaveCache();
				yield return null;
			}
		}
		if ((Object)(object)sprite != (Object)null && callback != null)
		{
			callback(sprite);
		}
	}

	public static void SaveCache()
	{
		if (_Cache != null && _Cache.UserCacheKeys != null && _Cache.UserCacheKeys.Count != 0)
		{
			PlayerPrefs.SetString("AvatarHelperCache", JsonHelper.ToJson(_Cache));
		}
	}
}
