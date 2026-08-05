using System;
using System.Collections.Generic;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class UnlockMainCityComActionHandler : IStoryActionHandler
{
	public string ActionId()
	{
		return "UnlockMainCityCom";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		Dictionary<string, object> dictionary = CustomScript.ParseActionPayloadToDict(actionPayload);
		if (dictionary != null && dictionary.TryGetValue("Component", out var value))
		{
			string[] array = value.ToString().Split(',');
			foreach (string componentName in array)
			{
				managers.UserArchiveManager.UnlockMainCityCom(componentName);
			}
		}
		return null;
	}
}
