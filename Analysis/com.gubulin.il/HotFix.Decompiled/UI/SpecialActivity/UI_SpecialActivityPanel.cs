using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GvG2;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common;
using Shift.Legion.GvGServer.Models.Map;
using Shift.Legion.Helpers;
using UI.AddCredit;
using UI.BlackMarketer;
using UI.Contract;
using UI.GiftBag;
using UI.GvGExpeditionHall;
using UI.InstanceZones;
using UI.IslandComeAgain;
using UI.LegendItemBlueprintTemplate;
using UI.LordOfDreams;
using UI.MonthCard;
using UI.PublicResources;
using UI.PvpSelectSoldiers;
using UI.Tips;
using UnityEngine;

namespace UI.SpecialActivity;

public class UI_SpecialActivityPanel : GComponent, IUiController
{
	private class Page
	{
		public GComponent Panel;

		public string Title;

		public Func<bool> hasRedDot;

		public Action OnSelected;

		public string ActivityId;

		public void OnClickTab(ref GComponent lastPanel)
		{
			if (lastPanel != null)
			{
				((GObject)lastPanel).visible = false;
			}
			((GObject)Panel).visible = true;
			lastPanel = Panel;
			OnSelected?.Invoke();
		}
	}

	public GLoader background;

	public GGraph _mask;

	public GButton backBtn;

	public UI_Title titleCom;

	public GComponent addCouponBtn;

	public GComponent addDiamondBtn;

	public GList TabsBack;

	public GImage n15;

	public GImage n34;

	public GImage n35;

	public UI_PurchaseLimit PurchaseLimitPanel;

	public UI_SignInPanel_NewYear SignInPanel_NewYear;

	public UI_SignInPnael SignInPanel;

	public UI_DrawPnael DrawPanel;

	public UI_RechargePanel RechargePanel;

	public UI_RealDrwaPanel RealDrwaPanel;

	public UI_GVGEntrancePanel GVGEntrancePanel;

	public UI_IslandComeAgainPanel IslandComeAgainPanel;

	public UI_NeutralDungeonPanel NeutralDungeonPanel;

	public UI_PlayerReturnActivityPanel PlayerReturnActivityPanel;

	public GList Tabs;

	public const string URL = "ui://kozswd8hndja0";

	public static string Name = "UI_SpecialActivityPanel";

	private float cardListTopOffset = 0f;

	private GComponent _lastSelectedPanel;

	private Dictionary<string, Page> Pages;

	private List<Page> PageList;

	private Coroutine Real_RenderPurchaseLimit;

	private List<Shift.Legion.Common.Models.Store.StoreItem> purchaseLimitData = new List<Shift.Legion.Common.Models.Store.StoreItem>();

	private SimpleDynamicPromotionActivity storeActivity;

	private SimpleDynamicSigninActivity signInActivity;

	private Activity drawActivity;

	private int curSignInDay;

	private List<SignInBonusData> signInList = new List<SignInBonusData>();

	private UI_ProductionNumFloating NumFloating;

	private Coroutine TimeLimitRemainingCoroutine;

	private const string LegendItemsStoreActivityName = "UI_LegendItemsStorePanel";

	private int currentCount;

	private Coroutine loadSomeUiPublicResourcesCoroutine;

	private Coroutine showMainPanelCoroutine;

	private static Dictionary<string, NTexture> BackTexture;

	private const string SIGN_IN_MISSED_DAY_COUNT = "SignInMissedDayCount";

	private SimpleDynamicSigninActivity NYActivity;

	private List<SignInBonusData> NYBonusList;

	private List<GButton> NYAchievementList = new List<GButton>();

	private int NYAchievementListSpacing = 0;

	private static NTexture NYBackTexture;

	private const string fakeNYData = "{\"ActivityId\":\"XS0002\",\"ActivityName\":\"\\u864E\\u5E74\\u7B7E\\u5230\",\"PageName\":\"\\u864E\\u5E74\\u7B7E\\u5230\",\"Desc\":\"\\u5468\\u5E74\\u5E86\\u6625\\u8282\\u7B7E\\u5230\\u6D3B\\u52A8\",\"BeginTime\":[\"2022-01-30T22:00:00.0000000+00:00\"],\"EndTime\":[\"2022-02-07T21:55:00.0000000+00:00\"],\"SignInSerialActivityPayload\":\"{\\\"PageName\\\":\\\"\\u864E\\u5E74\\u7B7E\\u5230\\\",\\\"SignInList\\\":[{\\\"Data\\\":{\\\"SerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u4E00\\u5929\\\",\\\"Target\\\":1,\\\"Bonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":30}\\\",\\\"DisplayBonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":30}\\\",\\\"Key\\\":\\\"\\\"},\\\"SignInSerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u4E00\\u5929\\\",\\\"Target\\\":1,\\\"BonusList\\\":[{\\\"Type\\\":1,\\\"Category\\\":0,\\\"Schema\\\":\\\"Item\\\",\\\"ItemId\\\":\\\"I40241\\\",\\\"Qty\\\":30,\\\"PayloadList\\\":null,\\\"PayloadDict\\\":null,\\\"ExtraData\\\":null,\\\"IsShining\\\":1}],\\\"DisplayBonus\\\":{\\\"I40241\\\":\\\"30\\\"}},{\\\"Data\\\":{\\\"SerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u4E8C\\u5929\\\",\\\"Target\\\":2,\\\"Bonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":15}\\\",\\\"DisplayBonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":15}\\\",\\\"Key\\\":\\\"\\\"},\\\"SignInSerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u4E8C\\u5929\\\",\\\"Target\\\":2,\\\"BonusList\\\":[{\\\"Type\\\":1,\\\"Category\\\":0,\\\"Schema\\\":\\\"Item\\\",\\\"ItemId\\\":\\\"I40241\\\",\\\"Qty\\\":15,\\\"PayloadList\\\":null,\\\"PayloadDict\\\":null,\\\"ExtraData\\\":null,\\\"IsShining\\\":1}],\\\"DisplayBonus\\\":{\\\"I40241\\\":\\\"15\\\"}},{\\\"Data\\\":{\\\"SerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u4E09\\u5929\\\",\\\"Target\\\":3,\\\"Bonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":15}\\\",\\\"DisplayBonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":15}\\\",\\\"Key\\\":\\\"\\\"},\\\"SignInSerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u4E09\\u5929\\\",\\\"Target\\\":3,\\\"BonusList\\\":[{\\\"Type\\\":1,\\\"Category\\\":0,\\\"Schema\\\":\\\"Item\\\",\\\"ItemId\\\":\\\"I40241\\\",\\\"Qty\\\":15,\\\"PayloadList\\\":null,\\\"PayloadDict\\\":null,\\\"ExtraData\\\":null,\\\"IsShining\\\":1}],\\\"DisplayBonus\\\":{\\\"I40241\\\":\\\"15\\\"}},{\\\"Data\\\":{\\\"SerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u56DB\\u5929\\\",\\\"Target\\\":4,\\\"Bonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":15}\\\",\\\"DisplayBonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":15}\\\",\\\"Key\\\":\\\"\\\"},\\\"SignInSerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u56DB\\u5929\\\",\\\"Target\\\":4,\\\"BonusList\\\":[{\\\"Type\\\":1,\\\"Category\\\":0,\\\"Schema\\\":\\\"Item\\\",\\\"ItemId\\\":\\\"I40241\\\",\\\"Qty\\\":15,\\\"PayloadList\\\":null,\\\"PayloadDict\\\":null,\\\"ExtraData\\\":null,\\\"IsShining\\\":1}],\\\"DisplayBonus\\\":{\\\"I40241\\\":\\\"15\\\"}},{\\\"Data\\\":{\\\"SerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u4E94\\u5929\\\",\\\"Target\\\":5,\\\"Bonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":15}\\\",\\\"DisplayBonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":15}\\\",\\\"Key\\\":\\\"\\\"},\\\"SignInSerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u4E94\\u5929\\\",\\\"Target\\\":5,\\\"BonusList\\\":[{\\\"Type\\\":1,\\\"Category\\\":0,\\\"Schema\\\":\\\"Item\\\",\\\"ItemId\\\":\\\"I40241\\\",\\\"Qty\\\":15,\\\"PayloadList\\\":null,\\\"PayloadDict\\\":null,\\\"ExtraData\\\":null,\\\"IsShining\\\":1}],\\\"DisplayBonus\\\":{\\\"I40241\\\":\\\"15\\\"}},{\\\"Data\\\":{\\\"SerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u516D\\u5929\\\",\\\"Target\\\":6,\\\"Bonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":30}\\\",\\\"DisplayBonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":30}\\\",\\\"Key\\\":\\\"\\\"},\\\"SignInSerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u516D\\u5929\\\",\\\"Target\\\":6,\\\"BonusList\\\":[{\\\"Type\\\":1,\\\"Category\\\":0,\\\"Schema\\\":\\\"Item\\\",\\\"ItemId\\\":\\\"I40241\\\",\\\"Qty\\\":30,\\\"PayloadList\\\":null,\\\"PayloadDict\\\":null,\\\"ExtraData\\\":null,\\\"IsShining\\\":1}],\\\"DisplayBonus\\\":{\\\"I40241\\\":\\\"30\\\"}}],\\\"SignInSerial\\\":\\\"XSQD0002\\\",\\\"ContentIndex\\\":0,\\\"Activity\\\":{\\\"Data\\\":{\\\"Status\\\":1,\\\"Singleton\\\":false,\\\"Parent\\\":\\\"\\\",\\\"SubActivity\\\":\\\"\\\",\\\"LevelCase\\\":\\\"[\\\\\\\"P120\\\\\\\"]\\\",\\\"SoldierCase\\\":\\\"\\\",\\\"PurchaseCase\\\":\\\"\\\",\\\"DifficultyLevel\\\":0,\\\"FormationTag\\\":\\\"\\\",\\\"Name\\\":\\\"\\u864E\\u5E74\\u7B7E\\u5230\\\",\\\"Desc\\\":\\\"\\u5468\\u5E74\\u5E86\\u6625\\u8282\\u7B7E\\u5230\\u6D3B\\u52A8\\\",\\\"ImgUrl\\\":\\\"\\\",\\\"Background\\\":\\\"\\\",\\\"Type\\\":5,\\\"ScoreItem\\\":\\\"\\\",\\\"TicketItem\\\":\\\"\\\",\\\"AutoFillTicket\\\":false,\\\"TicketFillPeriod\\\":0,\\\"TicketFillQuantity\\\":0,\\\"TicketLimit\\\":0,\\\"TicketPrice\\\":\\\"\\\",\\\"BonusExhibition\\\":[],\\\"BonusProgress\\\":\\\"\\\",\\\"ContentType\\\":5,\\\"ContentUnlockType\\\":0,\\\"UI\\\":\\\"\\\",\\\"CanReset\\\":false,\\\"ResetCost\\\":\\\"\\\",\\\"ContentPayload\\\":\\\"{\\\\\\\"\\\\\\\\u864e\\\\\\\\u5e74\\\\\\\\u7b7e\\\\\\\\u5230\\\\\\\":{\\\\\\\"SignInSerial\\\\\\\":\\\\\\\"XSQD0002\\\\\\\"}}\\\",\\\"DynamicBeginTime\\\":false,\\\"Period\\\":0,\\\"BeginTime\\\":[\\\"1/31/2022 6:00:00 AM +08:00\\\"],\\\"EndTime\\\":[\\\"2/8/2022 5:55:00 AM +08:00\\\"],\\\"SettleTime\\\":0,\\\"Key\\\":\\\"XS0002\\\"},\\\"ChildIds\\\":[],\\\"SortOrder\\\":0,\\\"TitleBonus\\\":null,\\\"BonusExhibition\\\":null,\\\"BonusProgress\\\":{},\\\"Bonuses\\\":null,\\\"UiName\\\":null,\\\"UiParams\\\":{},\\\"ResetCost\\\":[],\\\"LevelCase\\\":[\\\"P120\\\"],\\\"SoldierCase\\\":{},\\\"PurchaseCase\\\":[],\\\"ActivityId\\\":\\\"XS0002\\\",\\\"Parent\\\":\\\"\\\",\\\"DifficultyLevel\\\":0,\\\"FormationTag\\\":\\\"XS0002\\\",\\\"Type\\\":5,\\\"BeginTime\\\":[\\\"2022-01-30T22:00:00+00:00\\\"],\\\"EndTime\\\":[\\\"2022-02-07T21:55:00+00:00\\\"],\\\"Period\\\":0,\\\"Name\\\":\\\"\\u864E\\u5E74\\u7B7E\\u5230\\\",\\\"Desc\\\":\\\"\\u5468\\u5E74\\u5E86\\u6625\\u8282\\u7B7E\\u5230\\u6D3B\\u52A8\\\",\\\"ImgUrl\\\":\\\"\\\",\\\"BackgroundUrl\\\":\\\"\\\",\\\"AutoFillTicket\\\":false,\\\"TicketFillPeriod\\\":0,\\\"TicketFillQuantity\\\":0,\\\"TicketLimit\\\":0,\\\"TicketItem\\\":\\\"\\\",\\\"ScoreItem\\\":\\\"\\\",\\\"ContentType\\\":5,\\\"ContentUnlockType\\\":0},\\\"CaseConfig\\\":null,\\\"Tips\\\":[],\\\"Type\\\":null}\",\"SignInSerialInfo\":\"[{\\\"Data\\\":{\\\"SerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u4E00\\u5929\\\",\\\"Target\\\":1,\\\"Bonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":30}\\\",\\\"DisplayBonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":30}\\\",\\\"Key\\\":\\\"\\\"},\\\"SignInSerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u4E00\\u5929\\\",\\\"Target\\\":1,\\\"BonusList\\\":[{\\\"Type\\\":1,\\\"Category\\\":0,\\\"Schema\\\":\\\"Item\\\",\\\"ItemId\\\":\\\"I40241\\\",\\\"Qty\\\":30,\\\"PayloadList\\\":null,\\\"PayloadDict\\\":null,\\\"ExtraData\\\":null,\\\"IsShining\\\":1}],\\\"DisplayBonus\\\":{\\\"I40241\\\":\\\"30\\\"}},{\\\"Data\\\":{\\\"SerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u4E8C\\u5929\\\",\\\"Target\\\":2,\\\"Bonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":15}\\\",\\\"DisplayBonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":15}\\\",\\\"Key\\\":\\\"\\\"},\\\"SignInSerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u4E8C\\u5929\\\",\\\"Target\\\":2,\\\"BonusList\\\":[{\\\"Type\\\":1,\\\"Category\\\":0,\\\"Schema\\\":\\\"Item\\\",\\\"ItemId\\\":\\\"I40241\\\",\\\"Qty\\\":15,\\\"PayloadList\\\":null,\\\"PayloadDict\\\":null,\\\"ExtraData\\\":null,\\\"IsShining\\\":1}],\\\"DisplayBonus\\\":{\\\"I40241\\\":\\\"15\\\"}},{\\\"Data\\\":{\\\"SerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u4E09\\u5929\\\",\\\"Target\\\":3,\\\"Bonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":15}\\\",\\\"DisplayBonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":15}\\\",\\\"Key\\\":\\\"\\\"},\\\"SignInSerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u4E09\\u5929\\\",\\\"Target\\\":3,\\\"BonusList\\\":[{\\\"Type\\\":1,\\\"Category\\\":0,\\\"Schema\\\":\\\"Item\\\",\\\"ItemId\\\":\\\"I40241\\\",\\\"Qty\\\":15,\\\"PayloadList\\\":null,\\\"PayloadDict\\\":null,\\\"ExtraData\\\":null,\\\"IsShining\\\":1}],\\\"DisplayBonus\\\":{\\\"I40241\\\":\\\"15\\\"}},{\\\"Data\\\":{\\\"SerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u56DB\\u5929\\\",\\\"Target\\\":4,\\\"Bonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":15}\\\",\\\"DisplayBonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":15}\\\",\\\"Key\\\":\\\"\\\"},\\\"SignInSerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u56DB\\u5929\\\",\\\"Target\\\":4,\\\"BonusList\\\":[{\\\"Type\\\":1,\\\"Category\\\":0,\\\"Schema\\\":\\\"Item\\\",\\\"ItemId\\\":\\\"I40241\\\",\\\"Qty\\\":15,\\\"PayloadList\\\":null,\\\"PayloadDict\\\":null,\\\"ExtraData\\\":null,\\\"IsShining\\\":1}],\\\"DisplayBonus\\\":{\\\"I40241\\\":\\\"15\\\"}},{\\\"Data\\\":{\\\"SerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u4E94\\u5929\\\",\\\"Target\\\":5,\\\"Bonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":15}\\\",\\\"DisplayBonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":15}\\\",\\\"Key\\\":\\\"\\\"},\\\"SignInSerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u4E94\\u5929\\\",\\\"Target\\\":5,\\\"BonusList\\\":[{\\\"Type\\\":1,\\\"Category\\\":0,\\\"Schema\\\":\\\"Item\\\",\\\"ItemId\\\":\\\"I40241\\\",\\\"Qty\\\":15,\\\"PayloadList\\\":null,\\\"PayloadDict\\\":null,\\\"ExtraData\\\":null,\\\"IsShining\\\":1}],\\\"DisplayBonus\\\":{\\\"I40241\\\":\\\"15\\\"}},{\\\"Data\\\":{\\\"SerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u516D\\u5929\\\",\\\"Target\\\":6,\\\"Bonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":30}\\\",\\\"DisplayBonus\\\":\\\"{\\\\\\\"I40241\\\\\\\":30}\\\",\\\"Key\\\":\\\"\\\"},\\\"SignInSerialId\\\":\\\"XSQD0002\\\",\\\"Title\\\":\\\"\\u7B2C\\u516D\\u5929\\\",\\\"Target\\\":6,\\\"BonusList\\\":[{\\\"Type\\\":1,\\\"Category\\\":0,\\\"Schema\\\":\\\"Item\\\",\\\"ItemId\\\":\\\"I40241\\\",\\\"Qty\\\":30,\\\"PayloadList\\\":null,\\\"PayloadDict\\\":null,\\\"ExtraData\\\":null,\\\"IsShining\\\":1}],\\\"DisplayBonus\\\":{\\\"I40241\\\":\\\"30\\\"}}]\",\"CanSignIn\":false,\"TotalSignInCount\":0,\"LevelCase\":[\"P120\"]}";

	private const bool IsUseNewStyle = false;

	public const int SlotHeight = 143;

	public const int TopY = 53;

	private static List<string> _useBubbleItemID;

	internal LimitedTimeTotalRechargeActivity RechargeActivity;

	private List<GButton> RechargeAchievementList = new List<GButton>();

	private List<LimitedTimeTotalRechargeInfo> curRechargeAimAchievementList = new List<LimitedTimeTotalRechargeInfo>();

	private string Draw => LanguagesManager.GetDesc("CsharpCodeZhTcText842");

	public static List<string> useBubbleItemID
	{
		get
		{
			if (_useBubbleItemID == null)
			{
				_useBubbleItemID = "UseBubbleItemID".ToConfiguration<List<string>>();
			}
			return _useBubbleItemID;
		}
	}

	private int CurTopY
	{
		get
		{
			if (curRechargeAimAchievementList != null && curRechargeAimAchievementList.Count > 0 && curRechargeAimAchievementList[0].Rewards != null)
			{
				foreach (string key in curRechargeAimAchievementList[0].Rewards.Keys)
				{
					if (useBubbleItemID.Contains(key))
					{
						return 53;
					}
				}
			}
			return 0;
		}
	}

	public static string GetURL()
	{
		return "ui://kozswd8hndja0";
	}

	public static UI_SpecialActivityPanel CreateInstance()
	{
		return (UI_SpecialActivityPanel)(object)UIPackage.CreateObject("SpecialActivity", "SpecialActivityPanel");
	}

	public static UI_SpecialActivityPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SpecialActivityPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hndja0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		_mask = (GGraph)((GComponent)this).GetChild("_mask");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		titleCom = (UI_Title)(object)((GComponent)this).GetChild("titleCom");
		addCouponBtn = (GComponent)((GComponent)this).GetChild("addCouponBtn");
		addDiamondBtn = (GComponent)((GComponent)this).GetChild("addDiamondBtn");
		TabsBack = (GList)((GComponent)this).GetChild("TabsBack");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n35 = (GImage)((GComponent)this).GetChild("n35");
		PurchaseLimitPanel = (UI_PurchaseLimit)(object)((GComponent)this).GetChild("PurchaseLimitPanel");
		SignInPanel_NewYear = (UI_SignInPanel_NewYear)(object)((GComponent)this).GetChild("SignInPanel_NewYear");
		SignInPanel = (UI_SignInPnael)(object)((GComponent)this).GetChild("SignInPanel");
		DrawPanel = (UI_DrawPnael)(object)((GComponent)this).GetChild("DrawPanel");
		RechargePanel = (UI_RechargePanel)(object)((GComponent)this).GetChild("RechargePanel");
		RealDrwaPanel = (UI_RealDrwaPanel)(object)((GComponent)this).GetChild("RealDrwaPanel");
		GVGEntrancePanel = (UI_GVGEntrancePanel)(object)((GComponent)this).GetChild("GVGEntrancePanel");
		IslandComeAgainPanel = (UI_IslandComeAgainPanel)(object)((GComponent)this).GetChild("IslandComeAgainPanel");
		NeutralDungeonPanel = (UI_NeutralDungeonPanel)(object)((GComponent)this).GetChild("NeutralDungeonPanel");
		PlayerReturnActivityPanel = (UI_PlayerReturnActivityPanel)(object)((GComponent)this).GetChild("PlayerReturnActivityPanel");
		Tabs = (GList)((GComponent)this).GetChild("Tabs");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		Pages = new Dictionary<string, Page>();
		InitPages();
		PageList = Pages.Values.ToList();
		if (PageList.Count == 0)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText555") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			((GObject)this).visible = false;
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(DelayEnd());
			return;
		}
		PageList.Sort((Page a, Page b) => a.ActivityId.CompareTo(b.ActivityId));
		Tabs.SetVirtual();
		Tabs.itemRenderer = new ListItemRenderer(TabsRenderer);
		Tabs.numItems = PageList.Count;
		TabsBack.numItems = PageList.Count;
		((GComponent)Tabs).scrollPane.onScroll.Set((EventCallback0)delegate
		{
			((GComponent)TabsBack).scrollPane.posY = ((GComponent)Tabs).scrollPane.posY;
		});
		RechargePanel.AchievementList_NewStyle.Init(this);
		RenderCurSignInActivity();
		UpdateNYActivity();
		RenderCurStoreActivity();
		RenderCurRechargeActivity();
		RenderNeutralDungeonActivity();
		SetBuildingName();
		ShowMoneyAndGemBtn();
		Tabs.selectedIndex = 0;
		if (PageList.Count > 0)
		{
			PageList[0].OnClickTab(ref _lastSelectedPanel);
		}
		else
		{
			End();
		}
	}

	private IEnumerator DelayEnd()
	{
		yield return null;
		yield return null;
		yield return null;
		End();
	}

	public void BeforeDestroy()
	{
		RechargePanel.AchievementList_NewStyle.Destroy();
		if (TimeLimitRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(TimeLimitRemainingCoroutine);
		}
		if (Real_RenderPurchaseLimit != null)
		{
			FGUIManager.Instance.CloseIEnumerator(Real_RenderPurchaseLimit);
		}
	}

	public void Destroy()
	{
		UiHelper.UnloadPackage();
		if (drawActivity != null)
		{
			foreach (KeyValuePair<string, ActivityContentPayload> item in drawActivity.ContentPayload(GameManagers.Instance))
			{
				GameManagers.Instance.NewMsgIncomingManager.CheckActivityContent(drawActivity.ActivityId, item.Key);
			}
		}
		FGUIManager.Instance.activityEntranceController?.ShowSpecialActivityEntrance();
	}

	public void OnShow()
	{
		HiddenRechargeAchievementSFX();
		HiddenNYAchievementSFX();
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		addDiamondBtn.GetChild("addButton").onClick.Add(new EventCallback0(DiamondBtnEvent));
		addCouponBtn.GetChild("addButton").onClick.Add(new EventCallback0(MoneyBtnEvent));
		((GObject)DrawPanel.GoToDraw).onClick.Add(new EventCallback0(GoToDrawPanel));
		((GObject)RealDrwaPanel.GoToDraw).onClick.Add(new EventCallback0(GoToRealDrawPanel));
		((GObject)RealDrwaPanel.OpenGvGExpeditionHall).onClick.Add(new EventCallback0(OnOpenGvGExpeditionHallPanel));
		((GObject)GVGEntrancePanel.EnterGVGBtn).onClick.Add(new EventCallback0(GoToGvGSelectIsland));
		((GObject)IslandComeAgainPanel.EnterGVGBtn).onClick.Add(new EventCallback0(GoToIslandPanel));
		((GComponent)RechargePanel.AchievementList).scrollPane.onScroll.Add(new EventCallback0(HiddenRechargeAchievementSFX));
		((GComponent)SignInPanel_NewYear.AchievementList).scrollPane.onScroll.Add(new EventCallback0(HiddenNYAchievementSFX));
		((GObject)SignInPanel_NewYear.RetroactiveSignInInfo.BuyMtg).onClick.Set(new EventCallback0(GoToBuyMtg));
		((GObject)SignInPanel.RetroactiveSignInInfo.BuyMtg).onClick.Set(new EventCallback0(GoToBuyMtg));
		RechargePanel.AchievementList_NewStyle.RegisterUiEventListeners();
		((GObject)NeutralDungeonPanel.EnterNeutralDungeon).onClick.Add(new EventCallback0(EnterNeutralDungeon));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<string>("LIMIT_TIME_MERCHANDISE_EXPIRED", OnLimitTimeMerchandiseExpired);
		SharedMessenger.AddListener<string>("CLOSE_UI", UpdatePvpActivityNote);
		SharedMessenger.AddListener<float>("ON_RECHARGE", OnPurchaseSuccess);
		SharedMessenger.AddListener("ADD_USEABLE_RETROACTIVE_SIGN_IN_COUNT", OnOrderPaidUpdateParallelSignInActivity);
		GvGIZManager instance = GvGIZManager.Instance;
		instance.OnDataLoaded = (Action)Delegate.Combine(instance.OnDataLoaded, new Action(OnIZDataLoaded));
		PlayerReturnActivityPanel.RegisterUIEvent();
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		addDiamondBtn.GetChild("addButton").onClick.Remove(new EventCallback0(DiamondBtnEvent));
		addCouponBtn.GetChild("addButton").onClick.Remove(new EventCallback0(MoneyBtnEvent));
		((GObject)DrawPanel.GoToDraw).onClick.Remove(new EventCallback0(GoToDrawPanel));
		((GObject)RealDrwaPanel.GoToDraw).onClick.Remove(new EventCallback0(GoToRealDrawPanel));
		((GObject)RealDrwaPanel.OpenGvGExpeditionHall).onClick.Remove(new EventCallback0(OnOpenGvGExpeditionHallPanel));
		((GObject)GVGEntrancePanel.EnterGVGBtn).onClick.Remove(new EventCallback0(GoToGvGSelectIsland));
		((GObject)IslandComeAgainPanel.EnterGVGBtn).onClick.Remove(new EventCallback0(GoToIslandPanel));
		RechargePanel.AchievementList_NewStyle.UnregisterUiEventListeners();
		((GComponent)SignInPanel_NewYear.AchievementList).scrollPane.onScroll.Remove(new EventCallback0(HiddenNYAchievementSFX));
		((GObject)SignInPanel_NewYear.RetroactiveSignInInfo.BuyMtg).onClick.Clear();
		((GObject)SignInPanel.RetroactiveSignInInfo.BuyMtg).onClick.Clear();
		((GObject)NeutralDungeonPanel.EnterNeutralDungeon).onClick.Remove(new EventCallback0(EnterNeutralDungeon));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<string>("LIMIT_TIME_MERCHANDISE_EXPIRED", OnLimitTimeMerchandiseExpired);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", UpdatePvpActivityNote);
		SharedMessenger.RemoveListener<float>("ON_RECHARGE", OnPurchaseSuccess);
		SharedMessenger.RemoveListener("ADD_USEABLE_RETROACTIVE_SIGN_IN_COUNT", OnOrderPaidUpdateParallelSignInActivity);
		GvGIZManager instance = GvGIZManager.Instance;
		instance.OnDataLoaded = (Action)Delegate.Remove(instance.OnDataLoaded, new Action(OnIZDataLoaded));
		PlayerReturnActivityPanel.UnregisterUIEvent();
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void SetBuildingName()
	{
		TextFormat textFormat = titleCom.buildingName.textFormat;
		textFormat.font = "ui://kt6rg65orytnv47b";
		textFormat.size = 48;
		titleCom.buildingName.textFormat = textFormat;
		((GObject)titleCom.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText556");
	}

	private void ShowMoneyAndGemBtn()
	{
		UpdateGemstone();
		UpdateMoney(isInit: true);
		addDiamondBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Gem");
		addCouponBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Money");
	}

	private IEnumerator IEnumerator_LoadSomeUiPublicResources(Action action)
	{
		yield return null;
		UiHelper.LoadSomeUiPublicResources(action);
	}

	private bool GvGActivityisExpired(out string activityTimeText)
	{
		if (GvGIZManager.Instance.IZInfos == null)
		{
			activityTimeText = "";
			return true;
		}
		string iZId = GvGIZManager.Instance.IZInfos[0].IZId;
		InstanceZone_Protocol instanceZoneInfo = GvGIZManager.Instance.GetInstanceZoneInfo(iZId);
		int num = (int)GameController.Instance.GetServerTime();
		if (num < instanceZoneInfo.BeginTimestamp || instanceZoneInfo.EndTimestamp < num)
		{
			activityTimeText = "";
			return true;
		}
		DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp(instanceZoneInfo.BeginTimestamp);
		DateTimeOffset dateTimeOffset2 = DateTimeHelper.ParseTimeStamp(instanceZoneInfo.EndTimestamp);
		activityTimeText = LanguagesManager.GetDesc("CsharpCodeZhTcText285") + "：" + dateTimeOffset.LocalDateTime.ToString("yyyy" + LanguagesManager.GetDesc("CsharpCodeZhTcText557") + "MM" + LanguagesManager.GetDesc("CsharpCodeZhTcText397") + "dd" + LanguagesManager.GetDesc("CsharpCodeZhTcText398") + "hh:mm") + "-" + dateTimeOffset2.LocalDateTime.ToString("yyyy" + LanguagesManager.GetDesc("CsharpCodeZhTcText557") + "MM" + LanguagesManager.GetDesc("CsharpCodeZhTcText397") + "dd" + LanguagesManager.GetDesc("CsharpCodeZhTcText398") + "hh:mm");
		return false;
	}

	private void OnIZDataLoaded()
	{
		FGUIManager.Instance.UpdateConfigsGVGDisable();
		if (!GvGActivityisExpired(out var activityTimeText))
		{
			((GObject)GVGEntrancePanel.Time).text = activityTimeText;
			if (!((GObject)GVGEntrancePanel.Desc).isDisposed)
			{
				int iZProgress = GvGIZManager.Instance.IZInfos[0].IZProgress;
				GVGEntrancePanel.Desc.url = $"ui://SpecialActivity/text_world_boss_progress_{iZProgress}";
				GVGEntrancePanel.DescTitle.url = $"ui://SpecialActivity/text_world_boss_desc_title_{iZProgress}";
			}
		}
	}

	public static void UpdateBackgroundFromLink(string imgUrl, GLoader loader = null)
	{
		if (string.IsNullOrEmpty(imgUrl))
		{
			return;
		}
		if (BackTexture == null)
		{
			BackTexture = new Dictionary<string, NTexture>();
		}
		if (BackTexture.TryGetValue(imgUrl, out var value))
		{
			if (loader != null && !((GObject)loader).isDisposed)
			{
				loader.texture = value;
			}
			return;
		}
		FGUIManager.Instance.GetImageFromLink(imgUrl + $"?t={DateTimeHelper.TimeStamp}", delegate(NTexture texture)
		{
			if (loader != null && !((GObject)loader).isDisposed)
			{
				if (loader.texture == null)
				{
					((GObject)loader).alpha = 0f;
					((GObject)loader).TweenFade(1f, 0.45f);
				}
				loader.texture = texture;
			}
			if (!BackTexture.ContainsKey(imgUrl))
			{
				BackTexture.Add(imgUrl, texture);
			}
		});
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

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		if (itemId == "Gem")
		{
			UpdateGemstone();
			addDiamondBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addDiamondBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
		else if (itemId == "Money")
		{
			UpdateMoney();
		}
	}

	private void DiamondBtnEvent()
	{
		if (((GObject)this).parent != null && ((GObject)this).parent is UI_BlackMarketerAddCredit)
		{
			((UI_BlackMarketerAddCredit)(object)((GObject)this).parent).DiamondBtnEvent();
			End();
			return;
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerAddCredit.Name, new Dictionary<string, object>
		{
			{ "Parent", this },
			{
				"Activity",
				FGUIManager.Instance.GetBlackMarketerActivity("UI_BlackMarketerAddCredit")
			},
			{
				"Order",
				((GObject)this).sortingOrder
			}
		});
	}

	private void MoneyBtnEvent()
	{
		if (((GObject)this).parent != null && ((GObject)this).parent is UI_GiftBagPanel)
		{
			((UI_GiftBagPanel)(object)((GObject)this).parent).MoneyBtnEvent();
			End();
			return;
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GiftBagPanel.Name, new Dictionary<string, object>
		{
			{ "Parent", this },
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

	public void UpdateMoneyAndGemNum(List<Bonus> bonusList)
	{
		for (int i = 0; i < bonusList.Count; i++)
		{
			if (bonusList[i].ItemId == "Money")
			{
				UpdateMoney();
			}
			else if (bonusList[i].ItemId == "Gem")
			{
				UpdateGemstone();
			}
		}
	}

	private async void UpdateCurStoreActivity()
	{
		await FGUIManager.Instance.GetSimpleDynamicPromotionActivity(null, mustUpdateData: true);
		RenderCurStoreActivity();
	}

	private void RenderCurStoreActivity()
	{
		GetCurStoreActivity();
		UpdateMainPanel(isInit: true);
	}

	private void GetCurStoreActivity()
	{
	}

	public void OnPurchaseSuccess(float n)
	{
		ActivityEntranceController.Instance.UpdateNotise(RenderCurRechargeActivity);
	}

	public void SetStoreActivity(SimpleDynamicPromotionActivity activity)
	{
		storeActivity = activity;
	}

	public void UpdateMainPanel(bool isInit = false)
	{
		if (storeActivity == null)
		{
			return;
		}
		if (storeActivity.BeginTime != null && storeActivity.BeginTime.Count > 0 && storeActivity.EndTime != null && storeActivity.EndTime.Count > 0)
		{
			DateTimeOffset dateTimeOffset = new DateTimeOffset(DateTimeHelper.Now.DateTime, new TimeSpan(8, 0, 0));
			DateTimeOffset dateTimeOffset2 = storeActivity.BeginTime[0].Add(dateTimeOffset.Offset);
			DateTimeOffset dateTimeOffset3 = storeActivity.EndTime[0].Add(dateTimeOffset.Offset);
			string text;
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				object[] args = new object[2]
				{
					UiHelper.GetDateStringMMddHH(dateTimeOffset2.DateTime),
					UiHelper.GetDateStringMMddHH(dateTimeOffset3.DateTime)
				};
				text = string.Format(LanguagesManager.GetDesc("CsharpEventStartEndTime"), args);
			}
			else
			{
				text = dateTimeOffset2.DateTime.ToString("yyyy" + LanguagesManager.GetDesc("CsharpCodeZhTcText557") + "MM" + LanguagesManager.GetDesc("CsharpCodeZhTcText397") + "dd" + LanguagesManager.GetDesc("CsharpCodeZhTcText398") + "hh:mm" + LanguagesManager.GetDesc("CsharpCodeZhTcText558")) + Environment.NewLine + dateTimeOffset3.DateTime.ToString("yyyy" + LanguagesManager.GetDesc("CsharpCodeZhTcText557") + "MM" + LanguagesManager.GetDesc("CsharpCodeZhTcText397") + "dd" + LanguagesManager.GetDesc("CsharpCodeZhTcText398") + "hh:mm" + LanguagesManager.GetDesc("CsharpCodeZhTcText559"));
			}
			((GObject)PurchaseLimitPanel.ActivityTime).text = text;
		}
		IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
		int changeId = uiService.SetUiNotTouchable(Name);
		uiService.ShowWaitingAnimation(show: true);
		currentCount = 0;
		int aimNum = 0;
		if (isInit)
		{
			aimNum = 1;
			Action action = delegate
			{
				currentCount++;
			};
			loadSomeUiPublicResourcesCoroutine = FGUIManager.Instance.OpenIEnumerator(IEnumerator_LoadSomeUiPublicResources(action));
		}
		showMainPanelCoroutine = FGUIManager.Instance.OpenIEnumerator(ShowMainPanel(aimNum, changeId, isInit));
	}

	private void OnLimitTimeMerchandiseExpired(string storeItemId)
	{
		UpdateMainPanel();
	}

	private IEnumerator ShowMainPanel(int aimNum, int changeId, bool isInit = false)
	{
		if (currentCount >= aimNum)
		{
			RenderStoreItems(isInit);
			IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
			uiService.ShowWaitingAnimation(show: false);
			uiService.SetUiTouchable(changeId);
		}
		else
		{
			yield return (object)new WaitForSeconds(0.1f);
			showMainPanelCoroutine = FGUIManager.Instance.OpenIEnumerator(ShowMainPanel(aimNum, changeId, isInit));
		}
	}

	private void RenderStoreItems(bool isInit = false)
	{
		if (isInit)
		{
			purchaseLimitData.Clear();
		}
		if (isInit)
		{
			RenderPurchaseLimitGift();
			TimeLimitRemainingCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshTimeLimitRemaining());
		}
		else
		{
			RenderPurchaseLimitGift();
		}
	}

	private void RenderPurchaseLimitGift()
	{
		purchaseLimitData.Clear();
		PurchaseLimitPanel.cardList.RemoveChildrenToPool();
		Real_RenderPurchaseLimit = FGUIManager.Instance.OpenIEnumerator(Real_RenderPurchaseLimitList());
	}

	private IEnumerator Real_RenderPurchaseLimitList()
	{
		if (storeActivity.StoreItems == null || storeActivity.StoreItems.Length == 0)
		{
			yield break;
		}
		for (int i = 0; i < storeActivity.StoreItems.Length; i++)
		{
			Shift.Legion.Common.Models.Store.StoreItem storeItem = GetStoreItem(storeActivity.StoreItems[i]);
			if (storeItem != null && (storeItem.PurchaseLimitPeriod != PurchaseLimitType.Permanent || GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId) < storeItem.PurchaseLimit))
			{
				purchaseLimitData.Add(storeItem);
			}
		}
		if (purchaseLimitData.Count <= 0)
		{
			yield break;
		}
		for (int j = 0; j < purchaseLimitData.Count; j++)
		{
			int index = j;
			if (PurchaseLimitPanel.cardList != null && !((GObject)PurchaseLimitPanel.cardList).isDisposed)
			{
				GObject item = PurchaseLimitPanel.cardList.AddItemFromPool();
				item.alpha = 0f;
				item.touchable = false;
				RenderCardListItem(index, item);
				item.TweenFade(1f, 0.1f).OnComplete((GTweenCallback)delegate
				{
					item.touchable = true;
				});
				yield return null;
			}
		}
		if (PurchaseLimitPanel.cardList != null && !((GObject)PurchaseLimitPanel.cardList).isDisposed)
		{
			((GComponent)PurchaseLimitPanel.cardList).EnsureBoundsCorrect();
			if (!Mathf.Approximately(cardListTopOffset, 0f))
			{
				((GComponent)PurchaseLimitPanel.cardList).scrollPane.SetPosY(cardListTopOffset, false);
				cardListTopOffset = 0f;
			}
		}
	}

	private void RenderCardListItem(int index, GObject obj)
	{
		//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fc: Expected O, but got Unknown
		UI_AddCreditCard uI_AddCreditCard = (UI_AddCreditCard)(object)obj;
		Shift.Legion.Common.Models.Store.StoreItem storeItem = (Shift.Legion.Common.Models.Store.StoreItem)(((GObject)uI_AddCreditCard).data = purchaseLimitData[index]);
		if (storeItem.Icon.Contains("PublicResourceStoreItemIcons"))
		{
			uI_AddCreditCard.icon.url = "ui:" + storeItem.Icon;
		}
		else
		{
			uI_AddCreditCard.icon.url = "ui://PublicResources/" + storeItem.Icon;
		}
		if (storeItem.ExpireTimestamp > 0)
		{
			uI_AddCreditCard.FirstTimeDouble.Stauts.selectedIndex = 0;
			((GObject)uI_AddCreditCard.FirstTimeDouble).visible = true;
			int value = storeItem.ExpireTimestamp - (int)GameController.Instance.GetServerTime();
			((GObject)uI_AddCreditCard.FirstTimeDouble.time).text = UiHelper.ParseTime(Convert.ToInt32(value)) ?? "";
		}
		else
		{
			((GObject)uI_AddCreditCard.FirstTimeDouble).visible = false;
		}
		((GObject)uI_AddCreditCard.result).text = storeItem.Name;
		if (storeItem.PurchaseLimitPeriod != PurchaseLimitType.NoLimit)
		{
			string goodsPurchaseLimitTitle = FGUIManager.Instance.GetGoodsPurchaseLimitTitle(storeItem.PurchaseLimitPeriod);
			uI_AddCreditCard.RewardController.selectedIndex = 1;
			int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
			int num = storeItem.PurchaseLimit - purchaseCntAtLimitPeriod;
			string text = ((num > 0) ? "#7C4B2A" : "#c41d19");
			((GObject)uI_AddCreditCard.reward).text = string.Format("{0}[color={1}]{2}/{3}[/color]{4}", goodsPurchaseLimitTitle, text, num, storeItem.PurchaseLimit, LanguagesManager.GetDesc("CsharpCodeZhTcText236"));
			if (num <= 0)
			{
				uI_AddCreditCard.RewardController.selectedIndex = 2;
				((GObject)uI_AddCreditCard.FirstTimeDouble).visible = true;
				int num2 = 0;
				DateTimeOffset dateTimeOffset = DateTimeOffset.Now;
				if (storeItem.PurchaseLimitPeriod == PurchaseLimitType.Daily)
				{
					dateTimeOffset = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().DailyEndAt;
				}
				else if (storeItem.PurchaseLimitPeriod == PurchaseLimitType.Weekly)
				{
					dateTimeOffset = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().WeeklyEndAt;
				}
				else if (storeItem.PurchaseLimitPeriod == PurchaseLimitType.Monthly)
				{
					dateTimeOffset = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().MonthlyEndAt;
				}
				num2 = Convert.ToInt32((dateTimeOffset - DateTimeHelper.Now).TotalSeconds);
				uI_AddCreditCard.FirstTimeDouble.Stauts.selectedIndex = 1;
				((GObject)uI_AddCreditCard.FirstTimeDouble.time).text = UiHelper.ParseTimeChnForGift(num2) + LanguagesManager.GetDesc("CsharpCodeZhTcText872");
			}
			else
			{
				uI_AddCreditCard.RewardController.selectedIndex = 1;
			}
		}
		else
		{
			uI_AddCreditCard.RewardController.selectedIndex = 0;
		}
		KeyValuePair<string, float> availablePriceItemId = GetAvailablePriceItemId(storeItem);
		Dictionary<string, float> dictionary = storeItem.OriginPrice.First();
		string key = availablePriceItemId.Key;
		string text2 = $"{Convert.ToInt32(dictionary.Values.First())}";
		string text3 = $"{Convert.ToInt32(availablePriceItemId.Value)}";
		bool flag = key == "RMB";
		bool flag2 = true;
		uI_AddCreditCard.region.SetSelectedIndex(0);
		ProductLocalInfo value2 = null;
		if (HotUpdateProcess.Instance.IsRegionOutCN && flag)
		{
			((GObject)uI_AddCreditCard.originalCurrencyIcon).visible = false;
			((GObject)uI_AddCreditCard.currentCurrencyIcon).visible = false;
			if (!string.IsNullOrEmpty(storeItem.ReferenceId) && PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value2))
			{
				if (value2.Price > 0f)
				{
					text3 = value2.FormattedPrice;
					text2 = $"{value2.CurrencySymbol}{value2.Price / storeItem.InternationalDiscount:F2}";
				}
				else
				{
					flag2 = false;
					text3 = LanguagesManager.GetDesc("CsharpCodeTextPriceFree");
				}
			}
			else
			{
				flag2 = false;
				text3 = "--";
				if (string.IsNullOrEmpty(storeItem.ReferenceId) && availablePriceItemId.Value <= 0f)
				{
					text3 = LanguagesManager.GetDesc("CsharpCodeTextPriceFree");
				}
			}
			text3 = UI_MonthCardPanel.StripZeros(text3);
			uI_AddCreditCard.region.SetSelectedIndex(1);
		}
		else
		{
			((GObject)uI_AddCreditCard.originalCurrencyIcon).visible = true;
			((GObject)uI_AddCreditCard.currentCurrencyIcon).visible = true;
		}
		if (storeItem.IsFree)
		{
			uI_AddCreditCard.Discount.selectedIndex = (flag2 ? 1 : 0);
			((GObject)uI_AddCreditCard.Price1st).text = text3;
			((GObject)uI_AddCreditCard.Price2nd).text = text2;
			uI_AddCreditCard.currentCurrencyIcon.url = "ui://PublicResources/" + key;
			uI_AddCreditCard.originalCurrencyIcon.url = "ui://PublicResources/" + key;
		}
		else if (Mathf.Abs(storeItem.Discount - 1f) > float.Epsilon && storeItem.Discount > float.Epsilon)
		{
			uI_AddCreditCard.Discount.selectedIndex = (flag2 ? 1 : 0);
			((GObject)uI_AddCreditCard.Price1st).text = text3;
			((GObject)uI_AddCreditCard.Price2nd).text = text2;
			uI_AddCreditCard.currentCurrencyIcon.url = "ui://PublicResources/" + key;
			uI_AddCreditCard.originalCurrencyIcon.url = "ui://PublicResources/" + key;
		}
		else
		{
			uI_AddCreditCard.Discount.selectedIndex = 0;
			((GObject)uI_AddCreditCard.Price1st).text = text3;
			uI_AddCreditCard.currentCurrencyIcon.url = "ui://PublicResources/" + key;
		}
		((GObject)uI_AddCreditCard.Price1stSea).text = text3;
		uI_AddCreditCard.SetControllerPageText();
		((GObject)uI_AddCreditCard).onClick.Set(new EventCallback1(ShowGiftBag));
	}

	public static KeyValuePair<string, float> GetAvailablePriceItemId(Shift.Legion.Common.Models.Store.StoreItem storeItem)
	{
		KeyValuePair<string, float> result = default(KeyValuePair<string, float>);
		KeyValuePair<string, float> result2 = default(KeyValuePair<string, float>);
		for (int num = storeItem.Price.Count - 1; num >= 0; num--)
		{
			Dictionary<string, float> dictionary = storeItem.Price[num].ToDictionary((KeyValuePair<string, float> pair) => pair.Key, (KeyValuePair<string, float> pair) => pair.Value);
			foreach (KeyValuePair<string, float> item in dictionary)
			{
				if (item.Key == "MTG")
				{
					result2 = item;
				}
				if (item.Key == "RMB")
				{
					result = item;
					continue;
				}
				if ((float)GameManagers.Instance.StockController.GetStock(item.Key) >= item.Value)
				{
					return item;
				}
				if (!(item.Key == "Gem"))
				{
					continue;
				}
				return item;
			}
		}
		if (result.Value > float.Epsilon)
		{
			return result;
		}
		return result2;
	}

	private void ShowGiftBag(EventContext context)
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		if (storeActivity == null || !((Object)(object)FGUIManager.Instance.activityEntranceController != (Object)null) || !FGUIManager.Instance.activityEntranceController.SpecialActivityEnable(storeActivity.BeginTime, storeActivity.EndTime))
		{
			List<string> arg = new List<string> { storeActivity?.ActivityName + LanguagesManager.GetDesc("CsharpCodeZhTcText560") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			((GObject)PurchaseLimitPanel).visible = false;
			((GObject)SignInPanel).visible = false;
			((GObject)DrawPanel).visible = false;
			Tabs.selectedIndex = -1;
			UpdateCurStoreActivity();
		}
		else
		{
			object data = ((GObject)context.sender).data;
			Shift.Legion.Common.Models.Store.StoreItem storeItem = (Shift.Legion.Common.Models.Store.StoreItem)data;
			cardListTopOffset = ((GComponent)PurchaseLimitPanel.cardList).scrollPane.posY;
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_TakeItems.Name, new Dictionary<string, object>
			{
				{
					"Name",
					storeItem.Name ?? ""
				},
				{ "CanBuy", true },
				{ "GiftBag", storeItem },
				{ "Parent", this }
			});
		}
	}

	private async Task GetSomeTabStoreItems(bool needUpdate = false)
	{
	}

	private Shift.Legion.Common.Models.Store.StoreItem GetStoreItem(Shift.Legion.ClientApi.Protocol.Store.StoreItem incomingStoreItemData)
	{
		Shift.Legion.Common.Models.Store.StoreItem storeItem = new Shift.Legion.Common.Models.Store.StoreItem(GameManagers.Instance, incomingStoreItemData.StoreItemId)
		{
			Icon = incomingStoreItemData.Icon,
			Rarity = incomingStoreItemData.Rarity,
			Category = (StoreCategory)incomingStoreItemData.Category,
			DoubleAtFirst = incomingStoreItemData.DoubleAtFirst,
			BonusAtFirst = incomingStoreItemData.BonusAtFirst,
			Tags = incomingStoreItemData.Tags,
			ValidTime = incomingStoreItemData.ValidTime,
			KickOffTimestamp = incomingStoreItemData.KickOffTimestamp,
			ExpireTimestamp = incomingStoreItemData.ExpireTimestamp,
			Content = incomingStoreItemData.Content,
			DisplayContent = incomingStoreItemData.DisplayContent,
			OriginPrice = incomingStoreItemData.OriginPrice,
			Price = incomingStoreItemData.Price,
			Discount = incomingStoreItemData.Discount,
			PurchaseLimit = incomingStoreItemData.PurchaseLimit,
			PurchaseLimitPeriod = (PurchaseLimitType)incomingStoreItemData.PurchaseLimitPeriod,
			IsExpo = incomingStoreItemData.IsExpo,
			Substitution = incomingStoreItemData.Substitution,
			IsResident = incomingStoreItemData.IsResident,
			UserLevelFilter = incomingStoreItemData.UserLevelFilter,
			DungeonLevelFilter = incomingStoreItemData.DungeonLevelFilter,
			GameLevelFilter = incomingStoreItemData.GameLevelFilter,
			OwnedItemFilter = incomingStoreItemData.OwnedItemFilter,
			PurchaseFilter = incomingStoreItemData.PurchaseFilter
		};
		if (!storeItem.IsPassedFilters)
		{
			return null;
		}
		if ((!storeItem.IsKickedOff || storeItem.IsExpired || storeItem.IsSoldOut) && !storeItem.IsResident)
		{
			return null;
		}
		return storeItem;
	}

	private async void UpdateCurSignInActivity()
	{
		await FGUIManager.Instance.GetSimpleDynamicSigninActivity(null, mustUpdateData: true);
		RenderCurSignInActivity();
	}

	private void RenderCurSignInActivity()
	{
		RenderCurSignInActivityTabNote();
		RenderSignInPanel(isInit: true);
		RenderRetroactiveSignInPortraitInfo();
	}

	private void RenderCurSignInActivityTabNote()
	{
		UpdateTabs();
	}

	private void RenderRetroactiveSignInPortraitInfo()
	{
		if (signInActivity != null)
		{
			SignInPanel.RetroactiveSignInAvailable.SetSelectedIndex(signInActivity.RetroactiveSignInAvailable ? 1 : 0);
			if (signInActivity.RetroactiveSignInAvailable)
			{
				int missedDayCount = signInActivity.GetMissedDayCount();
				((GObject)SignInPanel.RetroactiveSignInInfo.MissedCnt).text = "SignInMissedDayCount".ToLanguage().Format(new object[1] { missedDayCount });
			}
		}
	}

	private void RenderSignInPanel(bool isInit = false)
	{
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Expected O, but got Unknown
		if (signInActivity == null)
		{
			return;
		}
		UpdateBackgroundFromLink(signInActivity.ImgUrl, SignInPanel.Back.Image);
		((GObject)SignInPanel.Desc).text = signInActivity.Desc;
		if (signInActivity.BeginTime != null && signInActivity.BeginTime.Count > 0 && signInActivity.EndTime != null && signInActivity.EndTime.Count > 0)
		{
			DateTimeOffset dateTimeOffset = new DateTimeOffset(DateTimeHelper.Now.DateTime, new TimeSpan(8, 0, 0));
			DateTimeOffset dateTimeOffset2 = signInActivity.BeginTime[0].Add(dateTimeOffset.Offset);
			DateTimeOffset dateTimeOffset3 = signInActivity.EndTime[0].Add(dateTimeOffset.Offset);
			string text;
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				object[] args = new object[2]
				{
					UiHelper.GetDateStringMMddHH(dateTimeOffset2.DateTime),
					UiHelper.GetDateStringMMddHH(dateTimeOffset3.DateTime)
				};
				text = string.Format(LanguagesManager.GetDesc("CsharpEventStartEndTime"), args);
			}
			else
			{
				text = dateTimeOffset2.DateTime.ToString("yyyy" + LanguagesManager.GetDesc("CsharpCodeZhTcText557") + "MM" + LanguagesManager.GetDesc("CsharpCodeZhTcText397") + "dd" + LanguagesManager.GetDesc("CsharpCodeZhTcText398") + "hh:mm" + LanguagesManager.GetDesc("CsharpCodeZhTcText558")) + Environment.NewLine + dateTimeOffset3.DateTime.ToString("yyyy" + LanguagesManager.GetDesc("CsharpCodeZhTcText557") + "MM" + LanguagesManager.GetDesc("CsharpCodeZhTcText397") + "dd" + LanguagesManager.GetDesc("CsharpCodeZhTcText398") + "hh:mm" + LanguagesManager.GetDesc("CsharpCodeZhTcText559"));
			}
			((GObject)SignInPanel.ActivityTime).text = text;
		}
		if (signInActivity.RetroactiveSignInAvailable)
		{
			curSignInDay = signInActivity.TodayIndex;
		}
		else
		{
			curSignInDay = (signInActivity.CanSignIn ? (signInActivity.TotalSignInCount + 1) : signInActivity.TotalSignInCount);
		}
		signInList = signInActivity.GetBonusData();
		if (!signInActivity.RetroactiveSignInAvailable && isInit)
		{
			if (curSignInDay > signInList.Count)
			{
				signInActivity = null;
				((GObject)SignInPanel).alpha = 0f;
				return;
			}
			((GObject)SignInPanel).alpha = 1f;
		}
		if (signInList.Count > 0)
		{
			SignInPanel.SignInLabelList.columnGap = signInList[0].Spacing;
		}
		((GObject)SignInPanel.SignInLabelList).x = 60f;
		((GObject)SignInPanel.SignInLabelList).data = isInit;
		SignInPanel.SignInLabelList.itemRenderer = new ListItemRenderer(RenderSignInLabel);
		SignInPanel.SignInLabelList.numItems = signInList.Count;
	}

	private void RenderSignInLabel(int index, GObject obj)
	{
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		bool isInit = (bool)((GObject)SignInPanel.SignInLabelList).data;
		GButton asButton2 = ((GComponent)asButton).GetChild("mainBtn").asButton;
		GButton asButton3 = ((GComponent)asButton2).GetChild("rewardBtn").asButton;
		GButton asButton4 = ((GComponent)asButton3).GetChild("ReceivedBtn").asButton;
		SignInBonusData bonusData = signInList[index];
		string itemId = bonusData.DisplayBonus.First().Key;
		((GComponent)asButton2).GetChild("day").text = string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText145"), index + 1, LanguagesManager.GetDesc("CsharpCodeZhTcText228"));
		if (signInActivity.RetroactiveSignInAvailable)
		{
			int signInRange = signInActivity.GetSignInRange(GameManagers.Instance);
			((GComponent)asButton).GetController("pageController").selectedIndex = ((bonusData.Target == signInRange) ? 1 : 0);
		}
		else
		{
			((GComponent)asButton).GetController("pageController").selectedIndex = ((bonusData.Target == curSignInDay) ? 1 : 0);
		}
		if (bonusData.Target == 4 || bonusData.Target == 6)
		{
		}
		((GComponent)asButton3).GetChild("num").text = bonusData.DisplayBonus.First().Value ?? "";
		if (Item.ItemType(itemId) == 3)
		{
			FGUIManager.Instance.SetItemIconAndFrame(((GComponent)asButton3).GetChild("icon").asLoader, itemId);
		}
		else
		{
			((GComponent)asButton3).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
		}
		if (Item.ItemType(itemId) == 10 || Item.ItemType(itemId) == 3)
		{
			((GObject)((GComponent)asButton3).GetChild("icon").asLoader).SetScale(0.75f, 0.75f);
		}
		((GObject)((GComponent)asButton3).GetChild("icon").asLoader).onClick.Set((EventCallback0)delegate
		{
			UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
			FGUIManager.Instance.ItemTip(itemId, 2);
		});
		Controller receiveCtr = ((GComponent)asButton2).GetController("receiveController");
		Controller pageCtr = ((GComponent)asButton4).GetController("PageController");
		Controller rewardCtr = ((GComponent)asButton3).GetController("receiveController");
		Transition stamp = ((GComponent)asButton4).GetTransition("stamp");
		if (signInActivity.RetroactiveSignInAvailable)
		{
			SetParallelSignInBtnStatus();
		}
		else
		{
			SetSerialSignBtnStatus();
		}
		GButton asButton5 = ((GComponent)asButton2).GetChild("SignInBtn").asButton;
		((GObject)asButton5).data = bonusData;
		((GObject)asButton5).onClick.Set(new EventCallback1(SignInEvent));
		void SetParallelSignInBtnStatus()
		{
			List<int> signInBonusClaimRecord = signInActivity.GetSignInBonusClaimRecord(GameManagers.Instance);
			int signInRange2 = signInActivity.GetSignInRange(GameManagers.Instance);
			if (bonusData.Target > signInRange2)
			{
				receiveCtr.selectedIndex = 2;
				pageCtr.selectedIndex = 0;
				rewardCtr.selectedIndex = 0;
			}
			else if (signInBonusClaimRecord.Contains(bonusData.Target))
			{
				receiveCtr.selectedIndex = 1;
				pageCtr.selectedIndex = 1;
				rewardCtr.selectedIndex = 1;
			}
			else
			{
				receiveCtr.selectedIndex = 0;
				pageCtr.selectedIndex = 0;
				rewardCtr.selectedIndex = 0;
			}
		}
		void SetSerialSignBtnStatus()
		{
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Expected O, but got Unknown
			if (bonusData.Target == curSignInDay)
			{
				if (signInActivity.CanSignIn)
				{
					receiveCtr.selectedIndex = 0;
					pageCtr.selectedIndex = 0;
					rewardCtr.selectedIndex = 0;
				}
				else if (isInit)
				{
					receiveCtr.selectedIndex = 1;
					pageCtr.selectedIndex = 1;
					rewardCtr.selectedIndex = 1;
				}
				else
				{
					pageCtr.selectedIndex = 0;
					stamp.Play((PlayCompleteCallback)delegate
					{
						receiveCtr.selectedIndex = 1;
						rewardCtr.selectedIndex = 1;
					});
				}
			}
			else if (bonusData.Target > curSignInDay)
			{
				receiveCtr.selectedIndex = 2;
				pageCtr.selectedIndex = 0;
				rewardCtr.selectedIndex = 0;
			}
			else
			{
				receiveCtr.selectedIndex = 1;
				pageCtr.selectedIndex = 1;
				rewardCtr.selectedIndex = 1;
			}
		}
	}

	private void SignInEvent(EventContext eventContext)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
		SignInBonusData signInBonusData = (SignInBonusData)((GObject)eventContext.sender).data;
		int dayTarget = signInBonusData.Target;
		ILRequestHelper<SignInClaimResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().SignInClaim(signInActivity.ActivityId, dayTarget), delegate(SignInClaimResponse response)
		{
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Expected O, but got Unknown
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				if (response.ErrorCode == 10801001 || response.ErrorCode == 10801003 || response.ErrorCode == 10801002)
				{
					UpdateCurSignInActivity();
				}
			}
			else
			{
				List<Bonus> resultBonuses;
				if (signInActivity.RetroactiveSignInAvailable)
				{
					resultBonuses = signInActivity.ParallelSignIn(GameManagers.Instance, dayTarget);
				}
				else
				{
					if (response.TotalSignIn < curSignInDay)
					{
						List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText213") };
						SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 1, arg3: false);
						return;
					}
					resultBonuses = signInActivity.SerialSignIn(GameManagers.Instance, response.DynamicActivityCanSignIn, response.TotalSignIn, response.DynamicActivityProgress);
					signInActivity.CanSignIn = false;
				}
				if (signInActivity.RetroactiveSignInAvailable)
				{
					GButton asButton = ((GComponent)SignInPanel.SignInLabelList).GetChildAt(dayTarget - 1).asButton;
					GButton asButton2 = ((GComponent)asButton).GetChild("mainBtn").asButton;
					GButton asButton3 = ((GComponent)asButton2).GetChild("rewardBtn").asButton;
					GButton asButton4 = ((GComponent)asButton3).GetChild("ReceivedBtn").asButton;
					Transition transition = ((GComponent)asButton4).GetTransition("stamp");
					transition.Play((PlayCompleteCallback)delegate
					{
						if (resultBonuses == null)
						{
						}
						if (resultBonuses != null)
						{
							UpdateMoneyAndGemNum(resultBonuses);
						}
						RenderSignInPanel();
						RenderCurSignInActivityTabNote();
					});
				}
				else
				{
					if (resultBonuses == null)
					{
					}
					if (resultBonuses != null)
					{
						UpdateMoneyAndGemNum(resultBonuses);
					}
					RenderSignInPanel();
					RenderCurSignInActivityTabNote();
				}
			}
		});
	}

	private IEnumerator RefreshTimeLimitRemaining()
	{
		while (true)
		{
			_ = DateTimeHelper.Now;
			for (int i = 0; i < PurchaseLimitPanel.cardList.numItems; i++)
			{
				UI_AddCreditCard button = (UI_AddCreditCard)(object)((GComponent)PurchaseLimitPanel.cardList).GetChildAt(i);
				if (!(((GObject)(button?)).data is Shift.Legion.Common.Models.Store.StoreItem storeItem))
				{
					continue;
				}
				bool limitTime = false;
				int remainingTime = 0;
				if (storeItem.ExpireTimestamp > 0)
				{
					limitTime = true;
					remainingTime = (int)(storeItem.ExpireTimestamp - GameController.Instance.GetServerTime());
				}
				else if (storeItem.ValidTime > 0)
				{
					remainingTime = GameManagers.Instance.StoreManager.GetLimitTimeMerchandiseRemainingTime(storeActivity.ActivityId, storeItem.StoreItemId);
				}
				if (limitTime)
				{
					if (remainingTime < 0)
					{
						((GObject)button.FirstTimeDouble).visible = false;
					}
					else
					{
						((GObject)button.FirstTimeDouble).visible = true;
						((GObject)button.FirstTimeDouble.time).text = UiHelper.ParseTime(Convert.ToInt32(remainingTime)) ?? "";
					}
				}
				if (storeItem.PurchaseLimitPeriod == PurchaseLimitType.NoLimit)
				{
					continue;
				}
				string title = FGUIManager.Instance.GetGoodsPurchaseLimitTitle(storeItem.PurchaseLimitPeriod);
				button.RewardController.selectedIndex = 1;
				int storeItemPurchaseCnt = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
				int remainingCnt = storeItem.PurchaseLimit - storeItemPurchaseCnt;
				string limitColor = ((remainingCnt > 0) ? "#7C4B2A" : "#c41d19");
				((GObject)button.reward).text = string.Format("{0}[color={1}]{2}/{3}[/color]{4}", title, limitColor, remainingCnt, storeItem.PurchaseLimit, LanguagesManager.GetDesc("CsharpCodeZhTcText236"));
				if (remainingCnt <= 0)
				{
					button.RewardController.selectedIndex = 2;
					((GObject)button.FirstTimeDouble).visible = true;
					DateTimeOffset _time = DateTimeOffset.Now;
					if (storeItem.PurchaseLimitPeriod == PurchaseLimitType.Daily)
					{
						_time = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().DailyEndAt;
					}
					else if (storeItem.PurchaseLimitPeriod == PurchaseLimitType.Weekly)
					{
						_time = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().WeeklyEndAt;
					}
					else if (storeItem.PurchaseLimitPeriod == PurchaseLimitType.Monthly)
					{
						_time = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().MonthlyEndAt;
					}
					int totalSeconds = Convert.ToInt32((_time - DateTimeHelper.Now).TotalSeconds);
					button.FirstTimeDouble.Stauts.selectedIndex = 1;
					((GObject)button.FirstTimeDouble.time).text = UiHelper.ParseTimeChnForGift(totalSeconds) + LanguagesManager.GetDesc("CsharpCodeZhTcText872");
				}
				else
				{
					button.RewardController.selectedIndex = 1;
				}
			}
			yield return (object)new WaitForSeconds(0.5f);
		}
	}

	private void RealDrawPanelInit()
	{
	}

	private void UpdatePvpActivityNote(string panelName)
	{
		if (panelName == UI_LadderTournamentPanel.Name)
		{
			DrawPanelInit();
		}
	}

	private void DrawPanelInit()
	{
	}

	private void RenderPvpActivityTabNote()
	{
		for (int i = 0; i < Tabs.numItems; i++)
		{
			GButton asButton = ((GComponent)Tabs).GetChildAt(i).asButton;
			if (((GObject)asButton).data != null && ((GObject)asButton).data.ToString() == Draw)
			{
				((GComponent)asButton).GetChild("note").visible = RankDataHelper.HasAnyInform();
			}
		}
	}

	private void GoToDrawPanel()
	{
		RankDataHelper.OpenPvpEntrancePanel();
	}

	private void OnOpenGvGExpeditionHallPanel()
	{
		ILRequestHelper<GvGMode3RoomOperationDiabledResponse>.Request((EventContext)null, (Func<Task<GvGMode3RoomOperationDiabledResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3RoomOperationDisabled()), (Action<GvGMode3RoomOperationDiabledResponse>)delegate(GvGMode3RoomOperationDiabledResponse response)
		{
			if (!response.Result)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
				{
					{
						"Content",
						LanguagesManager.TryParseMultiLanguageTip(response.ServerStatusMessage)
					},
					{
						"Buttons",
						new Dictionary<string, Action> { { "Confirm", End } }
					},
					{ "PageIndex", 4 },
					{ "ClickSound", "Confirm" },
					{ "Order", 999999 }
				});
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGExpeditionHallPanel.Name, null, multiMode: false, ignoreQueue: false, null, delegate
				{
					End();
				});
			}
		});
	}

	private void GoToRealDrawPanel()
	{
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ContractPanel.Name, new Dictionary<string, object> { { "Parent", this } });
		}
		else
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
	}

	private void GoToIslandPanel()
	{
		ILRequestHelper<GvGRoomOperationDisabledResponse>.Request((EventContext)null, (Func<Task<GvGRoomOperationDisabledResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGRoomOperationDisabled()), (Action<GvGRoomOperationDisabledResponse>)delegate(GvGRoomOperationDisabledResponse response)
		{
			if (!response.Result)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
				{
					{
						"Content",
						LanguagesManager.TryParseMultiLanguageTip(response.ServerStatusMessage)
					},
					{
						"Buttons",
						new Dictionary<string, Action> { { "Confirm", End } }
					},
					{ "PageIndex", 4 },
					{ "ClickSound", "Confirm" },
					{ "Order", 999999 }
				});
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_IslandComeAgainMatchingPanel.Name, null);
				Singleton<GvGInstanceZone>.Instance.SyncProduce();
				PlayStory();
			}
		});
	}

	private void PlayStory()
	{
		string levelId = FGUIManager.Instance.IslandComeAgainActivities?[0].LevelCase[0];
		if (!GameManagers.Instance.UserArchiveManager.IsLevelCompleted(levelId))
		{
			return;
		}
		string story_id = "Story5241";
		string text = $"GvGMode2GuideKey_u{GameManagers.Instance.UserId}";
		if (GameManagers.Instance.UserArchiveManager.GetIslandComeAgainSoldierStockLimitIncrement() > 0)
		{
			return;
		}
		ILRequestHelper<ActivateStoryResponse>.Request((EventContext)null, (Func<Task<ActivateStoryResponse>>)(() => GameController.Contexts.Service<INetworkService>().ActivateStory(-1L, story_id)), (Action<ActivateStoryResponse>)delegate(ActivateStoryResponse responseActivate)
		{
			if (responseActivate.Result)
			{
				GameManagers.Instance.StoryManager.ActivateStory(story_id);
				StoryManager.PlayStory(GameManagers.Instance, story_id);
			}
		});
	}

	private void GoToGvGSelectIsland()
	{
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		if (GameController.Configs.TryGetValue("GVGDisable", out var value) && value == "1")
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					LanguagesManager.GetDesc("CsharpCodeZhTcText561") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText562") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText563")
				},
				{
					"Buttons",
					new Dictionary<string, Action> { 
					{
						"Confirm",
						delegate
						{
							FGUIManager.Instance.UpdateConfigsGVGDisable();
						}
					} }
				},
				{ "PageIndex", 4 },
				{ "ClickSound", "Confirm" },
				{ "Order", 999999 }
			});
		}
		else
		{
			if (GvGIZManager.Instance.IZInfos == null)
			{
				return;
			}
			if (!GvGConfigHelper.GvGEnable(out var tipText))
			{
				List<string> arg = new List<string> { tipText };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
				return;
			}
			string izId = GvGIZManager.Instance.IZInfos[0].IZId;
			InstanceZone_Protocol instanceZoneInfo = GvGIZManager.Instance.GetInstanceZoneInfo(izId);
			int num = (int)GameController.Instance.GetServerTime();
			if (num < instanceZoneInfo.BeginTimestamp)
			{
				List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText418") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
				return;
			}
			if (instanceZoneInfo.EndTimestamp < num)
			{
				List<string> arg3 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText419") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg3, 1, arg3: false);
				return;
			}
			UnityUiService.Instance.ShowScreenSfx(new Vector2(1500f, 540f), 60f, "ui_gvg_fullscreen", 1f);
			UiAudioManager.Instance.PlaySoundEffect("Portal");
			((GComponent)(object)this).SetTimeout(0.42f).OnComplete((GTweenCallback)delegate
			{
				End();
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_GvGSelectIslandPanel.Name, new Dictionary<string, object>
				{
					{ "ReservePackageResOnClose", true },
					{ "IZId", izId },
					{
						"IZConfigId",
						GvGIZManager.Instance.IZInfos[0].IZConfigId
					},
					{ "CampId", "1" }
				});
			});
		}
	}

	private async void GetCurDrawActivity()
	{
		drawActivity = FGUIManager.Instance.GetSpecialActivity("UI_NationalDayContractPanel", ActivityType.HomePageActivity);
		if (drawActivity != null)
		{
			List<string> checkingActivities = new List<string> { drawActivity.ActivityId };
			if (drawActivity.ActivityProgress(GameManagers.Instance).IsNew)
			{
				await GameManagers.Instance.ActivityManager.ReviewActivities(checkingActivities);
			}
		}
		if (drawActivity != null && (Object)(object)FGUIManager.Instance.activityEntranceController != (Object)null && FGUIManager.Instance.activityEntranceController.ShowSpecialActivityExpireTip(drawActivity.EndTime) && drawActivity.Period == ActivityPeriod.Single && GameLocalDataManager.CanShowSpecialActivityExpireTip(drawActivity.ActivityId))
		{
			List<string> tipList = new List<string>();
			tipList.Add(drawActivity.Name + LanguagesManager.GetDesc("CsharpCodeZhTcText560"));
			((GComponent)(object)this).SetTimeout(0.75f).OnComplete((GTweenCallback)delegate
			{
				SharedMessenger.Broadcast("SHOW_TIPS", tipList, 1, arg3: false);
			});
		}
	}

	private void InitPages()
	{
		ActivityEntranceController entranceController = FGUIManager.Instance.activityEntranceController;
		NeutralDungeonData neutralDungeonData = FGUIManager.Instance.NeutralDungeonData;
		if (neutralDungeonData != null)
		{
			DateTimeOffset other = DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime());
			if (neutralDungeonData.AdBeginTime.CompareTo(other) != 1 && neutralDungeonData.AdEndTime.CompareTo(other) != -1)
			{
				Activity activity = neutralDungeonData.Activity;
				string title = neutralDungeonData.AdName;
				Page value = new Page
				{
					ActivityId = neutralDungeonData.AdId,
					Title = title,
					Panel = (GComponent)(object)NeutralDungeonPanel,
					hasRedDot = () => neutralDungeonData.HasUnlocked() && activity.CanPlay(GameManagers.Instance),
					OnSelected = delegate
					{
						if (activity == null || !((Object)(object)entranceController != (Object)null))
						{
							InformExpiredActivity(title);
						}
					}
				};
				Pages.Add(title, value);
				UpdateBackgroundFromLink(neutralDungeonData.AdBgUrl, NeutralDungeonPanel.Back.Image);
			}
		}
		if (FGUIManager.Instance.SimpleDynamicSigninActivities != null)
		{
			foreach (SimpleDynamicSigninActivity activity2 in FGUIManager.Instance.SimpleDynamicSigninActivities)
			{
				if (activity2 == null || !((Object)(object)entranceController != (Object)null) || !entranceController.SpecialActivityEnable(activity2.BeginTime, activity2.EndTime))
				{
					continue;
				}
				List<SignInBonusData> bonusData = activity2.GetBonusData();
				bool flag = bonusData.Count > 0 && bonusData[0].UIType == "0";
				if (flag)
				{
					signInActivity = activity2;
				}
				else
				{
					NYActivity = activity2;
				}
				string pageName = activity2.PageName;
				Page value2 = new Page
				{
					ActivityId = activity2.ActivityId,
					Title = pageName,
					Panel = (GComponent)(flag ? ((object)SignInPanel) : ((object)SignInPanel_NewYear)),
					hasRedDot = () => activity2.CanSignIn,
					OnSelected = delegate
					{
						if (activity2 == null || !((Object)(object)entranceController != (Object)null) || !entranceController.SpecialActivityEnable(activity2.BeginTime, activity2.EndTime))
						{
							InformExpiredActivity(activity2.ActivityName);
						}
					}
				};
				Pages.Add(pageName, value2);
			}
		}
		if (FGUIManager.Instance.SimpleDynamicPromotionActivities != null)
		{
			foreach (SimpleDynamicPromotionActivity activity3 in FGUIManager.Instance.SimpleDynamicPromotionActivities)
			{
				if (activity3 == null || !((Object)(object)entranceController != (Object)null) || !entranceController.SpecialActivityEnable(activity3.BeginTime, activity3.EndTime))
				{
					continue;
				}
				storeActivity = activity3;
				string pageName2 = activity3.PageName;
				Pages.Add(pageName2, new Page
				{
					ActivityId = activity3.ActivityId,
					Title = pageName2,
					Panel = (GComponent)(object)PurchaseLimitPanel,
					OnSelected = delegate
					{
						if (activity3 == null || !((Object)(object)entranceController != (Object)null) || !entranceController.SpecialActivityEnable(activity3.BeginTime, activity3.EndTime))
						{
							InformExpiredActivity(activity3.ActivityName);
						}
					}
				});
				break;
			}
		}
		if (FGUIManager.Instance.LimitedTimeTotalRechargeCurrentActivity != null)
		{
			foreach (LimitedTimeTotalRechargeActivity activity4 in new List<LimitedTimeTotalRechargeActivity> { FGUIManager.Instance.LimitedTimeTotalRechargeCurrentActivity })
			{
				DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime());
				DateTimeOffset dateTimeOffset2 = DateTimeOffset.Parse(activity4.BeginTime[0]);
				DateTimeOffset dateTimeOffset3 = DateTimeOffset.Parse(activity4.EndTime[0]);
				if (dateTimeOffset < dateTimeOffset2 || dateTimeOffset > dateTimeOffset3)
				{
					continue;
				}
				RechargeActivity = activity4;
				string activityName = activity4.ActivityName;
				Pages.Add(activityName, new Page
				{
					ActivityId = activity4.ActivityId,
					Title = activityName,
					Panel = (GComponent)(object)RechargePanel,
					hasRedDot = () => RechargeActivity.HasAnyInform(),
					OnSelected = delegate
					{
						RechargePanel.AchievementList_NewStyle.OnPageActive();
						DateTimeOffset dateTimeOffset7 = DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime());
						DateTimeOffset dateTimeOffset8 = DateTimeOffset.Parse(activity4.BeginTime[0]);
						DateTimeOffset dateTimeOffset9 = DateTimeOffset.Parse(activity4.EndTime[0]);
						if (dateTimeOffset7 < dateTimeOffset8 || dateTimeOffset7 > dateTimeOffset9)
						{
							InformExpiredActivity(activity4.ActivityName);
						}
					}
				});
				break;
			}
		}
		if (FGUIManager.Instance.SimpleDynamicCardPoolActivities != null)
		{
			foreach (SimpleDynamicCardPoolActivity activity5 in FGUIManager.Instance.SimpleDynamicCardPoolActivities)
			{
				DateTimeOffset dateTimeOffset4 = DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime());
				DateTimeOffset dateTimeOffset5 = DateTimeOffset.Parse(activity5.BeginTime[0]);
				DateTimeOffset dateTimeOffset6 = DateTimeOffset.Parse(activity5.EndTime[0]);
				if (dateTimeOffset4 < dateTimeOffset5 || dateTimeOffset4 > dateTimeOffset6)
				{
					continue;
				}
				string title2 = activity5.Name;
				Pages.Add(title2, new Page
				{
					ActivityId = activity5.ActivityId,
					Title = title2,
					Panel = (GComponent)(object)RealDrwaPanel,
					OnSelected = delegate
					{
						DateTimeOffset dateTimeOffset7 = DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime());
						DateTimeOffset dateTimeOffset8 = DateTimeOffset.Parse(activity5.BeginTime[0]);
						DateTimeOffset dateTimeOffset9 = DateTimeOffset.Parse(activity5.EndTime[0]);
						if (dateTimeOffset7 < dateTimeOffset8 || dateTimeOffset7 > dateTimeOffset9)
						{
							InformExpiredActivity(activity5.Name);
						}
						else
						{
							UpdateBackgroundFromLink(activity5.ImgUrl, RealDrwaPanel.Back.Image);
							((GObject)RealDrwaPanel.Desc).text = activity5.Desc;
							RealDrwaPanel.Type.selectedIndex = ((title2 == "浮空群岛") ? 1 : 0);
						}
					}
				});
				UpdateBackgroundFromLink(activity5.ImgUrl, RealDrwaPanel.Back.Image);
				break;
			}
		}
		if (FGUIManager.Instance.WorldBossActivities != null)
		{
			using List<SimpleDynamicCardPoolActivity>.Enumerator enumerator5 = FGUIManager.Instance.WorldBossActivities.GetEnumerator();
			if (enumerator5.MoveNext())
			{
				SimpleDynamicCardPoolActivity current = enumerator5.Current;
				GvGIZManager.Instance.LoadDataOnce();
			}
		}
		if (FGUIManager.Instance.PlayerReturnActivity != null)
		{
			SimpleDynamicRecallActivity activity6 = FGUIManager.Instance.PlayerReturnActivity.Activity;
			if (activity6 != null && (Object)(object)entranceController != (Object)null && entranceController.SpecialActivityEnable(activity6.BeginTime, activity6.EndTime))
			{
				string pageName3 = activity6.PageName;
				Pages.Add(pageName3, new Page
				{
					ActivityId = activity6.ActivityId,
					Title = pageName3,
					Panel = (GComponent)(object)PlayerReturnActivityPanel,
					OnSelected = delegate
					{
						if (activity6 == null || !((Object)(object)entranceController != (Object)null) || !entranceController.SpecialActivityEnable(activity6.BeginTime, activity6.EndTime))
						{
							InformExpiredActivity(activity6.ActivityName);
						}
					}
				});
			}
			PlayerReturnActivityPanel.Init();
		}
		RenderWorldBossActivitiesPanel();
		RenderIslandActivitiesPanel();
	}

	private void RenderWorldBossActivitiesPanel()
	{
		if (FGUIManager.Instance.WorldBossActivities == null)
		{
			return;
		}
		using List<SimpleDynamicCardPoolActivity>.Enumerator enumerator = FGUIManager.Instance.WorldBossActivities.GetEnumerator();
		if (enumerator.MoveNext())
		{
			SimpleDynamicCardPoolActivity current = enumerator.Current;
			string name = current.Name;
			Pages.Add(name, new Page
			{
				ActivityId = current.ActivityId,
				Title = name,
				Panel = (GComponent)(object)GVGEntrancePanel
			});
		}
	}

	private void RenderIslandActivitiesPanel()
	{
		if (FGUIManager.Instance.IslandComeAgainActivities == null)
		{
			return;
		}
		using List<DynamicIslandComeAgainActivity>.Enumerator enumerator = FGUIManager.Instance.IslandComeAgainActivities.GetEnumerator();
		if (enumerator.MoveNext())
		{
			DynamicIslandComeAgainActivity current = enumerator.Current;
			string name = current.Name;
			Pages.Add(name, new Page
			{
				ActivityId = current.ActivityId,
				Title = name,
				Panel = (GComponent)(object)IslandComeAgainPanel
			});
		}
	}

	private void TabsRenderer(int index, GObject obj)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		UI_ActivityTab uI_ActivityTab = (UI_ActivityTab)(object)obj;
		Page page = PageList[index];
		((GObject)uI_ActivityTab.title).text = page.Title;
		((GObject)uI_ActivityTab.note).visible = page.hasRedDot?.Invoke() ?? false;
		((GObject)uI_ActivityTab).onClick.Set((EventCallback0)delegate
		{
			page.OnClickTab(ref _lastSelectedPanel);
			Tabs.selectedIndex = index;
			foreach (Page page2 in PageList)
			{
				if (!(page2.ActivityId == page.ActivityId))
				{
					((GObject)page2.Panel).visible = false;
				}
			}
		});
	}

	private void UpdateTabs()
	{
		PageList = Pages.Values.ToList();
		if (PageList.Count != 0)
		{
			PageList.Sort((Page a, Page b) => a.ActivityId.CompareTo(b.ActivityId));
			Tabs.numItems = PageList.Count;
			Tabs.RefreshVirtualList();
		}
	}

	private void InformExpiredActivity(string activityName)
	{
		List<string> arg = new List<string> { activityName + LanguagesManager.GetDesc("CsharpCodeZhTcText560") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	private void RenderNeutralDungeonActivity()
	{
		GetNeutralActivity();
		RenderNeutralDungeonActivityTabNote();
		RenderNeutralDungeonPanel();
	}

	private void GetNeutralActivity()
	{
	}

	private void RenderNeutralDungeonActivityTabNote()
	{
		UpdateTabs();
	}

	private void RenderNeutralDungeonPanel()
	{
		NeutralDungeonData neutralDungeonData = FGUIManager.Instance.NeutralDungeonData;
		DateTimeOffset dateTimeOffset = neutralDungeonData.AdBeginTime.ToOffset(DateTimeHelper.TimezoneOffset);
		DateTimeOffset dateTimeOffset2 = neutralDungeonData.AdEndTime.ToOffset(DateTimeHelper.TimezoneOffset);
		object[] args = new object[8]
		{
			dateTimeOffset.Year,
			dateTimeOffset.Month,
			dateTimeOffset.Day,
			$"{dateTimeOffset.Hour:D2}:{dateTimeOffset.Minute:D2}",
			dateTimeOffset2.Year,
			dateTimeOffset2.Month,
			dateTimeOffset2.Day,
			$"{dateTimeOffset2.Hour:D2}:{dateTimeOffset2.Minute:D2}"
		};
		((GObject)NeutralDungeonPanel.OpenTime).text = string.Format(LanguagesManager.GetDesc("NeutralDungeon_AdTime_Period_PlaceHolder") ?? "", args);
		((GObject)NeutralDungeonPanel.Desc).text = neutralDungeonData.AdDesc;
	}

	private void EnterNeutralDungeon()
	{
		NeutralDungeonData neutralDungeonData = FGUIManager.Instance.NeutralDungeonData;
		if (!neutralDungeonData.HasUnlocked())
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("NeutralDungeon_Need_Pass_P310_PlaceHolder") ?? "" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		ActivityStatus status = neutralDungeonData.Activity.GetStatus(GameManagers.Instance);
		if (status != ActivityStatus.Enabled)
		{
			List<string> arg2 = new List<string> { LanguagesManager.GetDesc("nfd5v46uk67ue-n9_k67u") ?? "" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
		}
		else
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_InstanceZonesPanel.Name, new Dictionary<string, object>
			{
				{ "Type", 5 },
				{ "Activity", neutralDungeonData.Activity },
				{ "Parent", this }
			});
		}
	}

	private static void GoToBuyMtg()
	{
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerPanel.Name, null);
			return;
		}
		List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	private void OnOrderPaidUpdateParallelSignInActivity()
	{
		if (!((GObject)this).isDisposed)
		{
			if (NYActivity != null && NYActivity.RetroactiveSignInAvailable)
			{
				UpdateNYActivity();
			}
			if (signInActivity != null && signInActivity.RetroactiveSignInAvailable)
			{
				RenderCurSignInActivity();
			}
		}
	}

	private void UpdateNYActivity(bool isForcedSignIn = false)
	{
		GetNYActivity(isForcedSignIn);
		RenderNYPanel(isInit: true);
		UpdateTabs();
		RenderRetroactiveSignInLandscapeInfo();
	}

	private void GetNYActivity(bool isForcedSignIn = false)
	{
		if (NYActivity != null)
		{
			UpdateBackgroundFromLink(NYActivity.ImgUrl, SignInPanel_NewYear.Back.Image);
			((GObject)SignInPanel_NewYear.ActivityTime).text = NYActivity.Desc;
			NYBonusList = NYActivity.GetBonusData();
			if (isForcedSignIn)
			{
				NYActivity.CanSignIn = false;
			}
			if (NYBonusList.Count > 0)
			{
				NYAchievementListSpacing = NYBonusList[0].Spacing;
			}
		}
	}

	private void RenderRetroactiveSignInLandscapeInfo()
	{
		if (NYActivity != null)
		{
			SignInPanel_NewYear.RetroactiveSignInAvailable.SetSelectedIndex(NYActivity.RetroactiveSignInAvailable ? 1 : 0);
			if (NYActivity.RetroactiveSignInAvailable)
			{
				int missedDayCount = NYActivity.GetMissedDayCount();
				((GObject)SignInPanel_NewYear.RetroactiveSignInInfo.MissedCnt).text = "SignInMissedDayCount".ToLanguage().Format(new object[1] { missedDayCount });
			}
		}
	}

	private void RenderNYPanel(bool isInit = false)
	{
		if (NYActivity != null)
		{
			UpdateNYAchievenments(NYBonusList.Count);
			HiddenNYAchievementSFX();
		}
	}

	private void UpdateNYAchievenments(int num)
	{
		for (int num2 = NYAchievementList.Count - 1; num2 >= 0; num2--)
		{
			GButton val = NYAchievementList[num2];
			NYAchievementList.RemoveAt(num2);
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)val);
			((GObject)val).Dispose();
		}
		for (int i = 0; i < num; i++)
		{
			GButton val2 = (GButton)(object)UI_NYSignInBonus.CreateInstance();
			((GComponent)GRoot.inst).AddChild((GObject)(object)val2);
			((GComponent)SignInPanel_NewYear.AchievementList).AddChild((GObject)(object)val2);
			((GObject)val2).SetXY(0f, (float)i * (134f + (float)NYAchievementListSpacing));
			NYAchievementList.Add(val2);
			RenderNYAchievementCard(i, val2);
		}
		for (int j = 0; j < NYAchievementList.Count; j++)
		{
			if (j != 0)
			{
				((GObject)NYAchievementList[j]).AddRelation((GObject)(object)NYAchievementList[j - 1], (RelationType)9);
			}
			else
			{
				((GObject)NYAchievementList[j]).relations.ClearAll();
			}
		}
	}

	private void RenderNYAchievementCard(int index, GButton button)
	{
		UI_NYSignInBonus uI_NYSignInBonus = (UI_NYSignInBonus)(object)button;
		SignInBonusData signInBonusData = NYBonusList[index];
		button.title = signInBonusData.UiTitle + LanguagesManager.GetDesc("CsharpCodeZhTcText564");
		uI_NYSignInBonus.SetControllerPageText();
		if (signInBonusData.DisplayBonus == null || signInBonusData.DisplayBonus.Count <= 0)
		{
			return;
		}
		uI_NYSignInBonus.BonusList.RemoveChildrenToPool();
		foreach (KeyValuePair<string, string> displayBonu in signInBonusData.DisplayBonus)
		{
			GObject obj = uI_NYSignInBonus.BonusList.AddItemFromPool();
			RenderNYAchievementReward(obj, displayBonu, index);
		}
		if (NYActivity.RetroactiveSignInAvailable)
		{
			RenderParallelSignInLandscapeBtn(uI_NYSignInBonus, signInBonusData);
		}
		else
		{
			RenderSerialSignInLandscapeBtn(uI_NYSignInBonus, index, signInBonusData);
		}
	}

	private void RenderParallelSignInLandscapeBtn(UI_NYSignInBonus card, SignInBonusData config)
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		UI_receiveBtn receiveBtn = card.receiveBtn;
		Controller receiveStatus = card.ReceiveStatus;
		List<int> signInBonusClaimRecord = NYActivity.GetSignInBonusClaimRecord(GameManagers.Instance);
		int signInRange = NYActivity.GetSignInRange(GameManagers.Instance);
		if (config.Target > signInRange)
		{
			receiveStatus.SetSelectedIndex(0);
			receiveBtn.State.SetSelectedIndex(0);
			((GObject)receiveBtn.note).visible = false;
		}
		else if (signInBonusClaimRecord.Contains(config.Target))
		{
			receiveStatus.SetSelectedIndex(2);
			receiveBtn.State.SetSelectedIndex(1);
		}
		else
		{
			receiveStatus.SetSelectedIndex(1);
			receiveBtn.State.SetSelectedIndex(0);
			((GObject)receiveBtn.note).visible = true;
		}
		((GObject)receiveBtn).data = config;
		((GObject)receiveBtn).onClick.Set(new EventCallback1(GetNYReward));
	}

	private void RenderSerialSignInLandscapeBtn(UI_NYSignInBonus card, int index, SignInBonusData config)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		UI_receiveBtn receiveBtn = card.receiveBtn;
		Controller receiveStatus = card.ReceiveStatus;
		receiveStatus.selectedIndex = 1;
		bool flag = NYActivity.CanSignIn && NYActivity.TotalSignInCount == index;
		((GObject)receiveBtn).data = config;
		((GObject)receiveBtn.note).visible = flag;
		((GObject)receiveBtn).onClick.Set(new EventCallback1(GetNYReward));
		((GObject)receiveBtn).enabled = flag;
		receiveBtn.State.selectedIndex = 0;
		if (index < NYActivity.TotalSignInCount)
		{
			((GObject)receiveBtn).enabled = true;
			((GObject)receiveBtn).touchable = false;
			receiveBtn.State.selectedIndex = 1;
			receiveStatus.selectedIndex = 2;
		}
	}

	private void RenderNYAchievementReward(GObject obj, KeyValuePair<string, string> item, int index)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		UI_RechargeRewardItem uI_RechargeRewardItem = (UI_RechargeRewardItem)(object)obj;
		string itemId = item.Key;
		int number = int.Parse(item.Value);
		((GObject)uI_RechargeRewardItem.rewardNum).text = "x" + number.ShortNumberFormat();
		if (index >= 3)
		{
			FGUIManager.Instance.AddTextSpecialEffects(uI_RechargeRewardItem.fxBack, "activated_fx", new Vector3(75f, 75f, 75f));
		}
		else
		{
			((GObject)uI_RechargeRewardItem.fxBack).displayObject.Dispose();
		}
		FGUIManager.Instance.SetItemIconAndFrame(uI_RechargeRewardItem.rewardIcon, itemId, null, "", frameVisible: false);
		if (Item.ItemType(itemId) == 10 || Item.ItemType(itemId) == 3)
		{
			GLoader rewardIcon = uI_RechargeRewardItem.rewardIcon;
			((GObject)rewardIcon).y = 5f;
			rewardIcon.fill = (FillType)1;
			rewardIcon.verticalAlign = (VertAlignType)1;
			rewardIcon.align = (AlignType)1;
		}
		((GObject)uI_RechargeRewardItem.rewardIcon).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(itemId, 2);
		});
	}

	private void GetNYReward(EventContext eventContext)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
		SignInBonusData signInBonusData = (SignInBonusData)((GObject)eventContext.sender).data;
		int dayTarget = signInBonusData.Target;
		ILRequestHelper<SignInClaimResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().SignInClaim(NYActivity.ActivityId, dayTarget), delegate(SignInClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				if (response.ErrorCode == 10801001 || response.ErrorCode == 10801003 || response.ErrorCode == 10801002)
				{
					UpdateNYActivity();
				}
			}
			else
			{
				List<Bonus> list;
				if (NYActivity.RetroactiveSignInAvailable)
				{
					list = NYActivity.ParallelSignIn(GameManagers.Instance, dayTarget);
				}
				else
				{
					int num = (NYActivity.CanSignIn ? (NYActivity.TotalSignInCount + 1) : NYActivity.TotalSignInCount);
					if (response.TotalSignIn < num)
					{
						List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText213") };
						SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 1, arg3: false);
						return;
					}
					NYActivity.TotalSignInCount = response.TotalSignIn;
					list = NYActivity.SerialSignIn(GameManagers.Instance, response.DynamicActivityCanSignIn, response.TotalSignIn, response.DynamicActivityProgress);
					NYActivity.CanSignIn = false;
				}
				if (list == null)
				{
				}
				if (list != null)
				{
					UpdateMoneyAndGemNum(list);
				}
				UpdateNYActivity(isForcedSignIn: true);
				HiddenNYAchievementSFX();
			}
		});
	}

	private void HiddenNYAchievementSFX()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(0f, 6f);
		Vector2 val2 = ((GObject)SignInPanel_NewYear.AimAchievementListTop).LocalToRoot(Vector2.zero, GRoot.inst);
		Vector2 val3 = ((GObject)SignInPanel_NewYear.AimAchievementListBottom).LocalToRoot(Vector2.zero, GRoot.inst);
		for (int i = 0; i < NYAchievementList.Count; i++)
		{
			Vector2 val4 = ((GObject)NYAchievementList[i]).LocalToRoot(Vector2.zero, GRoot.inst);
			bool visible = ((!(val4.y < val2.y + val.y) && !(val4.y > val3.y - ((GObject)NYAchievementList[i]).height + val.y)) ? true : false);
			GObject child = ((GComponent)NYAchievementList[i]).GetChild("BonusList");
			GList val5 = (GList)(object)((child is GList) ? child : null);
			GObject[] children = ((GComponent)val5).GetChildren();
			foreach (GObject val6 in children)
			{
				UI_RechargeRewardItem uI_RechargeRewardItem = (UI_RechargeRewardItem)(object)val6;
				if (!((GObject)uI_RechargeRewardItem.fxBack).displayObject.isDisposed)
				{
					((GObject)uI_RechargeRewardItem.fxBack).displayObject.visible = visible;
				}
			}
		}
	}

	private void RenderCurRechargeActivity()
	{
		GetRechargeActivity();
		RenderRechargeActivityTabNote();
		RenderRechargePanel(isInit: true);
	}

	private async void GetRechargeActivity()
	{
	}

	private void RenderRechargeActivityTabNote()
	{
		UpdateTabs();
	}

	private void RenderRechargePanel(bool isInit = false)
	{
		if (RechargeActivity != null)
		{
			UpdateBackgroundFromLink(RechargeActivity.ImgUrl, RechargePanel.Back.Image);
			((GObject)RechargePanel.ActivityTime).text = RechargeActivity.Desc;
			bool flag = false;
			RechargePanel.UseNewStyle.selectedIndex = 0;
			CumulativeAimAchievementListSort();
			UpdateCumulativeAchievenments(curRechargeAimAchievementList.Count);
			HiddenRechargeAchievementSFX();
		}
	}

	private void UpdateCumulativeAchievenments(int num)
	{
		for (int num2 = RechargeAchievementList.Count - 1; num2 >= 0; num2--)
		{
			GButton val = RechargeAchievementList[num2];
			RechargeAchievementList.RemoveAt(num2);
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)val);
			((GObject)val).Dispose();
		}
		for (int i = 0; i < num; i++)
		{
			GButton val2 = (GButton)(object)UI_RechargeBonus.CreateInstance();
			((GComponent)GRoot.inst).AddChild((GObject)(object)val2);
			((GComponent)RechargePanel.AchievementList).AddChild((GObject)(object)val2);
			((GObject)val2).SetXY(0f, (float)i * 143f + (float)CurTopY);
			RechargeAchievementList.Add(val2);
			RenderCumulativeAchievementCard(i, val2);
		}
		for (int j = 0; j < RechargeAchievementList.Count; j++)
		{
			if (j != 0)
			{
				((GObject)RechargeAchievementList[j]).AddRelation((GObject)(object)RechargeAchievementList[j - 1], (RelationType)9);
			}
			else
			{
				((GObject)RechargeAchievementList[j]).relations.ClearAll();
			}
		}
	}

	private void CumulativeAimAchievementListSort()
	{
		curRechargeAimAchievementList.Clear();
		List<LimitedTimeTotalRechargeInfo> bonusInfos = RechargeActivity.BonusInfos;
		IEnumerable<LimitedTimeTotalRechargeInfo> collection = bonusInfos.Where((LimitedTimeTotalRechargeInfo a) => ArchiveExtension_DynamicActivity_LTTR.GetOneBonusState(RechargeActivity.ActivityId, a.RMB) == ArchiveExtension_DynamicActivity_LTTR.BonusState.Pending);
		IEnumerable<LimitedTimeTotalRechargeInfo> collection2 = bonusInfos.Where((LimitedTimeTotalRechargeInfo a) => ArchiveExtension_DynamicActivity_LTTR.GetOneBonusState(RechargeActivity.ActivityId, a.RMB) == ArchiveExtension_DynamicActivity_LTTR.BonusState.Undergoing);
		IEnumerable<LimitedTimeTotalRechargeInfo> collection3 = bonusInfos.Where((LimitedTimeTotalRechargeInfo a) => ArchiveExtension_DynamicActivity_LTTR.GetOneBonusState(RechargeActivity.ActivityId, a.RMB) == ArchiveExtension_DynamicActivity_LTTR.BonusState.Claimed);
		curRechargeAimAchievementList.AddRange(collection);
		curRechargeAimAchievementList.AddRange(collection2);
		curRechargeAimAchievementList.AddRange(collection3);
	}

	private void RenderCumulativeAchievementCard(int index, GButton button)
	{
		UI_RechargeBonus card = (UI_RechargeBonus)(object)button;
		LimitedTimeTotalRechargeInfo limitedTimeTotalRechargeInfo = curRechargeAimAchievementList[index];
		float currentTotalRecharge = ArchiveExtension_DynamicActivity_LTTR.GetCurrentTotalRecharge(RechargeActivity.ActivityId);
		float targetTotalRechargeTier = limitedTimeTotalRechargeInfo.RMB;
		ArchiveExtension_DynamicActivity_LTTR.BonusState oneBonusState = ArchiveExtension_DynamicActivity_LTTR.GetOneBonusState(RechargeActivity.ActivityId, limitedTimeTotalRechargeInfo.RMB);
		RenderCumulativeAchievementCard(index, currentTotalRecharge, targetTotalRechargeTier, card, limitedTimeTotalRechargeInfo, oneBonusState, GetRechargeReward);
	}

	public static void RenderCumulativeAchievementCard(int index, float currentTotalRecharge, float targetTotalRechargeTier, UI_RechargeBonus card, LimitedTimeTotalRechargeInfo achievement, ArchiveExtension_DynamicActivity_LTTR.BonusState achievementState, Action<EventContext, UI_RechargeBonus> onClickClaimReward)
	{
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		string text = $"{Convert.ToInt32(currentTotalRecharge)}";
		string text2 = $"{Convert.ToInt32(targetTotalRechargeTier)}";
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			text = $"{currentTotalRecharge / 100f:F2}";
			text2 = $"{targetTotalRechargeTier / 100f:F2}";
			((GObject)card.title).text = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcTotalRecharge"), text2);
		}
		else
		{
			((GObject)card.title).text = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcTotalRechargeCN"), text2);
		}
		if (currentTotalRecharge >= (float)achievement.RMB)
		{
			((GObject)card.num).text = "[color=#00a700]" + text + "/" + text2 + "[/color]";
		}
		else
		{
			((GObject)card.num).text = text + "/" + text2;
		}
		Controller receiveStatus = card.ReceiveStatus;
		if (achievementState == ArchiveExtension_DynamicActivity_LTTR.BonusState.Undergoing)
		{
			receiveStatus.selectedIndex = 0;
		}
		if (achievementState == ArchiveExtension_DynamicActivity_LTTR.BonusState.Pending)
		{
			receiveStatus.selectedIndex = 1;
		}
		if (achievementState == ArchiveExtension_DynamicActivity_LTTR.BonusState.Claimed)
		{
			receiveStatus.selectedIndex = 2;
		}
		card.SetControllerPageText();
		if (achievement.Rewards == null || achievement.Rewards.Count <= 0)
		{
			return;
		}
		UI_receiveBtn receiveBtn = card.receiveBtn;
		((GObject)card.receiveBtn).data = index;
		((GObject)receiveBtn.note).visible = achievementState == ArchiveExtension_DynamicActivity_LTTR.BonusState.Pending;
		((GObject)receiveBtn).onClick.Set((EventCallback1)delegate(EventContext x)
		{
			onClickClaimReward(x, card);
		});
		((GObject)receiveBtn).enabled = achievementState == ArchiveExtension_DynamicActivity_LTTR.BonusState.Pending;
		receiveBtn.title.strokeColor = Color32.op_Implicit(new Color32((byte)60, (byte)72, (byte)13, (byte)229));
		card.BonusList.RemoveChildrenToPool();
		foreach (KeyValuePair<string, int> reward in achievement.Rewards)
		{
			GObject obj = card.BonusList.AddItemFromPool();
			RenderRechargeAchievementReward(obj, reward, index, card);
		}
	}

	private static void RenderRechargeAchievementReward(GObject obj, KeyValuePair<string, int> item, int index, UI_RechargeBonus parentCard)
	{
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Expected O, but got Unknown
		UI_RechargeRewardItem uI_RechargeRewardItem = (UI_RechargeRewardItem)(object)obj;
		string itemId = item.Key;
		int value = item.Value;
		uI_RechargeRewardItem.IsShowContent.selectedIndex = 0;
		if (useBubbleItemID.Contains(itemId) && parentCard.ReceiveStatus.selectedIndex != 2)
		{
			((GObject)parentCard).sortingOrder = 1000;
			uI_RechargeRewardItem.IsShowContent.selectedIndex = 1;
			List<Modifier> list = Item.Effect(GameManagers.Instance, itemId);
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (Modifier item2 in list)
			{
				if (!(item2.ModifierId == "Items"))
				{
					continue;
				}
				foreach (KeyValuePair<string, object> item3 in item2.PayloadDictionary)
				{
					dictionary.Add(item3.Key, Convert.ToInt32(item3.Value));
				}
			}
			List<KeyValuePair<string, int>> list2 = dictionary.ToList();
			uI_RechargeRewardItem.ExtraCount.selectedIndex = Mathf.Min(list2.Count, uI_RechargeRewardItem.ExtraCount.pageCount);
			for (int i = 0; i < list2.Count && i < uI_RechargeRewardItem.ExtraCount.pageCount; i++)
			{
				string key = list2[i].Key;
				int value2 = list2[i].Value;
				GComponent asCom = ((GComponent)uI_RechargeRewardItem.ExtraContentUp).GetChild($"item{i}").asCom;
				RenderExtraBonusSingleBubble(asCom, key, value2);
				GComponent asCom2 = ((GComponent)uI_RechargeRewardItem.ExtraContentDown).GetChild($"item{i}").asCom;
				RenderExtraBonusSingleBubble(asCom2, key, value2);
			}
		}
		((GObject)uI_RechargeRewardItem.rewardNum).text = "x" + value.ShortNumberFormat();
		if (index >= 3)
		{
			FGUIManager.Instance.AddTextSpecialEffects(uI_RechargeRewardItem.fxBack, "activated_fx", new Vector3(75f, 75f, 75f));
		}
		else
		{
			((GObject)uI_RechargeRewardItem.fxBack).displayObject.Dispose();
		}
		FGUIManager.Instance.SetItemIconAndFrame(uI_RechargeRewardItem.rewardIcon, itemId, null, "", frameVisible: false);
		if (Item.ItemType(itemId) == 10 || Item.ItemType(itemId) == 3)
		{
			GLoader rewardIcon = uI_RechargeRewardItem.rewardIcon;
			((GObject)rewardIcon).y = 5f;
			rewardIcon.fill = (FillType)1;
			rewardIcon.verticalAlign = (VertAlignType)1;
			rewardIcon.align = (AlignType)1;
		}
		((GObject)uI_RechargeRewardItem.rewardIcon).onClick.Set((EventCallback0)delegate
		{
			if (!FGUIManager.TryShowOptionalBlueprint(itemId))
			{
				if (Item.ItemType(itemId) == 27)
				{
					ArchiveExtension_Formulas.GvGStoreItemInfo value3 = JsonHelper.ToObject<ArchiveExtension_Formulas.GvGStoreItemInfo>(Item.PostScript(itemId));
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemBlueprintTemplatePanel.Name, new Dictionary<string, object> { { "Info", value3 } });
				}
				else
				{
					FGUIManager.Instance.ItemTip(itemId, 2);
				}
			}
		});
	}

	private static void RenderExtraBonusSingleBubble(GComponent extraBonusItem, string itemId, int itemNum)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		FGUIManager.Instance.SetItemIconAndFrame(extraBonusItem.GetChild("icon").asLoader, itemId, null, "", frameVisible: false);
		((GObject)extraBonusItem.GetChild("num").asTextField).text = $"{itemNum}";
		Dictionary<string, object> _params = new Dictionary<string, object> { { "DialogX", 100 } };
		((GObject)extraBonusItem).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(itemId, 2, noCheckBtn: false, reserveRes: false, null, isPack: false, _params);
		});
	}

	private void RechargeAchievenmentClaimed(int index)
	{
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		((GObject)RechargePanel).touchable = false;
		GButton button = RechargeAchievementList[index];
		((GObject)button).relations.ClearAll();
		if (index != RechargeAchievementList.Count - 1)
		{
			((GObject)RechargeAchievementList[index + 1]).RemoveRelation((GObject)(object)button, (RelationType)9);
		}
		RechargeAchievementList.RemoveAt(index);
		GTweenCallback val = default(GTweenCallback);
		((GComponent)button).GetTransition("disappear").Play((PlayCompleteCallback)delegate
		{
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_0102: Expected O, but got Unknown
			RechargeAchievementList.Add(button);
			((GObject)button).SetXY(0f, (float)(RechargeAchievementList.Count * 143 + CurTopY));
			((GObject)button).AddRelation((GObject)(object)RechargeAchievementList[RechargeAchievementList.Count - 2], (RelationType)9);
			((GObject)button).alpha = 1f;
			CumulativeAimAchievementListSort();
			RenderRechargeAchievementList();
			GTweener obj = ((GObject)RechargeAchievementList[index]).TweenMoveY((float)(index * 143 + CurTopY), 0.5f).SetEase((EaseType)5);
			GTweenCallback obj2 = val;
			if (obj2 == null)
			{
				GTweenCallback val2 = delegate
				{
					if (index != 0)
					{
						((GObject)RechargeAchievementList[index]).AddRelation((GObject)(object)RechargeAchievementList[index - 1], (RelationType)9);
					}
					((GObject)RechargePanel).touchable = true;
				};
				GTweenCallback val3 = val2;
				val = val2;
				obj2 = val3;
			}
			obj.OnComplete(obj2);
			HiddenRechargeAchievementSFX();
		});
	}

	private void RenderRechargeAchievementList()
	{
		for (int i = 0; i < RechargeAchievementList.Count; i++)
		{
			RenderCumulativeAchievementCard(i, RechargeAchievementList[i]);
		}
	}

	private void GetRechargeReward(EventContext eventContext, UI_RechargeBonus card)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		int index = (int)((GObject)(GButton)eventContext.sender).data;
		LimitedTimeTotalRechargeInfo rmb_Level = curRechargeAimAchievementList[index];
		Action action = delegate
		{
			RechargeAchievenmentClaimed(index);
			RenderRechargeActivityTabNote();
		};
		ArchiveExtension_DynamicActivity_LTTR.ClaimedBonus(RechargeActivity.ActivityId, rmb_Level, action);
	}

	private void HiddenRechargeAchievementSFX()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(0f, 6f);
		Vector2 val2 = ((GObject)RechargePanel.AimAchievementListTop).LocalToRoot(Vector2.zero, GRoot.inst);
		Vector2 val3 = ((GObject)RechargePanel.AimAchievementListBottom).LocalToRoot(Vector2.zero, GRoot.inst);
		for (int i = 0; i < RechargeAchievementList.Count; i++)
		{
			Vector2 val4 = ((GObject)RechargeAchievementList[i]).LocalToRoot(Vector2.zero, GRoot.inst);
			bool visible = ((!(val4.y < val2.y + val.y) && !(val4.y > val3.y - ((GObject)RechargeAchievementList[i]).height + val.y)) ? true : false);
			GObject child = ((GComponent)RechargeAchievementList[i]).GetChild("BonusList");
			GList val5 = (GList)(object)((child is GList) ? child : null);
			GObject[] children = ((GComponent)val5).GetChildren();
			foreach (GObject val6 in children)
			{
				UI_RechargeRewardItem uI_RechargeRewardItem = (UI_RechargeRewardItem)(object)val6;
				if (!((GObject)uI_RechargeRewardItem.fxBack).displayObject.isDisposed)
				{
					((GObject)uI_RechargeRewardItem.fxBack).displayObject.visible = visible;
				}
			}
		}
	}
}
