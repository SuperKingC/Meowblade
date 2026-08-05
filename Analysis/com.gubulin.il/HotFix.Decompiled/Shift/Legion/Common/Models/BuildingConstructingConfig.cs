using System;
using System.Collections.Generic;
using Shift.Legion.ClientApi.Protocol.Building;

namespace Shift.Legion.Common.Models;

public class BuildingConstructingConfig
{
	public long StartTime;

	public long EndTime;

	public int UpgradeTo;

	public int Workers;

	public Dictionary<long, int> History;

	public int UpgradeRemainingTime => Math.Max(0, Convert.ToInt32((EndTime - DateTimeHelper.ServerNow.Ticks) / 10000000));

	public Shift.Legion.ClientApi.Protocol.Building.BuildingConstructingConfig ToProto(string buildingType)
	{
		Shift.Legion.ClientApi.Protocol.Building.BuildingConstructingConfig buildingConstructingConfig = new Shift.Legion.ClientApi.Protocol.Building.BuildingConstructingConfig
		{
			BuildingType = buildingType,
			StartTime = StartTime,
			EndTime = EndTime,
			UpgradeTo = UpgradeTo,
			Workers = Workers,
			History = new Dictionary<long, int>()
		};
		foreach (KeyValuePair<long, int> item in History)
		{
			buildingConstructingConfig.History.Add(item.Key, item.Value);
		}
		return buildingConstructingConfig;
	}
}
