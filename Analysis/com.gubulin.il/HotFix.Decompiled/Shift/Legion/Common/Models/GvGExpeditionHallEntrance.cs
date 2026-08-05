using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class GvGExpeditionHallEntrance : Building
{
	public object Controller;

	public GvGExpeditionHallEntrance(GameManagers managers)
		: base(managers, "7")
	{
	}
}
