using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_com_DestroyShipBtn : GButton
{
	public GImage n89;

	public GImage n90;

	public const string URL = "ui://pwrbvhpvtglq6t";

	public static string Name = "UI_com_DestroyShipBtn";

	public static string GetURL()
	{
		return "ui://pwrbvhpvtglq6t";
	}

	public static UI_com_DestroyShipBtn CreateInstance()
	{
		return (UI_com_DestroyShipBtn)(object)UIPackage.CreateObject("GvGShipPopup", "com_DestroyShipBtn");
	}

	public static UI_com_DestroyShipBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_DestroyShipBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvtglq6t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n89 = (GImage)((GComponent)this).GetChild("n89");
		n90 = (GImage)((GComponent)this).GetChild("n90");
	}
}
