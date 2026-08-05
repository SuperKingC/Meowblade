using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GvG2.Common.Models;

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
			CoroutineHandler = ParentMonoBehaviour.StartCoroutine(MainCoroutine());
		}
	}

	public void Clear()
	{
		CoQueue.Clear();
		if (CoroutineHandler != null)
		{
			ParentMonoBehaviour.StopCoroutine(CoroutineHandler);
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
