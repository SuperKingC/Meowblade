using FairyGUI;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Utils;

public readonly struct RewardClaimingEffectPlayer
{
	private readonly IRewardClaimingEffect _effect;

	private readonly Vector2 _endPos;

	private readonly float _moveDuration;

	public RewardClaimingEffectPlayer(IRewardClaimingEffect effect, Vector2 endPos, float moveDuration)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		_effect = effect;
		_endPos = endPos;
		_moveDuration = moveDuration;
	}

	public void Play()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		if (_effect != null)
		{
			Vector2 val = Vector2.op_Implicit(((GObject)_effect.Component).position) + Random.insideUnitCircle * 100f;
			((GObject)_effect.Component).SetXY(val.x, val.y);
			ToEnd();
		}
	}

	private void ToEnd()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		Vector2 val = Random.insideUnitCircle * 50f + _endPos;
		IRewardClaimingEffect effect1 = _effect;
		IRewardClaimingEffect effect2 = _effect;
		PlayCompleteCallback val2 = default(PlayCompleteCallback);
		((GObject)_effect.Component).TweenMove(val, _moveDuration).SetEase((EaseType)7).OnComplete((GTweenCallback)delegate
		{
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			Transition disappear = effect1.Disappear;
			PlayCompleteCallback obj = val2;
			if (obj == null)
			{
				PlayCompleteCallback val3 = delegate
				{
					((GObject)effect2.Component).Dispose();
				};
				PlayCompleteCallback val4 = val3;
				val2 = val3;
				obj = val4;
			}
			disappear.Play(obj);
		});
	}
}
