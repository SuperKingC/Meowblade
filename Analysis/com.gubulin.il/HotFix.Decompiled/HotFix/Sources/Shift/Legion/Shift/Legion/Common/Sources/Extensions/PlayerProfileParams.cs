using System;
using FairyGUI;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;

public class PlayerProfileParams<T> where T : GComponent
{
	public string CacheVersion { get; set; }

	public int UserId { get; set; }

	public int CampId { get; set; }

	public Action<T> OnProfileLoaded { get; set; } = null;
}
