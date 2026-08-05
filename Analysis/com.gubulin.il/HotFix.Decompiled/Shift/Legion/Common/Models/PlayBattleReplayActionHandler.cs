using System;
using System.Collections.Generic;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class PlayBattleReplayActionHandler : IStoryActionHandler
{
	public string ActionId()
	{
		return "PlayBattleReplay";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		Dictionary<string, object> dictionary = CustomScript.ParseActionPayloadToDict(actionPayload);
		if (dictionary != null && dictionary.TryGetValue("BattleId", out var value) && dictionary.TryGetValue("TargetFrame", out var value2) && dictionary.TryGetValue("MaskDuration", out var value3))
		{
			if (!dictionary.TryGetValue("LevelId", out var value4))
			{
				value4 = ((!managers.UserArchiveManager.IsNewGuideMode7()) ? "P001" : "P0111");
			}
			if (!dictionary.TryGetValue("ReplayMode", out var value5))
			{
				value5 = 2;
			}
			if (!dictionary.TryGetValue("IsLocalSource", out var value6))
			{
				value6 = "0";
			}
			PlayBattleReplayData arg = new PlayBattleReplayData
			{
				BattleId = value.ToString(),
				TargetFrame = int.Parse(value2.ToString()),
				LevelId = value4.ToString(),
				LocalSource = (int.Parse(value6.ToString()) == 1),
				ReplayMode = int.Parse(value5.ToString()),
				MaskDuration = int.Parse(value3.ToString())
			};
			managers.Messenger.Broadcast("ACTION_PLAY_BATTLE_REPLAY", arg, taskCompletionSource);
		}
		return null;
	}
}
