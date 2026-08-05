using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_ProgressBarForUi : GProgressBar
{
	public GImage n6;

	public GGraph bar;

	public GTextField time;

	public const string URL = "ui://kt6rg65oj93uj6";

	public static string Name = "UI_ProgressBarForUi";

	public static string GetURL()
	{
		return "ui://kt6rg65oj93uj6";
	}

	public static UI_ProgressBarForUi CreateInstance()
	{
		return (UI_ProgressBarForUi)(object)UIPackage.CreateObject("PublicResources", "ProgressBarForUi");
	}

	public static UI_ProgressBarForUi CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProgressBarForUi).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oj93uj6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		bar = (GGraph)((GComponent)this).GetChild("bar");
		time = (GTextField)((GComponent)this).GetChild("time");
	}
}
