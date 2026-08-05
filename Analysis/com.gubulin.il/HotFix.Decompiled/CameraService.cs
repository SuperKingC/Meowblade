using System.Collections.Generic;
using Entitas;
using FairyGUI;
using GameMaths;
using Shift.Legion;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class CameraService : Singleton<CameraService>, ICameraService, IService, IAnyBattleStartedListener, IAnyBattleStartedRemovedListener, IAnyFreeBattleModeListener
{
	private GameStateContext _context;

	private Contexts _contexts;

	private IGroup<GameEntity> _group;

	private List<GameEntity> _buffer;

	private GameStateEntity _eventListener;

	private GameObject _postProcessing;

	private GameObject _cameraContainer;

	private AsyncOperationHandle<Material> _skyboxMatHandle;

	private Camera _mainCamera;

	private CameraBinding BindingMonoBehaviour = null;

	private Skybox SkyboxComponent = null;

	public Vector3 CamDist;

	public static float DevelopWidth = 1920f;

	public static float DevelopHeigh = 1080f;

	public static float DevelopRate = DevelopHeigh / DevelopWidth;

	public static int curScreenHeight = Screen.height;

	public static int curScreenWidth = Screen.width;

	public static float ScreenRate = (float)Screen.height / (float)Screen.width;

	public static float cameraRectHeightRate = DevelopHeigh / (DevelopWidth / (float)Screen.width * (float)Screen.height);

	public static float cameraRectWidthRate = DevelopWidth / (DevelopHeigh / (float)Screen.height * (float)Screen.width);

	public float CameraSize = 5.4f;

	public static Vector3 GvGWorldPos = new Vector3(0f, -19f, 80f);

	private ICamera _camera;

	public Camera MainCamera => _mainCamera;

	public Vector3 Position
	{
		get
		{
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			_group.GetEntities(_buffer);
			if (_buffer.Count > 0)
			{
				return _buffer[0].position.value;
			}
			return Vector3.zero;
		}
		set
		{
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			_group.GetEntities(_buffer);
			if (_buffer.Count > 0)
			{
				_buffer[0].ReplacePosition(value);
			}
		}
	}

	public Quaternion Rotation
	{
		get
		{
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			_group.GetEntities(_buffer);
			if (_buffer.Count > 0)
			{
				return _buffer[0].rotation.value;
			}
			return Quaternion.identity;
		}
		set
		{
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			_group.GetEntities(_buffer);
			if (_buffer.Count > 0)
			{
				_buffer[0].ReplaceRotation(value);
			}
		}
	}

	public float Size
	{
		get
		{
			return _context.cameraSize.value;
		}
		set
		{
			_context.ReplaceCameraSize(value);
		}
	}

	public float Aspect
	{
		get
		{
			return _context.cameraAspect.value;
		}
		set
		{
			_context.ReplaceCameraAspect(value);
		}
	}

	public float ScreenWidth => Screen.width;

	public float ScreenHeight => Screen.height;

	public float ScreenRatio => (float)Screen.width / (float)Screen.height;

	private ICamera Camera
	{
		get
		{
			if (_camera == null)
			{
				GameEntity[] entities = ((Context<GameEntity>)_contexts.game).GetEntities();
				GameEntity[] array = entities;
				foreach (GameEntity gameEntity in array)
				{
					if (gameEntity.hasCamera)
					{
						_camera = gameEntity.camera.value;
						break;
					}
				}
			}
			return _camera;
		}
	}

	public override void InitInstance()
	{
		_buffer = new List<GameEntity>();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (((Scene)(ref scene)).name == "Load")
		{
			_camera = null;
		}
	}

	public void Init()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		Contexts contexts = GameController.Contexts;
		CamDist = Const.NormalCamDist;
		if ((Object)(object)_mainCamera == (Object)null)
		{
			GameObject val = GameObject.Find("MainCamera");
			_mainCamera = val.GetComponent<Camera>();
			GameObject val2 = GameObject.Find("GameController");
			GameObject val3 = new GameObject();
			_cameraContainer = Object.Instantiate<GameObject>(val3);
			((Object)_cameraContainer).name = "MainCameraRig";
			_cameraContainer.AddComponent<UnityView>();
			_cameraContainer.AddComponent<UnityCamera>();
			_cameraContainer.transform.SetParent(val2.transform);
			if (Define.PostProcessingCameraEnabled())
			{
				_postProcessing = Addressables.InstantiateAsync((object)"Prefabs/BattleFieldPostProcessingCamera", (Transform)null, false, true).WaitForCompletion();
				((Object)_postProcessing).name = "BattleFieldPostProcessingCamera";
				_postProcessing.AddComponent<PostProcessingCamera>();
				_postProcessing.transform.SetParent(val2.transform, false);
				_postProcessing.GetComponent<PostProcessingCamera>().Initialize(contexts);
			}
		}
		_contexts = GameController.Contexts;
		_context = GameController.Contexts.gameState;
		_group = ((Context<GameEntity>)GameController.Contexts.game).GetGroup(GameMatcher.Camera);
		_group.GetEntities(_buffer);
		foreach (GameEntity item in _buffer)
		{
			item.isDestroyed = true;
		}
		GameEntity gameEntity = ((Context<GameEntity>)contexts.game).CreateEntity();
		gameEntity.ReplaceView(_cameraContainer.GetComponent<UnityView>());
		gameEntity.ReplaceCamera(_cameraContainer.GetComponent<UnityCamera>());
		gameEntity.view.value.Initialize(contexts, gameEntity);
		gameEntity.camera.value.Initialize(contexts, gameEntity);
		gameEntity.isVisible = true;
		Component[] components = _cameraContainer.GetComponents(typeof(IEventListener));
		Component[] array = components;
		foreach (Component val4 in array)
		{
			((IEventListener)val4).RegisterListeners();
		}
		((Component)_mainCamera).transform.SetParent(_cameraContainer.transform, false);
	}

	public void Destroy()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		Transform transform = ((Component)_mainCamera).transform;
		transform.SetParent((Transform)null, false);
		transform.position = Vector3.op_Implicit(Vector3.zero);
	}

	public void AddEventsListener()
	{
		_eventListener = ((Context<GameStateEntity>)_context).CreateEntity();
		_eventListener.AddAnyFreeBattleModeListener(this);
		_eventListener.AddAnyBattleStartedListener(this);
		_eventListener.AddAnyBattleStartedRemovedListener(this);
	}

	public void RemoveEventsListener()
	{
		_contexts = null;
		_context = null;
		_group = null;
		_eventListener.RemoveAnyFreeBattleModeListener(this);
		_eventListener.RemoveAnyBattleStartedListener(this);
		_eventListener.RemoveAnyBattleStartedRemovedListener(this);
		((Entity)_eventListener).Destroy();
	}

	public void SetCameraParent(Transform transform)
	{
		transform.parent = ((Component)_mainCamera).transform;
	}

	public void FitCamera(Camera camera)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		if (DevelopRate <= ScreenRate)
		{
			camera.rect = new Rect(0f, (1f - cameraRectHeightRate) / 2f, 1f, cameraRectHeightRate);
		}
		else
		{
			camera.rect = new Rect(0f, (1f - cameraRectHeightRate) / 2f, 1f, cameraRectHeightRate);
		}
	}

	public void FicCameraOnChangeScreenSize(Camera camera, float _width, float _height)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		float num = _height / _width;
		cameraRectHeightRate = DevelopHeigh / (DevelopWidth / _width * _height);
		if (DevelopRate <= num)
		{
			camera.rect = new Rect(0f, (1f - cameraRectHeightRate) / 2f, 1f, cameraRectHeightRate);
		}
		else
		{
			camera.rect = new Rect(0f, (1f - cameraRectHeightRate) / 2f, 1f, cameraRectHeightRate);
		}
	}

	private Vector3 GetBattleFieldCameraPos()
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = num / 1.7777778f;
		float value = _context.battleFieldLength.value;
		Vector3 result = default(Vector3);
		((Vector3)(ref result))._002Ector((0f - (value - 19.2f)) / 2f, CamDist.y, CamDist.z);
		return result;
	}

	public Vector3 GetCameraPositionForScene(string scene)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		return (Vector3)(scene switch
		{
			"BattleField" => GetBattleFieldCameraPos(), 
			"SceneGvGWorld" => Vector3.op_Implicit(Consts.GVG_START_CAM_POS), 
			"MainCity.Left" => new Vector3(0f - FGUIManager.Instance.difference, 200f, -50f), 
			"MainCity.Right" => new Vector3(FGUIManager.Instance.difference, 200f, -50f), 
			_ => new Vector3(FGUIManager.Instance.difference, 200f, -50f), 
		});
	}

	public void InitBinding()
	{
		if ((Object)(object)BindingMonoBehaviour == (Object)null)
		{
			BindingMonoBehaviour = _cameraContainer.AddComponent<CameraBinding>();
			((Behaviour)BindingMonoBehaviour).enabled = false;
		}
	}

	public CameraBindingHandler BindTarget(Vector3 pos, float targetSize, float catchupTime = 0.5f)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		InitBinding();
		CameraBindingHandler result = BindingMonoBehaviour.BindTarget(pos, targetSize, catchupTime);
		((Behaviour)BindingMonoBehaviour).enabled = true;
		return result;
	}

	public CameraBindingHandler BindTarget(Transform trans, float targetSize, float catchupTime = 0.5f)
	{
		InitBinding();
		CameraBindingHandler result = BindingMonoBehaviour.BindTarget(trans, targetSize, catchupTime);
		((Behaviour)BindingMonoBehaviour).enabled = true;
		return result;
	}

	public void StopBinding()
	{
		if (!((Object)(object)BindingMonoBehaviour == (Object)null))
		{
			BindingMonoBehaviour.StopBinding();
		}
	}

	public void ChangeCameraSize(float aimSize)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		GTween.To(_context.cameraSize.value, aimSize, 0.8f).SetEase((EaseType)0).OnUpdate((GTweenCallback1)delegate(GTweener tweener)
		{
			_context.ReplaceCameraSize(tweener.value.x);
		});
	}

	public void ChangeCameraPosition(Vector3 pos)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		_context.ReplaceCameraPosition(pos);
	}

	public void SwitchToScene(string scene)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		if (_context.hasCameraMoveLimit)
		{
			_context.RemoveCameraMoveLimit();
		}
		Vector3 cameraPositionForScene = GetCameraPositionForScene(scene);
		switch (scene)
		{
		case "BattleField":
			_context.ReplaceCameraActive(newValue: true);
			_context.ReplaceCameraPosition(cameraPositionForScene);
			_context.ReplaceCameraRotation(Quaternion.Euler(45f, 0f, 0f));
			_context.ReplaceCameraSize(5.4f);
			break;
		case "SceneGVG2":
			cameraPositionForScene = Vector3.op_Implicit(Consts.GVG2_START_CAM_POS);
			_context.ReplaceCameraActive(newValue: true);
			_context.ReplaceCameraPosition(cameraPositionForScene);
			_context.ReplaceCameraRotation(Quaternion.Euler(45f, 0f, 0f));
			_context.ReplaceCameraSize(8.64f);
			_cameraContainer.transform.position = Vector3.op_Implicit(cameraPositionForScene);
			break;
		case "SceneGvGWorld":
			cameraPositionForScene = Vector3.op_Implicit(Consts.GVG_START_CAM_POS);
			_context.ReplaceCameraActive(newValue: true);
			_context.ReplaceCameraPosition(cameraPositionForScene);
			_context.ReplaceCameraRotation(Quaternion.Euler(45f, 0f, 0f));
			_context.ReplaceCameraSize(25f);
			_cameraContainer.transform.position = Vector3.op_Implicit(cameraPositionForScene);
			break;
		case "MainCity.Left":
			_context.ReplaceCameraActive(newValue: true);
			_context.ReplaceCameraPosition(cameraPositionForScene);
			_context.ReplaceCameraRotation(Quaternion.identity);
			_context.ReplaceCameraSize(5.4f);
			_cameraContainer.transform.position = Vector3.op_Implicit(cameraPositionForScene);
			break;
		case "MainCity.Right":
			_context.ReplaceCameraActive(newValue: true);
			_context.ReplaceCameraPosition(cameraPositionForScene);
			_context.ReplaceCameraRotation(Quaternion.identity);
			_context.ReplaceCameraSize(5.4f);
			_cameraContainer.transform.position = Vector3.op_Implicit(cameraPositionForScene);
			break;
		default:
			_context.ReplaceCameraActive(newValue: true);
			_context.ReplaceCameraPosition(cameraPositionForScene);
			_context.ReplaceCameraRotation(Quaternion.identity);
			_context.ReplaceCameraSize(5.4f);
			break;
		}
	}

	public void SetPosition(Vector3 position, bool animated = false, float duration = 0f)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		Position = position;
	}

	public void SetRotation(Quaternion rotation, bool animated = false, float duration = 0f)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		Rotation = rotation;
	}

	public void SetSize(float size, bool animated = false, float duration = 0f)
	{
		Size = size;
	}

	public Vector3 WorldToScreenPoint(Vector3 position)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (Camera == null)
		{
			return position;
		}
		return Camera.WorldToScreenPoint(position);
	}

	public void OnAnyBattleStarted(GameStateEntity entity)
	{
		BattleMode battleMode = _contexts.config.battleConfig.Red.BattleMode;
		if (battleMode == BattleMode.MultiWaveAttackMode)
		{
			_contexts.gameState.ReplaceCameraFollowTeam(Team.Red);
		}
		else
		{
			_contexts.gameState.ReplaceCameraFollowTeam((battleMode == BattleMode.DefenceMode) ? Team.Blue : Team.Red);
		}
	}

	public void OnAnyBattleStartedRemoved(GameStateEntity entity)
	{
		_contexts.gameState.isCameraFollowingUnit = false;
	}

	public void OnAnyFreeBattleMode(GameStateEntity entity)
	{
		_contexts.gameState.ReplaceCameraFollowTeam(Team.Red);
	}

	public void SetSkybox(string materialKey)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)SkyboxComponent == (Object)null)
		{
			SkyboxComponent = ((Component)_mainCamera).gameObject.AddComponent<Skybox>();
		}
		_skyboxMatHandle = Addressables.LoadAssetAsync<Material>((object)materialKey);
		Material material = _skyboxMatHandle.WaitForCompletion();
		SkyboxComponent.material = material;
		((Behaviour)SkyboxComponent).enabled = true;
		_mainCamera.clearFlags = (CameraClearFlags)1;
	}

	public void ClearSkybox()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)SkyboxComponent == (Object)null))
		{
			((Behaviour)SkyboxComponent).enabled = false;
			_mainCamera.clearFlags = (CameraClearFlags)2;
			Addressables.Release<Material>(_skyboxMatHandle);
		}
	}
}
