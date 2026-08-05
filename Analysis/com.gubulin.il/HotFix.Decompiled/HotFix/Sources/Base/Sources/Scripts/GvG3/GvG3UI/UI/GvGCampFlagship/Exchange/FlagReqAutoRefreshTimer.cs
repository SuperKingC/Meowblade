using System;
using System.Collections;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGCampFlagship.Exchange;

public class FlagReqAutoRefreshTimer
{
	private const int DELAY_HOURS = 6;

	private Coroutine _coroutine;

	private readonly WaitForSeconds _perSecond10 = new WaitForSeconds(10f);

	private Action _refresh;

	private bool _timerInitialized;

	private int _today1200;

	private int _today1150;

	private bool _refreshedAt1150;

	private bool _refreshedAt1200;

	private static int CurrentTimestamp => (int)GameController.Instance.GetServerTime();

	public void Init(Action refresh)
	{
		_refresh = refresh;
		InitRefreshedFlags();
		TryStartCoroutine();
	}

	private void InitRefreshedFlags()
	{
		if (!_timerInitialized)
		{
			DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.ServerNow, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
			int timeStamp = DateTimeHelper.GetTimeStamp(dailyRefreshTime);
			int num = timeStamp + 21600;
			_today1200 = num + 10;
			_today1150 = num - 600 + 10;
			if (CurrentTimestamp > _today1150)
			{
				_refreshedAt1150 = true;
			}
			if (CurrentTimestamp > _today1200)
			{
				_refreshedAt1200 = true;
			}
			_timerInitialized = true;
		}
	}

	private void TryStartCoroutine()
	{
		if (!_refreshedAt1150 || !_refreshedAt1200)
		{
			_coroutine = FGUIManager.Instance.OpenIEnumerator(Timer());
		}
	}

	private IEnumerator Timer()
	{
		while (!_refreshedAt1150 || !_refreshedAt1200)
		{
			bool needRefresh = false;
			if (!_refreshedAt1150 && CurrentTimestamp > _today1150)
			{
				needRefresh = true;
				_refreshedAt1150 = true;
			}
			if (!_refreshedAt1200 && CurrentTimestamp > _today1200)
			{
				needRefresh = true;
				_refreshedAt1200 = true;
			}
			if (needRefresh)
			{
				_refresh?.Invoke();
			}
			yield return _perSecond10;
		}
	}

	public void OnDestroy()
	{
		_refresh = null;
		if (_coroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_coroutine);
		}
	}
}
