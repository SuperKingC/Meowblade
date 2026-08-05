using System;

namespace HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi;

public class ActivityRedDotCacheIndicator : BaseActivityRedDotIndicator
{
	private readonly Func<bool> _indicateRedDot;

	public ActivityRedDotCacheIndicator(Func<bool> indicateRedDot)
	{
		_indicateRedDot = indicateRedDot;
	}

	public override bool DisplayRedDot()
	{
		return _indicateRedDot();
	}
}
