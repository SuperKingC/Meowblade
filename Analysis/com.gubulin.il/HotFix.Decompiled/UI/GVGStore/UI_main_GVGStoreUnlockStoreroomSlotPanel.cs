using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;

namespace UI.GVGStore;

public class UI_main_GVGStoreUnlockStoreroomSlotPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_UnlockStoreroomSlotDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://fvc33k3gv6i714";

	public static string Name = "UI_main_GVGStoreUnlockStoreroomSlotPanel";

	public static string GetURL()
	{
		return "ui://fvc33k3gv6i714";
	}

	public static UI_main_GVGStoreUnlockStoreroomSlotPanel CreateInstance()
	{
		return (UI_main_GVGStoreUnlockStoreroomSlotPanel)(object)UIPackage.CreateObject("GVGStore", "main_GVGStoreUnlockStoreroomSlotPanel");
	}

	public static UI_main_GVGStoreUnlockStoreroomSlotPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GVGStoreUnlockStoreroomSlotPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gv6i714", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_UnlockStoreroomSlotDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		RenderDialog();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)Dialog.Confirm).onClick.Add(new EventCallback0(Confirm));
		((GObject)Mask).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)Dialog.Confirm).onClick.Remove(new EventCallback0(Confirm));
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void Confirm()
	{
		GameManagers.Instance.UserArchiveManager.GetGvGStoreroomStockLimit(UpdateUi, isLevelUp: true);
		void UpdateUi(int index)
		{
			SharedMessenger.Broadcast("UPDATE_GVG_STOREROOM");
			End();
		}
	}

	private void RenderDialog()
	{
		Dictionary<string, int> storeroomEvoRequire = GameManagers.Instance.UserArchiveManager.GetStoreroomEvoRequire();
		string itemId = storeroomEvoRequire.Keys.ToList()[0];
		int num = storeroomEvoRequire.Values.ToList()[0];
		((GObject)Dialog.Tip).text = LanguagesManager.GetDesc("GvGStoreroomUnlockSlotTip");
		GButton consumptionItem = Dialog.DialogMiddleContent.ConsumptionItem;
		FGUIManager.Instance.SetItemIconAndFrame(((GComponent)consumptionItem).GetChild("icon").asLoader, itemId);
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		bool flag = stock >= num;
		string text = ((!flag) ? "#ff1a1a" : "#F6E2B2");
		string text2 = "#F6E2B2";
		((GComponent)consumptionItem).GetChild("reqDesc").asCom.GetChild("curPrice").text = $"[color={text}]{stock.ShortNumberFormat()}[/color][color={text2}]/{num}[/color]";
		((GComponent)consumptionItem).GetChild("reqDesc").asCom.GetChild("originPrice").visible = false;
		((GObject)Dialog.Confirm).enabled = flag;
	}
}
