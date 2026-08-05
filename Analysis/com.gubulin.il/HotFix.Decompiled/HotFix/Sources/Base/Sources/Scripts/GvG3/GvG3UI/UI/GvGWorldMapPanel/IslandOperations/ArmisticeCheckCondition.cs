using System;
using System.Collections.Generic;
using Shift.Legion.Common.Services;
using UI.GvGWorldMap3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.IslandOperations;

public class ArmisticeCheckCondition : IslandOperationCondition
{
	public ArmisticeCheckCondition(Func<bool> conditionCheck)
		: base(conditionCheck)
	{
	}

	public override bool BelongToOperation(string action)
	{
		if (action == "Jump")
		{
			return false;
		}
		return action == "Attack";
	}

	public override void ShowConfirmationDialog(Action onConfirm, Action onCancel)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_com_Armistice.Name, new Dictionary<string, object> { { "ConfirmAction", onCancel } });
	}
}
