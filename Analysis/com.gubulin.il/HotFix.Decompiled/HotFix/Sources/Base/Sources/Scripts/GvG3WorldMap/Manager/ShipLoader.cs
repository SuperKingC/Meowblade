using System.Collections;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using Shift.Legion.Common.Helpers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;

public class ShipLoader : ObjectPoolingLoaderBase<int, ShipController>
{
	private const int MaxSimultaneousLoading = 20;

	public bool NeedReloadOldActive;

	public eLoaderMode Mode = eLoaderMode.ChangePos;

	private HashSet<int> _additionWaitingLoads;

	public ShipLoader(Transform worldTrans)
		: base(worldTrans, "GvG/GvGShipBase", "Ships", 50)
	{
		SharedMessenger.AddListener<int>("GVG3_UNLOAD_SHIP_CONTROLLER", OnUnloadShip);
		_additionWaitingLoads = new HashSet<int>();
	}

	public ShipController RequestShipEntity(int shipEntityId)
	{
		if (ActiveObjects.TryGetValue(shipEntityId, out var value))
		{
			return value;
		}
		_additionWaitingLoads.Add(shipEntityId);
		return LoadShip(shipEntityId);
	}

	public override IEnumerator LazyUpdate()
	{
		WorldStateManager worldStateManager = Singleton<WorldStateManager>.Instance;
		while (true)
		{
			yield return null;
			if (NeedInterruptionAndReload)
			{
				break;
			}
			if (worldStateManager.IsLoadingEOIData)
			{
				continue;
			}
			HashSet<int> newVisibleEntityIds = new HashSet<int>(worldStateManager.Data.EOI_ShipSimpleEntityIds);
			newVisibleEntityIds.UnionWith(_additionWaitingLoads);
			if (Mode == eLoaderMode.ChangePos)
			{
				Dictionary<int, ShipController> oldActiveShip = new Dictionary<int, ShipController>();
				foreach (ShipController shipController in ActiveObjects.Values)
				{
					if (newVisibleEntityIds.Contains(shipController.EntityId))
					{
						oldActiveShip.Add(shipController.EntityId, shipController);
					}
					else
					{
						ReleaseShipController(shipController);
					}
				}
				ActiveObjects = oldActiveShip;
			}
			if (NeedReloadOldActive)
			{
				NeedReloadOldActive = false;
				foreach (ShipController shipController2 in ActiveObjects.Values)
				{
					shipController2.Reload();
				}
			}
			HashSet<int> entityIdsToCreate = new HashSet<int>();
			foreach (int entityId in newVisibleEntityIds)
			{
				if (!ActiveObjects.ContainsKey(entityId))
				{
					entityIdsToCreate.Add(entityId);
				}
			}
			yield return null;
			if (NeedInterruptionAndReload)
			{
				break;
			}
			List<ShipController> loadingShips = new List<ShipController>();
			foreach (int entityId2 in entityIdsToCreate)
			{
				ShipController shipController3 = LoadShip(entityId2);
				loadingShips.Add(shipController3);
				while (NeedWaitForIdleLoadingTask(loadingShips, 20))
				{
					yield return null;
				}
				if (NeedInterruptionAndReload)
				{
					break;
				}
			}
			while (NeedWaitForIdleLoadingTask(loadingShips, 1))
			{
				yield return null;
			}
			break;
		}
	}

	private ShipController LoadShip(int entityId)
	{
		ShipController shipController = ObjectPool.Get();
		ActiveObjects.Add(entityId, shipController);
		shipController.Load(entityId);
		return shipController;
	}

	private bool NeedWaitForIdleLoadingTask(List<ShipController> loadingList, int maxTaskCount)
	{
		if (loadingList.Count >= maxTaskCount)
		{
			for (int num = loadingList.Count - 1; num >= 0; num--)
			{
				if (!loadingList[num].IsLoading)
				{
					loadingList.RemoveAt(num);
				}
			}
			return true;
		}
		return false;
	}

	public ShipController GetShipController(int entityId)
	{
		ActiveObjects.TryGetValue(entityId, out var value);
		return value;
	}

	public new void UnloadAll()
	{
		foreach (ShipController value in ActiveObjects.Values)
		{
			value.Unload();
		}
		base.UnloadAll();
		SharedMessenger.RemoveListener<int>("GVG3_UNLOAD_SHIP_CONTROLLER", OnUnloadShip);
	}

	private void OnUnloadShip(int shipEntityId)
	{
		if (ActiveObjects.TryGetValue(shipEntityId, out var value))
		{
			ReleaseShipController(value);
			ActiveObjects.Remove(shipEntityId);
		}
	}

	private void ReleaseShipController(ShipController shipController)
	{
		shipController.Unload();
		ObjectPool.Release(shipController);
	}
}
