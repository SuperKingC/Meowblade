using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_WarReport : GButton
{
	public Controller button;

	public GImage n7;

	public GImage n8;

	public const string URL = "ui://82mo10n5frebax";

	public static string Name = "UI_WarReport";

	public static string GetURL()
	{
		return "ui://82mo10n5frebax";
	}

	public static UI_WarReport CreateInstance()
	{
		return (UI_WarReport)(object)UIPackage.CreateObject("PvpSelectSoldiers", "WarReport");
	}

	public static UI_WarReport CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WarReport).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5frebax", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
