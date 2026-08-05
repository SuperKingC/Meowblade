using System;
using System.Collections;
using System.Reflection;
using Assets.Scripts.Managers;
using FairyGUI;
using UI.Battle;
using UI.MaskCover;
using UI.Tips;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_DefenseDungeonStartBattle : DefenseDungeonClickSimulatorStep
{
	public Script_DefenseDungeonStartBattle(DefenseDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		yield return ClickSimulatorHelper.WaitLoadingAnimationDone();
		IEnumerator tryGetUiEnumerator = ClickSimulatorHelper.WaitTryingGetUiInstOnTop(UI_Battle.Name);
		yield return tryGetUiEnumerator;
		UI_Battle panel = tryGetUiEnumerator.Current as UI_Battle;
		yield return ClickSimulatorHelper.WaitForState(() => ((GObject)panel.MakeWarBtn).visible, targetState: true);
		((GButton)panel.MakeWarBtn).FireClick(true, false);
		UI_MaskCover.OnTouchBegin((GButton)(object)panel.MakeWarBtn);
		((GObject)panel.MakeWarBtn).onClick.Call();
		yield return (object)new WaitForSeconds(waitingGap);
		if (((GObject)panel.StartBattleTipPanel).visible)
		{
			panel.StartBattleTipPanel.Dialog.CloseBtn.FireClick(true, false);
			UI_MaskCover.OnTouchBegin(panel.StartBattleTipPanel.Dialog.CloseBtn);
			((GObject)panel.StartBattleTipPanel.Dialog.CloseBtn).onClick.Call();
			SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsMilitaryAFKAssistantMismatchedBattleFormation"));
			yield break;
		}
		if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_UniversalConfirmPopup.Name, out var confirmDialogObj))
		{
			UI_UniversalConfirmPopup confirmDialog = confirmDialogObj as UI_UniversalConfirmPopup;
			GButton cancelBtn = (Convert.ToBoolean(typeof(UI_UniversalConfirmPopup).GetField("mirror", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(confirmDialog)) ? confirmDialog.ConfirmDialog.yesBtn : confirmDialog.ConfirmDialog.noBtn);
			cancelBtn.FireClick(true, false);
			UI_MaskCover.OnTouchBegin(cancelBtn);
			((GObject)cancelBtn).onClick.Call();
			SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsMilitaryAFKAssistantMismatchedBattleFormation"));
			yield break;
		}
		yield return (object)new WaitForSeconds(waitingGap);
		yield return ClickSimulatorHelper.WaitWaitingAnimationDone(15f);
		if (((GObject)panel.MakeWarBtn).visible)
		{
			SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsMilitaryAFKAssistantMismatchedBattleFormation"));
			yield break;
		}
		yield return ClickSimulatorHelper.WaitForState(() => panel.ChangePageControll.selectedIndex, 1, 15f, LanguagesManager.GetDesc("TipsMilitaryAFKAssistantBattleStartFailed"));
		NextStep = new Script_DefenseDungeonEndBattle(LevelLocator);
		yield return null;
	}
}
