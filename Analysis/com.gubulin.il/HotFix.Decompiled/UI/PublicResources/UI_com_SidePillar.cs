using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_SidePillar : GComponent
{
	public GImage n1;

	public GImage n0;

	public const string URL = "ui://kt6rg65os0hbv4uw";

	public static string Name = "UI_com_SidePillar";

	public static string GetURL()
	{
		return "ui://kt6rg65os0hbv4uw";
	}

	public static UI_com_SidePillar CreateInstance()
	{
		return (UI_com_SidePillar)(object)UIPackage.CreateObject("PublicResources", "com_SidePillar");
	}

	public static UI_com_SidePillar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SidePillar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65os0hbv4uw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n0 = (GImage)((GComponent)this).GetChild("n0");
	}
}
