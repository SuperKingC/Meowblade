using System;
using Assets.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using UI.LegendItems;

namespace UI.LegendItemInfo;

public class LegendItemInfoDialogInfo
{
	public LegendItemUi Item;

	public string SoldierId;

	public int SlotIndex;

	public int TypeIndex;

	public LegendItemsHelper.BlackMarketLegendItem ItemData;

	public LegendItemBrief ItemBrief;

	public int ForgeLegendItemType;

	public bool CanChangeLockState;

	public LegendItemsShowType ShowType;

	public int FromShipEntityId;

	public bool IsPreviewMode;

	public Action CallbackForType8;

	public LegendItemInfoDialogInfo(LegendItemUi item, string soldierId = "", int slotIndex = -1, int typeIndex = 3, LegendItemsHelper.BlackMarketLegendItem itemData = null, LegendItemBrief itemBrief = null, int forgeLegendItemType = 0, bool canChangeLockState = false, LegendItemsShowType showType = LegendItemsShowType.Show, int fromShipEntityId = -1)
	{
		Item = item;
		SoldierId = soldierId;
		SlotIndex = slotIndex;
		TypeIndex = typeIndex;
		ItemData = itemData;
		ItemBrief = itemBrief;
		ForgeLegendItemType = forgeLegendItemType;
		CanChangeLockState = canChangeLockState;
		ShowType = showType;
		FromShipEntityId = fromShipEntityId;
	}

	public void ClearDialogInfo()
	{
		SlotIndex = -1;
		TypeIndex = 3;
		FromShipEntityId = -1;
		IsPreviewMode = false;
		CallbackForType8 = null;
	}
}
