using System.Collections.Generic;
using Entitas;

public sealed class AnyAssetEventSystem : ReactiveSystem<GameEntity>
{
	private readonly IGroup<GameEntity> _listeners;

	private readonly List<GameEntity> _entityBuffer;

	private readonly List<IAnyAssetListener> _listenerBuffer;

	public AnyAssetEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listeners = ((Context<GameEntity>)contexts.game).GetGroup(GameMatcher.AnyAssetListener);
		_entityBuffer = new List<GameEntity>();
		_listenerBuffer = new List<IAnyAssetListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.Asset) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasAsset;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			AssetComponent asset = entity.asset;
			foreach (GameEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyAssetListener.value);
				foreach (IAnyAssetListener item in _listenerBuffer)
				{
					item.OnAnyAsset(entity, asset.value);
				}
			}
		}
	}
}
