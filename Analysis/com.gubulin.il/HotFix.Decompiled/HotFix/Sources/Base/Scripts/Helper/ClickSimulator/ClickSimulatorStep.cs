using System.Collections;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public abstract class ClickSimulatorStep
{
	protected float waitingGap = 1.5f;

	public ClickSimulatorStep NextStep;

	public virtual IEnumerator Execute()
	{
		return null;
	}
}
