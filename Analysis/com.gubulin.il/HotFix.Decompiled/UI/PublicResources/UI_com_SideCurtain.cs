using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_SideCurtain : GComponent
{
	public GImage n0;

	public Transition t0;

	public const string URL = "ui://kt6rg65os0hbv4uu";

	public static string Name = "UI_com_SideCurtain";

	public static string GetURL()
	{
		return "ui://kt6rg65os0hbv4uu";
	}

	public static UI_com_SideCurtain CreateInstance()
	{
		return (UI_com_SideCurtain)(object)UIPackage.CreateObject("PublicResources", "com_SideCurtain");
	}

	public static UI_com_SideCurtain CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SideCurtain).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65os0hbv4uu", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
