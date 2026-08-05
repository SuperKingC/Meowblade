using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Warehouse;

public class UI_btn_SwitchCollection : GButton
{
	public Controller button;

	public GTextField title;

	public GImage note;

	public const string URL = "ui://kh10nzowp7vm5";

	public static string Name = "UI_btn_SwitchCollection";

	public static string GetURL()
	{
		return "ui://kh10nzowp7vm5";
	}

	public static UI_btn_SwitchCollection CreateInstance()
	{
		return (UI_btn_SwitchCollection)(object)UIPackage.CreateObject("Warehouse", "btn_SwitchCollection");
	}

	public static UI_btn_SwitchCollection CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SwitchCollection).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kh10nzowp7vm5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://kh10nzowp7vm5".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
