using System.Collections.Generic;
using Entitas;
using GameMaths;
using Shift.Legion.Common.Models;

public sealed class ConfigEntity : Entity
{
	private static readonly LoadViewFromResourcesComponent loadViewFromResourcesComponent = new LoadViewFromResourcesComponent();

	private static readonly ShowDamageComponent showDamageComponent = new ShowDamageComponent();

	public AgentConfigComponent agentConfig => (AgentConfigComponent)(object)((Entity)this).GetComponent(0);

	public bool hasAgentConfig => ((Entity)this).HasComponent(0);

	public AnyBaseVisionRadiusListenerComponent anyBaseVisionRadiusListener => (AnyBaseVisionRadiusListenerComponent)(object)((Entity)this).GetComponent(1);

	public bool hasAnyBaseVisionRadiusListener => ((Entity)this).HasComponent(1);

	public AnyBattleConfigListenerComponent anyBattleConfigListener => (AnyBattleConfigListenerComponent)(object)((Entity)this).GetComponent(2);

	public bool hasAnyBattleConfigListener => ((Entity)this).HasComponent(2);

	public AnyBattleDebugSwitcherListenerComponent anyBattleDebugSwitcherListener => (AnyBattleDebugSwitcherListenerComponent)(object)((Entity)this).GetComponent(3);

	public bool hasAnyBattleDebugSwitcherListener => ((Entity)this).HasComponent(3);

	public AnyCurrentFormationListenerComponent anyCurrentFormationListener => (AnyCurrentFormationListenerComponent)(object)((Entity)this).GetComponent(4);

	public bool hasAnyCurrentFormationListener => ((Entity)this).HasComponent(4);

	public AnyFormationUnitsListenerComponent anyFormationUnitsListener => (AnyFormationUnitsListenerComponent)(object)((Entity)this).GetComponent(5);

	public bool hasAnyFormationUnitsListener => ((Entity)this).HasComponent(5);

	public AnyHealBarSwitcherListenerComponent anyHealBarSwitcherListener => (AnyHealBarSwitcherListenerComponent)(object)((Entity)this).GetComponent(6);

	public bool hasAnyHealBarSwitcherListener => ((Entity)this).HasComponent(6);

	public AnyLoadViewFromResourcesListenerComponent anyLoadViewFromResourcesListener => (AnyLoadViewFromResourcesListenerComponent)(object)((Entity)this).GetComponent(7);

	public bool hasAnyLoadViewFromResourcesListener => ((Entity)this).HasComponent(7);

	public AnyLoadViewFromResourcesRemovedListenerComponent anyLoadViewFromResourcesRemovedListener => (AnyLoadViewFromResourcesRemovedListenerComponent)(object)((Entity)this).GetComponent(8);

	public bool hasAnyLoadViewFromResourcesRemovedListener => ((Entity)this).HasComponent(8);

	public AnyStagingAreaOffsetListenerComponent anyStagingAreaOffsetListener => (AnyStagingAreaOffsetListenerComponent)(object)((Entity)this).GetComponent(9);

	public bool hasAnyStagingAreaOffsetListener => ((Entity)this).HasComponent(9);

	public AnyStagingAreaSizeListenerComponent anyStagingAreaSizeListener => (AnyStagingAreaSizeListenerComponent)(object)((Entity)this).GetComponent(10);

	public bool hasAnyStagingAreaSizeListener => ((Entity)this).HasComponent(10);

	public AnyStartFightingDistanceListenerComponent anyStartFightingDistanceListener => (AnyStartFightingDistanceListenerComponent)(object)((Entity)this).GetComponent(11);

	public bool hasAnyStartFightingDistanceListener => ((Entity)this).HasComponent(11);

	public AnyTheSpeedOfMarchingOnListenerComponent anyTheSpeedOfMarchingOnListener => (AnyTheSpeedOfMarchingOnListenerComponent)(object)((Entity)this).GetComponent(12);

	public bool hasAnyTheSpeedOfMarchingOnListener => ((Entity)this).HasComponent(12);

	public AnyUnitNumberListenerComponent anyUnitNumberListener => (AnyUnitNumberListenerComponent)(object)((Entity)this).GetComponent(13);

	public bool hasAnyUnitNumberListener => ((Entity)this).HasComponent(13);

	public BaseVisionRadiusComponent baseVisionRadius => (BaseVisionRadiusComponent)(object)((Entity)this).GetComponent(14);

	public bool hasBaseVisionRadius => ((Entity)this).HasComponent(14);

	public BattleConfigComponent battleConfig => (BattleConfigComponent)(object)((Entity)this).GetComponent(15);

	public bool hasBattleConfig => ((Entity)this).HasComponent(15);

	public BattleDebugSwitcherComponent battleDebugSwitcher => (BattleDebugSwitcherComponent)(object)((Entity)this).GetComponent(16);

	public bool hasBattleDebugSwitcher => ((Entity)this).HasComponent(16);

	public CurrentFormationComponent currentFormation => (CurrentFormationComponent)(object)((Entity)this).GetComponent(17);

	public bool hasCurrentFormation => ((Entity)this).HasComponent(17);

	public DefenceModeMeleeVisionRadiusComponent defenceModeMeleeVisionRadius => (DefenceModeMeleeVisionRadiusComponent)(object)((Entity)this).GetComponent(18);

	public bool hasDefenceModeMeleeVisionRadius => ((Entity)this).HasComponent(18);

	public DefenceModeRangedVisionRadiusComponent defenceModeRangedVisionRadius => (DefenceModeRangedVisionRadiusComponent)(object)((Entity)this).GetComponent(19);

	public bool hasDefenceModeRangedVisionRadius => ((Entity)this).HasComponent(19);

	public FormationUnitsComponent formationUnits => (FormationUnitsComponent)(object)((Entity)this).GetComponent(20);

	public bool hasFormationUnits => ((Entity)this).HasComponent(20);

	public HealBarSwitcherComponent healBarSwitcher => (HealBarSwitcherComponent)(object)((Entity)this).GetComponent(21);

	public bool hasHealBarSwitcher => ((Entity)this).HasComponent(21);

	public bool isLoadViewFromResources
	{
		get
		{
			return ((Entity)this).HasComponent(22);
		}
		set
		{
			if (value == isLoadViewFromResources)
			{
				return;
			}
			int num = 22;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)loadViewFromResourcesComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public RvoTimeStepComponent rvoTimeStep => (RvoTimeStepComponent)(object)((Entity)this).GetComponent(23);

	public bool hasRvoTimeStep => ((Entity)this).HasComponent(23);

	public bool isShowDamage
	{
		get
		{
			return ((Entity)this).HasComponent(24);
		}
		set
		{
			if (value == isShowDamage)
			{
				return;
			}
			int num = 24;
			if (value)
			{
				Stack<IComponent> componentPool = ((Entity)this).GetComponentPool(num);
				IComponent obj;
				if (componentPool.Count <= 0)
				{
					IComponent val = (IComponent)(object)showDamageComponent;
					obj = val;
				}
				else
				{
					obj = componentPool.Pop();
				}
				IComponent val2 = obj;
				((Entity)this).AddComponent(num, val2);
			}
			else
			{
				((Entity)this).RemoveComponent(num);
			}
		}
	}

	public StagingAreaOffsetComponent stagingAreaOffset => (StagingAreaOffsetComponent)(object)((Entity)this).GetComponent(25);

	public bool hasStagingAreaOffset => ((Entity)this).HasComponent(25);

	public StagingAreaSizeComponent stagingAreaSize => (StagingAreaSizeComponent)(object)((Entity)this).GetComponent(26);

	public bool hasStagingAreaSize => ((Entity)this).HasComponent(26);

	public StartFightingDistanceComponent startFightingDistance => (StartFightingDistanceComponent)(object)((Entity)this).GetComponent(27);

	public bool hasStartFightingDistance => ((Entity)this).HasComponent(27);

	public TheSpeedOfMarchingOnComponent theSpeedOfMarchingOn => (TheSpeedOfMarchingOnComponent)(object)((Entity)this).GetComponent(28);

	public bool hasTheSpeedOfMarchingOn => ((Entity)this).HasComponent(28);

	public UiSettingsComponent uiSettings => (UiSettingsComponent)(object)((Entity)this).GetComponent(29);

	public bool hasUiSettings => ((Entity)this).HasComponent(29);

	public UnitNumberComponent unitNumber => (UnitNumberComponent)(object)((Entity)this).GetComponent(30);

	public bool hasUnitNumber => ((Entity)this).HasComponent(30);

	public void AddAgentConfig(int newMaxNeighbors, float newNeighborDist, float newTimeHorizon, float newTimeHorizonObst)
	{
		int num = 0;
		AgentConfigComponent agentConfigComponent = (AgentConfigComponent)(object)((Entity)this).CreateComponent(num, typeof(AgentConfigComponent));
		agentConfigComponent.maxNeighbors = newMaxNeighbors;
		agentConfigComponent.neighborDist = newNeighborDist;
		agentConfigComponent.timeHorizon = newTimeHorizon;
		agentConfigComponent.timeHorizonObst = newTimeHorizonObst;
		((Entity)this).AddComponent(num, (IComponent)(object)agentConfigComponent);
	}

	public void ReplaceAgentConfig(int newMaxNeighbors, float newNeighborDist, float newTimeHorizon, float newTimeHorizonObst)
	{
		int num = 0;
		AgentConfigComponent agentConfigComponent = (AgentConfigComponent)(object)((Entity)this).CreateComponent(num, typeof(AgentConfigComponent));
		agentConfigComponent.maxNeighbors = newMaxNeighbors;
		agentConfigComponent.neighborDist = newNeighborDist;
		agentConfigComponent.timeHorizon = newTimeHorizon;
		agentConfigComponent.timeHorizonObst = newTimeHorizonObst;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)agentConfigComponent);
	}

	public void RemoveAgentConfig()
	{
		((Entity)this).RemoveComponent(0);
	}

	public void AddAnyBaseVisionRadiusListener(List<IAnyBaseVisionRadiusListener> newValue)
	{
		int num = 1;
		AnyBaseVisionRadiusListenerComponent anyBaseVisionRadiusListenerComponent = (AnyBaseVisionRadiusListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBaseVisionRadiusListenerComponent));
		anyBaseVisionRadiusListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBaseVisionRadiusListenerComponent);
	}

	public void ReplaceAnyBaseVisionRadiusListener(List<IAnyBaseVisionRadiusListener> newValue)
	{
		int num = 1;
		AnyBaseVisionRadiusListenerComponent anyBaseVisionRadiusListenerComponent = (AnyBaseVisionRadiusListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBaseVisionRadiusListenerComponent));
		anyBaseVisionRadiusListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBaseVisionRadiusListenerComponent);
	}

	public void RemoveAnyBaseVisionRadiusListener()
	{
		((Entity)this).RemoveComponent(1);
	}

	public void AddAnyBaseVisionRadiusListener(IAnyBaseVisionRadiusListener value)
	{
		List<IAnyBaseVisionRadiusListener> list = (hasAnyBaseVisionRadiusListener ? anyBaseVisionRadiusListener.value : new List<IAnyBaseVisionRadiusListener>());
		list.Add(value);
		ReplaceAnyBaseVisionRadiusListener(list);
	}

	public void RemoveAnyBaseVisionRadiusListener(IAnyBaseVisionRadiusListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBaseVisionRadiusListener> value2 = anyBaseVisionRadiusListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBaseVisionRadiusListener();
		}
		else
		{
			ReplaceAnyBaseVisionRadiusListener(value2);
		}
	}

	public void AddAnyBattleConfigListener(List<IAnyBattleConfigListener> newValue)
	{
		int num = 2;
		AnyBattleConfigListenerComponent anyBattleConfigListenerComponent = (AnyBattleConfigListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleConfigListenerComponent));
		anyBattleConfigListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBattleConfigListenerComponent);
	}

	public void ReplaceAnyBattleConfigListener(List<IAnyBattleConfigListener> newValue)
	{
		int num = 2;
		AnyBattleConfigListenerComponent anyBattleConfigListenerComponent = (AnyBattleConfigListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleConfigListenerComponent));
		anyBattleConfigListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBattleConfigListenerComponent);
	}

	public void RemoveAnyBattleConfigListener()
	{
		((Entity)this).RemoveComponent(2);
	}

	public void AddAnyBattleConfigListener(IAnyBattleConfigListener value)
	{
		List<IAnyBattleConfigListener> list = (hasAnyBattleConfigListener ? anyBattleConfigListener.value : new List<IAnyBattleConfigListener>());
		list.Add(value);
		ReplaceAnyBattleConfigListener(list);
	}

	public void RemoveAnyBattleConfigListener(IAnyBattleConfigListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBattleConfigListener> value2 = anyBattleConfigListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBattleConfigListener();
		}
		else
		{
			ReplaceAnyBattleConfigListener(value2);
		}
	}

	public void AddAnyBattleDebugSwitcherListener(List<IAnyBattleDebugSwitcherListener> newValue)
	{
		int num = 3;
		AnyBattleDebugSwitcherListenerComponent anyBattleDebugSwitcherListenerComponent = (AnyBattleDebugSwitcherListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleDebugSwitcherListenerComponent));
		anyBattleDebugSwitcherListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyBattleDebugSwitcherListenerComponent);
	}

	public void ReplaceAnyBattleDebugSwitcherListener(List<IAnyBattleDebugSwitcherListener> newValue)
	{
		int num = 3;
		AnyBattleDebugSwitcherListenerComponent anyBattleDebugSwitcherListenerComponent = (AnyBattleDebugSwitcherListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyBattleDebugSwitcherListenerComponent));
		anyBattleDebugSwitcherListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyBattleDebugSwitcherListenerComponent);
	}

	public void RemoveAnyBattleDebugSwitcherListener()
	{
		((Entity)this).RemoveComponent(3);
	}

	public void AddAnyBattleDebugSwitcherListener(IAnyBattleDebugSwitcherListener value)
	{
		List<IAnyBattleDebugSwitcherListener> list = (hasAnyBattleDebugSwitcherListener ? anyBattleDebugSwitcherListener.value : new List<IAnyBattleDebugSwitcherListener>());
		list.Add(value);
		ReplaceAnyBattleDebugSwitcherListener(list);
	}

	public void RemoveAnyBattleDebugSwitcherListener(IAnyBattleDebugSwitcherListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyBattleDebugSwitcherListener> value2 = anyBattleDebugSwitcherListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyBattleDebugSwitcherListener();
		}
		else
		{
			ReplaceAnyBattleDebugSwitcherListener(value2);
		}
	}

	public void AddAnyCurrentFormationListener(List<IAnyCurrentFormationListener> newValue)
	{
		int num = 4;
		AnyCurrentFormationListenerComponent anyCurrentFormationListenerComponent = (AnyCurrentFormationListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCurrentFormationListenerComponent));
		anyCurrentFormationListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyCurrentFormationListenerComponent);
	}

	public void ReplaceAnyCurrentFormationListener(List<IAnyCurrentFormationListener> newValue)
	{
		int num = 4;
		AnyCurrentFormationListenerComponent anyCurrentFormationListenerComponent = (AnyCurrentFormationListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyCurrentFormationListenerComponent));
		anyCurrentFormationListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyCurrentFormationListenerComponent);
	}

	public void RemoveAnyCurrentFormationListener()
	{
		((Entity)this).RemoveComponent(4);
	}

	public void AddAnyCurrentFormationListener(IAnyCurrentFormationListener value)
	{
		List<IAnyCurrentFormationListener> list = (hasAnyCurrentFormationListener ? anyCurrentFormationListener.value : new List<IAnyCurrentFormationListener>());
		list.Add(value);
		ReplaceAnyCurrentFormationListener(list);
	}

	public void RemoveAnyCurrentFormationListener(IAnyCurrentFormationListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyCurrentFormationListener> value2 = anyCurrentFormationListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyCurrentFormationListener();
		}
		else
		{
			ReplaceAnyCurrentFormationListener(value2);
		}
	}

	public void AddAnyFormationUnitsListener(List<IAnyFormationUnitsListener> newValue)
	{
		int num = 5;
		AnyFormationUnitsListenerComponent anyFormationUnitsListenerComponent = (AnyFormationUnitsListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyFormationUnitsListenerComponent));
		anyFormationUnitsListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyFormationUnitsListenerComponent);
	}

	public void ReplaceAnyFormationUnitsListener(List<IAnyFormationUnitsListener> newValue)
	{
		int num = 5;
		AnyFormationUnitsListenerComponent anyFormationUnitsListenerComponent = (AnyFormationUnitsListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyFormationUnitsListenerComponent));
		anyFormationUnitsListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyFormationUnitsListenerComponent);
	}

	public void RemoveAnyFormationUnitsListener()
	{
		((Entity)this).RemoveComponent(5);
	}

	public void AddAnyFormationUnitsListener(IAnyFormationUnitsListener value)
	{
		List<IAnyFormationUnitsListener> list = (hasAnyFormationUnitsListener ? anyFormationUnitsListener.value : new List<IAnyFormationUnitsListener>());
		list.Add(value);
		ReplaceAnyFormationUnitsListener(list);
	}

	public void RemoveAnyFormationUnitsListener(IAnyFormationUnitsListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyFormationUnitsListener> value2 = anyFormationUnitsListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyFormationUnitsListener();
		}
		else
		{
			ReplaceAnyFormationUnitsListener(value2);
		}
	}

	public void AddAnyHealBarSwitcherListener(List<IAnyHealBarSwitcherListener> newValue)
	{
		int num = 6;
		AnyHealBarSwitcherListenerComponent anyHealBarSwitcherListenerComponent = (AnyHealBarSwitcherListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyHealBarSwitcherListenerComponent));
		anyHealBarSwitcherListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyHealBarSwitcherListenerComponent);
	}

	public void ReplaceAnyHealBarSwitcherListener(List<IAnyHealBarSwitcherListener> newValue)
	{
		int num = 6;
		AnyHealBarSwitcherListenerComponent anyHealBarSwitcherListenerComponent = (AnyHealBarSwitcherListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyHealBarSwitcherListenerComponent));
		anyHealBarSwitcherListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyHealBarSwitcherListenerComponent);
	}

	public void RemoveAnyHealBarSwitcherListener()
	{
		((Entity)this).RemoveComponent(6);
	}

	public void AddAnyHealBarSwitcherListener(IAnyHealBarSwitcherListener value)
	{
		List<IAnyHealBarSwitcherListener> list = (hasAnyHealBarSwitcherListener ? anyHealBarSwitcherListener.value : new List<IAnyHealBarSwitcherListener>());
		list.Add(value);
		ReplaceAnyHealBarSwitcherListener(list);
	}

	public void RemoveAnyHealBarSwitcherListener(IAnyHealBarSwitcherListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyHealBarSwitcherListener> value2 = anyHealBarSwitcherListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyHealBarSwitcherListener();
		}
		else
		{
			ReplaceAnyHealBarSwitcherListener(value2);
		}
	}

	public void AddAnyLoadViewFromResourcesListener(List<IAnyLoadViewFromResourcesListener> newValue)
	{
		int num = 7;
		AnyLoadViewFromResourcesListenerComponent anyLoadViewFromResourcesListenerComponent = (AnyLoadViewFromResourcesListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoadViewFromResourcesListenerComponent));
		anyLoadViewFromResourcesListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyLoadViewFromResourcesListenerComponent);
	}

	public void ReplaceAnyLoadViewFromResourcesListener(List<IAnyLoadViewFromResourcesListener> newValue)
	{
		int num = 7;
		AnyLoadViewFromResourcesListenerComponent anyLoadViewFromResourcesListenerComponent = (AnyLoadViewFromResourcesListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoadViewFromResourcesListenerComponent));
		anyLoadViewFromResourcesListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyLoadViewFromResourcesListenerComponent);
	}

	public void RemoveAnyLoadViewFromResourcesListener()
	{
		((Entity)this).RemoveComponent(7);
	}

	public void AddAnyLoadViewFromResourcesListener(IAnyLoadViewFromResourcesListener value)
	{
		List<IAnyLoadViewFromResourcesListener> list = (hasAnyLoadViewFromResourcesListener ? anyLoadViewFromResourcesListener.value : new List<IAnyLoadViewFromResourcesListener>());
		list.Add(value);
		ReplaceAnyLoadViewFromResourcesListener(list);
	}

	public void RemoveAnyLoadViewFromResourcesListener(IAnyLoadViewFromResourcesListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyLoadViewFromResourcesListener> value2 = anyLoadViewFromResourcesListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyLoadViewFromResourcesListener();
		}
		else
		{
			ReplaceAnyLoadViewFromResourcesListener(value2);
		}
	}

	public void AddAnyLoadViewFromResourcesRemovedListener(List<IAnyLoadViewFromResourcesRemovedListener> newValue)
	{
		int num = 8;
		AnyLoadViewFromResourcesRemovedListenerComponent anyLoadViewFromResourcesRemovedListenerComponent = (AnyLoadViewFromResourcesRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoadViewFromResourcesRemovedListenerComponent));
		anyLoadViewFromResourcesRemovedListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyLoadViewFromResourcesRemovedListenerComponent);
	}

	public void ReplaceAnyLoadViewFromResourcesRemovedListener(List<IAnyLoadViewFromResourcesRemovedListener> newValue)
	{
		int num = 8;
		AnyLoadViewFromResourcesRemovedListenerComponent anyLoadViewFromResourcesRemovedListenerComponent = (AnyLoadViewFromResourcesRemovedListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyLoadViewFromResourcesRemovedListenerComponent));
		anyLoadViewFromResourcesRemovedListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyLoadViewFromResourcesRemovedListenerComponent);
	}

	public void RemoveAnyLoadViewFromResourcesRemovedListener()
	{
		((Entity)this).RemoveComponent(8);
	}

	public void AddAnyLoadViewFromResourcesRemovedListener(IAnyLoadViewFromResourcesRemovedListener value)
	{
		List<IAnyLoadViewFromResourcesRemovedListener> list = (hasAnyLoadViewFromResourcesRemovedListener ? anyLoadViewFromResourcesRemovedListener.value : new List<IAnyLoadViewFromResourcesRemovedListener>());
		list.Add(value);
		ReplaceAnyLoadViewFromResourcesRemovedListener(list);
	}

	public void RemoveAnyLoadViewFromResourcesRemovedListener(IAnyLoadViewFromResourcesRemovedListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyLoadViewFromResourcesRemovedListener> value2 = anyLoadViewFromResourcesRemovedListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyLoadViewFromResourcesRemovedListener();
		}
		else
		{
			ReplaceAnyLoadViewFromResourcesRemovedListener(value2);
		}
	}

	public void AddAnyStagingAreaOffsetListener(List<IAnyStagingAreaOffsetListener> newValue)
	{
		int num = 9;
		AnyStagingAreaOffsetListenerComponent anyStagingAreaOffsetListenerComponent = (AnyStagingAreaOffsetListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyStagingAreaOffsetListenerComponent));
		anyStagingAreaOffsetListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyStagingAreaOffsetListenerComponent);
	}

	public void ReplaceAnyStagingAreaOffsetListener(List<IAnyStagingAreaOffsetListener> newValue)
	{
		int num = 9;
		AnyStagingAreaOffsetListenerComponent anyStagingAreaOffsetListenerComponent = (AnyStagingAreaOffsetListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyStagingAreaOffsetListenerComponent));
		anyStagingAreaOffsetListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyStagingAreaOffsetListenerComponent);
	}

	public void RemoveAnyStagingAreaOffsetListener()
	{
		((Entity)this).RemoveComponent(9);
	}

	public void AddAnyStagingAreaOffsetListener(IAnyStagingAreaOffsetListener value)
	{
		List<IAnyStagingAreaOffsetListener> list = (hasAnyStagingAreaOffsetListener ? anyStagingAreaOffsetListener.value : new List<IAnyStagingAreaOffsetListener>());
		list.Add(value);
		ReplaceAnyStagingAreaOffsetListener(list);
	}

	public void RemoveAnyStagingAreaOffsetListener(IAnyStagingAreaOffsetListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyStagingAreaOffsetListener> value2 = anyStagingAreaOffsetListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyStagingAreaOffsetListener();
		}
		else
		{
			ReplaceAnyStagingAreaOffsetListener(value2);
		}
	}

	public void AddAnyStagingAreaSizeListener(List<IAnyStagingAreaSizeListener> newValue)
	{
		int num = 10;
		AnyStagingAreaSizeListenerComponent anyStagingAreaSizeListenerComponent = (AnyStagingAreaSizeListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyStagingAreaSizeListenerComponent));
		anyStagingAreaSizeListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyStagingAreaSizeListenerComponent);
	}

	public void ReplaceAnyStagingAreaSizeListener(List<IAnyStagingAreaSizeListener> newValue)
	{
		int num = 10;
		AnyStagingAreaSizeListenerComponent anyStagingAreaSizeListenerComponent = (AnyStagingAreaSizeListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyStagingAreaSizeListenerComponent));
		anyStagingAreaSizeListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyStagingAreaSizeListenerComponent);
	}

	public void RemoveAnyStagingAreaSizeListener()
	{
		((Entity)this).RemoveComponent(10);
	}

	public void AddAnyStagingAreaSizeListener(IAnyStagingAreaSizeListener value)
	{
		List<IAnyStagingAreaSizeListener> list = (hasAnyStagingAreaSizeListener ? anyStagingAreaSizeListener.value : new List<IAnyStagingAreaSizeListener>());
		list.Add(value);
		ReplaceAnyStagingAreaSizeListener(list);
	}

	public void RemoveAnyStagingAreaSizeListener(IAnyStagingAreaSizeListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyStagingAreaSizeListener> value2 = anyStagingAreaSizeListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyStagingAreaSizeListener();
		}
		else
		{
			ReplaceAnyStagingAreaSizeListener(value2);
		}
	}

	public void AddAnyStartFightingDistanceListener(List<IAnyStartFightingDistanceListener> newValue)
	{
		int num = 11;
		AnyStartFightingDistanceListenerComponent anyStartFightingDistanceListenerComponent = (AnyStartFightingDistanceListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyStartFightingDistanceListenerComponent));
		anyStartFightingDistanceListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyStartFightingDistanceListenerComponent);
	}

	public void ReplaceAnyStartFightingDistanceListener(List<IAnyStartFightingDistanceListener> newValue)
	{
		int num = 11;
		AnyStartFightingDistanceListenerComponent anyStartFightingDistanceListenerComponent = (AnyStartFightingDistanceListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyStartFightingDistanceListenerComponent));
		anyStartFightingDistanceListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyStartFightingDistanceListenerComponent);
	}

	public void RemoveAnyStartFightingDistanceListener()
	{
		((Entity)this).RemoveComponent(11);
	}

	public void AddAnyStartFightingDistanceListener(IAnyStartFightingDistanceListener value)
	{
		List<IAnyStartFightingDistanceListener> list = (hasAnyStartFightingDistanceListener ? anyStartFightingDistanceListener.value : new List<IAnyStartFightingDistanceListener>());
		list.Add(value);
		ReplaceAnyStartFightingDistanceListener(list);
	}

	public void RemoveAnyStartFightingDistanceListener(IAnyStartFightingDistanceListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyStartFightingDistanceListener> value2 = anyStartFightingDistanceListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyStartFightingDistanceListener();
		}
		else
		{
			ReplaceAnyStartFightingDistanceListener(value2);
		}
	}

	public void AddAnyTheSpeedOfMarchingOnListener(List<IAnyTheSpeedOfMarchingOnListener> newValue)
	{
		int num = 12;
		AnyTheSpeedOfMarchingOnListenerComponent anyTheSpeedOfMarchingOnListenerComponent = (AnyTheSpeedOfMarchingOnListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyTheSpeedOfMarchingOnListenerComponent));
		anyTheSpeedOfMarchingOnListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyTheSpeedOfMarchingOnListenerComponent);
	}

	public void ReplaceAnyTheSpeedOfMarchingOnListener(List<IAnyTheSpeedOfMarchingOnListener> newValue)
	{
		int num = 12;
		AnyTheSpeedOfMarchingOnListenerComponent anyTheSpeedOfMarchingOnListenerComponent = (AnyTheSpeedOfMarchingOnListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyTheSpeedOfMarchingOnListenerComponent));
		anyTheSpeedOfMarchingOnListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyTheSpeedOfMarchingOnListenerComponent);
	}

	public void RemoveAnyTheSpeedOfMarchingOnListener()
	{
		((Entity)this).RemoveComponent(12);
	}

	public void AddAnyTheSpeedOfMarchingOnListener(IAnyTheSpeedOfMarchingOnListener value)
	{
		List<IAnyTheSpeedOfMarchingOnListener> list = (hasAnyTheSpeedOfMarchingOnListener ? anyTheSpeedOfMarchingOnListener.value : new List<IAnyTheSpeedOfMarchingOnListener>());
		list.Add(value);
		ReplaceAnyTheSpeedOfMarchingOnListener(list);
	}

	public void RemoveAnyTheSpeedOfMarchingOnListener(IAnyTheSpeedOfMarchingOnListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyTheSpeedOfMarchingOnListener> value2 = anyTheSpeedOfMarchingOnListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyTheSpeedOfMarchingOnListener();
		}
		else
		{
			ReplaceAnyTheSpeedOfMarchingOnListener(value2);
		}
	}

	public void AddAnyUnitNumberListener(List<IAnyUnitNumberListener> newValue)
	{
		int num = 13;
		AnyUnitNumberListenerComponent anyUnitNumberListenerComponent = (AnyUnitNumberListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyUnitNumberListenerComponent));
		anyUnitNumberListenerComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)anyUnitNumberListenerComponent);
	}

	public void ReplaceAnyUnitNumberListener(List<IAnyUnitNumberListener> newValue)
	{
		int num = 13;
		AnyUnitNumberListenerComponent anyUnitNumberListenerComponent = (AnyUnitNumberListenerComponent)(object)((Entity)this).CreateComponent(num, typeof(AnyUnitNumberListenerComponent));
		anyUnitNumberListenerComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)anyUnitNumberListenerComponent);
	}

	public void RemoveAnyUnitNumberListener()
	{
		((Entity)this).RemoveComponent(13);
	}

	public void AddAnyUnitNumberListener(IAnyUnitNumberListener value)
	{
		List<IAnyUnitNumberListener> list = (hasAnyUnitNumberListener ? anyUnitNumberListener.value : new List<IAnyUnitNumberListener>());
		list.Add(value);
		ReplaceAnyUnitNumberListener(list);
	}

	public void RemoveAnyUnitNumberListener(IAnyUnitNumberListener value, bool removeComponentWhenEmpty = true)
	{
		List<IAnyUnitNumberListener> value2 = anyUnitNumberListener.value;
		value2.Remove(value);
		if (removeComponentWhenEmpty && value2.Count == 0)
		{
			RemoveAnyUnitNumberListener();
		}
		else
		{
			ReplaceAnyUnitNumberListener(value2);
		}
	}

	public void AddBaseVisionRadius(int newValue)
	{
		int num = 14;
		BaseVisionRadiusComponent baseVisionRadiusComponent = (BaseVisionRadiusComponent)(object)((Entity)this).CreateComponent(num, typeof(BaseVisionRadiusComponent));
		baseVisionRadiusComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)baseVisionRadiusComponent);
	}

	public void ReplaceBaseVisionRadius(int newValue)
	{
		int num = 14;
		BaseVisionRadiusComponent baseVisionRadiusComponent = (BaseVisionRadiusComponent)(object)((Entity)this).CreateComponent(num, typeof(BaseVisionRadiusComponent));
		baseVisionRadiusComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)baseVisionRadiusComponent);
	}

	public void RemoveBaseVisionRadius()
	{
		((Entity)this).RemoveComponent(14);
	}

	public void AddBattleConfig(BattleConfig newRed, BattleConfig newBlue, float newBattleFieldLength)
	{
		int num = 15;
		BattleConfigComponent battleConfigComponent = (BattleConfigComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleConfigComponent));
		battleConfigComponent.Red = newRed;
		battleConfigComponent.Blue = newBlue;
		battleConfigComponent.BattleFieldLength = newBattleFieldLength;
		((Entity)this).AddComponent(num, (IComponent)(object)battleConfigComponent);
	}

	public void ReplaceBattleConfig(BattleConfig newRed, BattleConfig newBlue, float newBattleFieldLength)
	{
		int num = 15;
		BattleConfigComponent battleConfigComponent = (BattleConfigComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleConfigComponent));
		battleConfigComponent.Red = newRed;
		battleConfigComponent.Blue = newBlue;
		battleConfigComponent.BattleFieldLength = newBattleFieldLength;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleConfigComponent);
	}

	public void RemoveBattleConfig()
	{
		((Entity)this).RemoveComponent(15);
	}

	public void AddBattleDebugSwitcher(bool newValue)
	{
		int num = 16;
		BattleDebugSwitcherComponent battleDebugSwitcherComponent = (BattleDebugSwitcherComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleDebugSwitcherComponent));
		battleDebugSwitcherComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)battleDebugSwitcherComponent);
	}

	public void ReplaceBattleDebugSwitcher(bool newValue)
	{
		int num = 16;
		BattleDebugSwitcherComponent battleDebugSwitcherComponent = (BattleDebugSwitcherComponent)(object)((Entity)this).CreateComponent(num, typeof(BattleDebugSwitcherComponent));
		battleDebugSwitcherComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)battleDebugSwitcherComponent);
	}

	public void RemoveBattleDebugSwitcher()
	{
		((Entity)this).RemoveComponent(16);
	}

	public void AddCurrentFormation(Dictionary<string, Dictionary<string, string>> newValue)
	{
		int num = 17;
		CurrentFormationComponent currentFormationComponent = (CurrentFormationComponent)(object)((Entity)this).CreateComponent(num, typeof(CurrentFormationComponent));
		currentFormationComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)currentFormationComponent);
	}

	public void ReplaceCurrentFormation(Dictionary<string, Dictionary<string, string>> newValue)
	{
		int num = 17;
		CurrentFormationComponent currentFormationComponent = (CurrentFormationComponent)(object)((Entity)this).CreateComponent(num, typeof(CurrentFormationComponent));
		currentFormationComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)currentFormationComponent);
	}

	public void RemoveCurrentFormation()
	{
		((Entity)this).RemoveComponent(17);
	}

	public void AddDefenceModeMeleeVisionRadius(float newValue)
	{
		int num = 18;
		DefenceModeMeleeVisionRadiusComponent defenceModeMeleeVisionRadiusComponent = (DefenceModeMeleeVisionRadiusComponent)(object)((Entity)this).CreateComponent(num, typeof(DefenceModeMeleeVisionRadiusComponent));
		defenceModeMeleeVisionRadiusComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)defenceModeMeleeVisionRadiusComponent);
	}

	public void ReplaceDefenceModeMeleeVisionRadius(float newValue)
	{
		int num = 18;
		DefenceModeMeleeVisionRadiusComponent defenceModeMeleeVisionRadiusComponent = (DefenceModeMeleeVisionRadiusComponent)(object)((Entity)this).CreateComponent(num, typeof(DefenceModeMeleeVisionRadiusComponent));
		defenceModeMeleeVisionRadiusComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)defenceModeMeleeVisionRadiusComponent);
	}

	public void RemoveDefenceModeMeleeVisionRadius()
	{
		((Entity)this).RemoveComponent(18);
	}

	public void AddDefenceModeRangedVisionRadius(float newValue)
	{
		int num = 19;
		DefenceModeRangedVisionRadiusComponent defenceModeRangedVisionRadiusComponent = (DefenceModeRangedVisionRadiusComponent)(object)((Entity)this).CreateComponent(num, typeof(DefenceModeRangedVisionRadiusComponent));
		defenceModeRangedVisionRadiusComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)defenceModeRangedVisionRadiusComponent);
	}

	public void ReplaceDefenceModeRangedVisionRadius(float newValue)
	{
		int num = 19;
		DefenceModeRangedVisionRadiusComponent defenceModeRangedVisionRadiusComponent = (DefenceModeRangedVisionRadiusComponent)(object)((Entity)this).CreateComponent(num, typeof(DefenceModeRangedVisionRadiusComponent));
		defenceModeRangedVisionRadiusComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)defenceModeRangedVisionRadiusComponent);
	}

	public void RemoveDefenceModeRangedVisionRadius()
	{
		((Entity)this).RemoveComponent(19);
	}

	public void AddFormationUnits(Dictionary<string, Dictionary<string, List<string>>> newValue)
	{
		int num = 20;
		FormationUnitsComponent formationUnitsComponent = (FormationUnitsComponent)(object)((Entity)this).CreateComponent(num, typeof(FormationUnitsComponent));
		formationUnitsComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)formationUnitsComponent);
	}

	public void ReplaceFormationUnits(Dictionary<string, Dictionary<string, List<string>>> newValue)
	{
		int num = 20;
		FormationUnitsComponent formationUnitsComponent = (FormationUnitsComponent)(object)((Entity)this).CreateComponent(num, typeof(FormationUnitsComponent));
		formationUnitsComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)formationUnitsComponent);
	}

	public void RemoveFormationUnits()
	{
		((Entity)this).RemoveComponent(20);
	}

	public void AddHealBarSwitcher(bool newValue)
	{
		int num = 21;
		HealBarSwitcherComponent healBarSwitcherComponent = (HealBarSwitcherComponent)(object)((Entity)this).CreateComponent(num, typeof(HealBarSwitcherComponent));
		healBarSwitcherComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)healBarSwitcherComponent);
	}

	public void ReplaceHealBarSwitcher(bool newValue)
	{
		int num = 21;
		HealBarSwitcherComponent healBarSwitcherComponent = (HealBarSwitcherComponent)(object)((Entity)this).CreateComponent(num, typeof(HealBarSwitcherComponent));
		healBarSwitcherComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)healBarSwitcherComponent);
	}

	public void RemoveHealBarSwitcher()
	{
		((Entity)this).RemoveComponent(21);
	}

	public void AddRvoTimeStep(float newValue)
	{
		int num = 23;
		RvoTimeStepComponent rvoTimeStepComponent = (RvoTimeStepComponent)(object)((Entity)this).CreateComponent(num, typeof(RvoTimeStepComponent));
		rvoTimeStepComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)rvoTimeStepComponent);
	}

	public void ReplaceRvoTimeStep(float newValue)
	{
		int num = 23;
		RvoTimeStepComponent rvoTimeStepComponent = (RvoTimeStepComponent)(object)((Entity)this).CreateComponent(num, typeof(RvoTimeStepComponent));
		rvoTimeStepComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)rvoTimeStepComponent);
	}

	public void RemoveRvoTimeStep()
	{
		((Entity)this).RemoveComponent(23);
	}

	public void AddStagingAreaOffset(float newValue)
	{
		int num = 25;
		StagingAreaOffsetComponent stagingAreaOffsetComponent = (StagingAreaOffsetComponent)(object)((Entity)this).CreateComponent(num, typeof(StagingAreaOffsetComponent));
		stagingAreaOffsetComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)stagingAreaOffsetComponent);
	}

	public void ReplaceStagingAreaOffset(float newValue)
	{
		int num = 25;
		StagingAreaOffsetComponent stagingAreaOffsetComponent = (StagingAreaOffsetComponent)(object)((Entity)this).CreateComponent(num, typeof(StagingAreaOffsetComponent));
		stagingAreaOffsetComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)stagingAreaOffsetComponent);
	}

	public void RemoveStagingAreaOffset()
	{
		((Entity)this).RemoveComponent(25);
	}

	public void AddStagingAreaSize(Vector2 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 26;
		StagingAreaSizeComponent stagingAreaSizeComponent = (StagingAreaSizeComponent)(object)((Entity)this).CreateComponent(num, typeof(StagingAreaSizeComponent));
		stagingAreaSizeComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)stagingAreaSizeComponent);
	}

	public void ReplaceStagingAreaSize(Vector2 newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		int num = 26;
		StagingAreaSizeComponent stagingAreaSizeComponent = (StagingAreaSizeComponent)(object)((Entity)this).CreateComponent(num, typeof(StagingAreaSizeComponent));
		stagingAreaSizeComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)stagingAreaSizeComponent);
	}

	public void RemoveStagingAreaSize()
	{
		((Entity)this).RemoveComponent(26);
	}

	public void AddStartFightingDistance(int newValue)
	{
		int num = 27;
		StartFightingDistanceComponent startFightingDistanceComponent = (StartFightingDistanceComponent)(object)((Entity)this).CreateComponent(num, typeof(StartFightingDistanceComponent));
		startFightingDistanceComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)startFightingDistanceComponent);
	}

	public void ReplaceStartFightingDistance(int newValue)
	{
		int num = 27;
		StartFightingDistanceComponent startFightingDistanceComponent = (StartFightingDistanceComponent)(object)((Entity)this).CreateComponent(num, typeof(StartFightingDistanceComponent));
		startFightingDistanceComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)startFightingDistanceComponent);
	}

	public void RemoveStartFightingDistance()
	{
		((Entity)this).RemoveComponent(27);
	}

	public void AddTheSpeedOfMarchingOn(float newValue)
	{
		int num = 28;
		TheSpeedOfMarchingOnComponent theSpeedOfMarchingOnComponent = (TheSpeedOfMarchingOnComponent)(object)((Entity)this).CreateComponent(num, typeof(TheSpeedOfMarchingOnComponent));
		theSpeedOfMarchingOnComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)theSpeedOfMarchingOnComponent);
	}

	public void ReplaceTheSpeedOfMarchingOn(float newValue)
	{
		int num = 28;
		TheSpeedOfMarchingOnComponent theSpeedOfMarchingOnComponent = (TheSpeedOfMarchingOnComponent)(object)((Entity)this).CreateComponent(num, typeof(TheSpeedOfMarchingOnComponent));
		theSpeedOfMarchingOnComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)theSpeedOfMarchingOnComponent);
	}

	public void RemoveTheSpeedOfMarchingOn()
	{
		((Entity)this).RemoveComponent(28);
	}

	public void AddUiSettings(Dictionary<string, UiSetting> newValue)
	{
		int num = 29;
		UiSettingsComponent uiSettingsComponent = (UiSettingsComponent)(object)((Entity)this).CreateComponent(num, typeof(UiSettingsComponent));
		uiSettingsComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)uiSettingsComponent);
	}

	public void ReplaceUiSettings(Dictionary<string, UiSetting> newValue)
	{
		int num = 29;
		UiSettingsComponent uiSettingsComponent = (UiSettingsComponent)(object)((Entity)this).CreateComponent(num, typeof(UiSettingsComponent));
		uiSettingsComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)uiSettingsComponent);
	}

	public void RemoveUiSettings()
	{
		((Entity)this).RemoveComponent(29);
	}

	public void AddUnitNumber(int newValue)
	{
		int num = 30;
		UnitNumberComponent unitNumberComponent = (UnitNumberComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitNumberComponent));
		unitNumberComponent.value = newValue;
		((Entity)this).AddComponent(num, (IComponent)(object)unitNumberComponent);
	}

	public void ReplaceUnitNumber(int newValue)
	{
		int num = 30;
		UnitNumberComponent unitNumberComponent = (UnitNumberComponent)(object)((Entity)this).CreateComponent(num, typeof(UnitNumberComponent));
		unitNumberComponent.value = newValue;
		((Entity)this).ReplaceComponent(num, (IComponent)(object)unitNumberComponent);
	}

	public void RemoveUnitNumber()
	{
		((Entity)this).RemoveComponent(30);
	}
}
