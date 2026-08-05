using System.Collections.Generic;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Sources.Enums;

namespace HotFix.Sources.Base.Scripts.Helper;

public static class DictionaryExtensions
{
	public static Dictionary<K, int> TryAddValue<K>(this Dictionary<K, int> dict, Dictionary<K, int> dictB)
	{
		if (dictB == null)
		{
			return dict;
		}
		foreach (KeyValuePair<K, int> item in dictB)
		{
			dict.TryAddValue(item.Key, item.Value);
		}
		return dict;
	}

	public static Dictionary<K, double> TryAddValue<K>(this Dictionary<K, double> dict, Dictionary<K, double> dictB)
	{
		if (dictB == null)
		{
			return dict;
		}
		foreach (KeyValuePair<K, double> item in dictB)
		{
			dict.TryAddValue(item.Key, item.Value);
		}
		return dict;
	}

	public static Dictionary<K, float> TryAddValue<K>(this Dictionary<K, float> dict, Dictionary<K, float> dictB)
	{
		if (dictB == null)
		{
			return dict;
		}
		foreach (KeyValuePair<K, float> item in dictB)
		{
			dict.TryAddValue(item.Key, item.Value);
		}
		return dict;
	}

	public static Dictionary<K, decimal> TryAddValue<K>(this Dictionary<K, decimal> dict, Dictionary<K, decimal> dictB)
	{
		if (dictB == null)
		{
			return dict;
		}
		foreach (KeyValuePair<K, decimal> item in dictB)
		{
			dict.TryAddValue(item.Key, item.Value);
		}
		return dict;
	}

	public static Dictionary<K, long> TryAddValue<K>(this Dictionary<K, long> dict, Dictionary<K, long> dictB)
	{
		if (dictB == null)
		{
			return dict;
		}
		foreach (KeyValuePair<K, long> item in dictB)
		{
			dict.TryAddValue(item.Key, item.Value);
		}
		return dict;
	}

	public static void TryAddValue<K>(this Dictionary<K, int> dict, K key, int val)
	{
		if (dict.ContainsKey(key))
		{
			dict[key] += val;
		}
		else
		{
			dict.Add(key, val);
		}
	}

	public static void TryAddValue<K>(this Dictionary<K, double> dict, K key, double val)
	{
		if (dict.ContainsKey(key))
		{
			dict[key] += val;
		}
		else
		{
			dict.Add(key, val);
		}
	}

	public static void TryAddValue<K>(this Dictionary<K, float> dict, K key, float val)
	{
		if (dict.ContainsKey(key))
		{
			dict[key] += val;
		}
		else
		{
			dict.Add(key, val);
		}
	}

	public static void TryAddValue<K>(this Dictionary<K, decimal> dict, K key, decimal val)
	{
		if (dict.ContainsKey(key))
		{
			dict[key] += val;
		}
		else
		{
			dict.Add(key, val);
		}
	}

	public static void TryAddValue<K>(this Dictionary<K, long> dict, K key, long val)
	{
		if (dict.ContainsKey(key))
		{
			dict[key] += val;
		}
		else
		{
			dict.Add(key, val);
		}
	}

	public static KeyValuePair<K, V> First<K, V>(this Dictionary<K, V> dict)
	{
		using (Dictionary<K, V>.Enumerator enumerator = dict.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				return enumerator.Current;
			}
		}
		return default(KeyValuePair<K, V>);
	}

	public static StockChangeRecord[] ToStockChangeRecords(this Dictionary<string, int> dictionary, StockInContext context, string contextValue = "", int offsetMultiple = 1)
	{
		StockChangeRecord[] array = new StockChangeRecord[dictionary.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item in dictionary)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item.Key,
				Offset = item.Value * offsetMultiple,
				Context = (int)context,
				ContextValue = contextValue,
				Type = 1
			};
		}
		return array;
	}

	public static T ReadParamTalentFromParameters<T>(this Dictionary<string, object> parameters, string paramKey)
	{
		object value;
		return parameters.TryGetValue(paramKey, out value) ? ((T)value) : default(T);
	}
}
