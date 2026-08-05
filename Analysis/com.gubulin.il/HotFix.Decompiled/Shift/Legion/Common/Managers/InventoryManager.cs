using System.Collections.Generic;
using Shift.Legion.Common.Models.LegendItem;

namespace Shift.Legion.Common.Managers;

public class InventoryManager : Manager
{
	public Dictionary<long, LegendItem> LegendItems { get; set; } = new Dictionary<long, LegendItem>();

	public InventoryManager(GameManagers managers)
		: base(managers)
	{
	}

	public bool ReceiveLegendItem(LegendItem legendItem)
	{
		if (LegendItems.ContainsKey(legendItem.InstanceId))
		{
			return false;
		}
		LegendItems.Add(legendItem.InstanceId, legendItem);
		return true;
	}
}
