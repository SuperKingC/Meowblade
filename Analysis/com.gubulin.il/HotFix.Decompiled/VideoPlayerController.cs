using System;
using System.Collections;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
	private class VideoEndTime
	{
		private long _endTime;

		private const int FrameRate = 30;

		private long CurTimestamp => GameController.Instance.GetServerTime();

		public void SetVideoEndTime(long frameCount)
		{
			_endTime = CurTimestamp + frameCount / 30;
		}

		public bool VideoIsEnd()
		{
			return CurTimestamp >= _endTime;
		}
	}

	public VideoPlayer Player = null;

	public GLoader Loader = null;

	private Coroutine _Coroutine_CheckOver;

	private Action _afterFinishPlay;

	private Action _afterPrepared;

	private VideoEndTime _endTime;

	private void Start()
	{
		_endTime = new VideoEndTime();
	}

	public void PlayUrl(PlayVideoCommand command)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		_afterFinishPlay = command.AfterFinishPlay;
		_afterPrepared = command.AfterPrepare;
		Player.targetTexture.Release();
		Player.url = command.VideoUrl + $"?t={DateTimeHelper.TimeStamp}";
		Player.EnableAudioTrack((ushort)0, true);
		Player.Prepare();
		Player.prepareCompleted += new EventHandler(Prepared);
	}

	public void Stop()
	{
		if (_Coroutine_CheckOver != null)
		{
			((MonoBehaviour)this).StopCoroutine(_Coroutine_CheckOver);
		}
		Player.Stop();
		((GObject)Loader).visible = false;
		ClearCache();
	}

	private void Prepared(VideoPlayer vPlayer)
	{
		((GObject)Loader).visible = true;
		_afterPrepared?.Invoke();
		Player.Play();
		_endTime.SetVideoEndTime((long)Player.frameCount);
		if (_Coroutine_CheckOver != null)
		{
			((MonoBehaviour)this).StopCoroutine(_Coroutine_CheckOver);
		}
		_Coroutine_CheckOver = ((MonoBehaviour)this).StartCoroutine(CheckOver());
	}

	private void ClearCache()
	{
		Player.targetTexture.Release();
	}

	private IEnumerator CheckOver()
	{
		while (Player.frame < (long)(Player.frameCount - 1) && !_endTime.VideoIsEnd())
		{
			yield return (object)new WaitForEndOfFrame();
			yield return (object)new WaitForEndOfFrame();
		}
		_afterFinishPlay?.Invoke();
		_afterFinishPlay = null;
		Stop();
	}
}
