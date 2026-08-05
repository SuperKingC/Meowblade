namespace Shift.Legion.Common.Services;

public interface ITimeService : IService
{
	float FixedDeltaTime();

	float DeltaTime();
}
