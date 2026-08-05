using System.Collections.Generic;
using Entitas;

public sealed class GameUserDataLoadedCommandSystem : ReactiveSystem<CommandEntity>
{
	private readonly GameUserDataLoadedCommandExecutor _executor;

	public GameUserDataLoadedCommandSystem(Contexts contexts)
		: base((IContext<CommandEntity>)(object)contexts.command)
	{
		base.init((IContext<CommandEntity>)(object)contexts.command);
		_executor = new GameUserDataLoadedCommandExecutor(contexts);
	}

	protected override ICollector<CommandEntity> GetTrigger(IContext<CommandEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<CommandEntity>(context, new TriggerOnEvent<CommandEntity>[2]
		{
			TriggerOnEventMatcherExtension.Added<CommandEntity>(CommandMatcher.GameUserDataLoadedCommand),
			TriggerOnEventMatcherExtension.Removed<CommandEntity>(CommandMatcher.CommandDelay)
		});
	}

	protected override bool Filter(CommandEntity entity)
	{
		return entity.hasGameUserDataLoadedCommand && !entity.hasCommandDelay;
	}

	protected override void Execute(List<CommandEntity> entities)
	{
		_executor.Prepare();
		foreach (CommandEntity entity in entities)
		{
			_executor.Execute(entity.gameUserDataLoadedCommand);
			entity.isDestroyed = true;
		}
	}
}
