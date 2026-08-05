using System.Collections.Generic;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class SoliderDevelopPayload : ActivityContentPayload
{
	public int Period;

	public List<StageConfig> Stage { get; set; }

	public SoliderDevelopPayload(int payloadIndex, string pageName, Dictionary<string, object> data, Activity activity, string sourcePayload)
		: base(data)
	{
		ContentIndex = payloadIndex;
		Activity = activity;
		Dictionary<string, ShadowDemonTraining> dictionary = JsonHelper.ToObject<Dictionary<string, ShadowDemonTraining>>(sourcePayload);
		Stage = dictionary[pageName].Stage;
		Period = dictionary[pageName].Period;
		foreach (StageConfig item in Stage)
		{
			item.RegisterEventListener();
		}
	}

	public override bool HasAnyNewMsg(GameManagers managers)
	{
		foreach (StageConfig item in Stage)
		{
			if (item.HasAnyMessage())
			{
				return true;
			}
		}
		return false;
	}
}
