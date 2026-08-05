using System.Collections.Generic;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class MilitaryIntelligence : Building
{
	public object Controller;

	public MilitaryIntelligence(GameManagers managers)
		: base(managers, "14")
	{
	}

	public override bool HasAnyInform()
	{
		if (base.HasAnyInform())
		{
			return true;
		}
		if (Level < 1)
		{
			return false;
		}
		bool result = false;
		Activity currentSingletonActivityByType = GameManagers.Instance.ActivityManager.GetCurrentSingletonActivityByType(ActivityType.AttackInstance);
		Activity currentSingletonActivityByType2 = GameManagers.Instance.ActivityManager.GetCurrentSingletonActivityByType(ActivityType.DefenseInstance);
		Activity currentSingletonActivityByType3 = GameManagers.Instance.ActivityManager.GetCurrentSingletonActivityByType(ActivityType.TimeLimitInstance);
		List<Activity> activitiesByType = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.TreasureHunt);
		List<Activity> list = new List<Activity>();
		if (currentSingletonActivityByType != null)
		{
			list.Add(currentSingletonActivityByType);
			if (currentSingletonActivityByType.ChildIds.Count > 0)
			{
				foreach (string childId in currentSingletonActivityByType.ChildIds)
				{
					if (ActivityManager.Activities.TryGetValue(childId, out var value) && !list.Contains(value))
					{
						list.Add(value);
					}
				}
			}
		}
		if (currentSingletonActivityByType2 != null)
		{
			list.Add(currentSingletonActivityByType2);
			if (currentSingletonActivityByType2.ChildIds.Count > 0)
			{
				foreach (string childId2 in currentSingletonActivityByType2.ChildIds)
				{
					if (ActivityManager.Activities.TryGetValue(childId2, out var value2) && !list.Contains(value2))
					{
						list.Add(value2);
					}
				}
			}
		}
		if (currentSingletonActivityByType3 != null)
		{
			list.Add(currentSingletonActivityByType3);
			if (currentSingletonActivityByType3.ChildIds.Count > 0)
			{
				foreach (string childId3 in currentSingletonActivityByType3.ChildIds)
				{
					if (ActivityManager.Activities.TryGetValue(childId3, out var value3) && !list.Contains(value3))
					{
						list.Add(value3);
					}
				}
			}
		}
		if (activitiesByType != null)
		{
			foreach (Activity item in activitiesByType)
			{
				list.Add(item);
				if (item.ChildIds.Count <= 0)
				{
					continue;
				}
				foreach (string childId4 in item.ChildIds)
				{
					if (ActivityManager.Activities.TryGetValue(childId4, out var value4) && !list.Contains(value4))
					{
						list.Add(value4);
					}
				}
			}
		}
		foreach (Activity item2 in list)
		{
			if (item2.HasAnyNewMsg(Managers))
			{
				result = true;
			}
		}
		return result;
	}
}
