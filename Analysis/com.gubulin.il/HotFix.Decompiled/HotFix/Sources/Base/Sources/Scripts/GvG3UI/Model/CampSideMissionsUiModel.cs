using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class CampSideMissionsUiModel
{
	public int GroupId;

	public List<GvG3FlagShipMissionModel> SideMissions;

	public GvG3FlagShipMissionModel DisplayMission;

	public int DisplayMissionStatus;

	public bool Expanded;

	public bool CanClick => SideMissions.Count > 1 && DisplayMissionStatus != 2;

	public CampSideMissionsUiModel()
	{
	}

	public CampSideMissionsUiModel(int groupId, List<GvG3FlagShipMissionModel> missions)
	{
		GroupId = groupId;
		SideMissions = missions;
		SideMissions.Sort((GvG3FlagShipMissionModel a, GvG3FlagShipMissionModel b) => a.Data.Step - b.Data.Step);
		DisplayMission = GetDisplayMission();
		SetMissionsStatus();
	}

	private GvG3FlagShipMissionModel GetDisplayMission()
	{
		DisplayMission = SideMissions.Find((GvG3FlagShipMissionModel m) => m.MState != eMissionEntityState.Undergoing && !m.HasClaimed);
		if (DisplayMission != null)
		{
			DisplayMissionStatus = 0;
			return DisplayMission;
		}
		DisplayMission = SideMissions.Find((GvG3FlagShipMissionModel m) => m.MState == eMissionEntityState.Undergoing);
		if (DisplayMission != null)
		{
			DisplayMissionStatus = 1;
			return DisplayMission;
		}
		DisplayMissionStatus = 2;
		DisplayMission = SideMissions[0];
		return DisplayMission;
	}

	private void SetMissionsStatus()
	{
		bool flag = false;
		foreach (GvG3FlagShipMissionModel sideMission in SideMissions)
		{
			if (sideMission.MState != eMissionEntityState.Undergoing)
			{
				sideMission.UiStatus = 0;
			}
			else if (!flag)
			{
				sideMission.UiStatus = 1;
				flag = true;
			}
			else
			{
				sideMission.UiStatus = 2;
			}
		}
	}
}
