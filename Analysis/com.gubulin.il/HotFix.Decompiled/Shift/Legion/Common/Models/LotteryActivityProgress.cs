using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class LotteryActivityProgress
{
	public string ActivityId;

	public int Score;

	public bool IsNew;

	public int BeginAt;

	public int ExpireAt;

	public LotteryActivityProgress(string activityId)
	{
		ActivityId = activityId;
	}

	public LotteryActivityProgress Reset(GameManagers managers)
	{
		Score = 0;
		BeginAt = 0;
		ExpireAt = 0;
		return this;
	}
}
