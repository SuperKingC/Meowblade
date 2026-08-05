using UnityEngine;

namespace Shift.Legion.Common.Services;

public sealed class TimeService : Service, ITimeService, IService
{
	public TimeService(Contexts contexts)
		: base(contexts)
	{
	}

	public float FixedDeltaTime()
	{
		return Time.fixedDeltaTime;
	}

	public float DeltaTime()
	{
		return Time.deltaTime;
	}
}
