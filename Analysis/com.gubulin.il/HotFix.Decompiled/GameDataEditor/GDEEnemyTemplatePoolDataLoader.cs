using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEEnemyTemplatePoolDataLoader
{
	public static Dictionary<string, GDEEnemyTemplatePoolData> Load(DataContainer dataContainer)
	{
		GDEEnemyTemplatePoolData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEEnemyTemplatePoolData>();
		}
		Dictionary<string, GDEEnemyTemplatePoolData> dictionary = new Dictionary<string, GDEEnemyTemplatePoolData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEEnemyTemplatePoolData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
