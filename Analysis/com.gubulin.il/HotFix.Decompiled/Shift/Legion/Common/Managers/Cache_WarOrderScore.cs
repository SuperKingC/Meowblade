using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class Cache_WarOrderScore : CacheBaseBehavior
{
	private Task<SyncWeeklyMissionScoreResponse> _task;

	private List<string> ScoreItemIds;

	private List<Activity> BattlePassActivity = new List<Activity>();

	public bool IsSyncProduce
	{
		set
		{
			IsUpdateEnabled = value;
		}
	}

	public override IEnumerator Init()
	{
		yield return base.Init();
		TimeInterval = 0.3f;
		IsUpdateEnabled = false;
		_task = null;
		ScoreItemIds = new List<string>();
		BattlePassActivity = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.BattlePass, null, isSort: false);
		yield return null;
		foreach (Activity activity in BattlePassActivity)
		{
			if (activity.GetStatus(GameManagers.Instance) == ActivityStatus.Enabled)
			{
				Dictionary<string, ActivityContentPayload>.Enumerator enumerator2 = activity.ContentPayload(GameManagers.Instance).GetEnumerator();
				enumerator2.MoveNext();
				BattlePassActivityPayload payload = (BattlePassActivityPayload)enumerator2.Current.Value;
				if (!string.IsNullOrEmpty(payload.ScoreItem) && ScoreItemIds.IndexOf(payload.ScoreItem) < 0)
				{
					ScoreItemIds.Add(payload.ScoreItem);
				}
				yield return null;
			}
		}
	}

	public override void DeferredUpdate()
	{
		if (_task == null)
		{
			_task = GameController.Contexts.Service<INetworkService>().SyncWeeklyMissionScore();
		}
		else
		{
			if (!_task.IsCompleted)
			{
				return;
			}
			SyncWeeklyMissionScoreResponse result = _task.Result;
			_task = null;
			IsUpdateEnabled = false;
			if (result == null)
			{
			}
			if (!result.Result)
			{
				return;
			}
			foreach (string scoreItemId in ScoreItemIds)
			{
				GameManagers.Instance.StockController.SetStock(scoreItemId, result.Score, StockInContext.BattlePassScoreSync);
			}
		}
	}

	public override void OnAllCachesInit()
	{
		GameManagers.Instance.Messenger.AddListener<Mission>("MISSION_COMPLETE", OnMissionChanged);
		GameManagers.Instance.Messenger.AddListener<Level>("LEVEL_BONUS_CLAIMED", OnLevelBonusClaimed);
	}

	private void OnLevelBonusClaimed(Level level)
	{
		foreach (Activity item in BattlePassActivity)
		{
			if (item.LevelCase == null || !item.LevelCase.Contains(level.LevelId))
			{
				continue;
			}
			Dictionary<string, ActivityContentPayload> dictionary = item.ContentPayload(GameManagers.Instance);
			foreach (ActivityContentPayload value in dictionary.Values)
			{
				BattlePassActivityPayload battlePassActivityPayload = value as BattlePassActivityPayload;
				if (!string.IsNullOrEmpty(battlePassActivityPayload.ScoreItem) && ScoreItemIds.IndexOf(battlePassActivityPayload.ScoreItem) < 0)
				{
					ScoreItemIds.Add(battlePassActivityPayload.ScoreItem);
				}
			}
			IsSyncProduce = true;
		}
	}

	private void OnMissionChanged(Mission mission)
	{
		if (MissionManager.WeeklyMissions.ContainsKey(mission.Id))
		{
			IsSyncProduce = true;
		}
	}
}
