using System.Collections.Generic;
using GvG2.Common.Models;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;

namespace GvG2;

public class RouteManager
{
	public class RouteInfo
	{
		public float TraveTime;

		public float Length;

		public List<int> Route;
	}

	private Transform BlackMask;

	private GameObject Container;

	private MapDataManager MapDataManager;

	public RouteInfo SelectedRoute;

	public RouteManager(GameObject GvGWorldMap, MapDataManager mapDataManager)
	{
		BlackMask = GvGWorldMap.transform.Find("BlackMask");
		((Component)BlackMask).gameObject.SetActive(false);
		MapDataManager = mapDataManager;
	}

	public RouteInfo GetRouteInfo(string fromIsland, string toIsland)
	{
		Island islandById = MapDataManager.GetIslandById(fromIsland);
		Island islandById2 = MapDataManager.GetIslandById(toIsland);
		List<int> route = GetRoute(islandById.Props, islandById2.Props);
		float num = 0f;
		for (int i = 0; i < route.Count - 1; i++)
		{
			num += MapDataManager.GetNavLine(route[i], route[i + 1]).Len;
		}
		return new RouteInfo
		{
			TraveTime = num / 0.641f,
			Length = num,
			Route = route
		};
	}

	public void ShowRoute(string fromIsland, string toIsland)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)Container != (Object)null)
		{
			Object.Destroy((Object)(object)Container);
		}
		((Component)BlackMask).gameObject.SetActive(true);
		SpriteRenderer componentInChildren = ((Component)BlackMask).GetComponentInChildren<SpriteRenderer>();
		componentInChildren.color = new Color(0f, 0f, 0f, 0.8f);
		Transform transform = new GameObject("container").transform;
		transform.SetParent(((Component)BlackMask).transform.parent, false);
		transform.localPosition = Vector3.zero;
		Container = ((Component)transform).gameObject;
		Island islandById = MapDataManager.GetIslandById(fromIsland);
		Island islandById2 = MapDataManager.GetIslandById(toIsland);
		List<int> route = GetRoute(islandById.Props, islandById2.Props);
		float num = 0f;
		for (int i = 0; i < route.Count; i++)
		{
			int num2 = i + 1;
			if (num2 < route.Count)
			{
				NavLineProps navLine = MapDataManager.GetNavLine(route[i], route[num2]);
				num += navLine.Len;
				RenderLine(navLine, transform);
			}
			Island islandById3 = MapDataManager.GetIslandById($"{route[i]}");
			RenderIsland(islandById3, transform);
			if (num2 == route.Count)
			{
				RenderSelector(islandById3, transform);
			}
		}
		SelectedRoute = new RouteInfo
		{
			TraveTime = num / 0.641f,
			Length = num,
			Route = route
		};
	}

	public void HideRoute()
	{
		((Component)BlackMask).gameObject.SetActive(false);
		if (!((Object)(object)Container == (Object)null))
		{
			Object.Destroy((Object)(object)Container);
		}
	}

	private void RenderSelector(Island island, Transform container)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		Transform transform = GvGWorldMapController.Instance.InstantiateFromPrefab("selector").transform;
		transform.SetParent(container, false);
		((Component)transform).gameObject.SetActive(true);
		transform.localPosition = island.IslandObject.transform.localPosition;
	}

	private void RenderLine(NavLineProps line, Transform container)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		Transform transform = GvGWorldMapController.Instance.InstantiateFromPrefab("anim_line").transform;
		transform.SetParent(container, false);
		((Component)transform).gameObject.SetActive(true);
		transform.localPosition = line.Start;
		transform.localScale = new Vector3(line.Len, 1f, 1f);
		transform.localRotation = Quaternion.FromToRotation(Vector3.right, line.Dir);
	}

	private void RenderIsland(Island island, Transform container)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		string text = "GvG2/" + island.Props.Sprite;
		GameObject val = Addressables.InstantiateAsync((object)text, (Transform)null, false, true).WaitForCompletion();
		((Object)val).name = "IslandPlane";
		val.transform.SetParent(container, false);
		Transform transform = val.transform;
		transform.localPosition = new Vector3(island.Props.X, 0f, island.Props.Z);
		transform.localScale = new Vector3(island.Props.S, transform.localScale.y, island.Props.S);
		transform.localRotation = Quaternion.AngleAxis(island.Props.Ang_Model, Vector3.up);
		SortingGroup val2 = val.AddComponent<SortingGroup>();
		val2.sortingLayerName = "UI";
		val2.sortingOrder = 2;
		Transform val3 = transform.Find("plane");
		Transform trans = val3.Find("name");
		GvGHelper.SetOutlineText(trans, island.Name);
	}

	public List<int> GetRoute(IslandProps from, IslandProps to)
	{
		Dictionary<IslandProps, Dictionary<IslandProps, decimal>> graph = GenerateDijkstraGraph();
		if (!Dijkstra.CalcPath(graph, from, to, out var _, out var route))
		{
			return new List<int>();
		}
		List<int> list = new List<int>();
		foreach (IslandProps item in route)
		{
			list.Add(item.Id);
		}
		return list;
	}

	public static Dictionary<IslandProps, Dictionary<IslandProps, decimal>> GenerateDijkstraGraph()
	{
		Dictionary<string, IslandProps> islands_Dict = MapDataManager.WorldMapData.Islands_Dict;
		Dictionary<string, NavLineProps> navLine_Dict = MapDataManager.WorldMapData.NavLine_Dict;
		Dictionary<IslandProps, Dictionary<IslandProps, decimal>> dictionary = new Dictionary<IslandProps, Dictionary<IslandProps, decimal>>();
		foreach (IslandProps value3 in islands_Dict.Values)
		{
			Dictionary<IslandProps, decimal> dictionary2 = new Dictionary<IslandProps, decimal>();
			foreach (IslandProps value4 in islands_Dict.Values)
			{
				if (value3.Id == value4.Id)
				{
					dictionary2.Add(value4, 0m);
					continue;
				}
				decimal value = -1m;
				if (navLine_Dict.TryGetValue($"{value3.Id}_{value4.Id}", out var value2))
				{
					value = (decimal)(value2.Len * 1000f);
				}
				dictionary2.Add(value4, value);
			}
			dictionary.Add(value3, dictionary2);
		}
		return dictionary;
	}
}
