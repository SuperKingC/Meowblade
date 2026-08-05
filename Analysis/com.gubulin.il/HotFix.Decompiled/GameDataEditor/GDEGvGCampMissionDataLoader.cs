using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEGvGCampMissionDataLoader
{
	public static Dictionary<string, GDEGvGCampMissionData> Load(DataContainer dataContainer)
	{
		GDEGvGCampMissionData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEGvGCampMissionData>();
		}
		Dictionary<string, GDEGvGCampMissionData> dictionary = new Dictionary<string, GDEGvGCampMissionData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEGvGCampMissionData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
