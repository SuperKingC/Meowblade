using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEFormationDataLoader
{
	public static Dictionary<string, GDEFormationData> Load(DataContainer dataContainer)
	{
		GDEFormationData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEFormationData>();
		}
		Dictionary<string, GDEFormationData> dictionary = new Dictionary<string, GDEFormationData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEFormationData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
