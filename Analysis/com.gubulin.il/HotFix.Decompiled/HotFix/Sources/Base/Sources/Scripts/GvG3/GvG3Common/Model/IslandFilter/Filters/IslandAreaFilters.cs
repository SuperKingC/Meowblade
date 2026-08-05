using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Areas;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Cache;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Config;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Filters;

public class IslandAreaFilters
{
	private readonly IAreaEffectiveCondition _effectiveCondition;

	public string AreaName { get; }

	public List<IslandFilter> Filters { get; }

	public bool CheckAreaEffective => _effectiveCondition.CheckAreaEffective();

	public IslandAreaFilters(GvGIslandFilterAreaConfig config)
	{
		AreaName = config.AreaKey.ToLanguage();
		_effectiveCondition = ReadEffectiveCondition(config.EffectiveCondition);
		Filters = ReadIslandFilters(config.Filters);
	}

	private static IAreaEffectiveCondition ReadEffectiveCondition(string conditionKey)
	{
		return IslandFilterConfigHelper.GetAreaEffectiveCondition(conditionKey);
	}

	private static List<IslandFilter> ReadIslandFilters(List<string> filterKeys)
	{
		List<IslandFilter> list = new List<IslandFilter>();
		foreach (string filterKey in filterKeys)
		{
			IslandFilterConfig islandFilterConfig = filterKey.ToConfiguration<IslandFilterConfig>();
			FilterIslandSortCache sortCache = new FilterIslandSortCache(islandFilterConfig.Islands);
			IslandFilter item = new IslandFilter(filterKey, islandFilterConfig, sortCache);
			list.Add(item);
		}
		return list;
	}

	public void MarkFiltersIslandSortCacheDirty()
	{
		foreach (IslandFilter filter in Filters)
		{
			filter.MarkDirty();
		}
	}

	public bool ContainsFilter(string filterId)
	{
		return Filters.Any((IslandFilter f) => f.FilterId == filterId);
	}
}
