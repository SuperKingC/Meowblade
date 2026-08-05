using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_com_ChangeNameBtn : GButton
{
	public GImage n88;

	public GGraph n89;

	public const string URL = "ui://pwrbvhpvk5n86r";

	public static string Name = "UI_com_ChangeNameBtn";

	public static string GetURL()
	{
		return "ui://pwrbvhpvk5n86r";
	}

	public static UI_com_ChangeNameBtn CreateInstance()
	{
		return (UI_com_ChangeNameBtn)(object)UIPackage.CreateObject("GvGShipPopup", "com_ChangeNameBtn");
	}

	public static UI_com_ChangeNameBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ChangeNameBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvk5n86r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n88 = (GImage)((GComponent)this).GetChild("n88");
		n89 = (GGraph)((GComponent)this).GetChild("n89");
	}
}
