using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_AreaHighlightLoader : GComponent
{
	public const string URL = "ui://c9n2h0ksm7wz60";

	public static string Name = "UI_AreaHighlightLoader";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz60";
	}

	public static UI_AreaHighlightLoader CreateInstance()
	{
		return (UI_AreaHighlightLoader)(object)UIPackage.CreateObject("WorldMap", "AreaHighlightLoader");
	}

	public static UI_AreaHighlightLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AreaHighlightLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz60", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
	}
}
