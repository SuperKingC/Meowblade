using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierOnShip;

public class UI_btn_OneClickUnload : GButton
{
	public GImage n154;

	public GTextField title;

	public const string URL = "ui://pwlamcyxgp16r";

	public static string Name = "UI_btn_OneClickUnload";

	public static string GetURL()
	{
		return "ui://pwlamcyxgp16r";
	}

	public static UI_btn_OneClickUnload CreateInstance()
	{
		return (UI_btn_OneClickUnload)(object)UIPackage.CreateObject("GvGAmplifierOnShip", "btn_OneClickUnload");
	}

	public static UI_btn_OneClickUnload CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_OneClickUnload).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwlamcyxgp16r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n154 = (GImage)((GComponent)this).GetChild("n154");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://pwlamcyxgp16r".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
