using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Warehouse;

public class UI_switchGood : GButton
{
	public Controller button;

	public GTextField title;

	public GImage note;

	public const string URL = "ui://kh10nzowvv0u4";

	public static string Name = "UI_switchGood";

	public static string GetURL()
	{
		return "ui://kh10nzowvv0u4";
	}

	public static UI_switchGood CreateInstance()
	{
		return (UI_switchGood)(object)UIPackage.CreateObject("Warehouse", "switchGood");
	}

	public static UI_switchGood CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_switchGood).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kh10nzowvv0u4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://kh10nzowvv0u4".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
