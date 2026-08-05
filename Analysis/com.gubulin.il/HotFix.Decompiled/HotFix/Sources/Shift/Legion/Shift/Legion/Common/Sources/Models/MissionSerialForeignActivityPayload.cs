using System.Collections.Generic;
using ILRuntime_LitJson;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models;

public class MissionSerialForeignActivityPayload : ActivityContentPayload
{
	public Dictionary<int, MissionSerialConfig> MissionConfig;

	public List<BonusConfig> ScoreProgressBonusConfig;

	public Dictionary<string, int> SevenDaysPacketConfig;

	public int DaysDuration { get; set; }

	public MissionSerialForeignActivityPayload(int payloadIndex, Dictionary<string, object> data, Activity activity)
		: base(data)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		ContentIndex = payloadIndex;
		Activity = activity;
		if (data.TryGetValue("MissionConfig", out var value))
		{
			Dictionary<string, object> dictionary = (Dictionary<string, object>)value;
			MissionConfig = new Dictionary<int, MissionSerialConfig>();
			foreach (KeyValuePair<string, object> item in dictionary)
			{
				JsonData val = (JsonData)item.Value;
				MissionSerialConfig missionSerialConfig = JsonHelper.ToObject<MissionSerialConfig>(val.ToJson());
				MissionConfig.Add(missionSerialConfig.Day, missionSerialConfig);
			}
		}
		if (data.TryGetValue("ScoreProgressBonusConfig", out var value2))
		{
			Dictionary<string, object> dictionary2 = (Dictionary<string, object>)value2;
			ScoreProgressBonusConfig = new List<BonusConfig>();
			foreach (KeyValuePair<string, object> item2 in dictionary2)
			{
				int requiredScore = int.Parse(item2.Key);
				BonusConfig bonusConfig = JsonHelper.ToObject<BonusConfig>(JsonHelper.ToJson(item2.Value));
				bonusConfig.RequiredScore = requiredScore;
				ScoreProgressBonusConfig.Add(bonusConfig);
			}
			ScoreProgressBonusConfig.Sort((BonusConfig a, BonusConfig b) => a.RequiredScore - b.RequiredScore);
		}
		if (data.TryGetValue("DaysDuration", out var value3))
		{
			value3 = (int)value3;
		}
		if (data.TryGetValue("SevenDaysPacketConfig", out var value4))
		{
			SevenDaysPacketConfig = (Dictionary<string, int>)value4;
		}
	}

	public List<Mission> Missions(GameManagers managers)
	{
		List<Mission> list = new List<Mission>();
		ActivityStatus status = Activity.GetStatus(managers);
		foreach (KeyValuePair<int, MissionSerialConfig> item in MissionConfig)
		{
			List<MissionConfig> missionSerial = item.Value.MissionSerial;
			foreach (MissionConfig item2 in missionSerial)
			{
				if (MissionManager.Missions.TryGetValue(item2.MissionId, out var value))
				{
					if (status == ActivityStatus.Enabled)
					{
						value.Pickup(managers);
					}
					list.Add(value);
				}
			}
		}
		return list;
	}
}
