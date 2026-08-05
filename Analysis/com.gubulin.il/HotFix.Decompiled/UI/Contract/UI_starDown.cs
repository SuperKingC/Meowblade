using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_starDown : GComponent
{
	public GGraph graph;

	public Transition t0;

	public const string URL = "ui://avplaivdkn9ks";

	public static string Name = "UI_starDown";

	public static string GetURL()
	{
		return "ui://avplaivdkn9ks";
	}

	public static UI_starDown CreateInstance()
	{
		return (UI_starDown)(object)UIPackage.CreateObject("Contract", "starDown");
	}

	public static UI_starDown CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_starDown).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdkn9ks", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		graph = (GGraph)((GComponent)this).GetChild("graph");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
