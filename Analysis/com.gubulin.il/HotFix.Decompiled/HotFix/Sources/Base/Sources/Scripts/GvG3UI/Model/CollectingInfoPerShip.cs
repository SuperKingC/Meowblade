using System.Collections.Generic;
using Shift.Legion.GvG.Common.Models.GvGMode3.Collecting;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class CollectingInfoPerShip
{
	public string ShipId;

	public int ShipTargetIslandId;

	public int WorkersOnboardCount;

	public List<CollectingStockModel> SelectedCollectingStockModels;

	public float IsladnObedienceValue;

	public void InitCollectingStockModel()
	{
		List<CollectingStockModel> selectedCollectingStockModels = SelectedCollectingStockModels;
		SelectedCollectingStockModels = new List<CollectingStockModel>();
		foreach (CollectingStockModel item in selectedCollectingStockModels)
		{
			if (item != null)
			{
				SelectedCollectingStockModels.Add(item);
			}
		}
	}
}
