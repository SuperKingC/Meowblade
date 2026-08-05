using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Enum;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Filters;

public class ReachableCondition : BaseIslandFilterCondition
{
	public ReachableCondition(IslandFilterConditionType type)
		: base(type)
	{
	}

	public override bool CheckFilterCondition(IslandStateModel model)
	{
		return !Singleton<WorldStateManager>.Instance.Data.UnreachableIslands.Contains(model.IslandId);
	}
}
