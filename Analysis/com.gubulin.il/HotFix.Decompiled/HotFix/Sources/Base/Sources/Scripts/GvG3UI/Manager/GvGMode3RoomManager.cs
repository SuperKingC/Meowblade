using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using FairyGUI;
using GameDataEditor;
using GvG3;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.BaseSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.Helpers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;

public class GvGMode3RoomManager : Singleton<GvGMode3RoomManager>
{
	private int TryConnectionCount = 0;

	private int Pid;

	private int Port;

	private Coroutine InitDataCoroutine;

	private Coroutine DisconnectRoomCoroutine;

	private bool NeedReloadGSObserverRecord = false;

	private bool _IsRoomClosed = false;

	private Action OnSuccessCallback;

	private Action OnInitBaseInfoCallback;

	private const string GVG3_CLEAR_INSURANCE_SHIP_ID_TIP = "GvG3ClearInsuranceShipIdTip";

	private Stopwatch sw_interval;

	private Stopwatch sw_total;

	public GvGMode3ObserverRecord ObserverRecord;

	public GvGMode3ObserverRecord ObserverRecord_OnGS;

	public SkyIslandPlayerSettlementModel PlayerSettlement;

	public int StopTimestamp = -1;

	public int StartTimestamp = -1;

	public int IZVersionNumber;

	public Action OnRoomClose = delegate
	{
	};

	public Action OnRoomReconnect = delegate
	{
	};

	private Action<string> OnRebuildCallback;

	public Action OnDestroyShip = delegate
	{
	};

	private string RebuildShipId;

	private bool IsRoomStablished = false;

	public Action OnQuickStartReturnMainCity { get; set; } = null;

	public bool IsIZInSettlement => ObserverRecord != null && ((ObserverRecord.LastIZId != -1 && PlayerSettlement != null) || (ObserverRecord.HasEnterIZ && GameController.Instance.GetServerTime() >= StopTimestamp && StopTimestamp > 0));

	public bool IsConnecting => !string.IsNullOrEmpty(SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).CurrentConnectInfo);

	public string CurIzName { get; private set; }

	public bool IsRoomClosed => _IsRoomClosed || !IsConnecting;

	public int BattlePassDataVersion => IsIZInSettlement ? PlayerSettlement.BattlePassVersion : Singleton<WorldStateManager>.Instance.Data.BattlePassDataVersion;

	public bool IsIzOnGoing()
	{
		return ObserverRecord.HasEnterIZ && GameController.Instance.GetServerTime() < StopTimestamp && StopTimestamp > 0;
	}

	public void TryConnectToRoom(Action onSuccess = null, Action onInitBaseInfo = null, Action onError = null, bool forceRefreshObserverRecord = false)
	{
		TryConnectionCount++;
		SentrySdk.AddBreadcrumb($"[GvGMode3RoomManager] TryConnectToRoom() TryConnectionCount={TryConnectionCount}");
		if (DisconnectRoomCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(DisconnectRoomCoroutine);
			DisconnectRoomCoroutine = null;
		}
		if (IsRoomStablished && forceRefreshObserverRecord)
		{
			GetGvGMode3BaseInfo(delegate(C2S_GetGvGMode3BaseInfo.Response res)
			{
				Singleton<WorldStateManager>.Instance.SyncMyOwnState(res.ObserverRecord);
				onInitBaseInfo?.Invoke();
				onSuccess?.Invoke();
			});
		}
		else
		{
			if (IsConnecting)
			{
				onInitBaseInfo?.Invoke();
			}
			else if (onInitBaseInfo != null)
			{
				if (OnInitBaseInfoCallback == null)
				{
					OnInitBaseInfoCallback = onInitBaseInfo;
				}
				else
				{
					OnInitBaseInfoCallback = (Action)Delegate.Combine(OnInitBaseInfoCallback, onInitBaseInfo);
				}
			}
			if (IsRoomStablished)
			{
				onSuccess?.Invoke();
			}
			else if (onSuccess != null)
			{
				if (OnSuccessCallback == null)
				{
					OnSuccessCallback = onSuccess;
				}
				else
				{
					OnSuccessCallback = (Action)Delegate.Combine(OnSuccessCallback, onSuccess);
				}
			}
		}
		if (IsConnecting || TryConnectionCount > 1)
		{
			return;
		}
		StopwatchStart();
		bool isForceSync = !GameManagers.Instance.UserArchiveManager.HasEnterIZ() || NeedReloadGSObserverRecord;
		GameManagers.Instance.UserArchiveManager.GetGvGMode3Record(delegate(GvGMode3Records record)
		{
			NeedReloadGSObserverRecord = record.ObserverRecord.Pid > 0;
			if (isForceSync)
			{
				StopTimestamp = record.StopTimestamp;
				StartTimestamp = record.StartTimestamp;
			}
			ObserverRecord_OnGS = record.ObserverRecord;
			ObserverRecord = record.ObserverRecord;
			string url = HotUpdateProcess.Instance.Configs["SocketHost"];
			Pid = ObserverRecord.Pid;
			Port = ObserverRecord.ExternalSocketPort;
			Action onConnectionError = delegate
			{
				TryConnectionCount = 0;
				onError?.Invoke();
				OnSuccessCallback = null;
				OnInitBaseInfoCallback = null;
			};
			if (ObserverRecord.ObCampId <= 0 || string.IsNullOrEmpty(url))
			{
				ILRuntimeDebug.LogError($"[GvGMode3RoomManager.ConnectToRoom] 当前没有成功报名一个副本，无法连入副本 url={url} campId={ObserverRecord.ObCampId}");
				onConnectionError?.Invoke();
			}
			else
			{
				SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).StartConnect(url, Port, Pid, OnConnectionSuccess, delegate(C2S_RegistUserSessionCommand.Response resp)
				{
					RegistUserFailBitMask registUserFailFlag = (RegistUserFailBitMask)resp.RegistUserFailFlag;
					if (registUserFailFlag == RegistUserFailBitMask.None)
					{
						ILRuntimeDebug.LogError($"[GvGMode3RoomManager.ConnectToRoom] Socket 第一次尝试连接失败！ failFlag={registUserFailFlag}");
						onConnectionError?.Invoke();
					}
					else if ((registUserFailFlag & RegistUserFailBitMask.NoShipJoined) != RegistUserFailBitMask.None)
					{
						SyncInitialShips(delegate
						{
							SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).StartConnect(url, Port, Pid, OnConnectionSuccess, delegate(C2S_RegistUserSessionCommand.Response response)
							{
								ILRuntimeDebug.LogError($"[GvGMode3RoomManager.ConnectToRoom] 同步完初始数据后，Socket 第二次尝试连接失败！ failFlag={response.RegistUserFailFlag}");
								onConnectionError?.Invoke();
							});
						}, onConnectionError);
					}
				});
			}
		}, isForceSync);
	}

	public void TryConnectAndGetObserverRecord(Action onFinished = null, Action onGSRecord = null, Action onGvGRecord = null, Action onError = null)
	{
		bool forceSync = ObserverRecord == null || IsIZInSettlement;
		GameManagers.Instance.UserArchiveManager.GetGvGMode3Record(delegate(GvGMode3Records record)
		{
			StopTimestamp = record.StopTimestamp;
			StartTimestamp = record.StartTimestamp;
			if (record.ObserverRecord.HasEnterIZ && record.ObserverRecord.LastIZId == -1)
			{
				Singleton<GvGMode3RoomManager>.Instance.TryConnectToRoom(onFinished, onGvGRecord, onError);
			}
			else
			{
				ObserverRecord_OnGS = record.ObserverRecord;
				ObserverRecord = record.ObserverRecord;
				if (record.ObserverRecord.LastIZId != -1)
				{
					if (record.PlayerSettlement == null)
					{
						ILRuntimeDebug.LogError($"[GvGMode3RoomManager] LastIZId={record.ObserverRecord.LastIZId} 副本进入结算阶段，但是没有结算信息");
					}
					PlayerSettlement = record.PlayerSettlement;
				}
				onGSRecord?.Invoke();
				onFinished?.Invoke();
			}
		}, forceSync);
	}

	public void GetGSObserverRecord(Action onSuccess = null)
	{
		bool forceSync = ObserverRecord == null || (IsIZInSettlement && PlayerSettlement == null) || NeedReloadGSObserverRecord;
		GameManagers.Instance.UserArchiveManager.GetGvGMode3Record(delegate(GvGMode3Records record)
		{
			StopTimestamp = record.StopTimestamp;
			StartTimestamp = record.StartTimestamp;
			ObserverRecord_OnGS = record.ObserverRecord;
			if (ObserverRecord != null)
			{
				ObserverRecord = MergeRecords(ObserverRecord, ObserverRecord_OnGS);
			}
			else
			{
				ObserverRecord = record.ObserverRecord;
			}
			if (record.ObserverRecord.LastIZId != -1)
			{
				if (record.PlayerSettlement == null)
				{
					ILRuntimeDebug.LogError($"[GvGMode3RoomManager] IZId={record.ObserverRecord.LastIZId} 副本进入结算阶段，但是没有结算信息");
				}
				PlayerSettlement = record.PlayerSettlement;
			}
			onSuccess?.Invoke();
		}, forceSync);
	}

	public void TryDelayDisconnectRoom()
	{
		TryConnectionCount--;
		SentrySdk.AddBreadcrumb($"[GvGMode3RoomManager] TryDelayDisconnectRoom() TryConnectionCount={TryConnectionCount}");
		if (TryConnectionCount <= 0)
		{
			TryConnectionCount = 0;
			if (IsConnecting && DisconnectRoomCoroutine == null)
			{
				DisconnectRoomCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(TryDisconnectRoom());
			}
		}
		IEnumerator TryDisconnectRoom()
		{
			yield return (object)new WaitForSeconds(10f);
			while (InitDataCoroutine != null && !IsConnecting)
			{
				yield return null;
			}
			if (InitDataCoroutine != null)
			{
				((MonoBehaviour)FGUIManager.Instance).StopCoroutine(InitDataCoroutine);
				InitDataCoroutine = null;
			}
			if (TryConnectionCount <= 0 && IsConnecting)
			{
				TryConnectionCount = 0;
				SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).CloseConnect();
				OnDisconnected();
			}
			DisconnectRoomCoroutine = null;
		}
	}

	public void BuildShip(eRace shipRace, int curWorkerCount, bool fastBuild, Action onSuccess)
	{
		ILRequestHelper<GvGMode3BuildShipResponse>.Request((EventContext)null, (Func<Task<GvGMode3BuildShipResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3BuildShip(shipRace.ToString(), curWorkerCount, fastBuild)), (Action<GvGMode3BuildShipResponse>)delegate(GvGMode3BuildShipResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (string.IsNullOrEmpty(response.jsonGvGMode3Record))
				{
					ILRuntimeDebug.LogError("[GvGShipOverviewModel] 请求 GvGMode3BuildShipResponse 后返回 jsonGvGMode3Record 为空");
				}
				GvGMode3ObserverRecord gvGMode3ObserverRecord = JsonHelper.ToObject<GvGMode3ObserverRecord>(response.jsonGvGMode3Record);
				SyncGSObserverRecord(gvGMode3ObserverRecord);
				GameManagers.Instance.UserArchiveManager.SaveGvGMode3Record(gvGMode3ObserverRecord);
				Dictionary<string, int> requirement = ShipConfigHelper.GetByShipRaceType((int)shipRace).Requirement;
				if (requirement != null)
				{
					Dictionary<string, int> dictionary = new Dictionary<string, int>(requirement);
					if (fastBuild)
					{
						Dictionary<string, int> dictionary2 = "GvGMode3FastBuildCost".ToConfiguration<Dictionary<string, int>>();
						if (dictionary2 != null)
						{
							float num = ("I67207".IsActive() ? (1f - "I67207".GetTechData().EffectValue / 100f) : 1f);
							foreach (KeyValuePair<string, int> item in dictionary2)
							{
								if (dictionary.ContainsKey(item.Key))
								{
									dictionary[item.Key] = dictionary[item.Key] + Mathf.RoundToInt((float)item.Value * num);
								}
							}
						}
					}
					StockChangeRecord[] array = new StockChangeRecord[dictionary.Count];
					int num2 = 0;
					foreach (KeyValuePair<string, int> item2 in dictionary)
					{
						array[num2++] = new StockChangeRecord
						{
							ItemId = item2.Key,
							Offset = -item2.Value,
							Context = 7,
							Type = 1
						};
					}
					GameManagers.Instance.StockController.ReadStockChangeRecords(array);
				}
				onSuccess?.Invoke();
				SharedMessenger.Broadcast("ON_SHIP_BUILDING_STATE_CHANGE");
			}
		});
	}

	public void RebuildShip(string shipId, eRace shipRace, int workerCount, bool fastBuild, Action<string> onSuccess)
	{
		if (!IsConnecting || RebuildShipId != null)
		{
			return;
		}
		OnRebuildCallback = onSuccess;
		RebuildShipId = shipId;
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_RebuildShip
		{
			Req = new C2S_RebuildShip.Request
			{
				ShipId = shipId,
				RebuildRace = (int)shipRace,
				WorkerCount = workerCount,
				FastBuild = fastBuild
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_RebuildShip.Response response = (C2S_RebuildShip.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				OnRebuildCallback = null;
				RebuildShipId = null;
			}
		});
	}

	public void OnPushRebuildShip(S2C_RebuildShip.Request request)
	{
		if (request.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(request.ErrorCode);
			OnRebuildCallback = null;
			RebuildShipId = null;
			return;
		}
		if (string.IsNullOrEmpty(request.jsonGvGMode3Record))
		{
			ILRuntimeDebug.LogError("[OnPushRebuildShip] S2C_RebuildShip jsonGvGMode3Record 为空");
		}
		GvGMode3ObserverRecord gvGMode3ObserverRecord = JsonHelper.ToObject<GvGMode3ObserverRecord>(request.jsonGvGMode3Record);
		SyncGSObserverRecord(gvGMode3ObserverRecord);
		GameManagers.Instance.UserArchiveManager.SaveGvGMode3Record(gvGMode3ObserverRecord);
		int shipRace = gvGMode3ObserverRecord.Ships.Find((GvGMode3ShipModel ship) => ship.ShipId == RebuildShipId).PermanentData.ShipRace;
		Dictionary<string, int> rebuildRequirement = ShipConfigHelper.GetByShipRaceType(shipRace).RebuildRequirement;
		if (rebuildRequirement != null)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>(rebuildRequirement);
			if (request.FastBuild)
			{
				Dictionary<string, int> dictionary2 = "GvGMode3FastBuildCost".ToConfiguration<Dictionary<string, int>>();
				if (dictionary2 != null)
				{
					float num = ("I67207".IsActive() ? (1f - "I67207".GetTechData().EffectValue / 100f) : 1f);
					foreach (KeyValuePair<string, int> item in dictionary2)
					{
						if (dictionary.ContainsKey(item.Key))
						{
							dictionary[item.Key] = dictionary[item.Key] + Mathf.RoundToInt((float)item.Value * num);
						}
					}
				}
			}
			StockChangeRecord[] array = new StockChangeRecord[dictionary.Count];
			int num2 = 0;
			foreach (KeyValuePair<string, int> item2 in dictionary)
			{
				array[num2++] = new StockChangeRecord
				{
					ItemId = item2.Key,
					Offset = -item2.Value,
					Context = 7,
					Type = 1
				};
			}
			GameManagers.Instance.StockController.ReadStockChangeRecords(array);
		}
		Singleton<WorldStateManager>.Instance.ClearInsuranceShip(RebuildShipId);
		SyncObserverShip(RebuildShipId, delegate
		{
			if (GvGWorldMapController.IsInstanceCreated)
			{
				GvGWorldMapController.Instance.LoaderManager.ReloadShips();
			}
			OnRebuildCallback?.Invoke(RebuildShipId);
			OnRebuildCallback = null;
			RebuildShipId = null;
			SharedMessenger.Broadcast("ON_SHIP_BUILDING_STATE_CHANGE");
		});
	}

	public void AcceptShip(string shipId, Action onSuccess)
	{
		ILRequestHelper<GvGMode3AcceptShipResponse>.Request((EventContext)null, (Func<Task<GvGMode3AcceptShipResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3AcceptShip(shipId)), (Action<GvGMode3AcceptShipResponse>)delegate(GvGMode3AcceptShipResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (string.IsNullOrEmpty(response.jsonGvGMode3Record))
				{
					ILRuntimeDebug.LogError("[GvGShipOverviewModel] 请求 GvGMode3AcceptShipResponse 后返回 jsonGvGMode3Record 为空");
				}
				GvGMode3ObserverRecord gvGMode3ObserverRecord = JsonHelper.ToObject<GvGMode3ObserverRecord>(response.jsonGvGMode3Record);
				SyncGSObserverRecord(gvGMode3ObserverRecord);
				GameManagers.Instance.UserArchiveManager.SaveGvGMode3Record(gvGMode3ObserverRecord);
				if (ObserverRecord.HasEnterIZ && IsConnecting)
				{
					SyncObserverShip(shipId, delegate
					{
						if (GvGWorldMapController.IsInstanceCreated)
						{
							GvGWorldMapController.Instance.LoaderManager.ReloadShips();
						}
						onSuccess?.Invoke();
						SharedMessenger.Broadcast("ON_SHIP_BUILDING_STATE_CHANGE");
					});
				}
				else
				{
					onSuccess?.Invoke();
					SharedMessenger.Broadcast("ON_SHIP_BUILDING_STATE_CHANGE");
				}
			}
		});
	}

	public void CheckShipIsNotInsurance(string shipId, Action onSuccess)
	{
		if (!ObserverRecord.HasEnterIZ)
		{
			onSuccess();
		}
		else if (shipId == Singleton<WorldStateManager>.Instance.Data.InsuranceShipId)
		{
			"GvG3ClearInsuranceShipIdTip".ToLanguage().ToConfirmPopup(onSuccess, null, (AlignType)0);
		}
		else
		{
			onSuccess();
		}
	}

	public void DestroyShip(string shipId, Action onSuccess)
	{
		ILRequestHelper<GvGMode3DestroyShipResponse>.Request((EventContext)null, (Func<Task<GvGMode3DestroyShipResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3DestroyShip(shipId)), (Action<GvGMode3DestroyShipResponse>)delegate(GvGMode3DestroyShipResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GvGMode3ObserverRecord gvGMode3ObserverRecord = JsonHelper.ToObject<GvGMode3ObserverRecord>(response.jsonGvGMode3Record);
				SyncGSObserverRecord(gvGMode3ObserverRecord);
				GameManagers.Instance.UserArchiveManager.SaveGvGMode3Record(gvGMode3ObserverRecord);
				if (IsConnecting)
				{
					Singleton<GvGAmplifierManager>.Instance.NeedSyncStorage = true;
					if (GvGWorldMapController.IsInstanceCreated)
					{
						GvGWorldMapController.Instance.LoaderManager.ReloadShips();
					}
					Singleton<WorldStateManager>.Instance.ClearInsuranceShip(shipId);
				}
				onSuccess?.Invoke();
				SharedMessenger.Broadcast("ON_GVG3_SHIP_DESTROY");
			}
		});
	}

	private void OnPushDestroyShip(S2C_DestroyShip.Request request)
	{
		if (request.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(request.ErrorCode);
			return;
		}
		ObserverRecord.Ships.RemoveAll((GvGMode3ShipModel _model) => _model.ShipId == request.ShipId);
		ObserverRecord_OnGS.Ships.RemoveAll((GvGMode3ShipModel _model) => _model.ShipId == request.ShipId);
		SyncShipOrder(request.Order);
		GameManagers.Instance.UserArchiveManager.SaveGvGMode3Record(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord_OnGS);
		Singleton<GvGAmplifierManager>.Instance.NeedSyncStorage = true;
		if (GvGWorldMapController.IsInstanceCreated)
		{
			GvGWorldMapController.Instance.LoaderManager.ReloadShips();
		}
		OnDestroyShip?.Invoke();
	}

	public void LaunchShip(int shipEntityId, int islandId, Action onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_LaunchShip
		{
			Req = new C2S_LaunchShip.Request
			{
				ShipEntityId = shipEntityId,
				IslandId = islandId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_LaunchShip.Response response = (C2S_LaunchShip.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GvGMode3ShipModel gvGMode3ShipModel = ObserverRecord.Ships.Find((GvGMode3ShipModel ship) => ship.TemporaryData.EntityId == shipEntityId);
				gvGMode3ShipModel.PermanentData.HasLaunch = true;
				gvGMode3ShipModel.TemporaryData.TargetIslandId = response.ShipTargetIslandId;
				gvGMode3ShipModel.TemporaryData.ShipState = (eShipState)response.ShipState;
				string shipId = gvGMode3ShipModel.ShipId;
				gvGMode3ShipModel = ObserverRecord_OnGS.Ships.Find((GvGMode3ShipModel ship) => ship.ShipId == shipId);
				gvGMode3ShipModel.PermanentData.HasLaunch = true;
				GameManagers.Instance.UserArchiveManager.SaveGvGMode3Record(ObserverRecord_OnGS);
				SyncObserverShip(shipId, delegate
				{
					if (GvGWorldMapController.IsInstanceCreated)
					{
						GvGWorldMapController.Instance.LoaderManager.ReloadShips();
					}
					onFinished?.Invoke();
					SharedMessenger.Broadcast("ON_SHIP_BUILDING_STATE_CHANGE");
				});
			}
		});
	}

	public void ChangeShipName(string shipId, string newName, Action<string> onFinished = null)
	{
		ILRequestHelper<GvGMode3ChangeShipConfigResponse>.Request((EventContext)null, (Func<Task<GvGMode3ChangeShipConfigResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3ChangeShipConfig(shipId, 0, JsonHelper.ToJson(new GvGMode3ChangeShipConfigAction_ChangeName
		{
			Name = newName
		}))), (Action<GvGMode3ChangeShipConfigResponse>)delegate(GvGMode3ChangeShipConfigResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				newName = response.json;
				ObserverRecord_OnGS.GetMyShipData(shipId).PermanentData.ShipName = newName;
				ObserverRecord.GetMyShipData(shipId).PermanentData.ShipName = newName;
				GvGMode3ObserverRecord gvGMode3ObserverRecord = GameManagers.Instance.UserArchiveManager.LoadGvGMode3Record();
				GvGMode3ShipModel gvGMode3ShipModel = gvGMode3ObserverRecord.Ships.FirstOrDefault((GvGMode3ShipModel ship) => ship.ShipId == shipId);
				gvGMode3ShipModel.PermanentData.ShipName = newName;
				GameManagers.Instance.UserArchiveManager.SaveGvGMode3Record(gvGMode3ObserverRecord);
				onFinished?.Invoke(newName);
			}
		});
	}

	public void ChangeShipOrder(int index, int dir, Action onSuccess = null)
	{
		List<GvGMode3ShipModel> ships = ObserverRecord.Ships;
		if (index < 0 || index >= ships.Count || dir < -1 || dir > 1 || (index == 0 && dir == -1) || (index == ships.Count - 1 && dir == 1))
		{
			ILRuntimeDebug.LogError($"[GvGMode3RoomManager] ChangeShipOrder参数错误 index={index} dir={dir} Ships.Count={ships.Count}");
			return;
		}
		List<GvGMode3ShipModel> list = new List<GvGMode3ShipModel>();
		for (int i = 0; i < ships.Count; i++)
		{
			GvGMode3ShipModel gvGMode3ShipModel = ships[i];
			if (gvGMode3ShipModel.PermanentData.Index == -1)
			{
				break;
			}
			list.Add(gvGMode3ShipModel);
		}
		list.InsertionSort((GvGMode3ShipModel a, GvGMode3ShipModel b) => a.PermanentData.Index.CompareTo(b.PermanentData.Index));
		Dictionary<int, string> order = new Dictionary<int, string>();
		for (int num = 0; num < list.Count; num++)
		{
			order[num] = list[num].ShipId;
		}
		string value = order[index];
		string value2 = order[index + dir];
		order[index] = value2;
		order[index + dir] = value;
		ILRequestHelper<GvGMode3ShipChangeOrderResponse>.Request((EventContext)null, (Func<Task<GvGMode3ShipChangeOrderResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3ShipChangeOrder(order)), (Action<GvGMode3ShipChangeOrderResponse>)delegate(GvGMode3ShipChangeOrderResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GvGMode3ShipModel value3 = ships[index];
				GvGMode3ShipModel value4 = ships[index + dir];
				ships[index] = value4;
				ships[index + dir] = value3;
				for (int j = 0; j < ships.Count && ships[j].PermanentData.Index != -1; j++)
				{
					ships[j].PermanentData.Index = j;
				}
				SyncGSObserverRecord(ObserverRecord);
				GameManagers.Instance.UserArchiveManager.SaveGvGMode3Record(ObserverRecord_OnGS);
				SharedMessenger.Broadcast("ON_SHIP_BUILDING_STATE_CHANGE");
				onSuccess?.Invoke();
			}
		});
	}

	public void SyncGSObserverRecord(GvGMode3ObserverRecord gsRecord)
	{
		ObserverRecord_OnGS = gsRecord;
		ObserverRecord = MergeRecords(ObserverRecord, ObserverRecord_OnGS);
	}

	public void SyncGvGObserverRecord(GvGMode3ObserverRecord gvgRecord)
	{
		ObserverRecord = MergeRecords(gvgRecord, ObserverRecord_OnGS);
	}

	public void SyncObserverShip(string shipId, Action onSuccess = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetGvGMode3ShipTemporaryData
		{
			Req = new C2S_GetGvGMode3ShipTemporaryData.Request
			{
				ShipId = shipId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetGvGMode3ShipTemporaryData.Response response = (C2S_GetGvGMode3ShipTemporaryData.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GvGMode3ShipModel gvGMode3ShipModel = ObserverRecord.Ships.Find((GvGMode3ShipModel ship) => ship.ShipId == shipId);
				gvGMode3ShipModel.TemporaryData = response.ShipTemporaryData;
				Singleton<WorldStateManager>.Instance.SyncNewShipFromRecord(shipId, ObserverRecord);
				onSuccess?.Invoke();
			}
		});
	}

	public void SyncObserverShipLaunchState(int entityId, int islandId)
	{
		ShipStateModel shipStateModel = Singleton<WorldStateManager>.Instance.TryGetShip(entityId);
		shipStateModel.State = eShipState.Stay;
		shipStateModel.StayIslandId = islandId;
		GvGMode3ShipModel gvGMode3ShipModel = ObserverRecord.Ships.Find((GvGMode3ShipModel ship) => ship.TemporaryData != null && ship.TemporaryData.EntityId == entityId);
		gvGMode3ShipModel.TemporaryData.ShipState = eShipState.Stay;
		gvGMode3ShipModel.TemporaryData.TargetIslandId = islandId;
	}

	public void SyncShipCountLimit(int newCount)
	{
		ObserverRecord.ShipCountLimit = newCount;
		ObserverRecord_OnGS.ShipCountLimit = newCount;
	}

	public void SyncShipOrder(Dictionary<string, int> order)
	{
		ObserverRecord.UpdateShipOrder(order);
		ObserverRecord_OnGS.UpdateShipOrder(order);
	}

	public void SyncShipSightRange(int shipSightRange)
	{
		ObserverRecord.ShipSightRange = shipSightRange;
		ObserverRecord_OnGS.ShipSightRange = shipSightRange;
	}

	public void SyncShipSoulGuideCDTimestamp(int entityId, int timestamp)
	{
		GvGMode3ShipModel gvGMode3ShipModel = ObserverRecord.Ships.Find((GvGMode3ShipModel ship) => ship.TemporaryData != null && ship.TemporaryData.EntityId == entityId);
		gvGMode3ShipModel.TemporaryData.SoulGuideCDTimestamp = timestamp;
	}

	public void GvGMode3CloseLastBattlePass(Action onFinished = null)
	{
		ILRequestHelper<GvGMode3CloseBattlePassResponse>.Request((EventContext)null, (Func<Task<GvGMode3CloseBattlePassResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3CloseBattlePass(ObserverRecord.LastIZId)), (Action<GvGMode3CloseBattlePassResponse>)delegate(GvGMode3CloseBattlePassResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (PlayerSettlement != null)
				{
					PlayerSettlement.GvGBattlePassRecordIsClosed = true;
				}
				onFinished?.Invoke();
			}
		});
	}

	public void GvGMode3ClaimLastBattlePassBonus(string activityId, string node, Action onFinished = null)
	{
		ILRequestHelper<GvGMode3ClaimBattlePassBonusResponse>.Request((EventContext)null, (Func<Task<GvGMode3ClaimBattlePassBonusResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3ClaimBattlePassBonus(ObserverRecord.LastIZId, activityId, node)), (Action<GvGMode3ClaimBattlePassBonusResponse>)delegate(GvGMode3ClaimBattlePassBonusResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				PlayerSettlement.GvGBattlePassRecord[activityId] = (string.IsNullOrEmpty(response.BattlePassClaimedBonus) ? new List<int>() : JsonHelper.ToObject<List<int>>(response.BattlePassClaimedBonus));
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				DisplayStockChangeTips(response.StockChangeRecords);
				onFinished?.Invoke();
			}
		});
	}

	public static void DisplayStockChangeTips(List<StockChangeRecord> records)
	{
		foreach (StockChangeRecord record in records)
		{
			if (record.Offset > 0)
			{
				string oldItemId = record.ItemId;
				FGUIManager.Instance.ItemIdReplace(ref oldItemId);
				string arg = global::Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, oldItemId);
				ILRequestHelper.ShowMessage($"{arg}+{record.Offset}");
			}
		}
	}

	public void RefreshLastBattlePassData(Action onFinished = null)
	{
		ILRequestHelper<GvGMode3GetBattlePassDataResponse>.Request((EventContext)null, (Func<Task<GvGMode3GetBattlePassDataResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3GetBattlePassData(ObserverRecord.LastIZId)), (Action<GvGMode3GetBattlePassDataResponse>)delegate(GvGMode3GetBattlePassDataResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (PlayerSettlement != null)
				{
					PlayerSettlement.ContributionPoints = response.ContributionPoints;
					PlayerSettlement.HasAdvancedPass = response.HasAdvancedPass;
					PlayerSettlement.HasPremiumPass = response.HasPremiumPass;
					PlayerSettlement.BattlePassVersion = response.BattlePassVersion;
				}
				onFinished?.Invoke();
			}
		});
	}

	public void ClaimAllSettlementLeaderboardBonuses(Action onSuccess, Action onFailed)
	{
		List<int> list = new List<int>();
		if (!PlayerSettlement.CampRewardIsClaimed)
		{
			list.Add(7);
		}
		foreach (KeyValuePair<eLeaderboardType, SettlementRankData> selfRankData in PlayerSettlement.selfRankDatas)
		{
			if (!selfRankData.Value.HasClaimed)
			{
				list.Add((int)selfRankData.Key);
			}
		}
		foreach (KeyValuePair<eLeaderboardType, SettlementRankData> selfFinalProgressRankData in PlayerSettlement.selfFinalProgressRankDatas)
		{
			if (!selfFinalProgressRankData.Value.HasClaimed)
			{
				list.Add((int)selfFinalProgressRankData.Key);
			}
		}
		list.Add(20);
		ClaimSettlementLeaderboardBonus(list, onSuccess, onFailed);
	}

	public void ClaimSingleSettlementLeaderboardBonus(eLeaderboardType lbType, Action onSuccess, Action onFailed)
	{
		List<int> waitToClaim = new List<int> { (int)lbType };
		ClaimSettlementLeaderboardBonus(waitToClaim, onSuccess, onFailed);
	}

	public void CloseLastIZRoom(Action onSuccess, Action onFailed)
	{
		int lastIzId = ObserverRecord.LastIZId;
		ILRequestHelper<GvGMode3CloseLastIZResponse>.Request((EventContext)null, (Func<Task<GvGMode3CloseLastIZResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3CloseLastIZ(ObserverRecord.LastIZId)), (Action<GvGMode3CloseLastIZResponse>)delegate(GvGMode3CloseLastIZResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFailed?.Invoke();
			}
			else
			{
				ObserverRecord = null;
				PlayerSettlement = null;
				GetGSObserverRecord(onSuccess);
				if (response.ClearPurchaseStat != null)
				{
					foreach (string item in response.ClearPurchaseStat)
					{
						if (GameManagers.Instance.StoreManager.PurchaseStat.GetValue().PurchaseStat.ContainsKey(item))
						{
							GameManagers.Instance.StoreManager.PurchaseStat.GetValue().PurchaseStat.Remove(item);
							GameManagers.Instance.StoreManager.PurchaseStat.Save();
						}
					}
				}
				ProcessSoldierReturn(response.JsonSoldierReturns);
				GameManagers.Instance.UserArchiveManager.AddGvGMode3CompletedHistory(lastIzId.ToString());
				SharedMessenger.Broadcast("ON_PUSH_GIFT_BAG_REFRESH");
			}
		});
		static void ProcessSoldierReturn(string jsonReturn)
		{
			if (!string.IsNullOrEmpty(jsonReturn))
			{
				GvG3SettlementSoldierReturn gvG3SettlementSoldierReturn = JsonHelper.ToObject<GvG3SettlementSoldierReturn>(jsonReturn);
				GameManagers.Instance.UserArchiveManager.ClearGvGShipPlanSoldierStockChangeInfos();
				StockChangeRecord[] stockChangeRecords = gvG3SettlementSoldierReturn.ShipPlanRemainingSoldiers.ToStockChangeRecords(StockInContext.GvGMode3_ReturnSoldier_ShipPlanRemaining_WhenCloseLastIZ);
				GameManagers.Instance.StockController.ReadStockChangeRecords(stockChangeRecords);
				StockChangeRecord[] stockChangeRecords2 = gvG3SettlementSoldierReturn.SoldierInShips.ToStockChangeRecords(StockInContext.GvGMode3_ChangeSoldierWhenCloseLastIZ);
				GameManagers.Instance.StockController.ReadStockChangeRecords(stockChangeRecords2);
			}
		}
	}

	public void RecordIzTitle(string title)
	{
		CurIzName = title;
	}

	public override void InitInstance()
	{
		S2C_SystemPause.OnPushEvent = (Action<S2C_SystemPause.Request>)Delegate.Combine(S2C_SystemPause.OnPushEvent, new Action<S2C_SystemPause.Request>(OnPushSystemPause));
		S2C_SystemIZOver.OnPushEvent = (Action<S2C_SystemIZOver.Request>)Delegate.Combine(S2C_SystemIZOver.OnPushEvent, new Action<S2C_SystemIZOver.Request>(OnPushSystemClose));
		S2C_RebuildShip.OnPushEvent = (Action<S2C_RebuildShip.Request>)Delegate.Combine(S2C_RebuildShip.OnPushEvent, new Action<S2C_RebuildShip.Request>(OnPushRebuildShip));
		S2C_DestroyShip.OnPushEvent = (Action<S2C_DestroyShip.Request>)Delegate.Combine(S2C_DestroyShip.OnPushEvent, new Action<S2C_DestroyShip.Request>(OnPushDestroyShip));
		SharedMessenger.AddListener("ON_SOCKET_ERROR", OnSocketError);
		SharedMessenger.AddListener("ON_SOCKET_RECONNECT", OnReconnectionSuccess);
	}

	private void OnPushSystemPause(S2C_SystemPause.Request req)
	{
		_IsRoomClosed = true;
		IsRoomStablished = false;
		SentrySdk.AddBreadcrumb("[GvGMode3RoomManager] OnPushSystemPause PauseMessage=" + req.PauseMessage);
		UiHelper.ShowConfirmDialog(req.PauseMessage, null);
		ForceDisconnectRoom();
	}

	private void OnPushSystemClose(S2C_SystemIZOver.Request req)
	{
		_IsRoomClosed = true;
		IsRoomStablished = false;
		SentrySdk.AddBreadcrumb($"[GvGMode3RoomManager] OnPushSystemClose() Reason={req.Reason}");
		UiHelper.ShowConfirmDialog($"GvG3_SystemIZOver_{req.Reason}".ToLanguage(), null);
		ForceDisconnectRoom();
	}

	private void OnSocketError()
	{
		SentrySdk.AddBreadcrumb("[GvGMode3RoomManager] OnSocketError() socket 连不上");
	}

	private void OnConnectionSuccess()
	{
		StopwatchLogInterval("Socket连接成功");
		SentrySdk.AddBreadcrumb($"[GvGMode3RoomManager] OnConnectionSuccess() Socket 连接成功 port:{Port} pid:{Pid} timeStamp:{DateTimeHelper.TimeStamp}，开始请求基本数据");
		_IsRoomClosed = false;
		ObserverRecord_OnGS.HasEnterIZ = true;
		GetGvGMode3BaseInfo(delegate(C2S_GetGvGMode3BaseInfo.Response baseInfo)
		{
			StopwatchLogInterval("拿到BaseInfo");
			InitDataCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(OnInitData(baseInfo));
		});
	}

	private void OnReconnectionSuccess()
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		SentrySdk.AddBreadcrumb($"[GvGMode3RoomManager] OnConnectionSuccess() Socket 重新连接成功 port:{Port} pid:{Pid} timeStamp:{DateTimeHelper.TimeStamp}，开始请求基本数据");
		_IsRoomClosed = false;
		GetGvGMode3BaseInfo(delegate(C2S_GetGvGMode3BaseInfo.Response baseInfo)
		{
			OnSuccessCallback = delegate
			{
				OnRoomReconnect?.Invoke();
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
			};
			InitDataCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(OnInitData(baseInfo));
		});
	}

	private void OnDisconnected()
	{
		SentrySdk.AddBreadcrumb("[GvGMode3RoomManager] OnDisconnected() 已断开与副本的连接");
		_IsRoomClosed = true;
		IsRoomStablished = false;
		OnClearData();
	}

	private IEnumerator OnInitData(C2S_GetGvGMode3BaseInfo.Response baseInfo)
	{
		Singleton<WorldStateManager>.Instance.Init(ObserverRecord);
		Singleton<WorldStateManager>.Instance.InitBaseInfo_MiniData(baseInfo);
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).CurrentConnectInfo = $"{Port}_{Pid}";
		OnInitBaseInfoCallback?.Invoke();
		OnInitBaseInfoCallback = null;
		yield return Singleton<WorldStateManager>.Instance.InitBaseInfo_BigData(baseInfo);
		StopwatchLogInterval("OnInitData - WorldStateManager");
		yield return AmpConfigHelper.InitCoroutine(ObserverRecord.IZConfigId);
		StopwatchLogInterval("OnInitData - AmpConfigHelper");
		yield return (object)new WaitForSeconds(0.5f);
		Singleton<GvGIslandFilterManager>.Instance.Init(ObserverRecord, baseInfo.CampFlagshipIslandOfInterest);
		Singleton<WorldStateManager>.Instance.RegisterSocketEvents();
		Singleton<GvGShipUiInfoManager>.Instance.RegisterSocketEvents();
		Singleton<GvGAmplifierManager>.Instance.RegisterSocketEvents();
		Singleton<GvG3BattlePassManager>.Instance.RegisterSocketEvents();
		Singleton<GvGIslandFilterManager>.Instance.RegisterSocketEvents();
		Singleton<SyncGsStockManager>.Instance.RegisterSync();
		InitDataCoroutine = null;
		StopwatchLogInterval("OnInitData 初始化完毕");
		IsRoomStablished = true;
		OnSuccessCallback?.Invoke();
		OnSuccessCallback = null;
		yield return null;
		if (Singleton<GvGTalent勘探强化Manager>.Instance.IsActive())
		{
			Singleton<GvGTalent勘探强化Manager>.Instance.SyncShipCountDown();
		}
		yield return (object)new WaitForSeconds(2f);
		Singleton<GvG3BattlePassManager>.Instance.CheckClaimable();
		yield return (object)new WaitForSeconds(1f);
		Singleton<GvG3StoreManager>.Instance.CheckGvGStoreNotice();
		yield return (object)new WaitForSeconds(1f);
		Singleton<GvG3StoreManager>.Instance.CheckSoulKeyStoreNotice();
		yield return (object)new WaitForSeconds(1f);
		Singleton<GvGAmplifierManager>.Instance.GetGvGAmplifierData();
	}

	private void OnClearData()
	{
		Singleton<WorldStateManager>.Instance.UnregisterSocketEvents();
		Singleton<GvGShipUiInfoManager>.Instance.UnregisterSocketEvents();
		Singleton<GvGAmplifierManager>.Instance.UnregisterSocketEvents();
		Singleton<GvG3BattlePassManager>.Instance.UnregisterSocketEvents();
		Singleton<GvGIslandFilterManager>.Instance.UnregisterSocketEvents();
		Singleton<SyncGsStockManager>.Instance.UnregisterSync();
		Singleton<WorldStateManager>.Instance.ClearData();
		Singleton<GvGAmplifierManager>.Instance.ClearData();
		Singleton<GvGStoreHouseManager>.Instance.ClearData();
		Singleton<GvGIslandFilterManager>.Instance.ClearCheckRecord();
	}

	private void ForceDisconnectRoom()
	{
		SentrySdk.AddBreadcrumb("[GvGMode3RoomManager] ForceDisconnectRoom() 强制断开副本");
		TryConnectionCount = 0;
		if (InitDataCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(InitDataCoroutine);
			InitDataCoroutine = null;
		}
		if (DisconnectRoomCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(DisconnectRoomCoroutine);
			DisconnectRoomCoroutine = null;
		}
		if (IsConnecting)
		{
			SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).CloseConnect();
		}
		NeedReloadGSObserverRecord = true;
		OnRoomClose?.Invoke();
		OnDisconnected();
	}

	public void GetGvGMode3BaseInfo(Action<C2S_GetGvGMode3BaseInfo.Response> onSucces)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetGvGMode3BaseInfo
		{
			Req = new C2S_GetGvGMode3BaseInfo.Request()
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetGvGMode3BaseInfo.Response response = (C2S_GetGvGMode3BaseInfo.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				IZVersionNumber = response.IZVersionNumber;
				SyncGvGObserverRecord(response.ObserverRecord);
				onSucces?.Invoke(response);
			}
		});
	}

	private void SyncInitialShips(Action onSucces = null, Action onError = null)
	{
		GameManagers.Instance.UserArchiveManager.GetGvGMode3Record(delegate(GvGMode3Records record)
		{
			GvGMode3ObserverRecord obRecord = record.ObserverRecord;
			if (obRecord.Ships == null || obRecord.Ships.Count == 0)
			{
				ILRuntimeDebug.LogError("[GvGMode3RoomManager.SyncFirstShip] 投放飞空艇时，飞空艇列表为空");
				onError?.Invoke();
			}
			else
			{
				List<string> shipIds = new List<string>();
				foreach (GvGMode3ShipModel ship in obRecord.Ships)
				{
					shipIds.Add(ship.ShipId);
				}
				ILRequestHelper<GvGMode3JoinShipToRoomResponse>.Request((EventContext)null, (Func<Task<GvGMode3JoinShipToRoomResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3JoinShipToRoom(obRecord.IZConfigId, obRecord.CurIZId, shipIds)), (Action<GvGMode3JoinShipToRoomResponse>)delegate(GvGMode3JoinShipToRoomResponse response)
				{
					if (response.ErrorCode != 0)
					{
						ILRequestHelper.ShowErrorCode(response.ErrorCode);
						ILRuntimeDebug.LogError($"[GvGMode3RoomManager.SyncFirstShip] ErrorCode = {response.ErrorCode}");
						onError?.Invoke();
					}
					else
					{
						foreach (GvGMode3ShipModel ship2 in obRecord.Ships)
						{
							ship2.PermanentData.IsJoinIZ = true;
							ship2.PermanentData.HasLaunch = true;
						}
						onSucces?.Invoke();
						GameManagers.Instance.UserArchiveManager.SetConfigValue("GvGSoldiersEquippedItems", JsonHelper.ToObject<SoldiersEquippedItems>(response.jsonGvGSoldiersEquippedItems));
					}
				});
			}
		});
	}

	private GvGMode3ObserverRecord MergeRecords(GvGMode3ObserverRecord gvgRecord, GvGMode3ObserverRecord gsRecord)
	{
		gvgRecord.ObCampId = gsRecord.ObCampId;
		gvgRecord.CurIZId = gsRecord.CurIZId;
		gvgRecord.IZConfigId = gsRecord.IZConfigId;
		gvgRecord.LastIZId = gsRecord.LastIZId;
		gvgRecord.HasEnterIZ = gsRecord.HasEnterIZ;
		gvgRecord.ExternalSocketPort = gsRecord.ExternalSocketPort;
		gvgRecord.Pid = gsRecord.Pid;
		List<GvGMode3ShipModel> list = new List<GvGMode3ShipModel>();
		foreach (GvGMode3ShipModel gsShip in gsRecord.Ships)
		{
			GvGMode3ShipModel gvGMode3ShipModel = gvgRecord.Ships.Find((GvGMode3ShipModel s) => s.ShipId == gsShip.ShipId);
			if (gvGMode3ShipModel == null)
			{
				list.Add(gsShip);
				continue;
			}
			gvGMode3ShipModel.PermanentData = gsShip.PermanentData;
			list.Add(gvGMode3ShipModel);
		}
		gvgRecord.Ships = list;
		return gvgRecord;
	}

	private void ClaimSettlementLeaderboardBonus(List<int> waitToClaim, Action onSuccess, Action onFailed)
	{
		ILRequestHelper<GvGMode3ClaimSettlementResponse>.Request((EventContext)null, (Func<Task<GvGMode3ClaimSettlementResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3ClaimSettlement(ObserverRecord.LastIZId, waitToClaim)), (Action<GvGMode3ClaimSettlementResponse>)delegate(GvGMode3ClaimSettlementResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFailed?.Invoke();
			}
			else
			{
				foreach (StockChangeRecord stockChangeRecord in response.StockChangeRecords)
				{
					if (stockChangeRecord.Offset > 0)
					{
						ILRequestHelper.ShowMessage($"{GDMgr.Get<GDEItemData>(stockChangeRecord.ItemId).Name}+{stockChangeRecord.Offset}");
					}
				}
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				foreach (int item in waitToClaim)
				{
					SettlementRankData value;
					SettlementRankData value2;
					if (item == 7)
					{
						PlayerSettlement.CampRewardIsClaimed = true;
					}
					else if (PlayerSettlement.selfRankDatas.TryGetValue((eLeaderboardType)item, out value))
					{
						value.HasClaimed = true;
					}
					else if (PlayerSettlement.selfFinalProgressRankDatas.TryGetValue((eLeaderboardType)item, out value2))
					{
						value2.HasClaimed = true;
					}
				}
				PlayerSettlement.AmplifierDetail_RewardIsClaimed = true;
				onSuccess?.Invoke();
			}
		});
	}

	public void StopwatchStart()
	{
		if (sw_total == null && sw_interval == null)
		{
			sw_total = new Stopwatch();
			sw_interval = new Stopwatch();
			sw_total.Start();
			sw_interval.Start();
			SentrySdk.AddBreadcrumb("[副本加载流程] 开始加载");
		}
	}

	public void StopwatchLogInterval(string msg)
	{
		if (sw_interval != null)
		{
			SentrySdk.AddBreadcrumb("[副本加载流程] " + msg);
			sw_interval.Restart();
		}
	}

	public void StopwatchStop()
	{
		if (sw_total != null && sw_interval != null)
		{
			sw_total.Stop();
			sw_interval.Stop();
			SentrySdk.AddBreadcrumb("[副本加载流程] 结束加载");
			sw_total = null;
			sw_interval = null;
		}
	}
}
