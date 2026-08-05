using System.Collections.Generic;
using Entitas;

public sealed class ShowGizmosEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IShowGizmosListener> _listenerBuffer;

	public ShowGizmosEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IShowGizmosListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.ShowGizmos) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasShowGizmos && entity.hasShowGizmosListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			ShowGizmosComponent showGizmos = entity.showGizmos;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.showGizmosListener.value);
			foreach (IShowGizmosListener item in _listenerBuffer)
			{
				item.OnShowGizmos(entity, showGizmos.value);
			}
		}
	}
}
