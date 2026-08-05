using System;
using System.Collections.Generic;
using Entitas;
using GameMaths;
using Shift.Legion.Common.Models;

public sealed class ConfigContext : Context<ConfigEntity>
{
	public ConfigEntity agentConfigEntity => base.GetGroup(ConfigMatcher.AgentConfig).GetSingleEntity();

	public AgentConfigComponent agentConfig => agentConfigEntity.agentConfig;

	public bool hasAgentConfig => agentConfigEntity != null;

	public ConfigEntity baseVisionRadiusEntity => base.GetGroup(ConfigMatcher.BaseVisionRadius).GetSingleEntity();

	public BaseVisionRadiusComponent baseVisionRadius => baseVisionRadiusEntity.baseVisionRadius;

	public bool hasBaseVisionRadius => baseVisionRadiusEntity != null;

	public ConfigEntity battleConfigEntity => base.GetGroup(ConfigMatcher.BattleConfig).GetSingleEntity();

	public BattleConfigComponent battleConfig => battleConfigEntity.battleConfig;

	public bool hasBattleConfig => battleConfigEntity != null;

	public ConfigEntity battleDebugSwitcherEntity => base.GetGroup(ConfigMatcher.BattleDebugSwitcher).GetSingleEntity();

	public BattleDebugSwitcherComponent battleDebugSwitcher => battleDebugSwitcherEntity.battleDebugSwitcher;

	public bool hasBattleDebugSwitcher => battleDebugSwitcherEntity != null;

	public ConfigEntity currentFormationEntity => base.GetGroup(ConfigMatcher.CurrentFormation).GetSingleEntity();

	public CurrentFormationComponent currentFormation => currentFormationEntity.currentFormation;

	public bool hasCurrentFormation => currentFormationEntity != null;

	public ConfigEntity defenceModeMeleeVisionRadiusEntity => base.GetGroup(ConfigMatcher.DefenceModeMeleeVisionRadius).GetSingleEntity();

	public DefenceModeMeleeVisionRadiusComponent defenceModeMeleeVisionRadius => defenceModeMeleeVisionRadiusEntity.defenceModeMeleeVisionRadius;

	public bool hasDefenceModeMeleeVisionRadius => defenceModeMeleeVisionRadiusEntity != null;

	public ConfigEntity defenceModeRangedVisionRadiusEntity => base.GetGroup(ConfigMatcher.DefenceModeRangedVisionRadius).GetSingleEntity();

	public DefenceModeRangedVisionRadiusComponent defenceModeRangedVisionRadius => defenceModeRangedVisionRadiusEntity.defenceModeRangedVisionRadius;

	public bool hasDefenceModeRangedVisionRadius => defenceModeRangedVisionRadiusEntity != null;

	public ConfigEntity formationUnitsEntity => base.GetGroup(ConfigMatcher.FormationUnits).GetSingleEntity();

	public FormationUnitsComponent formationUnits => formationUnitsEntity.formationUnits;

	public bool hasFormationUnits => formationUnitsEntity != null;

	public ConfigEntity healBarSwitcherEntity => base.GetGroup(ConfigMatcher.HealBarSwitcher).GetSingleEntity();

	public HealBarSwitcherComponent healBarSwitcher => healBarSwitcherEntity.healBarSwitcher;

	public bool hasHealBarSwitcher => healBarSwitcherEntity != null;

	public ConfigEntity loadViewFromResourcesEntity => base.GetGroup(ConfigMatcher.LoadViewFromResources).GetSingleEntity();

	public bool isLoadViewFromResources
	{
		get
		{
			return loadViewFromResourcesEntity != null;
		}
		set
		{
			ConfigEntity configEntity = loadViewFromResourcesEntity;
			if (value != (configEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isLoadViewFromResources = true;
				}
				else
				{
					((Entity)configEntity).Destroy();
				}
			}
		}
	}

	public ConfigEntity rvoTimeStepEntity => base.GetGroup(ConfigMatcher.RvoTimeStep).GetSingleEntity();

	public RvoTimeStepComponent rvoTimeStep => rvoTimeStepEntity.rvoTimeStep;

	public bool hasRvoTimeStep => rvoTimeStepEntity != null;

	public ConfigEntity showDamageEntity => base.GetGroup(ConfigMatcher.ShowDamage).GetSingleEntity();

	public bool isShowDamage
	{
		get
		{
			return showDamageEntity != null;
		}
		set
		{
			ConfigEntity configEntity = showDamageEntity;
			if (value != (configEntity != null))
			{
				if (value)
				{
					base.CreateEntity().isShowDamage = true;
				}
				else
				{
					((Entity)configEntity).Destroy();
				}
			}
		}
	}

	public ConfigEntity stagingAreaOffsetEntity => base.GetGroup(ConfigMatcher.StagingAreaOffset).GetSingleEntity();

	public StagingAreaOffsetComponent stagingAreaOffset => stagingAreaOffsetEntity.stagingAreaOffset;

	public bool hasStagingAreaOffset => stagingAreaOffsetEntity != null;

	public ConfigEntity stagingAreaSizeEntity => base.GetGroup(ConfigMatcher.StagingAreaSize).GetSingleEntity();

	public StagingAreaSizeComponent stagingAreaSize => stagingAreaSizeEntity.stagingAreaSize;

	public bool hasStagingAreaSize => stagingAreaSizeEntity != null;

	public ConfigEntity startFightingDistanceEntity => base.GetGroup(ConfigMatcher.StartFightingDistance).GetSingleEntity();

	public StartFightingDistanceComponent startFightingDistance => startFightingDistanceEntity.startFightingDistance;

	public bool hasStartFightingDistance => startFightingDistanceEntity != null;

	public ConfigEntity theSpeedOfMarchingOnEntity => base.GetGroup(ConfigMatcher.TheSpeedOfMarchingOn).GetSingleEntity();

	public TheSpeedOfMarchingOnComponent theSpeedOfMarchingOn => theSpeedOfMarchingOnEntity.theSpeedOfMarchingOn;

	public bool hasTheSpeedOfMarchingOn => theSpeedOfMarchingOnEntity != null;

	public ConfigEntity uiSettingsEntity => base.GetGroup(ConfigMatcher.UiSettings).GetSingleEntity();

	public UiSettingsComponent uiSettings => uiSettingsEntity.uiSettings;

	public bool hasUiSettings => uiSettingsEntity != null;

	public ConfigEntity unitNumberEntity => base.GetGroup(ConfigMatcher.UnitNumber).GetSingleEntity();

	public UnitNumberComponent unitNumber => unitNumberEntity.unitNumber;

	public bool hasUnitNumber => unitNumberEntity != null;

	public ConfigEntity SetAgentConfig(int newMaxNeighbors, float newNeighborDist, float newTimeHorizon, float newTimeHorizonObst)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasAgentConfig)
		{
			throw new EntitasException("Could not set AgentConfig!\n" + ((object)this)?.ToString() + " already has an entity with AgentConfigComponent!", "You should check if the context already has a agentConfigEntity before setting it or use context.ReplaceAgentConfig().");
		}
		ConfigEntity configEntity = base.CreateEntity();
		configEntity.AddAgentConfig(newMaxNeighbors, newNeighborDist, newTimeHorizon, newTimeHorizonObst);
		return configEntity;
	}

	public void ReplaceAgentConfig(int newMaxNeighbors, float newNeighborDist, float newTimeHorizon, float newTimeHorizonObst)
	{
		ConfigEntity configEntity = agentConfigEntity;
		if (configEntity == null)
		{
			configEntity = SetAgentConfig(newMaxNeighbors, newNeighborDist, newTimeHorizon, newTimeHorizonObst);
		}
		else
		{
			configEntity.ReplaceAgentConfig(newMaxNeighbors, newNeighborDist, newTimeHorizon, newTimeHorizonObst);
		}
	}

	public void RemoveAgentConfig()
	{
		((Entity)agentConfigEntity).Destroy();
	}

	public ConfigEntity SetBaseVisionRadius(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBaseVisionRadius)
		{
			throw new EntitasException("Could not set BaseVisionRadius!\n" + ((object)this)?.ToString() + " already has an entity with BaseVisionRadiusComponent!", "You should check if the context already has a baseVisionRadiusEntity before setting it or use context.ReplaceBaseVisionRadius().");
		}
		ConfigEntity configEntity = base.CreateEntity();
		configEntity.AddBaseVisionRadius(newValue);
		return configEntity;
	}

	public void ReplaceBaseVisionRadius(int newValue)
	{
		ConfigEntity configEntity = baseVisionRadiusEntity;
		if (configEntity == null)
		{
			configEntity = SetBaseVisionRadius(newValue);
		}
		else
		{
			configEntity.ReplaceBaseVisionRadius(newValue);
		}
	}

	public void RemoveBaseVisionRadius()
	{
		((Entity)baseVisionRadiusEntity).Destroy();
	}

	public ConfigEntity SetBattleConfig(BattleConfig newRed, BattleConfig newBlue, float newBattleFieldLength)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleConfig)
		{
			throw new EntitasException("Could not set BattleConfig!\n" + ((object)this)?.ToString() + " already has an entity with BattleConfigComponent!", "You should check if the context already has a battleConfigEntity before setting it or use context.ReplaceBattleConfig().");
		}
		ConfigEntity configEntity = base.CreateEntity();
		configEntity.AddBattleConfig(newRed, newBlue, newBattleFieldLength);
		return configEntity;
	}

	public void ReplaceBattleConfig(BattleConfig newRed, BattleConfig newBlue, float newBattleFieldLength)
	{
		ConfigEntity configEntity = battleConfigEntity;
		if (configEntity == null)
		{
			configEntity = SetBattleConfig(newRed, newBlue, newBattleFieldLength);
		}
		else
		{
			configEntity.ReplaceBattleConfig(newRed, newBlue, newBattleFieldLength);
		}
	}

	public void RemoveBattleConfig()
	{
		((Entity)battleConfigEntity).Destroy();
	}

	public ConfigEntity SetBattleDebugSwitcher(bool newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasBattleDebugSwitcher)
		{
			throw new EntitasException("Could not set BattleDebugSwitcher!\n" + ((object)this)?.ToString() + " already has an entity with BattleDebugSwitcherComponent!", "You should check if the context already has a battleDebugSwitcherEntity before setting it or use context.ReplaceBattleDebugSwitcher().");
		}
		ConfigEntity configEntity = base.CreateEntity();
		configEntity.AddBattleDebugSwitcher(newValue);
		return configEntity;
	}

	public void ReplaceBattleDebugSwitcher(bool newValue)
	{
		ConfigEntity configEntity = battleDebugSwitcherEntity;
		if (configEntity == null)
		{
			configEntity = SetBattleDebugSwitcher(newValue);
		}
		else
		{
			configEntity.ReplaceBattleDebugSwitcher(newValue);
		}
	}

	public void RemoveBattleDebugSwitcher()
	{
		((Entity)battleDebugSwitcherEntity).Destroy();
	}

	public ConfigEntity SetCurrentFormation(Dictionary<string, Dictionary<string, string>> newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasCurrentFormation)
		{
			throw new EntitasException("Could not set CurrentFormation!\n" + ((object)this)?.ToString() + " already has an entity with CurrentFormationComponent!", "You should check if the context already has a currentFormationEntity before setting it or use context.ReplaceCurrentFormation().");
		}
		ConfigEntity configEntity = base.CreateEntity();
		configEntity.AddCurrentFormation(newValue);
		return configEntity;
	}

	public void ReplaceCurrentFormation(Dictionary<string, Dictionary<string, string>> newValue)
	{
		ConfigEntity configEntity = currentFormationEntity;
		if (configEntity == null)
		{
			configEntity = SetCurrentFormation(newValue);
		}
		else
		{
			configEntity.ReplaceCurrentFormation(newValue);
		}
	}

	public void RemoveCurrentFormation()
	{
		((Entity)currentFormationEntity).Destroy();
	}

	public ConfigEntity SetDefenceModeMeleeVisionRadius(float newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasDefenceModeMeleeVisionRadius)
		{
			throw new EntitasException("Could not set DefenceModeMeleeVisionRadius!\n" + ((object)this)?.ToString() + " already has an entity with DefenceModeMeleeVisionRadiusComponent!", "You should check if the context already has a defenceModeMeleeVisionRadiusEntity before setting it or use context.ReplaceDefenceModeMeleeVisionRadius().");
		}
		ConfigEntity configEntity = base.CreateEntity();
		configEntity.AddDefenceModeMeleeVisionRadius(newValue);
		return configEntity;
	}

	public void ReplaceDefenceModeMeleeVisionRadius(float newValue)
	{
		ConfigEntity configEntity = defenceModeMeleeVisionRadiusEntity;
		if (configEntity == null)
		{
			configEntity = SetDefenceModeMeleeVisionRadius(newValue);
		}
		else
		{
			configEntity.ReplaceDefenceModeMeleeVisionRadius(newValue);
		}
	}

	public void RemoveDefenceModeMeleeVisionRadius()
	{
		((Entity)defenceModeMeleeVisionRadiusEntity).Destroy();
	}

	public ConfigEntity SetDefenceModeRangedVisionRadius(float newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasDefenceModeRangedVisionRadius)
		{
			throw new EntitasException("Could not set DefenceModeRangedVisionRadius!\n" + ((object)this)?.ToString() + " already has an entity with DefenceModeRangedVisionRadiusComponent!", "You should check if the context already has a defenceModeRangedVisionRadiusEntity before setting it or use context.ReplaceDefenceModeRangedVisionRadius().");
		}
		ConfigEntity configEntity = base.CreateEntity();
		configEntity.AddDefenceModeRangedVisionRadius(newValue);
		return configEntity;
	}

	public void ReplaceDefenceModeRangedVisionRadius(float newValue)
	{
		ConfigEntity configEntity = defenceModeRangedVisionRadiusEntity;
		if (configEntity == null)
		{
			configEntity = SetDefenceModeRangedVisionRadius(newValue);
		}
		else
		{
			configEntity.ReplaceDefenceModeRangedVisionRadius(newValue);
		}
	}

	public void RemoveDefenceModeRangedVisionRadius()
	{
		((Entity)defenceModeRangedVisionRadiusEntity).Destroy();
	}

	public ConfigEntity SetFormationUnits(Dictionary<string, Dictionary<string, List<string>>> newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasFormationUnits)
		{
			throw new EntitasException("Could not set FormationUnits!\n" + ((object)this)?.ToString() + " already has an entity with FormationUnitsComponent!", "You should check if the context already has a formationUnitsEntity before setting it or use context.ReplaceFormationUnits().");
		}
		ConfigEntity configEntity = base.CreateEntity();
		configEntity.AddFormationUnits(newValue);
		return configEntity;
	}

	public void ReplaceFormationUnits(Dictionary<string, Dictionary<string, List<string>>> newValue)
	{
		ConfigEntity configEntity = formationUnitsEntity;
		if (configEntity == null)
		{
			configEntity = SetFormationUnits(newValue);
		}
		else
		{
			configEntity.ReplaceFormationUnits(newValue);
		}
	}

	public void RemoveFormationUnits()
	{
		((Entity)formationUnitsEntity).Destroy();
	}

	public ConfigEntity SetHealBarSwitcher(bool newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasHealBarSwitcher)
		{
			throw new EntitasException("Could not set HealBarSwitcher!\n" + ((object)this)?.ToString() + " already has an entity with HealBarSwitcherComponent!", "You should check if the context already has a healBarSwitcherEntity before setting it or use context.ReplaceHealBarSwitcher().");
		}
		ConfigEntity configEntity = base.CreateEntity();
		configEntity.AddHealBarSwitcher(newValue);
		return configEntity;
	}

	public void ReplaceHealBarSwitcher(bool newValue)
	{
		ConfigEntity configEntity = healBarSwitcherEntity;
		if (configEntity == null)
		{
			configEntity = SetHealBarSwitcher(newValue);
		}
		else
		{
			configEntity.ReplaceHealBarSwitcher(newValue);
		}
	}

	public void RemoveHealBarSwitcher()
	{
		((Entity)healBarSwitcherEntity).Destroy();
	}

	public ConfigEntity SetRvoTimeStep(float newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasRvoTimeStep)
		{
			throw new EntitasException("Could not set RvoTimeStep!\n" + ((object)this)?.ToString() + " already has an entity with RvoTimeStepComponent!", "You should check if the context already has a rvoTimeStepEntity before setting it or use context.ReplaceRvoTimeStep().");
		}
		ConfigEntity configEntity = base.CreateEntity();
		configEntity.AddRvoTimeStep(newValue);
		return configEntity;
	}

	public void ReplaceRvoTimeStep(float newValue)
	{
		ConfigEntity configEntity = rvoTimeStepEntity;
		if (configEntity == null)
		{
			configEntity = SetRvoTimeStep(newValue);
		}
		else
		{
			configEntity.ReplaceRvoTimeStep(newValue);
		}
	}

	public void RemoveRvoTimeStep()
	{
		((Entity)rvoTimeStepEntity).Destroy();
	}

	public ConfigEntity SetStagingAreaOffset(float newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasStagingAreaOffset)
		{
			throw new EntitasException("Could not set StagingAreaOffset!\n" + ((object)this)?.ToString() + " already has an entity with StagingAreaOffsetComponent!", "You should check if the context already has a stagingAreaOffsetEntity before setting it or use context.ReplaceStagingAreaOffset().");
		}
		ConfigEntity configEntity = base.CreateEntity();
		configEntity.AddStagingAreaOffset(newValue);
		return configEntity;
	}

	public void ReplaceStagingAreaOffset(float newValue)
	{
		ConfigEntity configEntity = stagingAreaOffsetEntity;
		if (configEntity == null)
		{
			configEntity = SetStagingAreaOffset(newValue);
		}
		else
		{
			configEntity.ReplaceStagingAreaOffset(newValue);
		}
	}

	public void RemoveStagingAreaOffset()
	{
		((Entity)stagingAreaOffsetEntity).Destroy();
	}

	public ConfigEntity SetStagingAreaSize(Vector2 newValue)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasStagingAreaSize)
		{
			throw new EntitasException("Could not set StagingAreaSize!\n" + ((object)this)?.ToString() + " already has an entity with StagingAreaSizeComponent!", "You should check if the context already has a stagingAreaSizeEntity before setting it or use context.ReplaceStagingAreaSize().");
		}
		ConfigEntity configEntity = base.CreateEntity();
		configEntity.AddStagingAreaSize(newValue);
		return configEntity;
	}

	public void ReplaceStagingAreaSize(Vector2 newValue)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		ConfigEntity configEntity = stagingAreaSizeEntity;
		if (configEntity == null)
		{
			configEntity = SetStagingAreaSize(newValue);
		}
		else
		{
			configEntity.ReplaceStagingAreaSize(newValue);
		}
	}

	public void RemoveStagingAreaSize()
	{
		((Entity)stagingAreaSizeEntity).Destroy();
	}

	public ConfigEntity SetStartFightingDistance(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasStartFightingDistance)
		{
			throw new EntitasException("Could not set StartFightingDistance!\n" + ((object)this)?.ToString() + " already has an entity with StartFightingDistanceComponent!", "You should check if the context already has a startFightingDistanceEntity before setting it or use context.ReplaceStartFightingDistance().");
		}
		ConfigEntity configEntity = base.CreateEntity();
		configEntity.AddStartFightingDistance(newValue);
		return configEntity;
	}

	public void ReplaceStartFightingDistance(int newValue)
	{
		ConfigEntity configEntity = startFightingDistanceEntity;
		if (configEntity == null)
		{
			configEntity = SetStartFightingDistance(newValue);
		}
		else
		{
			configEntity.ReplaceStartFightingDistance(newValue);
		}
	}

	public void RemoveStartFightingDistance()
	{
		((Entity)startFightingDistanceEntity).Destroy();
	}

	public ConfigEntity SetTheSpeedOfMarchingOn(float newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasTheSpeedOfMarchingOn)
		{
			throw new EntitasException("Could not set TheSpeedOfMarchingOn!\n" + ((object)this)?.ToString() + " already has an entity with TheSpeedOfMarchingOnComponent!", "You should check if the context already has a theSpeedOfMarchingOnEntity before setting it or use context.ReplaceTheSpeedOfMarchingOn().");
		}
		ConfigEntity configEntity = base.CreateEntity();
		configEntity.AddTheSpeedOfMarchingOn(newValue);
		return configEntity;
	}

	public void ReplaceTheSpeedOfMarchingOn(float newValue)
	{
		ConfigEntity configEntity = theSpeedOfMarchingOnEntity;
		if (configEntity == null)
		{
			configEntity = SetTheSpeedOfMarchingOn(newValue);
		}
		else
		{
			configEntity.ReplaceTheSpeedOfMarchingOn(newValue);
		}
	}

	public void RemoveTheSpeedOfMarchingOn()
	{
		((Entity)theSpeedOfMarchingOnEntity).Destroy();
	}

	public ConfigEntity SetUiSettings(Dictionary<string, UiSetting> newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasUiSettings)
		{
			throw new EntitasException("Could not set UiSettings!\n" + ((object)this)?.ToString() + " already has an entity with UiSettingsComponent!", "You should check if the context already has a uiSettingsEntity before setting it or use context.ReplaceUiSettings().");
		}
		ConfigEntity configEntity = base.CreateEntity();
		configEntity.AddUiSettings(newValue);
		return configEntity;
	}

	public void ReplaceUiSettings(Dictionary<string, UiSetting> newValue)
	{
		ConfigEntity configEntity = uiSettingsEntity;
		if (configEntity == null)
		{
			configEntity = SetUiSettings(newValue);
		}
		else
		{
			configEntity.ReplaceUiSettings(newValue);
		}
	}

	public void RemoveUiSettings()
	{
		((Entity)uiSettingsEntity).Destroy();
	}

	public ConfigEntity SetUnitNumber(int newValue)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (hasUnitNumber)
		{
			throw new EntitasException("Could not set UnitNumber!\n" + ((object)this)?.ToString() + " already has an entity with UnitNumberComponent!", "You should check if the context already has a unitNumberEntity before setting it or use context.ReplaceUnitNumber().");
		}
		ConfigEntity configEntity = base.CreateEntity();
		configEntity.AddUnitNumber(newValue);
		return configEntity;
	}

	public void ReplaceUnitNumber(int newValue)
	{
		ConfigEntity configEntity = unitNumberEntity;
		if (configEntity == null)
		{
			configEntity = SetUnitNumber(newValue);
		}
		else
		{
			configEntity.ReplaceUnitNumber(newValue);
		}
	}

	public void RemoveUnitNumber()
	{
		((Entity)unitNumberEntity).Destroy();
	}

	public ConfigContext()
		: base(31, 0, new ContextInfo("Config", ConfigComponentsLookup.componentNames, ConfigComponentsLookup.componentTypes), (Func<IEntity, IAERC>)((IEntity entity) => (IAERC)new UnsafeAERC()), (Func<ConfigEntity>)(() => new ConfigEntity()))
	{
	}//IL_0013: Unknown result type (might be due to invalid IL or missing references)
	//IL_005b: Expected O, but got Unknown

}
