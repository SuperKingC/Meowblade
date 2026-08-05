using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEActivityDataLoader
{
	public static Dictionary<string, GDEActivityData> Load(DataContainer dataContainer)
	{
		GDEActivityData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEActivityData>();
		}
		Dictionary<string, GDEActivityData> dictionary = new Dictionary<string, GDEActivityData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEActivityData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
