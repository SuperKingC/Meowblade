using System.Collections;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class ClickSimulatorScript
{
	public ClickSimulatorStep CurrentStep;

	public string Marker;

	private const float waitingGap = 2f;

	public IEnumerator Run()
	{
		while (CurrentStep != null)
		{
			SentrySdk.AddBreadcrumb("[ClickSimulator]Execute " + CurrentStep.GetType().Name);
			yield return CurrentStep.Execute();
			yield return (object)new WaitForSeconds(2f);
			CurrentStep = CurrentStep.NextStep;
		}
		SharedMessenger.Broadcast("CLICK_SIMULATOR_ONCE_FINISH", Marker);
	}
}
