using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_ProgressBar1 : GProgressBar
{
	public GImage n0;

	public UI_scoreBar bar;

	public const string URL = "ui://f4wr270rmm8nh";

	public static string Name = "UI_ProgressBar1";

	public static string GetURL()
	{
		return "ui://f4wr270rmm8nh";
	}

	public static UI_ProgressBar1 CreateInstance()
	{
		return (UI_ProgressBar1)(object)UIPackage.CreateObject("InstanceZones", "ProgressBar1");
	}

	public static UI_ProgressBar1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProgressBar1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rmm8nh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		bar = (UI_scoreBar)(object)((GComponent)this).GetChild("bar");
	}
}
