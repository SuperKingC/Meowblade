using System.Collections.Generic;

namespace GameDataEditor;

public static class GDESoldierFormationDataLoader
{
	public static Dictionary<string, GDESoldierFormationData> Load(DataContainer dataContainer)
	{
		GDESoldierFormationData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDESoldierFormationData>();
		}
		Dictionary<string, GDESoldierFormationData> dictionary = new Dictionary<string, GDESoldierFormationData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDESoldierFormationData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
