using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_ShipSkinBtn : GButton
{
	public GImage ShipSkin;

	public const string URL = "ui://u6x0b1gnvm144r";

	public static string Name = "UI_btn_ShipSkinBtn";

	public static string GetURL()
	{
		return "ui://u6x0b1gnvm144r";
	}

	public static UI_btn_ShipSkinBtn CreateInstance()
	{
		return (UI_btn_ShipSkinBtn)(object)UIPackage.CreateObject("GvGShipDetail", "btn_ShipSkinBtn");
	}

	public static UI_btn_ShipSkinBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ShipSkinBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnvm144r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ShipSkin = (GImage)((GComponent)this).GetChild("ShipSkin");
	}
}
