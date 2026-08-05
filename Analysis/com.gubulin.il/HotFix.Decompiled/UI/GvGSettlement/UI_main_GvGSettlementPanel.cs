using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.ObserverStat;
using Spine.Unity;
using UI.GvG3Leaderboard;
using UnityEngine;

namespace UI.GvGSettlement;

public class UI_main_GvGSettlementPanel : GComponent, IUiController
{
	public Controller PageController;

	public Controller TrophyCount;

	public Controller HasWaitToClaim;

	public Controller HasBestKill;

	public Controller CampId;

	public Controller HideBonus;

	public GLoader background;

	public GImage n180;

	public GImage n170;

	public GLoader n172;

	public GImage n176;

	public GImage n174;

	public GImage n177;

	public GImage n191;

	public GImage n173;

	public UI_com_Title Title;

	public GButton BackBtn1;

	public UI_com_Avatar PlayerAvatar;

	public GTextField PlayerName;

	public GTextField Date;

	public GTextField n106;

	public GGroup n108;

	public GImage n175;

	public GTextField n109;

	public UI_com_PlayerTrophy Trophy_0;

	public UI_com_PlayerTrophy Trophy_1;

	public UI_com_PlayerTrophy Trophy_2;

	public UI_btn_PageTab0 Tab0;

	public UI_btn_PageTab1 Tab1;

	public GImage n185;

	public GImage n181;

	public GTextField n187;

	public GTextField n189;

	public GTextField n188;

	public GImage n186;

	public GImage n182;

	public GImage n134;

	public GImage n190;

	public GImage n183;

	public GImage n184;

	public GList CampRanking;

	public GTextField n135;

	public GList CampBonusList;

	public UI_com_LeaderboardBonus Board1;

	public UI_com_LeaderboardBonus Board2;

	public UI_com_LeaderboardBonus Board3;

	public UI_btn_ExpeditionBoardEntry ExpeditionBoardEntry;

	public UI_btn_EternalNightBoardEntry EternalNightBoardEntry;

	public UI_btn_EternalNightBoardEntry EternalNightBoardEntry2;

	public UI_btn_Back BackBtn;

	public UI_btn_ClaimAll ClaimAllBtn;

	public UI_com_AmplifierScore AmplifierScore;

	public GGroup n196;

	public GTextField n198;

	public GGroup BonusGroup;

	public GList InfoList;

	public UI_btn_Back BackBtn2;

	public UI_com_Scroll n192;

	public GGroup InfoGroup;

	public GImage n178;

	public GTextField n119;

	public GGraph SpineLoader;

	public GTextField ShipName;

	public GList Soldiers;

	public GTextField n124;

	public GTextField MaxKillCount;

	public GGroup n179;

	public GGroup n166;

	public GTextField n167;

	public Transition t0;

	public const string URL = "ui://91jxdrkam9ta0";

	public static string Name = "UI_main_GvGSettlementPanel";

	private UICallbackParam<Action> OnClose;

	private ShipAnimCacheManager ShipAnimCacheManager;

	private List<StatData> StatList;

	private List<RItem> CampRankingBonuses;

	private string _izId;

	private bool IsBrawlFight => WorldMapConfigHelper.IsBrawlFightEvent(_izId);

	public static string GetURL()
	{
		return "ui://91jxdrkam9ta0";
	}

	public static UI_main_GvGSettlementPanel CreateInstance()
	{
		return (UI_main_GvGSettlementPanel)(object)UIPackage.CreateObject("GvGSettlement", "main_GvGSettlementPanel");
	}

	public static UI_main_GvGSettlementPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvGSettlementPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkam9ta0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected O, but got Unknown
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Expected O, but got Unknown
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Expected O, but got Unknown
		//IL_0442: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Expected O, but got Unknown
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Expected O, but got Unknown
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Expected O, but got Unknown
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Expected O, but got Unknown
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Expected O, but got Unknown
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ba: Expected O, but got Unknown
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_050f: Expected O, but got Unknown
		//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05eb: Expected O, but got Unknown
		//IL_05f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0601: Expected O, but got Unknown
		//IL_064c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0656: Expected O, but got Unknown
		//IL_0662: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Expected O, but got Unknown
		//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ae: Expected O, but got Unknown
		//IL_06ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c4: Expected O, but got Unknown
		//IL_06d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06da: Expected O, but got Unknown
		//IL_0725: Unknown result type (might be due to invalid IL or missing references)
		//IL_072f: Expected O, but got Unknown
		//IL_073b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0745: Expected O, but got Unknown
		//IL_0751: Unknown result type (might be due to invalid IL or missing references)
		//IL_075b: Expected O, but got Unknown
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		//IL_0771: Expected O, but got Unknown
		//IL_07bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c6: Expected O, but got Unknown
		//IL_07d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07dc: Expected O, but got Unknown
		//IL_07e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f2: Expected O, but got Unknown
		//IL_07fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0808: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		TrophyCount = ((GComponent)this).GetController("TrophyCount");
		HasWaitToClaim = ((GComponent)this).GetController("HasWaitToClaim");
		HasBestKill = ((GComponent)this).GetController("HasBestKill");
		CampId = ((GComponent)this).GetController("CampId");
		HideBonus = ((GComponent)this).GetController("HideBonus");
		background = (GLoader)((GComponent)this).GetChild("background");
		n180 = (GImage)((GComponent)this).GetChild("n180");
		n170 = (GImage)((GComponent)this).GetChild("n170");
		n172 = (GLoader)((GComponent)this).GetChild("n172");
		n176 = (GImage)((GComponent)this).GetChild("n176");
		n174 = (GImage)((GComponent)this).GetChild("n174");
		n177 = (GImage)((GComponent)this).GetChild("n177");
		n191 = (GImage)((GComponent)this).GetChild("n191");
		n173 = (GImage)((GComponent)this).GetChild("n173");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		BackBtn1 = (GButton)((GComponent)this).GetChild("BackBtn1");
		PlayerAvatar = (UI_com_Avatar)(object)((GComponent)this).GetChild("PlayerAvatar");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		Date = (GTextField)((GComponent)this).GetChild("Date");
		n106 = (GTextField)((GComponent)this).GetChild("n106");
		string id = "ui://91jxdrkam9ta0".Replace("ui://", "") + "-" + ((GObject)n106).id;
		((GObject)n106).text = LanguagesManager.GetDesc(id);
		n108 = (GGroup)((GComponent)this).GetChild("n108");
		n175 = (GImage)((GComponent)this).GetChild("n175");
		n109 = (GTextField)((GComponent)this).GetChild("n109");
		string id2 = "ui://91jxdrkam9ta0".Replace("ui://", "") + "-" + ((GObject)n109).id;
		((GObject)n109).text = LanguagesManager.GetDesc(id2);
		Trophy_0 = (UI_com_PlayerTrophy)(object)((GComponent)this).GetChild("Trophy_0");
		Trophy_1 = (UI_com_PlayerTrophy)(object)((GComponent)this).GetChild("Trophy_1");
		Trophy_2 = (UI_com_PlayerTrophy)(object)((GComponent)this).GetChild("Trophy_2");
		Tab0 = (UI_btn_PageTab0)(object)((GComponent)this).GetChild("Tab0");
		Tab1 = (UI_btn_PageTab1)(object)((GComponent)this).GetChild("Tab1");
		n185 = (GImage)((GComponent)this).GetChild("n185");
		n181 = (GImage)((GComponent)this).GetChild("n181");
		n187 = (GTextField)((GComponent)this).GetChild("n187");
		string id3 = "ui://91jxdrkam9ta0".Replace("ui://", "") + "-" + ((GObject)n187).id;
		((GObject)n187).text = LanguagesManager.GetDesc(id3);
		n189 = (GTextField)((GComponent)this).GetChild("n189");
		string id4 = "ui://91jxdrkam9ta0".Replace("ui://", "") + "-" + ((GObject)n189).id;
		((GObject)n189).text = LanguagesManager.GetDesc(id4);
		n188 = (GTextField)((GComponent)this).GetChild("n188");
		string id5 = "ui://91jxdrkam9ta0".Replace("ui://", "") + "-" + ((GObject)n188).id;
		((GObject)n188).text = LanguagesManager.GetDesc(id5);
		n186 = (GImage)((GComponent)this).GetChild("n186");
		n182 = (GImage)((GComponent)this).GetChild("n182");
		n134 = (GImage)((GComponent)this).GetChild("n134");
		n190 = (GImage)((GComponent)this).GetChild("n190");
		n183 = (GImage)((GComponent)this).GetChild("n183");
		n184 = (GImage)((GComponent)this).GetChild("n184");
		CampRanking = (GList)((GComponent)this).GetChild("CampRanking");
		n135 = (GTextField)((GComponent)this).GetChild("n135");
		string id6 = "ui://91jxdrkam9ta0".Replace("ui://", "") + "-" + ((GObject)n135).id;
		((GObject)n135).text = LanguagesManager.GetDesc(id6);
		CampBonusList = (GList)((GComponent)this).GetChild("CampBonusList");
		Board1 = (UI_com_LeaderboardBonus)(object)((GComponent)this).GetChild("Board1");
		Board2 = (UI_com_LeaderboardBonus)(object)((GComponent)this).GetChild("Board2");
		Board3 = (UI_com_LeaderboardBonus)(object)((GComponent)this).GetChild("Board3");
		ExpeditionBoardEntry = (UI_btn_ExpeditionBoardEntry)(object)((GComponent)this).GetChild("ExpeditionBoardEntry");
		EternalNightBoardEntry = (UI_btn_EternalNightBoardEntry)(object)((GComponent)this).GetChild("EternalNightBoardEntry");
		EternalNightBoardEntry2 = (UI_btn_EternalNightBoardEntry)(object)((GComponent)this).GetChild("EternalNightBoardEntry2");
		BackBtn = (UI_btn_Back)(object)((GComponent)this).GetChild("BackBtn");
		ClaimAllBtn = (UI_btn_ClaimAll)(object)((GComponent)this).GetChild("ClaimAllBtn");
		AmplifierScore = (UI_com_AmplifierScore)(object)((GComponent)this).GetChild("AmplifierScore");
		n196 = (GGroup)((GComponent)this).GetChild("n196");
		n198 = (GTextField)((GComponent)this).GetChild("n198");
		string id7 = "ui://91jxdrkam9ta0".Replace("ui://", "") + "-" + ((GObject)n198).id;
		((GObject)n198).text = LanguagesManager.GetDesc(id7);
		BonusGroup = (GGroup)((GComponent)this).GetChild("BonusGroup");
		InfoList = (GList)((GComponent)this).GetChild("InfoList");
		BackBtn2 = (UI_btn_Back)(object)((GComponent)this).GetChild("BackBtn2");
		n192 = (UI_com_Scroll)(object)((GComponent)this).GetChild("n192");
		InfoGroup = (GGroup)((GComponent)this).GetChild("InfoGroup");
		n178 = (GImage)((GComponent)this).GetChild("n178");
		n119 = (GTextField)((GComponent)this).GetChild("n119");
		string id8 = "ui://91jxdrkam9ta0".Replace("ui://", "") + "-" + ((GObject)n119).id;
		((GObject)n119).text = LanguagesManager.GetDesc(id8);
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
		Soldiers = (GList)((GComponent)this).GetChild("Soldiers");
		n124 = (GTextField)((GComponent)this).GetChild("n124");
		string id9 = "ui://91jxdrkam9ta0".Replace("ui://", "") + "-" + ((GObject)n124).id;
		((GObject)n124).text = LanguagesManager.GetDesc(id9);
		MaxKillCount = (GTextField)((GComponent)this).GetChild("MaxKillCount");
		n179 = (GGroup)((GComponent)this).GetChild("n179");
		n166 = (GGroup)((GComponent)this).GetChild("n166");
		n167 = (GTextField)((GComponent)this).GetChild("n167");
		string id10 = "ui://91jxdrkam9ta0".Replace("ui://", "") + "-" + ((GObject)n167).id;
		((GObject)n167).text = LanguagesManager.GetDesc(id10);
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("PageController", out var value))
		{
			PageController.selectedIndex = (int)value;
		}
		if (parameters.TryGetValue("OnClose", out var value2))
		{
			OnClose = (UICallbackParam<Action>)value2;
		}
		SkyIslandPlayerSettlementModel playerSettlement = Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement;
		_izId = playerSettlement.IZConfigId;
		ShipAnimCacheManager = new ShipAnimCacheManager();
		RenderLeftSideInfo();
		RenderInfoGroup();
		RenderBonusGroup();
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
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Set(new EventCallback0(End));
		((GObject)BackBtn1).onClick.Set(new EventCallback0(End));
		((GObject)BackBtn2).onClick.Set(new EventCallback0(End));
		((GObject)ExpeditionBoardEntry).onClick.Set(new EventCallback0(OnOpenExpeditionBoard));
		((GObject)EternalNightBoardEntry).onClick.Set(new EventCallback0(OnEternalNightBoard));
		((GObject)EternalNightBoardEntry2).onClick.Set(new EventCallback0(OnEternalNightBoard));
		((GObject)AmplifierScore.Help).onClick.Set(new EventCallback0(OnClickAmplifierScoreHelp));
		((GObject)ClaimAllBtn).onClick.Set(new EventCallback0(OnClaimAll));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BackBtn).onClick.Clear();
		((GObject)BackBtn1).onClick.Clear();
		((GObject)BackBtn2).onClick.Clear();
		((GObject)ExpeditionBoardEntry).onClick.Clear();
		((GObject)EternalNightBoardEntry).onClick.Clear();
		((GObject)EternalNightBoardEntry2).onClick.Clear();
		((GObject)AmplifierScore.Help).onClick.Clear();
		((GObject)ClaimAllBtn).onClick.Clear();
	}

	private void OnOpenExpeditionBoard()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3LeaderboardPanel.Name, new Dictionary<string, object>
		{
			{ "IzConfigId", _izId },
			{
				"UIType",
				UI_main_GvG3LeaderboardPanel.UIType.Expedition
			},
			{
				"OnClose",
				new UICallbackParam<Action>(RenderExpeditionBoard)
			}
		});
	}

	private void OnEternalNightBoard()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3LeaderboardPanel.Name, new Dictionary<string, object>
		{
			{ "IzConfigId", _izId },
			{
				"UIType",
				UI_main_GvG3LeaderboardPanel.UIType.EternalNight
			},
			{
				"OnClose",
				new UICallbackParam<Action>(delegate
				{
					RenderEternalNightBoard();
					RenderEternalNightBoard2();
				})
			}
		});
	}

	private void OnClickAmplifierScoreHelp()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_AmpScoreDetailPanel.Name, null);
	}

	private void OnClaimAll()
	{
		((GObject)ClaimAllBtn).touchable = false;
		Singleton<GvGMode3RoomManager>.Instance.ClaimAllSettlementLeaderboardBonuses(delegate
		{
			RenderBonusGroup();
			((GObject)ClaimAllBtn).touchable = true;
		}, delegate
		{
			((GObject)ClaimAllBtn).touchable = true;
		});
	}

	private void RenderLeftSideInfo()
	{
		SkyIslandPlayerSettlementModel playerSettlement = Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement;
		RenderNoEnterIzProfile(playerSettlement.UserId);
		PlayerAvatar.CampId.selectedIndex = playerSettlement.CampId;
		CampId.selectedIndex = playerSettlement.CampId;
		((GObject)Date).text = DateTimeHelper.Parse(playerSettlement.SettlementTimestamp).LocalDateTime.ToString("yyyy/MM/dd");
		RenderTrophies();
		RenderMyBestKill(playerSettlement.BestKillShip);
	}

	private void RenderNoEnterIzProfile(int userId)
	{
		FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.GetUserNickName(userId, PlayerName));
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.SetSelfImageByWebRequestAndStorage(Name, PlayerAvatar.HeadPortrait.icon));
	}

	private void RenderMyBestKill(BestKillShip bestKillShip)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		if (bestKillShip.ShipMultiKillCount == 0)
		{
			HasBestKill.selectedIndex = 0;
			return;
		}
		HasBestKill.selectedIndex = 1;
		int defaultSkinId = ShipConfigHelper.GetByShipRaceType((int)bestKillShip.Race).DefaultSkinId;
		RenderShipAnimation(defaultSkinId);
		((GObject)ShipName).text = bestKillShip.Name.ToRealShipName();
		((GObject)MaxKillCount).text = $"{bestKillShip.ShipMultiKillCount}";
		Soldiers.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			SelectedSoldiersItemRenderer(i, (UI_btn_SimpleSoldierSlot)(object)o);
		};
		Soldiers.numItems = 5;
	}

	private void RenderTrophies()
	{
		SkyIslandPlayerSettlementModel playerSettlement = Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement;
		List<SettlementTrophy> settlementTrophies = playerSettlement.SettlementTrophies;
		Dictionary<eLeaderboardType, SettlementRankData> dictionary = new Dictionary<eLeaderboardType, SettlementRankData>();
		foreach (KeyValuePair<eLeaderboardType, SettlementRankData> selfRankData in playerSettlement.selfRankDatas)
		{
			dictionary.Add(selfRankData.Key, selfRankData.Value);
		}
		foreach (KeyValuePair<eLeaderboardType, SettlementRankData> selfFinalProgressRankData in playerSettlement.selfFinalProgressRankDatas)
		{
			dictionary.Add(selfFinalProgressRankData.Key, selfFinalProgressRankData.Value);
		}
		TrophyCount.selectedIndex = settlementTrophies.Count;
		UI_com_PlayerTrophy[] array = new UI_com_PlayerTrophy[3] { Trophy_0, Trophy_1, Trophy_2 };
		int num = Mathf.Min(settlementTrophies.Count, array.Length);
		for (int i = 0; i < num; i++)
		{
			RenderSingleTrophy(array[i], i, settlementTrophies, dictionary);
		}
	}

	private void RenderSingleTrophy(UI_com_PlayerTrophy com, int index, List<SettlementTrophy> trophies, Dictionary<eLeaderboardType, SettlementRankData> lb_Dict)
	{
		SettlementTrophy settlementTrophy = trophies[index];
		if (!lb_Dict.TryGetValue(settlementTrophy.LBType, out var value))
		{
			ILRuntimeDebug.LogError($"[UI_main_GvGSettlementPanel] 排行榜数据中没找到此类型 Type = {settlementTrophy.LBType}");
			return;
		}
		com.TrophyIcon.url = "ui://PublicResources/" + settlementTrophy.TrophyName;
		((GObject)com.TypeText).text = settlementTrophy.LBType.GetName() + ":";
		((GObject)com.RankingData).text = $"{value.Data}";
		com.CampId.selectedIndex = Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.CampId;
	}

	private void RenderShipAnimation(int shipSkinId)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		GameObject cache = ShipAnimCacheManager.GetCache("", shipSkinId, delegate(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "dengdai", true);
		});
		cache.transform.localScale = new Vector3(20f, 20f, 20f);
		GoWrapper val = new GoWrapper(cache);
		val.supportStencil = true;
		SpineLoader.SetNativeObject((DisplayObject)(object)val);
	}

	private void SelectedSoldiersItemRenderer(int index, UI_btn_SimpleSoldierSlot item)
	{
		if (index >= Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.BestKillShip.SoldierInfos.Count)
		{
			item.IsEmpty.selectedIndex = 1;
			return;
		}
		BestKillSoldierInfo bestKillSoldierInfo = Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.BestKillShip.SoldierInfos[index];
		string soldierId = bestKillSoldierInfo.SoldierId;
		if (UnitInfoHelper.CheckIsValidSoldier(soldierId))
		{
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
			string iconPath = UiHelper.GetIconPath(soldierId);
			string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(bestKillSoldierInfo.PotentialLevel);
			UI_btn_SimpleSoldierIcon icon = item.Icon;
			((GObject)icon.SoulStoneLevel).alpha = 1f;
			icon.icon.url = "ui://PublicResources/" + iconPath;
			icon.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
			UiHelper.LoadSoldierIconFrameMaterial(((GObject)icon.iconFrame).asLoader, bestKillSoldierInfo.PotentialLevel);
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(icon.SoulStoneLevel, bestKillSoldierInfo.PotentialLevel, soldier.PotentialProgress);
			item.IsEmpty.selectedIndex = 0;
		}
		else
		{
			item.IsEmpty.selectedIndex = 1;
		}
	}

	private void RenderInfoGroup()
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		StatList = new List<StatData>();
		Dictionary<eObserverStatKey, string> dictionary = new Dictionary<eObserverStatKey, string>(Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.observerStatData);
		dictionary.Remove(eObserverStatKey.BestKillShip);
		dictionary.Remove(eObserverStatKey.FillupSoldier);
		foreach (KeyValuePair<eObserverStatKey, string> item in dictionary)
		{
			StatList.Add(new StatData
			{
				StatName = item.Key.GetName(),
				StatValue = long.Parse(item.Value)
			});
		}
		InfoList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			InfoListItemRenderer(i, (UI_com_InfoSlot)(object)o);
		};
		InfoList.numItems = StatList.Count;
	}

	private void InfoListItemRenderer(int index, UI_com_InfoSlot item)
	{
		StatData statData = StatList[index];
		((GObject)item.InfoName).text = statData.StatName;
		((GObject)item.InfoData).text = statData.StatValue.ToString();
	}

	private void RenderBonusGroup()
	{
		if (!Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.IsDoubleChecked)
		{
			HideBonus.selectedIndex = 1;
			return;
		}
		HideBonus.selectedIndex = 0;
		RenderCampRanking();
		RenderCampRankingBonuses();
		RenderExpeditionBoard();
		RenderEternalNightBoard();
		RenderEternalNightBoard2();
		RenderAmplifierScoreBonus();
		HasWaitToClaim.selectedIndex = ((!Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.IsSettlementBonusClaimed) ? 1 : 0);
	}

	private void RenderCampRanking()
	{
		int campId = Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.CampId;
		Dictionary<int, SettlementCampRankData> campTotalRankDict = Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.CampTotalRankDict;
		GObject[] children = ((GComponent)CampRanking).GetChildren();
		foreach (GObject val in children)
		{
			UI_com_CampRankSlot uI_com_CampRankSlot = val as UI_com_CampRankSlot;
			int selectedIndex = uI_com_CampRankSlot.CampId.selectedIndex;
			SettlementCampRankData settlementCampRankData = campTotalRankDict[selectedIndex];
			uI_com_CampRankSlot.IsMyCamp.selectedIndex = ((campId == selectedIndex) ? 1 : 0);
			uI_com_CampRankSlot.Ranking.selectedIndex = settlementCampRankData.Rank;
			((GObject)uI_com_CampRankSlot.RankData).text = $"{settlementCampRankData.Data}";
		}
	}

	private void RenderCampRankingBonuses()
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		CampRankingBonuses = new List<RItem>();
		foreach (KeyValuePair<string, int> item in Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.CampRankReward)
		{
			CampRankingBonuses.Add(new RItem
			{
				ItemId = item.Key,
				cnt = item.Value
			});
		}
		CampBonusList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			CampBonusListItemRenderer(i, (UI_com_CampBonusSlot)(object)o);
		};
		CampBonusList.numItems = CampRankingBonuses.Count;
	}

	private void CampBonusListItemRenderer(int index, UI_com_CampBonusSlot slot)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		RItem data = CampRankingBonuses[index];
		slot.IsClaimed.selectedIndex = (Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.CampRewardIsClaimed ? 1 : 0);
		((GObject)slot.Num).text = $"{data.cnt}";
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(data.ItemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
		FGUIManager.Instance.SetItemIconAndFrame(slot.Icon, data.ItemId);
	}

	private void RenderExpeditionBoard()
	{
		((GObject)ExpeditionBoardEntry.Notice).visible = !Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.IsSelfRankBonusClaimed;
		RenderLeaderboardBonus(Board1, Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.selfRankDatas, eLeaderboardType.远征总贡献榜_阵营);
	}

	private void RenderEternalNightBoard()
	{
		((GObject)EternalNightBoardEntry.Notice).visible = !Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.IsSelfFinalProgressRankBonusClaimed;
		if (!IsBrawlFight)
		{
			RenderLeaderboardBonus(Board2, Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.selfFinalProgressRankDatas, eLeaderboardType.BOSS单日最高输出榜_全副本);
		}
		else
		{
			RenderLeaderboardBonus(Board2, Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.selfFinalProgressRankDatas, eLeaderboardType.乱斗永夜个人积分榜);
		}
	}

	private void RenderEternalNightBoard2()
	{
		((GObject)EternalNightBoardEntry2.Notice).visible = !Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.IsSelfFinalProgressRankBonusClaimed;
		if (!IsBrawlFight)
		{
			RenderLeaderboardBonus(Board3, Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.selfFinalProgressRankDatas, eLeaderboardType.阴影之石捐献榜_全副本);
		}
		else
		{
			RenderLeaderboardBonus(Board3, Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.selfFinalProgressRankDatas, eLeaderboardType.乱斗永夜个人获胜榜);
		}
	}

	private void RenderLeaderboardBonus(UI_com_LeaderboardBonus comp, Dictionary<eLeaderboardType, SettlementRankData> rankTypeDict, eLeaderboardType briefType)
	{
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Expected O, but got Unknown
		comp.RankingType.selectedIndex = (int)briefType;
		switch (briefType)
		{
		case eLeaderboardType.远征总贡献榜_阵营:
			comp.TitleType.selectedIndex = 0;
			((GObject)comp.TypeName0).text = briefType.GetName();
			break;
		case eLeaderboardType.BOSS单日最高输出榜_全副本:
			comp.TitleType.selectedIndex = 1;
			((GObject)comp.TypeName1).text = briefType.GetName();
			break;
		case eLeaderboardType.阴影之石捐献榜_全副本:
			comp.TitleType.selectedIndex = 1;
			((GObject)comp.TypeName1).text = briefType.GetName();
			break;
		case eLeaderboardType.乱斗永夜阵营获胜榜:
			comp.TitleType.selectedIndex = 0;
			((GObject)comp.TypeName0).text = briefType.GetName();
			break;
		case eLeaderboardType.乱斗永夜个人积分榜:
			comp.TitleType.selectedIndex = 1;
			((GObject)comp.TypeName1).text = briefType.GetName();
			break;
		case eLeaderboardType.乱斗永夜个人获胜榜:
			comp.TitleType.selectedIndex = 1;
			((GObject)comp.TypeName1).text = briefType.GetName();
			break;
		}
		if (!rankTypeDict.TryGetValue(briefType, out var value))
		{
			value = new SettlementRankData
			{
				Rank = -1,
				Reward = new Dictionary<string, int>()
			};
		}
		if (value.Rank == -1)
		{
			comp.IsEmpty.selectedIndex = 1;
			((GObject)comp.Ranking).text = "0";
			((GObject)comp.EmptyTip).text = "~";
		}
		else
		{
			comp.IsEmpty.selectedIndex = 0;
			int rank = value.Rank;
			comp.RankingTopThree.selectedIndex = Math.Min(rank, 4);
			((GObject)comp.Ranking).text = $"{rank}";
		}
		((GObject)comp.RankingData).text = $"{value.Data}";
		List<BonusData> reward = new List<BonusData>();
		foreach (KeyValuePair<string, int> item2 in value.Reward)
		{
			BonusData item = new BonusData
			{
				ItemId = item2.Key,
				Count = item2.Value,
				IsClaimed = value.HasClaimed
			};
			reward.Add(item);
		}
		comp.BonusList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			LeaderboardBonusListItemRenderer(i, (UI_com_BonusSlot)(object)o, reward);
		};
		comp.BonusList.numItems = reward.Count;
		comp.EmptyState.SetSelectedIndex((reward.Count <= 0) ? 1 : 0);
	}

	private void LeaderboardBonusListItemRenderer(int index, UI_com_BonusSlot slot, List<BonusData> reward)
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		BonusData bonus = reward[index];
		slot.BonusItem.Icon.url = "ui://PublicResources/" + UiHelper.GetIcon(bonus.ItemId);
		((GObject)slot.BonusItem.Count).text = $"{bonus.Count}";
		slot.IsClaimed.selectedIndex = (bonus.IsClaimed ? 1 : 0);
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(bonus.ItemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
	}

	private void RenderAmplifierScoreBonus()
	{
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		SkyIslandSettlement_AmplifierDetail amplifierDetail = Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.AmplifierDetail;
		bool amplifierDetail_RewardIsClaimed = Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement.AmplifierDetail_RewardIsClaimed;
		List<BonusData> reward = new List<BonusData>();
		foreach (KeyValuePair<string, int> item in amplifierDetail.Reward)
		{
			reward.Add(new BonusData
			{
				ItemId = item.Key,
				Count = item.Value,
				IsClaimed = amplifierDetail_RewardIsClaimed
			});
		}
		((GObject)AmplifierScore.Score).text = amplifierDetail.Score.ToString();
		AmplifierScore.BonusList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderAmplifierBonusItem(i, (UI_com_BonusSlot)(object)o, reward);
		};
		AmplifierScore.BonusList.numItems = reward.Count;
		AmplifierScore.EmptyState.SetSelectedIndex((reward.Count <= 0) ? 1 : 0);
	}

	private void RenderAmplifierBonusItem(int index, UI_com_BonusSlot slot, List<BonusData> reward)
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		BonusData bonus = reward[index];
		slot.BonusItem.Icon.url = "ui://PublicResources/" + UiHelper.GetIcon(bonus.ItemId);
		((GObject)slot.BonusItem.Count).text = $"{bonus.Count}";
		slot.IsClaimed.selectedIndex = (bonus.IsClaimed ? 1 : 0);
		((GObject)slot).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(bonus.ItemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
	}

	public void End()
	{
		OnClose?.Callback?.Invoke();
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
		ShipAnimCacheManager.ClearCache();
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
	}
}
