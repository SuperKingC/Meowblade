using FairyGUI;

namespace HotFix.Sources.Base.Scripts.Utils;

public readonly struct RewardClaimingEffect : IRewardClaimingEffect
{
	public GComponent Component { get; }

	public Transition Disappear { get; }

	public RewardClaimingEffect(GComponent component, string transitionName)
	{
		Component = component;
		Disappear = component.GetTransition(transitionName);
	}
}
