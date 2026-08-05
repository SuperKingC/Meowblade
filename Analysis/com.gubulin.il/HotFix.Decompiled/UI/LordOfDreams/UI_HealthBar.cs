using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_HealthBar : GProgressBar
{
	public GImage bar;

	public const string URL = "ui://0i520nzmo3e9o8h";

	public static string Name = "UI_HealthBar";

	public static string GetURL()
	{
		return "ui://0i520nzmo3e9o8h";
	}

	public static UI_HealthBar CreateInstance()
	{
		return (UI_HealthBar)(object)UIPackage.CreateObject("LordOfDreams", "HealthBar");
	}

	public static UI_HealthBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HealthBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmo3e9o8h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
