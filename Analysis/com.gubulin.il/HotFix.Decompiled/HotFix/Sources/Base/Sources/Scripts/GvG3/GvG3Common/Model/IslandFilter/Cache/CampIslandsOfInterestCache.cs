using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Cache;

public class CampIslandsOfInterestCache
{
	private readonly HashSet<int> _campIslandsOfInterest = new HashSet<int>();

	public bool DirtyFlag { get; private set; }

	public CampIslandsOfInterestCache(IEnumerable<int> islands)
	{
		_campIslandsOfInterest.UnionWith(islands);
		DirtyFlag = false;
	}

	public bool IslandIsCampInterest(int islandId)
	{
		return _campIslandsOfInterest.Contains(islandId);
	}

	public void UpdateIslandsOfInterest(List<int> islands)
	{
		if (islands == null)
		{
			islands = new List<int>();
		}
		_campIslandsOfInterest.Clear();
		_campIslandsOfInterest.UnionWith(islands);
		DirtyFlag = false;
	}

	public void OnCampFlagshipIoiChange()
	{
		DirtyFlag = true;
	}
}
