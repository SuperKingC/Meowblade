using System;

public static class FloatExtension
{
	public static float Truncate(this float value, int digits)
	{
		double num = Math.Pow(10.0, digits);
		double num2 = Math.Truncate(num * (double)value) / num;
		return (float)num2;
	}
}
