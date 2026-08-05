using System.Collections;
using Assets.Scripts.Managers;
using FairyGUI;
using UI.GameEndPanels;
using UI.MaskCover;
using UI.Tips;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_DefenseDungeonEndBattle : DefenseDungeonClickSimulatorStep
{
	public Script_DefenseDungeonEndBattle(DefenseDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		yield return ClickSimulatorHelper.WaitBattleEndPanelShowUp(180f);
		SharedMessenger.Broadcast("CLICK_SIMULATOR_ONCE_CHALLENGE", LevelLocator.ActivityId);
		if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelVictory.Name, out var uiInst))
		{
			UI_GameEndPanelVictory victoryPanel = uiInst as UI_GameEndPanelVictory;
			yield return ClickSimulatorHelper.WaitForState(() => ((GObject)victoryPanel.ReceiveBtn).touchable, targetState: true);
			UI_MaskCover.OnTouchBegin(victoryPanel.ReceiveBtn);
			victoryPanel.ReceiveBtn.FireClick(true, true);
		}
		else if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelFail.Name, out uiInst))
		{
			UI_GameEndPanelFail failPanel = uiInst as UI_GameEndPanelFail;
			yield return ClickSimulatorHelper.WaitForState(() => ((GObject)failPanel.YesButton).visible, targetState: true);
			SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsMilitaryAFKAssistantBattleEndFailed"));
			yield break;
		}
		yield return (object)new WaitForSeconds(waitingGap);
		if (ClickSimulatorHelper.HasUiShownOnTop(UI_UserLevelUpPopup.Name))
		{
			SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsUserLevelUpWhileRunningSimulator"));
			yield break;
		}
		yield return ClickSimulatorHelper.WaitLoadingAnimationDone();
		yield return null;
	}
}
