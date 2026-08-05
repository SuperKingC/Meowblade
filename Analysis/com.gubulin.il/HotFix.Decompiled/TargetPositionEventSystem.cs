using System.Collections.Generic;
using Entitas;

public sealed class TargetPositionEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<ITargetPositionListener> _listenerBuffer;

	public TargetPositionEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<ITargetPositionListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.TargetPosition) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasTargetPosition && entity.hasTargetPositionListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		foreach (GameEntity entity in entities)
		{
			TargetPositionComponent targetPosition = entity.targetPosition;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.targetPositionListener.value);
			foreach (ITargetPositionListener item in _listenerBuffer)
			{
				item.OnTargetPosition(entity, targetPosition.value);
			}
		}
	}
}
