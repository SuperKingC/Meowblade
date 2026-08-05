using System.Collections.Generic;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.Activities;

public class ChallengeMissionPayload : ActivityContentPayload
{
	public List<ChallengeMissionSerial> MissionConfig;

	public CaseConfig ContentCaseConfig;

	public int DaysDuration;

	public ChallengeMissionPayload(int payloadIndex, Dictionary<string, object> data, Activity activity)
		: base(data)
	{
		ContentIndex = payloadIndex;
		Activity = activity;
		if (data.TryGetValue("MissionConfig", out var value))
		{
			Dictionary<string, object> dictionary = (Dictionary<string, object>)value;
			MissionConfig = new List<ChallengeMissionSerial>();
			foreach (KeyValuePair<string, object> item in dictionary)
			{
				MissionConfig.Add(JsonHelper.ToObject<ChallengeMissionSerial>(JsonHelper.ToJson(item.Value)));
			}
			MissionConfig.Sort((ChallengeMissionSerial a, ChallengeMissionSerial b) => a.Day - b.Day);
		}
		if (data.TryGetValue("CaseConfig", out var value2))
		{
			Dictionary<string, object> dictionary2 = (Dictionary<string, object>)value2;
			ContentCaseConfig = new CaseConfig();
			if (dictionary2.TryGetValue("RechargeCase", out var value3))
			{
				ContentCaseConfig.RechargeCase = JsonHelper.ToObject<List<float>>(JsonHelper.ToJson(value3));
			}
			if (dictionary2.TryGetValue("AccountDaysCase", out var value4))
			{
				ContentCaseConfig.AccountDaysCase = JsonHelper.ToObject<List<float>>(JsonHelper.ToJson(value4));
			}
		}
		if (data.TryGetValue("DaysDuration", out var value5))
		{
			DaysDuration = (int)value5;
		}
	}
}
