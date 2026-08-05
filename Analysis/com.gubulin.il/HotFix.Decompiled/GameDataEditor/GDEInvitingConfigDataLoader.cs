using System.Collections.Generic;

namespace GameDataEditor;

public static class GDEInvitingConfigDataLoader
{
	public static Dictionary<string, GDEInvitingConfigData> Load(DataContainer dataContainer)
	{
		GDEInvitingConfigData.DC = dataContainer;
		int num = dataContainer.DataMetaArray?.Count ?? 0;
		if (num == 0)
		{
			return new Dictionary<string, GDEInvitingConfigData>();
		}
		Dictionary<string, GDEInvitingConfigData> dictionary = new Dictionary<string, GDEInvitingConfigData>(num);
		foreach (KeyValuePair<string, List<int>> item in dataContainer.DataMetaArray)
		{
			List<int> value = item.Value;
			dictionary.Add(item.Key, new GDEInvitingConfigData(value[0], value[1], value[2], value[3], value[4], value[5], value[6]));
		}
		return dictionary;
	}
}
