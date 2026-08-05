using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common;
using Shift.Legion.GvG.Common.Model;
using Shift.Legion.GvGServer.Models.Map;
using Shift.Legion.Helpers;
using Spine;
using Spine.Unity;
using UI.GvGBattleRecords;
using UnityEngine;

namespace UI.LordOfDreams;

public class UI_GvGSelectIslandPanel : GComponent, IUiController
{
	public Controller StageController;

	public GLoader background;

	public GImage n79;

	public UI_IslandsMapPic IslandsMapPic;

	public GImage n101;

	public GGraph SfxLoader;

	public GGraph BosscardAppear;

	public GButton BackBtn;

	public UI_Title Title;

	public UI_BossCardBtn Island1;

	public UI_BossCardBtn Island2;

	public UI_BossCardBtn Island3;

	public UI_BossCardBtn Island4;

	public UI_BossCardBtn Island5;

	public UI_BossCardBtn Island6;

	public UI_BossCardGoldWithMask Island7;

	public UI_BossAbility Ability1;

	public UI_BossAbility Ability2;

	public UI_BossAbility Ability3;

	public UI_BossAbility Ability4;

	public UI_BossAbility Ability5;

	public UI_BossAbility Ability6;

	public UI_TodayBestLeaderboard TodayBestLeaderboard;

	public GGraph BosscardAppearMask;

	public GTextField RebornTimeLeftText;

	public GImage n108;

	public GImage n99;

	public UI_BattleLogBtn BattleLog;

	public UI_FinalBossPop n106;

	public GGraph n107;

	public UI_GvGBossDetails GvGBossDetails;

	public GImage n110;

	public UI_MapCloudLoader MapCloudLoader;

	public GImage n118;

	public UI_RewardDescriptionBtn RewardDescription;

	public GGraph ClickMask;

	public Transition AbilitiesProgress;

	public Transition ShowBigBossAbility;

	public Transition StageChange1to2;

	public Transition StageChange2to3;

	public const string URL = "ui://0i520nzmdy01ocw";

	public static string Name = "UI_GvGSelectIslandPanel";

	private string CampId = "";

	private string IZId = "";

	private string IZConfigId = "";

	public static Dictionary<int, GvGProcessInfo> BossConfigs;

	public Dictionary<string, GButton> Dict_BossCard;

	private Coroutine RebornUpdateCoroutine;

	private Coroutine BossHpUpdateCoroutine;

	private bool ShowBigBossAbilityPlayed = false;

	private CoroutineQueue LoadingCoroutineQueue;

	private int LastMissionDataIndex = 0;

	private bool StageChangePlaying;

	private AnimationState MapCloudState;

	public static string GetURL()
	{
		return "ui://0i520nzmdy01ocw";
	}

	public static UI_GvGSelectIslandPanel CreateInstance()
	{
		return (UI_GvGSelectIslandPanel)(object)UIPackage.CreateObject("LordOfDreams", "GvGSelectIslandPanel");
	}

	public static UI_GvGSelectIslandPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGSelectIslandPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmdy01ocw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StageController = ((GComponent)this).GetController("StageController");
		background = (GLoader)((GComponent)this).GetChild("background");
		n79 = (GImage)((GComponent)this).GetChild("n79");
		IslandsMapPic = (UI_IslandsMapPic)(object)((GComponent)this).GetChild("IslandsMapPic");
		n101 = (GImage)((GComponent)this).GetChild("n101");
		SfxLoader = (GGraph)((GComponent)this).GetChild("SfxLoader");
		BosscardAppear = (GGraph)((GComponent)this).GetChild("BosscardAppear");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		Island1 = (UI_BossCardBtn)(object)((GComponent)this).GetChild("Island1");
		Island2 = (UI_BossCardBtn)(object)((GComponent)this).GetChild("Island2");
		Island3 = (UI_BossCardBtn)(object)((GComponent)this).GetChild("Island3");
		Island4 = (UI_BossCardBtn)(object)((GComponent)this).GetChild("Island4");
		Island5 = (UI_BossCardBtn)(object)((GComponent)this).GetChild("Island5");
		Island6 = (UI_BossCardBtn)(object)((GComponent)this).GetChild("Island6");
		Island7 = (UI_BossCardGoldWithMask)(object)((GComponent)this).GetChild("Island7");
		Ability1 = (UI_BossAbility)(object)((GComponent)this).GetChild("Ability1");
		Ability2 = (UI_BossAbility)(object)((GComponent)this).GetChild("Ability2");
		Ability3 = (UI_BossAbility)(object)((GComponent)this).GetChild("Ability3");
		Ability4 = (UI_BossAbility)(object)((GComponent)this).GetChild("Ability4");
		Ability5 = (UI_BossAbility)(object)((GComponent)this).GetChild("Ability5");
		Ability6 = (UI_BossAbility)(object)((GComponent)this).GetChild("Ability6");
		TodayBestLeaderboard = (UI_TodayBestLeaderboard)(object)((GComponent)this).GetChild("TodayBestLeaderboard");
		BosscardAppearMask = (GGraph)((GComponent)this).GetChild("BosscardAppearMask");
		RebornTimeLeftText = (GTextField)((GComponent)this).GetChild("RebornTimeLeftText");
		n108 = (GImage)((GComponent)this).GetChild("n108");
		n99 = (GImage)((GComponent)this).GetChild("n99");
		BattleLog = (UI_BattleLogBtn)(object)((GComponent)this).GetChild("BattleLog");
		n106 = (UI_FinalBossPop)(object)((GComponent)this).GetChild("n106");
		n107 = (GGraph)((GComponent)this).GetChild("n107");
		GvGBossDetails = (UI_GvGBossDetails)(object)((GComponent)this).GetChild("GvGBossDetails");
		n110 = (GImage)((GComponent)this).GetChild("n110");
		MapCloudLoader = (UI_MapCloudLoader)(object)((GComponent)this).GetChild("MapCloudLoader");
		n118 = (GImage)((GComponent)this).GetChild("n118");
		RewardDescription = (UI_RewardDescriptionBtn)(object)((GComponent)this).GetChild("RewardDescription");
		ClickMask = (GGraph)((GComponent)this).GetChild("ClickMask");
		AbilitiesProgress = ((GComponent)this).GetTransition("AbilitiesProgress");
		ShowBigBossAbility = ((GComponent)this).GetTransition("ShowBigBossAbility");
		StageChange1to2 = ((GComponent)this).GetTransition("StageChange1to2");
		StageChange2to3 = ((GComponent)this).GetTransition("StageChange2to3");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		Dict_BossCard = new Dictionary<string, GButton>();
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("IZId", out var value))
		{
			IZId = value.ToString();
		}
		if (parameters.TryGetValue("CampId", out var value2))
		{
			CampId = value2.ToString();
		}
		if (parameters.TryGetValue("IZConfigId", out var value3))
		{
			IZConfigId = value3.ToString();
		}
		((GObject)TodayBestLeaderboard.List).visible = false;
		((GObject)TodayBestLeaderboard.TodayTotalScore).text = "0";
		((GObject)TodayBestLeaderboard.ScoreHistoryPanel.ScoreHistoryBtn.TotalScore).text = "0";
		LoadingCoroutineQueue = new CoroutineQueue();
		GetTodayBestLeaderboard();
		RestartLoadingDataPerSecond();
		StartGetAllBossHp(10f);
		GvGConfigHelper.ReStartUiParamsAdd(Name, parameters);
	}

	private void RestartLoadingDataPerSecond()
	{
		GvGIZManager.Instance.StopLoadDataPerSecond();
		GvGIZManager.Instance.LoadDataPerSecond();
	}

	public void End()
	{
		GvGConfigHelper.ReStartUiParamsClear();
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void OpenBattleRecordsPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGBattleRecordsPanel.Name, new Dictionary<string, object>
		{
			{ "IZConfigId", IZConfigId },
			{ "IZId", IZId }
		});
	}

	public void RegisterUiEventListeners()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		GvGIZManager instance = GvGIZManager.Instance;
		instance.OnDataLoaded = (Action)Delegate.Combine(instance.OnDataLoaded, new Action(OnIZDataLoaded));
		((GObject)BackBtn).onClick.Set(new EventCallback0(End));
		((GObject)BattleLog).onClick.Set(new EventCallback0(OpenBattleRecordsPanel));
		((GObject)TodayBestLeaderboard.BonusDetailBtn).onClick.Set(new EventCallback0(OnOpenCampMissionPanel));
		((GObject)TodayBestLeaderboard.ScoreHistoryPanel.ScoreHistoryBtn).onClick.Set(new EventCallback1(OnSwitchScoreHistoryPanel));
		((GObject)TodayBestLeaderboard.Help).onClick.Set(new EventCallback0(ShowGvGHelpTip));
		((GObject)GvGBossDetails).onClick.Add(new EventCallback0(ShowGvGBossDetails));
		((GObject)RewardDescription).onClick.Add(new EventCallback0(ShowRewardDescription));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		GvGIZManager instance = GvGIZManager.Instance;
		instance.OnDataLoaded = (Action)Delegate.Remove(instance.OnDataLoaded, new Action(OnIZDataLoaded));
		((GObject)BackBtn).onClick.Clear();
		((GObject)BattleLog).onClick.Clear();
		((GObject)TodayBestLeaderboard.BonusDetailBtn).onClick.Clear();
		((GObject)TodayBestLeaderboard.Help).onClick.Clear();
		((GObject)GvGBossDetails).onClick.Remove(new EventCallback0(ShowGvGBossDetails));
		((GObject)RewardDescription).onClick.Remove(new EventCallback0(ShowRewardDescription));
	}

	private void GetWorldBossInfo()
	{
		ILRequestHelper<GvGGetWorldBossInfoResponse>.Request((EventContext)null, (Func<Task<GvGGetWorldBossInfoResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGGetWorldBossInfo(eGvGProcessType.WorldBoss)), (Action<GvGGetWorldBossInfoResponse>)delegate(GvGGetWorldBossInfoResponse response)
		{
			if (!response.Result)
			{
				ILRuntimeDebug.LogError("GvGGetWorldBossInfo 请求失败！");
			}
			else if (response.Info == null)
			{
				ILRuntimeDebug.LogError("GvGGetWorldBossInfo: List<GvGProcessInfo> Info 为 null");
			}
			else
			{
				BossConfigs = new Dictionary<int, GvGProcessInfo>();
				foreach (GvGProcessInfo item in response.Info)
				{
					if (BossConfigs.ContainsKey(item.IslandId))
					{
						ILRuntimeDebug.LogError($"GvGGetWorldBossInfo: 出现重复的IslandId:{item.IslandId}");
					}
					else
					{
						BossConfigs.Add(item.IslandId, item);
					}
				}
				RenderAll();
				InitBossDetailPanel();
			}
		});
	}

	private void InitBossDetailPanel()
	{
		float wBScoreMultiplier = GvGIZManager.Instance.GetInstanceZoneInfo(IZId).CampDatas["1"].WBScoreMultiplier;
		int deadCnt = BossConfigs.Values.Sum((GvGProcessInfo bossConfig) => bossConfig.BossInfo.DeadCnt);
		UI_GvGBossDetailsPanel.SetData(wBScoreMultiplier, deadCnt);
	}

	private void StartGetAllBossHp(float seconds)
	{
		if (BossHpUpdateCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(BossHpUpdateCoroutine);
		}
		BossHpUpdateCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetAllBossHp(seconds));
	}

	private void StopGetAllBossHp()
	{
		if (BossHpUpdateCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(BossHpUpdateCoroutine);
			BossHpUpdateCoroutine = null;
		}
	}

	private IEnumerator GetAllBossHp(float seconds)
	{
		while (true)
		{
			yield return (object)new WaitForSeconds(seconds);
			ILRequestHelper<GvGGetWorldBossKeyInfoResponse>.Request((EventContext)null, (Func<Task<GvGGetWorldBossKeyInfoResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGGetWorldBossKeyInfo(IZId)), (Action<GvGGetWorldBossKeyInfoResponse>)delegate(GvGGetWorldBossKeyInfoResponse response)
			{
				if (!response.Result)
				{
					ILRuntimeDebug.LogError("GvG Boss血量刷新失败!");
				}
				else
				{
					UpdateAllBossHp(response.Infos);
				}
			});
		}
	}

	private void GetTodayBestLeaderboard()
	{
		ILRequestHelper<GvGWorldBossGetBattleResultListResponse>.Request((EventContext)null, (Func<Task<GvGWorldBossGetBattleResultListResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGWorldBossGetBattleResultList()), (Action<GvGWorldBossGetBattleResultListResponse>)delegate(GvGWorldBossGetBattleResultListResponse response)
		{
			if (!response.Result)
			{
				ILRuntimeDebug.LogError("GvGWorldBossGetBattleResultList 请求失败！");
			}
			else
			{
				ArchiveExtension_WorldBossRecord.Model model = JsonHelper.ToObject<ArchiveExtension_WorldBossRecord.Model>(response.Model);
				GameManagers.Instance.UserArchiveManager.SetWorldBossRecordModel(model);
				RenderTodayBestLeaderboard();
				RenderScoreHistoryPanel();
				RenderScoreMissionList();
			}
		});
	}

	private void UpdateAllBossHp(List<WBKeyInfo> infos)
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		bool flag = false;
		foreach (WBKeyInfo info in infos)
		{
			if (!Dict_BossCard.TryGetValue(info.WBId, out var value))
			{
				continue;
			}
			float num = NumericParser.Float(info.HPPer);
			double max = ((GComponent)value).GetChild("HealthBar").asProgress.max;
			((GObject)((GComponent)value).GetChild("HealthText").asTextField).text = info.HPPer + "%";
			((GComponent)value).GetChild("HealthBar").asProgress.value = max * (double)num / 100.0;
			if (info.IsBossDead == (bool)((GObject)value).data)
			{
				continue;
			}
			((GObject)value).data = info.IsBossDead;
			flag = true;
			if (info.IsBossDead)
			{
				if (GetStageIndex() == 3)
				{
					(value as UI_BossCardBtn)?.ChangeCardType(2);
				}
				else
				{
					(value as UI_BossCardBtn)?.ChangeCardType(1);
				}
				(value as UI_BossCardGoldBtn)?.SetNeedPlayDeadSfx(playValue: true);
			}
			else
			{
				(value as UI_BossCardBtn)?.ChangeCardType(0);
			}
		}
		if (flag)
		{
			RestartLoadingDataPerSecond();
		}
	}

	private void RenderAll()
	{
		RenderStage();
		RenderBossCardsAndAbilities();
	}

	private void RenderBossCardsAndAbilities()
	{
		foreach (GvGProcessInfo value in BossConfigs.Values)
		{
			int islandId = value.IslandId;
			string wBId = value.BossInfo.WBId;
			GButton val = null;
			bool flag = islandId == 7;
			val = ((!flag) ? ((GComponent)this).GetChild($"Island{islandId}").asButton : ((GComponent)this).GetChild($"Island{islandId}").asCom.GetChild("Island7").asButton);
			float num = (float)(value.BossInfo.BossCurHp / value.BossInfo.BossMaxHp) * 100f;
			((GComponent)val).GetChild("HealthBar").asProgress.value = (double)value.BossInfo.BossCurHp;
			((GComponent)val).GetChild("HealthBar").asProgress.max = (double)value.BossInfo.BossMaxHp;
			((GObject)((GComponent)val).GetChild("HealthText").asTextField).text = $"{num:N1}%";
			((GObject)val).data = value.BossInfo.IsBossDead;
			if (!Dict_BossCard.ContainsKey(wBId))
			{
				Dict_BossCard.Add(wBId, val);
				LoadingCoroutineQueue.AddCoroutine(RenderBossCard(val, value, flag));
			}
			LoadingCoroutineQueue.AddCoroutine(RenderAbility(value));
		}
		foreach (KeyValuePair<string, GButton> item in Dict_BossCard)
		{
			if (item.Value is UI_BossCardBtn)
			{
				UI_BossCardBtn uI_BossCardBtn = item.Value as UI_BossCardBtn;
				((GObject)uI_BossCardBtn.SpineLoader).visible = StageController.selectedIndex != 2;
			}
		}
	}

	private IEnumerator RenderBossCard(GButton card, GvGProcessInfo bossConfig, bool isBoss)
	{
		yield return null;
		if (((GObject)this).isDisposed)
		{
			yield break;
		}
		string wbid = bossConfig.BossInfo.WBId;
		int islanId = bossConfig.IslandId;
		GvGWorldBossInfo wbInfo = GvGConfigHelper.GetGvGWorldBossInfoByWBId(wbid);
		GGraph loader = ((GComponent)card).GetChild("SpineLoader").asGraph;
		((GObject)((GComponent)card).GetChild("BossName").asTextField).text = wbInfo.BossName;
		((GObject)card).onClick.Set((EventCallback0)delegate
		{
			OnSelectIsland(islanId, (GObject)(object)card);
		});
		if (isBoss)
		{
			((GObject)loader).visible = StageController.selectedIndex != 1;
		}
		UiHelper.LoadSpine_AB(loader, wbInfo.SoldierId, 50f, delegate(SkeletonAnimation animation)
		{
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			if (!((GObject)this).isDisposed)
			{
				GvGUICardConfig uiCard = wbInfo.uiCard;
				SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, $"skin{wbInfo.level}");
				animation.AnimationState.SetAnimation(0, "idle", true);
				((Component)animation).transform.localScale = new Vector3((0f - uiCard.direction) * uiCard.scale, uiCard.scale, uiCard.scale);
				((GObject)loader).x = uiCard.x;
				((GObject)loader).y = uiCard.y;
				(card as UI_BossCardBtn)?.Init(bossConfig.BossInfo.IsBossDead);
			}
		});
	}

	private IEnumerator RenderAbility(GvGProcessInfo bossConfig)
	{
		yield return null;
		if (!((GObject)this).isDisposed)
		{
			int islanId = bossConfig.IslandId;
			string wbid = bossConfig.BossInfo.WBId;
			GObject child = ((GComponent)this).GetChild($"Ability{islanId}");
			Ability cardAbilityData = bossConfig.BossInfo.GetCurrentRedAbility();
			if (child != null && cardAbilityData != null)
			{
				UI_BossAbility ability = (UI_BossAbility)(object)child.asCom;
				ability.Icon.url = cardAbilityData.GetAbilityIcon();
				ability.SetText(cardAbilityData.GetAbilityLevelAndName(), wbid, cardAbilityData.AbilityId, cardAbilityData.GetAbilityLevel());
				child.onClick.Set(new EventCallback0(cardAbilityData.ShowSkillDetailPopup));
			}
		}
	}

	private void RenderTodayBestLeaderboard()
	{
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.ServerNow, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
		string key = $"{dailyRefreshTime.Year}_{dailyRefreshTime.Month}_{dailyRefreshTime.Day}";
		ArchiveExtension_WorldBossRecord.Model worldBossRecordModel = GameManagers.Instance.UserArchiveManager.GetWorldBossRecordModel();
		if (!worldBossRecordModel.Records.TryGetValue(IZId, out var value))
		{
			return;
		}
		if (value.EveryDayRecords.TryGetValue(key, out var value2))
		{
			((GObject)TodayBestLeaderboard.List).visible = true;
			List<OnRewardUserModel> allBossTop = value2.AllBossTop4;
			for (int i = 0; i < 3; i++)
			{
				UI_TodayMyBestSlotMini uI_TodayMyBestSlotMini = (UI_TodayMyBestSlotMini)(object)((GComponent)TodayBestLeaderboard.List).GetChildAt(i).asCom;
				if (i >= allBossTop.Count)
				{
					((GObject)uI_TodayMyBestSlotMini).visible = false;
					continue;
				}
				OnRewardUserModel onRewardUserModel = allBossTop[i];
				uI_TodayMyBestSlotMini.NumberController.selectedIndex = i;
				((GObject)uI_TodayMyBestSlotMini.DamageText).text = onRewardUserModel.TotalDamage.ShortNumberFormat() ?? "";
				((GObject)uI_TodayMyBestSlotMini.Score).text = $"{onRewardUserModel.Score}";
				if (onRewardUserModel.ScoreMultiplier - 1f > float.Epsilon)
				{
					((GObject)uI_TodayMyBestSlotMini.Ratio).visible = true;
					((GObject)uI_TodayMyBestSlotMini.arrow).visible = true;
					((GObject)uI_TodayMyBestSlotMini.Ratio).text = $"(x{onRewardUserModel.ScoreMultiplier})";
					int score = (int)((float)onRewardUserModel.Score / onRewardUserModel.ScoreMultiplier);
					CheckScoreMultiplierTip(uI_TodayMyBestSlotMini.ScoreMultiplierTip, score);
					((GObject)uI_TodayMyBestSlotMini.ScoreMultiplierTip).onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
				}
				GvGWorldBossInfo gvGWorldBossInfoByWBId = GvGConfigHelper.GetGvGWorldBossInfoByWBId(onRewardUserModel.WBId);
				if (gvGWorldBossInfoByWBId != null)
				{
					((GComponent)((GComponent)uI_TodayMyBestSlotMini).GetChild("Avatar").asButton).GetChild("HeadPortrait").asCom.GetChild("icon").asLoader.url = "ui://PublicResources/" + gvGWorldBossInfoByWBId.Icon;
				}
			}
			((GObject)TodayBestLeaderboard.TodayTotalScore).text = $"{value2.TodayTotalScore}";
		}
		((GObject)TodayBestLeaderboard.ScoreHistoryPanel.ScoreHistoryBtn.TotalScore).text = $"{value.TotalScore}";
	}

	private int GetStageIndex()
	{
		int iZProgress = GvGIZManager.Instance.GetInstanceZoneInfo(IZId).IZProgress;
		return iZProgress + 1;
	}

	private void RenderStage()
	{
		int bossRebornTimeStamp = -1;
		foreach (GvGProcessInfo value in BossConfigs.Values)
		{
			int islandId = value.IslandId;
			GButton val = null;
			bool flag = islandId == 7;
			val = ((!flag) ? ((GComponent)this).GetChild($"Island{islandId}").asButton : ((GComponent)this).GetChild($"Island{islandId}").asCom.GetChild("Island7").asButton);
			if (GetStageIndex() == 3 && !flag && value.BossInfo.IsBossDead)
			{
				(val as UI_BossCardBtn)?.SetBossDeadType();
			}
			if (GetStageIndex() == 3 && flag && value.BossInfo.IsBossDead && value.BossInfo.NextRebornTimestamp < 0)
			{
				(val as UI_BossCardGoldBtn)?.PlayBossDead();
			}
			if (GetStageIndex() == 1 && !flag && value.BossInfo.IsBossDead)
			{
				(val as UI_BossCardBtn)?.ChangeCardType(1);
			}
			if (GetStageIndex() == 1 && !flag && !value.BossInfo.IsBossDead && ((GObject)val).data != null && (bool)((GObject)val).data != value.BossInfo.IsBossDead)
			{
				(val as UI_BossCardBtn)?.ChangeCardType(0);
			}
			if (GetStageIndex() == 1 && flag && value.BossInfo.IsBossDead && ((GObject)val).data != null && (bool)((GObject)val).data != value.BossInfo.IsBossDead)
			{
				(val as UI_BossCardGoldBtn)?.SetNeedPlayDeadSfx(playValue: true);
			}
			((GObject)val).data = value.BossInfo.IsBossDead;
			if (flag)
			{
				bossRebornTimeStamp = value.BossInfo.NextRebornTimestamp;
			}
		}
		SetStageState(GetStageIndex(), IZId, bossRebornTimeStamp);
		if (RebornUpdateCoroutine == null)
		{
			AbilitiesProgress.timeScale = 1.5f;
			RebornUpdateCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateBossRebornTime());
		}
	}

	private IEnumerator UpdateBossRebornTime()
	{
		int rebornTotalTime = -1;
		if (BossConfigs.TryGetValue(7, out var bigBoss))
		{
			rebornTotalTime = bigBoss.BossInfo.RebornCooldown;
		}
		while (true)
		{
			int curServerTime = (int)GameController.Instance.GetServerTime();
			if (rebornTotalTime != -1)
			{
				int bossRebornTime = GvGIZManager.Instance.GetBossRebornTime(IZId, CampId);
				int timeLeft = bossRebornTime - curServerTime;
				if (timeLeft < 0)
				{
					timeLeft = 0;
				}
				float percent = (float)timeLeft / (float)rebornTotalTime;
				AbilitiesProgress.Play(1, 0f, 0f, 1f - percent, (PlayCompleteCallback)null);
				((GObject)RebornTimeLeftText).text = UiHelper.ParseTime(Convert.ToInt32(timeLeft));
				GObject GvGBonusPanel = GameController.Contexts.Service<IUiService>().GetShowingUi(UI_GvGBonusPanel.Name);
				(GvGBonusPanel as UI_GvGBonusPanel)?.UpdateDamageRewardListRebornTime(((GObject)RebornTimeLeftText).text);
			}
			bool isAnyBossReborn = false;
			if (GetStageIndex() == 1 && BossConfigs != null)
			{
				foreach (GvGProcessInfo bossConfig in BossConfigs.Values)
				{
					int islanId = bossConfig.IslandId;
					if (islanId == 7)
					{
						continue;
					}
					GButton card = ((GComponent)this).GetChild($"Island{islanId}").asButton;
					int timeLeft2 = bossConfig.BossInfo.NextRebornTimestamp - curServerTime;
					if (!bossConfig.BossInfo.IsBossDead)
					{
						continue;
					}
					if (bossConfig.BossInfo.DeadCnt < 10)
					{
						if (timeLeft2 < 0)
						{
							timeLeft2 = 0;
							isAnyBossReborn = true;
						}
						((GComponent)card).GetChild("CountDown").text = UiHelper.ParseTime(Convert.ToInt32(timeLeft2));
					}
					else
					{
						((GComponent)card).GetChild("CountDown").text = "";
					}
				}
			}
			if (BossConfigs != null)
			{
				foreach (GvGProcessInfo bossConfig2 in BossConfigs.Values)
				{
					int islanId2 = bossConfig2.IslandId;
					if (islanId2 != 7)
					{
						continue;
					}
					if (bossConfig2.BossInfo.IsBossDead && bossConfig2.BossInfo.NextRebornTimestamp > 0)
					{
						int timeLeft3 = bossConfig2.BossInfo.NextRebornTimestamp - curServerTime;
						if (timeLeft3 < 0)
						{
							timeLeft3 = 0;
							isAnyBossReborn = true;
						}
						MapCloudLoader.UpdateIsland7BossRebornTime(timeLeft3);
					}
					else if (bossConfig2.BossInfo.IsBossDead && GetStageIndex() == 2)
					{
						int bossDeadTime = GvGIZManager.Instance.GetBossDeadTime(IZId, CampId);
						int timeLeft3 = bossDeadTime + 300 - curServerTime;
						if (timeLeft3 < 0)
						{
							timeLeft3 = 0;
						}
						MapCloudLoader.UpdateIsland7BossRebornTime(timeLeft3);
					}
				}
			}
			if (isAnyBossReborn)
			{
				RestartLoadingDataPerSecond();
			}
			yield return (object)new WaitForSeconds(1f);
		}
	}

	private void RenderScoreMissionList()
	{
		GList scoreBonusList = TodayBestLeaderboard.ScoreBonusList;
		if (!((GObject)scoreBonusList).touchable)
		{
			return;
		}
		if (scoreBonusList.numItems == 0)
		{
			((GComponent)scoreBonusList).scrollPane.posY = 0f;
			((GComponent)scoreBonusList).scrollPane.mouseWheelEnabled = false;
			((GComponent)scoreBonusList).scrollPane.CancelDragging();
			TodayBestLeaderboard.HasMission.selectedIndex = 1;
			for (int i = 0; i < 3; i++)
			{
				if (!TryAddMissionItem())
				{
					TodayBestLeaderboard.HasMission.selectedIndex = 0;
					break;
				}
			}
		}
		else
		{
			UpdateMissionItemState();
		}
	}

	private bool TryAddMissionItem()
	{
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		GList scoreBonusList = TodayBestLeaderboard.ScoreBonusList;
		List<GvGIZManager.UserCampMissionData> userCampMissions = GvGIZManager.Instance.GetUserCampMissions(IZId, CampId);
		if (scoreBonusList.numItems == 0)
		{
			LastMissionDataIndex = userCampMissions.FindIndex((GvGIZManager.UserCampMissionData m) => m.State != eCampMissionState.Claimed);
			if (LastMissionDataIndex < 0)
			{
				return false;
			}
		}
		else
		{
			LastMissionDataIndex++;
		}
		int listIndex = scoreBonusList.numItems;
		UI_ScoreBonusSlotMini uI_ScoreBonusSlotMini = (UI_ScoreBonusSlotMini)(object)scoreBonusList.AddItemFromPool();
		UI_ScoreBonusSlotWrapperMini wrapper = uI_ScoreBonusSlotMini.Wrapper;
		if (LastMissionDataIndex >= userCampMissions.Count)
		{
			((GObject)uI_ScoreBonusSlotMini.Wrapper).visible = false;
			((GObject)uI_ScoreBonusSlotMini).data = null;
			return true;
		}
		GvGIZManager.UserCampMissionData data = userCampMissions[LastMissionDataIndex];
		((GObject)uI_ScoreBonusSlotMini).data = data;
		((GObject)wrapper.TargetScore).text = $"{data.TargetScore}";
		((GObject)wrapper.Num).text = $"{data.BonusNum}";
		((GObject)wrapper.Icon.Back).visible = false;
		((GObject)wrapper.ClaimBtn).onClick.Set((EventCallback0)delegate
		{
			OnClaimScoreBonus(listIndex);
		});
		FGUIManager.Instance.SetItemIconAndFrame(wrapper.Icon.rewardIcon, data.BonusId);
		((GObject)wrapper.Icon).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(data.BonusId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
		if (listIndex == 0)
		{
			RenderCurScoreBonusSlotState(uI_ScoreBonusSlotMini, data);
		}
		else
		{
			uI_ScoreBonusSlotMini.StateController.selectedIndex = 0;
			wrapper.StateController.selectedIndex = 0;
		}
		return true;
	}

	private void UpdateMissionItemState()
	{
		bool flag = false;
		GList scoreBonusList = TodayBestLeaderboard.ScoreBonusList;
		List<GvGIZManager.UserCampMissionData> userCampMissions = GvGIZManager.Instance.GetUserCampMissions(IZId, CampId);
		for (int i = 0; i < scoreBonusList.numItems; i++)
		{
			UI_ScoreBonusSlotMini uI_ScoreBonusSlotMini = (UI_ScoreBonusSlotMini)(object)((GComponent)scoreBonusList).GetChildAt(i);
			GvGIZManager.UserCampMissionData userCampMissionData = (GvGIZManager.UserCampMissionData)((GObject)uI_ScoreBonusSlotMini).data;
			GvGIZManager.UserCampMissionData userCampMissionData2 = (GvGIZManager.UserCampMissionData)(((GObject)uI_ScoreBonusSlotMini).data = userCampMissions[userCampMissionData.Index]);
			if (!flag && userCampMissionData2.State != eCampMissionState.Claimed)
			{
				flag = true;
				RenderCurScoreBonusSlotState(uI_ScoreBonusSlotMini, userCampMissionData2);
			}
		}
	}

	private void RenderCurScoreBonusSlotState(UI_ScoreBonusSlotMini slot, GvGIZManager.UserCampMissionData data)
	{
		UI_ScoreBonusSlotWrapperMini wrapper = slot.Wrapper;
		slot.StateController.selectedIndex = 1;
		if (data.State == eCampMissionState.Claimed)
		{
			wrapper.StateController.selectedIndex = 3;
		}
		else if (data.State == eCampMissionState.Completed)
		{
			wrapper.StateController.selectedIndex = 2;
		}
		else
		{
			wrapper.StateController.selectedIndex = 1;
		}
	}

	private void RenderScoreHistoryPanel()
	{
		ArchiveExtension_WorldBossRecord.Model worldBossRecordModel = GameManagers.Instance.UserArchiveManager.GetWorldBossRecordModel();
		if (!worldBossRecordModel.Records.TryGetValue(IZId, out var value) || ((GObject)this).isDisposed)
		{
			return;
		}
		GList list = TodayBestLeaderboard.ScoreHistoryPanel.List;
		list.RemoveChildrenToPool();
		foreach (KeyValuePair<string, ArchiveExtension_WorldBossRecord.EveryDayRecord> everyDayRecord in value.EveryDayRecords)
		{
			UI_ScoreHistorySlot uI_ScoreHistorySlot = (UI_ScoreHistorySlot)(object)list.AddItemFromPool();
			string[] array = everyDayRecord.Key.Split(new char[1] { '_' });
			string text = array[0];
			string text2 = array[1];
			string text3 = array[2];
			if (!HotUpdateProcess.Instance.IsRegionOutCN)
			{
				((GObject)uI_ScoreHistorySlot.Date).text = text2 + LanguagesManager.GetDesc("CsharpCodeZhTcText397") + text3 + LanguagesManager.GetDesc("CsharpCodeZhTcText398");
			}
			else
			{
				((GObject)uI_ScoreHistorySlot.Date).text = text + "-" + text2 + "-" + text3;
			}
			((GObject)uI_ScoreHistorySlot.Score).text = $"{everyDayRecord.Value.TodayTotalScore}";
		}
	}

	private void ShowGvGBossDetails()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGBossDetailsPanel.Name, null);
	}

	private void ShowRewardDescription()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_RewardDescriptionPanel.Name, null);
	}

	private void ShowGvGHelpTip()
	{
		int iZProgress = GvGIZManager.Instance.GetInstanceZoneInfo(IZId).IZProgress;
		float wBScoreMultiplier = GvGIZManager.Instance.GetInstanceZoneInfo(IZId).CampDatas["1"].WBScoreMultiplier;
		float num = 0f;
		switch (iZProgress)
		{
		case 0:
			num = 1f;
			break;
		case 1:
			num = wBScoreMultiplier + 1f;
			break;
		case 2:
			num = wBScoreMultiplier + 2f;
			break;
		}
		Dictionary<string, object> parameters = new Dictionary<string, object> { { "ScoreMultiplier", num } };
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGHelpPanel.Name, parameters);
	}

	private void CheckScoreMultiplierTip(GGraph exclamationMarkBtn, int score)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		((GObject)exclamationMarkBtn).data = new Dictionary<string, object>
		{
			{
				"Title",
				LanguagesManager.GetDesc("CsharpCodeZhTcText411") + Environment.NewLine + string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText412"), score)
			},
			{
				"Pos",
				(object)new Vector2(((GObject)TodayBestLeaderboard).x + ((GObject)TodayBestLeaderboard).width / 2f, ((GObject)this).height / 2f - 260f)
			}
		};
	}

	private void OnSwitchScoreHistoryPanel(EventContext context)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		UI_ScoreHistoryPanel panel = TodayBestLeaderboard.ScoreHistoryPanel;
		if (panel.Collapse.playing || panel.Expand.playing)
		{
			return;
		}
		if (panel.StateController.selectedIndex == 0)
		{
			panel.Expand.Play((PlayCompleteCallback)delegate
			{
				panel.StateController.selectedIndex = 1;
			});
		}
		else
		{
			panel.Collapse.Play((PlayCompleteCallback)delegate
			{
				panel.StateController.selectedIndex = 0;
			});
		}
	}

	private void OnSelectIsland(int islandId, GObject card)
	{
		InstanceZone_Protocol instanceZoneInfo = GvGIZManager.Instance.GetInstanceZoneInfo(IZId);
		int num = (int)GameController.Instance.GetServerTime();
		if (num < instanceZoneInfo.BeginTimestamp)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText418") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
		else if (instanceZoneInfo.EndTimestamp < num)
		{
			List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText419") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
		}
		else if ((bool)card.data)
		{
			List<string> arg3 = new List<string> { "BOSS" + LanguagesManager.GetDesc("CsharpCodeZhTcText420") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg3, 1, arg3: false);
		}
		else
		{
			Dictionary<string, object> parameters = new Dictionary<string, object> { 
			{
				"SelectedBossConfig",
				BossConfigs[islandId]
			} };
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LordOfDreamsPanel.Name, parameters);
		}
	}

	private void OnOpenCampMissionPanel()
	{
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "IZId", IZId },
			{ "CampId", CampId },
			{
				"LastWBId",
				BossConfigs[7].BossInfo.WBId
			},
			{
				"IZProgress",
				GvGIZManager.Instance.GetInstanceZoneInfo(IZId).IZProgress
			}
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGBonusPanel.Name, parameters);
	}

	private void OnIZDataLoaded()
	{
		GetWorldBossInfo();
		RenderScoreMissionList();
	}

	private void OnClaimScoreBonus(int index)
	{
		GList glist = TodayBestLeaderboard.ScoreBonusList;
		int nextIndex = index + 1;
		UI_ScoreBonusSlotMini slot = (UI_ScoreBonusSlotMini)(object)((GComponent)glist).GetChildAt(index);
		GvGIZManager.UserCampMissionData data = (GvGIZManager.UserCampMissionData)((GObject)slot).data;
		UI_ScoreBonusSlotMini nextSlot = (UI_ScoreBonusSlotMini)(object)((GComponent)glist).GetChildAt(nextIndex);
		GvGIZManager.UserCampMissionData nextData = (GvGIZManager.UserCampMissionData)((GObject)nextSlot).data;
		if (data.State != eCampMissionState.Completed || ((GObject)slot.Wrapper.ClaimBtn).grayed)
		{
			return;
		}
		((GObject)glist).touchable = false;
		TweenCallback val2 = default(TweenCallback);
		ILRequestHelper<GvGClaimUserCampMissionResponse>.Request((EventContext)null, (Func<Task<GvGClaimUserCampMissionResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGClaimUserCampMission(IZId, CampId, data.MissionConfigId)), (Action<GvGClaimUserCampMissionResponse>)delegate(GvGClaimUserCampMissionResponse response)
		{
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Expected O, but got Unknown
			//IL_01fd: Expected O, but got Unknown
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				ILRuntimeDebug.LogError("GvGClaimUserCampMission 请求失败！");
				((GObject)glist).touchable = true;
			}
			else if (response.Claimed == null)
			{
				ILRuntimeDebug.LogError("GvGClaimUserCampMission: Dictionary<string, float> Claimed 为 null");
				((GObject)glist).touchable = true;
			}
			else
			{
				data.State = eCampMissionState.Claimed;
				GameManagers.Instance.UserArchiveManager.TryClaimGvGUserCampMissionRecord(IZId, data.MissionConfigId);
				foreach (KeyValuePair<string, float> item in response.Claimed)
				{
					Bonus.Get(item.Key, (int)item.Value).Claim(GameManagers.Instance);
				}
				TryAddMissionItem();
				slot.Wrapper.StateController.selectedIndex = 3;
				if (nextData != null)
				{
					RenderCurScoreBonusSlotState(nextSlot, nextData);
				}
				float num = 0.4f;
				nextSlot.Magnify.timeScale = 1f / num;
				nextSlot.Magnify.Play();
				TweenerCore<float, float, FloatOptions> val = DOTween.To((DOGetter<float>)(() => ((GComponent)glist).scrollPane.posY), (DOSetter<float>)delegate(float y)
				{
					((GComponent)glist).scrollPane.posY = y;
				}, (float)nextIndex * ((GObject)nextSlot).height, num);
				TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(val, (Ease)4);
				TweenCallback obj = val2;
				if (obj == null)
				{
					TweenCallback val3 = delegate
					{
						((GObject)glist).touchable = true;
						List<GvGIZManager.UserCampMissionData> userCampMissions = GvGIZManager.Instance.GetUserCampMissions(IZId, CampId);
						if (userCampMissions.FindIndex((GvGIZManager.UserCampMissionData m) => m.State != eCampMissionState.Claimed) < 0)
						{
							TodayBestLeaderboard.HasMission.selectedIndex = 0;
						}
					};
					TweenCallback val4 = val3;
					val2 = val3;
					obj = val4;
				}
				((Tween)val).onComplete = obj;
			}
		});
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
		LoadingCoroutineQueue.Clear();
		StopGetAllBossHp();
		GvGIZManager.Instance.StopLoadDataPerSecond();
	}

	public void Destroy()
	{
		if (RebornUpdateCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RebornUpdateCoroutine);
		}
	}

	private void SetStageIndex(int newIndex, string izId)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		IslandsMapPic.StageController.selectedIndex = newIndex;
		StageController.selectedIndex = newIndex;
		if (StageController.selectedIndex == 1)
		{
			FGUIManager.Instance.AddTextSpecialEffects(SfxLoader, "ui_gvg_chain_move", new Vector3(100f, 100f, 100f));
		}
		if (StageController.selectedIndex == 2 && !ShowBigBossAbilityPlayed)
		{
			ShowBigBossAbilityPlayed = true;
			ShowBigBossAbility.Play();
		}
		GameLocalDataManager.SetUserGvGIZProgress(izId, newIndex);
	}

	private void ChangeStageIndex(int newIndex, string izId, int bossRebornTimeStamp)
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		if (StageChangePlaying)
		{
			return;
		}
		if (StageController.selectedIndex == 0 && newIndex == 1)
		{
			SetStageIndex(newIndex, izId);
		}
		else if (StageController.selectedIndex == 0 && newIndex != 1)
		{
			if (GameLocalDataManager.PlaytGvGIZProgressChange(izId, newIndex))
			{
				StageChangePlaying = true;
				SetStageIndex(newIndex - 1, izId);
				((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
				{
					if (newIndex == 2)
					{
						PlayStageOneToTwo(newIndex, izId);
					}
					else if (newIndex == 3)
					{
						PlayStageTwoToThree(newIndex, izId);
					}
				});
			}
			else
			{
				SetStageIndex(newIndex, izId);
			}
		}
		else if (StageController.selectedIndex == 1 && newIndex == 2)
		{
			StageChangePlaying = true;
			PlayStageOneToTwo(newIndex, izId);
		}
		else if (StageController.selectedIndex == 2 && newIndex == 3)
		{
			MapCloudDisappearOnBossReborn(newIndex, izId, bossRebornTimeStamp);
		}
		else
		{
			SetStageIndex(newIndex, izId);
		}
	}

	private void MapCloudDisappearOnBossReborn(int newIndex, string izId, int bossRebornTimeStamp)
	{
		if (bossRebornTimeStamp < 0)
		{
			StageChangePlaying = true;
			((GObject)ClickMask).touchable = true;
			Action action = delegate
			{
				ShowBossCardOnBossReborn(newIndex, izId);
			};
			MapCloudLoader.MapCloudDisappear(action);
		}
	}

	private void ShowBossCardOnBossReborn(int newIndex, string izId)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		Island7.Island7.AppearOnStage3();
		for (int i = 1; i < 7; i++)
		{
			if (((GComponent)this).GetChild($"Island{i}") is UI_BossCardBtn uI_BossCardBtn)
			{
				uI_BossCardBtn?.AppearOnStage3();
			}
		}
		((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
		{
			SetStageIndex(newIndex, izId);
			foreach (KeyValuePair<string, GButton> item in Dict_BossCard)
			{
				if (item.Value is UI_BossCardBtn)
				{
					UI_BossCardBtn uI_BossCardBtn2 = item.Value as UI_BossCardBtn;
					((GObject)uI_BossCardBtn2.SpineLoader).visible = StageController.selectedIndex != 2;
				}
			}
			((GObject)ClickMask).touchable = false;
			StageChangePlaying = false;
		});
	}

	private void ShowMapCloudWaitBossReborn(string izId, int bossRebornTimeStamp)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		if (StageChangePlaying)
		{
			return;
		}
		bool needPlayDeadSfx = Island7.Island7.needPlayDeadSfx;
		StageChangePlaying = true;
		if (needPlayDeadSfx)
		{
			((GObject)ClickMask).touchable = true;
			((GComponent)(object)this).SetTimeout(2f).OnComplete((GTweenCallback)delegate
			{
				for (int i = 1; i < 7; i++)
				{
					if (((GComponent)this).GetChild($"Ability{i}") is UI_BossAbility uI_BossAbility2)
					{
						uI_BossAbility2.PlayStage2To3();
					}
				}
			});
			((GComponent)(object)this).SetTimeout(3f).OnComplete((GTweenCallback)delegate
			{
				MapCloudLoader.ShowMapCloud(bossRebornTimeStamp);
			});
			((GComponent)(object)this).SetTimeout(3.75f).OnComplete((GTweenCallback)delegate
			{
				StageChangePlaying = false;
				((GObject)ClickMask).touchable = false;
			});
		}
		else
		{
			for (int num = 1; num < 7; num++)
			{
				if (((GComponent)this).GetChild($"Ability{num}") is UI_BossAbility uI_BossAbility)
				{
					((GObject)uI_BossAbility).alpha = 0f;
				}
			}
			MapCloudLoader.ShowMapCloud(bossRebornTimeStamp, skip: true);
			StageChangePlaying = false;
		}
		Island7.Island7.PlayBossDead();
		SetStageIndex(2, izId);
	}

	private void SetStageState(int newIndex, string izId, int bossRebornTimeStamp)
	{
		int stageIndex = GetStageIndex();
		bool flag = (bool)((GObject)Island7.Island7).data;
		if (stageIndex == 2 && flag && StageController.selectedIndex != 1)
		{
			ShowMapCloudWaitBossReborn(izId, bossRebornTimeStamp);
		}
		else if (stageIndex == 3 && flag && bossRebornTimeStamp != -1 && StageController.selectedIndex != 1)
		{
			ShowMapCloudWaitBossReborn(izId, bossRebornTimeStamp);
		}
		else
		{
			ChangeStageIndex(newIndex, izId, bossRebornTimeStamp);
		}
	}

	private void PlayStageTwoToThree(int newIndex, string izId)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		StageChange2to3.SetHook("ui_gvg_card_explosion_2", (TransitionHook)delegate
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			FGUIManager.Instance.AddTextSpecialEffects(Island7.Island7.SfxBack, "ui_gvg_card_explosion_2", new Vector3(100f, 100f, 100f));
		});
		StageChange2to3.SetHook("SpineVisibleFalse", (TransitionHook)delegate
		{
			((GObject)Island7.Island7.SpineLoader).visible = false;
		});
		StageChange2to3.SetHook("ui_gvg_debuff_explosion", (TransitionHook)delegate
		{
			for (int i = 1; i < 7; i++)
			{
				if (((GComponent)this).GetChild($"Ability{i}") is UI_BossAbility uI_BossAbility)
				{
					uI_BossAbility.PlayStage2To3();
				}
			}
		});
		StageChange2to3.SetHook("Map_Cloud", (TransitionHook)delegate
		{
			MapCloudLoader.PlayStageChange2to3();
		});
		StageChange2to3.SetHook("ui_gvg_card_reborn_2", (TransitionHook)delegate
		{
			Island7.Island7.AppearOnStage3();
			for (int i = 1; i < 7; i++)
			{
				if (((GComponent)this).GetChild($"Island{i}") is UI_BossCardBtn uI_BossCardBtn && ((GObject)uI_BossCardBtn).visible && uI_BossCardBtn.ShowCountDown.selectedIndex != 2 && !uI_BossCardBtn.ZeroToTwo.playing)
				{
					uI_BossCardBtn?.AppearOnStage3();
				}
			}
		});
		((GObject)ClickMask).touchable = true;
		StageChange2to3.Play((PlayCompleteCallback)delegate
		{
			SetStageIndex(newIndex, izId);
			foreach (KeyValuePair<string, GButton> item in Dict_BossCard)
			{
				if (item.Value is UI_BossCardBtn)
				{
					UI_BossCardBtn uI_BossCardBtn = item.Value as UI_BossCardBtn;
					((GObject)uI_BossCardBtn.SpineLoader).visible = StageController.selectedIndex != 2;
				}
			}
			((GObject)ClickMask).touchable = false;
			StageChangePlaying = false;
		});
	}

	private void PlayStageOneToTwo(int newIndex, string izId)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		StageChange1to2.SetHook("ui_gvg_card_explosion_1", (TransitionHook)delegate
		{
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			foreach (KeyValuePair<string, GButton> item in Dict_BossCard)
			{
				if (item.Value is UI_BossCardBtn)
				{
					UI_BossCardBtn uI_BossCardBtn = item.Value as UI_BossCardBtn;
					uI_BossCardBtn.Disappaer();
				}
			}
			FGUIManager.Instance.AddTextSpecialEffects(SfxLoader, "ui_gvg_bosscard_appear_chain", new Vector3(100f, 100f, 100f));
		});
		StageChange1to2.SetHook("islandDIsappear", (TransitionHook)delegate
		{
			foreach (KeyValuePair<string, GButton> item2 in Dict_BossCard)
			{
				if (item2.Value is UI_BossCardBtn)
				{
					UI_BossCardBtn uI_BossCardBtn = item2.Value as UI_BossCardBtn;
					((GObject)uI_BossCardBtn.SpineLoader).visible = false;
				}
			}
		});
		GTweenCallback val = default(GTweenCallback);
		StageChange1to2.SetHook("BeginRoll", (TransitionHook)delegate
		{
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			GTweener obj = ((GComponent)(object)this).SetTimeout(0.5f);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					((GObject)Island7.Island7.SpineLoader).visible = true;
				};
				GTweenCallback val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.OnComplete(obj2);
			IslandsMapPic.StageController.selectedIndex = newIndex;
			FGUIManager.Instance.AddTextSpecialEffects(BosscardAppearMask, "ui_gvg_bosscard_appear_mask", new Vector3(100f, 100f, 100f));
			FGUIManager.Instance.AddTextSpecialEffects(BosscardAppear, "ui_gvg_bosscard_appear", new Vector3(100f, 100f, 100f));
		});
		((GObject)ClickMask).touchable = true;
		ShowBigBossAbilityPlayed = true;
		StageChange1to2.Play((PlayCompleteCallback)delegate
		{
			SetStageIndex(newIndex, izId);
			((GObject)ClickMask).touchable = false;
			StageChangePlaying = false;
		});
	}
}
