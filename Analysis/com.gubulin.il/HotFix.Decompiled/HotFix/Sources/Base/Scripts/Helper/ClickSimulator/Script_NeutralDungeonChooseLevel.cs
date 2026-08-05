using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Managers;
using FairyGUI;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using UI.InstanceZones;
using UI.MaskCover;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_NeutralDungeonChooseLevel : NeutralDungeonClickSimulatorStep
{
	public Script_NeutralDungeonChooseLevel(NeutralDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		IEnumerator tryGetUiEnumerator = ClickSimulatorHelper.WaitTryingGetUiInstOnTop(UI_InstanceZonesPanel.Name);
		yield return tryGetUiEnumerator;
		UI_InstanceZonesPanel panel = tryGetUiEnumerator.Current as UI_InstanceZonesPanel;
		List<UI_Btn_NeutralLevelBtn> neutralDungeonLevelBtns = typeof(UI_InstanceZonesPanel).GetField("NeutralDungeonLevelBtns", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(panel) as List<UI_Btn_NeutralLevelBtn>;
		ChapterActivityPayload chosenContentPayload = null;
		UI_Btn_NeutralLevelBtn chosenLevelBtn = null;
		for (int i = 0; i < neutralDungeonLevelBtns.Count; i++)
		{
			chosenLevelBtn = neutralDungeonLevelBtns[i];
			chosenContentPayload = ((GObject)chosenLevelBtn).data as ChapterActivityPayload;
			Level chosenLevel = chosenContentPayload.Levels(GameManagers.Instance).First();
			if (chosenLevel.LevelId == LevelLocator.LevelId)
			{
				yield return null;
				break;
			}
		}
		while (((GObject)chosenLevelBtn.icon).grayed)
		{
			yield return (object)new WaitForSeconds(waitingGap);
		}
		if (!chosenContentPayload.Activity.CanPlay(GameManagers.Instance, chosenContentPayload.ChapterId))
		{
			SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsLevelCannotPlay"));
			yield return null;
			yield break;
		}
		((GButton)chosenLevelBtn).FireClick(true, false);
		UI_MaskCover.OnTouchBegin((GButton)(object)chosenLevelBtn);
		((GObject)chosenLevelBtn).onClick.Call((object)true);
		yield return (object)new WaitForSeconds(waitingGap);
		if (panel.NeutralDungeonPanel.LevelCardPanel.Dialog.quickBtn.Status.selectedIndex == 1)
		{
			NextStep = new Script_NeutralDungeonStartQuickBattle(LevelLocator);
		}
		else
		{
			NextStep = new Script_NeutralDungeonStartBattle(LevelLocator);
		}
		GButton assembledBtn = ((GComponent)panel.NeutralDungeonPanel.LevelCardPanel.Dialog).GetChild("assembledBtn").asButton;
		assembledBtn.FireClick(true, false);
		UI_MaskCover.OnTouchBegin(assembledBtn);
		((GObject)assembledBtn).onClick.Call();
		yield return (object)new WaitForSeconds(waitingGap);
		yield return null;
	}
}
