using System.Collections.Generic;
using Entitas;
using Shift.Legion.Common.Sources.Enums;

public sealed class UiEntity : Entity
{
	public NewMsgIncomingComponent newMsgIncoming => (NewMsgIncomingComponent)(object)((Entity)this).GetComponent(0);

	public bool hasNewMsgIncoming => ((Entity)this).HasComponent(0);

	public void AddNewMsgIncoming(List<string> newNewUnlockedSoldiers, List<string> newSoldiersCanEvolute, List<string> newSoldiersCanEvoluteChecked, List<string> newSoldiersCanBreakthrough, List<string> newSoldiersCanBreakthroughChecked, List<string> newSoldiersCanUpgradePotential, List<string> newSoldiersCanUpgradePotentialChecked, List<string> newSoldiersCanUnlock, List<string> newSoldiersCanUnlockChecked, Dictionary<AchievementCat, List<string>> newPendingToClaimAchievements, List<string> newPendingToAcceptBuildings, List<string> newBuildingsCanUpgrade, List<string> newActivitiesWithNewMsg)
	{
		int num = 0;
		NewMsgIncomingComponent newMsgIncomingComponent = (NewMsgIncomingComponent)(object)((Entity)this).CreateComponent(num, typeof(NewMsgIncomingComponent));
		newMsgIncomingComponent.NewUnlockedSoldiers = newNewUnlockedSoldiers;
		newMsgIncomingComponent.SoldiersCanEvolute = newSoldiersCanEvolute;
		newMsgIncomingComponent.SoldiersCanEvoluteChecked = newSoldiersCanEvoluteChecked;
		newMsgIncomingComponent.SoldiersCanBreakthrough = newSoldiersCanBreakthrough;
		newMsgIncomingComponent.SoldiersCanBreakthroughChecked = newSoldiersCanBreakthroughChecked;
		newMsgIncomingComponent.SoldiersCanUpgradePotential = newSoldiersCanUpgradePotential;
		newMsgIncomingComponent.SoldiersCanUpgradePotentialChecked = newSoldiersCanUpgradePotentialChecked;
		newMsgIncomingComponent.SoldiersCanUnlock = newSoldiersCanUnlock;
		newMsgIncomingComponent.SoldiersCanUnlockChecked = newSoldiersCanUnlockChecked;
		newMsgIncomingComponent.PendingToClaimAchievements = newPendingToClaimAchievements;
		newMsgIncomingComponent.PendingToAcceptBuildings = newPendingToAcceptBuildings;
		newMsgIncomingComponent.BuildingsCanUpgrade = newBuildingsCanUpgrade;
		newMsgIncomingComponent.ActivitiesWithNewMsg = newActivitiesWithNewMsg;
		((Entity)this).AddComponent(num, (IComponent)(object)newMsgIncomingComponent);
	}

	public void ReplaceNewMsgIncoming(List<string> newNewUnlockedSoldiers, List<string> newSoldiersCanEvolute, List<string> newSoldiersCanEvoluteChecked, List<string> newSoldiersCanBreakthrough, List<string> newSoldiersCanBreakthroughChecked, List<string> newSoldiersCanUpgradePotential, List<string> newSoldiersCanUpgradePotentialChecked, List<string> newSoldiersCanUnlock, List<string> newSoldiersCanUnlockChecked, Dictionary<AchievementCat, List<string>> newPendingToClaimAchievements, List<string> newPendingToAcceptBuildings, List<string> newBuildingsCanUpgrade, List<string> newActivitiesWithNewMsg)
	{
		int num = 0;
		NewMsgIncomingComponent newMsgIncomingComponent = (NewMsgIncomingComponent)(object)((Entity)this).CreateComponent(num, typeof(NewMsgIncomingComponent));
		newMsgIncomingComponent.NewUnlockedSoldiers = newNewUnlockedSoldiers;
		newMsgIncomingComponent.SoldiersCanEvolute = newSoldiersCanEvolute;
		newMsgIncomingComponent.SoldiersCanEvoluteChecked = newSoldiersCanEvoluteChecked;
		newMsgIncomingComponent.SoldiersCanBreakthrough = newSoldiersCanBreakthrough;
		newMsgIncomingComponent.SoldiersCanBreakthroughChecked = newSoldiersCanBreakthroughChecked;
		newMsgIncomingComponent.SoldiersCanUpgradePotential = newSoldiersCanUpgradePotential;
		newMsgIncomingComponent.SoldiersCanUpgradePotentialChecked = newSoldiersCanUpgradePotentialChecked;
		newMsgIncomingComponent.SoldiersCanUnlock = newSoldiersCanUnlock;
		newMsgIncomingComponent.SoldiersCanUnlockChecked = newSoldiersCanUnlockChecked;
		newMsgIncomingComponent.PendingToClaimAchievements = newPendingToClaimAchievements;
		newMsgIncomingComponent.PendingToAcceptBuildings = newPendingToAcceptBuildings;
		newMsgIncomingComponent.BuildingsCanUpgrade = newBuildingsCanUpgrade;
		newMsgIncomingComponent.ActivitiesWithNewMsg = newActivitiesWithNewMsg;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)newMsgIncomingComponent);
	}

	public void RemoveNewMsgIncoming()
	{
		((Entity)this).RemoveComponent(0);
	}
}
