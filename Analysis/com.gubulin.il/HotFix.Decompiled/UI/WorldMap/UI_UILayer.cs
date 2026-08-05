using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_UILayer : GComponent
{
	public const string URL = "ui://c9n2h0ksm7wz9w";

	public static string Name = "UI_UILayer";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz9w";
	}

	public static UI_UILayer CreateInstance()
	{
		return (UI_UILayer)(object)UIPackage.CreateObject("WorldMap", "UILayer");
	}

	public static UI_UILayer CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UILayer).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz9w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
	}
}
