using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_btn_CancelForge : GButton
{
	public Controller button;

	public GImage n7;

	public GLoader icon;

	public const string URL = "ui://h09dvkcgi2xa37";

	public static string Name = "UI_btn_CancelForge";

	public static string GetURL()
	{
		return "ui://h09dvkcgi2xa37";
	}

	public static UI_btn_CancelForge CreateInstance()
	{
		return (UI_btn_CancelForge)(object)UIPackage.CreateObject("LegendItemBlueprint", "btn_CancelForge");
	}

	public static UI_btn_CancelForge CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CancelForge).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgi2xa37", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
