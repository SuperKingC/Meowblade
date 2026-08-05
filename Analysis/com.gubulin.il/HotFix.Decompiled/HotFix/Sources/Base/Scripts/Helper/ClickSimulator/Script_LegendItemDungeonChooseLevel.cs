using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Managers;
using FairyGUI;
using UI.LegendItemDungeon;
using UI.Legion;
using UI.MaskCover;
using UI.Tips;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_LegendItemDungeonChooseLevel : LegendItemDungeonClickSimulatorStep
{
	public Script_LegendItemDungeonChooseLevel(LegendItemDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		IEnumerator tryGetUiEnumerator = ClickSimulatorHelper.WaitTryingGetUiInstOnTop(UI_LegendItemDungeonPanel.Name);
		yield return tryGetUiEnumerator;
		UI_LegendItemDungeonPanel panel = tryGetUiEnumerator.Current as UI_LegendItemDungeonPanel;
		if (Convert.ToInt32(typeof(UI_CameraMain).GetMethod("GetCurFloor", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(panel, null)) == 0)
		{
			if (GameLocalDataManager.GetLastLegendExplorationSoldiers().Count < 1)
			{
				SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsNeedArrangeSoldiersManually"));
				yield break;
			}
			UI_Soldier arrangeSoldierBtn = ((GComponent)panel.Soldiers).GetChildAt(0) as UI_Soldier;
			((GButton)arrangeSoldierBtn).FireClick(true, false);
			UI_MaskCover.OnTouchBegin((GButton)(object)arrangeSoldierBtn);
			((GObject)arrangeSoldierBtn).onClick.Call();
			IEnumerator tryGetArrangeSoldierPanelEnumerator = ClickSimulatorHelper.WaitTryingGetUiInstOnTop(UI_LegionPanel.Name);
			yield return tryGetArrangeSoldierPanelEnumerator;
			UI_LegionPanel arrangeSoldierPanel = tryGetArrangeSoldierPanelEnumerator.Current as UI_LegionPanel;
			yield return (object)new WaitForSeconds(waitingGap);
			if (!((GObject)arrangeSoldierPanel.ConfirmBtn).enabled)
			{
				SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsNeedCheckArrangedSoldiers"));
				yield break;
			}
			arrangeSoldierPanel.ConfirmBtn.FireClick(true, false);
			UI_MaskCover.OnTouchBegin(arrangeSoldierPanel.ConfirmBtn);
			((GObject)arrangeSoldierPanel.ConfirmBtn).onClick.Call();
			yield return (object)new WaitForSeconds(waitingGap);
			((GButton)panel.MapCom.Downward).FireClick(true, false);
			UI_MaskCover.OnTouchBegin((GButton)(object)panel.MapCom.Downward);
			((GObject)panel.MapCom.Downward).onClick.Call();
			yield return (object)new WaitForSeconds(waitingGap);
			if (ClickSimulatorHelper.HasUiShownOnTop(UI_UniversalConfirmPopup.Name))
			{
				SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsNeedCheckArrangedSoldiers"));
				yield break;
			}
		}
		bool bossReady = LegendItemDungeonUiHelper.CurFinishedLevelNum >= LegendItemDungeonUiHelper.ScoreToBoss;
		if (bossReady)
		{
			if (((GObject)panel.MapCom.Downward).touchable)
			{
				((GButton)panel.MapCom.Downward).FireClick(true, false);
				UI_MaskCover.OnTouchBegin((GButton)(object)panel.MapCom.Downward);
				((GObject)panel.MapCom.Downward).onClick.Call();
				yield return (object)new WaitForSeconds(waitingGap);
			}
		}
		else
		{
			for (int curFloor = Convert.ToInt32(typeof(UI_CameraMain).GetMethod("GetCurFloor", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(panel, null)); curFloor != LevelLocator.Difficulty; curFloor = Convert.ToInt32(typeof(UI_CameraMain).GetMethod("GetCurFloor", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(panel, null)))
			{
				if (curFloor > LevelLocator.Difficulty)
				{
					((GButton)panel.MapCom.Upward).FireClick(true, false);
					UI_MaskCover.OnTouchBegin((GButton)(object)panel.MapCom.Upward);
					((GObject)panel.MapCom.Upward).onClick.Call();
				}
				else
				{
					((GButton)panel.MapCom.Downward).FireClick(true, false);
					UI_MaskCover.OnTouchBegin((GButton)(object)panel.MapCom.Downward);
					((GObject)panel.MapCom.Downward).onClick.Call();
				}
				yield return ClickSimulatorHelper.WaitForState(() => panel.MapCom.Map.MapMain.inMotion, targetState: false);
			}
		}
		UI_LevelButton curLevelBtn = null;
		int curLevelBtnIndex = -1;
		List<UI_LevelButton> levelBtns = typeof(UI_LegendItemDungeonPanel).GetField("levelBtns", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(panel) as List<UI_LevelButton>;
		if (bossReady)
		{
			curLevelBtn = levelBtns[0];
		}
		else
		{
			int levelBtnsCnt = levelBtns.Count;
			float totalMapWidth = ((GObject)panel.MapCom.Map.MapMain).width;
			_ = totalMapWidth / (float)levelBtnsCnt;
			float mapScrollOffset = Math.Abs(((GObject)panel.MapCom.Map.MapMain).x);
			float scrollWindowWidth = ((GObject)panel.MapCom).width;
			float scrollWindowCenterPointOffset = mapScrollOffset + scrollWindowWidth / 2f;
			for (int i = 0; i < levelBtnsCnt; i++)
			{
				UI_LevelButton levelBtn = levelBtns[i];
				if (scrollWindowCenterPointOffset > ((GObject)levelBtn).x - ((GObject)levelBtn).width / 2f && scrollWindowCenterPointOffset < ((GObject)levelBtn).x + ((GObject)levelBtn).width / 2f)
				{
					curLevelBtn = levelBtn;
					curLevelBtnIndex = i;
					break;
				}
			}
			int targetLevelBtnIndex = curLevelBtnIndex;
			UI_LevelButton targetLevelBtn = curLevelBtn;
			while (targetLevelBtnIndex > 0 && targetLevelBtn.GrayedController.selectedIndex == 1)
			{
				targetLevelBtnIndex--;
				targetLevelBtn = levelBtns[targetLevelBtnIndex];
			}
			while (targetLevelBtnIndex < levelBtnsCnt - 1 && targetLevelBtn.GrayedController.selectedIndex == 1)
			{
				targetLevelBtnIndex++;
				targetLevelBtn = levelBtns[targetLevelBtnIndex];
			}
			if (targetLevelBtn == null || targetLevelBtn.GrayedController.selectedIndex == 1)
			{
				SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsNoMoreLegendItemDungeonLevel"));
				yield return null;
				yield break;
			}
			while (targetLevelBtnIndex != curLevelBtnIndex)
			{
				if (curLevelBtnIndex - targetLevelBtnIndex > 0)
				{
					((GButton)panel.MapCom.LeftShift).FireClick(true, false);
					UI_MaskCover.OnTouchBegin((GButton)(object)panel.MapCom.LeftShift);
					((GObject)panel.MapCom.LeftShift).onClick.Call();
					curLevelBtnIndex--;
				}
				else
				{
					((GButton)panel.MapCom.RightShift).FireClick(true, false);
					UI_MaskCover.OnTouchBegin((GButton)(object)panel.MapCom.RightShift);
					((GObject)panel.MapCom.RightShift).onClick.Call();
					curLevelBtnIndex++;
				}
				yield return (object)new WaitForSeconds(waitingGap);
			}
			curLevelBtn = levelBtns[targetLevelBtnIndex];
		}
		((GButton)curLevelBtn).FireClick(true, false);
		UI_MaskCover.OnTouchBegin((GButton)(object)curLevelBtn);
		((GObject)curLevelBtn).onClick.Call();
		yield return (object)new WaitForSeconds(waitingGap);
		((GButton)panel.LevelCardPanel.Dailog.assembledBtn).FireClick(true, false);
		UI_MaskCover.OnTouchBegin((GButton)(object)panel.LevelCardPanel.Dailog.assembledBtn);
		((GObject)panel.LevelCardPanel.Dailog.assembledBtn).onClick.Call();
		yield return (object)new WaitForSeconds(waitingGap);
		NextStep = new Script_LegendItemDungeonStartBattle(LevelLocator);
		yield return null;
	}
}
