using System.Collections.Generic;
using Entitas;

public sealed class AnyBattleDebugSwitcherEventSystem : ReactiveSystem<ConfigEntity>
{
	private readonly IGroup<ConfigEntity> _listeners;

	private readonly List<ConfigEntity> _entityBuffer;

	private readonly List<IAnyBattleDebugSwitcherListener> _listenerBuffer;

	public AnyBattleDebugSwitcherEventSystem(Contexts contexts)
		: base((IContext<ConfigEntity>)(object)contexts.config)
	{
		base.init((IContext<ConfigEntity>)(object)contexts.config);
		_listeners = ((Context<ConfigEntity>)contexts.config).GetGroup(ConfigMatcher.AnyBattleDebugSwitcherListener);
		_entityBuffer = new List<ConfigEntity>();
		_listenerBuffer = new List<IAnyBattleDebugSwitcherListener>();
	}

	protected override ICollector<ConfigEntity> GetTrigger(IContext<ConfigEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<ConfigEntity>(context, new TriggerOnEvent<ConfigEntity>[1] { TriggerOnEventMatcherExtension.Added<ConfigEntity>(ConfigMatcher.BattleDebugSwitcher) });
	}

	protected override bool Filter(ConfigEntity entity)
	{
		return entity.hasBattleDebugSwitcher;
	}

	protected override void Execute(List<ConfigEntity> entities)
	{
		foreach (ConfigEntity entity in entities)
		{
			BattleDebugSwitcherComponent battleDebugSwitcher = entity.battleDebugSwitcher;
			foreach (ConfigEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyBattleDebugSwitcherListener.value);
				foreach (IAnyBattleDebugSwitcherListener item in _listenerBuffer)
				{
					item.OnAnyBattleDebugSwitcher(entity, battleDebugSwitcher.value);
				}
			}
		}
	}
}
