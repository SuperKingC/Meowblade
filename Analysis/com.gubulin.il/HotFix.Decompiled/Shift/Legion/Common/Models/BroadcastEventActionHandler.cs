using System;
using System.Collections.Generic;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class BroadcastEventActionHandler : IStoryActionHandler
{
	private class Json_BroadcastEvent_Event
	{
		public string Event;
	}

	private class Json_BroadcastEvent
	{
		public string Event;

		public List<string> ParametersType;

		public List<int> Parameters;
	}

	private class Json_BroadcastEvent_ListString
	{
		public string Event;

		public List<string> Parameters;
	}

	public string ActionId()
	{
		return "BroadcastEvent";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		Json_BroadcastEvent_Event json_BroadcastEvent_Event = JsonHelper.ToObject<Json_BroadcastEvent_Event>(actionPayload);
		switch (json_BroadcastEvent_Event.Event)
		{
		case "NEW_FORMATION_SLOT_UNLOCKED":
		{
			Json_BroadcastEvent json_BroadcastEvent = JsonHelper.ToObject<Json_BroadcastEvent>(actionPayload);
			string eventType = json_BroadcastEvent.Event;
			List<string> parametersType = json_BroadcastEvent.ParametersType;
			List<int> parameters = json_BroadcastEvent.Parameters;
			foreach (int item in parameters)
			{
				managers.Messenger.Broadcast(eventType, item);
			}
			return null;
		}
		case "FORMATION_FORCE_UNLOCKED":
		case "FORMATION_FORCE_LOCKED":
		{
			Json_BroadcastEvent_ListString json_BroadcastEvent_ListString = JsonHelper.ToObject<Json_BroadcastEvent_ListString>(actionPayload);
			managers.Messenger.Broadcast(json_BroadcastEvent_ListString.Event, json_BroadcastEvent_ListString.Parameters);
			return null;
		}
		default:
			ILRuntimeDebug.LogError("BroadcastEventActionHandler Event=" + json_BroadcastEvent_Event.Event + " but no action!");
			return null;
		}
	}
}
