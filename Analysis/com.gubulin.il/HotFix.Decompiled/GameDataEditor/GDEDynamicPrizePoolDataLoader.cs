using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEDynamicPrizePoolDataLoader
{
	public static Dictionary<string, GDEDynamicPrizePoolData> Load(DataContainer dataContainer)
	{
		GDEDynamicPrizePoolData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEDynamicPrizePoolData>();
		}
		Dictionary<string, GDEDynamicPrizePoolData> dictionary = new Dictionary<string, GDEDynamicPrizePoolData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEDynamicPrizePoolData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
