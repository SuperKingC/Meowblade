using System;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGWorldMapPanel.IslandOperations;

public interface IConditionInfo
{
	Func<string> ConditionDescription { get; }

	bool CheckCondition();

	bool BelongToOperation(string action);

	void ShowConfirmationDialog(Action onConfirm, Action onCancel);
}
