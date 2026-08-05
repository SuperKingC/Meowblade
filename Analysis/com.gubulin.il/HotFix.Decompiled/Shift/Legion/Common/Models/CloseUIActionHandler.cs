using System;
using System.Collections.Generic;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class CloseUIActionHandler : IStoryActionHandler
{
	public string ActionId()
	{
		return "CloseUI";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		SentrySdk.AddBreadcrumb("CloseUIActionHandler CustomScript.ActionCloseUI: " + actionPayload);
		Dictionary<string, object> dictionary = CustomScript.ParseActionPayloadToDict(actionPayload);
		if (dictionary != null && dictionary.TryGetValue("UI", out var value))
		{
			SharedMessenger.Broadcast("ACTION_CLOSE_UI", value.ToString());
		}
		taskCompletionSource?.TrySetResult(result: true);
		return null;
	}
}
