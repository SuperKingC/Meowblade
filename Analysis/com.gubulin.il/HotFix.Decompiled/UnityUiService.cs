using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FairyGUI;
using HotFix;
using HotFix.Sources.Base.Sources.Services.UiService;
using ObjectPool;
using RSG;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI;
using UI.AccountInfo;
using UI.AddCredit;
using UI.Battle;
using UI.Battle_PauseSetEffect;
using UI.BlackMarketer;
using UI.BlueprintGachaDetailInfo;
using UI.Certification;
using UI.Collection;
using UI.Contract;
using UI.CraftItemPopup;
using UI.DebrisCompound;
using UI.Dungeons;
using UI.EdgeMask;
using UI.EnemyIntroduction;
using UI.Friends;
using UI.FullScreenAnimation;
using UI.GVGStore;
using UI.GameActivity;
using UI.GameEndPanels;
using UI.GiftBag;
using UI.GiftOfLord;
using UI.Guide;
using UI.GvG3LandOfEternalNight;
using UI.GvG3Leaderboard;
using UI.GvG3MainStorylineQuest;
using UI.GvG3Medal;
using UI.GvG3SplitBluePrint;
using UI.GvG3StoreEntrance;
using UI.GvG3SupplyDepot;
using UI.GvG3Video;
using UI.GvGAmpIntroduction;
using UI.GvGAmplifierEntries;
using UI.GvGAmplifierForge;
using UI.GvGAmplifierOnShip;
using UI.GvGAmplifierStorage;
using UI.GvGBattlePass3;
using UI.GvGBattleRecord3;
using UI.GvGBattleRecords;
using UI.GvGBrawlFight;
using UI.GvGChangeShipName;
using UI.GvGChat;
using UI.GvGExchange3;
using UI.GvGExpeditionHall;
using UI.GvGFlagship3;
using UI.GvGIslandBuff;
using UI.GvGLoading;
using UI.GvGMode3Collecting;
using UI.GvGOEMBonus3;
using UI.GvGOEMForge3;
using UI.GvGOEMResult3;
using UI.GvGOnIsland3;
using UI.GvGOuterTech;
using UI.GvGPlayerCommand3;
using UI.GvGPurification3;
using UI.GvGPurificationResult3;
using UI.GvGRandomEvent3;
using UI.GvGSettlement;
using UI.GvGShipDetail;
using UI.GvGShipLaunch;
using UI.GvGShipOverview;
using UI.GvGShipPopup;
using UI.GvGStoreHouse;
using UI.GvGTalent;
using UI.GvGWorldMap2;
using UI.GvGWorldMap3;
using UI.GvGWorldMapRecord2;
using UI.InstanceZones;
using UI.IslandComeAgain;
using UI.LegendItemBlueprint;
using UI.LegendItemBlueprintTemplate;
using UI.LegendItemCultivation;
using UI.LegendItemDungeon;
using UI.LegendItemInfo;
using UI.LegendItems;
using UI.LegendItemsDraw;
using UI.LegendItemsStore;
using UI.Legion;
using UI.LoginAndName;
using UI.LordOfDreams;
using UI.Lottery;
using UI.Mail;
using UI.MainCity;
using UI.MaskCover;
using UI.MilitaryAFKAssistant;
using UI.MilitaryIntelligence;
using UI.MonthCard;
using UI.MtgGiftPacks;
using UI.NewbieMission;
using UI.PaymentOptions;
using UI.Playback;
using UI.Plot;
using UI.PrinceOfTheDevils;
using UI.ProgressionMission;
using UI.PublicResources;
using UI.PushFirstTopup;
using UI.PushGiftBag;
using UI.PvpSelectSoldiers;
using UI.QuickBattle;
using UI.RecruitingCamp;
using UI.RecyclingCenter;
using UI.Restart;
using UI.ReturningRewards;
using UI.RollingMarquee;
using UI.Screenshots;
using UI.SoldierCultivate;
using UI.SoldierFormationInfo;
using UI.SoulKeyStore;
using UI.Souvenir;
using UI.SpecialActivity;
using UI.StellarKeyStore;
using UI.Technology;
using UI.Tips;
using UI.UnlockSoldierInfo;
using UI.UnlockSoldierShow;
using UI.UpGrade;
using UI.UpPropGrade;
using UI.UpdateResources;
using UI.UpgradePotential;
using UI.UseItemResult;
using UI.Waiting;
using UI.WarOrder;
using UI.Warehouse;
using UI.WeekActivity;
using UI.WeekActivityPass;
using UI.WorkShop;
using UI.WorldMap;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnityUiService : MonoBehaviour, IUiService, IService
{
	public class UIParameters
	{
		public string UIName;

		public Dictionary<string, object> Params;
	}

	public enum UiPanelSortingOrder
	{
		CommonPanelOrder = 1000,
		AdvancedPanelOrder = 2000,
		DialogPanelOrder = 3000,
		MaxOrder = 4000
	}

	public static UnityUiService Instance;

	public static float AspectRatio;

	private Dictionary<string, GObject> _uis;

	private List<UIParameters> _uiParamList;

	private Stack<List<UIParameters>> _uisBackupStack;

	private Stack<List<UIParameters>> _uisHiddenBackupStack;

	private Dictionary<string, MethodInfo> _createInstanceMethodMap;

	private Dictionary<string, Type> _resourceMaps;

	private Dictionary<string, Promise> _loadingPackages;

	private Dictionary<string, bool> _packages;

	private Dictionary<string, TaskCompletionSource<bool>> _pendingUis;

	private List<string> _uisNeedQueuePlay;

	private List<string> _closeAllUisNeedContinue;

	private List<string> _closeAllUisNeedContinueDynamicList;

	private Queue<KeyValuePair<string, Dictionary<string, object>>> _uisQueueList;

	private Dictionary<string, int> UI_SortingOrder;

	private string _currentQueuePlaying;

	private UI_MaskCover _maskCover;

	private UI_NewbieMissionPanel newbieMissionPanel;

	private UI_EdgeMaskPanel _edgeMaskPanel;

	private bool _isLoadingMaskCover;

	private bool _isMaskCoverTouchable;

	private bool _isLoadingEdgeMask;

	private int _uiNotTouchableIndex;

	private HashSet<int> _uiNotTouchable;

	private UI_WaitingPanel _waitingPanel;

	private UI_WaitingPanel _paymentWaitingPanel;

	private bool _isLoadingWaitingPanel;

	private bool _isShowWaitingPanel;

	private UI_DebugInfo _debugInfo;

	public Dictionary<string, GObject> DictUI;

	private TipConstants _ipConstants;

	public static List<string> maskNames;

	public static List<string> backNames;

	private static List<string> canNotChangeBack;

	private static readonly List<string> PersistentUis = new List<string>
	{
		UI_RollingMarqueePanel.Name,
		UI_NewbieMissionPanel.Name,
		UI_main_MilitaryAFKAssistant.Name
	};

	private bool _isRecoveringBackup = false;

	public UI_MaskCover maskCover
	{
		get
		{
			return _maskCover;
		}
		set
		{
			_maskCover = value;
		}
	}

	public UI_NewbieMissionPanel NewbieMissionPanel
	{
		get
		{
			return newbieMissionPanel;
		}
		set
		{
			newbieMissionPanel = value;
		}
	}

	public UI_EdgeMaskPanel edgeMaskPanel
	{
		get
		{
			return _edgeMaskPanel;
		}
		set
		{
			_edgeMaskPanel = value;
		}
	}

	public UI_WaitingPanel waitingPanel
	{
		get
		{
			return _waitingPanel;
		}
		set
		{
			_waitingPanel = value;
		}
	}

	public UI_WaitingPanel paymentWaitingPanel
	{
		get
		{
			return _paymentWaitingPanel;
		}
		set
		{
			_paymentWaitingPanel = value;
		}
	}

	public static bool IsReady()
	{
		return (Object)(object)Instance != (Object)null && Instance.waitingPanel != null && Instance.edgeMaskPanel != null && Instance.maskCover != null;
	}

	private void Awake()
	{
		Instance = this;
		_loadingPackages = new Dictionary<string, Promise>();
		UIPackage.unloadBundleByFGUI = false;
		GetScreenWidthHeightRadio();
		DictUI = new Dictionary<string, GObject>();
		_uisNeedQueuePlay = new List<string>
		{
			UI_SoldierShowPanel.Name,
			UI_main_NewSoldierPanel.Name,
			UI_UpgradeSuccess.Name,
			UI_UpgradeSuccessPanel.Name,
			UI_NewUpguadeSuccessPanel.Name,
			UI_UserLevelUpPopup.Name,
			UI_Technology.Name,
			UI_ShowOfflineEarnings.Name,
			UI_MonthCardPanel.Name,
			UI_BlueprintUpGradePanel.Name,
			UI_PushGiftBagPanel.Name,
			UI_UndergroundCityUpGrade.Name,
			UI_ConfirmPopupDontShowAgain.Name
		};
		_uisQueueList = new Queue<KeyValuePair<string, Dictionary<string, object>>>();
		maskNames = new List<string> { "Mask", "mask", "back", "Back", "BlackGround" };
		backNames = new List<string> { "background", "Background", "mainMapLoader" };
		canNotChangeBack = new List<string>
		{
			UI_SomeTipPanel.Name,
			UI_MainCity.Name,
			UI_Battle.Name,
			UI_LoadingPanel.Name,
			UI_WechatLogin.Name,
			UI_WorldMapPanel.Name,
			UI_Guide.Name,
			UI_PlotDialog.Name,
			UI_DamageMeter.Name,
			UI_ScreenshotsPanel.Name,
			UI_ShowRankBattleBuff.Name,
			UI_PvPBattleResultAnimationEffect.Name,
			UI_NewbieMissionPanel.Name,
			UI_FullScreenAnimationPanel.Name,
			UI_main_MilitaryAFKAssistant.Name
		};
		int num = 1000;
		int num2 = 2000;
		int num3 = 3000;
		int num4 = 4000;
		_closeAllUisNeedContinue = new List<string>
		{
			UI_RollingMarqueePanel.Name,
			UI_CertificationNoticePanel.Name,
			UI_CertificationMainPanel.Name,
			UI_CertificationTipPopup.Name,
			UI_NewbieMissionPanel.Name,
			UI_main_MilitaryAFKAssistant.Name
		};
		_closeAllUisNeedContinueDynamicList = new List<string>();
		UI_SortingOrder = new Dictionary<string, int>
		{
			{
				UI_MainCity.Name,
				num - 1
			},
			{
				UI_Battle.Name,
				num - 1
			},
			{
				UI_Battle_PauseSetEffect.Name,
				num
			},
			{
				UI_PvpBattleLogPanel.Name,
				num
			},
			{
				UI_ChangeNamePanel.Name,
				num
			},
			{
				UI_mian_GvGAmpIntroductionPopup.Name,
				num
			},
			{
				UI_GvGChangeShipNamePanel.Name,
				num
			},
			{
				UI_main_GvGOnIsland3.Name,
				num - 1
			},
			{
				UI_main_GvGIslandBrawlFight.Name,
				num - 1
			},
			{
				UI_main_BrawlFightSelectIsland.Name,
				num - 1
			},
			{
				UI_LegionPanel.Name,
				num
			},
			{
				UI_GvGTip.Name,
				num - 1
			},
			{
				UI_GvG2Tip.Name,
				num - 1
			},
			{
				UI_main_GvG3Tip.Name,
				num - 1
			},
			{
				UI_main_GvGWorldMap3.Name,
				num - 1
			},
			{
				UI_main_IslandDefenders.Name,
				num
			},
			{
				UI_main_IslandPlayers.Name,
				num
			},
			{
				UI_main_IslandOutput.Name,
				num
			},
			{
				UI_main_ShowEfficiencyBuff.Name,
				num + 1
			},
			{
				UI_GvGWorldMap2.Name,
				num
			},
			{
				UI_GvGShipDetailPanel.Name,
				num
			},
			{
				UI_main_FoodFillupPanel.Name,
				num
			},
			{
				UI_main_SoulGuidePanel.Name,
				num
			},
			{
				UI_main_BuildConfirmPanel.Name,
				num + 1
			},
			{
				UI_main_GvG3LeaderboardPanel.Name,
				num
			},
			{
				UI_GvGExpeditionHallPanel.Name,
				num
			},
			{
				UI_main_GvGLoadingPanel.Name,
				num + 99
			},
			{
				UI_main_GvGLoading2Panel.Name,
				num + 99
			},
			{
				UI_GvGShipOverviewPanel.Name,
				num
			},
			{
				UI_GvGAmplifierStoragePanel.Name,
				num
			},
			{
				UI_GvGAmplifierEntriesPanel.Name,
				num
			},
			{
				UI_main_GvGOuterTechPanel.Name,
				num
			},
			{
				UI_main_TechResultPanel.Name,
				num
			},
			{
				UI_main_TechUpgradePanel.Name,
				num
			},
			{
				UI_GvGAmplifierOnShipPanel.Name,
				num
			},
			{
				UI_GvGAmplifierForgePanel.Name,
				num
			},
			{
				UI_main_GvGShipLaunch.Name,
				num
			},
			{
				UI_IslandFinishPopup.Name,
				num
			},
			{
				UI_LordOfDreamsPanel.Name,
				num
			},
			{
				UI_GvGBonusPanel.Name,
				num
			},
			{
				UI_GvGBattleEndPanel.Name,
				num
			},
			{
				UI_GvGSelectSoldierPanel.Name,
				num
			},
			{
				UI_GvGSelectIslandPanel.Name,
				num
			},
			{
				UI_main_GvGTalentPanel.Name,
				num
			},
			{
				UI_main_GvGStoreHousePanel.Name,
				num
			},
			{
				UI_main_StellarKeyStorePanel.Name,
				num
			},
			{
				UI_main_StellarKeyCraftPopup.Name,
				num
			},
			{
				UI_main_GvGSettlementPanel.Name,
				num
			},
			{
				UI_main_AmpScoreDetailPanel.Name,
				num
			},
			{
				UI_main_GvGMode3CollectingPanel.Name,
				num
			},
			{
				UI_main_FillUpConfirm.Name,
				num
			},
			{
				UI_main_SharePopupPanel.Name,
				num
			},
			{
				UI_main_GvGResetTalents.Name,
				num
			},
			{
				UI_main_IslandBattleRecordPanel.Name,
				num
			},
			{
				UI_main_IslandBuffPanel.Name,
				num
			},
			{
				UI_main_IslandCampaignPanel.Name,
				num
			},
			{
				UI_main_GvG3BattleRecordsPanel.Name,
				num
			},
			{
				UI_main_GvG3Chat.Name,
				num
			},
			{
				UI_main_GvGFlagshipPanel.Name,
				num
			},
			{
				UI_main_GvG3Exchange.Name,
				num
			},
			{
				UI_main_GvG3PostOEMMission.Name,
				num
			},
			{
				UI_main_GvG3OemResult.Name,
				num
			},
			{
				UI_main_GvG3OemForge.Name,
				num
			},
			{
				UI_main_GvG3OemBonus.Name,
				num
			},
			{
				UI_main_GvG3OutsourcingAmplifier.Name,
				num
			},
			{
				UI_main_GvG3Purification.Name,
				num
			},
			{
				UI_main_SupplyDepot.Name,
				num
			},
			{
				UI_main_CampPlayers.Name,
				num
			},
			{
				UI_main_FlagShipMissions.Name,
				num
			},
			{
				UI_main_MainMissionCampBonus.Name,
				num
			},
			{
				UI_main_TreasureMap.Name,
				num
			},
			{
				UI_main_GvG3EventNpcDialog.Name,
				num
			},
			{
				UI_main_GvG3EventNpcShop.Name,
				num
			},
			{
				UI_main_GvG3BuyNpcStoreItem.Name,
				num
			},
			{
				UI_main_BuyBattlePass.Name,
				num
			},
			{
				UI_main_BattlePassMission.Name,
				num
			},
			{
				UI_main_GvG3BattlePass.Name,
				num
			},
			{
				UI_main_CancelCommand.Name,
				num
			},
			{
				UI_main_PlayerCommand.Name,
				num
			},
			{
				UI_main_LandOfEternalNightCampBonus.Name,
				num
			},
			{
				UI_main_GvG3StoreEntrance.Name,
				num
			},
			{
				UI_main_GvG3IslandEventRanking.Name,
				num
			},
			{
				UI_main_IslandDescription.Name,
				num
			},
			{
				UI_main_ProgressSettlement.Name,
				num
			},
			{
				UI_main_ProgressRewardPreview.Name,
				num
			},
			{
				UI_com_Armistice.Name,
				num
			},
			{
				UI_main_FireSupportConfirmPanel.Name,
				num
			},
			{
				UI_main_OuterTechI67502.Name,
				num
			},
			{
				UI_main_GreenChannelConfirmPanel.Name,
				num
			},
			{
				UI_main_BuySweepCountDialog.Name,
				num
			},
			{
				UI_WarOrderPanel.Name,
				num
			},
			{
				UI_WarOrderBuyPanel.Name,
				num
			},
			{
				UI_WarOrderMissionPanel.Name,
				num
			},
			{
				UI_WorldMapPanel.Name,
				num
			},
			{
				UI_AccountInfoPanel.Name,
				num
			},
			{
				UI_ActivityPanel.Name,
				num
			},
			{
				UI_Technology.Name,
				num
			},
			{
				UI_InstanceZonesPanel.Name,
				num
			},
			{
				UI_WechatLogin.Name,
				num
			},
			{
				UI_ContractPanel.Name,
				num
			},
			{
				UI_RecruitingCamp.Name,
				num
			},
			{
				UI_SoldierCultivate.Name,
				num
			},
			{
				UI_CollectionPanel.Name,
				num
			},
			{
				UI_UpGradePanel.Name,
				num
			},
			{
				UI_Main_UpGradePanel.Name,
				num
			},
			{
				UI_main_GvGUseItemResultPanel.Name,
				num
			},
			{
				UI_main_GSUseItemResultPanel.Name,
				num
			},
			{
				UI_WorkShopPanel.Name,
				num
			},
			{
				UI_UpgradeSuccess.Name,
				num
			},
			{
				UI_MonthCardPanel.Name,
				num
			},
			{
				UI_LegendItemsStorePanel.Name,
				num
			},
			{
				UI_PrinceOfTheDevilsPanel.Name,
				num
			},
			{
				UI_QuickBattlePanel.Name,
				num
			},
			{
				UI_PvpSelectSoldiersPanel.Name,
				num
			},
			{
				UI_PvpEnemySettingPanel.Name,
				num
			},
			{
				UI_PvpZoneChoose.Name,
				num
			},
			{
				UI_PVPSeasonEntrancePanel.Name,
				num
			},
			{
				UI_ServerWideConquestPanel.Name,
				num
			},
			{
				UI_ServerWideRewardPanel.Name,
				num
			},
			{
				UI_ServerWideBattleReportSelectPanel.Name,
				num
			},
			{
				UI_ServerWideMatchResultPanel.Name,
				num
			},
			{
				UI_PVPSeasonMatchResultPanel.Name,
				num
			},
			{
				UI_PVPSeasonMissionPanel.Name,
				num
			},
			{
				UI_LadderTournamentPanel.Name,
				num
			},
			{
				UI_PvpBattleVictory.Name,
				num
			},
			{
				UI_PvpBattleFail.Name,
				num
			},
			{
				UI_PvpScoreRankListPanel.Name,
				num
			},
			{
				UI_Rank_RewardPanel.Name,
				num
			},
			{
				UI_AddRankAttackBuffDialog.Name,
				num
			},
			{
				UI_AddRankDefenseBuffDialog.Name,
				num
			},
			{
				UI_AddRankClearCDDialog.Name,
				num
			},
			{
				UI_PvpTotalRankListPanel.Name,
				num
			},
			{
				UI_UnlockPeakBattle.Name,
				num
			},
			{
				UI_SelectServerWideBattleArrayPanel.Name,
				num
			},
			{
				UI_PeakBattleSelectArrayPanel.Name,
				num
			},
			{
				UI_PresetFormationPanel.Name,
				num
			},
			{
				UI_PvpStorePanel.Name,
				num
			},
			{
				UI_TopTournamentBattlePanel.Name,
				num
			},
			{
				UI_TopTournamentEveryDayLogPanel.Name,
				num
			},
			{
				UI_TopTournamentHistoryRankList.Name,
				num
			},
			{
				UI_TopTournamentNameList.Name,
				num
			},
			{
				UI_PvpBattleLogDetailPanel.Name,
				num
			},
			{
				UI_UnlockSoldierInfoPanel.Name,
				num
			},
			{
				UI_GvGHelpPanel.Name,
				num
			},
			{
				UI_RewardDescriptionPanel.Name,
				num
			},
			{
				UI_IslandComeAgainMatchingPanel.Name,
				num
			},
			{
				UI_IslandComeAgainLotteryPanel.Name,
				num
			},
			{
				UI_IslandComeAgainCheckRewardPanel.Name,
				num
			},
			{
				UI_IslandComeAgainExchangeCurrencyPanel.Name,
				num
			},
			{
				UI_IslandComeAgainHelpPanel.Name,
				num
			},
			{
				UI_ReplenishTroopsPanel.Name,
				num
			},
			{
				UI_ChangeTroopsPanel.Name,
				num
			},
			{
				UI_MyTroopsPanel.Name,
				num
			},
			{
				UI_MainIslandPanel.Name,
				num
			},
			{
				UI_IslandInfoPanel.Name,
				num
			},
			{
				UI_IslandComeAgainBattleResultPanel.Name,
				num
			},
			{
				UI_TroopsChangeConfirmPanel.Name,
				num
			},
			{
				UI_IslandComeAgainBattleRecordsPanel.Name,
				num
			},
			{
				UI_IslandComeAgainBattleRecordDetailPanel.Name,
				num
			},
			{
				UI_main_LegendItemBlueprintForge.Name,
				num
			},
			{
				UI_main_LegendItemEvoConfirm.Name,
				num
			},
			{
				UI_main_LegendItemBlueprintSelect.Name,
				num
			},
			{
				UI_main_LegendItemBlueprintForgeConfirm.Name,
				num
			},
			{
				UI_main_ShowForgeResult.Name,
				num
			},
			{
				UI_main_LegendItemIdentityConfirm.Name,
				num
			},
			{
				UI_main_GVGStorePanel.Name,
				num
			},
			{
				UI_main_GVGStoreHelpPanel.Name,
				num
			},
			{
				UI_main_GVGStoreExchangeFormulaPanel.Name,
				num
			},
			{
				UI_main_GVGStoreExchangeConfirmPanel.Name,
				num
			},
			{
				UI_main_GVGStoreRefreshConfirmPanel.Name,
				num
			},
			{
				UI_main_GVGStoreBuyConfirmPanel.Name,
				num
			},
			{
				UI_main_GVGStoreUnlockStoreroomSlotPanel.Name,
				num
			},
			{
				UI_main_LegendItemBlueprintTemplatePanel.Name,
				num
			},
			{
				UI_main_GVGStoreJumpPanel.Name,
				num
			},
			{
				UI_main_GVGStoreRareStoreItemRefreshConfirmPanel.Name,
				num
			},
			{
				UI_main_GvG3RecordDetailPanel.Name,
				num
			},
			{
				UI_main_GvG3Medal.Name,
				num
			},
			{
				UI_JumpTip.Name,
				num + 1
			},
			{
				UI_GvGBossDetailsPanel.Name,
				num + 1
			},
			{
				UI_ProductUpGradePanel.Name,
				num + 1
			},
			{
				UI_GvGBattleRecordsPanel.Name,
				num + 1
			},
			{
				UI_GvGSingleBattleRecordPanel.Name,
				num + 1
			},
			{
				UI_GvGBattleRecordDetailPanel.Name,
				num + 2
			},
			{
				UI_EnemyIntroduction.Name,
				num + 3
			},
			{
				UI_SpearAndShield.Name,
				num + 3
			},
			{
				UI_DamageMeter.Name,
				num + 3
			},
			{
				UI_main_GvG3Video.Name,
				num
			},
			{
				UI_main_LandOfEternalNight.Name,
				num + 1
			},
			{
				UI_main_SplitBlueprint.Name,
				num
			},
			{
				UI_main_BlueprintToBeSplit.Name,
				num
			},
			{
				UI_main_DisplaySplitEffect.Name,
				num
			},
			{
				UI_main_PostFormulaOem.Name,
				num
			},
			{
				UI_main_PostFormulaOemFilter.Name,
				num
			},
			{
				UI_main_FormulaOemFilter.Name,
				num
			},
			{
				UI_main_PostNewFormulaTip.Name,
				num
			},
			{
				UI_main_PurificationEffect.Name,
				num
			},
			{
				UI_main_GiftOfLord.Name,
				num
			},
			{
				UI_main_RepeatedAttackPlanHelper.Name,
				num
			},
			{
				UI_main_CreateRepeatedAttackPlan.Name,
				num
			},
			{
				UI_main_BuyGvGInsurance.Name,
				num
			},
			{
				UI_main_SelectInsuranceShip.Name,
				num
			},
			{
				UI_main_InsuranceShip.Name,
				num
			},
			{
				UI_main_ReturningRewards.Name,
				num
			},
			{
				UI_main_ReturningRewardsPreview.Name,
				num
			},
			{
				UI_main_ReturningMissions.Name,
				num
			},
			{
				UI_main_BrawlCalendar.Name,
				num
			},
			{
				UI_main_BrawlBattleResult.Name,
				num
			},
			{
				UI_main_BrawlIslandBonusPreview.Name,
				num
			},
			{
				UI_main_ReturningInstructions.Name,
				num
			},
			{
				UI_main_ReturningFirstTimeFX.Name,
				num
			},
			{
				UI_main_BrawlBattleRankInfo.Name,
				num
			},
			{
				UI_main_BossBreakDownTip.Name,
				num
			},
			{
				UI_main_PvPEntranceUnlockTip.Name,
				num
			},
			{
				UI.SpecialActivity.UI_HelpPanel.Name,
				num2
			},
			{
				UI_main_GvG3ChatSendCost.Name,
				num2
			},
			{
				UI_main_GvG3ChatRedirectIsland.Name,
				num2
			},
			{
				UI_main_IslandRewards.Name,
				num2
			},
			{
				UI_main_GvG3PurificationResult.Name,
				num2
			},
			{
				UI_RestartPanel.Name,
				num2 - 1
			},
			{
				UI_DataBackUpPanel.Name,
				num2
			},
			{
				UI_PlotDialog.Name,
				num2
			},
			{
				UI_TakeItems.Name,
				num2
			},
			{
				UI_main_IntroductionPanelA.Name,
				num2
			},
			{
				UI_TakeItems_Large.Name,
				num2
			},
			{
				UI_main_CraftItemPopupPanel_GvG.Name,
				num2
			},
			{
				UI_main_CraftItemPopupPanel_GS.Name,
				num2
			},
			{
				UI_LegendItemBoxPanel.Name,
				num2
			},
			{
				UI_main_LegendItemBlueprintInfoPanel.Name,
				num2
			},
			{
				UI_ChoosePendingLottery.Name,
				num2
			},
			{
				UI_ScreenshotBtn.Name,
				num2
			},
			{
				UI_LegendItemInfoDialog.Name,
				num2
			},
			{
				UI_LegendItemInfoDialog2.Name,
				num2
			},
			{
				UI_StartRankBattleCountdown.Name,
				num2
			},
			{
				UI_main_GvG3ConfirmChangeLegendItem.Name,
				num2
			},
			{
				UI_ShowRankBattleBuff.Name,
				num2
			},
			{
				UI_RemoveAccountPanel.Name,
				num2
			},
			{
				UI_PvPBattleResultAnimationEffect.Name,
				num2 - 1
			},
			{
				UI_UserLevelUpPopup.Name,
				num2 + 2
			},
			{
				UI_MaterialIntroductionPanel.Name,
				num2 + 2
			},
			{
				UI_main_Souvenir.Name,
				num2 + 2
			},
			{
				UI_main_BlueprintGachaDetailInfoPanel.Name,
				num2 + 3
			},
			{
				UI_IdentificationPanel.Name,
				num2 + 3
			},
			{
				UI_BoxCostItemTip.Name,
				num2 + 3
			},
			{
				UI_UpgradeSuccessPanel.Name,
				num2 + 4
			},
			{
				UI_NewUpguadeSuccessPanel.Name,
				num2 + 4
			},
			{
				UI_SkipPanel.Name,
				num2 + 6
			},
			{
				UI_SoldierShowPanel.Name,
				num2 + 7
			},
			{
				UI_main_NewSoldierPanel.Name,
				num2 + 7
			},
			{
				UI_RaceInfoPanel.Name,
				num2 + 8
			},
			{
				UI_ExclamationMarkPanel.Name,
				num2 + 8
			},
			{
				UI_SkillDetailPopup.Name,
				num2 + 9
			},
			{
				UI_SkillEffectPanel.Name,
				num2 + 9
			},
			{
				UI_Guide.Name,
				num2 + 10
			},
			{
				UI_main_PvpRankAFKAssistant.Name,
				num3 - 1
			},
			{
				UI_UndergroundCityUpGradeTip.Name,
				num3
			},
			{
				UI_UndergroundCityUpGrade.Name,
				num3
			},
			{
				UI_CertificationPanel.Name,
				num3
			},
			{
				UI_CertificationTipDialog.Name,
				num3
			},
			{
				UI_ShowOfflineEarnings.Name,
				num3
			},
			{
				UI_GoToReviewPopup.Name,
				num3
			},
			{
				UI_LoadingPanel.Name,
				num3 + 1
			},
			{
				UI_PushGiftBagPanel.Name,
				num3
			},
			{
				UI_main_GameInstructions.Name,
				num3
			},
			{
				UI_main_LeaderboardRewards.Name,
				num3
			},
			{
				UI_CopyInvitingCodeWindow.Name,
				num3 + 1
			},
			{
				UI_UniversalConfirmPopup.Name,
				num3 + 1
			},
			{
				UI_PaymentOptionsDialog.Name,
				num3 + 1
			},
			{
				UI_UpdateResources.Name,
				num3 + 1
			},
			{
				UI_main_MilitaryAFKAssistant.Name,
				num3 + 2
			},
			{
				UI_ConfirmPopupDontShowAgain.Name,
				num3 + 3
			},
			{
				UI_SomeTipPanel.Name,
				num3 + 3
			},
			{
				UI_RollingMarqueePanel.Name,
				num3 + 4
			},
			{
				UI_FullScreenAnimationPanel.Name,
				num3 + 4
			},
			{
				UI_ScreenshotsPanel.Name,
				num4
			},
			{
				UI_WaitingPanel.Name,
				num4
			},
			{
				UI_MaskCover.Name,
				num4 + 1
			},
			{
				UI_CertificationMainPanel.Name,
				num4 + 1
			},
			{
				UI_CertificationNoticePanel.Name,
				num4 + 1
			},
			{
				UI_CertificationTipPopup.Name,
				num4 + 1
			},
			{
				UI_GuestRegistPopup.Name,
				num4 + 1
			},
			{
				UI_EdgeMaskPanel.Name,
				num4 + 2
			},
			{
				UI_popup_AppClosedTip.Name,
				num4 + 3
			}
		};
		Initialize();
		HotUpdateProcess.Instance.CheckFguiRootPos();
		EdgeMaskInit();
		_ipConstants = new TipConstants();
	}

	public void EdgeMaskInit()
	{
		float num = 1.7777778f;
		float num2 = (float)Screen.width / (float)Screen.height;
		float num3 = num2 / num;
		if (num3 < 1f)
		{
			SetEdgeMaskVisible(value: true);
		}
		else if (CheckIsMainCityShowed() || CheckIsClearUi() || CheckIsWorldMapShowed())
		{
			SetEdgeMaskVisible(value: false);
		}
		else
		{
			SetEdgeMaskVisible(value: true);
		}
	}

	private void Initialize()
	{
		_uis = new Dictionary<string, GObject>();
		_uiParamList = new List<UIParameters>();
		_uisBackupStack = new Stack<List<UIParameters>>();
		_uisHiddenBackupStack = new Stack<List<UIParameters>>();
		_packages = new Dictionary<string, bool>();
		_createInstanceMethodMap = new Dictionary<string, MethodInfo>();
		_resourceMaps = new Dictionary<string, Type>
		{
			{
				UI_MainCity.Name,
				typeof(UI_MainCity)
			},
			{
				UI_PvpBattleLogPanel.Name,
				typeof(UI_PvpBattleLogPanel)
			},
			{
				UI_ChangeNamePanel.Name,
				typeof(UI_ChangeNamePanel)
			},
			{
				UI_main_GvGOnIsland3.Name,
				typeof(UI_main_GvGOnIsland3)
			},
			{
				UI_main_GvGIslandBrawlFight.Name,
				typeof(UI_main_GvGIslandBrawlFight)
			},
			{
				UI_com_VictoryPopup.Name,
				typeof(UI_com_VictoryPopup)
			},
			{
				UI_mian_GvGAmpIntroductionPopup.Name,
				typeof(UI_mian_GvGAmpIntroductionPopup)
			},
			{
				UI_GvGChangeShipNamePanel.Name,
				typeof(UI_GvGChangeShipNamePanel)
			},
			{
				UI_SoldierCultivate.Name,
				typeof(UI_SoldierCultivate)
			},
			{
				UI_Technology.Name,
				typeof(UI_Technology)
			},
			{
				UI_RecruitingCamp.Name,
				typeof(UI_RecruitingCamp)
			},
			{
				UI_Lottery.Name,
				typeof(UI_Lottery)
			},
			{
				UI_MailPanel.Name,
				typeof(UI_MailPanel)
			},
			{
				UI_MailFriendsPanel.Name,
				typeof(UI_MailFriendsPanel)
			},
			{
				UI_GameEndPanelVictory.Name,
				typeof(UI_GameEndPanelVictory)
			},
			{
				UI_GameEndPanelFail.Name,
				typeof(UI_GameEndPanelFail)
			},
			{
				UI_Guide.Name,
				typeof(UI_Guide)
			},
			{
				UI_PlotDialog.Name,
				typeof(UI_PlotDialog)
			},
			{
				UI_LoginAndName.Name,
				typeof(UI_LoginAndName)
			},
			{
				UI_Battle.Name,
				typeof(UI_Battle)
			},
			{
				UI_Battle_PauseSetEffect.Name,
				typeof(UI_Battle_PauseSetEffect)
			},
			{
				UI_LordOfDreamsPanel.Name,
				typeof(UI_LordOfDreamsPanel)
			},
			{
				UI_main_BuildConfirmPanel.Name,
				typeof(UI_main_BuildConfirmPanel)
			},
			{
				UI_main_AcceptShipPanel.Name,
				typeof(UI_main_AcceptShipPanel)
			},
			{
				UI_main_BuildShipPanel.Name,
				typeof(UI_main_BuildShipPanel)
			},
			{
				UI_main_RebuildShipPanel.Name,
				typeof(UI_main_RebuildShipPanel)
			},
			{
				UI_main_FirstShipIntroPanel.Name,
				typeof(UI_main_FirstShipIntroPanel)
			},
			{
				UI_main_SoulGuidePanel.Name,
				typeof(UI_main_SoulGuidePanel)
			},
			{
				UI_GvGShipDetailPanel.Name,
				typeof(UI_GvGShipDetailPanel)
			},
			{
				UI_main_FoodFillupPanel.Name,
				typeof(UI_main_FoodFillupPanel)
			},
			{
				UI_GvGShipOverviewPanel.Name,
				typeof(UI_GvGShipOverviewPanel)
			},
			{
				UI_main_GvGLoadingPanel.Name,
				typeof(UI_main_GvGLoadingPanel)
			},
			{
				UI_main_GvGLoading2Panel.Name,
				typeof(UI_main_GvGLoading2Panel)
			},
			{
				UI_main_GvG3LeaderboardPanel.Name,
				typeof(UI_main_GvG3LeaderboardPanel)
			},
			{
				UI_GvGExpeditionHallPanel.Name,
				typeof(UI_GvGExpeditionHallPanel)
			},
			{
				UI_GvGAmplifierStoragePanel.Name,
				typeof(UI_GvGAmplifierStoragePanel)
			},
			{
				UI_main_SelectAmplifier.Name,
				typeof(UI_main_SelectAmplifier)
			},
			{
				UI_GvGAmplifierEntriesPanel.Name,
				typeof(UI_GvGAmplifierEntriesPanel)
			},
			{
				UI_main_GvGOuterTechPanel.Name,
				typeof(UI_main_GvGOuterTechPanel)
			},
			{
				UI_main_TechResultPanel.Name,
				typeof(UI_main_TechResultPanel)
			},
			{
				UI_main_TechUpgradePanel.Name,
				typeof(UI_main_TechUpgradePanel)
			},
			{
				UI_GvGAmplifierForgePanel.Name,
				typeof(UI_GvGAmplifierForgePanel)
			},
			{
				UI_GvGAmplifierOnShipPanel.Name,
				typeof(UI_GvGAmplifierOnShipPanel)
			},
			{
				UI_GvGWorldMap2.Name,
				typeof(UI_GvGWorldMap2)
			},
			{
				UI_IslandFinishPopup.Name,
				typeof(UI_IslandFinishPopup)
			},
			{
				UI_GvGBonusPanel.Name,
				typeof(UI_GvGBonusPanel)
			},
			{
				UI_GvGBattleEndPanel.Name,
				typeof(UI_GvGBattleEndPanel)
			},
			{
				UI_GvGSelectSoldierPanel.Name,
				typeof(UI_GvGSelectSoldierPanel)
			},
			{
				UI_GvGSelectIslandPanel.Name,
				typeof(UI_GvGSelectIslandPanel)
			},
			{
				UI_LegionPanel.Name,
				typeof(UI_LegionPanel)
			},
			{
				UI_WarOrderPanel.Name,
				typeof(UI_WarOrderPanel)
			},
			{
				UI_WarOrderBuyPanel.Name,
				typeof(UI_WarOrderBuyPanel)
			},
			{
				UI_WarOrderMissionPanel.Name,
				typeof(UI_WarOrderMissionPanel)
			},
			{
				UI_WorkShopPanel.Name,
				typeof(UI_WorkShopPanel)
			},
			{
				UI_CollectionPanel.Name,
				typeof(UI_CollectionPanel)
			},
			{
				UI_UpGradePanel.Name,
				typeof(UI_UpGradePanel)
			},
			{
				UI_Main_UpGradePanel.Name,
				typeof(UI_Main_UpGradePanel)
			},
			{
				UI_ProductUpGradePanel.Name,
				typeof(UI_ProductUpGradePanel)
			},
			{
				UI_MaterialIntroductionPanel.Name,
				typeof(UI_MaterialIntroductionPanel)
			},
			{
				UI_main_GvGUseItemResultPanel.Name,
				typeof(UI_main_GvGUseItemResultPanel)
			},
			{
				UI_main_GSUseItemResultPanel.Name,
				typeof(UI_main_GSUseItemResultPanel)
			},
			{
				UI_UndergroundCityUpGrade.Name,
				typeof(UI_UndergroundCityUpGrade)
			},
			{
				UI_main_NewSoldierPanel.Name,
				typeof(UI_main_NewSoldierPanel)
			},
			{
				UI_SoldierShowPanel.Name,
				typeof(UI_SoldierShowPanel)
			},
			{
				UI_ShowOfflineEarnings.Name,
				typeof(UI_ShowOfflineEarnings)
			},
			{
				UI_WechatLogin.Name,
				typeof(UI_WechatLogin)
			},
			{
				UI_main_ResetAccountPanel.Name,
				typeof(UI_main_ResetAccountPanel)
			},
			{
				UI_UpdateResources.Name,
				typeof(UI_UpdateResources)
			},
			{
				UI_WarehousePanel.Name,
				typeof(UI_WarehousePanel)
			},
			{
				UI_SkipPanel.Name,
				typeof(UI_SkipPanel)
			},
			{
				UI_SomeTipPanel.Name,
				typeof(UI_SomeTipPanel)
			},
			{
				UI_GvGTip.Name,
				typeof(UI_GvGTip)
			},
			{
				UI_GvG2Tip.Name,
				typeof(UI_GvG2Tip)
			},
			{
				UI_main_GvG3Tip.Name,
				typeof(UI_main_GvG3Tip)
			},
			{
				UI_SkillDetailPopup.Name,
				typeof(UI_SkillDetailPopup)
			},
			{
				UI_SkillEffectPanel.Name,
				typeof(UI_SkillEffectPanel)
			},
			{
				UI_InstructionsWindow.Name,
				typeof(UI_InstructionsWindow)
			},
			{
				UI_LoadingPanel.Name,
				typeof(UI_LoadingPanel)
			},
			{
				UI_SpearAndShield.Name,
				typeof(UI_SpearAndShield)
			},
			{
				UI_InstanceZonesPanel.Name,
				typeof(UI_InstanceZonesPanel)
			},
			{
				UI_DungeonsPanel.Name,
				typeof(UI_DungeonsPanel)
			},
			{
				UI_MaskCover.Name,
				typeof(UI_MaskCover)
			},
			{
				UI_DebugInfo.Name,
				typeof(UI_DebugInfo)
			},
			{
				UI_EdgeMaskPanel.Name,
				typeof(UI_EdgeMaskPanel)
			},
			{
				UI_WorldMapPanel.Name,
				typeof(UI_WorldMapPanel)
			},
			{
				UI_ContractPanel.Name,
				typeof(UI_ContractPanel)
			},
			{
				UI_HelpPanel2.Name,
				typeof(UI_HelpPanel2)
			},
			{
				UI_PrinceOfTheDevilsPanel.Name,
				typeof(UI_PrinceOfTheDevilsPanel)
			},
			{
				UI_BlackMarketerPanel.Name,
				typeof(UI_BlackMarketerPanel)
			},
			{
				UI_MilitaryIntelligencePanel.Name,
				typeof(UI_MilitaryIntelligencePanel)
			},
			{
				UI_TakeItems.Name,
				typeof(UI_TakeItems)
			},
			{
				UI_main_CraftItemPopupPanel_GvG.Name,
				typeof(UI_main_CraftItemPopupPanel_GvG)
			},
			{
				UI_main_CraftItemPopupPanel_GS.Name,
				typeof(UI_main_CraftItemPopupPanel_GS)
			},
			{
				UI_TakeItems_Large.Name,
				typeof(UI_TakeItems_Large)
			},
			{
				UI_main_IntroductionPanelA.Name,
				typeof(UI_main_IntroductionPanelA)
			},
			{
				UI_UniversalConfirmPopup.Name,
				typeof(UI_UniversalConfirmPopup)
			},
			{
				UI_popup_AppClosedTip.Name,
				typeof(UI_popup_AppClosedTip)
			},
			{
				UI_ConfirmPopupDontShowAgain.Name,
				typeof(UI_ConfirmPopupDontShowAgain)
			},
			{
				UI_EnemyIntroduction.Name,
				typeof(UI_EnemyIntroduction)
			},
			{
				UI_BlackMarketerAddCredit.Name,
				typeof(UI_BlackMarketerAddCredit)
			},
			{
				UI_UserLevelUpPopup.Name,
				typeof(UI_UserLevelUpPopup)
			},
			{
				UI_GoToReviewPopup.Name,
				typeof(UI_GoToReviewPopup)
			},
			{
				UI_GiftBagPanel.Name,
				typeof(UI_GiftBagPanel)
			},
			{
				UI_MonthCardPanel.Name,
				typeof(UI_MonthCardPanel)
			},
			{
				UI_UpgradeSuccessPanel.Name,
				typeof(UI_UpgradeSuccessPanel)
			},
			{
				UI_NewUpguadeSuccessPanel.Name,
				typeof(UI_NewUpguadeSuccessPanel)
			},
			{
				UI_ActivityPanel.Name,
				typeof(UI_ActivityPanel)
			},
			{
				UI_ChallengeMissionPanel.Name,
				typeof(UI_ChallengeMissionPanel)
			},
			{
				UI_ProgressionMissionPanel.Name,
				typeof(UI_ProgressionMissionPanel)
			},
			{
				UI_DebrisCompoundPanel.Name,
				typeof(UI_DebrisCompoundPanel)
			},
			{
				UI.SoldierFormationInfo.UI_SoldierFormationInfoPanel.Name,
				typeof(UI.SoldierFormationInfo.UI_SoldierFormationInfoPanel)
			},
			{
				UI_BlueprintUpGradePanel.Name,
				typeof(UI_BlueprintUpGradePanel)
			},
			{
				UI_LordUpgradeTipPanel.Name,
				typeof(UI_LordUpgradeTipPanel)
			},
			{
				UI_ExclamationMarkPanel.Name,
				typeof(UI_ExclamationMarkPanel)
			},
			{
				UI_CertificationPanel.Name,
				typeof(UI_CertificationPanel)
			},
			{
				UI_CertificationWarningPanel.Name,
				typeof(UI_CertificationWarningPanel)
			},
			{
				UI_WaitingPanel.Name,
				typeof(UI_WaitingPanel)
			},
			{
				UI_ChoosePendingLottery.Name,
				typeof(UI_ChoosePendingLottery)
			},
			{
				UI_WorkersOverviewPanel.Name,
				typeof(UI_WorkersOverviewPanel)
			},
			{
				UI_DamageMeter.Name,
				typeof(UI_DamageMeter)
			},
			{
				UI_RecyclingCenterPanel.Name,
				typeof(UI_RecyclingCenterPanel)
			},
			{
				UI_PushGiftBagPanel.Name,
				typeof(UI_PushGiftBagPanel)
			},
			{
				UI_main_FirstTopupPopPanel.Name,
				typeof(UI_main_FirstTopupPopPanel)
			},
			{
				UI_AccountInfoPanel.Name,
				typeof(UI_AccountInfoPanel)
			},
			{
				UI_main_FacebookGiftCode.Name,
				typeof(UI_main_FacebookGiftCode)
			},
			{
				UI_GiftCodePanel.Name,
				typeof(UI_GiftCodePanel)
			},
			{
				UI_ScreenshotsPanel.Name,
				typeof(UI_ScreenshotsPanel)
			},
			{
				UI_RaceInfoPanel.Name,
				typeof(UI_RaceInfoPanel)
			},
			{
				UI_FriendsPanel.Name,
				typeof(UI_FriendsPanel)
			},
			{
				UI_PlayBack.Name,
				typeof(UI_PlayBack)
			},
			{
				UI_RollingMarqueePanel.Name,
				typeof(UI_RollingMarqueePanel)
			},
			{
				UI_LegendItemDungeonPanel.Name,
				typeof(UI_LegendItemDungeonPanel)
			},
			{
				UI_LegendItemsPanel.Name,
				typeof(UI_LegendItemsPanel)
			},
			{
				UI_LegendItemCultivationPanel.Name,
				typeof(UI_LegendItemCultivationPanel)
			},
			{
				UI_main_LegendItemSelect.Name,
				typeof(UI_main_LegendItemSelect)
			},
			{
				UI_main_EffectSwitch.Name,
				typeof(UI_main_EffectSwitch)
			},
			{
				UI_com_SwitchMainAtt.Name,
				typeof(UI_com_SwitchMainAtt)
			},
			{
				UI_LegendItemInfoDialog.Name,
				typeof(UI_LegendItemInfoDialog)
			},
			{
				UI_LegendItemInfoDialog2.Name,
				typeof(UI_LegendItemInfoDialog2)
			},
			{
				UI_UnlockPopup.Name,
				typeof(UI_UnlockPopup)
			},
			{
				UI_LegendItemsDrawPanel.Name,
				typeof(UI_LegendItemsDrawPanel)
			},
			{
				UI_LegendItemBoxPanel.Name,
				typeof(UI_LegendItemBoxPanel)
			},
			{
				UI_IdentificationPanel.Name,
				typeof(UI_IdentificationPanel)
			},
			{
				UI_LegendItemsStorePanel.Name,
				typeof(UI_LegendItemsStorePanel)
			},
			{
				UI_CertificationMainPanel.Name,
				typeof(UI_CertificationMainPanel)
			},
			{
				UI_CertificationNoticePanel.Name,
				typeof(UI_CertificationNoticePanel)
			},
			{
				UI_CertificationTipPopup.Name,
				typeof(UI_CertificationTipPopup)
			},
			{
				UI_BoxCostItemTip.Name,
				typeof(UI_BoxCostItemTip)
			},
			{
				UI_RestartPanel.Name,
				typeof(UI_RestartPanel)
			},
			{
				UI_QuickBattlePanel.Name,
				typeof(UI_QuickBattlePanel)
			},
			{
				UI_PaymentOptionsDialog.Name,
				typeof(UI_PaymentOptionsDialog)
			},
			{
				UI_SpecialActivityPanel.Name,
				typeof(UI_SpecialActivityPanel)
			},
			{
				UI_PvpEnemySettingPanel.Name,
				typeof(UI_PvpEnemySettingPanel)
			},
			{
				UI_PvpSelectSoldiersPanel.Name,
				typeof(UI_PvpSelectSoldiersPanel)
			},
			{
				UI_PvpHelpPanel.Name,
				typeof(UI_PvpHelpPanel)
			},
			{
				UI_LadderTournamentPanel.Name,
				typeof(UI_LadderTournamentPanel)
			},
			{
				UI_PvpBattleVictory.Name,
				typeof(UI_PvpBattleVictory)
			},
			{
				UI_PvpBattleFail.Name,
				typeof(UI_PvpBattleFail)
			},
			{
				UI_StartRankBattleCountdown.Name,
				typeof(UI_StartRankBattleCountdown)
			},
			{
				UI_AddRankAttackBuffDialog.Name,
				typeof(UI_AddRankAttackBuffDialog)
			},
			{
				UI_AddRankDefenseBuffDialog.Name,
				typeof(UI_AddRankDefenseBuffDialog)
			},
			{
				UI_AddRankClearCDDialog.Name,
				typeof(UI_AddRankClearCDDialog)
			},
			{
				UI_ShowRankBattleBuff.Name,
				typeof(UI_ShowRankBattleBuff)
			},
			{
				UI_PvpScoreRankListPanel.Name,
				typeof(UI_PvpScoreRankListPanel)
			},
			{
				UI_PvpTotalRankListPanel.Name,
				typeof(UI_PvpTotalRankListPanel)
			},
			{
				UI_Rank_RewardPanel.Name,
				typeof(UI_Rank_RewardPanel)
			},
			{
				UI_PvPBattleResultAnimationEffect.Name,
				typeof(UI_PvPBattleResultAnimationEffect)
			},
			{
				UI_PvpZoneChoose.Name,
				typeof(UI_PvpZoneChoose)
			},
			{
				UI_PVPSeasonEntrancePanel.Name,
				typeof(UI_PVPSeasonEntrancePanel)
			},
			{
				UI_ServerWideConquestPanel.Name,
				typeof(UI_ServerWideConquestPanel)
			},
			{
				UI_ServerWideBattleReportSelectPanel.Name,
				typeof(UI_ServerWideBattleReportSelectPanel)
			},
			{
				UI_ServerWideBetSettingPanel.Name,
				typeof(UI_ServerWideBetSettingPanel)
			},
			{
				UI_ServerWideGroupReportPanel.Name,
				typeof(UI_ServerWideGroupReportPanel)
			},
			{
				UI_ServerWideBattleLogPanel.Name,
				typeof(UI_ServerWideBattleLogPanel)
			},
			{
				UI_ServerWideRewardPanel.Name,
				typeof(UI_ServerWideRewardPanel)
			},
			{
				UI_ServerWideMatchResultPanel.Name,
				typeof(UI_ServerWideMatchResultPanel)
			},
			{
				UI_PVPSeasonMatchResultPanel.Name,
				typeof(UI_PVPSeasonMatchResultPanel)
			},
			{
				UI_PVPSeasonMissionPanel.Name,
				typeof(UI_PVPSeasonMissionPanel)
			},
			{
				UI_UnlockPeakBattle.Name,
				typeof(UI_UnlockPeakBattle)
			},
			{
				UI_SelectServerWideBattleArrayPanel.Name,
				typeof(UI_SelectServerWideBattleArrayPanel)
			},
			{
				UI_PeakBattleSelectArrayPanel.Name,
				typeof(UI_PeakBattleSelectArrayPanel)
			},
			{
				UI_PresetFormationPanel.Name,
				typeof(UI_PresetFormationPanel)
			},
			{
				UI_PvpStorePanel.Name,
				typeof(UI_PvpStorePanel)
			},
			{
				UI_TopTournamentBattlePanel.Name,
				typeof(UI_TopTournamentBattlePanel)
			},
			{
				UI_TopTournamentEveryDayLogPanel.Name,
				typeof(UI_TopTournamentEveryDayLogPanel)
			},
			{
				UI_TopTournamentNameList.Name,
				typeof(UI_TopTournamentNameList)
			},
			{
				UI_TopTournamentHistoryRankList.Name,
				typeof(UI_TopTournamentHistoryRankList)
			},
			{
				UI_PvpBattleLogDetailPanel.Name,
				typeof(UI_PvpBattleLogDetailPanel)
			},
			{
				UI_MtgGiftPacksPanel.Name,
				typeof(UI_MtgGiftPacksPanel)
			},
			{
				UI_DataBackUpPanel.Name,
				typeof(UI_DataBackUpPanel)
			},
			{
				UI_NewbieMissionPanel.Name,
				typeof(UI_NewbieMissionPanel)
			},
			{
				UI_RemoveAccountPanel.Name,
				typeof(UI_RemoveAccountPanel)
			},
			{
				UI_FullScreenAnimationPanel.Name,
				typeof(UI_FullScreenAnimationPanel)
			},
			{
				UI_UnlockSoldierInfoPanel.Name,
				typeof(UI_UnlockSoldierInfoPanel)
			},
			{
				UI_GvGBattleRecordsPanel.Name,
				typeof(UI_GvGBattleRecordsPanel)
			},
			{
				UI_GvGBattleRecordDetailPanel.Name,
				typeof(UI_GvGBattleRecordDetailPanel)
			},
			{
				UI_GvGSingleBattleRecordPanel.Name,
				typeof(UI_GvGSingleBattleRecordPanel)
			},
			{
				UI_GvGBossDetailsPanel.Name,
				typeof(UI_GvGBossDetailsPanel)
			},
			{
				UI_GvGHelpPanel.Name,
				typeof(UI_GvGHelpPanel)
			},
			{
				UI_RewardDescriptionPanel.Name,
				typeof(UI_RewardDescriptionPanel)
			},
			{
				UI_IslandComeAgainMatchingPanel.Name,
				typeof(UI_IslandComeAgainMatchingPanel)
			},
			{
				UI_IslandComeAgainLotteryPanel.Name,
				typeof(UI_IslandComeAgainLotteryPanel)
			},
			{
				UI_MyTroopsPanel.Name,
				typeof(UI_MyTroopsPanel)
			},
			{
				UI_ReplenishTroopsPanel.Name,
				typeof(UI_ReplenishTroopsPanel)
			},
			{
				UI_ChangeTroopsPanel.Name,
				typeof(UI_ChangeTroopsPanel)
			},
			{
				UI_MainIslandPanel.Name,
				typeof(UI_MainIslandPanel)
			},
			{
				UI_IslandInfoPanel.Name,
				typeof(UI_IslandInfoPanel)
			},
			{
				UI_IslandComeAgainCheckRewardPanel.Name,
				typeof(UI_IslandComeAgainCheckRewardPanel)
			},
			{
				UI_IslandComeAgainExchangeCurrencyPanel.Name,
				typeof(UI_IslandComeAgainExchangeCurrencyPanel)
			},
			{
				UI_IslandComeAgainBattleResultPanel.Name,
				typeof(UI_IslandComeAgainBattleResultPanel)
			},
			{
				UI_TroopsChangeConfirmPanel.Name,
				typeof(UI_TroopsChangeConfirmPanel)
			},
			{
				UI_IslandComeAgainHelpPanel.Name,
				typeof(UI_IslandComeAgainHelpPanel)
			},
			{
				UI_IslandComeAgainBattleRecordsPanel.Name,
				typeof(UI_IslandComeAgainBattleRecordsPanel)
			},
			{
				UI_IslandComeAgainBattleRecordDetailPanel.Name,
				typeof(UI_IslandComeAgainBattleRecordDetailPanel)
			},
			{
				UI_main_LegendItemBlueprintInfoPanel.Name,
				typeof(UI_main_LegendItemBlueprintInfoPanel)
			},
			{
				UI_main_LegendItemBlueprintForge.Name,
				typeof(UI_main_LegendItemBlueprintForge)
			},
			{
				UI_main_LegendItemEvoConfirm.Name,
				typeof(UI_main_LegendItemEvoConfirm)
			},
			{
				UI_main_LegendItemBlueprintSelect.Name,
				typeof(UI_main_LegendItemBlueprintSelect)
			},
			{
				UI_main_LegendItemBlueprintForgeConfirm.Name,
				typeof(UI_main_LegendItemBlueprintForgeConfirm)
			},
			{
				UI_main_SelectBlueprintPopup.Name,
				typeof(UI_main_SelectBlueprintPopup)
			},
			{
				UI_main_OptionalBlueprintPopup.Name,
				typeof(UI_main_OptionalBlueprintPopup)
			},
			{
				UI_main_ObtainBlueprintPopup.Name,
				typeof(UI_main_ObtainBlueprintPopup)
			},
			{
				UI_main_ShowForgeResult.Name,
				typeof(UI_main_ShowForgeResult)
			},
			{
				UI_main_LegendItemIdentityConfirm.Name,
				typeof(UI_main_LegendItemIdentityConfirm)
			},
			{
				UI_main_GVGStorePanel.Name,
				typeof(UI_main_GVGStorePanel)
			},
			{
				UI_main_GVGStoreHelpPanel.Name,
				typeof(UI_main_GVGStoreHelpPanel)
			},
			{
				UI_main_GVGStoreExchangeFormulaPanel.Name,
				typeof(UI_main_GVGStoreExchangeFormulaPanel)
			},
			{
				UI_main_GVGStoreExchangeConfirmPanel.Name,
				typeof(UI_main_GVGStoreExchangeConfirmPanel)
			},
			{
				UI_main_GVGStoreRefreshConfirmPanel.Name,
				typeof(UI_main_GVGStoreRefreshConfirmPanel)
			},
			{
				UI_main_GVGStoreBuyConfirmPanel.Name,
				typeof(UI_main_GVGStoreBuyConfirmPanel)
			},
			{
				UI_main_GVGStoreSilenceBuyConfirmPanel.Name,
				typeof(UI_main_GVGStoreSilenceBuyConfirmPanel)
			},
			{
				UI_main_GVGStoreSilenceConfilmPanel.Name,
				typeof(UI_main_GVGStoreSilenceConfilmPanel)
			},
			{
				UI_main_GVGStoreUnlockStoreroomSlotPanel.Name,
				typeof(UI_main_GVGStoreUnlockStoreroomSlotPanel)
			},
			{
				UI_main_LegendItemBlueprintTemplatePanel.Name,
				typeof(UI_main_LegendItemBlueprintTemplatePanel)
			},
			{
				UI_main_GVGStoreJumpPanel.Name,
				typeof(UI_main_GVGStoreJumpPanel)
			},
			{
				UI_main_GVGStoreRareStoreItemRefreshConfirmPanel.Name,
				typeof(UI_main_GVGStoreRareStoreItemRefreshConfirmPanel)
			},
			{
				UI_main_GvGWorldMap3.Name,
				typeof(UI_main_GvGWorldMap3)
			},
			{
				UI_main_OpertionRebellionLimitPanel.Name,
				typeof(UI_main_OpertionRebellionLimitPanel)
			},
			{
				UI_main_IslandDefenders.Name,
				typeof(UI_main_IslandDefenders)
			},
			{
				UI_main_IslandPlayers.Name,
				typeof(UI_main_IslandPlayers)
			},
			{
				UI_main_IslandOutput.Name,
				typeof(UI_main_IslandOutput)
			},
			{
				UI_main_ShowEfficiencyBuff.Name,
				typeof(UI_main_ShowEfficiencyBuff)
			},
			{
				UI_main_SuppressBonusLimitPanel.Name,
				typeof(UI_main_SuppressBonusLimitPanel)
			},
			{
				UI_main_GvGShipLaunch.Name,
				typeof(UI_main_GvGShipLaunch)
			},
			{
				UI_main_GvGMode3CollectingPanel.Name,
				typeof(UI_main_GvGMode3CollectingPanel)
			},
			{
				UI_main_FillUpConfirm.Name,
				typeof(UI_main_FillUpConfirm)
			},
			{
				UI_main_SharePopupPanel.Name,
				typeof(UI_main_SharePopupPanel)
			},
			{
				UI_main_GvGTalentPanel.Name,
				typeof(UI_main_GvGTalentPanel)
			},
			{
				UI_main_GvGStoreHousePanel.Name,
				typeof(UI_main_GvGStoreHousePanel)
			},
			{
				UI_main_AmpScoreDetailPanel.Name,
				typeof(UI_main_AmpScoreDetailPanel)
			},
			{
				UI_main_GvGSettlementPanel.Name,
				typeof(UI_main_GvGSettlementPanel)
			},
			{
				UI_main_GvGResetTalents.Name,
				typeof(UI_main_GvGResetTalents)
			},
			{
				UI_main_IslandBattleRecordPanel.Name,
				typeof(UI_main_IslandBattleRecordPanel)
			},
			{
				UI_main_IslandBuffPanel.Name,
				typeof(UI_main_IslandBuffPanel)
			},
			{
				UI_main_IslandCampaignPanel.Name,
				typeof(UI_main_IslandCampaignPanel)
			},
			{
				UI_main_GvG3BattleRecordsPanel.Name,
				typeof(UI_main_GvG3BattleRecordsPanel)
			},
			{
				UI_main_GvG3RecordDetailPanel.Name,
				typeof(UI_main_GvG3RecordDetailPanel)
			},
			{
				UI_main_GvG3Chat.Name,
				typeof(UI_main_GvG3Chat)
			},
			{
				UI_main_GvG3ChatSendCost.Name,
				typeof(UI_main_GvG3ChatSendCost)
			},
			{
				UI_main_GvG3ChatRedirectIsland.Name,
				typeof(UI_main_GvG3ChatRedirectIsland)
			},
			{
				UI_main_GvGFlagshipPanel.Name,
				typeof(UI_main_GvGFlagshipPanel)
			},
			{
				UI_main_GvG3Exchange.Name,
				typeof(UI_main_GvG3Exchange)
			},
			{
				UI_main_GvG3PostOEMMission.Name,
				typeof(UI_main_GvG3PostOEMMission)
			},
			{
				UI_main_GvG3FormulaForge.Name,
				typeof(UI_main_GvG3FormulaForge)
			},
			{
				UI_main_GvG3FormulaOemBonus.Name,
				typeof(UI_main_GvG3FormulaOemBonus)
			},
			{
				UI_main_GvG3FormulaOemResult.Name,
				typeof(UI_main_GvG3FormulaOemResult)
			},
			{
				UI_main_GvG3OemResult.Name,
				typeof(UI_main_GvG3OemResult)
			},
			{
				UI_main_GvG3OemForge.Name,
				typeof(UI_main_GvG3OemForge)
			},
			{
				UI_main_GvG3OemBonus.Name,
				typeof(UI_main_GvG3OemBonus)
			},
			{
				UI_main_GvG3OutsourcingAmplifier.Name,
				typeof(UI_main_GvG3OutsourcingAmplifier)
			},
			{
				UI_main_GvG3PurificationResult.Name,
				typeof(UI_main_GvG3PurificationResult)
			},
			{
				UI_main_GvG3Purification.Name,
				typeof(UI_main_GvG3Purification)
			},
			{
				UI_main_SupplyDepot.Name,
				typeof(UI_main_SupplyDepot)
			},
			{
				UI_main_CampPlayers.Name,
				typeof(UI_main_CampPlayers)
			},
			{
				UI_main_FlagShipMissions.Name,
				typeof(UI_main_FlagShipMissions)
			},
			{
				UI_main_MainMissionCampBonus.Name,
				typeof(UI_main_MainMissionCampBonus)
			},
			{
				UI_main_TreasureMap.Name,
				typeof(UI_main_TreasureMap)
			},
			{
				UI_main_GvG3EventNpcDialog.Name,
				typeof(UI_main_GvG3EventNpcDialog)
			},
			{
				UI_main_GvG3EventNpcShop.Name,
				typeof(UI_main_GvG3EventNpcShop)
			},
			{
				UI_main_BossBreakDownTip.Name,
				typeof(UI_main_BossBreakDownTip)
			},
			{
				UI_SoulKeyStorePanel.Name,
				typeof(UI_SoulKeyStorePanel)
			},
			{
				UI_main_StellarKeyCraftPopup.Name,
				typeof(UI_main_StellarKeyCraftPopup)
			},
			{
				UI_main_StellarKeyStorePanel.Name,
				typeof(UI_main_StellarKeyStorePanel)
			},
			{
				UI_main_StellarKeyBuyPanel.Name,
				typeof(UI_main_StellarKeyBuyPanel)
			},
			{
				UI_main_GvG3BuyNpcStoreItem.Name,
				typeof(UI_main_GvG3BuyNpcStoreItem)
			},
			{
				UI_main_BuyBattlePass.Name,
				typeof(UI_main_BuyBattlePass)
			},
			{
				UI_main_BattlePassMission.Name,
				typeof(UI_main_BattlePassMission)
			},
			{
				UI_main_GvG3BattlePass.Name,
				typeof(UI_main_GvG3BattlePass)
			},
			{
				UI_GuestRegistPopup.Name,
				typeof(UI_GuestRegistPopup)
			},
			{
				UI_CopyInvitingCodeWindow.Name,
				typeof(UI_CopyInvitingCodeWindow)
			},
			{
				UI_main_CancelCommand.Name,
				typeof(UI_main_CancelCommand)
			},
			{
				UI_main_PlayerCommand.Name,
				typeof(UI_main_PlayerCommand)
			},
			{
				UI_main_LandOfEternalNightCampBonus.Name,
				typeof(UI_main_LandOfEternalNightCampBonus)
			},
			{
				UI_main_LandOfEternalNight.Name,
				typeof(UI_main_LandOfEternalNight)
			},
			{
				UI_main_GvG3StoreEntrance.Name,
				typeof(UI_main_GvG3StoreEntrance)
			},
			{
				UI_main_GvG3IslandEventRanking.Name,
				typeof(UI_main_GvG3IslandEventRanking)
			},
			{
				UI_main_IslandDescription.Name,
				typeof(UI_main_IslandDescription)
			},
			{
				UI_main_GvG3ConfirmChangeLegendItem.Name,
				typeof(UI_main_GvG3ConfirmChangeLegendItem)
			},
			{
				UI_main_ProgressSettlement.Name,
				typeof(UI_main_ProgressSettlement)
			},
			{
				UI_main_IslandRewards.Name,
				typeof(UI_main_IslandRewards)
			},
			{
				UI_main_ProgressRewardPreview.Name,
				typeof(UI_main_ProgressRewardPreview)
			},
			{
				UI_main_GameInstructions.Name,
				typeof(UI_main_GameInstructions)
			},
			{
				UI_main_LeaderboardRewards.Name,
				typeof(UI_main_LeaderboardRewards)
			},
			{
				UI_main_GvG3Medal.Name,
				typeof(UI_main_GvG3Medal)
			},
			{
				UI_main_GvG3Video.Name,
				typeof(UI_main_GvG3Video)
			},
			{
				UI_JumpTip.Name,
				typeof(UI_JumpTip)
			},
			{
				UI_com_Armistice.Name,
				typeof(UI_com_Armistice)
			},
			{
				UI_main_FireSupportConfirmPanel.Name,
				typeof(UI_main_FireSupportConfirmPanel)
			},
			{
				UI_main_GreenChannelConfirmPanel.Name,
				typeof(UI_main_GreenChannelConfirmPanel)
			},
			{
				UI_main_OuterTechI67502.Name,
				typeof(UI_main_OuterTechI67502)
			},
			{
				UI_main_OutTechHelpPanel.Name,
				typeof(UI_main_OutTechHelpPanel)
			},
			{
				UI_OccupationPanel.Name,
				typeof(UI_OccupationPanel)
			},
			{
				UI_main_BuySweepCountDialog.Name,
				typeof(UI_main_BuySweepCountDialog)
			},
			{
				UI_main_SplitBlueprint.Name,
				typeof(UI_main_SplitBlueprint)
			},
			{
				UI_main_BlueprintToBeSplit.Name,
				typeof(UI_main_BlueprintToBeSplit)
			},
			{
				UI_main_DisplaySplitEffect.Name,
				typeof(UI_main_DisplaySplitEffect)
			},
			{
				UI_main_PostFormulaOem.Name,
				typeof(UI_main_PostFormulaOem)
			},
			{
				UI_main_PostFormulaOemFilter.Name,
				typeof(UI_main_PostFormulaOemFilter)
			},
			{
				UI_main_FormulaOemFilter.Name,
				typeof(UI_main_FormulaOemFilter)
			},
			{
				UI_main_PostNewFormulaTip.Name,
				typeof(UI_main_PostNewFormulaTip)
			},
			{
				UI_main_PurificationEffect.Name,
				typeof(UI_main_PurificationEffect)
			},
			{
				UI_main_GiftOfLord.Name,
				typeof(UI_main_GiftOfLord)
			},
			{
				UI.SpecialActivity.UI_HelpPanel.Name,
				typeof(UI.SpecialActivity.UI_HelpPanel)
			},
			{
				UI_main_Souvenir.Name,
				typeof(UI_main_Souvenir)
			},
			{
				UI_main_PvpRankAFKAssistant.Name,
				typeof(UI_main_PvpRankAFKAssistant)
			},
			{
				UI_main_MilitaryAFKAssistant.Name,
				typeof(UI_main_MilitaryAFKAssistant)
			},
			{
				UI_main_RepeatedAttackPlanHelper.Name,
				typeof(UI_main_RepeatedAttackPlanHelper)
			},
			{
				UI_main_CreateRepeatedAttackPlan.Name,
				typeof(UI_main_CreateRepeatedAttackPlan)
			},
			{
				UI_main_BlueprintGachaDetailInfoPanel.Name,
				typeof(UI_main_BlueprintGachaDetailInfoPanel)
			},
			{
				UI_main_BuyGvGInsurance.Name,
				typeof(UI_main_BuyGvGInsurance)
			},
			{
				UI_main_SelectInsuranceShip.Name,
				typeof(UI_main_SelectInsuranceShip)
			},
			{
				UI_main_InsuranceShip.Name,
				typeof(UI_main_InsuranceShip)
			},
			{
				UI_main_PvPEntranceUnlockTip.Name,
				typeof(UI_main_PvPEntranceUnlockTip)
			},
			{
				UI_main_ReturningRewards.Name,
				typeof(UI_main_ReturningRewards)
			},
			{
				UI_main_ReturningRewardsPreview.Name,
				typeof(UI_main_ReturningRewardsPreview)
			},
			{
				UI_main_ReturningMissions.Name,
				typeof(UI_main_ReturningMissions)
			},
			{
				UI_main_BrawlFightEnroll.Name,
				typeof(UI_main_BrawlFightEnroll)
			},
			{
				UI_main_BrawlFightRuleHelp.Name,
				typeof(UI_main_BrawlFightRuleHelp)
			},
			{
				UI_main_BrawlFightRuleHelp2.Name,
				typeof(UI_main_BrawlFightRuleHelp2)
			},
			{
				UI_main_BrawlFightSelectIsland.Name,
				typeof(UI_main_BrawlFightSelectIsland)
			},
			{
				UI_main_BrawlFightSelectPosition.Name,
				typeof(UI_main_BrawlFightSelectPosition)
			},
			{
				UI_main_BrawlCalendar.Name,
				typeof(UI_main_BrawlCalendar)
			},
			{
				UI_main_BrawlBattleResult.Name,
				typeof(UI_main_BrawlBattleResult)
			},
			{
				UI_main_BrawlIslandBonusPreview.Name,
				typeof(UI_main_BrawlIslandBonusPreview)
			},
			{
				UI_main_BrawlBuffInfo.Name,
				typeof(UI_main_BrawlBuffInfo)
			},
			{
				UI_main_ReturningInstructions.Name,
				typeof(UI_main_ReturningInstructions)
			},
			{
				UI_main_ReturningFirstTimeFX.Name,
				typeof(UI_main_ReturningFirstTimeFX)
			},
			{
				UI_main_BrawlBattleRankInfo.Name,
				typeof(UI_main_BrawlBattleRankInfo)
			},
			{
				UI_main_weekActivityStorePanel.Name,
				typeof(UI_main_weekActivityStorePanel)
			},
			{
				UI_popup_SpinActivityResult.Name,
				typeof(UI_popup_SpinActivityResult)
			},
			{
				UI_popup_weekGiftPackPanel.Name,
				typeof(UI_popup_weekGiftPackPanel)
			},
			{
				UI_popup_weekSpinCard.Name,
				typeof(UI_popup_weekSpinCard)
			},
			{
				UI_popup_probabilityDescription.Name,
				typeof(UI_popup_probabilityDescription)
			},
			{
				UI_Popup_getTicket.Name,
				typeof(UI_Popup_getTicket)
			},
			{
				UI_main_DailyMission.Name,
				typeof(UI_main_DailyMission)
			},
			{
				UI_main_BuyWeekActPass.Name,
				typeof(UI_main_BuyWeekActPass)
			}
		};
		_pendingUis = new Dictionary<string, TaskCompletionSource<bool>>();
		_uisQueueList.Clear();
		_currentQueuePlaying = null;
		_maskCover = null;
		_isLoadingMaskCover = false;
		_isLoadingEdgeMask = false;
		_isMaskCoverTouchable = false;
		_uiNotTouchableIndex = 0;
		_uiNotTouchable = new HashSet<int>();
		TryDisposeWaitingPanel();
		_isLoadingWaitingPanel = false;
		_isShowWaitingPanel = false;
	}

	public void InitInstance()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (((Scene)(ref scene)).name == "Load")
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
			RemoveEventsListener();
		}
	}

	public void Init()
	{
	}

	public void Destroy()
	{
	}

	public void AddEventsListener()
	{
		SharedMessenger.AddListener<string, Dictionary<string, object>, TaskCompletionSource<bool>>("ACTION_OPEN_UI", OnRequestOpenUi);
		SharedMessenger.AddListener<string>("ACTION_CLOSE_UI", OnRequestCloseUi);
		SharedMessenger.AddListener<string>("STORY_SKIP", OnStorySkip);
	}

	public void RemoveEventsListener()
	{
		SharedMessenger.RemoveListener<string, Dictionary<string, object>, TaskCompletionSource<bool>>("ACTION_OPEN_UI", OnRequestOpenUi);
		SharedMessenger.RemoveListener<string>("ACTION_CLOSE_UI", OnRequestCloseUi);
		SharedMessenger.RemoveListener<string>("STORY_SKIP", OnStorySkip);
		UI_MaskCover uI_MaskCover = _maskCover;
		if (uI_MaskCover != null)
		{
			((GObject)uI_MaskCover).Dispose();
		}
		_maskCover = null;
		TryDisposeWaitingPanel();
		UI_WaitingPanel uI_WaitingPanel = _paymentWaitingPanel;
		if (uI_WaitingPanel != null)
		{
			((GObject)uI_WaitingPanel).Dispose();
		}
		_paymentWaitingPanel = null;
	}

	private void OnStorySkip(string uiName)
	{
		if (!string.IsNullOrEmpty(uiName))
		{
			OnUIClosed(uiName, responseContinue: false);
			SentrySdk.AddBreadcrumb("OnStorySkip ClosePanel " + uiName);
			ClosePanel(uiName);
		}
	}

	private void OnRequestOpenUi(string uiName, Dictionary<string, object> parameters, TaskCompletionSource<bool> taskCompletionSource = null)
	{
		if (taskCompletionSource != null && uiName != "UI_FullScreenAnimationPanel")
		{
			if (_pendingUis.ContainsKey(uiName))
			{
				return;
			}
			_pendingUis.Add(uiName, taskCompletionSource);
		}
		OpenPanel(uiName, parameters);
	}

	private void OnRequestCloseUi(string uiName)
	{
		SentrySdk.AddBreadcrumb("OnRequestCloseUi(" + uiName + ")");
		ClosePanel(uiName);
	}

	public void PreLoadPackage(string name, Action action)
	{
		LoadPackage(name).Then((Action)delegate
		{
			action?.Invoke();
		});
	}

	private Promise LoadPackage(string packageName)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		if (_loadingPackages.TryGetValue(packageName, out var value))
		{
			return value;
		}
		Promise promise = new Promise();
		string id = "FGUI/" + packageName + "/" + packageName;
		if (_packages.ContainsKey(id) && _packages[id])
		{
			promise.Resolve();
			return promise;
		}
		_loadingPackages[packageName] = promise;
		Type.GetType("UI." + packageName + "." + packageName + "Binder")?.GetMethod("BindAll")?.Invoke(null, null);
		PooledList<IPromise<AssetBundle>> list = ObjectPool<PooledList<IPromise<AssetBundle>>>.Spawn((Func<PooledList<IPromise<AssetBundle>>>)(() => new PooledList<IPromise<AssetBundle>>()));
		((List<IPromise<AssetBundle>>)(object)list).Add((IPromise<AssetBundle>)(object)AssetsManager.Instance.LoadAssetBundle(id + "_desc.ab"));
		if (AssetsManager.Instance.IsAssetBundleExists(id + "_res.ab"))
		{
			((List<IPromise<AssetBundle>>)(object)list).Add((IPromise<AssetBundle>)(object)AssetsManager.Instance.LoadAssetBundle(id + "_res.ab"));
		}
		Promise<AssetBundle>.All((IEnumerable<IPromise<AssetBundle>>)list).Then((Action<IEnumerable<AssetBundle>>)delegate(IEnumerable<AssetBundle> assetBundles)
		{
			AssetBundle val = null;
			AssetBundle val2 = null;
			int num = 0;
			foreach (AssetBundle assetBundle in assetBundles)
			{
				switch (num)
				{
				case 0:
					val = assetBundle;
					break;
				case 1:
					val2 = assetBundle;
					break;
				}
				num++;
			}
			if (val != null && val2 != null)
			{
				UIPackage.AddPackage(val, val2);
				HotUpdateProcess.UnloadAssetBundle(id + "_desc.ab");
				_packages[id] = true;
				promise.Resolve();
			}
			else if (val != null)
			{
				UIPackage.AddPackage(val);
				HotUpdateProcess.UnloadAssetBundle(id + "_desc.ab");
				_packages[id] = true;
				promise.Resolve();
			}
			else
			{
				promise.Reject((Exception)new ArgumentException("FairyGUI AB包 " + id + " descBundle 加载失败!"));
			}
		}).Catch((Action<Exception>)delegate(Exception ex)
		{
			SentrySdk.AddBreadcrumb(ex.Message + ":" + ex.StackTrace);
			ILRuntimeDebug.LogException(ex);
			promise.Reject((Exception)new ArgumentException("FairyGUI AB包 " + id + " 加载失败!"));
		})
			.Finally((Action)delegate
			{
				list.UnSpawn();
				_loadingPackages.Remove(packageName);
			});
		return promise;
	}

	public void UnloadPackage(string packageName)
	{
		string text = "FGUI/" + packageName + "/" + packageName;
		if (_packages.ContainsKey(text) && _packages[text])
		{
			AssetsManager.Instance.UnloadAssetBundle(text + "_desc.ab");
			if (AssetsManager.Instance.IsAssetBundleExists(text + "_res.ab"))
			{
				AssetsManager.Instance.UnloadAssetBundle(text + "_res.ab");
			}
			if (!AssetsManager.Instance.IsAssetBundleInUsing(text + "_desc.ab"))
			{
				_packages[text] = false;
				UIPackage.RemovePackage(packageName);
			}
		}
	}

	public void OpenPanel(string identifier, Dictionary<string, object> parameters, bool multiMode = false, bool ignoreQueue = false, Action<Exception> errorCallback = null, Action ui_callback = null)
	{
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		if (!_resourceMaps.ContainsKey(identifier))
		{
			errorCallback?.Invoke(new ArgumentOutOfRangeException("找不到 " + identifier + " 对应的代码"));
			if (_pendingUis.TryGetValue(identifier, out var value))
			{
				value.TrySetResult(result: false);
			}
			return;
		}
		SharedMessenger.Broadcast("START_LOADING_UI", identifier);
		if (_uisNeedQueuePlay.Contains(identifier) && !ignoreQueue)
		{
			multiMode = false;
			if (_currentQueuePlaying != null)
			{
				_uisQueueList.Enqueue(new KeyValuePair<string, Dictionary<string, object>>(identifier, parameters));
				return;
			}
			_currentQueuePlaying = identifier;
		}
		Type type = _resourceMaps[identifier];
		string text = type.Namespace?.Replace("UI.", "");
		Window windowLoader = new Window();
		((GObject)windowLoader).gameObjectName = identifier;
		if (UI_SortingOrder.ContainsKey(identifier))
		{
			((GObject)windowLoader).sortingOrder = UI_SortingOrder[identifier];
		}
		else
		{
			((GObject)windowLoader).sortingOrder = 1000;
		}
		((GComponent)GRoot.inst).AddChild((GObject)(object)windowLoader);
		if (!multiMode)
		{
			_uiParamList.Add(new UIParameters
			{
				UIName = identifier,
				Params = parameters
			});
		}
		Action<Exception> onLoadError = delegate(Exception ex)
		{
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)windowLoader, true);
			errorCallback?.Invoke(ex);
		};
		SentrySdk.AddBreadcrumb("LoadPackage packageName=" + text + " identifier=" + identifier);
		GComponentCreator val = default(GComponentCreator);
		LoadPackage(text).Then((Action)delegate
		{
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Expected O, but got Unknown
			//IL_00c4: Expected O, but got Unknown
			if (!_createInstanceMethodMap.TryGetValue(identifier, out var value2))
			{
				value2 = type.GetMethod("CreateInstance", BindingFlags.Static | BindingFlags.Public);
				if (value2 == null)
				{
					onLoadError(new InvalidProgramException(identifier + " 没有实现CreateInstance方法"));
					return;
				}
				_createInstanceMethodMap.Add(identifier, value2);
			}
			try
			{
				MethodInfo method = type.GetMethod("GetURL", BindingFlags.Static | BindingFlags.Public);
				string text2 = (string)method.Invoke(null, null);
				GComponentCreator obj = val;
				if (obj == null)
				{
					GComponentCreator val2 = () => HotFixManager.Instance.appdomain.Instantiate<GComponent>(type.FullName, (object[])null);
					GComponentCreator val3 = val2;
					val = val2;
					obj = val3;
				}
				UIObjectFactory.SetPackageItemExtension(text2, obj);
				InternalOpenPanel(windowLoader, type, value2, identifier, parameters, multiMode, ui_callback);
			}
			catch (Exception ex)
			{
				Debug.LogError((object)$"OpenPanel {identifier} Error : {ex}");
				onLoadError(ex);
			}
		}).Catch((Action<Exception>)delegate(Exception ex)
		{
			Debug.LogError((object)("Catch ! OpenPanelError : " + ex));
			onLoadError(ex);
		});
	}

	private void InternalOpenPanel(Window windowLoader, Type type, MethodInfo method, string identifier, Dictionary<string, object> parameters, bool multiMode = false, Action ui_callback = null)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		GObject val = (GObject)method.Invoke(null, null);
		DictUI[identifier] = val;
		if (val == null)
		{
			throw new ArgumentOutOfRangeException("找不到 " + identifier + " 对应的资源");
		}
		if (_uis.ContainsKey(identifier) && !multiMode)
		{
			SentrySdk.AddBreadcrumb("Duplicated UI " + identifier + " On Stage, Close Old One");
			ClosePanel(identifier, reservePackageRes: true);
		}
		if (!multiMode)
		{
			_uis.Add(identifier, val);
			int changeId = SetUiNotTouchable(identifier);
			((MonoBehaviour)this).StartCoroutine(SetUiTouchableAfterDelayAsync(300, changeId));
		}
		MethodInfo method2 = type.GetMethod("RegisterUiEventListeners");
		if (method2 != null)
		{
			method2.Invoke(val, null);
		}
		MethodInfo method3 = type.GetMethod("Init");
		if (method3 != null)
		{
			method3.Invoke(val, new object[1] { parameters });
		}
		if (!_ipConstants.IsTipUi(identifier))
		{
			windowLoader.contentPane = UIPackage.CreateObject("PublicResources", "WindowLoader").asCom;
			((GObject)windowLoader.contentPane).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
			((GObject)windowLoader.contentPane).AddRelation((GObject)(object)GRoot.inst, (RelationType)24);
			windowLoader.contentPane.AddChild(val);
			windowLoader.Show();
			if (!canNotChangeBack.Contains(identifier))
			{
				SetPanelMask(val);
			}
			if (identifier == UI_MaterialIntroductionPanel.Name && parameters.TryGetValue("Parent", out var value) && (value is UI_PushGiftBagPanel || value is UI_TakeItems))
			{
				MethodInfo method4 = type.GetMethod("TryBringToFont");
				if (method4 != null)
				{
					method4.Invoke(val, new object[1] { windowLoader });
				}
			}
		}
		else
		{
			((GComponent)GRoot.inst).AddChild(val);
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)windowLoader, true);
		}
		MethodInfo method5 = type.GetMethod("OnShow");
		if (method5 != null)
		{
			method5.Invoke(val, null);
		}
		if (identifier == UI_PaymentOptionsDialog.Name)
		{
			(val as UI_PaymentOptionsDialog).SetUICallBack(ui_callback);
		}
		OnUIOpened(identifier, parameters);
	}

	public void ChangeAllUiSizeAndPos()
	{
		foreach (KeyValuePair<string, GObject> ui in _uis)
		{
			bool scaleAdaption = canNotChangeBack.Contains(ui.Key) || FGUIManager.HasUiScaleAdaptation(ui.Value);
			FGUIManager.SetUiPanelSizeAndXy(ui.Value, scaleAdaption);
			if (!canNotChangeBack.Contains(ui.Key))
			{
				ResizeBackgroundAndMask(ui.Value);
			}
		}
	}

	private void ResizeBackgroundAndMask(GObject panel)
	{
		float width = ((GObject)GRoot.inst).width;
		float num = ((GObject)GRoot.inst).height;
		bool flag = panel.parent != null && !(panel.parent is UI_WindowLoader);
		if (AspectRatio <= 1f)
		{
			num = width / 1.7777778f;
		}
		if (!flag)
		{
			for (int i = 0; i < backNames.Count; i++)
			{
				GObject child = panel.asCom.GetChild(backNames[i]);
				if (child != null && (child is GLoader || child is GComponent))
				{
					child.SetSize(width, num);
					break;
				}
			}
		}
		foreach (string maskName in maskNames)
		{
			GObject child2 = panel.asCom.GetChild(maskName);
			if (child2 != null && (child2 is GGraph || child2 is GImage))
			{
				ChangePanelMaskSize(child2, flag);
				break;
			}
		}
	}

	public void SetPanelMask(GObject panel, bool privatePanel = false)
	{
		if (AspectRatio <= 1f || !(panel is GComponent))
		{
			return;
		}
		if (!privatePanel)
		{
			for (int i = 0; i < backNames.Count; i++)
			{
				GObject child = panel.asCom.GetChild(backNames[i]);
				if (child != null && (child is GLoader || child is GComponent))
				{
					AddPanelBackGraph(child);
					child.SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
					break;
				}
			}
		}
		for (int j = 0; j < maskNames.Count; j++)
		{
			GObject child2 = panel.asCom.GetChild(maskNames[j]);
			if (child2 != null && (child2 is GGraph || child2 is GImage))
			{
				ChangePanelMaskSize(child2, privatePanel);
				break;
			}
		}
	}

	public void AddPanelBackGraph(GObject _mask)
	{
		object obj;
		if (_mask == null)
		{
			obj = null;
		}
		else
		{
			GComponent parent = _mask.parent;
			obj = ((parent != null) ? ((GObject)parent).parent : null);
		}
		GComponent val = (GComponent)obj;
		if (val != null && (_mask is GLoader || _mask is GComponent))
		{
			Instance.SetEdgeMaskVisible(value: true);
		}
	}

	public void ChangePanelMaskSize(GObject _mask, bool privatePanel = false)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		GObject obj = _mask;
		object obj2;
		if (obj == null)
		{
			obj2 = null;
		}
		else
		{
			GComponent parent = obj.parent;
			obj2 = ((parent != null) ? ((GObject)parent).parent : null);
		}
		GComponent val = (GComponent)obj2;
		if (privatePanel)
		{
			GObject obj3 = _mask;
			val = ((obj3 != null) ? obj3.parent : null);
		}
		if (val == null)
		{
			return;
		}
		GObject child = val.GetChild("OuterMask");
		if (child == null && (_mask is GGraph || _mask is GImage))
		{
			GGraph val2 = new GGraph();
			((GObject)val2).name = "OuterMask";
			((GObject)val2).SetPivot(0.5f, 0.5f);
			((GObject)val2).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
			Color val3 = Color.black;
			float alpha = _mask.alpha;
			float num = 0f;
			if (_mask is GGraph)
			{
				val3 = _mask.asGraph.color;
			}
			if (_mask is GImage)
			{
				alpha = 0.65f;
			}
			if (privatePanel)
			{
				num = 0f - ((GObject)val).x;
			}
			val2.DrawRect(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height, 0, Color.black, val3);
			((GObject)val2).touchable = _mask.touchable;
			((GObject)val2).alpha = alpha;
			((GObject)val2).onClick.Add((EventCallback0)delegate
			{
				_mask.onClick.Call();
			});
			((GObject)val2).visible = _mask.visible;
			val.AddChildAt((GObject)(object)val2, 0);
			((GObject)val2).SetXY(num, 0f);
			((GObject)val2).SetSize(((GObject)val).width, ((GObject)val).height);
			((GObject)val2).AddRelation((GObject)(object)val, (RelationType)24);
			_mask.alpha = 0f;
		}
	}

	public void GetScreenWidthHeightRadio()
	{
		float num = (float)Screen.width / (float)Screen.height;
		AspectRatio = num / 1.7777778f;
	}

	private IEnumerator SetUiTouchableAfterDelayAsync(int milliseconds, int changeId)
	{
		if (changeId != -1)
		{
			yield return (object)new WaitForSeconds((float)milliseconds / 1000f);
			SetUiTouchable(changeId);
		}
	}

	public bool CheckIsMainCityShowed()
	{
		if (!_uis.ContainsKey(UI_MainCity.Name) && !_uis.ContainsKey(UI_Battle.Name))
		{
			return false;
		}
		int num = (_uis.ContainsKey(UI_Guide.Name) ? (_uis.Count - 1) : _uis.Count);
		num = (_uis.ContainsKey(UI_NewbieMissionPanel.Name) ? (num - 1) : num);
		if ((_uis.ContainsKey(UI_RollingMarqueePanel.Name) && num == 2) || (!_uis.ContainsKey(UI_RollingMarqueePanel.Name) && num == 1))
		{
			return true;
		}
		return false;
	}

	public bool IsOnTop(string uiName)
	{
		if (_uis.Count == 0)
		{
			return false;
		}
		UIParameters uIParameters = _uiParamList.Last();
		return uIParameters.UIName == uiName;
	}

	public bool CheckIsMainCityShowedForNewGuideMode()
	{
		if (!GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
		{
			return false;
		}
		if (!_uis.ContainsKey(UI_MainCity.Name))
		{
			return false;
		}
		int num = (_uis.ContainsKey(UI_NewbieMissionPanel.Name) ? (_uis.Count - 1) : _uis.Count);
		if ((_uis.ContainsKey(UI_RollingMarqueePanel.Name) && num == 2) || (!_uis.ContainsKey(UI_RollingMarqueePanel.Name) && num == 1))
		{
			return true;
		}
		return false;
	}

	public bool CheckIsWorldMapShowed()
	{
		if (!_uis.ContainsKey(UI_MainCity.Name) && !_uis.ContainsKey(UI_Battle.Name) && !_uis.ContainsKey(UI_WorldMapPanel.Name))
		{
			return false;
		}
		int num = (_uis.ContainsKey(UI_Guide.Name) ? (_uis.Count - 1) : _uis.Count);
		if ((_uis.ContainsKey(UI_RollingMarqueePanel.Name) && num == 3) || (!_uis.ContainsKey(UI_RollingMarqueePanel.Name) && num == 2))
		{
			return true;
		}
		return false;
	}

	public bool CheckIsClearUi()
	{
		int num = (_uis.ContainsKey(UI_RollingMarqueePanel.Name) ? (_uis.Count - 1) : _uis.Count);
		return num <= 0;
	}

	public void ClosePanel(string identifier, bool reservePackageRes = false)
	{
		if (DictUI.TryGetValue(identifier, out var _))
		{
			DictUI.Remove(identifier);
		}
		if (!_uis.TryGetValue(identifier, out var value2))
		{
			return;
		}
		FGUIManager.RemoveUIsScaleAdaptation(value2);
		int changeId = SetUiNotTouchable(identifier);
		_uis.Remove(identifier);
		_uiParamList.RemoveAll((UIParameters item) => item.UIName == identifier);
		string uiPackageName = GetUiPackageName(identifier);
		int currentPackageReference = GetCurrentPackageReference(uiPackageName);
		if (currentPackageReference > 0)
		{
			reservePackageRes = true;
		}
		SentrySdk.AddBreadcrumb($"ClosePanel {identifier}, reservePackageRes={reservePackageRes}");
		DestroyUiController(value2, reservePackageRes);
		OnUIClosed(identifier);
		if (_currentQueuePlaying == identifier)
		{
			_currentQueuePlaying = null;
			if (_uisQueueList.Count > 0)
			{
				KeyValuePair<string, Dictionary<string, object>> keyValuePair = _uisQueueList.Dequeue();
				OpenPanel(keyValuePair.Key, keyValuePair.Value);
			}
		}
		value2.Dispose();
		value2 = null;
		((MonoBehaviour)this).StartCoroutine(SetUiTouchableAfterDelayAsync(300, changeId));
	}

	public void OnGvGClose()
	{
		string[] array = new string[3]
		{
			UI_main_GvG3Tip.Name,
			UI_GvGTip.Name,
			UI_GvG2Tip.Name
		};
		string[] array2 = array;
		foreach (string key in array2)
		{
			if (DictUI.ContainsKey(key))
			{
				DictUI.Remove(key);
			}
		}
	}

	private void OnUIClosed(string uiName, bool responseContinue = true)
	{
		SharedMessenger.Broadcast("CLOSE_UI", uiName);
		if (_pendingUis.TryGetValue(uiName, out var value))
		{
			_pendingUis.Remove(uiName);
			SharedMessenger.Broadcast("CUSTOM_ACTION_FINISH", value, responseContinue);
		}
	}

	private void OnUIOpened(string uiName, Dictionary<string, object> parameters)
	{
		SharedMessenger.Broadcast("OPEN_UI", uiName, parameters);
	}

	private void DestroyUiController(GObject ui, bool reservePackageRes = false)
	{
		if (!(ui is IUiController uiController))
		{
			throw new NullReferenceException("{identifier} 未实现IUiController接口！");
		}
		uiController.BeforeDestroy();
		uiController.UnregisterUiEventListeners();
		uiController.Destroy();
		if (ui.parent != null && ((GObject)ui.parent).parent != null)
		{
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)((GObject)ui.parent).parent, true);
		}
		if (!reservePackageRes)
		{
			string text = ((object)ui).GetType().Namespace?.Replace("UI.", "");
			UnloadPackage(text);
			SentrySdk.AddBreadcrumb("UnloadPackage packageName=" + text + " ui=" + ui.name);
		}
	}

	public void OpenDialog(string identifier, Dictionary<string, object> parameters)
	{
		throw new NotImplementedException();
	}

	public void CloseDialog(string identifier)
	{
		throw new NotImplementedException();
	}

	public void CloseAllDialog()
	{
		((GComponent)GRoot.inst).RemoveChildren();
	}

	public void ShowNewbieMissionPanel(bool isBattleField = false)
	{
		if (!GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
		{
			return;
		}
		HideNewbieMissionPanel();
		if (isBattleField)
		{
			string currentLevelId = GameManagers.Instance.UserArchiveManager.GetCurrentLevelId();
			if (!string.IsNullOrEmpty(currentLevelId))
			{
				Level levelInstance = GameManagers.Instance.ChapterManager.GetLevelInstance(currentLevelId);
				if (levelInstance.Chapter.Type != ChapterType.StoryMain || levelInstance.ChapterId == "C1000" || levelInstance.ChapterId == "C10000" || levelInstance.ChapterId == "C10001" || levelInstance.ChapterId == "C1000" || levelInstance.ChapterId == "C10002")
				{
					return;
				}
			}
		}
		string value = (isBattleField ? "BattleField" : "MainCity");
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_NewbieMissionPanel.Name, new Dictionary<string, object> { { "CurrentScene", value } });
	}

	public void HideNewbieMissionPanel()
	{
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
		{
			GameLocalDataManager.ClearLastOpenReplayListCache();
			GameController.Contexts.Service<IUiService>().ClosePanel(UI_NewbieMissionPanel.Name);
			Instance.NewbieMissionPanel = null;
		}
	}

	public void CloseAll(bool ignoreLoading = true, List<string> ignoreUI = null)
	{
		SentrySdk.AddBreadcrumb("CloseAll");
		string[] array = _uis.Keys.ToArray();
		foreach (string text in array)
		{
			if ((!ignoreLoading || !(text == UI_LoadingPanel.Name)) && !_closeAllUisNeedContinue.Contains(text) && !_closeAllUisNeedContinueDynamicList.Contains(text) && !CanNotClose(text) && (ignoreUI == null || !ignoreUI.Contains(text)))
			{
				ClosePanel(text);
			}
		}
		Instance.SetEdgeMaskVisible(Instance.edgeMaskPanel.ratio <= 1f);
	}

	public void CloseSomePanels(List<string> panelsName, bool reservePackageRes = false, bool ignoreLoading = true, bool edgeMaskVisible = false)
	{
		SentrySdk.AddBreadcrumb("CloseSomePanels: " + string.Join(",", panelsName));
		if (panelsName == null || panelsName.Count <= 0)
		{
			return;
		}
		foreach (string item in panelsName)
		{
			if ((!ignoreLoading || !(item == UI_LoadingPanel.Name)) && !_closeAllUisNeedContinue.Contains(item) && !_closeAllUisNeedContinueDynamicList.Contains(item))
			{
				ClosePanel(item, reservePackageRes);
			}
		}
		Instance.SetEdgeMaskVisible(edgeMaskVisible);
	}

	public void AddDontCloseUisOnCloseAll(List<string> uis)
	{
		if (uis == null || uis.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < uis.Count; i++)
		{
			if (!_closeAllUisNeedContinueDynamicList.Contains(uis[i]))
			{
				_closeAllUisNeedContinueDynamicList.Add(uis[i]);
			}
		}
	}

	public void ClearDontCloseUisOnCloseAll()
	{
		_closeAllUisNeedContinueDynamicList.Clear();
	}

	public void SetUiVisible(string uiName, bool visible)
	{
		if (_uis.ContainsKey(uiName))
		{
			if (_uis[uiName].parent != null)
			{
				((GObject)_uis[uiName].parent).visible = visible;
			}
			else
			{
				_uis[uiName].visible = visible;
			}
		}
	}

	public bool HasShowingUi()
	{
		return _uis.Keys.Except(PersistentUis).Any();
	}

	public bool HasShowingUi(string panelsName)
	{
		return _uis.Keys.Contains(panelsName);
	}

	public GObject GetShowingUi(string panelsName)
	{
		if (_uis.Keys.Contains(panelsName))
		{
			return _uis[panelsName];
		}
		return null;
	}

	public List<string> GetOpenPanelNames()
	{
		List<string> list = new List<string>();
		for (int i = 0; i < _uiParamList.Count; i++)
		{
			string uIName = _uiParamList[i].UIName;
			if (!PersistentUis.Contains(uIName))
			{
				list.Add(uIName);
			}
		}
		return list;
	}

	public Dictionary<string, object> GetPanelOpenParams(string panelName)
	{
		for (int i = 0; i < _uiParamList.Count; i++)
		{
			if (_uiParamList[i].UIName == panelName)
			{
				return _uiParamList[i].Params;
			}
		}
		return null;
	}

	private void UpdateFairGUITouchable()
	{
		((GObject)_maskCover).touchable = _isMaskCoverTouchable;
	}

	public int SetUiNotTouchable(string identifier)
	{
		_uiNotTouchableIndex++;
		_uiNotTouchable.Add(_uiNotTouchableIndex);
		FairyGuiSwitchTouchEnable(enable: false);
		return _uiNotTouchableIndex;
	}

	public void SetUiTouchable(int changeId)
	{
		if (_uiNotTouchable.Contains(changeId))
		{
			_uiNotTouchable.Remove(changeId);
		}
		FairyGuiSwitchTouchEnable(_uiNotTouchable.Count == 0);
	}

	public void ClearUiTouchable()
	{
		_uiNotTouchable.Clear();
		FairyGuiSwitchTouchEnable(_uiNotTouchable.Count == 0);
	}

	public void SetEdgeMaskVisible(bool value)
	{
		if (_edgeMaskPanel == null)
		{
			if (_isLoadingEdgeMask)
			{
				return;
			}
			_isLoadingEdgeMask = true;
			string identifier = UI_EdgeMaskPanel.Name;
			Type type = _resourceMaps[identifier];
			string packageName = type.Namespace?.Replace("UI.", "");
			GComponentCreator val = default(GComponentCreator);
			LoadPackage(packageName).Then((Action)delegate
			{
				//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d3: Expected O, but got Unknown
				//IL_00d8: Expected O, but got Unknown
				if (!_createInstanceMethodMap.TryGetValue(identifier, out var value2))
				{
					value2 = type.GetMethod("CreateInstance", BindingFlags.Static | BindingFlags.Public);
					if (value2 == null)
					{
						throw new InvalidProgramException(identifier + " 没有实现CreateInstance方法");
					}
					_createInstanceMethodMap.Add(identifier, value2);
				}
				UI_EdgeMaskPanel uI_EdgeMaskPanel = _edgeMaskPanel;
				if (uI_EdgeMaskPanel != null)
				{
					((GObject)uI_EdgeMaskPanel).Dispose();
				}
				MethodInfo method = type.GetMethod("GetURL", BindingFlags.Static | BindingFlags.Public);
				string text = (string)method.Invoke(null, null);
				GComponentCreator obj = val;
				if (obj == null)
				{
					GComponentCreator val2 = () => HotFixManager.Instance.appdomain.Instantiate<GComponent>(type.FullName, (object[])null);
					GComponentCreator val3 = val2;
					val = val2;
					obj = val3;
				}
				UIObjectFactory.SetPackageItemExtension(text, obj);
				_edgeMaskPanel = (UI_EdgeMaskPanel)value2.Invoke(null, null);
				_edgeMaskPanel.Init(null);
				((GComponent)GRoot.inst).AddChild((GObject)(object)_edgeMaskPanel);
				_edgeMaskPanel.OnShow();
				_isLoadingEdgeMask = false;
				_edgeMaskPanel.SetMaskVisible(value);
			}).Catch((Action<Exception>)Debug.LogWarning);
		}
		else
		{
			_edgeMaskPanel.SetMaskVisible(value);
		}
	}

	public void SetMaskVisible(bool value)
	{
		if (_maskCover == null)
		{
			if (_isLoadingMaskCover)
			{
				return;
			}
			_isLoadingMaskCover = true;
			string identifier = UI_MaskCover.Name;
			Type type = _resourceMaps[identifier];
			string packageName = type.Namespace?.Replace("UI.", "");
			GComponentCreator val = default(GComponentCreator);
			LoadPackage(packageName).Then((Action)delegate
			{
				//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d3: Expected O, but got Unknown
				//IL_00d8: Expected O, but got Unknown
				if (!_createInstanceMethodMap.TryGetValue(identifier, out var value2))
				{
					value2 = type.GetMethod("CreateInstance", BindingFlags.Static | BindingFlags.Public);
					if (value2 == null)
					{
						throw new InvalidProgramException(identifier + " 没有实现CreateInstance方法");
					}
					_createInstanceMethodMap.Add(identifier, value2);
				}
				UI_MaskCover uI_MaskCover = _maskCover;
				if (uI_MaskCover != null)
				{
					((GObject)uI_MaskCover).Dispose();
				}
				MethodInfo method = type.GetMethod("GetURL", BindingFlags.Static | BindingFlags.Public);
				string text = (string)method.Invoke(null, null);
				GComponentCreator obj = val;
				if (obj == null)
				{
					GComponentCreator val2 = () => HotFixManager.Instance.appdomain.Instantiate<GComponent>(type.FullName, (object[])null);
					GComponentCreator val3 = val2;
					val = val2;
					obj = val3;
				}
				UIObjectFactory.SetPackageItemExtension(text, obj);
				_maskCover = (UI_MaskCover)value2.Invoke(null, null);
				_maskCover.Init(null);
				((GComponent)GRoot.inst).AddChild((GObject)(object)_maskCover);
				_maskCover.OnShow();
				_isLoadingMaskCover = false;
				_maskCover.SetMaskVisible(value);
			}).Catch((Action<Exception>)Debug.LogWarning);
		}
		else
		{
			_maskCover.SetMaskVisible(value);
		}
	}

	public void ShowGetLegendItemFullSfx(string sfxName, float delay, int type = 0)
	{
		_maskCover?.ShowFullScreenSfx(sfxName, delay, type);
	}

	public void ShowGetBonusItemSfx(Vector2 startPos, Vector2 endPos, string sfxName = "exp_missile_green", float delayTime = 0.5f)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		_maskCover?.ShowGetBonusSfx(startPos, endPos, sfxName, delayTime);
	}

	public void ShowScreenSfx(Vector2 startPos, float sfxSize = 60f, string sfxName = "exp_missile_green", float delayTime = 0.5f)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		_maskCover?.ShowScreenSfx(startPos, sfxSize, sfxName, delayTime);
	}

	public void FairyGuiSwitchTouchEnable(bool enable)
	{
		_isMaskCoverTouchable = !enable;
		if (_maskCover == null)
		{
			if (_isLoadingMaskCover)
			{
				return;
			}
			_isLoadingMaskCover = true;
			string identifier = UI_MaskCover.Name;
			Type type = _resourceMaps[identifier];
			string packageName = type.Namespace?.Replace("UI.", "");
			GComponentCreator val = default(GComponentCreator);
			LoadPackage(packageName).Then((Action)delegate
			{
				//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c4: Expected O, but got Unknown
				//IL_00c9: Expected O, but got Unknown
				if (!_createInstanceMethodMap.TryGetValue(identifier, out var value))
				{
					value = type.GetMethod("CreateInstance", BindingFlags.Static | BindingFlags.Public);
					if (value == null)
					{
						throw new InvalidProgramException(identifier + " 没有实现CreateInstance方法");
					}
					_createInstanceMethodMap.Add(identifier, value);
				}
				UI_MaskCover uI_MaskCover = _maskCover;
				if (uI_MaskCover != null)
				{
					((GObject)uI_MaskCover).Dispose();
				}
				MethodInfo method = type.GetMethod("GetURL", BindingFlags.Static | BindingFlags.Public);
				string text = (string)method.Invoke(null, null);
				GComponentCreator obj = val;
				if (obj == null)
				{
					GComponentCreator val2 = () => HotFixManager.Instance.appdomain.Instantiate<GComponent>(type.FullName, (object[])null);
					GComponentCreator val3 = val2;
					val = val2;
					obj = val3;
				}
				UIObjectFactory.SetPackageItemExtension(text, obj);
				_maskCover = (UI_MaskCover)value.Invoke(null, null);
				_maskCover.Init(null);
				((GComponent)GRoot.inst).AddChild((GObject)(object)_maskCover);
				_maskCover.OnShow();
				_isLoadingMaskCover = false;
				UpdateFairGUITouchable();
			}).Catch((Action<Exception>)Debug.LogWarning);
		}
		else
		{
			UpdateFairGUITouchable();
		}
	}

	private void UpdateWaitingAnimationVisible()
	{
		_waitingPanel.UpdateVisible(_isShowWaitingPanel);
	}

	public void SetWaitingPanelType(int typeIndex)
	{
		if (_waitingPanel != null)
		{
			_waitingPanel.TypeController.selectedIndex = typeIndex;
		}
	}

	public void SetWaitingPanelDownloadProgress(float barValue, string tipText = "")
	{
		if (_waitingPanel != null)
		{
			((GObject)_waitingPanel.progress).text = $"{(int)barValue}%";
			if (!string.IsNullOrWhiteSpace(tipText))
			{
				((GObject)_waitingPanel.info).text = tipText;
			}
		}
	}

	public void ShowWaitingAnimation(bool show)
	{
		INetworkService networkService = GameController.Contexts.Service<INetworkService>();
		if (!networkService.IsStop())
		{
			((MonoBehaviour)this).StartCoroutine(ShowWaitingAnimationCoroutine(show));
		}
		else
		{
			((MonoBehaviour)this).StartCoroutine(ShowWaitingAnimationCoroutine(show: false));
		}
	}

	public void ShowPaymentWaitingAnimation(bool show)
	{
		if (paymentWaitingPanel == null)
		{
			string identifier = UI_WaitingPanel.Name;
			Type type = _resourceMaps[identifier];
			string packageName = type.Namespace?.Replace("UI.", "");
			GComponentCreator val = default(GComponentCreator);
			LoadPackage(packageName).Then((Action)delegate
			{
				//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d3: Expected O, but got Unknown
				//IL_00d8: Expected O, but got Unknown
				if (!_createInstanceMethodMap.TryGetValue(identifier, out var value))
				{
					value = type.GetMethod("CreateInstance", BindingFlags.Static | BindingFlags.Public);
					if (value == null)
					{
						throw new InvalidProgramException(identifier + " 没有实现CreateInstance方法");
					}
					_createInstanceMethodMap.Add(identifier, value);
				}
				UI_WaitingPanel uI_WaitingPanel = _paymentWaitingPanel;
				if (uI_WaitingPanel != null)
				{
					((GObject)uI_WaitingPanel).Dispose();
				}
				MethodInfo method = type.GetMethod("GetURL", BindingFlags.Static | BindingFlags.Public);
				string text = (string)method.Invoke(null, null);
				GComponentCreator obj = val;
				if (obj == null)
				{
					GComponentCreator val2 = () => HotFixManager.Instance.appdomain.Instantiate<GComponent>(type.FullName, (object[])null);
					GComponentCreator val3 = val2;
					val = val2;
					obj = val3;
				}
				UIObjectFactory.SetPackageItemExtension(text, obj);
				_paymentWaitingPanel = (UI_WaitingPanel)value.Invoke(null, null);
				_paymentWaitingPanel.Init(null);
				((GComponent)GRoot.inst).AddChild((GObject)(object)_paymentWaitingPanel);
				_paymentWaitingPanel.OnShow();
				_isLoadingWaitingPanel = false;
				((GObject)_paymentWaitingPanel).visible = show;
			}).Catch((Action<Exception>)Debug.LogWarning);
		}
		else
		{
			((GObject)_paymentWaitingPanel).visible = show;
		}
	}

	public void InitDebugInfoPanel()
	{
		string identifier = UI_DebugInfo.Name;
		Type type = _resourceMaps[identifier];
		string packageName = type.Namespace?.Replace("UI.", "");
		GComponentCreator val = default(GComponentCreator);
		LoadPackage(packageName).Then((Action)delegate
		{
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Expected O, but got Unknown
			//IL_00b2: Expected O, but got Unknown
			if (!_createInstanceMethodMap.TryGetValue(identifier, out var value))
			{
				value = type.GetMethod("CreateInstance", BindingFlags.Static | BindingFlags.Public);
				if (value == null)
				{
					throw new InvalidProgramException(identifier + " 没有实现CreateInstance方法");
				}
				_createInstanceMethodMap.Add(identifier, value);
			}
			MethodInfo method = type.GetMethod("GetURL", BindingFlags.Static | BindingFlags.Public);
			string text = (string)method.Invoke(null, null);
			GComponentCreator obj = val;
			if (obj == null)
			{
				GComponentCreator val2 = () => HotFixManager.Instance.appdomain.Instantiate<GComponent>(type.FullName, (object[])null);
				GComponentCreator val3 = val2;
				val = val2;
				obj = val3;
			}
			UIObjectFactory.SetPackageItemExtension(text, obj);
			if (_debugInfo != null)
			{
				_debugInfo.UnregisterUiEventListeners();
				((GObject)_debugInfo).Dispose();
			}
			_debugInfo = (UI_DebugInfo)value.Invoke(null, null);
			_debugInfo.RegisterUiEventListeners();
			((GComponent)GRoot.inst).AddChild((GObject)(object)_debugInfo);
			_debugInfo.Init(null);
			_debugInfo.OnShow();
		});
	}

	private IEnumerator ShowWaitingAnimationCoroutine(bool show)
	{
		_isShowWaitingPanel = show;
		if (!show)
		{
			yield return (object)new WaitForSeconds(0.6f);
		}
		if (_waitingPanel == null)
		{
			if (_isLoadingWaitingPanel)
			{
				yield break;
			}
			_isLoadingWaitingPanel = true;
			string identifier = UI_WaitingPanel.Name;
			Type type = _resourceMaps[identifier];
			string packageName = type.Namespace?.Replace("UI.", "");
			GComponentCreator val = default(GComponentCreator);
			LoadPackage(packageName).Then((Action)delegate
			{
				//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b9: Expected O, but got Unknown
				//IL_00be: Expected O, but got Unknown
				if (!_createInstanceMethodMap.TryGetValue(identifier, out var value))
				{
					value = type.GetMethod("CreateInstance", BindingFlags.Static | BindingFlags.Public);
					if (value == null)
					{
						throw new InvalidProgramException(identifier + " 没有实现CreateInstance方法");
					}
					_createInstanceMethodMap.Add(identifier, value);
				}
				TryDisposeWaitingPanel();
				MethodInfo method = type.GetMethod("GetURL", BindingFlags.Static | BindingFlags.Public);
				string text = (string)method.Invoke(null, null);
				GComponentCreator obj = val;
				if (obj == null)
				{
					GComponentCreator val2 = () => HotFixManager.Instance.appdomain.Instantiate<GComponent>(type.FullName, (object[])null);
					GComponentCreator val3 = val2;
					val = val2;
					obj = val3;
				}
				UIObjectFactory.SetPackageItemExtension(text, obj);
				_waitingPanel = (UI_WaitingPanel)value.Invoke(null, null);
				_waitingPanel.RegisterUiEventListeners();
				_waitingPanel.Init(null);
				((GComponent)GRoot.inst).AddChild((GObject)(object)_waitingPanel);
				_waitingPanel.OnShow();
				_isLoadingWaitingPanel = false;
				UpdateWaitingAnimationVisible();
			}).Catch((Action<Exception>)Debug.LogWarning);
		}
		else
		{
			if (_isShowWaitingPanel)
			{
				_waitingPanel.OnShow();
			}
			UpdateWaitingAnimationVisible();
		}
	}

	private void TryDisposeWaitingPanel()
	{
		if (_waitingPanel != null)
		{
			_waitingPanel.UnregisterUiEventListeners();
			((GObject)_waitingPanel).Dispose();
		}
		_waitingPanel = null;
	}

	private bool CanNotClose(string uiName)
	{
		foreach (List<UIParameters> item in _uisBackupStack)
		{
			if (item.Any((UIParameters item) => item.UIName == uiName))
			{
				return true;
			}
		}
		return false;
	}

	public void PushBackupAndCloseAllUIs(List<string> ignoreList = null, bool toBackupStack = true, bool closeHidden = false)
	{
		List<UIParameters> list = new List<UIParameters>();
		foreach (UIParameters uiParam in _uiParamList)
		{
			if ((ignoreList == null || !ignoreList.Contains(uiParam.UIName)) && (closeHidden || GetShowingUi(uiParam.UIName).visible))
			{
				list.Add(uiParam);
			}
		}
		if (toBackupStack)
		{
			_uisBackupStack.Push(list);
		}
		foreach (UIParameters item in list)
		{
			bool reservePackageRes = false;
			if (item.Params != null && item.Params.TryGetValue("ReservePackageResOnClose", out var value))
			{
				reservePackageRes = (bool)value;
			}
			ClosePanel(item.UIName, reservePackageRes);
		}
	}

	public bool IsRecoveringBackupUis()
	{
		return _isRecoveringBackup;
	}

	public void StartRecoverBackup()
	{
		_isRecoveringBackup = true;
	}

	public void RecoverLastBackup(int skipBackupCount = 0)
	{
		if (_uisBackupStack.Count == 0)
		{
			return;
		}
		List<UIParameters> backup = _uisBackupStack.Pop();
		for (int i = 0; i < skipBackupCount; i++)
		{
			if (_uisBackupStack.Count == 0)
			{
				return;
			}
			backup = _uisBackupStack.Pop();
		}
		((MonoBehaviour)this).StartCoroutine(RecoverBackupSequentially(backup));
	}

	private IEnumerator RecoverBackupSequentially(List<UIParameters> backup)
	{
		foreach (UIParameters uiParam in backup)
		{
			if (!HasShowingUi(uiParam.UIName))
			{
				Dictionary<string, object> parameters = ((uiParam.Params != null) ? new Dictionary<string, object>(uiParam.Params) : new Dictionary<string, object>());
				if (!parameters.ContainsKey("IsOpenedByRecovery"))
				{
					parameters.Add("IsOpenedByRecovery", true);
				}
				string uiName = uiParam.UIName;
				OpenPanel(uiName, parameters);
				float elapsed = 0f;
				while (!HasShowingUi(uiName) && elapsed < 3f)
				{
					elapsed += Time.deltaTime;
					yield return null;
				}
				if (!HasShowingUi(uiName))
				{
					Debug.LogWarning((object)("RecoverLastBackup: timeout waiting for UI '" + uiName + "' to be shown."));
				}
			}
		}
		_isRecoveringBackup = false;
	}

	public void HideUis(List<string> uiList, bool uiVisible = false)
	{
		if (uiList == null)
		{
			return;
		}
		foreach (string ui in uiList)
		{
			if (HasShowingUi(ui))
			{
				GetShowingUi(ui).visible = uiVisible;
			}
		}
	}

	public void PushBackupAndHideAllUIs(List<string> ignoreList = null)
	{
		List<UIParameters> list = new List<UIParameters>();
		foreach (UIParameters uiParam in _uiParamList)
		{
			if (ignoreList == null || !ignoreList.Contains(uiParam.UIName))
			{
				list.Add(uiParam);
			}
		}
		_uisHiddenBackupStack.Push(list);
		foreach (UIParameters item in list)
		{
			if (HasShowingUi(item.UIName))
			{
				GetShowingUi(item.UIName).visible = false;
			}
		}
	}

	public void RecoverLastHiddenUIs(int skipBackupCount = 0)
	{
		if (_uisHiddenBackupStack.Count == 0)
		{
			return;
		}
		List<UIParameters> list = _uisHiddenBackupStack.Pop();
		for (int i = 0; i < skipBackupCount; i++)
		{
			if (_uisHiddenBackupStack.Count == 0)
			{
				return;
			}
			list = _uisHiddenBackupStack.Pop();
		}
		foreach (UIParameters item in list)
		{
			if (HasShowingUi(item.UIName))
			{
				GetShowingUi(item.UIName).visible = true;
			}
			else
			{
				ILRuntimeDebug.LogError("RecoverLastHiddenUIs -- missing ui:" + item.UIName);
			}
		}
	}

	private string GetUiPackageName(string uiName)
	{
		_resourceMaps.TryGetValue(uiName, out var value);
		return (value?.Namespace)?.Substring("UI.".Length);
	}

	private int GetCurrentPackageReference(string packageName)
	{
		int num = 0;
		foreach (string key in _uis.Keys)
		{
			if (GetUiPackageName(key) == packageName)
			{
				num++;
			}
		}
		return num;
	}
}
