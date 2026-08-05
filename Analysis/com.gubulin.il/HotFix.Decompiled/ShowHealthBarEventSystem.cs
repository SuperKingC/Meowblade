using System.Collections.Generic;
using Entitas;

public sealed class ShowHealthBarEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IShowHealthBarListener> _listenerBuffer;

	public ShowHealthBarEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IShowHealthBarListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.ShowHealthBar) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isShowHealthBar && entity.hasShowHealthBarListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.showHealthBarListener.value);
			foreach (IShowHealthBarListener item in _listenerBuffer)
			{
				item.OnShowHealthBar(entity);
			}
		}
	}
}
