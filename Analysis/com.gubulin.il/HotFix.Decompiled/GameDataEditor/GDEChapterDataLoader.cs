using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEChapterDataLoader
{
	public static Dictionary<string, GDEChapterData> Load(DataContainer dataContainer)
	{
		GDEChapterData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEChapterData>();
		}
		Dictionary<string, GDEChapterData> dictionary = new Dictionary<string, GDEChapterData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEChapterData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
