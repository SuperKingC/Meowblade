using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Managers;
using FairyGUI;
using Shift.Legion.Common.Models;
using UI.InstanceZones;
using UI.MaskCover;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_OffensiveDungeonRefreshLevel : OffensiveDungeonClickSimulatorStep
{
	public new OffensiveDungeonLevelLocator LevelLocator;

	public Script_OffensiveDungeonRefreshLevel(OffensiveDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		IEnumerator tryGetUiEnumerator = ClickSimulatorHelper.WaitTryingGetUiInstOnTop(UI_InstanceZonesPanel.Name);
		yield return tryGetUiEnumerator;
		UI_InstanceZonesPanel panel = tryGetUiEnumerator.Current as UI_InstanceZonesPanel;
		((GButton)panel.RefreshCardBtn).FireClick(true, false);
		UI_MaskCover.OnTouchBegin((GButton)(object)panel.RefreshCardBtn);
		((GObject)panel.RefreshCardBtn).onClick.Call();
		yield return (object)new WaitForSeconds(waitingGap);
		List<Level> oldLevels = typeof(UI_InstanceZonesPanel).GetField("levels", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(panel) as List<Level>;
		List<string> oldLevelIds = new List<string>();
		foreach (Level oldLevel in oldLevels)
		{
			oldLevelIds.Add(oldLevel.LevelId);
		}
		UI_RefreshCardPopup refreshCardPopup = typeof(UI_InstanceZonesPanel).GetField("RefreshCardPopup", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(panel) as UI_RefreshCardPopup;
		if (!((GObject)refreshCardPopup.ConfirmDialog.RefreshCardBtn).enabled)
		{
			SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsNeedMoreOffensiveRefreshTickets"));
			yield break;
		}
		UI_MaskCover.OnTouchBegin((GButton)(object)refreshCardPopup.ConfirmDialog.RefreshCardBtn);
		((GButton)refreshCardPopup.ConfirmDialog.RefreshCardBtn).FireClick(true, true);
		List<Level> curLevels = new List<Level>();
		for (int i = 0; i < oldLevels.Count; i++)
		{
			Level oldLevel2 = oldLevels[i];
			curLevels.Add(oldLevel2);
		}
		bool levelRefreshed = false;
		do
		{
			curLevels = typeof(UI_InstanceZonesPanel).GetField("levels", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(panel) as List<Level>;
			if (curLevels.Count == oldLevels.Count)
			{
				for (int j = 0; j < curLevels.Count; j++)
				{
					if (curLevels[j].LevelId != oldLevelIds[j])
					{
						levelRefreshed = true;
						break;
					}
				}
				if (levelRefreshed)
				{
					break;
				}
			}
			yield return (object)new WaitForSeconds(0.5f);
		}
		while (!levelRefreshed);
		NextStep = new Script_OffensiveDungeonChooseLevel(LevelLocator);
		yield return null;
	}
}
