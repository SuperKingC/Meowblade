using System.Collections.Generic;
using Entitas;

public sealed class SkeletonEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<ISkeletonListener> _listenerBuffer;

	public SkeletonEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<ISkeletonListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.Skeleton) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasSkeleton && entity.hasSkeletonListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			SkeletonComponent skeleton = entity.skeleton;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.skeletonListener.value);
			foreach (ISkeletonListener item in _listenerBuffer)
			{
				item.OnSkeleton(entity, skeleton.value);
			}
		}
	}
}
