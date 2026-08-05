using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_Effect01 : GComponent
{
	public GLoader icon;

	public GMovieClip n56;

	public Transition t0;

	public const string URL = "ui://fvc33k3ges3n4j";

	public static string Name = "UI_com_Effect01";

	public static string GetURL()
	{
		return "ui://fvc33k3ges3n4j";
	}

	public static UI_com_Effect01 CreateInstance()
	{
		return (UI_com_Effect01)(object)UIPackage.CreateObject("GVGStore", "com_Effect01");
	}

	public static UI_com_Effect01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Effect01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3ges3n4j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n56 = (GMovieClip)((GComponent)this).GetChild("n56");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
