using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_CloseBtn : GButton
{
	public GImage n112;

	public const string URL = "ui://pwrbvhpvlaby31";

	public static string Name = "UI_CloseBtn";

	public static string GetURL()
	{
		return "ui://pwrbvhpvlaby31";
	}

	public static UI_CloseBtn CreateInstance()
	{
		return (UI_CloseBtn)(object)UIPackage.CreateObject("GvGShipPopup", "CloseBtn");
	}

	public static UI_CloseBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CloseBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvlaby31", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n112 = (GImage)((GComponent)this).GetChild("n112");
	}
}
