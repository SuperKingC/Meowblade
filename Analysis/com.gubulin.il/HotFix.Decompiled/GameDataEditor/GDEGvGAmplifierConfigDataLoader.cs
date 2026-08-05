using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEGvGAmplifierConfigDataLoader
{
	public static Dictionary<string, GDEGvGAmplifierConfigData> Load(DataContainer dataContainer)
	{
		GDEGvGAmplifierConfigData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEGvGAmplifierConfigData>();
		}
		Dictionary<string, GDEGvGAmplifierConfigData> dictionary = new Dictionary<string, GDEGvGAmplifierConfigData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEGvGAmplifierConfigData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
