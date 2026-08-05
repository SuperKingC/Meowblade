using FairyGUI;
using FairyGUI.Utils;

namespace UI.QuickBattle;

public class UI_FortRed : GButton
{
	public Controller button;

	public Controller Type;

	public GImage back;

	public UI_OurHPbar HpBar;

	public Transition Down;

	public const string URL = "ui://kqd1t06oc5l21l";

	public static string Name = "UI_FortRed";

	public static string GetURL()
	{
		return "ui://kqd1t06oc5l21l";
	}

	public static UI_FortRed CreateInstance()
	{
		return (UI_FortRed)(object)UIPackage.CreateObject("QuickBattle", "FortRed");
	}

	public static UI_FortRed CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FortRed).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06oc5l21l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		back = (GImage)((GComponent)this).GetChild("back");
		HpBar = (UI_OurHPbar)(object)((GComponent)this).GetChild("HpBar");
		Down = ((GComponent)this).GetTransition("Down");
	}
}
