using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEGvGIslandMapConfigDataLoader
{
	public static Dictionary<string, GDEGvGIslandMapConfigData> Load(DataContainer dataContainer)
	{
		GDEGvGIslandMapConfigData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEGvGIslandMapConfigData>();
		}
		Dictionary<string, GDEGvGIslandMapConfigData> dictionary = new Dictionary<string, GDEGvGIslandMapConfigData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEGvGIslandMapConfigData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
