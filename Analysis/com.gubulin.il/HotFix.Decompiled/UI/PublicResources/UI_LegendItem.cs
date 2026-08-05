using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_LegendItem : GButton
{
	public Controller button;

	public Controller TypeController;

	public Controller ClassController;

	public GLoader FrameIcon;

	public GLoader Icon;

	public GLoader LvFrame;

	public GRichTextField Level;

	public UI_soldierNumBtn SoldierIcon;

	public GLoader ClassIcon;

	public GList ClassList;

	public GTextField name;

	public GTextField Tip;

	public GImage n14;

	public GImage removeBack;

	public GImage removeNote;

	public GTextField removeText;

	public const string URL = "ui://kt6rg65ov5cz5";

	public static string Name = "UI_LegendItem";

	public static string GetURL()
	{
		return "ui://kt6rg65ov5cz5";
	}

	public static UI_LegendItem CreateInstance()
	{
		return (UI_LegendItem)(object)UIPackage.CreateObject("PublicResources", "LegendItem");
	}

	public static UI_LegendItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ov5cz5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		TypeController = ((GComponent)this).GetController("TypeController");
		ClassController = ((GComponent)this).GetController("ClassController");
		FrameIcon = (GLoader)((GComponent)this).GetChild("FrameIcon");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		LvFrame = (GLoader)((GComponent)this).GetChild("LvFrame");
		Level = (GRichTextField)((GComponent)this).GetChild("Level");
		string id = "ui://kt6rg65ov5cz5".Replace("ui://", "") + "-" + ((GObject)Level).id;
		((GObject)Level).text = LanguagesManager.GetDesc(id);
		SoldierIcon = (UI_soldierNumBtn)(object)((GComponent)this).GetChild("SoldierIcon");
		ClassIcon = (GLoader)((GComponent)this).GetChild("ClassIcon");
		ClassList = (GList)((GComponent)this).GetChild("ClassList");
		name = (GTextField)((GComponent)this).GetChild("name");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		string id2 = "ui://kt6rg65ov5cz5".Replace("ui://", "") + "-" + ((GObject)Tip).id;
		((GObject)Tip).text = LanguagesManager.GetDesc(id2);
		n14 = (GImage)((GComponent)this).GetChild("n14");
		removeBack = (GImage)((GComponent)this).GetChild("removeBack");
		removeNote = (GImage)((GComponent)this).GetChild("removeNote");
		removeText = (GTextField)((GComponent)this).GetChild("removeText");
		string id3 = "ui://kt6rg65ov5cz5".Replace("ui://", "") + "-" + ((GObject)removeText).id;
		((GObject)removeText).text = LanguagesManager.GetDesc(id3);
	}
}
