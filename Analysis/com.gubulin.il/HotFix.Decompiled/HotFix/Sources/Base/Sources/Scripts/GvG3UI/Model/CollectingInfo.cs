using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class CollectingInfo
{
	public RealTimeStorehouseLimitParModel StorehouseLimitParModel;

	public List<CollectingItemInfo> ItemInfos { get; set; } = new List<CollectingItemInfo>();

	public List<CollectingInfoPerShip> ShipInfos { get; set; } = new List<CollectingInfoPerShip>();
}
