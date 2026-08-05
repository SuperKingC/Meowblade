using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_dec_Light02 : GComponent
{
	public GImage n13;

	public Transition t0;

	public const string URL = "ui://p4ocf6q0whk917";

	public static string Name = "UI_dec_Light02";

	public static string GetURL()
	{
		return "ui://p4ocf6q0whk917";
	}

	public static UI_dec_Light02 CreateInstance()
	{
		return (UI_dec_Light02)(object)UIPackage.CreateObject("GvGRandomEvent3", "dec_Light02");
	}

	public static UI_dec_Light02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_Light02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0whk917", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n13 = (GImage)((GComponent)this).GetChild("n13");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
