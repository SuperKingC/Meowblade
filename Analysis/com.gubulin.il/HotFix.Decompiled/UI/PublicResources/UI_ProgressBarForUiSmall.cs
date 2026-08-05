using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_ProgressBarForUiSmall : GProgressBar
{
	public GImage n6;

	public GImage bar;

	public const string URL = "ui://kt6rg65otdyrv4b0";

	public static string Name = "UI_ProgressBarForUiSmall";

	public static string GetURL()
	{
		return "ui://kt6rg65otdyrv4b0";
	}

	public static UI_ProgressBarForUiSmall CreateInstance()
	{
		return (UI_ProgressBarForUiSmall)(object)UIPackage.CreateObject("PublicResources", "ProgressBarForUiSmall");
	}

	public static UI_ProgressBarForUiSmall CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProgressBarForUiSmall).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65otdyrv4b0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		bar = (GImage)((GComponent)this).GetChild("bar");
	}
}
