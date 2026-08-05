using System;
using System.Collections.Generic;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class DeactivateStoryActionHandler : IStoryActionHandler
{
	public string ActionId()
	{
		return "DeactivateStory";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		Dictionary<string, object> dictionary = CustomScript.ParseActionPayloadToDict(actionPayload);
		if (dictionary != null && dictionary.TryGetValue("Story", out var value))
		{
			string text = value.ToString();
			string[] array = text.Split(',');
			foreach (string storyId in array)
			{
				managers.StoryManager.DeactivateStory(storyId);
			}
		}
		return null;
	}
}
