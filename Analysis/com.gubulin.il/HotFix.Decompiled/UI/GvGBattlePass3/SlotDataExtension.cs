namespace UI.GvGBattlePass3;

public static class SlotDataExtension
{
	public static bool IsHasNoActivatedBonus(this SlotData data, bool advancedActivated, bool premiumActivated)
	{
		bool flag = data.num_basic <= 0;
		bool flag2 = data.num_advanced <= 0 || !advancedActivated;
		bool flag3 = data.num_premium <= 0 || !premiumActivated;
		return flag && flag2 && flag3;
	}
}
