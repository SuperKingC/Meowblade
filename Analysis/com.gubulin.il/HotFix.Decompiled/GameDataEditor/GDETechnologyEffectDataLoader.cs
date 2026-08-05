using System.Collections.Generic;

namespace GameDataEditor;

public static class GDETechnologyEffectDataLoader
{
	public static Dictionary<string, GDETechnologyEffectData> Load(DataContainer dataContainer)
	{
		GDETechnologyEffectData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDETechnologyEffectData>();
		}
		Dictionary<string, GDETechnologyEffectData> dictionary = new Dictionary<string, GDETechnologyEffectData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDETechnologyEffectData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
