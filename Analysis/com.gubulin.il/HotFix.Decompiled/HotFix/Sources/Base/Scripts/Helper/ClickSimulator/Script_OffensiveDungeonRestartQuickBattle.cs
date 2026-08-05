using System.Collections;
using FairyGUI;
using UI.GameEndPanels;
using UI.MaskCover;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_OffensiveDungeonRestartQuickBattle : OffensiveDungeonClickSimulatorStep
{
	public Script_OffensiveDungeonRestartQuickBattle(OffensiveDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelVictory.Name, out var uiInst))
		{
			UI_GameEndPanelVictory victoryPanel = uiInst as UI_GameEndPanelVictory;
			yield return ClickSimulatorHelper.WaitForState(() => ((GObject)victoryPanel.ReceiveBtn).touchable, targetState: true);
			UI_MaskCover.OnTouchBegin(victoryPanel.ReceiveBtn);
			victoryPanel.ReceiveBtn.FireClick(true, true);
		}
		NextStep = new Script_OffensiveDungeonChooseLevel(LevelLocator);
		yield return null;
	}
}
