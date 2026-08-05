using System;
using System.Collections;
using System.Collections.Generic;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class BonusActionHandler : IStoryActionHandler
{
	public string ActionId()
	{
		return "Bonus";
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
			string text = key;
			if (!(text == "AutoProduce"))
			{
				if (text == "Unlock")
				{
					List<string> list = new List<string>();
					if (item.Value is ArrayList)
					{
						foreach (object item2 in (ArrayList)item.Value)
						{
							list.Add(item2.ToString());
						}
					}
					else
					{
						list = JsonHelper.ToObject<List<string>>(item.Value.ToString());
					}
					Bonus.Get(item.Key, list).Claim(managers);
				}
				else
				{
					Bonus.Get(item.Key, item.Value).Claim(managers);
				}
			}
			else
			{
				Bonus.Get(item.Key, JsonHelper.ToObject<Dictionary<string, int>>(item.Value.ToString())).Claim(managers);
			}
		}
		return null;
	}
}
