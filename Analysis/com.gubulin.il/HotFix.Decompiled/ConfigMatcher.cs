using Entitas;

public sealed class ConfigMatcher
{
	private static IMatcher<ConfigEntity> _matcherAgentConfig;

	private static IMatcher<ConfigEntity> _matcherAnyBaseVisionRadiusListener;

	private static IMatcher<ConfigEntity> _matcherAnyBattleConfigListener;

	private static IMatcher<ConfigEntity> _matcherAnyBattleDebugSwitcherListener;

	private static IMatcher<ConfigEntity> _matcherAnyCurrentFormationListener;

	private static IMatcher<ConfigEntity> _matcherAnyFormationUnitsListener;

	private static IMatcher<ConfigEntity> _matcherAnyHealBarSwitcherListener;

	private static IMatcher<ConfigEntity> _matcherAnyLoadViewFromResourcesListener;

	private static IMatcher<ConfigEntity> _matcherAnyLoadViewFromResourcesRemovedListener;

	private static IMatcher<ConfigEntity> _matcherAnyStagingAreaOffsetListener;

	private static IMatcher<ConfigEntity> _matcherAnyStagingAreaSizeListener;

	private static IMatcher<ConfigEntity> _matcherAnyStartFightingDistanceListener;

	private static IMatcher<ConfigEntity> _matcherAnyTheSpeedOfMarchingOnListener;

	private static IMatcher<ConfigEntity> _matcherAnyUnitNumberListener;

	private static IMatcher<ConfigEntity> _matcherBaseVisionRadius;

	private static IMatcher<ConfigEntity> _matcherBattleConfig;

	private static IMatcher<ConfigEntity> _matcherBattleDebugSwitcher;

	private static IMatcher<ConfigEntity> _matcherCurrentFormation;

	private static IMatcher<ConfigEntity> _matcherDefenceModeMeleeVisionRadius;

	private static IMatcher<ConfigEntity> _matcherDefenceModeRangedVisionRadius;

	private static IMatcher<ConfigEntity> _matcherFormationUnits;

	private static IMatcher<ConfigEntity> _matcherHealBarSwitcher;

	private static IMatcher<ConfigEntity> _matcherLoadViewFromResources;

	private static IMatcher<ConfigEntity> _matcherRvoTimeStep;

	private static IMatcher<ConfigEntity> _matcherShowDamage;

	private static IMatcher<ConfigEntity> _matcherStagingAreaOffset;

	private static IMatcher<ConfigEntity> _matcherStagingAreaSize;

	private static IMatcher<ConfigEntity> _matcherStartFightingDistance;

	private static IMatcher<ConfigEntity> _matcherTheSpeedOfMarchingOn;

	private static IMatcher<ConfigEntity> _matcherUiSettings;

	private static IMatcher<ConfigEntity> _matcherUnitNumber;

	public static IMatcher<ConfigEntity> AgentConfig
	{
		get
		{
			if (_matcherAgentConfig == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1]);
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherAgentConfig = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherAgentConfig;
		}
	}

	public static IMatcher<ConfigEntity> AnyBaseVisionRadiusListener
	{
		get
		{
			if (_matcherAnyBaseVisionRadiusListener == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 1 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherAnyBaseVisionRadiusListener = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherAnyBaseVisionRadiusListener;
		}
	}

	public static IMatcher<ConfigEntity> AnyBattleConfigListener
	{
		get
		{
			if (_matcherAnyBattleConfigListener == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 2 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherAnyBattleConfigListener = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherAnyBattleConfigListener;
		}
	}

	public static IMatcher<ConfigEntity> AnyBattleDebugSwitcherListener
	{
		get
		{
			if (_matcherAnyBattleDebugSwitcherListener == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 3 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherAnyBattleDebugSwitcherListener = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherAnyBattleDebugSwitcherListener;
		}
	}

	public static IMatcher<ConfigEntity> AnyCurrentFormationListener
	{
		get
		{
			if (_matcherAnyCurrentFormationListener == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 4 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherAnyCurrentFormationListener = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherAnyCurrentFormationListener;
		}
	}

	public static IMatcher<ConfigEntity> AnyFormationUnitsListener
	{
		get
		{
			if (_matcherAnyFormationUnitsListener == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 5 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherAnyFormationUnitsListener = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherAnyFormationUnitsListener;
		}
	}

	public static IMatcher<ConfigEntity> AnyHealBarSwitcherListener
	{
		get
		{
			if (_matcherAnyHealBarSwitcherListener == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 6 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherAnyHealBarSwitcherListener = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherAnyHealBarSwitcherListener;
		}
	}

	public static IMatcher<ConfigEntity> AnyLoadViewFromResourcesListener
	{
		get
		{
			if (_matcherAnyLoadViewFromResourcesListener == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 7 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherAnyLoadViewFromResourcesListener = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherAnyLoadViewFromResourcesListener;
		}
	}

	public static IMatcher<ConfigEntity> AnyLoadViewFromResourcesRemovedListener
	{
		get
		{
			if (_matcherAnyLoadViewFromResourcesRemovedListener == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 8 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherAnyLoadViewFromResourcesRemovedListener = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherAnyLoadViewFromResourcesRemovedListener;
		}
	}

	public static IMatcher<ConfigEntity> AnyStagingAreaOffsetListener
	{
		get
		{
			if (_matcherAnyStagingAreaOffsetListener == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 9 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherAnyStagingAreaOffsetListener = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherAnyStagingAreaOffsetListener;
		}
	}

	public static IMatcher<ConfigEntity> AnyStagingAreaSizeListener
	{
		get
		{
			if (_matcherAnyStagingAreaSizeListener == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 10 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherAnyStagingAreaSizeListener = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherAnyStagingAreaSizeListener;
		}
	}

	public static IMatcher<ConfigEntity> AnyStartFightingDistanceListener
	{
		get
		{
			if (_matcherAnyStartFightingDistanceListener == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 11 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherAnyStartFightingDistanceListener = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherAnyStartFightingDistanceListener;
		}
	}

	public static IMatcher<ConfigEntity> AnyTheSpeedOfMarchingOnListener
	{
		get
		{
			if (_matcherAnyTheSpeedOfMarchingOnListener == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 12 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherAnyTheSpeedOfMarchingOnListener = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherAnyTheSpeedOfMarchingOnListener;
		}
	}

	public static IMatcher<ConfigEntity> AnyUnitNumberListener
	{
		get
		{
			if (_matcherAnyUnitNumberListener == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 13 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherAnyUnitNumberListener = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherAnyUnitNumberListener;
		}
	}

	public static IMatcher<ConfigEntity> BaseVisionRadius
	{
		get
		{
			if (_matcherBaseVisionRadius == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 14 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherBaseVisionRadius = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherBaseVisionRadius;
		}
	}

	public static IMatcher<ConfigEntity> BattleConfig
	{
		get
		{
			if (_matcherBattleConfig == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 15 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherBattleConfig = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherBattleConfig;
		}
	}

	public static IMatcher<ConfigEntity> BattleDebugSwitcher
	{
		get
		{
			if (_matcherBattleDebugSwitcher == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 16 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherBattleDebugSwitcher = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherBattleDebugSwitcher;
		}
	}

	public static IMatcher<ConfigEntity> CurrentFormation
	{
		get
		{
			if (_matcherCurrentFormation == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 17 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherCurrentFormation = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherCurrentFormation;
		}
	}

	public static IMatcher<ConfigEntity> DefenceModeMeleeVisionRadius
	{
		get
		{
			if (_matcherDefenceModeMeleeVisionRadius == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 18 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherDefenceModeMeleeVisionRadius = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherDefenceModeMeleeVisionRadius;
		}
	}

	public static IMatcher<ConfigEntity> DefenceModeRangedVisionRadius
	{
		get
		{
			if (_matcherDefenceModeRangedVisionRadius == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 19 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherDefenceModeRangedVisionRadius = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherDefenceModeRangedVisionRadius;
		}
	}

	public static IMatcher<ConfigEntity> FormationUnits
	{
		get
		{
			if (_matcherFormationUnits == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 20 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherFormationUnits = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherFormationUnits;
		}
	}

	public static IMatcher<ConfigEntity> HealBarSwitcher
	{
		get
		{
			if (_matcherHealBarSwitcher == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 21 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherHealBarSwitcher = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherHealBarSwitcher;
		}
	}

	public static IMatcher<ConfigEntity> LoadViewFromResources
	{
		get
		{
			if (_matcherLoadViewFromResources == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 22 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherLoadViewFromResources = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherLoadViewFromResources;
		}
	}

	public static IMatcher<ConfigEntity> RvoTimeStep
	{
		get
		{
			if (_matcherRvoTimeStep == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 23 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherRvoTimeStep = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherRvoTimeStep;
		}
	}

	public static IMatcher<ConfigEntity> ShowDamage
	{
		get
		{
			if (_matcherShowDamage == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 24 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherShowDamage = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherShowDamage;
		}
	}

	public static IMatcher<ConfigEntity> StagingAreaOffset
	{
		get
		{
			if (_matcherStagingAreaOffset == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 25 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherStagingAreaOffset = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherStagingAreaOffset;
		}
	}

	public static IMatcher<ConfigEntity> StagingAreaSize
	{
		get
		{
			if (_matcherStagingAreaSize == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 26 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherStagingAreaSize = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherStagingAreaSize;
		}
	}

	public static IMatcher<ConfigEntity> StartFightingDistance
	{
		get
		{
			if (_matcherStartFightingDistance == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 27 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherStartFightingDistance = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherStartFightingDistance;
		}
	}

	public static IMatcher<ConfigEntity> TheSpeedOfMarchingOn
	{
		get
		{
			if (_matcherTheSpeedOfMarchingOn == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 28 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherTheSpeedOfMarchingOn = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherTheSpeedOfMarchingOn;
		}
	}

	public static IMatcher<ConfigEntity> UiSettings
	{
		get
		{
			if (_matcherUiSettings == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 29 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherUiSettings = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherUiSettings;
		}
	}

	public static IMatcher<ConfigEntity> UnitNumber
	{
		get
		{
			if (_matcherUnitNumber == null)
			{
				Matcher<ConfigEntity> val = (Matcher<ConfigEntity>)(object)Matcher<ConfigEntity>.AllOf(new int[1] { 30 });
				val.componentNames = ConfigComponentsLookup.componentNames;
				_matcherUnitNumber = (IMatcher<ConfigEntity>)(object)val;
			}
			return _matcherUnitNumber;
		}
	}

	public static IAllOfMatcher<ConfigEntity> AllOf(params int[] indices)
	{
		return Matcher<ConfigEntity>.AllOf(indices);
	}

	public static IAllOfMatcher<ConfigEntity> AllOf(params IMatcher<ConfigEntity>[] matchers)
	{
		return Matcher<ConfigEntity>.AllOf(matchers);
	}

	public static IAnyOfMatcher<ConfigEntity> AnyOf(params int[] indices)
	{
		return Matcher<ConfigEntity>.AnyOf(indices);
	}

	public static IAnyOfMatcher<ConfigEntity> AnyOf(params IMatcher<ConfigEntity>[] matchers)
	{
		return Matcher<ConfigEntity>.AnyOf(matchers);
	}
}
