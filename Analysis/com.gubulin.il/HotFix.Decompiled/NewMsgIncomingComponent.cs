using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Shift.Legion.Common.Sources.Enums;

[Ui]
[Unique]
public sealed class NewMsgIncomingComponent : IComponent
{
	public List<string> NewUnlockedSoldiers = new List<string>();

	public List<string> SoldiersCanEvolute = new List<string>();

	public List<string> SoldiersCanEvoluteChecked = new List<string>();

	public List<string> SoldiersCanBreakthrough = new List<string>();

	public List<string> SoldiersCanBreakthroughChecked = new List<string>();

	public List<string> SoldiersCanUpgradePotential = new List<string>();

	public List<string> SoldiersCanUpgradePotentialChecked = new List<string>();

	public List<string> SoldiersCanUnlock = new List<string>();

	public List<string> SoldiersCanUnlockChecked = new List<string>();

	public Dictionary<AchievementCat, List<string>> PendingToClaimAchievements = new Dictionary<AchievementCat, List<string>>();

	public List<string> PendingToAcceptBuildings = new List<string>();

	public List<string> BuildingsCanUpgrade = new List<string>();

	public List<string> ActivitiesWithNewMsg = new List<string>();
}
