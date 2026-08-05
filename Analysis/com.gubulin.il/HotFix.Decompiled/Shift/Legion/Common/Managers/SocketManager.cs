using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.C2S;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.S2C;
using Shift.Legion.ClientApi;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.BaseSocket;
using Shift.Legion.GvGServer.Models.GvGMode2IslandSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.BattlePass;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.NPC;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.OuterTech;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.PlayerCommand;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Ship;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Sweep;
using Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using Shift.Legion.GvGServer.Models.WorldBossSocket;
using SuperSocket.ClientEngine;
using SuperSocketProtocol;
using UI.GvGExpeditionHall;
using UI.GvGOnIsland3;
using UI.GvGWorldMap3;
using UI.Tips;
using UnityEngine;

namespace Shift.Legion.Common.Managers;

public class SocketManager
{
	public class BaseSocketPackageBody
	{
	}

	public abstract class BaseSocketPackageBodyContext
	{
		public ePackageId PackageId { get; set; }

		public int UserId { get; set; }

		public short MsgIdx { get; set; }

		public BaseSocketPackageBody Req { get; set; }

		public BaseSocketPackageBody Resp { get; set; }

		public virtual void OnDestroy()
		{
			Req = null;
			Resp = null;
		}

		public virtual void OnPush()
		{
		}
	}

	public enum ePackageId
	{
		C2S_TestConnection = -6,
		C2S_Ping = -5,
		HttpCommand = -4,
		ConnectSocket = -3,
		C2S_TestCommand = -2,
		NotInit = -1,
		S2C_Init = 0,
		C2S_Regist = 2,
		C2S_Unregist = 3,
		C2S_AcceptPushFlag = 4,
		S2C_SystemIZOver = 998,
		S2C_SystemPause = 999,
		S2C_BroadcastEOIBattleField = 1000,
		S2C_BroadcastIslandInitInfo = 1002,
		S2C_BroadcastBossHp = 1004,
		S2C_BattleResult = 1005,
		S2C_BroadcastEntitiesDead = 1006,
		S2C_BroadcastBattleDamageInfo = 1007,
		S2C_StartOneBattle = 1008,
		S2C_ChangeIZProgress = 1010,
		S2C_CreateShip = 1011,
		S2C_ShipSummaryCreateSuccess = 1012,
		S2C_IslandSummary = 1013,
		S2C_ShipSummary = 1014,
		S2C_MakeFlightSchedule = 1015,
		S2C_ChangeCampScore = 1016,
		S2C_ChangeShipSummaryStateFighting = 1017,
		S2C_ChangeShipSummaryStateShipFillingUp = 1018,
		S2C_StartOneGvGMode2Battle = 1019,
		S2C_BroadcastGvGMode2BattleResult = 1020,
		S2C_IslandCampSummary = 1021,
		S2C_GvGMode2StateChange = 1022,
		S2C_ChangeHoldingCamp = 1023,
		S2C_HoldingPercent = 1024,
		S2C_IZOver = 1025,
		S2C_NewEntityKeyInfo = 1026,
		S2C_GvGMode2IslandStop = 1027,
		S2C_GvGMode2ShipDead = 1028,
		S2C_SyncBattleReport = 1029,
		S2C_Brocast_BattleReport_GvGMode2Island = 1030,
		S2C_ChangeShipSummarySoldierCnt = 1031,
		S2C_ShipDead = 1032,
		S2C_ChangeBestKill = 1033,
		S2C_StorehouseItemChanged = 1034,
		S2C_ItemChange = 1035,
		S2C_FillupSoldiers = 1036,
		S2C_GvGMode3IslandEntityInfo = 1037,
		S2C_StayIsland = 1038,
		S2C_IslandAction = 1039,
		S2C_BroadcastGvGMode3BattleResult = 1040,
		S2C_GvGMode3ShipSummarySpeed = 1041,
		S2C_GvGMode3FoodOnboardCount = 1042,
		S2C_GvGStateChange = 1043,
		S2C_GvGMode3IslandStop = 1044,
		S2C_GvGMode3ShipDead = 1045,
		S2C_ChangeGvGMode3BestKill = 1046,
		S2C_GvGMode3IslandRank = 1047,
		S2C_GvGMode3ShipBossDamageRank = 1048,
		S2C_GvGMode3ShipKillSoldiersCount = 1049,
		S2C_FillupFood = 1050,
		S2C_SyncSoldierInfo = 1051,
		S2C_SyncSoldierCount = 1052,
		S2C_GroupCountLimit = 1053,
		S2C_BackupGroupSlotLimit = 1054,
		S2C_ResetTalentFinish = 1055,
		S2C_DestroyShip = 1056,
		S2C_ShipCountLimit = 1057,
		S2C_SubmitFlagShipReq = 1058,
		S2C_PostOEMMission = 1059,
		S2C_SelfOEMMissionChanged = 1060,
		S2C_Purification = 1061,
		S2C_地貌勘探ObDetectedIslands = 1062,
		S2C_ShipSightRange = 1063,
		S2C_GvGMode3IslandEvents = 1064,
		S2C_BuyNPCShop = 1065,
		S2C_FlagShipState = 1066,
		S2C_SyncRunningTreasureMapEvent = 1067,
		S2C_SyncRunningRandomEvent = 1068,
		S2C_FinishNPCDialogMission = 1069,
		S2C_CreatePlayerCommand = 1070,
		S2C_ContributionPointsChanged = 1071,
		S2C_BattlePassPaidCertChanged = 1073,
		S2C_SyncFinalProgressInfo = 1074,
		S2C_GetFinalProgressBossDamageTodayTop3 = 1075,
		S2C_ShipJump = 1076,
		S2C_GvGMode3NewIOI = 1077,
		S2C_ShipCanRetreatTimestamp = 1078,
		S2C_WaitToClaimSystemMessageIdsCount = 1079,
		S2C_UnlockedAmpFormulas = 1080,
		S2C_AttackEvent = 1081,
		S2C_RebuildShip = 1082,
		S2C_SoulGuideCooldown = 1083,
		S2C_GvGMode2_HoldingPercent = 1084,
		S2C_GvGMode2_ChangeHoldingCamp = 1085,
		S2C_GvGMode2_NewEntityKeyInfo = 1086,
		S2C_CanNotCollecting = 1087,
		S2C_OuterTechAmpTransfrom = 1088,
		S2C_BuySweepCount = 1090,
		S2C_GvGMode3UnreachableIslands = 1091,
		S2C_PostFormulaOEMMission = 1092,
		S2C_SelfFormulaOEMMissionChanged = 1093,
		S2C_RealTime火力支援MaxTimeOfUsageModel = 1094,
		S2C_Event_火力支援 = 1095,
		S2C_ShipContinueExecutePlan = 1096,
		S2C_ShipPlanChangeSoldier = 1097,
		S2C_CreateShipPlanSuccess = 1098,
		S2C_BrawlReplayCreateShip = 1099,
		S2C_BrawlReplayKeyFrame = 1101,
		S2C_BrawlReplayScoreChanged = 1102,
		S2C_BrawlReplayNotification = 1103,
		S2C_BrawlEvent_TodayAllowSignUp = 1104,
		S2C_OuterTechHideRefresh = 1105,
		C2S_Init = 100000,
		C2S_SyncTime = 100001,
		C2S_ChangeMapViewLevel = 100010,
		C2S_GetIslandInfos = 100011,
		C2S_GetEntitiesAllInfo = 100012,
		C2S_SetObserveTargetId = 100013,
		C2S_GetObserveTargets = 100014,
		C2S_GetBossHp = 100015,
		C2S_GetGvGInspectBossInfo = 100016,
		C2S_GetWBKeyInfos = 100017,
		C2S_GetBattleDamageDetailInfo = 100018,
		C2S_GetCurBattleDetailInfo = 100019,
		C2S_GetEOIEntities = 100020,
		C2S_GetShipSummaryAndFlightSchedule = 100021,
		C2S_MakeFlightSchedule = 100022,
		C2S_CreateShip = 100023,
		C2S_ShipSummaryChangeFormationId = 100024,
		C2S_GetOwnShips = 100025,
		C2S_GetGvGMode2IZConfig = 100026,
		C2S_GetOwnCampKillInfo = 100027,
		C2S_ChangeBattleStrategy = 100028,
		C2S_GetGvGMode2Island_EOIEntities = 100029,
		C2S_GetGvGMode2Island_EntityInfo = 100030,
		C2S_GetGvGMode2Island_IslandInfo = 100031,
		C2S_GetBattleReport = 100032,
		C2S_GetBattleId = 100033,
		C2S_GetStorehouse = 100034,
		C2S_ChangeGvGMode3BattleStrategy = 100035,
		C2S_GetGvGMode3Island_EOIEntities = 100036,
		C2S_GetGvGMode3Island_IslandInfo = 100037,
		C2S_GetGvGMode3Island_EntityInfo = 100038,
		C2S_GetIncomingEnemyShips = 100039,
		C2S_ForgeAmplifier = 100040,
		C2S_ChangeShipAmplifiers = 100041,
		C2S_GetAmplifierStorage = 100042,
		C2S_GetShipAmplifiers = 100043,
		C2S_GetAmplifierTalentData = 100045,
		S2C_ForgeAmplifier = 100044,
		C2S_IslandAction = 100060,
		C2S_Share伟大航路DiscoveredIsland = 100061,
		C2S_GetEarlyWarningInfo = 100062,
		C2S_GetPreventionInfo = 100063,
		C2S_SaveShipGroupConfig = 100070,
		C2S_FillupSoldiers = 100071,
		C2S_ChangeFormationId = 100072,
		C2S_ChangeGroupOrder = 100073,
		C2S_LaunchShip = 100074,
		C2S_GetUnitDetailInfo = 100075,
		C2S_GetShipCollectingDetailInfo = 100076,
		C2S_ChangeShipCollectingInfo = 100077,
		C2S_FillupFood = 100078,
		C2S_GetCanDestroyStatusAllMyShip = 100079,
		C2S_GetGvGMode3IslandEntityInfos = 100080,
		C2S_ChangeCameraPos = 100081,
		C2S_GvGMode3GetShipSummaryAndFlightScheduleInfo = 100082,
		C2S_GetGvGMode3IslandDetailInfo = 100083,
		C2S_GetPreFlightSchedule = 100084,
		C2S_GetLaunchableIsland = 100085,
		C2S_UseItem = 100086,
		C2S_Sweep = 100090,
		C2S_BuySweepCount = 100091,
		C2S_GetGvGMode3BaseInfo = 100100,
		C2S_GetRealTimeFoodCostReduceModel = 100101,
		C2S_GetRealTimeShipSummarySpeedModel = 100102,
		C2S_GetRealTimeCollectingEfficiencyModel = 100103,
		C2S_GetGvGMode3ShipTemporaryData = 100104,
		C2S_GetRealTimeStorehouseLimitParModel = 100105,
		C2S_GetRealTimeGroupCountLimitModel = 100106,
		C2S_GetRealTimeFoodOnBoardModel = 100107,
		C2S_SendChatChannelMessage = 100200,
		C2S_GetChatChannelMessages = 100211,
		C2S_GetSystemMessages = 100212,
		C2S_GetSystemMessages_IslandBattleLog = 100213,
		C2S_GetSystemMessages_BattleResultBonus = 100214,
		C2S_ClaimAllBattleResultBonus = 100215,
		S2C_BroadcastChatChannelMessages = 100220,
		S2C_BroadcastSystemMessages = 100221,
		C2S_GetActiveTalents = 100300,
		C2S_ActivateTalent = 100301,
		S2C_ActivateTalent_ResetResult = 100302,
		C2S_GetActivateTalentStat = 100303,
		C2S_GetOuterTechStatus = 100310,
		C2S_OuterTech_UseGreenWay = 100311,
		C2S_OuterTech_SplitBluePrint = 100312,
		S2C_UseOuterTech = 100320,
		S2C_OuterTech_SplitBluePrint = 100321,
		C2S_OuterTechAmpTransform = 100322,
		C2S_Soldier_Wear = 100350,
		C2S_Soldier_TakeOff = 100351,
		S2C_Soldier_SoldierLegendItem = 100352,
		C2S_GetPlayerBattleLog = 100400,
		C2S_GetIslandRunningBattleLog = 100401,
		S2C_GvGStorehouseChange = 100410,
		S2C_GvGFoodOnBoard = 100411,
		S2C_ResetOuterTech = 100412,
		S2C_DailySuppressBonusTimesChange = 100413,
		C2S_GetFlagShipReq = 100500,
		C2S_SubmitFlagShipReq = 100501,
		C2S_PostOEMMission = 100502,
		C2S_GetOEMMissions = 100503,
		C2S_SubmitOEMMission = 100504,
		C2S_GetSelfOEMMissions = 100505,
		C2S_GetOEMMissionsState = 100506,
		C2S_ClaimSelfOEMMissions = 100507,
		C2S_Purification = 100508,
		C2S_ClaimYesterdayContributionItem = 100509,
		C2S_GetContributionItemInfo = 100510,
		C2S_GetTalentDailySupplyBox = 100511,
		C2S_GetFoodDailySupplyInfo = 100512,
		C2S_GiveFoodDailySupplyToShip = 100513,
		C2S_Share额外发现CollectingGroup = 100514,
		C2S_ClaimMission = 100515,
		C2S_GetMissions = 100516,
		C2S_GetCampEnergy = 100517,
		C2S_GetCampInfo = 100518,
		C2S_ClaimMainMissionRankReward = 100519,
		C2S_GetNPCShop = 100520,
		C2S_BuyNPCShop = 100521,
		C2S_FinishNPCDialogMission = 100522,
		C2S_GetMission = 100523,
		C2S_SubmitShadowEnergy = 100524,
		C2S_GetFinalProgressInfo = 100526,
		C2S_ClaimTreasureMapMission = 100527,
		C2S_CreatePlayerCommand = 100528,
		C2S_CancelPlayerCommand = 100529,
		C2S_CheckPlayerCommandMessage = 100530,
		C2S_CancelTreasureMapMission = 100531,
		C2S_ShipJump = 100532,
		C2S_GetJumpInfo = 100533,
		C2S_GetGvGMode3Leaderboard = 100534,
		C2S_GetAllContributionExcludingBuy = 100540,
		C2S_ClaimBattlePassBonus = 100541,
		C2S_GetFinalProgressRank = 100542,
		C2S_GetFinalProgressBossDamageTodayTop3 = 100543,
		C2S_ShipRetreat = 100544,
		C2S_RebuildShip = 100545,
		C2S_OfflineShipSoldier = 100546,
		C2S_DoSoulGuide = 100547,
		C2S_GetNeedToSyncEOIShips = 100548,
		C2S_GetShipNearestFlagShipOrMoonIsland = 100549,
		C2S_SyncShipCollectingProduceState = 100550,
		C2S_GetShipAllCombatPower = 100551,
		C2S_UseTalent勘探强化Detect = 100552,
		C2S_GetTalent勘探强化CountDown = 100553,
		C2S_GetUserProfileDatas = 100554,
		C2S_PostFormulaOEMMission = 100555,
		C2S_SubmitFormulaOEMMission = 100556,
		C2S_GetFormulaOEMMissions = 100557,
		C2S_GetSelfFormulaOEMMissions = 100558,
		C2S_ClaimSelfFormulaOEMMission = 100559,
		C2S_RefreshFormulaOEMMissions = 100560,
		C2S_ShipReturnToLastIsland = 100570,
		C2S_GetUserIslandOfInterest = 100561,
		C2S_Activate火力支援 = 100562,
		C2S_GetIslandShipsForDisplay = 100563,
		C2S_GetCreateShipPlanRequirement = 100564,
		C2S_CreateShipPlan = 100565,
		C2S_ChangeInsuranceShipId = 100566,
		C2S_BrawlEvent_SignUp = 100600,
		C2S_BrawlEvent_Cancel = 100601,
		C2S_BrawlEvent_GetResultByDay = 100602,
		C2S_BrawlEvent_GetInfo = 100603,
		C2S_BrawlEvent_ClaimResultByDay = 100604,
		C2S_BrawlEvent_Review = 100605,
		C2S_BrawlEvent_GetSignUpInfoByIsland = 100606,
		C2S_BrawlEvent_GetDetailInfoByIsland = 100607,
		C2S_BrawlEvent_GetDetailInfoByMUID = 100608,
		C2S_Robot_GvGMode3_Command = 900001,
		MaxValue = int.MaxValue
	}

	public class SocketConnection
	{
		private class RequestTimer
		{
			public double RequestTime;

			public int RequestFrame;

			public double TimeoutTime;

			public ePackageId PackageId;

			public int MgsId;
		}

		private enum LogErrorState
		{
			Empty,
			Logging
		}

		private const double MAX_TIMEOUT_TIME = 5.0;

		private const double TIMEOUT_TIME = 5.0;

		private const int CONNECT_MSG_INDEX = -1;

		private LogErrorState _errorState;

		private SuperSocketClient SuperSocketClient;

		private Dictionary<int, Action<BaseSocketPackageBodyContext>> MapRequestCallBack = null;

		private Dictionary<int, RequestTimer> RequestTimer_Dict = null;

		private HashSet<int> TimeoutMgsIds = null;

		private Coroutine TimeoutCoroutineHandler;

		private short CurSendMsgIdx = 1;

		private int UserId;

		private Action OnConnectionSuccess;

		private Action<C2S_RegistUserSessionCommand.Response> OnConnectionError;

		private static bool IsErrorShowed;

		private bool IsConnected;

		private bool HasShowTimeout = false;

		private Queue<Action> ActionQueue;

		private Coroutine UpdateCoroutineHandler;

		private double _lastTestConnectionTime;

		private double CurrentTime => (DateTime.Now - DateTime.MinValue).TotalSeconds;

		public eConType Type { get; private set; }

		public string Ip { get; private set; }

		public int Port { get; private set; }

		public int PId { get; private set; }

		public string CurrentConnectInfo { get; set; }

		public SocketConnection(eConType type)
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			Type = type;
			_errorState = LogErrorState.Empty;
			GameObject val = new GameObject($"SuperSocketClient_{type}");
			ActionQueue = new Queue<Action>();
			SuperSocketClient = val.AddComponent<SuperSocketClient>();
			SuperSocketClient.Action_Closed = OnActionClosed;
			SuperSocketClient.Action_Connected = OnActionConnected;
			SuperSocketClient.Action_Error = OnActionError;
			SuperSocketClient.Action_Received = OnActionReceived;
			MapRequestCallBack = new Dictionary<int, Action<BaseSocketPackageBodyContext>>();
			RequestTimer_Dict = new Dictionary<int, RequestTimer>();
			TimeoutMgsIds = new HashSet<int>();
			CurSendMsgIdx = 0;
			UserId = GameController.Contexts.gameState.user.value.UserId;
			SharedMessenger.AddListener<bool>("APP_FOCUS", OnApplicationFocus);
		}

		public void StartConnect(string ip, int port, int pid, Action onConnectionSuccess, Action<C2S_RegistUserSessionCommand.Response> onConnectionError = null)
		{
			try
			{
				Ip = ip;
				Port = port;
				PId = pid;
				OnConnectionSuccess = onConnectionSuccess;
				OnConnectionError = onConnectionError;
				SentrySdk.AddBreadcrumb($"[SocketConnection] type={Type} {ip}:{port} - {pid}StartConnect 开始socket连接！");
				StartUpdate();
				SuperSocketClient.BeginConnect(Ip, Port);
				StartTimeoutCounting();
				AddTimeoutCounting(-1, ePackageId.ConnectSocket);
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				ILRuntimeDebug.LogError($"[SocketConnection] type={Type} ip={ip} prot={port} pid ={pid} StartConnect 开始socket连接失败");
			}
		}

		public void Reconnect(Action onConnectionSuccess, Action<C2S_RegistUserSessionCommand.Response> onConnectionError = null)
		{
			OnConnectionSuccess = onConnectionSuccess;
			OnConnectionError = onConnectionError;
			StartUpdate();
			SuperSocketClient.BeginConnect(Ip, Port);
			StartTimeoutCounting();
			AddTimeoutCounting(-1, ePackageId.ConnectSocket);
		}

		public void CloseConnect()
		{
			ClearTimeoutCounting();
			SuperSocketClient.CloseConnect();
			SentrySdk.AddBreadcrumb($"[SocketConnection] type={Type} CloseConnect 关闭socket连接！");
		}

		public void Request(BaseSocketPackageBodyContext basebody, Action<BaseSocketPackageBodyContext> resp_action)
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Expected O, but got Unknown
			BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
			EasyClient val = (EasyClient)(typeof(SuperSocketClient).GetField("mClient", bindingAttr)?.GetValue(SuperSocketClient));
			if (val == null || !((EasyClientBase)val).IsConnected)
			{
				OnError();
				return;
			}
			SocketPackage val2 = new SocketPackage();
			val2.Code = (OpCode)6;
			val2.Timestamp = (long)new TimeSpan(DateTime.Now.Ticks).TotalSeconds;
			val2.PackageId = (int)basebody.PackageId;
			val2.PId = PId;
			val2.UserId = UserId;
			val2.MsgIdx = CurSendMsgIdx;
			CurSendMsgIdx++;
			if (_errorState == LogErrorState.Logging)
			{
				SentrySdk.AddBreadcrumb($"[SocketConnection] Request Start: {basebody.PackageId} localTime: {DateTimeHelper.Now.ToUnixTimeMilliseconds()}");
			}
			val2.Body = basebody.Req.Serialize();
			try
			{
				SuperSocketClient.SendSocketByte(((BaseSocketPackage)val2).ToBytes());
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
				return;
			}
			if (_errorState == LogErrorState.Logging)
			{
				SentrySdk.AddBreadcrumb($"[SocketConnection] Request Complete: {basebody.PackageId} localTime: {DateTimeHelper.Now.ToUnixTimeMilliseconds()}");
			}
			AddTimeoutCounting(val2.MsgIdx, basebody.PackageId);
			if (resp_action != null)
			{
				MapRequestCallBack.Add(val2.MsgIdx, resp_action);
			}
		}

		private void OnActionConnected(object obj)
		{
			SentrySdk.AddBreadcrumb($"[SocketConnection] type={Type} OnActionConnected");
			IsErrorShowed = false;
			ActionQueue.Enqueue(delegate
			{
				RemoveTimeoutCounting(-1);
				string nonStr = GetHashCode().ToString();
				Request(new C2S_RegistUserSessionCommand
				{
					UserId = UserId,
					Req = new C2S_RegistUserSessionCommand.Request
					{
						NonStr = nonStr
					}
				}, delegate(BaseSocketPackageBodyContext response)
				{
					C2S_RegistUserSessionCommand.Response response2 = (C2S_RegistUserSessionCommand.Response)response.Resp;
					if (response2.ErrorCode != 0)
					{
						CloseConnect();
						OnConnectionError?.Invoke(response2);
					}
					else if (response2.NonStr != nonStr)
					{
						ILRuntimeDebug.LogError($"[SocketConnection] type={Type} u{UserId}向Socket服务器注册UserId失败，NonStr验证未通过{nonStr}=>{response2.NonStr}，连接关闭");
						CloseConnect();
						OnConnectionError?.Invoke(response2);
					}
					else
					{
						OnConnectionSuccess?.Invoke();
						IsConnected = true;
					}
				});
			});
		}

		private void OnActionReceived(byte[] packageBytes)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Expected O, but got Unknown
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Invalid comparison between Unknown and I4
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Invalid comparison between Unknown and I4
			SocketPackage val = new SocketPackage(packageBytes);
			try
			{
				if (val.PId != PId || !Map_PackageId_PackageIdTypes.TryGetValue(val.PackageId, out var value))
				{
					return;
				}
				BaseSocketPackageBodyContext baseSocketPackageBodyContext = Activator.CreateInstance(value.BaseBodyContext) as BaseSocketPackageBodyContext;
				baseSocketPackageBodyContext.UserId = val.UserId;
				baseSocketPackageBodyContext.MsgIdx = val.MsgIdx;
				baseSocketPackageBodyContext.PackageId = (ePackageId)val.PackageId;
				if (_errorState == LogErrorState.Logging)
				{
					SentrySdk.AddBreadcrumb($"[SocketConnection] OnActionReceived: {val.PackageId} localTime: {DateTimeHelper.Now.ToUnixTimeMilliseconds()}, server: {val.Timestamp}");
				}
				OpCode code = val.Code;
				OpCode val2 = code;
				if ((int)val2 != 2)
				{
					if ((int)val2 == 7)
					{
						RemoveTimeoutCounting(val.MsgIdx);
						baseSocketPackageBodyContext.Resp = (BaseSocketPackageBody)val.Body.Deserialize(value.Response);
						if (MapRequestCallBack.TryGetValue(val.MsgIdx, out var value2))
						{
							value2(baseSocketPackageBodyContext);
						}
					}
				}
				else
				{
					baseSocketPackageBodyContext.Req = (BaseSocketPackageBody)val.Body.Deserialize(value.Request);
					baseSocketPackageBodyContext.OnPush();
				}
				baseSocketPackageBodyContext.OnDestroy();
			}
			catch (Exception exception)
			{
				ILRuntimeDebug.LogException(exception);
			}
		}

		private void OnActionError(object obj)
		{
			SentrySdk.AddBreadcrumb($"[SocketConnection] type={Type} OnActionError");
			ActionQueue.Enqueue(delegate
			{
				SentrySdk.AddBreadcrumb($"[SocketConnection] type={Type} Action_Error");
				OnError();
			});
		}

		private void OnActionClosed(object obj)
		{
			SentrySdk.AddBreadcrumb($"[SocketConnection] type={Type} OnActionClosed");
			ActionQueue.Enqueue(delegate
			{
				SentrySdk.AddBreadcrumb($"[SocketConnection] type={Type} Action_Closed");
				CurrentConnectInfo = string.Empty;
				IsConnected = false;
				ClearUpdate();
			});
		}

		private void OnError()
		{
			SentrySdk.AddBreadcrumb("[SocketConnection] OnError");
			PopupErrorGvg3();
			IsConnected = false;
			IsErrorShowed = true;
			CurrentConnectInfo = string.Empty;
			CloseConnect();
			ClearUpdate();
			SharedMessenger.Broadcast("ON_SOCKET_ERROR");
			SharedMessenger.Broadcast("ON_SOCKET_ERROR_EXT", this);
		}

		private void OnApplicationFocus(bool isFocus)
		{
			if (isFocus && IsConnected)
			{
				Request(new C2S_Ping(), delegate
				{
				});
			}
		}

		private void AddTimeoutCounting(int msgIdx, ePackageId packageId)
		{
			if (packageId != ePackageId.ConnectSocket)
			{
				RequestTimer_Dict.Add(msgIdx, new RequestTimer
				{
					RequestTime = CurrentTime,
					RequestFrame = Time.frameCount,
					TimeoutTime = CurrentTime + 5.0,
					PackageId = packageId,
					MgsId = msgIdx
				});
			}
		}

		private bool RemoveTimeoutCounting(int msgIdx)
		{
			TimeoutMgsIds.Remove(msgIdx);
			if (RequestTimer_Dict.ContainsKey(msgIdx))
			{
				return RequestTimer_Dict.Remove(msgIdx);
			}
			return false;
		}

		private void ClearTimeoutCounting()
		{
			RequestTimer_Dict.Clear();
			MapRequestCallBack.Clear();
			if (TimeoutCoroutineHandler != null)
			{
				((MonoBehaviour)SuperSocketClient).StopCoroutine(TimeoutCoroutineHandler);
				TimeoutCoroutineHandler = null;
			}
			HasShowTimeout = false;
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
		}

		private void StartTimeoutCounting()
		{
			ClearTimeoutCounting();
			TimeoutCoroutineHandler = ((MonoBehaviour)SuperSocketClient).StartCoroutine(Counter());
			IEnumerator Counter()
			{
				while (true)
				{
					double now = CurrentTime;
					bool hasTimeout = false;
					if (RequestTimer_Dict.Count > 0)
					{
						bool needTestConnection = false;
						bool needCallError = false;
						foreach (RequestTimer timer in RequestTimer_Dict.Values)
						{
							double timeExceeded = now - timer.TimeoutTime;
							if (0.0 < timeExceeded && timeExceeded < 5.0)
							{
								hasTimeout = true;
								if (timer.PackageId == ePackageId.C2S_TestConnection)
								{
									ILRuntimeDebug.LogError($"[SocketConnection] type={Type} C2S_TestConnection 请求超时, 认为断网或与服务器断连");
									SentrySdk.AddBreadcrumb($"[SocketConnection] type={Type} C2S_TestConnection 请求超时, 认为断网或与服务器断连");
									needCallError = true;
								}
								else if (!TimeoutMgsIds.Contains(timer.MgsId))
								{
									SentrySdk.AddBreadcrumb($"[SocketConnection] SetTimeOut msgIdx={timer.MgsId}, requestFrame: {timer.RequestFrame}/{Time.frameCount} packageId = {timer.PackageId}");
									TimeoutMgsIds.Add(timer.MgsId);
									needTestConnection = true;
								}
							}
						}
						if (needCallError)
						{
							OnError();
						}
						else if (needTestConnection)
						{
							if (_errorState == LogErrorState.Empty && CurrentTime - _lastTestConnectionTime < 1.0)
							{
								_errorState = LogErrorState.Logging;
							}
							else if (_errorState == LogErrorState.Logging)
							{
								_errorState = LogErrorState.Empty;
								ILRuntimeDebug.LogError("[SocketConnection] 完成断网重连统计");
							}
							_lastTestConnectionTime = CurrentTime;
							Request(new C2S_TestConnection(), delegate
							{
							});
						}
					}
					if (HasShowTimeout != hasTimeout)
					{
						HasShowTimeout = hasTimeout;
						GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(HasShowTimeout);
					}
					yield return (object)new WaitForSecondsRealtime(0.5f);
				}
			}
		}

		private void PopupErrorGvg3()
		{
			if (!GameController.Contexts.Service<IUiService>().HasShowingUi(UI_UniversalConfirmPopup.Name) && (GameController.Contexts.Service<IUiService>().HasShowingUi(UI_GvGExpeditionHallPanel.Name) || GameController.Contexts.Service<IUiService>().HasShowingUi(UI_main_GvGWorldMap3.Name) || GameController.Contexts.Service<IUiService>().HasShowingUi(UI_main_GvGOnIsland3.Name)))
			{
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(PopErrorNextFrame());
			}
			IEnumerator PopErrorNextFrame()
			{
				yield return null;
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
				{
					{
						"Content",
						"GvGReconnectTip".ToLanguage()
					},
					{
						"Buttons",
						new Dictionary<string, Action> { 
						{
							"Confirm",
							delegate
							{
								OnClickReconnect(PopupErrorGvg3);
							}
						} }
					},
					{ "PageIndex", 4 },
					{
						"ConfirmTitle",
						"BtnTitle_Reconnect".ToLanguage()
					},
					{ "ClickSound", "Confirm" },
					{ "Order", 999999 }
				}, multiMode: false, ignoreQueue: true);
			}
		}

		public void OnClickReconnect(Action errorCallback)
		{
			GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
			TimerCallback val = default(TimerCallback);
			Reconnect(delegate
			{
				GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
				SharedMessenger.Broadcast("ON_SOCKET_RECONNECT");
			}, delegate
			{
				//IL_001e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0023: Unknown result type (might be due to invalid IL or missing references)
				//IL_0025: Expected O, but got Unknown
				//IL_002a: Expected O, but got Unknown
				Timers inst = Timers.inst;
				TimerCallback obj = val;
				if (obj == null)
				{
					TimerCallback val2 = delegate
					{
						GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
						errorCallback();
					};
					TimerCallback val3 = val2;
					val = val2;
					obj = val3;
				}
				inst.Add(1f, 1, obj);
			});
		}

		private void ClearUpdate()
		{
			ActionQueue.Clear();
			if (UpdateCoroutineHandler != null)
			{
				((MonoBehaviour)SuperSocketClient).StopCoroutine(UpdateCoroutineHandler);
				UpdateCoroutineHandler = null;
			}
		}

		private void StartUpdate()
		{
			ClearUpdate();
			UpdateCoroutineHandler = ((MonoBehaviour)SuperSocketClient).StartCoroutine(Update());
			IEnumerator Update()
			{
				while (true)
				{
					if (ActionQueue.Count > 0)
					{
						ActionQueue.Dequeue()();
					}
					yield return null;
				}
			}
		}
	}

	public class SocketErrorCode
	{
		public const int UnknownError = -1;

		public const int Success = 0;
	}

	public class MapPackageIdTypes
	{
		public Type BaseBodyContext;

		public Type Response;

		public Type Request;
	}

	private Dictionary<eConType, SocketConnection> Connections_Dict;

	private static SocketManager _Instance = null;

	public static Dictionary<int, MapPackageIdTypes> Map_PackageId_PackageIdTypes = new Dictionary<int, MapPackageIdTypes>
	{
		{
			2,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_RegistUserSessionCommand),
				Response = typeof(C2S_RegistUserSessionCommand.Response),
				Request = typeof(C2S_RegistUserSessionCommand.Request)
			}
		},
		{
			-6,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_TestConnection),
				Response = typeof(C2S_TestConnection.Response),
				Request = typeof(C2S_TestConnection.Request)
			}
		},
		{
			-5,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_Ping),
				Response = typeof(C2S_Ping.Response),
				Request = typeof(C2S_Ping.Request)
			}
		},
		{
			100010,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ChangeMapViewLevel),
				Response = typeof(C2S_ChangeMapViewLevel.Response),
				Request = typeof(C2S_ChangeMapViewLevel.Request)
			}
		},
		{
			1000,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BroadcastEOIBattleField),
				Response = typeof(S2C_BroadcastEOIBattleField.Response),
				Request = typeof(S2C_BroadcastEOIBattleField.Request)
			}
		},
		{
			1002,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BroadcastIslandInitInfo),
				Response = typeof(S2C_BroadcastIslandInitInfo.Response),
				Request = typeof(S2C_BroadcastIslandInitInfo.Request)
			}
		},
		{
			-2,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_TestCommand),
				Response = typeof(C2S_TestCommand.Response),
				Request = typeof(C2S_TestCommand.Request)
			}
		},
		{
			100011,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetIslandInfos),
				Response = typeof(C2S_GetIslandInfos.Response),
				Request = typeof(C2S_GetIslandInfos.Request)
			}
		},
		{
			100015,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetBossHp),
				Response = typeof(C2S_GetBossHp.Response),
				Request = typeof(C2S_GetBossHp.Request)
			}
		},
		{
			1004,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BroadcastBossHp),
				Response = typeof(S2C_BroadcastBossHp.Response),
				Request = typeof(S2C_BroadcastBossHp.Request)
			}
		},
		{
			1005,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BattleResult),
				Response = typeof(S2C_BattleResult.Response),
				Request = typeof(S2C_BattleResult.Request)
			}
		},
		{
			1007,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BroadcastBattleDamageInfo),
				Response = typeof(S2C_BroadcastBattleDamageInfo.Response),
				Request = typeof(S2C_BroadcastBattleDamageInfo.Request)
			}
		},
		{
			100018,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetBattleDamageDetailInfo),
				Response = typeof(C2S_GetBattleDamageDetailInfo.Response),
				Request = typeof(C2S_GetBattleDamageDetailInfo.Request)
			}
		},
		{
			100019,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetCurBattleDetailInfo),
				Response = typeof(C2S_GetCurBattleDetailInfo.Response),
				Request = typeof(C2S_GetCurBattleDetailInfo.Request)
			}
		},
		{
			1008,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_StartOneBattle),
				Response = typeof(S2C_StartOneBattle.Response),
				Request = typeof(S2C_StartOneBattle.Request)
			}
		},
		{
			1006,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BroadcastEntitiesDead),
				Response = typeof(S2C_BroadcastEntitiesDead.Response),
				Request = typeof(S2C_BroadcastEntitiesDead.Request)
			}
		},
		{
			1016,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ChangeCampScore),
				Response = typeof(S2C_ChangeCampScore.Response),
				Request = typeof(S2C_ChangeCampScore.Request)
			}
		},
		{
			1010,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ChangeIZProgress),
				Response = typeof(S2C_ChangeIZProgress.Response),
				Request = typeof(S2C_ChangeIZProgress.Request)
			}
		},
		{
			1013,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_IslandSummary),
				Response = typeof(S2C_IslandSummary.Response),
				Request = typeof(S2C_IslandSummary.Request)
			}
		},
		{
			1015,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_MakeFlightSchedule),
				Response = typeof(S2C_MakeFlightSchedule.Response),
				Request = typeof(S2C_MakeFlightSchedule.Request)
			}
		},
		{
			1012,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ShipSummaryCreateSuccess),
				Response = typeof(S2C_ShipSummaryCreateSuccess.Response),
				Request = typeof(S2C_ShipSummaryCreateSuccess.Request)
			}
		},
		{
			1085,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode2_ChangeHoldingCamp),
				Response = typeof(S2C_GvGMode2_ChangeHoldingCamp.Response),
				Request = typeof(S2C_GvGMode2_ChangeHoldingCamp.Request)
			}
		},
		{
			1084,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode2_HoldingPercent),
				Response = typeof(S2C_GvGMode2_HoldingPercent.Response),
				Request = typeof(S2C_GvGMode2_HoldingPercent.Request)
			}
		},
		{
			1086,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode2_NewEntityKeyInfo),
				Response = typeof(S2C_GvGMode2_NewEntityKeyInfo.Response),
				Request = typeof(S2C_GvGMode2_NewEntityKeyInfo.Request)
			}
		},
		{
			4,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_AcceptPushFlag),
				Response = typeof(C2S_AcceptPushFlag.Response),
				Request = typeof(C2S_AcceptPushFlag.Request)
			}
		},
		{
			100024,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ShipSummaryChangeFormationId),
				Response = typeof(C2S_ShipSummaryChangeFormationId.Response),
				Request = typeof(C2S_ShipSummaryChangeFormationId.Request)
			}
		},
		{
			100020,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetEOIEntities),
				Response = typeof(C2S_GetEOIEntities.Response),
				Request = typeof(C2S_GetEOIEntities.Request)
			}
		},
		{
			100026,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetGvGMode2IZConfig),
				Response = typeof(C2S_GetGvGMode2IZConfig.Response),
				Request = typeof(C2S_GetGvGMode2IZConfig.Request)
			}
		},
		{
			100025,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetOwnShips),
				Response = typeof(C2S_GetOwnShips.Response),
				Request = typeof(C2S_GetOwnShips.Request)
			}
		},
		{
			100021,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetShipSummaryAndFlightSchedule),
				Response = typeof(C2S_GetShipSummaryAndFlightSchedule.Response),
				Request = typeof(C2S_GetShipSummaryAndFlightSchedule.Request)
			}
		},
		{
			1017,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ChangeShipSummaryStateFighting),
				Response = typeof(S2C_ChangeShipSummaryStateFighting.Response),
				Request = typeof(S2C_ChangeShipSummaryStateFighting.Request)
			}
		},
		{
			1018,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ChangeShipSummaryStateShipFillingUp),
				Response = typeof(S2C_ChangeShipSummaryStateShipFillingUp.Response),
				Request = typeof(S2C_ChangeShipSummaryStateShipFillingUp.Request)
			}
		},
		{
			100027,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetOwnCampKillInfo),
				Response = typeof(C2S_GetOwnCampKillInfo.Response),
				Request = typeof(C2S_GetOwnCampKillInfo.Request)
			}
		},
		{
			100022,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_MakeFlightSchedule),
				Response = typeof(C2S_MakeFlightSchedule.Response),
				Request = typeof(C2S_MakeFlightSchedule.Request)
			}
		},
		{
			1021,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_IslandCampSummary),
				Response = typeof(S2C_IslandCampSummary.Response),
				Request = typeof(S2C_IslandCampSummary.Request)
			}
		},
		{
			100028,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ChangeBattleStrategy),
				Response = typeof(C2S_ChangeBattleStrategy.Response),
				Request = typeof(C2S_ChangeBattleStrategy.Request)
			}
		},
		{
			100030,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetGvGMode2Island_EntityInfo),
				Response = typeof(C2S_GetGvGMode2Island_EntityInfo.Response),
				Request = typeof(C2S_GetGvGMode2Island_EntityInfo.Request)
			}
		},
		{
			100029,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetGvGMode2Island_EOIEntities),
				Response = typeof(C2S_GetGvGMode2Island_EOIEntities.Response),
				Request = typeof(C2S_GetGvGMode2Island_EOIEntities.Request)
			}
		},
		{
			100031,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetGvGMode2Island_IslandInfo),
				Response = typeof(C2S_GetGvGMode2Island_IslandInfo.Response),
				Request = typeof(C2S_GetGvGMode2Island_IslandInfo.Request)
			}
		},
		{
			1020,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BroadcastGvGMode2BattleResult),
				Response = typeof(S2C_BroadcastGvGMode2BattleResult.Response),
				Request = typeof(S2C_BroadcastGvGMode2BattleResult.Request)
			}
		},
		{
			1022,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode2StateChange),
				Response = typeof(S2C_GvGMode2StateChange.Response),
				Request = typeof(S2C_GvGMode2StateChange.Request)
			}
		},
		{
			1019,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_StartOneGvGMode2Battle),
				Response = typeof(S2C_StartOneGvGMode2Battle.Response),
				Request = typeof(S2C_StartOneGvGMode2Battle.Request)
			}
		},
		{
			1025,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_IZOver),
				Response = typeof(S2C_IZOver.Response),
				Request = typeof(S2C_IZOver.Request)
			}
		},
		{
			1027,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode2IslandStop),
				Response = typeof(S2C_GvGMode2IslandStop.Response),
				Request = typeof(S2C_GvGMode2IslandStop.Request)
			}
		},
		{
			1028,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode2ShipDead),
				Response = typeof(S2C_GvGMode2ShipDead.Response),
				Request = typeof(S2C_GvGMode2ShipDead.Request)
			}
		},
		{
			1031,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ChangeShipSummarySoldierCnt),
				Response = typeof(S2C_ChangeShipSummarySoldierCnt.Response),
				Request = typeof(S2C_ChangeShipSummarySoldierCnt.Request)
			}
		},
		{
			1032,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ShipDead),
				Response = typeof(S2C_ShipDead.Response),
				Request = typeof(S2C_ShipDead.Request)
			}
		},
		{
			1033,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ChangeBestKill),
				Response = typeof(S2C_ChangeBestKill.Response),
				Request = typeof(S2C_ChangeBestKill.Request)
			}
		},
		{
			100074,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_LaunchShip),
				Response = typeof(C2S_LaunchShip.Response),
				Request = typeof(C2S_LaunchShip.Request)
			}
		},
		{
			100546,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_OfflineShipSoldier),
				Response = typeof(C2S_OfflineShipSoldier.Response),
				Request = typeof(C2S_OfflineShipSoldier.Request)
			}
		},
		{
			100545,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_RebuildShip),
				Response = typeof(C2S_RebuildShip.Response),
				Request = typeof(C2S_RebuildShip.Request)
			}
		},
		{
			100081,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ChangeCameraPos),
				Response = typeof(C2S_ChangeCameraPos.Response),
				Request = typeof(C2S_ChangeCameraPos.Request)
			}
		},
		{
			100080,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetGvGMode3IslandEntityInfos),
				Response = typeof(C2S_GetGvGMode3IslandEntityInfos.Response),
				Request = typeof(C2S_GetGvGMode3IslandEntityInfos.Request)
			}
		},
		{
			100082,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GvGMode3GetShipSummaryAndFlightScheduleInfo),
				Response = typeof(C2S_GvGMode3GetShipSummaryAndFlightScheduleInfo.Response),
				Request = typeof(C2S_GvGMode3GetShipSummaryAndFlightScheduleInfo.Request)
			}
		},
		{
			100100,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetGvGMode3BaseInfo),
				Response = typeof(C2S_GetGvGMode3BaseInfo.Response),
				Request = typeof(C2S_GetGvGMode3BaseInfo.Request)
			}
		},
		{
			100527,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ClaimTreasureMapMission),
				Response = typeof(C2S_ClaimTreasureMapMission.Response),
				Request = typeof(C2S_ClaimTreasureMapMission.Request)
			}
		},
		{
			100070,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_SaveShipGroupConfig),
				Response = typeof(C2S_SaveShipGroupConfig.Response),
				Request = typeof(C2S_SaveShipGroupConfig.Request)
			}
		},
		{
			100060,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_IslandAction),
				Response = typeof(C2S_IslandAction.Response),
				Request = typeof(C2S_IslandAction.Request)
			}
		},
		{
			100531,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_CancelTreasureMapMission),
				Response = typeof(C2S_CancelTreasureMapMission.Response),
				Request = typeof(C2S_CancelTreasureMapMission.Request)
			}
		},
		{
			1039,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_IslandAction),
				Response = typeof(S2C_IslandAction.Response),
				Request = typeof(S2C_IslandAction.Request)
			}
		},
		{
			1038,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_StayIsland),
				Response = typeof(S2C_StayIsland.Response),
				Request = typeof(S2C_StayIsland.Request)
			}
		},
		{
			1041,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode3ShipSummarySpeed),
				Response = typeof(S2C_GvGMode3ShipSummarySpeed.Response),
				Request = typeof(S2C_GvGMode3ShipSummarySpeed.Request)
			}
		},
		{
			1042,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode3FoodOnboardCount),
				Response = typeof(S2C_GvGMode3FoodOnboardCount.Response),
				Request = typeof(S2C_GvGMode3FoodOnboardCount.Request)
			}
		},
		{
			100220,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BroadcastChatChannelMessages),
				Response = typeof(S2C_BroadcastChatChannelMessages.Response),
				Request = typeof(S2C_BroadcastChatChannelMessages.Request)
			}
		},
		{
			100221,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BroadcastSystemMessages),
				Response = typeof(S2C_BroadcastSystemMessages.Response),
				Request = typeof(S2C_BroadcastSystemMessages.Request)
			}
		},
		{
			1053,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GroupCountLimit),
				Response = typeof(S2C_GroupCountLimit.Response),
				Request = typeof(S2C_GroupCountLimit.Request)
			}
		},
		{
			1054,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BackupGroupSlotLimit),
				Response = typeof(S2C_BackupGroupSlotLimit.Response),
				Request = typeof(S2C_BackupGroupSlotLimit.Request)
			}
		},
		{
			100302,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ActivateTalent_ResetResult),
				Response = typeof(S2C_ActivateTalent_ResetResult.Response),
				Request = typeof(S2C_ActivateTalent_ResetResult.Request)
			}
		},
		{
			1092,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_PostFormulaOEMMission),
				Response = typeof(S2C_PostFormulaOEMMission.Response),
				Request = typeof(S2C_PostFormulaOEMMission.Request)
			}
		},
		{
			1093,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_SelfFormulaOEMMissionChanged),
				Response = typeof(S2C_SelfFormulaOEMMissionChanged.Response),
				Request = typeof(S2C_SelfFormulaOEMMissionChanged.Request)
			}
		},
		{
			100321,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2COuterTechSplitBluePrint),
				Response = typeof(S2COuterTechSplitBluePrint.Response),
				Request = typeof(S2COuterTechSplitBluePrint.Request)
			}
		},
		{
			100322,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_OuterTechAmpTransform),
				Response = typeof(C2S_OuterTechAmpTransform.Response),
				Request = typeof(C2S_OuterTechAmpTransform.Request)
			}
		},
		{
			1058,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_SubmitFlagShipReq),
				Response = typeof(S2C_SubmitFlagShipReq.Response),
				Request = typeof(S2C_SubmitFlagShipReq.Request)
			}
		},
		{
			1065,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BuyNPCShop),
				Response = typeof(S2C_BuyNPCShop.Response),
				Request = typeof(S2C_BuyNPCShop.Request)
			}
		},
		{
			1087,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_CanNotCollecting),
				Response = typeof(S2C_CanNotCollecting.Response),
				Request = typeof(S2C_CanNotCollecting.Request)
			}
		},
		{
			1088,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_OuterTechAmpTransfrom),
				Response = typeof(S2C_OuterTechAmpTransfrom.Response),
				Request = typeof(S2C_OuterTechAmpTransfrom.Request)
			}
		},
		{
			1069,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_FinishNPCDialogMission),
				Response = typeof(S2C_FinishNPCDialogMission.Response),
				Request = typeof(S2C_FinishNPCDialogMission.Request)
			}
		},
		{
			1067,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_SyncRunningTreasureMapEvent),
				Response = typeof(S2C_SyncRunningTreasureMapEvent.Response),
				Request = typeof(S2C_SyncRunningTreasureMapEvent.Request)
			}
		},
		{
			1057,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ShipCountLimit),
				Response = typeof(S2C_ShipCountLimit.Response),
				Request = typeof(S2C_ShipCountLimit.Request)
			}
		},
		{
			1055,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ResetTalentFinish),
				Response = typeof(S2C_ResetTalentFinish.Response),
				Request = typeof(S2C_ResetTalentFinish.Request)
			}
		},
		{
			1059,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_PostOEMMission),
				Response = typeof(S2C_PostOEMMission.Response),
				Request = typeof(S2C_PostOEMMission.Request)
			}
		},
		{
			1060,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_SelfOEMMissionChanged),
				Response = typeof(S2C_SelfOEMMissionChanged.Response),
				Request = typeof(S2C_SelfOEMMissionChanged.Request)
			}
		},
		{
			1061,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_Purification),
				Response = typeof(S2C_Purification.Response),
				Request = typeof(S2C_Purification.Request)
			}
		},
		{
			1073,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BattlePassPaidCertChanged),
				Response = typeof(S2C_BattlePassPaidCertChanged.Response),
				Request = typeof(S2C_BattlePassPaidCertChanged.Request)
			}
		},
		{
			1071,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ContributionPointsChanged),
				Response = typeof(S2C_ContributionPointsChanged.Response),
				Request = typeof(S2C_ContributionPointsChanged.Request)
			}
		},
		{
			1070,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_CreatePlayerCommand),
				Response = typeof(S2C_CreatePlayerCommand.Response),
				Request = typeof(S2C_CreatePlayerCommand.Request)
			}
		},
		{
			1066,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_FlagShipState),
				Response = typeof(S2C_FlagShipState.Response),
				Request = typeof(S2C_FlagShipState.Request)
			}
		},
		{
			1074,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_SyncFinalProgressInfo),
				Response = typeof(S2C_SyncFinalProgressInfo.Response),
				Request = typeof(S2C_SyncFinalProgressInfo.Request)
			}
		},
		{
			1075,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GetFinalProgressBossDamageTodayTop3),
				Response = typeof(S2C_GetFinalProgressBossDamageTodayTop3.Response),
				Request = typeof(S2C_GetFinalProgressBossDamageTodayTop3.Request)
			}
		},
		{
			1082,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_RebuildShip),
				Response = typeof(S2C_RebuildShip.Response),
				Request = typeof(S2C_RebuildShip.Request)
			}
		},
		{
			1096,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ShipContinueExecutePlan),
				Response = typeof(S2C_ShipContinueExecutePlan.Response),
				Request = typeof(S2C_ShipContinueExecutePlan.Request)
			}
		},
		{
			1090,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BuySweepCount),
				Response = typeof(S2C_BuySweepCount.Response),
				Request = typeof(S2C_BuySweepCount.Request)
			}
		},
		{
			100412,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ResetOuterTech),
				Response = typeof(S2C_ResetOuterTech.Response),
				Request = typeof(S2C_ResetOuterTech.Request)
			}
		},
		{
			100413,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_DailySuppressBonusTimesChange),
				Response = typeof(S2C_DailySuppressBonusTimesChange.Response),
				Request = typeof(S2C_DailySuppressBonusTimesChange.Request)
			}
		},
		{
			1097,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ShipPlanChangeSoldier),
				Response = typeof(S2C_ShipPlanChangeSoldier.Response),
				Request = typeof(S2C_ShipPlanChangeSoldier.Request)
			}
		},
		{
			1098,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_CreateShipPlanSuccess),
				Response = typeof(S2C_CreateShipPlanSuccess.Response),
				Request = typeof(S2C_CreateShipPlanSuccess.Request)
			}
		},
		{
			1099,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BrawlReplayCreateShip),
				Response = typeof(S2C_BrawlReplayCreateShip.Response),
				Request = typeof(S2C_BrawlReplayCreateShip.Request)
			}
		},
		{
			1101,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BrawlReplayKeyFrame),
				Response = typeof(S2C_BrawlReplayKeyFrame.Response),
				Request = typeof(S2C_BrawlReplayKeyFrame.Request)
			}
		},
		{
			1102,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BrawlReplayScoreChanged),
				Response = typeof(S2C_BrawlReplayScoreChanged.Response),
				Request = typeof(S2C_BrawlReplayScoreChanged.Request)
			}
		},
		{
			1103,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BrawlReplayNotification),
				Response = typeof(S2C_BrawlReplayNotification.Response),
				Request = typeof(S2C_BrawlReplayNotification.Request)
			}
		},
		{
			100083,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetGvGMode3IslandDetailInfo),
				Response = typeof(C2S_GetGvGMode3IslandDetailInfo.Response),
				Request = typeof(C2S_GetGvGMode3IslandDetailInfo.Request)
			}
		},
		{
			100521,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_BuyNPCShop),
				Response = typeof(C2S_BuyNPCShop.Response),
				Request = typeof(C2S_BuyNPCShop.Request)
			}
		},
		{
			100540,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetAllContributionExcludingBuy),
				Response = typeof(C2S_GetAllContributionExcludingBuy.Response),
				Request = typeof(C2S_GetAllContributionExcludingBuy.Request)
			}
		},
		{
			100541,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ClaimBattlePassBonus),
				Response = typeof(C2S_ClaimBattlePassBonus.Response),
				Request = typeof(C2S_ClaimBattlePassBonus.Request)
			}
		},
		{
			100520,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetNPCShop),
				Response = typeof(C2S_GetNPCShop.Response),
				Request = typeof(C2S_GetNPCShop.Request)
			}
		},
		{
			100522,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_FinishNPCDialogMission),
				Response = typeof(C2S_FinishNPCDialogMission.Response),
				Request = typeof(C2S_FinishNPCDialogMission.Request)
			}
		},
		{
			100041,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ChangeShipAmplifiers),
				Response = typeof(C2S_ChangeShipAmplifiers.Response),
				Request = typeof(C2S_ChangeShipAmplifiers.Request)
			}
		},
		{
			100040,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ForgeAmplifier),
				Response = typeof(C2S_ForgeAmplifier.Response),
				Request = typeof(C2S_ForgeAmplifier.Request)
			}
		},
		{
			100042,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetAmplifierStorage),
				Response = typeof(C2S_GetAmplifierStorage.Response),
				Request = typeof(C2S_GetAmplifierStorage.Request)
			}
		},
		{
			100043,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetShipAmplifiers),
				Response = typeof(C2S_GetShipAmplifiers.Response),
				Request = typeof(C2S_GetShipAmplifiers.Request)
			}
		},
		{
			100034,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetStorehouse),
				Response = typeof(C2S_GetStorehouse.Response),
				Request = typeof(C2S_GetStorehouse.Request)
			}
		},
		{
			100071,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_FillupSoldiers),
				Response = typeof(C2S_FillupSoldiers.Response),
				Request = typeof(C2S_FillupSoldiers.Request)
			}
		},
		{
			100075,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetUnitDetailInfo),
				Response = typeof(C2S_GetUnitDetailInfo.Response),
				Request = typeof(C2S_GetUnitDetailInfo.Request)
			}
		},
		{
			100312,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2SOuterTechSplitBluePrint),
				Response = typeof(C2SOuterTechSplitBluePrint.Response),
				Request = typeof(C2SOuterTechSplitBluePrint.Request)
			}
		},
		{
			100076,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetShipCollectingDetailInfo),
				Response = typeof(C2S_GetShipCollectingDetailInfo.Response),
				Request = typeof(C2S_GetShipCollectingDetailInfo.Request)
			}
		},
		{
			100077,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ChangeShipCollectingInfo),
				Response = typeof(C2S_ChangeShipCollectingInfo.Response),
				Request = typeof(C2S_ChangeShipCollectingInfo.Request)
			}
		},
		{
			100084,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetPreFlightSchedule),
				Response = typeof(C2S_GetPreFlightSchedule.Response),
				Request = typeof(C2S_GetPreFlightSchedule.Request)
			}
		},
		{
			100103,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetRealTimeCollectingEfficiencyModel),
				Response = typeof(C2S_GetRealTimeCollectingEfficiencyModel.Response),
				Request = typeof(C2S_GetRealTimeCollectingEfficiencyModel.Request)
			}
		},
		{
			100101,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetRealTimeFoodCostReduceModel),
				Response = typeof(C2S_GetRealTimeFoodCostReduceModel.Response),
				Request = typeof(C2S_GetRealTimeFoodCostReduceModel.Request)
			}
		},
		{
			100102,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetRealTimeShipSummarySpeedModel),
				Response = typeof(C2S_GetRealTimeShipSummarySpeedModel.Response),
				Request = typeof(C2S_GetRealTimeShipSummarySpeedModel.Request)
			}
		},
		{
			100085,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetLaunchableIsland),
				Response = typeof(C2S_GetLaunchableIsland.Response),
				Request = typeof(C2S_GetLaunchableIsland.Request)
			}
		},
		{
			100104,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetGvGMode3ShipTemporaryData),
				Response = typeof(C2S_GetGvGMode3ShipTemporaryData.Response),
				Request = typeof(C2S_GetGvGMode3ShipTemporaryData.Request)
			}
		},
		{
			100105,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetRealTimeStorehouseLimitParModel),
				Response = typeof(C2S_GetRealTimeStorehouseLimitParModel.Response),
				Request = typeof(C2S_GetRealTimeStorehouseLimitParModel.Request)
			}
		},
		{
			100300,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetActiveTalents),
				Response = typeof(C2S_GetActiveTalents.Response),
				Request = typeof(C2S_GetActiveTalents.Request)
			}
		},
		{
			100301,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ActivateTalent),
				Response = typeof(C2S_ActivateTalent.Response),
				Request = typeof(C2S_ActivateTalent.Request)
			}
		},
		{
			100303,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetActivateTalentStat),
				Response = typeof(C2S_GetActivateTalentStat.Response),
				Request = typeof(C2S_GetActivateTalentStat.Request)
			}
		},
		{
			100555,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_PostFormulaOEMMission),
				Response = typeof(C2S_PostFormulaOEMMission.Response),
				Request = typeof(C2S_PostFormulaOEMMission.Request)
			}
		},
		{
			100507,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ClaimSelfOEMMissions),
				Response = typeof(C2S_ClaimSelfOEMMissions.Response),
				Request = typeof(C2S_ClaimSelfOEMMissions.Request)
			}
		},
		{
			100504,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_SubmitOEMMission),
				Response = typeof(C2S_SubmitOEMMission.Response),
				Request = typeof(C2S_SubmitOEMMission.Request)
			}
		},
		{
			100213,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetSystemMessages_IslandBattleLog),
				Response = typeof(C2S_GetSystemMessages_IslandBattleLog.Response),
				Request = typeof(C2S_GetSystemMessages_IslandBattleLog.Request)
			}
		},
		{
			100401,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetIslandRunningBattleLog),
				Response = typeof(C2S_GetIslandRunningBattleLog.Response),
				Request = typeof(C2S_GetIslandRunningBattleLog.Request)
			}
		},
		{
			100400,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetPlayerBattleLog),
				Response = typeof(C2S_GetPlayerBattleLog.Response),
				Request = typeof(C2S_GetPlayerBattleLog.Request)
			}
		},
		{
			100211,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetChatChannelMessages),
				Response = typeof(C2S_GetChatChannelMessages.Response),
				Request = typeof(C2S_GetChatChannelMessages.Request)
			}
		},
		{
			100212,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetSystemMessages),
				Response = typeof(C2S_GetSystemMessages.Response),
				Request = typeof(C2S_GetSystemMessages.Request)
			}
		},
		{
			100200,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_SendChatChannelMessage),
				Response = typeof(C2S_SendChatChannelMessage.Response),
				Request = typeof(C2S_SendChatChannelMessage.Request)
			}
		},
		{
			100500,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetFlagShipReq),
				Response = typeof(C2S_GetFlagShipReq.Response),
				Request = typeof(C2S_GetFlagShipReq.Request)
			}
		},
		{
			100501,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_SubmitFlagShipReq),
				Response = typeof(C2S_SubmitFlagShipReq.Response),
				Request = typeof(C2S_SubmitFlagShipReq.Request)
			}
		},
		{
			100505,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetSelfOEMMissions),
				Response = typeof(C2S_GetSelfOEMMissions.Response),
				Request = typeof(C2S_GetSelfOEMMissions.Request)
			}
		},
		{
			100503,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetOEMMissions),
				Response = typeof(C2S_GetOEMMissions.Response),
				Request = typeof(C2S_GetOEMMissions.Request)
			}
		},
		{
			100512,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetFoodDailySupplyInfo),
				Response = typeof(C2S_GetFoodDailySupplyInfo.Response),
				Request = typeof(C2S_GetFoodDailySupplyInfo.Request)
			}
		},
		{
			100513,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GiveFoodDailySupplyToShip),
				Response = typeof(C2S_GiveFoodDailySupplyToShip.Response),
				Request = typeof(C2S_GiveFoodDailySupplyToShip.Request)
			}
		},
		{
			100511,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetTalentDailySupplyBox),
				Response = typeof(C2S_GetTalentDailySupplyBox.Response),
				Request = typeof(C2S_GetTalentDailySupplyBox.Request)
			}
		},
		{
			100509,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ClaimYesterdayContributionItem),
				Response = typeof(C2S_ClaimYesterdayContributionItem.Response),
				Request = typeof(C2S_ClaimYesterdayContributionItem.Request)
			}
		},
		{
			100510,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetContributionItemInfo),
				Response = typeof(C2S_GetContributionItemInfo.Response),
				Request = typeof(C2S_GetContributionItemInfo.Request)
			}
		},
		{
			100502,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_PostOEMMission),
				Response = typeof(C2S_PostOEMMission.Response),
				Request = typeof(C2S_PostOEMMission.Request)
			}
		},
		{
			100517,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetCampEnergy),
				Response = typeof(C2S_GetCampEnergy.Response),
				Request = typeof(C2S_GetCampEnergy.Request)
			}
		},
		{
			100506,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetOEMMissionsState),
				Response = typeof(C2S_GetOEMMissionsState.Response),
				Request = typeof(C2S_GetOEMMissionsState.Request)
			}
		},
		{
			100508,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_Purification),
				Response = typeof(C2S_Purification.Response),
				Request = typeof(C2S_Purification.Request)
			}
		},
		{
			100518,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetCampInfo),
				Response = typeof(C2S_GetCampInfo.Response),
				Request = typeof(C2S_GetCampInfo.Request)
			}
		},
		{
			100516,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetMissions),
				Response = typeof(C2S_GetMissions.Response),
				Request = typeof(C2S_GetMissions.Request)
			}
		},
		{
			100515,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ClaimMission),
				Response = typeof(C2S_ClaimMission.Response),
				Request = typeof(C2S_ClaimMission.Request)
			}
		},
		{
			100519,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ClaimMainMissionRankReward),
				Response = typeof(C2S_ClaimMainMissionRankReward.Response),
				Request = typeof(C2S_ClaimMainMissionRankReward.Request)
			}
		},
		{
			100528,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_CreatePlayerCommand),
				Response = typeof(C2S_CreatePlayerCommand.Response),
				Request = typeof(C2S_CreatePlayerCommand.Request)
			}
		},
		{
			100529,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_CancelPlayerCommand),
				Response = typeof(C2S_CancelPlayerCommand.Response),
				Request = typeof(C2S_CancelPlayerCommand.Request)
			}
		},
		{
			100530,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_CheckPlayerCommandMessage),
				Response = typeof(C2S_CheckPlayerCommandMessage.Response),
				Request = typeof(C2S_CheckPlayerCommandMessage.Request)
			}
		},
		{
			100524,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_SubmitShadowEnergy),
				Response = typeof(C2S_SubmitShadowEnergy.Response),
				Request = typeof(C2S_SubmitShadowEnergy.Request)
			}
		},
		{
			100542,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetFinalProgressRank),
				Response = typeof(C2S_GetFinalProgressRank.Response),
				Request = typeof(C2S_GetFinalProgressRank.Request)
			}
		},
		{
			100526,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetFinalProgressInfo),
				Response = typeof(C2S_GetFinalProgressInfo.Response),
				Request = typeof(C2S_GetFinalProgressInfo.Request)
			}
		},
		{
			100543,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetFinalProgressBossDamageTodayTop3),
				Response = typeof(C2S_GetFinalProgressBossDamageTodayTop3.Response),
				Request = typeof(C2S_GetFinalProgressBossDamageTodayTop3.Request)
			}
		},
		{
			100551,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetShipAllCombatPower),
				Response = typeof(C2S_GetShipAllCombatPower.Response),
				Request = typeof(C2S_GetShipAllCombatPower.Request)
			}
		},
		{
			100554,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetUserProfileDatas),
				Response = typeof(C2S_GetUserProfileDatas.Response),
				Request = typeof(C2S_GetUserProfileDatas.Request)
			}
		},
		{
			100560,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_RefreshFormulaOEMMissios),
				Response = typeof(C2S_RefreshFormulaOEMMissios.Response),
				Request = typeof(C2S_RefreshFormulaOEMMissios.Request)
			}
		},
		{
			100556,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_SubmitFormulaOEMMission),
				Response = typeof(C2S_SubmitFormulaOEMMission.Response),
				Request = typeof(C2S_SubmitFormulaOEMMission.Request)
			}
		},
		{
			100558,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetSelfFormulaOEMMissions),
				Response = typeof(C2S_GetSelfFormulaOEMMissions.Response),
				Request = typeof(C2S_GetSelfFormulaOEMMissions.Request)
			}
		},
		{
			100559,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ClaimSelfFormulaOEMMissions),
				Response = typeof(C2S_ClaimSelfFormulaOEMMissions.Response),
				Request = typeof(C2S_ClaimSelfFormulaOEMMissions.Request)
			}
		},
		{
			100557,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetFormulaOEMMissios),
				Response = typeof(C2S_GetFormulaOEMMissios.Response),
				Request = typeof(C2S_GetFormulaOEMMissios.Request)
			}
		},
		{
			100561,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetUserIslandOfInterest),
				Response = typeof(C2S_GetUserIslandOfInterest.Response),
				Request = typeof(C2S_GetUserIslandOfInterest.Request)
			}
		},
		{
			100035,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ChangeGvGMode3BattleStrategy),
				Response = typeof(C2S_ChangeGvGMode3BattleStrategy.Response),
				Request = typeof(C2S_ChangeGvGMode3BattleStrategy.Request)
			}
		},
		{
			100038,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetGvGMode3Island_EntityInfo),
				Response = typeof(C2S_GetGvGMode3Island_EntityInfo.Response),
				Request = typeof(C2S_GetGvGMode3Island_EntityInfo.Request)
			}
		},
		{
			100036,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetGvGMode3Island_EOIEntities),
				Response = typeof(C2S_GetGvGMode3Island_EOIEntities.Response),
				Request = typeof(C2S_GetGvGMode3Island_EOIEntities.Request)
			}
		},
		{
			100037,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetGvGMode3Island_IslandInfo),
				Response = typeof(C2S_GetGvGMode3Island_IslandInfo.Response),
				Request = typeof(C2S_GetGvGMode3Island_IslandInfo.Request)
			}
		},
		{
			1040,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BroadcastGvGMode3BattleResult),
				Response = typeof(S2C_BroadcastGvGMode3BattleResult.Response),
				Request = typeof(S2C_BroadcastGvGMode3BattleResult.Request)
			}
		},
		{
			1046,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ChangeGvGMode3BestKill),
				Response = typeof(S2C_ChangeGvGMode3BestKill.Response),
				Request = typeof(S2C_ChangeGvGMode3BestKill.Request)
			}
		},
		{
			1047,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode3IslandRank),
				Response = typeof(S2C_GvGMode3IslandRank.Response),
				Request = typeof(S2C_GvGMode3IslandRank.Request)
			}
		},
		{
			1044,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode3IslandStop),
				Response = typeof(S2C_GvGMode3IslandStop.Response),
				Request = typeof(S2C_GvGMode3IslandStop.Request)
			}
		},
		{
			1045,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode3ShipDead),
				Response = typeof(S2C_GvGMode3ShipDead.Response),
				Request = typeof(S2C_GvGMode3ShipDead.Request)
			}
		},
		{
			1043,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGStateChange),
				Response = typeof(S2C_GvGStateChange.Response),
				Request = typeof(S2C_GvGStateChange.Request)
			}
		},
		{
			1023,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ChangeHoldingCamp),
				Response = typeof(S2C_ChangeHoldingCamp.Response),
				Request = typeof(S2C_ChangeHoldingCamp.Request)
			}
		},
		{
			1024,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_HoldingPercent),
				Response = typeof(S2C_HoldingPercent.Response),
				Request = typeof(S2C_HoldingPercent.Request)
			}
		},
		{
			1026,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_NewEntityKeyInfo),
				Response = typeof(S2C_NewEntityKeyInfo.Response),
				Request = typeof(S2C_NewEntityKeyInfo.Request)
			}
		},
		{
			1035,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ItemChange),
				Response = typeof(S2C_ItemChange.Response),
				Request = typeof(S2C_ItemChange.Request)
			}
		},
		{
			1050,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_FillupFood),
				Response = typeof(S2C_FillupFood.Response),
				Request = typeof(S2C_FillupFood.Request)
			}
		},
		{
			1036,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_FillupSoldiers),
				Response = typeof(S2C_FillupSoldiers.Response),
				Request = typeof(S2C_FillupSoldiers.Request)
			}
		},
		{
			1051,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_SyncSoldierInfo),
				Response = typeof(S2C_SyncSoldierInfo.Response),
				Request = typeof(S2C_SyncSoldierInfo.Request)
			}
		},
		{
			100078,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_FillupFood),
				Response = typeof(C2S_FillupFood.Response),
				Request = typeof(C2S_FillupFood.Request)
			}
		},
		{
			100079,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetCanDestroyStatusAllMyShip),
				Response = typeof(C2S_GetCanDestroyStatusAllMyShip.Response),
				Request = typeof(C2S_GetCanDestroyStatusAllMyShip.Request)
			}
		},
		{
			1037,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode3IslandEntityInfo),
				Response = typeof(S2C_GvGMode3IslandEntityInfo.Response),
				Request = typeof(S2C_GvGMode3IslandEntityInfo.Request)
			}
		},
		{
			999,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_SystemPause),
				Response = typeof(S2C_SystemPause.Response),
				Request = typeof(S2C_SystemPause.Request)
			}
		},
		{
			998,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_SystemIZOver),
				Response = typeof(S2C_SystemIZOver.Response),
				Request = typeof(S2C_SystemIZOver.Request)
			}
		},
		{
			1052,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_SyncSoldierCount),
				Response = typeof(S2C_SyncSoldierCount.Response),
				Request = typeof(S2C_SyncSoldierCount.Request)
			}
		},
		{
			1079,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_WaitToClaimSystemMessageIdsCount),
				Response = typeof(S2C_WaitToClaimSystemMessageIdsCount.Response),
				Request = typeof(S2C_WaitToClaimSystemMessageIdsCount.Request)
			}
		},
		{
			100044,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ForgeAmplifier),
				Response = typeof(S2C_ForgeAmplifier.Response),
				Request = typeof(S2C_ForgeAmplifier.Request)
			}
		},
		{
			100410,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGStorehouseChange),
				Response = typeof(S2C_GvGStorehouseChange.Response),
				Request = typeof(S2C_GvGStorehouseChange.Request)
			}
		},
		{
			100086,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_UseItem),
				Response = typeof(C2S_UseItem.Response),
				Request = typeof(C2S_UseItem.Request)
			}
		},
		{
			1056,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_DestroyShip),
				Response = typeof(S2C_DestroyShip.Response),
				Request = typeof(S2C_DestroyShip.Request)
			}
		},
		{
			100045,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetAmplifierTalentData),
				Response = typeof(C2S_GetAmplifierTalentData.Response),
				Request = typeof(C2S_GetAmplifierTalentData.Request)
			}
		},
		{
			100514,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_Share额外发现CollectingGroup),
				Response = typeof(C2S_Share额外发现CollectingGroup.Response),
				Request = typeof(C2S_Share额外发现CollectingGroup.Request)
			}
		},
		{
			1062,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_地貌勘探ObDetectedIslands),
				Response = typeof(S2C_地貌勘探ObDetectedIslands.Response),
				Request = typeof(S2C_地貌勘探ObDetectedIslands.Request)
			}
		},
		{
			1063,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ShipSightRange),
				Response = typeof(S2C_ShipSightRange.Response),
				Request = typeof(S2C_ShipSightRange.Request)
			}
		},
		{
			100061,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_Share伟大航路DiscoveredIsland),
				Response = typeof(C2S_Share伟大航路DiscoveredIsland.Response),
				Request = typeof(C2S_Share伟大航路DiscoveredIsland.Request)
			}
		},
		{
			100062,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetEarlyWarningInfo),
				Response = typeof(C2S_GetEarlyWarningInfo.Response),
				Request = typeof(C2S_GetEarlyWarningInfo.Request)
			}
		},
		{
			100063,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetPreventionInfo),
				Response = typeof(C2S_GetPreventionInfo.Response),
				Request = typeof(C2S_GetPreventionInfo.Request)
			}
		},
		{
			1064,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode3IslandEvents),
				Response = typeof(S2C_GvGMode3IslandEvents.Response),
				Request = typeof(S2C_GvGMode3IslandEvents.Request)
			}
		},
		{
			100039,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetIncomingEnemyShips),
				Response = typeof(C2S_GetIncomingEnemyShips.Response),
				Request = typeof(C2S_GetIncomingEnemyShips.Request)
			}
		},
		{
			100214,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetSystemMessages_BattleResultBonus),
				Response = typeof(C2S_GetSystemMessages_BattleResultBonus.Response),
				Request = typeof(C2S_GetSystemMessages_BattleResultBonus.Request)
			}
		},
		{
			100215,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ClaimAllBattleResultBonus),
				Response = typeof(C2S_ClaimAllBattleResultBonus.Response),
				Request = typeof(C2S_ClaimAllBattleResultBonus.Request)
			}
		},
		{
			100534,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetGvGMode3Leaderboard),
				Response = typeof(C2S_GetGvGMode3Leaderboard.Response),
				Request = typeof(C2S_GetGvGMode3Leaderboard.Request)
			}
		},
		{
			100532,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ShipJump),
				Response = typeof(C2S_ShipJump.Response),
				Request = typeof(C2S_ShipJump.Request)
			}
		},
		{
			1076,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ShipJump),
				Response = typeof(S2C_ShipJump.Response),
				Request = typeof(S2C_ShipJump.Request)
			}
		},
		{
			1049,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode3ShipKillSoldiersCount),
				Response = typeof(S2C_GvGMode3ShipKillSoldiersCount.Response),
				Request = typeof(S2C_GvGMode3ShipKillSoldiersCount.Request)
			}
		},
		{
			1048,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode3ShipBossDamageRank),
				Response = typeof(S2C_GvGMode3ShipBossDamageRank.Response),
				Request = typeof(S2C_GvGMode3ShipBossDamageRank.Request)
			}
		},
		{
			1077,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode3NewIOI),
				Response = typeof(S2C_GvGMode3NewIOI.Response),
				Request = typeof(S2C_GvGMode3NewIOI.Request)
			}
		},
		{
			100544,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ShipRetreat),
				Response = typeof(C2S_ShipRetreat.Response),
				Request = typeof(C2S_ShipRetreat.Request)
			}
		},
		{
			1078,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_ShipCanRetreatTimestamp),
				Response = typeof(S2C_ShipCanRetreatTimestamp.Response),
				Request = typeof(S2C_ShipCanRetreatTimestamp.Request)
			}
		},
		{
			1080,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_UnlockedAmpFormulas),
				Response = typeof(S2C_UnlockedAmpFormulas.Response),
				Request = typeof(S2C_UnlockedAmpFormulas.Request)
			}
		},
		{
			1081,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_AttackEvent),
				Response = typeof(S2C_AttackEvent.Response),
				Request = typeof(S2C_AttackEvent.Request)
			}
		},
		{
			100547,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_DoSoulGuide),
				Response = typeof(C2S_DoSoulGuide.Response),
				Request = typeof(C2S_DoSoulGuide.Request)
			}
		},
		{
			1083,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_SoulGuideCooldown),
				Response = typeof(S2C_SoulGuideCooldown.Response),
				Request = typeof(S2C_SoulGuideCooldown.Request)
			}
		},
		{
			100548,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetNeedToSyncEOIShips),
				Response = typeof(C2S_GetNeedToSyncEOIShips.Response),
				Request = typeof(C2S_GetNeedToSyncEOIShips.Request)
			}
		},
		{
			100549,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetShipNearestFlagShipOrMoonIsland),
				Response = typeof(C2S_GetShipNearestFlagShipOrMoonIsland.Response),
				Request = typeof(C2S_GetShipNearestFlagShipOrMoonIsland.Request)
			}
		},
		{
			100550,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_SyncShipCollectingProduceState),
				Response = typeof(C2S_SyncShipCollectingProduceState.Response),
				Request = typeof(C2S_SyncShipCollectingProduceState.Request)
			}
		},
		{
			100553,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetTalent勘探强化CountDown),
				Response = typeof(C2S_GetTalent勘探强化CountDown.Response),
				Request = typeof(C2S_GetTalent勘探强化CountDown.Request)
			}
		},
		{
			100552,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_UseTalent勘探强化Detect),
				Response = typeof(C2S_UseTalent勘探强化Detect.Response),
				Request = typeof(C2S_UseTalent勘探强化Detect.Request)
			}
		},
		{
			100106,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetRealTimeGroupCountLimitModel),
				Response = typeof(C2S_GetRealTimeGroupCountLimitModel.Response),
				Request = typeof(C2S_GetRealTimeGroupCountLimitModel.Request)
			}
		},
		{
			100311,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_OuterTech_UseGreenWay),
				Response = typeof(C2S_OuterTech_UseGreenWay.Response),
				Request = typeof(C2S_OuterTech_UseGreenWay.Request)
			}
		},
		{
			100090,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_Sweep),
				Response = typeof(C2S_Sweep.Response),
				Request = typeof(C2S_Sweep.Request)
			}
		},
		{
			100091,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_BuySweepCount),
				Response = typeof(C2S_BuySweepCount.Response),
				Request = typeof(C2S_BuySweepCount.Request)
			}
		},
		{
			1091,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_GvGMode3UnreachableIslands),
				Response = typeof(S2C_GvGMode3UnreachableIslands.Response),
				Request = typeof(S2C_GvGMode3UnreachableIslands.Request)
			}
		},
		{
			100411,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_FoodOnBoard),
				Response = typeof(S2C_FoodOnBoard.Response),
				Request = typeof(S2C_FoodOnBoard.Request)
			}
		},
		{
			100570,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ShipReturnToLastIsland),
				Response = typeof(C2S_ShipReturnToLastIsland.Response),
				Request = typeof(C2S_ShipReturnToLastIsland.Request)
			}
		},
		{
			100562,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_Activate火力支援),
				Response = typeof(C2S_Activate火力支援.Response),
				Request = typeof(C2S_Activate火力支援.Request)
			}
		},
		{
			1094,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_RealTime火力支援MaxTimeOfUsageModel),
				Response = typeof(S2C_RealTime火力支援MaxTimeOfUsageModel.Response),
				Request = typeof(S2C_RealTime火力支援MaxTimeOfUsageModel.Request)
			}
		},
		{
			1095,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_Event_火力支援),
				Response = typeof(S2C_Event_火力支援.Response),
				Request = typeof(S2C_Event_火力支援.Request)
			}
		},
		{
			100563,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetIslandShipsForDisplay),
				Response = typeof(C2S_GetIslandShipsForDisplay.Response),
				Request = typeof(C2S_GetIslandShipsForDisplay.Request)
			}
		},
		{
			100350,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_SoldierWear),
				Response = typeof(C2S_SoldierWear.Response),
				Request = typeof(C2S_SoldierWear.Request)
			}
		},
		{
			100564,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_GetCreateShipPlanRequirement),
				Response = typeof(C2S_GetCreateShipPlanRequirement.Response),
				Request = typeof(C2S_GetCreateShipPlanRequirement.Request)
			}
		},
		{
			100351,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_SolidierTakeOff),
				Response = typeof(C2S_SolidierTakeOff.Response),
				Request = typeof(C2S_SolidierTakeOff.Request)
			}
		},
		{
			100352,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_SoldierLegendItem),
				Response = typeof(S2C_SoldierLegendItem.Response),
				Request = typeof(S2C_SoldierLegendItem.Request)
			}
		},
		{
			100565,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_CreateShipPlan),
				Response = typeof(C2S_CreateShipPlan.Response),
				Request = typeof(C2S_CreateShipPlan.Request)
			}
		},
		{
			100566,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_ChangeInsuranceShipId),
				Response = typeof(C2S_ChangeInsuranceShipId.Response),
				Request = typeof(C2S_ChangeInsuranceShipId.Request)
			}
		},
		{
			100600,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_BrawlEvent_SignUp),
				Response = typeof(C2S_BrawlEvent_SignUp.Response),
				Request = typeof(C2S_BrawlEvent_SignUp.Request)
			}
		},
		{
			100601,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_BrawlEvent_Cancel),
				Response = typeof(C2S_BrawlEvent_Cancel.Response),
				Request = typeof(C2S_BrawlEvent_Cancel.Request)
			}
		},
		{
			100602,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_BrawlEvent_GetResultByDay),
				Response = typeof(C2S_BrawlEvent_GetResultByDay.Response),
				Request = typeof(C2S_BrawlEvent_GetResultByDay.Request)
			}
		},
		{
			100603,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_BrawlEvent_GetInfo),
				Response = typeof(C2S_BrawlEvent_GetInfo.Response),
				Request = typeof(C2S_BrawlEvent_GetInfo.Request)
			}
		},
		{
			100604,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_BrawlEvent_ClaimResultByDay),
				Response = typeof(C2S_BrawlEvent_ClaimResultByDay.Response),
				Request = typeof(C2S_BrawlEvent_ClaimResultByDay.Request)
			}
		},
		{
			100605,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_BrawlEvent_Review),
				Response = typeof(C2S_BrawlEvent_Review.Response),
				Request = typeof(C2S_BrawlEvent_Review.Request)
			}
		},
		{
			100606,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_BrawlEvent_GetSignUpInfoByIsland),
				Response = typeof(C2S_BrawlEvent_GetSignUpInfoByIsland.Response),
				Request = typeof(C2S_BrawlEvent_GetSignUpInfoByIsland.Request)
			}
		},
		{
			100607,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_BrawlEvent_GetDetailInfoByIsland),
				Response = typeof(C2S_BrawlEvent_GetDetailInfoByIsland.Response),
				Request = typeof(C2S_BrawlEvent_GetDetailInfoByIsland.Request)
			}
		},
		{
			100608,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(C2S_BrawlEvent_GetDetailInfoByMUID),
				Response = typeof(C2S_BrawlEvent_GetDetailInfoByMUID.Response),
				Request = typeof(C2S_BrawlEvent_GetDetailInfoByMUID.Request)
			}
		},
		{
			1104,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_BrawlEvent_TodayAllowSignUp),
				Response = typeof(S2C_BrawlEvent_TodayAllowSignUp.Response),
				Request = typeof(S2C_BrawlEvent_TodayAllowSignUp.Request)
			}
		},
		{
			1105,
			new MapPackageIdTypes
			{
				BaseBodyContext = typeof(S2C_OuterTechHideRefresh),
				Response = typeof(S2C_OuterTechHideRefresh.Response),
				Request = typeof(S2C_OuterTechHideRefresh.Request)
			}
		}
	};

	public static SocketManager Instance
	{
		get
		{
			if (_Instance == null)
			{
				_Instance = new SocketManager();
			}
			return _Instance;
		}
	}

	public SocketManager()
	{
		Connections_Dict = new Dictionary<eConType, SocketConnection>();
	}

	public SocketConnection GetConnection(eConType type)
	{
		if (!Connections_Dict.ContainsKey(type))
		{
			Connections_Dict.Add(type, new SocketConnection(type));
		}
		return Connections_Dict[type];
	}
}
