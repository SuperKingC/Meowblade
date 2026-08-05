using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo;

public class GvG3VideoDisplay
{
	public string Title { get; private set; }

	public string Desc { get; private set; }

	public string Icon { get; private set; }

	public string Url { get; private set; }

	public string UnlockTip { get; private set; }

	public string PlayTip { get; private set; }

	public string TitleIcon { get; private set; }

	public Dictionary<string, int> DisplayBonus { get; private set; }

	public GvG3VideoDisplay(GDEMissionData data)
	{
		Title = data.Name;
		Desc = data.Desc;
		Icon = (data.Enabled ? ("ui://GvG3Video/" + data.Icon) : "ui://GvG3Video/未开放");
		TitleIcon = "ui://GvG3Video/" + data.Name;
		DisplayBonus = JsonHelper.ToObject<Dictionary<string, int>>(data.DisplayBonus);
		Url = HotUpdateProcess.Instance.Configs["VideoUrl"] + data.JumpContext;
		UnlockTip = GetUnlockTip(data);
		PlayTip = GetPlayTip(data.Key);
	}

	private string GetPlayTip(string dataKey)
	{
		Mission mission = MissionManager.VideoMissions.Values.FirstOrDefault((Mission vm) => vm.Data.NextMission == dataKey);
		return (mission == null) ? string.Empty : "GvG3PlayVideo".ToLanguage(mission.Data.Name);
	}

	private string GetUnlockTip(GDEMissionData data)
	{
		if (!string.IsNullOrEmpty(data.GameLevelFilter))
		{
			return LevelCompleteTip(data);
		}
		if (data.Tags != null && data.Tags.Any())
		{
			return BuildingRepairTip(data);
		}
		return string.Empty;
	}

	private string BuildingRepairTip(GDEMissionData data)
	{
		return "GvG3UnlockVideo_Building".ToLanguage(GameManagers.Instance.BuildingManager.GetBuildingByType(data.Tags[0]).Name);
	}

	private string LevelCompleteTip(GDEMissionData data)
	{
		return ("GvG3UnlockVideo_" + JsonHelper.ToObject<List<string>>(data.GameLevelFilter)[0]).ToLanguage();
	}
}
