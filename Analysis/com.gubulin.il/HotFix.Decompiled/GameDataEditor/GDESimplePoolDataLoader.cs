using System.Collections.Generic;

namespace GameDataEditor;

public static class GDESimplePoolDataLoader
{
	public static Dictionary<string, GDESimplePoolData> Load(DataContainer dataContainer)
	{
		GDESimplePoolData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDESimplePoolData>();
		}
		Dictionary<string, GDESimplePoolData> dictionary = new Dictionary<string, GDESimplePoolData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDESimplePoolData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
