using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_btn_Back : GButton
{
	public Controller button;

	public GImage n3;

	public GLoader icon;

	public const string URL = "ui://91jxdrkanc8f14";

	public static string Name = "UI_btn_Back";

	public static string GetURL()
	{
		return "ui://91jxdrkanc8f14";
	}

	public static UI_btn_Back CreateInstance()
	{
		return (UI_btn_Back)(object)UIPackage.CreateObject("GvGSettlement", "btn_Back");
	}

	public static UI_btn_Back CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Back).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkanc8f14", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
