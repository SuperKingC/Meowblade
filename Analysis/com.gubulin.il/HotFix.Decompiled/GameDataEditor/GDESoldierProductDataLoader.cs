using System.Collections.Generic;

namespace GameDataEditor;

public static class GDESoldierProductDataLoader
{
	public static Dictionary<string, GDESoldierProductData> Load(DataContainer dataContainer)
	{
		GDESoldierProductData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDESoldierProductData>();
		}
		Dictionary<string, GDESoldierProductData> dictionary = new Dictionary<string, GDESoldierProductData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDESoldierProductData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
