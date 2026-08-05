using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_eff_AvatarTarget : GComponent
{
	public GImage n10;

	public Transition t0;

	public const string URL = "ui://ebc4ciwrelcgq5z";

	public static string Name = "UI_eff_AvatarTarget";

	public static string GetURL()
	{
		return "ui://ebc4ciwrelcgq5z";
	}

	public static UI_eff_AvatarTarget CreateInstance()
	{
		return (UI_eff_AvatarTarget)(object)UIPackage.CreateObject("GvGOnIsland3", "eff_AvatarTarget");
	}

	public static UI_eff_AvatarTarget CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_AvatarTarget).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrelcgq5z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n10 = (GImage)((GComponent)this).GetChild("n10");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
