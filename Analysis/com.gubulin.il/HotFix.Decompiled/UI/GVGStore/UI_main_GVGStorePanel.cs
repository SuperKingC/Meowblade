using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvGServer.Models.BaseSocket;
using Shift.Legion.Helpers;
using UI.AddCredit;
using UI.LegendItemBlueprintTemplate;
using UI.PublicResources;
using UI.Tips;
using UnityEngine;

namespace UI.GVGStore;

public class UI_main_GVGStorePanel : GComponent, IUiController
{
	private class ShowStoneBoxFlag
	{
		public int CurrentCount;

		public bool ShowRedNote;
	}

	private class StoreItem
	{
		public string ItemId;

		public bool Bought;
	}

	private class StoreItemInput
	{
		public string ItemId;

		public int Type;
	}

	public Controller State;

	public Controller RefreshIsFree;

	public Controller showShenJiStore;

	public GLoader background;

	public GImage n18;

	public GImage n54;

	public UI_com_Title Title;

	public GButton BackBtn;

	public GButton Help;

	public GImage n9;

	public UI_com_StoreItemGroup StoreItems;

	public UI_dec_bg02 n16;

	public GImage n10;

	public GTextField UpdateTime;

	public UI_btn_Refresh Refresh;

	public GTextField n20;

	public GTextField FreeTicketNumber;

	public GGroup n22;

	public GLoader TicketIcon;

	public GTextField n13;

	public GTextField TicketNumber;

	public GGroup n23;

	public GGroup n21;

	public UI_dec_bg01 n24;

	public GImage n26;

	public GTextField n27;

	public GTextField n28;

	public GImage n55;

	public UI_btn_Activate activateBtn;

	public GLoader couponConsumeIcon;

	public GTextField couponSonsuemCount;

	public GGroup HideAfterActive;

	public GGroup n29;

	public GImage n49;

	public GImage n50;

	public UI_btn_ShenJiEntrance shenJiBtn;

	public GGroup n51;

	public UI_com_ShenJiHeader ShenJiHeader;

	public UI_com_Storeroom Storeroom;

	public UI_btn_confirm0 GetMore;

	public UI_btn_confirm1 Exchange;

	public UI_com_ShenJiStore shenJiStorePanel;

	public UI_btn_CloseDivineStore Close;

	public UI_com_GuaranteedTicket Ticket;

	public UI_com_SelectStoneBoxPopup selectBoxPop;

	public Transition ShenJiShow;

	public Transition t1;

	public Transition t2;

	public const string URL = "ui://fvc33k3ggle60";

	public static string Name = "UI_main_GVGStorePanel";

	private const string _I62201 = "I62201";

	private Vector2 _exchangeStartPos;

	private Vector2 _exchangeEndPos;

	public UI_ProductionNumFloating NumFloating;

	private readonly string[] _constMaterials = new string[8] { "I62000", "I62001", "I62002", "I62003", "I62004", "I62005", "I62006", "I62007" };

	private List<string> storeroomItems = new List<string>();

	private const string UnlockState = "Unlock";

	private int currentStockLimit;

	private List<string> boxList = new List<string>();

	private int _currentBoxIndex;

	private Dictionary<string, int> _bonusItems = new Dictionary<string, int>();

	private Dictionary<string, ShowStoneBoxFlag> _boxShowRedNoteFlag;

	private int _nextUpdateStoreItemsTime;

	private int _freeRefreshCount;

	private List<StoreItem> _storeItems = new List<StoreItem>();

	private Coroutine _updateCountDownCoroutine;

	private const int StoreItemNum = 3;

	private bool _playUpdateStoreItems;

	private bool _hasRareStoreItem;

	private StoreActivateMode _storeActive;

	private bool _hasAttendedAnyIzConfigId;

	private Vector2 ExchangeStartPos
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			if (_exchangeStartPos == default(Vector2))
			{
				_exchangeStartPos = ((GObject)ShenJiHeader.couponIcon).LocalToRoot(Vector2.zero, GRoot.inst);
			}
			return _exchangeStartPos;
		}
	}

	private Vector2 ExchangeEndPos
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			if (_exchangeEndPos == default(Vector2))
			{
				_exchangeEndPos = ((GObject)shenJiBtn).LocalToRoot(Vector2.zero, GRoot.inst);
			}
			return _exchangeEndPos;
		}
	}

	public static string GetURL()
	{
		return "ui://fvc33k3ggle60";
	}

	public static UI_main_GVGStorePanel CreateInstance()
	{
		return (UI_main_GVGStorePanel)(object)UIPackage.CreateObject("GVGStore", "main_GVGStorePanel");
	}

	public static UI_main_GVGStorePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GVGStorePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3ggle60", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected O, but got Unknown
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Expected O, but got Unknown
		//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected O, but got Unknown
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Expected O, but got Unknown
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Expected O, but got Unknown
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		RefreshIsFree = ((GComponent)this).GetController("RefreshIsFree");
		showShenJiStore = ((GComponent)this).GetController("showShenJiStore");
		background = (GLoader)((GComponent)this).GetChild("background");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Help = (GButton)((GComponent)this).GetChild("Help");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		StoreItems = (UI_com_StoreItemGroup)(object)((GComponent)this).GetChild("StoreItems");
		n16 = (UI_dec_bg02)(object)((GComponent)this).GetChild("n16");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		UpdateTime = (GTextField)((GComponent)this).GetChild("UpdateTime");
		Refresh = (UI_btn_Refresh)(object)((GComponent)this).GetChild("Refresh");
		n20 = (GTextField)((GComponent)this).GetChild("n20");
		string id = "ui://fvc33k3ggle60".Replace("ui://", "") + "-" + ((GObject)n20).id;
		((GObject)n20).text = LanguagesManager.GetDesc(id);
		FreeTicketNumber = (GTextField)((GComponent)this).GetChild("FreeTicketNumber");
		n22 = (GGroup)((GComponent)this).GetChild("n22");
		TicketIcon = (GLoader)((GComponent)this).GetChild("TicketIcon");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id2 = "ui://fvc33k3ggle60".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id2);
		TicketNumber = (GTextField)((GComponent)this).GetChild("TicketNumber");
		n23 = (GGroup)((GComponent)this).GetChild("n23");
		n21 = (GGroup)((GComponent)this).GetChild("n21");
		n24 = (UI_dec_bg01)(object)((GComponent)this).GetChild("n24");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id3 = "ui://fvc33k3ggle60".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id3);
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id4 = "ui://fvc33k3ggle60".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id4);
		n55 = (GImage)((GComponent)this).GetChild("n55");
		activateBtn = (UI_btn_Activate)(object)((GComponent)this).GetChild("activateBtn");
		couponConsumeIcon = (GLoader)((GComponent)this).GetChild("couponConsumeIcon");
		couponSonsuemCount = (GTextField)((GComponent)this).GetChild("couponSonsuemCount");
		string id5 = "ui://fvc33k3ggle60".Replace("ui://", "") + "-" + ((GObject)couponSonsuemCount).id;
		((GObject)couponSonsuemCount).text = LanguagesManager.GetDesc(id5);
		HideAfterActive = (GGroup)((GComponent)this).GetChild("HideAfterActive");
		n29 = (GGroup)((GComponent)this).GetChild("n29");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		shenJiBtn = (UI_btn_ShenJiEntrance)(object)((GComponent)this).GetChild("shenJiBtn");
		n51 = (GGroup)((GComponent)this).GetChild("n51");
		ShenJiHeader = (UI_com_ShenJiHeader)(object)((GComponent)this).GetChild("ShenJiHeader");
		Storeroom = (UI_com_Storeroom)(object)((GComponent)this).GetChild("Storeroom");
		GetMore = (UI_btn_confirm0)(object)((GComponent)this).GetChild("GetMore");
		Exchange = (UI_btn_confirm1)(object)((GComponent)this).GetChild("Exchange");
		shenJiStorePanel = (UI_com_ShenJiStore)(object)((GComponent)this).GetChild("shenJiStorePanel");
		Close = (UI_btn_CloseDivineStore)(object)((GComponent)this).GetChild("Close");
		Ticket = (UI_com_GuaranteedTicket)(object)((GComponent)this).GetChild("Ticket");
		selectBoxPop = (UI_com_SelectStoneBoxPopup)(object)((GComponent)this).GetChild("selectBoxPop");
		ShenJiShow = ((GComponent)this).GetTransition("ShenJiShow");
		t1 = ((GComponent)this).GetTransition("t1");
		t2 = ((GComponent)this).GetTransition("t2");
	}

	public void BeforeDestroy()
	{
		shenJiStorePanel.BeforeDestroy();
		if (_updateCountDownCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_updateCountDownCoroutine);
		}
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		InitStoneBox();
		InitSelectBoxPop();
		ShowStoreroom();
		ChangeStoreItemsAlpha(0f);
		InitGvgStore();
	}

	private void InitGvgStore()
	{
		Singleton<GvG3StoreManager>.Instance.GetIzGvGStoreActivatedAsync(delegate(StoreActivateMode activeMode)
		{
			Singleton<GvG3StoreManager>.Instance.GetHasAttendedAnyIzConfigIdAsync(delegate(bool hasAttended)
			{
				if (!((GObject)this).isDisposed)
				{
					_storeActive = activeMode;
					_hasAttendedAnyIzConfigId = hasAttended;
					showShenJiStore.SetSelectedIndex(hasAttended ? 1 : 0);
					SetStoreState(_storeActive);
					if (_storeActive != StoreActivateMode.Sleep)
					{
						UpdateStoreItems(forceRefresh: false);
					}
					InitShenJiStore();
				}
			});
		});
	}

	public void OnShow()
	{
		Singleton<GvG3StoreManager>.Instance.CheckGvGStorePanel();
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
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		((GObject)GetMore).onClick.Add(new EventCallback0(GetMoreEvent));
		((GObject)Exchange).onClick.Add(new EventCallback0(ExchangeEvent));
		((GObject)Help).onClick.Add(new EventCallback0(OpenHelpDialog));
		((GObject)Refresh).onClick.Add(new EventCallback0(ReplaceStoreItems));
		((GObject)Storeroom.selectStone).onClick.Set(new EventCallback0(OnClickShowSelectStonePop));
		((GObject)selectBoxPop.Mask).onClick.Set(new EventCallback0(HideSelectStonePop));
		((GObject)shenJiBtn).onClick.Set(new EventCallback0(OnClickShenJiBtn));
		((GObject)ShenJiHeader.couponIcon).onClick.Set(new EventCallback0(OnClickExchangeCoupon));
		((GObject)ShenJiHeader.ClickGraph).onClick.Set(new EventCallback0(ExchangeGvGStoreGuaranteedTicket));
		((GObject)activateBtn).onClick.Set(new EventCallback0(OnClickActiveStore));
		shenJiStorePanel.RegisterUiEventListeners();
		((GObject)couponConsumeIcon).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip("I62200", ((GObject)this).sortingOrder);
		});
		((GObject)Close).onClick.Set(new EventCallback0(CloseShenJiStorePanel));
		GvG3StoreManager instance = Singleton<GvG3StoreManager>.Instance;
		instance.EOnCurrentExchangeScoreChange = (Action)Delegate.Combine(instance.EOnCurrentExchangeScoreChange, new Action(RefreshExchangeCouponProgress));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener("UPDATE_GVG_STOREROOM", ShowStoreroom);
		SharedMessenger.AddListener<bool>("UPDATE_GVG_STORE_ITEMS", RefreshStoreItems);
		S2C_SystemIZOver.OnPushEvent = (Action<S2C_SystemIZOver.Request>)Delegate.Combine(S2C_SystemIZOver.OnPushEvent, new Action<S2C_SystemIZOver.Request>(OnSystemClose));
	}

	public void UnregisterUiEventListeners()
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
		((GObject)BackBtn).onClick.Remove(new EventCallback0(End));
		((GObject)GetMore).onClick.Remove(new EventCallback0(GetMoreEvent));
		((GObject)Exchange).onClick.Remove(new EventCallback0(ExchangeEvent));
		((GObject)Help).onClick.Remove(new EventCallback0(OpenHelpDialog));
		((GObject)Refresh).onClick.Remove(new EventCallback0(ReplaceStoreItems));
		((GObject)Storeroom.selectStone).onClick.Clear();
		((GObject)selectBoxPop.Mask).onClick.Clear();
		((GObject)shenJiBtn).onClick.Clear();
		((GObject)ShenJiHeader.couponIcon).onClick.Clear();
		((GObject)ShenJiHeader.ClickGraph).onClick.Clear();
		((GObject)couponConsumeIcon).onClick.Clear();
		shenJiStorePanel.UnregisterUiEventListeners();
		((GObject)Close).onClick.Clear();
		GvG3StoreManager instance = Singleton<GvG3StoreManager>.Instance;
		instance.EOnCurrentExchangeScoreChange = (Action)Delegate.Remove(instance.EOnCurrentExchangeScoreChange, new Action(RefreshExchangeCouponProgress));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener("UPDATE_GVG_STOREROOM", ShowStoreroom);
		SharedMessenger.RemoveListener<bool>("UPDATE_GVG_STORE_ITEMS", RefreshStoreItems);
		S2C_SystemIZOver.OnPushEvent = (Action<S2C_SystemIZOver.Request>)Delegate.Remove(S2C_SystemIZOver.OnPushEvent, new Action<S2C_SystemIZOver.Request>(OnSystemClose));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void SetStoreState(StoreActivateMode mode)
	{
		bool flag = mode != StoreActivateMode.Sleep;
		State.SetSelectedIndex(flag ? 1 : 0);
		((GObject)GetMore).grayed = mode == StoreActivateMode.Sleep;
	}

	private void addDiamond()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerAddCredit.Name, new Dictionary<string, object>
		{
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

	private void GetMoreEvent()
	{
		if (_storeActive == StoreActivateMode.Sleep)
		{
			"GvGStoreGetMoreTip".ToShowLanguageTip();
			return;
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GVGStoreJumpPanel.Name, new Dictionary<string, object> { { "StoreActivateMode", _storeActive } });
	}

	private void ExchangeEvent()
	{
		ArchiveExtension_Formulas.GetLimitedFormulas(OpenFormulaPanel);
		static void OpenFormulaPanel(List<Formula> limitedFormulas)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GVGStoreExchangeFormulaPanel.Name, new Dictionary<string, object> { { "LimitedFormulas", limitedFormulas } });
		}
	}

	private void OpenHelpDialog()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GVGStoreHelpPanel.Name, null);
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 28)
		{
			if (incr > 0)
			{
				if (_bonusItems.ContainsKey(itemId))
				{
					_bonusItems[itemId] += incr;
				}
				else
				{
					_bonusItems.Add(itemId, incr);
				}
			}
			ShowStoreroom();
			UpdateStoreItems(forceRefresh: true);
			shenJiStorePanel.UpdateSelectedGuaranteedStoreItem();
		}
		else if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 29 || Shift.Legion.Common.Models.Item.ItemType(itemId) == 30)
		{
			ShowStoreroom();
			OnStoneBoxCountChange();
		}
		else if (itemId == "I62200")
		{
			RefreshSleepStateView();
		}
	}

	private void ShowStoreroom()
	{
		if (currentStockLimit > 0)
		{
			RenderStoreroom(currentStockLimit);
		}
		else
		{
			GameManagers.Instance.UserArchiveManager.GetGvGStoreroomStockLimit(RenderStoreroom);
		}
	}

	private void InitStoneBox()
	{
		_boxShowRedNoteFlag = new Dictionary<string, ShowStoneBoxFlag>();
		boxList = new List<string> { "I62100", "I62099", "I62101" };
		foreach (string box in boxList)
		{
			ShowStoneBoxFlag showStoneBoxFlag = new ShowStoneBoxFlag();
			showStoneBoxFlag.CurrentCount = GameManagers.Instance.StockController.GetStock(box);
			showStoneBoxFlag.ShowRedNote = false;
			_boxShowRedNoteFlag.Add(box, showStoneBoxFlag);
		}
		_currentBoxIndex = GetCurrentBoxIndex();
	}

	private void RefreshStoneBox()
	{
		RenderCurrentBox(_currentBoxIndex);
		RefreshSelectStoneNote();
	}

	private void OnClickShowSelectStonePop()
	{
		((GObject)selectBoxPop).visible = true;
		RefreshSelectStonePanel(isInit: true);
	}

	private void InitSelectBoxPop()
	{
		((GObject)selectBoxPop).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		((GObject)selectBoxPop).visible = false;
	}

	private void HideSelectStonePop()
	{
		((GObject)selectBoxPop).visible = false;
	}

	private void RefreshSelectStonePanel(bool isInit)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		GList stoneBoxList = selectBoxPop.dialog.stoneBoxList;
		stoneBoxList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			string text = boxList[index];
			UI_com_StoneBoxIcon uI_com_StoneBoxIcon = (UI_com_StoneBoxIcon)(object)item;
			FGUIManager.Instance.SetItemIconAndFrame(uI_com_StoneBoxIcon.Pack, text, null, "", frameVisible: false);
			int stock = GameManagers.Instance.StockController.GetStock(text);
			bool flag = stock <= 0;
			((GObject)uI_com_StoneBoxIcon.count).text = stock.ToString();
			uI_com_StoneBoxIcon.Status.SetSelectedIndex((!flag) ? 1 : 0);
			((GObject)uI_com_StoneBoxIcon.itemName).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, text);
			ShowStoneBoxFlag flag2 = _boxShowRedNoteFlag[text];
			((GObject)uI_com_StoneBoxIcon.redNote).visible = flag2.ShowRedNote;
			((GObject)uI_com_StoneBoxIcon).touchable = !flag;
			((GObject)uI_com_StoneBoxIcon).onClick.Set((EventCallback0)delegate
			{
				flag2.ShowRedNote = false;
				OnClickSelectBox(index);
			});
		};
		stoneBoxList.numItems = boxList.Count;
		if (isInit)
		{
			SetSelectTarget();
		}
	}

	private void OnStoneBoxCountChange()
	{
		bool flag = false;
		foreach (KeyValuePair<string, ShowStoneBoxFlag> item in _boxShowRedNoteFlag)
		{
			string key = item.Key;
			ShowStoneBoxFlag value = item.Value;
			int stock = GameManagers.Instance.StockController.GetStock(key);
			if (value.CurrentCount == 0 && stock > 0)
			{
				value.ShowRedNote = true;
				flag = true;
			}
			value.CurrentCount = stock;
		}
		if (flag)
		{
			RefreshSelectStoneNote();
		}
		RefreshStoneBox();
	}

	private void RefreshSelectStoneNote()
	{
		foreach (ShowStoneBoxFlag value in _boxShowRedNoteFlag.Values)
		{
			if (value.ShowRedNote)
			{
				((GObject)Storeroom.selectStone.shenJiEntranceNote).visible = true;
				return;
			}
		}
		string itemId = boxList[_currentBoxIndex];
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		if (stock > 0)
		{
			((GObject)Storeroom.selectStone.shenJiEntranceNote).visible = false;
			return;
		}
		foreach (string box in boxList)
		{
			int stock2 = GameManagers.Instance.StockController.GetStock(box);
			if (stock2 > 0)
			{
				((GObject)Storeroom.selectStone.shenJiEntranceNote).visible = true;
				return;
			}
		}
		((GObject)Storeroom.selectStone.shenJiEntranceNote).visible = false;
	}

	private void SetSelectTarget()
	{
		GList stoneBoxList = selectBoxPop.dialog.stoneBoxList;
		for (int i = 0; i < stoneBoxList.numItems; i++)
		{
			UI_com_StoneBoxIcon uI_com_StoneBoxIcon = (UI_com_StoneBoxIcon)(object)((GComponent)stoneBoxList).GetChildAt(i);
			uI_com_StoneBoxIcon.isSelect.SetSelectedIndex((_currentBoxIndex == i) ? 1 : 0);
		}
	}

	private int GetCurrentBoxIndex()
	{
		int num = 0;
		if (GameLocalDataManager.HasKey("IntKey_GvgStoreSelectStoneBoxIndex"))
		{
			num = GameLocalDataManager.GetInt("IntKey_GvgStoreSelectStoneBoxIndex");
			num = Mathf.Clamp(num, 0, boxList.Count - 1);
			string itemId = boxList[num];
			int stock = GameManagers.Instance.StockController.GetStock(itemId);
			if (stock > 0)
			{
				return num;
			}
		}
		for (int num2 = boxList.Count - 1; num2 >= 0; num2--)
		{
			string itemId2 = boxList[num2];
			int stock2 = GameManagers.Instance.StockController.GetStock(itemId2);
			if (stock2 > 0)
			{
				return num2;
			}
		}
		return num;
	}

	private void RenderCurrentBox(int checkBoxIndex)
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		string text = boxList[checkBoxIndex];
		FGUIManager.Instance.SetItemIconAndFrame(Storeroom.Pack, text, null, "", frameVisible: false);
		int stock = GameManagers.Instance.StockController.GetStock(text);
		((GObject)Storeroom.PackNum).text = $"x{stock}";
		((GObject)Storeroom.Pack).data = text;
		((GObject)Storeroom.Pack).onClick.Set(new EventCallback1(OpenBox));
		Storeroom.State.SetSelectedIndex((stock > 0) ? 1 : 0);
	}

	private void OpenBox(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string text = ((GObject)context.sender).data.ToString();
		if (GameManagers.Instance.StockController.GetStock(text) <= 0)
		{
			return;
		}
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(text);
		if (Shift.Legion.Common.Models.Item.ItemType(text) == 29)
		{
			UseGvGStoreChest(text, 1);
		}
		else if (Shift.Legion.Common.Models.Item.ItemType(text) == 30)
		{
			List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, text);
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (Modifier item in list)
			{
				if (!(item.ModifierId == "Items"))
				{
					continue;
				}
				foreach (KeyValuePair<string, object> item2 in item.PayloadDictionary)
				{
					dictionary.Add(item2.Key, Convert.ToInt32(item2.Value));
				}
			}
			List<KeyValuePair<string, int>> list2 = dictionary.ToList();
			string identifier = ((list2.Count > 4) ? UI_TakeItems_Large.Name : UI_TakeItems.Name);
			GameController.Contexts.Service<IUiService>().OpenPanel(identifier, new Dictionary<string, object>
			{
				{
					"Name",
					SchemaIndexHelper.GetNameById(GameManagers.Instance, text) ?? ""
				},
				{ "ShowSelectedReward", true },
				{ "SelectItems", list2 },
				{
					"Parent",
					((GObject)this).parent
				},
				{ "SelectItemId", text }
			});
		}
		else
		{
			FGUIManager.Instance.ItemTip(text, 1, noCheckBtn: false, reserveRes: false, this, isPack: true);
		}
	}

	private void UseGvGStoreChest(string itemId, int useNum)
	{
		ILRequestHelper<UseItemResponse>.Request((EventContext)null, (Func<Task<UseItemResponse>>)(() => GameController.Contexts.Service<INetworkService>().UseItem(-1L, itemId, useNum, null)), (Action<UseItemResponse>)delegate(UseItemResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameManagers instance = GameManagers.Instance;
				List<Bonus> list = new List<Bonus>();
				string itemId2 = string.Empty;
				if (response.Bonuses != null)
				{
					foreach (ModelsBonus bonuse in response.Bonuses)
					{
						list.Add(Bonus.Get(bonuse.ItemId, bonuse.Qty, bonuse.Type, bonuse.IsShining));
						itemId2 = bonuse.ItemId;
					}
				}
				if (response.StockChangeRecords != null)
				{
					bool flag = false;
					string text = "";
					foreach (Bonus item in list)
					{
						if (item.ItemId.IndexOf("Unlock.") >= 0)
						{
							string text2 = item.ItemId.Replace("Unlock.", "");
							if (SchemaIndexHelper.GetSchemaById(text2) == "Soldier")
							{
								text = text2;
								flag = true;
							}
						}
					}
					if (flag)
					{
						for (int num = response.StockChangeRecords.Count - 1; num >= 0; num--)
						{
							if (response.StockChangeRecords[num].Offset > 0 && response.StockChangeRecords[num].ItemId == text)
							{
								response.StockChangeRecords.RemoveAt(num);
								break;
							}
						}
					}
					instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
					ILRequestHelper.ShowMessage(Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, itemId2) + "+1");
				}
			}
		});
	}

	private void OnClickSelectBox(int boxIndex)
	{
		if (_currentBoxIndex != boxIndex)
		{
			_currentBoxIndex = boxIndex;
			GameLocalDataManager.SetInt("IntKey_GvgStoreSelectStoneBoxIndex", boxIndex);
			Storeroom.changeStoneBox.Play();
			RenderCurrentBox(_currentBoxIndex);
			RefreshSelectStoneNote();
			HideSelectStonePop();
		}
	}

	private void InitShenJiStore()
	{
		if (!_hasAttendedAnyIzConfigId)
		{
			return;
		}
		Singleton<GvG3StoreManager>.Instance.GetGvGStoreGuaranteedItemsAsync(delegate(GetGvGStoreGuaranteedItemsResponse response)
		{
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected O, but got Unknown
			if (!((GObject)this).isDisposed)
			{
				RefreshSleepStateView();
				RefreshExchangeCouponProgress();
				RenderTicketIcon();
				shenJiStorePanel.Init(response.GuaranteedItemDict, new EventCallback0(UpdateTicketNumber));
			}
		}, forceRefresh: true);
	}

	private void RenderStoreroom(int stockLimit)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		storeroomItems = GetStoreroomItems(stockLimit, out var curStock);
		((GObject)Storeroom.ItemNum).text = $"{curStock}/{stockLimit}";
		Storeroom.Materials.itemRenderer = new ListItemRenderer(RenderStoreroomItem);
		Storeroom.Materials.numItems = storeroomItems.Count;
		RefreshStoneBox();
	}

	private void RenderStoreroomItem(int index, GObject obj)
	{
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		if (!(obj is UI_com_StoreroomItem uI_com_StoreroomItem))
		{
			return;
		}
		string text = storeroomItems[index];
		if (string.IsNullOrEmpty(text))
		{
			uI_com_StoreroomItem.Type.selectedIndex = 1;
		}
		else if (text == "Unlock")
		{
			uI_com_StoreroomItem.Type.selectedIndex = 2;
		}
		else
		{
			uI_com_StoreroomItem.Type.selectedIndex = 0;
			FGUIManager.Instance.SetItemIconAndFrame(uI_com_StoreroomItem.Icon, text, null, "", frameVisible: false);
		}
		if (!string.IsNullOrEmpty(text) && _bonusItems.ContainsKey(text) && _bonusItems[text] > 0)
		{
			uI_com_StoreroomItem.ShowIcon.Play();
			_bonusItems[text]--;
			if (_bonusItems[text] <= 0)
			{
				_bonusItems.Remove(text);
			}
		}
		((GObject)uI_com_StoreroomItem).data = text;
		((GObject)uI_com_StoreroomItem).onClick.Set(new EventCallback1(StoreroomItemClickEvent));
	}

	private List<string> GetStoreroomItems(int stockLimit, out int curStock)
	{
		List<string> list = new List<string>();
		for (int i = 0; i < _constMaterials.Length; i++)
		{
			string text = _constMaterials[i];
			int stock = GameManagers.Instance.StockController.GetStock(text);
			for (int j = 0; j < stock; j++)
			{
				list.Add(text);
			}
		}
		curStock = list.Count;
		int num = stockLimit - list.Count;
		if (num < 0)
		{
			num = 0;
		}
		for (int k = 0; k < num; k++)
		{
			list.Add(string.Empty);
		}
		int num2 = 30 - stockLimit;
		for (int l = 0; l < num2; l++)
		{
			list.Add("Unlock");
		}
		return list;
	}

	private void StoreroomItemClickEvent(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string text = ((GObject)context.sender).data.ToString();
		if (!string.IsNullOrEmpty(text))
		{
			if (text == "Unlock")
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GVGStoreUnlockStoreroomSlotPanel.Name, null);
			}
			else
			{
				FGUIManager.Instance.ItemTip(text, 1);
			}
		}
	}

	private void UpdateStoreItems(bool forceRefresh)
	{
		Singleton<GvG3StoreManager>.Instance.GetGvGStoreData(delegate(GvG3StoreManager.GvGStoreConfigData configData)
		{
			if (((GObject)StoreItems).alpha < 1f)
			{
				ChangeStoreItemsAlpha(1f);
			}
			RenderStoreItems(configData.Response);
		}, manual: false, forceRefresh);
	}

	private void OnClickShenJiBtn()
	{
		if (_hasAttendedAnyIzConfigId)
		{
			OpenShenJiPanel();
		}
	}

	public void OpenShenJiPanel()
	{
		if (State.selectedIndex != 2)
		{
			Singleton<GvG3StoreManager>.Instance.GetGvGStoreGuaranteedItemsAsync(delegate(GetGvGStoreGuaranteedItemsResponse response)
			{
				shenJiStorePanel.Display(response.TotalRefreshCount);
			});
			State.SetSelectedIndex(2);
			((GObject)shenJiStorePanel).visible = true;
			ShenJiShow.Play();
		}
	}

	private void CloseShenJiStorePanel()
	{
		int selectedIndex = ((_storeActive != StoreActivateMode.Sleep) ? 1 : 0);
		State.SetSelectedIndex(selectedIndex);
		ShenJiShow.PlayReverse();
	}

	private void UpdateTicketNumber()
	{
		((GObject)Ticket.Count).text = GameManagers.Instance.StockController.GetStock("I62201").ToString();
	}

	private void RenderTicketIcon()
	{
		FGUIManager.Instance.SetItemIconAndFrame(Ticket.Icon, "I62201", null, "", frameVisible: false);
	}

	private void OnClickExchangeCoupon()
	{
		int currentExchangeScore = Singleton<GvG3StoreManager>.Instance.CurrentExchangeScore;
		GvG3StoreManager.GuaranteedTicketConfig ticketConfig = Singleton<GvG3StoreManager>.Instance.TicketConfig;
		if (currentExchangeScore >= ticketConfig.RefreshCountCost)
		{
			ExchangeGvGStoreGuaranteedTicket();
		}
		else
		{
			"I62201".DisplayItemTip();
		}
	}

	private void ExchangeGvGStoreGuaranteedTicket()
	{
		Singleton<GvG3StoreManager>.Instance.ExchangeGvGStoreGuaranteedTicket(OnExchangeCompleted);
	}

	private void OnExchangeCompleted()
	{
		PlayExchange();
		UI_com_Effect01 effect = CreateEffect01AndInit();
		PlayMoveEffect(effect);
	}

	private void PlayExchange()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		if (ShenJiHeader.t0.playing)
		{
			ShenJiHeader.t0.Stop(true, true);
		}
		ShenJiHeader.t0.Play(new PlayCompleteCallback(RefreshExchangeCouponProgress));
	}

	private UI_com_Effect01 CreateEffect01AndInit()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		UI_com_Effect01 uI_com_Effect = UI_com_Effect01.CreateInstance_ILRuntime();
		((GComponent)UnityUiService.Instance.maskCover).AddChild((GObject)(object)uI_com_Effect);
		((GObject)uI_com_Effect).SetXY(ExchangeStartPos.x, ExchangeStartPos.y);
		return uI_com_Effect;
	}

	private void PlayMoveEffect(UI_com_Effect01 effect01)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		new ExchangeTicketEffectPlayer(effect01, ExchangeEndPos).Play();
	}

	private void OnClickActiveStore()
	{
		int stock = GameManagers.Instance.StockController.GetStock("I62200");
		if (stock <= 0)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("GvG3StoreManualActivateFailedTips") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 999, arg3: false);
			return;
		}
		int gvgStoreConfirmActivateDontShowAgainUntil = GameLocalDataManager.GetGvgStoreConfirmActivateDontShowAgainUntil();
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "HasRareItem", false },
			{ "FreeRefreshCount", 0 }
		};
		if (GameController.Instance.GetServerTime() >= gvgStoreConfirmActivateDontShowAgainUntil)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GVGStoreSilenceConfilmPanel.Name, parameters);
		}
		else
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GVGStoreRefreshConfirmPanel.Name, parameters);
		}
	}

	private void ChangeStoreItemsAlpha(float itemsAlpha)
	{
		((GObject)StoreItems).alpha = itemsAlpha;
		((GObject)StoreItems).touchable = itemsAlpha > 0f;
	}

	private void RefreshStoreItems(bool manual)
	{
		_playUpdateStoreItems = manual;
		Singleton<GvG3StoreManager>.Instance.GetGvGStoreData(delegate(GvG3StoreManager.GvGStoreConfigData configData)
		{
			if (_storeActive == StoreActivateMode.Sleep && manual)
			{
				_playUpdateStoreItems = false;
				InitGvgStore();
			}
			RenderStoreItems(configData.Response);
		}, manual, forceRefresh: true);
	}

	private void RefreshExchangeCouponProgress()
	{
		int currentExchangeScore = Singleton<GvG3StoreManager>.Instance.CurrentExchangeScore;
		GvG3StoreManager.GuaranteedTicketConfig ticketConfig = Singleton<GvG3StoreManager>.Instance.TicketConfig;
		((GObject)ShenJiHeader.scoreProgressText).text = $"{currentExchangeScore / 3}/{ticketConfig.RefreshCountCost / 3}";
		ShenJiHeader.scoreProgressBar.fillAmount = Mathf.Min(1f, (float)currentExchangeScore / (float)ticketConfig.RefreshCountCost);
		int stock = GameManagers.Instance.StockController.GetStock("I62201");
		bool flag = currentExchangeScore >= ticketConfig.RefreshCountCost;
		ShenJiHeader.State.SetSelectedIndex(flag ? 1 : 0);
		((GObject)shenJiBtn.shenJiEntranceNote).visible = stock > 0;
	}

	private void RefreshSleepStateView()
	{
		int stock = GameManagers.Instance.StockController.GetStock("I62200");
		bool flag = stock > 0;
		if (flag)
		{
			((GObject)couponSonsuemCount).text = $"{stock}/1";
		}
		else
		{
			((GObject)couponSonsuemCount).text = $"[color=#f70000]{stock}[/color]/1";
		}
		activateBtn.isGray.SetSelectedIndex((!flag) ? 1 : 0);
	}

	private void OnSystemClose(S2C_SystemIZOver.Request request)
	{
		SetStoreState(StoreActivateMode.Sleep);
		if (_updateCountDownCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_updateCountDownCoroutine);
		}
	}

	private void RenderStoreItems(GetGvGStoreItemsResponse itemsData)
	{
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		_storeItems.Clear();
		foreach (GvGStoreItem storeItem in itemsData.StoreItems)
		{
			_storeItems.Add(new StoreItem
			{
				ItemId = storeItem.FormulaId,
				Bought = storeItem.Purchased
			});
		}
		_nextUpdateStoreItemsTime = itemsData.NextUpdateTime;
		_freeRefreshCount = itemsData.RemainingFreeRefreshCount;
		FGUIManager.Instance.SetItemIconAndFrame(TicketIcon, "I62200", null, "", frameVisible: false);
		bool flag = _freeRefreshCount > 0;
		RefreshIsFree.SetSelectedIndex(flag ? 1 : 0);
		if (flag)
		{
			((GObject)FreeTicketNumber).text = _freeRefreshCount.ToString();
		}
		else
		{
			((GObject)TicketNumber).text = string.Format("{0}", GameManagers.Instance.StockController.GetStock("I62200"));
		}
		if (_updateCountDownCoroutine == null)
		{
			_updateCountDownCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateCountDown());
		}
		if (!_playUpdateStoreItems)
		{
			UpdateStoreItem();
			return;
		}
		((GObject)Refresh).touchable = false;
		StoreItems.t0.SetHook("Update", new TransitionHook(UpdateStoreItem));
		for (int i = 0; i < 3; i++)
		{
			int itemIndex = i;
			StoreItems.t0.SetHook($"StoreItemAppear{itemIndex}", (TransitionHook)delegate
			{
				ShowRareStoreItemAppear(itemIndex);
			});
		}
		StoreItems.t0.Play((PlayCompleteCallback)delegate
		{
			((GObject)Refresh).touchable = true;
		});
	}

	private void ShowRareStoreItemAppear(int index)
	{
		GObject child = ((GComponent)StoreItems).GetChild($"StoreItem{index}");
		UI_com_StoreItem storeItemBtn = child as UI_com_StoreItem;
		if (storeItemBtn != null)
		{
			PlayAppear();
		}
		void PlayAppear()
		{
			switch (storeItemBtn.Type.selectedIndex)
			{
			case 2:
				storeItemBtn.UltraRarePrizeSfxWrapper.PlayAppearParticleEffects();
				break;
			case 3:
				storeItemBtn.GrandPrizeSfxWrapper.PlayAppearParticleEffects();
				break;
			}
		}
	}

	private void UpdateStoreItem()
	{
		_hasRareStoreItem = false;
		for (int i = 0; i < 3; i++)
		{
			if (((GComponent)StoreItems).GetChild($"StoreItem{i}") is UI_com_StoreItem obj)
			{
				RenderStoreItem(i, (GObject)(object)obj);
			}
		}
		_playUpdateStoreItems = false;
	}

	private void RenderStoreItem(int index, GObject obj)
	{
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		UI_com_StoreItem storeItemBtn = obj as UI_com_StoreItem;
		if (storeItemBtn == null)
		{
			return;
		}
		if (_storeItems.Count <= index)
		{
			((GObject)storeItemBtn).visible = false;
			return;
		}
		((GObject)storeItemBtn).visible = true;
		StoreItem storeItem = _storeItems[index];
		Formula storeItemFormula = GameManagers.Instance.UserArchiveManager.GetStoreItemFormula(storeItem.ItemId);
		RenderStoreItemInput(storeItemBtn, storeItemFormula);
		KeyValuePair<string, int> keyValuePair = JsonHelper.ToObject<Dictionary<string, int>>(storeItemFormula.Output).ToList()[0];
		FGUIManager.Instance.SetItemIconAndFrame(storeItemBtn.StoreItemIcon, keyValuePair.Key, null, "", frameVisible: false);
		((GObject)storeItemBtn.StoreItemIcon).data = keyValuePair.Key;
		((GObject)storeItemBtn.StoreItemIcon).onClick.Set(new EventCallback1(ShowStoreItemInfo));
		((GObject)storeItemBtn.ItemName).text = Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, keyValuePair.Key);
		((GObject)storeItemBtn.ItemNum).text = keyValuePair.Value.ToString();
		storeItemBtn.Type.selectedIndex = storeItemFormula.Rarity;
		if (!_hasRareStoreItem)
		{
			_hasRareStoreItem = storeItemFormula.Rarity >= 2 && !storeItem.Bought;
		}
		RenderCardIdle();
		if (storeItem.Bought)
		{
			storeItemBtn.State.selectedIndex = 1;
		}
		else if (!storeItemFormula.CanUse())
		{
			storeItemBtn.State.selectedIndex = 2;
		}
		else
		{
			storeItemBtn.State.selectedIndex = 0;
		}
		((GObject)storeItemBtn.Buy).data = new ArchiveExtension_Formulas.ConfirmBuyStoreItem
		{
			Formula = storeItemFormula,
			ItemId = keyValuePair.Key,
			Index = index,
			ItemNum = keyValuePair.Value
		};
		((GObject)storeItemBtn.Buy).onClick.Set(new EventCallback1(BuyStoreItem));
		void RenderCardIdle()
		{
			switch (storeItemBtn.Type.selectedIndex)
			{
			case 2:
				storeItemBtn.UltraRarePrizeSfxWrapper.PlayIdleParticleEffects();
				break;
			case 3:
				storeItemBtn.GrandPrizeSfxWrapper.PlayIdleParticleEffects();
				break;
			}
		}
	}

	private void ShowStoreItemInfo(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string itemId = ((GObject)context.sender).data.ToString();
		if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 27)
		{
			ArchiveExtension_Formulas.GvGStoreItemInfo value = JsonHelper.ToObject<ArchiveExtension_Formulas.GvGStoreItemInfo>(Shift.Legion.Common.Models.Item.PostScript(itemId));
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemBlueprintTemplatePanel.Name, new Dictionary<string, object> { { "Info", value } });
		}
		else
		{
			FGUIManager.Instance.ItemTip(itemId, 1, noCheckBtn: true, reserveRes: false, this);
		}
	}

	private void RenderStoreItemInput(UI_com_StoreItem storeItemBtn, Formula formula)
	{
		List<string> inputList = formula.GetInputList();
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		List<StoreItemInput> list = new List<StoreItemInput>();
		for (int i = 0; i < inputList.Count; i++)
		{
			string text = inputList[i];
			if (!dictionary.ContainsKey(text))
			{
				dictionary.Add(text, GameManagers.Instance.StockController.GetStock(text));
			}
		}
		for (int j = 0; j < inputList.Count; j++)
		{
			StoreItemInput storeItemInput = new StoreItemInput
			{
				ItemId = inputList[j]
			};
			if (dictionary[storeItemInput.ItemId] <= 0)
			{
				storeItemInput.Type = 3;
			}
			else
			{
				storeItemInput.Type = 0;
				dictionary[storeItemInput.ItemId]--;
			}
			list.Add(storeItemInput);
		}
		storeItemBtn.Materials.RemoveChildrenToPool();
		for (int k = 0; k < list.Count; k++)
		{
			if (storeItemBtn.Materials.AddItemFromPool() is UI_com_StoreroomItem btn)
			{
				RenderStoreItemInputItem(btn, list[k]);
			}
		}
	}

	private void RenderStoreItemInputItem(UI_com_StoreroomItem btn, StoreItemInput inputItem)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		FGUIManager.Instance.SetItemIconAndFrame(btn.Icon, inputItem.ItemId, null, "", frameVisible: false);
		btn.Type.selectedIndex = inputItem.Type;
		btn.RenderRarity(inputItem.ItemId);
		((GObject)btn).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(inputItem.ItemId, 1, noCheckBtn: true);
		});
	}

	private IEnumerator UpdateCountDown()
	{
		string tipText = LanguagesManager.GetDesc("GvGStoreItemsRefreshCountDown");
		string tipText2 = LanguagesManager.GetDesc("GvG3StoreNoMoreAutoRefreshTip");
		string tipText3 = LanguagesManager.GetDesc("GvG3StoreManualActivateCountDownDes");
		WaitForSeconds wait = new WaitForSeconds(1f);
		while (!((GObject)this).isDisposed)
		{
			bool manual = _storeActive == StoreActivateMode.Manual;
			int time = (manual ? Singleton<GvG3StoreManager>.Instance.NotSilentTimestamp : _nextUpdateStoreItemsTime);
			string tipText4 = (manual ? tipText3 : tipText);
			if (time > 0)
			{
				int remaining = time - (int)GameController.Instance.GetServerTime();
				if (remaining <= 0)
				{
					UpdateStoreItems(forceRefresh: true);
				}
				((GObject)UpdateTime).text = string.Format(tipText4, new object[1] { UiHelper.ParseTimeChinsesDH(remaining) ?? "" });
			}
			else
			{
				long remainTime = Singleton<WorldStateManager>.Instance.Data.IZEndTimestamp - GameController.Instance.GetServerTime();
				((GObject)UpdateTime).text = string.Format(tipText2, UiHelper.ParseTimeChinsesDH((int)remainTime));
			}
			yield return wait;
		}
	}

	private void BuyStoreItem(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		ArchiveExtension_Formulas.ConfirmBuyStoreItem confirmBuyStoreItem = (ArchiveExtension_Formulas.ConfirmBuyStoreItem)((GObject)context.sender).data;
		if (confirmBuyStoreItem != null)
		{
			int gvgStoreConfirmBuyItemDontShowAgainUntil = GameLocalDataManager.GetGvgStoreConfirmBuyItemDontShowAgainUntil();
			if (_storeActive == StoreActivateMode.Manual && GameController.Instance.GetServerTime() >= gvgStoreConfirmBuyItemDontShowAgainUntil)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GVGStoreSilenceBuyConfirmPanel.Name, new Dictionary<string, object> { { "StoreItem", confirmBuyStoreItem } });
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GVGStoreBuyConfirmPanel.Name, new Dictionary<string, object> { { "StoreItem", confirmBuyStoreItem } });
			}
		}
	}

	private void ReplaceStoreItems()
	{
		int gvgStoreConfirmActivateDontShowAgainUntil = GameLocalDataManager.GetGvgStoreConfirmActivateDontShowAgainUntil();
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "HasRareItem", _hasRareStoreItem },
			{ "FreeRefreshCount", _freeRefreshCount },
			{
				"ReplaceTitle",
				LanguagesManager.GetDesc("GvGStoreRefreshOnManualActiveTips")
			},
			{
				"ReplaceDes",
				LanguagesManager.GetDesc("GvGStoreRefreshOnManualActiveDes")
			}
		};
		if (GameController.Instance.GetServerTime() >= gvgStoreConfirmActivateDontShowAgainUntil && _storeActive != StoreActivateMode.Ongoing)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GVGStoreSilenceConfilmPanel.Name, parameters);
		}
		else
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GVGStoreRefreshConfirmPanel.Name, parameters);
		}
	}
}
