using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_ConfirmTroopsChange : GButton
{
	public Controller button;

	public GImage n0;

	public const string URL = "ui://k2sprg26njc896";

	public static string Name = "UI_ConfirmTroopsChange";

	public static string GetURL()
	{
		return "ui://k2sprg26njc896";
	}

	public static UI_ConfirmTroopsChange CreateInstance()
	{
		return (UI_ConfirmTroopsChange)(object)UIPackage.CreateObject("IslandComeAgain", "ConfirmTroopsChange");
	}

	public static UI_ConfirmTroopsChange CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmTroopsChange).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26njc896", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GImage)((GComponent)this).GetChild("n0");
	}
}
