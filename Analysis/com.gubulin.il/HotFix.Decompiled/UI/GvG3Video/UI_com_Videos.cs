using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Video;

public class UI_com_Videos : GComponent
{
	public GList Videos;

	public const string URL = "ui://2itu6489ogcpr";

	public static string Name = "UI_com_Videos";

	public static string GetURL()
	{
		return "ui://2itu6489ogcpr";
	}

	public static UI_com_Videos CreateInstance()
	{
		return (UI_com_Videos)(object)UIPackage.CreateObject("GvG3Video", "com_Videos");
	}

	public static UI_com_Videos CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Videos).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489ogcpr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Videos = (GList)((GComponent)this).GetChild("Videos");
	}
}
