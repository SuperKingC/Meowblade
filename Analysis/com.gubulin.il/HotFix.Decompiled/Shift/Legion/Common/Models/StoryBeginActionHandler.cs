using System;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class StoryBeginActionHandler : IStoryActionHandler
{
	public string ActionId()
	{
		return "StoryBegin";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		managers.Messenger.Broadcast("STORY_REQUEST_TO_BEGIN", actionPayload, taskCompletionSource);
		return null;
	}
}
