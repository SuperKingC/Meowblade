using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemDungeon;

public class UI_PresetFormationBtn : GButton
{
	public Controller button;

	public GImage Back;

	public GRichTextField title;

	public const string URL = "ui://2eraz3j9l53y1v";

	public static string Name = "UI_PresetFormationBtn";

	public static string GetURL()
	{
		return "ui://2eraz3j9l53y1v";
	}

	public static UI_PresetFormationBtn CreateInstance()
	{
		return (UI_PresetFormationBtn)(object)UIPackage.CreateObject("LegendItemDungeon", "PresetFormationBtn");
	}

	public static UI_PresetFormationBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PresetFormationBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2eraz3j9l53y1v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Back = (GImage)((GComponent)this).GetChild("Back");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://2eraz3j9l53y1v".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
