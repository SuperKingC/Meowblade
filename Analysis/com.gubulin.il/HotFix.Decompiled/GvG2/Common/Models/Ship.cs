using System;
using System.Collections.Generic;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using UnityEngine;

namespace GvG2.Common.Models;

public class Ship
{
	public Action<Ship> OnUpdateFlightSchedule = delegate
	{
	};

	public ShipProps Props;

	public C2S_GetShipSummaryAndFlightScheduleInfo Details;

	public GameObject ShipObj;

	public Transform ShipTrans;

	public Transform RotatorTrans;

	public Transform IconTrans;

	public Action<int> OnDestroy = delegate
	{
	};

	private static Quaternion IconGlobalRotation = Quaternion.Euler(Vector3.zero);

	private static Dictionary<int, string> CampId_PrefabName = new Dictionary<int, string>
	{
		{ 1, "ship_red" },
		{ 2, "ship_green" },
		{ 3, "ship_blue" },
		{ 4, "ship_yellow" }
	};

	public Ship(ShipProps props, Transform parent)
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		Props = props;
		ShipObj = GvGWorldMapController.Instance.InstantiateFromPrefab(CampId_PrefabName[Props.CampId]);
		ShipObj.SetActive(false);
		((Object)ShipObj).name = $"{props.Id}";
		ShipObj.transform.SetParent(parent, false);
		ShipObj.transform.localPosition = new Vector3(1000f, 1000f, 1000f);
		ShipTrans = ShipObj.transform;
		RotatorTrans = ShipTrans.Find("rotator");
		IconTrans = ShipTrans.Find("rotator/icon");
		SpriteRenderer portrait = ((Component)IconTrans.Find("portrait")).GetComponent<SpriteRenderer>();
		AvatarHelper.GetUserAvatarSprite($"{Props.CampId}", Props.UserId, delegate(Sprite sprite)
		{
			if (!((Object)(object)ShipObj == (Object)null))
			{
				portrait.sprite = sprite;
			}
		});
		if (Props.UserId == GameController.Contexts.gameState.user.value.UserId)
		{
			LODGroup component = ShipObj.GetComponent<LODGroup>();
			component.ForceLOD(0);
			component.enabled = false;
			Transform transform = GvGWorldMapController.Instance.InstantiateFromPrefab("mine_ship_ui").transform;
			transform.parent = IconTrans;
			transform.localPosition = Vector3.zero;
			transform.localScale = Vector3.one;
			transform.localRotation = Quaternion.Euler(Vector3.zero);
			FlightTimeCounter flightTimeCounter = ((Component)transform).gameObject.AddComponent<FlightTimeCounter>();
			flightTimeCounter.Init(this);
		}
	}

	public void Destroy()
	{
		OnDestroy?.Invoke(Props.Id);
		ShipTrans = null;
		Object.Destroy((Object)(object)ShipObj);
		OnDestroy = null;
	}

	public void OnChangeDirection(Vector3 dir)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		RotatorTrans.localRotation = Quaternion.LookRotation(dir, Vector3.up);
		IconTrans.rotation = IconGlobalRotation;
	}

	public void SetDetails(C2S_GetShipSummaryAndFlightScheduleInfo details)
	{
		Details = details;
		OnUpdateFlightSchedule?.Invoke(this);
	}

	public void ChangeFlightSchedule(FlightSchedule flight, int state, int stayIslandId)
	{
		if (Details != null)
		{
			Details.State = state;
			Details.StayIslandId = stayIslandId;
			Details.FlightSchedule = flight;
			OnUpdateFlightSchedule?.Invoke(this);
		}
	}
}
