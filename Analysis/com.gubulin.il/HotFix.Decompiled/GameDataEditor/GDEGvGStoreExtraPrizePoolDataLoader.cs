using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEGvGStoreExtraPrizePoolDataLoader
{
	public static Dictionary<string, GDEGvGStoreExtraPrizePoolData> Load(DataContainer dataContainer)
	{
		GDEGvGStoreExtraPrizePoolData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEGvGStoreExtraPrizePoolData>();
		}
		Dictionary<string, GDEGvGStoreExtraPrizePoolData> dictionary = new Dictionary<string, GDEGvGStoreExtraPrizePoolData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEGvGStoreExtraPrizePoolData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
