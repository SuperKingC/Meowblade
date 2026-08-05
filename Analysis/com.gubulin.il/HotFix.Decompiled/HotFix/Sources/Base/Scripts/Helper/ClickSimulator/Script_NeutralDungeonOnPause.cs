using System.Collections;
using FairyGUI;
using Shift.Legion.Common.Services;
using UI.Battle;
using UI.GameEndPanels;
using UI.QuickBattle;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_NeutralDungeonOnPause : NeutralDungeonClickSimulatorStep
{
	public Script_NeutralDungeonOnPause(NeutralDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		yield return (object)new WaitForSeconds(1f);
		yield return ClickSimulatorHelper.WaitLoadingAnimationDone();
		GComponent uiInst;
		if (GameController.Contexts.Service<BaseSceneService>().CurrentScene == "BattleField")
		{
			UI_Battle battlePanel = (ClickSimulatorHelper.TryGetUiInstOnTop(UI_Battle.Name, out uiInst) ? (uiInst as UI_Battle) : null);
			if (battlePanel != null && battlePanel.ChangePageControll.selectedIndex != 1)
			{
				yield break;
			}
			yield return ClickSimulatorHelper.WaitBattleEndPanelShowUp(180f);
			SharedMessenger.Broadcast("CLICK_SIMULATOR_ONCE_CHALLENGE", LevelLocator.ActivityId);
			if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelVictory.Name, out uiInst))
			{
				UI_GameEndPanelVictory victoryPanel = uiInst as UI_GameEndPanelVictory;
				yield return ClickSimulatorHelper.WaitForState(() => ((GObject)victoryPanel.ReceiveBtn).touchable, targetState: true);
			}
			else if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelFail.Name, out uiInst))
			{
				UI_GameEndPanelFail failPanel = uiInst as UI_GameEndPanelFail;
				yield return ClickSimulatorHelper.WaitForState(() => ((GObject)failPanel.YesButton).visible, targetState: true);
			}
			yield break;
		}
		if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_QuickBattlePanel.Name, out uiInst))
		{
			UI_QuickBattlePanel quickBattlePanel = uiInst as UI_QuickBattlePanel;
			if (quickBattlePanel.PageController.selectedIndex == 0)
			{
				yield break;
			}
			yield return ClickSimulatorHelper.WaitBattleEndPanelShowUp(90f);
		}
		if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelVictory.Name, out uiInst))
		{
			SharedMessenger.Broadcast("CLICK_SIMULATOR_ONCE_CHALLENGE", LevelLocator.ActivityId);
			UI_GameEndPanelVictory victoryPanel2 = uiInst as UI_GameEndPanelVictory;
			yield return ClickSimulatorHelper.WaitForState(() => ((GObject)victoryPanel2.ReceiveBtn).touchable, targetState: true);
		}
		else if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelFail.Name, out uiInst))
		{
			SharedMessenger.Broadcast("CLICK_SIMULATOR_ONCE_CHALLENGE", LevelLocator.ActivityId);
			UI_GameEndPanelFail failPanel2 = uiInst as UI_GameEndPanelFail;
			yield return ClickSimulatorHelper.WaitForState(() => ((GObject)failPanel2.YesButton).visible, targetState: true);
		}
	}
}
