using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_btn_ExchangeCoupon : GButton
{
	public Controller button;

	public Controller State;

	public GLoader icon;

	public const string URL = "ui://fvc33k3gr57r3d";

	public static string Name = "UI_btn_ExchangeCoupon";

	public static string GetURL()
	{
		return "ui://fvc33k3gr57r3d";
	}

	public static UI_btn_ExchangeCoupon CreateInstance()
	{
		return (UI_btn_ExchangeCoupon)(object)UIPackage.CreateObject("GVGStore", "btn_ExchangeCoupon");
	}

	public static UI_btn_ExchangeCoupon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ExchangeCoupon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gr57r3d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
