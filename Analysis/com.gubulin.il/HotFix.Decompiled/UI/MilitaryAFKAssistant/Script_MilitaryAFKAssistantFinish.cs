using System;
using System.Collections;
using HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

namespace UI.MilitaryAFKAssistant;

public class Script_MilitaryAFKAssistantFinish : ClickSimulatorStep
{
	private Action FinishAction;

	public Script_MilitaryAFKAssistantFinish(Action action)
	{
		FinishAction = action;
	}

	public override IEnumerator Execute()
	{
		FinishAction();
		yield return null;
	}
}
