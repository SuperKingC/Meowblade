using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_DevilsIconBtn : GButton
{
	public Controller button;

	public GImage n5;

	public const string URL = "ui://82mo10n5frebaw";

	public static string Name = "UI_DevilsIconBtn";

	public static string GetURL()
	{
		return "ui://82mo10n5frebaw";
	}

	public static UI_DevilsIconBtn CreateInstance()
	{
		return (UI_DevilsIconBtn)(object)UIPackage.CreateObject("PvpSelectSoldiers", "DevilsIconBtn");
	}

	public static UI_DevilsIconBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DevilsIconBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5frebaw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
