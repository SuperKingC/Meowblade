using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shift.Legion.Common.Managers;

public class CacheManager : MonoBehaviour
{
	private static CacheManager _Instance;

	private Dictionary<Type, object> _CachesDict;

	private List<CacheBaseBehavior> _CacheList;

	private int _UpdateIndex;

	public static CacheManager Instance => _Instance;

	public Dictionary<Type, object> CacheToRegister()
	{
		Dictionary<Type, object> dictionary = new Dictionary<Type, object>();
		dictionary.Add(typeof(Cache_WarOrderState), new Cache_WarOrderState());
		dictionary.Add(typeof(Cache_OrcActivityRedDot), new Cache_OrcActivityRedDot());
		dictionary.Add(typeof(Cache_WarOrderScore), new Cache_WarOrderScore());
		dictionary.Add(typeof(Cache_SoldierFormationData), new Cache_SoldierFormationData());
		dictionary.Add(typeof(Cache_LevelActivityData), new Cache_LevelActivityData());
		dictionary.Add(typeof(Cache_StoreContentConfigData), new Cache_StoreContentConfigData());
		dictionary.Add(typeof(Cache_PrinceRedDot), new Cache_PrinceRedDot());
		dictionary.Add(typeof(Cache_NoviceRechargeRedDot), new Cache_NoviceRechargeRedDot());
		dictionary.Add(typeof(Cache_BlackMarketTreasureRedDot), new Cache_BlackMarketTreasureRedDot());
		dictionary.Add(typeof(Cache_DeparturePresentRedDot), new Cache_DeparturePresentRedDot());
		dictionary.Add(typeof(Cache_CertificationRedDot), new Cache_CertificationRedDot());
		dictionary.Add(typeof(Cache_IslandComeAgainDailyMissionRedDot), new Cache_IslandComeAgainDailyMissionRedDot());
		dictionary.Add(typeof(Cache_RecallWelfare_RedDot), new Cache_RecallWelfare_RedDot());
		return dictionary;
	}

	private void Awake()
	{
		if (!((Object)(object)_Instance != (Object)null))
		{
			_UpdateIndex = 0;
			_CachesDict = CacheToRegister();
			_CacheList = new List<CacheBaseBehavior>();
			_Instance = this;
		}
	}

	private IEnumerator InitCoroutine()
	{
		foreach (KeyValuePair<Type, object> item in _CachesDict)
		{
			CacheBaseBehavior cache = (CacheBaseBehavior)item.Value;
			cache.Name = item.Key.Name;
			cache.BaseInit();
			yield return cache.Init();
			_CacheList.Add(cache);
			yield return null;
		}
		foreach (CacheBaseBehavior cache2 in _CacheList)
		{
			cache2.OnAllCachesInit();
		}
	}

	public void Init()
	{
		((MonoBehaviour)this).StartCoroutine(InitCoroutine());
	}

	private void Update()
	{
		if (_CacheList.Count != 0)
		{
			int num = 0;
			while (!_CacheList[_UpdateIndex].CheckUpdate() && ++num < _CacheList.Count)
			{
				_UpdateIndex = (_UpdateIndex + 1) % _CacheList.Count;
			}
			_UpdateIndex = (_UpdateIndex + 1) % _CacheList.Count;
		}
	}

	public T Get<T>()
	{
		Type typeFromHandle = typeof(T);
		if (_CachesDict.ContainsKey(typeFromHandle))
		{
			return (T)_CachesDict[typeFromHandle];
		}
		return default(T);
	}
}
