using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_ConfirmReplenishTroops : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n5;

	public const string URL = "ui://k2sprg26in7b3c";

	public static string Name = "UI_ConfirmReplenishTroops";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b3c";
	}

	public static UI_ConfirmReplenishTroops CreateInstance()
	{
		return (UI_ConfirmReplenishTroops)(object)UIPackage.CreateObject("IslandComeAgain", "ConfirmReplenishTroops");
	}

	public static UI_ConfirmReplenishTroops CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmReplenishTroops).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b3c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
