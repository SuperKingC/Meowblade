using System.Collections.Generic;

namespace GameDataEditor;

public static class GDELegendItemChangePropsCostDataLoader
{
	public static Dictionary<string, GDELegendItemChangePropsCostData> Load(DataContainer dataContainer)
	{
		GDELegendItemChangePropsCostData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDELegendItemChangePropsCostData>();
		}
		Dictionary<string, GDELegendItemChangePropsCostData> dictionary = new Dictionary<string, GDELegendItemChangePropsCostData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDELegendItemChangePropsCostData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
