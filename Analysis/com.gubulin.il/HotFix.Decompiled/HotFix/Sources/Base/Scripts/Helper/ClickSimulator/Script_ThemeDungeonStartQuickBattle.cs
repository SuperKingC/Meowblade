using System.Collections;
using Assets.Scripts.Managers;
using FairyGUI;
using UI.MaskCover;
using UI.QuickBattle;
using UI.Tips;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_ThemeDungeonStartQuickBattle : ThemeDungeonClickSimulatorStep
{
	public Script_ThemeDungeonStartQuickBattle(ThemeDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
		NextStep = new Script_ThemeDungeonEndQuickBattle(levelLocator);
	}

	public override IEnumerator Execute()
	{
		IEnumerator tryGetUiEnumerator = ClickSimulatorHelper.WaitTryingGetUiInstOnTop(UI_QuickBattlePanel.Name);
		yield return tryGetUiEnumerator;
		UI_QuickBattlePanel panel = tryGetUiEnumerator.Current as UI_QuickBattlePanel;
		((GButton)panel.MakeWar).FireClick(true, false);
		UI_MaskCover.OnTouchBegin((GButton)(object)panel.MakeWar);
		((GObject)panel.MakeWar).onClick.Call();
		yield return (object)new WaitForSeconds(waitingGap);
		if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_UniversalConfirmPopup.Name, out var dialogObj))
		{
			UI_UniversalConfirmPopup dialog = dialogObj as UI_UniversalConfirmPopup;
			dialog.ConfirmDialog.yesBtn.FireClick(true, false);
			UI_MaskCover.OnTouchBegin(dialog.ConfirmDialog.yesBtn);
			((GObject)dialog.ConfirmDialog.yesBtn).onClick.Call();
			SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsMilitaryAFKAssistantMismatchedBattleFormation"));
		}
		else
		{
			yield return ClickSimulatorHelper.WaitForState(() => panel.PageController.selectedIndex, 1, 15f, LanguagesManager.GetDesc("TipsMilitaryAFKAssistantBattleStartFailed"));
			NextStep = new Script_ThemeDungeonEndQuickBattle(LevelLocator);
			yield return null;
		}
	}
}
