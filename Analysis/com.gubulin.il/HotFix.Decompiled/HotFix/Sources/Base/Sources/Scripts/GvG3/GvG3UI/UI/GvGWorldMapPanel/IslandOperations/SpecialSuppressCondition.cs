using System;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.IslandOperations;

public class SpecialSuppressCondition : IslandOperationCondition
{
	public SpecialSuppressCondition(Func<bool> conditionCheck, Func<string> conditionDescription = null)
		: base(conditionCheck, conditionDescription)
	{
	}

	public override bool BelongToOperation(string action)
	{
		if (action == "Jump")
		{
			return false;
		}
		eIslandAction eIslandAction = (eIslandAction)Enum.Parse(typeof(eIslandAction), action);
		return eIslandAction == eIslandAction.Attack || eIslandAction == eIslandAction.SuppressRebellion;
	}
}
