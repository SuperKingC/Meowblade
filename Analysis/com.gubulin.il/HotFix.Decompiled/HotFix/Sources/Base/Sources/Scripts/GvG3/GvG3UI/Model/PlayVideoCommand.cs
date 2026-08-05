using System;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model;

public class PlayVideoCommand
{
	public string VideoUrl { get; private set; }

	public Action AfterFinishPlay { get; private set; }

	public Action AfterPrepare { get; private set; }

	public PlayVideoCommand(string url, Action finished, Action prepared)
	{
		VideoUrl = url;
		AfterFinishPlay = finished;
		AfterPrepare = prepared;
	}
}
