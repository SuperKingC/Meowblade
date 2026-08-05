using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

public static class MissionExtensions
{
	public static void GoToRelativeUi(this Mission mission)
	{
		if (!string.IsNullOrEmpty(mission.JumpContext))
		{
			Contexts.sharedInstance.Service<IUiService>().OpenPanel(mission.JumpContext, mission.JumpContextParams);
		}
	}
}
