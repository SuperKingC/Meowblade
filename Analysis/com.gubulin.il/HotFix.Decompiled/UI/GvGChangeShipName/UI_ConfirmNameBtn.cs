using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGChangeShipName;

public class UI_ConfirmNameBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField title;

	public const string URL = "ui://3pjle3p4ntp93o";

	public static string Name = "UI_ConfirmNameBtn";

	public static string GetURL()
	{
		return "ui://3pjle3p4ntp93o";
	}

	public static UI_ConfirmNameBtn CreateInstance()
	{
		return (UI_ConfirmNameBtn)(object)UIPackage.CreateObject("GvGChangeShipName", "ConfirmNameBtn");
	}

	public static UI_ConfirmNameBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmNameBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3pjle3p4ntp93o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://3pjle3p4ntp93o".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
