using System;
using System.Collections.Generic;

namespace Shift.Legion.GvG.Helpers;

public class ChkCondition
{
	public string Key;

	public decimal Val;

	public string Op;

	public bool Check(Dictionary<string, decimal> input)
	{
		if (!input.GetValue(Key, out var value))
		{
			return false;
		}
		return Op switch
		{
			"=" => value == Val, 
			"<" => value < Val, 
			">" => value > Val, 
			"<=" => value <= Val, 
			">=" => value >= Val, 
			_ => throw new Exception("[Chk] Wrong Op =" + Op), 
		};
	}
}
