using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEFormationUnlockDataLoader
{
	public static Dictionary<string, GDEFormationUnlockData> Load(DataContainer dataContainer)
	{
		GDEFormationUnlockData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEFormationUnlockData>();
		}
		Dictionary<string, GDEFormationUnlockData> dictionary = new Dictionary<string, GDEFormationUnlockData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEFormationUnlockData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
