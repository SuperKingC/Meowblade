using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_ConfirmRebuildBtn : GButton
{
	public GImage n119;

	public GImage n121;

	public const string URL = "ui://pwrbvhpvirg26l";

	public static string Name = "UI_ConfirmRebuildBtn";

	public static string GetURL()
	{
		return "ui://pwrbvhpvirg26l";
	}

	public static UI_ConfirmRebuildBtn CreateInstance()
	{
		return (UI_ConfirmRebuildBtn)(object)UIPackage.CreateObject("GvGShipPopup", "ConfirmRebuildBtn");
	}

	public static UI_ConfirmRebuildBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmRebuildBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvirg26l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n119 = (GImage)((GComponent)this).GetChild("n119");
		n121 = (GImage)((GComponent)this).GetChild("n121");
	}
}
