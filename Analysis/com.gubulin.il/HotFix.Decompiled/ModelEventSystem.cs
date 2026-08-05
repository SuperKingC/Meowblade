using System.Collections.Generic;
using Entitas;

public sealed class ModelEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IModelListener> _listenerBuffer;

	public ModelEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IModelListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.Model) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasModel && entity.hasModelListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			ModelComponent model = entity.model;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.modelListener.value);
			foreach (IModelListener item in _listenerBuffer)
			{
				item.OnModel(entity, model.value);
			}
		}
	}
}
