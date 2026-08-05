using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_eff_AvatarMe : GComponent
{
	public GImage n7;

	public Transition t0;

	public const string URL = "ui://ebc4ciwrelcgq61";

	public static string Name = "UI_eff_AvatarMe";

	public static string GetURL()
	{
		return "ui://ebc4ciwrelcgq61";
	}

	public static UI_eff_AvatarMe CreateInstance()
	{
		return (UI_eff_AvatarMe)(object)UIPackage.CreateObject("GvGOnIsland3", "eff_AvatarMe");
	}

	public static UI_eff_AvatarMe CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_AvatarMe).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrelcgq61", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
