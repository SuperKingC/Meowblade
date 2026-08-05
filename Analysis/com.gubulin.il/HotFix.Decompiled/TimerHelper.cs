using System;
using System.Collections;
using UnityEngine;

public static class TimerHelper
{
	public static Coroutine CallNextFrame(Action callback, int skipFrames = 1)
	{
		return ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(NextFrame());
		IEnumerator NextFrame()
		{
			int i = 0;
			while (i < skipFrames)
			{
				yield return null;
				int num = i + 1;
				i = num;
			}
			callback();
		}
	}
}
