using System.Collections.Generic;

namespace UI.GvGBattlePass3;

public class ActivityHasClaimedBonus
{
	private readonly HashSet<string> _hasUnclaimedBonuses = new HashSet<string>();

	public void TryAddClaimedRecord(string activityId)
	{
		if (!string.IsNullOrEmpty(activityId))
		{
			_hasUnclaimedBonuses.Add(activityId);
		}
	}

	public bool HasClaimedBonus(string activityId)
	{
		return _hasUnclaimedBonuses.Contains(activityId);
	}

	public bool HasAnyClaimed()
	{
		int count = _hasUnclaimedBonuses.Count;
		return count > 0;
	}

	public void Clear()
	{
		_hasUnclaimedBonuses.Clear();
	}
}
