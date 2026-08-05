using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Enum;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Filters;

public abstract class BaseIslandFilterCondition : IIslandFilterCondition
{
	public IslandFilterConditionType Type { get; }

	public abstract bool CheckFilterCondition(IslandStateModel model);

	protected BaseIslandFilterCondition(IslandFilterConditionType type)
	{
		Type = type;
	}
}
