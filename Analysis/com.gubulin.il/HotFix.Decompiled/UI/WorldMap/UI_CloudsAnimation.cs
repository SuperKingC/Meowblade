using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_CloudsAnimation : GComponent
{
	public GLoader MapCloudLoader;

	public const string URL = "ui://c9n2h0ksm7wz9d";

	public static string Name = "UI_CloudsAnimation";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz9d";
	}

	public static UI_CloudsAnimation CreateInstance()
	{
		return (UI_CloudsAnimation)(object)UIPackage.CreateObject("WorldMap", "CloudsAnimation");
	}

	public static UI_CloudsAnimation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CloudsAnimation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz9d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		MapCloudLoader = (GLoader)((GComponent)this).GetChild("MapCloudLoader");
	}
}
