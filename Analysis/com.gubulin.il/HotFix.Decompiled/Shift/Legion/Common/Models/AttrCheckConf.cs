using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class AttrCheckConf
{
	public string name;

	public string op;

	public string val;

	public List<AttrCheckConf> sub;
}
