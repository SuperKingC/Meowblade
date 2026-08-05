using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEDecorativeObjectsDataLoader
{
	public static Dictionary<string, GDEDecorativeObjectsData> Load(DataContainer dataContainer)
	{
		GDEDecorativeObjectsData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEDecorativeObjectsData>();
		}
		Dictionary<string, GDEDecorativeObjectsData> dictionary = new Dictionary<string, GDEDecorativeObjectsData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEDecorativeObjectsData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
