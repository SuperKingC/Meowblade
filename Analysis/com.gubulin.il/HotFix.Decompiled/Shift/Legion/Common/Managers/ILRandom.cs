using System;

namespace Shift.Legion.Common.Managers;

public class ILRandom
{
	private const int MBIG = int.MaxValue;

	private const int MSEED = 161803398;

	private int _inext;

	private int _inextp;

	private readonly int[] _seedArray = new int[56];

	public ILRandom(int seed)
	{
		InitState(seed);
	}

	public void InitState(int seed)
	{
		int num = 0;
		int num2 = ((seed == int.MinValue) ? int.MaxValue : Math.Abs(seed));
		int num3 = 161803398 - num2;
		_seedArray[55] = num3;
		int num4 = 1;
		for (int i = 1; i < 55; i++)
		{
			if ((num += 21) >= 55)
			{
				num -= 55;
			}
			_seedArray[num] = num4;
			num4 = num3 - num4;
			if (num4 < 0)
			{
				num4 += int.MaxValue;
			}
			num3 = _seedArray[num];
		}
		for (int j = 1; j < 5; j++)
		{
			for (int k = 1; k < 56; k++)
			{
				int num5 = k + 30;
				if (num5 >= 55)
				{
					num5 -= 55;
				}
				_seedArray[k] -= _seedArray[1 + num5];
				if (_seedArray[k] < 0)
				{
					_seedArray[k] += int.MaxValue;
				}
			}
		}
		_inext = 0;
		_inextp = 21;
	}

	protected virtual double Sample()
	{
		return (double)InternalSample() * 4.656612875245797E-10;
	}

	private int InternalSample()
	{
		int inext = _inext;
		int inextp = _inextp;
		if (++inext >= 56)
		{
			inext = 1;
		}
		if (++inextp >= 56)
		{
			inextp = 1;
		}
		int num = _seedArray[inext] - _seedArray[inextp];
		if (num == int.MaxValue)
		{
			num--;
		}
		if (num < 0)
		{
			num += int.MaxValue;
		}
		_seedArray[inext] = num;
		_inext = inext;
		_inextp = inextp;
		return num;
	}

	public virtual int Next()
	{
		return InternalSample();
	}

	private double GetSampleForLargeRange()
	{
		int num = InternalSample();
		if (InternalSample() % 2 == 0)
		{
			num = -num;
		}
		double num2 = num;
		num2 += 2147483646.0;
		return num2 / 4294967293.0;
	}

	public virtual int Next(int minValue, int maxValue)
	{
		if (minValue > maxValue)
		{
			throw new ArgumentOutOfRangeException("minValue", $"minValue({minValue}) must be less than or equal to maxValue({maxValue})");
		}
		long num = (long)maxValue - (long)minValue;
		if (num <= int.MaxValue)
		{
			return (int)(Sample() * (double)num) + minValue;
		}
		return (int)((long)(GetSampleForLargeRange() * (double)num) + minValue);
	}

	public virtual int Next(int maxValue)
	{
		if (maxValue < 0)
		{
			throw new ArgumentOutOfRangeException("maxValue", $"maxValue({maxValue}) must be positive");
		}
		return (int)(Sample() * (double)maxValue);
	}

	public virtual double NextDouble()
	{
		return Sample();
	}

	public double NextDouble(float minValue, float maxValue)
	{
		return (double)minValue + (double)(maxValue - minValue) * NextDouble();
	}

	public virtual void NextBytes(byte[] buffer)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		for (int i = 0; i < buffer.Length; i++)
		{
			buffer[i] = (byte)InternalSample();
		}
	}
}
