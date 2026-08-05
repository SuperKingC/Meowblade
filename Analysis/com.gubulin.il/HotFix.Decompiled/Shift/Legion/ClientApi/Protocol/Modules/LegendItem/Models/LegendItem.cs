using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Modules.Inventory.Models;

namespace Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;

[ProtoContract]
public class LegendItem
{
	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.Inventory.Models.InventoryItem")]
	public InventoryItem Item;

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItemData")]
	public LegendItemData ItemData;

	public string Base64ItemData;

	public long InstanceId
	{
		get
		{
			return Item.InstanceId;
		}
		set
		{
			Item.InstanceId = value;
		}
	}

	public string ItemId => Item.ItemId;

	public long Qty
	{
		get
		{
			return Item.Qty;
		}
		set
		{
			Item.Qty = value;
		}
	}

	public int Score
	{
		get
		{
			return Item.Score;
		}
		set
		{
			Item.Score = value;
		}
	}

	public float CombatPowerModifier
	{
		get
		{
			return Item.CombatPowerModifier;
		}
		set
		{
			Item.CombatPowerModifier = value;
		}
	}

	public bool Locked
	{
		get
		{
			return ItemData.Locked;
		}
		set
		{
			ItemData.Locked = value;
		}
	}

	public int EnhanceExp
	{
		get
		{
			return ItemData.EnhanceExp;
		}
		set
		{
			ItemData.EnhanceExp = value;
		}
	}

	public int EnhanceLevel
	{
		get
		{
			return ItemData.EnhanceLevel;
		}
		set
		{
			ItemData.EnhanceLevel = value;
		}
	}

	public List<ItemEntry> MainEntries => ItemData.MainEntries;

	public List<ItemEntry> SubEntries => ItemData.SubEntries;

	public List<ItemEntry> FxEntries => ItemData.FxEntries;

	public List<ItemEntry> AlterMainEntries => ItemData.AlterMainEntries;

	public List<FxEntryGroup> AlterFxEntries => ItemData.AlterFxEntries;

	public int TotalChangePropertyCnt
	{
		get
		{
			int num = 0;
			foreach (ItemEntry mainEntry in MainEntries)
			{
				num += mainEntry.ChangeCnt;
			}
			foreach (ItemEntry subEntry in SubEntries)
			{
				num += subEntry.ChangeCnt;
			}
			foreach (ItemEntry fxEntry in FxEntries)
			{
				num += fxEntry.ChangeCnt;
			}
			return num;
		}
	}

	public int ReforgeCnt
	{
		get
		{
			return ItemData.ReforgeCnt;
		}
		set
		{
			ItemData.ReforgeCnt = value;
		}
	}

	public int TotalReforgeLockCnt
	{
		get
		{
			int num = 0;
			foreach (ItemEntry mainEntry in MainEntries)
			{
				num += mainEntry.ReforgeLockCnt;
			}
			foreach (ItemEntry subEntry in SubEntries)
			{
				num += subEntry.ReforgeLockCnt;
			}
			foreach (ItemEntry fxEntry in FxEntries)
			{
				num += fxEntry.ReforgeLockCnt;
			}
			return num;
		}
	}
}
