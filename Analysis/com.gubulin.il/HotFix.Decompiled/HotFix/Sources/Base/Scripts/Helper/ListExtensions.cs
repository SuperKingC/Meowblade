using System;
using System.Collections.Generic;
using System.Linq;
using Shift.Legion.Common.Interfaces;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Scripts.Helper;

public static class ListExtensions
{
	public static List<T> Clone<T>(this List<T> list) where T : new()
	{
		string json = JsonHelper.ToJson(list);
		return JsonHelper.ToObject<List<T>>(json);
	}

	public static bool AddDistinct<T>(this List<T> list, T input) where T : IId
	{
		if (list.Any((T _obj) => _obj.GetId() == input.GetId()))
		{
			return false;
		}
		list.Add(input);
		return true;
	}

	public static bool AddDistinct(this List<string> list, string input)
	{
		if (list.Any((string _obj) => _obj.Equals(input)))
		{
			return false;
		}
		list.Add(input);
		return true;
	}

	public static List<T> SkipItems<T>(this List<T> list, int count) where T : new()
	{
		if (list == null)
		{
			throw new ArgumentNullException("list", "List cannot be null.");
		}
		if (count <= 0)
		{
			return list;
		}
		if (count >= list.Count)
		{
			return new List<T>();
		}
		List<T> list2 = new List<T>();
		for (int i = count; i < list.Count; i++)
		{
			list2.Add(list[i]);
		}
		return list2;
	}

	public static void InsertionSort<T>(this IList<T> list, Comparison<T> comparison)
	{
		if (list == null)
		{
			throw new ArgumentNullException("list");
		}
		if (comparison == null)
		{
			throw new ArgumentNullException("comparison");
		}
		int count = list.Count;
		for (int i = 1; i < count; i++)
		{
			T val = list[i];
			int num = i - 1;
			while (num >= 0 && comparison(list[num], val) > 0)
			{
				list[num + 1] = list[num];
				num--;
			}
			list[num + 1] = val;
		}
	}
}
