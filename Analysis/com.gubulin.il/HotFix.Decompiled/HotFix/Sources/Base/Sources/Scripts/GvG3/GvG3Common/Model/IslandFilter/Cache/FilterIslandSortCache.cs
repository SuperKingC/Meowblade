using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Cache;

public class FilterIslandSortCache : IFilterIslandSortCache
{
	private class DictionaryValueComparer
	{
		public readonly Dictionary<int, float> Dictionary;

		public DictionaryValueComparer(Dictionary<int, float> dictionary)
		{
			Dictionary = dictionary;
		}

		public int Compare(IntContainer<int> x, IntContainer<int> y)
		{
			return Dictionary[x.Value].CompareTo(Dictionary[y.Value]);
		}
	}

	private struct IntContainer<T> where T : struct
	{
		public T Value { get; set; }
	}

	private readonly List<int> _islandCache;

	private readonly List<IntContainer<int>> _islandSortCache;

	private readonly DictionaryValueComparer _comparer;

	private bool _isDirty;

	public FilterIslandSortCache(List<int> island)
	{
		_islandCache = new List<int>(island);
		_comparer = new DictionaryValueComparer(new Dictionary<int, float>(island.Count));
		_islandSortCache = new List<IntContainer<int>>(island.Count);
		foreach (int item in island)
		{
			_islandSortCache.Add(new IntContainer<int>
			{
				Value = item
			});
		}
		_isDirty = true;
	}

	public void MarkDirty()
	{
		_isDirty = true;
	}

	public List<int> GetAllIslandId()
	{
		return _islandCache;
	}

	public List<int> GetSortedIslandId()
	{
		if (_isDirty)
		{
			SortIslandByDistanceToFlagShip();
			UpdateCache();
			_isDirty = false;
		}
		return _islandCache;
	}

	private void UpdateCache()
	{
		for (int i = 0; i < _islandSortCache.Count; i++)
		{
			_islandCache[i] = _islandSortCache[i].Value;
		}
	}

	private void SortIslandByDistanceToFlagShip()
	{
		RecalculateDistance(_comparer.Dictionary, _islandSortCache);
		_islandSortCache.Sort(_comparer.Compare);
	}

	private static void RecalculateDistance(Dictionary<int, float> floatValueCache, List<IntContainer<int>> intList)
	{
		foreach (IntContainer<int> @int in intList)
		{
			floatValueCache[@int.Value] = CalculateManhattanDistance(@int.Value);
		}
	}

	private static float CalculateManhattanDistance(int islandId)
	{
		Vec2 pos2D = WorldMapConfigHelper.Configs.TryGetIsland(islandId).Pos2D;
		int stayIslandId = Singleton<WorldStateManager>.Instance.GetOurFlagShip().StayIslandId;
		Vec2 pos2D2 = WorldMapConfigHelper.Configs.TryGetIsland(stayIslandId).Pos2D;
		return PositionHelper.ManhattanDistance(pos2D, pos2D2);
	}
}
