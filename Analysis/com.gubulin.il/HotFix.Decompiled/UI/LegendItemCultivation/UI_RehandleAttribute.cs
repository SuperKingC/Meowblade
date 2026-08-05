using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_RehandleAttribute : GButton
{
	public Controller button;

	public Controller TypeController;

	public Controller StateController;

	public GGraph n9;

	public GTextField title;

	public GTextField curAttributeName;

	public GTextField curValue;

	public GTextField newValue;

	public GTextField title1;

	public GTextField nextAttributeName;

	public GButton ConsumptionItem;

	public UI_Loack lockBtn;

	public const string URL = "ui://b9wlonaqtpmtg";

	public static string Name = "UI_RehandleAttribute";

	public static string GetURL()
	{
		return "ui://b9wlonaqtpmtg";
	}

	public static UI_RehandleAttribute CreateInstance()
	{
		return (UI_RehandleAttribute)(object)UIPackage.CreateObject("LegendItemCultivation", "RehandleAttribute");
	}

	public static UI_RehandleAttribute CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RehandleAttribute).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqtpmtg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		TypeController = ((GComponent)this).GetController("TypeController");
		StateController = ((GComponent)this).GetController("StateController");
		n9 = (GGraph)((GComponent)this).GetChild("n9");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://b9wlonaqtpmtg".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		curAttributeName = (GTextField)((GComponent)this).GetChild("curAttributeName");
		string id2 = "ui://b9wlonaqtpmtg".Replace("ui://", "") + "-" + ((GObject)curAttributeName).id;
		((GObject)curAttributeName).text = LanguagesManager.GetDesc(id2);
		curValue = (GTextField)((GComponent)this).GetChild("curValue");
		string id3 = "ui://b9wlonaqtpmtg".Replace("ui://", "") + "-" + ((GObject)curValue).id;
		((GObject)curValue).text = LanguagesManager.GetDesc(id3);
		newValue = (GTextField)((GComponent)this).GetChild("newValue");
		string id4 = "ui://b9wlonaqtpmtg".Replace("ui://", "") + "-" + ((GObject)newValue).id;
		((GObject)newValue).text = LanguagesManager.GetDesc(id4);
		title1 = (GTextField)((GComponent)this).GetChild("title1");
		string id5 = "ui://b9wlonaqtpmtg".Replace("ui://", "") + "-" + ((GObject)title1).id;
		((GObject)title1).text = LanguagesManager.GetDesc(id5);
		nextAttributeName = (GTextField)((GComponent)this).GetChild("nextAttributeName");
		string id6 = "ui://b9wlonaqtpmtg".Replace("ui://", "") + "-" + ((GObject)nextAttributeName).id;
		((GObject)nextAttributeName).text = LanguagesManager.GetDesc(id6);
		ConsumptionItem = (GButton)((GComponent)this).GetChild("ConsumptionItem");
		lockBtn = (UI_Loack)(object)((GComponent)this).GetChild("lockBtn");
	}
}
