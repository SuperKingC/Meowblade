using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using HotFix;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using Shift.Legion.Helpers;
using UI.GvGWorldMap2;
using UnityEngine;

namespace GvG2;

public class GvGInstanceZone2 : Singleton<GvGInstanceZone2>
{
	private Coroutine _Coroutine_Ping = null;

	public override void InitInstance()
	{
	}

	public void EnterRoom()
	{
		GvGRoomHelper.GvGRoomOperation(eGvGRoomOperation.Inquire, delegate(string json)
		{
			if (!string.IsNullOrEmpty(json))
			{
				InquireResult inquireResult = JsonHelper.ToObject<InquireResult>(json);
				if (!string.IsNullOrEmpty(inquireResult.LockTimestamp) && !string.IsNullOrEmpty(inquireResult.StartTimestamp))
				{
					ExitRoom();
					ConnectToGvGInstanceZone(inquireResult.Pid, inquireResult.ExternalSocketPort);
				}
			}
		});
	}

	public void ExitRoom()
	{
		if (_Coroutine_Ping != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_Coroutine_Ping);
		}
	}

	private IEnumerator Ping()
	{
		yield return (object)new WaitForSeconds(2f);
	}

	private void ConnectToGvGInstanceZone(string pid, string port)
	{
		int pid2 = int.Parse(pid);
		int port2 = int.Parse(port);
		SocketManager.Instance.GetConnection(eConType.GvGMode2WorldMap).StartConnect(HotUpdateProcess.Instance.Configs["SocketHost"], port2, pid2, delegate
		{
			GetOwnShips();
		});
	}

	private void OnPushShipSummaryCreateSuccess(SocketManager.BaseSocketPackageBody res)
	{
		GetOwnShips();
		S2C_ShipSummaryCreateSuccess.OnPushEvent = (Action<S2C_ShipSummaryCreateSuccess.Request>)Delegate.Remove(S2C_ShipSummaryCreateSuccess.OnPushEvent, new Action<S2C_ShipSummaryCreateSuccess.Request>(OnPushShipSummaryCreateSuccess));
	}

	private void GetOwnShips()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode2WorldMap).Request(new C2S_GetOwnShips
		{
			Req = new C2S_GetOwnShips.Request
			{
				NonStr = ""
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetOwnShips.Response response = (C2S_GetOwnShips.Response)context_response.Resp;
			if (response.ErrorCode < 0)
			{
				ILRuntimeDebug.LogError("请求 GetOwnShips 不成功");
			}
			else if (response.ShipEntityIds == null)
			{
				ILRuntimeDebug.LogError("请求 GetOwnShips 返回的 ShipEntityIds 为 null");
			}
			else if (response.ShipEntityIds.Count > 0)
			{
				OpenGvGWorldMap2(response.ShipEntityIds);
			}
			else
			{
				S2C_ShipSummaryCreateSuccess.OnPushEvent = (Action<S2C_ShipSummaryCreateSuccess.Request>)Delegate.Combine(S2C_ShipSummaryCreateSuccess.OnPushEvent, new Action<S2C_ShipSummaryCreateSuccess.Request>(OnPushShipSummaryCreateSuccess));
				List<string> soldiers = new List<string> { "S001", "S002", "S003", "S004", "S005" };
				string formationId = "FA01";
				CreateOwnShip(soldiers, formationId);
			}
		});
	}

	private void CreateOwnShip(List<string> soldiers, string formationId)
	{
		ILRequestHelper<GvGMode2CreateShipSummaryResponse>.Request((EventContext)null, (Func<Task<GvGMode2CreateShipSummaryResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode2CreateShipSummary(soldiers, formationId)), (Action<GvGMode2CreateShipSummaryResponse>)delegate(GvGMode2CreateShipSummaryResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowMessage("GvGMode2CreateShipSummary 请求失败！");
			}
			else if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				ILRequestHelper.ShowMessage(LanguagesManager.GetDesc("IslandComeAgainCreateShipSucceed"));
			}
		});
	}

	private void OpenGvGWorldMap2(List<int> ownShipIds)
	{
		Singleton<GvGInstanceZone>.Instance.ClearData();
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGWorldMap2.Name, new Dictionary<string, object>
		{
			{ "ReservePackageResOnClose", true },
			{ "OwnShipIds", ownShipIds }
		});
	}
}
