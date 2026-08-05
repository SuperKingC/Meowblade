using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.Common.Managers;

public class Cache_IslandComeAgainDailyMissionRedDot : CacheBaseBehavior
{
	public static string ON_REDDOT_CHANGE = typeof(Cache_IslandComeAgainDailyMissionRedDot).Name;

	private bool _IsUpdating = false;

	private bool _IsShowRedDot = false;

	public bool IsShowRedDot
	{
		get
		{
			return _IsShowRedDot;
		}
		set
		{
			_IsShowRedDot = value;
			SharedMessenger.Broadcast(ON_REDDOT_CHANGE, this);
		}
	}

	public override IEnumerator Init()
	{
		IsUpdateEnabled = false;
		base.DelayUpdateFromNow = 1f;
		yield return null;
	}

	public override void DeferredUpdate()
	{
		if (_IsUpdating)
		{
			return;
		}
		_IsUpdating = true;
		bool hasRedDot = false;
		FGUIManager.Instance.GetIslandComeAgainActivities(delegate
		{
			_IsUpdating = false;
			DynamicIslandComeAgainActivity dynamicIslandComeAgainActivity = FGUIManager.Instance.IslandComeAgainActivities?.FirstOrDefault();
			if (dynamicIslandComeAgainActivity == null)
			{
				IsUpdateEnabled = false;
			}
			else
			{
				List<int> todayIZIDClaimRecord = GameManagers.Instance.UserArchiveManager.GetTodayIZIDClaimRecord();
				int count = GameManagers.Instance.UserArchiveManager.GetTodayIZIDRecord().Count;
				if (dynamicIslandComeAgainActivity.DailyMissions != null && dynamicIslandComeAgainActivity.DailyMissions.Count > 0)
				{
					foreach (DailyMission dailyMission in dynamicIslandComeAgainActivity.DailyMissions)
					{
						if (!todayIZIDClaimRecord.Contains(dailyMission.MissionId) && count >= dailyMission.OnComplete)
						{
							hasRedDot = true;
							break;
						}
					}
				}
				IsShowRedDot = hasRedDot;
				IsUpdateEnabled = false;
			}
		});
	}

	public override void OnAllCachesInit()
	{
	}
}
