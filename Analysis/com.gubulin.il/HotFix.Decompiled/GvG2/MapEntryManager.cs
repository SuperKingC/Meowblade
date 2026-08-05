using System.Collections.Generic;
using GvG2.Common.Models;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;

namespace GvG2;

public class MapEntryManager
{
	private Transform BlackMask;

	private Transform Hole;

	private GameObject Container;

	private MapDataManager MapDataManager;

	private bool IsHoleHidden;

	public bool IsInitHighLightHidden;

	public MapEntryManager(GameObject GvGWorldMap, MapDataManager mapDataManager)
	{
		IsInitHighLightHidden = true;
		BlackMask = GvGWorldMap.transform.Find("BlackMask");
		((Component)BlackMask).gameObject.SetActive(false);
		IsHoleHidden = false;
		MapDataManager = mapDataManager;
	}

	public void HighlightIsland(List<int> islandIdList)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)Container != (Object)null)
		{
			Object.Destroy((Object)(object)Container);
		}
		((Component)BlackMask).gameObject.SetActive(true);
		SpriteRenderer componentInChildren = ((Component)BlackMask).GetComponentInChildren<SpriteRenderer>();
		componentInChildren.color = new Color(0f, 0f, 0f, 0.5f);
		Transform transform = new GameObject("container").transform;
		transform.SetParent(((Component)BlackMask).transform.parent, false);
		transform.localPosition = Vector3.zero;
		Container = ((Component)transform).gameObject;
		foreach (int islandId in islandIdList)
		{
			Island islandById = MapDataManager.GetIslandById($"{islandId}");
			RenderIsland(islandById, transform);
		}
	}

	public void HideHighlight()
	{
		IsInitHighLightHidden = true;
		((Component)BlackMask).gameObject.SetActive(false);
		if (!((Object)(object)Container == (Object)null))
		{
			Object.Destroy((Object)(object)Container);
		}
	}

	public void ShowBlackMask()
	{
		((Component)BlackMask).gameObject.SetActive(true);
	}

	public void ShowHoleAt(Island myCamp)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		if (!IsHoleHidden)
		{
			IsInitHighLightHidden = false;
			Hole = Addressables.InstantiateAsync((object)"GvG/BlackMaskHole", (Transform)null, false, true).WaitForCompletion().transform;
			Hole.SetParent(BlackMask, false);
			Hole.localPosition = myCamp.IslandObject.transform.localPosition;
			((Component)Hole).gameObject.SetActive(true);
			GvGWorldMapController.Instance.SetDragEnable(flag: false);
			MapDataManager.ShowCampIslandOnly(myCamp);
		}
	}

	public void HideMaskAndHole()
	{
		IsHoleHidden = true;
		((Component)BlackMask).gameObject.SetActive(false);
		if ((Object)(object)Hole != (Object)null && (Object)(object)((Component)Hole).gameObject != (Object)null)
		{
			((Component)Hole).gameObject.SetActive(false);
			Object.Destroy((Object)(object)((Component)Hole).gameObject);
		}
		GvGWorldMapController.Instance.SetDragEnable(flag: true);
		MapDataManager.ShowAllIsland();
	}

	private void RenderIsland(Island island, Transform container)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		string text = "GvG2/" + island.Props.Sprite;
		GameObject val = Addressables.InstantiateAsync((object)text, (Transform)null, false, true).WaitForCompletion();
		((Object)val).name = "IslandPlane";
		val.transform.parent = container;
		Transform transform = val.transform;
		transform.localPosition = new Vector3(island.Props.X, 0f, island.Props.Z);
		transform.localScale = new Vector3(island.Props.S, transform.localScale.y, island.Props.S);
		transform.localRotation = Quaternion.AngleAxis(island.Props.Ang_Model, Vector3.up);
		SortingGroup val2 = val.AddComponent<SortingGroup>();
		val2.sortingLayerName = "UI";
		val2.sortingOrder = 2;
		island.IslandStateManager.Render(val);
		((Component)transform.Find("plane/ui/island_state")).GetComponent<SortingGroup>().sortingLayerName = "UI";
		GameObject val3 = GvGWorldMapController.Instance.InstantiateFromPrefab("highlight");
		val3.transform.SetParent(container, false);
		val3.transform.localPosition = transform.localPosition;
		Transform val4 = transform.Find("plane");
		Transform trans = val4.Find("name");
		GvGHelper.SetOutlineText(trans, island.Name);
	}
}
