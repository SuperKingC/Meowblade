using System.Collections;
using Assets.Scripts.Managers;
using FairyGUI;
using UI.GameEndPanels;
using UI.InstanceZones;
using UI.MaskCover;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_DefenseDungeonEndQuickBattle : DefenseDungeonClickSimulatorStep
{
	public Script_DefenseDungeonEndQuickBattle(DefenseDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		yield return ClickSimulatorHelper.WaitBattleEndPanelShowUp(90f);
		SharedMessenger.Broadcast("CLICK_SIMULATOR_ONCE_CHALLENGE", LevelLocator.ActivityId);
		if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelVictory.Name, out var uiInst))
		{
			UI_GameEndPanelVictory victoryPanel = uiInst as UI_GameEndPanelVictory;
			yield return ClickSimulatorHelper.WaitForState(() => ((GObject)victoryPanel.againBtn).visible, targetState: true);
			if (!((GObject)victoryPanel.againBtn).touchable)
			{
				GComponent oldInstanceZonesPanel = ClickSimulatorHelper.GetUiInst(UI_InstanceZonesPanel.Name);
				UI_MaskCover.OnTouchBegin(victoryPanel.ReceiveBtn);
				victoryPanel.ReceiveBtn.FireClick(true, true);
				yield return ClickSimulatorHelper.WaitForState(() => ((GObject)oldInstanceZonesPanel).isDisposed, targetState: true, 10f);
				yield return ClickSimulatorHelper.WaitUisShowOnTop(10f, UI_InstanceZonesPanel.Name);
			}
		}
		else if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelFail.Name, out uiInst))
		{
			UI_GameEndPanelFail failPanel = uiInst as UI_GameEndPanelFail;
			yield return ClickSimulatorHelper.WaitForState(() => ((GObject)failPanel.YesButton).visible, targetState: true);
			SharedMessenger.Broadcast("CLICK_SIMULATOR_ABORTED", LanguagesManager.GetDesc("TipsMilitaryAFKAssistantBattleEndFailed"));
			yield break;
		}
		yield return null;
	}
}
