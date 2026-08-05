using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEMissionFrontEndOnlyDataLoader
{
	public static Dictionary<string, GDEMissionFrontEndOnlyData> Load(DataContainer dataContainer)
	{
		GDEMissionFrontEndOnlyData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEMissionFrontEndOnlyData>();
		}
		Dictionary<string, GDEMissionFrontEndOnlyData> dictionary = new Dictionary<string, GDEMissionFrontEndOnlyData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEMissionFrontEndOnlyData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
