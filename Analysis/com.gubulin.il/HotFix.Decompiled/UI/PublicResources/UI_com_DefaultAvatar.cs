using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_DefaultAvatar : GComponent
{
	public GGraph n0;

	public GImage n1;

	public const string URL = "ui://kt6rg65o8pruv4p7";

	public static string Name = "UI_com_DefaultAvatar";

	public static string GetURL()
	{
		return "ui://kt6rg65o8pruv4p7";
	}

	public static UI_com_DefaultAvatar CreateInstance()
	{
		return (UI_com_DefaultAvatar)(object)UIPackage.CreateObject("PublicResources", "com_DefaultAvatar");
	}

	public static UI_com_DefaultAvatar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_DefaultAvatar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65o8pruv4p7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
	}
}
