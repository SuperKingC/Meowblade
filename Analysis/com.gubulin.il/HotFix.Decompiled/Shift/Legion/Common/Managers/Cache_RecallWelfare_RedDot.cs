using System.Collections;

namespace Shift.Legion.Common.Managers;

public class Cache_RecallWelfare_RedDot : CacheBaseBehavior
{
	public const string ON_RECALL_WELFARE_MISSION_PROGRESS_CHANGED = "ON_RECALL_WELFARE_MISSION_PROGRESS_CHANGED";

	private bool _isUpdating = false;

	private bool _isShowRedDot = false;

	public bool IsShowRedDot
	{
		get
		{
			return _isShowRedDot;
		}
		set
		{
			if (value != _isShowRedDot)
			{
				_isShowRedDot = value;
				SharedMessenger.Broadcast("ON_RECALL_WELFARE_MISSION_PROGRESS_CHANGED", this);
			}
		}
	}

	public override IEnumerator Init()
	{
		IsUpdateEnabled = true;
		base.DelayUpdateFromNow = 1f;
		yield return null;
	}
}
