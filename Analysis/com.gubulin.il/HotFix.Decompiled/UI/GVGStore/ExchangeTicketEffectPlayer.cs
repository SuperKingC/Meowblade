using FairyGUI;
using UnityEngine;

namespace UI.GVGStore;

public readonly struct ExchangeTicketEffectPlayer
{
	private readonly UI_com_Effect01 _effect01;

	private readonly Vector2 _endPos;

	public ExchangeTicketEffectPlayer(UI_com_Effect01 effect, Vector2 endPos)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		_effect01 = effect;
		_endPos = endPos;
	}

	public void Play()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		if (_effect01 != null)
		{
			Vector2 val = Vector2.op_Implicit(((GObject)_effect01).position) + Random.insideUnitCircle * 100f;
			ExchangeTicketEffectPlayer player = this;
			((GObject)_effect01).TweenMove(val, 0.2f).SetDelay(Random.Range(0f, 0.1f)).SetEase((EaseType)8)
				.OnComplete((GTweenCallback)delegate
				{
					player.ToEnd();
				});
		}
	}

	private void ToEnd()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		Vector2 val = Random.insideUnitCircle * 50f + _endPos;
		UI_com_Effect01 effect01 = _effect01;
		UI_com_Effect01 comEffect01 = _effect01;
		PlayCompleteCallback val2 = default(PlayCompleteCallback);
		((GObject)_effect01).TweenMove(val, 0.3f).SetEase((EaseType)7).OnComplete((GTweenCallback)delegate
		{
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			Transition t = effect01.t0;
			PlayCompleteCallback obj = val2;
			if (obj == null)
			{
				PlayCompleteCallback val3 = delegate
				{
					((GObject)comEffect01).Dispose();
				};
				PlayCompleteCallback val4 = val3;
				val2 = val3;
				obj = val4;
			}
			t.Play(obj);
		});
	}
}
