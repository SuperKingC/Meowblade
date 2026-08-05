using System.Collections.Generic;
using Entitas;

public sealed class CollisionRadiusEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<ICollisionRadiusListener> _listenerBuffer;

	public CollisionRadiusEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<ICollisionRadiusListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.CollisionRadius) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasCollisionRadius && entity.hasCollisionRadiusListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			CollisionRadiusComponent collisionRadius = entity.collisionRadius;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.collisionRadiusListener.value);
			foreach (ICollisionRadiusListener item in _listenerBuffer)
			{
				item.OnCollisionRadius(entity, collisionRadius.value);
			}
		}
	}
}
