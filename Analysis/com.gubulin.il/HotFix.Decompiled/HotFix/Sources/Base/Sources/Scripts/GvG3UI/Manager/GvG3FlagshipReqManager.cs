using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.C2S;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.S2C;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using Shift.Legion.Helpers;
using UI.GvGOEMBonus3;
using UI.GvGOEMResult3;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;

public class GvG3FlagshipReqManager : Singleton<GvG3FlagshipReqManager>
{
	private readonly string _campOemMissionsKey = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId}_{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}_" + $"{GameController.Contexts.gameState.user.value.UserId}_CampOemMissions";

	private readonly List<FlagShipReqMission_ToProtocol> _flagShipReqMissionToProtocolList = new List<FlagShipReqMission_ToProtocol>(75);

	private readonly List<SelfOEMMission_ToProtocol> _selfOemMissions = new List<SelfOEMMission_ToProtocol>(5);

	private OemMissionsModel _oemMissionsModel;

	public Action<FlagshipMissions> OnPushRefreshUi;

	private int _submitMissionMuid = -1;

	public Action<List<SelfOEMMission_ToProtocol>> UpdateSelfOemMissions = delegate
	{
	};

	public Action<OemMissionsModel> UpdateOemMissions = delegate
	{
	};

	public Action<List<FormulaOEMMissionsSelfRecord>> OnFormulaOemMissionsSelfRecordsUpdate = delegate
	{
	};

	public Action<FormulaOEMMissionsSelfRecord> OnFormulaOemMissionSelfRecordUpdate = delegate
	{
	};

	public void Init()
	{
		RegisterUiEventListeners();
		_oemMissionsModel = new OemMissionsModel();
	}

	private void RegisterUiEventListeners()
	{
		S2C_SubmitFlagShipReq.OnPushEvent = (Action<S2C_SubmitFlagShipReq.Request>)Delegate.Combine(S2C_SubmitFlagShipReq.OnPushEvent, new Action<S2C_SubmitFlagShipReq.Request>(OnPushSubmitFlagShipReq));
		S2C_PostOEMMission.OnPushEvent = (Action<S2C_PostOEMMission.Request>)Delegate.Combine(S2C_PostOEMMission.OnPushEvent, new Action<S2C_PostOEMMission.Request>(OnPushPostOEMMission));
		S2C_SelfOEMMissionChanged.OnPushEvent = (Action<S2C_SelfOEMMissionChanged.Request>)Delegate.Combine(S2C_SelfOEMMissionChanged.OnPushEvent, new Action<S2C_SelfOEMMissionChanged.Request>(OnPushUpdateSelfOEMMissions));
		S2C_PostFormulaOEMMission.OnPushEvent = (Action<S2C_PostFormulaOEMMission.Request>)Delegate.Combine(S2C_PostFormulaOEMMission.OnPushEvent, new Action<S2C_PostFormulaOEMMission.Request>(OnPushPostFormulaOEMMission));
		S2C_SelfFormulaOEMMissionChanged.OnPushEvent = (Action<S2C_SelfFormulaOEMMissionChanged.Request>)Delegate.Combine(S2C_SelfFormulaOEMMissionChanged.OnPushEvent, new Action<S2C_SelfFormulaOEMMissionChanged.Request>(OnPushSelfFormulaOEMMissionChanged));
	}

	private void UnregisterUiEventListeners()
	{
		S2C_SubmitFlagShipReq.OnPushEvent = (Action<S2C_SubmitFlagShipReq.Request>)Delegate.Remove(S2C_SubmitFlagShipReq.OnPushEvent, new Action<S2C_SubmitFlagShipReq.Request>(OnPushSubmitFlagShipReq));
		S2C_PostOEMMission.OnPushEvent = (Action<S2C_PostOEMMission.Request>)Delegate.Remove(S2C_PostOEMMission.OnPushEvent, new Action<S2C_PostOEMMission.Request>(OnPushPostOEMMission));
		S2C_SelfOEMMissionChanged.OnPushEvent = (Action<S2C_SelfOEMMissionChanged.Request>)Delegate.Remove(S2C_SelfOEMMissionChanged.OnPushEvent, new Action<S2C_SelfOEMMissionChanged.Request>(OnPushUpdateSelfOEMMissions));
		S2C_PostFormulaOEMMission.OnPushEvent = (Action<S2C_PostFormulaOEMMission.Request>)Delegate.Remove(S2C_PostFormulaOEMMission.OnPushEvent, new Action<S2C_PostFormulaOEMMission.Request>(OnPushPostFormulaOEMMission));
		S2C_SelfFormulaOEMMissionChanged.OnPushEvent = (Action<S2C_SelfFormulaOEMMissionChanged.Request>)Delegate.Remove(S2C_SelfFormulaOEMMissionChanged.OnPushEvent, new Action<S2C_SelfFormulaOEMMissionChanged.Request>(OnPushSelfFormulaOEMMissionChanged));
	}

	public void Destroy()
	{
		UnregisterUiEventListeners();
		ClearCache();
	}

	private void ClearCache()
	{
		_flagShipReqMissionToProtocolList.Clear();
		_submitMissionMuid = -1;
		_selfOemMissions.Clear();
		_oemMissionsModel = null;
	}

	public void RefreshFlagshipMissionsOnAppointedTime(Action<FlagshipMissions> onFinished = null)
	{
		_flagShipReqMissionToProtocolList.Clear();
		GetFlagshipMissions(onFinished, displayWaitingUi: false);
	}

	public void GetFlagshipMissions(Action<FlagshipMissions> onFinished = null, bool displayWaitingUi = true)
	{
		if (_flagShipReqMissionToProtocolList.Count > 0)
		{
			onFinished?.Invoke(new FlagshipMissions
			{
				Missions = _flagShipReqMissionToProtocolList
			});
			return;
		}
		if (displayWaitingUi)
		{
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetFlagShipReq
		{
			Req = new C2S_GetFlagShipReq.Request
			{
				Non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetFlagShipReq.Response response = (C2S_GetFlagShipReq.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				if (displayWaitingUi)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				}
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (response.Missions != null)
				{
					_flagShipReqMissionToProtocolList.AddRange(response.Missions);
				}
				onFinished?.Invoke(new FlagshipMissions
				{
					Missions = _flagShipReqMissionToProtocolList
				});
				if (displayWaitingUi)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				}
			}
		});
	}

	public void SubmitFlagshipMission(int muid)
	{
		_submitMissionMuid = muid;
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_SubmitFlagShipReq
		{
			Req = new C2S_SubmitFlagShipReq.Request
			{
				MUID = muid
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_SubmitFlagShipReq.Response response = (C2S_SubmitFlagShipReq.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
		});
	}

	private void OnPushSubmitFlagShipReq(S2C_SubmitFlagShipReq.Request request)
	{
		if (request.ErrorCode < 0)
		{
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			ILRequestHelper.ShowErrorCode(request.ErrorCode);
			return;
		}
		FlagShipReqMission_ToProtocol flagShipReqMission_ToProtocol = _flagShipReqMissionToProtocolList.Find((FlagShipReqMission_ToProtocol mission) => mission.Uid == _submitMissionMuid);
		if (flagShipReqMission_ToProtocol != null)
		{
			flagShipReqMission_ToProtocol.UpdateFinishCount(request.CurFinishCount);
			OnPushRefreshUi?.Invoke(new FlagshipMissions
			{
				Missions = _flagShipReqMissionToProtocolList
			});
		}
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
	}

	private void OpenMissionsBonusPanel(List<RItem> rewards)
	{
		foreach (RItem reward in rewards)
		{
			ILRequestHelper.ShowMessage($"{Item.Name(GameManagers.Instance, reward.ItemId)}+{reward.cnt}");
		}
	}

	public void GetSelfOemMissions()
	{
		_selfOemMissions.Clear();
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetSelfOEMMissions
		{
			Req = new C2S_GetSelfOEMMissions.Request
			{
				non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetSelfOEMMissions.Response response = (C2S_GetSelfOEMMissions.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (response.OEMMissions != null)
				{
					_selfOemMissions.AddRange(response.OEMMissions);
				}
				UpdateSelfOemMissions?.Invoke(_selfOemMissions);
			}
		});
	}

	public void ClaimSelfOemMissions()
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ClaimSelfOEMMissions
		{
			Req = new C2S_ClaimSelfOEMMissions.Request
			{
				non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_ClaimSelfOEMMissions.Response response = (C2S_ClaimSelfOEMMissions.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Singleton<WorldStateManager>.Instance.Data.PlayerFlagshipInfo.UpdateOEMAmplifiersCanBeReceived(received: false);
				Singleton<WorldStateManager>.Instance.Data.PlayerFlagshipInfo.UpdateOEMAmplifiersHasFailed(hasFailed: false);
				ShowSelfOemMissionsBonus(response.ClaimBonus);
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				Singleton<GvGAmplifierManager>.Instance.NeedSyncStorage = true;
			}
		});
	}

	public void PostSelfOemMission(int ampIdx, bool isExtra)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_PostOEMMission
		{
			Req = new C2S_PostOEMMission.Request
			{
				AmpIdx = ampIdx,
				IsExtra = isExtra
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_PostOEMMission.Response response = (C2S_PostOEMMission.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
		});
	}

	private void OnPushPostOEMMission(S2C_PostOEMMission.Request request)
	{
		if (request.ErrorCode != 0)
		{
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			ILRequestHelper.ShowErrorCode(request.ErrorCode);
		}
		else
		{
			request.SyncGsStockChange();
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
		}
	}

	private void OnPushUpdateSelfOEMMissions(S2C_SelfOEMMissionChanged.Request request)
	{
		SelfOEMMission_ToProtocol selfOEMMission_ToProtocol = _selfOemMissions.Find((SelfOEMMission_ToProtocol m) => m.MUID == request.SelfOEMMission.MUID);
		bool flag = request.SelfOEMMission.State == 6;
		if (selfOEMMission_ToProtocol != null)
		{
			if (flag)
			{
				_selfOemMissions.Remove(selfOEMMission_ToProtocol);
			}
			else
			{
				selfOEMMission_ToProtocol.EndTimestamp = request.SelfOEMMission.EndTimestamp;
				selfOEMMission_ToProtocol.IsCritical = request.SelfOEMMission.IsCritical;
				selfOEMMission_ToProtocol.IsExpired = request.SelfOEMMission.IsExpired;
				selfOEMMission_ToProtocol.IsTitan = request.SelfOEMMission.IsTitan;
				selfOEMMission_ToProtocol.SyncState(request.SelfOEMMission.State);
			}
		}
		else if (!flag)
		{
			_selfOemMissions.Add(request.SelfOEMMission);
		}
		UpdateSelfOemMissions?.Invoke(_selfOemMissions);
	}

	private void ShowSelfOemMissionsBonus(OEMGiverClaimBonus claimBonus)
	{
		if (claimBonus.Amps == null)
		{
			claimBonus.Amps = new List<ForgedExtraAmplifier>();
		}
		if (claimBonus.ReturnCost_ToProtocol == null)
		{
			claimBonus.ReturnCost_ToProtocol = new List<RItem>();
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3OemResult.Name, new Dictionary<string, object> { { "ClaimBonus", claimBonus } });
	}

	public void SubmitOemMission(int mUid, float delay, int ampIdx, Action onFinished = null)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_SubmitOEMMission
		{
			Req = new C2S_SubmitOEMMission.Request
			{
				MUID = mUid
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_SubmitOEMMission.Response response = (C2S_SubmitOEMMission.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				SetGsStock(response.TakerStorehouseChanged);
				ShowOemMissionBonus(response.GiverBonus, response.TakerBonus, delay, ampIdx);
				UpdateOemMissionsState(new List<int> { mUid });
				onFinished?.Invoke();
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
		});
	}

	public void GetOemMissions()
	{
		OemMissionsModel oemMissionsCache = GetOemMissionsCache();
		if (oemMissionsCache != null && !oemMissionsCache.NeedRefresh())
		{
			_oemMissionsModel.Missions.Clear();
			_oemMissionsModel.Missions.AddRange(oemMissionsCache.Missions);
			_oemMissionsModel.NextRefreshTimestamp = oemMissionsCache.NextRefreshTimestamp;
			_oemMissionsModel.IzVersionNumber = oemMissionsCache.IzVersionNumber;
			_oemMissionsModel.NextDayRefreshTimestamp = oemMissionsCache.NextDayRefreshTimestamp;
			List<int> muids = _oemMissionsModel.Missions.Select((OemMissionToProtocol m) => m.Muid).ToList();
			UpdateOemMissionsState(muids);
		}
		else
		{
			GetNewOemMissions();
		}
	}

	public void GetNewOemMissions()
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetOEMMissions
		{
			Req = new C2S_GetOEMMissions.Request
			{
				Non = 0
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetOEMMissions.Response response = (C2S_GetOEMMissions.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (response.OEMMissions != null && response.OEMMissions.Count > 0)
				{
					_oemMissionsModel.SaveNextRefreshTimestamp();
					_oemMissionsModel.Missions.Clear();
					_oemMissionsModel.Missions.AddRange(response.OEMMissions);
					SaveOemMissions(_oemMissionsModel);
				}
				UpdateOemMissions?.Invoke(_oemMissionsModel);
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
		});
	}

	private void UpdateOemMissionsState(List<int> muids)
	{
		if (muids == null || muids.Count <= 0)
		{
			return;
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetOEMMissionsState
		{
			Req = new C2S_GetOEMMissionsState.Request
			{
				MUIDList = muids
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetOEMMissionsState.Response response = (C2S_GetOEMMissionsState.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (response.States != null && response.States.Count > 0)
				{
					foreach (OEMMissionState_ToProtocol state in response.States)
					{
						OemMissionToProtocol oemMissionToProtocol = _oemMissionsModel.Missions.Find((OemMissionToProtocol m) => m.Muid == state.MUID);
						if (oemMissionToProtocol != null)
						{
							oemMissionToProtocol.SyncState(state.State);
							oemMissionToProtocol.IsExpired = state.IsExpired;
						}
					}
					SaveOemMissions(_oemMissionsModel);
				}
				UpdateOemMissions?.Invoke(_oemMissionsModel);
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			}
		});
	}

	public static void SetGsStock(List<RItem> items)
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

	private void ShowOemMissionBonus(OEMGiverBonus giverBonus, OEMTakerBonus takerBonus, float delay, int ampIdx)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		((GComponent)(object)GRoot.inst).SetTimeout(delay).OnComplete(new GTweenCallback(OpenGvG3OemBonus));
		void OpenGvG3OemBonus()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3OemBonus.Name, new Dictionary<string, object>
			{
				{ "GiverBonus", giverBonus.Amps },
				{
					"TakerBonus",
					takerBonus.BonusItems(ampIdx)
				},
				{ "ExtraReward", takerBonus.OEMResult_Formula }
			});
		}
	}

	private OemMissionsModel GetOemMissionsCache()
	{
		string text = PlayerPrefs.GetString(_campOemMissionsKey);
		return string.IsNullOrEmpty(text) ? null : JsonHelper.ToObject<OemMissionsModel>(text);
	}

	private void SaveOemMissions(OemMissionsModel model)
	{
		if (model != null)
		{
			PlayerPrefs.SetString(_campOemMissionsKey, JsonHelper.ToJson(model));
		}
	}

	public void GetFormulaOemMissions(C2S_GetFormulaOEMMissios.Request request, Action<C2S_GetFormulaOEMMissios.Response> onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetFormulaOEMMissios
		{
			Req = request
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetFormulaOEMMissios.Response response = (C2S_GetFormulaOEMMissios.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onFinished?.Invoke(response);
			}
		});
	}

	public void PostFormulaOemMission(int ampIdx, int cnt, Action onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_PostFormulaOEMMission
		{
			Req = new C2S_PostFormulaOEMMission.Request
			{
				AmpIdx = ampIdx,
				Cnt = cnt
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_PostFormulaOEMMission.Response response = (C2S_PostFormulaOEMMission.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onFinished?.Invoke();
			}
		});
	}

	public void GetSelfFormulaOemMissions()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetSelfFormulaOEMMissions
		{
			Req = new C2S_GetSelfFormulaOEMMissions.Request
			{
				non = -1
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetSelfFormulaOEMMissions.Response response = (C2S_GetSelfFormulaOEMMissions.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				OnFormulaOemMissionsSelfRecordsUpdate?.Invoke(response.Records ?? new List<FormulaOEMMissionsSelfRecord>(5));
			}
		});
	}

	private void OnPushPostFormulaOEMMission(S2C_PostFormulaOEMMission.Request request)
	{
		if (request.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(request.ErrorCode);
		}
	}

	private void OnPushSelfFormulaOEMMissionChanged(S2C_SelfFormulaOEMMissionChanged.Request request)
	{
		OnFormulaOemMissionSelfRecordUpdate?.Invoke(request.ChangedMission);
	}
}
