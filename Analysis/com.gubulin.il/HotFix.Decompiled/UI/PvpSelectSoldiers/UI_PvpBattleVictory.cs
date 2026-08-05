using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.GameEndPanels;
using UI.QuickBattle;
using UI.Tips;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_PvpBattleVictory : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static PlayCompleteCallback _003C_003E9__26_0;

		public static PlayCompleteCallback _003C_003E9__26_1;

		public static PlayCompleteCallback _003C_003E9__26_2;

		public static Action _003C_003E9__34_2;

		internal void _003C_prepareFxActionBeforePlayReplay_003Eb__26_0()
		{
			GameController.Contexts.Service<IUiService>().ClosePanel(UI_PvPBattleResultAnimationEffect.Name, reservePackageRes: true);
		}

		internal void _003C_prepareFxActionBeforePlayReplay_003Eb__26_1()
		{
			GameController.Contexts.Service<IUiService>().ClosePanel(UI_DamageMeter.Name);
		}

		internal void _003C_prepareFxActionBeforePlayReplay_003Eb__26_2()
		{
			GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
			if (UnityUiService.Instance.GetShowingUi(UI_PvpSelectSoldiersPanel.Name) is UI_PvpSelectSoldiersPanel uI_PvpSelectSoldiersPanel && !((GObject)uI_PvpSelectSoldiersPanel).isDisposed)
			{
				uI_PvpSelectSoldiersPanel.Type.selectedIndex = 2;
				((GObject)uI_PvpSelectSoldiersPanel.MyStandardFormationSketchMap.Background).alpha = 0f;
				((GObject)uI_PvpSelectSoldiersPanel.EnemyStandardFormationSketchMap.Background).alpha = 0f;
				((GObject)uI_PvpSelectSoldiersPanel.QuickBattleBackground).visible = false;
				((GObject)uI_PvpSelectSoldiersPanel.gradientEdges).visible = false;
				((GObject)uI_PvpSelectSoldiersPanel.QuickBattleStage).alpha = 1f;
				uI_PvpSelectSoldiersPanel.QuickBattleStage.Type.selectedIndex = 0;
				((GObject)uI_PvpSelectSoldiersPanel.QuickBattleStage.MyLegionIndex.indexText).text = "1";
				((GObject)uI_PvpSelectSoldiersPanel.QuickBattleStage.EnemyLegionIndex.indexText).text = "1";
				uI_PvpSelectSoldiersPanel.QuickBattleStage.ShowQuickBattleStage.Play();
			}
		}

		internal void _003CAutoChallenge_003Eb__34_2()
		{
		}
	}

	public Controller Status;

	public GLoader background;

	public GGraph BlackMask;

	public UI_InstanceZonesReward InstanceZonesReward;

	public UI_VictoryRibbon Light;

	public UI_YesButton YesButton;

	public UI_ContinueButton ContinueButton;

	public UI_AutoChallengeButton AutoChallengeButton;

	public Transition Rotate;

	public Transition Drop;

	public Transition ShowRewardAndChoose;

	public Transition ShowMainUi;

	public Transition HideMainUi;

	public const string URL = "ui://82mo10n5hcbs76";

	public static string Name = "UI_PvpBattleVictory";

	public static int lastRank;

	private static int notTouchableId = -1;

	private int LastScore;

	private int LastRank;

	private int curRank;

	private bool isQuickBattle;

	private RankSummary myRankSummary;

	private int battleResult = 1;

	private object battleStats;

	private string battleId;

	private Dictionary<string, int> rankUpBonus;

	public static string GetURL()
	{
		return "ui://82mo10n5hcbs76";
	}

	public static UI_PvpBattleVictory CreateInstance()
	{
		return (UI_PvpBattleVictory)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpBattleVictory");
	}

	public static UI_PvpBattleVictory CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpBattleVictory).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5hcbs76", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		background = (GLoader)((GComponent)this).GetChild("background");
		BlackMask = (GGraph)((GComponent)this).GetChild("BlackMask");
		InstanceZonesReward = (UI_InstanceZonesReward)(object)((GComponent)this).GetChild("InstanceZonesReward");
		Light = (UI_VictoryRibbon)(object)((GComponent)this).GetChild("Light");
		YesButton = (UI_YesButton)(object)((GComponent)this).GetChild("YesButton");
		ContinueButton = (UI_ContinueButton)(object)((GComponent)this).GetChild("ContinueButton");
		AutoChallengeButton = (UI_AutoChallengeButton)(object)((GComponent)this).GetChild("AutoChallengeButton");
		Rotate = ((GComponent)this).GetTransition("Rotate");
		Drop = ((GComponent)this).GetTransition("Drop");
		ShowRewardAndChoose = ((GComponent)this).GetTransition("ShowRewardAndChoose");
		ShowMainUi = ((GComponent)this).GetTransition("ShowMainUi");
		HideMainUi = ((GComponent)this).GetTransition("HideMainUi");
	}

	private static void LockUi()
	{
		notTouchableId = GameController.Contexts.Service<IUiService>().SetUiNotTouchable(Name);
	}

	private static void ReleaseUiLock(string uiName)
	{
		if (!(uiName != Name) && notTouchableId != -1)
		{
			GameController.Contexts.Service<IUiService>().SetUiTouchable(notTouchableId);
			notTouchableId = -1;
		}
	}

	public void BeforeDestroy()
	{
		ReleaseUiLock(Name);
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(UI_PlayersRank.Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		LastRank = lastRank;
		RankDataHelper.LastRankScore = (LastScore = GetRankScore(RankDataHelper.GetRankScoreReward(LastRank)));
		if (parameters.TryGetValue("BattleId", out var value))
		{
			battleId = value.ToString();
		}
		if (parameters.TryGetValue("BattleResult", out var value2))
		{
			battleResult = (int)value2;
		}
		if (parameters.TryGetValue("BattleStats", out var value3))
		{
			battleStats = value3;
		}
		if (parameters.TryGetValue("RankUpBonus", out var value4))
		{
			rankUpBonus = (Dictionary<string, int>)value4;
		}
		if (parameters.TryGetValue("NewRank", out var value5))
		{
			curRank = (int)value5;
		}
		if (parameters.TryGetValue("isQuickBattle", out var value6) && (bool)value6)
		{
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
			isQuickBattle = true;
		}
		else
		{
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
			isQuickBattle = false;
		}
		RenderMainUi();
	}

	private void _prepareFxActionBeforePlayReplay(Level level)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		if (level.LevelId != "RankBattleFieldLevel" || !isQuickBattle)
		{
			return;
		}
		if (UnityUiService.Instance.GetShowingUi(UI_PvPBattleResultAnimationEffect.Name) is UI_PvPBattleResultAnimationEffect uI_PvPBattleResultAnimationEffect)
		{
			Transition fadeAway = uI_PvPBattleResultAnimationEffect.OurAvatarInfo.FadeAway;
			object obj = _003C_003Ec._003C_003E9__26_0;
			if (obj == null)
			{
				PlayCompleteCallback val = delegate
				{
					GameController.Contexts.Service<IUiService>().ClosePanel(UI_PvPBattleResultAnimationEffect.Name, reservePackageRes: true);
				};
				_003C_003Ec._003C_003E9__26_0 = val;
				obj = (object)val;
			}
			fadeAway.Play((PlayCompleteCallback)obj);
		}
		if (UnityUiService.Instance.GetShowingUi(UI_DamageMeter.Name) is UI_DamageMeter uI_DamageMeter)
		{
			Transition slideOut = uI_DamageMeter.SlideOut;
			object obj2 = _003C_003Ec._003C_003E9__26_1;
			if (obj2 == null)
			{
				PlayCompleteCallback val2 = delegate
				{
					GameController.Contexts.Service<IUiService>().ClosePanel(UI_DamageMeter.Name);
				};
				_003C_003Ec._003C_003E9__26_1 = val2;
				obj2 = (object)val2;
			}
			slideOut.Play((PlayCompleteCallback)obj2);
		}
		Transition hideMainUi = HideMainUi;
		object obj3 = _003C_003Ec._003C_003E9__26_2;
		if (obj3 == null)
		{
			PlayCompleteCallback val3 = delegate
			{
				GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
				if (UnityUiService.Instance.GetShowingUi(UI_PvpSelectSoldiersPanel.Name) is UI_PvpSelectSoldiersPanel uI_PvpSelectSoldiersPanel && !((GObject)uI_PvpSelectSoldiersPanel).isDisposed)
				{
					uI_PvpSelectSoldiersPanel.Type.selectedIndex = 2;
					((GObject)uI_PvpSelectSoldiersPanel.MyStandardFormationSketchMap.Background).alpha = 0f;
					((GObject)uI_PvpSelectSoldiersPanel.EnemyStandardFormationSketchMap.Background).alpha = 0f;
					((GObject)uI_PvpSelectSoldiersPanel.QuickBattleBackground).visible = false;
					((GObject)uI_PvpSelectSoldiersPanel.gradientEdges).visible = false;
					((GObject)uI_PvpSelectSoldiersPanel.QuickBattleStage).alpha = 1f;
					uI_PvpSelectSoldiersPanel.QuickBattleStage.Type.selectedIndex = 0;
					((GObject)uI_PvpSelectSoldiersPanel.QuickBattleStage.MyLegionIndex.indexText).text = "1";
					((GObject)uI_PvpSelectSoldiersPanel.QuickBattleStage.EnemyLegionIndex.indexText).text = "1";
					uI_PvpSelectSoldiersPanel.QuickBattleStage.ShowQuickBattleStage.Play();
				}
			};
			_003C_003Ec._003C_003E9__26_2 = val3;
			obj3 = (object)val3;
		}
		hideMainUi.Play((PlayCompleteCallback)obj3);
	}

	public void OnShow()
	{
		UiAudioManager.Instance.PlayBackgroundSound("BattleWinBgm");
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{
				"SortingOrder",
				((GObject)this).sortingOrder + 1
			},
			{ "BattleResult", battleResult },
			{ "BattleStats", battleStats },
			{ "ShowLookBack", true },
			{ "isRankBattle", true },
			{ "BattleId", battleId }
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_DamageMeter.Name, parameters);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)YesButton).onClick.Add(new EventCallback1(ConfirmBtnClickEvent));
		((GObject)ContinueButton).onClick.Add(new EventCallback1(ContinueBtnClickEvent));
		((GObject)AutoChallengeButton).onClick.Add(new EventCallback1(AutoChallenge));
		GameManagers.Instance.Messenger.AddListener<Level>("SPECIAL_LEVEL_BATTLE_START", _prepareFxActionBeforePlayReplay);
		GameManagers.Instance.Messenger.AddListener<string>("SET_UI_TOUCHABLE", ReleaseUiLock);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)YesButton).onClick.Remove(new EventCallback1(ConfirmBtnClickEvent));
		((GObject)ContinueButton).onClick.Remove(new EventCallback1(ContinueBtnClickEvent));
		((GObject)AutoChallengeButton).onClick.Remove(new EventCallback1(AutoChallenge));
		GameManagers.Instance.Messenger.RemoveListener<Level>("SPECIAL_LEVEL_BATTLE_START", _prepareFxActionBeforePlayReplay);
		GameManagers.Instance.Messenger.RemoveListener<string>("SET_UI_TOUCHABLE", ReleaseUiLock);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
		CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
		{
			{ "ForceCloseOtherUi", true },
			{ "TaskCompletionSource", null },
			{
				"LoadingAnimationDirection",
				LoadingAnimationDirection.Left
			},
			{
				"OpenUiOnReturn",
				UI_LadderTournamentPanel.Name
			}
		}));
	}

	private void ReturnToLadderTournamentPanel()
	{
		List<string> panelsName = new List<string>
		{
			UI_DamageMeter.Name,
			Name,
			UI_QuickBattlePanel.Name,
			UI_PvPBattleResultAnimationEffect.Name,
			UI_PvpSelectSoldiersPanel.Name
		};
		GameController.Contexts.Service<IUiService>().CloseSomePanels(panelsName, reservePackageRes: true, ignoreLoading: true, edgeMaskVisible: true);
		if (UI_LadderTournamentPanel.LadderTournamentPanel != null)
		{
			UI_LadderTournamentPanel.LadderTournamentPanel.PlayersRanks.PlayersArmys.numItems = 0;
			UI_LadderTournamentPanel.LadderTournamentPanel.UpdatePanel();
		}
	}

	private void ConfirmBtnClickEvent(EventContext context)
	{
		if (isQuickBattle)
		{
			ReturnToLadderTournamentPanel();
		}
		else
		{
			End();
		}
	}

	private void ContinueBtnClickEvent(EventContext context)
	{
		Status.selectedIndex = 1;
		ScoreAndRankUpdate();
	}

	private void AutoChallenge(EventContext context)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)AutoChallengeButton).onClick.Remove(new EventCallback1(AutoChallenge));
		((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			if (!((GObject)this).isDisposed)
			{
				((GObject)AutoChallengeButton).onClick.Add(new EventCallback1(AutoChallenge));
			}
		});
		int autoChallengeDontShowAgainUntil = GameLocalDataManager.GetAutoChallengeDontShowAgainUntil();
		if (DateTimeHelper.GetTimeStamp(DateTimeHelper.ServerNow) >= autoChallengeDontShowAgainUntil)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ConfirmPopupDontShowAgain.Name, new Dictionary<string, object>
			{
				{ "TipKey", "TipKey_AutoChallenge" },
				{
					"TipValue",
					DateTimeHelper.GetTimeStamp(DateTimeHelper.GetWeeklyRefreshTime(DateTimeHelper.ServerNow, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddDays(7.0))
				},
				{
					"TipContent",
					LanguagesManager.GetDesc("CsharpCodeTextAutoChallengeTipDontShowAgain")
				},
				{
					"Content",
					LanguagesManager.GetDesc("CsharpCodeTextAutoChallengeTip")
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{
							"Confirm",
							delegate
							{
								((MonoBehaviour)FGUIManager.Instance).StartCoroutine(doAutoChallenge());
							}
						},
						{
							"Cancel",
							delegate
							{
							}
						}
					}
				},
				{ "ClickSound", "Confirm" },
				{ "Order", 999999 }
			});
		}
		else
		{
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(doAutoChallenge());
		}
	}

	private IEnumerator doAutoChallenge()
	{
		UnityUiService.Instance.ShowWaitingAnimation(show: true);
		LockUi();
		Task<GetSelfRankResponse> getSelfRankTask = GameController.Contexts.Service<INetworkService>().GetSelfRank(-1L);
		while (!getSelfRankTask.IsCanceled && !getSelfRankTask.IsCompleted)
		{
			yield return (object)new WaitForEndOfFrame();
		}
		GetSelfRankResponse getMyRankResponse = getSelfRankTask.Result;
		if (getMyRankResponse.Result)
		{
			lastRank = getMyRankResponse.Rank;
			if (lastRank == 1)
			{
				if (UI_PvpSelectSoldiersPanel.ContinueFailedHandler == null || !UI_PvpSelectSoldiersPanel.ContinueFailedHandler(UI_PvpSelectSoldiersPanel.ClickResult.ChallengeFailedNotFoundEnemy, LanguagesManager.GetDesc("CsharpCodeTextFindNoValidNPCToChallenge")))
				{
					string errMsg = LanguagesManager.GetDesc("CsharpCodeTextFindNoValidNPCToChallenge");
					SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { errMsg }, ((GObject)this).sortingOrder, arg3: false);
				}
				((GObject)AutoChallengeButton).visible = false;
				UnityUiService.Instance.ShowWaitingAnimation(show: false);
				ReleaseUiLock(Name);
				yield break;
			}
			Task<GetRankListResponse> getRankListTask = GameController.Contexts.Service<INetworkService>().GetRankList();
			while (!getRankListTask.IsCanceled && !getRankListTask.IsCompleted)
			{
				yield return (object)new WaitForEndOfFrame();
			}
			GetRankListResponse getRankListResponse = getRankListTask.Result;
			new List<RankSummary>();
			if (getRankListResponse.Result)
			{
				List<RankSummary> rankListToContinueChallenge = getRankListResponse.RankSummaryList;
				RankSummary challengeTargetRank = null;
				for (int i = rankListToContinueChallenge.Count - 1; i >= 0; i--)
				{
					RankSummary rankSummary = rankListToContinueChallenge[i];
					int curRankBattleCd = RankDataHelper.GetPvpRankProgressCdFinishAt(((rankSummary.UserId == 0) ? (-1 * rankSummary.Rank) : rankSummary.UserId).ToString());
					if (curRankBattleCd <= 0 && rankSummary.UserId < 1 && lastRank > rankSummary.Rank)
					{
						challengeTargetRank = rankSummary;
						break;
					}
				}
				if (challengeTargetRank == null)
				{
					UnityUiService.Instance.ShowWaitingAnimation(show: false);
					ReleaseUiLock(Name);
					if (UI_PvpSelectSoldiersPanel.ContinueFailedHandler == null || !UI_PvpSelectSoldiersPanel.ContinueFailedHandler(UI_PvpSelectSoldiersPanel.ClickResult.ChallengeFailedNotFoundEnemy, LanguagesManager.GetDesc("CsharpCodeTextFindNoValidNPCToChallenge")))
					{
						string errMsg2 = LanguagesManager.GetDesc("CsharpCodeTextFindNoValidNPCToChallenge");
						SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { errMsg2 }, ((GObject)this).sortingOrder, arg3: false);
					}
				}
				else if (!(UnityUiService.Instance.GetShowingUi(UI_PvpSelectSoldiersPanel.Name) is UI_PvpSelectSoldiersPanel uiPvpSelectSoldiersPanel))
				{
					ReturnToLadderTournamentPanel();
					ILRuntimeDebug.LogError("doAutoChallenge when uiPvpSelectSoldiersPanel == null");
					UnityUiService.Instance.ShowWaitingAnimation(show: false);
					ReleaseUiLock(Name);
					if (UI_PvpSelectSoldiersPanel.ContinueFailedHandler == null || !UI_PvpSelectSoldiersPanel.ContinueFailedHandler(UI_PvpSelectSoldiersPanel.ClickResult.UnNamedFailed, LanguagesManager.GetDesc("TipOpenPvpSelectSoldierPanelFailed")))
					{
						SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { "Unknown Error" }, ((GObject)this).sortingOrder, arg3: false);
					}
				}
				else
				{
					uiPvpSelectSoldiersPanel._rankSummaryList = rankListToContinueChallenge;
					uiPvpSelectSoldiersPanel.aimRankInfo = challengeTargetRank;
					uiPvpSelectSoldiersPanel.LoadLocal();
					uiPvpSelectSoldiersPanel.ShowEnemyInfo();
					SentrySdk.AddBreadcrumb("[ReplayInfoDebug]SyncRankFormationUnits_And_StartRankBattle By Auto Challenge");
					uiPvpSelectSoldiersPanel.SyncRankFormationUnits_And_StartRankBattle(challengeTargetRank.Rank, null);
				}
			}
			else
			{
				UnityUiService.Instance.ShowWaitingAnimation(show: false);
				ReleaseUiLock(Name);
				if (UI_PvpSelectSoldiersPanel.ContinueFailedHandler == null || !UI_PvpSelectSoldiersPanel.ContinueFailedHandler(UI_PvpSelectSoldiersPanel.ClickResult.UnNamedFailed, LanguagesManager.GetErrorMessage(getRankListResponse.ErrorCode)))
				{
					ILRequestHelper.ShowErrorCode(getRankListResponse.ErrorCode);
				}
			}
		}
		else
		{
			UnityUiService.Instance.ShowWaitingAnimation(show: false);
			ReleaseUiLock(Name);
			if (UI_PvpSelectSoldiersPanel.ContinueFailedHandler == null || !UI_PvpSelectSoldiersPanel.ContinueFailedHandler(UI_PvpSelectSoldiersPanel.ClickResult.UnNamedFailed, LanguagesManager.GetErrorMessage(getMyRankResponse.ErrorCode)))
			{
				ILRequestHelper.ShowErrorCode(getMyRankResponse.ErrorCode);
			}
		}
	}

	private void RenderMainUi()
	{
		Status.selectedIndex = ((rankUpBonus == null) ? 1 : 0);
		((GObject)AutoChallengeButton).visible = isQuickBattle && lastRank != 1;
		ScoreAndRankInit();
		ShowMainUi.Play();
	}

	private void ItemTip()
	{
		FGUIManager.Instance.ItemTip(RankDataHelper.PvPRankScoreItem, 1, noCheckBtn: true);
	}

	private void ScoreAndRankInit()
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		((GObject)InstanceZonesReward.LastClass).text = GetUserGradeText(LastRank);
		((GObject)InstanceZonesReward.LastScore).text = string.Format("+{0}/{1}", LastScore, LanguagesManager.GetDesc("CsharpCodeZhTcText248"));
		InstanceZonesReward.LastLevel.ShowRankLevel(LastRank);
		((GObject)InstanceZonesReward.ScoreIconFoo).onClick.Set(new EventCallback0(ItemTip));
		((GObject)InstanceZonesReward.CurClass).text = GetUserGradeText(curRank);
		((GObject)InstanceZonesReward.CurScore).text = string.Format("+{0}/{1}", GetRankScore(RankDataHelper.GetRankScoreReward(curRank)), LanguagesManager.GetDesc("CsharpCodeZhTcText248"));
		InstanceZonesReward.CurLevel.ShowRankLevel(curRank);
		((GObject)InstanceZonesReward.ScoreIconBar).onClick.Set(new EventCallback0(ItemTip));
		InstanceZonesReward.SetControllerPageText();
	}

	private int GetRankScore(Dictionary<string, int> _dictionary)
	{
		if (_dictionary == null || _dictionary.Count <= 0)
		{
			return 0;
		}
		return _dictionary.ToList()[0].Value;
	}

	private void ScoreAndRankUpdate()
	{
		if (rankUpBonus != null && rankUpBonus.Count > 0)
		{
			MaxLevelUpdate();
		}
	}

	private void MaxLevelUpdate()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		InstanceZonesReward.ChangeStatus.Play();
		((GComponent)(object)this).SetTimeout(0.25f).OnComplete((GTweenCallback)delegate
		{
			MaxLevelAndRewardInit();
			InstanceZonesReward.Status.selectedIndex = 1;
			InstanceZonesReward.SetControllerPageText();
		});
	}

	private void MaxLevelAndRewardInit()
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		((GObject)InstanceZonesReward.MaxLevel).text = string.Format("{0}{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText476"), LastRank);
		GTween.To((float)LastRank, (float)curRank, 0.8f).SetEase((EaseType)0).OnUpdate((GTweenCallback1)delegate(GTweener tweener)
		{
			((GObject)InstanceZonesReward.MaxLevel).text = string.Format("{0}{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText476"), Convert.ToInt32(Mathf.Floor(tweener.value.x)));
		})
			.OnComplete((GTweenCallback)delegate
			{
				((GObject)InstanceZonesReward.MaxLevel).text = string.Format("{0}{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText476"), curRank);
			});
		KeyValuePair<string, int> keyValuePair = rankUpBonus.ToList()[0];
		((GObject)InstanceZonesReward.MaxLevelUpReward.title).text = $"+{keyValuePair.Value}";
		string rewardItemId = keyValuePair.Key;
		FGUIManager.Instance.SetItemIconAndFrame(InstanceZonesReward.MaxLevelUpReward.icon, rewardItemId, null, "", frameVisible: false);
		((GObject)InstanceZonesReward.MaxLevelUpReward.icon).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(rewardItemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
		((GComponent)(object)this).SetTimeout(2.125f).OnComplete((GTweenCallback)delegate
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			FGUIManager.Instance.AddTextSpecialEffects(InstanceZonesReward.MaxLevelUpReward.FxBack, "activated_fx", new Vector3(280f, 280f, 280f));
		});
		((GComponent)(object)this).SetTimeout(0.375f).OnComplete((GTweenCallback)delegate
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			FGUIManager.Instance.AddTextSpecialEffects(InstanceZonesReward.MaxLevelUpReward.FxForeground, "activating_fx", new Vector3(150f, 150f, 150f));
		});
	}

	private string GetUserGradeText(int rank)
	{
		if (rank <= 0 || rank > 800)
		{
			return "";
		}
		int rangeIndex = ((rank % 100 == 0) ? (rank / 100) : (rank / 100 + 1));
		return "[size=40]" + RankDataHelper.GetPvpRankRangeText(rangeIndex) + "[/size]";
	}
}
