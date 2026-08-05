using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

public class CoroutineQueue
{
	private MonoBehaviour ParentMonoBehaviour;

	private Coroutine CoroutineHandler;

	private readonly Queue<IEnumerator> CoQueue;

	public int Count => CoQueue.Count;

	public CoroutineQueue()
	{
		CoQueue = new Queue<IEnumerator>();
	}

	public CoroutineQueue(MonoBehaviour mono)
	{
		ParentMonoBehaviour = mono;
		CoQueue = new Queue<IEnumerator>();
	}

	public void AddCoroutine(IEnumerator co)
	{
		CoQueue.Enqueue(co);
		if (CoroutineHandler == null)
		{
			if (!((Component)ParentMonoBehaviour).gameObject.activeInHierarchy)
			{
				SentrySdk.AddBreadcrumb("[CoroutineQueue] ParentMonoBehaviour is inactive, name=" + ((Object)((Component)ParentMonoBehaviour).gameObject).name);
			}
			CoroutineHandler = ParentMonoBehaviour.StartCoroutine(MainCoroutine());
		}
	}

	public void Clear()
	{
		CoQueue.Clear();
		if (CoroutineHandler != null)
		{
			ParentMonoBehaviour.StopCoroutine(CoroutineHandler);
			CoroutineHandler = null;
		}
	}

	private IEnumerator MainCoroutine()
	{
		while (CoQueue.Count > 0)
		{
			yield return CoQueue.Dequeue();
		}
		CoroutineHandler = null;
	}
}
