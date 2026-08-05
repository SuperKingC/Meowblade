using System.Collections.Generic;

namespace GameDataEditor;

public static class GDELegendItemEnhancementDataLoader
{
	public static Dictionary<string, GDELegendItemEnhancementData> Load(DataContainer dataContainer)
	{
		GDELegendItemEnhancementData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDELegendItemEnhancementData>();
		}
		Dictionary<string, GDELegendItemEnhancementData> dictionary = new Dictionary<string, GDELegendItemEnhancementData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDELegendItemEnhancementData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
