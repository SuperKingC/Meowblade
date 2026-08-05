using System.Collections.Generic;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models.LegendItem;

namespace Assets.Scripts.UI;

public class LegendItemUi
{
	public long InstanceId;

	public string UniversalLegendItemId;

	public int UniversalLegendItemCount;

	public Shift.Legion.Common.Models.LegendItem.LegendItem LegendItemData;

	public List<int> ReforgeIndex;

	public LegendItemUi(string itemId, int count)
	{
		UniversalLegendItemId = itemId;
		UniversalLegendItemCount = count;
	}

	public LegendItemUi(long instanceId, Shift.Legion.Common.Models.LegendItem.LegendItem legendItemData)
	{
		InstanceId = instanceId;
		LegendItemData = legendItemData;
		ReforgeIndex = LegendItemsHelper.GetLegendItemLockSubEntriesIndex(InstanceId);
	}

	public void UpdateFromApiModel(Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem apiModel)
	{
		LegendItemData = new Shift.Legion.Common.Models.LegendItem.LegendItem(GameManagers.Instance, apiModel);
		InstanceId = apiModel.InstanceId;
		ReforgeIndex = LegendItemsHelper.GetLegendItemLockSubEntriesIndex(InstanceId);
	}
}
