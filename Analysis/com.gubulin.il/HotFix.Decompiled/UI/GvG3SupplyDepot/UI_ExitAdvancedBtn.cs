using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_ExitAdvancedBtn : GButton
{
	public Controller button;

	public GImage n5;

	public const string URL = "ui://pobej4q7kvzv15";

	public static string Name = "UI_ExitAdvancedBtn";

	public static string GetURL()
	{
		return "ui://pobej4q7kvzv15";
	}

	public static UI_ExitAdvancedBtn CreateInstance()
	{
		return (UI_ExitAdvancedBtn)(object)UIPackage.CreateObject("GvG3SupplyDepot", "ExitAdvancedBtn");
	}

	public static UI_ExitAdvancedBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExitAdvancedBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7kvzv15", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
