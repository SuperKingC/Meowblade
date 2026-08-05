using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;

public static class ActivityExtension
{
	public static string GetTicketExtraLimitDesc(this Activity activity)
	{
		return activity.Type switch
		{
			ActivityType.TimeLimitInstance => GetTimeLimitInstanceTicketExtraLimitDesc(), 
			_ => string.Empty, 
		};
	}

	private static string GetTimeLimitInstanceTicketExtraLimitDesc()
	{
		int num = 0;
		if (GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("OverlordContract") > 0)
		{
			num++;
		}
		if (GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("PrimeContract") > 0)
		{
			num += 2;
		}
		return (num <= 0) ? string.Empty : $"[color=#FFF04C](+{num})[/color]";
	}
}
