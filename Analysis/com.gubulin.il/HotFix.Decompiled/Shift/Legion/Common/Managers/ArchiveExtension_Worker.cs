using System.Collections.Generic;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Worker
{
	private const string BaseDiligentWorkerRateKey = "BASE_DILIGENT_WORKER_RATE";

	private const string BaseLazyWorkerRateKey = "BASE_LAZY_WORKER_RATE";

	private const string BaseDiligentWorkerDurationKey = "BASE_DILIGENT_WORKER_DURATION";

	private const string BaseLazyWorkerDurationKey = "BASE_LAZY_WORKER_DURATION";

	private const string WorkerStatusInnerCdKey = "WORKER_STATUS_INNER_CD";

	public static float GetWorkerStatusCd(this UserArchiveManager manager)
	{
		List<float> configValue = manager.GetConfigValue<List<float>>("WORKER_STATUS_INNER_CD");
		return manager.Managers.RandomManager.Float(configValue[0], configValue[1]);
	}

	public static float GetBaseDiligentWorkerRate(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<float>("BASE_DILIGENT_WORKER_RATE");
	}

	public static float GetBaseLazyWorkerRate(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<float>("BASE_LAZY_WORKER_RATE");
	}

	public static float GetBaseDiligentWorkerDuration(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<float>("BASE_DILIGENT_WORKER_DURATION");
	}

	public static float GetBaseLazyWorkerDuration(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<float>("BASE_LAZY_WORKER_DURATION");
	}
}
