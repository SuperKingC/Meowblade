using System.Collections.Generic;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using UI.GvG3SupplyDepot;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGCampFlagship.SupplyDepot;

public class FoodSupplyCallbackQueue
{
	private readonly Queue<FoodSupplyCallback> _callbackQueue = new Queue<FoodSupplyCallback>();

	private bool _isProcessing = false;

	private readonly UI_com_FoodSupply _uiComponent;

	public FoodSupplyCallbackQueue(UI_com_FoodSupply uiComponent)
	{
		_uiComponent = uiComponent;
	}

	public void EnqueueCallback(string shipId, C2S_GiveFoodDailySupplyToShip.Response response)
	{
		FoodSupplyCallback item = new FoodSupplyCallback(_uiComponent, shipId, response);
		_callbackQueue.Enqueue(item);
		if (!_isProcessing)
		{
			ProcessNextCallback();
		}
	}

	private void ProcessNextCallback()
	{
		if (_callbackQueue.Count == 0)
		{
			_isProcessing = false;
			return;
		}
		_isProcessing = true;
		FoodSupplyCallback foodSupplyCallback = _callbackQueue.Dequeue();
		foodSupplyCallback.Execute(OnCallbackComplete);
	}

	private void OnCallbackComplete()
	{
		ProcessNextCallback();
	}
}
