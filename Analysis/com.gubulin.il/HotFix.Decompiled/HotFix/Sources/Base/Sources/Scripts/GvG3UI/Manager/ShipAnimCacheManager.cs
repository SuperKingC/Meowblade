using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Spine.Unity;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;

public class ShipAnimCacheManager
{
	private Dictionary<string, ShipAnimCache> Caches;

	public ShipAnimCacheManager()
	{
		Caches = new Dictionary<string, ShipAnimCache>();
	}

	public void ClearCache()
	{
		foreach (KeyValuePair<string, ShipAnimCache> cache in Caches)
		{
			if ((Object)(object)cache.Value?.SpineGameObject != (Object)null)
			{
				Object.Destroy((Object)(object)cache.Value.SpineGameObject);
			}
		}
		Caches.Clear();
	}

	public GameObject GetCache(string instanceId, int skinId, Action<SkeletonAnimation> onLoaded = null, bool isMask = false, bool isSimpleSpine = false, Action<SkeletonAnimation> onGetAnim = null)
	{
		if (!Caches.TryGetValue(instanceId, out var cache))
		{
			cache = new ShipAnimCache
			{
				TargetId = instanceId,
				SkinId = int.MinValue,
				SpineGameObject = null,
				Animation = null
			};
			Caches.Add(instanceId, cache);
		}
		if (cache.SkinId != skinId)
		{
			cache.SkinId = skinId;
			if ((Object)(object)cache.SpineGameObject != (Object)null)
			{
				Object.Destroy((Object)(object)cache.SpineGameObject);
			}
			string name = (isSimpleSpine ? ShipConfigHelper.GetSkinById(skinId).SimpleSpine : ShipConfigHelper.GetSkinById(skinId).Spine);
			cache.SpineGameObject = UiHelper.LoadSpine_AB(name, 100f, delegate(SkeletonAnimation animation)
			{
				onLoaded?.Invoke(animation);
				cache.Animation = animation;
			}, isMask);
		}
		else if ((Object)(object)cache.Animation != (Object)null)
		{
			onGetAnim?.Invoke(cache.Animation);
		}
		return cache.SpineGameObject;
	}

	public GameObject GetCache(string instanceId, string spineName, Action<SkeletonAnimation> onLoaded = null, bool isMask = false, Action<SkeletonAnimation> onGetAnim = null)
	{
		if (!Caches.TryGetValue(instanceId, out var cache))
		{
			cache = new ShipAnimCache
			{
				TargetId = instanceId,
				SpineName = null,
				SpineGameObject = null
			};
			Caches.Add(instanceId, cache);
		}
		if (cache.SpineName != spineName)
		{
			cache.SpineName = spineName;
			if ((Object)(object)cache.SpineGameObject != (Object)null)
			{
				Object.Destroy((Object)(object)cache.SpineGameObject);
			}
			cache.SpineGameObject = UiHelper.LoadSpine_AB(spineName, 100f, delegate(SkeletonAnimation animation)
			{
				onLoaded?.Invoke(animation);
				cache.Animation = animation;
			}, isMask);
		}
		else if ((Object)(object)cache.Animation != (Object)null)
		{
			onGetAnim?.Invoke(cache.Animation);
		}
		return cache.SpineGameObject;
	}

	public void ReleaseCache(string instanceId)
	{
		if (Caches.TryGetValue(instanceId, out var value))
		{
			Object.Destroy((Object)(object)value.SpineGameObject);
			Caches.Remove(instanceId);
		}
	}
}
