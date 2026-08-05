using System;
using System.Collections.Generic;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class PickUpMissionActionHandler : IStoryActionHandler
{
	public string ActionId()
	{
		return "PickUpMission";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		Dictionary<string, object> dictionary = CustomScript.ParseActionPayloadToDict(actionPayload);
		if (dictionary != null && dictionary.TryGetValue("Mission", out var value))
		{
			string text = value.ToString();
			string[] array = text.Split(',');
			foreach (string text2 in array)
			{
			}
		}
		return null;
	}
}
