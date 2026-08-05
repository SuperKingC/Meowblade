using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;

public class HiddenIslandManager
{
	public class LineInfo
	{
		public GameObject GO;

		public HashSet<int> HiddenNodes;
	}

	private Transform LinesTrans;

	private Dictionary<int, List<LineInfo>> IslandConnectedLines;

	public HiddenIslandManager(GameObject worldMap)
	{
		IslandConnectedLines = new Dictionary<int, List<LineInfo>>();
		Dictionary<string, LineInfo> dictionary = new Dictionary<string, LineInfo>();
		LinesTrans = worldMap.transform.Find("Lines");
		List<IslandConfigData> list = new List<IslandConfigData>();
		list.AddRange(WorldMapConfigHelper.Configs.HiddenIslands);
		list.AddRange(WorldMapConfigHelper.Configs.SpecialSuppressIslands);
		foreach (IslandConfigData item in list)
		{
			int id = item.Props.Id;
			List<int> conn = item.Props.Conn;
			List<LineInfo> list2 = new List<LineInfo>();
			IslandConnectedLines.Add(id, list2);
			foreach (int item2 in conn)
			{
				int num = id;
				int num2 = item2;
				if (id > item2)
				{
					num = item2;
					num2 = id;
				}
				string text = $"{num}_{num2}";
				if (!dictionary.TryGetValue(text, out var value))
				{
					value = new LineInfo
					{
						GO = ((Component)LinesTrans.Find(text)).gameObject,
						HiddenNodes = new HashSet<int>()
					};
					dictionary.Add(text, value);
				}
				value.HiddenNodes.Add(id);
				list2.Add(value);
			}
		}
		foreach (LineInfo value2 in dictionary.Values)
		{
			value2.GO.SetActive(false);
		}
		RegisterEvents();
	}

	public void OnDestroy()
	{
		UnregisterEvents();
	}

	private void RegisterEvents()
	{
		SharedMessenger.AddListener<int>("ON_GVG3_HideIslandLine", HideIslandLine);
		SharedMessenger.AddListener<int>("ON_GVG3_ShowIslandLine", ShowIslandLine);
	}

	private void UnregisterEvents()
	{
		SharedMessenger.RemoveListener<int>("ON_GVG3_HideIslandLine", HideIslandLine);
		SharedMessenger.RemoveListener<int>("ON_GVG3_ShowIslandLine", ShowIslandLine);
	}

	private void HideIslandLine(int hiddenIslandId)
	{
		SetIslandLineActive(hiddenIslandId, isActive: false);
	}

	private void ShowIslandLine(int hiddenIslandId)
	{
		SetIslandLineActive(hiddenIslandId, isActive: true);
	}

	private void SetIslandLineActive(int hiddenIslandId, bool isActive)
	{
		if (!IslandConnectedLines.TryGetValue(hiddenIslandId, out var value))
		{
			return;
		}
		foreach (LineInfo item in value)
		{
			if (isActive)
			{
				item.HiddenNodes.Remove(hiddenIslandId);
			}
			else
			{
				item.HiddenNodes.Add(hiddenIslandId);
			}
			item.GO.SetActive(item.HiddenNodes.Count == 0);
		}
	}
}
