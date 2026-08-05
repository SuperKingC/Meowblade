using System.Collections;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using UI.GameActivity;

namespace Shift.Legion.Common.Managers;

public class Cache_DeparturePresentRedDot : CacheBaseBehavior
{
	public const string ON_DEPARTURE_PRESENT_RED_DOT_CHANGE = "ON_DEPARTURE_PRESENT_RED_DOT_CHANGE";

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
				SharedMessenger.Broadcast("ON_DEPARTURE_PRESENT_RED_DOT_CHANGE", this);
			}
		}
	}

	public override IEnumerator Init()
	{
		IsUpdateEnabled = true;
		base.DelayUpdateFromNow = 1f;
		yield return null;
	}

	public override void DeferredUpdate()
	{
		if (!_isUpdating)
		{
			_isUpdating = true;
			IsShowRedDot = UI_main_DeparturePresent.DisplayRedNote();
			IsUpdateEnabled = false;
			_isUpdating = false;
		}
	}

	public override void OnAllCachesInit()
	{
		SharedMessenger.AddListener<string, Level, Team, bool>("LEVEL_COMPLETED", OnLevelComplete);
	}

	private void OnLevelComplete(string battleId, Level level, Team winner, bool newCompleteFlag)
	{
		IsUpdateEnabled = true;
		base.DelayUpdateFromNow = 0.5f;
	}
}
