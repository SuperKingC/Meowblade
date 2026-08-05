using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_btn_ConfirmForgeLarge : GButton
{
	public Controller button;

	public GImage n22;

	public GImage n21;

	public const string URL = "ui://h09dvkcgrtmo2a";

	public static string Name = "UI_btn_ConfirmForgeLarge";

	public static string GetURL()
	{
		return "ui://h09dvkcgrtmo2a";
	}

	public static UI_btn_ConfirmForgeLarge CreateInstance()
	{
		return (UI_btn_ConfirmForgeLarge)(object)UIPackage.CreateObject("LegendItemBlueprint", "btn_ConfirmForgeLarge");
	}

	public static UI_btn_ConfirmForgeLarge CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ConfirmForgeLarge).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgrtmo2a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n21 = (GImage)((GComponent)this).GetChild("n21");
	}
}
