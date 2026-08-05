using System;
using System.Collections.Generic;
using Entitas;
using Shift.Legion.Common.Sources.Enums;

public sealed class UiContext : Context<UiEntity>
{
	public UiEntity newMsgIncomingEntity => base.GetGroup(UiMatcher.NewMsgIncoming).GetSingleEntity();

	public NewMsgIncomingComponent newMsgIncoming => newMsgIncomingEntity.newMsgIncoming;

	public bool hasNewMsgIncoming => newMsgIncomingEntity != null;

	public UiEntity SetNewMsgIncoming(List<string> newNewUnlockedSoldiers, List<string> newSoldiersCanEvolute, List<string> newSoldiersCanEvoluteChecked, List<string> newSoldiersCanBreakthrough, List<string> newSoldiersCanBreakthroughChecked, List<string> newSoldiersCanUpgradePotential, List<string> newSoldiersCanUpgradePotentialChecked, List<string> newSoldiersCanUnlock, List<string> newSoldiersCanUnlockChecked, Dictionary<AchievementCat, List<string>> newPendingToClaimAchievements, List<string> newPendingToAcceptBuildings, List<string> newBuildingsCanUpgrade, List<string> newActivitiesWithNewMsg)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasNewMsgIncoming)
		{
			throw new EntitasException("Could not set NewMsgIncoming!\n" + ((object)this)?.ToString() + " already has an entity with NewMsgIncomingComponent!", "You should check if the context already has a newMsgIncomingEntity before setting it or use context.ReplaceNewMsgIncoming().");
		}
		UiEntity uiEntity = base.CreateEntity();
		uiEntity.AddNewMsgIncoming(newNewUnlockedSoldiers, newSoldiersCanEvolute, newSoldiersCanEvoluteChecked, newSoldiersCanBreakthrough, newSoldiersCanBreakthroughChecked, newSoldiersCanUpgradePotential, newSoldiersCanUpgradePotentialChecked, newSoldiersCanUnlock, newSoldiersCanUnlockChecked, newPendingToClaimAchievements, newPendingToAcceptBuildings, newBuildingsCanUpgrade, newActivitiesWithNewMsg);
		return uiEntity;
	}

	public void ReplaceNewMsgIncoming(List<string> newNewUnlockedSoldiers, List<string> newSoldiersCanEvolute, List<string> newSoldiersCanEvoluteChecked, List<string> newSoldiersCanBreakthrough, List<string> newSoldiersCanBreakthroughChecked, List<string> newSoldiersCanUpgradePotential, List<string> newSoldiersCanUpgradePotentialChecked, List<string> newSoldiersCanUnlock, List<string> newSoldiersCanUnlockChecked, Dictionary<AchievementCat, List<string>> newPendingToClaimAchievements, List<string> newPendingToAcceptBuildings, List<string> newBuildingsCanUpgrade, List<string> newActivitiesWithNewMsg)
	{
		UiEntity uiEntity = newMsgIncomingEntity;
		if (uiEntity == null)
		{
			uiEntity = SetNewMsgIncoming(newNewUnlockedSoldiers, newSoldiersCanEvolute, newSoldiersCanEvoluteChecked, newSoldiersCanBreakthrough, newSoldiersCanBreakthroughChecked, newSoldiersCanUpgradePotential, newSoldiersCanUpgradePotentialChecked, newSoldiersCanUnlock, newSoldiersCanUnlockChecked, newPendingToClaimAchievements, newPendingToAcceptBuildings, newBuildingsCanUpgrade, newActivitiesWithNewMsg);
		}
		else
		{
			uiEntity.ReplaceNewMsgIncoming(newNewUnlockedSoldiers, newSoldiersCanEvolute, newSoldiersCanEvoluteChecked, newSoldiersCanBreakthrough, newSoldiersCanBreakthroughChecked, newSoldiersCanUpgradePotential, newSoldiersCanUpgradePotentialChecked, newSoldiersCanUnlock, newSoldiersCanUnlockChecked, newPendingToClaimAchievements, newPendingToAcceptBuildings, newBuildingsCanUpgrade, newActivitiesWithNewMsg);
		}
	}

	public void RemoveNewMsgIncoming()
	{
		((Entity)newMsgIncomingEntity).Destroy();
	}

	public UiContext()
		: base(1, 0, new ContextInfo("Ui", UiComponentsLookup.componentNames, UiComponentsLookup.componentTypes), (Func<IEntity, IAERC>)((IEntity entity) => (IAERC)new UnsafeAERC()), (Func<UiEntity>)(() => new UiEntity()))
	{
	}//IL_0012: Unknown result type (might be due to invalid IL or missing references)
	//IL_005a: Expected O, but got Unknown

}
