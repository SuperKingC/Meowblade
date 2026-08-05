using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_btn_ConfirmCampBtn : GButton
{
	public GImage n119;

	public GImage n121;

	public const string URL = "ui://k19peou7dnvl29";

	public static string Name = "UI_btn_ConfirmCampBtn";

	public static string GetURL()
	{
		return "ui://k19peou7dnvl29";
	}

	public static UI_btn_ConfirmCampBtn CreateInstance()
	{
		return (UI_btn_ConfirmCampBtn)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_ConfirmCampBtn");
	}

	public static UI_btn_ConfirmCampBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ConfirmCampBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7dnvl29", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
