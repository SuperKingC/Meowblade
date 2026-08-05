using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

internal static class StorageHelper
{
	public static void DoStorageOffsetChanges<T>(Dictionary<T, int> storage, Dictionary<T, int> offsetChanges)
	{
		foreach (KeyValuePair<T, int> offsetChange in offsetChanges)
		{
			if (storage.ContainsKey(offsetChange.Key))
			{
				storage[offsetChange.Key] += offsetChange.Value;
			}
			else
			{
				storage.Add(offsetChange.Key, offsetChange.Value);
			}
		}
	}

	public static void DoStorageChanges_SyncCurValue<T>(Dictionary<T, int> storage, Dictionary<T, int> curValueChanges)
	{
		foreach (KeyValuePair<T, int> curValueChange in curValueChanges)
		{
			storage[curValueChange.Key] = curValueChange.Value;
		}
	}
}
