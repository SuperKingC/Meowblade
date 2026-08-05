using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;

public class GvG3SettlementSoldierReturn
{
	public Dictionary<string, int> SoldierInShips { get; set; } = new Dictionary<string, int>();

	public Dictionary<string, int> ShipPlanRemainingSoldiers { get; set; } = new Dictionary<string, int>();
}
