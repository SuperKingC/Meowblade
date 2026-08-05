using System.Collections.Generic;
using Entitas;

public sealed class AnyBattleConfigEventSystem : ReactiveSystem<ConfigEntity>
{
	private readonly IGroup<ConfigEntity> _listeners;

	private readonly List<ConfigEntity> _entityBuffer;

	private readonly List<IAnyBattleConfigListener> _listenerBuffer;

	public AnyBattleConfigEventSystem(Contexts contexts)
		: base((IContext<ConfigEntity>)(object)contexts.config)
	{
		base.init((IContext<ConfigEntity>)(object)contexts.config);
		_listeners = ((Context<ConfigEntity>)contexts.config).GetGroup(ConfigMatcher.AnyBattleConfigListener);
		_entityBuffer = new List<ConfigEntity>();
		_listenerBuffer = new List<IAnyBattleConfigListener>();
	}

	protected override ICollector<ConfigEntity> GetTrigger(IContext<ConfigEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<ConfigEntity>(context, new TriggerOnEvent<ConfigEntity>[1] { TriggerOnEventMatcherExtension.Added<ConfigEntity>(ConfigMatcher.BattleConfig) });
	}

	protected override bool Filter(ConfigEntity entity)
	{
		return entity.hasBattleConfig;
	}

	protected override void Execute(List<ConfigEntity> entities)
	{
		foreach (ConfigEntity entity in entities)
		{
			BattleConfigComponent battleConfig = entity.battleConfig;
			foreach (ConfigEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyBattleConfigListener.value);
				foreach (IAnyBattleConfigListener item in _listenerBuffer)
				{
					item.OnAnyBattleConfig(entity, battleConfig.Red, battleConfig.Blue, battleConfig.BattleFieldLength);
				}
			}
		}
	}
}
