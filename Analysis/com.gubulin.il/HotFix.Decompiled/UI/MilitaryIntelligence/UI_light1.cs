using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryIntelligence;

public class UI_light1 : GComponent
{
	public GImage n46;

	public Transition t1;

	public const string URL = "ui://nfd5v46ufm8z1h";

	public static string Name = "UI_light1";

	public static string GetURL()
	{
		return "ui://nfd5v46ufm8z1h";
	}

	public static UI_light1 CreateInstance()
	{
		return (UI_light1)(object)UIPackage.CreateObject("MilitaryIntelligence", "light1");
	}

	public static UI_light1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_light1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://nfd5v46ufm8z1h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n46 = (GImage)((GComponent)this).GetChild("n46");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
