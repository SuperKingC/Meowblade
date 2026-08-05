using System.Collections.Generic;
using Entitas;

public sealed class ShowCastingBarRemovedEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IShowCastingBarRemovedListener> _listenerBuffer;

	public ShowCastingBarRemovedEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IShowCastingBarRemovedListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Removed<GameEntity>(GameMatcher.ShowCastingBar) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return !entity.isShowCastingBar && entity.hasShowCastingBarRemovedListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.showCastingBarRemovedListener.value);
			foreach (IShowCastingBarRemovedListener item in _listenerBuffer)
			{
				item.OnShowCastingBarRemoved(entity);
			}
		}
	}
}
