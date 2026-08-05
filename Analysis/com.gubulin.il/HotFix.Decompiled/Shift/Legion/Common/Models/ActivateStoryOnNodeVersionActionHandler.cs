using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class ActivateStoryOnNodeVersionActionHandler : IStoryActionHandler
{
	public string ActionId()
	{
		return "ActivateStoryOnNodeVersion";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		Dictionary<string, object> dictionary = CustomScript.ParseActionPayloadToDict(actionPayload);
		if (dictionary == null)
		{
			throw new Exception("[ActivateStoryOnNodeVersion] actionPayload is null");
		}
		object value;
		string text = (dictionary.TryGetValue("NodeId", out value) ? value.ToString() : null);
		object value2;
		int num = (dictionary.TryGetValue("Version", out value2) ? ((int)value2) : (-1));
		object value3;
		string text2 = (dictionary.TryGetValue("Story", out value3) ? value3.ToString() : null);
		if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text2))
		{
			ILRuntimeDebug.LogError($"[ActivateStoryOnNodeVersion] payload配置不对 nodeId={text} branchVersion={num} infoStr={text2} payloadDict={dictionary.ToJson()}");
			return null;
		}
		int storyNodeVersionById = managers.UserArchiveManager.GetStoryNodeVersionById(text);
		if (num != storyNodeVersionById)
		{
			return null;
		}
		Dictionary<string, string> playingStoriesLine = managers.UserArchiveManager.GetPlayingStoriesLine();
		string[] array = text2.Split(',');
		foreach (string text3 in array)
		{
			if (!playingStoriesLine.ContainsKey(text3))
			{
				managers.StoryManager.ActivateStory(text3);
			}
		}
		return null;
	}
}
