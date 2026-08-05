using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Entitas;
using FairyGUI;
using HotFix;
using HotFix.Sources.Base.Scripts.Managers;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.ThirdParty.SDKs.Android;
using ObjectPool;
using RSG;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientLib.Services;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.LegendItemDungeon;
using UI.LoginAndName;
using UI.Tips;
using UnityEngine;

public class GameController : MonoBehaviour, IAnyDataReadyListener
{
	public static bool WillRestart = false;

	private static Contexts _contexts;

	public static Contexts ReplayContexts;

	private UpdateRootSystems _updateRootSystems;

	private ReplayFixedUpdateRootSystems _replayFixedUpdateRootSystems;

	private bool _resourceIsUpToDate;

	public static GameController Instance;

	public static List<int> List_OrderID = null;

	public static bool HasPendingOrders_IOS = true;

	public static bool HasPendingOrders_Intl = true;

	public long LocalUpdateTime;

	private float _FlushServerTime;

	private int _server_local_diff;

	private float _playtime = 0f;

	private bool _IsRealtimeParamInit;

	private double _ClientRealTimeWhenSynced;

	private double _ServerTimeWhenSynced;

	private float _replayDeltaTime;

	private string _idfa;

	private string _ua;

	private bool _isShowingModal;

	public static bool IsNewGuideMode
	{
		get
		{
			if (HotUpdateProcess.Instance.Configs.ContainsKey("NewGuideMode"))
			{
				return true;
			}
			return false;
		}
	}

	public static bool IsAutoLoginAccount
	{
		get
		{
			if (Configs.TryGetValue("AutoLoginAccount", out var value))
			{
				return value == "1";
			}
			return false;
		}
	}

	public static bool IsLocalServer
	{
		get
		{
			if (Configs.TryGetValue("LocalServer", out var value))
			{
				return value == "1";
			}
			return false;
		}
	}

	public static string UserAgent => "pro";

	public static string FSM
	{
		get
		{
			if (HotUpdateProcess.Instance.Configs.TryGetValue("FSM", out var value))
			{
				return value;
			}
			return "0";
		}
	}

	public static Contexts Contexts => _contexts ?? (_contexts = Contexts.sharedInstance);

	public static Dictionary<string, string> Configs
	{
		get
		{
			return HotUpdateProcess.Instance.Configs;
		}
		set
		{
		}
	}

	public string IDFA => _idfa;

	public string UA => _ua;

	private void Awake()
	{
		WillRestart = false;
		_IsRealtimeParamInit = false;
		_FlushServerTime = 999f;
		Instance = this;
		_playtime = CertificationHelper.GetTodayPlayTime(isInit: true);
		Contexts.SubscribeId();
		SentrySdk.AddBreadcrumb("GameController CreateLoginServices On Awake");
		CreateLoginServices(Contexts);
		ReplayContexts = new Contexts();
		_ = SpawnManager.Instance;
		SharedMessenger.AddListener<Level>("BATTLE_START", OnBattleStart);
		SharedMessenger.AddListener<PlayBattleReplayData, CustomTaskCompletionSource<bool>>("ACTION_PLAY_BATTLE_REPLAY", OnPlayBattleReplay);
		SharedMessenger.AddListener("DESTROY_BATTLE_CONTEXTS", OnResetReplayContexts);
		SharedMessenger.AddListener<NeedRestartResponse>("NEED_RESTART", OnNeedRestart);
		SharedMessenger.AddListener<NeedReLoginResponse>("NEED_RE_LOGIN", OnNeedReLogin);
		SharedMessenger.AddListener("SWITCH_ACCOUNT", OnSwitchAccount);
		SharedMessenger.AddListener<string, int>("USER_CREDENTIALS_OPERATION", OnUserCredentialsOperation);
		OnResourcesReady();
	}

	public void Init()
	{
		if (GameManagers.Instance != null && GameManagers.Instance.Initialized)
		{
			GameManagers.Instance.RemoveEventListeners();
		}
		GameManagers.Instance = new GameManagers(SharedMessenger.messengerInstance);
		ResetECS();
		CreateServices(Contexts);
		GameManagers.Configs.Clear();
		foreach (KeyValuePair<string, string> config in Configs)
		{
			GameManagers.Configs.Add(config.Key, config.Value);
		}
		GameStateEntity gameStateEntity = ((Context<GameStateEntity>)Contexts.gameState).CreateEntity();
		gameStateEntity.AddAnyDataReadyListener(this);
		_updateRootSystems = new UpdateRootSystems(Contexts);
		((Systems)_updateRootSystems).Initialize();
		_resourceIsUpToDate = true;
		Contexts.Service<IGameDataService>().StartLoadGameData();
	}

	public void OnLoginSuccess(LoginResponse response)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		SentryController.Instance.SetUserId(response.User.UserId);
		SentrySdk.AddBreadcrumb("GameController Init After Login Success");
		Init();
		if (response.RequireDeviceInfo)
		{
			DeviceInfo info = new DeviceInfo
			{
				BatteryLevel = SystemInfo.batteryLevel,
				BatteryStatus = ((object)SystemInfo.batteryStatus/*cast due to .constrained prefix*/).ToString(),
				CopyTextureSupport = ((object)SystemInfo.copyTextureSupport/*cast due to .constrained prefix*/).ToString(),
				DeviceModel = SystemInfo.deviceModel,
				DeviceName = SystemInfo.deviceName,
				DeviceType = ((object)SystemInfo.deviceType/*cast due to .constrained prefix*/).ToString(),
				DeviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier,
				GraphicsDeviceId = SystemInfo.graphicsDeviceID,
				GraphicsDeviceName = SystemInfo.graphicsDeviceName,
				GraphicsDeviceType = ((object)SystemInfo.graphicsDeviceType/*cast due to .constrained prefix*/).ToString(),
				GraphicsDeviceVendor = SystemInfo.graphicsDeviceVendor,
				GraphicsDeviceVendorId = SystemInfo.graphicsDeviceVendorID,
				GraphicsDeviceVersion = SystemInfo.graphicsDeviceVersion,
				GraphicsMemorySize = SystemInfo.graphicsMemorySize,
				GraphicsMultiThreaded = SystemInfo.graphicsMultiThreaded,
				GraphicsShaderLevel = SystemInfo.graphicsShaderLevel,
				GraphicsUvStartsAtTop = SystemInfo.graphicsUVStartsAtTop,
				HasDynamicUniformArrayIndexingInFragmentShaders = SystemInfo.hasDynamicUniformArrayIndexingInFragmentShaders,
				HasHiddenSurfaceRemovalOnGpu = SystemInfo.hasHiddenSurfaceRemovalOnGPU,
				MaxCubemapSize = SystemInfo.maxCubemapSize,
				MaxTextureSize = SystemInfo.maxTextureSize,
				NpotSupport = ((object)SystemInfo.npotSupport/*cast due to .constrained prefix*/).ToString(),
				OperatingSystem = SystemInfo.operatingSystem,
				OperatingSystemFamily = ((object)SystemInfo.operatingSystemFamily/*cast due to .constrained prefix*/).ToString(),
				ProcessorCount = SystemInfo.processorCount,
				ProcessorFrequency = SystemInfo.processorFrequency,
				ProcessorType = SystemInfo.processorType,
				SupportedRenderTargetCount = SystemInfo.supportedRenderTargetCount,
				Supports2DArrayTextures = SystemInfo.supports2DArrayTextures,
				Supports32BitsIndexBuffer = SystemInfo.supports32bitsIndexBuffer,
				Supports3DRenderTextures = SystemInfo.supports3DRenderTextures,
				Supports3DTextures = SystemInfo.supports3DTextures,
				SupportsAccelerometer = SystemInfo.supportsAccelerometer,
				SupportsAsyncCompute = SystemInfo.supportsAsyncCompute,
				SupportsAsyncGpuReadback = SystemInfo.supportsAsyncGPUReadback,
				SupportsAudio = SystemInfo.supportsAudio,
				SupportsComputeShaders = SystemInfo.supportsComputeShaders,
				SupportsCubemapArrayTextures = SystemInfo.supportsCubemapArrayTextures,
				SupportsGyroscope = SystemInfo.supportsGyroscope,
				SupportsHardwareQuadTopology = SystemInfo.supportsHardwareQuadTopology,
				SupportsInstancing = SystemInfo.supportsInstancing,
				SupportsLocationService = SystemInfo.supportsLocationService,
				SupportsMipStreaming = SystemInfo.supportsMipStreaming,
				SupportsMotionVectors = SystemInfo.supportsMotionVectors,
				SupportsMultisampleAutoResolve = SystemInfo.supportsMultisampleAutoResolve,
				SupportsMultisampledTextures = SystemInfo.supportsMultisampledTextures,
				SupportsRawShadowDepthSampling = SystemInfo.supportsRawShadowDepthSampling,
				SupportsSeparatedRenderTargetsBlend = SystemInfo.supportsSeparatedRenderTargetsBlend,
				SupportsShadows = SystemInfo.supportsShadows,
				SupportsSparseTextures = SystemInfo.supportsSparseTextures,
				SupportsTextureWrapMirrorOnce = SystemInfo.supportsTextureWrapMirrorOnce,
				SupportsVibration = SystemInfo.supportsVibration,
				SystemMemorySize = SystemInfo.systemMemorySize,
				UsesReversedZBuffer = SystemInfo.usesReversedZBuffer,
				IDFA = _idfa
			};
			TaskAwaiter<UserDeviceInfoResponse> submitDeviceInfoAwaiter = Contexts.Service<INetworkService>().SubmitDeviceInfo(info).GetAwaiter();
			submitDeviceInfoAwaiter.OnCompleted(delegate
			{
				HotUpdateProcess.UserSource = submitDeviceInfoAwaiter.GetResult().Source;
			});
			Contexts.gameState.ReplaceUser(response.User);
			Contexts.Service<IGameDataService>().StartLoadUserArchive(response.User.UserId);
		}
	}

	private void OnLoginFail(object sender, object reason)
	{
		SharedMessenger.Broadcast("LOGIN_FAIL", (string)reason);
	}

	public void OnGuestBindSuccess(string credentialType, string userInfo)
	{
	}

	public void OnGuestBindFail(string credentialType, string errMsg)
	{
	}

	private void Update()
	{
		if (Configs == null)
		{
			return;
		}
		LocalUpdateTime = DateTimeHelper.Now.ToUnixTimeSeconds();
		Contexts.Service<INetworkService>()?.Update();
		if (_playtime >= 86400f)
		{
			_playtime = 0f;
		}
		_playtime += Time.deltaTime;
		_FlushServerTime += Time.deltaTime;
		if (_FlushServerTime > 25f)
		{
			SyncTime();
			_FlushServerTime = 0f;
		}
		if (FSM != "0")
		{
			if (_playtime >= 3000f)
			{
				CertificationHelper.ShowCertificationTip();
			}
			if (_playtime >= 3600f)
			{
				CertificationHelper.ShowCertificationDialogOnExperienceEnding();
			}
		}
		FGUIManager.Instance.AdaptationsOnChangeScreenSize(_playtime);
		if (_resourceIsUpToDate && _updateRootSystems != null)
		{
			((Systems)_updateRootSystems).Execute();
			((Systems)_updateRootSystems).Cleanup();
			if (_replayFixedUpdateRootSystems != null && Contexts.Service<ReplayPlayerService>().CanPlay())
			{
				((Systems)_replayFixedUpdateRootSystems).Execute();
				((Systems)_replayFixedUpdateRootSystems).Cleanup();
			}
		}
	}

	public void SyncTime()
	{
		Task<SyncTimeResponse> res_TimeFromServer = Contexts.Service<INetworkService>().SyncTimeFromServer();
		res_TimeFromServer.GetAwaiter().OnCompleted(delegate
		{
			int timestamp = res_TimeFromServer.Result.Timestamp;
			if (!_IsRealtimeParamInit)
			{
				_IsRealtimeParamInit = true;
				_ServerTimeWhenSynced = timestamp;
				_ClientRealTimeWhenSynced = Time.realtimeSinceStartup;
			}
			_server_local_diff = (int)(timestamp - DateTimeHelper.Now.ToUnixTimeSeconds());
			UiHelper.server_local_diff = _server_local_diff;
			if (!HotFix_Utils.TrySetPlayTime(_playtime))
			{
				_playtime = 0f;
			}
		});
	}

	public double GetServerRealtimeSeconds()
	{
		return (double)Time.realtimeSinceStartup - _ClientRealTimeWhenSynced + _ServerTimeWhenSynced;
	}

	public long GetServerTime()
	{
		return DateTimeHelper.Now.ToUnixTimeSeconds() + _server_local_diff;
	}

	public int GetServerTimestamp()
	{
		return (int)_ServerTimeWhenSynced;
	}

	private void OnDestroy()
	{
		SharedMessenger.RemoveListener<Level>("BATTLE_START", OnBattleStart);
		SharedMessenger.RemoveListener<PlayBattleReplayData, CustomTaskCompletionSource<bool>>("ACTION_PLAY_BATTLE_REPLAY", OnPlayBattleReplay);
		SharedMessenger.RemoveListener("DESTROY_BATTLE_CONTEXTS", OnResetReplayContexts);
		SharedMessenger.RemoveListener<NeedRestartResponse>("NEED_RESTART", OnNeedRestart);
		SharedMessenger.RemoveListener<NeedReLoginResponse>("NEED_RE_LOGIN", OnNeedReLogin);
		if (_resourceIsUpToDate && _updateRootSystems != null)
		{
			((Systems)_updateRootSystems).DeactivateReactiveSystems();
			((Systems)_updateRootSystems).ClearReactiveSystems();
			((Systems)_updateRootSystems).TearDown();
		}
	}

	private void CreateLoginServices(Contexts contexts)
	{
		UnityViewService unityViewService = new UnityViewService(contexts);
		unityViewService.SetViewRoot(contexts, ((Component)this).transform);
		contexts.AddService(typeof(IUiService), UnityUiService.Instance);
		contexts.AddService(typeof(INetworkService), new NetworkService(Configs, ClientVersionInfo.Instance.UserAgent(UserAgent)));
		contexts.AddService(typeof(BaseSceneService), new SceneService(contexts));
		IService[] services = contexts.Services;
		IService[] array = services;
		foreach (IService service in array)
		{
			service.Init();
			service.AddEventsListener();
		}
		contexts.Service<INetworkService>().AddLoginFailHandler(OnLoginFail);
	}

	private void CreateServices(Contexts contexts)
	{
		UnityViewService unityViewService = new UnityViewService(contexts);
		unityViewService.SetViewRoot(contexts, ((Component)this).transform);
		contexts.AddService(typeof(IViewService), unityViewService);
		contexts.AddService(typeof(IGameDataService), GameDataService.Instance);
		contexts.AddService(typeof(IUiService), UnityUiService.Instance);
		contexts.AddService(typeof(IInputService), new UnityInputService(contexts));
		contexts.AddService(typeof(ITimeService), new TimeService(contexts));
		contexts.AddService(typeof(IStoreService), new StoreService(contexts));
		contexts.AddService(typeof(ICameraService), Singleton<CameraService>.Instance);
		contexts.AddService(typeof(ITextTranslateService), new TextTranslateService(contexts));
		contexts.AddService(typeof(IStagingService), new StagingService(contexts));
		contexts.AddService(typeof(ICreateUnitService), new CreateUnitService(contexts));
		contexts.AddService(typeof(IBattleFieldService), new BattleFieldService(contexts));
		SentrySdk.AddBreadcrumb("[CreateServices]Add NetworkService");
		contexts.AddService(typeof(INetworkService), new NetworkService(Configs, ClientVersionInfo.Instance.UserAgent(UserAgent)));
		contexts.AddService(typeof(BaseSceneService), new SceneService(contexts));
		contexts.AddService(typeof(ReplayPlayerService), new ReplayPlayerService(contexts, Configs));
		IService[] services = contexts.Services;
		IService[] array = services;
		foreach (IService service in array)
		{
			service.Init();
			service.AddEventsListener();
		}
		string token = Contexts.Service<INetworkService>().GetToken();
		SentrySdk.AddBreadcrumb("GetToken After CreateService: " + token);
		Contexts.Service<INetworkService>().SetToken(token);
	}

	private void CreateReplayServices(Contexts contexts)
	{
		UnityViewService unityViewService = new UnityViewService(contexts);
		unityViewService.SetViewRoot(contexts, ((Component)this).transform);
		contexts.AddService(typeof(IViewService), unityViewService);
		contexts.AddService(typeof(ITimeService), new TimeService(contexts));
		contexts.AddService(typeof(IBattleFieldService), new BattleFieldService(contexts));
		IService[] services = contexts.Services;
		IService[] array = services;
		foreach (IService service in array)
		{
			service.Init();
			service.AddEventsListener();
		}
		contexts.AddService(typeof(ICameraService), Singleton<CameraService>.Instance);
	}

	private void ClearReplayServices(Contexts contexts)
	{
		contexts.RemoveService(typeof(ICameraService));
		contexts.ClearServices();
	}

	public void OnAnyDataReady(GameStateEntity entity)
	{
		Contexts.Service<ReplayPlayerService>().PrepareStringMap();
	}

	private void OnPlayBattleReplay(PlayBattleReplayData data, CustomTaskCompletionSource<bool> taskCompletionSource)
	{
		Action<string> value = delegate
		{
			PlayBattleReplay(data, taskCompletionSource);
		};
		Dictionary<string, object> dic = new Dictionary<string, object>
		{
			{ "LevelId", data.LevelId },
			{ "Asset", "Prefabs/BattleField" },
			{ "ForceCloseOtherUi", true },
			{ "TaskCompletionSource", null },
			{ "LoadedCallback", value }
		};
		CommandFactory.CreateOpenSceneCommand("BattleField", new SceneBattleFieldArguments(dic));
	}

	private void PlayBattleReplay(PlayBattleReplayData data, CustomTaskCompletionSource<bool> taskCompletionSource)
	{
		ClearReplayServices(ReplayContexts);
		ReplayFixedUpdateRootSystems replayFixedUpdateRootSystems = _replayFixedUpdateRootSystems;
		if (replayFixedUpdateRootSystems != null)
		{
			((Systems)replayFixedUpdateRootSystems).DeactivateReactiveSystems();
		}
		ReplayContexts.Reset();
		CreateReplayServices(ReplayContexts);
		ClientBattleFieldLogic.SetBattleFieldCameraMoveLimit(Contexts);
		_replayFixedUpdateRootSystems = new ReplayFixedUpdateRootSystems(ReplayContexts);
		((Systems)_replayFixedUpdateRootSystems).Initialize();
		ReplayContexts.gameState.isBattleStarted = true;
		Level levelInstance = GameManagers.Instance.ChapterManager.GetLevelInstance(data.LevelId);
		Contexts.gameState.ReplaceBattleFieldMapIdentifier(levelInstance.Data.MapIdentifier);
		Contexts.gameState.ReplaceBattleFieldLength(levelInstance.Data.Length);
		Contexts.gameState.ReplaceReplayMode(data.ReplayMode);
		Contexts.gameState.ReplaceReplayBattleId(data.BattleId);
		bool isPvP = RankDataHelper.IsPvPLevel(levelInstance.LevelId);
		ReplayContexts.config.ReplaceHealBarSwitcher(data.ReplayMode != 2);
		int cullingMask = Camera.main.cullingMask;
		if (data.MaskDuration > 0)
		{
			Camera.main.cullingMask = 0;
		}
		string text = "STORY0011";
		if (data.BattleId == text && HotUpdateProcess.Has_Fake_Story0011_BattleId)
		{
			data.LocalSource = true;
			data.BattleId = "5be0b7bd-9eb6-4da8-9c63-e5552527e890";
		}
		if (data.LocalSource)
		{
			Contexts.Service<ReplayPlayerService>().PlayLocalReplay(ReplayContexts, data.BattleId, data.TargetFrame, taskCompletionSource, isPvP);
		}
		else
		{
			Contexts.Service<ReplayPlayerService>().PlayOnlineReplay(ReplayContexts, data.BattleId, data.TargetFrame, taskCompletionSource, isPvP);
		}
		if (data.MaskDuration > 0)
		{
			RestoreCameraCullingMask(cullingMask, data.MaskDuration);
		}
	}

	private async void RestoreCameraCullingMask(int cullingMask, int maskDuration)
	{
		await Task.Delay(maskDuration);
		Camera.main.cullingMask = cullingMask;
	}

	public void StartInstanceZonesReplay(string battleId)
	{
		ClearReplayServices(ReplayContexts);
		ReplayFixedUpdateRootSystems replayFixedUpdateRootSystems = _replayFixedUpdateRootSystems;
		if (replayFixedUpdateRootSystems != null)
		{
			((Systems)replayFixedUpdateRootSystems).DeactivateReactiveSystems();
		}
		ReplayContexts.Reset();
		CreateReplayServices(ReplayContexts);
		ClientBattleFieldLogic.SetBattleFieldCameraMoveLimit(Contexts);
		_replayFixedUpdateRootSystems = new ReplayFixedUpdateRootSystems(ReplayContexts);
		((Systems)_replayFixedUpdateRootSystems).Initialize();
		ReplayContexts.gameState.isBattleStarted = true;
		CommandFactory.CreateStartBattleCommand(Contexts, battleId);
		Contexts.gameState.ReplaceReplayMode(3);
		Contexts.gameState.ReplaceReplayBattleId(battleId);
		Contexts.Service<ReplayPlayerService>().PlayOnlineReplay(ReplayContexts, battleId);
	}

	private void OnBattleStart(Level level)
	{
		string currentBattleId = GameManagers.Instance.UserArchiveManager.GetCurrentBattleId();
		ClearReplayServices(ReplayContexts);
		ReplayFixedUpdateRootSystems replayFixedUpdateRootSystems = _replayFixedUpdateRootSystems;
		if (replayFixedUpdateRootSystems != null)
		{
			((Systems)replayFixedUpdateRootSystems).DeactivateReactiveSystems();
		}
		ReplayContexts.Reset();
		CreateReplayServices(ReplayContexts);
		ClientBattleFieldLogic.SetBattleFieldCameraMoveLimit(Contexts);
		_replayFixedUpdateRootSystems = new ReplayFixedUpdateRootSystems(ReplayContexts);
		((Systems)_replayFixedUpdateRootSystems).Initialize();
		ReplayContexts.gameState.isBattleStarted = true;
		CommandFactory.CreateStartBattleCommand(Contexts, currentBattleId);
		Contexts.gameState.ReplaceReplayMode(1);
		Contexts.gameState.ReplaceReplayBattleId(currentBattleId);
		bool isPvP = RankDataHelper.IsPvPLevel(level.LevelId);
		Contexts.Service<ReplayPlayerService>().PlayOnlineReplay(ReplayContexts, currentBattleId, -1, null, isPvP);
	}

	private void OnResetReplayContexts()
	{
		try
		{
			Contexts.gameState.isBattleStarted = false;
			List<GameEntity> entities = new List<GameEntity>(((Context<GameEntity>)ReplayContexts.game).GetEntities());
			ClientBattleFieldLogic.ClearUnits(entities);
			if (_replayFixedUpdateRootSystems != null)
			{
				((Systems)_replayFixedUpdateRootSystems).Execute();
				((Systems)_replayFixedUpdateRootSystems).Cleanup();
				((Systems)_replayFixedUpdateRootSystems).DeactivateReactiveSystems();
				((Systems)_replayFixedUpdateRootSystems).ClearReactiveSystems();
				ClearReplayServices(ReplayContexts);
				ReplayContexts.Reset();
				((Systems)_replayFixedUpdateRootSystems).TearDown();
				_replayFixedUpdateRootSystems = null;
			}
		}
		catch (Exception ex)
		{
			Debug.LogError((object)ex);
		}
	}

	public void OnResourcesReady()
	{
		CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
		CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
		CallActionAfterPublishResourcesLoaded(async delegate
		{
			if ((int)Application.platform == 8)
			{
				GetIDFA();
				GetIDFV();
			}
			while (!GDMgr.isLanguageDataFinish)
			{
				await Task.Delay(100);
			}
			LanguagesManager.LoadLanguagesTemplates();
			GameLocalDataManager.ClearAllCache();
			Contexts.Service<IUiService>().OpenPanel(UI_WechatLogin.Name, new Dictionary<string, object>());
		});
	}

	private void GetIDFA()
	{
		HotFixManager.GetIDFA().Then((Action<string>)delegate(string idfa)
		{
			_idfa = idfa;
			OceanEngineEventManager.IDFA = _idfa;
			Contexts.Service<INetworkService>().SubmitDeviceIdentifier(SystemInfo.deviceUniqueIdentifier, _idfa);
		});
	}

	private void GetIDFV()
	{
		SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].BDAGetIDFV(null);
	}

	private static IEnumerator WaitForIOSUserAgentThenDoCallback(Action callback = null)
	{
		SentrySdk.AddBreadcrumb("[GameController] WaitForIOSUserAgentThenDoCallback start");
		float delayTotal = 0f;
		while (string.IsNullOrEmpty(BaseIOSSDK.UA))
		{
			yield return (object)new WaitForSeconds(0.1f);
			delayTotal += 0.1f;
			if (delayTotal > 3f)
			{
				break;
			}
		}
		yield return null;
		if (string.IsNullOrEmpty(BaseIOSSDK.UA))
		{
			ILRuntimeDebug.LogError($"[GameController]Get UA Failed, delayTotal={delayTotal}");
		}
		else
		{
			ILRuntimeDebug.LogError($"[GameController]GetUA Success, delayTotal={delayTotal}, UA={BaseIOSSDK.UA}");
		}
		callback?.Invoke();
	}

	private void GetUAFromWebView()
	{
		HotFixManager.GetUA().Then((Action<string>)delegate
		{
			((MonoBehaviour)HotUpdateProcess.Instance).StartCoroutine(WaitForIOSUserAgentThenDoCallback(delegate
			{
				_ua = BaseIOSSDK.UA;
				OceanEngineEventManager.UA = _ua;
			}));
		});
	}

	public async void TryAutoEnterGame()
	{
		if (!(HotUpdateProcess.ChannelCode == "bilibili"))
		{
			INetworkService networkService = Contexts.Service<INetworkService>();
			string token = networkService.GetToken();
			await networkService.Login(token);
		}
	}

	private void OnNeedRestart(NeedRestartResponse response)
	{
		if (!_isShowingModal)
		{
			_isShowingModal = true;
			if (GameManagers.Instance != null)
			{
				INetworkService networkService = Contexts.Service<INetworkService>();
				networkService.Stop();
			}
			Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
			Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					LanguagesManager.TryParseMultiLanguageTip(response.Tip)
				},
				{
					"Buttons",
					new Dictionary<string, Action> { { "Confirm", Quit } }
				},
				{ "PageIndex", 4 },
				{ "ClickSound", "Confirm" },
				{ "Order", 999999 }
			}, multiMode: false, ignoreQueue: true);
			Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			UnityUiService.Instance.FairyGuiSwitchTouchEnable(enable: true);
			FGUIManager.Instance.MaskCover.Destroy();
		}
	}

	private async void Restart()
	{
		OnResetReplayContexts();
		GameEntity[] entities = ((Context<GameEntity>)Contexts.game).GetEntities();
		GameEntity[] array = entities;
		foreach (GameEntity entity in array)
		{
			if (entity.hasAsset)
			{
				entity.RemoveAsset();
			}
		}
		if (entities.Length != 0)
		{
			await Task.Delay(100);
		}
		Configs = null;
		UnityUiService.Instance.CloseAll();
		((MonoBehaviour)UnityUiService.Instance).StopAllCoroutines();
		((MonoBehaviour)FGUIManager.Instance).StopAllCoroutines();
		((MonoBehaviour)VersionManager.Instance).StopAllCoroutines();
		if (GameManagers.Instance != null && GameManagers.Instance.Initialized)
		{
			GameManagers.Instance.RemoveEventListeners();
		}
		bool isLogin = GameManagers.Instance != null;
		GameManagers.Instance = null;
		if (isLogin)
		{
			ResetECS();
			await Task.Delay(30);
		}
		HotFix_Utils.Restart();
	}

	private void OnNeedReLogin(NeedReLoginResponse response)
	{
		if (!_isShowingModal)
		{
			INetworkService networkService = Contexts.Service<INetworkService>();
			networkService.Logout();
			if (GameManagers.Instance != null)
			{
				networkService.Stop();
			}
			_isShowingModal = true;
			Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
			Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					LanguagesManager.TryParseMultiLanguageTip(response.Tip)
				},
				{
					"Buttons",
					new Dictionary<string, Action> { { "Confirm", Quit } }
				},
				{ "PageIndex", 4 },
				{ "ClickSound", "Confirm" },
				{ "Order", 999999 }
			}, multiMode: false, ignoreQueue: true);
		}
	}

	private void ResetECS()
	{
		if (_updateRootSystems != null)
		{
			((Systems)_updateRootSystems).DeactivateReactiveSystems();
			((Systems)_updateRootSystems).ClearReactiveSystems();
		}
		SentrySdk.AddBreadcrumb("GameController Clear Services");
		Contexts.ClearServices();
		Contexts.Reset();
		if (_updateRootSystems != null)
		{
			((Systems)_updateRootSystems).TearDown();
			_updateRootSystems = null;
		}
	}

	private static void CallActionAfterPublishResourcesLoaded(Action action)
	{
		PooledList<Promise<AssetBundle>> list = ObjectPool<PooledList<Promise<AssetBundle>>>.Spawn((Func<PooledList<Promise<AssetBundle>>>)(() => new PooledList<Promise<AssetBundle>>()));
		((List<Promise<AssetBundle>>)(object)list).Add(AssetsManager.Instance.LoadAssetBundle("FGUI/PublicResources/PublicResources_desc.ab"));
		((List<Promise<AssetBundle>>)(object)list).Add(AssetsManager.Instance.LoadAssetBundle("FGUI/PublicResources/PublicResources_res.ab"));
		((List<Promise<AssetBundle>>)(object)list).Add(AssetsManager.Instance.LoadAssetBundle("FGUI/PublicResourcesRGB/PublicResourcesRGB_desc.ab"));
		((List<Promise<AssetBundle>>)(object)list).Add(AssetsManager.Instance.LoadAssetBundle("FGUI/PublicResourcesRGB/PublicResourcesRGB_res.ab"));
		Promise<AssetBundle>.All((IEnumerable<IPromise<AssetBundle>>)list).Then((Action<IEnumerable<AssetBundle>>)delegate(IEnumerable<AssetBundle> assetBundles)
		{
			AssetBundle val = null;
			AssetBundle val2 = null;
			AssetBundle val3 = null;
			AssetBundle val4 = null;
			int num = 0;
			foreach (AssetBundle assetBundle in assetBundles)
			{
				switch (num)
				{
				case 0:
					val = assetBundle;
					break;
				case 1:
					val2 = assetBundle;
					break;
				case 2:
					val3 = assetBundle;
					break;
				case 3:
					val4 = assetBundle;
					break;
				}
				num++;
			}
			if (val != null && val2 != null)
			{
				UIPackage.AddPackage(val, val2);
				Type.GetType("UI.PublicResources.PublicResourcesBinder")?.GetMethod("BindAll")?.Invoke(null, null);
			}
			else
			{
				Debug.LogWarning((object)"FGUI publicresource load failed.");
			}
			if (val3 != null && val4 != null)
			{
				UIPackage.AddPackage(val3, val4);
				action();
			}
			else
			{
				Debug.LogWarning((object)"FGUI publicresourcergb load failed.");
			}
		}).Finally((Action)delegate
		{
			list.UnSpawn();
		});
	}

	public static void OnUserCredentialsOperation(string tipText, int reason)
	{
		WillRestart = true;
		Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		LegendItemsHelper.ClearLegendItems();
		LegendItemDungeonUiHelper.ClearDungeonData();
		GameManagers.Instance?.WorldMapManager.ClearDicCache();
		Contexts.gameState.isUserDataLoaded = false;
		Contexts.gameState.isDataReady = false;
		Contexts.gameState.isGameDataLoaded = false;
		GameManagers.Instance?.UserArchiveManager.ReLoad();
		Contexts.Service<INetworkService>().Logout();
		ThinkingDataHelper.Instance.Logout();
		SDKManager.Instance.Logout();
		Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
		if (ShouldQuitManually())
		{
			HotFix_Utils.ShowAppClosedTip((CloseAppReason)reason);
		}
		else
		{
			UnityUiService.Instance.OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					tipText ?? ""
				},
				{
					"Buttons",
					new Dictionary<string, Action> { 
					{
						"Confirm",
						HotFix_Utils.Quit
					} }
				},
				{ "PageIndex", 4 },
				{ "ClickSound", "Confirm" },
				{ "Order", 999999 }
			});
		}
		GameLocalDataManager.ClearSelfUserLocalData();
		string selfAvatarLocalPath = UiHelper.GetSelfAvatarLocalPath();
		if (File.Exists(selfAvatarLocalPath))
		{
			File.Delete(selfAvatarLocalPath);
		}
	}

	public static void OnSwitchAccount()
	{
		WillRestart = true;
		Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		LegendItemsHelper.ClearLegendItems();
		LegendItemDungeonUiHelper.ClearDungeonData();
		string value = Contexts.gameState.user.value.UserId.ToString();
		GameLocalDataManager.ClearSelfUserLocalData();
		GameManagers.Instance.WorldMapManager.ClearDicCache();
		Contexts.gameState.isUserDataLoaded = false;
		Contexts.gameState.isDataReady = false;
		Contexts.gameState.isGameDataLoaded = false;
		GameManagers.Instance.UserArchiveManager.ReLoad();
		Contexts.Service<INetworkService>().Logout();
		ThinkingDataHelper.Instance.Logout();
		SDKManager.Instance.Logout();
		Contexts.Service<INetworkService>().SubmitDeviceLog(GameEvent.SwitchAccount, SystemInfo.deviceUniqueIdentifier, new Dictionary<string, string> { { "LastUserId", value } });
		Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
		Action value2 = delegate
		{
			SentryController.Instance.SetLogEnable(isEnable: false);
		};
		if (ShouldQuitManually())
		{
			HotFix_Utils.ShowAppClosedTip(CloseAppReason.SwitchAccount);
			return;
		}
		UnityUiService.Instance.OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				LanguagesManager.GetDesc("CsharpCodeZhTcText84") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText85")
			},
			{
				"Buttons",
				new Dictionary<string, Action> { 
				{
					"Confirm",
					HotFix_Utils.Quit
				} }
			},
			{ "PageIndex", 4 },
			{ "ClickSound", "Confirm" },
			{ "OnShowCallback_Action", value2 },
			{ "Order", 999999 }
		});
	}

	public static void Quit()
	{
		if (ShouldQuitManually())
		{
			HotFix_Utils.ShowAppClosedTip();
		}
		else
		{
			HotFix_Utils.Quit();
		}
	}

	private static bool ShouldQuitManually()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		return (int)Application.platform == 8;
	}
}
