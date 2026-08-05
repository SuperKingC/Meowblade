using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Areas;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Config;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Enum;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Filters;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter;

public static class IslandFilterConfigHelper
{
	private const string _GVG_ISLAND_FILTER_AREA_CONFIG_KEY = "GvGIslandFilterAreaConfig";

	private const string GVG_ISLAND_FILTER_VOID_BRAWL = "GvGIslandFilterAreaConfig_SkyIsland_VoidBrawl";

	private static readonly Dictionary<IslandFilterConditionType, IIslandFilterCondition> _filterConditions = new Dictionary<IslandFilterConditionType, IIslandFilterCondition>(2)
	{
		{
			IslandFilterConditionType.RandomEventCondition,
			new RandomEventCondition(IslandFilterConditionType.RandomEventCondition)
		},
		{
			IslandFilterConditionType.ReachableCondition,
			new ReachableCondition(IslandFilterConditionType.ReachableCondition)
		}
	};

	private static readonly Dictionary<IslandFilterEffectiveCondition, IAreaEffectiveCondition> _areaEffectiveConditions = new Dictionary<IslandFilterEffectiveCondition, IAreaEffectiveCondition>(2)
	{
		{
			IslandFilterEffectiveCondition.None,
			new EmptyAreaEffectiveCondition()
		},
		{
			IslandFilterEffectiveCondition.EverNightArea,
			new EverNightAreaFilterEffectiveCondition()
		}
	};

	public static IIslandFilterCondition GetIslandFilterCondition(string conditionType)
	{
		IslandFilterConditionType key = (IslandFilterConditionType)System.Enum.Parse(typeof(IslandFilterConditionType), conditionType);
		return _filterConditions[key];
	}

	public static IAreaEffectiveCondition GetAreaEffectiveCondition(string conditionType)
	{
		if (string.IsNullOrEmpty(conditionType))
		{
			return _areaEffectiveConditions[IslandFilterEffectiveCondition.None];
		}
		IslandFilterEffectiveCondition key = (IslandFilterEffectiveCondition)System.Enum.Parse(typeof(IslandFilterEffectiveCondition), conditionType);
		return _areaEffectiveConditions[key];
	}

	public static List<IslandAreaFilters> CreateIslandAreaFilters(string izConfigId)
	{
		string configKey = (WorldMapConfigHelper.IsBrawlFightEvent(izConfigId) ? "GvGIslandFilterAreaConfig_SkyIsland_VoidBrawl" : "GvGIslandFilterAreaConfig");
		List<GvGIslandFilterAreaConfig> source = configKey.ToConfiguration<List<GvGIslandFilterAreaConfig>>();
		return source.Select((GvGIslandFilterAreaConfig config) => new IslandAreaFilters(config)).ToList();
	}

	public static void FuncStopwatchTimeLog(Action action, string funcName, string funcLog = "")
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		action?.Invoke();
		stopwatch.Stop();
	}

	public static void PrintLog(string msg)
	{
	}
}
