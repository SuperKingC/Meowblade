namespace UI.LegendItems;

public class LegendItemsPanelInfo
{
	public LegendItemsShowType showType;

	public long itemId;

	public string soldierId;

	public int slotIndex;

	public int FromShipEntityId;

	public LegendItemsPanelInfo(LegendItemsShowType type, long itemId = -1L, string soldierId = "", int slotIndex = -1, int fromShipEntityId = -1)
	{
		showType = type;
		this.itemId = itemId;
		this.soldierId = soldierId;
		this.slotIndex = slotIndex;
		FromShipEntityId = fromShipEntityId;
	}

	public void ClearInfo()
	{
		itemId = -1L;
		soldierId = "";
		slotIndex = -1;
		FromShipEntityId = -1;
	}
}
