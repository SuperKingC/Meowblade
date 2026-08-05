using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using GvG2.Common.Models;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvGServer.Models.IslandManagerSocket;
using Shift.Legion.Helpers;
using Shift.Legion.Rank.Helpers;
using UI.GvGWorldMap2;
using UI.GvGWorldMapRecord2;
using UI.IslandComeAgain;
using UnityEngine;

namespace GvG2;

public class GvGInstanceZone : Singleton<GvGInstanceZone>
{
	public enum MatchState
	{
		NotInit = -2,
		StartMatching,
		InQueues,
		InRoom,
		InBattlefield,
		StartBattle,
		CancelMatch,
		Lock,
		SetInit,
		CancelMatchAndExit,
		BanMatching
	}

	public class MatchingInfo
	{
		public MatchState matchState;

		public int info;

		public string infoText;
	}

	public class GvGMode2BattleInfo
	{
		public string BattleId;

		public string LevelId;

		public int Result;

		public Dictionary<Team, BattleResultStats> BattleResultStats = new Dictionary<Team, BattleResultStats>();
	}

	private Coroutine _Coroutine_Inquire = null;

	private const string GVG2_JOIN_FAILED = "GvG2JoinFailedTip";

	private int joinCnt;

	private bool firstInquire;

	private int startTimestamp;

	public Action<MatchingInfo> UpdatePanelEvent;

	public static readonly string[] IsComeAgainLevelId = new string[1] { "Eventisland3" };

	public readonly string[] DoNotCloseUiOnReplay = new string[4]
	{
		UI_IslandComeAgainMatchingPanel.Name,
		UI_GvGWorldMap2.Name,
		UI_IslandComeAgainBattleRecordsPanel.Name,
		UI_IslandComeAgainBattleResultPanel.Name
	};

	public GvGMode2BattleInfo RecordLevelInfo;

	private int RoomId = -1;

	public bool IsInZone;

	private Dictionary<int, List<UserIslandEntityBattleRecordSummary>> summariesOutside = new Dictionary<int, List<UserIslandEntityBattleRecordSummary>>();

	public eGotoIslandOperation CurrentGotoIslandOperation { get; set; } = eGotoIslandOperation.Nothing;

	public List<string> CurrentSoldiers { get; set; }

	public string FormationId { get; set; }

	public string OldFormationId { get; set; }

	public string ShipId { get; set; }

	public int CampId { get; set; }

	public List<C2S_GetEOIEntitiesInfo> MyCampUserInfos { get; set; }

	public eShipSummaryState CurrentState { get; set; }

	public List<ShipSummaryUnitInfo> CurrentUnitInfo { get; set; } = new List<ShipSummaryUnitInfo>();

	public List<ShipSummaryUnitInfo> OldUnitInfo { get; set; } = new List<ShipSummaryUnitInfo>();

	public Dictionary<string, int> FillUpTimestamp { get; set; } = new Dictionary<string, int>();

	public int StartFillUpTimestamp { get; set; }

	public List<ShipSummaryUnitInfo> StartFillUpSoldiers { get; set; } = new List<ShipSummaryUnitInfo>();

	public Dictionary<string, int> StockInfoBeforeFillUp { get; set; } = new Dictionary<string, int>();

	public void UpdateCurrentStateInfo(C2S_GetShipSummaryAndFlightScheduleInfo info, int campId, bool forcedUpdateUnitInfo = false, bool isInit = false)
	{
		Singleton<GvGInstanceZone>.Instance.CampId = campId;
		Singleton<GvGInstanceZone>.Instance.CurrentState = (eShipSummaryState)info.State;
		Singleton<GvGInstanceZone>.Instance.OldFormationId = info.FormationId;
		if (string.IsNullOrEmpty(Singleton<GvGInstanceZone>.Instance.FormationId) || isInit)
		{
			Singleton<GvGInstanceZone>.Instance.FormationId = Singleton<GvGInstanceZone>.Instance.OldFormationId;
		}
		Singleton<GvGInstanceZone>.Instance.ShipId = info.ShipId;
		Singleton<GvGInstanceZone>.Instance.StartFillUpTimestamp = info.StartFillUpTimestamp;
		if (info.GroupInfo != null && (Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo.Count <= 0 || forcedUpdateUnitInfo))
		{
			Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo = RandomHelper.Clone(info.GroupInfo);
			Singleton<GvGInstanceZone>.Instance.CurrentSoldiers = Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo.Select((ShipSummaryUnitInfo soldierInfo) => soldierInfo.SoldierId).ToList();
			GameLocalDataManager.SaveIslandComeAgainSoldiers(Singleton<GvGInstanceZone>.Instance.CurrentSoldiers);
		}
		if (info.FillUpTimestamp != null)
		{
			Singleton<GvGInstanceZone>.Instance.FillUpTimestamp = new Dictionary<string, int>(info.FillUpTimestamp);
		}
		if (info.OldGroupInfo != null)
		{
			Singleton<GvGInstanceZone>.Instance.StartFillUpSoldiers = RandomHelper.Clone(info.OldGroupInfo);
		}
		if (Singleton<GvGInstanceZone>.Instance.OldUnitInfo.Count <= 0 || isInit)
		{
			bool flag = info.OldGroupInfo != null && info.OldGroupInfo.Count > 0;
			Singleton<GvGInstanceZone>.Instance.OldUnitInfo = (flag ? RandomHelper.Clone(info.OldGroupInfo) : RandomHelper.Clone(Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo));
		}
		if (info.StockInfoBeforeFillUp != null)
		{
			Singleton<GvGInstanceZone>.Instance.StockInfoBeforeFillUp = new Dictionary<string, int>(info.StockInfoBeforeFillUp);
		}
		if (isInit)
		{
			UpdateStockChangeOnInit(info);
		}
	}

	public void UpdateCurrentStateInfo(S2C_ChangeShipSummaryStateShipFillingUp.Request dataRequest)
	{
		Singleton<GvGInstanceZone>.Instance.CurrentState = (eShipSummaryState)dataRequest.ShipSummaryState;
		Singleton<GvGInstanceZone>.Instance.StartFillUpTimestamp = dataRequest.StartFillUpTimestamp;
		if (dataRequest.FillUpSoldiers != null && Singleton<GvGInstanceZone>.Instance.CurrentState != eShipSummaryState.InCampBaseShipFillUpFinish)
		{
			Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo = RandomHelper.Clone(dataRequest.FillUpSoldiers);
			Singleton<GvGInstanceZone>.Instance.CurrentSoldiers = Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo.Select((ShipSummaryUnitInfo soldierInfo) => soldierInfo.SoldierId).ToList();
			GameLocalDataManager.SaveIslandComeAgainSoldiers(Singleton<GvGInstanceZone>.Instance.CurrentSoldiers);
		}
		if (dataRequest.FillUpTimestamp != null)
		{
			Singleton<GvGInstanceZone>.Instance.FillUpTimestamp = new Dictionary<string, int>(dataRequest.FillUpTimestamp);
		}
		if (dataRequest.StartFillUpSoldiers != null)
		{
			Singleton<GvGInstanceZone>.Instance.StartFillUpSoldiers = RandomHelper.Clone(dataRequest.StartFillUpSoldiers);
		}
		if (dataRequest.StockInfoBeforeFillUp != null)
		{
			Singleton<GvGInstanceZone>.Instance.StockInfoBeforeFillUp = new Dictionary<string, int>(dataRequest.StockInfoBeforeFillUp);
		}
	}

	public void UpdateShipSummaryStateShipFillingUp(S2C_ChangeShipSummaryStateShipFillingUp.Request dataRequest)
	{
		GvGWorldMapController.Instance.UpdateShipSummaryStateShipFillingUp(dataRequest);
		UpdateCurrentStateInfo(dataRequest);
		ExecuteBackToCampBaseAndFillUp(dataRequest);
		ShipBackToCamp();
		UpdateStockChange(dataRequest);
	}

	public void ClearData()
	{
		CurrentGotoIslandOperation = eGotoIslandOperation.Nothing;
		CurrentUnitInfo = new List<ShipSummaryUnitInfo>();
		OldUnitInfo = new List<ShipSummaryUnitInfo>();
		FillUpTimestamp = new Dictionary<string, int>();
		StartFillUpSoldiers = new List<ShipSummaryUnitInfo>();
		StockInfoBeforeFillUp = new Dictionary<string, int>();
		StartFillUpTimestamp = 0;
	}

	public bool CanShowLegionChange()
	{
		GvGWorldMapController.Instance.UpdateGvGInstanceZoneInfo();
		if (!string.Equals(Singleton<GvGInstanceZone>.Instance.FormationId, Singleton<GvGInstanceZone>.Instance.OldFormationId))
		{
			return true;
		}
		if (Singleton<GvGInstanceZone>.Instance.OldUnitInfo?.Count != Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo?.Count)
		{
			return false;
		}
		List<string> list = Singleton<GvGInstanceZone>.Instance.OldUnitInfo?.Select((ShipSummaryUnitInfo info) => info.SoldierId).ToList();
		List<string> list2 = Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo?.Select((ShipSummaryUnitInfo info) => info.SoldierId).ToList();
		for (int num = 0; num < list?.Count; num++)
		{
			if (!string.Equals(list[num], list2?[num]))
			{
				return true;
			}
		}
		for (int num2 = 0; num2 < Singleton<GvGInstanceZone>.Instance.OldUnitInfo?.Count; num2++)
		{
			ShipSummaryUnitInfo shipSummaryUnitInfo = Singleton<GvGInstanceZone>.Instance.OldUnitInfo[num2];
			string text = list2?[num2];
			if (!string.IsNullOrEmpty(text))
			{
				Soldier soldier = GameManagers.Instance.SoldierManager.Get(text);
				if (shipSummaryUnitInfo.PotentialLevel != soldier.PotentialLevel)
				{
					return true;
				}
				if (shipSummaryUnitInfo.SoldierLevel != soldier.Level)
				{
					return true;
				}
				if (EquippedItemsIsDifferent(shipSummaryUnitInfo, soldier))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool EquippedItemsIsDifferent(ShipSummaryUnitInfo oldSoldier, Soldier newSoldier)
	{
		bool flag = oldSoldier.EquippedItems == null || oldSoldier.EquippedItems.Length == 0;
		if (!LegendItemsHelper.SoldiersEquippedItems.TryGetValue(newSoldier.Id, out var value))
		{
			return !flag;
		}
		if (value.Length == 0)
		{
			return !flag;
		}
		if (flag)
		{
			return true;
		}
		if (oldSoldier.EquippedItems.Length != value.Length)
		{
			return true;
		}
		for (int i = 0; i < oldSoldier.EquippedItems.Length; i++)
		{
			int num = (int)value[i];
			if (num != oldSoldier.EquippedItems[i])
			{
				return true;
			}
		}
		return false;
	}

	public void ExecuteBackToCampBaseAndChangeLegionGroup()
	{
		if (CurrentGotoIslandOperation == eGotoIslandOperation.ChangeLegionGroup)
		{
			eShipSummaryState currentState = CurrentState;
			eShipSummaryState eShipSummaryState = currentState;
			if ((uint)eShipSummaryState <= 1u || eShipSummaryState == eShipSummaryState.InCampBaseShipFillUpFinish)
			{
				Dictionary<string, object> parameters = new Dictionary<string, object> { 
				{
					"CurrentSoldiersInfo",
					Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo
				} };
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_ChangeTroopsPanel.Name, parameters);
			}
			CurrentGotoIslandOperation = eGotoIslandOperation.Nothing;
		}
	}

	private void ExecuteBackToCampBaseAndFillUp(S2C_ChangeShipSummaryStateShipFillingUp.Request dataRequest)
	{
		if (CurrentGotoIslandOperation != eGotoIslandOperation.ReplenishLegionGroup)
		{
			return;
		}
		if (CurrentState == eShipSummaryState.BackToCampBaseAndShipFillUp)
		{
			SyncProduce();
			return;
		}
		if (CurrentState == eShipSummaryState.InCampBaseShipFillingUp)
		{
			Dictionary<string, object> parameters = new Dictionary<string, object> { 
			{
				"ReplenishData",
				Singleton<GvGInstanceZone>.Instance.GetShipFillingUpRequest()
			} };
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ReplenishTroopsPanel.Name, parameters);
		}
		CurrentGotoIslandOperation = eGotoIslandOperation.Nothing;
	}

	private void ShipBackToCamp()
	{
		if (CurrentState == eShipSummaryState.InCampBaseShipFillingUp)
		{
			GvGWorldMapController.Instance.ShipBackToCamp();
		}
	}

	public void SyncProduce()
	{
		List<string> soldierIdsNeedSync = new List<string>();
		if (Singleton<GvGInstanceZone>.Instance.OldUnitInfo != null)
		{
			List<string> list = Singleton<GvGInstanceZone>.Instance.OldUnitInfo?.Select((ShipSummaryUnitInfo info) => info.SoldierId).ToList();
			for (int num = 0; num < list?.Count; num++)
			{
				if (!soldierIdsNeedSync.Contains(list[num]))
				{
					soldierIdsNeedSync.Add(list[num]);
				}
			}
		}
		if (Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo != null)
		{
			List<string> list2 = Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo?.Select((ShipSummaryUnitInfo info) => info.SoldierId).ToList();
			for (int num2 = 0; num2 < list2?.Count; num2++)
			{
				if (!soldierIdsNeedSync.Contains(list2[num2]))
				{
					soldierIdsNeedSync.Add(list2[num2]);
				}
			}
		}
		if (Singleton<GvGInstanceZone>.Instance.StartFillUpSoldiers != null)
		{
			List<string> list3 = Singleton<GvGInstanceZone>.Instance.StartFillUpSoldiers?.Select((ShipSummaryUnitInfo info) => info.SoldierId).ToList();
			for (int num3 = 0; num3 < list3?.Count; num3++)
			{
				if (!soldierIdsNeedSync.Contains(list3[num3]))
				{
					soldierIdsNeedSync.Add(list3[num3]);
				}
			}
		}
		if (soldierIdsNeedSync.Count <= 0)
		{
			if (Singleton<GvGInstanceZone>.Instance.CurrentSoldiers == null)
			{
				Singleton<GvGInstanceZone>.Instance.CurrentSoldiers = new List<string>(GameLocalDataManager.LoadIslandComeAgainSoldiers());
			}
			soldierIdsNeedSync.AddRange(Singleton<GvGInstanceZone>.Instance.CurrentSoldiers);
		}
		ILRequestHelper<SyncStockResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().SyncStock(-1L, syncAllStock: false, soldierIdsNeedSync), delegate(SyncStockResponse syncStockResponse)
		{
			if (!syncStockResponse.Result)
			{
				return;
			}
			foreach (KeyValuePair<string, int> stock in syncStockResponse.Stocks)
			{
				string key = stock.Key;
				int value = stock.Value;
				GameManagers.Instance.StockController.SetStock(key, value, StockInContext.GvGMode2ShipFillUp);
			}
		}, 1f);
	}

	private void UpdateStockChange(S2C_ChangeShipSummaryStateShipFillingUp.Request dataRequest)
	{
		if (CurrentState == eShipSummaryState.InCampBaseShipFillingUp)
		{
			SyncProduce();
		}
	}

	private void UpdateStockChangeOnInit(C2S_GetShipSummaryAndFlightScheduleInfo info)
	{
		if (CurrentState == eShipSummaryState.InCampBaseShipFillingUp)
		{
			SyncProduce();
		}
	}

	public bool CanReplenish(out string tip)
	{
		bool result = false;
		tip = "当前兵力充足，无需补兵";
		if (Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo != null && Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo.Count > 0)
		{
			for (int i = 0; i < Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo.Count; i++)
			{
				if (Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo[i].CurCnt < Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo[i].Total)
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}

	public void OpenBattleResultPanel(S2C_IZOver.Request request)
	{
		if (!string.IsNullOrEmpty(request.Result))
		{
			GvGMode2IZResult value = JsonHelper.ToObject<GvGMode2IZResult>(request.Result);
			SharedMessenger.Broadcast("ON_GVG2_INSTANCE_END");
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_IslandComeAgainBattleResultPanel.Name, new Dictionary<string, object> { { "BattleResult", value } });
		}
	}

	public S2C_ChangeShipSummaryStateShipFillingUp.Request GetShipFillingUpRequest()
	{
		bool flag = Singleton<GvGInstanceZone>.Instance.CurrentState == eShipSummaryState.InCampBaseShipFillingUp;
		return new S2C_ChangeShipSummaryStateShipFillingUp.Request
		{
			ShipSummaryState = (int)Singleton<GvGInstanceZone>.Instance.CurrentState,
			FillUpTimestamp = Singleton<GvGInstanceZone>.Instance.FillUpTimestamp,
			FillUpSoldiers = Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo,
			StartFillUpTimestamp = Singleton<GvGInstanceZone>.Instance.StartFillUpTimestamp,
			StartFillUpSoldiers = (flag ? Singleton<GvGInstanceZone>.Instance.StartFillUpSoldiers : new List<ShipSummaryUnitInfo>()),
			StockInfoBeforeFillUp = (flag ? Singleton<GvGInstanceZone>.Instance.StockInfoBeforeFillUp : new Dictionary<string, int>())
		};
	}

	public int GetExpectedFillUpTime()
	{
		List<ShipSummaryUnitInfo> currentUnitInfo = Singleton<GvGInstanceZone>.Instance.CurrentUnitInfo;
		List<ShipSummaryUnitInfo> list = new List<ShipSummaryUnitInfo>();
		foreach (ShipSummaryUnitInfo item2 in currentUnitInfo)
		{
			int soldierLevel = GameManagers.Instance.UserArchiveManager.GetSoldierLevel(item2.SoldierId);
			int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(item2.SoldierId, soldierLevel);
			int stock = GameManagers.Instance.StockController.GetStock(item2.SoldierId);
			int curCnt = Mathf.Min(stock, soldierFormationNumber * 5);
			ShipSummaryUnitInfo item = new ShipSummaryUnitInfo
			{
				SoldierId = item2.SoldierId,
				Total = soldierFormationNumber * 5,
				CurCnt = curCnt
			};
			list.Add(item);
		}
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
		for (int i = 0; i < currentUnitInfo.Count; i++)
		{
			int num = 0;
			num = ((!(currentUnitInfo[i].SoldierId != list[i].SoldierId)) ? (list[i].Total - currentUnitInfo[i].CurCnt) : list[i].Total);
			int stock2 = GameManagers.Instance.StockController.GetStock(list[i].SoldierId);
			int total = list[i].Total;
			float num2 = (float)total * 0.04f;
			int num3 = Mathf.Min(stock2, num);
			if (currentUnitInfo[i].SoldierId != list[i].SoldierId)
			{
				list[i].CurCnt = num;
			}
			else
			{
				list[i].CurCnt = currentUnitInfo[i].CurCnt + num;
			}
			dictionary.Add(list[i].SoldierId, num3);
			int num4 = Mathf.FloorToInt((float)num3 / num2);
			if (num4 > 25)
			{
				num4 = 25;
			}
			dictionary2.Add(list[i].SoldierId, num4);
		}
		return dictionary2.Values.OrderByDescending((int t) => t).ToList()[0];
	}

	public override void InitInstance()
	{
	}

	public void InquireInitInfo()
	{
		_Coroutine_Inquire = FGUIManager.Instance.OpenIEnumerator(Inquire(isInit: true));
	}

	public void StartMatch(Action onSuccess, Action<int> onFailed)
	{
		GvGRoomHelper.GvGRoomOperation(eGvGRoomOperation.Join, delegate(string json)
		{
			if (!string.IsNullOrEmpty(json))
			{
				JoinResult joinResult = JsonHelper.ToObject<JoinResult>(json);
				if (!joinResult.Join)
				{
					"GvG2JoinFailedTip".ToShowLanguageTip();
				}
				else
				{
					onSuccess?.Invoke();
					joinCnt = joinResult.JoinCnt;
					_Coroutine_Inquire = FGUIManager.Instance.OpenIEnumerator(Inquire());
				}
			}
		}, isInquiring: false, onFailed);
	}

	public void TryCancelMatch()
	{
		GvGRoomHelper.GvGRoomOperation(eGvGRoomOperation.Inquire, delegate(string json)
		{
			if (_Coroutine_Inquire != null)
			{
				FGUIManager.Instance.CloseIEnumerator(_Coroutine_Inquire);
				_Coroutine_Inquire = null;
			}
			if (string.IsNullOrEmpty(json))
			{
				CancelMatch(MatchState.CancelMatch);
			}
			else
			{
				_Coroutine_Inquire = FGUIManager.Instance.OpenIEnumerator(Inquire());
			}
		});
	}

	public void CancelMatch(MatchState newState = MatchState.CancelMatchAndExit)
	{
		GvGRoomHelper.GvGRoomOperation(eGvGRoomOperation.Leave, delegate(string json)
		{
			RoomId = -1;
			if (string.IsNullOrEmpty(json))
			{
			}
			LeaveResult leaveResult = JsonHelper.ToObject<LeaveResult>(json);
			if (!leaveResult.Leave)
			{
			}
			if (_Coroutine_Inquire != null)
			{
				FGUIManager.Instance.CloseIEnumerator(_Coroutine_Inquire);
				_Coroutine_Inquire = null;
			}
			UpdatePanelEvent?.Invoke(new MatchingInfo
			{
				matchState = newState
			});
		});
	}

	private IEnumerator Inquire(bool isInit = false)
	{
		firstInquire = isInit;
		if (!isInit)
		{
			yield return (object)new WaitForSeconds(1f);
		}
		GvGRoomHelper.GvGRoomOperation(eGvGRoomOperation.Inquire, delegate(string json)
		{
			if (!CanContinueInquire() && !isInit)
			{
				FGUIManager.Instance.CloseIEnumerator(_Coroutine_Inquire);
				_Coroutine_Inquire = null;
				UpdatePanelEvent?.Invoke(new MatchingInfo
				{
					matchState = MatchState.BanMatching
				});
			}
			else if (!GameController.Contexts.Service<IUiService>().HasShowingUi(UI_IslandComeAgainMatchingPanel.Name))
			{
				FGUIManager.Instance.CloseIEnumerator(_Coroutine_Inquire);
				_Coroutine_Inquire = null;
			}
			else if (string.IsNullOrEmpty(json))
			{
				if (!isInit)
				{
					UpdatePanelEvent?.Invoke(new MatchingInfo
					{
						matchState = MatchState.InQueues,
						info = joinCnt
					});
					_Coroutine_Inquire = FGUIManager.Instance.OpenIEnumerator(Inquire());
				}
				else
				{
					RoomId = -1;
				}
			}
			else
			{
				if (isInit)
				{
					UpdatePanelEvent?.Invoke(new MatchingInfo
					{
						matchState = MatchState.SetInit
					});
				}
				InquireResult inquireResult = JsonHelper.ToObject<InquireResult>(json);
				RoomId = int.Parse(inquireResult.RoomId);
				UpdatePanelEvent?.Invoke(new MatchingInfo
				{
					matchState = MatchState.InRoom,
					infoText = GetCurrentUserNumInRoom(inquireResult)
				});
				if (string.IsNullOrEmpty(inquireResult.LockTimestamp))
				{
					_Coroutine_Inquire = FGUIManager.Instance.OpenIEnumerator(Inquire(isInit));
				}
				else
				{
					UpdatePanelEvent?.Invoke(new MatchingInfo
					{
						matchState = MatchState.Lock,
						infoText = GetCurrentUserNumInRoom(inquireResult)
					});
					if (string.IsNullOrEmpty(inquireResult.StartTimestamp))
					{
						_Coroutine_Inquire = FGUIManager.Instance.OpenIEnumerator(Inquire(isInit));
					}
					else
					{
						startTimestamp = int.Parse(inquireResult.StartTimestamp);
						int num = (int)GameController.Instance.GetServerTime();
						if (num < startTimestamp)
						{
							_Coroutine_Inquire = FGUIManager.Instance.OpenIEnumerator(Inquire(isInit));
						}
						else
						{
							ConnectToGvGInstanceZone(inquireResult.Pid, inquireResult.ExternalSocketPort);
							FGUIManager.Instance.CloseIEnumerator(_Coroutine_Inquire);
							_Coroutine_Inquire = null;
						}
					}
				}
			}
		}, isInquiring: true);
	}

	public bool CanContinueInquire()
	{
		if (GameManagers.Instance.StockController.GetStock("WhiteListTestItem_GvGMode2") > 0)
		{
			return true;
		}
		DynamicIslandComeAgainActivity dynamicIslandComeAgainActivity = FGUIManager.Instance.IslandComeAgainActivities?[0];
		if (dynamicIslandComeAgainActivity == null)
		{
			return false;
		}
		int today0000Timestamp = DateTimeHelper.GetToday0000Timestamp();
		List<int> dailyActiveTime = dynamicIslandComeAgainActivity.DailyActiveTime;
		int num = dailyActiveTime[0] + today0000Timestamp;
		int num2 = dailyActiveTime[1] + today0000Timestamp;
		int num3 = (int)GameController.Instance.GetServerTime();
		return num <= num3 && num3 <= num2;
	}

	private string GetCurrentUserNumInRoom(InquireResult result)
	{
		int num = (int)GameController.Instance.GetServerTime();
		int num2 = int.Parse(result.RoomLimit) - (int)Math.Ceiling((float)(num - int.Parse(result.CreateTimestamp)) / 60f * 4f);
		return string.Format("{0}{1}/{2}", LanguagesManager.GetDesc("IslandComeAgainPlayersInQueue"), result.RedayCnt, Mathf.Max(28, num2));
	}

	private void ConnectToGvGInstanceZone(string pid, string port)
	{
		int Pid = int.Parse(pid);
		int ExternalSocketPort = int.Parse(port);
		string a = $"{ExternalSocketPort}_{Pid}";
		if (string.Equals(a, SocketManager.Instance.GetConnection(eConType.GvGMode2WorldMap).CurrentConnectInfo))
		{
			GetOwnShips();
			return;
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode2WorldMap).StartConnect(HotUpdateProcess.Instance.Configs["SocketHost"], ExternalSocketPort, Pid, delegate
		{
			SocketManager.Instance.GetConnection(eConType.GvGMode2WorldMap).CurrentConnectInfo = $"{ExternalSocketPort}_{Pid}";
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
				ILRuntimeDebug.LogError($"请求 GetOwnShips 不成功 resp.ErrorCode={response.ErrorCode}");
			}
			else if (response.ShipEntityIds == null || response.ShipEntityIds.Count <= 0)
			{
				S2C_ShipSummaryCreateSuccess.OnPushEvent = (Action<S2C_ShipSummaryCreateSuccess.Request>)Delegate.Combine(S2C_ShipSummaryCreateSuccess.OnPushEvent, new Action<S2C_ShipSummaryCreateSuccess.Request>(OnPushShipSummaryCreateSuccess));
				string formationId = "FA01";
				CreateOwnShip(CurrentSoldiers, formationId);
			}
			else if (firstInquire)
			{
				SharedMessenger.Broadcast("ISLAND_COME_AGAIN_BACK_BATTLEFIELD", response.ShipEntityIds);
				UpdatePanelEvent?.Invoke(new MatchingInfo
				{
					matchState = MatchState.InBattlefield,
					info = startTimestamp
				});
			}
			else
			{
				OpenGvGWorldMap2(response.ShipEntityIds);
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
				FormationId = formationId;
				UpdateSoldiersStock(response.GetSoldierStockCost());
				if (RoomId > 0)
				{
					GameManagers.Instance.UserArchiveManager.AddGvGMode2Record(RoomId);
					GameManagers.Instance.UserArchiveManager.AddTodayIZIDRecord(RoomId.ToString());
					CacheManager.Instance.Get<Cache_IslandComeAgainDailyMissionRedDot>().ForceUpdate();
				}
			}
		});
	}

	private void OpenGvGWorldMap2(List<int> ownShipIds)
	{
		UpdatePanelEvent?.Invoke(new MatchingInfo
		{
			matchState = MatchState.StartBattle
		});
		Singleton<GvGInstanceZone>.Instance.ClearData();
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGWorldMap2.Name, new Dictionary<string, object>
		{
			{ "ReservePackageResOnClose", true },
			{ "OwnShipIds", ownShipIds }
		});
	}

	private void UpdateSoldiersStock(Dictionary<string, int> costDic)
	{
		StockChangeRecord[] array = new StockChangeRecord[costDic.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item in costDic)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item.Key,
				Offset = -item.Value,
				Context = 106,
				ContextValue = item.Key,
				Type = 1
			};
		}
		GameManagers.Instance.StockController.ReadStockChangeRecords(array);
	}

	public string GetReplenishSoldierNumTextColor(int curCnt, int totalCnt)
	{
		float num = (float)curCnt / (float)totalCnt;
		if (num < 0.4f)
		{
			return "#ff1a1a";
		}
		if (num <= 0.99f)
		{
			return "#fff04c";
		}
		return "#ffffff";
	}

	public string GetReplenishSoldierStockTextColor(int stockCnt, int curCnt, int totalCnt)
	{
		if (stockCnt + curCnt >= totalCnt)
		{
			return "#ffffff";
		}
		return "#ff1a1a";
	}

	public void OnReplayStart()
	{
		GameController.Contexts.Service<IUiService>().AddDontCloseUisOnCloseAll(DoNotCloseUiOnReplay.ToList());
		ScriptApi.CreateTimer(0.5f, delegate
		{
			for (int i = 0; i < DoNotCloseUiOnReplay.Length; i++)
			{
				GObject showingUi = GameController.Contexts.Service<IUiService>().GetShowingUi(DoNotCloseUiOnReplay[i]);
				if (showingUi != null)
				{
					((GObject)showingUi.parent).visible = false;
				}
			}
		});
	}

	public void OnReplayEnd()
	{
		GameController.Contexts.Service<IUiService>().ClearDontCloseUisOnCloseAll();
		if (IsInZone)
		{
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GvGWorldMapController.Instance.ResumeIsntance());
		}
		for (int i = 0; i < DoNotCloseUiOnReplay.Length; i++)
		{
			GObject showingUi = GameController.Contexts.Service<IUiService>().GetShowingUi(DoNotCloseUiOnReplay[i]);
			if (showingUi != null)
			{
				((GObject)showingUi.parent).visible = true;
			}
		}
	}

	public void UpdateLocalBattleRecord()
	{
		GameLocalDataManager.SaveIslandComeAgainBattleRecords(summariesOutside);
		summariesOutside.Clear();
	}

	public void ClearLocalBattleRecord()
	{
		summariesOutside.Clear();
	}

	public void GetAllBattleRecordSummary(bool inZone, Action<List<UserIslandEntityBattleRecordSummary>> callbackAction)
	{
		IsInZone = inZone;
		int[] recordsIzIds = GetRecordsIzIds(inZone);
		if (inZone)
		{
			GetNewBattleRecordSummary(recordsIzIds, callbackAction);
			return;
		}
		if (summariesOutside.Count <= 0)
		{
			summariesOutside = GameLocalDataManager.LoadIslandComeAgainBattleRecords();
		}
		List<int> list = new List<int>();
		for (int i = 0; i < recordsIzIds.Length; i++)
		{
			if (!summariesOutside.ContainsKey(recordsIzIds[i]))
			{
				list.Add(recordsIzIds[i]);
			}
		}
		if (list.Count <= 0)
		{
			callbackAction?.Invoke(BattleRecordDataToList(summariesOutside));
		}
		else
		{
			GetNewBattleRecordSummary(list.ToArray(), callbackAction);
		}
	}

	public void GetAllBattleRecords(UserIslandEntityBattleRecordSummary summary, Action<List<GvGMode2BattleReportBattleRecord>> callbackAction)
	{
		if (summary == null)
		{
			return;
		}
		if (summary.Records != null && summary.Records.Count > 0)
		{
			callbackAction?.Invoke(summary.Records);
			return;
		}
		ILRequestHelper<GvGMode2GetBattleRecordsResponse>.Request((EventContext)null, (Func<Task<GvGMode2GetBattleRecordsResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode2GetBattleRecords(summary.IZId, summary.SummaryId)), (Action<GvGMode2GetBattleRecordsResponse>)delegate(GvGMode2GetBattleRecordsResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				List<GvGMode2BattleReportBattleRecord> records = new List<GvGMode2BattleReportBattleRecord>(response.Records);
				UpdateBattleRecordSummaryRecords(records, summary.IZId, summary.SummaryId);
				callbackAction?.Invoke(response.Records);
			}
		});
	}

	private int[] GetRecordsIzIds(bool inZone)
	{
		if (inZone)
		{
			return new int[1] { RoomId };
		}
		List<int> latestGvGMode2Results = GameManagers.Instance.UserArchiveManager.GetLatestGvGMode2Results();
		if (latestGvGMode2Results.Contains(RoomId))
		{
			latestGvGMode2Results.Remove(RoomId);
		}
		return latestGvGMode2Results.ToArray();
	}

	private List<UserIslandEntityBattleRecordSummary> BattleRecordDataToList(Dictionary<int, List<UserIslandEntityBattleRecordSummary>> originalData)
	{
		Dictionary<int, List<UserIslandEntityBattleRecordSummary>> dictionary = new Dictionary<int, List<UserIslandEntityBattleRecordSummary>>(originalData);
		List<UserIslandEntityBattleRecordSummary> list = new List<UserIslandEntityBattleRecordSummary>();
		List<int> list2 = dictionary.Keys.ToList();
		list2.Sort();
		list2.Reverse();
		foreach (int item in list2)
		{
			list.Add(new UserIslandEntityBattleRecordSummary
			{
				IZId = item,
				SummaryType = SummaryType.IZId
			});
			list.AddRange(dictionary[item]);
		}
		return list;
	}

	private Dictionary<int, List<UserIslandEntityBattleRecordSummary>> BattleRecordDataToDictionary(List<UserIslandEntityBattleRecordSummary> originalData)
	{
		Dictionary<int, List<UserIslandEntityBattleRecordSummary>> dictionary = new Dictionary<int, List<UserIslandEntityBattleRecordSummary>>();
		if (originalData == null)
		{
			return dictionary;
		}
		List<UserIslandEntityBattleRecordSummary> list = new List<UserIslandEntityBattleRecordSummary>(originalData);
		for (int i = 0; i < list.Count; i++)
		{
			int iZId = list[i].IZId;
			if (!dictionary.ContainsKey(iZId))
			{
				dictionary.Add(iZId, new List<UserIslandEntityBattleRecordSummary> { list[i] });
			}
			else
			{
				dictionary[iZId].Add(list[i]);
			}
		}
		return dictionary;
	}

	private void GetNewBattleRecordSummary(int[] IZIds, Action<List<UserIslandEntityBattleRecordSummary>> callbackAction)
	{
		ILRequestHelper<GvGMode2GetUserIZBattleSummaryResponse>.Request((EventContext)null, (Func<Task<GvGMode2GetUserIZBattleSummaryResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode2GetUserIZBattleSummary(IZIds)), (Action<GvGMode2GetUserIZBattleSummaryResponse>)delegate(GvGMode2GetUserIZBattleSummaryResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Dictionary<int, List<UserIslandEntityBattleRecordSummary>> dictionary = BattleRecordDataToDictionary(response.Summaries);
				if (IsInZone)
				{
					summariesOutside.Clear();
				}
				foreach (KeyValuePair<int, List<UserIslandEntityBattleRecordSummary>> item in dictionary)
				{
					if (!summariesOutside.ContainsKey(item.Key))
					{
						summariesOutside.Add(item.Key, item.Value);
					}
				}
				callbackAction?.Invoke(BattleRecordDataToList(summariesOutside));
			}
		});
	}

	private void UpdateBattleRecordSummaryRecords(List<GvGMode2BattleReportBattleRecord> records, int IZId, int summaryId)
	{
		if (summariesOutside != null && summariesOutside.Count > 0 && summariesOutside.TryGetValue(IZId, out var value))
		{
			UserIslandEntityBattleRecordSummary userIslandEntityBattleRecordSummary = value.FirstOrDefault((UserIslandEntityBattleRecordSummary t) => t.SummaryId == summaryId);
			if (userIslandEntityBattleRecordSummary != null)
			{
				userIslandEntityBattleRecordSummary.Records = records;
			}
		}
	}
}
