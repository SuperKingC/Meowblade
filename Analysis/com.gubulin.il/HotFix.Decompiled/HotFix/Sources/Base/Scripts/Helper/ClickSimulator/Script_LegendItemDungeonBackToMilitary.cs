using System.Collections;
using FairyGUI;
using Shift.Legion.Common.Services;
using UI.Battle;
using UI.GameEndPanels;
using UI.LegendItemDungeon;
using UI.MaskCover;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_LegendItemDungeonBackToMilitary : LegendItemDungeonClickSimulatorStep
{
	public Script_LegendItemDungeonBackToMilitary(LegendItemDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		yield return ClickSimulatorHelper.WaitLoadingAnimationDone();
		if (GameController.Contexts.Service<BaseSceneService>().CurrentScene == "BattleField")
		{
			GComponent uiInst;
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
		yield return (object)new WaitForSeconds(waitingGap);
		UI_LegendItemDungeonPanel dungeonPanel = ClickSimulatorHelper.GetUiInst(UI_LegendItemDungeonPanel.Name) as UI_LegendItemDungeonPanel;
		dungeonPanel.backBtn.FireClick(true, false);
		UI_MaskCover.OnTouchBegin(dungeonPanel.backBtn);
		((GObject)dungeonPanel.backBtn).onClick.Call();
		yield return null;
	}
}
