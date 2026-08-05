using System.Collections.Generic;
using Entitas;

public sealed class AnyBattleFieldEventSystem : ReactiveSystem<GameEntity>
{
	private readonly IGroup<GameEntity> _listeners;

	private readonly List<GameEntity> _entityBuffer;

	private readonly List<IAnyBattleFieldListener> _listenerBuffer;

	public AnyBattleFieldEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listeners = ((Context<GameEntity>)contexts.game).GetGroup(GameMatcher.AnyBattleFieldListener);
		_entityBuffer = new List<GameEntity>();
		_listenerBuffer = new List<IAnyBattleFieldListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.BattleField) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasBattleField;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			BattleFieldComponent battleField = entity.battleField;
			foreach (GameEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyBattleFieldListener.value);
				foreach (IAnyBattleFieldListener item in _listenerBuffer)
				{
					item.OnAnyBattleField(entity, battleField.value);
				}
			}
		}
	}
}
