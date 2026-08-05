using System.Threading.Tasks;

namespace Shift.Legion.Common.Managers;

public abstract class Manager
{
	internal GameManagers Managers;

	public Manager(GameManagers managers)
	{
		Managers = managers;
	}

	public virtual Task Init()
	{
		return null;
	}

	public virtual void AddEventListener()
	{
	}

	public virtual void RemoveEventListener()
	{
	}
}
