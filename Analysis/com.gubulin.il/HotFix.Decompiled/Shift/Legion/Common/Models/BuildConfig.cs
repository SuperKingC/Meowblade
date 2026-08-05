using System.Collections.Generic;
using Shift.Legion.Common.Enums;

namespace Shift.Legion.Common.Models;

public class BuildConfig
{
	public BuildingStatus Status;

	public int Level;

	public int MaxWorkers;

	public List<ProductionConfig> ProductionConfigs;
}
