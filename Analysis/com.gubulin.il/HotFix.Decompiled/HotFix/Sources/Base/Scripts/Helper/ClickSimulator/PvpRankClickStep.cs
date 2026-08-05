using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using Shift.Legion.Common.Managers;
using UI.MaskCover;
using UI.MilitaryAFKAssistant;
using UI.PvpSelectSoldiers;
using UI.Tips;
using UI.WorkShop;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class PvpRankClickStep : ClickSimulatorStep
{
	public enum BattleState
	{
		WaitStart,
		Running,
		Victory,
		Failed,
		StartBattleFailed_Retry,
		StartBattleFailed_Stop,
		GetBattleResultFailed_Waiting,
		GetBattleResultFailed_Stop
	}

	private UI_main_PvpRankAFKAssistant _panel;

	private UI_PvpBattleVictory _battleVictory;

	public BattleState _battleState;

	private UI_PvpSelectSoldiersPanel.ClickResult _clickResult;

	public PvpRankClickStep(UI_main_PvpRankAFKAssistant panel)
	{
		_panel = panel;
	}

	public override IEnumerator Execute()
	{
		GameManagers.Instance.Messenger.AddListener("PVP_RANK_BATTLE_START", WaitBattleStart);
		GameManagers.Instance.Messenger.AddListener<int>("PVP_RANK_BATTLE_START_FAILED", OnBattleStartFailed);
		GameManagers.Instance.Messenger.AddListener<int>("PVP_RANK_GET_BATTLE_RESULT_FAILED", OnGetBattleResultFailed);
		SharedMessenger.AddListener<string, Dictionary<string, object>>("OPEN_UI", OnUiPanelOpen);
		UI_PvpSelectSoldiersPanel.ContinueFailedHandler = (Func<UI_PvpSelectSoldiersPanel.ClickResult, string, bool>)Delegate.Combine(UI_PvpSelectSoldiersPanel.ContinueFailedHandler, new Func<UI_PvpSelectSoldiersPanel.ClickResult, string, bool>(PvpBattleContinueClickResult));
		UI_PvpSelectSoldiersPanel panel = (UI_PvpSelectSoldiersPanel)(object)UnityUiService.Instance.GetShowingUi(UI_PvpSelectSoldiersPanel.Name);
		if (panel.PropetryLock.Status.selectedIndex == 0)
		{
			((GButton)panel.PropetryLock).FireClick(true, false);
			((GObject)panel.PropetryLock).onClick.Call();
			UI_MaskCover.OnTouchBegin((GButton)(object)panel.PropetryLock);
			yield return WaitNextButtonClick();
		}
		_battleState = BattleState.WaitStart;
		SentrySdk.AddBreadcrumb($"[AFKDebug]BeginClickSimulator, Set _battleState={BattleState.WaitStart} ");
		while (true)
		{
			_clickResult = UI_PvpSelectSoldiersPanel.ClickResult.Empty;
			((GButton)panel.ChallengeBtn.ConfirmBtn).FireClick(true, false);
			((GObject)panel.ChallengeBtn.ConfirmBtn).onClick.Call();
			UI_MaskCover.OnTouchBegin((GButton)(object)panel.ChallengeBtn.ConfirmBtn);
			yield return WaitButtonClick();
			_panel.LoadSpine();
			yield return WaitWithTimeOut(() => _battleState == BattleState.Running || _battleState == BattleState.StartBattleFailed_Retry || _battleState == BattleState.StartBattleFailed_Stop, null, delegate
			{
				ShowFailedTip("TipStartPvPRankBattleTimeout");
				EndAction();
			}, 50);
			if (_battleState == BattleState.StartBattleFailed_Retry)
			{
				yield return (object)new WaitForSeconds(3f);
				continue;
			}
			break;
		}
		while (true)
		{
			yield return UI_WorkShopPanel.ILWaitUntil(() => _battleState == BattleState.Victory || _battleState == BattleState.Failed || _battleState == BattleState.GetBattleResultFailed_Stop);
			if (_panel.IsQuitting)
			{
				break;
			}
			yield return (object)new WaitForSeconds(1f);
			if (_battleState == BattleState.Victory)
			{
				yield return (object)new WaitForSeconds(2f);
				if (!((GObject)_battleVictory.AutoChallengeButton).visible)
				{
					ShowFailedTip("RankClickAssistantAbortTip3");
					break;
				}
				_battleState = BattleState.WaitStart;
				SentrySdk.AddBreadcrumb($"[AFKDebug]BattleVictory, Set _battleState={BattleState.WaitStart} ");
				while (true)
				{
					_clickResult = UI_PvpSelectSoldiersPanel.ClickResult.Empty;
					((GButton)_battleVictory.AutoChallengeButton).FireClick(true, false);
					((GObject)_battleVictory.AutoChallengeButton).onClick.Call();
					UI_MaskCover.OnTouchBegin((GButton)(object)_battleVictory.AutoChallengeButton);
					yield return WaitNextButtonClick();
					if (UnityUiService.Instance.GetShowingUi(UI_ConfirmPopupDontShowAgain.Name) is UI_ConfirmPopupDontShowAgain confirmPanel)
					{
						if (!((GButton)confirmPanel.ConfirmDialog.switchBtn).selected)
						{
							UI_MaskCover.OnTouchBegin((GButton)(object)confirmPanel.ConfirmDialog.switchBtn);
							((GButton)confirmPanel.ConfirmDialog.switchBtn).FireClick(true, true);
							yield return WaitNextButtonClick();
						}
						UI_MaskCover.OnTouchBegin(confirmPanel.ConfirmDialog.yesBtn);
						confirmPanel.ConfirmDialog.yesBtn.FireClick(true, true);
						yield return WaitNextButtonClick();
					}
					yield return WaitButtonClick();
					yield return WaitWithTimeOut(() => _battleState == BattleState.Running || _battleState == BattleState.StartBattleFailed_Retry || _battleState == BattleState.StartBattleFailed_Stop, null, delegate
					{
						ShowFailedTip("TipContinuousPvPRankBattleTimeout");
						EndAction();
					}, 50);
					if (_battleState == BattleState.StartBattleFailed_Retry)
					{
						yield return (object)new WaitForSeconds(3f);
						continue;
					}
					break;
				}
			}
			else
			{
				if (_battleState == BattleState.Failed)
				{
					ShowFailedTip("RankClickAssistantAbortTip2");
					break;
				}
				ILRuntimeDebug.LogError($"Unknown Condition _battleState == {_battleState}");
			}
		}
		EndAction();
	}

	private IEnumerator WaitButtonClick()
	{
		yield return WaitWithTimeOut(() => _clickResult != UI_PvpSelectSoldiersPanel.ClickResult.Empty, delegate
		{
			if (_clickResult != UI_PvpSelectSoldiersPanel.ClickResult.ChallengeSuccess)
			{
				if (_clickResult == UI_PvpSelectSoldiersPanel.ClickResult.UnNamedFailed)
				{
					EndAction();
				}
				else if (_clickResult == UI_PvpSelectSoldiersPanel.ClickResult.ChallengeFailedNotEnoughTroop)
				{
					EndAction();
					ShowFailedTip("RankClickAssistantAbortTip1");
				}
				else if (_clickResult == UI_PvpSelectSoldiersPanel.ClickResult.ChallengeFailedNotFoundEnemy)
				{
					EndAction();
					ShowFailedTip("RankClickAssistantAbortTip3");
				}
			}
		}, null);
	}

	public bool TryEndDirectly()
	{
		if (_battleState == BattleState.Running || _battleState == BattleState.StartBattleFailed_Retry || _battleState == BattleState.GetBattleResultFailed_Waiting)
		{
			return false;
		}
		EndAction();
		return true;
	}

	private void EndAction()
	{
		GameManagers.Instance.Messenger.RemoveListener("PVP_RANK_BATTLE_START", WaitBattleStart);
		GameManagers.Instance.Messenger.RemoveListener<int>("PVP_RANK_GET_BATTLE_RESULT_FAILED", OnGetBattleResultFailed);
		SharedMessenger.RemoveListener<string, Dictionary<string, object>>("OPEN_UI", OnUiPanelOpen);
		UI_PvpSelectSoldiersPanel.ContinueFailedHandler = (Func<UI_PvpSelectSoldiersPanel.ClickResult, string, bool>)Delegate.Remove(UI_PvpSelectSoldiersPanel.ContinueFailedHandler, new Func<UI_PvpSelectSoldiersPanel.ClickResult, string, bool>(PvpBattleContinueClickResult));
		_panel.End();
	}

	private void OnUiPanelOpen(string name, Dictionary<string, object> parameters)
	{
		if (name == UI_PvpBattleVictory.Name)
		{
			_battleVictory = UnityUiService.Instance.GetShowingUi(name) as UI_PvpBattleVictory;
			_battleState = BattleState.Victory;
			SentrySdk.AddBreadcrumb($"[AFKDebug]OnUiPanelOpen {name}, Set _battleState={BattleState.Victory} ");
		}
		else if (name == UI_PvpBattleFail.Name)
		{
			_battleState = BattleState.Failed;
			SentrySdk.AddBreadcrumb($"[AFKDebug]OnUiPanelOpen {name}, Set _battleState={BattleState.Failed} ");
		}
	}

	private void WaitBattleStart()
	{
		_battleState = BattleState.Running;
		SentrySdk.AddBreadcrumb($"[AFKDebug]WaitBattleStart, Set _battleState={BattleState.Running} ");
	}

	private void OnBattleStartFailed(int errCode)
	{
	}

	private void OnGetBattleResultFailed(int errCode)
	{
		if (errCode == 80032002)
		{
			_battleState = BattleState.GetBattleResultFailed_Waiting;
			SentrySdk.AddBreadcrumb($"[AFKDebug]OnGetBattleResultFailed, Set _battleState={BattleState.GetBattleResultFailed_Waiting} ");
			return;
		}
		_battleState = BattleState.GetBattleResultFailed_Stop;
		SentrySdk.AddBreadcrumb($"[AFKDebug]OnGetBattleResultFailed, Set _battleState={BattleState.GetBattleResultFailed_Stop} ");
		ShowFailedTip(LanguagesManager.GetDesc("TipGetRankBattleResultFailed") + ": " + LanguagesManager.GetErrorMessage(errCode));
		EndAction();
	}

	private void ShowFailedTip(string key)
	{
		string text = key.ToLanguage();
		ILRuntimeDebug.LogError("[PvPAFK]" + text + ", Uis: " + GetUiRefs());
		text.ToConfirmPopup(null, null, (AlignType)1, 40, mirrorBtns: false, needCancelButton: false);
	}

	private string GetUiRefs()
	{
		return string.Join(",", UnityUiService.Instance.DictUI.Keys);
	}

	private bool PvpBattleContinueClickResult(UI_PvpSelectSoldiersPanel.ClickResult result, string errMsg = null)
	{
		_clickResult = result;
		if (!string.IsNullOrEmpty(errMsg))
		{
			ILRuntimeDebug.LogError("[PvPAFK]" + errMsg + ", Uis: " + GetUiRefs());
			errMsg.ToConfirmPopup(null, null, (AlignType)1, 40, mirrorBtns: false, needCancelButton: false);
		}
		if (result == UI_PvpSelectSoldiersPanel.ClickResult.UnNamedFailed)
		{
			return false;
		}
		return true;
	}

	public static IEnumerator WaitNextButtonClick()
	{
		yield return (object)new WaitForSeconds(0.5f);
	}

	public IEnumerator WaitWithTimeOut(Func<bool> predicate, Action onSuccess, Action onTimeOut, int maxWaitingTurns = 10)
	{
		WaitForSeconds wait = new WaitForSeconds(0.2f);
		for (int i = 1; i <= maxWaitingTurns; i++)
		{
			if (_panel.IsQuitting)
			{
				break;
			}
			yield return wait;
			if (predicate())
			{
				onSuccess?.Invoke();
				break;
			}
			if (i == maxWaitingTurns)
			{
				onTimeOut?.Invoke();
				yield return null;
			}
		}
	}
}
