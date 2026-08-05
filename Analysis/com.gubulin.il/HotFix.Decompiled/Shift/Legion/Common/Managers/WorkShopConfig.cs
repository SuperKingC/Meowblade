using System.Collections.Generic;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public class WorkShopConfig
{
	public string BuildingType;

	public int MaxWorkers;

	public Dictionary<string, ProductionConfig> ProductionConfigs;

	public WorkShopConfig()
	{
		BuildingType = "WorkShop";
		MaxWorkers = 0;
		ProductionConfigs = new Dictionary<string, ProductionConfig>();
	}
}
