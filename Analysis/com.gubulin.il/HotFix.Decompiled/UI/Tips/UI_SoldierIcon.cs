using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_SoldierIcon : GButton
{
	public Controller button;

	public GTextField name;

	public GButton icon;

	public const string URL = "ui://47lbpgx9o21u4q";

	public static string Name = "UI_SoldierIcon";

	public static string GetURL()
	{
		return "ui://47lbpgx9o21u4q";
	}

	public static UI_SoldierIcon CreateInstance()
	{
		return (UI_SoldierIcon)(object)UIPackage.CreateObject("Tips", "SoldierIcon");
	}

	public static UI_SoldierIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9o21u4q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		name = (GTextField)((GComponent)this).GetChild("name");
		string id = "ui://47lbpgx9o21u4q".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id);
		icon = (GButton)((GComponent)this).GetChild("icon");
	}
}
