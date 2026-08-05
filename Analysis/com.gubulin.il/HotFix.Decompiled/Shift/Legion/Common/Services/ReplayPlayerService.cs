using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Entitas;
using GameMaths;
using HotFix;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Scripts.Utils;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;
using Spine.Unity;
using UI.PvpSelectSoldiers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Shift.Legion.Common.Services;

public class ReplayPlayerService : Service
{
	private string _battleId;

	private readonly List<BattleReplay> _replays;

	private int _replayFramesCount;

	private bool _downloading;

	private int _currentReplayIndex;

	private int _currentFrameId;

	private int _currentReplayFrameIndex;

	private bool _hasMoreReplay;

	private bool _allReplayDownloaded;

	private bool _isLocalSource;

	private bool _IsPvP = false;

	private int _PvP_Idx = -1;

	private float _downloadDataDelayTime;

	private float _pvpStartBattleCountdown;

	private const float PvpStartCountdownTime = 3f;

	private int _targetFrame;

	private CustomTaskCompletionSource<bool> _taskCompletionSource;

	private Contexts _replayContexts;

	private readonly Dictionary<string, string> _configs;

	private readonly bool _isReplayCompressed = true;

	private bool _playing;

	private static List<string> SpecialParticle;

	private Dictionary<uint, string> _stringMap;

	private float tm = 0f;

	private Coroutine _Coroutine_Real_DownloadNextFragment = null;

	private Coroutine _coroutine_Pvp_Start_Countdown = null;

	public bool isCurFrameFinish = true;

	private Dictionary<string, string> _FullScreenParticleSounds = new Dictionary<string, string>
	{
		{ "shadow_area_l2r", "shadow_area" },
		{ "shadow_area_r2l", "shadow_area" },
		{ "skill_bonedragon_shadow_l2r", "bonedragon" },
		{ "skill_bonedragon_shadow_r2l", "bonedragon" },
		{ "skill_devil_race_fullscreen_red", "devil_race" },
		{ "skill_devil_race_fullscreen_red2", "devil_race" },
		{ "skill_human_race_fullscreen", "human_race" },
		{ "skill_floor_ice_fullscreen", "floor_ice" }
	};

	private Dictionary<string, Vector3> _FullScreenParticlePos = null;

	private Dictionary<string, List<float>> _Translate_Particle_Info = null;

	private const int PvpKingMaxHealth = 10000;

	private KingHealthPointsTotalRecord KingsHeathRecord;

	private readonly List<GameUnitModel> CurFrameUnits_cache = new List<GameUnitModel>();

	private readonly List<Vector2> RedTeamUnitsPositionOnUI = new List<Vector2>();

	private readonly List<Vector2> BlueTeamUnitsPositionOnUI = new List<Vector2>();

	private int CurWinnerTeam;

	public bool ShowHealthBar => base.Contexts.gameState.hasReplayMode && base.Contexts.gameState.replayMode.value != 2;

	public bool isReplayMode => base.Contexts.gameState.hasReplayMode && base.Contexts.gameState.replayMode.value == 3;

	public bool Playing => _playing;

	public bool LocalSource => _isLocalSource;

	public string ReplayBaseDir => Path.Combine(Application.persistentDataPath, "replays");

	public ReplayPlayerService(Contexts contexts, Dictionary<string, string> configs)
		: base(contexts)
	{
		SpecialParticle = new List<string> { "skill_ZBOSS_002_shield", "skill_ZBOSS_002_beam", "skill_ZBOSS_002_self_feedback", "skill_ZBOSS_002_dead" };
		_replays = new List<BattleReplay>();
		_stringMap = new Dictionary<uint, string>();
		_configs = configs;
		if (configs.TryGetValue("CR", out var value) && value == "0")
		{
			_isReplayCompressed = false;
		}
		_configs["BattleReplayLocalUrl"] = $"file://{ReplayBaseDir}{Path.DirectorySeparatorChar}";
	}

	public Dictionary<uint, string> Get_StringMap()
	{
		return _stringMap;
	}

	public void PrepareStringMap()
	{
		string json = GDMgr.LoadGameDataFileAllText(null, "StringMap");
		_stringMap = JsonHelper.ToObject<Dictionary<uint, string>>(json);
		GDMgr.ReleaseGameDataFileAllText("StringMap");
		Interface_Battle.SyncStringMap(_stringMap);
	}

	private static void AddStringToMap(string str, Dictionary<uint, string> map)
	{
		if (!string.IsNullOrEmpty(str) && !(str == "-1"))
		{
			uint key = CRC32.CalcCRC(str);
			if (!map.ContainsKey(key))
			{
				map.Add(key, str);
			}
		}
	}

	public string GetStringFromMap(uint id)
	{
		return GetStringFromMap(id, _stringMap);
	}

	private static string GetStringFromMap(uint id, Dictionary<uint, string> map)
	{
		if (map.TryGetValue(id, out var value))
		{
			return value;
		}
		return string.Empty;
	}

	public IGroup<GameEntity> GetGroupOfReplayContexts(IMatcher<GameEntity> matcher)
	{
		return ((Context<GameEntity>)_replayContexts?.game).GetGroup(matcher);
	}

	public void PlayLocalReplay(Contexts replayContexts, string battleId, int targetFrame = -1, CustomTaskCompletionSource<bool> taskCompletionSource = null, bool isPvP = false)
	{
		_isLocalSource = true;
		PlayReplay(replayContexts, battleId, targetFrame, taskCompletionSource, isPvP);
	}

	public void PlayOnlineReplay(Contexts replayContexts, string battleId, int targetFrame = -1, CustomTaskCompletionSource<bool> taskCompletionSource = null, bool isPvP = false)
	{
		_isLocalSource = false;
		PlayReplay(replayContexts, battleId, targetFrame, taskCompletionSource, isPvP);
	}

	private void PlayReplay(Contexts replayContexts, string battleId, int targetFrame = -1, CustomTaskCompletionSource<bool> taskCompletionSource = null, bool isPvP = false)
	{
		_replayContexts = replayContexts;
		_battleId = battleId;
		_targetFrame = targetFrame;
		_taskCompletionSource = taskCompletionSource;
		_currentReplayIndex = 0;
		_currentFrameId = 0;
		_currentReplayFrameIndex = 0;
		_downloadDataDelayTime = 0f;
		_replays.Clear();
		_replayFramesCount = 0;
		_downloading = false;
		_hasMoreReplay = true;
		_allReplayDownloaded = false;
		_pvpStartBattleCountdown = 0f;
		_IsPvP = isPvP;
		if (_IsPvP)
		{
			_PvP_Idx = 0;
		}
		else
		{
			_PvP_Idx = -1;
		}
		InitPvPResultEffect();
		Play();
		DownloadNextFragment();
		SharedMessenger.Broadcast("PLAY_REPLAY", battleId);
	}

	public void Play()
	{
		SharedMessenger.Broadcast("START_PLAY_REPLAY_WATCHER", _battleId);
		_playing = true;
		base.Contexts.gameState.ReplaceReplayState(1);
	}

	public void Pause()
	{
		SharedMessenger.Broadcast("STOP_PLAY_REPLAY_WATCHER", _battleId);
		_playing = false;
		base.Contexts.gameState.ReplaceReplayState(2);
	}

	public void Skip(bool forceSkip = false)
	{
		if (_targetFrame > 0 || forceSkip)
		{
			FGUIManager.Instance.CloseIEnumerator(_Coroutine_Real_DownloadNextFragment);
			_Coroutine_Real_DownloadNextFragment = null;
			if (_coroutine_Pvp_Start_Countdown != null)
			{
				FGUIManager.Instance.CloseIEnumerator(_coroutine_Pvp_Start_Countdown);
			}
			base.Contexts.gameState.ReplaceReplayState(3);
			if (base.Contexts.gameState.replayMode.value == 2)
			{
				base.Contexts.gameState.ReplaceReplayMode(1);
			}
			_taskCompletionSource?.TrySetResult(result: true);
			_battleId = null;
			Stop();
		}
	}

	public void Stop()
	{
		SharedMessenger.Broadcast("STOP_PLAY_REPLAY_WATCHER", _battleId);
		SharedMessenger.Broadcast("STOP_REPLAY", _battleId);
		_battleId = null;
		_currentReplayIndex = 0;
		_downloadDataDelayTime = 0f;
		_currentFrameId = 0;
		_currentReplayFrameIndex = 0;
		_replays.Clear();
		_replayFramesCount = 0;
		_downloading = false;
		_hasMoreReplay = false;
		_allReplayDownloaded = true;
		_playing = false;
		_isLocalSource = false;
		_pvpStartBattleCountdown = 0f;
		if (base.Contexts.gameState.hasReplayState)
		{
			base.Contexts.gameState.RemoveReplayState();
		}
		if (base.Contexts.gameState.hasReplayMode)
		{
			base.Contexts.gameState.RemoveReplayMode();
		}
	}

	public void PlayNextFrame()
	{
		tm += base.Contexts.input.deltaTime.value;
		if (tm <= 0.0333333f)
		{
			return;
		}
		int num = (int)(tm / 0.0333333f);
		tm -= 0.0333333f * (float)num;
		if ((_battleId == "5be0b7bd-9eb6-4da8-9c63-e5552527e890" && HotUpdateProcess.Has_Fake_Story0011_BattleId && !HotUpdateProcess.Loaded_Fake_Story0011_BattleId) || _battleId == null || !_playing)
		{
			return;
		}
		if (base.Contexts.gameState.replayMode.value != 2 && _replays.Count < 1 && !_allReplayDownloaded)
		{
			base.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
			return;
		}
		if (_currentReplayIndex == _replays.Count)
		{
			base.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
			return;
		}
		if (_currentReplayFrameIndex == 1)
		{
			base.Contexts.Service<IBattleFieldService>().ClearUnits();
		}
		if (_currentReplayFrameIndex == 0 && _currentReplayIndex == 0)
		{
			PlayFrameService.GetInstance().PlayFrameServiceInit(GameController.Contexts.Service<IViewService>().GetViewRoot(), GameController.Contexts.Service<ReplayPlayerService>().Get_StringMap(), AnimationManager.get_StateDict(), GameController.Contexts.Service<ReplayPlayerService>().ShowHealthBar, GameController.Contexts.config.healBarSwitcher.value, UiAudioManager.Instance.soundSwitch, -1, false);
			IGroup<GameEntity> val = ((Context<GameEntity>)base.Contexts.game).GetGroup(GameMatcher.BattleField);
			GameEntity[] entities = val.GetEntities();
			GameEntity[] array = entities;
			foreach (GameEntity gameEntity in array)
			{
				gameEntity.battleField.value.PlayAnimationWhenBattleStart();
			}
		}
		BattleReplay val2 = _replays[_currentReplayIndex];
		if (_currentReplayFrameIndex >= val2.Frames.Count)
		{
			if (val2.Winner != 0)
			{
				SharedMessenger.Broadcast("STOP_PLAY_REPLAY_WATCHER", _battleId);
				FGUIManager.Instance.CloseIEnumerator(_Coroutine_Real_DownloadNextFragment);
				if (_coroutine_Pvp_Start_Countdown != null)
				{
					FGUIManager.Instance.CloseIEnumerator(_coroutine_Pvp_Start_Countdown);
				}
				if (base.Contexts.gameState.replayMode.value != 3 || !_IsPvP)
				{
					base.Contexts.gameState.ReplaceWinner((Team)val2.Winner);
				}
				base.Contexts.gameState.ReplaceReplayState(3);
				if (base.Contexts.gameState.replayMode.value == 2)
				{
					base.Contexts.gameState.ReplaceReplayMode(1);
				}
				_battleId = null;
			}
			else
			{
				_currentReplayIndex++;
				_currentReplayFrameIndex = 0;
				PlayNextFrame();
			}
			return;
		}
		if (!base.Contexts.gameState.isCameraFollowingUnit && !_IsPvP)
		{
			foreach (Dictionary<string, Queue<GameObject>> value in UnityGameObjectPool.GetInstance().GetCache().Values)
			{
				foreach (Queue<GameObject> value2 in value.Values)
				{
					foreach (GameObject item in value2)
					{
						if (Object.op_Implicit((Object)(object)item))
						{
							Object.DestroyImmediate((Object)(object)item);
						}
					}
					value2.Clear();
				}
			}
		}
		BattleFrame val3 = val2.Frames[_currentReplayFrameIndex];
		if (_currentReplayFrameIndex < 2)
		{
			num = 1;
		}
		for (int j = 0; j < num; j++)
		{
			val3 = val2.Frames[_currentReplayFrameIndex];
			_currentReplayFrameIndex++;
			_currentFrameId++;
			PlayFrame(val3, num > 1);
			if (_currentReplayFrameIndex >= val2.Frames.Count)
			{
				break;
			}
		}
		SharedMessenger.Broadcast("REFRESH_PLAY_REPLAY_WATCHER");
		if (_IsPvP && _PvP_Idx == 0 && _currentReplayIndex == 0 && _currentReplayFrameIndex == 2 && base.Contexts.gameState.replayMode.value != 3 && _pvpStartBattleCountdown <= 3f && _coroutine_Pvp_Start_Countdown == null)
		{
			_coroutine_Pvp_Start_Countdown = FGUIManager.Instance.OpenIEnumerator(PvpBattleStartCountdown());
			_playing = false;
		}
		if (val3.Frame >= _targetFrame && _targetFrame > 0)
		{
			SentrySdk.AddBreadcrumb($"PlayNextFrame Reached TargetFrame {_targetFrame}, BattleId={_battleId}");
			SharedMessenger.Broadcast("STOP_PLAY_REPLAY_WATCHER", _battleId);
			FGUIManager.Instance.CloseIEnumerator(_Coroutine_Real_DownloadNextFragment);
			if (_coroutine_Pvp_Start_Countdown != null)
			{
				FGUIManager.Instance.CloseIEnumerator(_coroutine_Pvp_Start_Countdown);
			}
			base.Contexts.gameState.ReplaceReplayState(3);
			if (base.Contexts.gameState.replayMode.value == 2)
			{
				base.Contexts.gameState.ReplaceReplayMode(1);
			}
			_taskCompletionSource?.TrySetResult(result: true);
			SharedMessenger.Broadcast("STOP_REPLAY", _battleId);
			_battleId = null;
		}
	}

	public bool CanPlay()
	{
		if (!_playing)
		{
			return false;
		}
		if (_replays.Count == 0)
		{
			return false;
		}
		if (_currentReplayIndex == _replays.Count && !_downloading)
		{
			return false;
		}
		return true;
	}

	public int PendingFramesCount()
	{
		return _replayFramesCount - _currentFrameId;
	}

	public void DownloadNextFragment()
	{
		if (_battleId != null && _hasMoreReplay && !_allReplayDownloaded && !_downloading && _Coroutine_Real_DownloadNextFragment == null)
		{
			_downloading = true;
			_Coroutine_Real_DownloadNextFragment = FGUIManager.Instance.OpenIEnumerator(Real_DownloadNextFragment());
		}
	}

	private IEnumerator PvpBattleStartCountdown()
	{
		while (_pvpStartBattleCountdown <= 3f)
		{
			SharedMessenger.Broadcast("REFRESH_PLAY_REPLAY_WATCHER");
			yield return (object)new WaitForSeconds(1f);
			_pvpStartBattleCountdown += 1f;
		}
		_playing = true;
		_coroutine_Pvp_Start_Countdown = null;
	}

	private IEnumerator Real_DownloadNextFragment()
	{
		if (_battleId == "5be0b7bd-9eb6-4da8-9c63-e5552527e890" && HotUpdateProcess.Has_Fake_Story0011_BattleId)
		{
			while (!HotUpdateProcess.Loaded_Fake_Story0011_BattleId)
			{
				yield return null;
			}
		}
		int replayIndex = _replays.Count;
		string baseUrl = (_isLocalSource ? _configs["BattleReplayLocalUrl"] : _configs["BattleReplayServerUrl"]);
		string url = $"{baseUrl}{_battleId}/{replayIndex}?t={DateTimeHelper.TimeStamp}";
		if (_IsPvP)
		{
			url = $"{baseUrl}{_battleId}/{_PvP_Idx * 10000 + replayIndex}?t={DateTimeHelper.TimeStamp}";
		}
		Interface_Battle.DownloadNextFragment(_battleId, baseUrl, url, _isReplayCompressed);
		yield return (object)new WaitForSeconds(0.5f);
		if (_IsPvP)
		{
			if (_downloadDataDelayTime > 15f)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				_Coroutine_Real_DownloadNextFragment = null;
				_coroutine_Pvp_Start_Countdown = null;
				Stop();
				UiHelper.ShowConfirmDialog(action: delegate
				{
					CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
					{
						{ "ForceCloseOtherUi", true },
						{ "TaskCompletionSource", null },
						{
							"LoadingAnimationDirection",
							LoadingAnimationDirection.Left
						},
						{
							"OpenUiOnReturn",
							RankDataHelper.OpenPvpMainPanelOnReturnMainCity()
						}
					}));
				}, message: LanguagesManager.GetDesc("CsharpCodeZhTcText746") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText747"));
				yield break;
			}
			if (_downloadDataDelayTime == -1f)
			{
				if (_IsPvP && _PvP_Idx == 0 && _currentReplayIndex == 0 && _currentReplayFrameIndex == 2 && base.Contexts.gameState.replayMode.value != 3 && _pvpStartBattleCountdown <= 3f && _coroutine_Pvp_Start_Countdown == null)
				{
					_coroutine_Pvp_Start_Countdown = FGUIManager.Instance.OpenIEnumerator(PvpBattleStartCountdown());
					_playing = false;
				}
				else if (!isReplayMode && _coroutine_Pvp_Start_Countdown == null)
				{
					_playing = true;
				}
			}
		}
		if (_IsPvP && _downloadDataDelayTime >= 0f)
		{
			_downloadDataDelayTime += 0.5f;
		}
		_Coroutine_Real_DownloadNextFragment = null;
	}

	public void SetDownloading(bool b)
	{
		_downloading = b;
	}

	public void OnReplayDownloaded(string battleId, BattleReplay replay)
	{
		if (battleId != _battleId || ((replay != null) ? replay.Frames : null) == null || replay.ReplayIndex != _replays.Count)
		{
			_downloading = false;
			return;
		}
		_downloadDataDelayTime = -1f;
		try
		{
			_replayFramesCount += replay.Frames.Count;
			if (replay.Frames.Count > 0)
			{
				base.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
			_replays.Add(replay);
			if (replay.Winner != 0)
			{
				_allReplayDownloaded = true;
				_hasMoreReplay = false;
			}
			else if (replay.Stopped)
			{
				_allReplayDownloaded = false;
				_hasMoreReplay = true;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			SetFinishDownloadWithDelay(200);
		}
	}

	private async void SetFinishDownloadWithDelay(int milliseconds)
	{
		await Task.Delay(milliseconds);
		_downloading = false;
	}

	private void PlayFrame(BattleFrame frame, bool skip_frame)
	{
		foreach (GameAction gameStateChange in frame.GameStateChanges)
		{
			if (gameStateChange == null)
			{
				return;
			}
			PlayGameStateChangeRecord(gameStateChange);
			gameStateChange.UnSpawn();
		}
		PlayFrameService.GetInstance().Translate_FrameActions(_targetFrame, frame, _currentReplayIndex, skip_frame);
		foreach (GameAction action in frame.Actions)
		{
			if (action == null)
			{
				break;
			}
			GameAction val = action;
			GameAction val2 = val;
			UnitCreationAction val3 = (UnitCreationAction)(object)((val2 is UnitCreationAction) ? val2 : null);
			if (val3 == null)
			{
				AudioChangeAction val4 = (AudioChangeAction)(object)((val2 is AudioChangeAction) ? val2 : null);
				if (val4 == null)
				{
					ParticleCreationAction val5 = (ParticleCreationAction)(object)((val2 is ParticleCreationAction) ? val2 : null);
					if (val5 != null)
					{
						Dictionary<string, string> fullScreenParticleSounds = _FullScreenParticleSounds;
						string stringFromMap = GetStringFromMap(val5.Asset);
						if (UiAudioManager.Instance.soundSwitch && fullScreenParticleSounds.TryGetValue(stringFromMap, out var value))
						{
							FGUIManager.Instance.BattleAudioManager.PlayFullScreenSound(value);
						}
						if (SpecialParticle.Contains(stringFromMap))
						{
							FGUIManager.Instance.OpenIEnumerator(ChangeGameParticleModelRendererQueue(val5.EntityId));
						}
					}
				}
				else
				{
					string stringFromMap2 = GetStringFromMap(val4.AudioClipName);
					if (PlayFrameService.GetInstance().audio_switch && !string.IsNullOrEmpty(stringFromMap2))
					{
						FGUIManager.Instance.BattleAudioManager.AudioPreparationDicAdd(stringFromMap2, (int)val4.Volume);
					}
				}
			}
			else
			{
				string empty = string.Empty;
				if (val3.Team == 200 && base.Contexts.config.hasBattleConfig)
				{
					BattleConfig red = base.Contexts.config.battleConfig.Red;
					empty = GetStringFromMap(val3.UnitIdentifier, _stringMap);
					if (red.UnitsBorn == null)
					{
						red.UnitsBorn = new Dictionary<string, int>();
					}
					if (!red.UnitsBorn.TryGetValue(empty, out var value2))
					{
						red.UnitsBorn.Add(empty, 0);
					}
					red.UnitsBorn[empty] = value2 + 1;
				}
				if (val3.Team == 100)
				{
					empty = GetStringFromMap(val3.UnitIdentifier);
					if (empty.Equals("M11301"))
					{
						FGUIManager.Instance.OpenIEnumerator(ChangeGameUnitModelRendererQueue(val3.EntityId));
					}
				}
			}
			action.UnSpawn();
		}
	}

	private IEnumerator ChangeGameParticleModelRendererQueue(int EntityId)
	{
		if (!PlayFrameService.GetInstance().GetCache().TryGetValue(EntityId, out var gameBaseModel))
		{
			yield break;
		}
		GameParticleModel gameParticleModel = (GameParticleModel)(object)((gameBaseModel is GameParticleModel) ? gameBaseModel : null);
		if (gameParticleModel != null)
		{
			while ((Object)(object)((GameBaseModel)gameParticleModel).inst == (Object)null)
			{
				yield return (object)new WaitForFixedUpdate();
			}
			yield return (object)new WaitForFixedUpdate();
			ParticleSystem[] _particleSystems = ((GameBaseModel)gameParticleModel).inst.GetComponentsInChildren<ParticleSystem>();
			ParticleSystem[] array = _particleSystems;
			foreach (ParticleSystem system in array)
			{
				ParticleSystemRenderer particleSystemRenderer = ((Component)system).GetComponent<ParticleSystemRenderer>();
				((Renderer)particleSystemRenderer).material.renderQueue = 3101;
			}
		}
	}

	private IEnumerator ChangeGameUnitModelRendererQueue(int EntityId)
	{
		yield return (object)new WaitForSeconds(2f);
		if (!PlayFrameService.GetInstance().GetCache().TryGetValue(EntityId, out var gameBaseModel))
		{
			yield break;
		}
		GameUnitModel gameUnitModel = (GameUnitModel)(object)((gameBaseModel is GameUnitModel) ? gameBaseModel : null);
		Transform _trans = ((GameBaseModel)gameUnitModel).trans;
		if (Object.op_Implicit((Object)(object)_trans.Find("Model/ModelAnimation")))
		{
			Transform _modelAnimation = _trans.Find("Model/ModelAnimation");
			SkeletonAnimation _animation = ((Component)_modelAnimation).GetComponent<SkeletonAnimation>();
			if ((Object)(object)_animation == (Object)null)
			{
				ILRuntimeDebug.LogError($"ChangeRendererQueue Entity={EntityId} Error,can not find SkeletonAnimation");
				yield break;
			}
			MeshRenderer _MeshRenderer = ((Component)_animation).gameObject.GetComponent<MeshRenderer>();
			if ((Object)(object)_MeshRenderer == (Object)null)
			{
				ILRuntimeDebug.LogError($"ChangeRendererQueue Entity={EntityId} Error,can not find MeshRenderer");
				yield break;
			}
			int queue = ((Renderer)_MeshRenderer).sharedMaterial.renderQueue;
			((Renderer)_MeshRenderer).sharedMaterial.renderQueue = queue + 1;
			((Renderer)_MeshRenderer).material.renderQueue = queue + 1;
		}
		else
		{
			ILRuntimeDebug.LogError($"ChangeRendererQueue Entity={EntityId} Error,can not find Model/ModelAnimation Transform");
		}
	}

	private void PlayGameAction(GameAction action)
	{
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_070e: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0849: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a07: Unknown result type (might be due to invalid IL or missing references)
		//IL_089b: Unknown result type (might be due to invalid IL or missing references)
		UnitCreationAction val = (UnitCreationAction)(object)((action is UnitCreationAction) ? action : null);
		if (val == null)
		{
			UnitDestructionAction val2 = (UnitDestructionAction)(object)((action is UnitDestructionAction) ? action : null);
			if (val2 == null)
			{
				ProjectileCreationAction val3 = (ProjectileCreationAction)(object)((action is ProjectileCreationAction) ? action : null);
				if (val3 == null)
				{
					ProjectileDestructionAction val4 = (ProjectileDestructionAction)(object)((action is ProjectileDestructionAction) ? action : null);
					if (val4 == null)
					{
						ParticleCreationAction val5 = (ParticleCreationAction)(object)((action is ParticleCreationAction) ? action : null);
						if (val5 == null)
						{
							ParticleDestructionAction val6 = (ParticleDestructionAction)(object)((action is ParticleDestructionAction) ? action : null);
							if (val6 == null)
							{
								StatsChangedAction val7 = (StatsChangedAction)(object)((action is StatsChangedAction) ? action : null);
								if (val7 == null)
								{
									PositionChangedAction val8 = (PositionChangedAction)(object)((action is PositionChangedAction) ? action : null);
									if (val8 == null)
									{
										AnimationChangeAction val9 = (AnimationChangeAction)(object)((action is AnimationChangeAction) ? action : null);
										if (val9 == null)
										{
											PlayPartialAnimationAction val10 = (PlayPartialAnimationAction)(object)((action is PlayPartialAnimationAction) ? action : null);
											if (val10 == null)
											{
												ClearPartialAnimationAction val11 = (ClearPartialAnimationAction)(object)((action is ClearPartialAnimationAction) ? action : null);
												if (val11 == null)
												{
													PauseAnimationAction val12 = (PauseAnimationAction)(object)((action is PauseAnimationAction) ? action : null);
													if (val12 == null)
													{
														OpenStoneFxAction val13 = (OpenStoneFxAction)(object)((action is OpenStoneFxAction) ? action : null);
														if (val13 == null)
														{
															RemoveStoneFxAction val14 = (RemoveStoneFxAction)(object)((action is RemoveStoneFxAction) ? action : null);
															if (val14 == null)
															{
																OpenFlowLightFxAction val15 = (OpenFlowLightFxAction)(object)((action is OpenFlowLightFxAction) ? action : null);
																if (val15 == null)
																{
																	CloseFlowLightFxAction val16 = (CloseFlowLightFxAction)(object)((action is CloseFlowLightFxAction) ? action : null);
																	if (val16 == null)
																	{
																		SetUnitModelAlphaAction val17 = (SetUnitModelAlphaAction)(object)((action is SetUnitModelAlphaAction) ? action : null);
																		if (val17 == null)
																		{
																			SetUnitVisibleAction val18 = (SetUnitVisibleAction)(object)((action is SetUnitVisibleAction) ? action : null);
																			if (val18 == null)
																			{
																				SetUnitHealthBarVisibleAction val19 = (SetUnitHealthBarVisibleAction)(object)((action is SetUnitHealthBarVisibleAction) ? action : null);
																				if (val19 == null)
																				{
																					SetUnitCastBarVisibleAction val20 = (SetUnitCastBarVisibleAction)(object)((action is SetUnitCastBarVisibleAction) ? action : null);
																					if (val20 == null)
																					{
																						CastingAbilityAction val21 = (CastingAbilityAction)(object)((action is CastingAbilityAction) ? action : null);
																						if (val21 == null)
																						{
																							ChangeProjectileTargetAction val22 = (ChangeProjectileTargetAction)(object)((action is ChangeProjectileTargetAction) ? action : null);
																							if (val22 == null)
																							{
																								SetUnitIsDeadAction val23 = (SetUnitIsDeadAction)(object)((action is SetUnitIsDeadAction) ? action : null);
																								if (val23 == null)
																								{
																									UnitAssetRemovedAction val24 = (UnitAssetRemovedAction)(object)((action is UnitAssetRemovedAction) ? action : null);
																									if (val24 == null)
																									{
																										AudioChangeAction val25 = (AudioChangeAction)(object)((action is AudioChangeAction) ? action : null);
																										if (val25 != null)
																										{
																											GameEntity entityWithId = _replayContexts.game.GetEntityWithId(val25.EntityId);
																											if (entityWithId != null)
																											{
																												entityWithId.ReplaceAudioClipName(GetStringFromMap(val25.AudioClipName, _stringMap));
																												entityWithId.ReplaceAudioVolume(val25.Volume);
																											}
																										}
																									}
																									else
																									{
																										GameEntity entityWithId2 = _replayContexts.game.GetEntityWithId(val24.EntityId);
																										if (entityWithId2 != null && entityWithId2.hasAsset)
																										{
																											entityWithId2.RemoveAsset();
																										}
																									}
																								}
																								else
																								{
																									GameEntity entityWithId3 = _replayContexts.game.GetEntityWithId(val23.EntityId);
																									if (entityWithId3 != null)
																									{
																										entityWithId3.isDead = val23.Value;
																									}
																								}
																								return;
																							}
																							GameEntity entityWithId4 = _replayContexts.game.GetEntityWithId(val22.EntityId);
																							if (entityWithId4 != null)
																							{
																								entityWithId4.ReplaceTargetId(val22.TargetId);
																								if (entityWithId4.hasTargetPosition)
																								{
																									entityWithId4.RemoveTargetPosition();
																								}
																								if (entityWithId4.hasStartPosition)
																								{
																									entityWithId4.RemoveStartPosition();
																								}
																								entityWithId4.ReplaceProjectileMoveType(ProjectileMoveType.Linear);
																							}
																						}
																						else
																						{
																							GameEntity entityWithId5 = _replayContexts.game.GetEntityWithId(val21.EntityId);
																							if (entityWithId5 != null)
																							{
																								entityWithId5.ReplaceCastingAbilityCastTime(val21.CastTime);
																								entityWithId5.ReplaceCastingAbilityElapsedTime(0f);
																							}
																						}
																						return;
																					}
																					GameEntity entityWithId6 = _replayContexts.game.GetEntityWithId(val20.EntityId);
																					if (entityWithId6 != null)
																					{
																						if (_targetFrame <= 0)
																						{
																							entityWithId6.isShowCastingBar = val20.Visible;
																						}
																						entityWithId6.isCastingAbility = entityWithId6.isShowCastingBar;
																					}
																				}
																				else
																				{
																					GameEntity entityWithId7 = _replayContexts.game.GetEntityWithId(val19.EntityId);
																					if (entityWithId7 != null && _targetFrame <= 0)
																					{
																						entityWithId7.isShowHealthBar = val19.Visible;
																					}
																				}
																			}
																			else
																			{
																				GameEntity entityWithId8 = _replayContexts.game.GetEntityWithId(val18.EntityId);
																				if (entityWithId8 != null)
																				{
																					entityWithId8.isVisible = val18.Visible;
																				}
																			}
																		}
																		else
																		{
																			_replayContexts.game.GetEntityWithId(val17.EntityId)?.ReplaceAlpha(val17.Alpha, val17.Duration);
																		}
																	}
																	else
																	{
																		GameEntity entityWithId9 = _replayContexts.game.GetEntityWithId(val16.EntityId);
																		if (entityWithId9 != null && entityWithId9.hasFlowLightFx)
																		{
																			entityWithId9.RemoveFlowLightFx();
																		}
																	}
																}
																else
																{
																	_replayContexts.game.GetEntityWithId(val15.EntityId)?.ReplaceFlowLightFx(val15.Id, val15.Power, val15.Speed);
																}
															}
															else
															{
																GameEntity entityWithId10 = _replayContexts.game.GetEntityWithId(val14.EntityId);
																if (entityWithId10 != null && entityWithId10.hasSpecialFx)
																{
																	entityWithId10.RemoveSpecialFx();
																}
															}
														}
														else
														{
															_replayContexts.game.GetEntityWithId(val13.EntityId)?.ReplaceSpecialFx(1);
														}
													}
													else
													{
														GameEntity entityWithId11 = _replayContexts.game.GetEntityWithId(val12.EntityId);
														if (entityWithId11 != null && entityWithId11.hasAnimator)
														{
															entityWithId11.animator.value.PauseAnimation();
														}
													}
												}
												else
												{
													GameEntity entityWithId12 = _replayContexts.game.GetEntityWithId(val11.EntityId);
													if (entityWithId12 != null && entityWithId12.hasAnimator)
													{
														entityWithId12.animator.value.ClearTrack(val11.TrackIndex);
													}
												}
											}
											else
											{
												GameEntity entityWithId13 = _replayContexts.game.GetEntityWithId(val10.EntityId);
												if (entityWithId13 != null && entityWithId13.hasAnimator)
												{
													entityWithId13.animator.value.PlayAnimationOnTrack((AnimationName)val10.AnimationName, val10.TrackIndex, val10.Loop);
												}
											}
										}
										else
										{
											GameEntity entityWithId14 = _replayContexts.game.GetEntityWithId(val9.EntityId);
											entityWithId14?.ReplaceAnimation((AnimationName)val9.AnimationName);
											entityWithId14?.ReplaceAnimationDuration(val9.Duration);
										}
									}
									else
									{
										GameEntity entityWithId15 = _replayContexts.game.GetEntityWithId(val8.EntityId);
										UnitPosition unitPosition = val8.UnitPosition;
										entityWithId15?.ReplacePosition(new Vector3((float)unitPosition.X / 1000f, (float)unitPosition.Y / 1000f, (float)unitPosition.Z / 1000f));
										entityWithId15?.ReplaceRotation(RotationHelper.GetUnitRotationFromShortValue(unitPosition.Rotation));
									}
								}
								else
								{
									_replayContexts.game.GetEntityWithId(val7.EntityId)?.ReplaceUnitStats(val7.Stats);
								}
							}
							else
							{
								GameEntity entityWithId16 = _replayContexts.game.GetEntityWithId(val6.EntityId);
								if (entityWithId16 != null)
								{
									entityWithId16.isDestroyed = true;
								}
							}
							return;
						}
						GameEntity gameEntity = ((Context<GameEntity>)_replayContexts.game).CreateEntity();
						gameEntity.ReplaceId(val5.EntityId);
						gameEntity.isGameObject = true;
						gameEntity.isShadow = val5.IsShadow;
						gameEntity.ReplaceAsset(GetStringFromMap(val5.Asset, _stringMap));
						gameEntity.ReplaceParentId(val5.ParentId);
						if (val5.Position != null)
						{
							UnitPosition position = val5.Position;
							gameEntity.ReplacePosition(new Vector3((float)position.X / 1000f, (float)position.Y / 1000f, (float)position.Z / 1000f));
						}
						gameEntity.ReplaceParticleState((ParticleState)val5.ParticleState);
						gameEntity.ReplaceParticleBaseScale(val5.ParticleBaseScale);
						gameEntity.ReplaceScale(val5.Scale);
						if (val5.GroupTargetId > 0)
						{
							gameEntity.ReplaceGroupTargetId(val5.GroupTargetId);
						}
						if (val5.TargetId > 0)
						{
							gameEntity.ReplaceTargetId(val5.TargetId);
						}
						if (val5.BoneName != 0)
						{
							gameEntity.ReplaceBoneName(GetStringFromMap(val5.BoneName, _stringMap));
						}
						gameEntity.isParticleFollowTarget = val5.ParticleFollowTarget;
						gameEntity.isParticleFollowTargetScale = val5.ParticleFollowTargetScale;
						gameEntity.isParticleFullscreen = val5.ParticleFullscreen;
						if (gameEntity.isParticleFullscreen)
						{
							gameEntity.ReplaceParticleFullscreenLayer(val5.FullscreenLayer);
							if (val5.FullscreenStartPosition != null)
							{
								UnitPosition fullscreenStartPosition = val5.FullscreenStartPosition;
								gameEntity.ReplaceParticleFullscreenStartPosition(new Vector3((float)fullscreenStartPosition.X / 1000f, (float)fullscreenStartPosition.Y / 1000f, (float)fullscreenStartPosition.Z / 1000f));
							}
							if (val5.FullscreenEndPosition != null)
							{
								UnitPosition fullscreenEndPosition = val5.FullscreenEndPosition;
								gameEntity.ReplaceParticleFullscreenEndPosition(new Vector3((float)fullscreenEndPosition.X / 1000f, (float)fullscreenEndPosition.Y / 1000f, (float)fullscreenEndPosition.Z / 1000f));
							}
							if (val5.FullscreenMoveDuration > 0f)
							{
								gameEntity.ReplaceParticleFullscreenMoveDuration(val5.FullscreenMoveDuration);
								gameEntity.ReplaceParticleFullscreenMoveElapsedTime(0f);
							}
						}
						if (val5.AudioClipName != 0)
						{
							gameEntity.ReplaceAudioClipName(GetStringFromMap(val5.AudioClipName, _stringMap));
							gameEntity.ReplaceAudioVolume(val5.AudioVolume);
						}
						gameEntity.isVisible = val5.Visible;
					}
					else
					{
						GameEntity entityWithId17 = _replayContexts.game.GetEntityWithId(val4.EntityId);
						if (entityWithId17 != null)
						{
							entityWithId17.isDestroyed = true;
						}
					}
				}
				else
				{
					GameEntity gameEntity2 = ((Context<GameEntity>)_replayContexts.game).CreateEntity();
					gameEntity2.ReplaceId(val3.EntityId);
					gameEntity2.isProjectile = true;
					gameEntity2.isGameObject = true;
					gameEntity2.ReplaceAsset(GetStringFromMap(val3.Asset, _stringMap));
					gameEntity2.ReplaceProjectileIdentifier(GetStringFromMap(val3.ProjectileIdentifier, _stringMap));
					gameEntity2.ReplaceProjectileMoveType((ProjectileMoveType)val3.ProjectileMoveType);
					gameEntity2.ReplaceMoveSpeed(val3.MoveSpeed);
					gameEntity2.ReplaceScale(val3.Scale);
					gameEntity2.ReplaceUnitScale(val3.UnitScale);
					gameEntity2.ReplaceProjectileRatio(val3.ProjectileRatio);
					gameEntity2.ReplaceParentId(val3.ParentId);
					gameEntity2.ReplaceSourceId(val3.SourceId);
					if (val3.TargetId > 0)
					{
						gameEntity2.ReplaceTargetId(val3.TargetId);
					}
					if (val3.TargetPosition != null)
					{
						UnitPosition targetPosition = val3.TargetPosition;
						gameEntity2.ReplaceTargetPosition(new Vector3((float)targetPosition.X / 1000f, (float)targetPosition.Y / 1000f, (float)targetPosition.Z / 1000f));
					}
					gameEntity2.ReplaceLaunchBone(GetStringFromMap(val3.LaunchBone, _stringMap));
					gameEntity2.ReplaceLandingBone(GetStringFromMap(val3.LandingBone, _stringMap));
					gameEntity2.isProjectileFlying = true;
					gameEntity2.ReplaceElapsedTime(0f);
					gameEntity2.isVisible = val3.Visible;
				}
			}
			else
			{
				GameEntity entityWithId18 = _replayContexts.game.GetEntityWithId(val2.EntityId);
				if (entityWithId18 != null)
				{
					entityWithId18.isDestroyed = true;
				}
			}
			return;
		}
		GameEntity gameEntity3 = ((Context<GameEntity>)_replayContexts.game).CreateEntity();
		gameEntity3.ReplaceId(val.EntityId);
		gameEntity3.isAiObject = true;
		gameEntity3.isGameObject = true;
		gameEntity3.isUnit = true;
		gameEntity3.ReplaceUnitIdentifier(GetStringFromMap(val.UnitIdentifier, _stringMap));
		gameEntity3.ReplaceModel(GetStringFromMap(val.Model, _stringMap));
		gameEntity3.ReplaceSkin(GetStringFromMap(val.Skin, _stringMap));
		gameEntity3.ReplaceAlpha(val.Alpha, 0f);
		gameEntity3.ReplaceAnimation((AnimationName)val.AnimationName);
		gameEntity3.ReplaceAnimationDuration(val.AnimationDuration);
		gameEntity3.ReplaceUnitScale(val.UnitScale);
		gameEntity3.ReplaceShadowScale(val.ShadowScale);
		if (val.UnitImageIndicator != 0)
		{
			gameEntity3.ReplaceUnitImageIndicator(GetStringFromMap(val.UnitImageIndicator, _stringMap));
		}
		else
		{
			gameEntity3.ReplaceUnitIndicator(new Color32(val.UnitIndicatorColor));
		}
		gameEntity3.ReplaceUnitBaseImage(GetStringFromMap(val.UnitBaseImage, _stringMap));
		gameEntity3.isVisible = val.Visible;
		if (_targetFrame <= 0)
		{
			gameEntity3.isShowHealthBar = val.ShowHealthBar;
		}
		gameEntity3.ReplaceUnitStats(val.Stats);
		UnitPosition unitPosition2 = val.UnitPosition;
		gameEntity3.ReplacePosition(new Vector3((float)unitPosition2.X / 1000f, (float)unitPosition2.Y / 1000f, (float)unitPosition2.Z / 1000f));
		gameEntity3.ReplaceRotation(RotationHelper.GetUnitRotationFromShortValue(unitPosition2.Rotation));
		gameEntity3.ReplaceTeam((Team)val.Team);
		if (gameEntity3.team.value == Team.Red)
		{
			gameEntity3.ReplaceAsset("RedStandardUnitModel");
		}
		else
		{
			gameEntity3.ReplaceAsset("BlueStandardUnitModel");
		}
		if (gameEntity3.team.value == Team.Red && base.Contexts.config.hasBattleConfig)
		{
			BattleConfig red = base.Contexts.config.battleConfig.Red;
			if (red.UnitsBorn == null)
			{
				red.UnitsBorn = new Dictionary<string, int>();
			}
			if (!red.UnitsBorn.TryGetValue(gameEntity3.unitIdentifier.value, out var value))
			{
				red.UnitsBorn.Add(gameEntity3.unitIdentifier.value, 0);
			}
			red.UnitsBorn[gameEntity3.unitIdentifier.value] = value + 1;
		}
	}

	private void PlayGameStateChangeRecord(GameAction action)
	{
		SetCameraFollowingUnitRecord val = (SetCameraFollowingUnitRecord)(object)((action is SetCameraFollowingUnitRecord) ? action : null);
		if (val == null)
		{
			CameraFollowTeamRecord val2 = (CameraFollowTeamRecord)(object)((action is CameraFollowTeamRecord) ? action : null);
			if (val2 == null)
			{
				TeamHealthPointsTotalRecord val3 = (TeamHealthPointsTotalRecord)(object)((action is TeamHealthPointsTotalRecord) ? action : null);
				if (val3 == null)
				{
					BattleWaveTimeLeftRecord val4 = (BattleWaveTimeLeftRecord)(object)((action is BattleWaveTimeLeftRecord) ? action : null);
					if (val4 == null)
					{
						if (!(action is ShowBattleWaveCountdownRecord))
						{
							if (!(action is ShowBattleWaveCountdownRemovedRecord))
							{
								if (!(action is NextLevelComingRecord))
								{
									if (!(action is NextLevelComingRemovedRecord))
									{
										BattleTimeLeftRecord val5 = (BattleTimeLeftRecord)(object)((action is BattleTimeLeftRecord) ? action : null);
										if (val5 == null)
										{
											if (!(action is CurrentLevelBattleStartedRecord))
											{
												if (!(action is FreeBattleModeRecord))
												{
													if (!(action is FreeBattleModeRemovedRecord))
													{
														BattleFieldSubLevelIndexRecord val6 = (BattleFieldSubLevelIndexRecord)(object)((action is BattleFieldSubLevelIndexRecord) ? action : null);
														if (val6 == null)
														{
															SubLevelWinnerRecord val7 = (SubLevelWinnerRecord)(object)((action is SubLevelWinnerRecord) ? action : null);
															if (val7 == null)
															{
																KingHealthPointsTotalRecord val8 = (KingHealthPointsTotalRecord)(object)((action is KingHealthPointsTotalRecord) ? action : null);
																if (val8 != null)
																{
																	UpdatePvPResultState(val8);
																}
															}
															else
															{
																base.Contexts.gameState.ReplaceSubLevelWinner((Team)val7.Value);
																typeof(Interface_Battle).GetMethod("ClearObjectPools")?.Invoke(null, null);
															}
														}
														else
														{
															FGUIManager.Instance.BattleAudioManager.Enabled = true;
															base.Contexts.gameState.ReplaceBattleFieldSubLevelIndex(val6.Value);
														}
													}
													else
													{
														base.Contexts.gameState.isFreeBattleMode = false;
													}
												}
												else
												{
													base.Contexts.gameState.isFreeBattleMode = true;
												}
											}
											else
											{
												base.Contexts.gameState.isCurrentLevelBattleStarted = true;
											}
										}
										else
										{
											base.Contexts.gameState.ReplaceBattleTimeLeft(val5.Value);
										}
									}
									else
									{
										base.Contexts.gameState.isNextLevelComing = false;
									}
								}
								else
								{
									base.Contexts.gameState.isNextLevelComing = true;
								}
							}
							else
							{
								base.Contexts.gameState.isShowBattleWaveCountdown = false;
							}
						}
						else
						{
							base.Contexts.gameState.isShowBattleWaveCountdown = true;
						}
					}
					else
					{
						base.Contexts.gameState.ReplaceBattleWaveTimeLeft(val4.Value);
					}
				}
				else
				{
					base.Contexts.gameState.ReplaceTeamHealthPointsTotal(val3.RedCurrent, val3.RedTotal, val3.BlueCurrent, val3.BlueTotal);
				}
			}
			else
			{
				_replayContexts.gameState.ReplaceCameraFollowTeam((Team)val2.Value);
				base.Contexts.gameState.ReplaceCameraFollowTeam((Team)val2.Value);
			}
		}
		else
		{
			_replayContexts.gameState.isCameraFollowingUnit = val.Value;
			base.Contexts.gameState.isCameraFollowingUnit = val.Value;
		}
	}

	public Dictionary<string, Vector3> Get_FullScreenParticlePos()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		if (_FullScreenParticlePos == null)
		{
			_FullScreenParticlePos = new Dictionary<string, Vector3>
			{
				{
					"shadow_area_l2r",
					new Vector3(0f, 0.5f, 24.6f)
				},
				{
					"skill_bonedragon_shadow_l2r",
					new Vector3(0f, 0f, 25f)
				},
				{
					"shadow_area_r2l",
					new Vector3(0f, 0.5f, 24.6f)
				},
				{
					"skill_bonedragon_shadow_r2l",
					new Vector3(0f, 0f, 25f)
				},
				{
					"skill_devil_race_fullscreen_red",
					new Vector3(0f, 0.5f, 24.6f)
				},
				{
					"skill_devil_race_fullscreen_red2",
					new Vector3(0f, 0.5f, 24.6f)
				},
				{
					"skill_human_race_fullscreen",
					new Vector3(0f, 0.5f, 24.6f)
				},
				{
					"skill_ZBOSS_001_human",
					new Vector3(0f, 0.5f, 24.6f)
				},
				{
					"skill_ZBOSS_002_fullscreen",
					new Vector3(0f, 0.5f, 24.6f)
				},
				{
					"skill_ZBOSS_002_fullscreen_2",
					new Vector3(0f, 0.5f, 24.6f)
				}
			};
		}
		return _FullScreenParticlePos;
	}

	public Dictionary<string, List<float>> Get_Translate_Particle_Info()
	{
		if (_Translate_Particle_Info == null)
		{
			_Translate_Particle_Info = new Dictionary<string, List<float>>
			{
				{
					"skill_missile_lightning_blue",
					new List<float> { 50f, 0f, 1f, 0f }
				},
				{
					"skill_missile_lightning_darkred",
					new List<float> { 50f, 0f, 1f, 0f }
				},
				{
					"skill_missile_lightning_yellow",
					new List<float> { 50f, 0f, 1f, 0f }
				}
			};
		}
		return _Translate_Particle_Info;
	}

	public string GetCurrentStatusInfo()
	{
		string text = "battleId=" + _battleId + ", " + $"playing={_playing}, " + $"replaysCnt={_replays.Count}, " + $"replayFramesCount={_replayFramesCount}, " + $"currentFrameId={_currentFrameId}, " + $"currentReplayIndex={_currentReplayIndex}, " + $"currentReplayFrameIndex={_currentReplayFrameIndex}, " + $"downloading={_downloading}, " + $"downloadDataDelayTime={_downloadDataDelayTime}";
		Level currentLevel = GameController.Contexts.Service<IBattleFieldService>().CurrentLevel;
		if (currentLevel != null)
		{
			text = text + Environment.NewLine + "curLevel=" + currentLevel.LevelId;
		}
		if (_replays.Count > _currentReplayIndex && _currentReplayIndex >= 0)
		{
			BattleReplay val = _replays[_currentReplayIndex];
			text = text + Environment.NewLine + $"winner={val.Winner}, stopped={val.Stopped}";
		}
		if (base.Contexts.gameState.hasReplayState)
		{
			text = text + Environment.NewLine + $"replayState={base.Contexts.gameState.replayState.value}";
		}
		return text;
	}

	private void InitPvPResultEffect()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		KingsHeathRecord = new KingHealthPointsTotalRecord
		{
			BlueCurrent = 10000,
			RedCurrent = 10000,
			BlueTotal = 10000,
			RedTotal = 10000
		};
		CurFrameUnits_cache.Clear();
		RedTeamUnitsPositionOnUI.Clear();
		BlueTeamUnitsPositionOnUI.Clear();
	}

	private void UpdatePvPResultState(KingHealthPointsTotalRecord kingsHealth)
	{
		int num = 10000 - kingsHealth.RedCurrent;
		int num2 = 10000 - kingsHealth.BlueCurrent;
		KingHealthPointsTotalRecord kingsHeathRecord = KingsHeathRecord;
		kingsHeathRecord.RedCurrent -= num;
		KingHealthPointsTotalRecord kingsHeathRecord2 = KingsHeathRecord;
		kingsHeathRecord2.BlueCurrent -= num2;
		SentrySdk.AddBreadcrumb($"UpdatePvPResultState {_PvP_Idx}/{RankDataHelper.info.NeedLegionSize}");
		Pause();
		EffectHelper.CoroutineDelay(0.45f, delegate
		{
			StartPvpResultEffect();
		});
	}

	private void StartPvpResultEffect()
	{
		UpdateCurFrameUnitsCache();
		EffectHelper.CoroutineDelay(0.3f, delegate
		{
			foreach (GameUnitModel item in CurFrameUnits_cache)
			{
				((GameBaseModel)item).Destroy();
			}
		});
		Action action = delegate
		{
			if (_PvP_Idx < RankDataHelper.info.NeedLegionSize - 1 && KingsHeathRecord.RedCurrent > 0 && KingsHeathRecord.BlueCurrent > 0)
			{
				FGUIManager.Instance.BattleAudioManager?.AllAudioClipsRelease();
				foreach (Dictionary<string, Queue<GameObject>> value in UnityGameObjectPool.GetInstance().GetCache().Values)
				{
					foreach (Queue<GameObject> value2 in value.Values)
					{
						foreach (GameObject item2 in value2)
						{
							if (Object.op_Implicit((Object)(object)item2))
							{
								Addressables.ReleaseInstance(item2);
							}
						}
					}
				}
				_replays.Clear();
				PlayFrameService.GetInstance().PlayFrameServiceDestroy();
				_PvP_Idx++;
				SharedMessenger.Broadcast("ON_PVP_REPLAY_NEXT_WAVE", _PvP_Idx);
				_currentReplayIndex = 0;
				_currentFrameId = 0;
				_currentReplayFrameIndex = 0;
				_replayFramesCount = 0;
				_allReplayDownloaded = false;
				_hasMoreReplay = true;
			}
			RankDataHelper.info.RealLegionSize = _PvP_Idx + 1;
			SentrySdk.AddBreadcrumb($"UpdatePvPResultState Finish {_PvP_Idx}/{RankDataHelper.info.NeedLegionSize}");
			Play();
			CurFrameUnits_cache.Clear();
			RedTeamUnitsPositionOnUI.Clear();
			BlueTeamUnitsPositionOnUI.Clear();
		};
		Dictionary<string, object> arg = new Dictionary<string, object>
		{
			{ "onFinished", action },
			{ "PvP_Idx", _PvP_Idx },
			{ "kingsHealth", KingsHeathRecord },
			{ "redAttackerSpawnPos", RedTeamUnitsPositionOnUI },
			{ "blueAttackerSpawnPos", BlueTeamUnitsPositionOnUI },
			{ "curWinnerTeam", CurWinnerTeam }
		};
		if (UnityUiService.Instance.DictUI.ContainsKey(UI_PvPBattleResultAnimationEffect.Name))
		{
			SharedMessenger.Broadcast("ON_PVP_RESULT_ANIM", arg);
		}
		else
		{
			action();
		}
	}

	private void UpdateCurFrameUnitsCache()
	{
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		GameUnitModel[] allUnits = PlayFrameService.GetInstance().GetAllUnits();
		GameUnitModel[] array = allUnits;
		foreach (GameUnitModel val in array)
		{
			if ((Object)(object)((GameBaseModel)val).inst == (Object)null || val.isDead || !val.isVisible || !((Object)(object)((GameBaseModel)val).trans != (Object)null))
			{
				continue;
			}
			Transform val2 = ((GameBaseModel)val).trans.Find("Model/ModelAnimation");
			if (!((Object)(object)val2 != (Object)null) || !((Object)(object)((Component)val2).gameObject != (Object)null))
			{
				continue;
			}
			SkeletonAnimation component = ((Component)val2).gameObject.GetComponent<SkeletonAnimation>();
			if ((Object)(object)component != (Object)null && ((SkeletonRenderer)component).Skeleton != null)
			{
				CurFrameUnits_cache.Add(val);
				val.OnShowHealthBar(false);
				val.OnShowCastBar(false);
				Vector3 position = ((GameBaseModel)val).position;
				if (val.team == 200)
				{
					RedTeamUnitsPositionOnUI.Add(EffectHelper.WorldToFguiPos(Vector3.op_Implicit(new Vector3(position.x, 0.7f, position.z))));
				}
				else if (val.team == 100)
				{
					BlueTeamUnitsPositionOnUI.Add(EffectHelper.WorldToFguiPos(Vector3.op_Implicit(new Vector3(position.x, 0.7f, position.z))));
				}
			}
		}
		if (CurFrameUnits_cache.Count > 0)
		{
			CurWinnerTeam = CurFrameUnits_cache[0].team;
		}
		else
		{
			CurWinnerTeam = 100;
		}
	}
}
