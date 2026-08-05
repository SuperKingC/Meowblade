using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.GvGShipOverview;

namespace UI.GvGShipDetail;

public class UI_main_FoodFillupPanel : GComponent, IUiController
{
	public class ItemEffect
	{
		public int ShipFood;
	}

	public GGraph back;

	public UI_com_FoodFillupDialog Dialog;

	public Transition t0;

	public const string URL = "ui://u6x0b1gnsvf66o";

	public static string Name = "UI_main_FoodFillupPanel";

	private List<string> ItemIds;

	private int ShipEntityId;

	public static string GetURL()
	{
		return "ui://u6x0b1gnsvf66o";
	}

	public static UI_main_FoodFillupPanel CreateInstance()
	{
		return (UI_main_FoodFillupPanel)(object)UIPackage.CreateObject("GvGShipDetail", "main_FoodFillupPanel");
	}

	public static UI_main_FoodFillupPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_FoodFillupPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnsvf66o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_FoodFillupDialog)(object)((GComponent)this).GetChild("Dialog");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		ShipEntityId = (parameters.TryGetValue("ShipEntityId", out var value) ? ((int)value) : (-1));
		if (ShipEntityId <= 0)
		{
			ILRuntimeDebug.LogError($"[UI_main_FoodFillupPanel] ShipEntityId={ShipEntityId}");
			End();
		}
		else
		{
			GetData();
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GObject)back).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.Fillup).onClick.Set(new EventCallback0(OnClickFillup));
		((GObject)Dialog.FastFillup).onClick.Set(new EventCallback0(OnClickFastFillup));
		((GObject)Dialog.GotoFlagShipBtn).onClick.Set(new EventCallback0(OnGotoFlagShip));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
		((GObject)Dialog.Fillup).onClick.Clear();
		((GObject)Dialog.FastFillup).onClick.Clear();
		((GObject)Dialog.GotoFlagShipBtn).onClick.Clear();
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	private void GetData()
	{
		ItemIds = "GvGFillUpFoodConfig".ToConfiguration<List<string>>();
		Update(isInit: true);
	}

	private void Update(bool isInit = false)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Dialog.ItemList.itemRenderer = (ListItemRenderer)delegate(int i, GObject o)
		{
			RenderItem(i, o as UI_com_FoodItem);
		};
		Dialog.ItemList.numItems = ItemIds.Count;
		if (isInit)
		{
			Dialog.ItemList.selectedIndex = 0;
		}
	}

	private void RenderItem(int i, UI_com_FoodItem slot)
	{
		string text = ItemIds[i];
		ItemEffect itemEffect = GDMgr.Get<GDEItemData>(text).Effect.ToObject<ItemEffect>();
		int stock = GameManagers.Instance.StockController.GetStock(text);
		FGUIManager.Instance.SetItemIconAndFrame(slot.FoodItemIcon, text);
		((GObject)slot.Count).text = $"{stock}";
		slot.HasItem.selectedIndex = ((stock > 0) ? 1 : 0);
		((GObject)slot.Effect).text = $"+{itemEffect.ShipFood}";
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (ItemIds.Contains(itemId))
		{
			Update();
		}
	}

	private void OnClickFastFillup()
	{
		string itemId = ItemIds[Dialog.ItemList.selectedIndex];
		Singleton<GvGShipUiInfoManager>.Instance.ShipFillupFood(ShipEntityId, itemId, 0);
	}

	private void OnClickFillup()
	{
		string itemId = ItemIds[Dialog.ItemList.selectedIndex];
		Singleton<GvGShipUiInfoManager>.Instance.ShipFillupFood(ShipEntityId, itemId, 1);
	}

	private void OnGotoFlagShip()
	{
		IUiService uiService = GameController.Contexts.Service<IUiService>();
		uiService.ClosePanel(UI_GvGShipDetailPanel.Name);
		if (uiService.HasShowingUi(UI_GvGShipOverviewPanel.Name))
		{
			uiService.ClosePanel(UI_GvGShipOverviewPanel.Name);
		}
		End();
		FlagShipStateModel ourFlagShip = Singleton<WorldStateManager>.Instance.GetOurFlagShip();
		GvGWorldMapController.Instance.FocusIslandById(ourFlagShip.StayIslandId);
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
