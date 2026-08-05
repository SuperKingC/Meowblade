using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.QuickBattle;
using UI.Tips;
using UnityEngine;
using UnityEngine.Networking;

namespace HotFix.Sources.Base.Scripts.Managers;

public class ReplayEventManager : MonoBehaviour
{
	private const float MaxReplayStuckTimerRunningTime = 60f;

	private const float MaxQuickReplayStuckTimerRunningTime = 60f;

	private static float ReplayStuckTimeoutSeconds = 10f;

	private static float QuickReplayStuckTimeoutSeconds = 10f;

	private float _replayStuckTime = 0f;

	private Coroutine _replayStuckTimeoutTimer;

	private float _quickReplayStuckTime = 0f;

	private Coroutine _quickReplayStuckTimeoutTimer;

	private const int GetRankBattleResultMaxTryCnt = 5;

	private static int GetRankBattleResultRetry = 0;

	private const int GetBattleResultMaxTryCnt = 5;

	private static int GetBattleResultRetry = 0;

	private const int GetQuickRankBattleResultMaxTryCnt = 5;

	private static int GetQuickRankBattleResultRetry = 0;

	private const int GetQuickBattleResultMaxTryCnt = 5;

	private static int GetQuickBattleResultRetry = 0;

	private void Awake()
	{
		Dictionary<string, string> configs = HotUpdateProcess.Instance.Configs;
		if (configs.TryGetValue("ReplayStuckTimeoutSeconds", out var value))
		{
			ReplayStuckTimeoutSeconds = float.Parse(value);
		}
		if (configs.TryGetValue("QuickReplayStuckTimeoutSeconds", out var value2))
		{
			QuickReplayStuckTimeoutSeconds = float.Parse(value2);
		}
		SharedMessenger.AddListener<string>("START_PLAY_REPLAY_WATCHER", OnStartPlayReplayWatcher);
		SharedMessenger.AddListener("REFRESH_PLAY_REPLAY_WATCHER", OnRefreshPlayReplayWatcher);
		SharedMessenger.AddListener<string>("STOP_PLAY_REPLAY_WATCHER", OnStopPlayReplayWatcher);
		SharedMessenger.AddListener<string>("START_QUICK_PLAY_REPLAY_WATCHER", OnStartQuickPlayReplayWatcher);
		SharedMessenger.AddListener("REFRESH_QUICK_PLAY_REPLAY_WATCHER", OnRefreshQuickPlayReplayWatcher);
		SharedMessenger.AddListener<string>("STOP_QUICK_PLAY_REPLAY_WATCHER", OnStopQuickPlayReplayWatch);
	}

	private void OnDestroy()
	{
		SharedMessenger.RemoveListener<string>("START_PLAY_REPLAY_WATCHER", OnStartPlayReplayWatcher);
		SharedMessenger.RemoveListener("REFRESH_PLAY_REPLAY_WATCHER", OnRefreshPlayReplayWatcher);
		SharedMessenger.RemoveListener<string>("STOP_PLAY_REPLAY_WATCHER", OnStopPlayReplayWatcher);
		SharedMessenger.RemoveListener<string>("START_QUICK_PLAY_REPLAY_WATCHER", OnStartQuickPlayReplayWatcher);
		SharedMessenger.RemoveListener("REFRESH_QUICK_PLAY_REPLAY_WATCHER", OnRefreshQuickPlayReplayWatcher);
		SharedMessenger.RemoveListener<string>("STOP_QUICK_PLAY_REPLAY_WATCHER", OnStopQuickPlayReplayWatch);
	}

	private void RestartReplayStuckTimer(string battleId)
	{
		StopReplayStuckTimer();
		_replayStuckTime = 0f;
		_replayStuckTimeoutTimer = ((MonoBehaviour)this).StartCoroutine(StartReplayStuckTimer(battleId));
	}

	private IEnumerator StartReplayStuckTimer(string battleId)
	{
		SentrySdk.AddBreadcrumb("StartReplayStuckTimer: " + Contexts.sharedInstance.Service<ReplayPlayerService>().GetCurrentStatusInfo());
		while (_replayStuckTime < 60f)
		{
			if (_replayStuckTime > ReplayStuckTimeoutSeconds)
			{
				StopReplayStuckTimer();
				((MonoBehaviour)this).StartCoroutine(OnReplayPlayFailed(battleId));
				yield break;
			}
			_replayStuckTime += Time.deltaTime;
			yield return null;
		}
		ILRuntimeDebug.LogError($"[ReplayEventManager]Replay Stuck Time Exceeded Max Replay Stuck Time {_replayStuckTime}s: {Contexts.sharedInstance.Service<ReplayPlayerService>().GetCurrentStatusInfo()}");
	}

	private void StopReplayStuckTimer()
	{
		if (_replayStuckTimeoutTimer != null)
		{
			SentrySdk.AddBreadcrumb("StopReplayStuckTimer: " + Contexts.sharedInstance.Service<ReplayPlayerService>().GetCurrentStatusInfo());
			((MonoBehaviour)this).StopCoroutine(_replayStuckTimeoutTimer);
			_replayStuckTimeoutTimer = null;
		}
	}

	private void RestartQuickReplayStuckTimer(string battleId)
	{
		StopQuickReplayStuckTimer();
		_quickReplayStuckTime = 0f;
		_quickReplayStuckTimeoutTimer = ((MonoBehaviour)this).StartCoroutine(StartQuickReplayStuckTimer(battleId));
	}

	private IEnumerator StartQuickReplayStuckTimer(string battleId)
	{
		SentrySdk.AddBreadcrumb("StartQuickReplayStuckTimer: " + QuickPlayReplayService.Instance.GetCurrentStatusInfo());
		while (_quickReplayStuckTime < 60f)
		{
			if (_quickReplayStuckTime > QuickReplayStuckTimeoutSeconds)
			{
				StopQuickReplayStuckTimer();
				((MonoBehaviour)this).StartCoroutine(OnQuickReplayPlayFailed(battleId));
				yield break;
			}
			_quickReplayStuckTime += Time.deltaTime;
			yield return null;
		}
		ILRuntimeDebug.LogError($"[ReplayEventManager]QuickReplay Stuck Time Exceeded Max Replay Stuck Time {_replayStuckTime}s: {QuickPlayReplayService.Instance.GetCurrentStatusInfo()}");
	}

	private void StopQuickReplayStuckTimer()
	{
		if (_quickReplayStuckTimeoutTimer != null)
		{
			SentrySdk.AddBreadcrumb("StopQuickReplayStuckTimer: " + QuickPlayReplayService.Instance.GetCurrentStatusInfo());
			((MonoBehaviour)this).StopCoroutine(_quickReplayStuckTimeoutTimer);
			_quickReplayStuckTimeoutTimer = null;
		}
	}

	private void OnApplicationFocus(bool isFocus)
	{
	}

	private void OnStartPlayReplayWatcher(string battleId)
	{
		RestartReplayStuckTimer(battleId);
	}

	private void OnStartQuickPlayReplayWatcher(string battleId)
	{
		RestartQuickReplayStuckTimer(battleId);
	}

	private void OnStopPlayReplayWatcher(string battleId)
	{
		StopReplayStuckTimer();
	}

	private void OnStopQuickPlayReplayWatch(string battleId)
	{
		StopQuickReplayStuckTimer();
	}

	private void OnRefreshPlayReplayWatcher()
	{
		_replayStuckTime = 0f;
	}

	private void OnRefreshQuickPlayReplayWatcher()
	{
		_quickReplayStuckTime = 0f;
	}

	private IEnumerator OnReplayPlayFailed(string battleId)
	{
		SentrySdk.AddBreadcrumb("[ReplayPlayFailed]ReplayPlayFailed: " + Contexts.sharedInstance.Service<ReplayPlayerService>().GetCurrentStatusInfo());
		string curReplayBattleId = Contexts.sharedInstance.gameState.replayBattleId?.value;
		if (curReplayBattleId != battleId)
		{
			ILRuntimeDebug.LogError("[OnReplayPlayFailed]Unexpected BattleId " + battleId + ", " + curReplayBattleId);
			yield break;
		}
		yield return CheckNetworkHealth();
		Level level = Contexts.sharedInstance.Service<IBattleFieldService>().Level;
		bool isPvp = RankDataHelper.IsPvPLevel(level.LevelId);
		GameLocalDataManager.IncrementTodayReplayStuckTimes();
		Contexts.sharedInstance.Service<ReplayPlayerService>().Skip(forceSkip: true);
		if (isPvp)
		{
			((MonoBehaviour)this).StartCoroutine(TryGetRankBattleResult(battleId));
		}
		else
		{
			((MonoBehaviour)this).StartCoroutine(TryGetBattleResult(battleId, level.LevelId));
		}
	}

	private IEnumerator TryGetRankBattleResult(string battleId, float delay = 0f)
	{
		Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: true);
		yield return (object)new WaitForSeconds(delay);
		ILRequestHelper<GetRankBattleResultResponse>.Request(null, () => Contexts.sharedInstance.Service<INetworkService>().GetRankBattleResult(-1L, battleId), delegate(GetRankBattleResultResponse response)
		{
			if (response.ErrorCode != 0)
			{
				SentrySdk.AddBreadcrumb($"[ReplayPlayFailed]GetRankBattleResult Failed {battleId}, ErrorCode={response.ErrorCode}");
				if (GetRankBattleResultRetry++ < 5)
				{
					((MonoBehaviour)this).StartCoroutine(TryGetRankBattleResult(battleId, GetRankBattleResultRetry));
				}
				else
				{
					GetRankBattleResultRetry = 0;
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
					ShowBattleAbortedTip();
					Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
				}
			}
			else
			{
				ILRuntimeDebug.LogError($"[ReplayPlayFailed]GetBattleResult Success, BattleId={battleId}, Winner={response.Winner}");
				GetRankBattleResultRetry = 0;
				Contexts.sharedInstance.Service<IBattleFieldService>().ProcessRankBattleResult(response, battleId);
				Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
		}, 1f);
	}

	private IEnumerator TryGetBattleResult(string battleId, string levelId, float delay = 0f)
	{
		Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: true);
		yield return (object)new WaitForSeconds(delay);
		ILRequestHelper<GetBattleResultResponse>.Request(null, () => Contexts.sharedInstance.Service<INetworkService>().GetBattleResult(-1L, battleId, levelId), delegate(GetBattleResultResponse response)
		{
			if (response.ErrorCode != 0)
			{
				SentrySdk.AddBreadcrumb($"[ReplayPlayFailed]GetBattleResult Failed {battleId}, ErrorCode={response.ErrorCode}");
				if (GetBattleResultRetry++ < 5)
				{
					((MonoBehaviour)this).StartCoroutine(TryGetBattleResult(battleId, levelId, GetBattleResultRetry));
				}
				else
				{
					GetBattleResultRetry = 0;
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
					ShowBattleAbortedTip();
					Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
				}
			}
			else
			{
				ILRuntimeDebug.LogError($"[ReplayPlayFailed]GetBattleResult Success, BattleId={battleId}, Winner={response.Winner}");
				GetBattleResultRetry = 0;
				Contexts.sharedInstance.Service<IBattleFieldService>().ProcessBattleResult(response, battleId);
				Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
		}, 1f);
	}

	private IEnumerator OnQuickReplayPlayFailed(string battleId)
	{
		SentrySdk.AddBreadcrumb("[ReplayPlayFailed]QuickReplayPlayFailed: " + QuickPlayReplayService.Instance.GetCurrentStatusInfo());
		string curReplayBattleId = QuickPlayReplayService.info.BattleId;
		if (curReplayBattleId != battleId)
		{
			ILRuntimeDebug.LogError("[OnReplayPlayFailed]Unexpected Quick BattleId " + battleId + ", " + curReplayBattleId);
			yield break;
		}
		yield return CheckNetworkHealth();
		bool isPvP = QuickPlayReplayService.info._IsPvP;
		string levelId = QuickPlayReplayService.info.LevelId;
		GameLocalDataManager.IncrementTodayReplayStuckTimes();
		QuickPlayReplayService.info.Clear();
		typeof(Interface_Battle).GetMethod("Destroy")?.Invoke(null, null);
		QuickPlayReplayService.info.isDownloadFinish = true;
		QuickPlayReplayService.info.isPlayingFinish = true;
		((MonoBehaviour)QuickPlayReplayService.Instance).StopAllCoroutines();
		if (UI_QuickBattlePanel.QuickBattlePanel.frameCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(UI_QuickBattlePanel.QuickBattlePanel.frameCoroutine);
		}
		if (UI_QuickBattlePanel.QuickBattlePanel.loadCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(UI_QuickBattlePanel.QuickBattlePanel.loadCoroutine);
		}
		if (UI_QuickBattlePanel.QuickBattlePanel.fallCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(UI_QuickBattlePanel.QuickBattlePanel.fallCoroutine);
		}
		if (isPvP)
		{
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(TryGetQuickRankBattleResult(curReplayBattleId));
			yield break;
		}
		if (UI_QuickBattlePanel.QuickBattlePanel.curLevel != null)
		{
			UI_QuickBattlePanel.QuickBattlePanel.Chapter = GameManagers.Instance.ChapterManager.GetChapter(UI_QuickBattlePanel.QuickBattlePanel.curLevel.ChapterId);
		}
		Activity levelActivity = GameManagers.Instance.ActivityManager.GetLevelActivity(levelId);
		if (levelActivity != null && levelActivity.Type == ActivityType.AttackInstance)
		{
			ShowBattleAbortedTip();
			Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
		}
		else
		{
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(TryGetQuickBattleResult(curReplayBattleId, levelId));
		}
	}

	private IEnumerator TryGetQuickRankBattleResult(string battleId, float delay = 0f)
	{
		Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: true);
		yield return (object)new WaitForSeconds(delay);
		ILRequestHelper<GetRankBattleResultResponse>.Request(null, () => Contexts.sharedInstance.Service<INetworkService>().GetRankBattleResult(-1L, battleId), delegate(GetRankBattleResultResponse response)
		{
			if (response.ErrorCode != 0)
			{
				SentrySdk.AddBreadcrumb($"[ReplayPlayFailed]GetQuickRankBattleResult Failed {battleId}, ErrorCode={response.ErrorCode}");
				if (GetQuickRankBattleResultRetry++ < 5)
				{
					((MonoBehaviour)FGUIManager.Instance).StartCoroutine(TryGetQuickRankBattleResult(battleId, GetQuickRankBattleResultRetry));
				}
				else
				{
					GetQuickRankBattleResultRetry = 0;
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
					ShowBattleAbortedTip();
					Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
				}
			}
			else
			{
				ILRuntimeDebug.LogError($"[ReplayPlayFailed]GetQuickBattleResult Success, BattleId={battleId}, Winner={response.Winner}");
				GetQuickRankBattleResultRetry = 0;
				Contexts.sharedInstance.Service<IBattleFieldService>().ProcessRankBattleResult(response, battleId);
				Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
		}, 1f);
	}

	private IEnumerator TryGetQuickBattleResult(string battleId, string levelId, float delay = 0f)
	{
		Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: true);
		yield return (object)new WaitForSeconds(delay);
		ILRequestHelper<GetBattleResultResponse>.Request(null, () => Contexts.sharedInstance.Service<INetworkService>().GetBattleResult(-1L, battleId, levelId), delegate(GetBattleResultResponse response)
		{
			if (response.ErrorCode != 0)
			{
				SentrySdk.AddBreadcrumb($"[ReplayPlayFailed]GetQuickBattleResult Failed {battleId}, ErrorCode={response.ErrorCode}");
				if (GetQuickBattleResultRetry++ < 5)
				{
					((MonoBehaviour)FGUIManager.Instance).StartCoroutine(TryGetQuickBattleResult(battleId, levelId, GetQuickBattleResultRetry));
				}
				else
				{
					GetQuickBattleResultRetry = 0;
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
					ShowBattleAbortedTip();
					Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
				}
			}
			else
			{
				ILRuntimeDebug.LogError($"[ReplayPlayFailed]GetQuickBattleResult Success, BattleId={battleId}, Winner={response.Winner}");
				GetQuickBattleResultRetry = 0;
				UI_QuickBattlePanel.QuickBattlePanel.ProcessBattleResult(response);
				Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
		}, 1f);
	}

	private void ShowBattleAbortedTip()
	{
		Contexts.sharedInstance.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Title",
				LanguagesManager.GetDesc("BattleAbortedTips_Title")
			},
			{
				"Content",
				LanguagesManager.GetDesc("BattleAbortedTips_Content")
			},
			{
				"ConfirmTitle",
				LanguagesManager.GetDesc("BattleAbortedTips_ConfirmTitle")
			},
			{
				"Buttons",
				new Dictionary<string, Action> { 
				{
					"Confirm",
					delegate
					{
						Contexts.sharedInstance.Service<IBattleFieldService>().ClearAllGameObject();
						Dictionary<string, object> dictionary = new Dictionary<string, object>
						{
							{ "ForceCloseOtherUi", true },
							{ "TaskCompletionSource", null },
							{
								"LoadingAnimationDirection",
								LoadingAnimationDirection.Left
							}
						};
						Level level = Contexts.sharedInstance.Service<IBattleFieldService>().Level;
						if (level != null && !string.IsNullOrEmpty(level.FromUi))
						{
							dictionary.Add("OpenUiOnReturn", level.FromUi);
							if (level.FromUiParams != null)
							{
								dictionary.Add("UiParamsOnReturn", level.FromUiParams);
							}
						}
						CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(dictionary));
					}
				} }
			},
			{ "PageIndex", 4 },
			{ "ClickSound", "Confirm" },
			{ "Order", 1 }
		});
	}

	private IEnumerator CheckNetworkHealth()
	{
		string url = HotUpdateProcess.Instance.RegionModel.Zone.url.res[0] + "/cnc.txt";
		UnityWebRequest uwr = UnityWebRequest.Get(CheckUrl(ref url));
		uwr.timeout = 4;
		yield return uwr.SendWebRequest();
		for (int i = 0; i < 5; i++)
		{
			if (!uwr.isNetworkError && !uwr.isHttpError && uwr.downloadHandler.text.Trim() == "1")
			{
				SentrySdk.AddBreadcrumb($"[ReplayPlayFailed]CheckNetworkHealth@{i}: Good");
				break;
			}
			SentrySdk.AddBreadcrumb($"[ReplayPlayFailed]CheckNetworkHealth@{i}: Bad, {uwr.error}");
			yield return (object)new WaitForSeconds(0.5f);
		}
	}

	private string CheckUrl(ref string url)
	{
		string text = url.Replace(" ", "%20");
		return text.Replace("#", "%23");
	}
}
