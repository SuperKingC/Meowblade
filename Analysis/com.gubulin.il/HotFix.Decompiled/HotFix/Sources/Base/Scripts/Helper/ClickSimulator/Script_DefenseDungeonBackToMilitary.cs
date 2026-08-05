using System.Collections;
using FairyGUI;
using Shift.Legion.Common.Services;
using UI.Battle;
using UI.GameEndPanels;
using UI.InstanceZones;
using UI.MaskCover;
using UI.QuickBattle;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_DefenseDungeonBackToMilitary : DefenseDungeonClickSimulatorStep
{
	public Script_DefenseDungeonBackToMilitary(DefenseDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		yield return ClickSimulatorHelper.WaitLoadingAnimationDone();
		GComponent uiInst;
		if (GameController.Contexts.Service<BaseSceneService>().CurrentScene == "BattleField")
		{
			UI_Battle battlePanel = (ClickSimulatorHelper.TryGetUiInstOnTop(UI_Battle.Name, out uiInst) ? (uiInst as UI_Battle) : null);
			if (battlePanel != null && battlePanel.ChangePageControll.selectedIndex != 1)
			{
				battlePanel.BackToCityBtn.FireClick(true, false);
				UI_MaskCover.OnTouchBegin(battlePanel.BackToCityBtn);
				((GObject)battlePanel.BackToCityBtn).onClick.Call();
				yield return (object)new WaitForSeconds(waitingGap);
			}
			else
			{
				yield return ClickSimulatorHelper.WaitBattleEndPanelShowUp(180f);
				SharedMessenger.Broadcast("CLICK_SIMULATOR_ONCE_CHALLENGE", LevelLocator.ActivityId);
				if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelVictory.Name, out uiInst))
				{
					UI_GameEndPanelVictory victoryPanel = uiInst as UI_GameEndPanelVictory;
					yield return ClickSimulatorHelper.WaitForState(() => ((GObject)victoryPanel.ReceiveBtn).touchable, targetState: true);
					victoryPanel.ReceiveBtn.FireClick(true, false);
					UI_MaskCover.OnTouchBegin(victoryPanel.ReceiveBtn);
					((GObject)victoryPanel.ReceiveBtn).onClick.Call();
				}
				if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelFail.Name, out uiInst))
				{
					UI_GameEndPanelFail failPanel = uiInst as UI_GameEndPanelFail;
					yield return ClickSimulatorHelper.WaitForState(() => ((GObject)failPanel.YesButton).visible, targetState: true);
					failPanel.YesButton.FireClick(true, false);
					UI_MaskCover.OnTouchBegin(failPanel.YesButton);
					((GObject)failPanel.YesButton).onClick.Call();
				}
			}
			yield return (object)new WaitForSeconds(waitingGap);
			yield return ClickSimulatorHelper.WaitLoadingAnimationDone();
		}
		else
		{
			if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_QuickBattlePanel.Name, out uiInst))
			{
				UI_QuickBattlePanel quickBattlePanel = uiInst as UI_QuickBattlePanel;
				if (quickBattlePanel.PageController.selectedIndex == 0)
				{
					quickBattlePanel.exitBtn.FireClick(true, false);
					UI_MaskCover.OnTouchBegin(quickBattlePanel.exitBtn);
					((GObject)quickBattlePanel.exitBtn).onClick.Call();
					yield return (object)new WaitForSeconds(waitingGap);
				}
				else
				{
					yield return ClickSimulatorHelper.WaitBattleEndPanelShowUp(90f);
				}
			}
			if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelVictory.Name, out uiInst))
			{
				SharedMessenger.Broadcast("CLICK_SIMULATOR_ONCE_CHALLENGE", LevelLocator.ActivityId);
				UI_GameEndPanelVictory victoryPanel2 = uiInst as UI_GameEndPanelVictory;
				yield return ClickSimulatorHelper.WaitForState(() => ((GObject)victoryPanel2.ReceiveBtn).touchable, targetState: true);
				victoryPanel2.ReceiveBtn.FireClick(true, false);
				UI_MaskCover.OnTouchBegin(victoryPanel2.ReceiveBtn);
				((GObject)victoryPanel2.ReceiveBtn).onClick.Call();
			}
			else if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelFail.Name, out uiInst))
			{
				SharedMessenger.Broadcast("CLICK_SIMULATOR_ONCE_CHALLENGE", LevelLocator.ActivityId);
				UI_GameEndPanelFail failPanel2 = uiInst as UI_GameEndPanelFail;
				yield return ClickSimulatorHelper.WaitForState(() => ((GObject)failPanel2.YesButton).visible, targetState: true);
				failPanel2.YesButton.FireClick(true, false);
				UI_MaskCover.OnTouchBegin(failPanel2.YesButton);
				((GObject)failPanel2.YesButton).onClick.Call();
			}
		}
		yield return (object)new WaitForSeconds(waitingGap);
		UI_InstanceZonesPanel dungeonPanel = ClickSimulatorHelper.GetUiInst(UI_InstanceZonesPanel.Name) as UI_InstanceZonesPanel;
		dungeonPanel.backBtn.FireClick(true, false);
		UI_MaskCover.OnTouchBegin(dungeonPanel.backBtn);
		((GObject)dungeonPanel.backBtn).onClick.Call();
		yield return null;
	}
}
