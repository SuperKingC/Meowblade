using System.Collections.Generic;
using Entitas;

public class HealthBarToggleSystem : ReactiveSystem<ConfigEntity>
{
	private readonly Contexts _contexts;

	private readonly IGroup<GameEntity> _group;

	private readonly List<GameEntity> _buffer;

	public HealthBarToggleSystem(Contexts contexts)
		: base((IContext<ConfigEntity>)(object)contexts.config)
	{
		base.init((IContext<ConfigEntity>)(object)contexts.config);
		_contexts = contexts;
		_group = ((Context<GameEntity>)contexts.game).GetGroup((IMatcher<GameEntity>)(object)GameMatcher.AllOf(GameMatcher.Character, GameMatcher.UnitStats));
		_buffer = new List<GameEntity>();
	}

	protected override ICollector<ConfigEntity> GetTrigger(IContext<ConfigEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<ConfigEntity>(context, new TriggerOnEvent<ConfigEntity>[1] { TriggerOnEventMatcherExtension.Added<ConfigEntity>(ConfigMatcher.HealBarSwitcher) });
	}

	protected override bool Filter(ConfigEntity entity)
	{
		return true;
	}

	protected override void Execute(List<ConfigEntity> entities)
	{
		bool value = _contexts.config.healBarSwitcher.value;
		_group.GetEntities(_buffer);
		foreach (GameEntity item in _buffer)
		{
			UnitStats value2 = item.unitStats.value;
			if (value2.CurrentHealth != value2.MaxHealthPoints)
			{
				item.isShowHealthBar = value;
			}
			else
			{
				item.isShowHealthBar = false;
			}
		}
	}
}
