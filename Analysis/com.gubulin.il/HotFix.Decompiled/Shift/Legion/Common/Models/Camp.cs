using System.Collections.Generic;
using System.Linq;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class Camp : Building
{
	public object Controller;

	public override int Slot
	{
		get
		{
			return base.Slot;
		}
		set
		{
			Managers.UserArchiveManager.UnlockCampSlot(value);
		}
	}

	public List<string> ProducingConfig => Managers.UserArchiveManager.GetCampProducingQueue().Values.ToList();

	public Camp(GameManagers managers)
		: base(managers, "10")
	{
	}
}
