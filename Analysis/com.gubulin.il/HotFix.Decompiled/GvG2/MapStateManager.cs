using System;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using GvG2.Common.Models;
using Shift.Legion;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvGServer.Models.BaseSocket;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using Shift.Legion.Helpers;
using UI.GvGWorldMap2;
using UnityEngine;

namespace GvG2;

public class MapStateManager
{
	public class IslandStopInfo
	{
		public int IslandId;

		public int IslandScore;

		public int WinnerCamp;
	}

	private MapEntryManager MapEntryManager;

	private MapVfxManager MapVfxManager;

	private MapDataManager MapDataManager;

	private ShipManager ShipManager;

	private FlightManager FlightManager;

	private MonoBehaviour ParentController;

	private Coroutine InitProcessCoroutine;

	private Coroutine UpdateMyShipSummaryCoroutine;

	public int MyCampId;

	public Island MyCampIsland;

	public C2S_GetShipSummaryAndFlightScheduleInfo MyShipSummary;

	public Ship MyShip;

	public Action<Island> OnInitCampIsland = delegate
	{
	};

	public Action<MapStateManager> OnInitCampIslandAndShip;

	public C2S_GetEOIEntitiesInfo MyInfo;

	public List<C2S_GetEOIEntitiesInfo> UserShipInfos;

	public Dictionary<int, List<C2S_GetEOIEntitiesInfo>> UserShipInfos_Dict;

	public C2S_GetGvGMode2IZConfig.Response IZState;

	private C2S_AcceptPushFlag.Request PushFlags;

	private List<IslandSummary> PushedIslandSummaries;

	private IslandStopInfo _IslandStopInfo;

	private CoroutineQueue BeskKillCoroutineQueue;

	public MapStateManager(MapEntryManager mapEntryManager, MapVfxManager mapVfxManager, MapDataManager mapDataManager, ShipManager shipManager, FlightManager flightManager, MonoBehaviour parentController)
	{
		MapEntryManager = mapEntryManager;
		MapVfxManager = mapVfxManager;
		MapDataManager = mapDataManager;
		ShipManager = shipManager;
		FlightManager = flightManager;
		ParentController = parentController;
		BeskKillCoroutineQueue = new CoroutineQueue(parentController);
	}

	public void RegisterEvents()
	{
		S2C_ChangeIZProgress.OnPushEvent = (Action<S2C_ChangeIZProgress.Request>)Delegate.Combine(S2C_ChangeIZProgress.OnPushEvent, new Action<S2C_ChangeIZProgress.Request>(OnUpdateIZState));
		S2C_MakeFlightSchedule.OnPushEvent = (Action<S2C_MakeFlightSchedule.Request>)Delegate.Combine(S2C_MakeFlightSchedule.OnPushEvent, new Action<S2C_MakeFlightSchedule.Request>(OnUpdateFlightSchedule));
		S2C_ChangeShipSummaryStateFighting.OnPushEvent = (Action<S2C_ChangeShipSummaryStateFighting.Request>)Delegate.Combine(S2C_ChangeShipSummaryStateFighting.OnPushEvent, new Action<S2C_ChangeShipSummaryStateFighting.Request>(OnUpdateShipState));
		S2C_IslandSummary.OnPushEvent = (Action<S2C_IslandSummary.Request>)Delegate.Combine(S2C_IslandSummary.OnPushEvent, new Action<S2C_IslandSummary.Request>(OnUpdateIslandSummary));
		S2C_ChangeCampScore.OnPushEvent = (Action<S2C_ChangeCampScore.Request>)Delegate.Combine(S2C_ChangeCampScore.OnPushEvent, new Action<S2C_ChangeCampScore.Request>(OnUpdateCampScore));
		S2C_ChangeShipSummarySoldierCnt.OnPushEvent = (Action<S2C_ChangeShipSummarySoldierCnt.Request>)Delegate.Combine(S2C_ChangeShipSummarySoldierCnt.OnPushEvent, new Action<S2C_ChangeShipSummarySoldierCnt.Request>(OnChangeShipSummarySoldierCnt));
		S2C_ShipDead.OnPushEvent = (Action<S2C_ShipDead.Request>)Delegate.Combine(S2C_ShipDead.OnPushEvent, new Action<S2C_ShipDead.Request>(OnPushShipDead));
		S2C_ChangeBestKill.OnPushEvent = (Action<S2C_ChangeBestKill.Request>)Delegate.Combine(S2C_ChangeBestKill.OnPushEvent, new Action<S2C_ChangeBestKill.Request>(OnChangeBestKill));
	}

	public void UnRegisterEvents()
	{
		S2C_ChangeIZProgress.OnPushEvent = (Action<S2C_ChangeIZProgress.Request>)Delegate.Remove(S2C_ChangeIZProgress.OnPushEvent, new Action<S2C_ChangeIZProgress.Request>(OnUpdateIZState));
		S2C_MakeFlightSchedule.OnPushEvent = (Action<S2C_MakeFlightSchedule.Request>)Delegate.Remove(S2C_MakeFlightSchedule.OnPushEvent, new Action<S2C_MakeFlightSchedule.Request>(OnUpdateFlightSchedule));
		S2C_ChangeShipSummaryStateFighting.OnPushEvent = (Action<S2C_ChangeShipSummaryStateFighting.Request>)Delegate.Remove(S2C_ChangeShipSummaryStateFighting.OnPushEvent, new Action<S2C_ChangeShipSummaryStateFighting.Request>(OnUpdateShipState));
		S2C_IslandSummary.OnPushEvent = (Action<S2C_IslandSummary.Request>)Delegate.Remove(S2C_IslandSummary.OnPushEvent, new Action<S2C_IslandSummary.Request>(OnUpdateIslandSummary));
		S2C_ChangeCampScore.OnPushEvent = (Action<S2C_ChangeCampScore.Request>)Delegate.Remove(S2C_ChangeCampScore.OnPushEvent, new Action<S2C_ChangeCampScore.Request>(OnUpdateCampScore));
		S2C_ChangeShipSummarySoldierCnt.OnPushEvent = (Action<S2C_ChangeShipSummarySoldierCnt.Request>)Delegate.Remove(S2C_ChangeShipSummarySoldierCnt.OnPushEvent, new Action<S2C_ChangeShipSummarySoldierCnt.Request>(OnChangeShipSummarySoldierCnt));
		S2C_ShipDead.OnPushEvent = (Action<S2C_ShipDead.Request>)Delegate.Remove(S2C_ShipDead.OnPushEvent, new Action<S2C_ShipDead.Request>(OnPushShipDead));
		S2C_ChangeBestKill.OnPushEvent = (Action<S2C_ChangeBestKill.Request>)Delegate.Remove(S2C_ChangeBestKill.OnPushEvent, new Action<S2C_ChangeBestKill.Request>(OnChangeBestKill));
	}

	public void StartProcess(bool isMocking = false)
	{
		MyCampId = -1;
		MyCampIsland = null;
		MyShip = null;
		MyInfo = null;
		MyShipSummary = null;
		UserShipInfos = null;
		IZState = null;
		if (isMocking)
		{
			InitProcessCoroutine = ParentController.StartCoroutine(InitMockingProcess());
		}
		else
		{
			InitProcessCoroutine = ParentController.StartCoroutine(InitProcess());
		}
	}

	public void UpdateMyShipSummary()
	{
		UpdateMyShipSummaryCoroutine = ParentController.StartCoroutine(UpdateMyShipDetails());
	}

	public void StopProcess()
	{
		if (InitProcessCoroutine != null)
		{
			ParentController.StopCoroutine(InitProcessCoroutine);
		}
		if (UpdateMyShipSummaryCoroutine != null)
		{
			ParentController.StopCoroutine(UpdateMyShipSummaryCoroutine);
		}
	}

	private IEnumerator InitMockingProcess()
	{
		MapEntryManager.ShowBlackMask();
		int myCampId = 1;
		int serverTime = (int)GameController.Instance.GetServerTime();
		IZState = new C2S_GetGvGMode2IZConfig.Response
		{
			CampScore = "1000",
			IZProgress = 1,
			IZBeginTimestamp = serverTime,
			IZEndTimestamp = serverTime + 30
		};
		yield return OnInitIZState(IZState, myCampId);
		int shipId = 0;
		int myId = GameController.Contexts.gameState.user.value.UserId;
		List<int> userIds = new List<int> { myId, 618701, 618698, 618702, 574392, 574391, 574375, 574378, 574380 };
		UserShipInfos = new List<C2S_GetEOIEntitiesInfo>();
		for (int i = 0; i < userIds.Count; i++)
		{
			List<C2S_GetEOIEntitiesInfo> userShipInfos = UserShipInfos;
			C2S_GetEOIEntitiesInfo obj = new C2S_GetEOIEntitiesInfo
			{
				UserId = userIds[i],
				CampId = ((i == 0) ? myCampId : Random.Range(1, 5))
			};
			List<int> list = new List<int>();
			int num = shipId + 1;
			shipId = num;
			list.Add(num);
			obj.ShipEntities = list;
			userShipInfos.Add(obj);
		}
		OnCreateShips(UserShipInfos);
		yield return null;
		for (int j = 0; j < userIds.Count; j++)
		{
			C2S_GetEOIEntitiesInfo inf = UserShipInfos[j];
			C2S_GetShipSummaryAndFlightScheduleInfo detail = new C2S_GetShipSummaryAndFlightScheduleInfo
			{
				EntityId = inf.ShipEntities[0],
				UserId = inf.UserId,
				FlightSchedule = new FlightSchedule
				{
					StartTime = -1,
					EndTime = -1,
					Route = null
				},
				State = 0,
				StayIslandId = MapDataManager.GetCampIsland(inf.CampId).Props.Id
			};
			OnInitShipDetails(detail, inf.UserId == myId);
		}
		yield return (object)new WaitForSeconds(2f);
		S2C_ChangeIZProgress.Request newState = new S2C_ChangeIZProgress.Request
		{
			IZProgress = 2
		};
		OnUpdateIZState(newState);
		yield return (object)new WaitForSeconds(1f);
		serverTime = (int)GameController.Instance.GetServerTime();
		List<S2C_MakeFlightSchedule.Request> flights = new List<S2C_MakeFlightSchedule.Request>();
		for (int k = 0; k < 1; k++)
		{
			C2S_GetEOIEntitiesInfo inf2 = UserShipInfos[k];
			MapDataManager.GetCampIsland(inf2.CampId);
			S2C_MakeFlightSchedule.Request flight = new S2C_MakeFlightSchedule.Request
			{
				EntityId = inf2.ShipEntities[0],
				FlightSchedule = new FlightSchedule
				{
					StartTime = serverTime,
					EndTime = serverTime + 5,
					Route = new int[3] { 23, 19, 10 }
				},
				ShipSummaryState = 4,
				ShipSummaryStayIslandId = MapDataManager.GetCampIsland(inf2.CampId).Props.Id
			};
			flights.Add(flight);
			OnUpdateFlightSchedule(flight);
		}
		yield return (object)new WaitForSeconds(5f);
		foreach (S2C_MakeFlightSchedule.Request flight2 in flights)
		{
			int[] route = flight2.FlightSchedule.Route;
			flight2.FlightSchedule.EndTime = -1;
			flight2.FlightSchedule.StartTime = -1;
			flight2.FlightSchedule.Route = null;
			flight2.ShipSummaryState = 0;
			flight2.ShipSummaryStayIslandId = route[^1];
			OnUpdateFlightSchedule(flight2);
		}
	}

	private IEnumerator UpdateMyShipDetails()
	{
		yield return GetShipDetails(UserShipInfos.GetRange(0, 1), isCurUser: true);
	}

	private IEnumerator InitProcess()
	{
		PushFlags = new C2S_AcceptPushFlag.Request
		{
			isAcceptPushIslandSummary = false,
			isAcceptPushIslandCampSummary = -1
		};
		MapEntryManager.ShowBlackMask();
		GetIZState();
		GetEOIShips();
		while (IZState == null || UserShipInfos == null)
		{
			yield return null;
		}
		bool hasToShowHighlight = IZState.IZProgress == 1;
		InitUserCampId(UserShipInfos);
		yield return OnInitIZState(IZState, UserShipInfos[0].CampId);
		OnCreateShips(UserShipInfos);
		yield return GetShipDetails(UserShipInfos.GetRange(0, 1), isCurUser: true);
		if (UserShipInfos.Count > 1)
		{
			yield return GetShipDetails(UserShipInfos.GetRange(1, UserShipInfos.Count - 1), isCurUser: false);
		}
		while (IZState.IZProgress != 2)
		{
			yield return null;
		}
		PushFlags.isAcceptPushIslandSummary = true;
		SendPushFlags();
		if (hasToShowHighlight)
		{
			GvGWorldMapController.Instance.SetInputEnable(flag: false);
			while (PushedIslandSummaries == null)
			{
				yield return null;
			}
			List<int> list = new List<int>();
			foreach (IslandSummary island in PushedIslandSummaries)
			{
				list.Add(island.IslandId);
			}
			ShowHighlight(list);
			yield return (object)new WaitForSeconds(3f);
			HideHighlight();
			GvGWorldMapController.Instance.SetInputEnable(flag: true);
		}
		if (_IslandStopInfo != null && _IslandStopInfo.WinnerCamp != -1)
		{
			Island stopedIsland = MapDataManager.GetIslandById($"{_IslandStopInfo.IslandId}");
			while ((Object)(object)stopedIsland.IslandPlane == (Object)null)
			{
				yield return null;
			}
			int curScore = GvGWorldMapController.MainUI.RevertCampScoreToPrevious(_IslandStopInfo.WinnerCamp, _IslandStopInfo.IslandId);
			OnUpdateCampScore(new S2C_ChangeCampScore.Request
			{
				CampScore = JsonHelper.ToJson(new Dictionary<int, int> { { _IslandStopInfo.WinnerCamp, curScore } }),
				ChangeCampId = _IslandStopInfo.WinnerCamp,
				StopIslandConfigId = _IslandStopInfo.IslandId
			});
		}
	}

	private void InitUserCampId(List<C2S_GetEOIEntitiesInfo> userShipInfos)
	{
	}

	public void CheckState()
	{
	}

	private void GetEOIShips()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode2WorldMap).Request(new C2S_GetEOIEntities
		{
			Req = new C2S_GetEOIEntities.Request
			{
				NonStr = ""
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetEOIEntities.Response response = (C2S_GetEOIEntities.Response)context_response.Resp;
			if (response.ErrorCode < 0)
			{
				ILRuntimeDebug.LogError("请求 C2S_GetEOIEntities 不成功");
				StopProcess();
			}
			else if (response.Infos == null)
			{
				ILRuntimeDebug.LogError("请求 C2S_GetEOIEntities 返回的 Infos 为 null");
				StopProcess();
			}
			else
			{
				List<C2S_GetEOIEntitiesInfo> infos = response.Infos;
				int myUserId = GameController.Contexts.gameState.user.value.UserId;
				int index = infos.FindIndex((C2S_GetEOIEntitiesInfo user) => user.UserId == myUserId);
				C2S_GetEOIEntitiesInfo value = infos[0];
				infos[0] = infos[index];
				infos[index] = value;
				MyInfo = infos[0];
				UserShipInfos = infos;
			}
		});
	}

	private IEnumerator GetShipDetails(List<C2S_GetEOIEntitiesInfo> waitToGetDetails, bool isCurUser)
	{
		int MAX_GET_COUNT = 5;
		List<int> shipList = new List<int>();
		foreach (C2S_GetEOIEntitiesInfo uerInfo in waitToGetDetails)
		{
			shipList.AddRange(uerInfo.ShipEntities);
		}
		int curIndex = 0;
		bool isReadyToGet = true;
		while (curIndex < shipList.Count)
		{
			if (isReadyToGet)
			{
				isReadyToGet = false;
				int getCount = Mathf.Min(MAX_GET_COUNT, shipList.Count - curIndex);
				SocketManager.Instance.GetConnection(eConType.GvGMode2WorldMap).Request(new C2S_GetShipSummaryAndFlightSchedule
				{
					Req = new C2S_GetShipSummaryAndFlightSchedule.Request
					{
						EntityIds = shipList.GetRange(curIndex, getCount)
					}
				}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
				{
					isReadyToGet = true;
					C2S_GetShipSummaryAndFlightSchedule.Response response = (C2S_GetShipSummaryAndFlightSchedule.Response)context_response.Resp;
					if (response.ErrorCode < 0)
					{
						ILRuntimeDebug.LogError("请求 C2S_GetShipSummaryAndFlightSchedule 不成功");
						StopProcess();
					}
					else if (response.Infos == null)
					{
						ILRuntimeDebug.LogError("请求 C2S_GetShipSummaryAndFlightSchedule 返回的 Infos 为 null");
						StopProcess();
					}
					else
					{
						List<C2S_GetShipSummaryAndFlightScheduleInfo> infos = response.Infos;
						foreach (C2S_GetShipSummaryAndFlightScheduleInfo item in infos)
						{
							OnInitShipDetails(item, isCurUser);
						}
						curIndex += getCount;
					}
				});
			}
			yield return null;
		}
	}

	private void GetIZState()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode2WorldMap).Request(new C2S_GetGvGMode2IZConfig
		{
			Req = new C2S_GetGvGMode2IZConfig.Request
			{
				NonStr = ""
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			IZState = (C2S_GetGvGMode2IZConfig.Response)context_response.Resp;
		});
	}

	private void SendPushFlags()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode2WorldMap).Request(new C2S_AcceptPushFlag
		{
			Req = PushFlags
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_AcceptPushFlag.Response response = (C2S_AcceptPushFlag.Response)context_response.Resp;
		});
	}

	internal void AllowPushIslandCampSummary(int islandId)
	{
		C2S_AcceptPushFlag.Request request = PushFlags.Clone();
		request.isAcceptPushIslandCampSummary = islandId;
		SocketManager.Instance.GetConnection(eConType.GvGMode2WorldMap).Request(new C2S_AcceptPushFlag
		{
			Req = request
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_AcceptPushFlag.Response response = (C2S_AcceptPushFlag.Response)context_response.Resp;
		});
	}

	public void MakeFlightSchedule(int startId, int endId, bool isBackToCampBaseAndShipFillUp = false)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode2WorldMap).Request(new C2S_MakeFlightSchedule
		{
			Req = new C2S_MakeFlightSchedule.Request
			{
				ShipEntityId = MyShipSummary.EntityId,
				StartId = startId,
				EndId = endId,
				IsBackToCampBaseAndFillUp = isBackToCampBaseAndShipFillUp
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_MakeFlightSchedule.Response response = (C2S_MakeFlightSchedule.Response)context_response.Resp;
		});
	}

	private IEnumerator OnInitIZState(C2S_GetGvGMode2IZConfig.Response iZState, int campId)
	{
		MyCampId = campId;
		MyCampIsland = MapDataManager.GetCampIsland(campId);
		Vector3 pos = MyCampIsland.IslandObject.transform.localPosition;
		GvGWorldMapController.Instance.IsReadyToRender = true;
		GvGWorldMapController.Instance.NeedUpdateView = true;
		GvGWorldMapController.MainUI.OnSetIZState(iZState);
		if (iZState.IsIZOver)
		{
			if (string.IsNullOrEmpty(iZState.IZResult))
			{
				GvGWorldMapController.MainUI.OpenTipPanel("副本已关闭", delegate
				{
					UI_GvGWorldMap2.ClosePanel();
				}, (AlignType)1, delegate
				{
					UI_GvGWorldMap2.ClosePanel();
				});
				StopProcess();
				yield break;
			}
			GvGWorldMapController.MainUI.IsIzOver = true;
			Singleton<GvGInstanceZone>.Instance.OpenBattleResultPanel(new S2C_IZOver.Request
			{
				Result = iZState.IZResult
			});
		}
		if (iZState.IZProgress == 1)
		{
			GvGWorldMapController.Instance.SetCamera(pos, 5.4f);
			while ((Object)(object)MyCampIsland.IslandPlane == (Object)null)
			{
				yield return null;
			}
			OnProgress1(MyCampIsland);
		}
		else if (iZState.IZProgress == 2)
		{
			GvGWorldMapController.Instance.SetCamera(Consts.GVG2_START_CAM_POS, 25f);
			OnProgress2();
			OnChangeBestKill(new S2C_ChangeBestKill.Request
			{
				UserId = iZState.BestKillUserId,
				KillCount = iZState.BestKillCount,
				CampId = iZState.BestKillCampId,
				IsKill = false
			});
		}
		OnInitCampIsland?.Invoke(MyCampIsland);
		yield return null;
	}

	private void OnCreateShips(List<C2S_GetEOIEntitiesInfo> userShipInfos)
	{
		foreach (C2S_GetEOIEntitiesInfo userShipInfo in userShipInfos)
		{
			foreach (int shipEntity in userShipInfo.ShipEntities)
			{
				ShipManager.AddShip(new ShipProps
				{
					Id = shipEntity,
					UserId = userShipInfo.UserId,
					CampId = userShipInfo.CampId
				});
			}
		}
		MyShip = ShipManager.GetById(MyInfo.ShipEntities[0]);
	}

	private void OnInitShipDetails(C2S_GetShipSummaryAndFlightScheduleInfo detail, bool isCurUser)
	{
		Ship byId = ShipManager.GetById(detail.EntityId);
		FlightSchedule flightSchedule = detail.FlightSchedule;
		flightSchedule.StartTime = flightSchedule.StartTime;
		FlightSchedule flightSchedule2 = detail.FlightSchedule;
		flightSchedule2.EndTime = flightSchedule2.EndTime;
		byId.SetDetails(detail);
		FlightManager.AddFlightSchedule(detail.EntityId, detail.FlightSchedule, isInit: true);
		if (isCurUser)
		{
			MyShipSummary = detail;
			GvGWorldMapController.MainUI.OnSetShipDetails(MyShipSummary, MyCampId);
			Singleton<GvGInstanceZone>.Instance.UpdateCurrentStateInfo(MyShipSummary, MyCampId, forcedUpdateUnitInfo: true, isInit: true);
			OnInitCampIslandAndShip?.Invoke(this);
		}
	}

	private void OnUpdateIZState(S2C_ChangeIZProgress.Request req)
	{
		if (req.IZProgress == 2)
		{
			IZState.IZProgress = req.IZProgress;
			GvGWorldMapController.MainUI.OnSetIZState(IZState);
			OnProgress2();
		}
	}

	private void OnUpdateFlightSchedule(S2C_MakeFlightSchedule.Request req)
	{
		Ship byId = ShipManager.GetById(req.EntityId);
		if (byId != null && byId.Details != null)
		{
			FlightSchedule flightSchedule = req.FlightSchedule;
			flightSchedule.StartTime = flightSchedule.StartTime;
			FlightSchedule flightSchedule2 = req.FlightSchedule;
			flightSchedule2.EndTime = flightSchedule2.EndTime;
			byId.ChangeFlightSchedule(req.FlightSchedule, req.ShipSummaryState, req.ShipSummaryStayIslandId);
			FlightManager.AddFlightSchedule(req.EntityId, req.FlightSchedule);
			if (byId == MyShip)
			{
				GvGWorldMapController.MainUI.OnSetShipDetails(MyShipSummary, MyCampId);
			}
		}
	}

	private void OnUpdateShipState(S2C_ChangeShipSummaryStateFighting.Request req)
	{
		if (MyShipSummary != null)
		{
			MyShipSummary.State = req.ShipSummaryState;
		}
		if (req.ShipSummaryState == 7)
		{
			GvGWorldMapController.Instance.OnEnterIsland(req.IslandPid, req.IslandExternalSocketPort, req.ShipSummaryStayIslandId);
		}
		Singleton<GvGInstanceZone>.Instance.UpdateCurrentStateInfo(MyShipSummary, MyCampId);
		if (req.ShipSummaryState == 0 || req.ShipSummaryState == 1 || req.ShipSummaryState == 3)
		{
			Singleton<GvGInstanceZone>.Instance.ExecuteBackToCampBaseAndChangeLegionGroup();
		}
	}

	private void OnChangeShipSummarySoldierCnt(S2C_ChangeShipSummarySoldierCnt.Request req)
	{
		Dictionary<string, int> dictionary = JsonHelper.ToObject<Dictionary<string, int>>(req.JsonSoldierCnt);
		foreach (ShipSummaryUnitInfo item in MyShipSummary.GroupInfo)
		{
			if (dictionary.TryGetValue(item.SoldierId, out var value))
			{
				item.CurCnt = value;
			}
		}
		GvGWorldMapController.MainUI.OnSetShipDetails(MyShipSummary, MyCampId);
		Singleton<GvGInstanceZone>.Instance.UpdateCurrentStateInfo(MyShipSummary, MyCampId, forcedUpdateUnitInfo: true);
	}

	private void OnUpdateIslandSummary(S2C_IslandSummary.Request req)
	{
		if (req.IslandSummaries == null)
		{
			ILRuntimeDebug.LogError("S2C_IslandSummary.Request.IslandSummaries 为 null");
			return;
		}
		foreach (IslandSummary islandSummary in req.IslandSummaries)
		{
			Island islandById = MapDataManager.GetIslandById($"{islandSummary.IslandId}");
			islandById.SetState(islandSummary);
		}
		PushedIslandSummaries = req.IslandSummaries;
	}

	public void OnUpdateCampScore(S2C_ChangeCampScore.Request req)
	{
		Dictionary<int, int> scores = JsonHelper.ToObject<Dictionary<int, int>>(req.CampScore);
		Island islandById = MapDataManager.GetIslandById($"{req.StopIslandConfigId}");
		if (req.ChangeCampId != -1 && islandById != null)
		{
			MapVfxManager.LaunchLightBallFromIsland(islandById, req.ChangeCampId, delegate
			{
				GvGWorldMapController.MainUI.OnChangeCampScore(scores, 0.8f);
			});
		}
	}

	private void OnPushShipDead(S2C_ShipDead.Request req)
	{
		int entityId = req.EntityId;
		if (entityId == MyShip.Props.Id)
		{
			List<string> arg = new List<string> { "我方部队无可用兵力，已自动回到主城补兵" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 999, arg3: false);
		}
		else
		{
			SetShipBackToCamp(entityId);
		}
	}

	private void OnChangeBestKill(S2C_ChangeBestKill.Request req)
	{
		BeskKillCoroutineQueue.AddCoroutine(GvGWorldMapController.MainUI.ProccessBestKill(req.UserId, req.KillCount, req.CampId, req.IsKill));
	}

	public void SetIslandStopInfo(int winnerCampId, int fromIslandId, int islandScore)
	{
		_IslandStopInfo = new IslandStopInfo
		{
			IslandId = fromIslandId,
			IslandScore = islandScore,
			WinnerCamp = winnerCampId
		};
	}

	public List<C2S_GetEOIEntitiesInfo> GetCampUsers(int campId)
	{
		if (UserShipInfos_Dict == null)
		{
			UserShipInfos_Dict = new Dictionary<int, List<C2S_GetEOIEntitiesInfo>>();
			foreach (C2S_GetEOIEntitiesInfo userShipInfo in UserShipInfos)
			{
				if (!UserShipInfos_Dict.TryGetValue(userShipInfo.CampId, out var value))
				{
					value = new List<C2S_GetEOIEntitiesInfo>();
					UserShipInfos_Dict.Add(userShipInfo.CampId, value);
				}
				value.Add(userShipInfo);
			}
		}
		if (UserShipInfos_Dict.TryGetValue(campId, out var value2))
		{
			return value2;
		}
		ILRuntimeDebug.LogError($"没有找到 campId={campId}");
		return null;
	}

	private void OnProgress1(Island myCamp)
	{
		UI_GvGWorldMap2 mainUI = GvGWorldMapController.MainUI;
		mainUI.PageController.selectedIndex = 0;
		MapEntryManager.ShowHoleAt(myCamp);
	}

	private void OnProgress2()
	{
		UI_GvGWorldMap2 mainUI = GvGWorldMapController.MainUI;
		mainUI.PageController.selectedIndex = 1;
		MapEntryManager.HideMaskAndHole();
	}

	public void ShowHighlight(List<int> islandList)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		UI_GvGWorldMap2 mainUI = GvGWorldMapController.MainUI;
		GvGWorldMapController.Instance.SetCamera(Consts.GVG2_MAP_CENTER, 8.64f, 0.5f);
		mainUI.PageController.selectedIndex = 3;
		MapEntryManager.HighlightIsland(islandList);
	}

	public void HideHighlight()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		UI_GvGWorldMap2 mainUI = GvGWorldMapController.MainUI;
		GvGWorldMapController.Instance.SetCamera(Consts.GVG2_MAP_CENTER, 8.64f, 0f);
		mainUI.PageController.selectedIndex = 1;
		MapEntryManager.HideHighlight();
	}

	public void MyShipBackToCamp()
	{
		SetShipBackToCamp(MyShip.Props.Id);
	}

	public void SetShipBackToCamp(int shipId)
	{
		Ship byId = ShipManager.GetById(shipId);
		if (byId == null)
		{
			ILRuntimeDebug.LogError($"SetShipBackToCamp 找不到相应飞空艇 shipId = {shipId}");
			return;
		}
		if (byId.Details == null)
		{
			ILRuntimeDebug.LogError($"SetShipBackToCamp shipId = {shipId} 的Details为null");
			return;
		}
		MapDataManager.GetIslandById($"{byId.Details.StayIslandId}")?.DockingManager?.UndockShip(byId);
		Island campIsland = MapDataManager.GetCampIsland(byId.Props.CampId);
		campIsland?.DockingManager?.DockShip(byId, isInit: false);
		byId.Details.StayIslandId = campIsland.Props.Id;
	}
}
