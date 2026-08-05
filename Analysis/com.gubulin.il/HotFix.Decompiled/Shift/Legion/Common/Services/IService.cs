namespace Shift.Legion.Common.Services;

public interface IService
{
	void Init();

	void Destroy();

	void AddEventsListener();

	void RemoveEventsListener();
}
