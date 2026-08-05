using System;
using System.Collections.Generic;
using Shift.Legion.Common.Services;
using UI.GvGWorldMap3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.IslandOperations;

public class JumpUseOuterTechCondition : IslandOperationCondition
{
	public JumpUseOuterTechCondition(Func<bool> conditionCheck, Func<string> conditionDescription = null)
		: base(conditionCheck, conditionDescription)
	{
	}

	public override bool BelongToOperation(string action)
	{
		return action == "Jump";
	}

	public override void ShowConfirmationDialog(Action onConfirm, Action onCancel)
	{
		string value = ((base.ConditionDescription == null) ? string.Empty : base.ConditionDescription());
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_OuterTechI67502.Name, new Dictionary<string, object>
		{
			{ "ConfirmAction", onConfirm },
			{ "CancelAction", onCancel },
			{ "JumpCost", value }
		});
	}
}
