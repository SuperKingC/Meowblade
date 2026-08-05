using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Scripts.UI.LoadWebImage;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Models.Sources;
using Shift.Legion;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.Battle;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_PvpBattleLogPanel : GComponent, IUiController
{
	public class BattleLogUserInfo
	{
		public int RedUserId;

		public bool RedIsUser;

		public string RedNpcUrl;

		public bool BlueIsUser;

		public string BlueNpcUrl;

		public int BlueUserId;

		public string BattleId;
	}

	public GGraph Mask;

	public UI_PvpBattleLogDialog Dialog;

	public const string URL = "ui://82mo10n5uk8wbq";

	public static string Name = "UI_PvpBattleLogPanel";

	private List<string> canNotCLosePanelsOnLoadScene;

	private int countermax = 0;

	private LogFilter curLogFilterType;

	private BattleLogSource dataSource;

	private int CurUserId;

	private const int PageNum = 10;

	private const int NickNameMaxLength = 14;

	private LoadWebImageTaskQueue loadWebImageTaskQueue;

	private int TopTournamentCurrentDayIndex;

	private bool _logDownloading;

	private readonly List<UI_LogFilterBtn> _logFilters = new List<UI_LogFilterBtn>(2);

	private List<RankChangeRecord> lastTurnLast10ChangeRecords = new List<RankChangeRecord>();

	private List<RankChangeRecord> lastTurnLast10RankChangeRecords = new List<RankChangeRecord>();

	private List<RankChangeRecord> lastTurnUserPlayOffChangeRecords = new List<RankChangeRecord>();

	private int total_download_cnt = 0;

	private int retry_times = 0;

	private Coroutine downloadReplayDataCoroutine;

	public Dictionary<int, AvatarAndNameCache> AvatarAndNameCachingMap = new Dictionary<int, AvatarAndNameCache>();

	public static string GetURL()
	{
		return "ui://82mo10n5uk8wbq";
	}

	public static UI_PvpBattleLogPanel CreateInstance()
	{
		return (UI_PvpBattleLogPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpBattleLogPanel");
	}

	public static UI_PvpBattleLogPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpBattleLogPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5uk8wbq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_PvpBattleLogDialog)(object)((GComponent)this).GetChild("Dialog");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GComponent)((GComponent)Dialog).GetChild("BattleLogList").asList).scrollPane.onPullUpRelease.Add(new EventCallback0(Refresh));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GComponent)((GComponent)Dialog).GetChild("BattleLogList").asList).scrollPane.onPullUpRelease.Remove(new EventCallback0(Refresh));
	}

	private void FilterInit()
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		_logFilters.Add(Dialog.Filter.Win);
		_logFilters.Add(Dialog.Filter.Fail);
		for (int i = 0; i < _logFilters.Count; i++)
		{
			UI_LogFilterBtn uI_LogFilterBtn = _logFilters[i];
			((GButton)uI_LogFilterBtn).selected = false;
			if (i == 0)
			{
				((GObject)uI_LogFilterBtn).data = 1;
			}
			if (i == 1)
			{
				((GObject)uI_LogFilterBtn).data = 2;
			}
			((GObject)uI_LogFilterBtn).onClick.Set(new EventCallback1(ChangeFilter));
		}
		curLogFilterType = LogFilter.All;
	}

	private void ChangeFilter(EventContext context)
	{
		UI_LogFilterBtn uI_LogFilterBtn = (UI_LogFilterBtn)(object)context.sender;
		if (((GObject)uI_LogFilterBtn).data != null && !_logDownloading)
		{
			if (uI_LogFilterBtn.Checked.selectedIndex == 1)
			{
				ChangeLogFilter(LogFilter.All);
				Dialog.BattleLogList.RemoveChildrenToPool();
				BattleLogListInit();
			}
			else
			{
				ChangeLogFilter((LogFilter)(int)((GObject)uI_LogFilterBtn).data);
				Dialog.BattleLogList.RemoveChildrenToPool();
				BattleLogListInit();
			}
		}
	}

	private void ChangeLogFilter(LogFilter type)
	{
		curLogFilterType = type;
		if (curLogFilterType == LogFilter.All)
		{
			foreach (UI_LogFilterBtn logFilter2 in _logFilters)
			{
				logFilter2.Checked.SetSelectedIndex(0);
			}
			return;
		}
		foreach (UI_LogFilterBtn logFilter3 in _logFilters)
		{
			LogFilter logFilter = (LogFilter)(int)((GObject)logFilter3).data;
			logFilter3.Checked.SetSelectedIndex((logFilter == curLogFilterType) ? 1 : 0);
		}
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		UIObjectFactory.SetPackageItemExtension("ui://PvpSelectSoldiers/Loading", typeof(ScrollPaneHeader));
		FilterInit();
		object value3;
		if (parameters != null && parameters.TryGetValue("CurrentUserId", out var value))
		{
			CurUserId = (int)value;
			TopTournamentCurrentDayIndex = (int)parameters["TopTournamentDayIndex"];
			if (TopTournamentCurrentDayIndex <= 0)
			{
				if (parameters.TryGetValue("LastTurnRankChangeRecord", out var value2))
				{
					lastTurnUserPlayOffChangeRecords = (List<RankChangeRecord>)value2;
				}
				dataSource = BattleLogSource.LastTurnTopTournament;
			}
			else
			{
				dataSource = BattleLogSource.TopTournament;
			}
		}
		else if (parameters != null && parameters.TryGetValue("LastTurnLast10RankChangeRecord", out value3))
		{
			CurUserId = GameController.Contexts.gameState.user.value.UserId;
			lastTurnLast10ChangeRecords = (List<RankChangeRecord>)value3;
			dataSource = BattleLogSource.LastTurnLast10;
		}
		else
		{
			CurUserId = GameController.Contexts.gameState.user.value.UserId;
			dataSource = BattleLogSource.Common;
		}
		BattleLogListInit();
		SetOpenUiOnReturnMainCityData(parameters);
	}

	private void SetOpenUiOnReturnMainCityData(Dictionary<string, object> parameters)
	{
		canNotCLosePanelsOnLoadScene = new List<string>
		{
			UI_LadderTournamentPanel.Name,
			UI_PvpZoneChoose.Name,
			UI_TopTournamentHistoryRankList.Name,
			UI_TopTournamentBattlePanel.Name,
			UI_TopTournamentEveryDayLogPanel.Name,
			Name
		};
		RankDataHelper.SetPanelsOpenUiOnReturnMainCityData(canNotCLosePanelsOnLoadScene, parameters);
	}

	private List<RankChangeRecord> FilterRankChangeRecords(ref List<RankChangeRecord> summariesInit)
	{
		if (summariesInit != null)
		{
			summariesInit.RemoveAll((RankChangeRecord summary) => summary.HostRank < 1 && !summary.BattleId.StartsWith("TT_"));
		}
		if (curLogFilterType == LogFilter.All)
		{
			return summariesInit;
		}
		for (int num = summariesInit.Count - 1; num >= 0; num--)
		{
			if (CanFilterBattleLog(summariesInit[num]))
			{
				summariesInit.RemoveAt(num);
			}
		}
		return summariesInit;
	}

	private async void BattleLogListInit()
	{
		if (!_logDownloading)
		{
			_logDownloading = true;
			loadWebImageTaskQueue?.Clear();
			loadWebImageTaskQueue = new LoadWebImageTaskQueue();
			if (dataSource == BattleLogSource.TopTournament)
			{
				await TopTournamentBattleLogRender();
				Dialog.Type.selectedIndex = 0;
			}
			else if (dataSource == BattleLogSource.LastTurnTopTournament)
			{
				await LastTurnTopTournamentBattleLogRender();
				Dialog.Type.selectedIndex = 0;
			}
			else if (dataSource == BattleLogSource.LastTurnLast10)
			{
				LastTurnLast10BattleLogRender();
				Dialog.Type.selectedIndex = 1;
			}
			else
			{
				await RefreshInit();
				Dialog.Type.selectedIndex = 0;
			}
			Dialog.SetControllerPageText();
			loadWebImageTaskQueue?.Start();
			_logDownloading = false;
		}
	}

	private void LastTurnLast10BattleLogRender()
	{
		if (lastTurnLast10ChangeRecords != null && lastTurnLast10ChangeRecords.Count > 0)
		{
			FilterRankChangeRecords(ref lastTurnLast10ChangeRecords);
			RenderLastTurnLast10AllLog(lastTurnLast10ChangeRecords);
		}
	}

	private void RenderLastTurnLast10AllLog(List<RankChangeRecord> Summaries)
	{
		RenderAll(Summaries);
	}

	private int DayIndexListInit()
	{
		RankDataHelper.GetCurrentSeasonIs(isBattleEnd: true, out var turns);
		List<int> list = new List<int>();
		for (int i = 0; i < turns.Count; i++)
		{
			list.Add(turns[i].Turn - 1);
		}
		if (turns.Count <= 0 || list.Count <= 0)
		{
			return -1;
		}
		int num = (int)GameController.Instance.GetServerTime();
		int endAtTimestamp = turns[turns.Count - 1].EndAtTimestamp;
		if (num <= endAtTimestamp)
		{
			return 0;
		}
		return list.ToList()[list.Count - 1];
	}

	private async Task GetLastTurnLast10()
	{
		int turnId = DayIndexListInit();
		int originalCurTurnId = ((RankDataHelper.RankSeasonInfo.TurnId < 0) ? (turnId + RankDataHelper.RankSeasonInfo.Id * 10 + 1) : RankDataHelper.RankSeasonInfo.TurnId);
		int currentTurnId = originalCurTurnId - RankDataHelper.RankSeasonInfo.Id * 10;
		bool isFirstTurn = currentTurnId <= 0;
		int lastTurnId = (isFirstTurn ? 3 : (currentTurnId - 1));
		int lastSeasonId = (isFirstTurn ? (RankDataHelper.RankSeasonInfo.Id - 1) : RankDataHelper.RankSeasonInfo.Id);
		GetPvPRankLastTurnLast10SelfRankRecordResponse response = await GameController.Contexts.Service<INetworkService>().GetPvPRankLastTurnLast10SelfRankRecord(lastSeasonId, lastTurnId);
		if (!response.Result)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			return;
		}
		lastTurnLast10ChangeRecords = response.RankChangeRecords;
		FilterRankChangeRecords(ref lastTurnLast10ChangeRecords);
		RenderLastTurnLast10Log(lastTurnLast10ChangeRecords);
	}

	private void RenderLastTurnLast10Log(List<RankChangeRecord> Summaries)
	{
		if (Summaries != null && Summaries.Count > 0 && !((GObject)this).isDisposed)
		{
			UI_PvpBattleLogInfoResources uI_PvpBattleLogInfoResources = ((GComponent)Dialog).GetChild("BattleLogList").asList.AddItemFromPool() as UI_PvpBattleLogInfoResources;
			string lAST_TURN_BATTLE_LOG_TITLE = ConstStr.LAST_TURN_BATTLE_LOG_TITLE;
			((GComponent)uI_PvpBattleLogInfoResources).GetChild("Day").text = lAST_TURN_BATTLE_LOG_TITLE;
			Controller controller = ((GComponent)uI_PvpBattleLogInfoResources).GetController("Type");
			controller.selectedIndex = 0;
			for (int i = 0; i < Summaries.Count; i++)
			{
				DataProgressAndOutput(Summaries[i], isLastTurnLogInCommonLog: true);
			}
		}
	}

	private async Task TopTournamentBattleLogRender()
	{
		new List<RankChangeRecord>();
		GetPvPTopTournamentRecordSinglePlayerResponse dic = await GameController.Contexts.Service<INetworkService>().GetPvPTopTournamentRecordSinglePlayer(TopTournamentCurrentDayIndex, CurUserId);
		if (dic.Result)
		{
			List<RankChangeRecord> SummariesInit = dic.RankChangeRecords;
			FilterRankChangeRecords(ref SummariesInit);
			if (SummariesInit.Count != 0)
			{
				await RenderTopTournamentAllLog(SummariesInit);
			}
		}
		else
		{
			ILRequestHelper.ShowErrorCode(dic.ErrorCode);
		}
	}

	private async Task LastTurnTopTournamentBattleLogRender()
	{
		if (lastTurnUserPlayOffChangeRecords != null && lastTurnUserPlayOffChangeRecords.Count > 0)
		{
			FilterRankChangeRecords(ref lastTurnUserPlayOffChangeRecords);
			await RenderTopTournamentAllLog(lastTurnUserPlayOffChangeRecords);
			return;
		}
		new List<RankChangeRecord>();
		GetPvPRankLastTurnLastDaySinglePlayerRecordResultResponse dic = await GameController.Contexts.Service<INetworkService>().GetPvPRankLastTurnLastDaySinglePlayerRecordResult(CurUserId);
		if (dic.Result)
		{
			List<RankChangeRecord> SummariesInit = dic.RankChangeRecords;
			FilterRankChangeRecords(ref SummariesInit);
			if (SummariesInit.Count != 0)
			{
				await RenderTopTournamentAllLog(SummariesInit);
			}
		}
		else
		{
			ILRequestHelper.ShowErrorCode(dic.ErrorCode);
		}
	}

	private async Task RenderTopTournamentAllLog(List<RankChangeRecord> Summaries)
	{
		if (Summaries.Count == 0)
		{
			return;
		}
		for (int i = 0; i < Summaries.Count; i++)
		{
			if (i % 3 == 0)
			{
				await Task.Delay(2);
			}
			DataProgressAndOutput(Summaries[i]);
		}
	}

	private async Task RefreshInit()
	{
		lastTurnLast10ChangeRecords?.Clear();
		List<RankChangeRecord> SummariesInit = new List<RankChangeRecord>();
		GetPvPRankBattleRecordsResponse dic = await GameController.Contexts.Service<INetworkService>().GetRankBattleRecords(0, 0);
		if (dic.Result)
		{
			SummariesInit = dic.RankChangeRecords;
			if (SummariesInit.Count != 0)
			{
				countermax = ((SummariesInit[0].Index - 10 > 0) ? (SummariesInit[0].Index - 10) : 0);
			}
			FilterRankChangeRecords(ref SummariesInit);
		}
		else
		{
			ILRequestHelper.ShowErrorCode(dic.ErrorCode);
		}
		RenderAll(SummariesInit);
		await GetLastTurnLast10();
	}

	public async Task FinalRefreh()
	{
		loadWebImageTaskQueue?.Clear();
		loadWebImageTaskQueue = new LoadWebImageTaskQueue();
		List<RankChangeRecord> Summaries = new List<RankChangeRecord>();
		int list = 0;
		Summaries.Clear();
		if (countermax == 0)
		{
			return;
		}
		for (int i = ((countermax <= 10 && countermax > 0) ? 1 : (countermax - 10)); i <= countermax; i++)
		{
			if (!PlayerPrefs.HasKey("PvPLog" + i))
			{
				list = i;
				break;
			}
		}
		List<RankChangeRecord> summaries = GetLocalRecord(await GetService(Summaries, list), list);
		FilterRankChangeRecords(ref summaries);
		countermax = ((countermax - 10 > 0) ? (countermax - 10) : 0);
		RenderAll(summaries);
		loadWebImageTaskQueue?.Start();
	}

	private List<RankChangeRecord> GetLocalRecord(List<RankChangeRecord> Summaries, int list)
	{
		if (list != 1)
		{
			int num = ((list > 1) ? list : countermax);
			int num2 = ((countermax > 10) ? (countermax - 10) : 0);
			while (num > num2)
			{
				string json = PlayerPrefs.GetString("PvPLog" + num);
				RankChangeRecord item = JsonHelper.ToObject<RankChangeRecord>(json);
				Summaries.Add(item);
				num--;
			}
		}
		return Summaries;
	}

	private async Task<List<RankChangeRecord>> GetService(List<RankChangeRecord> Summaries, int list)
	{
		if (list != 0)
		{
			int cutoff = ((list > 1) ? list : 0);
			GetPvPRankBattleRecordsResponse dic = await GameController.Contexts.Service<INetworkService>().GetRankBattleRecords(cutoff, countermax);
			if (dic.Result)
			{
				Summaries = dic.RankChangeRecords;
			}
			else
			{
				ILRequestHelper.ShowErrorCode(dic.ErrorCode);
			}
		}
		return Summaries;
	}

	private void RenderAll(List<RankChangeRecord> Summaries)
	{
		if (Summaries.Count == 0)
		{
			return;
		}
		bool[] array = new bool[8];
		string[] array2 = new string[8]
		{
			LanguagesManager.GetDesc("CsharpCodeZhTcText466"),
			LanguagesManager.GetDesc("CsharpCodeZhTcText467"),
			LanguagesManager.GetDesc("CsharpCodeZhTcText468"),
			LanguagesManager.GetDesc("CsharpCodeZhTcText469"),
			LanguagesManager.GetDesc("CsharpCodeZhTcText470"),
			LanguagesManager.GetDesc("CsharpCodeZhTcText471"),
			LanguagesManager.GetDesc("CsharpCodeZhTcText472"),
			LanguagesManager.GetDesc("CsharpCodeZhTcText473")
		};
		for (int i = 0; i < Summaries.Count; i++)
		{
			int num = DateDefine(Summaries[i]);
			if (num > 7)
			{
				continue;
			}
			if (!array[num])
			{
				if (((GObject)this).isDisposed)
				{
					break;
				}
				GList asList = ((GComponent)Dialog).GetChild("BattleLogList").asList;
				UI_PvpBattleLogInfoResources uI_PvpBattleLogInfoResources;
				if (dataSource == BattleLogSource.Common && lastTurnLast10ChangeRecords != null && lastTurnLast10ChangeRecords.Count > 0)
				{
					int num2 = asList.numItems - (lastTurnLast10ChangeRecords.Count + 1);
					uI_PvpBattleLogInfoResources = UI_PvpBattleLogInfoResources.CreateInstance_ILRuntime();
					((GComponent)asList).AddChildAt((GObject)(object)uI_PvpBattleLogInfoResources, num2);
				}
				else
				{
					uI_PvpBattleLogInfoResources = asList.AddItemFromPool() as UI_PvpBattleLogInfoResources;
				}
				string text = array2[num];
				((GComponent)uI_PvpBattleLogInfoResources).GetChild("Day").text = text;
				Controller controller = ((GComponent)uI_PvpBattleLogInfoResources).GetController("Type");
				controller.selectedIndex = 0;
				array[num] = true;
			}
			DataProgressAndOutput(Summaries[i]);
		}
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void Refresh()
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		GList _list = ((GComponent)Dialog).GetChild("BattleLogList").asList;
		ScrollPaneHeader footer = (ScrollPaneHeader)(object)((GComponent)_list).scrollPane.footer;
		footer.SetRefreshStatus(2);
		((GComponent)_list).scrollPane.LockFooter(30);
		GTweenCallback val = default(GTweenCallback);
		((GComponent)(object)this).SetTimeout(2f).OnComplete((GTweenCallback)delegate
		{
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_005b: Expected O, but got Unknown
			Task task = FinalRefreh();
			footer.SetRefreshStatus(3);
			((GComponent)_list).scrollPane.LockFooter(35);
			GTweener obj = ((GComponent)(object)this).SetTimeout(0.5f);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					footer.SetRefreshStatus(0);
					((GComponent)_list).scrollPane.LockFooter(0);
				};
				GTweenCallback val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.OnComplete(obj2);
		});
	}

	private int DateDefine(RankChangeRecord data)
	{
		DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime()).Add(DateTimeHelper.TimezoneOffset);
		DateTimeOffset dateTimeOffset2 = DateTimeHelper.ParseTimeStamp(data.Timestamp).Add(DateTimeHelper.TimezoneOffset);
		if (dateTimeOffset < dateTimeOffset2)
		{
			return 50;
		}
		dateTimeOffset = new DateTimeOffset(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, 0, 0, 0, DateTimeHelper.TimezoneOffset);
		dateTimeOffset2 = new DateTimeOffset(dateTimeOffset2.Year, dateTimeOffset2.Month, dateTimeOffset2.Day, 0, 0, 0, DateTimeHelper.TimezoneOffset);
		return (dateTimeOffset - dateTimeOffset2).Days;
	}

	private bool CanFilterBattleLog(RankChangeRecord data)
	{
		if (curLogFilterType == LogFilter.Win && data.ChallengerId == CurUserId && data.Winner == 100)
		{
			return true;
		}
		if (curLogFilterType == LogFilter.Win && data.HostId == CurUserId && data.Winner == 200)
		{
			return true;
		}
		if (curLogFilterType == LogFilter.Fail && data.ChallengerId == CurUserId && data.Winner == 200)
		{
			return true;
		}
		if (curLogFilterType == LogFilter.Fail && data.HostId == CurUserId && data.Winner == 100)
		{
			return true;
		}
		return false;
	}

	private void DataProgressAndOutput(RankChangeRecord data, bool isLastTurnLogInCommonLog = false)
	{
		E_Winner e_Winner = E_Winner.Error;
		int id = 0;
		int winner = 0;
		int rank = 0;
		int types = 0;
		int enemyrank = 0;
		int enemyid = 0;
		string battleId = data.BattleId;
		int redPlayOffHp = -1;
		int bluePlayOffHp = -1;
		BattleLogUserInfo battleLogUserInfo = new BattleLogUserInfo
		{
			RedUserId = data.ChallengerId,
			BlueUserId = data.HostId
		};
		if (data.ChallengerId <= 0)
		{
			battleLogUserInfo.RedIsUser = false;
			battleLogUserInfo.RedNpcUrl = RankDataHelper.GetNpcIconName(data.ChallengerRank);
		}
		else
		{
			battleLogUserInfo.RedIsUser = true;
		}
		if (data.HostId <= 0)
		{
			battleLogUserInfo.BlueIsUser = false;
			battleLogUserInfo.BlueNpcUrl = RankDataHelper.GetNpcIconName(data.HostRank);
		}
		else
		{
			battleLogUserInfo.BlueIsUser = true;
		}
		if (data.ChallengerId == CurUserId)
		{
			id = data.ChallengerId;
			rank = data.ChallengerRank;
			types = 1;
			enemyrank = data.HostRank;
			enemyid = data.HostId;
			if (data.Winner == 100)
			{
				e_Winner = E_Winner.enemy;
			}
			else if (data.Winner == 200)
			{
				e_Winner = E_Winner.player;
			}
			if (data.KingPoints != null && data.KingPoints.Count > 1)
			{
				redPlayOffHp = data.KingPoints[0];
				bluePlayOffHp = data.KingPoints[1];
			}
		}
		if (data.HostId == CurUserId)
		{
			id = data.HostId;
			rank = data.HostRank;
			types = 0;
			enemyrank = data.ChallengerRank;
			enemyid = data.ChallengerId;
			if (data.Winner == 100)
			{
				e_Winner = E_Winner.player;
			}
			else if (data.Winner == 200)
			{
				e_Winner = E_Winner.enemy;
			}
			if (data.KingPoints != null && data.KingPoints.Count > 1)
			{
				redPlayOffHp = data.KingPoints[1];
				bluePlayOffHp = data.KingPoints[0];
			}
		}
		switch (e_Winner)
		{
		case E_Winner.player:
			winner = 1;
			break;
		case E_Winner.enemy:
			winner = 0;
			break;
		case E_Winner.Error:
			Debug.LogError((object)"战斗记录有关胜负方记录有误");
			break;
		}
		Render(id, winner, rank, types, enemyid, enemyrank, battleId, redPlayOffHp, bluePlayOffHp, battleLogUserInfo, isLastTurnLogInCommonLog);
	}

	private void Render(int id, int winner, int rank, int types, int enemyid, int enemyrank, string battleid, int redPlayOffHp, int bluePlayOffHp, BattleLogUserInfo logInfo, bool isLastTurnLogInCommonLog = false)
	{
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b6: Expected O, but got Unknown
		if (((GObject)this).isDisposed || ((GObject)Dialog).isDisposed)
		{
			return;
		}
		GList asList = ((GComponent)Dialog).GetChild("BattleLogList").asList;
		UI_PvpBattleLogInfoResources gobj;
		if (dataSource == BattleLogSource.Common && lastTurnLast10ChangeRecords != null && lastTurnLast10ChangeRecords.Count > 0 && !isLastTurnLogInCommonLog)
		{
			int num = asList.numItems - (lastTurnLast10ChangeRecords.Count + 1);
			gobj = UI_PvpBattleLogInfoResources.CreateInstance_ILRuntime();
			((GComponent)asList).AddChildAt((GObject)(object)gobj, num);
		}
		else
		{
			gobj = asList.AddItemFromPool() as UI_PvpBattleLogInfoResources;
		}
		if (gobj == null)
		{
			return;
		}
		Controller controller = ((GComponent)gobj).GetController("Type");
		controller.selectedIndex = 1;
		controller = ((GComponent)gobj).GetController("AttackAndDefense");
		controller.selectedIndex = types;
		controller = ((GComponent)gobj).GetController("Status");
		controller.selectedIndex = winner;
		UI_RankListLevelDiy uI_RankListLevelDiy = ((GComponent)gobj).GetChild("MyRank") as UI_RankListLevelDiy;
		uI_RankListLevelDiy.ShowRankLevel(rank);
		UI_RankListLevelDiy uI_RankListLevelDiy2 = ((GComponent)gobj).GetChild("EnemyRank") as UI_RankListLevelDiy;
		uI_RankListLevelDiy2.ShowRankLevel(enemyrank);
		((GObject)uI_RankListLevelDiy2).visible = dataSource == BattleLogSource.Common;
		((GObject)uI_RankListLevelDiy).visible = dataSource == BattleLogSource.Common;
		GObject child = ((GComponent)gobj).GetChild("RedUserHpBar");
		GObject child2 = ((GComponent)gobj).GetChild("BlueUserHpBar");
		if (redPlayOffHp <= -1 || bluePlayOffHp <= -1)
		{
			child.visible = false;
			child2.visible = false;
		}
		else
		{
			child.visible = true;
			child2.visible = true;
			((GComponent)gobj).GetChild("RedUserHp").asProgress.value = redPlayOffHp;
			((GComponent)gobj).GetChild("BlueUserHp").asProgress.value = bluePlayOffHp;
		}
		gobj.Attaches.SetSelectedIndex(0);
		if (id <= 0)
		{
			gobj.MyAvatar.HeadPortrait.Type.selectedIndex = 1;
			gobj.MyAvatar.HeadPortrait.icon.url = RankDataHelper.GetNpcIconName(rank);
			((GObject)gobj.MyName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText51");
			gobj.MyName.color = Color32.op_Implicit(new Color32((byte)60, (byte)179, (byte)113, byte.MaxValue));
			gobj.isShowMedalLeft.SetSelectedIndex(0);
		}
		else
		{
			gobj.MyAvatar.HeadPortrait.Type.selectedIndex = 0;
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetPvpUserAvatarAndNameForUiPvpBattleLogInfoResources(id, gobj.MyAvatar.HeadPortrait.icon, gobj.MyName));
			FGUIManager.Instance.GetUserMedal(id, gobj.LeftMedalList, gobj.isShowMedalLeft, SetComponentHeight);
		}
		if (enemyid <= 0)
		{
			gobj.EnemyAvatar.HeadPortrait.Type.selectedIndex = 1;
			gobj.EnemyAvatar.HeadPortrait.icon.url = RankDataHelper.GetNpcIconName(enemyrank);
			((GObject)gobj.EnemyName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText51");
			gobj.EnemyName.color = Color32.op_Implicit(new Color32((byte)60, (byte)179, (byte)113, byte.MaxValue));
			gobj.isShowMedalRight.SetSelectedIndex(0);
		}
		else
		{
			gobj.EnemyAvatar.HeadPortrait.Type.selectedIndex = 0;
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetPvpUserAvatarAndNameForUiPvpBattleLogInfoResources(enemyid, gobj.EnemyAvatar.HeadPortrait.icon, gobj.EnemyName));
			FGUIManager.Instance.GetUserMedal(enemyid, gobj.RightMedalList, gobj.isShowMedalRight, SetComponentHeight);
		}
		UI_ShowLevelChange uI_ShowLevelChange = ((GComponent)gobj).GetChild("LevelChangeContent") as UI_ShowLevelChange;
		if (uI_ShowLevelChange != null)
		{
			((GObject)uI_ShowLevelChange).visible = false;
		}
		if ((dataSource == BattleLogSource.Common || dataSource == BattleLogSource.LastTurnLast10) && uI_ShowLevelChange != null)
		{
			if (types == 0 && winner == 0)
			{
				uI_ShowLevelChange.Type.selectedIndex = 1;
				((GObject)uI_ShowLevelChange).visible = true;
			}
			else if (types == 1 && winner == 1)
			{
				uI_ShowLevelChange.Type.selectedIndex = 2;
				((GObject)uI_ShowLevelChange).visible = true;
			}
			((GObject)uI_ShowLevelChange.LastLevel).text = string.Format("{0}{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText475"), rank);
			((GObject)uI_ShowLevelChange.CurrentLevel).text = $"{enemyrank}";
		}
		logInfo.BattleId = battleid;
		((GObject)gobj.PlayBtn).data = logInfo;
		((GObject)gobj.PlayBtn).onClick.Set((EventCallback0)delegate
		{
			OnClickPlayBtn(logInfo);
		});
		void SetComponentHeight(bool hasMedals)
		{
			if (gobj.Attaches.selectedIndex != 1)
			{
				gobj.Attaches.SetSelectedIndex(hasMedals ? 1 : 0);
			}
		}
	}

	private async void OnClickPlayBtn(BattleLogUserInfo battleLogUserInfo)
	{
		if (dataSource == BattleLogSource.TopTournament || dataSource == BattleLogSource.LastTurnTopTournament)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpBattleLogDetailPanel.Name, new Dictionary<string, object>
			{
				{ "DataSource", dataSource },
				{ "UserInfo", battleLogUserInfo }
			});
			return;
		}
		GetLevelReplaysResponse replaydataservice = await GameController.Contexts.Service<INetworkService>().GetLevelReplays("RankBattleFieldLevel", random: false, battleLogUserInfo.BattleId);
		if (!replaydataservice.Result)
		{
			ILRequestHelper.ShowErrorCode(replaydataservice.ErrorCode);
		}
		else if (replaydataservice.Replays != null && replaydataservice.Replays.Count > 0)
		{
			LevelBattleReplay replayData = replaydataservice.Replays[0];
			if (replayData.Detail == null || string.IsNullOrEmpty(replayData.Detail.PvP_Details))
			{
				GameController.Contexts.Service<INetworkService>().InformWatchingPvPRankReplay(battleLogUserInfo.BattleId);
				GameManagers.Instance.Messenger.Broadcast("WATCHING_PVP_RANK_REPLAY");
				LevelBattleReplay _replaydata = replaydataservice.Replays[0];
				BattleRecordDetail detail = _replaydata.Detail;
				StartPlayReplay(_replaydata, detail, battleLogUserInfo);
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpBattleLogDetailPanel.Name, new Dictionary<string, object>
				{
					{ "DataSource", dataSource },
					{ "UserInfo", battleLogUserInfo },
					{ "BattleReplay", replayData }
				});
			}
		}
	}

	private void StartPlayReplay(LevelBattleReplay _replaydata, BattleRecordDetail detail, BattleLogUserInfo battleLogUserInfo)
	{
		if (_replaydata == null || detail == null)
		{
			return;
		}
		List<string> list = new List<string>();
		list.Add("ret.bin");
		for (int i = 0; i < detail.PvP_ReplaySegments.Count; i++)
		{
			for (int j = i * 10000; j < detail.PvP_ReplaySegments[i]; j++)
			{
				list.Add(j.ToString());
			}
		}
		UI_Battle.pvpEnemyInfo = new UI_Battle.PvpEnemyInfo
		{
			UserId = battleLogUserInfo.BlueUserId,
			IsUser = battleLogUserInfo.BlueIsUser,
			NpcUrl = battleLogUserInfo.BlueNpcUrl
		};
		UI_Battle.pvpRedInfo = new UI_Battle.PvpRedUserInfo
		{
			UserId = battleLogUserInfo.RedUserId,
			IsUser = battleLogUserInfo.RedIsUser,
			NpcUrl = battleLogUserInfo.RedNpcUrl
		};
		RankDataHelper.info = new RankBattleInfo(_replaydata.BattleId);
		RankDataHelper.info.RealLegionSize = detail.PvP_ReplaySegments.Count;
		RankDataHelper.info.NeedLegionSize = detail.PvP_ReplaySegments.Count;
		RankDataHelper.UpdateRankBattleReplayResult(_replaydata.BattleId, _replaydata.Result, new Dictionary<Team, BattleResultStats>());
		total_download_cnt = list.Count;
		if (downloadReplayDataCoroutine == null)
		{
			downloadReplayDataCoroutine = FGUIManager.Instance.OpenIEnumerator(DownloadReplayData(_replaydata, list));
		}
	}

	public IEnumerator DownloadReplayData(LevelBattleReplay replay, List<string> queue, string downloading = "", float wait_tm = 0f)
	{
		GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: true);
		UnityUiService.Instance.SetWaitingPanelType(1);
		UnityUiService.Instance.SetWaitingPanelDownloadProgress(0f, LanguagesManager.GetDesc("CsharpCodeZhTcText52"));
		yield return ReplayDownloadManager.DownloadReplayZip(replay.BattleId, delegate(bool isSuccess)
		{
			if (!isSuccess)
			{
			}
		}, delegate(float progress)
		{
			float barValue = progress * 65f;
			UnityUiService.Instance.SetWaitingPanelDownloadProgress(barValue, LanguagesManager.GetDesc("CsharpCodeZhTcText52"));
		});
		yield return PlayBattleReplay(replay, queue);
		downloadReplayDataCoroutine = null;
	}

	public IEnumerator PlayBattleReplay(LevelBattleReplay replay, List<string> queue, string downloading = "", float wait_tm = 0f)
	{
		if (wait_tm > 0f)
		{
			yield return (object)new WaitForSeconds(0.2f);
		}
		else
		{
			yield return null;
		}
		if (queue.Count == 0)
		{
			yield break;
		}
		if (string.IsNullOrEmpty(downloading))
		{
			downloading = queue[0];
			queue.RemoveAt(0);
		}
		ReplayDownloadManager.DownloadReplay(replay.BattleId, downloading, delegate(bool isSucess)
		{
			if (!isSucess)
			{
				if (retry_times > 10)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText53") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText54") };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				}
				else
				{
					retry_times++;
					FGUIManager.Instance.OpenIEnumerator(PlayBattleReplay(replay, queue, downloading, 0.2f));
				}
			}
			else
			{
				retry_times = 0;
				float num = 1f * (float)(total_download_cnt - queue.Count) / (float)total_download_cnt;
				float barValue = num * 35f + 65f;
				UnityUiService.Instance.SetWaitingPanelDownloadProgress(barValue, LanguagesManager.GetDesc("CsharpCodeZhTcText474"));
				if (queue.Count == 0)
				{
					GameController.Contexts.Service<IUiService>().ShowWaitingAnimation(show: false);
					PlayBattleReplayData playBattleReplayData = new PlayBattleReplayData
					{
						BattleId = replay.BattleId,
						TargetFrame = replay.ReplayFrames - 1,
						LevelId = replay.LevelId,
						LocalSource = true,
						ReplayMode = 3,
						MaskDuration = 0
					};
					QuickPlayReplayService.info.BattleId = string.Empty;
					GameLocalDataManager.SetLastReplayUserInfo(replay.Nickname, replay.Avatar);
					GameLocalDataManager.SetLastReplay(playBattleReplayData);
					GameManagers.Instance.Messenger.Broadcast<PlayBattleReplayData, CustomTaskCompletionSource<bool>>("ACTION_PLAY_BATTLE_REPLAY", playBattleReplayData, null);
				}
				else
				{
					FGUIManager.Instance.OpenIEnumerator(PlayBattleReplay(replay, queue));
				}
			}
		});
	}

	private IEnumerator GetPvpUserAvatarAndName(int userId)
	{
		if (!AvatarAndNameCachingMap.TryGetValue(userId, out var avatarAndName))
		{
			avatarAndName = new AvatarAndNameCache
			{
				CachingStatus = eCachingStatus.Caching
			};
		}
		if (userId == GameController.Contexts.gameState.user.value.UserId)
		{
			string pngPath = UiHelper.GetSelfAvatarLocalPath();
			if (!File.Exists(pngPath))
			{
				yield return ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.EnsureSelfAvatarExist());
				if (((GObject)this).isDisposed)
				{
					yield break;
				}
			}
			CoroutineWithData cd = new CoroutineWithData((MonoBehaviour)(object)FGUIManager.Instance, HotFix_Utils.getTextureByPath(pngPath));
			yield return cd.Coroutine;
			if (((GObject)this).isDisposed)
			{
				yield break;
			}
			if (cd.Result != null)
			{
				avatarAndName.AvatarTexture = new NTexture((Texture)(Texture2D)cd.Result);
			}
			avatarAndName.Nickname = GameController.Contexts.gameState.user.value.Nickname;
			avatarAndName.CachingStatus = eCachingStatus.Cached;
		}
		else if (userId > 0)
		{
			GameLocalDataManager.UserLocalData userLocalData = GameLocalDataManager.GetSomeUserLocalData(userId);
			if (userLocalData == null)
			{
				yield return ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.EnsurePVPAvatarExist(userId));
				if (((GObject)this).isDisposed)
				{
					yield break;
				}
				userLocalData = GameLocalDataManager.GetSomeUserLocalData(userId);
			}
			CoroutineWithData cd2 = new CoroutineWithData(target: HotFix_Utils.getTextureByPath(UiHelper.GetUserAvatarLocalPath(userId.ToString())), owner: (MonoBehaviour)(object)FGUIManager.Instance);
			yield return cd2.Coroutine;
			if (((GObject)this).isDisposed)
			{
				yield break;
			}
			if (cd2.Result != null)
			{
				avatarAndName.AvatarTexture = new NTexture((Texture)(Texture2D)cd2.Result);
			}
			avatarAndName.Nickname = userLocalData.NickName;
			avatarAndName.CachingStatus = eCachingStatus.Cached;
		}
		AvatarAndNameCachingMap[userId] = avatarAndName;
	}

	private IEnumerator GetPvpUserAvatarAndNameForUiPvpBattleLogInfoResources(int userId, GLoader avatarLoader, GTextField nameTextField)
	{
		if (!AvatarAndNameCachingMap.TryGetValue(userId, out var avatarAndName))
		{
			avatarAndName = new AvatarAndNameCache
			{
				CachingStatus = eCachingStatus.NoCache
			};
			AvatarAndNameCachingMap[userId] = avatarAndName;
		}
		if (avatarAndName.CachingStatus == eCachingStatus.NoCache)
		{
			avatarAndName.CachingStatus = eCachingStatus.Caching;
			yield return ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetPvpUserAvatarAndName(userId));
		}
		int waitingFrameCnt = 0;
		while (avatarAndName.CachingStatus != eCachingStatus.Cached)
		{
			waitingFrameCnt++;
			if (waitingFrameCnt > 600)
			{
				ILRuntimeDebug.LogError($"[RenderPvpBattleLog]Get {userId} UserProfile Timeout, waitingFrameCnt={waitingFrameCnt}");
				yield break;
			}
			yield return null;
			if (((GObject)this).isDisposed || avatarLoader == null || ((GObject)avatarLoader).isDisposed || nameTextField == null || ((GObject)nameTextField).isDisposed)
			{
				yield break;
			}
		}
		if (!((GObject)this).isDisposed && avatarLoader != null && !((GObject)avatarLoader).isDisposed && nameTextField != null && !((GObject)nameTextField).isDisposed)
		{
			avatarLoader.texture = avatarAndName.AvatarTexture;
			((GObject)nameTextField).text = FGUIManager.Instance.TruncateTextLength(avatarAndName.Nickname, 14);
		}
	}
}
