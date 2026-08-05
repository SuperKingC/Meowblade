using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common;
using Shift.Legion.GvG.Common.Model;
using Shift.Legion.GvGServer.Models.Map;
using Shift.Legion.GvGServer.Models.WorldBossSocket;
using Spine.Unity;
using UI.GameEndPanels;
using UI.GvGBattleRecords;
using UnityEngine;

namespace UI.LordOfDreams;

public class UI_LordOfDreamsPanel : GComponent, IUiController
{
	public Controller StateController;

	public GLoader background;

	public UI_BattlefieldAnimWrapper BattlefieldAnimWrapper;

	public UI_IslandAnimWrapper IslandAnimWrapper;

	public GGraph SpineLoader;

	public Transition ZoomIn;

	public Transition ZoomOut;

	public const string URL = "ui://0i520nzmzsih16";

	public static string Name = "UI_LordOfDreamsPanel";

	private UI_IslandScreenAdaptWrapper IslandPanel;

	private UI_BattlefieldScreenAdaptWrapper BattlefieldPanel;

	private UI_MyDamagePanel MyDamagePanel;

	private GvGProcessInfo BossConfig;

	private GvGWorldBossInfo GvGConfigBossInfo;

	private float StartPlayingTime;

	private S2C_BattleResult.Request BattleResultRequest;

	private List<GvGWorldBossRecordRanking2Response> LeaderboardData;

	private int MyShipCount = -1;

	private float MyRankingPercent;

	private FinalBossDamageRewardTable DamageRewards;

	private SkeletonAnimation MapCloudAnim;

	private Coroutine GetLeaderboardCoroutine;

	public static string GetURL()
	{
		return "ui://0i520nzmzsih16";
	}

	public static UI_LordOfDreamsPanel CreateInstance()
	{
		return (UI_LordOfDreamsPanel)(object)UIPackage.CreateObject("LordOfDreams", "LordOfDreamsPanel");
	}

	public static UI_LordOfDreamsPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LordOfDreamsPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmzsih16", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StateController = ((GComponent)this).GetController("StateController");
		background = (GLoader)((GComponent)this).GetChild("background");
		BattlefieldAnimWrapper = (UI_BattlefieldAnimWrapper)(object)((GComponent)this).GetChild("BattlefieldAnimWrapper");
		IslandAnimWrapper = (UI_IslandAnimWrapper)(object)((GComponent)this).GetChild("IslandAnimWrapper");
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
		ZoomIn = ((GComponent)this).GetTransition("ZoomIn");
		ZoomOut = ((GComponent)this).GetTransition("ZoomOut");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		if (parameters.TryGetValue("SelectedBossConfig", out var value))
		{
			BossConfig = (GvGProcessInfo)value;
		}
		MyRankingPercent = -1f;
		IslandPanel = IslandAnimWrapper.IslandScreenAdaptWrapper;
		BattlefieldPanel = BattlefieldAnimWrapper.BattlefieldScreenAdaptWrapper;
		MyDamagePanel = IslandPanel.MyDamagePanel;
		GameController.Contexts.Service<IUiService>().PushBackupAndCloseAllUIs(new List<string>
		{
			Name,
			UI_DamageMeter.Name,
			UI_GvGBattleRecordsPanel.Name,
			UI_GvGBattleRecordDetailPanel.Name
		});
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		FGUIManager.SetToFullScreen((GObject)(object)this);
		((GObject)IslandPanel).SetSize(((GObject)this).width, ((GObject)this).height);
		((GObject)BattlefieldPanel).SetSize(((GObject)this).width, ((GObject)this).height);
		StateController.selectedIndex = 0;
		LeaderboardData = new List<GvGWorldBossRecordRanking2Response>(5) { null, null, null, null, null };
		IslandPanel.DamageLeaderboard.List.SetVirtual();
		IslandPanel.DamageLeaderboard.List.itemRenderer = new ListItemRenderer(LeaderboardSlotRenderer);
		IslandPanel.DamageLeaderboard.List.numItems = 0;
		UiHelper.LoadSpine_AB(SpineLoader, "Map_Cloud", 100f, delegate(SkeletonAnimation animation)
		{
			MapCloudAnim = animation;
			((Behaviour)MapCloudAnim).enabled = false;
		});
		GetSelfShipCount();
		GvGWorldController.CreateInstance();
		GvGWorldController.Instance.ConnectToIsland(BossConfig);
		RenderBossAbilities();
		RenderMyDamagePanel();
		GetLeaderboardCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetLeaderboardsPerMinutes());
		GvGConfigHelper.ReStartUiParamsAdd(Name, parameters);
		GvGConfigBossInfo = GvGConfigHelper.GetGvGWorldBossInfoByWBId(BossConfig.BossInfo.WBId);
		((GObject)IslandPanel.BossHealthBar.BossName).text = GvGConfigBossInfo.BossName;
		((GObject)BattlefieldPanel.BossHealthBar.BossName).text = GvGConfigBossInfo.BossName;
		BattlefieldPanel.MyBattleInfo.Init(BossConfig.BossInfo.WBId);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().RecoverLastBackup();
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void RegisterUiEventListeners()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		UI_IslandScreenAdaptWrapper islandScreenAdaptWrapper = IslandAnimWrapper.IslandScreenAdaptWrapper;
		((GObject)islandScreenAdaptWrapper.BackBtn).onClick.Set(new EventCallback0(End));
		((GObject)islandScreenAdaptWrapper.MyDamagePanel.MyDamageBtn).onClick.Set(new EventCallback0(OnSwitchMyDamagePanel));
		islandScreenAdaptWrapper.DamageLeaderboard.PageController.onChanged.Set(new EventCallback0(UpdateLeaderboard));
		((GObject)islandScreenAdaptWrapper.BattleLogBtn).onClick.Set(new EventCallback0(OpenGvGBattleRecordsPanel));
		((GObject)background).onClick.Set(new EventCallback1(OnClickScreen));
		UI_BattlefieldScreenAdaptWrapper battlefieldScreenAdaptWrapper = BattlefieldAnimWrapper.BattlefieldScreenAdaptWrapper;
		((GObject)battlefieldScreenAdaptWrapper.BackBtn).onClick.Set(new EventCallback0(OnClickZoomOut));
		battlefieldScreenAdaptWrapper.MyBattleInfo.RegisterUiEventListeners();
		((GObject)battlefieldScreenAdaptWrapper.BattleLogBtn).onClick.Set(new EventCallback0(OnClickBattleLog));
		GvGIZManager instance = GvGIZManager.Instance;
		instance.OnDataLoaded = (Action)Delegate.Combine(instance.OnDataLoaded, new Action(OnIZDataLoaded));
		SharedMessenger.AddListener<int>("ON_GVG_MAP_VIEW_LEVEL_CHANGE", OnMapViewLevelChange);
		SharedMessenger.AddListener<S2C_BattleResult.Request>("ON_GVG_BATTLE_END", OnGvGBattleEnd);
		SharedMessenger.AddListener<ArchiveExtension_WorldBossRecord.Model>("ON_GVG_BATTLE_RESULT", OnGvGBattleResult);
		SharedMessenger.AddListener<BossHealth>("ON_GVG_BOSS_HP_CHANGE", OnBossHpChange);
		SharedMessenger.AddListener<bool>("ON_GVG_BOSS_DEAD", OnBossDead);
	}

	public void UnregisterUiEventListeners()
	{
		UI_IslandScreenAdaptWrapper islandScreenAdaptWrapper = IslandAnimWrapper.IslandScreenAdaptWrapper;
		((GObject)islandScreenAdaptWrapper.BackBtn).onClick.Clear();
		((GObject)islandScreenAdaptWrapper.MyDamagePanel.MyDamageBtn).onClick.Clear();
		islandScreenAdaptWrapper.DamageLeaderboard.PageController.onChanged.Clear();
		((GObject)islandScreenAdaptWrapper.BattleLogBtn).onClick.Clear();
		((GObject)background).onClick.Clear();
		UI_BattlefieldScreenAdaptWrapper battlefieldScreenAdaptWrapper = BattlefieldAnimWrapper.BattlefieldScreenAdaptWrapper;
		((GObject)battlefieldScreenAdaptWrapper.BackBtn).onClick.Clear();
		battlefieldScreenAdaptWrapper.MyBattleInfo.UnregisterUiEventListeners();
		((GObject)battlefieldScreenAdaptWrapper.BattleLogBtn).onClick.Clear();
		GvGIZManager instance = GvGIZManager.Instance;
		instance.OnDataLoaded = (Action)Delegate.Remove(instance.OnDataLoaded, new Action(OnIZDataLoaded));
		SharedMessenger.RemoveListener<int>("ON_GVG_MAP_VIEW_LEVEL_CHANGE", OnMapViewLevelChange);
		SharedMessenger.RemoveListener<S2C_BattleResult.Request>("ON_GVG_BATTLE_END", OnGvGBattleEnd);
		SharedMessenger.RemoveListener<ArchiveExtension_WorldBossRecord.Model>("ON_GVG_BATTLE_RESULT", OnGvGBattleResult);
		SharedMessenger.RemoveListener<bool>("ON_GVG_BOSS_DEAD", OnBossDead);
	}

	private void RenderMyDamagePanel()
	{
		string iZId = BossConfig.IZId;
		DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.ServerNow, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
		string key = $"{dailyRefreshTime.Year}_{dailyRefreshTime.Month}_{dailyRefreshTime.Day}";
		ArchiveExtension_WorldBossRecord.Model worldBossRecordModel = GameManagers.Instance.UserArchiveManager.GetWorldBossRecordModel();
		((GObject)MyDamagePanel.List).visible = false;
		if (!worldBossRecordModel.Records.TryGetValue(iZId, out var value) || !value.EveryDayRecords.TryGetValue(key, out var value2))
		{
			return;
		}
		((GObject)MyDamagePanel.List).visible = true;
		List<OnRewardUserModel> bossTop = value2.GetBossTop3(BossConfig.BossInfo.WBId);
		for (int i = 0; i < 3; i++)
		{
			UI_MyDamageSlot uI_MyDamageSlot = (UI_MyDamageSlot)(object)((GComponent)MyDamagePanel.List).GetChildAt(i).asCom;
			if (i >= bossTop.Count)
			{
				((GObject)uI_MyDamageSlot).visible = false;
				continue;
			}
			OnRewardUserModel onRewardUserModel = bossTop[i];
			uI_MyDamageSlot.NumberController.selectedIndex = i;
			((GObject)uI_MyDamageSlot.DamageText).text = onRewardUserModel.TotalDamage.ShortNumberFormat() ?? "";
			GvGWorldBossInfo gvGWorldBossInfoByWBId = GvGConfigHelper.GetGvGWorldBossInfoByWBId(onRewardUserModel.WBId);
			if (gvGWorldBossInfoByWBId != null)
			{
				uI_MyDamageSlot.Avatar.HeadPortrait.Type.selectedIndex = 1;
				uI_MyDamageSlot.Avatar.HeadPortrait.icon.url = "ui://PublicResources/" + gvGWorldBossInfoByWBId.Icon;
			}
		}
	}

	private void GetSelfShipCount()
	{
		MyShipCount = -1;
		ILRequestHelper<GvGGetSelfShipCountResponse>.Request((EventContext)null, (Func<Task<GvGGetSelfShipCountResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGGetSelfShipCount(BossConfig.IZId)), (Action<GvGGetSelfShipCountResponse>)delegate(GvGGetSelfShipCountResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				MyShipCount = response.Count;
			}
		});
	}

	private void GetLeaderboardByPageNumber(int page, Action<GvGWorldBossRecordRanking2Response> OnLoaded)
	{
		int islandId = BossConfig.IslandId;
		string key = "";
		switch (page)
		{
		case 0:
			key = "HistoryMax";
			break;
		case 1:
		{
			DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.ServerNow, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
			key = $"{dailyRefreshTime.Year}_{dailyRefreshTime.Month}_{dailyRefreshTime.Day}";
			break;
		}
		case 2:
			key = "HistoryMax3";
			break;
		case 3:
			key = "Max3Summary";
			break;
		}
		ILRequestHelper<GvGWorldBossRecordRanking2Response>.Request((EventContext)null, (Func<Task<GvGWorldBossRecordRanking2Response>>)(() => GameController.Contexts.Service<INetworkService>().GvGWorldBossRecordRanking2(BossConfig.IZId, BossConfig.BossInfo.WBId, key)), (Action<GvGWorldBossRecordRanking2Response>)delegate(GvGWorldBossRecordRanking2Response response)
		{
			if (!response.Result)
			{
				ILRuntimeDebug.LogError("GvGWorldBossRecordRanking 请求失败！");
			}
			else if (response.Model != null)
			{
				OnLoaded?.Invoke(response);
			}
		});
	}

	private IEnumerator GetLeaderboardsPerMinutes()
	{
		while (true)
		{
			GetLeaderboardsData();
			yield return (object)new WaitForSeconds(300f);
		}
	}

	private void GetLeaderboardsData()
	{
		if (BossConfig.IslandId != 7)
		{
			IslandPanel.DamageLeaderboard.PageController.selectedIndex = 0;
			GetLeaderboardByPageNumber(0, delegate(GvGWorldBossRecordRanking2Response model)
			{
				LeaderboardData[0] = model;
				UpdateLeaderboard();
			});
			GetLeaderboardByPageNumber(1, delegate(GvGWorldBossRecordRanking2Response model)
			{
				LeaderboardData[1] = model;
				UpdateLeaderboard();
			});
			return;
		}
		if (GvGIZManager.Instance.GetInstanceZoneInfo(BossConfig.IZId).IZProgress == 1)
		{
			IslandPanel.DamageLeaderboard.PageController.selectedIndex = 2;
		}
		else
		{
			IslandPanel.DamageLeaderboard.PageController.selectedIndex = 4;
		}
		GetLeaderboardByPageNumber(2, delegate(GvGWorldBossRecordRanking2Response model)
		{
			LeaderboardData[2] = model;
			LeaderboardData[4] = model;
			UpdateLeaderboard();
		});
		GvGIZManager.Instance.LoadDataOnce();
		GetLeaderboardByPageNumber(3, delegate(GvGWorldBossRecordRanking2Response model)
		{
			MyRankingPercent = ((model.TotalRank == 0 || model.SelfRank < 0) ? (-1f) : ((float)(model.SelfRank + 1) / (float)model.TotalRank));
			UI_DamageLeaderboard damageLeaderboard = IslandPanel.DamageLeaderboard;
			damageLeaderboard.DamageRewardList.numItems = DamageRewards.row.Count;
		});
	}

	private void UpdateLeaderboard()
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		((GObject)IslandPanel.DamageLeaderboard.Mine).visible = false;
		((GObject)IslandPanel.DamageLeaderboard.MineNew).visible = false;
		GvGWorldBossRecordRanking2Response gvGWorldBossRecordRanking2Response = LeaderboardData[IslandPanel.DamageLeaderboard.PageController.selectedIndex];
		if (gvGWorldBossRecordRanking2Response == null)
		{
			IslandPanel.DamageLeaderboard.List.numItems = 0;
			return;
		}
		if (gvGWorldBossRecordRanking2Response.SelfRank != -1)
		{
			((GObject)IslandPanel.DamageLeaderboard.Mine).visible = true;
			((GObject)IslandPanel.DamageLeaderboard.MineNew).visible = true;
			RenderSingleLeaderboardSlot(IslandPanel.DamageLeaderboard.Mine, gvGWorldBossRecordRanking2Response.SelfRank, gvGWorldBossRecordRanking2Response.SelfDamage, GameController.Contexts.gameState.user.value.UserId);
		}
		IslandPanel.DamageLeaderboard.List.numItems = gvGWorldBossRecordRanking2Response.Model.RankModels.Count;
	}

	private void LeaderboardSlotRenderer(int index, GObject obj)
	{
		GvGWorldBossRecordRanking2Response gvGWorldBossRecordRanking2Response = LeaderboardData[IslandPanel.DamageLeaderboard.PageController.selectedIndex];
		if (gvGWorldBossRecordRanking2Response != null)
		{
			RankModel rankModel = gvGWorldBossRecordRanking2Response.Model.RankModels[index];
			RenderSingleLeaderboardSlot((UI_DamageLeaderboardSlot)(object)obj, index, rankModel.TotalDamage, rankModel.UserId);
		}
	}

	private void RenderSingleLeaderboardSlot(UI_DamageLeaderboardSlot slot, int ranking, string damage, int userId)
	{
		ranking++;
		((GObject)slot.DamageText).text = long.Parse(damage).ShortNumberFormat();
		((GObject)slot.Ranking).text = ranking.ToString();
		if (ranking < 4)
		{
			slot.TypeController.selectedIndex = ranking;
		}
		else
		{
			slot.TypeController.selectedIndex = 0;
		}
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, userId, slot.Avatar.HeadPortrait.icon, slot.PlayerName));
	}

	private void RenderBossAbilities()
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		GList abilities = IslandPanel.BossHealthBar.Abilities;
		GList abilities2 = BattlefieldPanel.BossHealthBar.Abilities;
		abilities.RemoveChildrenToPool();
		List<Ability> bossAbilities = BossConfig.BossInfo.GetBossAbilities();
		if (bossAbilities == null)
		{
			return;
		}
		foreach (Ability item in bossAbilities)
		{
			if (item.GetAbilityLevel() != 0)
			{
				UI_BossAbility uI_BossAbility = (UI_BossAbility)(object)abilities.AddItemFromPool();
				uI_BossAbility.Icon.url = item.GetAbilityIcon();
				((GObject)uI_BossAbility.Title).text = item.GetAbilityLevelAndName();
				((GObject)uI_BossAbility).onClick.Set(new EventCallback0(item.ShowSkillDetailPopup));
				uI_BossAbility = (UI_BossAbility)(object)abilities2.AddItemFromPool();
				uI_BossAbility.Icon.url = item.GetAbilityIcon();
				((GObject)uI_BossAbility.Title).text = item.GetAbilityLevelAndName();
				((GObject)uI_BossAbility).onClick.Set(new EventCallback0(item.ShowSkillDetailPopup));
			}
		}
	}

	private void DamageRewardRerderer(int index, GObject obj)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		FinalBossDamageRewardTable_Row finalBossDamageRewardTable_Row = DamageRewards.row[index];
		UI_DamageRewardSlot2 uI_DamageRewardSlot = (UI_DamageRewardSlot2)(object)obj;
		List<FinalBossDamageRewardTable_Row_R> bonuses = finalBossDamageRewardTable_Row.r;
		uI_DamageRewardSlot.RankingController.selectedIndex = index;
		uI_DamageRewardSlot.BonusList.SetVirtual();
		uI_DamageRewardSlot.BonusList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			UI_DamageBonusItem uI_DamageBonusItem = (UI_DamageBonusItem)(object)o;
			int number = (int)NumericParser.Float(bonuses[i].cnt);
			((GObject)uI_DamageBonusItem.num).text = number.ShortNumberFormat() ?? "";
			FGUIManager.Instance.SetItemIconAndFrame(uI_DamageBonusItem.rewardIcon, bonuses[i].ItemId, null, "", frameVisible: false);
		};
		uI_DamageRewardSlot.BonusList.numItems = bonuses.Count;
		if (NumericParser.Float(finalBossDamageRewardTable_Row.min) < MyRankingPercent && MyRankingPercent <= NumericParser.Float(finalBossDamageRewardTable_Row.max))
		{
			uI_DamageRewardSlot.ShowMyRank.selectedIndex = 1;
		}
		else
		{
			uI_DamageRewardSlot.ShowMyRank.selectedIndex = 0;
		}
	}

	private void OnIZDataLoaded()
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		if (!((GObject)this).isDisposed && DamageRewards == null)
		{
			DamageRewards = GvGIZManager.Instance.GetDamageRewardTable(BossConfig.IZId);
			if (DamageRewards != null)
			{
				UI_DamageLeaderboard damageLeaderboard = IslandPanel.DamageLeaderboard;
				damageLeaderboard.DamageRewardList.SetVirtual();
				damageLeaderboard.DamageRewardList.itemRenderer = new ListItemRenderer(DamageRewardRerderer);
				damageLeaderboard.DamageRewardList.numItems = DamageRewards.row.Count;
			}
		}
	}

	private void OnClickScreen(EventContext context)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(context.inputEvent.x, context.inputEvent.y);
		val.y = (float)Screen.height - val.y;
		Ray val2 = Camera.main.ScreenPointToRay(Vector2.op_Implicit(val));
		RaycastHit val3 = default(RaycastHit);
		if (!Physics.Raycast(val2, ref val3, 10000f))
		{
			return;
		}
		GameObject gameObject = ((Component)((RaycastHit)(ref val3)).collider).gameObject;
		if (!(((Object)gameObject).name == "AvatarIcon"))
		{
			return;
		}
		UI_GvGAvatarWrapper uI_GvGAvatarWrapper = (UI_GvGAvatarWrapper)(object)gameObject.GetComponent<UIPanel>().ui;
		BroadcastGroupInitInfo broadcastGroupInitInfo = (BroadcastGroupInitInfo)((GObject)uI_GvGAvatarWrapper).data;
		if (broadcastGroupInitInfo.IsBoss && StateController.selectedIndex == 0 && MyShipCount != -1)
		{
			if (MyShipCount < 1)
			{
				OnSelectSoldier();
				return;
			}
			if (GvGWorldController.Instance.UserGroups != null && GvGWorldController.Instance.UserGroups.Count > 0)
			{
				OnClickPlayZoomIn();
				return;
			}
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText422") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
	}

	private void OnSelectSoldier()
	{
		Dictionary<string, object> parameters = new Dictionary<string, object> { 
		{
			"Actions",
			new Dictionary<string, Action> { 
			{
				"OnStartBattleCallback",
				delegate
				{
					GetSelfShipCount();
				}
			} }
		} };
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGSelectSoldierPanel.Name, parameters);
	}

	private void OpenGvGBattleRecordsPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGBattleRecordsPanel.Name, new Dictionary<string, object>
		{
			{ "IZConfigId", BossConfig.IZConfigId },
			{ "IZId", BossConfig.IZId }
		});
	}

	private void OnMapViewLevelChange(int mapViewLevel)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		if (mapViewLevel == 1)
		{
			if (ZoomOut.playing)
			{
				float num = Time.time - StartPlayingTime;
				ZoomOut.Stop();
				ZoomIn.Play(1, 0f, 1.208f - num, 1.208f, (PlayCompleteCallback)delegate
				{
					StateController.selectedIndex = 1;
				});
			}
			else if (((GObject)BattlefieldAnimWrapper).scale.x != 1f)
			{
				ZoomIn.Play((PlayCompleteCallback)delegate
				{
					StateController.selectedIndex = 1;
				});
				StartPlayingTime = Time.time;
			}
		}
		else if (ZoomIn.playing)
		{
			float num2 = Time.time - StartPlayingTime;
			ZoomIn.Stop();
			ZoomOut.Play(1, 0f, 1.208f - num2, 1.208f, (PlayCompleteCallback)delegate
			{
				StateController.selectedIndex = 0;
			});
		}
		else if (((GObject)IslandAnimWrapper).scale.x != 1f)
		{
			ZoomOut.Play((PlayCompleteCallback)delegate
			{
				StateController.selectedIndex = 0;
			});
			StartPlayingTime = Time.time;
		}
	}

	private void OnClickPlayZoomIn()
	{
		GvGWorldController.Instance.ChangeCameraBindingRequest(eMapViewLevel.BattleField);
	}

	private void OnClickZoomOut()
	{
		GvGWorldController.Instance.ChangeCameraBindingRequest(eMapViewLevel.Island);
	}

	private void OnSwitchMyDamagePanel()
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		if (MyDamagePanel.Collapse.playing || MyDamagePanel.Expand.playing)
		{
			return;
		}
		if (MyDamagePanel.StateController.selectedIndex == 0)
		{
			MyDamagePanel.Expand.Play((PlayCompleteCallback)delegate
			{
				MyDamagePanel.StateController.selectedIndex = 1;
			});
		}
		else
		{
			MyDamagePanel.Collapse.Play((PlayCompleteCallback)delegate
			{
				MyDamagePanel.StateController.selectedIndex = 0;
			});
		}
	}

	private void OnGvGBattleEnd(S2C_BattleResult.Request req)
	{
		((GObject)this).touchable = false;
		BattleResultRequest = req;
	}

	private void OnGvGBattleResult(ArchiveExtension_WorldBossRecord.Model model)
	{
		Dictionary<string, object> param = new Dictionary<string, object>
		{
			{ "BattleResultRequest", BattleResultRequest },
			{ "WorldBossRecord", model },
			{
				"Actions",
				new Dictionary<string, Action> { 
				{
					"OnClose",
					delegate
					{
						End();
					}
				} }
			}
		};
		ScriptApi.CreateTimer(1f, delegate
		{
			if ((Object)(object)GvGWorldController.Instance != (Object)null)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGBattleEndPanel.Name, param);
			}
		});
	}

	private void OnBossHpChange(BossHealth bossHealth)
	{
		((GProgressBar)IslandPanel.BossHealthBar.HealthBar).max = bossHealth.MaxHp;
		((GProgressBar)IslandPanel.BossHealthBar.HealthBar).value = bossHealth.CurHp;
		((GObject)IslandPanel.BossHealthBar.HpText).text = $"{bossHealth.CurHp}/{bossHealth.MaxHp}";
		((GObject)IslandPanel.BossHealthBar).visible = true;
		((GProgressBar)BattlefieldPanel.BossHealthBar.HealthBar).max = bossHealth.MaxHp;
		((GProgressBar)BattlefieldPanel.BossHealthBar.HealthBar).value = bossHealth.CurHp;
		((GObject)BattlefieldPanel.BossHealthBar.HpText).text = $"{bossHealth.CurHp}/{bossHealth.MaxHp}";
		((GObject)BattlefieldPanel.BossHealthBar).visible = true;
	}

	private void OnBossDead(bool IsUserGroupFighting)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		string bossName = GvGConfigHelper.GetGvGWorldBossInfoByWBId(BossConfig.BossInfo.WBId).BossName;
		List<string> arg = new List<string> { bossName + LanguagesManager.GetDesc("CsharpCodeZhTcText420") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		if (!IsUserGroupFighting)
		{
			((GComponent)(object)this).SetTimeout(0.8f).OnComplete((GTweenCallback)delegate
			{
				End();
			});
		}
	}

	private void OnClickBattleLog()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGSingleBattleRecordPanel.Name, new Dictionary<string, object>
		{
			{ "IZConfigId", BossConfig.IZConfigId },
			{ "IZId", BossConfig.IZId }
		});
	}

	public void OnShow()
	{
		UI_IslandScreenAdaptWrapper islandScreenAdaptWrapper = IslandAnimWrapper.IslandScreenAdaptWrapper;
		UiTagManager.Instance.Register("GvG.SelectSoldierPopup", islandScreenAdaptWrapper.BossIconGuider);
		SharedMessenger.Broadcast("ON_GVG_LORDOFDREAM_PANEL_SHOW");
	}

	public void BeforeDestroy()
	{
		BattlefieldPanel.MyBattleInfo.Destroy();
		if (GetLeaderboardCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(GetLeaderboardCoroutine);
		}
	}

	public void Destroy()
	{
		UI_IslandScreenAdaptWrapper islandScreenAdaptWrapper = IslandAnimWrapper.IslandScreenAdaptWrapper;
		UiTagManager.Instance.Unregister("GvG.SelectSoldierPopup", islandScreenAdaptWrapper.BossIconGuider);
		Singleton<CameraService>.Instance.SwitchToScene("MainCity.Right");
		if ((Object)(object)GvGWorldController.Instance != (Object)null)
		{
			GvGWorldController.ReleaseInstance();
		}
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
	}
}
