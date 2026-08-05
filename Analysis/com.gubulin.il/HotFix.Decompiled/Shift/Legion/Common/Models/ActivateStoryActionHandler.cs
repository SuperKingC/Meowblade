using System;
using System.Collections.Generic;
using System.Linq;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class ActivateStoryActionHandler : IStoryActionHandler
{
	private readonly string[] _gvg3Stories = new string[1] { "Story11313" };

	public string ActionId()
	{
		return "ActivateStory";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		Dictionary<string, object> dictionary = CustomScript.ParseActionPayloadToDict(actionPayload);
		if (dictionary != null && dictionary.TryGetValue("Story", out var value))
		{
			string text = value.ToString();
			Dictionary<string, string> playingStoriesLine = managers.UserArchiveManager.GetPlayingStoriesLine();
			string[] array = text.Split(',');
			foreach (string text2 in array)
			{
				if (!playingStoriesLine.ContainsKey(text2) && CheckGvG3Available(text2))
				{
					managers.StoryManager.ActivateStory(text2);
				}
			}
		}
		return null;
		bool CheckGvG3Available(string storyId)
		{
			return !_gvg3Stories.Contains(storyId) || Define.GvGMode3UnderDevelopment();
		}
	}
}
