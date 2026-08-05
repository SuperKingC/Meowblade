using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;

namespace UI.GVGStore;

public class UI_main_GVGStoreRefreshConfirmPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_RefreshDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://fvc33k3gv6i7w";

	public static string Name = "UI_main_GVGStoreRefreshConfirmPanel";

	private const int UseTicketNum = 1;

	private bool _hasRareStoreItem;

	public static string GetURL()
	{
		return "ui://fvc33k3gv6i7w";
	}

	public static UI_main_GVGStoreRefreshConfirmPanel CreateInstance()
	{
		return (UI_main_GVGStoreRefreshConfirmPanel)(object)UIPackage.CreateObject("GVGStore", "main_GVGStoreRefreshConfirmPanel");
	}

	public static UI_main_GVGStoreRefreshConfirmPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GVGStoreRefreshConfirmPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gv6i7w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_RefreshDialog)(object)((GComponent)this).GetChild("Dialog");
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
		_hasRareStoreItem = parameters.TryGetValue("HasRareItem", out var value) && (bool)value;
		object value2;
		int num = (parameters.TryGetValue("FreeRefreshCount", out value2) ? ((int)value2) : 0);
		if (num > 0)
		{
			RenderDialog(num);
		}
		else
		{
			RenderDialog();
		}
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Dialog.exitBtn).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.RefreshCardBtn).onClick.Add(new EventCallback0(ConfirmClickEvent));
		SharedMessenger.AddListener("CLOSE_GVG_STORE_REFRESH_DIALOG", End);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Dialog.exitBtn).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.RefreshCardBtn).onClick.Remove(new EventCallback0(ConfirmClickEvent));
		SharedMessenger.RemoveListener("CLOSE_GVG_STORE_REFRESH_DIALOG", End);
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderDialog(int freeRefreshCount)
	{
		((GObject)Dialog.FreeTicketNumber).text = freeRefreshCount.ToString();
		((GObject)Dialog.RefreshCardBtn).enabled = true;
		Dialog.RefreshIsFree.SetSelectedIndex(1);
	}

	private void RenderDialog()
	{
		GButton consumptionItem = Dialog.DialogMiddleContent.ConsumptionItem;
		FGUIManager.Instance.SetItemIconAndFrame(((GComponent)consumptionItem).GetChild("icon").asLoader, "I62200");
		int stock = GameManagers.Instance.StockController.GetStock("I62200");
		bool flag = stock >= 1;
		string text = ((!flag) ? "#ff1a1a" : "#F6E2B2");
		string text2 = "#F6E2B2";
		((GComponent)consumptionItem).GetChild("reqDesc").asCom.GetChild("curPrice").text = $"[color={text}]{stock.ShortNumberFormat()}[/color][color={text2}]/{1}[/color]";
		((GComponent)consumptionItem).GetChild("reqDesc").asCom.GetChild("originPrice").visible = false;
		((GObject)Dialog.RefreshCardBtn).enabled = flag;
		Dialog.RefreshIsFree.SetSelectedIndex(0);
	}

	private void ConfirmClickEvent()
	{
		if (_hasRareStoreItem)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GVGStoreRareStoreItemRefreshConfirmPanel.Name, null);
		}
		else
		{
			ConfirmExchange();
		}
	}

	private void ConfirmExchange()
	{
		SharedMessenger.Broadcast("UPDATE_GVG_STORE_ITEMS", arg1: true);
		End();
	}
}
