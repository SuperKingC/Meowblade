using System;
using System.Collections.Generic;
using Shift.Legion.Helpers;

namespace Shift.Legion.Rank.Helpers;

public static class RandomHelper
{
	private static Random random = new Random();

	private static Random randomUserId;

	public static List<T> Choose<T>(this List<T> list, int n)
	{
		for (int num = list.Count - 1; num >= 0; num--)
		{
			int index = random.Next(0, num + 1);
			T value = list[index];
			list[index] = list[num];
			list[num] = value;
		}
		List<T> list2 = new List<T>();
		for (int i = 0; i < n && i < list.Count; i++)
		{
			list2.Add(list[i]);
		}
		return list2;
	}

	public static List<T> Clone<T>(this List<T> list) where T : new()
	{
		string json = JsonHelper.ToJson(list);
		return JsonHelper.ToObject<List<T>>(json);
	}

	public static void Shuffle<T>(this T[] items)
	{
		for (int i = 0; i < items.Length - 1; i++)
		{
			int num = random.Next(i, items.Length);
			T val = items[i];
			items[i] = items[num];
			items[num] = val;
		}
	}

	public static void Shuffle<T>(this IList<T> items)
	{
		for (int i = 0; i < items.Count - 1; i++)
		{
			int index = random.Next(i, items.Count);
			T value = items[i];
			items[i] = items[index];
			items[index] = value;
		}
	}
}
