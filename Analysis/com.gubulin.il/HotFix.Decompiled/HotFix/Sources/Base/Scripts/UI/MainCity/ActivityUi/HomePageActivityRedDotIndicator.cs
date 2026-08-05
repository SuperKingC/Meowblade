using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi;

public class HomePageActivityRedDotIndicator : BaseActivityRedDotIndicator
{
	private readonly Activity _activity;

	public HomePageActivityRedDotIndicator(Activity activity)
	{
		_activity = activity;
	}

	public override bool DisplayRedDot()
	{
		return !IsSpecial(_activity.ActivityId) && _activity.HasAnyNewMsg(GameManagers.Instance);
	}
}
