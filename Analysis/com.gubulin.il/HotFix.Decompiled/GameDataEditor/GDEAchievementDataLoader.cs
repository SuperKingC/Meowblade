using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEAchievementDataLoader
{
	public static Dictionary<string, GDEAchievementData> Load(DataContainer dataContainer)
	{
		GDEAchievementData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEAchievementData>();
		}
		Dictionary<string, GDEAchievementData> dictionary = new Dictionary<string, GDEAchievementData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEAchievementData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
