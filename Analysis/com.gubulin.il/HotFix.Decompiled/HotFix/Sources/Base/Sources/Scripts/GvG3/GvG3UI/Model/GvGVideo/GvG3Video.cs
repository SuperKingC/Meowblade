using System;
using System.Linq;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo;

public class GvG3Video
{
	public readonly GvG3VideoDisplay Display;

	public readonly GvG3VideoMeta Meta;

	public VideoStatus VideoStatus { get; private set; }

	public VideoRewardStatus VideoRewardStatus { get; private set; }

	public GvG3Video(GDEMissionData data)
	{
		Display = new GvG3VideoDisplay(data);
		Meta = new GvG3VideoMeta(data);
		UpdateStatus();
	}

	public void UpdateStatus()
	{
		if (!Meta.Enabled)
		{
			VideoStatus = VideoStatus.NotEnabled;
			UpdateRewardStatus(VideoRewardStatus.NotClaimable);
			return;
		}
		MissionManager.VideoMissions.TryGetValue(Meta.Id, out var value);
		if (value == null)
		{
			throw new Exception("GvG3Video.UpdateStatus：mission is null,missionId=" + Meta.Id);
		}
		MissionConfig missionConfig = value.MissionState(GameManagers.Instance);
		VideoStatus = GetVideoStatus(missionConfig);
		UpdateRewardStatus(GetRewardStatus(missionConfig.Status));
	}

	public void UpdateRewardStatus(VideoRewardStatus status)
	{
		VideoRewardStatus = status;
	}

	private VideoRewardStatus GetRewardStatus(MissionStatus missionStatus)
	{
		return missionStatus switch
		{
			MissionStatus.Claimed => VideoRewardStatus.Claimed, 
			MissionStatus.Completed => VideoRewardStatus.Claimable, 
			_ => VideoRewardStatus.NotClaimable, 
		};
	}

	private VideoStatus GetVideoStatus(MissionConfig missionConfig)
	{
		if (missionConfig.Status == MissionStatus.Pending || missionConfig.Status == MissionStatus.Failed || missionConfig.Status == MissionStatus.Disabled)
		{
			return VideoStatus.Locked;
		}
		MissionConfig missionConfig2 = MissionManager.VideoMissions.Values.FirstOrDefault((Mission vm) => vm.Data.NextMission == Meta.Id)?.MissionState(GameManagers.Instance);
		if (missionConfig2 == null)
		{
			return VideoStatus.AllowToPlay;
		}
		return (missionConfig2.Status < MissionStatus.Completed) ? VideoStatus.Unlocked : VideoStatus.AllowToPlay;
	}
}
