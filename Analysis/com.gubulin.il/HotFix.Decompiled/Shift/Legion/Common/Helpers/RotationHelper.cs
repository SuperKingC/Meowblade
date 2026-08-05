using GameMaths;

namespace Shift.Legion.Common.Helpers;

public static class RotationHelper
{
	public static Quaternion Left = Quaternion.Euler(0f, 180f, 0f);

	public static Quaternion Right = Quaternion.identity;

	public static Quaternion FlipLeft = Quaternion.Euler(0f, -180f, 0f);

	public static Quaternion UnitBaseImageLeft = Quaternion.Euler(90f, 180f, 0f);

	public static Quaternion UnitBaseImageRight = Quaternion.Euler(90f, 0f, 0f);

	public static short GetUnitRotationShortValue(Quaternion rotation)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return (!(rotation == Left)) ? ((short)1) : ((short)0);
	}

	public static Quaternion GetUnitRotationFromShortValue(short rotation)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		return (rotation == 0) ? Left : Right;
	}
}
