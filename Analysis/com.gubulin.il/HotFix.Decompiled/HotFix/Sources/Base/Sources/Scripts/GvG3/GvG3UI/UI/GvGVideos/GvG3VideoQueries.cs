using System;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGVideos;

public class GvG3VideoQueries
{
	public List<GvG3Video> Videos { get; } = new List<GvG3Video>();

	public string RewardItemId { get; private set; }

	public GvG3VideoQueries()
	{
		ControllerInit();
	}

	private void ControllerInit()
	{
		ValidateVideoUrl();
		LoadVideos();
		GetRewardItemId();
	}

	private void ValidateVideoUrl()
	{
		if (!HotUpdateProcess.Instance.Configs.TryGetValue("VideoUrl", out var _))
		{
			throw new Exception("GvG3VideosController.LoadVideos：Configs does not contain VideoUrl");
		}
	}

	private void GetRewardItemId()
	{
		RewardItemId = Videos[0].Display.DisplayBonus.Keys.ToList()[0];
	}

	private void LoadVideos()
	{
		List<GDEMissionData> list = (from item in GDMgr.GetAllItems<GDEMissionData>()
			where item.Type == 4
			select item).ToList();
		foreach (GDEMissionData item in list)
		{
			Videos.Add(new GvG3Video(item));
		}
	}

	public GvG3Video FindVideo(string videoId)
	{
		return Videos.Find((GvG3Video v) => v.Meta.Id == videoId);
	}

	public Mission FindMission(string videoId)
	{
		if (MissionManager.VideoMissions.TryGetValue(FindVideo(videoId).Meta.Id, out var value))
		{
			return value;
		}
		throw new Exception("GvG3VideosController.GetMission：mission is non-existent，mission=" + videoId);
	}
}
