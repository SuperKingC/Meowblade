using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEAnimationDataLoader
{
	public static Dictionary<string, GDEAnimationData> Load(DataContainer dataContainer)
	{
		GDEAnimationData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEAnimationData>();
		}
		Dictionary<string, GDEAnimationData> dictionary = new Dictionary<string, GDEAnimationData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEAnimationData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
