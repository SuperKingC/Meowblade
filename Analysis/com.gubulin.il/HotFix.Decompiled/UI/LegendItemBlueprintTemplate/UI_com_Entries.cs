using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprintTemplate;

public class UI_com_Entries : GComponent
{
	public GTextField title0;

	public GImage n2;

	public GTextField title1;

	public GTextField MainEntry;

	public GTextField SubEntry;

	public GList NewEntries;

	public GImage line;

	public const string URL = "ui://se4hok01wrnf5";

	public static string Name = "UI_com_Entries";

	public static string GetURL()
	{
		return "ui://se4hok01wrnf5";
	}

	public static UI_com_Entries CreateInstance()
	{
		return (UI_com_Entries)(object)UIPackage.CreateObject("LegendItemBlueprintTemplate", "com_Entries");
	}

	public static UI_com_Entries CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Entries).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnf5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		title0 = (GTextField)((GComponent)this).GetChild("title0");
		string id = "ui://se4hok01wrnf5".Replace("ui://", "") + "-" + ((GObject)title0).id;
		((GObject)title0).text = LanguagesManager.GetDesc(id);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		title1 = (GTextField)((GComponent)this).GetChild("title1");
		string id2 = "ui://se4hok01wrnf5".Replace("ui://", "") + "-" + ((GObject)title1).id;
		((GObject)title1).text = LanguagesManager.GetDesc(id2);
		MainEntry = (GTextField)((GComponent)this).GetChild("MainEntry");
		SubEntry = (GTextField)((GComponent)this).GetChild("SubEntry");
		NewEntries = (GList)((GComponent)this).GetChild("NewEntries");
		line = (GImage)((GComponent)this).GetChild("line");
	}
}
