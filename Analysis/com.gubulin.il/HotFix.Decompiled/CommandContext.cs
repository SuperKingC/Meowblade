using System;
using Entitas;

public sealed class CommandContext : Context<CommandEntity>
{
	public CommandContext()
		: base(21, 0, new ContextInfo("Command", CommandComponentsLookup.componentNames, CommandComponentsLookup.componentTypes), (Func<IEntity, IAERC>)((IEntity entity) => (IAERC)new UnsafeAERC()), (Func<CommandEntity>)(() => new CommandEntity()))
	{
	}//IL_0013: Unknown result type (might be due to invalid IL or missing references)
	//IL_005b: Expected O, but got Unknown

}
