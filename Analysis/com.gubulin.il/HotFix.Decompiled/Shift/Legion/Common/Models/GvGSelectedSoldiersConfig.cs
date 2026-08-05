using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class GvGSelectedSoldiersConfig
{
	public string FId { get; set; } = "F01";

	public List<string> SoldierIds { get; set; } = new List<string> { "Unlock", "Unlock", "Unlock", "Unlock", "Unlock" };
}
