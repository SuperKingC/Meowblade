using System.Collections.Generic;
using Entitas;

public sealed class AnyCameraPositionEventSystem : ReactiveSystem<GameStateEntity>
{
	private readonly IGroup<GameStateEntity> _listeners;

	private readonly List<GameStateEntity> _entityBuffer;

	private readonly List<IAnyCameraPositionListener> _listenerBuffer;

	public AnyCameraPositionEventSystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_listeners = ((Context<GameStateEntity>)contexts.gameState).GetGroup(GameStateMatcher.AnyCameraPositionListener);
		_entityBuffer = new List<GameStateEntity>();
		_listenerBuffer = new List<IAnyCameraPositionListener>();
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[1] { TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.CameraPosition) });
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return entity.hasCameraPosition;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		foreach (GameStateEntity entity in entities)
		{
			CameraPositionComponent cameraPosition = entity.cameraPosition;
			foreach (GameStateEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyCameraPositionListener.value);
				foreach (IAnyCameraPositionListener item in _listenerBuffer)
				{
					item.OnAnyCameraPosition(entity, cameraPosition.value);
				}
			}
		}
	}
}
