using System.Collections.Generic;
using Entitas;

public sealed class AlphaEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IAlphaListener> _listenerBuffer;

	public AlphaEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IAlphaListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.Alpha) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasAlpha && entity.hasAlphaListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			AlphaComponent alpha = entity.alpha;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.alphaListener.value);
			foreach (IAlphaListener item in _listenerBuffer)
			{
				item.OnAlpha(entity, alpha.value, alpha.duration);
			}
		}
	}
}
