using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI.MainCity.ActivityUi;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.AddCredit;
using UI.GameActivity;
using UI.MtgGiftPacks;
using UnityEngine;

namespace UI.WeekActivityPass;

public class UI_main_WeekActivityPass : GComponent
{
	public GImage n142;

	public GList RewardList;

	public UI_com_LevelSlot_Big NextBigSlot;

	public UI_dec_Scroll n144;

	public GImage n143;

	public GGraph n163;

	public GTextField n152;

	public GTextField n117;

	public GLoader CurLevelIcon;

	public GTextField CurLevelText;

	public GGroup n161;

	public UI_btn_QuickGet QuickGetBtn;

	public UI_btn_DailyMissions DailyMissionBtn;

	public UI_btn_OneClickClaim OneClickClaimBtn;

	public GTextField activityTime;

	public const string URL = "ui://11dkggb8nk8f2z";

	public static string Name = "UI_main_WeekActivityPass";

	private int LastBigRewardLevel = 0;

	private int _curLevel = 0;

	private int SlotWidth = 0;

	private int ListWidth = 0;

	public bool AdvanceActivated;

	public bool PremiumActivated;

	public List<SlotData> RewardData = new List<SlotData>();

	public List<SlotData> SpecialReward = new List<SlotData>();

	public GameObject Mask = null;

	public Activity NormalActivity = null;

	public BattlePassActivityPayload NormalPayload = null;

	public Activity AdvancedActivity = null;

	public BattlePassActivityPayload AdvancedPayload = null;

	public Activity PremiumActivity = null;

	public BattlePassActivityPayload PremiumPayload = null;

	private UI_ActivityPanel _parent;

	public int CurLevel
	{
		get
		{
			return _curLevel;
		}
		set
		{
			_curLevel = value;
			((GObject)CurLevelText).text = value.ToString();
			UpdateRewardList();
		}
	}

	public static string GetURL()
	{
		return "ui://11dkggb8nk8f2z";
	}

	public static UI_main_WeekActivityPass CreateInstance()
	{
		return (UI_main_WeekActivityPass)(object)UIPackage.CreateObject("WeekActivityPass", "main_WeekActivityPass");
	}

	public static UI_main_WeekActivityPass CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_WeekActivityPass).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8nk8f2z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n142 = (GImage)((GComponent)this).GetChild("n142");
		RewardList = (GList)((GComponent)this).GetChild("RewardList");
		NextBigSlot = (UI_com_LevelSlot_Big)(object)((GComponent)this).GetChild("NextBigSlot");
		n144 = (UI_dec_Scroll)(object)((GComponent)this).GetChild("n144");
		n143 = (GImage)((GComponent)this).GetChild("n143");
		n163 = (GGraph)((GComponent)this).GetChild("n163");
		n152 = (GTextField)((GComponent)this).GetChild("n152");
		string id = "ui://11dkggb8nk8f2z".Replace("ui://", "") + "-" + ((GObject)n152).id;
		((GObject)n152).text = LanguagesManager.GetDesc(id);
		n117 = (GTextField)((GComponent)this).GetChild("n117");
		string id2 = "ui://11dkggb8nk8f2z".Replace("ui://", "") + "-" + ((GObject)n117).id;
		((GObject)n117).text = LanguagesManager.GetDesc(id2);
		CurLevelIcon = (GLoader)((GComponent)this).GetChild("CurLevelIcon");
		CurLevelText = (GTextField)((GComponent)this).GetChild("CurLevelText");
		n161 = (GGroup)((GComponent)this).GetChild("n161");
		QuickGetBtn = (UI_btn_QuickGet)(object)((GComponent)this).GetChild("QuickGetBtn");
		DailyMissionBtn = (UI_btn_DailyMissions)(object)((GComponent)this).GetChild("DailyMissionBtn");
		OneClickClaimBtn = (UI_btn_OneClickClaim)(object)((GComponent)this).GetChild("OneClickClaimBtn");
		activityTime = (GTextField)((GComponent)this).GetChild("activityTime");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		((GComponent)RewardList).scrollPane.onScroll.Add(new EventCallback0(OnBonusListScroll));
		((GObject)QuickGetBtn).onClick.Set(new EventCallback0(OnClickQuickGetAll));
		((GObject)OneClickClaimBtn).onClick.Set(new EventCallback0(OnOneClickClaim));
		((GObject)DailyMissionBtn).onClick.Set(new EventCallback0(OpenMissionPanel));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void UnregisterUiEventListeners()
	{
		((GComponent)RewardList).scrollPane.onScroll.Clear();
		((GObject)QuickGetBtn).onClick.Clear();
		((GObject)OneClickClaimBtn).onClick.Clear();
		((GObject)DailyMissionBtn).onClick.Clear();
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void Init(UI_ActivityPanel parentPanel)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		CacheManager.Instance.Get<Cache_WeekActPassScore>().IsSyncProduce = true;
		UI_com_LevelSlot uI_com_LevelSlot = UI_com_LevelSlot.CreateInstance();
		SlotWidth = ((GObject)uI_com_LevelSlot).initWidth;
		ListWidth = (int)((GObject)RewardList).width;
		((GObject)uI_com_LevelSlot).Dispose();
		((GComponent)this).EnsureBoundsCorrect();
		_parent = parentPanel;
		((GObject)QuickGetBtn).visible = false;
		((GObject)OneClickClaimBtn).visible = false;
		RewardList.SetVirtual();
		RewardList.itemRenderer = new ListItemRenderer(ItemRenderer);
		RewardList.numItems = 0;
		((GObject)NextBigSlot).visible = false;
		List<Activity> activitiesByType = GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.WeekActPass, null, isSort: false);
		foreach (Activity item in activitiesByType)
		{
			if (item.GetStatus(GameManagers.Instance) == ActivityStatus.Enabled)
			{
				Dictionary<string, ActivityContentPayload>.Enumerator enumerator2 = item.ContentPayload(GameManagers.Instance).GetEnumerator();
				enumerator2.MoveNext();
				BattlePassActivityPayload battlePassActivityPayload = (BattlePassActivityPayload)enumerator2.Current.Value;
				if (string.IsNullOrEmpty(battlePassActivityPayload.PaidCert))
				{
					NormalActivity = item;
					NormalPayload = battlePassActivityPayload;
				}
				else if (battlePassActivityPayload.PaidCert == "WeeklyMoon_BattlePass_AdvancedCert")
				{
					AdvancedActivity = item;
					AdvancedPayload = battlePassActivityPayload;
				}
				else if (battlePassActivityPayload.PaidCert == "WeeklyMoon_BattlePass_PremiumCert")
				{
					PremiumActivity = item;
					PremiumPayload = battlePassActivityPayload;
				}
			}
		}
		OnActivityLoaded();
		foreach (int key in PremiumPayload.BonusConfig.Keys)
		{
			SlotData slotData = new SlotData
			{
				Level = key
			};
			NormalPayload.BonusConfig.TryGetValue(key, out var value);
			AdvancedPayload.BonusConfig.TryGetValue(key, out var value2);
			PremiumPayload.BonusConfig.TryGetValue(key, out var value3);
			if (value != null && value.Count > 0)
			{
				KeyValuePair<string, int> keyValuePair = value.First();
				slotData.icon_basic = GetIconByItemId(keyValuePair.Key);
				slotData.num_basic = keyValuePair.Value;
				slotData.id_basic = keyValuePair.Key;
			}
			if (value2 != null && value2.Count > 0)
			{
				KeyValuePair<string, int> keyValuePair2 = value2.First();
				slotData.icon_advanced = GetIconByItemId(keyValuePair2.Key);
				slotData.num_advanced = keyValuePair2.Value;
				slotData.id_advanced = keyValuePair2.Key;
			}
			if (value3 != null && value3.Count > 0)
			{
				KeyValuePair<string, int> keyValuePair3 = value3.First();
				slotData.icon_premium = GetIconByItemId(keyValuePair3.Key);
				slotData.num_premium = keyValuePair3.Value;
				slotData.id_premium = keyValuePair3.Key;
			}
			slotData.Index = RewardData.Count;
			slotData.TargetScrollX = CalculateSlotEmergingScrollX(slotData.Index);
			RewardData.Add(slotData);
			if (PremiumPayload.SpecialNodes.Contains(key))
			{
				SpecialReward.Add(slotData);
				slotData.IsSpecialNode = true;
			}
		}
		GetRewardState();
		RefreshRewardList();
		RewardList.ScrollToView(CurrentContributionSlotIndex());
	}

	private void OnActivityLoaded()
	{
		CurLevel = GameManagers.Instance.StockController.GetStock(NormalPayload.ScoreItem);
		AdvanceActivated = GameManagers.Instance.StockController.GetStock(AdvancedPayload.PaidCert) > 0;
		PremiumActivated = GameManagers.Instance.StockController.GetStock(PremiumPayload.PaidCert) > 0;
		CurLevelIcon.url = GetIconByItemId(NormalPayload.ScoreItem);
		((GObject)QuickGetBtn).visible = true;
		((GObject)OneClickClaimBtn).visible = true;
		ActivityConfig activityConfig = NormalActivity.ActivityProgress(GameManagers.Instance);
		DateTimeOffset dateTimeOffset = activityConfig.BeginAt.ToOffset(DateTimeHelper.TimezoneOffset);
		DateTimeOffset dateTimeOffset2 = activityConfig.EndAt.ToOffset(DateTimeHelper.TimezoneOffset);
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(RefreshTimeCountDown(dateTimeOffset2.ToUnixTimeSeconds()));
			return;
		}
		string dateStringYYMMdd = UiHelper.GetDateStringYYMMdd(dateTimeOffset.DateTime);
		string dateStringYYMMdd2 = UiHelper.GetDateStringYYMMdd(dateTimeOffset2.DateTime);
		((GObject)activityTime).text = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("WeekActivityPassDuration".ToLanguage(), dateStringYYMMdd, dateStringYYMMdd2);
	}

	private IEnumerator RefreshTimeCountDown(long endTime)
	{
		WaitForSeconds wait = new WaitForSeconds(1f);
		while (!((GObject)this).isDisposed)
		{
			long remainTime = endTime - GameController.Instance.GetServerTime();
			string remainTimeStr = UiHelper.ParseTimeSpanUniversal((int)remainTime);
			((GObject)activityTime).text = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format("WeekActivityPassTimeTip".ToLanguage(), remainTimeStr);
			yield return wait;
		}
	}

	public void RefreshRewardList()
	{
		RewardList.numItems = RewardData.Count;
	}

	private static string GetIconByItemId(string itemId)
	{
		return UiHelper.GetItemIconPath(itemId);
	}

	private int CalculateSlotEmergingScrollX(int slotIndex)
	{
		int num = 30;
		int num2 = ListWidth - SlotWidth + num;
		return SlotWidth * (slotIndex + 1) - num2;
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (NormalPayload != null && itemId == NormalPayload.ScoreItem)
		{
			CurLevel = GameManagers.Instance.StockController.GetStock(NormalPayload.ScoreItem);
			_parent.UpdateWeekActPassTabs();
		}
	}

	private void ItemRenderer(int index, GObject obj)
	{
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected O, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		if (((GObject)this).isDisposed)
		{
			return;
		}
		UI_com_LevelSlot uI_com_LevelSlot = (UI_com_LevelSlot)(object)obj;
		if (index >= RewardData.Count)
		{
			((GObject)uI_com_LevelSlot.TargetLevel).text = "--";
			uI_com_LevelSlot.IsSpecialNode.SetSelectedIndex(0);
			((GObject)uI_com_LevelSlot.Basic).visible = false;
			((GObject)uI_com_LevelSlot.Advanced).visible = false;
			((GObject)uI_com_LevelSlot.Premium).visible = false;
			return;
		}
		SlotData slotData = RewardData[index];
		((GObject)uI_com_LevelSlot.TargetLevel).text = slotData.Level.ToString();
		uI_com_LevelSlot.Basic.Icon.url = slotData.icon_basic;
		uI_com_LevelSlot.Advanced.Icon.url = slotData.icon_advanced;
		uI_com_LevelSlot.Premium.Icon.url = slotData.icon_premium;
		uI_com_LevelSlot.Basic.State.selectedIndex = (int)slotData.state_basic;
		uI_com_LevelSlot.Advanced.State.selectedIndex = (int)slotData.state_advanced;
		uI_com_LevelSlot.Premium.State.selectedIndex = (int)slotData.state_premium;
		((GObject)uI_com_LevelSlot.Basic.Num).text = slotData.num_basic.ToString();
		((GObject)uI_com_LevelSlot.Advanced.Num).text = slotData.num_advanced.ToString();
		((GObject)uI_com_LevelSlot.Premium.Num).text = slotData.num_premium.ToString();
		((GObject)uI_com_LevelSlot.Basic).onClick.Set((EventCallback0)delegate
		{
			OnClickNormalSlot(index);
		});
		((GObject)uI_com_LevelSlot.Advanced).onClick.Set((EventCallback0)delegate
		{
			OnClickAdvancedSlot(index);
		});
		((GObject)uI_com_LevelSlot.Premium).onClick.Set((EventCallback0)delegate
		{
			OnClickPremiumSlot(index);
		});
		uI_com_LevelSlot.Advanced.Lock.SetSelectedIndex((!AdvanceActivated) ? 1 : 0);
		uI_com_LevelSlot.Premium.Lock.SetSelectedIndex((!PremiumActivated) ? 1 : 0);
		((GObject)uI_com_LevelSlot.Basic).visible = slotData.num_basic > 0;
		((GObject)uI_com_LevelSlot.Advanced).visible = slotData.num_advanced > 0;
		((GObject)uI_com_LevelSlot.Premium).visible = slotData.num_premium > 0;
		uI_com_LevelSlot.IsSpecialNode.SetSelectedIndex(slotData.IsSpecialNode ? 1 : 0);
		bool flag = CurLevel >= slotData.Level;
		bool flag2 = false;
		if (flag)
		{
			int num = index + 1;
			SlotData slotData2 = ((num >= RewardData.Count) ? null : RewardData[num]);
			if (slotData2 != null && slotData2.Level > CurLevel)
			{
				flag2 = true;
			}
		}
		uI_com_LevelSlot.Progress.SetSelectedIndex((!flag) ? 2 : (flag2 ? 1 : 0));
	}

	public void UpdateRewardList(bool isAutoScrollToHead = true)
	{
		if (!((GObject)this).isDisposed)
		{
			int num = 0;
			if (AdvancedPayload != null && PremiumPayload != null)
			{
				AdvanceActivated = GameManagers.Instance.StockController.GetStock(AdvancedPayload.PaidCert) > 0;
				PremiumActivated = GameManagers.Instance.StockController.GetStock(PremiumPayload.PaidCert) > 0;
			}
			GetRewardState();
			RefreshRewardList();
			UpdateNextBigReward();
			if (isAutoScrollToHead)
			{
				RewardList.ScrollToView(CurrentContributionSlotIndex());
			}
		}
	}

	private int CurrentContributionSlotIndex()
	{
		int num = RewardData.FindIndex((SlotData reward) => reward.Level > CurLevel);
		if (num < 0)
		{
			num = RewardData.Count - 1;
		}
		return Mathf.Max(num - 5, 0);
	}

	private static bool CheckInProgress(List<float> progress, int level)
	{
		foreach (float item in progress)
		{
			if (Math.Abs(Math.Round(item) - (double)level) < 0.10000000149011612)
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
		List<float> progress3 = PremiumActivity.ClaimProgress(GameManagers.Instance);
		foreach (SlotData rewardDatum in RewardData)
		{
			int level = rewardDatum.Level;
			if (CheckInProgress(progress, level))
			{
				rewardDatum.state_basic = BonusStatus.CLAIMED;
			}
			else if (CurLevel >= level && rewardDatum.num_basic > 0)
			{
				rewardDatum.state_basic = BonusStatus.CLAIMABLE;
			}
			else
			{
				rewardDatum.state_basic = BonusStatus.INACTIVE;
			}
			if (CheckInProgress(progress2, level))
			{
				rewardDatum.state_advanced = BonusStatus.CLAIMED;
			}
			else if (CurLevel >= level && rewardDatum.num_advanced > 0 && AdvanceActivated)
			{
				rewardDatum.state_advanced = BonusStatus.CLAIMABLE;
			}
			else
			{
				rewardDatum.state_advanced = BonusStatus.INACTIVE;
			}
			if (CheckInProgress(progress3, level))
			{
				rewardDatum.state_premium = BonusStatus.CLAIMED;
			}
			else if (CurLevel >= level && rewardDatum.num_premium > 0 && PremiumActivated)
			{
				rewardDatum.state_premium = BonusStatus.CLAIMABLE;
			}
			else
			{
				rewardDatum.state_premium = BonusStatus.INACTIVE;
			}
		}
	}

	private void UpdateNextBigReward(bool isForcedRefresh = false)
	{
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected O, but got Unknown
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		if (((GObject)this).isDisposed || ((GComponent)RewardList).numChildren <= 0)
		{
			return;
		}
		int index = RewardList.ChildIndexToItemIndex(((GComponent)RewardList).numChildren - 3);
		int targetScrollX = RewardData[index].TargetScrollX;
		foreach (SlotData item in SpecialReward)
		{
			if (item.TargetScrollX <= targetScrollX)
			{
				continue;
			}
			SlotData slotData = item;
			if (LastBigRewardLevel != slotData.Level || isForcedRefresh)
			{
				LastBigRewardLevel = slotData.Level;
				((GObject)NextBigSlot).visible = true;
				NextBigSlot.Switch.Play();
				((GObject)NextBigSlot.TargetLevel).text = slotData.Level.ToString();
				NextBigSlot.Basic.Icon.url = slotData.icon_basic;
				NextBigSlot.Advanced.Icon.url = slotData.icon_advanced;
				NextBigSlot.Premium.Icon.url = slotData.icon_premium;
				((GObject)NextBigSlot.Basic.Num).text = slotData.num_basic.ToString();
				((GObject)NextBigSlot.Advanced.Num).text = slotData.num_advanced.ToString();
				((GObject)NextBigSlot.Premium.Num).text = slotData.num_premium.ToString();
				NextBigSlot.Basic.State.selectedIndex = (int)slotData.state_basic;
				NextBigSlot.Advanced.State.selectedIndex = (int)slotData.state_advanced;
				NextBigSlot.Premium.State.selectedIndex = (int)slotData.state_premium;
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
				((GObject)NextBigSlot.Basic).visible = slotData.num_basic > 0;
				((GObject)NextBigSlot.Advanced).visible = slotData.num_advanced > 0;
				((GObject)NextBigSlot.Premium).visible = slotData.num_premium > 0;
			}
			NextBigSlot.Advanced.Lock.SetSelectedIndex((!AdvanceActivated) ? 1 : 0);
			NextBigSlot.Premium.Lock.SetSelectedIndex((!PremiumActivated) ? 1 : 0);
			return;
		}
		LastBigRewardLevel = -1;
		((GObject)NextBigSlot).visible = false;
	}

	private void OnBonusListScroll()
	{
		UpdateNextBigReward();
	}

	private void OnClickNormalSlot(int index)
	{
		SlotData slotData = RewardData[index];
		if (slotData.state_basic == BonusStatus.CLAIMABLE)
		{
			OnClickClaimBonus(NormalActivity, slotData.Level);
		}
		else
		{
			FGUIManager.Instance.ItemTip(slotData.id_basic, ((GObject)this).sortingOrder, noCheckBtn: true);
		}
	}

	private void OnClickAdvancedSlot(int index)
	{
		if (AdvanceActivated)
		{
			SlotData slotData = RewardData[index];
			if (slotData.state_advanced == BonusStatus.CLAIMABLE)
			{
				OnClickClaimBonus(AdvancedActivity, slotData.Level);
			}
			else
			{
				FGUIManager.Instance.ItemTip(slotData.id_advanced, ((GObject)this).sortingOrder, noCheckBtn: true);
			}
		}
		else
		{
			OpenBuyPanel(UI_main_BuyWeekActPass.PageMode.WeekActPass);
		}
	}

	private void OnClickPremiumSlot(int index)
	{
		if (PremiumActivated)
		{
			SlotData slotData = RewardData[index];
			if (slotData.state_premium == BonusStatus.CLAIMABLE)
			{
				OnClickClaimBonus(PremiumActivity, slotData.Level);
			}
			else
			{
				FGUIManager.Instance.ItemTip(slotData.id_premium, ((GObject)this).sortingOrder, noCheckBtn: true);
			}
		}
		else
		{
			OpenBuyPanel(UI_main_BuyWeekActPass.PageMode.WeekActPass);
		}
	}

	private void OnOneClickClaim()
	{
		if (!ActivityEntranceRedDotController.HasUnclaimedWeekActPassReward())
		{
			"WeekActivityPassNoReward".ToLanguage().ToTip();
		}
		else
		{
			OnClickClaimBonus(NormalActivity, -1);
			if (AdvanceActivated)
			{
				OnClickClaimBonus(AdvancedActivity, -1);
			}
			if (PremiumActivated)
			{
				OnClickClaimBonus(PremiumActivity, -1);
			}
		}
		if (!AdvanceActivated || !PremiumActivated)
		{
			OpenBuyPanel(UI_main_BuyWeekActPass.PageMode.WeekActPass);
		}
	}

	private void OnClickQuickGetAll()
	{
		OpenBuyPanel(UI_main_BuyWeekActPass.PageMode.Progress);
	}

	private async void OnClickClaimBonus(Activity act, int node)
	{
		MoonBattlePassActivityClaimResponse response = await GameController.Contexts.Service<INetworkService>().MoonBattlePassActivityClaim(act.ActivityId, (node < 0) ? null : node.ToString());
		if (response.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			return;
		}
		Dictionary<string, float> claimed = new Dictionary<string, float>();
		act.ClaimBonus(GameManagers.Instance, ref claimed, "", node);
		UpdateRewardList(isAutoScrollToHead: false);
		_parent.UpdateWeekActPassTabs();
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

	private void OpenBuyPanel(UI_main_BuyWeekActPass.PageMode mode, int defaultLevel = -1)
	{
		if (!((GObject)this).isDisposed)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_BuyWeekActPass.Name, new Dictionary<string, object> { 
			{
				"Param",
				new UI_main_BuyWeekActPass.PageParam
				{
					Parent = this,
					MaxLevel = RewardData.Last().Level,
					Mode = mode,
					DefaultLevel = defaultLevel,
					NormalPayload = NormalPayload,
					AdvancedPayload = AdvancedPayload,
					PremiumPayload = PremiumPayload
				}
			} });
		}
	}

	public void OpenMissionPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_DailyMission.Name, new Dictionary<string, object> { 
		{
			"Param",
			new UI_main_DailyMission.ShowParam
			{
				Parent = this
			}
		} });
	}
}
