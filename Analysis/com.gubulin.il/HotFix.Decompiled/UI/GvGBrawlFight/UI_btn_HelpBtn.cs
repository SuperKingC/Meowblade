using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_HelpBtn : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://hozu168rnt90a";

	public static string Name = "UI_btn_HelpBtn";

	public static string GetURL()
	{
		return "ui://hozu168rnt90a";
	}

	public static UI_btn_HelpBtn CreateInstance()
	{
		return (UI_btn_HelpBtn)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_HelpBtn");
	}

	public static UI_btn_HelpBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_HelpBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rnt90a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
