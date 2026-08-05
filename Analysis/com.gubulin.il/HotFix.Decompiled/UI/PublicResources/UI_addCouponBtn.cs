using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;

namespace UI.PublicResources;

public class UI_addCouponBtn : GComponent
{
	public Controller button;

	public GImage n3;

	public UI_addButton addButton;

	public GLoader icon;

	public GGraph textSFXBack;

	public GTextField num;

	public const string URL = "ui://kt6rg65oo5taav";

	public static string Name = "UI_addCouponBtn";

	public string CurItemId;

	public static string GetURL()
	{
		return "ui://kt6rg65oo5taav";
	}

	public static UI_addCouponBtn CreateInstance()
	{
		return (UI_addCouponBtn)(object)UIPackage.CreateObject("PublicResources", "addCouponBtn");
	}

	public static UI_addCouponBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_addCouponBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oo5taav", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		addButton = (UI_addButton)(object)((GComponent)this).GetChild("addButton");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		textSFXBack = (GGraph)((GComponent)this).GetChild("textSFXBack");
		num = (GTextField)((GComponent)this).GetChild("num");
	}

	public void SetBtnIcon(string _itemId)
	{
		CurItemId = _itemId;
		icon.url = "ui://PublicResources/" + UiHelper.GetIcon(_itemId);
	}

	public void UpdateMoney(bool isInit = false)
	{
		int stock = GameManagers.Instance.StockController.GetStock(CurItemId);
		if (!isInit && ((GObject)this.num).data != null && (int)((GObject)this.num).data != stock)
		{
			int num = (int)((GObject)this.num).data;
			FGUIManager.Instance.AddNumFloatingForCouponBtn(UI_ProductionNumFloating.CreateInstance_ILRuntime(), (GComponent)(object)this, stock - num, 1, dispose: true);
		}
		((GObject)this.num).text = GameManagers.Instance.StockController.GetStock(CurItemId).ShortNumberFormat();
		((GObject)this.num).data = stock;
	}
}
