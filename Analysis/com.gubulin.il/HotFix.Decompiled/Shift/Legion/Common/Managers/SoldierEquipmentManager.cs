using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem.Models;
using Shift.Legion.Common.Models.LegendItem;

namespace Shift.Legion.Common.Managers;

public class SoldierEquipmentManager : Manager
{
	public SoldiersEquippedItems SoldiersEquippedItems { get; set; }

	public SoldierEquipmentManager(GameManagers managers)
		: base(managers)
	{
		SoldiersEquippedItems = new SoldiersEquippedItems();
	}

	public long[] GetSoldierEquippedItems(string soldierId)
	{
		if (SoldiersEquippedItems == null)
		{
			throw new NullReferenceException("请先从服务器获取所有兵种身上装备的物品数据");
		}
		if (SoldiersEquippedItems.Value.TryGetValue(soldierId, out var value))
		{
			return value;
		}
		return new long[3];
	}

	public List<LegendItem> GetSoldierEquippedItemInstances(string soldierId)
	{
		List<LegendItem> list = new List<LegendItem>();
		foreach (string key in LegendItemsHelper.EquippedLegendItems.Keys)
		{
			if (LegendItemsHelper.EquippedLegendItems[key] != soldierId)
			{
				continue;
			}
			long num = long.Parse(key);
			if (num <= 0)
			{
				continue;
			}
			LegendItemUi legendItemUi = LegendItemsHelper.GetLegendItemUi(num);
			if (legendItemUi != null)
			{
				LegendItem legendItemData = legendItemUi.LegendItemData;
				if (legendItemData != null)
				{
					list.Add(legendItemData);
				}
			}
		}
		return list;
	}

	public void SetSoldierEquippedItems(string soldierId, long[] items)
	{
		if (SoldiersEquippedItems == null)
		{
			throw new NullReferenceException("请先从服务器获取所有兵种身上装备的物品数据");
		}
		if (SoldiersEquippedItems.Value == null)
		{
			SoldiersEquippedItems.Value = new Dictionary<string, long[]>();
		}
		SoldiersEquippedItems.Value[soldierId] = items;
	}
}
