using System;
using System.Collections.Generic;

public class Dijkstra
{
	private class ShotestNode<T>
	{
		public T NodeId;

		public decimal Dist;

		public ShotestNode(T _node, decimal dist)
		{
			NodeId = _node;
			Dist = dist;
		}
	}

	private static T minDistance<T>(Dictionary<T, ShotestNode<T>> dist, Dictionary<T, bool> sptSet)
	{
		decimal num = decimal.MaxValue;
		T result = default(T);
		foreach (KeyValuePair<T, ShotestNode<T>> item in dist)
		{
			if (!sptSet[item.Key] && item.Value.Dist < num)
			{
				num = item.Value.Dist;
				result = item.Key;
			}
		}
		return result;
	}

	private static List<T> GetRoute<T>(T dest, Dictionary<T, ShotestNode<T>> min_dist)
	{
		List<T> list = new List<T> { dest };
		ShotestNode<T> shotestNode = min_dist[dest];
		while (shotestNode.NodeId != null)
		{
			list.Add(shotestNode.NodeId);
			shotestNode = min_dist[shotestNode.NodeId];
		}
		list.Reverse();
		return list;
	}

	public static bool CalcPath<T>(Dictionary<T, Dictionary<T, decimal>> graph, T src, T dest, out decimal dist, out List<T> route)
	{
		route = null;
		dist = -1m;
		if (!graph.ContainsKey(src))
		{
			Console.WriteLine($"src={src} not in graph!");
			return false;
		}
		if (!graph.ContainsKey(dest))
		{
			Console.WriteLine($"dest={dest} not in graph!");
			return false;
		}
		if (src.Equals(dest))
		{
			Console.WriteLine($"src={src} Equals dest={dest}");
			return false;
		}
		Dictionary<T, ShotestNode<T>> dictionary = new Dictionary<T, ShotestNode<T>>();
		Dictionary<T, bool> dictionary2 = new Dictionary<T, bool>();
		foreach (T key2 in graph.Keys)
		{
			dictionary.Add(key2, new ShotestNode<T>(default(T), decimal.MaxValue));
			dictionary2.Add(key2, value: false);
		}
		dictionary[src].Dist = default(decimal);
		for (int i = 0; i < graph.Count - 1; i++)
		{
			T val = minDistance(dictionary, dictionary2);
			dictionary2[val] = true;
			foreach (KeyValuePair<T, bool> item in dictionary2)
			{
				T key = item.Key;
				if (!item.Value && graph[val][key] > 0m && dictionary[val].Dist != decimal.MaxValue && dictionary[val].Dist + graph[val][key] < dictionary[key].Dist)
				{
					dictionary[key].NodeId = val;
					dictionary[key].Dist = dictionary[val].Dist + graph[val][key];
				}
			}
		}
		route = GetRoute(dest, dictionary);
		dist = dictionary[dest].Dist;
		return true;
	}
}
