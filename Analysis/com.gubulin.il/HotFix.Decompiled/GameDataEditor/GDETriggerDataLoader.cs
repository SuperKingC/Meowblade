using System.Collections.Generic;

namespace GameDataEditor;

public static class GDETriggerDataLoader
{
	public static Dictionary<string, GDETriggerData> Load(DataContainer dataContainer)
	{
		GDETriggerData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDETriggerData>();
		}
		Dictionary<string, GDETriggerData> dictionary = new Dictionary<string, GDETriggerData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDETriggerData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
