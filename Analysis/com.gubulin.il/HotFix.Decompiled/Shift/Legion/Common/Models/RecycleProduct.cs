using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class RecycleProduct
{
	public GDERecycleProductData Data;

	public string RecycleProductId;

	public int Weight;

	public float Time;

	public float Multiplier;

	public Dictionary<string, int> Productions;

	public Dictionary<string, int> Requirements;

	public string LevelFilter;

	public RecycleProduct(GDERecycleProductData data)
	{
		Data = data;
		RecycleProductId = data.Key;
		Weight = data.ProduceWeight;
		Time = data.Time;
		Multiplier = data.Multiplier;
		LevelFilter = data.LevelFilter;
		Productions = new Dictionary<string, int>();
		if (!string.IsNullOrEmpty(data.Production))
		{
			foreach (KeyValuePair<string, int> item in JsonHelper.ToObject<Dictionary<string, int>>(data.Production))
			{
				Productions.Add(item.Key, item.Value);
			}
		}
		Requirements = new Dictionary<string, int>();
		if (string.IsNullOrEmpty(data.Requirement))
		{
			return;
		}
		foreach (KeyValuePair<string, int> item2 in JsonHelper.ToObject<Dictionary<string, int>>(data.Requirement))
		{
			Requirements.Add(item2.Key, item2.Value);
		}
	}
}
