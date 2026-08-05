using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEPrizePoolComboDataLoader
{
	public static Dictionary<string, GDEPrizePoolComboData> Load(DataContainer dataContainer)
	{
		GDEPrizePoolComboData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEPrizePoolComboData>();
		}
		Dictionary<string, GDEPrizePoolComboData> dictionary = new Dictionary<string, GDEPrizePoolComboData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEPrizePoolComboData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
