using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEBreakthroughDataLoader
{
	public static Dictionary<string, GDEBreakthroughData> Load(DataContainer dataContainer)
	{
		GDEBreakthroughData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEBreakthroughData>();
		}
		Dictionary<string, GDEBreakthroughData> dictionary = new Dictionary<string, GDEBreakthroughData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEBreakthroughData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
