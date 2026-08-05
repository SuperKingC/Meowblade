using System;
using System.Collections;
using FairyGUI;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Utils;

internal class EffectHelper
{
	public static Coroutine CoroutineDelay(float delaySeconds, Action onFinished)
	{
		return FGUIManager.Instance.OpenIEnumerator(Delay(delaySeconds, onFinished));
	}

	public static IEnumerator Delay(float delaySeconds, Action onFinished)
	{
		yield return (object)new WaitForSeconds(delaySeconds);
		onFinished();
	}

	public static Coroutine PlayCoroutineEffect(float totalEffecTime, Action<float, float> onUpdate, Action onFinished, float delayStartSeconds = 0f, float delayEndSeconds = 0f)
	{
		return FGUIManager.Instance.OpenIEnumerator(OnUpdateCoroutineEffect(totalEffecTime, onUpdate, onFinished, delayStartSeconds, delayEndSeconds));
	}

	private static IEnumerator OnUpdateCoroutineEffect(float totalEffecTime, Action<float, float> onUpdate, Action onFinished, float delayStartSeconds, float delayEndSeconds)
	{
		float effectTime = 0f;
		if (delayStartSeconds > 0f)
		{
			yield return (object)new WaitForSeconds(delayStartSeconds);
		}
		while (effectTime < totalEffecTime)
		{
			yield return (object)new WaitForFixedUpdate();
			effectTime += Time.deltaTime;
			if (effectTime > totalEffecTime)
			{
				effectTime = totalEffecTime;
			}
			onUpdate(effectTime, totalEffecTime);
		}
		if (delayEndSeconds > 0f)
		{
			yield return (object)new WaitForSeconds(delayEndSeconds);
		}
		onFinished();
	}

	public static Vector2 WorldToFguiPos(Vector3 worldPos)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = Camera.main.WorldToScreenPoint(worldPos);
		val.y = (float)Screen.height - val.y;
		return ((GObject)GRoot.inst).GlobalToLocal(Vector2.op_Implicit(val));
	}
}
