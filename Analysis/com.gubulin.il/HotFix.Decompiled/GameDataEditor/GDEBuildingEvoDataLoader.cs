using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEBuildingEvoDataLoader
{
	public static Dictionary<string, GDEBuildingEvoData> Load(DataContainer dataContainer)
	{
		GDEBuildingEvoData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEBuildingEvoData>();
		}
		Dictionary<string, GDEBuildingEvoData> dictionary = new Dictionary<string, GDEBuildingEvoData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEBuildingEvoData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
