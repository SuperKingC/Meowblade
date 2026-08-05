using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.Modules.Inventory.Models;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models.LegendItem;

public class LegendItem
{
	public long InstanceId;

	public GDELegendItemData Data;

	public string ItemId;

	public int EnhanceLevel;

	public int TotalGainedExp;

	public readonly List<ItemEntry> MainEntries;

	public readonly List<ItemEntry> SubEntries;

	public readonly List<ItemEntry> FxEntries;

	public readonly List<ItemEntry> AlterMainEntries;

	public readonly List<FxEntryGroup> AlterFxEntries;

	public bool Locked;

	public int Score;

	public float CombatPowerModifier;

	public string SetAlias;

	public LegendItemEnhancementConfig EnhancementConfig => LegendItemEnhancementConfig.GetEnhanceConfig(Data.EnhanceConfig, EnhanceLevel);

	public int UnlockedSubEntries => EnhancementConfig?.UnlockedSubEntries ?? 1;

	public LegendItem(GameManagers managers, Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem apiModel)
	{
		InstanceId = apiModel.InstanceId;
		string key = (ItemId = apiModel.ItemId);
		Data = LegendItemManager.LegendItemTemplates[key];
		MainEntries = apiModel.MainEntries;
		SubEntries = apiModel.SubEntries;
		FxEntries = apiModel.FxEntries;
		AlterMainEntries = apiModel.AlterMainEntries;
		AlterFxEntries = apiModel.AlterFxEntries;
		EnhanceLevel = apiModel.EnhanceLevel;
		TotalGainedExp = apiModel.EnhanceExp;
		Locked = apiModel.Locked;
		Score = apiModel.Score;
		CombatPowerModifier = apiModel.CombatPowerModifier;
		SetAlias = apiModel.ItemData.SetAlias;
	}

	public LegendItem(GameManagers managers, LegendItemData legendItemData, InventoryItem inventoryItem)
	{
		InstanceId = inventoryItem.InstanceId;
		string key = (ItemId = inventoryItem.ItemId);
		Data = LegendItemManager.LegendItemTemplates[key];
		MainEntries = legendItemData.MainEntries;
		SubEntries = legendItemData.SubEntries;
		FxEntries = legendItemData.FxEntries;
		Locked = legendItemData.Locked;
		Score = inventoryItem.Score;
		CombatPowerModifier = inventoryItem.CombatPowerModifier;
		SetAlias = legendItemData.SetAlias;
	}

	public bool Enhance(GameManagers managers)
	{
		if (!CanEnhance(managers))
		{
			return false;
		}
		ConsumeEnhance(managers);
		return true;
	}

	public bool ConsumeEnhance(GameManagers managers)
	{
		return true;
	}

	public bool CanEnhance(GameManagers managers)
	{
		if (!LegendItemManager.LegendItemEnhancementDataDict.TryGetValue(Data.Key, out var value) || !value.TryGetValue(EnhanceLevel + 1, out var _))
		{
			return false;
		}
		return true;
	}

	public bool ConfirmEnhance(GameManagers managers)
	{
		return true;
	}
}
