using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_eff_Star_1 : GComponent
{
	public GImage n0;

	public GImage n1;

	public GImage n2;

	public Transition t0;

	public const string URL = "ui://hda5vzklmeyj57";

	public static string Name = "UI_eff_Star_1";

	public static string GetURL()
	{
		return "ui://hda5vzklmeyj57";
	}

	public static UI_eff_Star_1 CreateInstance()
	{
		return (UI_eff_Star_1)(object)UIPackage.CreateObject("GameEndPanels", "eff_Star_1");
	}

	public static UI_eff_Star_1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_Star_1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklmeyj57", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
