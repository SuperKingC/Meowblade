using GameDataEditor;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Helper;

public static class StorehouseHelper
{
	public static bool IsGvGItem(string itemKey)
	{
		if (string.IsNullOrEmpty(itemKey))
		{
			return false;
		}
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemKey);
		if (gDEItemData == null)
		{
			return false;
		}
		ItemType itemType = (ItemType)gDEItemData.ItemType;
		return itemType >= ItemType.GvGServer_CollectingMaterial && itemType < ItemType.GvGServer_MAX;
	}

	public static bool IsGvGAmplifierFormulaItem(string itemKey)
	{
		ItemType itemType = (ItemType)GDMgr.Get<GDEItemData>(itemKey).ItemType;
		return itemType == ItemType.GvGServer_AmplifierFormula;
	}
}
