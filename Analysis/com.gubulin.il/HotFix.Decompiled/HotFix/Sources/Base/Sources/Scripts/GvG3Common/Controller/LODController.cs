using System;
using System.Collections.Generic;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Controller;

internal class LODController<T> where T : Enum
{
	private T Level;

	private Dictionary<T, HashSet<GameObject>> LOD;

	public T CurLevel
	{
		get
		{
			return Level;
		}
		set
		{
			SwitchLevel(value);
		}
	}

	public LODController()
	{
		LOD = new Dictionary<T, HashSet<GameObject>>();
		foreach (T value in Enum.GetValues(typeof(T)))
		{
			LOD.Add(value, new HashSet<GameObject>());
		}
	}

	public void AddToLevel(T level, GameObject go)
	{
		LOD[level].Add(go);
		bool active = LOD[Level].Contains(go);
		go.SetActive(active);
	}

	public void AddToLevel(T level, Transform trans)
	{
		AddToLevel(level, ((Component)trans).gameObject);
	}

	private void SwitchLevel(T curLodLevel)
	{
		if (object.Equals(Level, curLodLevel))
		{
			return;
		}
		foreach (GameObject item in LOD[Level])
		{
			item.SetActive(false);
		}
		foreach (GameObject item2 in LOD[curLodLevel])
		{
			item2.SetActive(true);
		}
		Level = curLodLevel;
	}

	public HashSet<GameObject> GetLevelGameObject(T level)
	{
		return LOD[level];
	}

	public void Clear()
	{
		LOD.Clear();
	}
}
