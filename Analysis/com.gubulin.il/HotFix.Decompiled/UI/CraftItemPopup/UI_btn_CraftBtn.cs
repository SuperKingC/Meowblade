using FairyGUI;
using FairyGUI.Utils;

namespace UI.CraftItemPopup;

public class UI_btn_CraftBtn : GButton
{
	public Controller button;

	public GImage background;

	public GImage title;

	public const string URL = "ui://4pn38ozniuisd";

	public static string Name = "UI_btn_CraftBtn";

	public static string GetURL()
	{
		return "ui://4pn38ozniuisd";
	}

	public static UI_btn_CraftBtn CreateInstance()
	{
		return (UI_btn_CraftBtn)(object)UIPackage.CreateObject("CraftItemPopup", "btn_CraftBtn");
	}

	public static UI_btn_CraftBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CraftBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4pn38ozniuisd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		background = (GImage)((GComponent)this).GetChild("background");
		title = (GImage)((GComponent)this).GetChild("title");
	}
}
