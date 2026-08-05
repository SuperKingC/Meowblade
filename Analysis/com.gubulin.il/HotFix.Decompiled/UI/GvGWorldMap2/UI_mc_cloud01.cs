using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_mc_cloud01 : GComponent
{
	public GImage n20;

	public Transition Zoom;

	public const string URL = "ui://hd2s9kukfu263q";

	public static string Name = "UI_mc_cloud01";

	public static string GetURL()
	{
		return "ui://hd2s9kukfu263q";
	}

	public static UI_mc_cloud01 CreateInstance()
	{
		return (UI_mc_cloud01)(object)UIPackage.CreateObject("GvGWorldMap2", "mc_cloud01");
	}

	public static UI_mc_cloud01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_cloud01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukfu263q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n20 = (GImage)((GComponent)this).GetChild("n20");
		Zoom = ((GComponent)this).GetTransition("Zoom");
	}
}
