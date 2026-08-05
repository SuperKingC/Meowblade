using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using UI.GvGShipLaunch;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.UI.GvGShipLaunchMap;

public class GvGShipLaunchMapController : MonoBehaviour
{
	private static GameObject GvGShipLaunchMap;

	private LoaderManager LoaderManager;

	private AreaRenderManager AreaRenderManager;

	private HiddenIslandManager HiddenIslandManager;

	private CloudsManager CloudsManager;

	private GameObject _selector;

	public static GvGShipLaunchMapController Instance;

	public static bool IsInstanceCreated;

	public bool IsInitialized;

	public CameraBindingHandler CamBinder;

	public Transform CameraTracker;

	public static UI_main_GvGShipLaunch MainUi;

	public Dictionary<string, GameObject> Prefabs;

	public int IslandId;

	public static void CreateInstance(UI_main_GvGShipLaunch mainUi, int defaultIslandId, string _IZConfigId)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		if (!IsInstanceCreated)
		{
			IsInstanceCreated = true;
			MainUi = mainUi;
			GvGShipLaunchMap = Addressables.InstantiateAsync((object)"GvG/GvGWorldMap", (Transform)null, false, true).WaitForCompletion();
			string text = "GvG/NavLines_" + _IZConfigId;
			GameObject val = Addressables.InstantiateAsync((object)text, (Transform)null, false, true).WaitForCompletion();
			val.transform.SetParent(GvGShipLaunchMap.transform, false);
			val.transform.localPosition = Vector3.zero;
			((Object)val).name = "Lines";
			Instance = GvGShipLaunchMap.AddComponent<GvGShipLaunchMapController>();
			Instance.IslandId = defaultIslandId;
		}
	}

	public static void ReleaseInstance()
	{
		if (IsInstanceCreated)
		{
			IsInstanceCreated = false;
			Instance.AreaRenderManager.OnDestroy();
			Instance.CloudsManager.OnDestroy();
			Instance.LoaderManager.OnDestroy();
			Instance.HiddenIslandManager.OnDestroy();
			Instance.UnRegisterEventListeners();
			Singleton<CameraService>.Instance.ClearSkybox();
			Singleton<CameraService>.Instance.StopBinding();
			Addressables.ReleaseInstance(GvGShipLaunchMap);
			Instance = null;
		}
	}

	private void Awake()
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		IsInitialized = false;
		((Object)GvGShipLaunchMap).name = "GvGShipLaunchMap";
		GvGShipLaunchMap.transform.parent = ((Component)GameController.Instance).gameObject.transform;
		GvGShipLaunchMap.transform.localPosition = Vector3.zero;
		Singleton<CameraService>.Instance.SetSkybox("GvGSkybox");
		Singleton<CameraService>.Instance.SwitchToScene("SceneGVG2");
		CameraTracker = AddEmptyObject("CameraTracker");
		CamBinder = Singleton<CameraService>.Instance.BindTarget(CameraTracker, 6f);
		LoaderManager = new LoaderManager(GvGShipLaunchMap.transform, (MonoBehaviour)(object)this, loadShip: false);
		AreaRenderManager = new AreaRenderManager(GvGShipLaunchMap);
		HiddenIslandManager = new HiddenIslandManager(GvGShipLaunchMap);
		CloudsManager = new CloudsManager(GvGShipLaunchMap);
		CamBinder.NotifyOnceOnCatchup = true;
		InitPrefabs();
		RegisterEventListeners();
	}

	private void Start()
	{
		UpdateIslandId(IslandId);
	}

	private void RegisterEventListeners()
	{
	}

	private void UnRegisterEventListeners()
	{
	}

	private void Update()
	{
		LoaderManager.Update();
	}

	private Transform AddEmptyObject(string name)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject(name);
		val.transform.parent = GvGShipLaunchMap.transform;
		val.transform.localScale = Vector3.one;
		return val.transform;
	}

	private void InitPrefabs()
	{
		Transform val = ((Component)this).transform.Find("Prefabs");
		Prefabs = new Dictionary<string, GameObject>();
		for (int i = 0; i < val.childCount; i++)
		{
			Transform child = val.GetChild(i);
			Prefabs.Add(((Object)child).name, ((Component)child).gameObject);
		}
	}

	private GameObject GetPrefab(string name)
	{
		if (Prefabs.TryGetValue(name, out var value))
		{
			return value;
		}
		ILRuntimeDebug.LogError("场景中找不到预制体 " + name);
		return null;
	}

	private GameObject InstantiateFromPrefab(string name)
	{
		GameObject prefab = GetPrefab(name);
		if ((Object)(object)prefab != (Object)null)
		{
			return Object.Instantiate<GameObject>(prefab);
		}
		return null;
	}

	public void UpdateIslandId(int islandId)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		IslandId = islandId;
		IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(IslandId);
		if (_selector == null)
		{
			_selector = InstantiateFromPrefab("selector");
			_selector.transform.SetParent(GvGShipLaunchMap.transform, true);
		}
		_selector.transform.localPosition = islandConfigData.Position;
		_selector.transform.localEulerAngles = Vector3.zero;
		float num = islandConfigData.FogAreaScale.x * 0.2f;
		_selector.transform.localScale = new Vector3(num, num, 0f);
		SetCamera(islandConfigData.Position, 6f, 0.5f);
	}

	public void SetCamera(Vector3 pos, float size, float catchupTime)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		GameObject selector = _selector;
		if (selector != null)
		{
			selector.SetActive(false);
		}
		CameraTracker.localPosition = pos;
		CamBinder.CatchupTime = catchupTime;
		ScriptApi.CreateTimer(catchupTime, delegate
		{
			GameObject selector2 = _selector;
			if (selector2 != null)
			{
				selector2.SetActive(true);
			}
		});
	}
}
