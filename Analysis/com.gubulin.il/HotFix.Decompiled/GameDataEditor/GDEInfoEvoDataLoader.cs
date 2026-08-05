using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEInfoEvoDataLoader
{
	public static Dictionary<string, GDEInfoEvoData> Load(DataContainer dataContainer)
	{
		GDEInfoEvoData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEInfoEvoData>();
		}
		Dictionary<string, GDEInfoEvoData> dictionary = new Dictionary<string, GDEInfoEvoData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEInfoEvoData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
