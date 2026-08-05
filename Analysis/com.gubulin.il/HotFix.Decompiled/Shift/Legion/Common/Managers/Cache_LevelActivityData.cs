using System.Collections;

namespace Shift.Legion.Common.Managers;

public class Cache_LevelActivityData : CacheBaseBehavior
{
	public static string ON_REDDOT_CHANCE = typeof(Cache_LevelActivityData).Name;

	public static string ON_PAGE_REDDOT_CHANCE = typeof(Cache_LevelActivityData).Name + "Page";

	public override IEnumerator Init()
	{
		yield return base.Init();
		base.DelayUpdateFromNow = 2f;
		TimeInterval = 2f;
		yield return GameManagers.Instance.ActivityManager.GetAllLevelActivityData();
		IsUpdateEnabled = false;
		yield return null;
	}
}
