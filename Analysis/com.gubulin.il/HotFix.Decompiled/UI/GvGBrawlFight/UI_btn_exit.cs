using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_exit : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://hozu168rln2i99";

	public static string Name = "UI_btn_exit";

	public static string GetURL()
	{
		return "ui://hozu168rln2i99";
	}

	public static UI_btn_exit CreateInstance()
	{
		return (UI_btn_exit)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_exit");
	}

	public static UI_btn_exit CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_exit).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rln2i99", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
