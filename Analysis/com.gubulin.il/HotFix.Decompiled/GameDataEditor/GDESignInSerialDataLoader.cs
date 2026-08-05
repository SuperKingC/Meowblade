using System.Collections.Generic;

namespace GameDataEditor;

public static class GDESignInSerialDataLoader
{
	public static Dictionary<string, GDESignInSerialData> Load(DataContainer dataContainer)
	{
		GDESignInSerialData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDESignInSerialData>();
		}
		Dictionary<string, GDESignInSerialData> dictionary = new Dictionary<string, GDESignInSerialData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDESignInSerialData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
