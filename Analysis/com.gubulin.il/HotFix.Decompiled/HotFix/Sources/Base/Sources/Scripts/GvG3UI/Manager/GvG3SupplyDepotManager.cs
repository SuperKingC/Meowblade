using System;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;

public class GvG3SupplyDepotManager : Singleton<GvG3SupplyDepotManager>
{
	private C2S_GetContributionItemInfo.Response _contributionItemInfo;

	public Action UpdateUi = delegate
	{
	};

	public C2S_GetContributionItemInfo.Response ContributionItemInfo => _contributionItemInfo;

	public void Init()
	{
		RegisterUiEventListeners();
	}

	private void RegisterUiEventListeners()
	{
	}

	private void UnregisterUiEventListeners()
	{
	}

	public void Destroy()
	{
		UnregisterUiEventListeners();
		ClearCache();
	}

	private void ClearCache()
	{
		_contributionItemInfo = null;
	}

	public void GetFoodDailySupplyInfo(Action<C2S_GetFoodDailySupplyInfo.Response> renderer)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetFoodDailySupplyInfo
		{
			Req = new C2S_GetFoodDailySupplyInfo.Request
			{
				non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetFoodDailySupplyInfo.Response response = (C2S_GetFoodDailySupplyInfo.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Singleton<WorldStateManager>.Instance.Data.PlayerFlagshipInfo.UpdateFood(response.FlagShipCurFood, response.FlagShipMaxFood);
				renderer?.Invoke(response);
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
		});
	}

	public void GiveFoodDailySupplyToShip(string shipId, Action<C2S_GiveFoodDailySupplyToShip.Response> updateUi)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GiveFoodDailySupplyToShip
		{
			Req = new C2S_GiveFoodDailySupplyToShip.Request
			{
				ShipId = shipId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GiveFoodDailySupplyToShip.Response response = (C2S_GiveFoodDailySupplyToShip.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Singleton<WorldStateManager>.Instance.Data.PlayerFlagshipInfo.UpdateFood(response.FlagShipCur);
				updateUi?.Invoke(response);
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
		});
	}

	public void GetContributionItemInfo(Action onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetContributionItemInfo
		{
			Req = new C2S_GetContributionItemInfo.Request
			{
				non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetContributionItemInfo.Response response = (C2S_GetContributionItemInfo.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				_contributionItemInfo = response;
				onFinished?.Invoke();
				UpdateUi?.Invoke();
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
		});
	}

	public void ClaimYesterdayContributionItems(Action onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ClaimYesterdayContributionItem
		{
			Req = new C2S_ClaimYesterdayContributionItem.Request
			{
				non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_ClaimYesterdayContributionItem.Response response = (C2S_ClaimYesterdayContributionItem.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Singleton<WorldStateManager>.Instance.Data.PlayerFlagshipInfo.UpdateDailyContributionBoxClaimed(claimed: true);
				GetContributionItemInfo(onFinished);
			}
		});
	}

	public void GetTalentDailySupplyBox(Action onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetTalentDailySupplyBox
		{
			Req = new C2S_GetTalentDailySupplyBox.Request
			{
				non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetTalentDailySupplyBox.Response response = (C2S_GetTalentDailySupplyBox.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Singleton<WorldStateManager>.Instance.Data.PlayerFlagshipInfo.UpdateDailySupplyPackClaimed(claimed: true);
				GetContributionItemInfo(onFinished);
			}
		});
	}
}
