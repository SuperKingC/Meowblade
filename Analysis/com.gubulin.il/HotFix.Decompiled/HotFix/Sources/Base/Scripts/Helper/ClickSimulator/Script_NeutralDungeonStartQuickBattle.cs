using System.Collections;
using Assets.Scripts.Managers;
using FairyGUI;
using UI.QuickBattle;
using UI.Tips;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_NeutralDungeonStartQuickBattle : NeutralDungeonClickSimulatorStep
{
	public Script_NeutralDungeonStartQuickBattle(NeutralDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
		NextStep = new Script_NeutralDungeonEndQuickBattle(levelLocator);
	}

	public override IEnumerator Execute()
	{
		IEnumerator tryGetUiEnumerator = ClickSimulatorHelper.WaitTryingGetUiInstOnTop(UI_QuickBattlePanel.Name);
		yield return tryGetUiEnumerator;
		UI_QuickBattlePanel panel = tryGetUiEnumerator.Current as UI_QuickBattlePanel;
		((GButton)panel.MakeWar).FireClick(true, false);
		((GObject)panel.MakeWar).onClick.Call();
		yield return (object)new WaitForSeconds(waitingGap);
		if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_UniversalConfirmPopup.Name, out var confirmDialogObj))
		{
			UI_UniversalConfirmPopup confirmDialog = confirmDialogObj as UI_UniversalConfirmPopup;
			confirmDialog.ConfirmDialog.yesBtn.FireClick(true, false);
			((GObject)confirmDialog.ConfirmDialog.yesBtn).onClick.Call();
			SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsMilitaryAFKAssistantMismatchedBattleFormation"));
		}
		else
		{
			yield return ClickSimulatorHelper.WaitForState(() => panel.PageController.selectedIndex, 1, 15f, LanguagesManager.GetDesc("TipsMilitaryAFKAssistantBattleStartFailed"));
			NextStep = new Script_NeutralDungeonEndQuickBattle(LevelLocator);
			yield return null;
		}
	}
}
