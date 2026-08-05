using System.Collections.Generic;

namespace GameDataEditor;

public static class GDERecycleProductDataLoader
{
	public static Dictionary<string, GDERecycleProductData> Load(DataContainer dataContainer)
	{
		GDERecycleProductData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDERecycleProductData>();
		}
		Dictionary<string, GDERecycleProductData> dictionary = new Dictionary<string, GDERecycleProductData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDERecycleProductData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
