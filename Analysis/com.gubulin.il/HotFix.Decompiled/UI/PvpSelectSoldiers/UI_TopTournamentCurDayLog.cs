using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Scripts.UI.LoadWebImage;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums.Sources;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using UI.PublicResources;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_TopTournamentCurDayLog : GComponent
{
	public Controller Type;

	public Controller ColorType;

	public Controller isServerWideOpen;

	public GImage n73;

	public GImage n59;

	public GTextField CurrentDay;

	public GGraph n61;

	public GList BattleLogList;

	public GImage n68;

	public UI_DayBattleLog DayBattleLog;

	public GImage n64;

	public GTextField WinningPercentage;

	public GGroup n70;

	public GImage n65;

	public GTextField Score;

	public GLoader Help;

	public GGroup n71;

	public GTextField tip;

	public const string URL = "ui://82mo10n5aveldgk";

	public static string Name = "UI_TopTournamentCurDayLog";

	private const int MaxShowLogNum = 7;

	private int myUserId;

	private LoadWebImageTaskQueue loadWebImageTaskQueue;

	private int currentDayIndex;

	private Dictionary<string, List<Dictionary<string, object>>> TodayBattleLogData = new Dictionary<string, List<Dictionary<string, object>>>();

	private List<Dictionary<string, object>> showBattleLogData = new List<Dictionary<string, object>>();

	public static string GetURL()
	{
		return "ui://82mo10n5aveldgk";
	}

	public static UI_TopTournamentCurDayLog CreateInstance()
	{
		return (UI_TopTournamentCurDayLog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TopTournamentCurDayLog");
	}

	public static UI_TopTournamentCurDayLog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TopTournamentCurDayLog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5aveldgk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		ColorType = ((GComponent)this).GetController("ColorType");
		isServerWideOpen = ((GComponent)this).GetController("isServerWideOpen");
		n73 = (GImage)((GComponent)this).GetChild("n73");
		n59 = (GImage)((GComponent)this).GetChild("n59");
		CurrentDay = (GTextField)((GComponent)this).GetChild("CurrentDay");
		n61 = (GGraph)((GComponent)this).GetChild("n61");
		BattleLogList = (GList)((GComponent)this).GetChild("BattleLogList");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		DayBattleLog = (UI_DayBattleLog)(object)((GComponent)this).GetChild("DayBattleLog");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		WinningPercentage = (GTextField)((GComponent)this).GetChild("WinningPercentage");
		n70 = (GGroup)((GComponent)this).GetChild("n70");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		Score = (GTextField)((GComponent)this).GetChild("Score");
		Help = (GLoader)((GComponent)this).GetChild("Help");
		n71 = (GGroup)((GComponent)this).GetChild("n71");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://82mo10n5aveldgk".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
	}

	public async Task Init()
	{
		((GObject)DayBattleLog).onClick.Set(new EventCallback0(OpenBattleLogDialog));
		await GetPvPTopTournamentRecordData();
		SetupHelpButton();
	}

	private async Task GetPvPTopTournamentRecordData()
	{
		Dictionary<int, string> _dayIndexData = RankDataHelper.GetTopTournamentLogDayIndex();
		if (_dayIndexData == null || _dayIndexData.Count <= 0)
		{
			RenderLastTurnTournamentRecord();
			return;
		}
		KeyValuePair<int, string> _recentData = _dayIndexData.ToList()[_dayIndexData.Count - 1];
		((GObject)DayBattleLog.CurrentDate).text = _recentData.Value;
		currentDayIndex = _recentData.Key;
		((GObject)CurrentDay).text = _recentData.Value;
		((GObject)DayBattleLog).enabled = true;
		RenderCurrentTurnTopTournamentRecord();
	}

	private async void RenderLastTurnTournamentRecord()
	{
		List<RankDataHelper.tRankStartGame> turns;
		int turnState = RankDataHelper.GetCurrentSeasonIs(isBattleEnd: false, out turns);
		((GObject)tip).visible = true;
		if (turns.Count <= 0 && turnState != 0)
		{
			((GObject)DayBattleLog).enabled = false;
			return;
		}
		GetPvPRankLastTurnLastDayResultResponse response = await GameController.Contexts.Service<INetworkService>().GetPvPRankLastTurnLastDayResult();
		if (!response.Result)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			((GObject)DayBattleLog).enabled = false;
			return;
		}
		TodayBattleLogData = response.BattleLogData;
		if (TodayBattleLogData == null || TodayBattleLogData.Count <= 0)
		{
			((GObject)DayBattleLog).enabled = false;
			return;
		}
		((GObject)tip).visible = false;
		((GObject)DayBattleLog).enabled = true;
		((GObject)DayBattleLog.CurrentDate).text = RankDataHelper.GetLastTurnLastDayTitle();
		currentDayIndex = 0;
		((GObject)CurrentDay).text = ((GObject)DayBattleLog.CurrentDate).text;
		KeyValuePair<string, List<Dictionary<string, object>>> _mvpData = TodayBattleLogData.ToList()[0];
		showBattleLogData = _mvpData.Value;
		SetTypeSelectIndex(NumericParser.Float(_mvpData.Key));
		((GObject)Score).text = string.Format("+{0}", showBattleLogData[0]["Score"]);
		RenderLogList();
	}

	private async void RenderCurrentTurnTopTournamentRecord()
	{
		GetPvPTopTournamentRecordResponse response = await GameController.Contexts.Service<INetworkService>().GetPvPTopTournamentRecord(currentDayIndex);
		if (!response.Result)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			((GObject)tip).visible = true;
			return;
		}
		TodayBattleLogData = response.BattleLogData;
		if (TodayBattleLogData == null || TodayBattleLogData.Count <= 0)
		{
			((GObject)tip).visible = true;
			return;
		}
		KeyValuePair<string, List<Dictionary<string, object>>> _mvpData = TodayBattleLogData.ToList()[0];
		showBattleLogData = _mvpData.Value;
		SetTypeSelectIndex(NumericParser.Float(_mvpData.Key));
		((GObject)Score).text = string.Format("+{0}", showBattleLogData[0]["Score"]);
		RenderLogList();
	}

	private void SetTypeSelectIndex(float winningPercentage)
	{
		((GObject)WinningPercentage).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint((winningPercentage * 100f).ToString("N1")) + "%";
		if (winningPercentage >= 1f)
		{
			ColorType.selectedIndex = 0;
		}
		else if (winningPercentage >= 0.8f)
		{
			ColorType.selectedIndex = 1;
		}
		else
		{
			ColorType.selectedIndex = 2;
		}
	}

	private void RenderLogList()
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		loadWebImageTaskQueue?.Clear();
		loadWebImageTaskQueue = new LoadWebImageTaskQueue();
		myUserId = GameController.Contexts.gameState.user.value.UserId;
		int numItems = ((showBattleLogData.Count > 7) ? 7 : showBattleLogData.Count);
		BattleLogList.itemRenderer = new ListItemRenderer(RenderLogDetail);
		BattleLogList.numItems = numItems;
		loadWebImageTaskQueue?.Start();
		if (showBattleLogData.Count > 7)
		{
			Type.selectedIndex = 1;
		}
		else
		{
			Type.selectedIndex = 0;
		}
	}

	private void RenderLogDetail(int index, GObject obj)
	{
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		if (!((GObject)this).isDisposed && !((GObject)BattleLogList).isDisposed && obj is UI_TopTournamentLogTitle uI_TopTournamentLogTitle)
		{
			Dictionary<string, object> dictionary = showBattleLogData[index];
			int num = (int)dictionary["UserId"];
			uI_TopTournamentLogTitle.Type.selectedIndex = ((num == myUserId) ? 1 : 0);
			loadWebImageTaskQueue?.AddTask(((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, num, uI_TopTournamentLogTitle.Avatar.HeadPortrait.icon, uI_TopTournamentLogTitle.UserName)));
			FGUIManager.Instance.GetUserMedal(num, uI_TopTournamentLogTitle.medalList, uI_TopTournamentLogTitle.isShowMedal);
			((GObject)uI_TopTournamentLogTitle).data = num;
			((GObject)uI_TopTournamentLogTitle).onClick.Set(new EventCallback1(CheckLogDetail));
		}
	}

	private void OpenBattleLogDialog()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_TopTournamentEveryDayLogPanel.Name, null);
	}

	private async void CheckLogDetail(EventContext context)
	{
		object _clickData = ((GObject)context.sender).data;
		if (_clickData != null)
		{
			if (currentDayIndex != 0)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpBattleLogPanel.Name, new Dictionary<string, object>
				{
					{
						"CurrentUserId",
						(int)_clickData
					},
					{ "TopTournamentDayIndex", currentDayIndex }
				});
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpBattleLogPanel.Name, new Dictionary<string, object>
				{
					{
						"CurrentUserId",
						(int)_clickData
					},
					{ "TopTournamentDayIndex", currentDayIndex },
					{ "LastTurnRankChangeRecord", null }
				});
			}
		}
	}

	private void SetupHelpButton()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		bool flag = ShouldShowServerWideHelp();
		isServerWideOpen.selectedIndex = (flag ? 1 : 0);
		if (flag)
		{
			((GObject)Help).onClick.Set(new EventCallback1(OnHelpBtnClick));
		}
	}

	private bool ShouldShowServerWideHelp()
	{
		if (!RankDataHelper.IsServerWideBattle)
		{
			return false;
		}
		WarOfRealmInfo allServersChampionshipInfo = RankDataHelper.AllServersChampionshipInfo;
		if (allServersChampionshipInfo == null)
		{
			return false;
		}
		StageStatus currentStageStatus = allServersChampionshipInfo.CurrentStageStatus;
		if (currentStageStatus == StageStatus.Unknown)
		{
			return false;
		}
		int num = (int)currentStageStatus;
		StageStatus status;
		if (num >= 1 && num <= 9)
		{
			status = StageStatus.Round1_PreStage;
		}
		else
		{
			if (num < 10 || num > 18)
			{
				return false;
			}
			status = StageStatus.Round2_PreStage;
		}
		StageInfo stageInfo = allServersChampionshipInfo.GetStageInfo(status);
		if (stageInfo == null)
		{
			return false;
		}
		int serverNowTimestamp = DateTimeHelper.ServerNowTimestamp;
		if (serverNowTimestamp < stageInfo.BeginTime)
		{
			return false;
		}
		DateTimeOffset dateTimeOffset = DateTimeHelper.Parse(stageInfo.EndTime).ToOffset(DateTimeHelper.TimezoneOffset);
		DateTimeOffset dateTimeOffset2 = new DateTimeOffset(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, 12, 0, 0, DateTimeHelper.TimezoneOffset).AddDays(1.0);
		int timeStamp = DateTimeHelper.GetTimeStamp(dateTimeOffset2);
		return serverNowTimestamp < timeStamp;
	}

	private void OnHelpBtnClick(EventContext context)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject target = (GObject)context.sender;
		bool flag = IsCurrentDayWeekend();
		string langKey = (flag ? "AllServersChampionshipScoreHelpTip2" : "AllServersChampionshipScoreHelpTip1");
		FairyGUITip.ShowTip(target, eFairyGUITipDir.Down, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = LanguagesManager.GetDesc(langKey);
		}, default(Rect), lastSetXy: true);
	}

	private bool IsCurrentDayWeekend()
	{
		long serverTime = GameController.Instance.GetServerTime();
		DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp((int)serverTime).ToOffset(DateTimeHelper.TimezoneOffset);
		return (dateTimeOffset.DayOfWeek == DayOfWeek.Sunday && dateTimeOffset.Hour >= 12) || dateTimeOffset.DayOfWeek == DayOfWeek.Monday || (dateTimeOffset.DayOfWeek == DayOfWeek.Tuesday && dateTimeOffset.Hour < 12);
	}
}
