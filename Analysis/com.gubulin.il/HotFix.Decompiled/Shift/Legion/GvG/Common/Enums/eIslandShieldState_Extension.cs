namespace Shift.Legion.GvG.Common.Enums;

public static class eIslandShieldState_Extension
{
	public static bool HasShield(this eIslandShieldState state)
	{
		return state == eIslandShieldState.Full || state == eIslandShieldState.Damaged || state == eIslandShieldState.Occupied;
	}
}
