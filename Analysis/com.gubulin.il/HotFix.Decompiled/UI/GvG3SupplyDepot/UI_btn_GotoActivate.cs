using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_btn_GotoActivate : GButton
{
	public Controller button;

	public GTextField n4;

	public GImage n5;

	public const string URL = "ui://pobej4q7mo53m";

	public static string Name = "UI_btn_GotoActivate";

	public static string GetURL()
	{
		return "ui://pobej4q7mo53m";
	}

	public static UI_btn_GotoActivate CreateInstance()
	{
		return (UI_btn_GotoActivate)(object)UIPackage.CreateObject("GvG3SupplyDepot", "btn_GotoActivate");
	}

	public static UI_btn_GotoActivate CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_GotoActivate).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7mo53m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://pobej4q7mo53m".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
