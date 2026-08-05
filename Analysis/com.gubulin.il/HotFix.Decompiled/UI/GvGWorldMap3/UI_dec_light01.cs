using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_dec_light01 : GComponent
{
	public GImage n5;

	public GImage n7;

	public GImage n6;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://4eq8fgd29m6ysar";

	public static string Name = "UI_dec_light01";

	public static string GetURL()
	{
		return "ui://4eq8fgd29m6ysar";
	}

	public static UI_dec_light01 CreateInstance()
	{
		return (UI_dec_light01)(object)UIPackage.CreateObject("GvGWorldMap3", "dec_light01");
	}

	public static UI_dec_light01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_light01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd29m6ysar", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
