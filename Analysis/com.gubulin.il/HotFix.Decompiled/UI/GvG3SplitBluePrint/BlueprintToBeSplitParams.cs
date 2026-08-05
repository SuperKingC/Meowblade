using System;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;

namespace UI.GvG3SplitBluePrint;

public class BlueprintToBeSplitParams
{
	public Action<string> EnqueueAction { get; }

	public Action<string> DequeueAction { get; }

	public Blueprint Blueprint { get; private set; }

	public BlueprintOperationMode OperationMode { get; private set; }

	public BlueprintDialogType DialogType { get; }

	public bool OperationEnabled { get; private set; }

	public BlueprintToBeSplitParams(Action<string> enqueueAction, Action<string> dequeueAction, BlueprintDialogType dialogType)
	{
		EnqueueAction = enqueueAction;
		DequeueAction = dequeueAction;
		DialogType = dialogType;
	}

	public void UpdateParams(Blueprint blueprint, BlueprintOperationMode operationMode, bool enabled)
	{
		Blueprint = blueprint;
		OperationMode = operationMode;
		OperationEnabled = enabled;
	}
}
