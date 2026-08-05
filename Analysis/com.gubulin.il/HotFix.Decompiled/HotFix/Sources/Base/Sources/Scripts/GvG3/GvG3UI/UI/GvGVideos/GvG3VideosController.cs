using System;
using System.Collections.Generic;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo;
using Shift.Legion.Common.Models;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGVideos;

public class GvG3VideosController
{
	private readonly GvG3VideoQueries _videoQueries;

	private readonly GvG3VideoPlayOperation _videoPlayOperation;

	private readonly GvG3VideoClaimOperation _videoClaimOperation;

	public List<GvG3Video> Videos => _videoQueries.Videos;

	public GvG3VideosController(GLoader loader)
	{
		_videoQueries = new GvG3VideoQueries();
		_videoPlayOperation = new GvG3VideoPlayOperation(loader);
		_videoClaimOperation = new GvG3VideoClaimOperation();
	}

	public void RemovePlayer()
	{
		_videoPlayOperation.RemovePlayer();
	}

	public void StopVideo()
	{
		_videoPlayOperation.StopVideo();
	}

	public void PlayVideo(string videoId, Action prepared, Action<GvG3Video> completed)
	{
		GvG3Video gvG3Video = _videoQueries.FindVideo(videoId);
		GvG3Video nextVideo = _videoQueries.FindVideo(gvG3Video.Meta.NextVideoId);
		Mission mission = _videoQueries.FindMission(gvG3Video.Meta.Id);
		_videoPlayOperation.PlayVideo(new PlayVideoParam(gvG3Video, nextVideo, mission, prepared, completed));
	}

	public void ClaimReward(string videoId, Action<GvG3Video> claimed = null)
	{
		_videoClaimOperation.ClaimReward(_videoQueries.FindVideo(videoId), _videoQueries.FindMission(videoId), claimed);
	}

	public string GetRewardItemId()
	{
		return _videoQueries.RewardItemId;
	}

	public GvG3Video FindVideo(string videoId)
	{
		return _videoQueries.FindVideo(videoId);
	}
}
