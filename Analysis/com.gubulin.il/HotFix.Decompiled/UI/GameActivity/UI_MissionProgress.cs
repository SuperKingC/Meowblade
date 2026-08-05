using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_MissionProgress : GProgressBar
{
	public GImage n0;

	public GImage bar;

	public const string URL = "ui://29q48tv6gawy15";

	public static string Name = "UI_MissionProgress";

	public static string GetURL()
	{
		return "ui://29q48tv6gawy15";
	}

	public static UI_MissionProgress CreateInstance()
	{
		return (UI_MissionProgress)(object)UIPackage.CreateObject("GameActivity", "MissionProgress");
	}

	public static UI_MissionProgress CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MissionProgress).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6gawy15", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		bar = (GImage)((GComponent)this).GetChild("bar");
	}
}
