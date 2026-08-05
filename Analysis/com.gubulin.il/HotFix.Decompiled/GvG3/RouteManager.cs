using System.Linq;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using UnityEngine;

namespace GvG3;

public class RouteManager
{
	public Transform GvGWorldMapTrans;

	private Transform BlackMask;

	public Transform Canvas;

	private GameObject Container;

	private int[] Route;

	public RouteManager(GameObject _GvGWorldMap)
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		GvGWorldMapTrans = _GvGWorldMap.transform;
		BlackMask = GvGWorldMapTrans.Find("BlackMask");
		Canvas = BlackMask.Find("Canvas");
		((Component)BlackMask).gameObject.SetActive(false);
		SpriteRenderer componentInChildren = ((Component)BlackMask).GetComponentInChildren<SpriteRenderer>();
		componentInChildren.color = new Color(0f, 0f, 0f, 0.67f);
	}

	public void ShowRoute(int[] route)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		IslandOnTop_HideOldRoute(Route, route);
		Route = route;
		if ((Object)(object)Container != (Object)null)
		{
			Object.Destroy((Object)(object)Container);
		}
		((Component)BlackMask).gameObject.SetActive(true);
		Transform transform = new GameObject("container").transform;
		transform.SetParent(GvGWorldMapTrans, false);
		transform.localPosition = Vector3.zero;
		Container = ((Component)transform).gameObject;
		for (int i = 0; i < route.Length; i++)
		{
			int num = i + 1;
			if (num < route.Length)
			{
				NavLineConfigData line = WorldMapConfigHelper.Configs.TryGetNavLine(route[i], route[i + 1]);
				RenderLine(line, transform);
			}
			IslandConfigData island = WorldMapConfigHelper.Configs.TryGetIsland(route[i]);
			ShowIslandOnTop(route[i], isOnTop: true);
			if (num == route.Length)
			{
				RenderSelector(island, transform);
			}
		}
	}

	private void IslandOnTop_HideOldRoute(int[] oldRoute, int[] newRoute)
	{
		if (oldRoute == null || newRoute == null)
		{
			return;
		}
		for (int i = 0; i < oldRoute.Length; i++)
		{
			if (!newRoute.Contains(oldRoute[i]))
			{
				ShowIslandOnTop(oldRoute[i], isOnTop: false);
			}
		}
	}

	public void ShowNullRoute(int startIsland, int endIsland, bool displaySelector = true)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		((Component)BlackMask).gameObject.SetActive(true);
		int[] array = new int[2] { startIsland, endIsland };
		IslandOnTop_HideOldRoute(Route, array);
		if ((Object)(object)Container != (Object)null)
		{
			Object.Destroy((Object)(object)Container);
		}
		Route = array;
		Transform transform = new GameObject("container").transform;
		transform.SetParent(GvGWorldMapTrans, false);
		transform.localPosition = Vector3.zero;
		Container = ((Component)transform).gameObject;
		for (int i = 0; i < Route.Length; i++)
		{
			IslandConfigData island = WorldMapConfigHelper.Configs.TryGetIsland(Route[i]);
			ShowIslandOnTop(Route[i], isOnTop: true);
			if (displaySelector && i == Route.Length - 1)
			{
				RenderSelector(island, transform);
			}
		}
	}

	public void EraseRoute()
	{
		((Component)BlackMask).gameObject.SetActive(false);
		if (!((Object)(object)Container == (Object)null))
		{
			Object.Destroy((Object)(object)Container);
			for (int i = 0; i < Route.Length; i++)
			{
				ShowIslandOnTop(Route[i], isOnTop: false);
			}
		}
	}

	private void RenderLine(NavLineConfigData line, Transform container)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		Transform transform = GvGWorldMapController.Instance.InstantiateFromPrefab("anim_line").transform;
		transform.SetParent(container, false);
		((Component)transform).gameObject.SetActive(true);
		transform.localPosition = line.Start;
		transform.localScale = line.Scale;
		transform.localRotation = line.Rotation;
	}

	private void ShowIslandOnTop(int islandId, bool isOnTop)
	{
		Singleton<WorldStateManager>.Instance.TryGetIsland(islandId).ShowOnTop(isOnTop);
	}

	private void RenderSelector(IslandConfigData island, Transform container)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		Transform transform = GvGWorldMapController.Instance.InstantiateFromPrefab("selector").transform;
		transform.SetParent(container, false);
		((Component)transform).gameObject.SetActive(true);
		transform.localPosition = island.Position;
	}

	public void UpdateCamPos(Vector3 globalPos)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		((Component)BlackMask).transform.position = globalPos;
	}

	public void OnCamSizeChange(float val)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		Canvas.localScale = new Vector3(val * 2f, 1f, val * 2f);
	}
}
