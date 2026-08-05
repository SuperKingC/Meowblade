using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.UseItemResult;
using UnityEngine;

namespace UI.StellarKeyStore;

public class UI_main_StellarKeyStorePanel : GComponent, IUiController
{
	public Controller Type;

	public Controller IsEmpty;

	public GLoader background;

	public GImage n45;

	public GImage n54;

	public GImage n55;

	public GImage n56;

	public GImage n57;

	public GImage n58;

	public GImage n59;

	public GImage n60;

	public GImage n61;

	public GImage n62;

	public GImage n64;

	public GButton BackBtn;

	public UI_com_Title Title;

	public GTextField RefreshTime;

	public GImage n44;

	public GImage n47;

	public GImage n46;

	public GImage n48;

	public GList Tabs;

	public GList CardList;

	public GList KeyList;

	public UI_btn_OpenCraftPanel OpenCraftPanelBtn;

	public GImage n67;

	public GTextField n66;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://khops95lyjov0";

	public static string Name = "UI_main_StellarKeyStorePanel";

	private GvG3StoreManager.StellarKeyStoreConfigData Data;

	private GvG3StoreManager.StellarKeyStorePageData CurPageData;

	private GvG3StoreManager.eStellarStorePage CurPageType;

	private string RefreshTimeTemplateText;

	public static string GetURL()
	{
		return "ui://khops95lyjov0";
	}

	public static UI_main_StellarKeyStorePanel CreateInstance()
	{
		return (UI_main_StellarKeyStorePanel)(object)UIPackage.CreateObject("StellarKeyStore", "main_StellarKeyStorePanel");
	}

	public static UI_main_StellarKeyStorePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_StellarKeyStorePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://khops95lyjov0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		IsEmpty = ((GComponent)this).GetController("IsEmpty");
		background = (GLoader)((GComponent)this).GetChild("background");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		n58 = (GImage)((GComponent)this).GetChild("n58");
		n59 = (GImage)((GComponent)this).GetChild("n59");
		n60 = (GImage)((GComponent)this).GetChild("n60");
		n61 = (GImage)((GComponent)this).GetChild("n61");
		n62 = (GImage)((GComponent)this).GetChild("n62");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		Title = (UI_com_Title)(object)((GComponent)this).GetChild("Title");
		RefreshTime = (GTextField)((GComponent)this).GetChild("RefreshTime");
		string id = "ui://khops95lyjov0".Replace("ui://", "") + "-" + ((GObject)RefreshTime).id;
		((GObject)RefreshTime).text = LanguagesManager.GetDesc(id);
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		Tabs = (GList)((GComponent)this).GetChild("Tabs");
		CardList = (GList)((GComponent)this).GetChild("CardList");
		KeyList = (GList)((GComponent)this).GetChild("KeyList");
		OpenCraftPanelBtn = (UI_btn_OpenCraftPanel)(object)((GComponent)this).GetChild("OpenCraftPanelBtn");
		n67 = (GImage)((GComponent)this).GetChild("n67");
		n66 = (GTextField)((GComponent)this).GetChild("n66");
		string id2 = "ui://khops95lyjov0".Replace("ui://", "") + "-" + ((GObject)n66).id;
		((GObject)n66).text = LanguagesManager.GetDesc(id2);
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		RefreshTimeTemplateText = ((GObject)RefreshTime).text;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		UpdateKeyList();
		Singleton<GvG3StoreManager>.Instance.GetStellarKeyStoreData(delegate(GvG3StoreManager.StellarKeyStoreConfigData data)
		{
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected O, but got Unknown
			if (!((GObject)this).isDisposed)
			{
				Data = data;
				UpdateProductList();
				UpdateRemainingTime(null);
				Timers.inst.Add(1f, 0, new TimerCallback(UpdateRemainingTime));
			}
		});
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Set(new EventCallback0(End));
		((GObject)OpenCraftPanelBtn).onClick.Set(new EventCallback0(OnClickOpenCraftPanelBtn));
		Type.onChanged.Set(new EventCallback1(OnPageChange));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)BackBtn).onClick.Clear();
		((GObject)OpenCraftPanelBtn).onClick.Clear();
		Type.onChanged.Clear();
	}

	private void OnPageChange(EventContext context)
	{
		UpdateProductList();
		UpdateRemainingTime(null);
	}

	private void OnClickOpenCraftPanelBtn()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_StellarKeyCraftPopup.Name, new Dictionary<string, object> { 
		{
			"OnConfirmCraft",
			new UICallbackParam<Action<UI_main_StellarKeyCraftPopup.CraftInfo>>(OnConfirmCraft)
		} });
	}

	private void OnClickProductCard(string activityId, Product product, int boughtCount, UI_btn_ProductCard slot)
	{
		if (slot.CanBuy.selectedIndex != 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_StellarKeyBuyPanel.Name, new Dictionary<string, object>
			{
				{
					"Type",
					slot.Content.Type.selectedIndex
				},
				{ "Product", product },
				{ "BoughtCount", boughtCount },
				{
					"OnConfirmBuy",
					new UICallbackParam<Action>(OnConfirmBuy)
				}
			});
		}
		void OnConfirmBuy()
		{
			Singleton<GvG3StoreManager>.Instance.StellarKeyBuy(product.Id, activityId, delegate(bool success)
			{
				if (success)
				{
					GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(product.Id);
					$"{gDEItemData.Name}+{1}".ToTip();
					UpdateKeyList();
					UpdateProductList();
				}
			});
		}
	}

	private void OnConfirmCraft(UI_main_StellarKeyCraftPopup.CraftInfo info)
	{
		Singleton<GvG3StoreManager>.Instance.StellarKeyCraft(info.FormulaId, delegate(bool success)
		{
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			if (success)
			{
				Vector2 endPos = Vector2.zero;
				GObject[] children = ((GComponent)KeyList).GetChildren();
				foreach (GObject val in children)
				{
					UI_com_KeyStock uI_com_KeyStock = (UI_com_KeyStock)(object)val;
					string text = $"{(GvG3StoreManager.eStellarKeyType)uI_com_KeyStock.Type.selectedIndex}";
					if (text == info.Output.Key)
					{
						endPos = ((GObject)uI_com_KeyStock.Count).LocalToRoot(((GObject)uI_com_KeyStock.Count).size.Div(2f), GRoot.inst);
					}
				}
				EmitLightBallEffect(info.OutputIconPos, endPos, 0.7f, (EaseType)11, UpdateKeyList);
			}
		});
	}

	private void UpdateRemainingTime(object param)
	{
		if (CurPageData == null)
		{
			((GObject)RefreshTime).visible = false;
			return;
		}
		int endTime = Data.Activity_Dict[CurPageData.ActivityId].EndTime;
		int num = Mathf.Max(0, endTime - (int)GameController.Instance.GetServerTime());
		string text = "";
		text = ((num >= 86400) ? string.Format("{0}{1}", num / 86400, "DateTime_Days".ToLanguage()) : ((num >= 3600) ? string.Format("{0}{1}", num / 3600, "DateTime_Hours".ToLanguage()) : ((num < 60) ? string.Format("{0}{1}", num, "DateTime_Seconds".ToLanguage()) : string.Format("{0}{1}", num / 60, "DateTime_Minutes".ToLanguage()))));
		((GObject)RefreshTime).visible = true;
		((GObject)RefreshTime).text = HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format(RefreshTimeTemplateText, text);
	}

	private void UpdateProductList()
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		if (Data != null)
		{
			int selectedIndex = Type.selectedIndex;
			CurPageType = (GvG3StoreManager.eStellarStorePage)selectedIndex;
			Data.Page_Dict.TryGetValue($"{CurPageType}", out var value);
			CurPageData = value;
			int num = ((CurPageData != null && CurPageData.Product_List != null) ? CurPageData.Product_List.Count : 0);
			CardList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
			{
				RenderProductCardItem(i, (UI_btn_ProductCard)(object)o);
			};
			CardList.numItems = num;
			IsEmpty.selectedIndex = ((num == 0) ? 1 : 0);
		}
	}

	private void RenderProductCardItem(int i, UI_btn_ProductCard slot)
	{
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		if (CurPageData != null)
		{
			Product product = CurPageData.Product_List[i];
			string activityId = CurPageData.ActivityId;
			string id = product.Id;
			Data.Activity_Dict[activityId].ActivityConfig.Progress.TryGetValue(id, out var value);
			int boughtCount = ((value != null) ? ((int)value) : 0);
			GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(id);
			bool flag = boughtCount < product.Limit || product.Limit < 0;
			slot.Content.Type.selectedIndex = Type.selectedIndex;
			slot.CanBuy.selectedIndex = (flag ? 1 : 0);
			((GObject)slot.BoughtCountLimit).text = $"{product.Limit - boughtCount}/{product.Limit}";
			slot.HasLimit.selectedIndex = ((product.Limit > 0) ? 1 : 0);
			((GObject)slot.Content.ItemName).text = gDEItemData.Name;
			((GObject)slot.Content.Price).text = $"x{product.Cost}";
			FGUIManager.Instance.SetItemIconAndFrame(slot.Content.KeyIcon, product.Currency, null, "", frameVisible: false);
			FGUIManager.Instance.SetItemIconAndFrame(slot.Content.ItemIcon, id, null, "", frameVisible: false);
			if (slot.Content.sfxBack == null)
			{
				FGUIManager.Instance.AddTextSpecialEffects(slot.Content.sfxBack, "ui_active_glow_orange_3", new Vector3(180f, 180f, 180f));
			}
			((GObject)slot).onClick.Set((EventCallback0)delegate
			{
				OnClickProductCard(activityId, product, boughtCount, slot);
			});
		}
	}

	private void UpdateKeyList()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		KeyList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderKeyListItem(i, (UI_com_KeyStock)(object)o);
		};
		KeyList.numItems = KeyList.numItems;
	}

	private void RenderKeyListItem(int i, UI_com_KeyStock slot)
	{
		string itemId = $"{(GvG3StoreManager.eStellarKeyType)slot.Type.selectedIndex}";
		((GObject)slot.Count).text = $"{GameManagers.Instance.StockController.GetStock(itemId)}";
	}

	private void EmitLightBallEffect(Vector2 startPos, Vector2 endPos, float duration, EaseType easeType, Action onFinished = null)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		GGraph container = new GGraph();
		((GObject)container).SetPivot(0.5f, 0.5f);
		((GObject)container).SetSize(10f, 10f, true);
		((GComponent)GRoot.inst).AddChild((GObject)(object)container);
		((GObject)container).sortingOrder = 99999;
		FGUIManager.Instance.AddTextSpecialEffects(container, "exp_missile_green", Vector3.zero);
		((GObject)container).xy = startPos;
		((GObject)container).TweenMove(endPos, duration).SetEase(easeType).OnComplete((GTweenCallback)delegate
		{
			((GObject)container).Dispose();
			onFinished?.Invoke();
		});
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		if (Timers.inst.Exists(new TimerCallback(UpdateRemainingTime)))
		{
			Timers.inst.Remove(new TimerCallback(UpdateRemainingTime));
		}
	}
}
