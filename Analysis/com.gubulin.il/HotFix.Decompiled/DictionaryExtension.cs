using System.Collections.Generic;

public static class DictionaryExtension
{
	public static TValue TryGet<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
	{
		dict.TryGetValue(key, out var value);
		return value;
	}
}
