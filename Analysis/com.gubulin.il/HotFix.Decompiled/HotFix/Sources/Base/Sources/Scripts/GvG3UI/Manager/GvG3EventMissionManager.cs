using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.GvGServer.Helper;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.NPC;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.PlayerCommand;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;

public class GvG3EventMissionManager : Singleton<GvG3EventMissionManager>
{
	public Action<List<IIslandEvent>> UpdateIslandEvents = delegate
	{
	};

	public Action<IEvent_伟大航路> Update伟大航路 = delegate
	{
	};

	public Action<C2S_GetNPCShop.Response> UpdateNpcShop = delegate
	{
	};

	public Action UpdateNcpDialog = delegate
	{
	};

	public Action<IEvent_PlayerCommand> UpdatePlayerCommand = delegate
	{
	};

	private C2S_BuyNPCShop.Request _npcShopBuyRequest;

	private Action _onBuyNpcShopItemSuccess = delegate
	{
	};

	private Action _onCreatedPlayerCommand = delegate
	{
	};

	public int CurrentIslandId { get; set; }

	public int CurrentNpcShopMUid { get; private set; }

	public void Init()
	{
		RegisterUiEventListeners();
	}

	private void RegisterUiEventListeners()
	{
		S2C_FinishNPCDialogMission.OnPushEvent = (Action<S2C_FinishNPCDialogMission.Request>)Delegate.Combine(S2C_FinishNPCDialogMission.OnPushEvent, new Action<S2C_FinishNPCDialogMission.Request>(OnPushFinishNPCDialog));
		S2C_BuyNPCShop.OnPushEvent = (Action<S2C_BuyNPCShop.Request>)Delegate.Combine(S2C_BuyNPCShop.OnPushEvent, new Action<S2C_BuyNPCShop.Request>(OnPushBuyNpcShopItemResult));
		S2C_CreatePlayerCommand.OnPushEvent = (Action<S2C_CreatePlayerCommand.Request>)Delegate.Combine(S2C_CreatePlayerCommand.OnPushEvent, new Action<S2C_CreatePlayerCommand.Request>(OnPushCreatePlayerCommand));
	}

	private void UnregisterUiEventListeners()
	{
		S2C_FinishNPCDialogMission.OnPushEvent = (Action<S2C_FinishNPCDialogMission.Request>)Delegate.Remove(S2C_FinishNPCDialogMission.OnPushEvent, new Action<S2C_FinishNPCDialogMission.Request>(OnPushFinishNPCDialog));
		S2C_BuyNPCShop.OnPushEvent = (Action<S2C_BuyNPCShop.Request>)Delegate.Remove(S2C_BuyNPCShop.OnPushEvent, new Action<S2C_BuyNPCShop.Request>(OnPushBuyNpcShopItemResult));
		S2C_CreatePlayerCommand.OnPushEvent = (Action<S2C_CreatePlayerCommand.Request>)Delegate.Remove(S2C_CreatePlayerCommand.OnPushEvent, new Action<S2C_CreatePlayerCommand.Request>(OnPushCreatePlayerCommand));
	}

	public void Destroy()
	{
		UnregisterUiEventListeners();
		ClearCache();
	}

	private void ClearCache()
	{
		CurrentIslandId = -1;
		CurrentNpcShopMUid = 1;
	}

	public void SyncIslandEvents(IslandStateModel islandStateModel)
	{
		if (CurrentIslandId > 0 && islandStateModel.IslandId == CurrentIslandId)
		{
			Singleton<WorldStateManager>.Instance.GetIslandDetail(CurrentIslandId, delegate(IslandStateModel islandState)
			{
				UpdateIslandEvents?.Invoke(islandState.IslandEvents);
				Update伟大航路?.Invoke(islandStateModel.Is伟大航路Shared ? islandStateModel.Event_伟大航路 : null);
			});
		}
	}

	public void ClaimMission(int mUid)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ClaimTreasureMapMission
		{
			Req = new C2S_ClaimTreasureMapMission.Request
			{
				MUID = mUid
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_ClaimTreasureMapMission.Response response = (C2S_ClaimTreasureMapMission.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
		});
	}

	public void CancelTreasureMapMission()
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_CancelTreasureMapMission
		{
			Req = new C2S_CancelTreasureMapMission.Request
			{
				non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_CancelTreasureMapMission.Response response = (C2S_CancelTreasureMapMission.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
		});
	}

	public void FinishNpcDialog(int mUid, Action onFinished = null)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_FinishNPCDialogMission
		{
			Req = new C2S_FinishNPCDialogMission.Request
			{
				MUID = mUid
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_FinishNPCDialogMission.Response response = (C2S_FinishNPCDialogMission.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			onFinished?.Invoke();
		});
	}

	public void OnPushFinishNPCDialog(S2C_FinishNPCDialogMission.Request request)
	{
		if (request.ErrorCode < 0)
		{
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			ILRequestHelper.ShowErrorCode(request.ErrorCode);
		}
		else
		{
			GvG3FlagshipReqManager.SetGsStock(request.GSItems);
			UpdateNcpDialog?.Invoke();
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
		}
	}

	public void GetNpcShop(int mUid, bool isOpenPage = false)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		CurrentNpcShopMUid = mUid;
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetNPCShop
		{
			Req = new C2S_GetNPCShop.Request
			{
				MUID = mUid,
				FirstOpen = isOpenPage
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetNPCShop.Response response = (C2S_GetNPCShop.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			UpdateNpcShop?.Invoke(response);
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
		});
	}

	public void BuyNpcShop(int mUid, string formulaId, int buyCnt, Action onBuyNpcShopItemSuccess = null)
	{
		_onBuyNpcShopItemSuccess = onBuyNpcShopItemSuccess;
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		_npcShopBuyRequest = new C2S_BuyNPCShop.Request
		{
			MUID = mUid,
			FormulaId = formulaId,
			BuyCnt = buyCnt
		};
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_BuyNPCShop
		{
			Req = _npcShopBuyRequest
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_BuyNPCShop.Response response = (C2S_BuyNPCShop.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				_npcShopBuyRequest = null;
				_onBuyNpcShopItemSuccess = null;
			}
		});
	}

	public void OnPushBuyNpcShopItemResult(S2C_BuyNPCShop.Request request)
	{
		if (request.ErrorCode < 0)
		{
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			ILRequestHelper.ShowErrorCode(request.ErrorCode);
			_npcShopBuyRequest = null;
			_onBuyNpcShopItemSuccess = null;
		}
		else
		{
			SyncStockChange();
			GetNpcShop(CurrentNpcShopMUid);
			_onBuyNpcShopItemSuccess?.Invoke();
			_onBuyNpcShopItemSuccess = null;
		}
	}

	private void SyncStockChange()
	{
		if (_npcShopBuyRequest != null)
		{
			StockChangeRecord[] changeRecords = GetChangeRecords();
			GameManagers.Instance.StockController.ReadStockChangeRecords(changeRecords);
			_npcShopBuyRequest = null;
		}
	}

	private StockChangeRecord[] GetChangeRecords()
	{
		GvGMode3ShopEventFormulaConfigModel gvGMode3ShopEventFormulaConfigModel = GvG3FlagShipMissionsConfigHelper.EventShopFormulas(_npcShopBuyRequest.FormulaId);
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (KeyValuePair<string, int> item in gvGMode3ShopEventFormulaConfigModel.Input)
		{
			if (!StorehouseHelper.IsGvGItem(item.Key))
			{
				int costOfInput = gvGMode3ShopEventFormulaConfigModel.GetCostOfInput(item.Key);
				dictionary.Add(item.Key, costOfInput);
			}
		}
		return dictionary.ToStockChangeRecords(StockInContext.FormulaBonus, _npcShopBuyRequest.FormulaId ?? "", -_npcShopBuyRequest.BuyCnt);
	}

	public void SyncPlayerCommand(IslandStateModel islandStateModel)
	{
		if (CurrentIslandId > 0 && islandStateModel.IslandId == CurrentIslandId)
		{
			UpdatePlayerCommand?.Invoke(islandStateModel.PlayerCommand);
		}
	}

	public void CheckPlayerCommandMessage(string commandMsg, Action<C2S_CheckPlayerCommandMessage.Response> onChecked = null)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_CheckPlayerCommandMessage
		{
			Req = new C2S_CheckPlayerCommandMessage.Request
			{
				Msg = commandMsg
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_CheckPlayerCommandMessage.Response obj = (C2S_CheckPlayerCommandMessage.Response)contextResponse.Resp;
			onChecked?.Invoke(obj);
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
		});
	}

	public void CancelPlayerCommand(int mUid, Action onFinished = null)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_CancelPlayerCommand
		{
			Req = new C2S_CancelPlayerCommand.Request
			{
				MUID = mUid
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_CancelPlayerCommand.Response response = (C2S_CancelPlayerCommand.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onFinished?.Invoke();
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
		});
	}

	public void CreatePlayerCommand(int commandType, int contributionPointAdd, int timerAdd, string commandMsg, int islandId, Action onFinished = null)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		_onCreatedPlayerCommand = onFinished;
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_CreatePlayerCommand
		{
			Req = new C2S_CreatePlayerCommand.Request
			{
				CommandType = commandType,
				ContributionPointAdd = contributionPointAdd,
				TimerAdd = timerAdd,
				Message = commandMsg,
				IslandId = islandId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_CreatePlayerCommand.Response response = (C2S_CreatePlayerCommand.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				_onCreatedPlayerCommand = null;
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
		});
	}

	private void OnPushCreatePlayerCommand(S2C_CreatePlayerCommand.Request request)
	{
		if (request.ErrorCode != 0)
		{
			_onCreatedPlayerCommand = null;
			if (request.ErrorCode == 813107030)
			{
				ILRequestHelper.ShowMessage(string.Format("ErrorCode_CreatePlayerCommandFailed_GemNotEnough".ToLanguage(), new object[1] { Item.Name(GameManagers.Instance, "Gem") }));
			}
			else
			{
				ILRequestHelper.ShowErrorCode(request.ErrorCode);
			}
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			return;
		}
		_onCreatedPlayerCommand?.Invoke();
		_onCreatedPlayerCommand = null;
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
		if (request.ChangedStorehouse == null)
		{
			return;
		}
		foreach (RItem item in request.ChangedStorehouse)
		{
			GameManagers.Instance.StockController.SetStock(item.ItemId, item.cnt, StockInContext.AutoFill);
		}
	}
}
