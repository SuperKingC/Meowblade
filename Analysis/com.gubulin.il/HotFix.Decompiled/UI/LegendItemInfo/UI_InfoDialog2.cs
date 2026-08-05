using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemInfo;

public class UI_InfoDialog2 : GComponent
{
	public Controller Type;

	public Controller ClassController;

	public GImage back;

	public GTextField title0;

	public GImage n49;

	public GButton Icon;

	public UI_EquipBtn equipBtn;

	public GTextField title2;

	public GTextField primeAttribute;

	public GTextField primeTips;

	public GTextField title3;

	public GTextField score;

	public GList Entries;

	public UI_btn_ConfirmForgeCost ConfirmCostItem;

	public UI_btn_LegendItemLock Lock;

	public Transition t0;

	public const string URL = "ui://lzvt5p2vnadol";

	public static string Name = "UI_InfoDialog2";

	public static string GetURL()
	{
		return "ui://lzvt5p2vnadol";
	}

	public static UI_InfoDialog2 CreateInstance()
	{
		return (UI_InfoDialog2)(object)UIPackage.CreateObject("LegendItemInfo", "InfoDialog2");
	}

	public static UI_InfoDialog2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InfoDialog2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lzvt5p2vnadol", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		ClassController = ((GComponent)this).GetController("ClassController");
		back = (GImage)((GComponent)this).GetChild("back");
		title0 = (GTextField)((GComponent)this).GetChild("title0");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		Icon = (GButton)((GComponent)this).GetChild("Icon");
		equipBtn = (UI_EquipBtn)(object)((GComponent)this).GetChild("equipBtn");
		title2 = (GTextField)((GComponent)this).GetChild("title2");
		string id = "ui://lzvt5p2vnadol".Replace("ui://", "") + "-" + ((GObject)title2).id;
		((GObject)title2).text = LanguagesManager.GetDesc(id);
		primeAttribute = (GTextField)((GComponent)this).GetChild("primeAttribute");
		string id2 = "ui://lzvt5p2vnadol".Replace("ui://", "") + "-" + ((GObject)primeAttribute).id;
		((GObject)primeAttribute).text = LanguagesManager.GetDesc(id2);
		primeTips = (GTextField)((GComponent)this).GetChild("primeTips");
		string id3 = "ui://lzvt5p2vnadol".Replace("ui://", "") + "-" + ((GObject)primeTips).id;
		((GObject)primeTips).text = LanguagesManager.GetDesc(id3);
		title3 = (GTextField)((GComponent)this).GetChild("title3");
		string id4 = "ui://lzvt5p2vnadol".Replace("ui://", "") + "-" + ((GObject)title3).id;
		((GObject)title3).text = LanguagesManager.GetDesc(id4);
		score = (GTextField)((GComponent)this).GetChild("score");
		string id5 = "ui://lzvt5p2vnadol".Replace("ui://", "") + "-" + ((GObject)score).id;
		((GObject)score).text = LanguagesManager.GetDesc(id5);
		Entries = (GList)((GComponent)this).GetChild("Entries");
		ConfirmCostItem = (UI_btn_ConfirmForgeCost)(object)((GComponent)this).GetChild("ConfirmCostItem");
		Lock = (UI_btn_LegendItemLock)(object)((GComponent)this).GetChild("Lock");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
