using System.Collections.Generic;
using Entitas;

public sealed class ShadowScaleEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IShadowScaleListener> _listenerBuffer;

	public ShadowScaleEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IShadowScaleListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.ShadowScale) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasShadowScale && entity.hasShadowScaleListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			ShadowScaleComponent shadowScale = entity.shadowScale;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.shadowScaleListener.value);
			foreach (IShadowScaleListener item in _listenerBuffer)
			{
				item.OnShadowScale(entity, shadowScale.value);
			}
		}
	}
}
