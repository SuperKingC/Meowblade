using System.Collections;
using FairyGUI;
using UI.GameEndPanels;
using UI.MaskCover;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_LegendItemDungeonRestartQuickBattle : LegendItemDungeonClickSimulatorStep
{
	public Script_LegendItemDungeonRestartQuickBattle(LegendItemDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelVictory.Name, out var uiInst))
		{
			UI_GameEndPanelVictory victoryPanel = uiInst as UI_GameEndPanelVictory;
			yield return ClickSimulatorHelper.WaitForState(() => ((GObject)victoryPanel.againBtn).visible, targetState: true);
			UI_MaskCover.OnTouchBegin((GButton)(object)victoryPanel.againBtn);
			((GButton)victoryPanel.againBtn).FireClick(true, true);
		}
		NextStep = new Script_LegendItemDungeonEndQuickBattle(LevelLocator);
		yield return null;
	}
}
