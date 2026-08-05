using System;
using System.Collections.Generic;
using Shift.Legion.Common.Enums.Sources;

namespace Shift.Legion.Common.Models;

public class SubLegionConfig
{
	public SubLegionType Type;

	public string ContextId;

	public List<KeyValuePair<string, int>> SoldierStocks;

	public DateTimeOffset ExpireAt;
}
