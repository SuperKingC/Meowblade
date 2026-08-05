using System.Collections.Generic;
using Entitas;

public sealed class ChangeCurrentFormationUnitCommandSystem : ReactiveSystem<CommandEntity>
{
	private readonly ChangeCurrentFormationUnitCommandExecutor _executor;

	public ChangeCurrentFormationUnitCommandSystem(Contexts contexts)
		: base((IContext<CommandEntity>)(object)contexts.command)
	{
		base.init((IContext<CommandEntity>)(object)contexts.command);
		_executor = new ChangeCurrentFormationUnitCommandExecutor(contexts);
	}

	protected override ICollector<CommandEntity> GetTrigger(IContext<CommandEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<CommandEntity>(context, new TriggerOnEvent<CommandEntity>[2]
		{
			TriggerOnEventMatcherExtension.Added<CommandEntity>(CommandMatcher.ChangeCurrentFormationUnitCommand),
			TriggerOnEventMatcherExtension.Removed<CommandEntity>(CommandMatcher.CommandDelay)
		});
	}

	protected override bool Filter(CommandEntity entity)
	{
		return entity.hasChangeCurrentFormationUnitCommand && !entity.hasCommandDelay;
	}

	protected override void Execute(List<CommandEntity> entities)
	{
		_executor.Prepare();
		foreach (CommandEntity entity in entities)
		{
			_executor.Execute(entity.changeCurrentFormationUnitCommand);
			entity.isDestroyed = true;
		}
	}
}
