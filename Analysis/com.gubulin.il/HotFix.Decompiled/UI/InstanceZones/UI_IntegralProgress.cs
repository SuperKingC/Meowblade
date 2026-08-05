using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_IntegralProgress : GComponent
{
	public UI_ProgressBar1 bar;

	public const string URL = "ui://f4wr270rjcdfl";

	public static string Name = "UI_IntegralProgress";

	public static string GetURL()
	{
		return "ui://f4wr270rjcdfl";
	}

	public static UI_IntegralProgress CreateInstance()
	{
		return (UI_IntegralProgress)(object)UIPackage.CreateObject("InstanceZones", "IntegralProgress");
	}

	public static UI_IntegralProgress CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IntegralProgress).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rjcdfl", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		bar = (UI_ProgressBar1)(object)((GComponent)this).GetChild("bar");
	}
}
