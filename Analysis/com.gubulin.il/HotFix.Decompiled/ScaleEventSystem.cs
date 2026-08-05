using System.Collections.Generic;
using Entitas;

public sealed class ScaleEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IScaleListener> _listenerBuffer;

	public ScaleEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IScaleListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.Scale) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasScale && entity.hasScaleListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			ScaleComponent scale = entity.scale;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.scaleListener.value);
			foreach (IScaleListener item in _listenerBuffer)
			{
				item.OnScale(entity, scale.value);
			}
		}
	}
}
