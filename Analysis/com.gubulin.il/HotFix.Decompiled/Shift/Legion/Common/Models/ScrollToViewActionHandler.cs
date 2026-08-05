using System;
using System.Collections.Generic;
using FairyGUI;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class ScrollToViewActionHandler : IStoryActionHandler
{
	public string ActionId()
	{
		return "ScrollToView";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		Dictionary<string, object> dictionary = CustomScript.ParseActionPayloadToDict(actionPayload);
		if (dictionary != null && dictionary.TryGetValue("Tag", out var value))
		{
			object obj = UiTagManager.Instance.FindObjectByTag(value.ToString());
			if (obj == null)
			{
				return null;
			}
			GObject val = (GObject)((obj is GObject) ? obj : null);
			if (val != null)
			{
				GComponent parent = val.parent;
				GList val2 = (GList)(object)((parent is GList) ? parent : null);
				if (val2 != null)
				{
					val2.ScrollToView(((GComponent)val2).GetChildIndex(val));
				}
			}
		}
		return null;
	}
}
