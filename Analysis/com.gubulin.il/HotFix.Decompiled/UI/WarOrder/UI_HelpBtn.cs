using FairyGUI;
using FairyGUI.Utils;

namespace UI.WarOrder;

public class UI_HelpBtn : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://ax280w58h2p03m";

	public static string Name = "UI_HelpBtn";

	public static string GetURL()
	{
		return "ui://ax280w58h2p03m";
	}

	public static UI_HelpBtn CreateInstance()
	{
		return (UI_HelpBtn)(object)UIPackage.CreateObject("WarOrder", "HelpBtn");
	}

	public static UI_HelpBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HelpBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58h2p03m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
