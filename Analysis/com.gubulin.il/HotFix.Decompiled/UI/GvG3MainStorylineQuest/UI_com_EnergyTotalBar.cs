using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_com_EnergyTotalBar : GProgressBar
{
	public GImage bar;

	public const string URL = "ui://249h3k3dtoycs41";

	public static string Name = "UI_com_EnergyTotalBar";

	public static string GetURL()
	{
		return "ui://249h3k3dtoycs41";
	}

	public static UI_com_EnergyTotalBar CreateInstance()
	{
		return (UI_com_EnergyTotalBar)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "com_EnergyTotalBar");
	}

	public static UI_com_EnergyTotalBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_EnergyTotalBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dtoycs41", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
