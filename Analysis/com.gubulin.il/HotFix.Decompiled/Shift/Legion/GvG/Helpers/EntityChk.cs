using System.Collections.Generic;
using System.Linq;

namespace Shift.Legion.GvG.Helpers;

public class EntityChk
{
	public string Op;

	public List<ChkCondition> Chk;

	public bool Check(Dictionary<string, decimal> input)
	{
		string op = Op;
		string text = op;
		if (!(text == "|"))
		{
			if (text == "&")
			{
				return Chk.All((ChkCondition _chk) => _chk.Check(input));
			}
			return Chk.Any((ChkCondition _chk) => _chk.Check(input));
		}
		return Chk.Any((ChkCondition _chk) => _chk.Check(input));
	}
}
