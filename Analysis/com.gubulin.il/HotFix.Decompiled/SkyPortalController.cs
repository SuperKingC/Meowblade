using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Models;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SkyPortalController : GoblinController
{
	public Building building;

	private GameObject ShipsContainer;

	private List<GameObject> ShipSlot_List;

	private void Start()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		ShipsContainer = Addressables.InstantiateAsync((object)"Prefabs/Buildings/MainCityMiningShips", (Transform)null, false, true).WaitForCompletion();
		((Object)ShipsContainer).name = "ShipsContainer";
		ShipsContainer.transform.SetParent(((Component)this).transform, false);
		ShipSlot_List = new List<GameObject>();
		for (int i = 0; i < ShipsContainer.transform.childCount; i++)
		{
			ShipSlot_List.Add(((Component)ShipsContainer.transform.GetChild(i)).gameObject);
		}
		OnInitConstructionState();
		GvGCollectingManager instance = Singleton<GvGCollectingManager>.Instance;
		instance.OnCollectingSync = (Action)Delegate.Combine(instance.OnCollectingSync, new Action(OnCollectingSync));
		SharedMessenger.AddListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", OnAnyConstructionStart);
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", OnAnyConstructionFinished);
	}

	private void OnDestroy()
	{
		GvGCollectingManager instance = Singleton<GvGCollectingManager>.Instance;
		instance.OnCollectingSync = (Action)Delegate.Remove(instance.OnCollectingSync, new Action(OnCollectingSync));
		SharedMessenger.RemoveListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", OnAnyConstructionStart);
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", OnAnyConstructionFinished);
	}

	private void OnCollectingSync()
	{
		List<ShipCollectingModel> shipCollecting_List = Singleton<GvGCollectingManager>.Instance.ShipCollecting_List;
		int campId = Singleton<GvGCollectingManager>.Instance.CampId;
		for (int i = 0; i < ShipSlot_List.Count; i++)
		{
			if (i < shipCollecting_List.Count && shipCollecting_List[i].WorkersStates != null)
			{
				UpdateShipCollecting(i, ShipSlot_List[i], shipCollecting_List[i], campId);
			}
			else
			{
				RemoveShipCollecting(i, ShipSlot_List[i]);
			}
		}
	}

	private void UpdateShipCollecting(int index, GameObject slot, ShipCollectingModel data, int campId)
	{
		if (!slot.activeSelf)
		{
			slot.SetActive(true);
		}
		SkyPortalShipController skyPortalShipController = slot.GetComponent<SkyPortalShipController>();
		if ((Object)(object)skyPortalShipController == (Object)null)
		{
			skyPortalShipController = slot.AddComponent<SkyPortalShipController>();
		}
		skyPortalShipController.SetShipCollectingData(data, campId);
	}

	private void RemoveShipCollecting(int index, GameObject slot)
	{
		if (slot.activeSelf)
		{
			slot.SetActive(false);
		}
	}

	private void OnInitConstructionState()
	{
		ShipsContainer.SetActive(building.Status == BuildingStatus.Running);
	}

	private void OnAnyConstructionStart(string buildingType, BuildingConstructingConfig info)
	{
		if (building != null && building.Level >= 1 && building.BuildingType == buildingType)
		{
			ShipsContainer.SetActive(false);
		}
	}

	private void OnAnyConstructionFinished(string buildingType, int level)
	{
		if (building != null && building.BuildingType == buildingType)
		{
			ShipsContainer.SetActive(true);
		}
	}
}
