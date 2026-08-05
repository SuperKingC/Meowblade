using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi;

public class FundsActivityRedDotIndicator : BaseActivityRedDotIndicator
{
	private readonly Activity _activity;

	public FundsActivityRedDotIndicator(Activity activity)
	{
		_activity = activity;
	}

	public override bool DisplayRedDot()
	{
		if (IsSpecial(_activity.ActivityId))
		{
			return false;
		}
		return _activity.HasAnyNewMsg(GameManagers.Instance) || _activity.ActivityProgress(GameManagers.Instance).IsNew;
	}
}
