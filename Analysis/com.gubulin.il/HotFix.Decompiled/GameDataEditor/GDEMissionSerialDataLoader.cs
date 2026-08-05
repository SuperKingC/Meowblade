using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEMissionSerialDataLoader
{
	public static Dictionary<string, GDEMissionSerialData> Load(DataContainer dataContainer)
	{
		GDEMissionSerialData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEMissionSerialData>();
		}
		Dictionary<string, GDEMissionSerialData> dictionary = new Dictionary<string, GDEMissionSerialData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEMissionSerialData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
