using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class SoulKeyItemEffect
{
	public string SoldierId { get; set; }

	public int PotentialLevel { get; set; }

	public Dictionary<string, int> GiveBack { get; set; }
}
