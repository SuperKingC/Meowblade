using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Cache;

public interface IFilterIslandSortCache
{
	void MarkDirty();

	List<int> GetAllIslandId();

	List<int> GetSortedIslandId();
}
