using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Assets.Scripts.UI;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.C2S;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Extension;
using Shift.Legion.ClientApi;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.Battle;
using Shift.Legion.GvG.Common.Models.BattleLog;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.Helpers;
using UI.GvGBattleRecord3;
using UnityEngine;
using UnityEngine.Networking;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;

public class GvGMode3BattleRecordsManager : Singleton<GvGMode3BattleRecordsManager>
{
	private class RunningBattleLogKeyCache
	{
		public int LastGetTime;

		public C2S_GetIslandRunningBattleLog.Response CacheData;
	}

	public const string GvGMode3RecordLevelId = "EventislandGVG_001";

	private const string IslandLogSaveName = "IslandLog.json";

	private const string IslandResultReportSaveName = "IslandResultReport.json";

	private const string BattleRecordDetailSaveName = "BattleRecordDetail.bin";

	private const string BattleParamsSaveName = "BattleParams.json";

	private const string BattleResultSaveName = "ret.bin";

	private const string MyBattleLogSaveName = ".json";

	private const string RunningBattleLogSaveName = ".json";

	private string _battleLogHttp;

	private int CurFilterShipRace;

	private List<BattleLog_Big> AllPlayerLogs;

	private int CurUserId;

	private List<BattleLog_Big> MyLogFiltered;

	private Dictionary<int, RunningBattleLogKeyCache> _runningLogCaches = new Dictionary<int, RunningBattleLogKeyCache>();

	private bool _battleRecordDataLoading;

	public Action<bool> UpdateBattleResultBonusRedDot => delegate
	{
	};

	public GvGMode3RecordLevelModel RecordLevelInfo { get; set; }

	public override void InitInstance()
	{
		_battleLogHttp = (HotUpdateProcess.Instance.Configs.TryGetValue("GvGMode3Log", out var value) ? value : "https://skyisland.gubulin.com");
		RecordLevelInfo = new GvGMode3RecordLevelModel();
		AllPlayerLogs = new List<BattleLog_Big>();
		CurUserId = GameController.Contexts.gameState.user.value.UserId;
	}

	public void ClearCache()
	{
		RecordLevelInfo = null;
	}

	private static string GetShipGroupUid(string shipId, int shipRace, int deadCnt)
	{
		return $"{shipId}_{shipRace}_{deadCnt}";
	}

	private string GetBattleParamsId(string processId, string battleId)
	{
		return processId + "/BattleInfo/" + battleId;
	}

	private string GroupBattleRecordDetailId(string processId, string shipId, int shipRace, int deadCnt)
	{
		return processId + "/ShipInfo/" + GetShipGroupUid(shipId, shipRace, deadCnt);
	}

	private string GetPlayerBattleLogRedisKey(int userId)
	{
		return $"PlayerBattleLog_{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId}_{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}_{userId}";
	}

	private string GetBattleResultHttpUrl(string battleId, string saveName)
	{
		return GameController.Configs["BattleReplayDownloadUrl"] + battleId + "/" + saveName;
	}

	private string GetDataHttpUrl(string dataId, string saveName)
	{
		return _battleLogHttp + "/" + dataId + "/" + saveName;
	}

	private string GetDataLocalPath(string dataId, string saveName)
	{
		return GetLocalPath(dataId, saveName);
	}

	private static string GetLocalPath(string path, string saveName)
	{
		string text = Application.persistentDataPath + "/GvGMode3BattleLog";
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return text + "/" + path + "/" + saveName;
	}

	private IEnumerator GetHttpData<T>(string httpUrl, string localPath, bool useProtoBuf = false) where T : class
	{
		UnityWebRequest webRequest = UnityWebRequest.Get(httpUrl);
		try
		{
			webRequest.timeout = 3;
			yield return webRequest.SendWebRequest();
			if (webRequest.isNetworkError || webRequest.isHttpError)
			{
				yield return null;
				yield break;
			}
			if (!webRequest.isDone || webRequest.downloadHandler.data.Length == 0)
			{
				yield return null;
				yield break;
			}
			byte[] resultData = webRequest.downloadHandler.data;
			SaveLocalData(localPath, resultData, useProtoBuf);
			if (useProtoBuf)
			{
				yield return resultData.Deserialize<T>();
			}
			else
			{
				yield return JsonHelper.ToObject<T>(Encoding.UTF8.GetString(resultData));
			}
		}
		finally
		{
			((IDisposable)webRequest)?.Dispose();
		}
	}

	private T ReadLocalData<T>(string localPath, bool useProtoBuf = false) where T : class
	{
		if (!File.Exists(localPath))
		{
			return null;
		}
		try
		{
			if (!useProtoBuf)
			{
				using (StreamReader streamReader = new StreamReader(localPath, Encoding.UTF8))
				{
					string json = streamReader.ReadToEnd();
					return JsonHelper.ToObject<T>(json);
				}
			}
			using FileStream fileStream = new FileStream(localPath, FileMode.Open, FileAccess.Read);
			using BinaryReader binaryReader = new BinaryReader(fileStream);
			int count = (int)fileStream.Length;
			byte[] array = binaryReader.ReadBytes(count);
			return (array.Length == 0) ? null : array.Deserialize<T>();
		}
		catch (Exception ex)
		{
			ILRuntimeDebug.LogError("[GvG3战报]:" + localPath + "读取文件时发生异常: " + ex.Message);
			return null;
		}
	}

	private void SaveLocalData(string localPath, byte[] byteData, bool useProtoBuf = false)
	{
		if (File.Exists(localPath))
		{
			return;
		}
		if (byteData == null)
		{
			ILRuntimeDebug.LogError("[GvG3战报]:" + localPath + "写入文件时发生异常:data is null");
			return;
		}
		try
		{
			string directoryName = Path.GetDirectoryName(localPath);
			if (!Directory.Exists(directoryName) && !string.IsNullOrEmpty(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			if (!useProtoBuf)
			{
				using (StreamWriter streamWriter = new StreamWriter(localPath, append: false, Encoding.UTF8))
				{
					streamWriter.Write(Encoding.UTF8.GetString(byteData));
					return;
				}
			}
			using FileStream output = new FileStream(localPath, FileMode.Create, FileAccess.Write);
			using BinaryWriter binaryWriter = new BinaryWriter(output);
			binaryWriter.Write(byteData);
		}
		catch (Exception ex)
		{
			ILRuntimeDebug.LogError("[GvG3战报]:" + localPath + "写入文件时发生异常: " + ex.Message);
		}
	}

	private IEnumerator GetData<T>(string localPath, string httpUrl, bool useProtoBuf = false) where T : class
	{
		T data = ReadLocalData<T>(localPath, useProtoBuf);
		if (data != null)
		{
			yield return data;
			yield break;
		}
		CoroutineWithData cd = new CoroutineWithData((MonoBehaviour)(object)FGUIManager.Instance, GetHttpData<T>(httpUrl, localPath, useProtoBuf));
		yield return cd.Coroutine;
		if (cd.Result == null)
		{
			yield return null;
		}
		else
		{
			yield return (T)cd.Result;
		}
	}

	public List<BattleLog_Big> GetMyLogFiltered(int filterShipRace, bool forceRefresh = false)
	{
		if (forceRefresh)
		{
			MyLogFiltered = null;
		}
		if (filterShipRace == CurFilterShipRace && MyLogFiltered != null)
		{
			return MyLogFiltered;
		}
		CurFilterShipRace = filterShipRace;
		MyLogFiltered = FilterLogsWithRace(AllPlayerLogs, filterShipRace);
		return MyLogFiltered;
	}

	private List<BattleLog_Big> FilterLogsWithRace(List<BattleLog_Big> logs, int shipRace)
	{
		if (shipRace == -2)
		{
			return new List<BattleLog_Big>(AllPlayerLogs);
		}
		return logs.Where((BattleLog_Big log) => (log.ShipInfoA.UserId == CurUserId && log.ShipInfoA.ShipRace == shipRace) || (log.ShipInfoB.UserId == CurUserId && log.ShipInfoB.ShipRace == shipRace)).ToList();
	}

	public void GetPlayerBattleLog_New(int filterShipRace, Action<List<BattleLog_Big>> onFinished)
	{
		FGUIManager.Instance.OpenIEnumerator(GetCoroutine());
		IEnumerator GetCoroutine()
		{
			List<string> newLogKeys = null;
			bool isLoaded = false;
			GetPlayerBattleLog(null, 10, delegate(List<string> keys)
			{
				newLogKeys = keys;
				isLoaded = true;
			});
			while (!isLoaded)
			{
				yield return null;
			}
			if (newLogKeys != null)
			{
				if (AllPlayerLogs.Count > 0 && newLogKeys.Count > 0)
				{
					string lastTop = AllPlayerLogs[0].LogKey;
					int index = newLogKeys.IndexOf(lastTop);
					if (index != -1)
					{
						newLogKeys.RemoveRange(index, newLogKeys.Count - index);
					}
					else
					{
						AllPlayerLogs.Clear();
					}
				}
				if (newLogKeys.Count > 0)
				{
					yield return LoadPlayerBattleLog(newLogKeys, delegate(List<BattleLog_Big> newLogs)
					{
						AllPlayerLogs.InsertRange(0, newLogs);
					});
					onFinished?.Invoke(GetMyLogFiltered(filterShipRace, forceRefresh: true));
				}
				else
				{
					onFinished?.Invoke(GetMyLogFiltered(filterShipRace));
				}
			}
		}
	}

	public void GetPlayerBattleLog_Early(int filterShipRace, Action<List<BattleLog_Big>> onFinished)
	{
		if (AllPlayerLogs.Count == 0)
		{
			onFinished?.Invoke(new List<BattleLog_Big>());
		}
		else
		{
			FGUIManager.Instance.OpenIEnumerator(GetCoroutine());
		}
		IEnumerator GetCoroutine()
		{
			GetMyLogFiltered(filterShipRace);
			while (true)
			{
				List<string> newLogKeys = null;
				bool isLoaded = false;
				GetPlayerBattleLog(AllPlayerLogs.Last().LogKey, 5, delegate(List<string> keys)
				{
					newLogKeys = keys;
					isLoaded = true;
				});
				while (!isLoaded)
				{
					yield return null;
				}
				if (newLogKeys == null)
				{
					yield break;
				}
				List<BattleLog_Big> newFiltered = null;
				if (newLogKeys.Count <= 0)
				{
					break;
				}
				yield return LoadPlayerBattleLog(newLogKeys, delegate(List<BattleLog_Big> newLogs)
				{
					AllPlayerLogs.AddRange(newLogs);
					newFiltered = FilterLogsWithRace(newLogs, filterShipRace);
				});
				if (newFiltered.Count > 0)
				{
					MyLogFiltered.AddRange(newFiltered);
					break;
				}
				yield return (object)new WaitForSeconds(0.2f);
			}
			onFinished?.Invoke(MyLogFiltered);
		}
	}

	public void GetPlayerBattleLog(string startKey, int num, Action<List<string>> onFinished)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetPlayerBattleLog
		{
			Req = new C2S_GetPlayerBattleLog.Request
			{
				Num = num,
				StartKey = startKey
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetPlayerBattleLog.Response response = (C2S_GetPlayerBattleLog.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke(null);
			}
			else
			{
				onFinished?.Invoke(response.Keys ?? new List<string>());
			}
		});
	}

	private IEnumerator LoadPlayerBattleLog(List<string> playerLogKey, Action<List<BattleLog_Big>> onFinished)
	{
		List<BattleLog_Big> result = new List<BattleLog_Big>(playerLogKey.Count);
		string dataId = GetPlayerBattleLogRedisKey(GameController.Contexts.gameState.user.value.UserId);
		int myCamp = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		foreach (string logKey in playerLogKey)
		{
			if (!string.IsNullOrEmpty(logKey))
			{
				string saveName = logKey + ".json";
				yield return LoadData(dataId, saveName, delegate(PlayerLog playerLog)
				{
					playerLog.BigLog.PlayerLogInit(playerLog.ProcessId, logKey);
					playerLog.BigLog.DataInit(myCamp);
					result.Add(playerLog.BigLog);
				});
				yield return null;
			}
		}
		onFinished?.Invoke(result);
	}

	private int MyLogSort(BattleLog_Big a, BattleLog_Big b)
	{
		if (a.Timestamp_ms > b.Timestamp_ms)
		{
			return -1;
		}
		return (a.Timestamp_ms < b.Timestamp_ms) ? 1 : 0;
	}

	public void GetSystemMessagesIslandBattleLog(int islandId, Action<List<IslandLog>> onUpdate, int startId = -1, Action onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetSystemMessages_IslandBattleLog
		{
			Req = new C2S_GetSystemMessages_IslandBattleLog.Request
			{
				StartId = startId,
				IslandId = islandId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetSystemMessages_IslandBattleLog.Response response = (C2S_GetSystemMessages_IslandBattleLog.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				FGUIManager.Instance.OpenIEnumerator(GetIslandLogs(response, onUpdate, onFinished));
			}
		});
	}

	public void GetSystemMessagesBattleResultBonus(long startId = -1L, bool isGetWaitToClaimIds = false, Action<C2S_GetSystemMessages_BattleResultBonus.Response> onFinished = null)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetSystemMessages_BattleResultBonus
		{
			Req = new C2S_GetSystemMessages_BattleResultBonus.Request
			{
				StartId = startId,
				IsGetWaitToClaimIds = isGetWaitToClaimIds
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetSystemMessages_BattleResultBonus.Response response = (C2S_GetSystemMessages_BattleResultBonus.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				UpdateBattleResultBonusRedDot?.Invoke(response.WaitToClaimIds != null);
				onFinished?.Invoke(response);
			}
		});
	}

	public void ClaimAllBattleResultBonus(Action<C2S_ClaimAllBattleResultBonus.Response> onClaimFinished)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_ClaimAllBattleResultBonus
		{
			Req = new C2S_ClaimAllBattleResultBonus.Request()
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_ClaimAllBattleResultBonus.Response response = (C2S_ClaimAllBattleResultBonus.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				onClaimFinished?.Invoke(response);
			}
		});
	}

	private IEnumerator GetIslandLogs(C2S_GetSystemMessages_IslandBattleLog.Response response, Action<List<IslandLog>> onUpdate, Action onFinished = null)
	{
		List<GvGMode3ChatRecord> records = response.RecordList ?? new List<GvGMode3ChatRecord>();
		List<IslandLog> islandLogs = new List<IslandLog>();
		if (response.RunningLog != null)
		{
			islandLogs.Add(ConvertToIslandLog(response.RunningLog));
		}
		foreach (GvGMode3ChatRecord data in records)
		{
			string processId = data.MessageToShow.ToIslandLogProcessId();
			if (!string.IsNullOrEmpty(processId))
			{
				yield return LoadData(processId, "IslandLog.json", delegate(IslandLog islandLog)
				{
					islandLog.Id = (int)data.Id;
					islandLog.Checked = GameLocalDataManager.IslandLogChecked(processId);
					islandLogs.Add(islandLog);
				});
			}
		}
		yield return null;
		onUpdate?.Invoke(islandLogs);
		onFinished?.Invoke();
	}

	private IEnumerator GetIslandLogs(List<RunningBattleLogItem> logItems, Action<List<BattleLog_Big>> onComplete)
	{
		List<BattleLog_Big> islandLogs = new List<BattleLog_Big>();
		if (logItems == null)
		{
			onComplete?.Invoke(islandLogs);
			yield break;
		}
		int myCamp = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		foreach (RunningBattleLogItem item in logItems)
		{
			string processId = item.BattleLogKey;
			int userid = item.UserId;
			if (!string.IsNullOrEmpty(processId) && userid > 0)
			{
				string dataId = GetPlayerBattleLogRedisKey(userid);
				string saveName = processId + ".json";
				yield return LoadData(dataId, saveName, delegate(PlayerLog playerLog)
				{
					playerLog.BigLog.PlayerLogInit(playerLog.ProcessId, processId);
					playerLog.BigLog.DataInit(myCamp);
					islandLogs.Add(playerLog.BigLog);
				});
				yield return null;
			}
		}
		yield return null;
		onComplete?.Invoke(islandLogs);
	}

	private static IslandLog ConvertToIslandLog(C2S_GetSystemMessages_IslandBattleLog.RunningBattleLog runningRecord)
	{
		IslandLog islandLog = new IslandLog();
		islandLog.IsRunning = true;
		islandLog.Id = int.MaxValue;
		islandLog.Checked = true;
		islandLog.IslandStartTimestamp_ms = runningRecord.Timestamp_ms;
		islandLog.OriginalCampId = runningRecord.OriginalCampId;
		islandLog.ProcessStartByWhichCamp = runningRecord.ProcessStartByWhichCamp;
		islandLog.NameId = "mockId";
		islandLog.ProcessId = "mockProcess";
		islandLog.WinnerCampId = -1;
		return islandLog;
	}

	public void GetIslandBigBattleLog(string processId, Action<List<BattleLog_Big>> onFinished)
	{
		string dataLocalPath = GetDataLocalPath(processId, "IslandLog.json");
		IslandLog islandLog = ReadLocalData<IslandLog>(dataLocalPath);
		if (islandLog != null)
		{
			onFinished?.Invoke(islandLog.BigLogs ?? new List<BattleLog_Big>());
		}
	}

	public void GetIslandRunningBattleLog(int islandId, Action<List<BattleLog_Big>> onFinished)
	{
		double serverRealtimeSeconds = GameController.Instance.GetServerRealtimeSeconds();
		if (_runningLogCaches.TryGetValue(islandId, out var value) && (double)(value.LastGetTime + 10) > serverRealtimeSeconds)
		{
			LoadBattleLogBig(value.CacheData);
			return;
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetIslandRunningBattleLog
		{
			Req = new C2S_GetIslandRunningBattleLog.Request
			{
				Num = 5,
				IslandId = islandId
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_GetIslandRunningBattleLog.Response response = (C2S_GetIslandRunningBattleLog.Response)contextResponse.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished(null);
			}
			else
			{
				_runningLogCaches[islandId] = new RunningBattleLogKeyCache
				{
					LastGetTime = (int)GameController.Instance.GetServerRealtimeSeconds(),
					CacheData = response
				};
				LoadBattleLogBig(response);
			}
		});
		void LoadBattleLogBig(C2S_GetIslandRunningBattleLog.Response response)
		{
			FGUIManager.Instance.OpenIEnumerator(GetIslandLogs(response.Logs, onFinished));
		}
	}

	private IEnumerator GetIslandLogBriefs(string processId, Action<List<IslandLogBrief>> onFinished)
	{
		yield return LoadData(processId, "IslandResultReport.json", delegate(List<IslandLogBrief> logBriefs)
		{
			foreach (IslandLogBrief logBrief in logBriefs)
			{
				logBrief.Rank = logBrief.TotalRank + 1;
			}
			onFinished?.Invoke(logBriefs);
		});
	}

	public void GetIslandLogBrief(string processId, Action<List<IslandLogBrief>> onFinished)
	{
		FGUIManager.Instance.OpenIEnumerator(GetIslandLogBriefs(processId, onFinished));
	}

	public void UpdateRecordLevelInfo(string battleId = null, string levelId = null, int? result = null, Dictionary<Team, BattleResultStats> stats = null, int? hasBoss = null, List<ItemAbility> abilities = null, int? bossLevel = null, Dictionary<string, SoldierDetail> redDetails = null, Dictionary<string, SoldierDetail> blueDetails = null)
	{
		if (battleId != null)
		{
			RecordLevelInfo.BattleId = battleId;
		}
		if (levelId != null)
		{
			RecordLevelInfo.LevelId = levelId;
		}
		if (result.HasValue)
		{
			RecordLevelInfo.Result = result.Value;
		}
		if (stats != null)
		{
			RecordLevelInfo.BattleResultStats = stats;
		}
		if (hasBoss.HasValue)
		{
			RecordLevelInfo.HasBoss = hasBoss.Value != 0;
		}
		if (abilities != null)
		{
			RecordLevelInfo.Abilities = abilities;
		}
		if (bossLevel.HasValue)
		{
			RecordLevelInfo.BossLevel = bossLevel.Value;
		}
		if (redDetails != null)
		{
			RecordLevelInfo.RedDetails = redDetails;
		}
		if (blueDetails != null)
		{
			RecordLevelInfo.BlueDetails = blueDetails;
		}
	}

	public void PlayBattleRecord(string battleId, string processId, BattleLogShipInfo redInfo, BattleLogShipInfo blueInfo, bool hasBoss)
	{
		if (!_battleRecordDataLoading)
		{
			_battleRecordDataLoading = true;
			FGUIManager.Instance.OpenIEnumerator(LoadBattleRecordData(new GvG3RecordDetailUiModel
			{
				RedInfo = redInfo,
				BlueInfo = blueInfo,
				RecordLevelId = "EventislandGVG_001"
			}, battleId, processId, hasBoss));
		}
	}

	private IEnumerator LoadBattleRecordData(GvG3RecordDetailUiModel recordData, string battleId, string processId, bool hasBoss)
	{
		yield return LoadData(GetBattleParamsId(processId, battleId), "BattleParams.json", delegate(GvGMode3CalcBattleParams battleParams)
		{
			recordData.BattleParams = battleParams;
		});
		if (recordData.BattleParams != null && recordData.RedInfo.UserId != recordData.BattleParams.UserId)
		{
			GvG3RecordDetailUiModel gvG3RecordDetailUiModel = recordData;
			GvG3RecordDetailUiModel gvG3RecordDetailUiModel2 = recordData;
			BattleLogShipInfo blueInfo = recordData.BlueInfo;
			BattleLogShipInfo redInfo = recordData.RedInfo;
			gvG3RecordDetailUiModel.RedInfo = blueInfo;
			gvG3RecordDetailUiModel2.BlueInfo = redInfo;
		}
		yield return LoadData<BattleRecordDetailModel>(GroupBattleRecordDetailId(processId, recordData.RedInfo.GroupId, recordData.RedInfo.ShipRace, recordData.RedInfo.DeadCnt), dataIdUrlEncode: GroupBattleRecordDetailId(processId, UiHelper.UrlEncode(recordData.RedInfo.GroupId), recordData.RedInfo.ShipRace, recordData.RedInfo.DeadCnt), saveName: "BattleRecordDetail.bin", onFinished: delegate(BattleRecordDetailModel model)
		{
			recordData.RedDetailData = model;
		});
		yield return LoadData<BattleRecordDetailModel>(GroupBattleRecordDetailId(processId, recordData.BlueInfo.GroupId, recordData.BlueInfo.ShipRace, recordData.BlueInfo.DeadCnt), dataIdUrlEncode: GroupBattleRecordDetailId(processId, UiHelper.UrlEncode(recordData.BlueInfo.GroupId), recordData.BlueInfo.ShipRace, recordData.BlueInfo.DeadCnt), saveName: "BattleRecordDetail.bin", onFinished: delegate(BattleRecordDetailModel model)
		{
			recordData.BlueDetailData = model;
		});
		yield return LoadData(battleId, "ret.bin", delegate(GetGvGBattleResultResponse response)
		{
			recordData.BattleResult = response;
		}, isRet: true, useProtoBuf: true);
		if (!recordData.CheckDataIntegrity)
		{
			_battleRecordDataLoading = false;
			yield break;
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3RecordDetailPanel.Name, new Dictionary<string, object>
		{
			{ "ReservePackageResOnClose", true },
			{ "RecordDetail", recordData },
			{ "HasBoss", hasBoss }
		});
		_battleRecordDataLoading = false;
	}

	private IEnumerator LoadData<T>(string dataId, string saveName, Action<T> onFinished, bool isRet = false, bool useProtoBuf = false, string dataIdUrlEncode = "") where T : class
	{
		string dataLocalPath = GetDataLocalPath(dataId, saveName);
		CoroutineWithData loadData = new CoroutineWithData(target: GetData<T>(dataLocalPath, isRet ? GetBattleResultHttpUrl(dataId, saveName) : GetDataHttpUrl((!string.IsNullOrEmpty(dataIdUrlEncode)) ? dataIdUrlEncode : dataId, saveName), useProtoBuf), owner: (MonoBehaviour)(object)FGUIManager.Instance);
		yield return loadData.Coroutine;
		object result = loadData.Result;
		if (result is T result2)
		{
			onFinished?.Invoke(result2);
		}
	}
}
