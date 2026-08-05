using System.Collections;
using Assets.Scripts.Managers;
using FairyGUI;
using UI.GameEndPanels;
using UI.MaskCover;
using UI.Tips;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_DefenseDungeonRestartQuickBattle : DefenseDungeonClickSimulatorStep
{
	public Script_DefenseDungeonRestartQuickBattle(DefenseDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelVictory.Name, out var uiInst))
		{
			UI_GameEndPanelVictory victoryPanel = uiInst as UI_GameEndPanelVictory;
			yield return ClickSimulatorHelper.WaitForState(() => ((GObject)victoryPanel.againBtn).visible, targetState: true);
			UI_MaskCover.OnTouchBegin((GButton)(object)victoryPanel.againBtn);
			((GButton)victoryPanel.againBtn).FireClick(true, true);
			yield return (object)new WaitForSeconds(waitingGap);
			if (ClickSimulatorHelper.HasUiShownOnTop(UI_UserLevelUpPopup.Name))
			{
				SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsUserLevelUpWhileRunningSimulator"));
				yield break;
			}
		}
		NextStep = new Script_DefenseDungeonEndQuickBattle(LevelLocator);
		yield return null;
	}
}
