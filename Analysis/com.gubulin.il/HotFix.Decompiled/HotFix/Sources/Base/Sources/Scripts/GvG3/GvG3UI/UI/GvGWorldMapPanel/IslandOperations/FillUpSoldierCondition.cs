using System;
using System.Collections.Generic;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.GvGWorldMap3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.IslandOperations;

public class FillUpSoldierCondition : IslandOperationCondition
{
	public FillUpSoldierCondition(Func<bool> conditionCheck)
		: base(conditionCheck)
	{
	}

	public override bool BelongToOperation(string action)
	{
		if (action == "Jump")
		{
			return true;
		}
		eIslandAction eIslandAction = (eIslandAction)Enum.Parse(typeof(eIslandAction), action);
		return eIslandAction == eIslandAction.GoTo || eIslandAction == eIslandAction.Attack || eIslandAction == eIslandAction.SuppressRebellion || eIslandAction == eIslandAction.Collect || eIslandAction == eIslandAction.FillUpSoldier;
	}

	public override void ShowConfirmationDialog(Action onConfirm, Action onCancel)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_FillUpConfirm.Name, new Dictionary<string, object>
		{
			{ "LeaveAction", onConfirm },
			{
				"FillUpAction",
				new Action(FillUpAction)
			}
		});
		void FillUpAction()
		{
			onCancel?.Invoke();
			ExtraAction?.Invoke();
		}
	}
}
