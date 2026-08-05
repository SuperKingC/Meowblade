using System.Collections.Generic;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Informs
{
	private const string PendingInformsKey = "PENDING_INFORMS";

	public static List<InformConfig> GetPendingInforms(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<List<InformConfig>>("PENDING_INFORMS");
	}

	public static void InsertPendingInform(this UserArchiveManager manager, InformConfig informConfig)
	{
		manager.AddToList("PENDING_INFORMS", informConfig);
	}
}
