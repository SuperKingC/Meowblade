using System.Collections.Generic;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.GvG.Common.Models;

public static class RItemExtensions
{
	public static Dictionary<string, int> ToDict(this List<RItem> list)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		if (list != null)
		{
			foreach (RItem item in list)
			{
				dictionary.Add(item.ItemId, item.cnt);
			}
		}
		return dictionary;
	}

	public static List<RItem> ToRItemList(this Dictionary<string, int> dict)
	{
		List<RItem> list = new List<RItem>();
		if (dict != null)
		{
			foreach (KeyValuePair<string, int> item in dict)
			{
				list.Add(new RItem
				{
					ItemId = item.Key,
					cnt = item.Value
				});
			}
		}
		return list;
	}

	public static List<RItem> ToRItemList(this Dictionary<string, int> dict, int multiple = 1)
	{
		List<RItem> list = new List<RItem>();
		if (dict != null)
		{
			foreach (KeyValuePair<string, int> item in dict)
			{
				list.Add(new RItem
				{
					ItemId = item.Key,
					cnt = item.Value * multiple
				});
			}
		}
		return list;
	}

	public static Dictionary<int, int> ToDict(this List<RItemInt> list)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		if (list != null)
		{
			foreach (RItemInt item in list)
			{
				dictionary.Add(item.ItemId, item.cnt);
			}
		}
		return dictionary;
	}

	public static List<RItemInt> ToRItemList(this Dictionary<int, int> dict)
	{
		List<RItemInt> list = new List<RItemInt>();
		if (dict != null)
		{
			foreach (KeyValuePair<int, int> item in dict)
			{
				list.Add(new RItemInt
				{
					ItemId = item.Key,
					cnt = item.Value
				});
			}
		}
		return list;
	}

	public static StockChangeRecord[] ToStockChangeRecords(this List<RItem> rItems, StockInContext context, string contextValue = "", int offsetMultiple = 1)
	{
		StockChangeRecord[] array = new StockChangeRecord[rItems.Count];
		int num = 0;
		foreach (RItem rItem in rItems)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = rItem.ItemId,
				Offset = rItem.cnt * offsetMultiple,
				Context = (int)context,
				ContextValue = contextValue,
				Type = 1
			};
		}
		return array;
	}
}
