using System.Collections.Generic;
using Entitas;

public class CloseLoadingUiOnSceneLoadedSystem : ReactiveSystem<GameEntity>
{
	public CloseLoadingUiOnSceneLoadedSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return CollectorContextExtension.CreateCollector<GameEntity>(context, GameMatcher.SceneLoaded);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isSceneLoaded;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		CommandFactory.CreateCloseLoadingUiCommand();
	}
}
