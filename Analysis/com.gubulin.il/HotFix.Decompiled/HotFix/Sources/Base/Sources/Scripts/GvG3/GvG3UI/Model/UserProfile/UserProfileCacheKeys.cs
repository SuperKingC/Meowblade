using System.Collections.Generic;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;

public class UserProfileCacheKeys
{
	public string CacheVersion { get; set; } = string.Empty;

	public List<string> ProfileCacheKeys { get; set; } = new List<string>();

	public List<string> Avatar132CacheKeys { get; set; } = new List<string>();
}
