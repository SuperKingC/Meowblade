using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_ConfirmBuildBtn : GButton
{
	public GImage n119;

	public GImage n121;

	public const string URL = "ui://pwrbvhpvlaby35";

	public static string Name = "UI_ConfirmBuildBtn";

	public static string GetURL()
	{
		return "ui://pwrbvhpvlaby35";
	}

	public static UI_ConfirmBuildBtn CreateInstance()
	{
		return (UI_ConfirmBuildBtn)(object)UIPackage.CreateObject("GvGShipPopup", "ConfirmBuildBtn");
	}

	public static UI_ConfirmBuildBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmBuildBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvlaby35", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
