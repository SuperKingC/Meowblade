using System;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.IslandOperations;

public class IslandOperationCondition : IConditionInfo
{
	protected readonly Func<bool> ConditionCheck;

	protected Action ExtraAction;

	protected const string JUMP = "Jump";

	public Func<string> ConditionDescription { get; }

	public IslandOperationCondition(Func<bool> conditionCheck, Func<string> conditionDescription = null)
	{
		ConditionCheck = conditionCheck ?? throw new NullReferenceException("IslandOperationCondition conditionCheck is null");
		ConditionDescription = conditionDescription;
	}

	public bool CheckCondition()
	{
		return ConditionCheck();
	}

	public virtual bool BelongToOperation(string action)
	{
		return true;
	}

	public virtual void ShowConfirmationDialog(Action onConfirm, Action onCancel)
	{
		string tipText = ConditionDescription?.Invoke();
		tipText.ToConfirmPopup(ConfirmAction, onCancel, (AlignType)0);
		void ConfirmAction()
		{
			onConfirm?.Invoke();
			ExtraAction?.Invoke();
		}
	}

	public void AddExtraAction(Action extraAction)
	{
		ExtraAction = extraAction;
	}
}
