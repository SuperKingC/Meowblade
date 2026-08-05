using System;
using System.Threading.Tasks;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGVideos;

public class GvG3VideoPlayOperation
{
	private VideoPlayerController _player;

	public GvG3VideoPlayOperation(GLoader loader)
	{
		_player = VideoPlayerHelper.Get(loader);
	}

	public void RemovePlayer()
	{
		StopVideo();
		_player.Loader = null;
		_player = null;
	}

	public void StopVideo()
	{
		_player.Stop();
	}

	public void PlayVideo(PlayVideoParam playParam)
	{
		_player.PlayUrl(new PlayVideoCommand(playParam.Video.Display.Url, Finished, playParam.Prepared));
		void Finished()
		{
			CompleteVideo(playParam);
		}
	}

	private void CompleteVideo(PlayVideoParam playParam)
	{
		MissionConfig missionConfig = playParam.Mission.MissionState(GameManagers.Instance);
		if (missionConfig.Status >= MissionStatus.Completed)
		{
			playParam.Completed?.Invoke(playParam.Video);
		}
		else
		{
			CheckMissionStatus(missionConfig, playParam);
		}
	}

	private void CheckMissionStatus(MissionConfig state, PlayVideoParam playParam)
	{
		state.Status = MissionStatus.Completed;
		ILRequestHelper<CheckMissionStatusResponse>.Request((EventContext)null, (Func<Task<CheckMissionStatusResponse>>)(() => GameController.Contexts.Service<INetworkService>().CheckMissionStatus(playParam.Mission.Id, (int)state.Status)), (Action<CheckMissionStatusResponse>)delegate(CheckMissionStatusResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				CheckMissionStatusCallback(playParam);
			}
		});
	}

	private void CheckMissionStatusCallback(PlayVideoParam playParam)
	{
		playParam.Video.UpdateRewardStatus(VideoRewardStatus.Claimable);
		playParam.NextVideo?.UpdateStatus();
		GameManagers.Instance.Messenger.Broadcast("MISSION_COMPLETE", playParam.Mission);
		playParam.Completed?.Invoke(playParam.Video);
	}
}
