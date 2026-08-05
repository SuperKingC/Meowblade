using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_RechargeBack : GComponent
{
	public GLoader Image;

	public const string URL = "ui://kozswd8h10luf22";

	public static string Name = "UI_RechargeBack";

	public static string GetURL()
	{
		return "ui://kozswd8h10luf22";
	}

	public static UI_RechargeBack CreateInstance()
	{
		return (UI_RechargeBack)(object)UIPackage.CreateObject("SpecialActivity", "RechargeBack");
	}

	public static UI_RechargeBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RechargeBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8h10luf22", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Image = (GLoader)((GComponent)this).GetChild("Image");
	}
}
