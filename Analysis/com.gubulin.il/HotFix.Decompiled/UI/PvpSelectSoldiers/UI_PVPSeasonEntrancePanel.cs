using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums.Sources;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_PVPSeasonEntrancePanel : GComponent, IUiController
{
	public Controller SeasonType;

	public GLoader background;

	public GButton BackBtn;

	public UI_Title PanelTitle;

	public GComponent MMRScore;

	public GImage n40;

	public GImage n37;

	public UI_eff_TitleSpark n41;

	public GLoader SeasonName;

	public GGroup TitleGroup;

	public GList EntryList;

	public GImage n42;

	public UI_btn_SeasonEntranceFunction SeasonHelp;

	public UI_btn_SeasonEntranceFunction SeasonMission;

	public UI_btn_SeasonEntranceFunction RankStore;

	public Transition t0;

	public const string URL = "ui://82mo10n5y310doj";

	public static string Name = "UI_PVPSeasonEntrancePanel";

	private UI_btn_LadderTournamentEntrance LadderTournamentEntrance;

	private UI_btn_ServerWideConquestEntrance ServerWideConquestEntrance;

	private const int QualifiedRank = 128;

	public static string GetURL()
	{
		return "ui://82mo10n5y310doj";
	}

	public static UI_PVPSeasonEntrancePanel CreateInstance()
	{
		return (UI_PVPSeasonEntrancePanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PVPSeasonEntrancePanel");
	}

	public static UI_PVPSeasonEntrancePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PVPSeasonEntrancePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5y310doj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SeasonType = ((GComponent)this).GetController("SeasonType");
		background = (GLoader)((GComponent)this).GetChild("background");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		PanelTitle = (UI_Title)(object)((GComponent)this).GetChild("PanelTitle");
		MMRScore = (GComponent)((GComponent)this).GetChild("MMRScore");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		n41 = (UI_eff_TitleSpark)(object)((GComponent)this).GetChild("n41");
		SeasonName = (GLoader)((GComponent)this).GetChild("SeasonName");
		TitleGroup = (GGroup)((GComponent)this).GetChild("TitleGroup");
		EntryList = (GList)((GComponent)this).GetChild("EntryList");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		SeasonHelp = (UI_btn_SeasonEntranceFunction)(object)((GComponent)this).GetChild("SeasonHelp");
		SeasonMission = (UI_btn_SeasonEntranceFunction)(object)((GComponent)this).GetChild("SeasonMission");
		RankStore = (UI_btn_SeasonEntranceFunction)(object)((GComponent)this).GetChild("RankStore");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		SetBuildingName();
		EntryList.RemoveChildrenToPool();
		LadderTournamentEntrance = EntryList.AddItemFromPool("ui://82mo10n5r204dot") as UI_btn_LadderTournamentEntrance;
		ServerWideConquestEntrance = EntryList.AddItemFromPool("ui://82mo10n5ooqpdou") as UI_btn_ServerWideConquestEntrance;
		((GObject)LadderTournamentEntrance.LadderTournamentButton).onClick.Set(new EventCallback0(RankDataHelper.OpenPvpEntrance));
		((GObject)ServerWideConquestEntrance.LadderTournamentButton).onClick.Set(new EventCallback0(RankDataHelper.OpenAllServersChampionshipPanel));
		((GObject)ServerWideConquestEntrance.PlayerRankPanel).onClick.Set((EventCallback0)delegate
		{
			CheckMatchResult(forceOpen: true);
		});
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(RenderPvpLadderEntranceCoroutine());
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(RenderAllServersChampionshipEntranceCoroutine());
		RenderPvpToken();
		CheckSeasonMission();
		CheckPvPStore();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		((GObject)SeasonHelp).onClick.Add(new EventCallback1(OpenSeasonHelp));
		((GObject)SeasonMission).onClick.Add(new EventCallback1(OpenSeasonMissionsList));
		((GObject)RankStore).onClick.Add(new EventCallback1(OpenRankStore));
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		SharedMessenger.AddListener<string>("CLOSE_UI", OnAnyUIClosed);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)LadderTournamentEntrance.LadderTournamentButton).onClick.Clear();
		((GObject)ServerWideConquestEntrance.LadderTournamentButton).onClick.Clear();
		((GObject)SeasonHelp).onClick.Clear();
		((GObject)SeasonMission).onClick.Clear();
		((GObject)RankStore).onClick.Clear();
		((GObject)BackBtn).onClick.Clear();
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnAnyUIClosed);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void SetBuildingName()
	{
		((GObject)PanelTitle.buildingName).text = GameManagers.Instance.BuildingManager.GetBuildingByType("18").Name;
		PanelTitle.icon.url = "ui://kt6rg65owl8zv7e";
	}

	private void OpenSeasonHelp(EventContext context)
	{
		UiHelper.OpenHelpPage("全服争霸", "玩法", "斗争圣域赛季说明");
	}

	private void OpenSeasonMissionsList(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PVPSeasonMissionPanel.Name, null);
	}

	private void OpenRankStore(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpStorePanel.Name, null);
	}

	private void RenderPvpToken()
	{
		MMRScore.GetChild("num").text = "0";
		MMRScore.GetChild("addButton").visible = false;
		MMRScore.GetChild("diamond").asLoader.url = "ui://PublicResources/" + RankDataHelper.PvPRankScoreItem;
		UiHelper.NumberTextChangeGTween(0f, RankDataHelper.GetPvPRankScoreItemNum(), MMRScore.GetChild("num").asTextField, 1f, (EaseType)19);
	}

	private IEnumerator RenderPvpLadderEntranceCoroutine()
	{
		if (RankDataHelper.NeedUpdateSeasonInfo())
		{
			yield return RankDataHelper.GetPvpRankSeasonCoroutine();
		}
		((GObject)LadderTournamentEntrance.EventDuration).text = RankDataHelper.RankSeasonInfo.GetDisplayDuration();
		((GObject)LadderTournamentEntrance.WeekCount).text = string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText145"), RankDataHelper.RankStartGameInfo.Turn, LanguagesManager.GetDesc("CsharpCodeZhTcText818"));
		if (RankDataHelper.RankSeasonInfo.Id == -1)
		{
			LadderTournamentEntrance.LadderTournamentState.selectedIndex = 0;
		}
		else
		{
			LadderTournamentEntrance.LadderTournamentState.selectedIndex = 1;
			((GObject)LadderTournamentEntrance.PlayerNoRank).text = "--";
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(RenderMyRankInfoCoroutine());
		}
		yield return null;
	}

	private IEnumerator RenderAllServersChampionshipEntranceCoroutine()
	{
		if (RankDataHelper.NeedUpdateAllServersChampionshipInfo())
		{
			yield return RankDataHelper.GetAllServersChampionshipInfoCoroutine();
		}
		if (RankDataHelper.AllServersChampionshipInfo == null)
		{
			RenderNoAllServersChampionshipInfo();
			yield break;
		}
		RenderPlayerRankState();
		if (RankDataHelper.AllServersChampionshipInfo.IsRoundII())
		{
			ServerWideConquestEntrance.ConquestRound.selectedIndex = 1;
		}
		else
		{
			ServerWideConquestEntrance.ConquestRound.selectedIndex = 0;
		}
		((GObject)ServerWideConquestEntrance.EventDuration).text = RankDataHelper.AllServersChampionshipInfo.GetDisplayDuration();
		((GObject)ServerWideConquestEntrance.StateText).text = RankDataHelper.AllServersChampionshipInfo.GetBattleBeginDescription();
		ServerWideConquestEntrance.HasRewardToGet.selectedIndex = ((!RankDataHelper.AllServersChampionshipInfo.SettlementClaimed && RankDataHelper.AllServersChampionshipInfo.PlayerSettlementInfo != null && RankDataHelper.AllServersChampionshipInfo.PlayerSettlementInfo.FinalRank != int.MinValue) ? 1 : 0);
	}

	private void RenderNoAllServersChampionshipInfo()
	{
		ServerWideConquestEntrance.PlayerRankState.selectedIndex = 0;
		ServerWideConquestEntrance.HasRewardToGet.selectedIndex = 0;
		((GObject)ServerWideConquestEntrance.StateGroup).visible = false;
		((GObject)ServerWideConquestEntrance.LadderTournamentButton).grayed = true;
	}

	private async Task RenderPlayerRankState()
	{
		WarOfRealmInfo championshipInfo = RankDataHelper.AllServersChampionshipInfo;
		if (championshipInfo == null)
		{
			return;
		}
		StageStatus currentStageStatus = championshipInfo.CurrentStageStatus;
		int userId = GameController.Contexts.gameState.user.value.UserId;
		WarRankData selfRankData = championshipInfo.GetPlayerRankDataForCurrentStagePhase(userId);
		if (currentStageStatus == StageStatus.Round1_PreStage || currentStageStatus == StageStatus.Round2_PreStage)
		{
			if (selfRankData == null)
			{
				ServerWideConquestEntrance.PlayerRankState.selectedIndex = 1;
				((GObject)ServerWideConquestEntrance.PlayerRankNumber).text = "--";
				((GObject)ServerWideConquestEntrance.SecondInfoContent).text = "--";
			}
			else
			{
				ServerWideConquestEntrance.PlayerRankState.selectedIndex = ((selfRankData.Rank > 128) ? 1 : 2);
				((GObject)ServerWideConquestEntrance.PlayerRankNumber).text = $"{selfRankData.Rank}";
				((GObject)ServerWideConquestEntrance.SecondInfoContent).text = $"{selfRankData.Score}";
				CheckMatchResult();
			}
			return;
		}
		if (championshipInfo.PlayerSettlementInfo != null && championshipInfo.PlayerSettlementInfo.FinalRank != int.MaxValue)
		{
			ServerWideConquestEntrance.PlayerRankState.selectedIndex = 5;
			((GObject)ServerWideConquestEntrance.PlayerRankNumber).text = $"{championshipInfo.PlayerSettlementInfo.FinalRank}";
			CheckMatchResult();
			return;
		}
		bool participated = false;
		MatchInfo matchInfo = await RankDataHelper.GetMatchGroupInfo(championshipInfo.ActivityId, currentStageStatus);
		if (matchInfo?.WarGroupPlayers != null)
		{
			foreach (List<int> groupPlayers in matchInfo.WarGroupPlayers.Values)
			{
				if (groupPlayers.Contains(userId))
				{
					participated = true;
				}
			}
		}
		if (!participated)
		{
			ServerWideConquestEntrance.PlayerRankState.selectedIndex = 0;
		}
		else if (selfRankData == null)
		{
			foreach (WarRankData rankData in (await RankDataHelper.GetMatchGroupInfo(stageStatus: WarOfRealmInfo.GetPrevStageStatus(currentStageStatus), activityId: championshipInfo.ActivityId)).WarRankDataInfo.WarRankDatas)
			{
				if (rankData.UserId == userId)
				{
					selfRankData = rankData;
					break;
				}
			}
			if (selfRankData != null)
			{
				ServerWideConquestEntrance.PlayerRankState.selectedIndex = 3;
				((GObject)ServerWideConquestEntrance.PlayerRankNumber).text = $"{selfRankData.Rank}";
			}
		}
		else
		{
			ServerWideConquestEntrance.PlayerRankState.selectedIndex = 4;
			((GObject)ServerWideConquestEntrance.PlayerRankNumber).text = $"{selfRankData.Rank}";
			CheckMatchResult();
		}
	}

	private void CheckMatchResult(bool forceOpen = false)
	{
		if (RankDataHelper.AllServersChampionshipInfo == null)
		{
			ILRuntimeDebug.LogError("CheckMatchResult No AllServerChampionship");
		}
		else
		{
			if ((RankDataHelper.AllServersChampionshipInfo.SettlementClaimed && !forceOpen) || (RankDataHelper.AllServerChampionshipRankBonusChecked() && !forceOpen))
			{
				return;
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{
					"Approval",
					RankDataHelper.AllServersChampionshipInfo.Approval
				},
				{
					"Claimed",
					RankDataHelper.AllServersChampionshipInfo.SettlementClaimed
				}
			};
			if (RankDataHelper.AllServersChampionshipInfo.PlayerSettlementInfo?.RItems != null && RankDataHelper.AllServersChampionshipInfo.PlayerSettlementInfo.RItems.Count > 0)
			{
				dictionary["RItems"] = RankDataHelper.AllServersChampionshipInfo.PlayerSettlementInfo.RItems;
				dictionary["Rank"] = RankDataHelper.AllServersChampionshipInfo.PlayerSettlementInfo.FinalRank;
			}
			else if (RankDataHelper.AllServersChampionshipInfo.WarRankDataInfo?.WarRankDatas != null)
			{
				foreach (WarRankData warRankData in RankDataHelper.AllServersChampionshipInfo.WarRankDataInfo.WarRankDatas)
				{
					if (warRankData != null && warRankData.UserId == GameController.Contexts.gameState.user.value.UserId)
					{
						dictionary["Rank"] = warRankData.Rank;
						break;
					}
				}
			}
			StageInfo currentStageInfo = RankDataHelper.AllServersChampionshipInfo.GetCurrentStageInfo();
			if (currentStageInfo != null)
			{
				int serverNowTimestamp = DateTimeHelper.ServerNowTimestamp;
				bool flag = currentStageInfo.IsPreparing(serverNowTimestamp);
				if (dictionary.ContainsKey("Rank") && !flag)
				{
					RankDataHelper.UpdateAllServerChampionshipRankBonusCheckedCache();
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_PVPSeasonMatchResultPanel.Name, dictionary);
				}
			}
		}
	}

	private void CheckSeasonMission()
	{
		((GObject)SeasonMission.note).visible = RankDataHelper.SeasonMissionHasFreeBonusToClaim();
	}

	private void CheckPvPStore()
	{
		((GObject)RankStore.markNew).visible = RankDataHelper.SeasonBetStoreIsNewRefreshed();
	}

	private IEnumerator RenderMyRankInfoCoroutine()
	{
		Task<GetSelfRankResponse> getMyRankTask = GameController.Contexts.Service<INetworkService>().GetSelfRank(-1L);
		while (!getMyRankTask.IsCompleted)
		{
			yield return (object)new WaitForSeconds(0.1f);
		}
		GetSelfRankResponse getMyRankResponse = getMyRankTask.Result;
		if (getMyRankResponse == null || !getMyRankResponse.Result)
		{
			ILRequestHelper.ShowErrorCode(getMyRankResponse?.ErrorCode ?? (-1));
		}
		else
		{
			int myRank = getMyRankResponse.Rank;
			if (myRank > 0)
			{
				LadderTournamentEntrance.LadderTournamentState.selectedIndex = 2;
				int floorIndex = ((myRank % 100 == 0) ? (myRank / 100) : (myRank / 100 + 1));
				((GObject)LadderTournamentEntrance.PlayerRankLevel).text = RankDataHelper.GetPvpRankRangeText(floorIndex) ?? "";
				((GObject)LadderTournamentEntrance.PlayerRankNumber).text = myRank.ToString();
			}
			else
			{
				((GObject)LadderTournamentEntrance.PlayerNoRank).text = LanguagesManager.GetDesc("PlayerNoRankTip");
			}
		}
		Task<GetPvPTopTournamentRankResponse> getTournamentRankTask = GameController.Contexts.Service<INetworkService>().GetPvPTopTournamentRankInfo();
		while (!getTournamentRankTask.IsCompleted)
		{
			yield return (object)new WaitForSeconds(0.1f);
		}
		GetPvPTopTournamentRankResponse getTournamentRankResponse = getTournamentRankTask.Result;
		if (getTournamentRankResponse == null || !getTournamentRankResponse.Result)
		{
			ILRequestHelper.ShowErrorCode(getTournamentRankResponse?.ErrorCode ?? (-1));
			yield break;
		}
		int myTournamentRank = 0;
		if (getTournamentRankResponse.TopTournamentRankListInfo != null)
		{
			int myUserId = GameController.Contexts.gameState.user.value.UserId;
			for (int i = 0; i < getTournamentRankResponse.TopTournamentRankListInfo.Count; i++)
			{
				Dictionary<string, object> _data = getTournamentRankResponse.TopTournamentRankListInfo[i];
				int _userId = (int)_data["UserId"];
				if (_userId == myUserId)
				{
					myTournamentRank = i + 1;
					break;
				}
			}
		}
		((GObject)LadderTournamentEntrance.SecondInfoContent).text = ((myTournamentRank > 0) ? $"{myTournamentRank}" : "--");
	}

	private void OnAnyUIClosed(string panelName)
	{
		if (panelName == UI_PVPSeasonMissionPanel.Name)
		{
			CheckSeasonMission();
		}
		else if (panelName == UI_PvpStorePanel.Name)
		{
			CheckPvPStore();
		}
	}
}
