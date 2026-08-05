using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEStrongholdDataLoader
{
	public static Dictionary<string, GDEStrongholdData> Load(DataContainer dataContainer)
	{
		GDEStrongholdData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEStrongholdData>();
		}
		Dictionary<string, GDEStrongholdData> dictionary = new Dictionary<string, GDEStrongholdData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEStrongholdData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
