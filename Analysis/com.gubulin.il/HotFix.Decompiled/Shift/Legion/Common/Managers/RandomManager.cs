using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shift.Legion.Common.Managers;

public class RandomManager : Manager
{
	private ILRandom _random;

	private int _phase;

	private double _v1;

	private double _v2;

	private double _s;

	public RandomManager(GameManagers managers)
		: base(managers)
	{
	}

	public override Task Init()
	{
		_random = new ILRandom(DateTimeHelper.Now.Millisecond);
		return null;
	}

	public void SetSeed(int seed)
	{
		_random.InitState(seed);
	}

	public bool Bool(float chance)
	{
		return Float() < chance;
	}

	public int Int()
	{
		return _random.Next();
	}

	public int Int(int maxValue)
	{
		return _random.Next(maxValue);
	}

	public int Int(int minValue, int maxValue)
	{
		return _random.Next(minValue, maxValue);
	}

	public float Float()
	{
		return (float)_random.NextDouble();
	}

	public float Float(float minValue, float maxValue)
	{
		return minValue + (maxValue - minValue) * Float();
	}

	public T Element<T>(IList<T> elements)
	{
		return elements[Int(0, elements.Count)];
	}

	public double NormalRand()
	{
		double result;
		if (_phase == 0)
		{
			do
			{
				_v1 = _random.NextDouble() * 2.0 - 1.0;
				_v2 = _random.NextDouble() * 2.0 - 1.0;
				_s = _v1 * _v1 + _v2 * _v2;
			}
			while (_s >= 1.0 || Math.Abs(_s) < double.Epsilon);
			result = _v1 * Math.Sqrt(-2.0 * Math.Log(_s) / _s);
		}
		else
		{
			result = _v2 * Math.Sqrt(-2.0 * Math.Log(_s) / _s);
		}
		_phase = 1 - _phase;
		return result;
	}
}
