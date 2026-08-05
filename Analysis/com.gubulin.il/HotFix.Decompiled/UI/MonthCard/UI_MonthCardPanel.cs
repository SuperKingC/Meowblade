using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.AddCredit;
using UI.BlackMarketer;
using UI.GiftBag;
using UI.MainCity;
using UI.PublicResources;
using UI.PvpSelectSoldiers;
using UI.Tips;
using UnityEngine;

namespace UI.MonthCard;

public class UI_MonthCardPanel : GComponent, IUiController
{
	public Controller PageController;

	public GLoader background;

	public GImage n17;

	public GComponent n18;

	public GComponent n19;

	public GComponent n20;

	public GImage n21;

	public GImage n22;

	public GGraph mask;

	public GButton backBtn;

	public UI_Title titleCom;

	public GComponent addCouponBtn;

	public GComponent addDiamondBtn;

	public GComponent addWorkerBtn;

	public GList cardList;

	public GGraph missibleSfxBack;

	public GGraph missbleEndPos;

	public const string URL = "ui://4ctl553savmf0";

	public static string Name = "UI_MonthCardPanel";

	private bool PanelUpdating;

	private List<string> monthCardItemList = new List<string>();

	private List<int> monthCardBonusQtyList = new List<int>();

	private List<string> monthCardBonusIconList = new List<string>();

	private List<string> textureList = new List<string>();

	private List<List<string>> curDisplayContent = new List<List<string>>();

	private Activity storeActivity;

	private List<Shift.Legion.Common.Models.Store.StoreItem> itemList = new List<Shift.Legion.Common.Models.Store.StoreItem>();

	private UI_ProductionNumFloating NumFloating;

	private Coroutine LeaseholdRemainingCoroutine;

	private IUiController parentUiController;

	private int caedIndex;

	public const string MonthCardActivityId = "DungeonContractMerchant";

	public static string GetURL()
	{
		return "ui://4ctl553savmf0";
	}

	public static UI_MonthCardPanel CreateInstance()
	{
		return (UI_MonthCardPanel)(object)UIPackage.CreateObject("MonthCard", "MonthCardPanel");
	}

	public static UI_MonthCardPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MonthCardPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4ctl553savmf0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		background = (GLoader)((GComponent)this).GetChild("background");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GComponent)((GComponent)this).GetChild("n18");
		n19 = (GComponent)((GComponent)this).GetChild("n19");
		n20 = (GComponent)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		titleCom = (UI_Title)(object)((GComponent)this).GetChild("titleCom");
		addCouponBtn = (GComponent)((GComponent)this).GetChild("addCouponBtn");
		addDiamondBtn = (GComponent)((GComponent)this).GetChild("addDiamondBtn");
		addWorkerBtn = (GComponent)((GComponent)this).GetChild("addWorkerBtn");
		cardList = (GList)((GComponent)this).GetChild("cardList");
		missibleSfxBack = (GGraph)((GComponent)this).GetChild("missibleSfxBack");
		missbleEndPos = (GGraph)((GComponent)this).GetChild("missbleEndPos");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		addDiamondBtn.GetChild("addButton").onClick.Add(new EventCallback0(DiamondBtnEvent));
		addCouponBtn.GetChild("addButton").onClick.Add(new EventCallback0(MoneyBtnEvent));
		((GObject)addWorkerBtn).onClick.Add(new EventCallback0(OpenWorkerOverview));
		addWorkerBtn.GetChild("addButton").onClick.Add(new EventCallback1(WorkerBtnEvent));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)mask).onClick.Add(new EventCallback0(End));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
		SharedMessenger.AddListener("OPEN_WORKER_OVERVIEW_PANEL", OpenWorkerOverview);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		addDiamondBtn.GetChild("addButton").onClick.Remove(new EventCallback0(DiamondBtnEvent));
		addCouponBtn.GetChild("addButton").onClick.Remove(new EventCallback0(MoneyBtnEvent));
		((GObject)addWorkerBtn).onClick.Remove(new EventCallback0(OpenWorkerOverview));
		addWorkerBtn.GetChild("addButton").onClick.Remove(new EventCallback1(WorkerBtnEvent));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)mask).onClick.Remove(new EventCallback0(End));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
		SharedMessenger.RemoveListener("OPEN_WORKER_OVERVIEW_PANEL", OpenWorkerOverview);
	}

	public void BeforeDestroy()
	{
		if (LeaseholdRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(LeaseholdRemainingCoroutine);
		}
	}

	public void Destroy()
	{
		if (parentUiController != null && parentUiController is UI_MainCity)
		{
			UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
		}
	}

	public void Init(Dictionary<string, object> parameters)
	{
		if (parameters != null)
		{
			if (parameters.TryGetValue("Activity", out var value))
			{
				storeActivity = (Activity)value;
			}
			if (parameters.TryGetValue("Status", out var value2))
			{
				PageController.selectedIndex = (int)value2;
			}
			if (parameters.TryGetValue("Parent", out var value3))
			{
				parentUiController = (IUiController)value3;
			}
		}
		if (storeActivity == null)
		{
			End();
		}
		List<string> activityIds = new List<string> { storeActivity.ActivityId };
		if (storeActivity.ActivityProgress(GameManagers.Instance).IsNew)
		{
			GameManagers.Instance.ActivityManager.ReviewActivities(activityIds);
		}
		FGUIManager.Instance.IsShowMonthCardFirst = false;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("Order", out var value4))
		{
			((GObject)this).sortingOrder = (int)value4;
		}
		else
		{
			((GObject)this).sortingOrder = 1;
		}
		SetBuildingName();
		UpdateManPower();
		UpdatePanel();
	}

	public void OnShow()
	{
		if (LeaseholdRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(LeaseholdRemainingCoroutine);
		}
		if (storeActivity != null)
		{
			foreach (KeyValuePair<string, ActivityContentPayload> item in storeActivity.ContentPayload(GameManagers.Instance))
			{
				GameManagers.Instance.NewMsgIncomingManager.CheckActivityContent(storeActivity.ActivityId, item.Key);
			}
		}
		if (PageController.selectedIndex == 1)
		{
			TryBringToFont();
		}
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
		LeaseholdRemainingCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshLeaseholdRemaining());
	}

	public void UpdateManPower()
	{
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		Dungeon value = GameController.Contexts.game.dungeon.value;
		addWorkerBtn.GetChild("CurrentWorkerAmount").text = Dungeon.GetFreeManPower(GameManagers.Instance).ToString();
		addWorkerBtn.GetChild("AllWorkerAmount").text = Dungeon.GetTotalManPower(GameManagers.Instance).ToString();
		if (GameManagers.Instance.LeaseholdManager.GetLeaseholdManPower() > 0)
		{
			addWorkerBtn.GetChild("AllWorkerAmount").asTextField.color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue));
			addWorkerBtn.GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText153") + Environment.NewLine + string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText164"), Dungeon.GetTotalManPower(GameManagers.Instance) - GameManagers.Instance.LeaseholdManager.GetLeaseholdManPower())
				},
				{
					"Pos",
					(object)new Vector2(1718f, 88f)
				}
			};
			addWorkerBtn.GetChild("ExclamationMarkBtn").visible = true;
		}
		else
		{
			addWorkerBtn.GetChild("AllWorkerAmount").asTextField.color = Color32.op_Implicit(new Color32((byte)243, (byte)221, (byte)170, byte.MaxValue));
			addWorkerBtn.GetChild("ExclamationMarkBtn").visible = false;
		}
	}

	public async void UpdatePanel()
	{
		if (!PanelUpdating)
		{
			PanelUpdating = true;
			await GetCardData();
			RenderCardList();
			for (int i = 0; i < itemList.Count; i++)
			{
				ThinkingDataHelper.Instance.PayPreviewTrack(itemList[i].StoreItemId);
			}
			if (itemList.Count > 0)
			{
				ThinkingDataHelper.Instance.TimeEvent("nopay_preview");
			}
			PanelUpdating = false;
		}
	}

	private void RenderCardList()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		if (!((GObject)this).isDisposed && !((GObject)cardList).isDisposed)
		{
			cardList.itemRenderer = new ListItemRenderer(UpdateMonthCard);
			cardList.numItems = itemList.Count;
		}
	}

	public void UpdateMonthCard(int index, GObject obj)
	{
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0789: Unknown result type (might be due to invalid IL or missing references)
		//IL_0793: Expected O, but got Unknown
		//IL_07b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ba: Expected O, but got Unknown
		//IL_07d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e1: Expected O, but got Unknown
		//IL_0821: Unknown result type (might be due to invalid IL or missing references)
		//IL_082b: Expected O, but got Unknown
		//IL_0595: Unknown result type (might be due to invalid IL or missing references)
		UI_ContractCard uI_ContractCard = (UI_ContractCard)(object)obj;
		Shift.Legion.Common.Models.Store.StoreItem storeItem = (Shift.Legion.Common.Models.Store.StoreItem)(((GObject)uI_ContractCard).data = itemList[index]);
		string itemId = storeItem.Content.Keys.First();
		bool isAdvanceCard = false;
		bool flag = false;
		if (storeItem.Name == LanguagesManager.GetDesc("CsharpCodeZhTcText434"))
		{
			((GComponent)uI_ContractCard).GetController("RarityController").selectedIndex = 1;
			flag = GameManagers.Instance.UserArchiveManager.IsLevelCompleted("P1130");
			isAdvanceCard = true;
		}
		else if (storeItem.Name == LanguagesManager.GetDesc("CsharpCodeZhTcText435"))
		{
			((GComponent)uI_ContractCard).GetController("RarityController").selectedIndex = 0;
			flag = UI_PvpSelectSoldiersPanel.IsPassed830();
		}
		if (!Define.IsClickAssistantOpen())
		{
			flag = false;
		}
		uI_ContractCard.showAssistantBtn.SetSelectedIndex(flag ? 1 : 0);
		((GComponent)uI_ContractCard).GetChild("primaryBenefitTitle").text = storeItem.Desc ?? "";
		((GComponent)uI_ContractCard).GetChild("primaryBenefitNum").text = "";
		((GComponent)uI_ContractCard).GetChild("primaryBenefitIcon").asLoader.url = "ui://PublicResources/" + storeItem.Icon;
		curDisplayContent = storeItem.DisplayContent;
		((GObject)((GComponent)uI_ContractCard).GetChild("SecondaryRewardList").asList).touchable = false;
		RenderSecondaryRewardList(((GComponent)uI_ContractCard).GetChild("SecondaryRewardList").asList, curDisplayContent.Count, ((GComponent)uI_ContractCard).GetController("RarityController").selectedIndex);
		Controller controller = ((GComponent)uI_ContractCard).GetController("StatusController");
		FGUIManager.Instance.AddTextSpecialEffects(uI_ContractCard.ConfirmTakeBtn.effPos1, "ui_stroke_button_4", Vector3.one * 100f);
		FGUIManager.Instance.AddTextSpecialEffects(uI_ContractCard.ConfirmTakeBtn.effPos2, "ui_stroke_button_5", Vector3.one * 100f);
		int leaseholdItemRemainingTime = GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime(itemId);
		if (leaseholdItemRemainingTime <= 0)
		{
			controller.selectedIndex = 0;
			List<Modifier> list = Item.Effect(GameManagers.Instance, itemId);
			foreach (Modifier item in list)
			{
				if (item.ModifierId == "Bonus")
				{
					string itemId2 = item.PayloadDictionary.Keys.First();
					int num = int.Parse(item.PayloadDictionary.Values.First().ToString());
					string icon = UiHelper.GetIcon(itemId2);
					((GObject)uI_ContractCard.ConfirmTakeBtn.specialRewardNum).text = $"+{num}";
					uI_ContractCard.ConfirmTakeBtn.specialRewardIcon.url = "ui://PublicResources/" + icon;
					break;
				}
			}
		}
		else
		{
			controller.selectedIndex = 1;
			List<Modifier> list2 = Item.Effect(GameManagers.Instance, itemId);
			foreach (Modifier item2 in list2)
			{
				if (item2.ModifierId == "Daily")
				{
					Dictionary<string, object> dictionary = (Dictionary<string, object>)item2.PayloadDictionary["Bonus"];
					string itemId3 = dictionary.Keys.First();
					string icon2 = UiHelper.GetIcon(itemId3);
					((GObject)uI_ContractCard.ConfirmTakeBtn.specialRewardNum).text = "+" + dictionary.Values.First().ToString();
					uI_ContractCard.ConfirmTakeBtn.specialRewardIcon.url = "ui://PublicResources/" + icon2;
				}
			}
			UI_countdownBtn countdownBtn = uI_ContractCard.CountdownBtn;
			if (leaseholdItemRemainingTime <= 259200)
			{
				((GObject)countdownBtn.time2).text = UiHelper.ParseTimeChinsesDH(leaseholdItemRemainingTime) ?? "";
				((GObject)countdownBtn.time1).width = 0f;
				countdownBtn.Status.selectedIndex = 1;
				uI_ContractCard.ContinueBuyBtn.Status.selectedIndex = 1;
				((GObject)countdownBtn.tip3rd).text = LanguagesManager.GetDesc("CsharpCodeZhTcText436");
			}
			else
			{
				((GObject)countdownBtn.time1).text = UiHelper.ParseTimeChinsesDH(leaseholdItemRemainingTime) ?? "";
				((GObject)countdownBtn.time2).width = 0f;
				countdownBtn.Status.selectedIndex = 0;
				uI_ContractCard.ContinueBuyBtn.Status.selectedIndex = 0;
				((GObject)countdownBtn.tip3rd).text = LanguagesManager.GetDesc("CsharpCodeZhTcText437");
			}
			controller.selectedIndex = (GameManagers.Instance.LeaseholdManager.CanClaimDailyBonus(itemId) ? 1 : 2);
			GComponent asCom = ((GComponent)uI_ContractCard).GetChild("EffectiveSfxBack").asCom;
			if (((GObject)cardList).data != null && ((Shift.Legion.Common.Models.Store.StoreItem)((GObject)uI_ContractCard).data).StoreItemId == ((Shift.Legion.Common.Models.Store.StoreItem)((GObject)cardList).data).StoreItemId)
			{
				asCom.GetController("StatusController").selectedIndex = 0;
				FGUIManager.Instance.AddTextSpecialEffects(((GComponent)uI_ContractCard).GetChild("SfxBack").asGraph, "paper_big_explosion_gold", new Vector3(98f, 98f, 98f), "Default", 0.5f, delegate(GameObject paperBigExplosionGold)
				{
					//IL_0016: Unknown result type (might be due to invalid IL or missing references)
					paperBigExplosionGold.transform.localPosition = new Vector3(0f, 0f, -1f);
					UiAudioManager.Instance.PlaySoundEffect("Refresh");
				});
			}
			else
			{
				asCom.GetController("StatusController").selectedIndex = 1;
			}
		}
		uI_ContractCard.SetControllerPageText();
		uI_ContractCard.ConfirmTakeBtn.StatusController.SetSelectedIndex(controller.selectedIndex);
		string key = FGUIManager.Instance.GetPriceItemId(storeItem).Key;
		bool flag2 = key == "RMB";
		ProductLocalInfo value = null;
		if (HotUpdateProcess.Instance.IsRegionOutCN && flag2)
		{
			((GComponent)uI_ContractCard).GetChild("PriceImgs").visible = false;
			((GComponent)uI_ContractCard).GetChild("PriceText").visible = true;
			string text = "--";
			if (!string.IsNullOrEmpty(storeItem.ReferenceId) && PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value))
			{
				text = value.FormattedPrice;
			}
			else
			{
				ILRuntimeDebug.LogError(storeItem.ReferenceId + " Not Found ProductLocalInfo");
			}
			((GComponent)uI_ContractCard).GetChild("PriceText").text = text;
		}
		else
		{
			((GComponent)uI_ContractCard).GetChild("PriceImgs").visible = true;
			((GComponent)uI_ContractCard).GetChild("PriceText").visible = false;
		}
		((GComponent)uI_ContractCard).GetChild("currencyIcon").asLoader.url = "ui://PublicResources/" + key;
		((GObject)cardList).data = null;
		((GObject)((GComponent)uI_ContractCard).GetChild("ConfirmBuyBtn").asButton).data = storeItem;
		((GObject)((GComponent)uI_ContractCard).GetChild("ConfirmTakeBtn").asButton).data = storeItem;
		((GObject)((GComponent)uI_ContractCard).GetChild("ContinueBuyBtn").asButton).data = storeItem;
		((GObject)((GComponent)uI_ContractCard).GetChild("ConfirmBuyBtn").asButton).onClick.Set(new EventCallback1(BuyMonthCard));
		((GObject)((GComponent)uI_ContractCard).GetChild("ConfirmTakeBtn").asButton).onClick.Set(new EventCallback1(TakeItems));
		((GObject)((GComponent)uI_ContractCard).GetChild("ContinueBuyBtn").asButton).onClick.Set(new EventCallback1(BuyMonthCard));
		bool cardIsActivated = controller.selectedIndex > 0;
		uI_ContractCard.PrivilegeBtn.IsActivated.SetSelectedIndex(cardIsActivated ? 1 : 0);
		((GObject)uI_ContractCard.PrivilegeBtn).onClick.Set((EventCallback0)delegate
		{
			string langKey = ((!cardIsActivated) ? (isAdvanceCard ? "MonthCardPrivilegeBtnTip2" : "MonthCardPrivilegeBtnTip1") : (isAdvanceCard ? "MonthCardPrivilegeBtnTip4" : "MonthCardPrivilegeBtnTip3"));
			langKey.ToLanguage().ToTip();
		});
	}

	private void RenderSecondaryRewardList(GList list, int num, int rarityIndex)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		list.itemRenderer = (ListItemRenderer)delegate(int index, GObject obj)
		{
			RenderSecondaryRewardItem(index, obj, rarityIndex);
		};
		list.numItems = num;
	}

	private void RenderSecondaryRewardItem(int index, GObject obj, int rarityIndex)
	{
		GButton asButton = obj.asButton;
		if (index < curDisplayContent.Count)
		{
			List<string> list = curDisplayContent[index];
			((GComponent)asButton).GetChild("title").text = list[0] ?? "";
			((GComponent)asButton).GetChild("Icon").asLoader.url = "ui://PublicResources/" + list[1];
			((GComponent)asButton).GetChild("num").text = list[2] ?? "";
			((GComponent)asButton).GetController("RarityController").selectedIndex = rarityIndex;
		}
	}

	private void PlayMissileSfx()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		((GObject)missibleSfxBack).SetPivot(0.5f, 0.5f, true);
		((GObject)missibleSfxBack).SetXY(960f, 500f);
		FGUIManager.Instance.AddTextSpecialEffects(missibleSfxBack, "exp_missile_green", Vector3.zero);
		((GObject)missibleSfxBack).TweenMove(((GObject)missbleEndPos).xy, 0.5f);
		UiAudioManager.Instance.PlaySoundEffect("Missile");
	}

	public void TryBringToFont()
	{
		if (((GObject)((GObject)this).parent).parent != null && ((GObject)((GObject)this).parent).parent is Window)
		{
			GComponent parent = ((GObject)((GObject)this).parent).parent;
			Window val = (Window)(object)((parent is Window) ? parent : null);
			val.BringToFront();
			((GObject)val).sortingOrder = 3000;
		}
	}

	public void WorkerBtnEvent(EventContext context)
	{
		UpdatePanel();
		context.StopPropagation();
	}

	private void OpenWorkerOverview()
	{
		Dictionary<string, object> parameters = new Dictionary<string, object> { 
		{
			"Order",
			((GObject)this).sortingOrder
		} };
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_WorkersOverviewPanel.Name, parameters);
	}

	public void End()
	{
		ThinkingDataHelper.Instance.NoPayPreviewTrack();
		if (!FGUIManager.Instance.leaseholdChanged && parentUiController != null && parentUiController is UI_BlackMarketerPanel)
		{
			((UI_BlackMarketerPanel)parentUiController).UpdateItemCard(Name);
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	private void SetBuildingName()
	{
		((GObject)titleCom.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText438");
		UpdateGemstone();
		UpdateMoney(isInit: true);
		addDiamondBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Gem");
		addCouponBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Money");
	}

	public void UpdateGemstone()
	{
		int stock = GameManagers.Instance.StockController.GetStock("Money");
		((GObject)addDiamondBtn.GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock("Gem").ToString();
		int num = ((addCouponBtn.GetChild("num").data != null) ? ((int)addCouponBtn.GetChild("num").data) : stock);
		if (num != stock && stock > num)
		{
			int num2 = stock - num;
			if (NumFloating == null)
			{
				NumFloating = UI_ProductionNumFloating.CreateInstance_ILRuntime();
			}
			if (!((GObject)NumFloating).onStage)
			{
				FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloating, addCouponBtn, stock - num);
			}
			else
			{
				((GObject)NumFloating.Title).text = $"+{(int)((GObject)NumFloating.Title).data + num2}";
				((GObject)NumFloating.Title).data = (int)((GObject)NumFloating.Title).data + num2;
			}
		}
		addCouponBtn.GetChild("num").data = stock;
	}

	public void UpdateMoney(bool isInit = false)
	{
		int stock = GameManagers.Instance.StockController.GetStock("Money");
		if (!isInit && addCouponBtn.GetChild("num").data != null && (int)addCouponBtn.GetChild("num").data != stock)
		{
			int num = (int)addCouponBtn.GetChild("num").data;
			FGUIManager.Instance.AddNumFloatingForCouponBtn(UI_ProductionNumFloating.CreateInstance_ILRuntime(), addCouponBtn, stock - num, 1, dispose: true);
		}
		((GObject)addCouponBtn.GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock("Money").ShortNumberFormat();
		addCouponBtn.GetChild("num").data = stock;
	}

	private void DiamondBtnEvent()
	{
		if (FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerAddCredit.Name, new Dictionary<string, object> { 
			{
				"Activity",
				FGUIManager.Instance.GetBlackMarketerActivity("UI_BlackMarketerAddCredit")
			} });
		}
	}

	public void MoneyBtnEvent()
	{
		if (FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_GiftBagPanel.Name, new Dictionary<string, object>
			{
				{
					"Activity",
					FGUIManager.Instance.GetBlackMarketerActivity("UI_GiftBagPanel")
				},
				{
					"Order",
					((GObject)this).sortingOrder
				}
			});
		}
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		switch (itemId)
		{
		case "Gem":
			UpdateGemstone();
			addDiamondBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addDiamondBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
			break;
		case "Money":
			UpdateMoney();
			break;
		case "ManPower":
			UpdateManPower();
			break;
		}
	}

	private void TakeItems(EventContext context)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)(GButton)context.sender).data;
		Shift.Legion.Common.Models.Store.StoreItem storeItem = (Shift.Legion.Common.Models.Store.StoreItem)data;
		string firstContentItemId = storeItem.Content.Keys.First();
		if (!GameManagers.Instance.LeaseholdManager.CanClaimDailyBonus(firstContentItemId))
		{
			return;
		}
		ILRequestHelper<LeaseholdDailyBonusClaimResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().ClaimLeaseholdDailyBonus(firstContentItemId), delegate(LeaseholdDailyBonusClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameManagers.Instance.LeaseholdManager.ClaimDailyBonus(firstContentItemId);
				PlayMissileSfx();
				UpdatePanel();
			}
		}, 1f);
	}

	private void BuyMonthCard(EventContext context)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		object _data = ((GObject)(GButton)context.sender).data;
		Shift.Legion.Common.Models.Store.StoreItem _storeItem = (Shift.Legion.Common.Models.Store.StoreItem)_data;
		caedIndex = -1;
		for (int i = 0; i < itemList.Count; i++)
		{
			if (itemList[i].StoreItemId == _storeItem.StoreItemId)
			{
				caedIndex = i;
				break;
			}
		}
		if (caedIndex >= 0 && FGUIManager.Instance.NotEnoughToPayTip(_storeItem, ((GObject)this).sortingOrder))
		{
			ProductLocalInfo value = null;
			if (!string.IsNullOrEmpty(_storeItem.ReferenceId))
			{
				PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(_storeItem.ReferenceId, out value);
			}
			PurchaseManager.Instance.InvokePurchase(_storeItem, value, 1, delegate
			{
				((GObject)cardList).data = _data;
				int leaseholdItemRemainingTime = GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime(_storeItem.Content.Keys.First());
				ThinkingDataHelper.Instance.ContractTrack(_storeItem.Name, leaseholdItemRemainingTime);
			}, doubleCheck: true);
		}
	}

	private async void OrderShipSuccessEvent(List<Bonus> result, List<Bonus> bonuses)
	{
		PlayMissileSfx();
		await GetCardData();
		UpdateMonthCard(caedIndex, ((GComponent)cardList).GetChildAt(caedIndex));
	}

	private IEnumerator RefreshLeaseholdRemaining()
	{
		while (true)
		{
			if (PanelUpdating || ((GObject)cardList).isDisposed)
			{
				yield return (object)new WaitForSeconds(0.1f);
				continue;
			}
			for (int i = 0; i < itemList.Count; i++)
			{
				Shift.Legion.Common.Models.Store.StoreItem storeItem = itemList[i];
				UI_ContractCard card = (UI_ContractCard)(object)((GComponent)cardList).GetChildAt(i);
				Controller statusController = ((card != null) ? ((GComponent)card).GetController("StatusController") : null);
				if (statusController == null || statusController.selectedIndex == 0)
				{
					continue;
				}
				bool newItemIncoming = false;
				string storeItemFirstContentId = storeItem.Content.Keys.First();
				string monthCardItemId = ((i < monthCardItemList.Count) ? monthCardItemList[i] : null);
				if (monthCardItemId == null || monthCardItemId != storeItemFirstContentId)
				{
					newItemIncoming = true;
					monthCardItemId = storeItem.Content.Keys.First();
					if (i >= monthCardItemList.Count)
					{
						monthCardItemList.Add(monthCardItemId);
					}
					else
					{
						monthCardItemList[i] = monthCardItemId;
					}
					List<Modifier> effect = Item.Effect(GameManagers.Instance, monthCardItemId);
					foreach (Modifier modifer in effect)
					{
						if (modifer.ModifierId != "Bonus")
						{
							continue;
						}
						string monthCardBonusItemId = modifer.PayloadDictionary.Keys.First();
						int monthCardBonusQty = int.Parse(modifer.PayloadDictionary.Values.First().ToString());
						string monthCardBonusIcon = UiHelper.GetIcon(monthCardBonusItemId);
						if (i >= monthCardBonusQtyList.Count)
						{
							monthCardBonusQtyList.Add(monthCardBonusQty);
						}
						else
						{
							monthCardBonusQtyList[i] = monthCardBonusQty;
						}
						if (i >= monthCardBonusIconList.Count)
						{
							monthCardBonusIconList.Add(monthCardBonusIcon);
						}
						else
						{
							monthCardBonusIconList[i] = monthCardBonusIcon;
						}
						break;
					}
					KeyValuePair<string, float> _price = FGUIManager.Instance.GetPriceItemId(storeItem);
					storeItem.Price.First();
					_ = _price.Key;
				}
				int remainingTime = GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime(monthCardItemId);
				if (remainingTime <= 0)
				{
					if (statusController.selectedIndex != 0 || newItemIncoming)
					{
						statusController.selectedIndex = 0;
						((GObject)card.ConfirmTakeBtn.specialRewardNum).text = $"+{monthCardBonusQtyList[i]}";
						((GObject)card.ConfirmTakeBtn.specialRewardIcon).asLoader.url = "ui://PublicResources/" + monthCardBonusIconList[i];
					}
					continue;
				}
				UI_countdownBtn countDownBtn = (UI_countdownBtn)(object)((GComponent)card).GetChild("CountdownBtn").asCom;
				if (remainingTime <= 259200)
				{
					((GObject)countDownBtn.time2).text = UiHelper.ParseTimeChinsesDH(remainingTime) ?? "";
					((GObject)countDownBtn.time1).width = 0f;
					((GComponent)countDownBtn).GetController("Status").selectedIndex = 1;
					((GComponent)((GComponent)card).GetChild("ContinueBuyBtn").asButton).GetController("Status").selectedIndex = 1;
					GComponent countDown = ((GComponent)card).GetChild("CountdownBtn").asCom;
					countDown.GetChild("tip3rd").text = LanguagesManager.GetDesc("CsharpCodeZhTcText436");
				}
				else
				{
					((GObject)countDownBtn.time1).text = UiHelper.ParseTimeChinsesDH(remainingTime) ?? "";
					((GObject)countDownBtn.time2).width = 0f;
					((GComponent)countDownBtn).GetController("Status").selectedIndex = 0;
					((GComponent)((GComponent)card).GetChild("ContinueBuyBtn").asButton).GetController("Status").selectedIndex = 0;
					GComponent countDown2 = ((GComponent)card).GetChild("CountdownBtn").asCom;
					countDown2.GetChild("tip3rd").text = LanguagesManager.GetDesc("CsharpCodeZhTcText437");
				}
			}
			yield return (object)new WaitForSeconds(0.5f);
		}
	}

	private async Task GetCardData()
	{
		GetStoreActivityItemsResponse storeItemsResponse = await GameController.Contexts.Service<INetworkService>().GetStoreActivityItems(storeActivity.ActivityId, storeActivity.ContentPayload(GameManagers.Instance).Keys.First());
		if (!storeItemsResponse.Result)
		{
			ILRequestHelper.ShowErrorCode(storeItemsResponse.ErrorCode);
			return;
		}
		Shift.Legion.ClientApi.Protocol.Store.StoreItem[] incomingStoreItems = storeItemsResponse.StoreItems;
		itemList.Clear();
		if (incomingStoreItems != null && incomingStoreItems.Length != 0)
		{
			Shift.Legion.ClientApi.Protocol.Store.StoreItem[] array = incomingStoreItems;
			foreach (Shift.Legion.ClientApi.Protocol.Store.StoreItem storeItem in array)
			{
				itemList.Add(new Shift.Legion.Common.Models.Store.StoreItem(GameManagers.Instance, storeItem.StoreItemId)
				{
					Icon = storeItem.Icon,
					Rarity = storeItem.Rarity,
					Category = (StoreCategory)storeItem.Category,
					DoubleAtFirst = storeItem.DoubleAtFirst,
					BonusAtFirst = storeItem.BonusAtFirst,
					Tags = storeItem.Tags,
					ValidTime = storeItem.ValidTime,
					KickOffTimestamp = storeItem.KickOffTimestamp,
					ExpireTimestamp = storeItem.ExpireTimestamp,
					Content = storeItem.Content,
					OriginPrice = storeItem.OriginPrice,
					Price = storeItem.Price,
					Discount = storeItem.Discount,
					PurchaseLimit = storeItem.PurchaseLimit,
					PurchaseLimitPeriod = (PurchaseLimitType)storeItem.PurchaseLimitPeriod,
					IsExpo = storeItem.IsExpo,
					Substitution = storeItem.Substitution,
					IsResident = storeItem.IsResident,
					UserLevelFilter = storeItem.UserLevelFilter,
					DungeonLevelFilter = storeItem.DungeonLevelFilter,
					GameLevelFilter = storeItem.GameLevelFilter,
					OwnedItemFilter = storeItem.OwnedItemFilter,
					PurchaseFilter = storeItem.PurchaseFilter
				});
			}
		}
	}

	public static string StripZeros(string formattedPrice)
	{
		Match match = Regex.Match(formattedPrice, "\\.0+$");
		if (match.Success)
		{
			return formattedPrice.Substring(0, match.Index);
		}
		return formattedPrice;
	}
}
