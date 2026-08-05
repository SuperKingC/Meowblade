using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using DG.Tweening;
using DG.Tweening.Core;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.AddCredit;
using UI.MtgGiftPacks;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGBattlePass3;

public class UI_main_GvG3BattlePass : GComponent, IUiController
{
	public Controller PageController;

	public Controller Mode;

	public Controller Status;

	public GLoader background;

	public GImage n151;

	public GImage n150;

	public GImage n149;

	public GImage n142;

	public GImage n154;

	public GImage n155;

	public GImage n143;

	public GTextField n153;

	public GTextField n152;

	public GImage n145;

	public GImage n146;

	public GTextField TotalScore;

	public GTextField NextScore;

	public GLoader CurLevelIcon;

	public GTextField n117;

	public GTextField n136;

	public GTextField n137;

	public GTextField CurLevelText;

	public GList RewardList;

	public GImage n147;

	public GImage n158;

	public UI_btn_ActivatePremium ActivatePremium;

	public GGroup n159;

	public UI_com_LevelSlot_Big NextBigSlot;

	public UI_dec_Scroll n144;

	public GComponent addMTGBtn;

	public UI_com_Title Title;

	public UI_btn_QuickGet QuickGetBtn;

	public UI_btn_WeeklyTab WeeklyTab;

	public UI_btn_CloseBattlePass CloseBattlePass;

	public UI_btn_OneClickClaim OneClickClaimBtn;

	public UI_btn_BuyAdvanced BuyAdvanceBtn;

	public GButton BackBtn;

	public GButton HelpBtn;

	public UI_btn_GvGInsurance Insurance;

	public GGraph WeeklyMask;

	public Transition TimeBreathing;

	public Transition TimeNormal;

	public Transition TimeShake;

	public Transition t3;

	public const string URL = "ui://bfjg32huq1eq4c";

	public static string Name = "UI_main_GvG3BattlePass";

	private int LastBigRewardLevel = 0;

	private bool IsUpdatingRewardList = false;

	private int _curContributionPoint = 0;

	private bool _IsAdvanced = false;

	private float ScoreToShow = 0f;

	private int SlotWidth = 0;

	private int ListWidth = 0;

	public int FirstPointNum = 0;

	public int LastPointNum = 0;

	public static int MaxCurContributionLevel;

	public static List<SpecialSlot> SpecialReward = new List<SpecialSlot>();

	private List<GameObject> SfxCache = new List<GameObject>();

	private UI_ProductionNumFloating NumFloatingGem;

	private UI_ProductionNumFloating NumFloatingMTG;

	public static LoadingStatus DataLoadingStatus = LoadingStatus.NOT_STARTED;

	public static List<SlotData> RewardData = new List<SlotData>();

	public static int RewardDisplayCount;

	private static GvG3BattlePassManager.ConfigData _configData;

	private Tweener CurLevelTweener;

	public GameObject Mask = null;

	private bool _IsNoteDirty = false;

	private readonly ActivityHasClaimedBonus _claimedBonus = new ActivityHasClaimedBonus();

	private Window _window;

	private UICallbackParam<Action> OnClose;

	private int _curContributionLevel;

	private int _nextContributionLevel;

	private int _contributionToNextLevel;

	private bool _premiumActivated;

	private Coroutine PlayTimeShakingCoroutine;

	public bool IsIzInSettlement => Singleton<GvGMode3RoomManager>.Instance.IsIZInSettlement;

	public SkyIslandPlayerSettlementModel PlayerSettlement => Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement;

	private bool HasBonusToBeClaimed => RewardData.Any((SlotData slot) => slot.BonusToBeClaimed(IsAdvancedMode, PremiumActivated));

	private bool HasNodeToBeUnlock => !IsAdvancedMode || !PremiumActivated || CurContributionLevel() < MaxCurContributionLevel;

	public int ContributionToNextLevel => _contributionToNextLevel;

	public bool IsAdvancedMode
	{
		get
		{
			return _IsAdvanced;
		}
		set
		{
			if (!((GObject)this).isDisposed)
			{
				if (!_IsAdvanced && value)
				{
					SharedMessenger.Broadcast("ON_GVG3_BATTLE_PASS_UPGRADE_ADVANCED");
				}
				_IsAdvanced = value;
				CalcRewardDisplayCount(_IsAdvanced, PremiumActivated);
				MaxCurContributionLevel = RewardData[RewardDisplayCount - 1].NominalLevel;
				UpdateMode();
				UpdateRewardList();
				UpdateNextBigReward();
				UpdateInsuranceState();
				((GObject)n159).visible = SetActivatePremiumVisible();
			}
		}
	}

	public bool PremiumActivated
	{
		get
		{
			return _premiumActivated;
		}
		set
		{
			if (!((GObject)this).isDisposed)
			{
				_premiumActivated = value;
				CalcRewardDisplayCount(_IsAdvanced, _premiumActivated);
				MaxCurContributionLevel = RewardData[RewardDisplayCount - 1].NominalLevel;
				(FirstPointNum, LastPointNum) = MinMaxPoint();
				UpdateMode();
				UpdateRewardList();
				UpdateNextBigReward();
			}
		}
	}

	public static string GetURL()
	{
		return "ui://bfjg32huq1eq4c";
	}

	public static UI_main_GvG3BattlePass CreateInstance()
	{
		return (UI_main_GvG3BattlePass)(object)UIPackage.CreateObject("GvGBattlePass3", "main_GvG3BattlePass");
	}

	public static UI_main_GvG3BattlePass CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvG3BattlePass).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huq1eq4c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Expected O, but got Unknown
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected O, but got Unknown
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Expected O, but got Unknown
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Expected O, but got Unknown
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Expected O, but got Unknown
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Expected O, but got Unknown
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Expected O, but got Unknown
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Expected O, but got Unknown
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		Mode = ((GComponent)this).GetController("Mode");
		Status = ((GComponent)this).GetController("Status");
		background = (GLoader)((GComponent)this).GetChild("background");
		n151 = (GImage)((GComponent)this).GetChild("n151");
		n150 = (GImage)((GComponent)this).GetChild("n150");
		n149 = (GImage)((GComponent)this).GetChild("n149");
		n142 = (GImage)((GComponent)this).GetChild("n142");
		n154 = (GImage)((GComponent)this).GetChild("n154");
		n155 = (GImage)((GComponent)this).GetChild("n155");
		n143 = (GImage)((GComponent)this).GetChild("n143");
		n153 = (GTextField)((GComponent)this).GetChild("n153");
		string id = "ui://bfjg32huq1eq4c".Replace("ui://", "") + "-" + ((GObject)n153).id;
		((GObject)n153).text = LanguagesManager.GetDesc(id);
		n152 = (GTextField)((GComponent)this).GetChild("n152");
		string id2 = "ui://bfjg32huq1eq4c".Replace("ui://", "") + "-" + ((GObject)n152).id;
		((GObject)n152).text = LanguagesManager.GetDesc(id2);
		n145 = (GImage)((GComponent)this).GetChild("n145");
		n146 = (GImage)((GComponent)this).GetChild("n146");
		TotalScore = (GTextField)((GComponent)this).GetChild("TotalScore");
		NextScore = (GTextField)((GComponent)this).GetChild("NextScore");
		CurLevelIcon = (GLoader)((GComponent)this).GetChild("CurLevelIcon");
		n117 = (GTextField)((GComponent)this).GetChild("n117");
		string id3 = "ui://bfjg32huq1eq4c".Replace("ui://", "") + "-" + ((GObject)n117).id;
		((GObject)n117).text = LanguagesManager.GetDesc(id3);
		n136 = (GTextField)((GComponent)this).GetChild("n136");
		string id4 = "ui://bfjg32huq1eq4c".Replace("ui://", "") + "-" + ((GObject)n136).id;
		((GObject)n136).text = LanguagesManager.GetDesc(id4);
		n137 = (GTextField)((GComponent)this).GetChild("n137");
		string id5 = "ui://bfjg32huq1eq4c".Replace("ui://", "") + "-" + ((GObject)n137).id;
		((GObject)n137).text = LanguagesManager.GetDesc(id5);
		CurLevelText = (GTextField)((GComponent)this).GetChild("CurLevelText");
		RewardList = (GList)((GComponent)this).GetChild("RewardList");
		n147 = (GImage)((GComponent)this).GetChild("n147");
		n158 = (GImage)((GComponent)this).GetChild("n158");
		ActivatePremium = (UI_btn_ActivatePremium)(object)((GComponent)this).GetChild("ActivatePremium");
		n159 = (GGroup)((GComponent)this).GetChild("n159");
		NextBigSlot = (UI_com_LevelSlot_Big)(object)((GComponent)this).GetChild("NextBigSlot");
		n144 = (UI_dec_Scroll)(object)((GComponent)this).GetChild("n144");
		addMTGBtn = (GComponent)((GComponent)this).GetChild("addMTGBtn");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		QuickGetBtn = (UI_btn_QuickGet)(object)((GComponent)this).GetChild("QuickGetBtn");
		WeeklyTab = (UI_btn_WeeklyTab)(object)((GComponent)this).GetChild("WeeklyTab");
		CloseBattlePass = (UI_btn_CloseBattlePass)(object)((GComponent)this).GetChild("CloseBattlePass");
		OneClickClaimBtn = (UI_btn_OneClickClaim)(object)((GComponent)this).GetChild("OneClickClaimBtn");
		BuyAdvanceBtn = (UI_btn_BuyAdvanced)(object)((GComponent)this).GetChild("BuyAdvanceBtn");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		HelpBtn = (GButton)((GComponent)this).GetChild("HelpBtn");
		Insurance = (UI_btn_GvGInsurance)(object)((GComponent)this).GetChild("Insurance");
		WeeklyMask = (GGraph)((GComponent)this).GetChild("WeeklyMask");
		TimeBreathing = ((GComponent)this).GetTransition("TimeBreathing");
		TimeNormal = ((GComponent)this).GetTransition("TimeNormal");
		TimeShake = ((GComponent)this).GetTransition("TimeShake");
		t3 = ((GComponent)this).GetTransition("t3");
	}

	public void UpdateStatus()
	{
		if (!IsIzInSettlement)
		{
			Status.selectedIndex = 0;
		}
		else
		{
			Status.selectedIndex = (HasBonusToBeClaimed ? 1 : 2);
		}
	}

	private void CloseBattlePassOnClick()
	{
		if (!IsIzInSettlement)
		{
			return;
		}
		if (Status.selectedIndex <= 1)
		{
			ILRequestHelper.ShowMessage("GvG3LastBattlePassToBeClaimed".ToLanguage());
			if (Status.selectedIndex == 1)
			{
				ScrollToPendingClaim();
			}
		}
		else if (HasNodeToBeUnlock)
		{
			"GvG3LastBattlePassToBeUnlock".ToLanguage().ToConfirmPopup(CloseLastBattlePass, null, (AlignType)0, 40, mirrorBtns: true);
		}
		else
		{
			CloseLastBattlePass();
		}
		void CloseLastBattlePass()
		{
			Singleton<GvGMode3RoomManager>.Instance.GvGMode3CloseLastBattlePass(End);
		}
	}

	private void ScrollToPendingClaim()
	{
		for (int i = 0; i < RewardList.numItems; i++)
		{
			SlotData slotData = RewardData[i];
			if (slotData.BonusToBeClaimed(IsAdvancedMode, PremiumActivated))
			{
				RewardList.ScrollToView(Math.Max(0, i - 3), true);
				break;
			}
		}
	}

	public int GetCurContributionPoint()
	{
		return _curContributionPoint;
	}

	public void SetCurContributionPoint(int value, bool isAutoScrollToHead = true)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		_curContributionPoint = value;
		_curContributionLevel = -1;
		_nextContributionLevel = -1;
		NextContributionLevel(_curContributionPoint);
		Tweener curLevelTweener = CurLevelTweener;
		if (curLevelTweener != null)
		{
			TweenExtensions.Kill((Tween)(object)curLevelTweener, false);
		}
		CurLevelTweener = (Tweener)(object)DOTween.To((DOGetter<float>)(() => ScoreToShow), (DOSetter<float>)delegate(float x)
		{
			ScoreToShow = x;
		}, (float)_curContributionPoint, 0.5f);
		TweenSettingsExtensions.OnComplete<Tweener>(TweenSettingsExtensions.OnUpdate<Tweener>(CurLevelTweener, (TweenCallback)delegate
		{
			if (!((GObject)this).isDisposed)
			{
				((GObject)TotalScore).text = Mathf.FloorToInt(ScoreToShow).ToString();
				UpdateRewardList(isAutoScrollToHead);
			}
		}), (TweenCallback)delegate
		{
			((GObject)CurLevelText).text = CurContributionLevel().ToString();
			((GObject)NextScore).text = ContributionToNextLevel.ToString();
		});
	}

	public int CurContributionToTargetLevel(int targetLevel, out int targetContribution)
	{
		targetContribution = 0;
		if (targetLevel > MaxCurContributionLevel)
		{
			return 0;
		}
		SlotData slotData = RewardData.Find((SlotData reward) => reward.NominalLevel == targetLevel);
		if (slotData == null)
		{
			return 0;
		}
		targetContribution = slotData.Contribution;
		return slotData.Contribution - GetCurContributionPoint();
	}

	public int CurContributionLevel()
	{
		if (_curContributionLevel >= 0)
		{
			return _curContributionLevel;
		}
		if (_curContributionPoint <= 0)
		{
			_curContributionLevel = 0;
			return _curContributionLevel;
		}
		SlotData slotData = RewardData.Find((SlotData reward) => reward.Contribution == _curContributionPoint);
		if (slotData != null)
		{
			_curContributionLevel = slotData.NominalLevel;
			return _curContributionLevel;
		}
		slotData = RewardData.Find((SlotData reward) => reward.Contribution > _curContributionPoint);
		if (slotData == null)
		{
			_curContributionLevel = ((MaxCurContributionLevel == 0) ? (_curContributionLevel = -1) : MaxCurContributionLevel);
			return _curContributionLevel;
		}
		_curContributionLevel = slotData.NominalLevel - 1;
		return _curContributionLevel;
	}

	public int NextContributionLevel(int curContributionPoint = 0)
	{
		if (_nextContributionLevel < 0)
		{
			int index = NextContributionSlotIndex();
			SlotData slotData = RewardData[index];
			_contributionToNextLevel = Mathf.Max(0, slotData.Contribution - curContributionPoint);
		}
		return _nextContributionLevel;
	}

	private void UpdateMode()
	{
		if (_premiumActivated)
		{
			Mode.SetSelectedIndex(2);
		}
		else if (_IsAdvanced)
		{
			Mode.SetSelectedIndex(1);
		}
		else
		{
			Mode.SetSelectedIndex(0);
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Set(new EventCallback0(End));
		((GComponent)RewardList).scrollPane.onScroll.Add(new EventCallback0(OnBonusListScroll));
		((GObject)BuyAdvanceBtn).onClick.Set((EventCallback0)delegate
		{
			OpenBuyPanel(0);
		});
		((GObject)ActivatePremium).onClick.Set((EventCallback0)delegate
		{
			OpenBuyPanel(2);
		});
		((GObject)QuickGetBtn).onClick.Set((EventCallback0)delegate
		{
			OpenBuyPanel(1);
		});
		((GObject)OneClickClaimBtn).onClick.Set(new EventCallback0(OnOneClickClaim));
		addMTGBtn.GetChild("addButton").onClick.Set(new EventCallback0(OnClickMTGBtn));
		((GObject)WeeklyTab).onClick.Set(new EventCallback0(OpenMissionPanel));
		((GObject)HelpBtn).onClick.Set(new EventCallback0(OnClickHelpBtn));
		((GObject)CloseBattlePass).onClick.Set(new EventCallback0(CloseBattlePassOnClick));
		((GObject)Insurance).onClick.Set(new EventCallback0(OnInsuranceClick));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
		SharedMessenger.AddListener("ON_GVG3_CHECK_INSURANCE_ISLAND", OnCheckInsuranceIsland);
		WorldStateManager instance = Singleton<WorldStateManager>.Instance;
		instance.OnAdvancedPaidCertChanged = (Action<bool>)Delegate.Combine(instance.OnAdvancedPaidCertChanged, new Action<bool>(UpdateIsAdvancedMode));
		WorldStateManager instance2 = Singleton<WorldStateManager>.Instance;
		instance2.OnPremiumPaidCertChanged = (Action<bool>)Delegate.Combine(instance2.OnPremiumPaidCertChanged, new Action<bool>(UpdatePremiumActivated));
		WorldStateManager instance3 = Singleton<WorldStateManager>.Instance;
		instance3.OnTotalContributionPointsChanged = (Action<int>)Delegate.Combine(instance3.OnTotalContributionPointsChanged, new Action<int>(OnPushContributionPointChange));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BackBtn).onClick.Clear();
		((GComponent)RewardList).scrollPane.onScroll.Clear();
		((GObject)BuyAdvanceBtn).onClick.Clear();
		((GObject)ActivatePremium).onClick.Clear();
		((GObject)QuickGetBtn).onClick.Clear();
		((GObject)NextBigSlot.SlotBuyBtn).onClick.Clear();
		((GObject)OneClickClaimBtn).onClick.Clear();
		addMTGBtn.GetChild("addButton").onClick.Clear();
		((GObject)WeeklyTab).onClick.Clear();
		((GObject)HelpBtn).onClick.Clear();
		((GObject)CloseBattlePass).onClick.Clear();
		((GObject)Insurance).onClick.Clear();
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
		SharedMessenger.RemoveListener("ON_GVG3_CHECK_INSURANCE_ISLAND", OnCheckInsuranceIsland);
		WorldStateManager instance = Singleton<WorldStateManager>.Instance;
		instance.OnAdvancedPaidCertChanged = (Action<bool>)Delegate.Remove(instance.OnAdvancedPaidCertChanged, new Action<bool>(UpdateIsAdvancedMode));
		WorldStateManager instance2 = Singleton<WorldStateManager>.Instance;
		instance2.OnPremiumPaidCertChanged = (Action<bool>)Delegate.Remove(instance2.OnPremiumPaidCertChanged, new Action<bool>(UpdatePremiumActivated));
		WorldStateManager instance3 = Singleton<WorldStateManager>.Instance;
		instance3.OnTotalContributionPointsChanged = (Action<int>)Delegate.Remove(instance3.OnTotalContributionPointsChanged, new Action<int>(OnPushContributionPointChange));
	}

	public void Init(Dictionary<string, object> parameters)
	{
		if (parameters != null && parameters.TryGetValue("OnClose", out var value))
		{
			OnClose = (UICallbackParam<Action>)value;
		}
		UI_com_LevelSlot uI_com_LevelSlot = UI_com_LevelSlot.CreateInstance();
		SlotWidth = ((GObject)uI_com_LevelSlot).initWidth;
		ListWidth = (int)((GObject)RewardList).width;
		MaxCurContributionLevel = -1;
		((GObject)uI_com_LevelSlot).Dispose();
		((GComponent)this).EnsureBoundsCorrect();
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
		((GObject)QuickGetBtn).visible = false;
		((GObject)BuyAdvanceBtn).visible = false;
		((GObject)n159).visible = false;
		((GObject)OneClickClaimBtn).visible = false;
		((GObject)NextBigSlot.SlotBuyBtn).visible = false;
		((GObject)Insurance).visible = false;
		if (IsIzInSettlement)
		{
			RenderRewardList();
		}
		else
		{
			Singleton<GvGStoreHouseManager>.Instance.SyncStoreHouse(RenderRewardList);
		}
		void RenderRewardList()
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Expected O, but got Unknown
			RewardList.SetVirtual();
			RewardList.itemProvider = new ListItemProvider(GetListItemResource);
			RewardList.itemRenderer = new ListItemRenderer(ItemRenderer);
			RewardList.numItems = 0;
			InitSFXMask();
			((GObject)NextBigSlot).visible = false;
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetRewardData());
			addMTGBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("MTG");
			UpdateMTG();
			_IsNoteDirty = false;
			_claimedBonus.Clear();
		}
	}

	private static (int, int) MinMaxPoint()
	{
		int contribution = RewardData[0].Contribution;
		int contribution2 = RewardData[RewardDisplayCount - 1].Contribution;
		return (contribution, contribution2);
	}

	private void OnActivityLoaded()
	{
		if (!((GObject)this).isDisposed && _configData != null)
		{
			IsAdvancedMode = (IsIzInSettlement ? PlayerSettlement.HasAdvancedPass : Singleton<WorldStateManager>.Instance.Data.HasBattlePassPaidCert);
			PremiumActivated = (IsIzInSettlement ? PlayerSettlement.HasPremiumPass : Singleton<WorldStateManager>.Instance.Data.HasBattlePassPremiumPaidCert);
			CalcRewardDisplayCount(IsAdvancedMode, PremiumActivated);
			MaxCurContributionLevel = RewardData[RewardDisplayCount - 1].NominalLevel;
			SetCurContributionPoint(IsIzInSettlement ? Mathf.FloorToInt(PlayerSettlement.ContributionPoints) : Singleton<WorldStateManager>.Instance.Data.TotalContributionPoints);
			(FirstPointNum, LastPointNum) = MinMaxPoint();
			FGUIManager.Instance.SetItemIconAndFrame(CurLevelIcon, _configData.NormalPayload.ScoreItem, null, "", frameVisible: false);
			((GObject)QuickGetBtn).visible = true;
			((GObject)BuyAdvanceBtn).visible = true;
			((GObject)OneClickClaimBtn).visible = true;
			((GObject)NextBigSlot.SlotBuyBtn).visible = true;
			((GObject)n159).visible = SetActivatePremiumVisible();
			RewardList.numItems = RewardDisplayCount;
		}
	}

	private bool SetActivatePremiumVisible()
	{
		if (_configData.PremiumActivity == null || _configData.AdvancedActivity == null)
		{
			return false;
		}
		return !PremiumActivated && IsAdvancedMode;
	}

	public float GetRemainingTime()
	{
		if (_configData == null)
		{
			return -1f;
		}
		DateTimeOffset endAt = _configData.NormalActivity.ActivityProgress(GameManagers.Instance).EndAt;
		long serverTime = GameController.Instance.GetServerTime();
		DateTimeOffset value = DateTimeHelper.ParseTimeStamp((int)serverTime);
		double totalSeconds = endAt.Subtract(value).TotalSeconds;
		return (float)totalSeconds;
	}

	private void InitEndTimeAnim()
	{
		TimeNormal.Play();
		float num = GetRemainingTime() / 86400f;
		if (num < 3f)
		{
			PlayTimeShakingCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(PlayTimeShaking());
		}
		else if (num < 7f)
		{
			TimeBreathing.Play();
		}
	}

	private IEnumerator PlayTimeShaking()
	{
		while (true)
		{
			TimeShake.Play();
			yield return (object)new WaitForSeconds(1.8f);
		}
	}

	private void OnAllDataLoaded()
	{
		if (!((GObject)this).isDisposed && _configData != null)
		{
			IsAdvancedMode = (IsIzInSettlement ? PlayerSettlement.HasAdvancedPass : Singleton<WorldStateManager>.Instance.Data.HasBattlePassPaidCert);
			PremiumActivated = (IsIzInSettlement ? PlayerSettlement.HasPremiumPass : Singleton<WorldStateManager>.Instance.Data.HasBattlePassPremiumPaidCert);
			SetCurContributionPoint(IsIzInSettlement ? ((int)PlayerSettlement.ContributionPoints) : Singleton<WorldStateManager>.Instance.Data.TotalContributionPoints);
			CalcRewardDisplayCount(IsAdvancedMode, PremiumActivated);
			MaxCurContributionLevel = RewardData[RewardDisplayCount - 1].NominalLevel;
		}
	}

	private void InitSFXMask()
	{
		ref GameObject mask = ref Mask;
		Object obj = Resources.Load("Items/LegionPanelSpritMask");
		mask = (GameObject)(object)((obj is GameObject) ? obj : null);
		Mask = Object.Instantiate<GameObject>(Mask);
		Mask.transform.parent = ((GObject)RewardList).displayObject.gameObject.transform;
		SpriteMask component = Mask.GetComponent<SpriteMask>();
		component.backSortingLayerID = SortingLayer.NameToID("Default");
	}

	public static void ClearConfigData()
	{
		DataLoadingStatus = LoadingStatus.NOT_STARTED;
		RewardData.Clear();
	}

	private IEnumerator GetRewardData()
	{
		if (DataLoadingStatus == LoadingStatus.LOADING)
		{
			while (DataLoadingStatus != LoadingStatus.LOADED)
			{
				yield return null;
			}
		}
		if (DataLoadingStatus == LoadingStatus.LOADED)
		{
			OnActivityLoaded();
			OnAllDataLoaded();
			yield break;
		}
		DataLoadingStatus = LoadingStatus.LOADING;
		Singleton<GvG3BattlePassManager>.Instance.GetConfigData(delegate(GvG3BattlePassManager.ConfigData configData)
		{
			_configData = configData;
			RewardData.Add(GenerateEmptySlot());
			foreach (GvG3BattlePassManager.LevelConfig levelConfig in configData.LevelConfigs)
			{
				SlotData slotData = GenerateSlot(levelConfig);
				RewardData.Add(slotData);
				ReadLevelConfigBasicBonuses(slotData, levelConfig.NormalBonuses);
				ReadLevelConfigAdvancedBonuses(slotData, levelConfig.AdvancedBonuses);
				ReadLevelConfigPremiumBonuses(slotData, levelConfig.PremiumBonuses);
				slotData.IsSpecialNode = levelConfig.IsSpecialNode;
				if (levelConfig.IsSpecialNode)
				{
					SpecialReward.Add(new SpecialSlot
					{
						TargetScrollX = slotData.TargetScrollX,
						Data = slotData
					});
				}
			}
			OnActivityLoaded();
			UpdateNextBigReward();
			OnAllDataLoaded();
			DataLoadingStatus = LoadingStatus.LOADED;
		}, ClearConfigData);
	}

	private SlotData GenerateEmptySlot()
	{
		return new SlotData
		{
			Contribution = 0,
			NominalLevel = 0,
			TargetScrollX = CalculateSlotEmergingScrollX(-1)
		};
	}

	private SlotData GenerateSlot(GvG3BattlePassManager.LevelConfig config)
	{
		return new SlotData
		{
			NominalLevel = config.Level,
			Contribution = config.ContributionScore,
			TargetScrollX = CalculateSlotEmergingScrollX(config.Level - 1)
		};
	}

	private static void ReadLevelConfigPremiumBonuses(SlotData slot, Dictionary<string, int> bonuses)
	{
		Dictionary<string, int>.Enumerator enumerator = bonuses.GetEnumerator();
		if (bonuses.Count > 0)
		{
			enumerator.MoveNext();
			KeyValuePair<string, int> current = enumerator.Current;
			slot.icon_premium = GetIconByItemId(current.Key);
			slot.num_premium = current.Value;
			slot.id_premium = current.Key;
		}
	}

	private static void ReadLevelConfigAdvancedBonuses(SlotData slot, Dictionary<string, int> bonuses)
	{
		Dictionary<string, int>.Enumerator enumerator = bonuses.GetEnumerator();
		if (bonuses.Count > 0)
		{
			enumerator.MoveNext();
			KeyValuePair<string, int> current = enumerator.Current;
			slot.icon_advanced = GetIconByItemId(current.Key);
			slot.num_advanced = current.Value;
			slot.id_advanced = current.Key;
		}
	}

	private static void ReadLevelConfigBasicBonuses(SlotData slot, Dictionary<string, int> bonuses)
	{
		Dictionary<string, int>.Enumerator enumerator = bonuses.GetEnumerator();
		if (bonuses.Count > 0)
		{
			enumerator.MoveNext();
			KeyValuePair<string, int> current = enumerator.Current;
			slot.icon_basic = GetIconByItemId(current.Key);
			slot.num_basic = current.Value;
			slot.id_basic = current.Key;
		}
	}

	private static string GetIconByItemId(string itemId)
	{
		return "ui://PublicResources/" + UiHelper.GetIcon(itemId);
	}

	private int CalculateSlotEmergingScrollX(int slotIndex)
	{
		int num = 30;
		int num2 = ListWidth - SlotWidth + num;
		return SlotWidth * (slotIndex + 1) - num2;
	}

	private static void CalcRewardDisplayCount(bool advanced, bool premium)
	{
		for (int num = RewardData.Count - 1; num >= 0; num--)
		{
			if (!RewardData[num].IsHasNoActivatedBonus(advanced, premium))
			{
				RewardDisplayCount = num + 1;
				return;
			}
		}
		RewardDisplayCount = RewardData.Count;
	}

	public void OnShow()
	{
	}

	private string GetListItemResource(int index)
	{
		return (index <= 0) ? "ui://bfjg32hurdmf5m" : "ui://bfjg32huq1eq3g";
	}

	private void ItemRenderer(int index, GObject obj)
	{
		if (!((GObject)this).isDisposed)
		{
			if (index <= 0)
			{
				RenderFalseNode();
			}
			else
			{
				RenderTrueNode();
			}
		}
		void RenderFalseNode()
		{
			if (obj is UI_com_FakeLevelSlot uI_com_FakeLevelSlot)
			{
				SlotData slotData = RewardData[index];
				int num = CurContributionLevel();
				uI_com_FakeLevelSlot.Progress.SetSelectedIndex((num <= slotData.NominalLevel) ? 1 : 0);
				uI_com_FakeLevelSlot.Type.SetSelectedIndex(Mode.selectedIndex);
			}
		}
		void RenderTrueNode()
		{
			//IL_02df: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e9: Expected O, but got Unknown
			//IL_0301: Unknown result type (might be due to invalid IL or missing references)
			//IL_030b: Expected O, but got Unknown
			//IL_0323: Unknown result type (might be due to invalid IL or missing references)
			//IL_032d: Expected O, but got Unknown
			//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ed: Expected O, but got Unknown
			UI_com_LevelSlot levelSlot = obj as UI_com_LevelSlot;
			if (levelSlot != null)
			{
				levelSlot.Type.SetSelectedIndex(Mode.selectedIndex);
				if (index >= RewardData.Count)
				{
					((GObject)levelSlot.TargetLevel).text = "--";
					((GObject)levelSlot.Basic).visible = false;
					((GObject)levelSlot.Advanced).visible = false;
					((GObject)levelSlot.Premium).visible = false;
					levelSlot.Progress.selectedIndex = 2;
				}
				else
				{
					SlotData slotData = RewardData[index];
					((GObject)levelSlot.TargetLevel).text = slotData.NominalLevel.ToString();
					int num = CurContributionLevel();
					if (slotData.NominalLevel < num)
					{
						levelSlot.Progress.selectedIndex = 0;
					}
					else if (slotData.NominalLevel == num)
					{
						levelSlot.Progress.selectedIndex = 1;
					}
					else
					{
						levelSlot.Progress.selectedIndex = 2;
					}
					levelSlot.IsSpecialNode.selectedIndex = (slotData.IsSpecialNode ? 1 : 0);
					levelSlot.Basic.Icon.url = slotData.icon_basic;
					levelSlot.Advanced.Icon.url = slotData.icon_advanced;
					levelSlot.Premium.Icon.url = slotData.icon_premium;
					levelSlot.Basic.State.selectedIndex = slotData.state_basic;
					levelSlot.Advanced.State.selectedIndex = slotData.state_advanced;
					levelSlot.Premium.State.selectedIndex = slotData.state_premium;
					((GObject)levelSlot.Basic.Num).text = slotData.num_basic.ToString();
					((GObject)levelSlot.Advanced.Num).text = slotData.num_advanced.ToString();
					((GObject)levelSlot.Premium.Num).text = slotData.num_premium.ToString();
					UpdateAdvancedSlotSFX(levelSlot.Advanced, IsAdvancedMode);
					UpdateAdvancedSlotSFX(levelSlot.Premium, PremiumActivated);
					((GObject)levelSlot.Basic).onClick.Set((EventCallback0)delegate
					{
						OnClickNormalSlot(levelSlot, index);
					});
					((GObject)levelSlot.Advanced).onClick.Set((EventCallback0)delegate
					{
						OnClickAdvancedSlot(levelSlot.Advanced, index);
					});
					((GObject)levelSlot.Premium).onClick.Set((EventCallback0)delegate
					{
						OnClickPremiumSlot(levelSlot.Premium, index);
					});
					((GObject)levelSlot.Basic).visible = slotData.num_basic > 0;
					((GObject)levelSlot.Advanced).visible = slotData.num_advanced > 0;
					((GObject)levelSlot.Premium).visible = slotData.num_premium > 0;
					((GObject)levelSlot.LevelIcon).onClick.Clear();
					if (levelSlot.Progress.selectedIndex > 1)
					{
						((GObject)levelSlot.LevelIcon).data = index;
						((GObject)levelSlot.LevelIcon).onClick.Set(new EventCallback1(ShowNextLevelTip));
					}
				}
			}
		}
	}

	private void ShowNextLevelTip(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		int index = (int)val.data;
		SlotData slotData = RewardData[index];
		if (_window == null)
		{
			GComponent asCom = UIPackage.CreateObject("GvGBattlePass3", "com_NextLevelScore").asCom;
			_window = new Window
			{
				contentPane = asCom,
				sortingOrder = 3000
			};
		}
		if (_window.contentPane is UI_com_NextLevelScore uI_com_NextLevelScore)
		{
			((GObject)uI_com_NextLevelScore.Tip).text = slotData.NextLevelContributionTip(slotData.Contribution - GetCurContributionPoint());
		}
		GRoot.inst.ShowPopup((GObject)(object)_window, val);
	}

	private static void UpdateAdvancedSlotSFX(UI_btn_RewardSlot2 slot, bool unlock)
	{
		if (!((GObject)slot).isDisposed)
		{
			((GComponent)slot).GetController("Lock").SetSelectedIndex((!unlock) ? 1 : 0);
		}
	}

	private void UpdateRewardList(bool isAutoScrollToHead = true)
	{
		if (((GObject)this).isDisposed)
		{
			return;
		}
		int num = 0;
		while (IsUpdatingRewardList)
		{
			Task.Delay(200);
			num++;
			if (num > 10)
			{
				break;
			}
		}
		IsUpdatingRewardList = true;
		if (DataLoadingStatus == LoadingStatus.LOADED)
		{
			GetRewardState();
			RewardList.numItems = RewardDisplayCount;
			UpdateNextBigReward();
			UpdateStatus();
		}
		if (isAutoScrollToHead)
		{
			RewardList.ScrollToView(CurrentContributionSlotIndex());
		}
		((GObject)QuickGetBtn).grayed = GetCurContributionPoint() >= LastPointNum;
		((GObject)QuickGetBtn).touchable = !((GObject)QuickGetBtn).grayed;
		IsUpdatingRewardList = false;
	}

	private int CurrentContributionSlotIndex()
	{
		int num = RewardDisplayCount - 1;
		int num2 = RewardData.FindIndex((SlotData reward) => reward.Contribution >= GetCurContributionPoint());
		if (num2 < 0)
		{
			num2 = num;
		}
		if (num2 > num)
		{
			num2 = num;
		}
		return Mathf.Max(num2 - 5, 0);
	}

	private int NextContributionSlotIndex()
	{
		int num = RewardDisplayCount - 1;
		int num2 = RewardData.FindIndex((SlotData reward) => reward.Contribution > GetCurContributionPoint());
		if (num2 < 0)
		{
			num2 = num;
		}
		if (num2 > num)
		{
			num2 = num;
		}
		return num2;
	}

	private static bool CheckInProgress(HashSet<int> progress, int contribution)
	{
		return progress?.Contains(contribution) ?? false;
	}

	private void GetRewardState()
	{
		HashSet<int> hashSet = new HashSet<int>();
		HashSet<int> hashSet2 = new HashSet<int>();
		HashSet<int> hashSet3 = new HashSet<int>();
		Dictionary<string, List<int>> dictionary = (IsIzInSettlement ? PlayerSettlement.GvGBattlePassRecord : Singleton<WorldStateManager>.Instance.Data.BattlePassClaimedBonus);
		if (!string.IsNullOrEmpty(_configData.NormalActivity?.ActivityId))
		{
			dictionary.TryGetValue(_configData.NormalActivity.ActivityId, out var value);
			hashSet.UnionWith(value ?? new List<int>());
		}
		if (!string.IsNullOrEmpty(_configData.AdvancedActivity?.ActivityId))
		{
			dictionary.TryGetValue(_configData.AdvancedActivity.ActivityId, out var value2);
			hashSet2.UnionWith(value2 ?? new List<int>());
		}
		if (!string.IsNullOrEmpty(_configData.PremiumActivity?.ActivityId))
		{
			dictionary.TryGetValue(_configData.PremiumActivity.ActivityId, out var value3);
			hashSet3.UnionWith(value3 ?? new List<int>());
		}
		_claimedBonus.Clear();
		foreach (SlotData rewardDatum in RewardData)
		{
			int contribution = rewardDatum.Contribution;
			if (CheckInProgress(hashSet, contribution))
			{
				rewardDatum.state_basic = 2;
			}
			else if (GetCurContributionPoint() >= contribution && rewardDatum.num_basic > 0)
			{
				rewardDatum.state_basic = 1;
				_claimedBonus.TryAddClaimedRecord(_configData.NormalActivity?.ActivityId);
			}
			else
			{
				rewardDatum.state_basic = 0;
			}
			if (CheckInProgress(hashSet2, contribution))
			{
				rewardDatum.state_advanced = 2;
			}
			else if (GetCurContributionPoint() >= contribution && rewardDatum.num_advanced > 0)
			{
				rewardDatum.state_advanced = 1;
				_claimedBonus.TryAddClaimedRecord(_configData.AdvancedActivity?.ActivityId);
			}
			else
			{
				rewardDatum.state_advanced = 0;
			}
			if (CheckInProgress(hashSet3, contribution))
			{
				rewardDatum.state_premium = 2;
			}
			else if (GetCurContributionPoint() >= contribution && rewardDatum.num_premium > 0)
			{
				rewardDatum.state_premium = 1;
				_claimedBonus.TryAddClaimedRecord(_configData.PremiumActivity?.ActivityId);
			}
			else
			{
				rewardDatum.state_premium = 0;
			}
		}
	}

	private void UpdateNextBigReward(bool isForcedRefresh = false)
	{
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		if (((GObject)this).isDisposed || ((GComponent)RewardList).numChildren <= 0)
		{
			return;
		}
		int index = RewardList.ChildIndexToItemIndex(((GComponent)RewardList).numChildren - 3);
		int targetScrollX = RewardData[index].TargetScrollX;
		foreach (SpecialSlot item in SpecialReward)
		{
			if (item.TargetScrollX <= targetScrollX)
			{
				continue;
			}
			SlotData slotData = item.Data;
			if (LastBigRewardLevel != slotData.Contribution || isForcedRefresh)
			{
				LastBigRewardLevel = slotData.Contribution;
				((GObject)NextBigSlot).visible = true;
				NextBigSlot.Switch.Play();
				SetSmallSFXMask();
				((GObject)NextBigSlot.TargetLevel).text = slotData.NominalLevel.ToString();
				NextBigSlot.Basic.Icon.url = slotData.icon_basic;
				NextBigSlot.Advanced.Icon.url = slotData.icon_advanced;
				NextBigSlot.Premium.Icon.url = slotData.icon_premium;
				((GObject)NextBigSlot.Basic.Num).text = slotData.num_basic.ToString();
				((GObject)NextBigSlot.Advanced.Num).text = slotData.num_advanced.ToString();
				((GObject)NextBigSlot.Premium.Num).text = slotData.num_premium.ToString();
				NextBigSlot.Basic.State.selectedIndex = slotData.state_basic;
				NextBigSlot.Advanced.State.selectedIndex = slotData.state_advanced;
				NextBigSlot.Premium.State.selectedIndex = slotData.state_premium;
				((GObject)NextBigSlot.Basic).onClick.Set((EventCallback0)delegate
				{
					FGUIManager.Instance.ItemTip(slotData.id_basic, ((GObject)this).sortingOrder, noCheckBtn: true);
				});
				((GObject)NextBigSlot.Advanced).onClick.Set((EventCallback0)delegate
				{
					FGUIManager.Instance.ItemTip(slotData.id_advanced, ((GObject)this).sortingOrder, noCheckBtn: true);
				});
				((GObject)NextBigSlot.Premium).onClick.Set((EventCallback0)delegate
				{
					FGUIManager.Instance.ItemTip(slotData.id_premium, ((GObject)this).sortingOrder, noCheckBtn: true);
				});
				((GObject)NextBigSlot.SlotBuyBtn).onClick.Set((EventCallback0)delegate
				{
					OpenBuyPanel(1, slotData.NominalLevel);
				});
				((GObject)NextBigSlot.Basic).visible = slotData.num_basic > 0;
				((GObject)NextBigSlot.Advanced).visible = slotData.num_advanced > 0;
				((GObject)NextBigSlot.Premium).visible = slotData.num_premium > 0;
			}
			UpdateAdvancedSlotSFX(NextBigSlot.Advanced, IsAdvancedMode);
			UpdateAdvancedSlotSFX(NextBigSlot.Premium, PremiumActivated);
			return;
		}
		LastBigRewardLevel = -1;
		((GObject)NextBigSlot).visible = false;
		SetBigSFXMask();
	}

	private void OnBonusListScroll()
	{
		if (!IsUpdatingRewardList)
		{
			UpdateNextBigReward();
		}
	}

	private void UpdateInsuranceState()
	{
		((GObject)Insurance).visible = Define.IsGvGAutomationOpen();
		Insurance.State.SetSelectedIndex(_IsAdvanced ? 1 : 0);
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (itemId == "MTG")
		{
			UpdateMTG();
		}
	}

	private void OrderShipSuccessEvent(List<Bonus> result, List<Bonus> bonuses)
	{
		if (IsIzInSettlement)
		{
			Singleton<GvGMode3RoomManager>.Instance.RefreshLastBattlePassData(RefreshLastBattlePassData);
		}
		void RefreshLastBattlePassData()
		{
			OnPushContributionPointChange(Mathf.FloorToInt(PlayerSettlement.ContributionPoints));
			UpdateIsAdvancedMode(PlayerSettlement.HasAdvancedPass);
			UpdatePremiumActivated(PlayerSettlement.HasPremiumPass);
			UpdateStatus();
		}
	}

	private void OnCheckInsuranceIsland()
	{
		End();
	}

	private void UpdateIsAdvancedMode(bool isAdvancedMode)
	{
		if (isAdvancedMode != IsAdvancedMode)
		{
			IsAdvancedMode = isAdvancedMode;
		}
	}

	private void UpdatePremiumActivated(bool premiumActivated)
	{
		if (premiumActivated != PremiumActivated)
		{
			PremiumActivated = premiumActivated;
		}
	}

	private void OnPushContributionPointChange(int points)
	{
		if (points != GetCurContributionPoint())
		{
			SetCurContributionPoint(points, isAutoScrollToHead: false);
		}
	}

	public void UpdateMTG()
	{
		int stock = GameManagers.Instance.StockController.GetStock("MTG");
		((GObject)addMTGBtn.GetChild("num").asTextField).text = stock.ToString();
		int num = ((addMTGBtn.GetChild("num").data != null) ? ((int)addMTGBtn.GetChild("num").data) : stock);
		if (num != stock && stock > num)
		{
			int num2 = stock - num;
			if (NumFloatingMTG == null)
			{
				NumFloatingMTG = UI_ProductionNumFloating.CreateInstance_ILRuntime();
			}
			if (!((GObject)NumFloatingMTG).onStage)
			{
				FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloatingMTG, addMTGBtn, stock - num);
			}
			else
			{
				((GObject)NumFloatingMTG.Title).text = $"+{(int)((GObject)NumFloatingMTG.Title).data + num2}";
				((GObject)NumFloatingMTG.Title).data = (int)((GObject)NumFloatingMTG.Title).data + num2;
			}
		}
		addMTGBtn.GetChild("num").data = stock;
	}

	private void OnClickNormalSlot(UI_com_LevelSlot levelSlot, int index)
	{
		SlotData slotData = RewardData[index];
		if (levelSlot.Basic.State.selectedIndex == 1)
		{
			ClaimReward(_configData.NormalActivity?.ActivityId, slotData.Contribution.ToString());
		}
		else
		{
			FGUIManager.Instance.ItemTip(slotData.id_basic, ((GObject)this).sortingOrder, noCheckBtn: true);
		}
	}

	private void OnClickAdvancedSlot(UI_btn_RewardSlot2 slot, int index)
	{
		SlotData slotData = RewardData[index];
		if (IsAdvancedMode)
		{
			if (slot.State.selectedIndex == 1)
			{
				ClaimReward(_configData.AdvancedActivity?.ActivityId, slotData.Contribution.ToString());
			}
			else
			{
				FGUIManager.Instance.ItemTip(slotData.id_advanced, ((GObject)this).sortingOrder, noCheckBtn: true);
			}
		}
		else
		{
			OpenBuyPanel(0);
		}
	}

	private void OnClickPremiumSlot(UI_btn_RewardSlot2 slot, int index)
	{
		SlotData slotData = RewardData[index];
		if (PremiumActivated)
		{
			if (slot.State.selectedIndex == 1)
			{
				ClaimReward(_configData.PremiumActivity?.ActivityId, slotData.Contribution.ToString());
			}
			else
			{
				FGUIManager.Instance.ItemTip(slotData.id_premium, ((GObject)this).sortingOrder, noCheckBtn: true);
			}
		}
		else
		{
			OpenBuyPanel(2);
		}
	}

	private void OnOneClickClaim()
	{
		bool flag = _claimedBonus.HasClaimedBonus(_configData.NormalActivity?.ActivityId);
		bool flag2 = IsAdvancedMode && _claimedBonus.HasClaimedBonus(_configData.AdvancedActivity?.ActivityId);
		bool flag3 = PremiumActivated && _claimedBonus.HasClaimedBonus(_configData.PremiumActivity?.ActivityId);
		if (flag)
		{
			ClaimReward(_configData.NormalActivity?.ActivityId, "");
		}
		if (flag2)
		{
			ClaimReward(_configData.AdvancedActivity?.ActivityId, "");
		}
		if (flag3)
		{
			ClaimReward(_configData.PremiumActivity?.ActivityId, "");
		}
		if (!(flag || flag2 || flag3))
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText638") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
	}

	private void ClaimReward(string activityId, string contributionPoint)
	{
		if (!string.IsNullOrEmpty(activityId))
		{
			if (IsIzInSettlement)
			{
				Singleton<GvGMode3RoomManager>.Instance.GvGMode3ClaimLastBattlePassBonus(activityId, contributionPoint, UpdateRewards);
			}
			else
			{
				Singleton<WorldStateManager>.Instance.ClaimBattlePassBonus(activityId, contributionPoint, UpdateRewards);
			}
		}
		void UpdateRewards()
		{
			UpdateRewardList(isAutoScrollToHead: false);
			UpdateNextBigReward(isForcedRefresh: true);
			_IsNoteDirty = true;
			UpdateStatus();
		}
	}

	public void OnClickMTGBtn()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerAddCredit.Name, new Dictionary<string, object>
		{
			{
				"Activity",
				FGUIManager.Instance.GetBlackMarketerActivity(UI_MtgGiftPacksPanel.Name)
			},
			{
				"Order",
				((GObject)this).sortingOrder
			}
		});
	}

	private void OpenBuyPanel(int mode, int defaultLevel = -1)
	{
		if (!((GObject)this).isDisposed && DataLoadingStatus == LoadingStatus.LOADED)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_BuyBattlePass.Name, new Dictionary<string, object>
			{
				{ "Parent", this },
				{ "Mode", mode },
				{ "DefaultLevel", defaultLevel }
			});
		}
	}

	private void OpenMissionPanel()
	{
		if (!((GObject)this).isDisposed)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_BattlePassMission.Name, new Dictionary<string, object> { { "Parent", this } });
		}
	}

	private void OnClickHelpBtn()
	{
		"GvG3HelpButtonClick".ToShowLanguageTip();
	}

	private void OnInsuranceClick()
	{
		UI_main_BuyGvGInsurance.OpenBuyGvGInsurancePanel(_IsAdvanced, delegate
		{
			OpenBuyPanel(0);
		});
	}

	private void SetBigSFXMask()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		Mask.transform.localScale = new Vector3(412f, 185f, 108f);
		Mask.transform.localPosition = new Vector3(801f, -313f, 0f);
	}

	private void SetSmallSFXMask()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		Mask.transform.localScale = new Vector3(360f, 185f, 108f);
		Mask.transform.localPosition = new Vector3(880f, -318f, 0f);
	}

	public void End()
	{
		OnClose?.Callback?.Invoke();
		if (PlayTimeShakingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(PlayTimeShakingCoroutine);
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		if (_IsNoteDirty)
		{
			CacheManager.Instance.Get<Cache_WarOrderState>().ForceUpdate();
		}
	}

	public void Destroy()
	{
		foreach (GameObject item in SfxCache)
		{
			if (Object.op_Implicit((Object)(object)item))
			{
				SpawnManager.Instance.Destroy(item);
			}
		}
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
		Window window = _window;
		if (window != null)
		{
			((GObject)window).Dispose();
		}
		MaxCurContributionLevel = -1;
		Singleton<GvG3BattlePassManager>.Instance.CheckClaimable();
	}

	public void BeforeDestroy()
	{
	}
}
