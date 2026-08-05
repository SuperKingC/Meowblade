using System;
using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class NewMsgIncomingConfig
{
	public List<string> NewUnlockedSoldiers = new List<string>();

	public List<string> SoldiersCanEvoluteChecked = new List<string>();

	public List<string> SoldiersCanBreakthroughChecked = new List<string>();

	public List<string> SoldiersCanUpgradePotentialChecked = new List<string>();

	public List<string> SoldiersCanUnlockChecked = new List<string>();

	public List<string> RegionHasStrongholdWithoutOccupantChecked = new List<string>();

	public List<string> BuildingChecked = new List<string>();

	public Dictionary<string, int> BuildingMaxLevelChecked = new Dictionary<string, int>();

	public Dictionary<string, List<string>> ActivityContentChecked = new Dictionary<string, List<string>>();

	public Dictionary<string, Dictionary<string, List<string>>> LastCheckStoreItemList = new Dictionary<string, Dictionary<string, List<string>>>();

	public int LastCheckTechPoint = 0;

	public DateTimeOffset LastCheckDate;

	public NewMsgIncomingConfig(DateTimeOffset lastCheckDate)
	{
		LastCheckDate = lastCheckDate;
	}
}
