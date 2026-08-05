using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_btn_ConfirmToMineBtn : GButton
{
	public GImage n102;

	public GImage n103;

	public const string URL = "ui://u6x0b1gnlyij2r";

	public static string Name = "UI_btn_ConfirmToMineBtn";

	public static string GetURL()
	{
		return "ui://u6x0b1gnlyij2r";
	}

	public static UI_btn_ConfirmToMineBtn CreateInstance()
	{
		return (UI_btn_ConfirmToMineBtn)(object)UIPackage.CreateObject("GvGShipDetail", "btn_ConfirmToMineBtn");
	}

	public static UI_btn_ConfirmToMineBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ConfirmToMineBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnlyij2r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n102 = (GImage)((GComponent)this).GetChild("n102");
		n103 = (GImage)((GComponent)this).GetChild("n103");
	}
}
