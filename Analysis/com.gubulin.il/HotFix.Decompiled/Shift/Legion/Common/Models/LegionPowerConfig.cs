using System;
using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class LegionPowerConfig
{
	public Dictionary<string, int> FormationInfo = new Dictionary<string, int>();

	public int MaxPower;

	public DateTimeOffset CheckTime;

	public LegionPowerConfig(int maxPower, DateTimeOffset checkTime)
	{
		MaxPower = maxPower;
		CheckTime = checkTime;
	}

	public object Clone()
	{
		LegionPowerConfig legionPowerConfig = new LegionPowerConfig(MaxPower, CheckTime);
		foreach (KeyValuePair<string, int> item in FormationInfo)
		{
			legionPowerConfig.FormationInfo.Add(item.Key, item.Value);
		}
		return legionPowerConfig;
	}
}
