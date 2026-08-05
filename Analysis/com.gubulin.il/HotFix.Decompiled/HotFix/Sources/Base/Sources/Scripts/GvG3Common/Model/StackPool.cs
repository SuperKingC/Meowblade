using System;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

public class StackPool<T>
{
	private int curPoolSize;

	private T[] pool;

	private Func<T> CreateIntance;

	private Action<T> OnGetIntance;

	private Action<T> DestroyInstance;

	private Action<T> ReleaseInstance;

	private readonly bool logWarning;

	public StackPool(int maxPoolSize, Func<T> onCreate, Action<T> onGet, Action<T> onRelease, Action<T> onDestroy, bool logWarning = false)
	{
		if (onCreate == null)
		{
			Debug.LogError((object)("[ObjectPool<" + typeof(T).Name + ">] onCreate cannot be null"));
		}
		if (onGet == null)
		{
			Debug.LogError((object)("[ObjectPool<" + typeof(T).Name + ">] onGet cannot be null"));
		}
		if (onRelease == null)
		{
			Debug.LogError((object)("[ObjectPool<" + typeof(T).Name + ">] onRelease cannot be null"));
		}
		if (onDestroy == null)
		{
			Debug.LogError((object)("[ObjectPool<" + typeof(T).Name + ">] onDestroy cannot be null"));
		}
		CreateIntance = onCreate;
		OnGetIntance = onGet;
		ReleaseInstance = onRelease;
		DestroyInstance = onDestroy;
		pool = new T[maxPoolSize];
		curPoolSize = 0;
		this.logWarning = logWarning;
	}

	private void Push(T obj)
	{
		pool[curPoolSize++] = obj;
	}

	private T Pop()
	{
		return pool[--curPoolSize];
	}

	private T TryCreate()
	{
		T result = default(T);
		try
		{
			result = CreateIntance();
			return result;
		}
		catch (Exception ex)
		{
			Debug.LogWarning((object)("[ObjectPool<" + typeof(T).Name + ">] fail to create instance"));
			Debug.LogError((object)ex);
		}
		return result;
	}

	private void TryDestroy(T obj)
	{
		try
		{
			DestroyInstance(obj);
		}
		catch (Exception ex)
		{
			Debug.LogWarning((object)("[ObjectPool<" + typeof(T).Name + ">] fail to destroy instance"));
			Debug.LogError((object)ex);
		}
	}

	public T Get()
	{
		if (curPoolSize == 0)
		{
			return TryCreate();
		}
		T val = Pop();
		OnGetIntance(val);
		return val;
	}

	public void Release(T obj)
	{
		if (curPoolSize >= pool.Length)
		{
			if (logWarning)
			{
				Debug.LogWarning((object)("[ObjectPool<" + typeof(T).Name + ">] not enough space, try increase the pool size"));
			}
			TryDestroy(obj);
		}
		else
		{
			ReleaseInstance(obj);
			Push(obj);
		}
	}

	public void Clear()
	{
		for (int i = 0; i < curPoolSize; i++)
		{
			TryDestroy(pool[i]);
		}
	}
}
