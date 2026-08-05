using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_MyRank : GComponent
{
	public GImage n8;

	public GTextField MyRank;

	public UI_LevelDiy RankLevel;

	public UI_DevilsIconBtn Icon;

	public GTextField n28;

	public GTextField n29;

	public GTextField LegionCombatPower;

	public GTextField ScoreIncome;

	public GImage n16;

	public GImage n18;

	public UI_RefreshCardBtn RefreshRankList;

	public UI_WarReport Report;

	public UI_IdleBonus IdleBonus;

	public UI_btn_GeneralFunctionSmall SeasonMission;

	public UI_btn_GeneralFunctionSmall RankStore;

	public UI_RewardPreview RewardPreview;

	public GTextField n27;

	public Transition RankUp;

	public const string URL = "ui://82mo10n5js4q6t";

	public static string Name = "UI_MyRank";

	private int myRank;

	private RankSummary myRankSummary;

	private const int rankSize = 10;

	private const string ScoreColor = "#4bff3c";

	private List<RankSummary> challengeSummaries = new List<RankSummary>();

	private string PreparePos => LanguagesManager.GetDesc("CsharpCodeZhTcText455");

	public static string GetURL()
	{
		return "ui://82mo10n5js4q6t";
	}

	public static UI_MyRank CreateInstance()
	{
		return (UI_MyRank)(object)UIPackage.CreateObject("PvpSelectSoldiers", "MyRank");
	}

	public static UI_MyRank CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MyRank).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5js4q6t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n8 = (GImage)((GComponent)this).GetChild("n8");
		MyRank = (GTextField)((GComponent)this).GetChild("MyRank");
		RankLevel = (UI_LevelDiy)(object)((GComponent)this).GetChild("RankLevel");
		Icon = (UI_DevilsIconBtn)(object)((GComponent)this).GetChild("Icon");
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id = "ui://82mo10n5js4q6t".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id);
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id2 = "ui://82mo10n5js4q6t".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id2);
		LegionCombatPower = (GTextField)((GComponent)this).GetChild("LegionCombatPower");
		ScoreIncome = (GTextField)((GComponent)this).GetChild("ScoreIncome");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		RefreshRankList = (UI_RefreshCardBtn)(object)((GComponent)this).GetChild("RefreshRankList");
		Report = (UI_WarReport)(object)((GComponent)this).GetChild("Report");
		IdleBonus = (UI_IdleBonus)(object)((GComponent)this).GetChild("IdleBonus");
		SeasonMission = (UI_btn_GeneralFunctionSmall)(object)((GComponent)this).GetChild("SeasonMission");
		RankStore = (UI_btn_GeneralFunctionSmall)(object)((GComponent)this).GetChild("RankStore");
		RewardPreview = (UI_RewardPreview)(object)((GComponent)this).GetChild("RewardPreview");
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id3 = "ui://82mo10n5js4q6t".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id3);
		RankUp = ((GComponent)this).GetTransition("RankUp");
	}

	public async Task<ChallengeData> Init()
	{
		((GObject)Report).onClick.Set(new EventCallback1(ReportClickEvent));
		((GObject)RefreshRankList).onClick.Set(new EventCallback1(RefreshClickEvent));
		((GObject)RewardPreview).onClick.Set(new EventCallback1(RewardPreviewClickEvent));
		((GObject)IdleBonus).onClick.Set(new EventCallback0(GetIdleBonus));
		((GObject)RankStore).onClick.Set(new EventCallback0(OpenRankStore));
		await GetMyRank();
		await GetMyRankSummary();
		RenderMyRankInfo();
		return new ChallengeData(myRank, challengeSummaries);
	}

	public async Task<ChallengeData> Update()
	{
		await GetMyRankSummary();
		return new ChallengeData(myRank, challengeSummaries);
	}

	private void RenderMyRankInfo()
	{
		if (!((GObject)this).isDisposed)
		{
			((GObject)MyRank).text = ((myRank < 1 || myRank > 800) ? PreparePos : GetUserGradeText(myRank));
			int num = ((myRank >= 1 && myRank <= 800) ? myRank : 0);
			if (((GObject)MyRank).text == PreparePos)
			{
				((GObject)RankLevel).visible = false;
			}
			else
			{
				((GObject)RankLevel).visible = true;
				RankLevel.ShowRankLevel(num);
			}
			if (!RankDataHelper.LastBattleRankUp)
			{
				((GObject)RankLevel).alpha = 1f;
			}
			((GObject)LegionCombatPower).text = $"{LegionHelper.GetPlayerMaxPossibleCombatPower(GameManagers.Instance)}";
			int? num2 = RankDataHelper.GetRankScoreReward(num)?.ToList()?[0].Value;
			((GObject)ScoreIncome).text = (RankDataHelper.LastBattleRankUp ? string.Format("[color={0}]+{1}[/color]/{2}", "#4bff3c", RankDataHelper.LastRankScore, LanguagesManager.GetDesc("CsharpCodeZhTcText248")) : string.Format("[color={0}]+{1}[/color]/{2}", "#4bff3c", num2, LanguagesManager.GetDesc("CsharpCodeZhTcText248")));
			((GObject)ScoreIncome).data = num2;
		}
	}

	private string GetUserGradeText(int rank)
	{
		int rangeIndex = ((rank % 100 == 0) ? (rank / 100) : (rank / 100 + 1));
		return RankDataHelper.GetPvpRankRangeText(rangeIndex) ?? "";
	}

	private void RewardPreviewClickEvent(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_Rank_RewardPanel.Name, null);
	}

	private void ReportClickEvent(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpBattleLogPanel.Name, null);
	}

	private void RefreshClickEvent(EventContext context)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		((GObject)RefreshRankList).enabled = false;
		UI_LadderTournamentPanel.LadderTournamentPanel?.ManualRefresh();
		((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
		{
			((GObject)RefreshRankList).enabled = true;
		});
	}

	private void OpenRankStore()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpStorePanel.Name, null);
	}

	private async Task GetMyRank()
	{
		myRank = 0;
		GetSelfRankResponse response = await GameController.Contexts.Service<INetworkService>().GetSelfRank(-1L);
		if (response.Result)
		{
			myRank = response.Rank;
		}
		else
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
		}
	}

	private void GetIdleBonus()
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		if (!IdleBonus.CanGetBonus())
		{
			return;
		}
		Vector2 startPos = ((GObject)IdleBonus).LocalToGlobal(new Vector2(((GObject)IdleBonus).width / 2f, ((GObject)IdleBonus).height / 2f));
		GComponent mMRScore = UI_LadderTournamentPanel.LadderTournamentPanel.MMRScore;
		Vector2 endPos = ((GObject)mMRScore).LocalToGlobal(new Vector2(((GObject)mMRScore).width / 2f, ((GObject)mMRScore).height / 2f));
		Action action = delegate
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Expected O, but got Unknown
			if (!((GObject)IdleBonus).isDisposed)
			{
				IdleBonus.UpdateIdleBoxState();
				UnityUiService.Instance.ShowGetBonusItemSfx(startPos, endPos);
				((GComponent)(object)this).SetTimeout(0.5f).OnComplete(new GTweenCallback(UpdateMMRScore));
			}
		};
		RankDataHelper.GetIdleBonus(action);
	}

	private async Task GetMyRankSummary()
	{
		int fromRank = ((myRank < 1 || myRank > 800) ? 801 : myRank);
		GetRankListResponse response = await GameController.Contexts.Service<INetworkService>().GetRankList();
		if (response.Result)
		{
			RankDataHelper.UpdateUnlockedBlocksInfo(response.UnlockedBlocks, response.UnlockNextBlockProgress);
			UI_PvpBattleVictory.lastRank = fromRank;
			challengeSummaries = response.RankSummaryList;
			challengeSummaries?.Reverse();
			RankDataHelper.UpdatePvpRankProgressScore(response.SelfScore);
			UpdateMMRScore();
			IdleBonus.UpdateIdleBoxState();
			RankDataHelper.IsInTopTournament = response.IsInTopTournament;
			UI_LadderTournamentPanel.LadderTournamentPanel.FirstThree.SetPeakBattleState();
		}
		else
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
		}
	}

	private void UpdateMMRScore()
	{
		if (((GObject)this).isDisposed || UI_LadderTournamentPanel.LadderTournamentPanel == null || ((GObject)UI_LadderTournamentPanel.LadderTournamentPanel).isDisposed)
		{
			return;
		}
		GTextField asTextField = UI_LadderTournamentPanel.LadderTournamentPanel.MMRScore.GetChild("num").asTextField;
		if (asTextField != null && !((GObject)asTextField).isDisposed)
		{
			if (((GObject)asTextField).data == null)
			{
				((GObject)asTextField).data = 0;
			}
			int num = (int)((GObject)asTextField).data;
			UiHelper.NumberTextChangeGTween(num, RankDataHelper.GetPvPRankScoreItemNum(), asTextField, 1f, (EaseType)19);
			((GObject)asTextField).data = RankDataHelper.GetPvPRankScoreItemNum();
		}
	}
}
