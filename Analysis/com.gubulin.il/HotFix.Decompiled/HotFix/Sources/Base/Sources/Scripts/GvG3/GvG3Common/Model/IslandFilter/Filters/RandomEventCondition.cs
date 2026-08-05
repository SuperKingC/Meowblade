using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Enum;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Filters;

public class RandomEventCondition : BaseIslandFilterCondition
{
	public RandomEventCondition(IslandFilterConditionType type)
		: base(type)
	{
	}

	public override bool CheckFilterCondition(IslandStateModel model)
	{
		return model.RandomEventFilterIsValid();
	}
}
