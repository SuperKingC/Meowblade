using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shift.Legion.GvG.Common;

public class CoroutineQueue
{
	private MonoBehaviour ParentMonoBehaviour;

	private Coroutine CoroutineHandler;

	private readonly Queue<IEnumerator> CoQueue;

	public int Count => CoQueue.Count;

	public CoroutineQueue()
	{
		ParentMonoBehaviour = (MonoBehaviour)(object)FGUIManager.Instance;
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
