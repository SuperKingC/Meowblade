using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Managers;
using FairyGUI;
using Shift.Legion.Client.Sources.Extensions;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using UI.InstanceZones;
using UI.MaskCover;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_ThemeDungeonChooseLevel : ThemeDungeonClickSimulatorStep
{
	public Script_ThemeDungeonChooseLevel(ThemeDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		IEnumerator tryGetUiEnumerator = ClickSimulatorHelper.WaitTryingGetUiInstOnTop(UI_InstanceZonesPanel.Name);
		yield return tryGetUiEnumerator;
		UI_InstanceZonesPanel panel = tryGetUiEnumerator.Current as UI_InstanceZonesPanel;
		if (LevelLocator.IsAdvanced && panel.PageController.selectedIndex != 4)
		{
			ChapterActivityPayload contentPayloadOfPortal = ((GObject)panel.MapEntrance).data as ChapterActivityPayload;
			if (!contentPayloadOfPortal.CanPortal(GameManagers.Instance))
			{
				SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsNeedPortalLevelAccomplish"));
				yield return null;
				yield break;
			}
			((GButton)panel.MapEntrance).FireClick(true, false);
			UI_MaskCover.OnTouchBegin((GButton)(object)panel.MapEntrance);
			((GObject)panel.MapEntrance).onClick.Call();
			yield return (object)new WaitForSeconds(waitingGap);
		}
		if (!LevelLocator.IsAdvanced && panel.PageController.selectedIndex != 0)
		{
			((GButton)panel.MapEntrance).FireClick(true, false);
			UI_MaskCover.OnTouchBegin((GButton)(object)panel.MapEntrance);
			((GObject)panel.MapEntrance).onClick.Call((object)true);
			yield return (object)new WaitForSeconds(waitingGap);
		}
		List<UI_LevelBtn> timeLimitLevelBtns = typeof(UI_InstanceZonesPanel).GetField("TimeLimitLevelBtns", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(panel) as List<UI_LevelBtn>;
		ChapterActivityPayload chosenContentPayload = null;
		UI_LevelBtn chosenLevelBtn = null;
		for (int i = 0; i < timeLimitLevelBtns.Count; i++)
		{
			chosenLevelBtn = timeLimitLevelBtns[i];
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
		if (panel.LevelCardPanel.Dailog.quickBtn.Status.selectedIndex == 1)
		{
			NextStep = new Script_ThemeDungeonStartQuickBattle(LevelLocator);
		}
		else
		{
			NextStep = new Script_ThemeDungeonStartBattle(LevelLocator);
		}
		GButton assembledBtn = ((GComponent)panel.LevelCardPanel.Dailog).GetChild("assembledBtn").asButton;
		assembledBtn.FireClick(true, false);
		UI_MaskCover.OnTouchBegin(assembledBtn);
		((GObject)assembledBtn).onClick.Call();
		yield return (object)new WaitForSeconds(waitingGap);
		yield return null;
	}
}
