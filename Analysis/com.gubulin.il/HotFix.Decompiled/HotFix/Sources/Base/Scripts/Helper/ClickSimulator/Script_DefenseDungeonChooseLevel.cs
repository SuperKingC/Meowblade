using System.Collections;
using FairyGUI;
using UI.InstanceZones;
using UI.MaskCover;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_DefenseDungeonChooseLevel : DefenseDungeonClickSimulatorStep
{
	public new DefenseDungeonLevelLocator LevelLocator;

	public Script_DefenseDungeonChooseLevel(DefenseDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		IEnumerator tryGetUiEnumerator = ClickSimulatorHelper.WaitTryingGetUiInstOnTop(UI_InstanceZonesPanel.Name);
		yield return tryGetUiEnumerator;
		UI_InstanceZonesPanel panel = tryGetUiEnumerator.Current as UI_InstanceZonesPanel;
		UI_DefensiveTaskCom levelCard = ((GComponent)panel.DefensiveMissionList).GetChildAt(LevelLocator.LevelIndex) as UI_DefensiveTaskCom;
		UI_assembledBtn assembledBtn = levelCard.assembledBtn;
		if (levelCard.quickBtn.Status.selectedIndex == 1)
		{
			NextStep = new Script_DefenseDungeonStartQuickBattle(LevelLocator);
		}
		else
		{
			NextStep = new Script_DefenseDungeonStartBattle(LevelLocator);
		}
		((GButton)assembledBtn).FireClick(true, false);
		UI_MaskCover.OnTouchBegin((GButton)(object)assembledBtn);
		((GObject)assembledBtn).onClick.Call();
		yield return (object)new WaitForSeconds(waitingGap);
		yield return null;
	}
}
