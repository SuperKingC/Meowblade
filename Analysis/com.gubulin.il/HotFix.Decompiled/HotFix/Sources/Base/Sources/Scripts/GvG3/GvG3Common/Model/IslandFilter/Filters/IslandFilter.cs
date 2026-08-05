using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Cache;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Config;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Enum;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Filters;

public class IslandFilter
{
	private readonly List<IIslandFilterCondition> _conditions;

	private readonly IFilterIslandSortCache _islandSortCache;

	public string FilterId { get; }

	public string FilterName { get; }

	public List<string> ItemIds { get; }

	public string CheckNotAvailableTip { get; }

	public List<string> ItemUrls { get; }

	public IslandFilter(string filterId, IslandFilterConfig config, IFilterIslandSortCache sortCache)
	{
		FilterId = filterId;
		FilterName = config.FilterLanguageKey.ToLanguage();
		ItemIds = config.IconUrls;
		CheckNotAvailableTip = config.CheckNotAvailableTip.ToLanguage();
		_conditions = ReadConditions(config.Conditions ?? new List<string>());
		ItemUrls = ReadItemUrls(config.IconUrls ?? new List<string>());
		_islandSortCache = sortCache;
	}

	private static List<string> ReadItemUrls(List<string> itemIds)
	{
		List<string> list = new List<string>();
		foreach (string itemId in itemIds)
		{
			list.Add(UiHelper.GetItemIconPath(itemId));
		}
		return list;
	}

	private static List<IIslandFilterCondition> ReadConditions(List<string> conditionKeys)
	{
		List<IIslandFilterCondition> list = new List<IIslandFilterCondition>();
		foreach (string conditionKey in conditionKeys)
		{
			list.Add(IslandFilterConfigHelper.GetIslandFilterCondition(conditionKey));
		}
		return list;
	}

	public bool CanDisplayFilterIcons(IslandStateModel model)
	{
		return _conditions.All((IIslandFilterCondition cd) => cd.CheckFilterCondition(model));
	}

	public bool IslandConformFilterConditions(IslandStateModel model)
	{
		return _conditions.Find((IIslandFilterCondition c) => c.Type == IslandFilterConditionType.RandomEventCondition)?.CheckFilterCondition(model) ?? true;
	}

	public void MarkDirty()
	{
		_islandSortCache.MarkDirty();
	}

	public List<int> GetAllIslandId()
	{
		return _islandSortCache.GetAllIslandId();
	}

	public List<int> GetSortedIslandId()
	{
		return _islandSortCache.GetSortedIslandId();
	}
}
