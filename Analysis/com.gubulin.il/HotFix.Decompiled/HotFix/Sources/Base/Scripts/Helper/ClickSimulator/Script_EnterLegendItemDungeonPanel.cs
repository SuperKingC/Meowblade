using System.Collections;
using FairyGUI;
using UI.MaskCover;
using UI.MilitaryIntelligence;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_EnterLegendItemDungeonPanel : LegendItemDungeonClickSimulatorStep
{
	public Script_EnterLegendItemDungeonPanel(LegendItemDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		IEnumerator tryGetUiEnumerator = ClickSimulatorHelper.WaitTryingGetUiInstOnTop(UI_MilitaryIntelligencePanel.Name);
		yield return tryGetUiEnumerator;
		UI_MilitaryIntelligencePanel panel = tryGetUiEnumerator.Current as UI_MilitaryIntelligencePanel;
		for (int i = 0; i < panel.CardLoader.cardList.numItems; i++)
		{
			UI_StandardCardNew entrance = ((GComponent)panel.CardLoader.cardList).GetChildAt(i) as UI_StandardCardNew;
			if (((GObject)entrance).touchable && entrance.TypeController.selectedIndex == 4)
			{
				((GButton)entrance).FireClick(true, false);
				UI_MaskCover.OnTouchBegin((GButton)(object)entrance);
				((GObject)entrance).onClick.Call();
				NextStep = new Script_LegendItemDungeonChooseLevel(LevelLocator);
				yield return (object)new WaitForSeconds(waitingGap);
				break;
			}
		}
		yield return null;
	}
}
