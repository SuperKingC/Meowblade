using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Assets.Scripts.UI;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.ClientApi;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.Networking;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;

public static class GvG3ProfileHelper
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct Constants
	{
		public const string CACHE_KEY = "GvG3ProfileCache";

		public const int AVATAR_132 = 132;

		public const int AVATAR_450 = 450;
	}

	private static GvG3UserProfileRequestHelper _profileRequestHelper;

	private static CoroutineQueue _profileCoroutineQueue;

	private static CoroutineQueue _avatarCoroutineQueue;

	private static readonly Dictionary<int, GvGMode3ProfileModel> _userProfiles = new Dictionary<int, GvGMode3ProfileModel>();

	private static readonly List<GvG3UserProfileRequestOptions> _waitHandleCallbacks = new List<GvG3UserProfileRequestOptions>();

	private static readonly Dictionary<int, Sprite> _user132Sprites = new Dictionary<int, Sprite>();

	public static readonly string DefaultAvatarUrl = "ui://PublicResources/Clap1";

	private static UserProfileCacheKeys _cacheKeys;

	public static UserProfile TryGetUserProfile(int userId)
	{
		GvGMode3ProfileModel value = null;
		_userProfiles?.TryGetValue(userId, out value);
		return value?.Profile;
	}

	public static void GetUserProfile(GvG3UserProfileRequestOptions profileRequestOptions)
	{
		if (_userProfiles.TryGetValue(profileRequestOptions.UserId, out var value))
		{
			profileRequestOptions.InvokeGetUserProfileCallback(value);
			return;
		}
		InitProfileRequestHelper();
		InitProfileCoroutineQueueAndAdd(GetUserProfileCoroutine(profileRequestOptions));
	}

	private static void InitProfileCoroutineQueueAndAdd(IEnumerator enumerator)
	{
		if (_profileCoroutineQueue == null)
		{
			_profileCoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)FGUIManager.Instance);
		}
		_profileCoroutineQueue.AddCoroutine(enumerator);
	}

	private static void InitAvatarCoroutineQueueAndAdd(IEnumerator enumerator)
	{
		if (_avatarCoroutineQueue == null)
		{
			_avatarCoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)FGUIManager.Instance);
		}
		_avatarCoroutineQueue.AddCoroutine(enumerator);
	}

	private static void InitProfileRequestHelper()
	{
		if (_profileRequestHelper == null)
		{
			_profileRequestHelper = new GvG3UserProfileRequestHelper(RemoveUserProfileRequestCallbacks);
		}
	}

	private static void InvokeGetUserProfileCallback(this GvG3UserProfileRequestOptions profileRequestOptions, GvGMode3ProfileModel profileModel)
	{
		string izStr = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId}_{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}";
		profileRequestOptions.GetProfileCallback?.Invoke(profileModel.Profile);
		profileRequestOptions.InvokeGetAvatar132Callback(profileModel, izStr);
	}

	private static void InvokeGetAvatar132Callback(this GvG3UserProfileRequestOptions profileRequestOptions, GvGMode3ProfileModel profile, string izStr)
	{
		if (profileRequestOptions.GetAvatar132Callback != null)
		{
			if (_user132Sprites.TryGetValue(profile.UserId, out var value))
			{
				profileRequestOptions.GetAvatar132Callback?.Invoke(value);
			}
			else
			{
				InitAvatarCoroutineQueueAndAdd(GetUserAvatar132(izStr, profileRequestOptions, profile));
			}
		}
	}

	private static IEnumerator GetUserProfileCoroutine(GvG3UserProfileRequestOptions profileRequestOptions)
	{
		if (_userProfiles.TryGetValue(profileRequestOptions.UserId, out var profile))
		{
			yield return InvokeCallback(profile, profileRequestOptions);
			yield break;
		}
		yield return InitCache();
		TryClearCache(profileRequestOptions.CacheVersion);
		string profileJson = TryGetProfileJson(profileRequestOptions.UserId);
		if (string.IsNullOrEmpty(profileJson))
		{
			RequestProfileAndRecordCallback(profileRequestOptions);
		}
		else
		{
			yield return DeserializeProfileAndInvokeCallback(profileJson, profileRequestOptions);
		}
	}

	private static IEnumerator InitCache()
	{
		if (_cacheKeys == null)
		{
			string json = PlayerPrefs.GetString("GvG3ProfileCache");
			_cacheKeys = ((!string.IsNullOrWhiteSpace(json)) ? JsonHelper.ToObject<UserProfileCacheKeys>(json) : new UserProfileCacheKeys
			{
				CacheVersion = string.Empty,
				ProfileCacheKeys = new List<string>(),
				Avatar132CacheKeys = new List<string>()
			});
			yield return null;
		}
	}

	private static void RequestProfileAndRecordCallback(GvG3UserProfileRequestOptions profileRequestOptions)
	{
		_waitHandleCallbacks.Add(profileRequestOptions);
		_profileRequestHelper.GetProfileData(profileRequestOptions.UserId);
	}

	private static IEnumerator DeserializeProfileAndInvokeCallback(string profileJson, GvG3UserProfileRequestOptions profileRequestOptions)
	{
		GvGMode3ProfileModel profile = JsonHelper.ToObject<GvGMode3ProfileModel>(profileJson);
		TryUpdateUserProfiles(profile, profileRequestOptions.UserId);
		yield return InvokeCallback(profile, profileRequestOptions);
	}

	private static IEnumerator GetUserAvatar132(string izStr, GvG3UserProfileRequestOptions profileRequestOptions, GvGMode3ProfileModel profile)
	{
		int userId = profileRequestOptions.UserId;
		string pngPath = TryGetAvatar132PngPath(userId);
		if (string.IsNullOrEmpty(pngPath))
		{
			yield return DownloadAvatar(izStr, userId);
		}
		yield return TryGetAvatarTextures(profile, userId.ToString());
		if (_user132Sprites.TryGetValue(profile.UserId, out var sprite132))
		{
			profileRequestOptions.GetAvatar132Callback?.Invoke(sprite132);
			yield return null;
		}
	}

	private static IEnumerator TryGetAvatarTextures(GvGMode3ProfileModel profile, string userId)
	{
		if (profile != null)
		{
			yield return GetAvatarTexture2D(profile, userId, 132);
		}
	}

	private static IEnumerator GetAvatarTexture2D(GvGMode3ProfileModel profile, string userId, int size)
	{
		if (!_user132Sprites.ContainsKey(profile.UserId))
		{
			CoroutineWithData cd = new CoroutineWithData(target: HotFix_Utils.getTextureByPath(UiHelper.GetGvG3UserAvatarLocalPath(userId, size.ToString())), owner: (MonoBehaviour)(object)FGUIManager.Instance);
			yield return cd.Coroutine;
			Texture2D tex = new Texture2D(size, size);
			if (cd.Result != null)
			{
				tex = (Texture2D)cd.Result;
			}
			Sprite sprite = Sprite.Create(tex, new Rect(0f, 0f, (float)((Texture)tex).width, (float)((Texture)tex).height), new Vector2(0.5f, 0.5f), 100f, 1u, (SpriteMeshType)0);
			_user132Sprites[profile.UserId] = sprite;
			yield return null;
		}
	}

	private static IEnumerator DownloadAvatar(string izStr, int userId)
	{
		string avatarUrl = GetGvG3Avatar132HttpUrl(izStr, userId);
		UnityWebRequest request = UnityWebRequest.Get(avatarUrl);
		try
		{
			request.timeout = 3;
			yield return request.SendWebRequest();
			if (request.isNetworkError || request.isHttpError || !request.isDone || request.downloadHandler.data == null)
			{
				yield break;
			}
			UserProfileAvatar deserialize = request.downloadHandler.data.Deserialize<UserProfileAvatar>();
			string userIdStr = userId.ToString();
			string pngPath = UiHelper.GetGvG3UserAvatarLocalPath(userIdStr, 132.ToString());
			yield return WriteAvatarBytes(userIdStr, 132, deserialize.AvatarData);
			SaveAvatar132ChangeCache(userId, pngPath);
			yield return null;
		}
		finally
		{
			((IDisposable)request)?.Dispose();
		}
	}

	private static string GetGvG3Avatar132HttpUrl(string izStr, int userId)
	{
		string value;
		string text = (HotUpdateProcess.Instance.Configs.TryGetValue("GvGMode3Log", out value) ? value : "https://skyisland.gubulin.com");
		return $"{text}/GvGMode3Avatar/{GameDataService.Instance.EnvStr}/{izStr}/UserProfile132_{userId}.bytes";
	}

	private static IEnumerator WriteAvatarBytes(string userIdText, int size, byte[] avatarBytes)
	{
		if (avatarBytes != null && avatarBytes.Length != 0)
		{
			string localPath = UiHelper.GetGvG3UserAvatarLocalPath(userIdText, size.ToString());
			File.WriteAllBytes(localPath, avatarBytes);
			yield return null;
		}
	}

	private static void RemoveUserProfileRequestCallbacks(List<GvGMode3ProfileModel> profiles)
	{
		foreach (GvGMode3ProfileModel profile in profiles)
		{
			_waitHandleCallbacks.RemoveAll((GvG3UserProfileRequestOptions callback) => FindAndHandleCallback(profile, callback));
		}
	}

	private static bool FindAndHandleCallback(GvGMode3ProfileModel profile, GvG3UserProfileRequestOptions option)
	{
		if (profile == null)
		{
			return false;
		}
		if (profile.UserId != option.UserId)
		{
			return false;
		}
		IEnumerator enumerator = RequestProfileCallback(profile, option);
		InitProfileCoroutineQueueAndAdd(enumerator);
		return true;
	}

	private static IEnumerator RequestProfileCallback(GvGMode3ProfileModel profile, GvG3UserProfileRequestOptions profileRequestOptions)
	{
		yield return SaveProfileChangeCache(profile, profileRequestOptions.UserId);
		TryUpdateUserProfiles(profile, profileRequestOptions.UserId);
		yield return InvokeCallback(profile, profileRequestOptions);
	}

	private static IEnumerator SaveProfileChangeCache(GvGMode3ProfileModel profile, int userId)
	{
		SaveProfileChangeCache(userId, profile);
		yield return null;
	}

	private static void TryUpdateUserProfiles(GvGMode3ProfileModel profile, int userId)
	{
		if (profile != null)
		{
			_userProfiles[userId] = profile;
		}
	}

	private static IEnumerator InvokeCallback(GvGMode3ProfileModel profile, GvG3UserProfileRequestOptions profileRequestOptions)
	{
		if (profile != null)
		{
			profileRequestOptions.InvokeGetUserProfileCallback(profile);
			yield return null;
		}
	}

	public static void TryClearCache(string newCacheVersion)
	{
		if (_cacheKeys.CacheVersion == newCacheVersion)
		{
			return;
		}
		_cacheKeys.CacheVersion = newCacheVersion;
		foreach (string profileCacheKey in _cacheKeys.ProfileCacheKeys)
		{
			PlayerPrefs.DeleteKey(profileCacheKey);
		}
		_cacheKeys.ProfileCacheKeys.Clear();
		foreach (string avatar132CacheKey in _cacheKeys.Avatar132CacheKeys)
		{
			PlayerPrefs.DeleteKey(avatar132CacheKey);
		}
		_cacheKeys.Avatar132CacheKeys.Clear();
	}

	public static void SaveProfileChangeCache(int userId, GvGMode3ProfileModel profile)
	{
		string profileChangeKey = GetProfileChangeKey(userId);
		PlayerPrefs.SetString(profileChangeKey, JsonHelper.ToJson(profile));
		if (!_cacheKeys.ProfileCacheKeys.Contains(profileChangeKey))
		{
			_cacheKeys.ProfileCacheKeys.Add(profileChangeKey);
			PlayerPrefs.SetString("GvG3ProfileCache", JsonHelper.ToJson(_cacheKeys));
		}
	}

	public static string TryGetProfileJson(int userId)
	{
		string profileChangeKey = GetProfileChangeKey(userId);
		return PlayerPrefs.GetString(profileChangeKey);
	}

	public static void SaveAvatar132ChangeCache(int userId, string pngPath)
	{
		string avatar132ChangeKey = GetAvatar132ChangeKey(userId);
		PlayerPrefs.SetString(avatar132ChangeKey, pngPath);
		if (!_cacheKeys.Avatar132CacheKeys.Contains(avatar132ChangeKey))
		{
			_cacheKeys.Avatar132CacheKeys.Add(avatar132ChangeKey);
			PlayerPrefs.SetString("GvG3ProfileCache", JsonHelper.ToJson(_cacheKeys));
		}
	}

	public static string TryGetAvatar132PngPath(int userId)
	{
		string avatar132ChangeKey = GetAvatar132ChangeKey(userId);
		return PlayerPrefs.GetString(avatar132ChangeKey);
	}

	private static string GetProfileChangeKey(int userId)
	{
		return $"GVG3_PROFILE_CACHE_{userId}";
	}

	private static string GetAvatar132ChangeKey(int userId)
	{
		return $"GVG3_AVATAR132_CACHE_{userId}";
	}
}
