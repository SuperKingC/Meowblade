using System.Collections.Generic;

namespace Shift.Legion.GvG.Common.Model;

public class GvGFrameData
{
	public int Frame;

	public Dictionary<string, Dictionary<string, object>> Datas = new Dictionary<string, Dictionary<string, object>>();
}
