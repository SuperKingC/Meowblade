using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_HealthBar2 : GProgressBar
{
	public GImage bar;

	public const string URL = "ui://0i520nzmo3e9o8i";

	public static string Name = "UI_HealthBar2";

	public static string GetURL()
	{
		return "ui://0i520nzmo3e9o8i";
	}

	public static UI_HealthBar2 CreateInstance()
	{
		return (UI_HealthBar2)(object)UIPackage.CreateObject("LordOfDreams", "HealthBar2");
	}

	public static UI_HealthBar2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HealthBar2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmo3e9o8i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		bar = (GImage)((GComponent)this).GetChild("bar");
	}
}
