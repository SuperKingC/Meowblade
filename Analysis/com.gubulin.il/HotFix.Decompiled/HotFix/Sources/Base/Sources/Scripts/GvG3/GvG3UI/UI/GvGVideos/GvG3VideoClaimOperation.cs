using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.GvGVideo;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGVideos;

public class GvG3VideoClaimOperation
{
	public void ClaimReward(GvG3Video video, Mission mission, Action<GvG3Video> claimed = null)
	{
		ILRequestHelper<MissionClaimResponse>.Request((EventContext)null, (Func<Task<MissionClaimResponse>>)(() => GameController.Contexts.Service<INetworkService>().MissionClaim(mission.Id)), (Action<MissionClaimResponse>)delegate(MissionClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				ClaimMission(mission, response.BonusList);
				ClaimCallback(video, claimed);
			}
		});
	}

	private void ClaimCallback(GvG3Video video, Action<GvG3Video> claimed = null)
	{
		video.UpdateRewardStatus(VideoRewardStatus.Claimed);
		claimed?.Invoke(video);
	}

	private void ClaimMission(Mission mission, List<ModelsBonus> bonusList)
	{
		SharedMessenger.Broadcast("MISSION_CLAIMED", mission);
		if (bonusList != null && bonusList.Count > 0)
		{
			FGUIManager.Instance.ClaimBonusFromApiModels(bonusList);
			return;
		}
		List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText234") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 103, arg3: false);
	}
}
