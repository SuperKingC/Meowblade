using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_item02 : GButton
{
	public Controller button;

	public GLoader itemIcon;

	public const string URL = "ui://hozu168rsdaq8m";

	public static string Name = "UI_btn_item02";

	public static string GetURL()
	{
		return "ui://hozu168rsdaq8m";
	}

	public static UI_btn_item02 CreateInstance()
	{
		return (UI_btn_item02)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_item02");
	}

	public static UI_btn_item02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_item02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rsdaq8m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		itemIcon = (GLoader)((GComponent)this).GetChild("itemIcon");
	}
}
