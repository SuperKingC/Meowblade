namespace Shift.Legion.Common.Helpers;

public static class EnumHelper
{
	public static bool HasFlags(sbyte p1, sbyte p2)
	{
		return (p1 & p2) != 0;
	}

	public static bool HasFlags(byte p1, byte p2)
	{
		return (p1 & p2) != 0;
	}

	public static bool HasFlags(short p1, short p2)
	{
		return (p1 & p2) != 0;
	}

	public static bool HasFlags(ushort p1, ushort p2)
	{
		return (p1 & p2) != 0;
	}

	public static bool HasFlags(int p1, int p2)
	{
		return (p1 & p2) != 0;
	}

	public static bool HasFlags(uint p1, uint p2)
	{
		return (p1 & p2) != 0;
	}

	public static bool HasFlags(long p1, long p2)
	{
		return (p1 & p2) != 0;
	}

	public static bool HasFlags(ulong p1, ulong p2)
	{
		return (p1 & p2) != 0;
	}
}
