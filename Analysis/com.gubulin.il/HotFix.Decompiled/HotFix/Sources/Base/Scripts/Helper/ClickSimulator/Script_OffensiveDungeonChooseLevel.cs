using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using FairyGUI;
using UI.InstanceZones;
using UI.MaskCover;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_OffensiveDungeonChooseLevel : OffensiveDungeonClickSimulatorStep
{
	public Script_OffensiveDungeonChooseLevel(OffensiveDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
	}

	public override IEnumerator Execute()
	{
		IEnumerator tryGetUiEnumerator = ClickSimulatorHelper.WaitTryingGetUiInstOnTop(UI_InstanceZonesPanel.Name);
		yield return tryGetUiEnumerator;
		UI_InstanceZonesPanel panel = tryGetUiEnumerator.Current as UI_InstanceZonesPanel;
		List<GButton> offensiveCards = typeof(UI_InstanceZonesPanel).GetField("offensiveCards", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(panel) as List<GButton>;
		GButton lastRenderedCard = offensiveCards[offensiveCards.Count - 1];
		while (Mathf.Abs(((GObject)lastRenderedCard).alpha - 1f) > float.Epsilon)
		{
			yield return (object)new WaitForSeconds(0.5f);
		}
		UI_OffensiveCard chosenCard = null;
		for (int i = 0; i < offensiveCards.Count; i++)
		{
			UI_OffensiveCard card = offensiveCards[i] as UI_OffensiveCard;
			if (card.classList.numItems == LevelLocator.Difficulty && card.PageController.selectedIndex == 0)
			{
				chosenCard = card;
				break;
			}
		}
		if (chosenCard == null)
		{
			NextStep = new Script_OffensiveDungeonRefreshLevel(LevelLocator);
			yield break;
		}
		((GButton)chosenCard).FireClick(true, false);
		UI_MaskCover.OnTouchBegin((GButton)(object)chosenCard);
		((GObject)chosenCard).onClick.Call();
		yield return (object)new WaitForSeconds(waitingGap);
		if (panel.DefensiveLeftBack.quickBtn.Status.selectedIndex == 1)
		{
			NextStep = new Script_OffensiveDungeonStartQuickBattle(LevelLocator);
		}
		else
		{
			NextStep = new Script_OffensiveDungeonStartBattle(LevelLocator);
		}
		UI_MakeWar assembledBtn = panel.DefensiveLeftBack.MakeWarBtn;
		((GButton)assembledBtn).FireClick(true, false);
		UI_MaskCover.OnTouchBegin((GButton)(object)assembledBtn);
		((GObject)assembledBtn).onClick.Call();
		yield return (object)new WaitForSeconds(waitingGap);
		yield return null;
	}
}
