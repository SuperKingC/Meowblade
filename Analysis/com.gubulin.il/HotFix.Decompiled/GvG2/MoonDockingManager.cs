using System.Collections;
using System.Collections.Generic;
using GvG2.Common.Models;
using UnityEngine;
using UnityEngine.Rendering;

namespace GvG2;

public class MoonDockingManager : DockingManagerBase
{
	public class Slot
	{
		public Vector3 Pos;

		public Ship Ship;

		public GameObject SlotObj;
	}

	public class SlotCounter
	{
		public int Count;

		public GameObject CounterObj;
	}

	private static bool IsStaticInit;

	private static Dictionary<int, SpawnAreaRect> SpawnArea;

	private static Dictionary<int, CampCounterPosV3> CampCounterPos;

	private static int CurUserId;

	private Island Island;

	public Dictionary<int, Slot> Slots;

	public Dictionary<int, SlotCounter> Counters;

	private Transform Container;

	public MoonDockingManager(Island parentIsland)
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		Island = parentIsland;
		Slots = new Dictionary<int, Slot>();
		Counters = new Dictionary<int, SlotCounter>();
		if (!IsStaticInit)
		{
			IsStaticInit = true;
			CurUserId = GameController.Contexts.gameState.user.value.UserId;
			float num = 0.235f;
			float num2 = -1.322f + num;
			float num3 = 1.322f - num;
			float num4 = 1.464f - num;
			float num5 = -1.164f + num;
			float num6 = (num3 - num2) / 2f;
			float num7 = (num4 - num5) / 2f;
			Rect rect = default(Rect);
			((Rect)(ref rect))._002Ector(num2, num4 - num7, num6, num7);
			Rect rect2 = default(Rect);
			((Rect)(ref rect2))._002Ector(num3 - num6, num4 - num7, num6, num7);
			Rect rect3 = default(Rect);
			((Rect)(ref rect3))._002Ector(num2, num5, num6, num7);
			Rect rect4 = default(Rect);
			((Rect)(ref rect4))._002Ector(num3 - num6, num5, num6, num7);
			SpawnArea = new Dictionary<int, SpawnAreaRect>
			{
				{
					1,
					new SpawnAreaRect
					{
						rect = rect
					}
				},
				{
					2,
					new SpawnAreaRect
					{
						rect = rect2
					}
				},
				{
					3,
					new SpawnAreaRect
					{
						rect = rect4
					}
				},
				{
					4,
					new SpawnAreaRect
					{
						rect = rect3
					}
				}
			};
			Vector3 v = default(Vector3);
			((Vector3)(ref v))._002Ector(-0.972f, 0f, 1.054f);
			Vector3 v2 = default(Vector3);
			((Vector3)(ref v2))._002Ector(0.972f, 0f, 1.054f);
			Vector3 v3 = default(Vector3);
			((Vector3)(ref v3))._002Ector(-0.972f, 0f, -0.754f);
			Vector3 v4 = default(Vector3);
			((Vector3)(ref v4))._002Ector(0.972f, 0f, -0.754f);
			CampCounterPos = new Dictionary<int, CampCounterPosV3>
			{
				{
					1,
					new CampCounterPosV3
					{
						V3 = v
					}
				},
				{
					2,
					new CampCounterPosV3
					{
						V3 = v2
					}
				},
				{
					3,
					new CampCounterPosV3
					{
						V3 = v4
					}
				},
				{
					4,
					new CampCounterPosV3
					{
						V3 = v3
					}
				}
			};
		}
	}

	private void RenderSlot(Slot slot)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		Ship ship = slot.Ship;
		string name = DockingManagerBase.CampSlotPrefab[ship.Props.CampId];
		GameObject slotObj = GvGWorldMapController.Instance.InstantiateFromPrefab(name);
		slotObj.SetActive(true);
		slotObj.transform.SetParent(Container, false);
		slotObj.transform.localPosition = slot.Pos;
		slot.SlotObj = slotObj;
		SpriteRenderer portrait = ((Component)slotObj.transform.Find("portrait")).GetComponent<SpriteRenderer>();
		portrait.sprite = GvGWorldMapController.Instance.DefaultAvatarSprite;
		AvatarHelper.GetUserAvatarSprite($"{ship.Props.CampId}", ship.Props.UserId, delegate(Sprite sprite)
		{
			if (!((Object)(object)slotObj == (Object)null))
			{
				portrait.sprite = sprite;
			}
		});
	}

	public override void RenderSlots()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		Transform transform = Island.IslandPlane.transform;
		Container = new GameObject("slots").transform;
		Container.SetParent(transform, false);
		Container.localPosition = Vector3.zero;
		foreach (KeyValuePair<int, Slot> slot in Slots)
		{
			Slot value = slot.Value;
			RenderSlot(value);
			if (value.Ship.Props.UserId == CurUserId)
			{
				value.SlotObj.GetComponent<SortingGroup>().sortingOrder = 52;
			}
		}
		foreach (KeyValuePair<int, SlotCounter> counter in Counters)
		{
			RenderSlotCounter(counter.Key);
		}
	}

	public override void DockShip(Ship ship, bool isInit)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		if (!Slots.ContainsKey(ship.Props.Id))
		{
			Rect rect = SpawnArea[ship.Props.CampId].rect;
			float num = Random.Range(((Rect)(ref rect)).xMin, ((Rect)(ref rect)).xMax);
			float num2 = Random.Range(((Rect)(ref rect)).yMin, ((Rect)(ref rect)).yMax);
			Slot slot = new Slot
			{
				Ship = ship,
				Pos = new Vector3(num, 0f, num2)
			};
			Slots.Add(ship.Props.Id, slot);
			OnChangeShips?.Invoke();
			IncreaseCount(ship.Props.CampId);
			if ((Object)(object)Island.IslandPlane == (Object)null)
			{
				HideShip(ship);
				return;
			}
			RenderSlot(slot);
			SlotOrderToTop(slot);
			slot.SlotObj.SetActive(false);
			((MonoBehaviour)GvGWorldMapController.Instance).StartCoroutine(PlayDockAnim(slot));
		}
	}

	public override void UndockShip(Ship ship)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		if (!Slots.TryGetValue(ship.Props.Id, out var value))
		{
			ShowShip(ship);
			return;
		}
		Slots.Remove(ship.Props.Id);
		OnChangeShips?.Invoke();
		DecreaseCount(ship.Props.CampId);
		ship.ShipTrans.localPosition = Island.IslandObject.transform.localPosition;
		if ((Object)(object)Island.IslandPlane == (Object)null)
		{
			ShowShip(ship);
			return;
		}
		SlotOrderToTop(value);
		((MonoBehaviour)GvGWorldMapController.Instance).StartCoroutine(PlayUndockAnim(value));
	}

	public IEnumerator PlayDockAnim(Slot slot)
	{
		Ship ship = slot.Ship;
		((Component)ship.ShipTrans).GetComponent<Animation>().Play("ship_hide");
		yield return (object)new WaitForSeconds(0.3f);
		ship.ShipObj.SetActive(false);
		RenderSlotCounter(ship.Props.CampId);
		if (Counters.TryGetValue(ship.Props.CampId, out var counter) && (Object)(object)counter.CounterObj != (Object)null)
		{
			((Component)counter.CounterObj.transform).GetComponent<Animation>().Play("slot_counter_bounce");
		}
		if (!((Object)(object)slot.SlotObj == (Object)null))
		{
			Transform slotTrans = slot.SlotObj.transform;
			((Component)slotTrans).gameObject.SetActive(true);
			((Component)slotTrans).GetComponent<Animation>().Play("slot_show");
		}
	}

	public IEnumerator PlayUndockAnim(Slot slot)
	{
		RenderSlotCounter(slot.Ship.Props.CampId);
		if (Counters.TryGetValue(slot.Ship.Props.CampId, out var counter) && (Object)(object)counter.CounterObj != (Object)null)
		{
			((Component)counter.CounterObj.transform).GetComponent<Animation>().Play("slot_counter_bounce");
		}
		if (!((Object)(object)slot.SlotObj == (Object)null))
		{
			Transform slotTrans = slot.SlotObj.transform;
			((Component)slotTrans).GetComponent<Animation>().Play("slot_hide");
			yield return (object)new WaitForSeconds(0.3f);
			if (!((Object)(object)slot.SlotObj == (Object)null))
			{
				Object.Destroy((Object)(object)slot.SlotObj);
				Ship ship = slot.Ship;
				ship.ShipObj.SetActive(true);
				((Component)ship.ShipTrans).GetComponent<Animation>().Play("ship_show");
			}
		}
	}

	private void ShowShip(Ship ship)
	{
		ship.ShipObj.SetActive(true);
		((Component)ship.ShipTrans).GetComponent<Animation>().Play("ship_show");
	}

	private void HideShip(Ship ship)
	{
		ship.ShipObj.SetActive(false);
	}

	private void SlotOrderToTop(Slot targetSlot)
	{
		foreach (KeyValuePair<int, Slot> slot in Slots)
		{
			Slot value = slot.Value;
			if (value.Ship.Props.UserId == CurUserId)
			{
				value.SlotObj.GetComponent<SortingGroup>().sortingOrder = 52;
			}
			else if (targetSlot == value)
			{
				value.SlotObj.GetComponent<SortingGroup>().sortingOrder = 51;
			}
			else
			{
				targetSlot.SlotObj.GetComponent<SortingGroup>().sortingOrder = 50;
			}
		}
	}

	private void RenderSlotCounter(int campId)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)Island.IslandPlane == (Object)null)
		{
			return;
		}
		SlotCounter slotCounter = Counters[campId];
		if (slotCounter.Count > 0)
		{
			if ((Object)(object)slotCounter.CounterObj == (Object)null)
			{
				string name = DockingManagerBase.CampSlotCounterPrefab[campId];
				GameObject val = GvGWorldMapController.Instance.InstantiateFromPrefab(name);
				val.SetActive(true);
				val.transform.SetParent(Island.IslandPlane.transform, false);
				val.transform.localPosition = CampCounterPos[campId].V3;
				slotCounter.CounterObj = val;
			}
			GvGHelper.SetOutlineText(slotCounter.CounterObj.transform.Find("count"), $"{slotCounter.Count}");
		}
		else if ((Object)(object)slotCounter.CounterObj != (Object)null)
		{
			Object.Destroy((Object)(object)slotCounter.CounterObj);
		}
	}

	private void IncreaseCount(int campId)
	{
		if (!Counters.ContainsKey(campId))
		{
			Counters.Add(campId, new SlotCounter
			{
				Count = 0
			});
		}
		Counters[campId].Count++;
	}

	private void DecreaseCount(int campId)
	{
		if (!Counters.ContainsKey(campId) || Counters[campId].Count == 0)
		{
			ILRuntimeDebug.LogError($"岛上停泊的飞空艇个数不能少于0， 停泊点campId={campId}， 岛屿ID={Island.Id}");
		}
		Counters[campId].Count--;
	}

	public override bool HasMyShip()
	{
		int userId = GameController.Contexts.gameState.user.value.UserId;
		foreach (KeyValuePair<int, Slot> slot in Slots)
		{
			Ship ship = slot.Value.Ship;
			if (ship.Details.UserId == userId)
			{
				return true;
			}
		}
		return false;
	}

	public override List<Ship> GetDockingShips()
	{
		List<Ship> list = new List<Ship>();
		foreach (KeyValuePair<int, Slot> slot in Slots)
		{
			list.Add(slot.Value.Ship);
		}
		return list;
	}
}
