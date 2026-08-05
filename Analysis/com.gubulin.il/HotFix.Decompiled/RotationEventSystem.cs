using System.Collections.Generic;
using Entitas;

public sealed class RotationEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IRotationListener> _listenerBuffer;

	public RotationEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IRotationListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.Rotation) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasRotation && entity.hasRotationListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		foreach (GameEntity entity in entities)
		{
			RotationComponent rotation = entity.rotation;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.rotationListener.value);
			foreach (IRotationListener item in _listenerBuffer)
			{
				item.OnRotation(entity, rotation.value);
			}
		}
	}
}
