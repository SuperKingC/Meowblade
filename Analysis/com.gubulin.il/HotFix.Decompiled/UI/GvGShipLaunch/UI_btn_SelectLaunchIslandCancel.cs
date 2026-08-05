using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipLaunch;

public class UI_btn_SelectLaunchIslandCancel : GButton
{
	public Controller button;

	public GImage n4;

	public const string URL = "ui://tc205cu3mony9";

	public static string Name = "UI_btn_SelectLaunchIslandCancel";

	public static string GetURL()
	{
		return "ui://tc205cu3mony9";
	}

	public static UI_btn_SelectLaunchIslandCancel CreateInstance()
	{
		return (UI_btn_SelectLaunchIslandCancel)(object)UIPackage.CreateObject("GvGShipLaunch", "btn_SelectLaunchIslandCancel");
	}

	public static UI_btn_SelectLaunchIslandCancel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SelectLaunchIslandCancel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tc205cu3mony9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
