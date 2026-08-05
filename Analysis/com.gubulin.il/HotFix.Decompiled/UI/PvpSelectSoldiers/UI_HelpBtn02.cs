using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_HelpBtn02 : GButton
{
	public Controller button;

	public GImage n4;

	public GImage n5;

	public const string URL = "ui://82mo10n5xfypdo0";

	public static string Name = "UI_HelpBtn02";

	public static string GetURL()
	{
		return "ui://82mo10n5xfypdo0";
	}

	public static UI_HelpBtn02 CreateInstance()
	{
		return (UI_HelpBtn02)(object)UIPackage.CreateObject("PvpSelectSoldiers", "HelpBtn02");
	}

	public static UI_HelpBtn02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HelpBtn02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5xfypdo0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
