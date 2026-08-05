using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_RealDrawBack : GComponent
{
	public GLoader Image;

	public const string URL = "ui://kozswd8h10luf23";

	public static string Name = "UI_RealDrawBack";

	public static string GetURL()
	{
		return "ui://kozswd8h10luf23";
	}

	public static UI_RealDrawBack CreateInstance()
	{
		return (UI_RealDrawBack)(object)UIPackage.CreateObject("SpecialActivity", "RealDrawBack");
	}

	public static UI_RealDrawBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RealDrawBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8h10luf23", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
