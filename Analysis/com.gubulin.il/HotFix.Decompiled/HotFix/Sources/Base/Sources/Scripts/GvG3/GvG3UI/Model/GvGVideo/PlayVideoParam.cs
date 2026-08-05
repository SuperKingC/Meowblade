using System;
using Shift.Legion.Common.Models;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo;

public class PlayVideoParam
{
	public GvG3Video Video { get; }

	public GvG3Video NextVideo { get; }

	public Mission Mission { get; }

	public Action Prepared { get; }

	public Action<GvG3Video> Completed { get; }

	public PlayVideoParam(GvG3Video video, GvG3Video nextVideo, Mission mission, Action prepared, Action<GvG3Video> completed)
	{
		Video = video;
		NextVideo = nextVideo;
		Mission = mission;
		Prepared = prepared;
		Completed = completed;
	}
}
