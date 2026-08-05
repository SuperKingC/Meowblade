using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEProjectileDataLoader
{
	public static Dictionary<string, GDEProjectileData> Load(DataContainer dataContainer)
	{
		GDEProjectileData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEProjectileData>();
		}
		Dictionary<string, GDEProjectileData> dictionary = new Dictionary<string, GDEProjectileData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEProjectileData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
