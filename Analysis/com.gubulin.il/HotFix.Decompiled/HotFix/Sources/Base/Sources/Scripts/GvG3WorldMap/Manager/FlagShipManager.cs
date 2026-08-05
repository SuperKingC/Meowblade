using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using Shift.Legion.Common.Helpers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;

public class FlagShipManager
{
	private Transform Container;

	private Dictionary<int, FlagShipController> Controllers;

	public FlagShipManager(GameObject _GvGWorldMap)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject("FlagShips");
		Container = val.transform;
		Container.SetParent(_GvGWorldMap.transform, false);
		Container.localPosition = Vector3.zero;
	}

	public void LoadFlagShips()
	{
		Controllers = new Dictionary<int, FlagShipController>();
		foreach (int key in Singleton<WorldStateManager>.Instance.Data.FlagShips.Keys)
		{
			GameObject val = GvGWorldMapController.Instance.InstantiateFromPrefab("FlagShip");
			FlagShipController flagShipController = val.AddComponent<FlagShipController>();
			((Component)flagShipController).transform.SetParent(Container, false);
			flagShipController.Load(key);
			Controllers.Add(key, flagShipController);
		}
	}

	public void OnDestroy()
	{
		foreach (FlagShipController value in Controllers.Values)
		{
			value.Unload();
		}
		Object.Destroy((Object)(object)((Component)Container).gameObject);
	}

	public FlagShipController GetControllerByCampId(int campId)
	{
		if (!Controllers.TryGetValue(campId, out var value))
		{
			ILRuntimeDebug.LogError($"[FlagShipManager] 找不大 campId={campId} 所对应的旗舰controller");
		}
		return value;
	}
}
