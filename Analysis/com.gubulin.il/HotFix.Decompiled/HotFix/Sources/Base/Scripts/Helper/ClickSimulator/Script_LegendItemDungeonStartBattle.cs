using System;
using System.Collections;
using System.Reflection;
using Assets.Scripts.Managers;
using FairyGUI;
using UI.Battle;
using UI.LegendItemDungeon;
using UI.MaskCover;
using UI.Tips;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_LegendItemDungeonStartBattle : LegendItemDungeonClickSimulatorStep
{
	public Script_LegendItemDungeonStartBattle(LegendItemDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		yield return ClickSimulatorHelper.WaitLoadingAnimationDone();
		IEnumerator tryGetUiEnumerator = ClickSimulatorHelper.WaitTryingGetUiInstOnTop(UI_Battle.Name);
		yield return tryGetUiEnumerator;
		UI_Battle panel = tryGetUiEnumerator.Current as UI_Battle;
		yield return ClickSimulatorHelper.WaitForState(() => ((GObject)panel.OpenPresetBtn).touchable, targetState: true);
		int openPresetBtnMaxRetry = 2;
		int openPresetRetry = 0;
		UI_PresetFormationPanel formationPanel;
		while (true)
		{
			((GButton)panel.OpenPresetBtn).FireClick(true, false);
			UI_MaskCover.OnTouchBegin((GButton)(object)panel.MakeWarBtn);
			((GObject)panel.OpenPresetBtn).onClick.Call();
			yield return (object)new WaitForSeconds(waitingGap);
			tryGetUiEnumerator = ClickSimulatorHelper.WaitTryingGetUiInstOnTop(UI_PresetFormationPanel.Name);
			yield return tryGetUiEnumerator;
			formationPanel = tryGetUiEnumerator.Current as UI_PresetFormationPanel;
			if (formationPanel != null)
			{
				break;
			}
			if (openPresetRetry++ < openPresetBtnMaxRetry)
			{
				continue;
			}
			SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsMilitaryAFKAssistantOpenPresetFormationFailed"));
			yield break;
		}
		UI_BattleArray uiBattleArray = ((GComponent)formationPanel.Dialog.Soliders).GetChildAt(LevelLocator.FormationIndex) as UI_BattleArray;
		((GButton)uiBattleArray.ArrayIndex).FireClick(true, false);
		UI_MaskCover.OnTouchBegin((GButton)(object)uiBattleArray.ArrayIndex);
		((GObject)uiBattleArray.ArrayIndex).onClick.Call();
		yield return (object)new WaitForSeconds(waitingGap);
		UI_MaskCover.OnTouchBegin((GButton)(object)uiBattleArray.UseBtn);
		((GButton)uiBattleArray.UseBtn).FireClick(true, true);
		yield return (object)new WaitForSeconds(waitingGap);
		((GButton)panel.MakeWarBtn).FireClick(true, false);
		UI_MaskCover.OnTouchBegin((GButton)(object)panel.MakeWarBtn);
		((GObject)panel.MakeWarBtn).onClick.Call();
		yield return (object)new WaitForSeconds(waitingGap);
		if (((GObject)panel.StartBattleTipPanel).visible)
		{
			UI_MaskCover.OnTouchBegin(panel.StartBattleTipPanel.Dialog.CloseBtn);
			panel.StartBattleTipPanel.Dialog.CloseBtn.FireClick(true, true);
			SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsMilitaryAFKAssistantMismatchedBattleFormation"));
			yield break;
		}
		if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_UniversalConfirmPopup.Name, out var confirmDialogObj))
		{
			UI_UniversalConfirmPopup confirmDialog = confirmDialogObj as UI_UniversalConfirmPopup;
			GButton cancelBtn = (Convert.ToBoolean(typeof(UI_UniversalConfirmPopup).GetField("mirror", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(confirmDialog)) ? confirmDialog.ConfirmDialog.yesBtn : confirmDialog.ConfirmDialog.noBtn);
			UI_MaskCover.OnTouchBegin(cancelBtn);
			cancelBtn.FireClick(true, true);
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
		NextStep = new Script_LegendItemDungeonEndBattle(LevelLocator);
		yield return null;
	}
}
