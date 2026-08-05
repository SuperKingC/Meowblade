using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_WindowLoader : GComponent
{
	public const string URL = "ui://kt6rg65o7n5ttll";

	public static string Name = "UI_WindowLoader";

	public static string GetURL()
	{
		return "ui://kt6rg65o7n5ttll";
	}

	public static UI_WindowLoader CreateInstance()
	{
		return (UI_WindowLoader)(object)UIPackage.CreateObject("PublicResources", "WindowLoader");
	}

	public static UI_WindowLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WindowLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65o7n5ttll", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
	}
}
