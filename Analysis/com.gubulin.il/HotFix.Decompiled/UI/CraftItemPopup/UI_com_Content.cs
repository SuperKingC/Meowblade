using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.CraftItemPopup;

public class UI_com_Content : GComponent
{
	public GLoader icon;

	public GGraph SfxBack;

	public GTextField stockNumTitle;

	public GTextField stockNum;

	public GGraph line;

	public GTextField title;

	public GTextField Property;

	public GTextField Access;

	public const string URL = "ui://4pn38ozniuisf";

	public static string Name = "UI_com_Content";

	public static string GetURL()
	{
		return "ui://4pn38ozniuisf";
	}

	public static UI_com_Content CreateInstance()
	{
		return (UI_com_Content)(object)UIPackage.CreateObject("CraftItemPopup", "com_Content");
	}

	public static UI_com_Content CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Content).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4pn38ozniuisf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		icon = (GLoader)((GComponent)this).GetChild("icon");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		stockNumTitle = (GTextField)((GComponent)this).GetChild("stockNumTitle");
		string id = "ui://4pn38ozniuisf".Replace("ui://", "") + "-" + ((GObject)stockNumTitle).id;
		((GObject)stockNumTitle).text = LanguagesManager.GetDesc(id);
		stockNum = (GTextField)((GComponent)this).GetChild("stockNum");
		line = (GGraph)((GComponent)this).GetChild("line");
		title = (GTextField)((GComponent)this).GetChild("title");
		Property = (GTextField)((GComponent)this).GetChild("Property");
		Access = (GTextField)((GComponent)this).GetChild("Access");
	}
}
