using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;

public static class List_Extension
{
	public static List<List<T>> Slice<T>(this List<T> list, int sliceSize)
	{
		List<List<T>> list2 = new List<List<T>>();
		for (int i = 0; i < list.Count; i += sliceSize)
		{
			int count = sliceSize;
			if (i + sliceSize > list.Count)
			{
				count = list.Count - i;
			}
			list2.Add(list.GetRange(i, count));
		}
		return list2;
	}
}
