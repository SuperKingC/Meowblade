using System;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.IslandOperations;

public class OnStarIslandSoldierCountCondition : IslandOperationCondition
{
	public OnStarIslandSoldierCountCondition(Func<bool> conditionCheck, Func<string> conditionDescription = null)
		: base(conditionCheck, conditionDescription)
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
		string tipText = base.ConditionDescription?.Invoke();
		tipText.ToConfirmPopup(ConfirmAction, onCancel, (AlignType)0);
		void ConfirmAction()
		{
			onCancel?.Invoke();
			ExtraAction?.Invoke();
		}
	}
}
