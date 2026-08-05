using System;
using System.Collections;
using System.Collections.Generic;
using GvG2.Common.Models;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace GvG2;

public class GvGMapRenderManager
{
	public enum ColliderType
	{
		Island,
		NavLine
	}

	public class RectCollider
	{
		public string Id;

		public ColliderType Type;

		public Rect Rect;

		public Collider Collider;

		public bool IsVisible = false;

		public Island Island;

		public string LastSprite = "-";
	}

	private List<RectCollider> IslandColliders;

	private List<RectCollider> LineColliders;

	private Dictionary<string, RectCollider> RectColliders_Dict;

	private Vector2 ScreenRightTop;

	private Vector2 ScreenLeftBottom;

	private CoroutineQueue CoroutineQueue;

	public GvGMapRenderManager(MonoBehaviour parentController)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		IslandColliders = new List<RectCollider>();
		LineColliders = new List<RectCollider>();
		RectColliders_Dict = new Dictionary<string, RectCollider>();
		ScreenRightTop = new Vector2((float)Screen.width, (float)Screen.height);
		ScreenLeftBottom = Vector2.zero;
		CoroutineQueue = new CoroutineQueue(parentController);
	}

	public void AddNewCollider(string id, Collider collider, Island island = null)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		((Object)collider).name = id;
		Vector3 localScale = ((Component)collider).transform.localScale;
		Vector3 localPosition = island.IslandObject.transform.localPosition;
		Rect rect = default(Rect);
		((Rect)(ref rect))._002Ector(localPosition.x - localScale.x * 0.5f, localPosition.z - localScale.z * 0.5f, localScale.x, localScale.z);
		RectCollider rectCollider = new RectCollider
		{
			Id = id,
			Type = ((!(((Object)((Component)collider).transform.parent.parent).name == "Islands")) ? ColliderType.NavLine : ColliderType.Island),
			Rect = rect,
			Collider = collider,
			Island = island
		};
		if (rectCollider.Type == ColliderType.Island)
		{
			IslandColliders.Add(rectCollider);
		}
		else
		{
			LineColliders.Add(rectCollider);
		}
		RectColliders_Dict.Add(id, rectCollider);
	}

	private Vec2 GetScreenToFloorPos(Vector2 screenPos)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		Ray val = Camera.main.ScreenPointToRay(Vector2.op_Implicit(screenPos));
		Vector3 direction = ((Ray)(ref val)).direction;
		Vector3 normalized = ((Vector3)(ref direction)).normalized;
		Vector3 val2 = normalized * (((Ray)(ref val)).origin.y / Mathf.Abs(normalized.y)) + ((Ray)(ref val)).origin;
		return new Vec2(val2.x, val2.z);
	}

	private IEnumerator LoadIsland(RectCollider islandCollider)
	{
		yield return null;
		Island island = islandCollider.Island;
		IslandProps props = island.Props;
		if (islandCollider.IsVisible)
		{
			if ((Object)(object)island.IslandPlane != (Object)null)
			{
				if (islandCollider.LastSprite == props.Sprite)
				{
					yield break;
				}
				Object.Destroy((Object)(object)island.IslandPlane);
				yield return null;
			}
			string aa_key = "GvG2/" + props.Sprite;
			IList<IResourceLocation> loc = Addressables.LoadResourceLocationsAsync((object)aa_key, (Type)null).WaitForCompletion();
			if (loc.Count == 0)
			{
				island.IslandPlane = GameObject.CreatePrimitive((PrimitiveType)3);
				island.IslandPlane.transform.localScale = new Vector3(1f, 0.1f, 1f);
				Object.Destroy((Object)(object)island.IslandPlane.GetComponent<BoxCollider>());
			}
			else
			{
				island.IslandPlane = Addressables.InstantiateAsync((object)aa_key, (Transform)null, false, true).WaitForCompletion();
			}
			((Object)island.IslandPlane).name = "IslandPlane";
			island.IslandPlane.transform.parent = island.IslandObject.transform;
			island.RenderIslandPlane();
			islandCollider.LastSprite = props.Sprite;
		}
		else if ((Object)(object)island.IslandPlane != (Object)null)
		{
			Object.Destroy((Object)(object)island.IslandPlane);
		}
	}

	private IEnumerator LoadLine(RectCollider lineCollider)
	{
		yield return null;
	}

	public void UpdateCheckVisibleObjects()
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		Vec2 screenToFloorPos = GetScreenToFloorPos(ScreenLeftBottom);
		Vec2 screenToFloorPos2 = GetScreenToFloorPos(ScreenRightTop);
		Rect val = Rect.MinMaxRect(screenToFloorPos.x, screenToFloorPos.y, screenToFloorPos2.x, screenToFloorPos2.y);
		foreach (RectCollider islandCollider in IslandColliders)
		{
			bool flag = ((Rect)(ref val)).Overlaps(islandCollider.Rect);
			if (flag != islandCollider.IsVisible)
			{
				islandCollider.IsVisible = flag;
				CoroutineQueue.AddCoroutine(LoadIsland(islandCollider));
			}
		}
	}
}
