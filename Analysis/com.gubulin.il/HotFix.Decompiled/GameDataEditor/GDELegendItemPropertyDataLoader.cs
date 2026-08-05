using System.Collections.Generic;

namespace GameDataEditor;

public static class GDELegendItemPropertyDataLoader
{
	public static Dictionary<string, GDELegendItemPropertyData> Load(DataContainer dataContainer)
	{
		GDELegendItemPropertyData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDELegendItemPropertyData>();
		}
		Dictionary<string, GDELegendItemPropertyData> dictionary = new Dictionary<string, GDELegendItemPropertyData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDELegendItemPropertyData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
