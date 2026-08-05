using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_ProgressBar1 : GProgressBar
{
	public GImage bar;

	public GTextField experience;

	public const string URL = "ui://j611zmymgsom2c";

	public static string Name = "UI_ProgressBar1";

	public static string GetURL()
	{
		return "ui://j611zmymgsom2c";
	}

	public static UI_ProgressBar1 CreateInstance()
	{
		return (UI_ProgressBar1)(object)UIPackage.CreateObject("MainCity", "ProgressBar1");
	}

	public static UI_ProgressBar1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProgressBar1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmymgsom2c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		bar = (GImage)((GComponent)this).GetChild("bar");
		experience = (GTextField)((GComponent)this).GetChild("experience");
	}
}
