using System.Collections.Generic;

namespace GameDataEditor;

public static class GDELanguagesDataLoader
{
	public static Dictionary<string, GDELanguagesData> Load(DataContainer dataContainer)
	{
		GDELanguagesData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDELanguagesData>();
		}
		Dictionary<string, GDELanguagesData> dictionary = new Dictionary<string, GDELanguagesData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDELanguagesData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
