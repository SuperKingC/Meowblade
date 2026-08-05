using System;
using System.Collections.Generic;
using System.Reflection;
using FairyGUI;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class FireClickActionHandler : IStoryActionHandler
{
	public string ActionId()
	{
		return "FireClick";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		Dictionary<string, object> dictionary = CustomScript.ParseActionPayloadToDict(actionPayload);
		if (dictionary != null && dictionary.TryGetValue("Tag", out var value))
		{
			object obj = UiTagManager.Instance.FindObjectByTag(value.ToString());
			if (obj == null)
			{
				return null;
			}
			if (obj is GObject)
			{
				GObject val = (GObject)obj;
				Type type = ((object)val).GetType();
				Type typeFromHandle = typeof(GButton);
				if (val is GButton)
				{
					GButton val2 = (GButton)((obj is GButton) ? obj : null);
					MethodInfo method = type.GetMethod("FireClick");
					if (method != null)
					{
						val2.FireClick(false, false);
						((GObject)val2).onClick.Call((object)taskCompletionSource);
					}
					else
					{
						((EventDispatcher)val).BubbleEvent("onClick", (object)taskCompletionSource);
					}
				}
				else
				{
					((EventDispatcher)val).BubbleEvent("onClick", (object)taskCompletionSource);
				}
			}
		}
		return null;
	}
}
