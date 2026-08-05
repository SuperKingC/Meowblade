using System;
using System.Collections;
using System.Collections.Generic;
using GvG2.Common.Models;
using UnityEngine;

namespace GvG2;

public class CampDockingManager : DockingManagerBase
{
	private Island Island;

	public Ship[] Slots;

	private const int MAX_SLOTS = 10;

	public CampDockingManager(Island parentIsland)
	{
		Slots = new Ship[10];
		for (int i = 0; i < 10; i++)
		{
			Slots[i] = null;
		}
		Island = parentIsland;
	}

	private void RenderSlot(int index, Transform slotTrans)
	{
		Ship ship = Slots[index];
		GameObject slotObj = ((Component)slotTrans).gameObject;
		if (ship == null)
		{
			slotObj.SetActive(false);
			return;
		}
		slotObj.SetActive(true);
		SpriteRenderer portrait = ((Component)slotTrans.Find("Content/portrait")).GetComponent<SpriteRenderer>();
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
		Transform val = Island.IslandPlane.transform.Find("slots");
		for (int i = 0; i < 10; i++)
		{
			RenderSlot(i, val.Find($"{i}"));
		}
	}

	public override void DockShip(Ship ship, bool isInit)
	{
		for (int i = 0; i < 10; i++)
		{
			if (Slots[i] != null && Slots[i].Props.Id == ship.Props.Id)
			{
				return;
			}
		}
		int curSlotIndex = 0;
		while (curSlotIndex < 10 && Slots[curSlotIndex] != null)
		{
			int num = curSlotIndex + 1;
			curSlotIndex = num;
		}
		Slots[curSlotIndex] = ship;
		OnChangeShips?.Invoke();
		if ((Object)(object)Island.IslandPlane == (Object)null)
		{
			HideShip(ship);
			return;
		}
		Transform slotTrans = Island.IslandPlane.transform.Find($"slots/{curSlotIndex}");
		if (!isInit)
		{
			((MonoBehaviour)GvGWorldMapController.Instance).StartCoroutine(PlayDockAnim(ship, slotTrans, delegate
			{
				RenderSlot(curSlotIndex, slotTrans);
			}));
		}
		else
		{
			RenderSlot(curSlotIndex, slotTrans);
		}
	}

	public override void UndockShip(Ship ship)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		int i;
		for (i = 0; i < 10 && Slots[i] != ship; i++)
		{
		}
		if (i == 10)
		{
			ShowShip(ship);
			return;
		}
		Slots[i] = null;
		OnChangeShips?.Invoke();
		ship.ShipTrans.localPosition = Island.IslandObject.transform.localPosition;
		if ((Object)(object)Island.IslandPlane == (Object)null)
		{
			ShowShip(ship);
			return;
		}
		Transform slotTrans = Island.IslandPlane.transform.Find($"slots/{i}");
		((MonoBehaviour)GvGWorldMapController.Instance).StartCoroutine(PlayUndockAnim(ship, slotTrans));
	}

	public IEnumerator PlayDockAnim(Ship ship, Transform slotTrans, Action onShowSlot = null)
	{
		((Component)ship.ShipTrans).GetComponent<Animation>().Play("ship_hide");
		yield return (object)new WaitForSeconds(0.3f);
		ship.ShipObj.SetActive(false);
		if ((Object)(object)slotTrans != (Object)null)
		{
			onShowSlot?.Invoke();
			((Component)slotTrans).GetComponent<Animation>().Play("slot_show");
		}
	}

	public IEnumerator PlayUndockAnim(Ship ship, Transform slotTrans, Action onEndAnim = null)
	{
		if ((Object)(object)slotTrans != (Object)null)
		{
			((Component)slotTrans).GetComponent<Animation>().Play("slot_hide");
			yield return (object)new WaitForSeconds(0.3f);
			if (slotTrans != null)
			{
				GameObject gameObject = ((Component)slotTrans).gameObject;
				if (gameObject != null)
				{
					gameObject.SetActive(false);
				}
			}
		}
		ship.ShipObj.SetActive(true);
		((Component)ship.ShipTrans).GetComponent<Animation>().Play("ship_show");
		yield return (object)new WaitForSeconds(0.3f);
		onEndAnim?.Invoke();
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

	public override bool HasMyShip()
	{
		int userId = GameController.Contexts.gameState.user.value.UserId;
		for (int i = 0; i < 10; i++)
		{
			if (Slots[i] != null && Slots[i].Details.UserId == userId)
			{
				return true;
			}
		}
		return false;
	}

	public override List<Ship> GetDockingShips()
	{
		List<Ship> list = new List<Ship>();
		Ship[] slots = Slots;
		foreach (Ship ship in slots)
		{
			if (ship != null)
			{
				list.Add(ship);
			}
		}
		return list;
	}
}
