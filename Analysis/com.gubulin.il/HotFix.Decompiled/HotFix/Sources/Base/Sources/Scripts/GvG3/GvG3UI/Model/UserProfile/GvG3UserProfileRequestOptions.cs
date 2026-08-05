using System;
using Shift.Legion.ClientApi.Protocol;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;

public class GvG3UserProfileRequestOptions
{
	public string CacheVersion { get; }

	public int UserId { get; }

	public Action<global::Shift.Legion.ClientApi.Protocol.UserProfile> GetProfileCallback { get; }

	public Action<Sprite> GetAvatar132Callback { get; }

	public GvG3UserProfileRequestOptions(string cacheVersion, int userId, Action<global::Shift.Legion.ClientApi.Protocol.UserProfile> getProfileCallback = null, Action<Sprite> getAvatar132Callback = null)
	{
		CacheVersion = cacheVersion;
		UserId = userId;
		GetProfileCallback = getProfileCallback;
		GetAvatar132Callback = getAvatar132Callback;
	}
}
