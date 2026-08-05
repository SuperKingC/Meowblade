using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_accountInfoBtn : GButton
{
	public Controller button;

	public GTextField title;

	public GImage note;

	public const string URL = "ui://b9yxt7u0gw2m27";

	public static string Name = "UI_accountInfoBtn";

	public static string GetURL()
	{
		return "ui://b9yxt7u0gw2m27";
	}

	public static UI_accountInfoBtn CreateInstance()
	{
		return (UI_accountInfoBtn)(object)UIPackage.CreateObject("AccountInfo", "accountInfoBtn");
	}

	public static UI_accountInfoBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_accountInfoBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0gw2m27", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://b9yxt7u0gw2m27".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
