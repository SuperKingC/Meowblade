using System;
using System.Collections.Generic;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class InsertToDynamicPrizePoolActionHandler : IStoryActionHandler
{
	public string ActionId()
	{
		return "InsertToDynamicPrizePool";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		Dictionary<string, object> dictionary = CustomScript.ParseActionPayloadToDict(actionPayload);
		if (dictionary == null)
		{
			return null;
		}
		foreach (KeyValuePair<string, object> item in dictionary)
		{
			string key = item.Key;
			if (!managers.LotteryManager.DynamicPrizePoolConfigs.TryGetValue(key, out var value))
			{
				continue;
			}
			Dictionary<string, List<int>> dictionary2 = JsonHelper.ToObject<Dictionary<string, List<int>>>(item.Value.ToString());
			foreach (KeyValuePair<string, List<int>> item2 in dictionary2)
			{
				DynamicPrizePoolConfig value2 = value.GetValue();
				value2.AddToContent(item2);
				value.SetValue(value2);
			}
		}
		return null;
	}
}
