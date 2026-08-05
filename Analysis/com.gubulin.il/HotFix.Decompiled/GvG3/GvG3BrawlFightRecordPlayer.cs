using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FairyGUI;
using GvG3OnIsland;
using HotFix.Sources.Base.Scripts.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3OnIsland.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3OnIsland.Model;
using Shift.Legion.ClientApi;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.GvGMode3Island;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;
using Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using Shift.Legion.Helpers;
using UI.GvGOnIsland3;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GvG3;

public class GvG3BrawlFightRecordPlayer : GvG3IslandController
{
	private enum PlayState
	{
		NotInit,
		Stop,
		NeedInit,
		Jump,
		Playing
	}

	private class FightMatch
	{
		public int FromId;

		public int TragetId;
	}

	private AudioSource _bgm;

	private PlayState _state;

	private double _currentSecond;

	private long _currentFrame;

	public const int FramePerSecond = 15;

	private string _framePath;

	private double _lastStepTime;

	private BrawlReplayInfo _header;

	private bool _isPause;

	private string _recordName;

	private bool _debugGroupMissing;

	private Dictionary<int, Gvg3GroupBrawlFight> _allGroup;

	private float _playSpeed;

	private Queue<BaseBrawlReplay> _workingQueue;

	private int _lastReplaySecond;

	private Gvg3GroupBrawlFight _myGroup;

	private int _stepIndex;

	private Queue<FightMatch> _fightMatches;

	private int _myShipEntityId;

	public Action<BrawlReplay_Result> OnPlayComplete;

	public Action<S2C_GvGMode3IslandRank.Request> OnPushIslandRank;

	public Action<int, int> SetSoldierRemainCount;

	public Action<Gvg3GroupBrawlFight> OnPushMyShipAliveState;

	public Action<S2C_BrawlReplayNotification.Request> OnPushNotification;

	public Gvg3GroupBrawlFight MyGroup => _myGroup;

	public float PlaySpeed
	{
		get
		{
			return _playSpeed;
		}
		set
		{
			_playSpeed = value;
			if (!_isPause)
			{
				Time.timeScale = value;
			}
		}
	}

	public float CurrentTime => Mathf.Min((float)_currentSecond, MaxTime);

	public float MaxTime => (float)_header.MaxFrames / 15f;

	public bool IsPause => _isPause;

	public static GvG3BrawlFightRecordPlayer CreatePlayer()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		GvG3IslandController.GvGIslandMap = Addressables.InstantiateAsync((object)"GvG/IslandBattleField_BrawlEvent_1", (Transform)null, false, true).WaitForCompletion();
		GvG3BrawlFightRecordPlayer gvG3BrawlFightRecordPlayer = GvG3IslandController.GvGIslandMap.AddComponent<GvG3BrawlFightRecordPlayer>();
		((Object)GvG3IslandController.GvGIslandMap).name = "GvGIsland_BrawlFight";
		GvG3IslandController.Instance = gvG3BrawlFightRecordPlayer;
		GvG3IslandController.IsInstanceCreated = true;
		gvG3BrawlFightRecordPlayer._state = PlayState.NotInit;
		gvG3BrawlFightRecordPlayer._playSpeed = 1f;
		gvG3BrawlFightRecordPlayer.InitBgm();
		gvG3BrawlFightRecordPlayer.CameraBindingManager.CamOffset = new Vector3(0f, 96f, -100f);
		gvG3BrawlFightRecordPlayer.CameraBindingManager.FollowImmediately();
		return gvG3BrawlFightRecordPlayer;
	}

	private void InitBgm()
	{
		_bgm = GvG3IslandController.GvGIslandMap.AddComponent<AudioSource>();
		if (UiAudioManager.Instance.bgmSwitch)
		{
			AssetsManager.Instance.LoadAsset<AudioClip>("GVG_BGM").Then((Action<AudioClip>)delegate(AudioClip clip)
			{
				_bgm.clip = clip;
				_bgm.playOnAwake = false;
				_bgm.loop = true;
				_bgm.Play();
			});
		}
	}

	public void InitRecord(string recordUrl, int stepIdx)
	{
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(recordUrl);
		string text = Path.Combine(Application.persistentDataPath, "replays", fileNameWithoutExtension);
		try
		{
			if (!Directory.Exists(text))
			{
				ZipHelper.UnZip(recordUrl, text);
			}
			_recordName = fileNameWithoutExtension;
			_framePath = text;
			_state = PlayState.Stop;
			_stepIndex = stepIdx;
			string path = Path.Combine(text, "BrawlReplayInfo.info");
			string json = File.ReadAllText(path);
			_header = JsonHelper.ToObject<BrawlReplayInfo>(json);
			CampShipCount_Dict = new Dictionary<int, int>();
			_allGroup = new Dictionary<int, Gvg3GroupBrawlFight>();
			_workingQueue = new Queue<BaseBrawlReplay>();
			_fightMatches = new Queue<FightMatch>();
			_myShipEntityId = -1;
		}
		catch (Exception arg)
		{
			ILRuntimeDebug.LogError($"Failed to init replay player, recordUrl={recordUrl}, error={arg}");
			Directory.Delete(text, recursive: true);
			throw;
		}
	}

	public void PlayRecord(int startSecond)
	{
		startSecond = Mathf.Max(startSecond, 0);
		PlaySpeed = 1f;
		_currentSecond = startSecond;
		_isPause = false;
		_state = PlayState.NeedInit;
	}

	public void SetPause(bool isPause)
	{
		_isPause = isPause;
		Time.timeScale = (isPause ? 0f : PlaySpeed);
		GameManagers.Instance.Messenger.Broadcast("GVG3_BRAWL_FIGHT_SET_PASUE", isPause);
		_lastStepTime = GameController.Instance.GetServerRealtimeSeconds();
	}

	public void Stop()
	{
		_state = PlayState.Stop;
		BrawlReplay_Result result = _header.Result;
		OnPlayComplete?.Invoke(result);
	}

	protected override void Update()
	{
		base.Update();
		if (_state == PlayState.NeedInit)
		{
			InitStep();
		}
		else if (_state == PlayState.Jump)
		{
			JumpStep();
		}
		else if (_state == PlayState.Playing && !_isPause)
		{
			Step();
			StepFightingMatch();
		}
	}

	private void Step()
	{
		double serverRealtimeSeconds = GameController.Instance.GetServerRealtimeSeconds();
		double num = serverRealtimeSeconds - _lastStepTime;
		_lastStepTime = serverRealtimeSeconds;
		_currentSecond += num * (double)PlaySpeed;
		long num2 = (long)Math.Floor(_currentSecond * 15.0);
		int targetSecond = Mathf.CeilToInt((float)_currentSecond);
		PrepareData(targetSecond);
		while (_workingQueue.Count > 0)
		{
			BaseBrawlReplay baseBrawlReplay = _workingQueue.Peek();
			if (baseBrawlReplay.Frame <= num2)
			{
				Render(baseBrawlReplay);
				_workingQueue.Dequeue();
				continue;
			}
			break;
		}
		if (num2 > _header.MaxFrames)
		{
			Stop();
		}
	}

	private void InitStep()
	{
		_currentFrame = 0L;
		string text = Path.Combine(_framePath, "Init");
		if (!DecodeSingleFile(text))
		{
			throw new Exception("Decode failed: missing Init Frame - " + text);
		}
		_state = PlayState.Jump;
	}

	private void JumpStep()
	{
		int num = Mathf.FloorToInt((float)_currentSecond);
		int num2 = -1;
		foreach (int item in _header.KeyFrameInfo)
		{
			if (item <= num && item > num2)
			{
				num2 = item;
			}
		}
		if (num2 == 0)
		{
			_currentFrame = 4L;
		}
		else
		{
			_currentFrame = num2 * 15;
		}
		_fightMatches.Clear();
		string framePath = Path.Combine(_framePath, $"Key_{num2}");
		DecodeSingleFile(framePath);
		AfterJumpKeyFrame();
		_workingQueue.Clear();
		_lastReplaySecond = num2;
		_lastStepTime = GameController.Instance.GetServerRealtimeSeconds();
		_state = PlayState.Playing;
	}

	private bool DecodeSingleFile(string framePath)
	{
		bool result = false;
		FrameBrawlReplay frameBrawlReplay = null;
		if (File.Exists(framePath))
		{
			byte[] data = File.ReadAllBytes(framePath);
			frameBrawlReplay = data.Deserialize<FrameBrawlReplay>();
			if (frameBrawlReplay.Info != null && frameBrawlReplay.Info.Count > 0)
			{
				foreach (BaseBrawlReplay item in frameBrawlReplay.Info)
				{
					Decode(item);
				}
			}
			result = true;
		}
		else
		{
			ILRuntimeDebug.LogError("Frame missing -- " + framePath);
		}
		return result;
	}

	public void JumpToSecond(int seconds)
	{
		_currentSecond = seconds;
		_state = PlayState.Jump;
	}

	private void PrepareData(int targetSecond)
	{
		if (_lastReplaySecond >= targetSecond)
		{
			return;
		}
		for (int i = _lastReplaySecond + 1; i <= targetSecond; i++)
		{
			string path = Path.Combine(_framePath, $"{i}");
			if (!File.Exists(path))
			{
				continue;
			}
			byte[] data = File.ReadAllBytes(path);
			FrameBrawlReplay frameBrawlReplay = data.Deserialize<FrameBrawlReplay>();
			if (frameBrawlReplay.Info != null && frameBrawlReplay.Info.Count > 0)
			{
				foreach (BaseBrawlReplay item in frameBrawlReplay.Info)
				{
					if (item.Frame > _currentFrame)
					{
						_workingQueue.Enqueue(item);
					}
				}
			}
			_lastReplaySecond = i;
		}
	}

	private void Render(BaseBrawlReplay replay)
	{
		_currentFrame = replay.Frame;
		Decode(replay);
	}

	public void Release()
	{
		GvG3IslandController.Instance = null;
		GvG3IslandController.IsInstanceCreated = false;
		Time.timeScale = 1f;
		_bgm.Stop();
		UnRegisterEventListeners();
		Singleton<CameraService>.Instance.ClearSkybox();
		CameraBindingManager.OnDestroy();
		Addressables.ReleaseInstance(GvG3IslandController.GvGIslandMap);
		GvG3TipsManager.Instance.StopAllTips();
		if (_debugGroupMissing)
		{
			ILRuntimeDebug.LogError("[BrawlFightPlayer] Missing Group: " + _recordName);
		}
	}

	protected override void Zoom(eZoomLevel level, bool isImmediate = false)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		base.ZoomLevel = level;
		float num = 17.5f;
		switch (base.ZoomLevel)
		{
		case eZoomLevel.ZoomLevel1:
			num = 17.5f;
			break;
		case eZoomLevel.ZoomLevel2:
			num = 55f;
			break;
		}
		CameraBindingManager.SetTargetCamSize(num);
		if (isImmediate)
		{
			CameraBindingManager.CamSize = num;
		}
		else
		{
			CameraBindingManager.CamSize_CatchupInTime(0.5f);
		}
		if ((Object)(object)CameraTracker != (Object)null && (Object)(object)GvG3IslandController.Instance != (Object)null)
		{
			CameraTracker.position = PosChecker_Island(base.ZoomLevel, CameraTracker.position);
		}
		OnChangeZoomLevel?.Invoke(base.ZoomLevel);
	}

	private void Decode(BaseBrawlReplay replay)
	{
		SocketManager.ePackageId packageId = (SocketManager.ePackageId)replay.PackageId;
		byte[] data = replay.Data;
		switch (packageId)
		{
		case SocketManager.ePackageId.S2C_ChangeGvGMode3BestKill:
		{
			S2C_ChangeGvGMode3BestKill.Request req2 = LoadData<S2C_ChangeGvGMode3BestKill.Request>(data);
			OnPushChangeBestKill(req2);
			break;
		}
		case SocketManager.ePackageId.S2C_BrawlReplayCreateShip:
		{
			S2C_BrawlReplayCreateShip.Request request5 = LoadData<S2C_BrawlReplayCreateShip.Request>(data);
			OnBrawlReplayCreateShip(request5);
			break;
		}
		case SocketManager.ePackageId.S2C_GvGMode3IslandRank:
		{
			S2C_GvGMode3IslandRank.Request obj = LoadData<S2C_GvGMode3IslandRank.Request>(data);
			OnPushIslandRank?.Invoke(obj);
			break;
		}
		case SocketManager.ePackageId.S2C_GvGStateChange:
		{
			S2C_GvGStateChange.Request req3 = LoadData<S2C_GvGStateChange.Request>(data);
			OnPushChangeState(req3);
			break;
		}
		case SocketManager.ePackageId.S2C_BroadcastGvGMode3BattleResult:
		{
			S2C_BroadcastGvGMode3BattleResult.Request request4 = LoadData<S2C_BroadcastGvGMode3BattleResult.Request>(data);
			if (request4.GvGMode3BattleResults == null)
			{
				break;
			}
			foreach (GvGMode3BattleResult gvGMode3BattleResult in request4.GvGMode3BattleResults)
			{
				if (gvGMode3BattleResult.ScoreChanged == null)
				{
					continue;
				}
				foreach (ScoreChangeInfo item in gvGMode3BattleResult.ScoreChanged)
				{
					item.StepIndex = _stepIndex;
				}
			}
			OnPushBattleResult(request4);
			break;
		}
		case SocketManager.ePackageId.S2C_GvGMode3ShipDead:
		{
			S2C_GvGMode3ShipDead.Request req = LoadData<S2C_GvGMode3ShipDead.Request>(data);
			OnPushShipDead(req);
			break;
		}
		case SocketManager.ePackageId.S2C_BrawlReplayKeyFrame:
		{
			S2C_BrawlReplayKeyFrame.Request request3 = LoadData<S2C_BrawlReplayKeyFrame.Request>(data);
			OnBrawlReplayKeyFrame(request3);
			break;
		}
		case SocketManager.ePackageId.S2C_BrawlReplayScoreChanged:
		{
			S2C_BrawlReplayScoreChanged.Request request2 = LoadData<S2C_BrawlReplayScoreChanged.Request>(data);
			OnPushScoreChange(request2);
			break;
		}
		case SocketManager.ePackageId.S2C_BrawlReplayNotification:
		{
			S2C_BrawlReplayNotification.Request request = LoadData<S2C_BrawlReplayNotification.Request>(data);
			OnPushBrawlReplayNotification(request);
			break;
		}
		default:
			ILRuntimeDebug.LogError($"Un-Support package id {packageId}");
			break;
		}
	}

	private void OnPushBrawlReplayNotification(S2C_BrawlReplayNotification.Request request9)
	{
		OnPushNotification?.Invoke(request9);
	}

	protected override List<GvG3PlayTipParam> GenerateTips(GvGMode3BattleResult info, GvG3Group group)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		List<GvG3PlayTipParam> list = base.GenerateTips(info, group);
		if ((Object)(object)_myGroup == (Object)null)
		{
			return list;
		}
		UI_com_GvGPlayerAvatar uI_com_GvGPlayerAvatar = (UI_com_GvGPlayerAvatar)(object)group.AvatarWrapper.Avatar.component;
		Vector3 worldPos = ((GObject)uI_com_GvGPlayerAvatar.Avatar).displayObject.cachedTransform.TransformPoint(Vector3.down * ((GObject)uI_com_GvGPlayerAvatar.Avatar).height);
		Vector2 val = EffectHelper.WorldToFguiPos(worldPos);
		if (info.ScoreChanged != null)
		{
			ScoreChangeInfo scoreChangeInfo = null;
			foreach (ScoreChangeInfo item in info.ScoreChanged)
			{
				if (item.EntityId == _myGroup.EntityId)
				{
					if (scoreChangeInfo == null)
					{
						scoreChangeInfo = item;
					}
					else
					{
						scoreChangeInfo.ChangedScore += item.ChangedScore;
					}
				}
			}
			if (scoreChangeInfo != null)
			{
				scoreChangeInfo.TipScale = ((MapViewLevel == eMapViewLevel.Island) ? 0.6f : 1f);
				list.Add(new GvG3PlayTipParam
				{
					Param = new Dictionary<string, object>
					{
						{ "ScoreChangeParam", scoreChangeInfo },
						{ "Pos", val },
						{ "Type", 4 }
					},
					ShowTime = Time.time
				});
			}
		}
		return list;
	}

	private void OnPushScoreChange(S2C_BrawlReplayScoreChanged.Request request)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)_myGroup == (Object)null) && request != null)
		{
			Gvg3GroupBrawlFight myGroup = _myGroup;
			if (request.EntityId == myGroup.EntityId)
			{
				UI_com_GvGPlayerAvatar uI_com_GvGPlayerAvatar = (UI_com_GvGPlayerAvatar)(object)myGroup.AvatarWrapper.Avatar.component;
				Vector3 worldPos = ((GObject)uI_com_GvGPlayerAvatar.Avatar).displayObject.cachedTransform.TransformPoint(Vector3.down * ((GObject)uI_com_GvGPlayerAvatar.Avatar).height);
				Vector2 val = EffectHelper.WorldToFguiPos(worldPos);
				ScoreChangeInfo scoreChangeInfo = new ScoreChangeInfo
				{
					EntityId = _myGroup.EntityId,
					ChangedScore = request.ChangedScore,
					TipScale = ((MapViewLevel == eMapViewLevel.Island) ? 0.6f : 1f),
					Par = -1f,
					StepIndex = _stepIndex
				};
				List<GvG3PlayTipParam> list = new List<GvG3PlayTipParam>();
				scoreChangeInfo.TipScale = ((MapViewLevel == eMapViewLevel.Island) ? 0.6f : 1f);
				list.Add(new GvG3PlayTipParam
				{
					Param = new Dictionary<string, object>
					{
						{ "ScoreChangeParam", scoreChangeInfo },
						{ "Pos", val },
						{ "Type", 4 }
					},
					ShowTime = Time.time
				});
				PlayTip(list);
			}
		}
	}

	private T LoadData<T>(byte[] protoBytes) where T : class
	{
		return protoBytes.Deserialize<T>();
	}

	private void OnBrawlReplayCreateShip(S2C_BrawlReplayCreateShip.Request request)
	{
		EntityInfo groupData = Cast2EntityInfo(request);
		TryCreateGroup(groupData);
	}

	private void AfterJumpKeyFrame()
	{
		CampShipCount_Dict.Clear();
		foreach (GvG3Group value2 in Dict_GvGGroup.Values)
		{
			CampShipCount_Dict[value2.CampId] = ((!CampShipCount_Dict.TryGetValue(value2.CampId, out var value)) ? 1 : (value + 1));
		}
		int total = CampShipCount_Dict.Values.Sum();
		foreach (KeyValuePair<int, int> item in CampShipCount_Dict)
		{
			OnChangeCampShipCount?.Invoke(new CampShipCount
			{
				CampId = item.Key,
				ShipCount = item.Value,
				Total = total
			});
		}
	}

	private void OnBrawlReplayKeyFrame(S2C_BrawlReplayKeyFrame.Request request)
	{
		if (!_allGroup.TryGetValue(request.EntityId, out var value))
		{
			_debugGroupMissing = true;
			return;
		}
		value.IsDead = request.IsDead;
		value.Info.IsDead = request.IsDead;
		if (request.IsDead)
		{
			value.Hide();
			if (Dict_GvGGroup.ContainsKey(request.EntityId))
			{
				RemoveGroupById(request.EntityId);
			}
		}
		else
		{
			value.Show();
			value.OnBrawlFightKeyFrame();
			if (!Dict_GvGGroup.ContainsKey(request.EntityId))
			{
				Dict_GvGGroup[request.EntityId] = value;
				if (value.UserId == UserId || value.IsBossGroup)
				{
					List_GvGGroup.Insert(0, value);
					value.IsVisibleByPriority = true;
					VisibleGroupCount++;
					return;
				}
				List_GvGGroup.Add(value);
				if (VisibleGroupCount >= 50)
				{
					return;
				}
				value.IsVisibleByPriority = true;
				VisibleGroupCount++;
			}
			S2C_GvGStateChange.Request req = new S2C_GvGStateChange.Request
			{
				EntityId = request.EntityId,
				State = request.GvGMode3State,
				X = request.X,
				Y = request.Y,
				RoleFace = request.RoleFace,
				Data = request.GvGMode3StateData
			};
			OnPushChangeState(req);
			int num = request.Total.Sum();
			SetGroupSoldierRemaining(request.EntityId, num);
			SetSoldierRemainCount?.Invoke(request.EntityId, num);
		}
		if (value.UserId == UserId)
		{
			OnPushMyShipAliveState?.Invoke(value);
		}
	}

	private static EntityInfo Cast2EntityInfo(S2C_BrawlReplayCreateShip.Request r)
	{
		return new EntityInfo
		{
			EntityId = r.EntityId,
			UserId = r.UserId,
			CampId = r.CampId,
			FormationId = r.FormationId,
			GroupSpeed = r.GroupSpeed,
			BattleStrategy = r.BattleStrategy,
			IsDead = false,
			RoleFace = r.RoleFace,
			UnitsInfo = r.UnitsInfo,
			X = r.X,
			Y = r.Y,
			GroupIconSize = r.GroupIconSize,
			debug_MatrixWidth = -1f,
			GvGMode3State = r.GvGMode3State,
			GvGMode3StateData = r.GvGMode3StateData,
			ShipRace = r.ShipRace,
			ShipSkinId = r.ShipSkinId,
			ShipId = r.ShipId,
			Icon = r.Icon,
			GvGRole = r.GvGRole
		};
	}

	protected override void TryCreateGroup(EntityInfo groupData, bool isSpawn = false)
	{
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		int entityId = groupData.EntityId;
		if (!_allGroup.ContainsKey(entityId))
		{
			GameObject val = InstantiateFromPrefab("GvGGroup");
			val.transform.SetParent(GvG3IslandController.GvGIslandMap.transform, false);
			((Object)val).name = $"Entity{groupData.EntityId}";
			Gvg3GroupBrawlFight gvg3GroupBrawlFight = val.AddComponent<Gvg3GroupBrawlFight>();
			gvg3GroupBrawlFight.Info = groupData;
			gvg3GroupBrawlFight.IsCreating = true;
			gvg3GroupBrawlFight.IsDead = false;
			gvg3GroupBrawlFight.EntityId = groupData.EntityId;
			gvg3GroupBrawlFight.UserId = groupData.UserId;
			gvg3GroupBrawlFight.GvGRole = (eGvG3Role)groupData.GvGRole;
			gvg3GroupBrawlFight.SetIsCurUser(gvg3GroupBrawlFight.UserId == UserId);
			if (gvg3GroupBrawlFight.IsCurUser)
			{
				_myShipEntityId = groupData.EntityId;
			}
			gvg3GroupBrawlFight.SetGroupDataToUI(groupData, IslandId);
			gvg3GroupBrawlFight.SetBornPos(new Vector3(groupData.X / 1000f, 0f, groupData.Y / 1000f));
			gvg3GroupBrawlFight.SetFormation(groupData.FormationId);
			gvg3GroupBrawlFight.SetUnitInfo(groupData.UnitsInfo);
			gvg3GroupBrawlFight.SetSpeed(groupData.GroupSpeed / 1000f);
			gvg3GroupBrawlFight.SetCampId(groupData.CampId);
			gvg3GroupBrawlFight.SetRoleFace(groupData.RoleFace);
			gvg3GroupBrawlFight.UpdateMapViewLevel(MapViewLevel);
			gvg3GroupBrawlFight.SetState((eGvGMode3FightingState)groupData.GvGMode3State, groupData.X, groupData.Y, groupData.RoleFace, groupData.GvGMode3StateData, groupData.HoldingScorePerSecond);
			if (groupData.debug_MatrixWidth > 0f)
			{
				gvg3GroupBrawlFight.SetDebugMatrixWidth(groupData.debug_MatrixWidth / 1000f);
			}
			if (isSpawn)
			{
				gvg3GroupBrawlFight.SetSpawning();
			}
			else
			{
				gvg3GroupBrawlFight.SetAppear();
			}
			if (gvg3GroupBrawlFight.UserId == UserId)
			{
				_myGroup = gvg3GroupBrawlFight;
				OnCreateMyShips?.Invoke(groupData);
				OnPushMyShipAliveState?.Invoke(gvg3GroupBrawlFight);
			}
			if (gvg3GroupBrawlFight.IsBossGroup)
			{
				BossGroup = gvg3GroupBrawlFight;
			}
			AddGroup(gvg3GroupBrawlFight);
			_allGroup.Add(gvg3GroupBrawlFight.EntityId, gvg3GroupBrawlFight);
			gvg3GroupBrawlFight.StopShowAnimation();
		}
	}

	protected override void CheckIslandHoldingEffectOnGroupStateChange(int entityId, eGvGMode3FightingState state)
	{
	}

	public void SetFightingTarget(int formId, int targetId)
	{
		_fightMatches.Enqueue(new FightMatch
		{
			FromId = formId,
			TragetId = targetId
		});
	}

	private void StepFightingMatch()
	{
		if (_myShipEntityId < 0)
		{
			return;
		}
		while (_fightMatches.Count > 0)
		{
			FightMatch fightMatch = _fightMatches.Peek();
			if (fightMatch.FromId == _myShipEntityId || fightMatch.TragetId == _myShipEntityId)
			{
				int key = ((fightMatch.FromId == _myShipEntityId) ? fightMatch.TragetId : fightMatch.FromId);
				if (_allGroup.TryGetValue(_myShipEntityId, out var value) && _allGroup.TryGetValue(key, out var value2))
				{
					value.SetToBeMe();
					value.MyTarget = value2;
					value2.IsCurUserTarget = true;
					value2.SetToBeTarget();
				}
			}
			_fightMatches.Dequeue();
		}
	}

	protected override void OnPushShipDead(S2C_GvGMode3ShipDead.Request req)
	{
		GvG3Group gvG3Group = RemoveGroupById(req.EntityId);
		if ((Object)(object)gvG3Group == (Object)null)
		{
			_debugGroupMissing = true;
			return;
		}
		if ((Object)(object)gvG3Group != (Object)null && gvG3Group.IsBossGroup)
		{
			BossGroup = null;
		}
		if ((Object)(object)gvG3Group != (Object)null)
		{
			gvG3Group.SetDead();
		}
		if (gvG3Group.UserId == UserId)
		{
			Gvg3GroupBrawlFight obj = (Gvg3GroupBrawlFight)gvG3Group;
			OnPushMyShipAliveState?.Invoke(obj);
		}
	}

	public override Vector3 PosChecker_Island(eZoomLevel zoomLevel, Vector3 cur)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		Vector3 zero = Vector3.zero;
		if (zoomLevel != eZoomLevel.ZoomLevel2)
		{
			zero.x = Mathf.Clamp(cur.x, -100f, 100f);
			zero.z = Mathf.Clamp(cur.z, -53f, 60f);
		}
		zero.y = cur.y;
		return zero;
	}
}
