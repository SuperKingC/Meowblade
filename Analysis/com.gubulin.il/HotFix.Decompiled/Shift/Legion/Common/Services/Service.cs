namespace Shift.Legion.Common.Services;

public abstract class Service : IService
{
	protected Contexts Contexts { get; private set; }

	protected Service(Contexts contexts)
	{
		Contexts = contexts;
	}

	public virtual void Init()
	{
	}

	public virtual void Destroy()
	{
		Contexts = null;
	}

	public virtual void AddEventsListener()
	{
	}

	public virtual void RemoveEventsListener()
	{
	}
}
