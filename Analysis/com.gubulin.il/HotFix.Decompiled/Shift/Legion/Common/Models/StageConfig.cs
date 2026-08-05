using System.Collections.Generic;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Models;

public class StageConfig
{
	public bool AnimSignal;

	private bool _lastCheckState;

	public int Id { get; set; }

	public List<string> SoliderUnlock { get; set; }

	public List<string> LevelUnlock { get; set; }

	public List<string> MissionSerial { get; set; }

	public List<string> Gift { get; set; }

	public void RegisterEventListener()
	{
		GameManagers.Instance.Messenger.AddListener<Mission>("MISSION_COMPLETE", OnMissionComplete);
	}

	private void OnMissionComplete(Mission mission)
	{
		if (_lastCheckState)
		{
			return;
		}
		if (LevelUnlock != null)
		{
			foreach (string item in LevelUnlock)
			{
				if (item == mission.Id)
				{
					AnimSignal = true;
				}
			}
		}
		if (SoliderUnlock == null)
		{
			return;
		}
		foreach (string item2 in SoliderUnlock)
		{
			if (item2 == mission.Id)
			{
				AnimSignal = true;
			}
		}
	}

	public bool IsUnlocked()
	{
		if ((LevelUnlock == null || LevelUnlock.Count == 0) && (SoliderUnlock == null || SoliderUnlock.Count == 0))
		{
			_lastCheckState = true;
			return true;
		}
		bool flag = false;
		if (LevelUnlock != null)
		{
			foreach (string item in LevelUnlock)
			{
				Mission mission = MissionManager.Missions[item];
				mission.CheckProgress(GameManagers.Instance);
				MissionConfig missionConfig = mission.MissionState(GameManagers.Instance);
				if (missionConfig.Status == MissionStatus.Claimed || missionConfig.Status == MissionStatus.Completed)
				{
					flag = true;
				}
			}
		}
		if (SoliderUnlock != null)
		{
			foreach (string item2 in SoliderUnlock)
			{
				Mission mission2 = MissionManager.Missions[item2];
				mission2.CheckProgress(GameManagers.Instance);
				MissionConfig missionConfig2 = mission2.MissionState(GameManagers.Instance);
				if (missionConfig2.Status == MissionStatus.Claimed || missionConfig2.Status == MissionStatus.Completed)
				{
					flag = true;
				}
			}
		}
		_lastCheckState = flag;
		return flag;
	}

	public bool HasAnyMessage()
	{
		if (!IsUnlocked())
		{
			return false;
		}
		if (MissionSerial != null)
		{
			foreach (string item in MissionSerial)
			{
				Mission mission = MissionManager.Missions[item];
				MissionConfig missionConfig = mission.MissionState(GameManagers.Instance);
				if (missionConfig.Status == MissionStatus.Completed)
				{
					return true;
				}
			}
		}
		return false;
	}
}
