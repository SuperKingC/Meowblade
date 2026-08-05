using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.IslandFilter.Areas;

public class EverNightAreaFilterEffectiveCondition : BaseAreaEffectiveCondition
{
	private const int _EVER_NIGHT_PROGRESS = 6;

	public override bool CheckAreaEffective()
	{
		return Singleton<WorldStateManager>.Instance.Data.ProgressData.CampProgress == 6;
	}
}
