using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_LadderTournamentPanel : GComponent, IUiController
{
	public GLoader background;

	public GButton BackBtn;

	public GImage n12;

	public GGroup backRight;

	public UI_Title PanelTitle;

	public GComponent CompetitionSeasonScore;

	public GComponent MMRScore;

	public UI_AttackStrengthen AttackStrengthen;

	public UI_DefenseTime DefenseTime;

	public UI_FirstThree FirstThree;

	public UI_PlayersRank PlayersRanks;

	public UI_MyRank MyRank;

	public UI_ReadMore ReadMore;

	public UI_HelpBtn HelpBtn;

	public const string URL = "ui://82mo10n5js4q6q";

	public static string Name = "UI_LadderTournamentPanel";

	public static UI_LadderTournamentPanel LadderTournamentPanel;

	private bool panelUpdating;

	private int updatePanelInterval = 0;

	public Coroutine updatePanelCoroutine;

	private Coroutine UpdateTextPerSecCoroutine;

	private string PanelName => LanguagesManager.GetDesc("CsharpCodeZhTcText454");

	public static string GetURL()
	{
		return "ui://82mo10n5js4q6q";
	}

	public static UI_LadderTournamentPanel CreateInstance()
	{
		return (UI_LadderTournamentPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "LadderTournamentPanel");
	}

	public static UI_LadderTournamentPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LadderTournamentPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5js4q6q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		backRight = (GGroup)((GComponent)this).GetChild("backRight");
		PanelTitle = (UI_Title)(object)((GComponent)this).GetChild("PanelTitle");
		CompetitionSeasonScore = (GComponent)((GComponent)this).GetChild("CompetitionSeasonScore");
		MMRScore = (GComponent)((GComponent)this).GetChild("MMRScore");
		AttackStrengthen = (UI_AttackStrengthen)(object)((GComponent)this).GetChild("AttackStrengthen");
		DefenseTime = (UI_DefenseTime)(object)((GComponent)this).GetChild("DefenseTime");
		FirstThree = (UI_FirstThree)(object)((GComponent)this).GetChild("FirstThree");
		PlayersRanks = (UI_PlayersRank)(object)((GComponent)this).GetChild("PlayersRanks");
		MyRank = (UI_MyRank)(object)((GComponent)this).GetChild("MyRank");
		ReadMore = (UI_ReadMore)(object)((GComponent)this).GetChild("ReadMore");
		HelpBtn = (UI_HelpBtn)(object)((GComponent)this).GetChild("HelpBtn");
	}

	public void BeforeDestroy()
	{
		if (updatePanelCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(updatePanelCoroutine);
		}
		if (UpdateTextPerSecCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(UpdateTextPerSecCoroutine);
		}
		LadderTournamentPanel = null;
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(UI_PlayersRank.Name);
		FGUIManager.Instance.ReleaseGloaderTexture2D(UI_FirstThree.Name);
	}

	private void OpenHistoryRankList(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_TopTournamentHistoryRankList.Name, null);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		LadderTournamentPanel = this;
		PanelTitle.SetBuildingName(PanelName);
		MMRScore.GetChild("num").text = "0";
		InitPanel();
		GetRankProgress();
		CheckSeasonMission();
		CheckPvPStore();
	}

	public void OnShow()
	{
		updatePanelCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdatePanelTiming());
		UpdateTextPerSecCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateTextPerSec());
		MMRScore.GetChild("addButton").visible = false;
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
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		((GObject)DefenseTime).onClick.Add(new EventCallback1(DefenseTimeClickEvent));
		((GObject)AttackStrengthen).onClick.Add(new EventCallback1(AttackStrengthenClickEvent));
		((GObject)ReadMore).onClick.Add(new EventCallback1(ReadMoreClickEvent));
		((GObject)HelpBtn).onClick.Set(new EventCallback0(OnClickHelpBtn));
		((GObject)MyRank.SeasonMission).onClick.Set(new EventCallback0(OnClickSeasonMissions));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<string>("CLOSE_UI", OnAnyUIClosed);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Remove(new EventCallback0(End));
		((GObject)DefenseTime).onClick.Remove(new EventCallback1(DefenseTimeClickEvent));
		((GObject)AttackStrengthen).onClick.Remove(new EventCallback1(AttackStrengthenClickEvent));
		((GObject)ReadMore).onClick.Remove(new EventCallback1(ReadMoreClickEvent));
		((GObject)HelpBtn).onClick.Clear();
		((GObject)MyRank.SeasonMission).onClick.Clear();
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnAnyUIClosed);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (itemId == RankDataHelper.PvPRankScoreItem)
		{
			MMRScore.GetChild("num").text = $"{RankDataHelper.GetPvPRankScoreItemNum()}";
		}
	}

	private async void InitPanel()
	{
		((GObject)MyRank.RankLevel).alpha = 0f;
		if (RankDataHelper.LastBattleRankUp)
		{
			((GObject)MyRank.MyRank).alpha = 0f;
		}
		if (!panelUpdating)
		{
			panelUpdating = true;
			IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
			int changeId = uiService.SetUiNotTouchable(Name);
			uiService.ShowWaitingAnimation(show: true);
			await RankDataHelper.GetTopBattleFormations();
			await FirstThree.Init();
			ChallengeData challengeData = await MyRank.Init();
			PlayersRanks.Init(challengeData.AimRankSummaries, challengeData.MyRank);
			AttackStrengthen.UpdateBuffNum();
			uiService.ShowWaitingAnimation(show: false);
			uiService.SetUiTouchable(changeId);
			LastBattleRankUp();
			PlayUnlockPeakBattleQualification();
			if (!RankDataHelper.IsServerWideBattle)
			{
				((GObject)MyRank.SeasonMission).visible = false;
				((GObject)MyRank.RankStore).x = 1181f;
			}
			panelUpdating = false;
		}
	}

	public async void UpdatePanel()
	{
		((GObject)MyRank.RankLevel).alpha = 0f;
		if (RankDataHelper.LastBattleRankUp)
		{
			((GObject)MyRank.MyRank).alpha = 0f;
		}
		if (!panelUpdating)
		{
			panelUpdating = true;
			IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
			int changeId = uiService.SetUiNotTouchable(Name);
			uiService.ShowWaitingAnimation(show: true);
			await RankDataHelper.GetTopBattleFormations();
			ChallengeData challengeData = await MyRank.Init();
			PlayersRanks.Init(challengeData.AimRankSummaries, challengeData.MyRank);
			AttackStrengthen.UpdateBuffNum();
			LastBattleRankUp();
			PlayUnlockPeakBattleQualification();
			uiService.ShowWaitingAnimation(show: false);
			uiService.SetUiTouchable(changeId);
			panelUpdating = false;
		}
	}

	public async void ManualRefresh()
	{
		if (!panelUpdating)
		{
			panelUpdating = true;
			await RankDataHelper.GetTopBattleFormations();
			ChallengeData challengeData = await MyRank.Update();
			PlayersRanks.Update(challengeData.AimRankSummaries, challengeData.MyRank);
			panelUpdating = false;
		}
	}

	private IEnumerator UpdateTiming()
	{
		while (true)
		{
			yield return (object)new WaitForSeconds(300f);
			UpdatePanel();
		}
	}

	private IEnumerator UpdatePanelTiming()
	{
		while (true)
		{
			if (!GameController.Contexts.Service<IUiService>().HasShowingUi(UI_PvpSelectSoldiersPanel.Name) && !GameController.Contexts.Service<IUiService>().HasShowingUi(UI_PvPBattleResultAnimationEffect.Name) && !GameController.Contexts.Service<IUiService>().HasShowingUi(UI_PvpBattleVictory.Name))
			{
				updatePanelInterval++;
			}
			yield return (object)new WaitForSeconds(1f);
			if (updatePanelInterval >= 300)
			{
				updatePanelInterval = 0;
				UpdatePanel();
			}
		}
	}

	private void PlayUnlockPeakBattleQualification()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		if (RankDataHelper.NeedPlayPeakBattleUnlockEffect())
		{
			((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_UnlockPeakBattle.Name, null);
				FirstThree.Type.selectedIndex = 1;
				GameLocalDataManager.SetUnlockPeakBattleTurnId(RankDataHelper.RankSeasonInfo.TurnId.ToString());
			});
		}
	}

	private void LastBattleRankUp()
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		if (!RankDataHelper.LastBattleRankUp)
		{
			return;
		}
		RankDataHelper.LastBattleRankUp = false;
		float x = 1296f;
		for (int i = 0; i < PlayersRanks.PlayersArmys.numItems; i++)
		{
			((GComponent)PlayersRanks.PlayersArmys).GetChildAt(i).alpha = 0f;
			((GComponent)PlayersRanks.PlayersArmys).GetChildAt(i).x = x;
		}
		MyRank.RankUp.Play();
		if (((GObject)MyRank.ScoreIncome).data != null)
		{
			((GComponent)(object)this).SetTimeout(0.7f).OnComplete((GTweenCallback)delegate
			{
				//IL_0059: Unknown result type (might be due to invalid IL or missing references)
				//IL_0063: Expected O, but got Unknown
				//IL_006a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0074: Expected O, but got Unknown
				if (!((GObject)this).isDisposed)
				{
					int _curScore = (int)((GObject)MyRank.ScoreIncome).data;
					GTween.To((float)RankDataHelper.LastRankScore, (float)_curScore, 0.8f).SetEase((EaseType)0).OnUpdate((GTweenCallback1)delegate(GTweener tweener)
					{
						if (!((GObject)MyRank).isDisposed)
						{
							((GObject)MyRank.ScoreIncome).text = string.Format("[color=#9cf240]+{0}[/color]/{1}", Convert.ToInt32(Mathf.Floor(tweener.value.x)), LanguagesManager.GetDesc("CsharpCodeZhTcText248"));
						}
					})
						.OnComplete((GTweenCallback)delegate
						{
							if (!((GObject)MyRank).isDisposed)
							{
								((GObject)MyRank.ScoreIncome).text = string.Format("[color=#9cf240]+{0}[/color]/{1}", _curScore, LanguagesManager.GetDesc("CsharpCodeZhTcText248"));
							}
						});
				}
			});
		}
		((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
		{
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			if (!((GObject)PlayersRanks).isDisposed)
			{
				float num = 0.2f;
				for (int j = 0; j < PlayersRanks.PlayersArmys.numItems; j++)
				{
					int index = j;
					((GComponent)(object)PlayersRanks.PlayersArmys).SetTimeout(num).OnComplete((GTweenCallback)delegate
					{
						if (index < PlayersRanks.PlayersArmys.numItems)
						{
							GObject childAt = ((GComponent)PlayersRanks.PlayersArmys).GetChildAt(index);
							childAt.TweenFade(1f, 0.33f);
							childAt.TweenMoveX(0f, 0.33f);
						}
					});
					num += 0.2f;
				}
			}
		});
	}

	private void OnClickSeasonMissions()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PVPSeasonMissionPanel.Name, null);
	}

	private async void OnClickHelpBtn()
	{
		UiHelper.OpenHelpPage("游戏帮助界面", "玩法", "天梯排位赛");
	}

	private void DefenseTimeClickEvent(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_AddRankDefenseBuffDialog.Name, null);
	}

	private void AttackStrengthenClickEvent(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_AddRankAttackBuffDialog.Name, null);
	}

	private void ReadMoreClickEvent(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpTotalRankListPanel.Name, null);
	}

	private IEnumerator UpdateTextPerSec()
	{
		yield return (object)new WaitForSeconds(1f);
		DefenseTime.UpdateText();
		UpdateTextPerSecCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateTextPerSec());
	}

	public void GetRankProgress()
	{
		MMRScore.GetChild("diamond").asLoader.url = "ui://PublicResources/" + RankDataHelper.PvPRankScoreItem;
	}

	private void CheckSeasonMission()
	{
		((GObject)MyRank.SeasonMission.note).visible = RankDataHelper.SeasonMissionHasFreeBonusToClaim();
	}

	private void CheckPvPStore()
	{
		((GObject)MyRank.RankStore.markNew).visible = RankDataHelper.SeasonBetStoreIsNewRefreshed();
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
