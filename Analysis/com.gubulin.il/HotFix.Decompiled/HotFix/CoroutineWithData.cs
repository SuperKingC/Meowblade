using System.Collections;
using UnityEngine;

namespace HotFix;

public class CoroutineWithData
{
	public object Result;

	private IEnumerator target;

	private readonly MonoBehaviour Owner;

	public Coroutine Coroutine { get; private set; }

	public CoroutineWithData(MonoBehaviour owner, IEnumerator target)
	{
		Owner = owner;
		this.target = target;
		Coroutine = Owner.StartCoroutine(Run());
	}

	public void Stop()
	{
		Owner.StopCoroutine(Coroutine);
	}

	private IEnumerator Run()
	{
		while (target.MoveNext())
		{
			Result = target.Current;
			yield return Result;
		}
	}
}
