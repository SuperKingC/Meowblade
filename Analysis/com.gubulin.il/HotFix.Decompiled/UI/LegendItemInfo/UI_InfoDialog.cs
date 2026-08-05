using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemInfo;

public class UI_InfoDialog : GComponent
{
	public Controller Type;

	public Controller ClassController;

	public Controller ExchangeBtnState;

	public GImage back;

	public GTextField title0;

	public UI_yes cultivation;

	public GButton Icon;

	public UI_no change;

	public UI_EquipBtn equipBtn;

	public GTextField title2;

	public GTextField primeAttribute;

	public UI_PropetryContent Content;

	public GTextField title3;

	public GTextField score;

	public GList Entries;

	public UI_btn_ConfirmForgeCost ConfirmCostItem;

	public UI_btn_CancelForge CancelForge;

	public UI_btn_LegendItemLock Lock;

	public GTextField n45;

	public GGroup n46;

	public const string URL = "ui://lzvt5p2vv5cz1";

	public static string Name = "UI_InfoDialog";

	public void SetButtonTitle()
	{
		((GObject)cultivation.title).text = LanguagesManager.GetDesc("LegendItemInfo-InfoDialog-cultivation-title");
	}

	public static string GetURL()
	{
		return "ui://lzvt5p2vv5cz1";
	}

	public static UI_InfoDialog CreateInstance()
	{
		return (UI_InfoDialog)(object)UIPackage.CreateObject("LegendItemInfo", "InfoDialog");
	}

	public static UI_InfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lzvt5p2vv5cz1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		ClassController = ((GComponent)this).GetController("ClassController");
		ExchangeBtnState = ((GComponent)this).GetController("ExchangeBtnState");
		back = (GImage)((GComponent)this).GetChild("back");
		title0 = (GTextField)((GComponent)this).GetChild("title0");
		cultivation = (UI_yes)(object)((GComponent)this).GetChild("cultivation");
		Icon = (GButton)((GComponent)this).GetChild("Icon");
		change = (UI_no)(object)((GComponent)this).GetChild("change");
		equipBtn = (UI_EquipBtn)(object)((GComponent)this).GetChild("equipBtn");
		title2 = (GTextField)((GComponent)this).GetChild("title2");
		string id = "ui://lzvt5p2vv5cz1".Replace("ui://", "") + "-" + ((GObject)title2).id;
		((GObject)title2).text = LanguagesManager.GetDesc(id);
		primeAttribute = (GTextField)((GComponent)this).GetChild("primeAttribute");
		string id2 = "ui://lzvt5p2vv5cz1".Replace("ui://", "") + "-" + ((GObject)primeAttribute).id;
		((GObject)primeAttribute).text = LanguagesManager.GetDesc(id2);
		Content = (UI_PropetryContent)(object)((GComponent)this).GetChild("Content");
		title3 = (GTextField)((GComponent)this).GetChild("title3");
		string id3 = "ui://lzvt5p2vv5cz1".Replace("ui://", "") + "-" + ((GObject)title3).id;
		((GObject)title3).text = LanguagesManager.GetDesc(id3);
		score = (GTextField)((GComponent)this).GetChild("score");
		string id4 = "ui://lzvt5p2vv5cz1".Replace("ui://", "") + "-" + ((GObject)score).id;
		((GObject)score).text = LanguagesManager.GetDesc(id4);
		Entries = (GList)((GComponent)this).GetChild("Entries");
		ConfirmCostItem = (UI_btn_ConfirmForgeCost)(object)((GComponent)this).GetChild("ConfirmCostItem");
		CancelForge = (UI_btn_CancelForge)(object)((GComponent)this).GetChild("CancelForge");
		Lock = (UI_btn_LegendItemLock)(object)((GComponent)this).GetChild("Lock");
		n45 = (GTextField)((GComponent)this).GetChild("n45");
		string id5 = "ui://lzvt5p2vv5cz1".Replace("ui://", "") + "-" + ((GObject)n45).id;
		((GObject)n45).text = LanguagesManager.GetDesc(id5);
		n46 = (GGroup)((GComponent)this).GetChild("n46");
	}
}
