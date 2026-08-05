using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Enum;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Filters;

public interface IIslandFilterCondition
{
	IslandFilterConditionType Type { get; }

	bool CheckFilterCondition(IslandStateModel model);
}
