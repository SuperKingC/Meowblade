using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_InfoBtn : GButton
{
	public Controller button;

	public GTextField title;

	public GImage note;

	public const string URL = "ui://b9wlonaqtpmt2";

	public static string Name = "UI_InfoBtn";

	public static string GetURL()
	{
		return "ui://b9wlonaqtpmt2";
	}

	public static UI_InfoBtn CreateInstance()
	{
		return (UI_InfoBtn)(object)UIPackage.CreateObject("LegendItemCultivation", "InfoBtn");
	}

	public static UI_InfoBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InfoBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqtpmt2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://b9wlonaqtpmt2".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
