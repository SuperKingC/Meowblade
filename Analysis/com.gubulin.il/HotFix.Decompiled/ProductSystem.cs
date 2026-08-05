using System;

public sealed class ProductSystem : BaseExecuteSystem
{
	private DateTimeOffset _lastCheckAt;

	private float tm;

	public ProductSystem(Contexts contexts)
		: base(contexts)
	{
		tm = 0f;
	}

	public override void Execute()
	{
	}
}
