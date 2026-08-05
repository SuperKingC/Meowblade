using System.Collections;
using Assets.Scripts.Managers;
using FairyGUI;
using Shift.Legion.Common.Models;
using UI.GameEndPanels;
using UI.LegendItemDungeon;
using UI.MaskCover;
using UI.Tips;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_LegendItemDungeonEndBattle : LegendItemDungeonClickSimulatorStep
{
	public Script_LegendItemDungeonEndBattle(LegendItemDungeonLevelLocator levelLocator)
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
			Level level = typeof(UI_GameEndPanelVictory).GetField("level").GetValue(victoryPanel) as Level;
			if (level.LevelId == LegendItemDungeonUiHelper.BossLevelId)
			{
				yield return (object)new WaitForSeconds(waitingGap);
				UI_TreasureHuntBossLevelBox component = victoryPanel.RewardAndChoose.TreasureHuntBossLevelBox;
				Vector2 offset = -((GObject)component).pivot * (((GObject)component).pivotAsAnchor ? 1f : 0f);
				Vector2 clickPos = ((GObject)component).size * (0.5f * Vector2.one + offset) + Random.insideUnitCircle * (((GObject)component).height * 0.5f);
				Vector2 pos = ((GObject)component).LocalToGlobal(clickPos);
				UI_MaskCover.OnTouchBegin(pos);
				((GObject)victoryPanel.RewardAndChoose.TreasureHuntBossLevelBox).onClick.Call();
				yield return (object)new WaitForSeconds(waitingGap);
			}
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
