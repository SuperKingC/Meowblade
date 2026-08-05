using System;

public static class ConfigComponentsLookup
{
	public const int AgentConfig = 0;

	public const int AnyBaseVisionRadiusListener = 1;

	public const int AnyBattleConfigListener = 2;

	public const int AnyBattleDebugSwitcherListener = 3;

	public const int AnyCurrentFormationListener = 4;

	public const int AnyFormationUnitsListener = 5;

	public const int AnyHealBarSwitcherListener = 6;

	public const int AnyLoadViewFromResourcesListener = 7;

	public const int AnyLoadViewFromResourcesRemovedListener = 8;

	public const int AnyStagingAreaOffsetListener = 9;

	public const int AnyStagingAreaSizeListener = 10;

	public const int AnyStartFightingDistanceListener = 11;

	public const int AnyTheSpeedOfMarchingOnListener = 12;

	public const int AnyUnitNumberListener = 13;

	public const int BaseVisionRadius = 14;

	public const int BattleConfig = 15;

	public const int BattleDebugSwitcher = 16;

	public const int CurrentFormation = 17;

	public const int DefenceModeMeleeVisionRadius = 18;

	public const int DefenceModeRangedVisionRadius = 19;

	public const int FormationUnits = 20;

	public const int HealBarSwitcher = 21;

	public const int LoadViewFromResources = 22;

	public const int RvoTimeStep = 23;

	public const int ShowDamage = 24;

	public const int StagingAreaOffset = 25;

	public const int StagingAreaSize = 26;

	public const int StartFightingDistance = 27;

	public const int TheSpeedOfMarchingOn = 28;

	public const int UiSettings = 29;

	public const int UnitNumber = 30;

	public const int TotalComponents = 31;

	public static readonly string[] componentNames = new string[31]
	{
		"AgentConfig", "AnyBaseVisionRadiusListener", "AnyBattleConfigListener", "AnyBattleDebugSwitcherListener", "AnyCurrentFormationListener", "AnyFormationUnitsListener", "AnyHealBarSwitcherListener", "AnyLoadViewFromResourcesListener", "AnyLoadViewFromResourcesRemovedListener", "AnyStagingAreaOffsetListener",
		"AnyStagingAreaSizeListener", "AnyStartFightingDistanceListener", "AnyTheSpeedOfMarchingOnListener", "AnyUnitNumberListener", "BaseVisionRadius", "BattleConfig", "BattleDebugSwitcher", "CurrentFormation", "DefenceModeMeleeVisionRadius", "DefenceModeRangedVisionRadius",
		"FormationUnits", "HealBarSwitcher", "LoadViewFromResources", "RvoTimeStep", "ShowDamage", "StagingAreaOffset", "StagingAreaSize", "StartFightingDistance", "TheSpeedOfMarchingOn", "UiSettings",
		"UnitNumber"
	};

	public static readonly Type[] componentTypes = new Type[31]
	{
		typeof(AgentConfigComponent),
		typeof(AnyBaseVisionRadiusListenerComponent),
		typeof(AnyBattleConfigListenerComponent),
		typeof(AnyBattleDebugSwitcherListenerComponent),
		typeof(AnyCurrentFormationListenerComponent),
		typeof(AnyFormationUnitsListenerComponent),
		typeof(AnyHealBarSwitcherListenerComponent),
		typeof(AnyLoadViewFromResourcesListenerComponent),
		typeof(AnyLoadViewFromResourcesRemovedListenerComponent),
		typeof(AnyStagingAreaOffsetListenerComponent),
		typeof(AnyStagingAreaSizeListenerComponent),
		typeof(AnyStartFightingDistanceListenerComponent),
		typeof(AnyTheSpeedOfMarchingOnListenerComponent),
		typeof(AnyUnitNumberListenerComponent),
		typeof(BaseVisionRadiusComponent),
		typeof(BattleConfigComponent),
		typeof(BattleDebugSwitcherComponent),
		typeof(CurrentFormationComponent),
		typeof(DefenceModeMeleeVisionRadiusComponent),
		typeof(DefenceModeRangedVisionRadiusComponent),
		typeof(FormationUnitsComponent),
		typeof(HealBarSwitcherComponent),
		typeof(LoadViewFromResourcesComponent),
		typeof(RvoTimeStepComponent),
		typeof(ShowDamageComponent),
		typeof(StagingAreaOffsetComponent),
		typeof(StagingAreaSizeComponent),
		typeof(StartFightingDistanceComponent),
		typeof(TheSpeedOfMarchingOnComponent),
		typeof(UiSettingsComponent),
		typeof(UnitNumberComponent)
	};
}
