using System;
using System.Collections;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.Common.Helpers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;

public class LoaderManager
{
	public bool NeedUpdate;

	private Transform TargetCameraTrans;

	private MonoBehaviour ParentController;

	private Rect NoReloadingArea;

	public IslandLoader IslandLoader;

	private ShipLoader ShipLoader;

	private ViewStateLoader ViewStateLoader;

	private float NextSyncShipsTime;

	private Coroutine ViewStateLoaderCoroutine;

	private Coroutine IslandLoaderCoroutine;

	private Coroutine ShipLoaderCoroutine;

	private const float SyncShipsTimeInterval = 7f;

	private bool SmallView_IsSynced = false;

	private Rect SmallView_NoResyncArea;

	private List<int> SmallView_SyncingIslandIds;

	private HashSet<int> SmallView_SyncingIslandIds_Changed;

	private float SmallView_NextSyncTime;

	private float SmallView_SyncTimeInterval = 2f;

	private float _lastChangePosTime;

	public LoaderManager(Transform world, MonoBehaviour parentController, bool loadShip = true)
	{
		NeedUpdate = true;
		TargetCameraTrans = ((Component)Camera.main).transform.parent;
		ParentController = parentController;
		SmallView_SyncingIslandIds_Changed = new HashSet<int>();
		IslandLoader = new IslandLoader(world);
		if (loadShip)
		{
			ShipLoader = new ShipLoader(world);
		}
		ViewStateLoader = new ViewStateLoader();
		SharedMessenger.AddListener<int>("GVG3_ON_DEPART_ISLAND", OnAnyShipReachOrDepartIsland);
		SharedMessenger.AddListener<int>("GVG3_ON_REACH_ISLAND", OnAnyShipReachOrDepartIsland);
	}

	private IEnumerator StartObjectLoader<KEY, T>(ObjectPoolingLoaderBase<KEY, T> loader) where T : MonoBehaviour
	{
		loader.IsLoading = true;
		do
		{
			loader.NeedInterruptionAndReload = false;
			yield return loader.LazyUpdate();
			yield return null;
		}
		while (loader.NeedInterruptionAndReload);
		loader.IsLoading = false;
	}

	private IEnumerator StartDataLoader(DataLoaderBase loader)
	{
		loader.IsLoading = true;
		do
		{
			loader.NeedInterruptionAndReload = false;
			yield return loader.Reload();
			yield return (object)new WaitForSeconds(1f);
		}
		while (loader.NeedInterruptionAndReload);
		loader.IsLoading = false;
	}

	public void Update()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		Vector3 localPosition = TargetCameraTrans.localPosition;
		Vector2 camPos2D = default(Vector2);
		((Vector2)(ref camPos2D))._002Ector(localPosition.x, localPosition.z);
		UpdateIslandsAndShips(camPos2D);
		UpdateSmallViewState(camPos2D);
	}

	private void UpdateIslandsAndShips(Vector2 camPos2D)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		if (_lastChangePosTime + 10f < Time.time)
		{
			NeedUpdate = true;
			_lastChangePosTime = Time.time;
		}
		if (NeedUpdate || !((Rect)(ref NoReloadingArea)).Contains(camPos2D))
		{
			Singleton<WorldStateManager>.Instance.IsLoadingEOIData = true;
			NeedUpdate = false;
			NoReloadingArea = new Rect(camPos2D.x - 35f, camPos2D.y - 25f, 70f, 50f);
			ViewStateLoader.Mode = eLoaderMode.ChangePos;
			if (ViewStateLoader.IsLoading)
			{
				ViewStateLoader.NeedInterruptionAndReload = true;
			}
			else
			{
				ViewStateLoaderCoroutine = ParentController.StartCoroutine(StartDataLoader(ViewStateLoader));
			}
			if (IslandLoader.IsLoading)
			{
				IslandLoader.NeedInterruptionAndReload = true;
			}
			else
			{
				IslandLoaderCoroutine = ParentController.StartCoroutine(StartObjectLoader(IslandLoader));
			}
			if (ShipLoader != null)
			{
				ShipLoader.Mode = eLoaderMode.ChangePos;
				if (ShipLoader.IsLoading)
				{
					ShipLoader.NeedInterruptionAndReload = true;
				}
				else
				{
					ShipLoaderCoroutine = ParentController.StartCoroutine(StartObjectLoader(ShipLoader));
				}
			}
			NextSyncShipsTime = Time.time + 7f;
		}
		else
		{
			if (!(Time.time >= NextSyncShipsTime))
			{
				return;
			}
			Singleton<WorldStateManager>.Instance.IsLoadingEOIData = true;
			ViewStateLoader.Mode = eLoaderMode.SyncChanges;
			if (ViewStateLoader.IsLoading)
			{
				ViewStateLoader.NeedInterruptionAndReload = true;
			}
			else
			{
				ViewStateLoaderCoroutine = ParentController.StartCoroutine(StartDataLoader(ViewStateLoader));
			}
			if (ShipLoader != null)
			{
				ShipLoader.Mode = eLoaderMode.SyncChanges;
				if (ShipLoader.IsLoading)
				{
					ShipLoader.NeedInterruptionAndReload = true;
				}
				else
				{
					ShipLoaderCoroutine = ParentController.StartCoroutine(StartObjectLoader(ShipLoader));
				}
			}
			NextSyncShipsTime = Time.time + 7f;
		}
	}

	private void UpdateSmallViewState(Vector2 camPos2D)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		if (!((Rect)(ref SmallView_NoResyncArea)).Contains(camPos2D))
		{
			SmallView_NoResyncArea = new Rect(camPos2D.x - 6.4f, camPos2D.y - 3.6000001f, 12.8f, 7.2000003f);
			SmallView_IsSynced = false;
			SmallView_SyncingIslandIds = null;
		}
		if (SmallView_IsSynced || !(GvGWorldMapController.Instance.CameraBindingManager.MainCamera.orthographicSize < 8.75f))
		{
			return;
		}
		if (SmallView_SyncingIslandIds == null)
		{
			Vector2 screenPos = default(Vector2);
			((Vector2)(ref screenPos))._002Ector((float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
			Vec2 screenToFloorPos = PositionHelper.GetScreenToFloorPos(screenPos);
			Rect targetRect = default(Rect);
			((Rect)(ref targetRect))._002Ector(screenToFloorPos.x - 22.4f, screenToFloorPos.y - 12.599999f, 44.8f, 25.199999f);
			SmallView_SyncingIslandIds = WorldMapConfigHelper.Configs.QuadTree.Search(targetRect);
			SmallView_SyncingIslandIds_Changed.Clear();
		}
		if (Time.time >= SmallView_NextSyncTime)
		{
			SmallView_NextSyncTime = Time.time + SmallView_SyncTimeInterval;
			List<int> list = ((SmallView_SyncingIslandIds_Changed.Count <= 0) ? SmallView_SyncingIslandIds : new List<int>(SmallView_SyncingIslandIds_Changed));
			if (list.Count > 0)
			{
				Singleton<WorldStateManager>.Instance.GetIslandShipsForDisplay(list);
				SmallView_IsSynced = true;
				SmallView_SyncingIslandIds_Changed.Clear();
			}
			else
			{
				SmallView_IsSynced = true;
			}
		}
	}

	private void OnAnyShipReachOrDepartIsland(int islandId)
	{
		if (SmallView_SyncingIslandIds != null && SmallView_SyncingIslandIds.Contains(islandId))
		{
			SmallView_IsSynced = false;
			SmallView_SyncingIslandIds_Changed.Add(islandId);
			if (Time.time >= SmallView_NextSyncTime)
			{
				SmallView_NextSyncTime = Time.time + 2f;
			}
		}
	}

	public void Pause(bool hide = true)
	{
		IslandLoader.SetContainerActive(!hide);
		ShipLoader.SetContainerActive(!hide);
	}

	public void Resume()
	{
		NeedUpdate = true;
		IslandLoader.NeedReloadOldActive = true;
		IslandLoader.NeedReloadStates = true;
		IslandLoader.SetContainerActive(isActive: true);
		if (IslandLoader.IsLoading && IslandLoaderCoroutine != null)
		{
			IslandLoader.IsLoading = false;
			ParentController.StopCoroutine(IslandLoaderCoroutine);
		}
		ShipLoader.NeedReloadOldActive = true;
		ShipLoader.SetContainerActive(isActive: true);
		if (ShipLoader.IsLoading && ShipLoaderCoroutine != null)
		{
			ShipLoader.IsLoading = false;
			ParentController.StopCoroutine(ShipLoaderCoroutine);
		}
		ViewStateLoader.ClearCache();
		if (ViewStateLoader.IsLoading && ViewStateLoaderCoroutine != null)
		{
			ViewStateLoader.IsLoading = false;
			ParentController.StopCoroutine(ViewStateLoaderCoroutine);
		}
	}

	public void ReloadIslands(Action onFinished = null)
	{
		NeedUpdate = true;
		IslandLoader.NeedReloadStates = true;
		if (onFinished != null)
		{
			IslandLoader islandLoader = IslandLoader;
			islandLoader.OnLoadingFinished = (Action)Delegate.Combine(islandLoader.OnLoadingFinished, new Action(loadFinishedCallback));
		}
		void loadFinishedCallback()
		{
			IslandLoader islandLoader2 = IslandLoader;
			islandLoader2.OnLoadingFinished = (Action)Delegate.Remove(islandLoader2.OnLoadingFinished, new Action(loadFinishedCallback));
			onFinished();
		}
	}

	public void ReloadShips()
	{
		NeedUpdate = true;
	}

	public ShipController GetShipController(int entityId)
	{
		ShipController shipController = ShipLoader.GetShipController(entityId);
		if ((Object)(object)shipController == (Object)null)
		{
			shipController = ShipLoader.RequestShipEntity(entityId);
		}
		return shipController;
	}

	public IslandController GetIslandController(int islandId)
	{
		return IslandLoader.GetIslandController(islandId);
	}

	public void OnDestroy()
	{
		IslandLoader.UnloadAll();
		ShipLoader?.UnloadAll();
		ViewStateLoader.UnloadAll();
		ParentController = null;
		SharedMessenger.RemoveListener<int>("GVG3_ON_DEPART_ISLAND", OnAnyShipReachOrDepartIsland);
		SharedMessenger.RemoveListener<int>("GVG3_ON_REACH_ISLAND", OnAnyShipReachOrDepartIsland);
	}
}
