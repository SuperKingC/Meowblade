using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.PvpSelectSoldiers;
using UI.QuickBattle;
using UnityEngine;
using UnityEngine.Networking;

public class QuickPlayReplayService : MonoBehaviour
{
	public class Info
	{
		public bool instanceZonesReplayPlaying;

		public string LevelId;

		public Level CurLevel;

		public string BattleId;

		public string BaseUrl;

		public int Index_Downloaded;

		public bool isDownloadFinish;

		public bool isPlayingFinish;

		public int pvpTotalFramesAdded;

		public int QuickBattlePlayMultiple;

		public KingHealthPointsTotalRecord KingsHeathRecord;

		public int Frame_Downloaded;

		public int Frame_Playing;

		public int SubLevelIndex;

		public bool _IsPvP = false;

		public int _PvP_Idx = -1;

		public long LastBattleFinishAt;

		public int TargetRank;

		public float DownloadDelayTime;

		public int result;

		public List<BattleFrame> Frames;

		public BattleInfo BattleInfo;

		public Dictionary<int, QuickPlayReplayFrame> UI_UseFrames;

		public Dictionary<int, UnitInfo> UnitInfos;

		public Dictionary<int, QuickPlayReplayKeyFrame> KeyFrames;

		public List<int> canPlatFrames;

		public int GetPvpNewFrameKey(int _frame)
		{
			if (!_IsPvP)
			{
				return _frame;
			}
			return Mathf.CeilToInt((float)pvpTotalFramesAdded / (float)QuickBattlePlayMultiple) * QuickBattlePlayMultiple + _frame;
		}

		public int GetPvpDownloadedFrame(int _frame)
		{
			if (!_IsPvP)
			{
				return _frame;
			}
			return pvpTotalFramesAdded + _frame;
		}

		public int GetPvpNewWaveEntityId(int _entityId)
		{
			if (!_IsPvP)
			{
				return _entityId;
			}
			return _PvP_Idx * 10000 + _entityId;
		}

		public void Clear()
		{
			if (Frames == null)
			{
				Frames = new List<BattleFrame>();
			}
			else
			{
				Frames.Clear();
			}
			if (UnitInfos == null)
			{
				UnitInfos = new Dictionary<int, UnitInfo>();
			}
			else
			{
				UnitInfos.Clear();
			}
			if (KeyFrames == null)
			{
				KeyFrames = new Dictionary<int, QuickPlayReplayKeyFrame>();
			}
			else
			{
				KeyFrames.Clear();
			}
			if (UI_UseFrames == null)
			{
				UI_UseFrames = new Dictionary<int, QuickPlayReplayFrame>();
			}
			else
			{
				UI_UseFrames.Clear();
			}
			if (canPlatFrames == null)
			{
				canPlatFrames = new List<int>();
			}
			else
			{
				canPlatFrames.Clear();
			}
		}

		public void Reset()
		{
			LevelId = string.Empty;
			BattleId = string.Empty;
			BaseUrl = string.Empty;
			isDownloadFinish = false;
			isPlayingFinish = false;
			instanceZonesReplayPlaying = false;
			QuickBattlePlayMultiple = 2;
			_IsPvP = false;
			_PvP_Idx = -1;
			LastBattleFinishAt = 1L;
			TargetRank = 0;
			KingsHeathRecord = null;
			DownloadDelayTime = 0f;
			BattleInfo = new BattleInfo();
			BattleResultStats = new Dictionary<Team, BattleResultStats>();
			CurLevel = null;
			Clear();
			SubLevelIndex = 0;
			result = 0;
			Index_Downloaded = 0;
			pvpTotalFramesAdded = 0;
			Frame_Downloaded = 0;
			Frame_Playing = 0;
		}
	}

	public static QuickPlayReplayService Instance;

	public static int MaxBattleCount;

	public static string CurTicketIcon;

	public static Dictionary<string, object> returnUiParams;

	public static string returnUiName;

	private const int PvpKingMaxHealth = 10000;

	public static Dictionary<Team, BattleResultStats> BattleResultStats = new Dictionary<Team, BattleResultStats>();

	public static Info info;

	private int analysisFrames;

	private int try_cnt = 0;

	private List<byte[]> list_byte;

	protected Contexts Contexts { get; private set; }

	public void StartInstanceZonesReplay()
	{
	}

	public void BattleLookBack()
	{
		GameLocalDataManager.ClearReplayCache();
		PlayBattleReplayData playBattleReplayData = new PlayBattleReplayData
		{
			BattleId = info.BattleId,
			TargetFrame = info.Frames.Count - 1,
			LevelId = info.LevelId,
			LocalSource = false,
			ReplayMode = 3,
			MaskDuration = 0
		};
		info.BattleId = string.Empty;
		GameLocalDataManager.SetLastReplay(playBattleReplayData);
		GameManagers.Instance.Messenger.Broadcast<PlayBattleReplayData, CustomTaskCompletionSource<bool>>("ACTION_PLAY_BATTLE_REPLAY", playBattleReplayData, null);
	}

	public string GetCurrentStatusInfo()
	{
		string[] obj = new string[17]
		{
			"battleId=",
			info.BattleId,
			", ",
			$"isPvP={info._IsPvP}, ",
			$"pvpIdx={info._PvP_Idx}, ",
			"levelId=",
			info.LevelId,
			", ",
			$"SubLevelIndex={info.SubLevelIndex}, ",
			$"Index_Downloaded={info.Index_Downloaded}, ",
			$"pvpTotalFramesAdded={info.pvpTotalFramesAdded}, ",
			$"Frame_Downloaded={info.Frame_Downloaded}, ",
			$"Frame_Playing={info.Frame_Playing}, ",
			$"DownloadDelayTime={info.DownloadDelayTime}",
			$"UI.curFrame={UI_QuickBattlePanel.QuickBattlePanel?.GetCurFrame()}",
			null,
			null
		};
		KingHealthPointsTotalRecord kingsHeathRecord = info.KingsHeathRecord;
		object arg = ((kingsHeathRecord != null) ? new int?(kingsHeathRecord.RedCurrent) : ((int?)null));
		KingHealthPointsTotalRecord kingsHeathRecord2 = info.KingsHeathRecord;
		obj[15] = $"RedHealth {arg}/{((kingsHeathRecord2 != null) ? new int?(kingsHeathRecord2.RedTotal) : ((int?)null))}";
		KingHealthPointsTotalRecord kingsHeathRecord3 = info.KingsHeathRecord;
		object arg2 = ((kingsHeathRecord3 != null) ? new int?(kingsHeathRecord3.BlueCurrent) : ((int?)null));
		KingHealthPointsTotalRecord kingsHeathRecord4 = info.KingsHeathRecord;
		obj[16] = $"BlueHealth {arg2}/{((kingsHeathRecord4 != null) ? new int?(kingsHeathRecord4.BlueTotal) : ((int?)null))}";
		return string.Concat(obj);
	}

	private void Awake()
	{
		analysisFrames = 10;
		Instance = this;
		info = new Info();
		Contexts = GameController.Contexts;
		returnUiParams = new Dictionary<string, object>();
	}

	public void StartQuickPlay(string _LevelId, int multiple, Action action, Level curLevel, int _frames, GButton exitBtn, GButton makeWar)
	{
		ILRequestHelper<StartBattleResponse>.Request((EventContext)null, (Func<Task<StartBattleResponse>>)(() => GameController.Contexts.Service<INetworkService>().StartBattle(-1L, _LevelId, null, null, null, quickBattle: true)), (Action<StartBattleResponse>)delegate(StartBattleResponse response)
		{
			if (!response.Result)
			{
				SentrySdk.AddBreadcrumb($"Start Quick Play Failed {response.BattleId}, {curLevel.LevelId}, ErrorCode={response.ErrorCode}");
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				((GObject)exitBtn).touchable = true;
				((GObject)makeWar).touchable = true;
			}
			else if (string.IsNullOrEmpty(response.BattleId))
			{
				SentrySdk.AddBreadcrumb($"Start Quick Play Failed {response.BattleId}, {curLevel.LevelId}, ErrorCode={response.ErrorCode}");
				ILRuntimeDebug.LogError("[快速战斗] battle id 为null");
				((GObject)exitBtn).touchable = true;
				((GObject)makeWar).touchable = true;
			}
			else
			{
				SentrySdk.AddBreadcrumb("Start Quick Play " + response.BattleId + ", " + curLevel.LevelId);
				info.Reset();
				info.LevelId = _LevelId;
				info.CurLevel = curLevel;
				info.QuickBattlePlayMultiple = multiple;
				analysisFrames = _frames;
				Contexts.Service<IBattleFieldService>().QuickBattle_OnAnyBattleFieldLevel(curLevel);
				Contexts.gameState.ReplaceBattleFieldSubLevelIndex(0);
				info.BattleId = response.BattleId;
				ClientBattleFieldLogic.StartBattle(GameController.Contexts, info.BattleId, curLevel);
				StartReplay();
				action();
			}
		});
	}

	private int GetEnemyRankRange()
	{
		if (info.TargetRank < 1 || info.TargetRank > 800)
		{
			return RankDataHelper.UnlockedBlocks;
		}
		return (info.TargetRank % 100 == 0) ? (info.TargetRank / 100) : (info.TargetRank / 100 + 1);
	}

	private void CloseQuickPanel()
	{
		UI_QuickBattlePanel.QuickBattlePanel?.End();
	}

	public void StartRankQuickPlay(string _levelId, int targetRank, long lastBattleFinishAt, int multiple, Action action, Level curLevel, int _frames, GButton exitBtn, GButton makeWar, string enemyGroupName)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		info.Reset();
		info.LevelId = _levelId;
		info.CurLevel = curLevel;
		info.QuickBattlePlayMultiple = multiple;
		analysisFrames = _frames;
		info.KingsHeathRecord = new KingHealthPointsTotalRecord
		{
			BlueCurrent = 10000,
			RedCurrent = 10000,
			BlueTotal = 10000,
			RedTotal = 10000
		};
		info._IsPvP = true;
		ILRequestHelper<StartRankBattleResponse>.Request((EventContext)null, (Func<Task<StartRankBattleResponse>>)(() => GameController.Contexts.Service<INetworkService>().StartRankBattle(-1L, targetRank, lastBattleFinishAt, isQuick: true)), (Action<StartRankBattleResponse>)delegate(StartRankBattleResponse response)
		{
			if (response.ErrorCode != 0)
			{
				GameManagers.Instance.Messenger.Broadcast("PVP_RANK_BATTLE_START_FAILED", response.ErrorCode);
			}
			if (10114000 == response.ErrorCode || 10114017 == response.ErrorCode || 10114018 == response.ErrorCode || 80000012 == response.ErrorCode || 80000013 == response.ErrorCode || 80000998 == response.ErrorCode)
			{
				string desc = LanguagesManager.GetDesc("ErrorCode_" + response.ErrorCode);
				UiHelper.ShowConfirmDialog(desc, CloseQuickPanel);
				SentrySdk.AddBreadcrumb($"Start Quick Rank Play Failed {response.BattleId}, targetRank={targetRank}, ErrorCode={response.ErrorCode}");
				StartPVPQuickBattleFailed();
			}
			else if (10114016 == response.ErrorCode)
			{
				int num = (int)GameController.Instance.GetServerTime();
				DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp(num);
				DateTimeOffset dateTimeOffset2 = new DateTimeOffset(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, 10, 0, 0, DateTimeHelper.TimezoneOffset);
				int num2 = DateTimeHelper.GetTimeStamp(dateTimeOffset2);
				if (num2 < num)
				{
					num2 += 86400;
				}
				string message = string.Format("{0}{1}{2}{3}{4}{5}{6}/{7}{8}", RankDataHelper.GetPvpRankRangeText(GetEnemyRankRange()), LanguagesManager.GetDesc("CsharpCodeZhTcText489"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText490"), RankDataHelper.GetPvpRankRangeText(RankDataHelper.UnlockedBlocks), LanguagesManager.GetDesc("CsharpCodeZhTcText491"), RankDataHelper.UnlockNextBlockProgress, 50, LanguagesManager.GetDesc("CsharpCodeZhTcText492")) + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText493") + UiHelper.ParseTimeChinsesDH_Foo(num2 - num) + LanguagesManager.GetDesc("CsharpCodeZhTcText494") + Environment.NewLine + "(" + LanguagesManager.GetDesc("CsharpCodeZhTcText744") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText745") + "10" + LanguagesManager.GetDesc("CsharpCodeZhTcText547") + ")";
				UiHelper.ShowConfirmDialog(message, null);
				SentrySdk.AddBreadcrumb($"Start Quick Rank Play Failed {response.BattleId}, targetRank={targetRank}, ErrorCode={response.ErrorCode}");
				StartPVPQuickBattleFailed();
			}
			else if (!response.Result)
			{
				if (response.ErrorCode == 10114002)
				{
					ILRequestHelper.ShowErrorCodeAndData(response.ErrorCode, new object[1] { enemyGroupName });
				}
				else
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				((GObject)exitBtn).touchable = true;
				((GObject)makeWar).touchable = true;
				SentrySdk.AddBreadcrumb($"Start Quick Rank Play Failed {response.BattleId}, targetRank={targetRank}, ErrorCode={response.ErrorCode}");
				StartPVPQuickBattleFailed();
			}
			else if (string.IsNullOrEmpty(response.BattleId))
			{
				ILRuntimeDebug.LogError("[快速战斗] battle id 为null");
				((GObject)exitBtn).touchable = true;
				((GObject)makeWar).touchable = true;
				SentrySdk.AddBreadcrumb($"Start Quick Rank Play Failed {response.BattleId}, targetRank={targetRank}, ErrorCode={response.ErrorCode}");
				StartPVPQuickBattleFailed();
			}
			else
			{
				SentrySdk.AddBreadcrumb("Start Rank Quick Play " + response.BattleId);
				GameManagers.Instance.UserArchiveManager.SetCurrentBattleId(response.BattleId);
				info.TargetRank = targetRank;
				info.LastBattleFinishAt = lastBattleFinishAt;
				RankDataHelper.info = new RankBattleInfo(response.BattleId);
				RankDataHelper.info.NeedLegionSize = RankDataHelper.GetPvpLegionSize(targetRank);
				Contexts.Service<IBattleFieldService>().QuickBattle_OnAnyBattleFieldLevel(curLevel);
				Contexts.gameState.ReplaceBattleFieldSubLevelIndex(0);
				info.BattleId = response.BattleId;
				ClientBattleFieldLogic.StartBattle(GameController.Contexts, info.BattleId, curLevel);
				StartReplay();
				action();
				ThinkingDataHelper.Instance.PvpBattleStart();
				GameManagers.Instance.Messenger.Broadcast("PVP_RANK_BATTLE_START");
			}
		});
	}

	private void StartPVPQuickBattleFailed()
	{
		SharedMessenger.Broadcast("SET_UI_TOUCHABLE", UI_PvpBattleVictory.Name);
		UI_PvPBattleResultAnimationEffect.PvPBattleResultAnimationEffectPanel?.End();
		UI_QuickBattlePanel.QuickBattlePanel?.End();
		if (UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel != null)
		{
			((GObject)UI_PvpSelectSoldiersPanel.PvpSelectSoldiersPanel.ChallengeBtn.ConfirmBtn).touchable = true;
		}
	}

	private void StartReplay()
	{
		if (info._IsPvP)
		{
			info._PvP_Idx = 0;
		}
		else
		{
			info._PvP_Idx = -1;
		}
		bool flag = false;
		info.BaseUrl = (flag ? GameController.Configs["BattleReplayLocalUrl"] : GameController.Configs["BattleReplayServerUrl"]);
		((MonoBehaviour)this).StartCoroutine(WaitToDownloadNext());
		((MonoBehaviour)this).StartCoroutine(ReadReplay());
	}

	private IEnumerator ContinueReplay()
	{
		yield return (object)new WaitForFixedUpdate();
		((MonoBehaviour)this).StartCoroutine(WaitToDownloadNext());
		((MonoBehaviour)this).StartCoroutine(ReadReplay());
	}

	public bool Add_Index_Downloading(BattleReplay replay)
	{
		info.Frames.AddRange(replay.Frames);
		info.Frame_Downloaded = info.GetPvpDownloadedFrame(replay.Frames[replay.Frames.Count - 1].Frame);
		if (replay.Winner != 0)
		{
			info.isDownloadFinish = true;
			return false;
		}
		return true;
	}

	public void TryDownloadReplay()
	{
		((MonoBehaviour)this).StartCoroutine(WaitToDownloadNext(0.1f));
	}

	private IEnumerator WaitToDownloadNext(float wait_tm_s = 0f)
	{
		if (info.DownloadDelayTime > 15f && info._IsPvP)
		{
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			UiHelper.ShowConfirmDialog(LanguagesManager.GetDesc("CsharpCodeZhTcText746") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText747"), RankDataHelper.ReturnToLadderTournamentPanel);
			yield break;
		}
		yield return (object)new WaitForSeconds(wait_tm_s);
		if (info._IsPvP && info.DownloadDelayTime >= 0f)
		{
			info.DownloadDelayTime += wait_tm_s;
		}
		string url = $"{info.BaseUrl}BatchThumb/{info.BattleId}/{info.Index_Downloaded}?t={DateTimeHelper.TimeStamp}";
		if (info._IsPvP)
		{
			if (info._PvP_Idx < 0)
			{
				ILRuntimeDebug.LogError($"[ReplayInfoDebug]WaitToDownloadNext Get Wrong Info: BaseUrl={info.BaseUrl}, BattleId={info.BattleId}, LevelId={info.LevelId}, PvPIdx={info._PvP_Idx}, IndexDownloaded={info.Index_Downloaded}");
			}
			url = $"{info.BaseUrl}BatchThumb/{info.BattleId}/{info._PvP_Idx * 10000 + info.Index_Downloaded}?t={DateTimeHelper.TimeStamp}";
		}
		DownloadNextFragment(url, _isReplayCompressed: true);
	}

	private void DownloadNextFragment(string _url, bool _isReplayCompressed)
	{
		if (info.isDownloadFinish)
		{
			return;
		}
		try_cnt++;
		try
		{
			BattleUnityRequestHelper.Instance.Get(_url, 0).Then((Action<UnityWebRequest>)delegate(UnityWebRequest uwr)
			{
				try
				{
					try_cnt = 0;
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
					byte[] data = uwr.downloadHandler.data;
					if (data.Length == 0)
					{
						TryDownloadReplay();
					}
					else
					{
						info.DownloadDelayTime = -1f;
						list_byte = null;
						list_byte = data.Deserialize<List<byte[]>>();
						bool flag = false;
						if (list_byte != null)
						{
							foreach (byte[] item in list_byte)
							{
								BattleReplay replay = Interface_Battle.BattleReplay_MessagePackSerializer_Deserialize(item, _isReplayCompressed);
								flag = Add_Index_Downloading(replay);
							}
							info.Index_Downloaded += list_byte.Count;
						}
						if (flag || data.Length == 0)
						{
							TryDownloadReplay();
						}
					}
				}
				catch (Exception)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
					Debug.LogError((object)(" 0 DownloadNextFragment CatchError: URL=" + _url + "  BaseUrl=" + info.BaseUrl + " BattleId=" + info.BattleId + " LevelId=" + info.LevelId));
					TryDownloadReplay();
				}
			}).Catch((Action<Exception>)delegate
			{
				if (try_cnt > 5)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
				}
				if (try_cnt > 15)
				{
					Debug.LogWarning((object)(" 1 DownloadNextFragment CatchError: URL=" + _url + "  BaseUrl=" + info.BaseUrl + " BattleId=" + info.BattleId + " LevelId=" + info.LevelId));
				}
				TryDownloadReplay();
			});
		}
		catch (Exception)
		{
			if (try_cnt > 5)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
			}
			Debug.LogError((object)(" 2 DownloadNextFragment CatchError: URL=" + _url + "  BaseUrl=" + info.BaseUrl + " BattleId=" + info.BattleId + " LevelId=" + info.LevelId));
			TryDownloadReplay();
		}
	}

	private IEnumerator ReadReplay()
	{
		TryReadReplay();
		yield return null;
		if (!info.isPlayingFinish)
		{
			((MonoBehaviour)this).StartCoroutine(ReadReplay());
		}
	}

	private void TryReadReplay()
	{
		for (int i = 0; i < analysisFrames; i++)
		{
			if (info.Frame_Downloaded <= info.Frame_Playing)
			{
				break;
			}
			bool flag = false;
			if (info.Frame_Playing < 0 || info.Frame_Playing > info.Frames.Count - 1)
			{
				continue;
			}
			BattleFrame val = info.Frames[info.Frame_Playing];
			int pvpNewFrameKey = info.GetPvpNewFrameKey(val.Frame);
			if (!info.UI_UseFrames.ContainsKey(pvpNewFrameKey))
			{
				QuickPlayReplayFrame quickPlayReplayFrame = new QuickPlayReplayFrame();
				quickPlayReplayFrame.frame_index = pvpNewFrameKey;
				quickPlayReplayFrame.Dict_UnitShowInfo = new Dictionary<int, UnitShowInfo>();
				info.UI_UseFrames.Add(pvpNewFrameKey, quickPlayReplayFrame);
			}
			foreach (GameAction gameStateChange in val.GameStateChanges)
			{
				if (gameStateChange != null)
				{
					PlayGameStateChangeRecord(gameStateChange, pvpNewFrameKey);
					gameStateChange.UnSpawn();
				}
			}
			foreach (GameAction action in val.Actions)
			{
				if (action != null)
				{
					if (Translate_GameAction(action, pvpNewFrameKey))
					{
						flag = true;
					}
					action.UnSpawn();
				}
			}
			if (flag)
			{
				AddKeyFrame(pvpNewFrameKey, QuickPlayReplayKeyFrame.eKeyFrameType.CreateUnit);
			}
			if (info.isDownloadFinish && info.Frame_Playing + 1 == info.Frame_Downloaded)
			{
				info.isPlayingFinish = true;
				((MonoBehaviour)this).StopAllCoroutines();
				{
					foreach (KeyValuePair<int, int> item in info.BattleInfo.Frame_SubLevelIndexRecord)
					{
					}
					break;
				}
			}
			info.Frame_Playing++;
		}
	}

	private bool Translate_GameAction(GameAction action, int frame_index)
	{
		bool flag = false;
		Dictionary<int, UnitShowInfo> dict_UnitShowInfo = info.UI_UseFrames[frame_index].Dict_UnitShowInfo;
		UnitCreationAction val = (UnitCreationAction)(object)((action is UnitCreationAction) ? action : null);
		if (val == null)
		{
			UnitDestructionAction val2 = (UnitDestructionAction)(object)((action is UnitDestructionAction) ? action : null);
			if (val2 == null)
			{
				PositionChangedAction val3 = (PositionChangedAction)(object)((action is PositionChangedAction) ? action : null);
				if (val3 == null)
				{
					SetUnitIsDeadAction val4 = (SetUnitIsDeadAction)(object)((action is SetUnitIsDeadAction) ? action : null);
					if (val4 == null)
					{
						UnitScaleChangedAction val5 = (UnitScaleChangedAction)(object)((action is UnitScaleChangedAction) ? action : null);
						if (val5 != null)
						{
							Do_unitScaleChangedAction(val5, frame_index);
						}
					}
					else
					{
						Do_setUnitIsDeadAction(val4, frame_index);
					}
				}
				else
				{
					if (!dict_UnitShowInfo.ContainsKey(info.GetPvpNewWaveEntityId(val3.EntityId)))
					{
						dict_UnitShowInfo.Add(info.GetPvpNewWaveEntityId(val3.EntityId), new UnitShowInfo());
					}
					Do_positionChangedAction(val3, dict_UnitShowInfo[info.GetPvpNewWaveEntityId(val3.EntityId)]);
				}
			}
			else
			{
				Do_unitDestructionAction(val2, frame_index);
			}
		}
		else
		{
			flag |= Do_unitCreationAction(val, frame_index);
		}
		return flag;
	}

	private bool PlayGameStateChangeRecord(GameAction action, int frame_index)
	{
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0479: Expected O, but got Unknown
		bool result = false;
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
					if (val4 == null && !(action is ShowBattleWaveCountdownRecord) && !(action is ShowBattleWaveCountdownRemovedRecord) && !(action is NextLevelComingRecord) && !(action is NextLevelComingRemovedRecord))
					{
						BattleTimeLeftRecord val5 = (BattleTimeLeftRecord)(object)((action is BattleTimeLeftRecord) ? action : null);
						if (val5 == null && !(action is CurrentLevelBattleStartedRecord) && !(action is FreeBattleModeRecord) && !(action is FreeBattleModeRemovedRecord))
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
										Dictionary<string, object> dictionary = new Dictionary<string, object>();
										dictionary.Add("PvP_Idx", info._PvP_Idx);
										UpdatePvPResultState(val8, frame_index, out var winner);
										dictionary.Add("curWinnerTeam", winner);
										dictionary.Add("kingsHealth", (object)new KingHealthPointsTotalRecord
										{
											BlueCurrent = info.KingsHeathRecord.BlueCurrent,
											RedCurrent = info.KingsHeathRecord.RedCurrent,
											BlueTotal = info.KingsHeathRecord.BlueTotal,
											RedTotal = info.KingsHeathRecord.RedTotal
										});
										AddKeyFrame(frame_index, QuickPlayReplayKeyFrame.eKeyFrameType.PvpEffect, dictionary);
									}
								}
								else
								{
									info.BattleInfo.Frame_SubLevelWinnerRecord.Add(frame_index, val7.Value);
									AddKeyFrame(frame_index, QuickPlayReplayKeyFrame.eKeyFrameType.MoveMap);
								}
							}
							else
							{
								Contexts.gameState.ReplaceBattleFieldSubLevelIndex(val6.Value);
								info.SubLevelIndex = val6.Value;
								info.BattleInfo.Frame_SubLevelIndexRecord.Add(frame_index, val6.Value);
								AddKeyFrame(frame_index, QuickPlayReplayKeyFrame.eKeyFrameType.RefreshUI);
							}
						}
					}
				}
				else
				{
					info.UI_UseFrames[frame_index].blueTeamTotalHealth = val3.BlueTotal;
					info.UI_UseFrames[frame_index].blueTeamCurHealth = val3.BlueCurrent;
					info.UI_UseFrames[frame_index].redTeamCurHealth = val3.RedCurrent;
					info.UI_UseFrames[frame_index].redTeamTotalHealth = val3.RedTotal;
					if (val3.BlueTotal > 0f && val3.BlueCurrent == 0f)
					{
						info.BattleInfo.BlueTeamHealthZeroFrame = new QuickPlayReplayKeyFrame(frame_index);
					}
					if (val3.BlueTotal > 0f && val3.BlueCurrent == val3.BlueTotal)
					{
						info.BattleInfo.BlueTeamHealthMaxFrame = new QuickPlayReplayKeyFrame(frame_index);
					}
					if (val3.RedTotal > 0f && val3.RedCurrent == 0f)
					{
						info.BattleInfo.RedTeamHealthZeroFrame = new QuickPlayReplayKeyFrame(frame_index);
					}
					if (val3.RedTotal > 0f && val3.RedCurrent == val3.RedTotal)
					{
						info.BattleInfo.RedTeamHealthMaxFrame = new QuickPlayReplayKeyFrame(frame_index);
					}
					float num = 100f * val3.BlueCurrent / val3.BlueTotal;
					float num2 = 100f * val3.RedCurrent / val3.RedTotal;
					if (FGUIManager.Instance.BothHealthBarValues.ContainsKey("RedHealthBarValue"))
					{
						FGUIManager.Instance.BothHealthBarValues["RedHealthBarValue"] = num2;
					}
					else
					{
						FGUIManager.Instance.BothHealthBarValues.Add("RedHealthBarValue", num2);
					}
					if (FGUIManager.Instance.BothHealthBarValues.ContainsKey("BlueHealthBarValue"))
					{
						FGUIManager.Instance.BothHealthBarValues["BlueHealthBarValue"] = num;
					}
					else
					{
						FGUIManager.Instance.BothHealthBarValues.Add("BlueHealthBarValue", num);
					}
				}
			}
		}
		return result;
	}

	private void UpdatePvPResultState(KingHealthPointsTotalRecord kingsHealth, int frame, out Team winner)
	{
		winner = Team.Blue;
		int num = 10000 - kingsHealth.RedCurrent;
		int num2 = 10000 - kingsHealth.BlueCurrent;
		winner = ((num < num2) ? Team.Red : Team.Blue);
		KingHealthPointsTotalRecord kingsHeathRecord = info.KingsHeathRecord;
		kingsHeathRecord.RedCurrent -= num;
		KingHealthPointsTotalRecord kingsHeathRecord2 = info.KingsHeathRecord;
		kingsHeathRecord2.BlueCurrent -= num2;
		StartPvpResultEffect(frame);
	}

	private void StartPvpResultEffect(int frame)
	{
		if (info._PvP_Idx < RankDataHelper.info.NeedLegionSize - 1 && info.KingsHeathRecord.RedCurrent > 0 && info.KingsHeathRecord.BlueCurrent > 0)
		{
			info._PvP_Idx++;
			info.pvpTotalFramesAdded = info.UI_UseFrames.Count;
			info.Index_Downloaded = 0;
			info.isDownloadFinish = false;
			info.isPlayingFinish = false;
			RankDataHelper.info.RealLegionSize = info._PvP_Idx + 1;
			((MonoBehaviour)this).StartCoroutine(ContinueReplay());
		}
	}

	private bool Do_unitCreationAction(UnitCreationAction action, int frame)
	{
		bool isKeyFrame = false;
		int pvpNewWaveEntityId = info.GetPvpNewWaveEntityId(action.EntityId);
		if (!info.UnitInfos.ContainsKey(pvpNewWaveEntityId))
		{
			UnitInfo unitInfo = new UnitInfo();
			SetUnitInfo(pvpNewWaveEntityId, unitInfo, action, ref isKeyFrame);
			info.UnitInfos.Add(pvpNewWaveEntityId, unitInfo);
			UseFramesUnitShowInfoAdd(pvpNewWaveEntityId, frame, unitInfo, action.UnitPosition);
		}
		else
		{
			UnitInfo unitInfo2 = new UnitInfo();
			info.UnitInfos[pvpNewWaveEntityId] = unitInfo2;
			SetUnitInfo(pvpNewWaveEntityId, unitInfo2, action, ref isKeyFrame);
			UseFramesUnitShowInfoAdd(pvpNewWaveEntityId, frame, unitInfo2, action.UnitPosition);
		}
		return isKeyFrame;
	}

	private void SetUnitInfo(int id, UnitInfo _unit, UnitCreationAction action, ref bool isKeyFrame)
	{
		_unit.EntityId = id;
		_unit.DeadFrame = 99999;
		_unit.DestroyFrame = 99999;
		_unit.max_hp = action.Stats.MaxHealthPoints;
		_unit.realScale = action.UnitScale;
		_unit.Model = GameController.Contexts.Service<ReplayPlayerService>().GetStringFromMap(action.Model);
		_unit.Skin = GameController.Contexts.Service<ReplayPlayerService>().GetStringFromMap(action.Skin);
		_unit.Visible = action.Visible;
		_unit.team = action.Team;
		uint unitIdentifier = action.UnitIdentifier;
		string stringFromMap = GameController.Contexts.Service<ReplayPlayerService>().GetStringFromMap(unitIdentifier);
		List<string> entityTags = GameEntityData.GetEntityTags(stringFromMap);
		if (entityTags.Contains("建筑") && entityTags.Contains("BOSS"))
		{
			_unit.isFort = true;
		}
		else if (entityTags.Contains("IS_BOSS"))
		{
			_unit.isBoss = true;
		}
		else if (entityTags.Contains("障碍物"))
		{
			_unit.isAbatis = true;
		}
		else
		{
			_unit.isSoldier = true;
		}
		if (!entityTags.Contains("召唤物"))
		{
			isKeyFrame = true;
		}
	}

	private void UseFramesUnitShowInfoAdd(int id, int frame, UnitInfo _unit, UnitPosition unitPosition)
	{
		if (!info.UI_UseFrames[frame].Dict_UnitShowInfo.ContainsKey(id))
		{
			info.UI_UseFrames[frame].Dict_UnitShowInfo.Add(id, new UnitShowInfo());
		}
		info.UI_UseFrames[frame].Dict_UnitShowInfo[id].SetPos(unitPosition.X, unitPosition.Z);
		info.UI_UseFrames[frame].Dict_UnitShowInfo[id].cur_hp = _unit.max_hp;
	}

	private void Do_unitDestructionAction(UnitDestructionAction action, int frame)
	{
		int pvpNewWaveEntityId = info.GetPvpNewWaveEntityId(action.EntityId);
		if (info.UnitInfos.ContainsKey(pvpNewWaveEntityId))
		{
			info.UnitInfos[pvpNewWaveEntityId].DestroyFrame = frame;
		}
	}

	private void Do_positionChangedAction(PositionChangedAction action, UnitShowInfo showinfo)
	{
		showinfo.SetPos(action.UnitPosition.X, action.UnitPosition.Z);
	}

	private void Do_statsChangedAction(StatsChangedAction action, UnitShowInfo showinfo)
	{
		showinfo.cur_hp = action.Stats.CurrentHealth;
	}

	private void Do_setUnitIsDeadAction(SetUnitIsDeadAction action, int frame)
	{
		int pvpNewWaveEntityId = info.GetPvpNewWaveEntityId(action.EntityId);
		if (info.UnitInfos.ContainsKey(pvpNewWaveEntityId))
		{
			info.UnitInfos[pvpNewWaveEntityId].DeadFrame = frame;
		}
	}

	private void Do_unitScaleChangedAction(UnitScaleChangedAction action, int frame)
	{
		AddKeyFrame(frame, QuickPlayReplayKeyFrame.eKeyFrameType.UnitScaleChange, new
		{
			Id = info.GetPvpNewWaveEntityId(action.EntityId),
			Scale = action.UnitScale
		});
	}

	private void AddKeyFrame(int frame, QuickPlayReplayKeyFrame.eKeyFrameType frame_type)
	{
		if (!info.KeyFrames.ContainsKey(frame))
		{
			info.KeyFrames.Add(frame, new QuickPlayReplayKeyFrame(frame));
		}
		info.KeyFrames[frame].Types.Add((int)frame_type);
	}

	private void AddKeyFrame(int frame, QuickPlayReplayKeyFrame.eKeyFrameType frame_type, object data)
	{
		if (!info.KeyFrames.ContainsKey(frame))
		{
			info.KeyFrames.Add(frame, new QuickPlayReplayKeyFrame(frame));
		}
		info.KeyFrames[frame].Types.Add((int)frame_type);
		info.KeyFrames[frame].data.Add(data);
	}
}
