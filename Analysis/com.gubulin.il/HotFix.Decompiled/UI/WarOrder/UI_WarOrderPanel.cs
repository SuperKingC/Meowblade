using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using DG.Tweening;
using DG.Tweening.Core;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.AddCredit;
using UI.MtgGiftPacks;
using UI.PublicResources;
using UnityEngine;

namespace UI.WarOrder;

public class UI_WarOrderPanel : GComponent, IUiController
{
	public Controller PageController;

	public Controller Mode;

	public GLoader background;

	public UI_Title Title;

	public GImage n132;

	public GComponent addDiamondBtn;

	public GComponent addMTGBtn;

	public GButton BackBtn;

	public GTextField TimeTitle;

	public GTextField StartTime;

	public GTextField EndTime;

	public GLoader CurLevelIcon;

	public GTextField CurLevelText;

	public GTextField n117;

	public UI_QuickGetBtn QuickGetBtn;

	public GList ProgressWrapper;

	public GList RewardList;

	public GImage n112;

	public UI_OneClickClaimBtn OneClickClaimBtn;

	public UI_BuyAdvancedBtn BuyAdvanceBtn;

	public UI_CSlider slider;

	public GImage n133;

	public UI_LevelSlot_Big NextBigSlot;

	public UI_WeeklyTab WeeklyTab;

	public UI_HelpBtn HelpBtn;

	public GGraph WeeklyMask;

	public Transition TimeBreathing;

	public Transition TimeNormal;

	public Transition TimeShake;

	public const string URL = "ui://ax280w58p8ii0";

	public static string Name = "UI_WarOrderPanel";

	private int LastBigRewardLevel = 0;

	private bool IsUpdatingRewardList = false;

	private int _CurLevel = 0;

	private bool _IsAdvanced = false;

	private float LevelToShow = 0f;

	private int SlotWidth = 0;

	private int ListWidth = 0;

	public int FirstLevelNum = 0;

	public int LastLevelNum = 0;

	private List<GameObject> SfxCache = new List<GameObject>();

	private UI_ProductionNumFloating NumFloatingGem;

	private UI_ProductionNumFloating NumFloatingMTG;

	public static LoadingStatus DataLoadingStatus = LoadingStatus.NOT_STARTED;

	public static List<SlotData> RewardData = new List<SlotData>();

	public static List<SpecialSlot> SpecialReward = new List<SpecialSlot>();

	public static Activity NormalActivity = null;

	public static BattlePassActivityPayload NormalPayload = null;

	public static Activity AdvancedActivity = null;

	public static BattlePassActivityPayload AdvancedPayload = null;

	private Tweener CurLevelTweener;

	public GameObject Mask = null;

	private bool _IsNoteDirty = false;

	private bool hasUnclaimedBonus = false;

	private Coroutine PlayTimeShakingCoroutine;

	public int CurLevel
	{
		get
		{
			return _CurLevel;
		}
		set
		{
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Expected O, but got Unknown
			_CurLevel = value;
			Tweener curLevelTweener = CurLevelTweener;
			if (curLevelTweener != null)
			{
				TweenExtensions.Kill((Tween)(object)curLevelTweener, false);
			}
			CurLevelTweener = (Tweener)(object)DOTween.To((DOGetter<float>)(() => LevelToShow), (DOSetter<float>)delegate(float x)
			{
				LevelToShow = x;
			}, (float)_CurLevel, 1f);
			TweenSettingsExtensions.OnUpdate<Tweener>(CurLevelTweener, (TweenCallback)delegate
			{
				if (!((GObject)this).isDisposed)
				{
					((GObject)CurLevelText).text = Math.Round(LevelToShow).ToString();
					UpdateRewardList();
				}
			});
		}
	}

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
				_IsAdvanced = value;
				Mode.selectedIndex = (_IsAdvanced ? 1 : 0);
				UpdateRewardList();
				UpdateNextBigReward();
			}
		}
	}

	public static string GetURL()
	{
		return "ui://ax280w58p8ii0";
	}

	public static UI_WarOrderPanel CreateInstance()
	{
		return (UI_WarOrderPanel)(object)UIPackage.CreateObject("WarOrder", "WarOrderPanel");
	}

	public static UI_WarOrderPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WarOrderPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58p8ii0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		Mode = ((GComponent)this).GetController("Mode");
		background = (GLoader)((GComponent)this).GetChild("background");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		n132 = (GImage)((GComponent)this).GetChild("n132");
		addDiamondBtn = (GComponent)((GComponent)this).GetChild("addDiamondBtn");
		addMTGBtn = (GComponent)((GComponent)this).GetChild("addMTGBtn");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		TimeTitle = (GTextField)((GComponent)this).GetChild("TimeTitle");
		string id = "ui://ax280w58p8ii0".Replace("ui://", "") + "-" + ((GObject)TimeTitle).id;
		((GObject)TimeTitle).text = LanguagesManager.GetDesc(id);
		StartTime = (GTextField)((GComponent)this).GetChild("StartTime");
		EndTime = (GTextField)((GComponent)this).GetChild("EndTime");
		CurLevelIcon = (GLoader)((GComponent)this).GetChild("CurLevelIcon");
		CurLevelText = (GTextField)((GComponent)this).GetChild("CurLevelText");
		string id2 = "ui://ax280w58p8ii0".Replace("ui://", "") + "-" + ((GObject)CurLevelText).id;
		((GObject)CurLevelText).text = LanguagesManager.GetDesc(id2);
		n117 = (GTextField)((GComponent)this).GetChild("n117");
		string id3 = "ui://ax280w58p8ii0".Replace("ui://", "") + "-" + ((GObject)n117).id;
		((GObject)n117).text = LanguagesManager.GetDesc(id3);
		QuickGetBtn = (UI_QuickGetBtn)(object)((GComponent)this).GetChild("QuickGetBtn");
		ProgressWrapper = (GList)((GComponent)this).GetChild("ProgressWrapper");
		RewardList = (GList)((GComponent)this).GetChild("RewardList");
		n112 = (GImage)((GComponent)this).GetChild("n112");
		OneClickClaimBtn = (UI_OneClickClaimBtn)(object)((GComponent)this).GetChild("OneClickClaimBtn");
		BuyAdvanceBtn = (UI_BuyAdvancedBtn)(object)((GComponent)this).GetChild("BuyAdvanceBtn");
		slider = (UI_CSlider)(object)((GComponent)this).GetChild("slider");
		n133 = (GImage)((GComponent)this).GetChild("n133");
		NextBigSlot = (UI_LevelSlot_Big)(object)((GComponent)this).GetChild("NextBigSlot");
		WeeklyTab = (UI_WeeklyTab)(object)((GComponent)this).GetChild("WeeklyTab");
		HelpBtn = (UI_HelpBtn)(object)((GComponent)this).GetChild("HelpBtn");
		WeeklyMask = (GGraph)((GComponent)this).GetChild("WeeklyMask");
		TimeBreathing = ((GComponent)this).GetTransition("TimeBreathing");
		TimeNormal = ((GComponent)this).GetTransition("TimeNormal");
		TimeShake = ((GComponent)this).GetTransition("TimeShake");
	}

	public void RegisterUiEventListeners()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		slider.RegisterUiEventListeners();
		((GObject)BackBtn).onClick.Set(new EventCallback0(End));
		((GComponent)RewardList).scrollPane.onScroll.Add(new EventCallback0(OnBonusListScroll));
		((GObject)BuyAdvanceBtn).onClick.Set((EventCallback0)delegate
		{
			OpenBuyPanel(0);
		});
		((GObject)QuickGetBtn).onClick.Set((EventCallback0)delegate
		{
			OpenBuyPanel(1);
		});
		((GObject)OneClickClaimBtn).onClick.Set(new EventCallback0(OnOneClickClaim));
		addDiamondBtn.GetChild("addButton").onClick.Set(new EventCallback0(OnClickDiamondBtn));
		addMTGBtn.GetChild("addButton").onClick.Set(new EventCallback0(OnClickMTGBtn));
		((GObject)WeeklyTab).onClick.Set(new EventCallback0(OpenMissionPanel));
		((GObject)HelpBtn).onClick.Set(new EventCallback0(OnClickHelpBtn));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void UnregisterUiEventListeners()
	{
		slider.UnregisterUiEventListeners();
		((GObject)BackBtn).onClick.Clear();
		((GComponent)RewardList).scrollPane.onScroll.Clear();
		((GObject)BuyAdvanceBtn).onClick.Clear();
		((GObject)QuickGetBtn).onClick.Clear();
		((GObject)NextBigSlot.SlotBuyBtn).onClick.Clear();
		((GObject)OneClickClaimBtn).onClick.Clear();
		addDiamondBtn.GetChild("addButton").onClick.Clear();
		addMTGBtn.GetChild("addButton").onClick.Clear();
		((GObject)WeeklyTab).onClick.Clear();
		((GObject)HelpBtn).onClick.Clear();
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		CacheManager.Instance.Get<Cache_WarOrderScore>().IsSyncProduce = true;
		UI_LevelSlot uI_LevelSlot = UI_LevelSlot.CreateInstance();
		SlotWidth = ((GObject)uI_LevelSlot).initWidth;
		ListWidth = (int)((GObject)RewardList).width;
		((GObject)uI_LevelSlot).Dispose();
		((GComponent)this).EnsureBoundsCorrect();
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
		((GObject)ProgressWrapper).alpha = 0f;
		((GObject)ProgressWrapper).TweenFade(1f, 1.5f);
		((GObject)QuickGetBtn).visible = false;
		((GObject)BuyAdvanceBtn).visible = false;
		((GObject)OneClickClaimBtn).visible = false;
		((GObject)NextBigSlot.SlotBuyBtn).visible = false;
		RewardList.SetVirtual();
		RewardList.itemRenderer = new ListItemRenderer(ItemRenderer);
		RewardList.numItems = 0;
		InitSFXMask();
		((GObject)NextBigSlot).visible = false;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(GetRewardData());
		addDiamondBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Gem");
		addMTGBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("MTG");
		UpdateGemstone();
		UpdateMTG();
		_IsNoteDirty = false;
		hasUnclaimedBonus = false;
		SetBuildingName();
	}

	private (int, int) MinMaxLevel(Dictionary<int, Dictionary<string, int>> dic)
	{
		int num = -1;
		int num2 = -1;
		foreach (KeyValuePair<int, Dictionary<string, int>> item in dic)
		{
			if (item.Key < num || num == -1)
			{
				num = item.Key;
			}
			if (item.Key > num2 || num2 == -1)
			{
				num2 = item.Key;
			}
		}
		return (num, num2);
	}

	private void OnActivityLoaded()
	{
		if (!((GObject)this).isDisposed && NormalPayload != null && AdvancedPayload != null)
		{
			(int, int) tuple = MinMaxLevel(AdvancedPayload.BonusConfig);
			FirstLevelNum = tuple.Item1;
			LastLevelNum = tuple.Item2;
			CurLevel = GameManagers.Instance.StockController.GetStock(NormalPayload.ScoreItem);
			IsAdvancedMode = GameManagers.Instance.StockController.GetStock(AdvancedPayload.PaidCert) > 0;
			CurLevelIcon.url = GetIconByItemId(NormalPayload.ScoreItem);
			((GObject)QuickGetBtn).visible = true;
			((GObject)BuyAdvanceBtn).visible = true;
			((GObject)OneClickClaimBtn).visible = true;
			((GObject)NextBigSlot.SlotBuyBtn).visible = true;
			UI_ProgressBar uI_ProgressBar = (UI_ProgressBar)(object)((GComponent)ProgressWrapper).GetChildAt(0);
			((GObject)uI_ProgressBar).width = SlotWidth * AdvancedPayload.BonusConfig.Count;
			ActivityConfig activityConfig = NormalActivity.ActivityProgress(GameManagers.Instance);
			DateTimeOffset dateTimeOffset = activityConfig.BeginAt.ToOffset(DateTimeHelper.TimezoneOffset);
			DateTimeOffset dateTimeOffset2 = activityConfig.EndAt.ToOffset(DateTimeHelper.TimezoneOffset);
			if (!HotUpdateProcess.Instance.IsRegionOutCN)
			{
				((GObject)StartTime).text = dateTimeOffset.ToString("yyyy" + LanguagesManager.GetDesc("CsharpCodeZhTcText557") + "M" + LanguagesManager.GetDesc("CsharpCodeZhTcText397") + "d" + LanguagesManager.GetDesc("CsharpCodeZhTcText398") + "hh:mm") + " — ";
				((GObject)EndTime).text = dateTimeOffset2.ToString("yyyy" + LanguagesManager.GetDesc("CsharpCodeZhTcText557") + "M" + LanguagesManager.GetDesc("CsharpCodeZhTcText397") + "d" + LanguagesManager.GetDesc("CsharpCodeZhTcText398") + "hh:mm") ?? "";
			}
			else
			{
				((GObject)StartTime).text = UiHelper.GetDateStringMMddHH(dateTimeOffset.LocalDateTime) + " — ";
				((GObject)EndTime).text = UiHelper.GetDateStringMMddHH(dateTimeOffset2.LocalDateTime);
			}
			InitEndTimeAnim();
			RewardList.numItems = AdvancedPayload.BonusConfig.Count;
		}
	}

	public float GetRemainingTime()
	{
		if (NormalActivity == null)
		{
			return -1f;
		}
		DateTimeOffset endAt = NormalActivity.ActivityProgress(GameManagers.Instance).EndAt;
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
		if (!((GObject)this).isDisposed && NormalPayload != null && AdvancedPayload != null)
		{
			IsAdvancedMode = GameManagers.Instance.StockController.GetStock(AdvancedPayload.PaidCert) > 0;
			CurLevel = GameManagers.Instance.StockController.GetStock(NormalPayload.ScoreItem);
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
		List<Activity> activities = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.BattlePass, null, isSort: false);
		foreach (Activity activity in activities)
		{
			if (activity.GetStatus(GameManagers.Instance) == ActivityStatus.Enabled)
			{
				Dictionary<string, ActivityContentPayload>.Enumerator enumerator2 = activity.ContentPayload(GameManagers.Instance).GetEnumerator();
				enumerator2.MoveNext();
				BattlePassActivityPayload payload = (BattlePassActivityPayload)enumerator2.Current.Value;
				if (string.IsNullOrEmpty(payload.PaidCert) && NormalActivity == null)
				{
					NormalActivity = activity;
					NormalPayload = payload;
				}
				else if (!string.IsNullOrEmpty(payload.PaidCert) && AdvancedActivity == null)
				{
					AdvancedActivity = activity;
					AdvancedPayload = payload;
				}
			}
		}
		OnActivityLoaded();
		yield return null;
		int index = 0;
		foreach (int level in AdvancedPayload.BonusConfig.Keys)
		{
			SlotData slotData = new SlotData
			{
				level = level
			};
			NormalPayload.BonusConfig.TryGetValue(level, out var normalSlot);
			AdvancedPayload.BonusConfig.TryGetValue(level, out var advancedSlot);
			if (normalSlot != null && normalSlot.Count > 0)
			{
				Dictionary<string, int>.Enumerator enumerator4 = normalSlot.GetEnumerator();
				enumerator4.MoveNext();
				KeyValuePair<string, int> s = enumerator4.Current;
				slotData.icon_normal = GetIconByItemId(s.Key);
				slotData.num_normal = s.Value;
				slotData.id_normal = s.Key;
			}
			if (advancedSlot != null && advancedSlot.Count > 0)
			{
				Dictionary<string, int>.Enumerator enumerator5 = advancedSlot.GetEnumerator();
				enumerator5.MoveNext();
				KeyValuePair<string, int> s2 = enumerator5.Current;
				slotData.icon_advanced1 = GetIconByItemId(s2.Key);
				slotData.num_advanced1 = s2.Value;
				slotData.id_advanced1 = s2.Key;
				if (advancedSlot.Count > 1)
				{
					enumerator5.MoveNext();
					s2 = enumerator5.Current;
					slotData.icon_advanced2 = GetIconByItemId(s2.Key);
					slotData.num_advanced2 = s2.Value;
					slotData.id_advanced2 = s2.Key;
				}
			}
			RewardData.Add(slotData);
			if (AdvancedPayload.SpecialNodes.Contains(slotData.level))
			{
				SpecialReward.Add(new SpecialSlot
				{
					TargetScrollX = CalculateSlotEmergingScrollX(index),
					Data = slotData
				});
				if (SpecialReward.Count == 1)
				{
					UpdateNextBigReward();
				}
			}
			if (!((GObject)this).isDisposed && index % 4 == 0 && index < 9)
			{
				RewardList.numItems = RewardData.Count;
				yield return null;
			}
			int num = index + 1;
			index = num;
			normalSlot = null;
			advancedSlot = null;
		}
		DataLoadingStatus = LoadingStatus.LOADED;
		OnAllDataLoaded();
	}

	private string GetIconByItemId(string itemId)
	{
		return "ui://PublicResources/" + UiHelper.GetIcon(itemId);
	}

	private int CalculateSlotEmergingScrollX(int slotIndex)
	{
		int num = 30;
		int num2 = ListWidth - SlotWidth + num;
		return SlotWidth * (slotIndex + 1) - num2;
	}

	public void OnShow()
	{
	}

	private void ItemRenderer(int index, GObject obj)
	{
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		if (((GObject)this).isDisposed)
		{
			return;
		}
		UI_LevelSlot levelSlot = (UI_LevelSlot)(object)obj;
		if (index >= RewardData.Count)
		{
			((GObject)levelSlot.TargetLevel).text = "--";
			levelSlot.LevelState.selectedIndex = 0;
			((GObject)levelSlot.Normal).visible = false;
			((GObject)levelSlot.Advanced1).visible = false;
			((GObject)levelSlot.Advanced2).visible = false;
			return;
		}
		SlotData slotData = RewardData[index];
		((GObject)levelSlot.TargetLevel).text = slotData.level.ToString();
		levelSlot.LevelState.selectedIndex = (((double)slotData.level <= Math.Round(LevelToShow)) ? 1 : 0);
		levelSlot.Normal.Icon.url = slotData.icon_normal;
		levelSlot.Advanced1.Icon.url = slotData.icon_advanced1;
		levelSlot.Advanced2.Icon.url = slotData.icon_advanced2;
		int selectedIndex = ((slotData.num_advanced2 > 0) ? 1 : 0);
		levelSlot.AdvanceNum.selectedIndex = selectedIndex;
		levelSlot.Normal.State.selectedIndex = slotData.state_normal;
		levelSlot.Advanced1.State.selectedIndex = slotData.state_advanced1;
		levelSlot.Advanced2.State.selectedIndex = slotData.state_advanced2;
		((GObject)levelSlot.Normal.Num).text = slotData.num_normal.ToString();
		((GObject)levelSlot.Advanced1.Num).text = slotData.num_advanced1.ToString();
		((GObject)levelSlot.Advanced2.Num).text = slotData.num_advanced2.ToString();
		if (slotData.state_normal == 1)
		{
			UpdateNormalSlotSFX((GComponent)(object)levelSlot.Normal);
		}
		UpdateAdvancedSlotSFX((GComponent)(object)levelSlot.Advanced1);
		UpdateAdvancedSlotSFX((GComponent)(object)levelSlot.Advanced2);
		((GObject)levelSlot.Normal).onClick.Set((EventCallback0)delegate
		{
			OnClickNormalSlot(levelSlot, index);
		});
		((GObject)levelSlot.Advanced1).onClick.Set((EventCallback0)delegate
		{
			OnClickAdvancedSlot(levelSlot.Advanced1, index);
		});
		((GObject)levelSlot.Advanced2).onClick.Set((EventCallback0)delegate
		{
			OnClickAdvancedSlot(levelSlot.Advanced2, index);
		});
		((GObject)levelSlot.Normal).visible = slotData.num_normal > 0;
		((GObject)levelSlot.Advanced1).visible = slotData.num_advanced1 > 0;
		((GObject)levelSlot.Advanced2).visible = slotData.num_advanced2 > 0;
	}

	private void UpdateNormalSlotSFX(GComponent slot, bool IsInMask = true)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		if (((GObject)slot).isDisposed)
		{
			return;
		}
		GGraph asGraph = slot.GetChild("SfxBack").asGraph;
		if (((GObject)slot).data == null)
		{
			string sFXName = "ui_stroke_square_sp" + (IsInMask ? "_inmask" : "");
			GameObject val = FGUIManager.Instance.AddTextSpecialEffects(asGraph, sFXName, new Vector3(100f, 100f, 100f));
			if ((Object)(object)val != (Object)null)
			{
				((GObject)slot).data = val;
				SfxCache.Add(val);
			}
		}
	}

	private void UpdateAdvancedSlotSFX(GComponent slot, bool IsInMask = true)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		if (((GObject)slot).isDisposed)
		{
			return;
		}
		GGraph asGraph = slot.GetChild("SfxBack").asGraph;
		GGraph asGraph2 = slot.GetChild("SfxBack2").asGraph;
		if (((GObject)slot).data == null)
		{
			string sFXName = "ui_stroke_square_sp" + (IsInMask ? "_inmask" : "");
			GameObject val = FGUIManager.Instance.AddTextSpecialEffects(asGraph, sFXName, new Vector3(100f, 100f, 100f));
			if ((Object)(object)val != (Object)null)
			{
				((GObject)slot).data = val;
				SfxCache.Add(val);
			}
			sFXName = "activated_fx" + (IsInMask ? "_inmask" : "");
			val = FGUIManager.Instance.AddTextSpecialEffects(asGraph2, sFXName, new Vector3(100f, 100f, 100f));
			if ((Object)(object)val != (Object)null)
			{
				SfxCache.Add(val);
			}
		}
		if (IsAdvancedMode)
		{
			slot.GetController("IsAdvancedMode").selectedIndex = 1;
			((GObject)asGraph).visible = true;
		}
		else
		{
			slot.GetController("IsAdvancedMode").selectedIndex = 0;
			((GObject)asGraph).visible = false;
		}
	}

	private void UpdateRewardList(bool isAutoScrollToHead = true)
	{
		if (((GObject)this).isDisposed || IsUpdatingRewardList)
		{
			return;
		}
		IsUpdatingRewardList = true;
		if (DataLoadingStatus == LoadingStatus.LOADED)
		{
			GetRewardState();
			UpdateNextBigReward();
		}
		RewardList.numItems = RewardData.Count;
		UI_ProgressBar uI_ProgressBar = (UI_ProgressBar)(object)((GComponent)ProgressWrapper).GetChildAt(0);
		if (LevelToShow < (float)FirstLevelNum)
		{
			float num = LevelToShow / (float)FirstLevelNum;
			((GObject)uI_ProgressBar.Bar).width = (float)SlotWidth / 2f * num;
		}
		else
		{
			float num2 = (LevelToShow - (float)FirstLevelNum) / (float)(LastLevelNum - FirstLevelNum);
			((GObject)uI_ProgressBar.Bar).width = (((GObject)uI_ProgressBar).width - (float)SlotWidth) * num2 + (float)SlotWidth / 2f;
		}
		if (isAutoScrollToHead)
		{
			float num3 = ((GObject)uI_ProgressBar.Bar).width - ((GObject)RewardList).width * 0.5f;
			float num4 = ((GComponent)RewardList).scrollPane.contentWidth - ((GObject)RewardList).width * 0.5f;
			if (0f < num3 && num3 < num4)
			{
				((GComponent)RewardList).scrollPane.posX = num3;
			}
		}
		((GObject)QuickGetBtn).grayed = CurLevel >= LastLevelNum;
		((GObject)QuickGetBtn).touchable = !((GObject)QuickGetBtn).grayed;
		IsUpdatingRewardList = false;
	}

	private bool CheckInProgress(List<float> progress, int level)
	{
		foreach (float item in progress)
		{
			if (Math.Round(item) == (double)level)
			{
				return true;
			}
		}
		return false;
	}

	private void GetRewardState()
	{
		List<float> progress = NormalActivity.ClaimProgress(GameManagers.Instance);
		List<float> progress2 = AdvancedActivity.ClaimProgress(GameManagers.Instance);
		hasUnclaimedBonus = false;
		foreach (SlotData rewardDatum in RewardData)
		{
			int level = rewardDatum.level;
			if (CheckInProgress(progress, level))
			{
				rewardDatum.state_normal = 2;
			}
			else if (Math.Round(LevelToShow) >= (double)level && rewardDatum.num_normal > 0)
			{
				rewardDatum.state_normal = 1;
				hasUnclaimedBonus = true;
			}
			else
			{
				rewardDatum.state_normal = 0;
			}
			if (CheckInProgress(progress2, level))
			{
				rewardDatum.state_advanced1 = 2;
				rewardDatum.state_advanced2 = 2;
			}
			else if (Math.Round(LevelToShow) >= (double)level && rewardDatum.num_advanced1 > 0)
			{
				rewardDatum.state_advanced1 = 1;
				rewardDatum.state_advanced2 = 1;
				hasUnclaimedBonus = true;
			}
			else
			{
				rewardDatum.state_advanced1 = 0;
				rewardDatum.state_advanced2 = 0;
			}
		}
	}

	private void UpdateNextBigReward(bool isForcedRefresh = false)
	{
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		if (((GObject)this).isDisposed)
		{
			return;
		}
		foreach (SpecialSlot item in SpecialReward)
		{
			if (!((float)item.TargetScrollX > ((GComponent)RewardList).scrollPane.posX))
			{
				continue;
			}
			SlotData data = item.Data;
			int num = ((data.num_advanced2 > 0) ? 1 : 0);
			if (num == 1 && IsAdvancedMode && data.level > CurLevel)
			{
				num = 2;
			}
			NextBigSlot.AdvanceNum.selectedIndex = num;
			if (LastBigRewardLevel != data.level || isForcedRefresh)
			{
				LastBigRewardLevel = data.level;
				((GObject)NextBigSlot).visible = true;
				NextBigSlot.Switch.Play();
				SetSmallSFXMask();
				((GObject)NextBigSlot.TargetLevel).text = data.level.ToString();
				NextBigSlot.Normal.Icon.url = data.icon_normal;
				NextBigSlot.Advanced1.Icon.url = data.icon_advanced1;
				NextBigSlot.Advanced2.Icon.url = data.icon_advanced2;
				((GObject)NextBigSlot.Normal.Num).text = data.num_normal.ToString();
				((GObject)NextBigSlot.Advanced1.Num).text = data.num_advanced1.ToString();
				((GObject)NextBigSlot.Advanced2.Num).text = data.num_advanced2.ToString();
				NextBigSlot.Normal.State.selectedIndex = data.state_normal;
				NextBigSlot.Advanced1.State.selectedIndex = data.state_advanced1;
				NextBigSlot.Advanced2.State.selectedIndex = data.state_advanced2;
				((GObject)NextBigSlot.Normal).onClick.Set((EventCallback0)delegate
				{
					FGUIManager.Instance.ItemTip(data.id_normal, ((GObject)this).sortingOrder, noCheckBtn: true);
				});
				((GObject)NextBigSlot.Advanced1).onClick.Set((EventCallback0)delegate
				{
					FGUIManager.Instance.ItemTip(data.id_advanced1, ((GObject)this).sortingOrder, noCheckBtn: true);
				});
				((GObject)NextBigSlot.Advanced2).onClick.Set((EventCallback0)delegate
				{
					FGUIManager.Instance.ItemTip(data.id_advanced2, ((GObject)this).sortingOrder, noCheckBtn: true);
				});
				((GObject)NextBigSlot.SlotBuyBtn).onClick.Set((EventCallback0)delegate
				{
					OpenBuyPanel(1, data.level);
				});
			}
			UpdateNormalSlotSFX((GComponent)(object)NextBigSlot.Normal, IsInMask: false);
			UpdateAdvancedSlotSFX((GComponent)(object)NextBigSlot.Advanced1, IsInMask: false);
			UpdateAdvancedSlotSFX((GComponent)(object)NextBigSlot.Advanced2, IsInMask: false);
			NextBigSlot.LevelState.selectedIndex = (((double)data.level <= Math.Round(LevelToShow)) ? 1 : 0);
			return;
		}
		LastBigRewardLevel = -1;
		((GObject)NextBigSlot).visible = false;
		SetBigSFXMask();
	}

	private void OnBonusListScroll()
	{
		((GComponent)ProgressWrapper).scrollPane.posX = ((GComponent)RewardList).scrollPane.posX;
		if (!IsUpdatingRewardList)
		{
			UpdateNextBigReward();
		}
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (AdvancedPayload != null && itemId == AdvancedPayload.PaidCert)
		{
			IsAdvancedMode = GameManagers.Instance.StockController.GetStock(AdvancedPayload.PaidCert) > 0;
		}
		else if (NormalPayload != null && itemId == NormalPayload.ScoreItem)
		{
			CurLevel = GameManagers.Instance.StockController.GetStock(NormalPayload.ScoreItem);
		}
		if (itemId == "Gem")
		{
			UpdateGemstone();
		}
		if (itemId == "MTG")
		{
			UpdateMTG();
		}
	}

	public void UpdateGemstone()
	{
		int stock = GameManagers.Instance.StockController.GetStock("Gem");
		((GObject)addDiamondBtn.GetChild("num").asTextField).text = stock.ToString();
		int num = ((addDiamondBtn.GetChild("num").data != null) ? ((int)addDiamondBtn.GetChild("num").data) : stock);
		if (num != stock && stock > num)
		{
			int num2 = stock - num;
			if (NumFloatingGem == null)
			{
				NumFloatingGem = UI_ProductionNumFloating.CreateInstance_ILRuntime();
			}
			if (!((GObject)NumFloatingGem).onStage)
			{
				FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloatingGem, addDiamondBtn, stock - num);
			}
			else
			{
				((GObject)NumFloatingGem.Title).text = $"+{(int)((GObject)NumFloatingGem.Title).data + num2}";
				((GObject)NumFloatingGem.Title).data = (int)((GObject)NumFloatingGem.Title).data + num2;
			}
		}
		addDiamondBtn.GetChild("num").data = stock;
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

	private void OnClickNormalSlot(UI_LevelSlot levelSlot, int index)
	{
		SlotData slotData = RewardData[index];
		if (levelSlot.Normal.State.selectedIndex == 1)
		{
			ClaimReward(NormalActivity, slotData.level.ToString());
		}
		else
		{
			FGUIManager.Instance.ItemTip(slotData.id_normal, ((GObject)this).sortingOrder, noCheckBtn: true);
		}
	}

	private void OnClickAdvancedSlot(UI_RewardSlot2 slot, int index)
	{
		SlotData slotData = RewardData[index];
		if (IsAdvancedMode)
		{
			if (slot.State.selectedIndex == 1)
			{
				ClaimReward(AdvancedActivity, slotData.level.ToString());
				return;
			}
			string itemId = ((((GObject)slot).name == "Advanced1") ? slotData.id_advanced1 : slotData.id_advanced2);
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		}
		else
		{
			OpenBuyPanel(0);
		}
	}

	private void OnOneClickClaim()
	{
		if (hasUnclaimedBonus)
		{
			ClaimReward(NormalActivity, "");
			ClaimReward(AdvancedActivity, "");
		}
		if (CurLevel >= LastLevelNum)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText638") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
	}

	private void ClaimReward(Activity activity, string level)
	{
		ILRequestHelper<BattlePassActivityClaimResponse>.Request((EventContext)null, (Func<Task<BattlePassActivityClaimResponse>>)(() => Contexts.sharedInstance.Service<INetworkService>().BattlePassActivityClaim(activity.ActivityId, level)), (Action<BattlePassActivityClaimResponse>)delegate(BattlePassActivityClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				foreach (Bonus bonus in response.BonusList)
				{
					bonus.Claim(GameManagers.Instance);
				}
				Dictionary<string, float> claimed = new Dictionary<string, float>();
				activity.ClaimBonus(GameManagers.Instance, ref claimed, level);
				UpdateRewardList(isAutoScrollToHead: false);
				UpdateNextBigReward(isForcedRefresh: true);
				_IsNoteDirty = true;
			}
		});
	}

	private void OnClickDiamondBtn()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerAddCredit.Name, new Dictionary<string, object>
		{
			{
				"Activity",
				FGUIManager.Instance.GetBlackMarketerActivity(UI_BlackMarketerAddCredit.Name)
			},
			{
				"Order",
				((GObject)this).sortingOrder
			}
		});
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
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_WarOrderBuyPanel.Name, new Dictionary<string, object>
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
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_WarOrderMissionPanel.Name, new Dictionary<string, object> { { "Parent", this } });
		}
	}

	private async void OnClickHelpBtn()
	{
		UiHelper.OpenHelpPage("游戏帮助界面", "玩法", "魔王战令详解");
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
		Mask.transform.localPosition = new Vector3(707f, -318f, 0f);
	}

	private void SetBuildingName()
	{
		((GObject)Title.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText426") ?? "";
	}

	public void End()
	{
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
			SpawnManager.Instance.Destroy(item);
		}
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
	}

	public void BeforeDestroy()
	{
	}
}
