using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_com_EmptySpace : GComponent
{
	public const string URL = "ui://th385mtty63li";

	public static string Name = "UI_com_EmptySpace";

	public static string GetURL()
	{
		return "ui://th385mtty63li";
	}

	public static UI_com_EmptySpace CreateInstance()
	{
		return (UI_com_EmptySpace)(object)UIPackage.CreateObject("GvGOuterTech", "com_EmptySpace");
	}

	public static UI_com_EmptySpace CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_EmptySpace).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mtty63li", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
	}
}
