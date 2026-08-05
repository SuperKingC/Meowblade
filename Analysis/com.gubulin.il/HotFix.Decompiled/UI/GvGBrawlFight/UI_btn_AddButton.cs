using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_AddButton : GButton
{
	public Controller button;

	public GImage back;

	public const string URL = "ui://hozu168rear793";

	public static string Name = "UI_btn_AddButton";

	public static string GetURL()
	{
		return "ui://hozu168rear793";
	}

	public static UI_btn_AddButton CreateInstance()
	{
		return (UI_btn_AddButton)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_AddButton");
	}

	public static UI_btn_AddButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_AddButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rear793", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
	}
}
