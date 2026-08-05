using System.Collections.Generic;
using Entitas;

public sealed class ShowCastingBarEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IShowCastingBarListener> _listenerBuffer;

	public ShowCastingBarEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IShowCastingBarListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.ShowCastingBar) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isShowCastingBar && entity.hasShowCastingBarListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.showCastingBarListener.value);
			foreach (IShowCastingBarListener item in _listenerBuffer)
			{
				item.OnShowCastingBar(entity);
			}
		}
	}
}
