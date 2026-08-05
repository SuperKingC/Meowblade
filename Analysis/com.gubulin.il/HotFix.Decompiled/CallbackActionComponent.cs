using System;
using Entitas;

[Timer]
public sealed class CallbackActionComponent : IComponent
{
	public Action value;
}
