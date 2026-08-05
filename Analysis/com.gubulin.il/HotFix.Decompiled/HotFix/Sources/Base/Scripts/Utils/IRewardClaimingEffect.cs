using FairyGUI;

namespace HotFix.Sources.Base.Scripts.Utils;

public interface IRewardClaimingEffect
{
	GComponent Component { get; }

	Transition Disappear { get; }
}
