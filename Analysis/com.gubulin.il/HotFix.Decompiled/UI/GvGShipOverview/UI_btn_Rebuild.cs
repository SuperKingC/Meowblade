using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_btn_Rebuild : GButton
{
	public GImage n125;

	public const string URL = "ui://7ymaonxtpglz64";

	public static string Name = "UI_btn_Rebuild";

	public static string GetURL()
	{
		return "ui://7ymaonxtpglz64";
	}

	public static UI_btn_Rebuild CreateInstance()
	{
		return (UI_btn_Rebuild)(object)UIPackage.CreateObject("GvGShipOverview", "btn_Rebuild");
	}

	public static UI_btn_Rebuild CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Rebuild).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtpglz64", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n125 = (GImage)((GComponent)this).GetChild("n125");
	}
}
