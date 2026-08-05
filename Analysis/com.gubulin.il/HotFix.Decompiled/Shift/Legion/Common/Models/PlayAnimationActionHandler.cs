using System;
using System.Collections.Generic;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class PlayAnimationActionHandler : IStoryActionHandler
{
	public string ActionId()
	{
		return "PlayAnimation";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		Dictionary<string, object> dictionary = CustomScript.ParseActionPayloadToDict(actionPayload);
		if (dictionary != null && dictionary.TryGetValue("Animation", out var value))
		{
			managers.Messenger.Broadcast("ACTION_PLAY_ANIMATION", value, taskCompletionSource);
		}
		return null;
	}
}
