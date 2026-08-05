using System.Collections.Generic;

namespace GameDataEditor;

public static class GDESoldierPotentialDataLoader
{
	public static Dictionary<string, GDESoldierPotentialData> Load(DataContainer dataContainer)
	{
		GDESoldierPotentialData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDESoldierPotentialData>();
		}
		Dictionary<string, GDESoldierPotentialData> dictionary = new Dictionary<string, GDESoldierPotentialData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDESoldierPotentialData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
