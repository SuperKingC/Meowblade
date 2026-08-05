using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_ChangeNameBtn : GButton
{
	public GImage n88;

	public const string URL = "ui://u6x0b1gnzpu41m";

	public static string Name = "UI_btn_ChangeNameBtn";

	public static string GetURL()
	{
		return "ui://u6x0b1gnzpu41m";
	}

	public static UI_btn_ChangeNameBtn CreateInstance()
	{
		return (UI_btn_ChangeNameBtn)(object)UIPackage.CreateObject("GvGShipDetail", "btn_ChangeNameBtn");
	}

	public static UI_btn_ChangeNameBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ChangeNameBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnzpu41m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n88 = (GImage)((GComponent)this).GetChild("n88");
	}
}
