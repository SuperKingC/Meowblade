using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_HelpBtn : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://82mo10n5h2p0diy";

	public static string Name = "UI_HelpBtn";

	public static string GetURL()
	{
		return "ui://82mo10n5h2p0diy";
	}

	public static UI_HelpBtn CreateInstance()
	{
		return (UI_HelpBtn)(object)UIPackage.CreateObject("PvpSelectSoldiers", "HelpBtn");
	}

	public static UI_HelpBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HelpBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5h2p0diy", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
