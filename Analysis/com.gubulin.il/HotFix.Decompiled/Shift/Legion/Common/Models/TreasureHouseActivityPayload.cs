using System;
using System.Collections;
using System.Collections.Generic;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class TreasureHouseActivityPayload : ActivityContentPayload
{
	public string SettingName;

	public Dictionary<float, Dictionary<string, float>> BonusConfig;

	public DateTimeOffset BeginTime;

	public DateTimeOffset EndTime;

	public TreasureHouseActivityPayload(string settingName, Dictionary<string, object> data, Activity activity)
		: base(data)
	{
		Activity = activity;
		SettingName = settingName;
		Dictionary<string, Dictionary<string, float>> dictionary = null;
		if (data["BonusConfig"] is IDictionary)
		{
			dictionary = new Dictionary<string, Dictionary<string, float>>();
			foreach (KeyValuePair<string, object> item in (Dictionary<string, object>)data["BonusConfig"])
			{
				dictionary.Add(item.Key, JsonHelper.ToObject<Dictionary<string, float>>(JsonHelper.ToJson(item.Value)));
			}
		}
		else
		{
			dictionary = JsonHelper.ToObject<Dictionary<string, Dictionary<string, float>>>(data["BonusConfig"].ToString());
		}
		BonusConfig = new Dictionary<float, Dictionary<string, float>>();
		foreach (KeyValuePair<string, Dictionary<string, float>> item2 in dictionary)
		{
			BonusConfig.Add(NumericParser.Float(item2.Key), item2.Value);
		}
		DateTimeOffset now = DateTimeHelper.Now;
		if (data.TryGetValue("BeginTime", out var value))
		{
			BeginTime = DateTimeHelper.Parse(value.ToString(), now);
		}
		if (data.TryGetValue("EndTime", out var value2))
		{
			EndTime = DateTimeHelper.Parse(value2.ToString(), now);
		}
	}
}
