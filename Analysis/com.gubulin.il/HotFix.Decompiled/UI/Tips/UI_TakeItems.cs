using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Entitas;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using GameMaths;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvGServer.Helper;
using Shift.Legion.Helpers;
using UI.GameActivity;
using UI.GiftBag;
using UI.LegendItemInfo;
using UI.MainCity;
using UI.PublicResources;
using UI.PvpSelectSoldiers;
using UI.SpecialActivity;
using UI.Warehouse;
using UnityEngine;

namespace UI.Tips;

public class UI_TakeItems : GComponent, IUiController, IAnyBattleWaveTimeLeftListener
{
	public Controller PageController;

	public Controller NestingGiftBagType;

	public GGraph mask;

	public GImage n62;

	public GImage n63;

	public GGroup n69;

	public GImage n68;

	public GImage n67;

	public GMovieClip CommonBox;

	public GMovieClip AdvancedBox;

	public GGroup n59;

	public GMovieClip AdvancedBox2;

	public GGraph shiningSfxBack;

	public UI_TakeContent Content;

	public GGraph openSfxBack;

	public GGroup mainGroup;

	public GImage boxIcon;

	public GGraph missibleSfxBack;

	public GGraph missbleEndPos;

	public GImage n66;

	public UI_newCommerSpeicalFlyAnim newCommerAnim;

	public Transition showUp;

	public Transition fade;

	public Transition LightEffect;

	public const string URL = "ui://47lbpgx9z4ur1n";

	public static string Name = "UI_TakeItems";

	private const string NewComerSpecialItemId = "I69021";

	private int NestingGiftBagTypeIndex;

	private bool _isNewCommerSpecial;

	private bool _isNewCommerSpecialWithoutItem;

	public static UI_TakeItems TakeItemsPanel;

	private List<Bonus> _items;

	private List<KeyValuePair<string, int>> _selectItems;

	private List<Bonus> _resultBonuses;

	private StoreItem giftBag;

	private ProductLocalInfo giftBagProductLocalInfo;

	private int purchaseLimit;

	private List<string> _textureList = new List<string>();

	private int rarity;

	private GMovieClip boxClip;

	private bool CanBuy;

	private bool ShowReward = false;

	private bool AutoBuy = false;

	private bool DoubleCheckToBuy = false;

	private bool ShowBoxReward = false;

	private bool ShowSelecledReward = false;

	private string openBoxSound;

	private IUiController parent;

	private UI_GiftBagPanel giftBagPanel;

	private UI_SpecialActivityPanel specialActivityPanel;

	private UI_ActivityPanel activityPanel;

	private UI_WarehousePanel warehousePanel;

	private GameStateEntity _gameStateEntity;

	private string selectItemId;

	private UI_ItemBtnSpecial selectedItem;

	private int CurrentPrice;

	private int OriginalPrice;

	private string UseCurrency;

	private string _missileEndTag;

	private Action _extraConfirmAction;

	private bool items_has_UnlockItem = false;

	private string UseBoxItemId = null;

	private int UseBoxItemCount;

	private bool IsItemUsed;

	private CustomTaskCompletionSource<bool> taskCompletionSource;

	private UI_newCommerSpecialIcon _specialIcon;

	public static string GetURL()
	{
		return "ui://47lbpgx9z4ur1n";
	}

	public static UI_TakeItems CreateInstance()
	{
		return (UI_TakeItems)(object)UIPackage.CreateObject("Tips", "TakeItems");
	}

	public static UI_TakeItems CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TakeItems).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9z4ur1n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		NestingGiftBagType = ((GComponent)this).GetController("NestingGiftBagType");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		n62 = (GImage)((GComponent)this).GetChild("n62");
		n63 = (GImage)((GComponent)this).GetChild("n63");
		n69 = (GGroup)((GComponent)this).GetChild("n69");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		n67 = (GImage)((GComponent)this).GetChild("n67");
		CommonBox = (GMovieClip)((GComponent)this).GetChild("CommonBox");
		AdvancedBox = (GMovieClip)((GComponent)this).GetChild("AdvancedBox");
		n59 = (GGroup)((GComponent)this).GetChild("n59");
		AdvancedBox2 = (GMovieClip)((GComponent)this).GetChild("AdvancedBox2");
		shiningSfxBack = (GGraph)((GComponent)this).GetChild("shiningSfxBack");
		Content = (UI_TakeContent)(object)((GComponent)this).GetChild("Content");
		openSfxBack = (GGraph)((GComponent)this).GetChild("openSfxBack");
		mainGroup = (GGroup)((GComponent)this).GetChild("mainGroup");
		boxIcon = (GImage)((GComponent)this).GetChild("boxIcon");
		missibleSfxBack = (GGraph)((GComponent)this).GetChild("missibleSfxBack");
		missbleEndPos = (GGraph)((GComponent)this).GetChild("missbleEndPos");
		n66 = (GImage)((GComponent)this).GetChild("n66");
		newCommerAnim = (UI_newCommerSpeicalFlyAnim)(object)((GComponent)this).GetChild("newCommerAnim");
		showUp = ((GComponent)this).GetTransition("showUp");
		fade = ((GComponent)this).GetTransition("fade");
		LightEffect = ((GComponent)this).GetTransition("LightEffect");
	}

	public void RegisterUiEventListeners()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		_gameStateEntity = ((Context<GameStateEntity>)GameController.Contexts.gameState).CreateEntity();
		_gameStateEntity.AddAnyBattleWaveTimeLeftListener(this);
		((GObject)Content.ConfirmTakeBtn).onClick.Add(new EventCallback0(ConfirmTakeClick));
		((GObject)Content.ConfirmBuyBtn).onClick.Add(new EventCallback0(ConfirmBuyClick));
		((GObject)Content.ConfirmSelectBtn).onClick.Add(new EventCallback0(ReceiveSelectedReward));
		((GObject)Content.ConfirmBtn).onClick.Add(new EventCallback1(OnClickConfirmBtn));
		((GObject)Content.increaseBtn).onClick.Add(new EventCallback0(IncreaseCompoundNum));
		((GObject)Content.reduceBtn).onClick.Add(new EventCallback0(ReduceCompoundNum));
		((GObject)Content.MaxValueBtn).onClick.Add(new EventCallback0(CompoundSoulStoneMaxEvent));
		Content.ItemsCounter.RegisterUiEventListeners();
		Content.ItemsCounter.OnChange = OnChangeBuyCount;
		SharedMessenger.AddListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
		UiTagManager.Instance.Register("MainCity.RechargeActivityBtn", newCommerAnim.flyEndPos);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		_gameStateEntity.RemoveAnyBattleWaveTimeLeftListener(this);
		((GObject)Content.ConfirmTakeBtn).onClick.Remove(new EventCallback0(ConfirmTakeClick));
		((GObject)Content.ConfirmBuyBtn).onClick.Remove(new EventCallback0(ConfirmBuyClick));
		((GObject)Content.ConfirmSelectBtn).onClick.Remove(new EventCallback0(ReceiveSelectedReward));
		((GObject)Content.ConfirmBtn).onClick.Remove(new EventCallback1(OnClickConfirmBtn));
		((GObject)Content.increaseBtn).onClick.Remove(new EventCallback0(IncreaseCompoundNum));
		((GObject)Content.reduceBtn).onClick.Remove(new EventCallback0(ReduceCompoundNum));
		((GObject)Content.MaxValueBtn).onClick.Remove(new EventCallback0(CompoundSoulStoneMaxEvent));
		Content.ItemsCounter.UnregisterUiEventListeners();
		SharedMessenger.RemoveListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
		UiTagManager.Instance.Unregister("MainCity.RechargeActivityBtn", newCommerAnim.flyEndPos);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_071c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0726: Expected O, but got Unknown
		//IL_087f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0889: Expected O, but got Unknown
		//IL_0918: Unknown result type (might be due to invalid IL or missing references)
		//IL_0922: Expected O, but got Unknown
		//IL_0a99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa3: Expected O, but got Unknown
		_isNewCommerSpecial = false;
		items_has_UnlockItem = false;
		Content.ItemsCounter.Init("");
		LightEffect.invalidateBatchingEveryFrame = true;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)newCommerAnim).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		((GObject)this).sortingOrder = 100;
		TakeItemsPanel = this;
		if (parameters.TryGetValue("UseBoxItemCount", out var value))
		{
			UseBoxItemCount = (int)value;
		}
		if (parameters.TryGetValue("UseBoxItemId", out var value2))
		{
			InitUseBoxItem(value2.ToString(), parameters);
		}
		if (parameters.TryGetValue("MissileEndTag", out var value3))
		{
			_missileEndTag = value3.ToString();
		}
		if (parameters.TryGetValue("taskCompletionSource", out var value4))
		{
			taskCompletionSource = (CustomTaskCompletionSource<bool>)value4;
		}
		if (parameters.TryGetValue("NestingGiftBagType", out var value5))
		{
			NestingGiftBagTypeIndex = (int)value5;
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode3() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode4() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode7() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode3() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode4() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode6())
			{
				_isNewCommerSpecial = NestingGiftBagTypeIndex == 1;
				_isNewCommerSpecialWithoutItem = _isNewCommerSpecial && GameManagers.Instance.StockController.GetStock(UseBoxItemId) < UseBoxItemCount;
			}
			NestingGiftBagType.SetSelectedIndex(NestingGiftBagTypeIndex);
			Content.NestingGiftBagType.SetSelectedIndex(NestingGiftBagTypeIndex);
		}
		if (parameters.TryGetValue("NestingGiftBagTitle", out var value6))
		{
			((GObject)Content.NestingGiftBagTitle).text = LanguagesManager.GetDesc((string)value6);
		}
		if (parameters.ContainsKey("Items"))
		{
			List<Bonus> items = (List<Bonus>)parameters["Items"];
			_items = items;
			foreach (Bonus item in _items)
			{
				if (item.ItemId.IndexOf("Unlock.") >= 0)
				{
					items_has_UnlockItem = true;
				}
				else if (item.ItemId.IndexOf("PotentialLevel.") >= 0)
				{
					items_has_UnlockItem = true;
				}
			}
		}
		else if (parameters.ContainsKey("GiftBag"))
		{
			giftBag = (StoreItem)parameters["GiftBag"];
			List<Bonus> list = new List<Bonus>();
			foreach (KeyValuePair<string, int> item2 in giftBag.Content)
			{
				list.Add(Bonus.Get(item2.Key, item2.Value));
			}
			_items = list;
			if (giftBag != null && !string.IsNullOrEmpty(giftBag.ReferenceId) && PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(giftBag.ReferenceId, out var value7))
			{
				giftBagProductLocalInfo = value7;
			}
		}
		else if (parameters.ContainsKey("SelectItems"))
		{
			_selectItems = (List<KeyValuePair<string, int>>)parameters["SelectItems"];
		}
		else
		{
			End();
		}
		if (parameters.ContainsKey("UseCurrency"))
		{
			UseCurrency = (string)parameters["UseCurrency"];
		}
		if (parameters.ContainsKey("Parent"))
		{
			parent = (IUiController)parameters["Parent"];
			if (parent is UI_GiftBagPanel)
			{
				giftBagPanel = (UI_GiftBagPanel)parent;
				ThinkingDataHelper.Instance.PayPreviewTrack(giftBag.StoreItemId);
				ThinkingDataHelper.Instance.TimeEvent("nopay_preview");
			}
			else if (parent is UI_SpecialActivityPanel)
			{
				specialActivityPanel = (UI_SpecialActivityPanel)parent;
				ThinkingDataHelper.Instance.PayPreviewTrack(giftBag.StoreItemId);
				ThinkingDataHelper.Instance.TimeEvent("nopay_preview");
			}
			else if (parent is UI_ActivityPanel)
			{
				activityPanel = (UI_ActivityPanel)parent;
			}
			else if (parent is UI_WarehousePanel)
			{
				warehousePanel = (UI_WarehousePanel)parent;
			}
		}
		string text = (string)parameters["Name"];
		((GObject)Content.name).text = text;
		object value10;
		if (parameters.TryGetValue("Show", out var value8))
		{
			ShowReward = (bool)value8;
			CanBuy = false;
		}
		else if (parameters.TryGetValue("ShowBox", out value8))
		{
			ShowBoxReward = (bool)value8;
			CanBuy = false;
			if (parameters.TryGetValue("ResultList", out var value9))
			{
				_resultBonuses = new List<Bonus>();
				foreach (Bonus item3 in (List<Bonus>)value9)
				{
					_resultBonuses.Add(item3);
				}
			}
			else
			{
				End();
			}
		}
		else if (parameters.TryGetValue("ShowSelectedReward", out value10))
		{
			ShowSelecledReward = (bool)value10;
			CanBuy = false;
			if (parameters.TryGetValue("SelectItemId", out var value11))
			{
				selectItemId = (string)value11;
			}
			((GObject)Content.ConfirmBtn).enabled = false;
			((GObject)Content.compoundNum).text = 1.ToString();
			((GObject)Content.compoundNum).data = 1;
			((GObject)Content.MaxValueBtn).data = GetStockCount(selectItemId);
			((GObject)mask).onClick.Add(new EventCallback0(ReceiveSelectedReward));
			if (parameters.TryGetValue("NoClose", out var value12) && (bool)value12)
			{
				((GObject)mask).touchable = false;
			}
		}
		if (parameters.TryGetValue("AutoBuy", out var value13))
		{
			AutoBuy = (bool)value13;
		}
		if (parameters.TryGetValue("CanBuy", out var value14))
		{
			CanBuy = (bool)value14;
		}
		else
		{
			CanBuy = false;
		}
		((GObject)Content.Help).visible = false;
		if (!CanBuy)
		{
			Content.OperationPageController.selectedIndex = 0;
			Content.Price.DiscountPageController.selectedIndex = 0;
			rarity = 2;
		}
		else
		{
			Content.OperationPageController.selectedIndex = 1;
			if (parameters.TryGetValue("IsBatchPurchaseMode", out var value15) && (bool)value15)
			{
				Content.OperationPageController.selectedIndex = 6;
			}
			Content.ItemsCounter.Init(LanguagesManager.GetDesc("CsharpCodeZhTcText609"));
			((GObject)mask).onClick.Add(new EventCallback0(End));
			rarity = 2;
			((GObject)mask).alpha = 0.8f;
			purchaseLimit = giftBag.PurchaseLimit;
			if (parameters.TryGetValue("PurchaseLimit", out var value16))
			{
				purchaseLimit = (int)value16;
			}
			if (parameters.TryGetValue("PurchaseLimitTips", out var purchaseLimitTips))
			{
				((GObject)Content.Help).visible = true;
				((GObject)Content.Help).onClick.Set((EventCallback1)delegate(EventContext context)
				{
					//IL_000e: Unknown result type (might be due to invalid IL or missing references)
					//IL_0014: Expected O, but got Unknown
					//IL_0037: Unknown result type (might be due to invalid IL or missing references)
					//IL_003d: Unknown result type (might be due to invalid IL or missing references)
					context.StopPropagation();
					GObject target = (GObject)context.sender;
					FairyGUITip.ShowTip(target, eFairyGUITipDir.Down, delegate(UI_com_UniversalPopupTip popup)
					{
						((GObject)popup.title).text = $"{purchaseLimitTips}";
					});
				});
			}
		}
		if (parameters.TryGetValue("DoubleCheckToBuy", out var value17))
		{
			DoubleCheckToBuy = (bool)value17;
		}
		if (ShowReward)
		{
			PageController.selectedIndex = 1;
			Content.OperationPageController.selectedIndex = 2;
			rarity = 1;
		}
		else
		{
			PageController.selectedIndex = 0;
		}
		if (ShowSelecledReward)
		{
			Content.OperationPageController.selectedIndex = 4;
		}
		openBoxSound = "OpenBox";
		if (NestingGiftBagTypeIndex == 2)
		{
			boxClip = AdvancedBox2;
		}
		else if (rarity > 1)
		{
			((GObject)AdvancedBox).visible = true;
			boxClip = AdvancedBox;
			((GObject)CommonBox).visible = false;
		}
		else
		{
			((GObject)CommonBox).visible = true;
			boxClip = CommonBox;
			((GObject)AdvancedBox).visible = false;
		}
		((GObject)shiningSfxBack).y = 535f;
		((GObject)openSfxBack).y = 250f;
		if (ShowReward)
		{
			((GObject)boxClip).visible = false;
		}
		if (!CanBuy)
		{
			((GObject)this).TweenFade(((GObject)this).alpha, 0.25f).OnComplete((GTweenCallback)delegate
			{
				PlayOpenSfx();
			});
		}
		else
		{
			boxClip.playing = false;
			boxClip.frame = 3;
			((GObject)Content).alpha = 1f;
			OnContentShow();
		}
		if (_isNewCommerSpecial)
		{
			GList materialList = Content.materialList;
			((GObject)materialList).y = ((GObject)materialList).y + 20f;
		}
		if (parameters.TryGetValue("ConfirmBtnTitle", out var value18))
		{
			((GObject)Content.ConfirmTakeBtn).icon = value18.ToString();
		}
		if (parameters.TryGetValue("ConfirmAction", out var value19))
		{
			_extraConfirmAction = (Action)value19;
		}
	}

	private static int GetStockCount(string itemId)
	{
		if (StorehouseHelper.IsGvGItem(itemId))
		{
			return Singleton<GvGStoreHouseManager>.Instance.GetItemCount(itemId);
		}
		return GameManagers.Instance.StockController.GetStock(itemId);
	}

	private void InitUseBoxItem(string itemId, Dictionary<string, object> parameters)
	{
		UseBoxItemId = itemId;
		List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, itemId);
		if (Shift.Legion.Common.Models.Item.ItemType(UseBoxItemId) != 11 || list == null)
		{
			return;
		}
		foreach (Modifier item in list)
		{
			if (item.ModifierId == "UIParams")
			{
				foreach (KeyValuePair<string, object> item2 in item.PayloadDictionary)
				{
					if (!parameters.ContainsKey(item2.Key))
					{
						parameters.Add(item2.Key, item2.Value);
					}
				}
			}
			if (!(item.ModifierId == "Bonus"))
			{
				continue;
			}
			List<Bonus> list2 = new List<Bonus>();
			foreach (KeyValuePair<string, object> item3 in item.PayloadDictionary)
			{
				list2.Add(Bonus.Get(item3.Key, item3.Value));
			}
			parameters["Items"] = list2;
		}
		parameters["Name"] = SchemaIndexHelper.GetNameById(GameManagers.Instance, UseBoxItemId);
	}

	public void OnShow()
	{
		if (AutoBuy)
		{
			((GObject)mainGroup).visible = false;
			((GObject)Content.ConfirmBuyBtn).onClick.Call();
			return;
		}
		if (_items != null)
		{
			UpdatePanel();
		}
		if (_selectItems != null)
		{
			UpdatePanel();
		}
		((GObject)mask).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		Content.ItemsCounter.SetButtonTitle();
	}

	public void BeforeDestroy()
	{
		for (int i = 0; i < _textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(_textureList[i]);
		}
		TakeItemsPanel = null;
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("TakeItems.ClaimBtn", Content.ConfirmTakeBtn);
		instance.Unregister("TakeItems.BuyBtn", Content.ConfirmBuyBtn);
	}

	public void OnContentShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("TakeItems.ClaimBtn", Content.ConfirmTakeBtn);
		instance.Register("TakeItems.BuyBtn", Content.ConfirmBuyBtn);
	}

	private void DisplayClaimMissileSfx()
	{
		if (!_isNewCommerSpecial)
		{
			PlayMissileSfx();
		}
		else
		{
			PlayNewComerSpecialAnim();
		}
	}

	private void PlayMissileSfx()
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		if (!((GObject)this).isDisposed)
		{
			LightEffect.Stop();
			((GObject)mainGroup).visible = false;
			if (!((GObject)shiningSfxBack).displayObject.isDisposed)
			{
				((GObject)shiningSfxBack).displayObject.Dispose();
			}
			((GObject)missibleSfxBack).SetPivot(0.5f, 0.5f, true);
			FGUIManager.Instance.AddTextSpecialEffects(missibleSfxBack, "exp_missile_green", Vector3.zero);
			((GObject)missibleSfxBack).TweenMove(((GObject)missbleEndPos).xy, 0.5f);
			UiAudioManager.Instance.PlaySoundEffect("Missile");
			((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
			{
				End();
			});
		}
	}

	private void PlayNewComerSpecialAnim()
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		if (((GObject)this).isDisposed)
		{
			return;
		}
		if (_items != null && !_isNewCommerSpecialWithoutItem)
		{
			foreach (Bonus item in _items)
			{
				ILRequestHelper.ShowMessage($"{Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, item.ItemId)}+{item.Qty}");
			}
		}
		LightEffect.Stop();
		Vector2 val = ((GObject)_specialIcon).LocalToGlobal(Vector2.zero);
		UI_newCommerSpecialIcon animIcon = newCommerAnim.animIcon;
		((GObject)animIcon).position = Vector2.op_Implicit(((GObject)newCommerAnim).GlobalToLocal(val) + ((GObject)_specialIcon).size * 0.5f);
		((GObject)newCommerAnim.n17).position = ((GObject)animIcon).position;
		UI_MainCity mainCity = (UI_MainCity)(object)UnityUiService.Instance.GetShowingUi(UI_MainCity.Name);
		((GObject)mainCity.RechargeActivityBtn).visible = false;
		((GObject)newCommerAnim).visible = true;
		((GObject)mainGroup).visible = false;
		Content.OperationPageController.SetSelectedIndex(7);
		_specialIcon.Status.SetSelectedIndex(2);
		newCommerAnim.showIcon.SetSelectedIndex(0);
		animIcon.Status.SetSelectedIndex(0);
		GTweenCallback val2 = default(GTweenCallback);
		PlayCompleteCallback val5 = default(PlayCompleteCallback);
		GTweenCallback val8 = default(GTweenCallback);
		EventCallback0 val11 = default(EventCallback0);
		newCommerAnim.t2.Play((PlayCompleteCallback)delegate
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_004c: Expected O, but got Unknown
			animIcon.Status.SetSelectedIndex(1);
			GTweener obj = ((GObject)animIcon).TweenFade(((GObject)animIcon).alpha, 0.7f);
			GTweenCallback obj2 = val2;
			if (obj2 == null)
			{
				GTweenCallback val3 = delegate
				{
					//IL_0023: Unknown result type (might be due to invalid IL or missing references)
					//IL_0028: Unknown result type (might be due to invalid IL or missing references)
					//IL_002a: Expected O, but got Unknown
					//IL_002f: Expected O, but got Unknown
					Transition t = newCommerAnim.t3;
					PlayCompleteCallback obj3 = val5;
					if (obj3 == null)
					{
						PlayCompleteCallback val6 = delegate
						{
							//IL_000c: Unknown result type (might be due to invalid IL or missing references)
							//IL_0032: Unknown result type (might be due to invalid IL or missing references)
							//IL_0037: Unknown result type (might be due to invalid IL or missing references)
							//IL_0058: Unknown result type (might be due to invalid IL or missing references)
							//IL_005d: Unknown result type (might be due to invalid IL or missing references)
							//IL_005f: Expected O, but got Unknown
							//IL_0064: Expected O, but got Unknown
							((GObject)animIcon.n2).TweenScale(Vector2.one, 0.6f);
							GTweener obj4 = ((GObject)animIcon).TweenMove(Vector2.op_Implicit(((GObject)newCommerAnim.flyEndPos).position), 0.6f);
							GTweenCallback obj5 = val8;
							if (obj5 == null)
							{
								GTweenCallback val9 = delegate
								{
									//IL_0062: Unknown result type (might be due to invalid IL or missing references)
									//IL_0067: Unknown result type (might be due to invalid IL or missing references)
									//IL_0069: Expected O, but got Unknown
									//IL_006e: Expected O, but got Unknown
									newCommerAnim.t4.Play();
									((GObject)animIcon).visible = false;
									newCommerAnim.showIcon.SetSelectedIndex(1);
									EventListener onClick = ((GObject)newCommerAnim.flyEndPos).onClick;
									EventCallback0 obj6 = val11;
									if (obj6 == null)
									{
										EventCallback0 val12 = delegate
										{
											((GObject)mainCity.RechargeActivityBtn).visible = true;
											mainCity.OpenRechargeActivityWithTabId();
											End();
										};
										EventCallback0 val13 = val12;
										val11 = val12;
										obj6 = val13;
									}
									onClick.Set(obj6);
								};
								GTweenCallback val10 = val9;
								val8 = val9;
								obj5 = val10;
							}
							obj4.OnComplete(obj5);
						};
						PlayCompleteCallback val7 = val6;
						val5 = val6;
						obj3 = val7;
					}
					t.Play(obj3);
				};
				GTweenCallback val4 = val3;
				val2 = val3;
				obj2 = val4;
			}
			obj.OnComplete(obj2);
		});
	}

	private void OnChangeBuyCount()
	{
		((GObject)Content.Price.originalPrice).text = $"{OriginalPrice * Content.ItemsCounter.Value}";
		((GObject)Content.Price.currentPrice).text = $"{CurrentPrice * Content.ItemsCounter.Value}";
	}

	public void UpdatePanel()
	{
		RenderMaterialList(ShowSelecledReward ? _selectItems.Count : _items.Count);
		if (!CanBuy)
		{
			return;
		}
		if (giftBag.IsPassedFilters && !giftBag.IsSoldOut && giftBag.IsKickedOff && !giftBag.IsExpired)
		{
			((GObject)Content.ConfirmBuyBtn).grayed = false;
			((GObject)Content.ConfirmBuyBtn).enabled = true;
		}
		else
		{
			((GObject)Content.ConfirmBuyBtn).grayed = true;
			((GObject)Content.ConfirmBuyBtn).enabled = false;
		}
		KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(giftBag);
		Dictionary<string, float> dictionary = giftBag.OriginPrice.First();
		string key = priceItemId.Key;
		CurrentPrice = Convert.ToInt32(priceItemId.Value * (float)Content.ItemsCounter.Value);
		OriginalPrice = Convert.ToInt32(dictionary.Values.First() * (float)Content.ItemsCounter.Value);
		string text = $"{OriginalPrice}";
		string text2 = $"{CurrentPrice}";
		bool flag = key == "RMB";
		bool flag2 = true;
		ProductLocalInfo value = null;
		if (HotUpdateProcess.Instance.IsRegionOutCN && flag)
		{
			((GObject)Content.Price.priceGroup).visible = false;
			((GObject)Content.Price.priceGroupIntl).visible = true;
			if (!string.IsNullOrEmpty(giftBag.ReferenceId) && PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(giftBag.ReferenceId, out value))
			{
				float num = value.Price * (float)Content.ItemsCounter.Value;
				if (num > 0f)
				{
					text2 = $"{value.CurrencySymbol}{num:F2}";
				}
				else
				{
					flag2 = false;
					text2 = LanguagesManager.GetDesc("CsharpCodeTextPriceFree");
				}
				float num2 = value.Price * (float)Content.ItemsCounter.Value / giftBag.InternationalDiscount;
				text = ((!(num2 > 0f)) ? LanguagesManager.GetDesc("CsharpCodeTextPriceFree") : $"{value.CurrencySymbol}{num2:F2}");
			}
			else
			{
				flag2 = false;
				text2 = "--";
				text = "--";
				if (string.IsNullOrEmpty(giftBag.ReferenceId) && priceItemId.Value <= 0f)
				{
					text2 = LanguagesManager.GetDesc("CsharpCodeTextPriceFree");
				}
			}
		}
		else
		{
			((GObject)Content.Price.priceGroup).visible = true;
			((GObject)Content.Price.priceGroupIntl).visible = false;
		}
		((GObject)Content.Price.originalPrice).text = text;
		((GObject)Content.Price.currentPrice).text = text2;
		if (giftBag.IsFree)
		{
			Content.Price.DiscountPageController.selectedIndex = (flag2 ? 1 : 0);
			((GObject)Content.Price.currentPriceTitle).text = LanguagesManager.GetDesc("CsharpCodeZhTcText610");
			Content.Price.currentCurrencyIcon.url = "ui://PublicResources/" + key;
			Content.Price.originalCurrencyIcon.url = "ui://PublicResources/" + key;
			((GObject)Content.Price.curIntlPriceText).text = LanguagesManager.GetDesc("CsharpCodeTextPriceFree");
		}
		else if (Mathf.Abs(giftBag.Discount - 1f) > float.Epsilon && giftBag.Discount > float.Epsilon)
		{
			Content.Price.DiscountPageController.selectedIndex = (flag2 ? 1 : 0);
			((GObject)Content.Price.currentPriceTitle).text = LanguagesManager.GetDesc("CsharpCodeZhTcText610");
			Content.Price.currentCurrencyIcon.url = "ui://PublicResources/" + key;
			Content.Price.originalCurrencyIcon.url = "ui://PublicResources/" + key;
			((GObject)Content.Price.curIntlPriceText).text = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText956"), text2);
			((GObject)Content.Price.originIntlPriceText).text = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText955"), text);
		}
		else
		{
			Content.Price.DiscountPageController.selectedIndex = 0;
			((GObject)Content.Price.currentPriceTitle).text = LanguagesManager.GetDesc("CsharpCodeZhTcText611");
			Content.Price.currentCurrencyIcon.url = "ui://PublicResources/" + key;
			((GObject)Content.Price.curIntlPriceText).text = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText957"), text2);
		}
		UiHelper.SetStoreItemDiscount(giftBag, Content.DiscountCom, ribbonVisible: true);
		int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(giftBag.StoreItemId);
		if (purchaseLimit != 0 && giftBag.ExpireTimestamp > 0)
		{
			((GObject)Content.BuyLimitGroup).visible = true;
			((GObject)Content.TimeLimitGroup).visible = true;
			Content.HelpType.selectedIndex = 1;
			string goodsPurchaseLimitTitle = FGUIManager.Instance.GetGoodsPurchaseLimitTitle(giftBag.PurchaseLimitPeriod);
			Content.ItemsCounter.MaxValue = purchaseLimit - purchaseCntAtLimitPeriod;
			((GObject)Content.BuyLimitTitle).text = goodsPurchaseLimitTitle ?? "";
			((GObject)Content.BuyLimit).text = $"{purchaseLimit - purchaseCntAtLimitPeriod}/{purchaseLimit}";
			int value2 = giftBag.ExpireTimestamp - (int)GameController.Instance.GetServerTime();
			((GObject)Content.TimeLimitTitle).text = LanguagesManager.GetDesc("CsharpCodeZhTcText612");
			((GObject)Content.TimeLimit).text = UiHelper.ParseTime(Convert.ToInt32(value2)) ?? "";
		}
		else if (purchaseLimit == 0 && giftBag.ExpireTimestamp > 0)
		{
			((GObject)Content.BuyLimitGroup).visible = false;
			((GObject)Content.TimeLimitGroup).visible = true;
			int value3 = giftBag.ExpireTimestamp - (int)GameController.Instance.GetServerTime();
			((GObject)Content.TimeLimitTitle).text = LanguagesManager.GetDesc("CsharpCodeZhTcText612");
			((GObject)Content.TimeLimit).text = UiHelper.ParseTime(Convert.ToInt32(value3)) ?? "";
		}
		else if (purchaseLimit != 0 && giftBag.ExpireTimestamp <= 0)
		{
			((GObject)Content.BuyLimitGroup).visible = false;
			((GObject)Content.TimeLimitGroup).visible = true;
			Content.HelpType.selectedIndex = 0;
			string goodsPurchaseLimitTitle2 = FGUIManager.Instance.GetGoodsPurchaseLimitTitle(giftBag.PurchaseLimitPeriod);
			Content.ItemsCounter.MaxValue = purchaseLimit - purchaseCntAtLimitPeriod;
			((GObject)Content.TimeLimitTitle).text = goodsPurchaseLimitTitle2 ?? "";
			((GObject)Content.TimeLimit).text = $"{purchaseLimit - purchaseCntAtLimitPeriod}/{purchaseLimit}";
		}
		else
		{
			((GObject)Content.BuyLimitGroup).visible = false;
			((GObject)Content.TimeLimitGroup).visible = false;
		}
	}

	private void MaterialListItemRender(int index, GObject obj)
	{
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected O, but got Unknown
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b1: Expected O, but got Unknown
		//IL_0597: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a1: Expected O, but got Unknown
		GComponent asCom = ((GComponent)obj.asButton).GetChild("Content").asCom;
		int num = (ShowSelecledReward ? _selectItems.Count : _items.Count);
		if (index >= num)
		{
			return;
		}
		int num2 = (ShowSelecledReward ? (_selectItems[index].Value * (int)((GObject)Content.compoundNum).data) : _items[index].Qty);
		string itemId = (ShowSelecledReward ? _selectItems[index].Key : _items[index].ItemId);
		if (itemId == "Unlock.H001")
		{
			GLoader asLoader = asCom.GetChild("icon").asLoader;
			asLoader.url = "ui://PublicResources/com_SeniorKuangKuang";
		}
		else if (_items == null)
		{
			FGUIManager.Instance.SetItemIconAndFrame(asCom.GetChild("icon").asLoader, itemId, _textureList);
		}
		else
		{
			FGUIManager.Instance.SetItemIconAndFrame(asCom.GetChild("icon").asLoader, itemId, _textureList, "", frameVisible: true, 1f, _items[index]);
		}
		itemId = FGUIManager.Instance.CutItemIdPrefix(itemId, out var prefix);
		if (prefix == "Unlock" || prefix == "PotentialLevel")
		{
			asCom.GetChild("num").text = "";
		}
		else
		{
			asCom.GetChild("num").text = $"x{num2}";
		}
		asCom.GetChild("num").data = (ShowSelecledReward ? _selectItems[index].Value : _items[index].Qty);
		asCom.GetChild("title").text = SchemaIndexHelper.GetNameByIdWithLineBreak(GameManagers.Instance, itemId);
		if (GameManagers.Instance.ModifierManager.GetPercentFloatPayload("UserExpGain") > 0f && itemId == "UserExp")
		{
			asCom.GetChild("num").text = string.Format("x{0}", Convert.ToInt32((float)num2 * (1f + GameManagers.Instance.ModifierManager.GetPercentFloatPayload("UserExpGain"))));
			asCom.GetChild("ExclamationMarkBtn").visible = true;
			asCom.GetChild("num").asTextField.color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue));
			asCom.GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText109") + Environment.NewLine + string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText142"), Convert.ToInt32(num2))
				},
				{
					"Pos",
					(object)new Vector2(960f, 460f)
				}
			};
			asCom.GetChild("ExclamationMarkBtn").onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		}
		else
		{
			asCom.GetChild("ExclamationMarkBtn").visible = false;
			asCom.GetChild("num").asTextField.color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
		}
		if (obj is UI_ItemBtn uI_ItemBtn)
		{
			((GObject)uI_ItemBtn).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true, reserveRes: true, this);
			});
			return;
		}
		UI_ItemBtnSpecial btn = (UI_ItemBtnSpecial)(object)obj;
		bool isSummonStone;
		bool showHelpTip = ShouldShowPreviewHelpBtn(itemId, out isSummonStone);
		((GObject)btn.helpBtn).visible = showHelpTip;
		if (isSummonStone)
		{
			FGUIManager.Instance.SetItemIconAndFrame(btn.Content.icon2, itemId);
		}
		btn.type.SetSelectedIndex(isSummonStone ? 1 : 0);
		btn.Content.type.SetSelectedIndex(isSummonStone ? 1 : 0);
		((GObject)btn).data = index;
		((GObject)btn).onClick.Set((EventCallback0)delegate
		{
			if (showHelpTip && btn.button.selectedIndex == 3)
			{
				OnClickShowItemDetail(itemId);
			}
			ChangeSelectChestIndex(index);
		});
	}

	private void ChangeSelectChestIndex(int selectIndex)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		selectedItem = (UI_ItemBtnSpecial)(object)((GComponent)Content.materialList).GetChildAt(selectIndex);
		if (Content.OperationPageController.selectedIndex == 4)
		{
			if (UiHelper.uiSpecialConfig.LegendItemSelectBox_SingleUse != null && UiHelper.uiSpecialConfig.LegendItemSelectBox_SingleUse.Contains(selectItemId))
			{
				((GObject)Content.n77).visible = false;
			}
			Vector3 position = ((GObject)Content.materialList).position;
			Content.OperationPageController.selectedIndex = 3;
			((GObject)Content.materialList).position = position;
		}
		((GObject)Content.ConfirmBtn).data = selectIndex;
		((GObject)Content.ConfirmBtn).enabled = true;
		Content.materialList.selectedIndex = selectIndex;
	}

	private void CompoundSoulStoneMaxEvent()
	{
		int num = Convert.ToInt32(((GObject)Content.MaxValueBtn).data);
		num = ((num >= 100) ? 100 : num);
		((GObject)Content.compoundNum).text = $"{num}";
		((GObject)Content.compoundNum).data = num;
		for (int i = 0; i < Content.materialList.numItems; i++)
		{
			GComponent asCom = ((GComponent)((GComponent)Content.materialList).GetChildAt(i).asButton).GetChild("Content").asCom;
			int num2 = num * (int)asCom.GetChild("num").data;
			((GObject)asCom.GetChild("num").asTextField).text = $"x{num2}";
		}
	}

	private void IncreaseCompoundNum()
	{
		int num = Convert.ToInt32(((GObject)Content.compoundNum).data);
		int num2 = Convert.ToInt32(((GObject)Content.MaxValueBtn).data);
		num2 = ((num2 >= 100) ? 100 : num2);
		if (num < num2)
		{
			((GObject)Content.compoundNum).data = num + 1;
			((GObject)Content.compoundNum).text = $"{num + 1}";
			for (int i = 0; i < Content.materialList.numItems; i++)
			{
				GComponent asCom = ((GComponent)((GComponent)Content.materialList).GetChildAt(i).asButton).GetChild("Content").asCom;
				int num3 = (num + 1) * (int)asCom.GetChild("num").data;
				((GObject)asCom.GetChild("num").asTextField).text = $"x{num3}";
			}
		}
	}

	private void ReduceCompoundNum()
	{
		int num = Convert.ToInt32(((GObject)Content.compoundNum).data);
		if (num > 1)
		{
			((GObject)Content.compoundNum).data = num - 1;
			((GObject)Content.compoundNum).text = $"{num - 1}";
			for (int i = 0; i < Content.materialList.numItems; i++)
			{
				GComponent asCom = ((GComponent)((GComponent)Content.materialList).GetChildAt(i).asButton).GetChild("Content").asCom;
				int num2 = (num - 1) * (int)asCom.GetChild("num").data;
				((GObject)asCom.GetChild("num").asTextField).text = $"x{num2}";
			}
		}
	}

	private void ReceiveSelectedReward()
	{
		End();
	}

	private void OnClickConfirmBtn(EventContext eventContext)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		if (Content.OperationPageController.selectedIndex == 3 && (int)((GObject)Content.compoundNum).data <= 0)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText584") + "0" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 1, arg3: false);
			return;
		}
		int num = (int)((GObject)eventContext.sender).data;
		List<int> selectIndexList = new List<int> { num };
		string item = (ShowSelecledReward ? _selectItems[num].Key : _items[num].ItemId);
		List<string> selectList = new List<string> { item };
		int num2 = ((((GObject)Content.compoundNum).data == null) ? 1 : ((int)((GObject)Content.compoundNum).data));
		if (StorehouseHelper.IsGvGItem(selectItemId))
		{
			OpenGvGPack(selectList, num2);
		}
		else
		{
			OpenPack(selectIndexList, num2);
		}
	}

	private void OpenGvGPack(List<string> selectList, int num)
	{
		Singleton<GvGStoreHouseManager>.Instance.UseItem(selectItemId, num, selectList);
		End();
	}

	private void OpenPack(List<int> selectIndexList, int num)
	{
		Content.OperationPageController.selectedIndex = 5;
		if (selectedItem != null)
		{
			((GObject)selectedItem).SetScale(1.4f, 1.4f);
			((GComponent)Content.selectedList).AddChildAt((GObject)(object)selectedItem, 0);
			((GObject)selectedItem).onClick.Clear();
		}
		GameManagers gameManagers = GameManagers.Instance;
		List<Modifier> source = Shift.Legion.Common.Models.Item.Effect(gameManagers, selectItemId);
		bool hasTimeMachine = source.Any((Modifier modifier) => modifier.ModifierId == "TimeMachine");
		if (hasTimeMachine)
		{
			gameManagers.Messenger.Broadcast<List<string>, bool>("BUILDING_NEED_PAUSE_PRODUCE", null, arg2: true);
		}
		int selectedItemType = Shift.Legion.Common.Models.Item.ItemType(selectItemId);
		GTweenCallback val = default(GTweenCallback);
		EventCallback0 val4 = default(EventCallback0);
		EventCallback0 val7 = default(EventCallback0);
		ILRequestHelper<UseItemResponse>.Request((EventContext)null, (Func<Task<UseItemResponse>>)(() => GameController.Contexts.Service<INetworkService>().UseItem(Convert.ToInt64(-1), selectItemId, num, selectIndexList)), (Action<UseItemResponse>)delegate(UseItemResponse response)
		{
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Expected O, but got Unknown
			//IL_0131: Expected O, but got Unknown
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Expected O, but got Unknown
			//IL_0168: Expected O, but got Unknown
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Expected O, but got Unknown
			//IL_00f4: Expected O, but got Unknown
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (selectedItemType == 11 || selectedItemType == 15 || selectedItemType == 29 || selectedItemType == 30)
				{
					FGUIManager.Instance.AddTextSpecialEffects(openSfxBack, "treasure_open", new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject treasureOpen)
					{
						treasureOpen.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
					});
					Content.ShowSelectedItem.Play();
					GTweener obj = ((GComponent)(object)this).SetTimeout(0.6f);
					GTweenCallback obj2 = val;
					if (obj2 == null)
					{
						GTweenCallback val2 = delegate
						{
							//IL_0025: Unknown result type (might be due to invalid IL or missing references)
							FGUIManager.Instance.AddTextSpecialEffects(shiningSfxBack, "treasure_shining", new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject treasureShining)
							{
								UiAudioManager.Instance.LoadSoundsForSfx(treasureShining, "BoxFlashing", playLoop: true);
							});
						};
						GTweenCallback val3 = val2;
						val = val2;
						obj2 = val3;
					}
					obj.OnComplete(obj2);
				}
				EventListener onClick = ((GObject)Content.ConfirmSelectBtn).onClick;
				EventCallback0 obj3 = val4;
				if (obj3 == null)
				{
					EventCallback0 val5 = delegate
					{
						if (warehousePanel != null)
						{
							warehousePanel.GetData();
						}
					};
					EventCallback0 val6 = val5;
					val4 = val5;
					obj3 = val6;
				}
				onClick.Add(obj3);
				EventListener onClick2 = ((GObject)mask).onClick;
				EventCallback0 obj4 = val7;
				if (obj4 == null)
				{
					EventCallback0 val8 = delegate
					{
						if (warehousePanel != null)
						{
							warehousePanel.GetData();
						}
					};
					EventCallback0 val6 = val8;
					val7 = val8;
					obj4 = val6;
				}
				onClick2.Add(obj4);
				((GObject)mask).touchable = true;
				List<Bonus> list = new List<Bonus>();
				foreach (ModelsBonus bonuse in response.Bonuses)
				{
					list.Add(Bonus.Get(bonuse.ItemId, bonuse.Qty, bonuse.Type, bonuse.IsShining));
				}
				if (hasTimeMachine)
				{
					SharedMessenger.Broadcast("TIME_MACHINE_LAUNCHED", response.TimeMachineSeconds, list);
					gameManagers.Messenger.Broadcast<List<string>, bool>("BUILDING_NEED_RESUME_PRODUCE", null, arg2: false);
				}
				bool flag = false;
				string text = "";
				List<Bonus> list2 = new List<Bonus>();
				foreach (ModelsBonus bonuse2 in response.Bonuses)
				{
					list2.Add(Bonus.Get(bonuse2.ItemId, bonuse2.Qty, bonuse2.Type, bonuse2.IsShining));
				}
				if (selectedItemType == 11 || selectedItemType == 29)
				{
					gameManagers.Messenger.Broadcast("CHEST_CLAIMED", selectItemId, list, response.ClaimedContent);
				}
				else if (selectedItemType == 15 || selectedItemType == 30)
				{
					bool flag2 = false;
					foreach (Bonus item in list2)
					{
						if (item.ItemId.IndexOf("Unlock.") >= 0)
						{
							flag2 = true;
							string text2 = item.ItemId.Replace("Unlock.", "");
							Bonus bonus = Bonus.Get(text2, new List<int> { 1, item.Qty }, 2);
							if (SchemaIndexHelper.GetSchemaById(text2) == "Soldier")
							{
								text = text2;
								flag = true;
							}
							bonus.Claim(GameManagers.Instance, null, null, forceClaim: true, broadcastInform: true, _isChangeStock: false);
						}
						else if (item.ItemId.IndexOf("PotentialLevel.") >= 0)
						{
							string text3 = item.ItemId.Replace("PotentialLevel.", "");
							if (SchemaIndexHelper.GetSchemaById(text3) == "Soldier")
							{
								text = text3;
								flag = true;
							}
							CommandFactory.CreateTakeItemsCommand(new List<Bonus> { item });
						}
						else if (Shift.Legion.Common.Models.Item.ItemType(item.ItemId) == 20)
						{
							flag2 = true;
						}
					}
					if (flag2)
					{
						End();
					}
				}
				if (response.StockChangeRecords != null)
				{
					if (flag)
					{
						for (int num2 = response.StockChangeRecords.Count - 1; num2 >= 0; num2--)
						{
							if (response.StockChangeRecords[num2].Offset > 0 && response.StockChangeRecords[num2].ItemId == text)
							{
								response.StockChangeRecords.RemoveAt(num2);
							}
							else if (response.StockChangeRecords[num2].Offset > 0 && response.StockChangeRecords[num2].Context == 11 && response.StockChangeRecords[num2].ContextValue.IndexOf(text) >= 0)
							{
								response.StockChangeRecords.RemoveAt(num2);
								break;
							}
						}
					}
					gameManagers.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				}
				FGUIManager.Instance.WarehousePanel?.UpdateStockImmediately(selectItemId);
			}
		});
	}

	private void UseItem(string itemId, int num, Action onSuccess = null)
	{
		ILRequestHelper<UseItemResponse>.Request((EventContext)null, (Func<Task<UseItemResponse>>)(() => GameController.Contexts.Service<INetworkService>().UseItem(Convert.ToInt64(-1), itemId, num, null)), (Action<UseItemResponse>)delegate(UseItemResponse response)
		{
			if (!response.Result)
			{
				IsItemUsed = false;
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				ILRuntimeDebug.LogError($"Use Item {itemId} Failed with code {response.ErrorCode}");
			}
			else
			{
				List<Bonus> list = new List<Bonus>();
				if (response.Bonuses != null)
				{
					foreach (ModelsBonus bonuse in response.Bonuses)
					{
						list.Add(Bonus.Get(bonuse.ItemId, bonuse.Qty, bonuse.Type, bonuse.IsShining));
					}
				}
				if (response.StockChangeRecords != null)
				{
					bool flag = false;
					string text = "";
					if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 11 || Shift.Legion.Common.Models.Item.ItemType(itemId) == 29)
					{
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
					}
					if (flag)
					{
						for (int num2 = response.StockChangeRecords.Count - 1; num2 >= 0; num2--)
						{
							if (response.StockChangeRecords[num2].Offset > 0 && response.StockChangeRecords[num2].ItemId == text)
							{
								response.StockChangeRecords.RemoveAt(num2);
								break;
							}
						}
					}
					GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				}
				if (response.LegendItems != null)
				{
					List<LegendItemUi> list2 = new List<LegendItemUi>();
					List<string> list3 = new List<string>();
					for (int i = 0; i < response.LegendItems.Count; i++)
					{
						ModelsBonus modelsBonus = response.LegendItems[i];
						Bonus bonus = Bonus.Get(modelsBonus.ItemId, modelsBonus.Qty, modelsBonus.Type, modelsBonus.IsShining, modelsBonus.ExtraData);
						Dictionary<string, float> dict = bonus.Claim(GameManagers.Instance);
						long key = long.Parse(dict.First().Key);
						LegendItem legendItem = GameManagers.Instance.InventoryManager.LegendItems[key];
						LegendItemUi legendItemUi = new LegendItemUi(legendItem.InstanceId, legendItem);
						LegendItemsHelper.UpdateLegendItems(legendItemUi);
						list2.Add(legendItemUi);
						list3.Add(legendItemUi.LegendItemData.ItemId);
					}
					Dictionary<string, object> parameters = new Dictionary<string, object>
					{
						{ "LegendItems", list2 },
						{
							"SortingOrder",
							((GObject)this).sortingOrder
						},
						{ "ItemId", itemId }
					};
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemBoxPanel.Name, parameters);
				}
				if (string.IsNullOrEmpty(response.NewBlueprints))
				{
					onSuccess?.Invoke();
				}
				else
				{
					List<string> list4 = JsonHelper.ToObject<List<string>>(response.NewBlueprints);
					if (list4.Count > 0)
					{
						LegendItemsHelper.OpenBlueprintsBoxResult(JsonHelper.ToObject<List<string>>(response.NewBlueprints), itemId);
					}
					onSuccess?.Invoke();
				}
			}
		});
	}

	private void PlayBoxDropSfx()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		Vector3 campPosition = ClientBattleFieldLogic.GetCampPosition(Team.Blue, GameController.Contexts.config.battleConfig.BattleFieldLength);
		Vector2 val = Vector2.op_Implicit(GameController.Contexts.Service<ICameraService>().WorldToScreenPoint(campPosition));
		val.y = (float)Screen.height - val.y;
		Vector2 val2 = ((GObject)this).GlobalToLocal(Vector2.op_Implicit(val));
		((GObject)boxIcon).SetXY(val2.x, val2.y);
		((GComponent)(object)this).SetTimeout(0.3f).OnComplete((GTweenCallback)delegate
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Expected O, but got Unknown
			((GObject)boxIcon).alpha = 1f;
			((GObject)boxIcon).TweenMoveY(630f, 0.2f).OnComplete((GTweenCallback)delegate
			{
				((GObject)boxIcon).TweenMoveY(660f, 0.2f);
			});
		});
		((GComponent)(object)this).SetTimeout(1.1f).OnComplete((GTweenCallback)delegate
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			((GObject)boxIcon).TweenMove(((GObject)CommonBox).xy, 0.3f).OnComplete((GTweenCallback)delegate
			{
				((GObject)mask).alpha = 1f;
				((GObject)boxIcon).alpha = 0f;
				((GObject)boxClip).visible = true;
			});
			((GObject)boxIcon).TweenScale(Vector2.one, 0.3f);
		});
	}

	private void PlayOpenSfx()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		float duration = 0f;
		if (ShowReward)
		{
			UiAudioManager.Instance.PlaySoundEffect("PlantFlag");
			duration = 1.4f;
			PlayBoxDropSfx();
		}
		((GComponent)(object)this).SetTimeout(duration).OnComplete((GTweenCallback)delegate
		{
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Expected O, but got Unknown
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Expected O, but got Unknown
			boxClip.playing = true;
			boxClip.SetPlaySettings(0, -1, 1, -1);
			UiAudioManager.Instance.PlaySoundEffect(openBoxSound);
			((GObject)boxClip).TweenFade(((GObject)boxClip).alpha, 0.33f).OnComplete((GTweenCallback)delegate
			{
				//IL_0099: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a3: Expected O, but got Unknown
				//IL_0048: Unknown result type (might be due to invalid IL or missing references)
				boxClip.playing = false;
				boxClip.frame = 3;
				if (!ShowSelecledReward)
				{
					FGUIManager.Instance.AddTextSpecialEffects(openSfxBack, "treasure_open", new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject treasureOpen)
					{
						treasureOpen.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
					});
				}
				((GObject)Content).TweenFade(1f, 0.45f).OnComplete(new GTweenCallback(OnContentShow));
			});
			if (!CanBuy)
			{
				((GObject)boxClip).TweenFade(((GObject)boxClip).alpha, 0.6f).OnComplete((GTweenCallback)delegate
				{
					//IL_002e: Unknown result type (might be due to invalid IL or missing references)
					if (!ShowSelecledReward)
					{
						FGUIManager.Instance.AddTextSpecialEffects(shiningSfxBack, "treasure_shining", new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject treasureOpen)
						{
							UiAudioManager.Instance.LoadSoundsForSfx(treasureOpen, "BoxFlashing", playLoop: true);
						});
					}
				});
			}
		});
	}

	private void RenderMaterialList(int num)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		switch (num)
		{
		case 2:
			Content.materialList.columnGap = 15;
			break;
		case 3:
			Content.materialList.columnGap = 15;
			break;
		default:
			Content.materialList.columnGap = 15;
			break;
		}
		if (ShowSelecledReward)
		{
			Content.materialList.defaultItem = "ui://Tips/ItemBtnSpecial";
		}
		else
		{
			Content.materialList.defaultItem = "ui://Tips/ItemBtn";
		}
		Content.materialList.itemRenderer = new ListItemRenderer(MaterialListItemRender);
		Content.materialList.numItems = num;
		if (num > 4)
		{
			Content.materialList.ResizeToFit(num);
		}
		if (_isNewCommerSpecial)
		{
			_specialIcon = UI_newCommerSpecialIcon.CreateInstance();
			_specialIcon.Status.SetSelectedIndex(0);
			((GComponent)Content.materialList).AddChild((GObject)(object)_specialIcon);
		}
	}

	private void ConfirmTakeClick()
	{
		_extraConfirmAction?.Invoke();
		if (!string.IsNullOrEmpty(UseBoxItemId))
		{
			if (!IsItemUsed)
			{
				IsItemUsed = true;
				if (_isNewCommerSpecialWithoutItem)
				{
					OnSuccess();
				}
				else
				{
					UseItem(UseBoxItemId, UseBoxItemCount, OnSuccess);
				}
			}
			return;
		}
		if (_items != null && ((!ShowReward && !ShowBoxReward && !ShowSelecledReward) || items_has_UnlockItem))
		{
			foreach (Bonus item in _items)
			{
				if (item.ItemId.IndexOf("Unlock.") >= 0)
				{
					CommandFactory.CreateTakeItemsCommand(new List<Bonus> { item });
				}
				else if (item.ItemId.IndexOf("PotentialLevel.") >= 0)
				{
					CommandFactory.CreateTakeItemsCommand(new List<Bonus> { item });
				}
			}
			((GObject)mainGroup).alpha = 0f;
			DisplayClaimMissileSfx();
		}
		if (_resultBonuses != null && (ShowBoxReward || ShowSelecledReward))
		{
			bool flag = false;
			for (int i = 0; i < _resultBonuses.Count; i++)
			{
				flag = _resultBonuses[i].ItemId == "FightTestCoin";
				_resultBonuses[i].BroadcastInforms();
			}
			((GObject)mainGroup).alpha = 0f;
			DisplayClaimMissileSfx();
			if (activityPanel != null)
			{
				activityPanel.UpdateMoneyAndGemNum(_resultBonuses);
			}
			if (giftBagPanel != null)
			{
				giftBagPanel.UpdateMoneyAndGemNum(_resultBonuses);
			}
			if (specialActivityPanel != null)
			{
				specialActivityPanel.UpdateMoneyAndGemNum(_resultBonuses);
			}
			if (warehousePanel != null)
			{
				warehousePanel.UpdateMoneyAndGemNum(_resultBonuses);
				warehousePanel.GetData();
			}
			if (flag)
			{
				UiHelper.UseFightTestBox("FightTestBox");
			}
		}
		if (ShowReward)
		{
			End();
		}
		void OnSuccess()
		{
			if (!((GObject)this).isDisposed)
			{
				if (_isNewCommerSpecial)
				{
					GameLocalDataManager.SetInt("NewComerSpecialIconShow", 2);
					SharedMessenger.Broadcast("CUSTOM_ACTION_FINISH", taskCompletionSource, arg2: true);
				}
				DisplayClaimMissileSfx();
			}
		}
	}

	private void ConfirmBuyClick()
	{
		if (giftBag != null)
		{
			int value = Content.ItemsCounter.Value;
			if (!FGUIManager.Instance.NotEnoughToPayTip(giftBag, ((GObject)this).sortingOrder, value))
			{
				End();
			}
			else if (!string.IsNullOrEmpty(UseCurrency))
			{
				PurchaseManager.Instance.InvokePurchase(giftBag, giftBagProductLocalInfo, value, UseCurrency, DoubleCheckToBuy);
			}
			else
			{
				PurchaseManager.Instance.InvokePurchase(giftBag, giftBagProductLocalInfo, value, (Action)null, DoubleCheckToBuy);
			}
		}
		else
		{
			End();
		}
	}

	private void OrderShipSuccessEvent(List<Bonus> result, List<Bonus> bonuses)
	{
		for (int i = 0; i < result.Count; i++)
		{
			if (Shift.Legion.Common.Models.Item.ItemType(result[i].ItemId) == 17)
			{
				Dictionary<string, int> value = GameManagers.Instance.AchievementManager.LegendItemFromBlackMarketStats.GetValue();
				if (value.ContainsKey(result[i].ItemId))
				{
					value[result[i].ItemId]++;
				}
				else
				{
					value.Add(result[i].ItemId, 1);
				}
				GameManagers.Instance.AchievementManager.LegendItemFromBlackMarketStats.SetValue(value);
				SharedMessenger.Broadcast("LEGEND_ITEMS_CHANGED", 35);
				ThinkingDataHelper.Instance.LegendItemsExchange(result[i].ItemId);
			}
		}
		if (giftBagPanel != null && !((GObject)giftBagPanel).isDisposed)
		{
			giftBagPanel?.UpdateMainPanel();
		}
		if (activityPanel != null && !((GObject)activityPanel).isDisposed)
		{
			activityPanel?.RenderWelfare(activityPanel.curSelectMissionDay);
			activityPanel?.UpdateFundActivityPanel();
		}
		UI_PvpStorePanel.PvpStorePanel?.UpdateMainPanel();
		DisplayClaimMissileSfx();
		if (activityPanel != null && !((GObject)activityPanel).isDisposed)
		{
			activityPanel.UpdateMoneyAndGemNum(result);
		}
		if (giftBagPanel != null && !((GObject)giftBagPanel).isDisposed)
		{
			giftBagPanel.UpdateMoneyAndGemNum(result);
		}
		if (specialActivityPanel != null && !((GObject)specialActivityPanel).isDisposed)
		{
			if (giftBag != null && giftBag.PurchaseLimitPeriod == PurchaseLimitType.Permanent && GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(giftBag.StoreItemId) >= giftBag.PurchaseLimit)
			{
				UI_SpecialActivityPanel _specialActivityPanel = specialActivityPanel;
				FGUIManager.Instance.GetSimpleDynamicPromotionActivity(delegate
				{
					SimpleDynamicPromotionActivity simpleDynamicPromotionActivity = FGUIManager.Instance.SimpleDynamicPromotionActivities.First();
					if (simpleDynamicPromotionActivity != null)
					{
						_specialActivityPanel.SetStoreActivity(simpleDynamicPromotionActivity);
					}
					_specialActivityPanel.UpdateMainPanel();
					_specialActivityPanel.UpdateMoneyAndGemNum(result);
				}, mustUpdateData: true);
			}
			else
			{
				specialActivityPanel.UpdateMainPanel();
				specialActivityPanel.UpdateMoneyAndGemNum(result);
			}
		}
		if (warehousePanel != null && !((GObject)warehousePanel).isDisposed)
		{
			warehousePanel.UpdateMoneyAndGemNum(result);
		}
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(UI_ExclamationMarkPanel.Name);
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < _textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(_textureList[i]);
		}
		if (giftBagPanel != null)
		{
			ThinkingDataHelper.Instance.NoPayPreviewTrack();
		}
		if (specialActivityPanel != null)
		{
			ThinkingDataHelper.Instance.NoPayPreviewTrack();
		}
		if (taskCompletionSource != null)
		{
			SharedMessenger.Broadcast("CUSTOM_ACTION_FINISH", taskCompletionSource, arg2: true);
		}
	}

	public void OnAnyBattleWaveTimeLeft(GameStateEntity entity, int value)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		if (ShowReward)
		{
			((GObject)Content.tip1stText).text = string.Format("{0}{1}", value - 2, LanguagesManager.GetDesc("CsharpCodeZhTcText613"));
			if (value <= 3)
			{
				((GComponent)(object)this).SetTimeout(0.33f).OnComplete(new GTweenCallback(End));
			}
		}
	}

	public static void OnClickShowItemDetail(string itemId)
	{
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		switch (gDEItemData.ItemType)
		{
		case 10:
		{
			Dictionary<string, SoliderUnlockEffect> soldierUnlock = gDEItemData.GetSoldierUnlock();
			Soldier value = GameManagers.Instance.SoldierManager.Get(soldierUnlock.Keys.First());
			UnityUiService.Instance.OpenPanel(UI_main_IntroductionPanelA.Name, new Dictionary<string, object> { { "SoliderInfo", value } });
			break;
		}
		case 17:
		{
			ItemEffectIdentifiedLegendItem itemEffectIdentifiedLegendItem2 = JsonHelper.ToObject<ItemEffectIdentifiedLegendItem>(GDMgr.Get<GDEItemData>(itemId).Effect);
			LegendItemsHelper.BlackMarketLegendItem itemData2 = new LegendItemsHelper.BlackMarketLegendItem(itemEffectIdentifiedLegendItem2.ItemData, itemEffectIdentifiedLegendItem2.LegendItemId, itemEffectIdentifiedLegendItem2.Score);
			UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(null, "", -1, 3, itemData2);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, null);
			break;
		}
		case 20:
		{
			ItemEffectIdentifiedLegendItem itemEffectIdentifiedLegendItem = JsonHelper.ToObject<ItemEffectIdentifiedLegendItem>(GDMgr.Get<GDEItemData>(itemId).Effect);
			LegendItemsHelper.BlackMarketLegendItem itemData = new LegendItemsHelper.BlackMarketLegendItem(itemEffectIdentifiedLegendItem.ItemData, itemEffectIdentifiedLegendItem.LegendItemId, itemEffectIdentifiedLegendItem.Score);
			UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(null, "", -1, 3, itemData);
			UI_LegendItemInfoDialog.DialogInfo.IsPreviewMode = true;
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, null);
			break;
		}
		}
	}

	public static bool ShouldShowPreviewHelpBtn(string itemId, out bool isSummonStone)
	{
		ItemType itemType = (ItemType)Shift.Legion.Common.Models.Item.ItemType(itemId);
		isSummonStone = itemType == ItemType.SummonStone;
		HashSet<ItemType> hashSet = new HashSet<ItemType>
		{
			ItemType.SummonStone,
			ItemType.BlackMarketLegendItem,
			ItemType.AutoIdentifyLegendItem
		};
		return hashSet.Contains(itemType);
	}
}
