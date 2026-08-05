using System.Collections.Generic;
using Entitas;

public sealed class AnyCameraFollowTeamEventSystem : ReactiveSystem<GameStateEntity>
{
	private readonly IGroup<GameStateEntity> _listeners;

	private readonly List<GameStateEntity> _entityBuffer;

	private readonly List<IAnyCameraFollowTeamListener> _listenerBuffer;

	public AnyCameraFollowTeamEventSystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_listeners = ((Context<GameStateEntity>)contexts.gameState).GetGroup(GameStateMatcher.AnyCameraFollowTeamListener);
		_entityBuffer = new List<GameStateEntity>();
		_listenerBuffer = new List<IAnyCameraFollowTeamListener>();
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[1] { TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.CameraFollowTeam) });
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return entity.hasCameraFollowTeam;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		foreach (GameStateEntity entity in entities)
		{
			CameraFollowTeamComponent cameraFollowTeam = entity.cameraFollowTeam;
			foreach (GameStateEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyCameraFollowTeamListener.value);
				foreach (IAnyCameraFollowTeamListener item in _listenerBuffer)
				{
					item.OnAnyCameraFollowTeam(entity, cameraFollowTeam.value);
				}
			}
		}
	}
}
