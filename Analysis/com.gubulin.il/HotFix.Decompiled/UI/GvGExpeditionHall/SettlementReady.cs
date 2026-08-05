using System;

namespace UI.GvGExpeditionHall;

public class SettlementReady
{
	private readonly bool _isReady;

	private readonly Action _isNotReadyFunc;

	public SettlementReady(bool isReady, Action isNotReadyFunc)
	{
		_isReady = isReady;
		_isNotReadyFunc = isNotReadyFunc;
	}

	public bool IsReady()
	{
		if (_isReady)
		{
			return true;
		}
		_isNotReadyFunc?.Invoke();
		return false;
	}
}
