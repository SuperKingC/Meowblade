using System.Collections;
using Shift.Legion.Common.Helpers;

namespace Shift.Legion.Common.Managers;

public class Cache_SoldierFormationData : CacheBaseBehavior
{
	public static string ON_REDDOT_CHANCE = typeof(Cache_SoldierFormationData).Name;

	public static string ON_PAGE_REDDOT_CHANCE = typeof(Cache_SoldierFormationData).Name + "Page";

	public override IEnumerator Init()
	{
		yield return base.Init();
		base.DelayUpdateFromNow = 2f;
		TimeInterval = 2f;
		_ = Singleton<SoldierFormationManager>.Instance;
		IsUpdateEnabled = false;
		yield return null;
	}
}
