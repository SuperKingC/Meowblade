using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Scripts.UI.LoadWebImage;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_TopTournamentHistoryRankList : GComponent, IUiController
{
	private class UserPlayOffInfo
	{
		public int UserId { get; set; }

		public List<RankChangeRecord> PlayOffRecords { get; set; }
	}

	public GGraph Mask;

	public UI_TopTournamentHistoryRankListDialog Dialog;

	public const string URL = "ui://82mo10n5zgaedhj";

	public static string Name = "UI_TopTournamentHistoryRankList";

	public static UI_TopTournamentHistoryRankList TopTournamentHistoryRankList;

	private List<GetPvPRankLastTurnResultResponse.TopTournamentRankModel> TopTournamentRankListData = new List<GetPvPRankLastTurnResultResponse.TopTournamentRankModel>();

	private const int FirstRank = 1;

	private const int SecondRank = 2;

	private const int ThirdRank = 3;

	private int myUserId;

	private LoadWebImageTaskQueue loadWebImageTaskQueue;

	private Dictionary<int, string> allBattleLogDayIndex = new Dictionary<int, string>();

	public static string GetURL()
	{
		return "ui://82mo10n5zgaedhj";
	}

	public static UI_TopTournamentHistoryRankList CreateInstance()
	{
		return (UI_TopTournamentHistoryRankList)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TopTournamentHistoryRankList");
	}

	public static UI_TopTournamentHistoryRankList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TopTournamentHistoryRankList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5zgaedhj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_TopTournamentHistoryRankListDialog)(object)((GComponent)this).GetChild("Dialog");
	}

	public void BeforeDestroy()
	{
		TopTournamentHistoryRankList = null;
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		TopTournamentHistoryRankList = this;
		int turnId = DayIndexListInit();
		object value;
		int changeId = (parameters.TryGetValue("ChangeId", out value) ? ((int)value) : (-1));
		RenderHistoryData(turnId, changeId);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private async void RenderHistoryData(int turnId, int changeId = 0)
	{
		IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
		if (changeId == 0)
		{
			changeId = uiService.SetUiNotTouchable(Name);
			uiService.ShowWaitingAnimation(show: true);
		}
		await GetTopTournamentHistoryRankListData(turnId);
		if (changeId <= -1)
		{
			uiService.ShowWaitingAnimation(show: false);
			uiService.ClearUiTouchable();
		}
		else
		{
			uiService.ShowWaitingAnimation(show: false);
			uiService.SetUiTouchable(changeId);
		}
	}

	private async Task GetTopTournamentHistoryRankListData(int turnId)
	{
		if (RankDataHelper.RankSeasonInfo == null)
		{
			Dialog.Type.selectedIndex = 1;
			((GObject)Dialog.tip).text = ((turnId == -1) ? LanguagesManager.GetDesc("CsharpCodeZhTcText510") : LanguagesManager.GetDesc("CsharpCodeZhTcText511"));
			return;
		}
		int originalCurTurnId = ((RankDataHelper.RankSeasonInfo.TurnId < 0) ? (turnId + RankDataHelper.RankSeasonInfo.Id * 10 + 1) : RankDataHelper.RankSeasonInfo.TurnId);
		int currentTurnId = originalCurTurnId - RankDataHelper.RankSeasonInfo.Id * 10;
		bool isFirstTurn = currentTurnId <= 0;
		int lastTurnId = (isFirstTurn ? 3 : (currentTurnId - 1));
		int lastSeasonId = (isFirstTurn ? (RankDataHelper.RankSeasonInfo.Id - 1) : RankDataHelper.RankSeasonInfo.Id);
		Dialog.ScoreRankingList.numItems = 0;
		GetPvPRankLastTurnResultResponse response = await GameController.Contexts.Service<INetworkService>().GetPvPRankLastTurnResult(lastSeasonId, lastTurnId);
		if (!response.Result)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			Dialog.Type.selectedIndex = 1;
			return;
		}
		TopTournamentRankListData = response.Data;
		if (TopTournamentRankListData == null || TopTournamentRankListData.Count <= 0)
		{
			Dialog.Type.selectedIndex = 1;
			return;
		}
		Dialog.Type.selectedIndex = 0;
		RenderRankList();
	}

	private void RenderRankList()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		loadWebImageTaskQueue?.Clear();
		loadWebImageTaskQueue = new LoadWebImageTaskQueue();
		myUserId = GameController.Contexts.gameState.user.value.UserId;
		Dialog.ScoreRankingList.itemRenderer = new ListItemRenderer(RenderScoreRank);
		Dialog.ScoreRankingList.numItems = TopTournamentRankListData.Count;
		loadWebImageTaskQueue?.Start();
	}

	private void RenderScoreRank(int index, GObject obj)
	{
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		UI_TopTournamentUserInfo uI_TopTournamentUserInfo = obj as UI_TopTournamentUserInfo;
		GetPvPRankLastTurnResultResponse.TopTournamentRankModel topTournamentRankModel = TopTournamentRankListData[index];
		int userId = topTournamentRankModel.UserId;
		int score = topTournamentRankModel.Score;
		int maxCombatPower = topTournamentRankModel.MaxCombatPower;
		int playOffScore = topTournamentRankModel.PlayOffScore;
		int num = index + 1;
		switch (num)
		{
		case 1:
			uI_TopTournamentUserInfo.RankType.selectedIndex = 0;
			break;
		case 2:
			uI_TopTournamentUserInfo.RankType.selectedIndex = 1;
			break;
		case 3:
			uI_TopTournamentUserInfo.RankType.selectedIndex = 2;
			break;
		default:
			uI_TopTournamentUserInfo.RankType.selectedIndex = 3;
			uI_TopTournamentUserInfo.Rank.ShowRankLevel(num);
			break;
		}
		uI_TopTournamentUserInfo.SelfType.selectedIndex = ((userId == myUserId) ? 1 : 0);
		bool flag = playOffScore > 0;
		((GObject)uI_TopTournamentUserInfo.CombatPower).text = ((maxCombatPower < 0) ? ("[size=28]" + LanguagesManager.GetDesc("CsharpCodeZhTcText512") + "[/size]") : $"[size=33]{maxCombatPower}[/size]");
		((GObject)uI_TopTournamentUserInfo.TotalScore).text = (flag ? $"{score - playOffScore}[color=#00FF00]+{playOffScore}[/color]" : $"{score}");
		((GObject)uI_TopTournamentUserInfo.Help).visible = flag;
		if (flag)
		{
			UserPlayOffInfo data = new UserPlayOffInfo
			{
				UserId = userId,
				PlayOffRecords = topTournamentRankModel.GetPlayOffRecord()
			};
			((GObject)uI_TopTournamentUserInfo.Help).data = data;
			((GObject)uI_TopTournamentUserInfo.Help).onClick.Set(new EventCallback1(CheckLogDetail));
		}
		uI_TopTournamentUserInfo.HighlyStyle.SetSelectedIndex(1);
		FGUIManager.Instance.GetUserMedal(userId, uI_TopTournamentUserInfo.medalList);
		loadWebImageTaskQueue?.AddTask(((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, userId, uI_TopTournamentUserInfo.Avatar.HeadPortrait.icon, uI_TopTournamentUserInfo.UserName)));
	}

	private void CheckLogDetail(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		if (data != null && data is UserPlayOffInfo userPlayOffInfo && userPlayOffInfo.PlayOffRecords.Count > 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpBattleLogPanel.Name, new Dictionary<string, object>
			{
				{ "CurrentUserId", userPlayOffInfo.UserId },
				{ "TopTournamentDayIndex", 0 },
				{ "LastTurnRankChangeRecord", userPlayOffInfo.PlayOffRecords }
			});
		}
	}

	public int DayIndexListInit()
	{
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		RankDataHelper.GetCurrentSeasonIs(isBattleEnd: true, out var turns);
		for (int i = 0; i < turns.Count; i++)
		{
			allBattleLogDayIndex.Add(turns[i].Turn - 1, string.Format("（{0}{1}{2}）", LanguagesManager.GetDesc("CsharpCodeZhTcText145"), turns[i].Turn, LanguagesManager.GetDesc("CsharpCodeZhTcText503")));
		}
		if (turns.Count <= 0 || allBattleLogDayIndex == null || allBattleLogDayIndex.Count <= 0)
		{
			return -1;
		}
		int num = (int)GameController.Instance.GetServerTime();
		int endAtTimestamp = turns[turns.Count - 1].EndAtTimestamp;
		if (num <= endAtTimestamp)
		{
			return 0;
		}
		KeyValuePair<int, string> keyValuePair = allBattleLogDayIndex.ToList()[allBattleLogDayIndex.Count - 1];
		Dialog.DayIndexList.Type.selectedIndex = 0;
		((GObject)Dialog.DayIndexList.CurrentDay).text = "(" + RankDataHelper.RankSeasonInfo.GetDisplayName() + "-" + keyValuePair.Value + ")";
		((GObject)Dialog.DayIndexList).onClick.Set(new EventCallback0(ShowAllDayTitle));
		RenderAllDayTitle();
		return keyValuePair.Key;
	}

	private void RenderAllDayTitle()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		Dialog.DayIndexList.DayIndexList.itemRenderer = new ListItemRenderer(RenderDayTitle);
		Dialog.DayIndexList.DayIndexList.numItems = allBattleLogDayIndex.Count;
		Dialog.DayIndexList.DayIndexList.ResizeToFit(allBattleLogDayIndex.Count);
	}

	private void RenderDayTitle(int index, GObject obj)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		if (obj is UI_TopTournamentDayTitleItem uI_TopTournamentDayTitleItem)
		{
			KeyValuePair<int, string> keyValuePair = allBattleLogDayIndex.ToList()[index];
			((GObject)uI_TopTournamentDayTitleItem.CurrentDay).text = keyValuePair.Value;
			((GObject)uI_TopTournamentDayTitleItem).data = index;
			((GObject)uI_TopTournamentDayTitleItem).onClick.Set(new EventCallback1(SelectCheckOneDayLog));
		}
	}

	private void ShowAllDayTitle()
	{
		Dialog.DayIndexList.Type.selectedIndex = ((Dialog.DayIndexList.Type.selectedIndex == 0) ? 1 : 0);
	}

	private void SelectCheckOneDayLog(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		if (data != null)
		{
			KeyValuePair<int, string> keyValuePair = allBattleLogDayIndex.ToList()[(int)data];
			((GObject)Dialog.DayIndexList.CurrentDay).text = keyValuePair.Value;
			RenderHistoryData(keyValuePair.Key);
		}
	}
}
