using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace UI.GvG3MainStorylineQuest;

internal class CampEnergyTweener
{
	private Tweener tweener;

	public int LastEndVal;

	private Action<float> OnUpdate;

	public CampEnergyTweener(int initVal, Action<float> onUpdate)
	{
		LastEndVal = initVal;
		OnUpdate = onUpdate;
		OnUpdate(initVal);
	}

	public void Kill()
	{
		TweenExtensions.Kill((Tween)(object)tweener, false);
	}

	public void To(int targetVal)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		if (tweener != null && TweenExtensions.IsActive((Tween)(object)tweener))
		{
			TweenExtensions.Kill((Tween)(object)tweener, false);
		}
		float val = LastEndVal;
		LastEndVal = targetVal;
		tweener = (Tweener)(object)TweenSettingsExtensions.OnUpdate<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => val), (DOSetter<float>)delegate(float x)
		{
			val = x;
		}, (float)targetVal, 1f), (TweenCallback)delegate
		{
			OnUpdate((int)val);
		});
	}
}
