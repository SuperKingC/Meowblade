using System.Collections;
using FairyGUI;
using Shift.Legion.Common.Services;
using UI.Battle;
using UI.GameEndPanels;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_LegendItemDungeonOnPause : LegendItemDungeonClickSimulatorStep
{
	public Script_LegendItemDungeonOnPause(LegendItemDungeonLevelLocator levelLocator)
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
				yield break;
			}
			yield return ClickSimulatorHelper.WaitBattleEndPanelShowUp(180f);
			SharedMessenger.Broadcast("CLICK_SIMULATOR_ONCE_CHALLENGE", LevelLocator.ActivityId);
			if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelVictory.Name, out uiInst))
			{
				UI_GameEndPanelVictory victoryPanel = uiInst as UI_GameEndPanelVictory;
				yield return ClickSimulatorHelper.WaitForState(() => ((GObject)victoryPanel.ReceiveBtn).touchable, targetState: true);
			}
			if (ClickSimulatorHelper.TryGetUiInstOnTop(UI_GameEndPanelFail.Name, out uiInst))
			{
				UI_GameEndPanelFail failPanel = uiInst as UI_GameEndPanelFail;
				yield return ClickSimulatorHelper.WaitForState(() => ((GObject)failPanel.YesButton).visible, targetState: true);
			}
		}
		else
		{
			yield return null;
		}
	}
}
