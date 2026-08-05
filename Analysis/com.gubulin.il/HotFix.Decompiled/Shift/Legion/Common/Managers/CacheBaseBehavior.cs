using System.Collections;
using UnityEngine;

namespace Shift.Legion.Common.Managers;

public abstract class CacheBaseBehavior
{
	public string Name;

	public bool IsUpdateEnabled = true;

	public float TimeInterval = 0f;

	private float _NextUpdateTime = 0f;

	public float DelayUpdateFromNow
	{
		set
		{
			_NextUpdateTime = Time.time + value;
		}
	}

	public void BaseInit()
	{
		IsUpdateEnabled = true;
		TimeInterval = 0f;
		_NextUpdateTime = 0f;
	}

	public virtual IEnumerator Init()
	{
		yield return null;
	}

	public void ForceUpdate()
	{
		DeferredUpdate();
		_NextUpdateTime = Time.time + TimeInterval;
	}

	public bool CheckUpdate()
	{
		if (!IsUpdateEnabled)
		{
			return false;
		}
		if (_NextUpdateTime < Time.time)
		{
			DeferredUpdate();
			_NextUpdateTime = Time.time + TimeInterval;
			return true;
		}
		return false;
	}

	public virtual void DeferredUpdate()
	{
	}

	public virtual void OnAllCachesInit()
	{
	}
}
