using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_btn_CheckAbility : GButton
{
	public Controller button;

	public GImage n5;

	public GImage n6;

	public const string URL = "ui://ebc4ciwrts8025";

	public static string Name = "UI_btn_CheckAbility";

	public static string GetURL()
	{
		return "ui://ebc4ciwrts8025";
	}

	public static UI_btn_CheckAbility CreateInstance()
	{
		return (UI_btn_CheckAbility)(object)UIPackage.CreateObject("GvGOnIsland3", "btn_CheckAbility");
	}

	public static UI_btn_CheckAbility CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CheckAbility).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrts8025", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
