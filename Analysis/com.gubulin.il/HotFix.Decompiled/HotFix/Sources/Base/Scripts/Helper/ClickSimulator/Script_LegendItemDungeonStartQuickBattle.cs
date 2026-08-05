using System.Collections;
using System.Reflection;
using FairyGUI;
using UI.MaskCover;
using UI.QuickBattle;

namespace HotFix.Sources.Base.Scripts.Helper.ClickSimulator;

public class Script_LegendItemDungeonStartQuickBattle : LegendItemDungeonClickSimulatorStep
{
	public Script_LegendItemDungeonStartQuickBattle(LegendItemDungeonLevelLocator levelLocator)
	{
		LevelLocator = levelLocator;
		NextStep = new Script_LegendItemDungeonEndQuickBattle(levelLocator);
	}

	public override IEnumerator Execute()
	{
		IEnumerator tryGetUiEnumerator = ClickSimulatorHelper.WaitTryingGetUiInstOnTop(UI_QuickBattlePanel.Name, 10f);
		yield return tryGetUiEnumerator;
		UI_QuickBattlePanel panel = tryGetUiEnumerator.Current as UI_QuickBattlePanel;
		((GButton)panel.MakeWar).FireClick(true, false);
		UI_MaskCover.OnTouchBegin((GButton)(object)panel.MakeWar);
		((GObject)panel.MakeWar).onClick.Call();
		object showSoldiersNumTipVal = typeof(UI_QuickBattlePanel).GetField("showSoldiersNumTip", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(panel);
		bool showSoldiersNumTip = default(bool);
		int num;
		if (showSoldiersNumTipVal is bool)
		{
			showSoldiersNumTip = (bool)showSoldiersNumTipVal;
			num = 1;
		}
		else
		{
			num = 0;
		}
		if (num == 0)
		{
			showSoldiersNumTip = false;
		}
		object showDispatchSoldierTipVal = typeof(UI_QuickBattlePanel).GetField("showDispatchSoldierTip", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(panel);
		bool showDispatchSoldierTip = default(bool);
		int num2;
		if (showDispatchSoldierTipVal is bool)
		{
			showDispatchSoldierTip = (bool)showDispatchSoldierTipVal;
			num2 = 1;
		}
		else
		{
			num2 = 0;
		}
		if (num2 == 0)
		{
			showDispatchSoldierTip = false;
		}
		if (!showSoldiersNumTip && !showDispatchSoldierTip)
		{
			NextStep = new Script_LegendItemDungeonEndQuickBattle(LevelLocator);
		}
		yield return null;
	}
}
