using System;
using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace UI.ReturningRewards;

public class RecallWelfareMissionWrapper : IRecallWelfareMission
{
	private static Dictionary<string, RecallWelfareMissionJumpContext> _jumpContexts;

	private readonly List<RecallWelfareMission> _missions;

	private RecallWelfareMission _current;

	private readonly HashSet<string> _claimed;

	private readonly HashSet<string> _completed;

	public eMissionType Type { get; }

	public int CurrentValue { get; }

	public string Description { get; }

	public string LevelCase { get; }

	public string MissionId => _current.MissionId;

	public RecallWelfareMissionUiState State { get; private set; }

	public int Score => _current.Score;

	public int TargetValue => _current.TargetValue;

	public RecallWelfareMissionWrapper(int progress, List<RecallWelfareMission> missions, List<string> completed, List<string> claimed)
	{
		Type = (eMissionType)missions[0].Type;
		Description = $"RecallWelfareMission_{Type}_Description".ToLanguage();
		CurrentValue = progress;
		LevelCase = $"RecallWelfareMission_{Type}_LevelCase".ToLanguage();
		_claimed = new HashSet<string>(claimed);
		_completed = new HashSet<string>(completed);
		_missions = missions;
		_current = GetCurrentMission(out var state);
		State = state;
	}

	public RecallWelfareMissionJumpContext GetJumpContext()
	{
		if (_jumpContexts == null)
		{
			_jumpContexts = "RecallWelfareMissionJumpContexts".ToConfiguration<Dictionary<string, RecallWelfareMissionJumpContext>>();
		}
		RecallWelfareMissionJumpContext value;
		return _jumpContexts.TryGetValue(Type.ToString(), out value) ? value : null;
	}

	public void OnMissionRewardClaimed(string missionId)
	{
		_claimed.Add(missionId);
		_current = GetCurrentMission(out var state);
		State = state;
	}

	private RecallWelfareMission GetCurrentMission(out RecallWelfareMissionUiState state)
	{
		_missions.Sort((RecallWelfareMission a, RecallWelfareMission b) => a.TargetValue - b.TargetValue);
		List<RecallWelfareMission> list = new List<RecallWelfareMission>();
		List<RecallWelfareMission> list2 = new List<RecallWelfareMission>();
		List<RecallWelfareMission> list3 = new List<RecallWelfareMission>();
		List<RecallWelfareMission> list4 = new List<RecallWelfareMission>();
		List<RecallWelfareMission> list5 = new List<RecallWelfareMission>();
		foreach (RecallWelfareMission mission in _missions)
		{
			if (_claimed.Contains(mission.MissionId))
			{
				list.Add(mission);
			}
			else if (_completed.Contains(mission.MissionId))
			{
				list3.Add(mission);
			}
			else if (GameManagers.Instance.UserArchiveManager.IsLevelCompleted(mission.Level))
			{
				list2.Add(mission);
			}
			else if (Type == eMissionType.累计领取远征每日宝箱次数 || Type == eMissionType.累计报名远征次数)
			{
				list5.Add(mission);
			}
			else
			{
				list4.Add(mission);
			}
		}
		if (list3.Any())
		{
			state = RecallWelfareMissionUiState.Completed;
			return list3[0];
		}
		if (list2.Any())
		{
			state = RecallWelfareMissionUiState.InProgress;
			return list2[0];
		}
		if (list.Count == _missions.Count)
		{
			state = RecallWelfareMissionUiState.Claimed;
			return list[list.Count - 1];
		}
		if (list4.Any())
		{
			state = RecallWelfareMissionUiState.Locked;
			return list4[0];
		}
		if (list5.Any())
		{
			state = RecallWelfareMissionUiState.Hidden;
			return list5[0];
		}
		throw new Exception($"RecallWelfareMissionWrapper GetCurrentMission type={Type} missions={JsonHelper.ToJson(_missions)}, state is error");
	}
}
