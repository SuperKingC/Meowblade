using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEMapFXDataLoader
{
	public static Dictionary<string, GDEMapFXData> Load(DataContainer dataContainer)
	{
		GDEMapFXData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEMapFXData>();
		}
		Dictionary<string, GDEMapFXData> dictionary = new Dictionary<string, GDEMapFXData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEMapFXData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
