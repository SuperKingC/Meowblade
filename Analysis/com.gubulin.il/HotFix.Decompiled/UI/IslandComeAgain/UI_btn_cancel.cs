using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_btn_cancel : GButton
{
	public Controller button;

	public GImage n12;

	public const string URL = "ui://k2sprg26rytnw";

	public static string Name = "UI_btn_cancel";

	public static string GetURL()
	{
		return "ui://k2sprg26rytnw";
	}

	public static UI_btn_cancel CreateInstance()
	{
		return (UI_btn_cancel)(object)UIPackage.CreateObject("IslandComeAgain", "btn_cancel");
	}

	public static UI_btn_cancel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_cancel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26rytnw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n12 = (GImage)((GComponent)this).GetChild("n12");
	}
}
