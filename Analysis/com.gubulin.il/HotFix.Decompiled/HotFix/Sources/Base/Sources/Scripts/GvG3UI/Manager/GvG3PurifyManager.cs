using System;
using System.Collections.Generic;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UI.GvGPurification3;
using UI.GvGPurificationResult3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;

public class GvG3PurifyManager : Singleton<GvG3PurifyManager>
{
	public const string PURIFICATION_RESULT = "PurificationResult";

	public Action UpdatePollutantsList = delegate
	{
	};

	public void Init()
	{
		RegisterUiEventListeners();
	}

	private void RegisterUiEventListeners()
	{
		S2C_Purification.OnPushEvent = (Action<S2C_Purification.Request>)Delegate.Combine(S2C_Purification.OnPushEvent, new Action<S2C_Purification.Request>(OnPushPurification));
	}

	private void UnregisterUiEventListeners()
	{
		S2C_Purification.OnPushEvent = (Action<S2C_Purification.Request>)Delegate.Remove(S2C_Purification.OnPushEvent, new Action<S2C_Purification.Request>(OnPushPurification));
	}

	public void Destroy()
	{
		UnregisterUiEventListeners();
		ClearCache();
	}

	private void ClearCache()
	{
	}

	public void Purify(List<RItem> pollutants)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_Purification
		{
			Req = new C2S_Purification.Request
			{
				Pollutant = pollutants
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_Purification.Response response = (C2S_Purification.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
		});
	}

	private void OnPushPurification(S2C_Purification.Request request)
	{
		if (request != null)
		{
			if (request.ErrorCode != 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(request.ErrorCode);
				ForcedClosePurificationEffectPanel();
			}
			else
			{
				SetGsStock(request.StorehouseChanged);
				UpdatePollutantsList?.Invoke();
				OpenPurificationResult(request);
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
		}
	}

	public void PlayPurificationEffect()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_PurificationEffect.Name, new Dictionary<string, object> { 
		{
			"PurificationResult",
			DisplayResult()
		} });
		static Action DisplayResult()
		{
			return DisplayPurificationResult;
		}
	}

	private static void ForcedClosePurificationEffectPanel()
	{
		UI_main_PurificationEffect.WaitToForcedClose = true;
		UI_main_PurificationEffect.End();
	}

	private static void DisplayPurificationResult()
	{
		UI_main_GvG3PurificationResult.WaitToDisplay = true;
	}

	private static void OpenPurificationResult(S2C_Purification.Request request)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3PurificationResult.Name, new Dictionary<string, object> { { "PurificationResult", request } });
	}

	private static void SetGsStock(List<RItem> items)
	{
		if (items == null)
		{
			return;
		}
		foreach (RItem item in items)
		{
			GameManagers.Instance.StockController.SetStock(item.ItemId, item.cnt, StockInContext.AutoFill);
		}
	}
}
