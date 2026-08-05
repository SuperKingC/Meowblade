using FairyGUI;
using FairyGUI.Utils;

namespace UI.Guide;

public class UI_FrameBorder : GComponent
{
	public GImage img;

	public Transition breathe;

	public const string URL = "ui://5vxjvcrbg6t9s";

	public static string Name = "UI_FrameBorder";

	public static string GetURL()
	{
		return "ui://5vxjvcrbg6t9s";
	}

	public static UI_FrameBorder CreateInstance()
	{
		return (UI_FrameBorder)(object)UIPackage.CreateObject("Guide", "FrameBorder");
	}

	public static UI_FrameBorder CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FrameBorder).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5vxjvcrbg6t9s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		img = (GImage)((GComponent)this).GetChild("img");
		breathe = ((GComponent)this).GetTransition("breathe");
	}
}
