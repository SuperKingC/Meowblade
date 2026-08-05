using System.Collections.Generic;
using Entitas;

public sealed class MoveSpeedEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IMoveSpeedListener> _listenerBuffer;

	public MoveSpeedEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IMoveSpeedListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.MoveSpeed) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasMoveSpeed && entity.hasMoveSpeedListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			MoveSpeedComponent moveSpeed = entity.moveSpeed;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.moveSpeedListener.value);
			foreach (IMoveSpeedListener item in _listenerBuffer)
			{
				item.OnMoveSpeed(entity, moveSpeed.value);
			}
		}
	}
}
