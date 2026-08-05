using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprintTemplate;

public class UI_com_Entry : GComponent
{
	public GTextField EntryText;

	public GImage n0;

	public const string URL = "ui://se4hok01wrnf6";

	public static string Name = "UI_com_Entry";

	public static string GetURL()
	{
		return "ui://se4hok01wrnf6";
	}

	public static UI_com_Entry CreateInstance()
	{
		return (UI_com_Entry)(object)UIPackage.CreateObject("LegendItemBlueprintTemplate", "com_Entry");
	}

	public static UI_com_Entry CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Entry).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnf6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		EntryText = (GTextField)((GComponent)this).GetChild("EntryText");
		n0 = (GImage)((GComponent)this).GetChild("n0");
	}
}
