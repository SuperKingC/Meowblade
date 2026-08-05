using Entitas;

public sealed class ConfigEventSystems : Feature
{
	public ConfigEventSystems(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new AnyBaseVisionRadiusEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyBattleConfigEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyBattleDebugSwitcherEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyCurrentFormationEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyFormationUnitsEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyHealBarSwitcherEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyLoadViewFromResourcesEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyLoadViewFromResourcesRemovedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyStagingAreaOffsetEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyStagingAreaSizeEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyStartFightingDistanceEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyTheSpeedOfMarchingOnEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyUnitNumberEventSystem(contexts));
	}
}
