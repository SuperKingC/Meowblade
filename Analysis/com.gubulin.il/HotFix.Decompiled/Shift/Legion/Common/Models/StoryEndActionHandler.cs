using System;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class StoryEndActionHandler : IStoryActionHandler
{
	public string ActionId()
	{
		return "StoryEnd";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		return delegate
		{
			managers.Messenger.Broadcast("STORY_END", actionPayload);
		};
	}
}
