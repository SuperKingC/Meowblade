using System.Collections.Generic;

namespace GameDataEditor;

public static class GDERegionDataLoader
{
	public static Dictionary<string, GDERegionData> Load(DataContainer dataContainer)
	{
		GDERegionData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDERegionData>();
		}
		Dictionary<string, GDERegionData> dictionary = new Dictionary<string, GDERegionData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDERegionData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
