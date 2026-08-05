using FairyGUI;
using FairyGUI.Utils;

namespace UI.CraftItemPopup;

public class UI_btn_ReduceButton : GButton
{
	public Controller button;

	public GImage back;

	public const string URL = "ui://4pn38ozniuisj";

	public static string Name = "UI_btn_ReduceButton";

	public static string GetURL()
	{
		return "ui://4pn38ozniuisj";
	}

	public static UI_btn_ReduceButton CreateInstance()
	{
		return (UI_btn_ReduceButton)(object)UIPackage.CreateObject("CraftItemPopup", "btn_ReduceButton");
	}

	public static UI_btn_ReduceButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ReduceButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4pn38ozniuisj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
	}
}
