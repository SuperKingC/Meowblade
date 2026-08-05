using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_btn_play : GButton
{
	public Controller button;

	public GImage n115;

	public const string URL = "ui://ebc4ciwrndngq6w";

	public static string Name = "UI_btn_play";

	public static string GetURL()
	{
		return "ui://ebc4ciwrndngq6w";
	}

	public static UI_btn_play CreateInstance()
	{
		return (UI_btn_play)(object)UIPackage.CreateObject("GvGOnIsland3", "btn_play");
	}

	public static UI_btn_play CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_play).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrndngq6w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n115 = (GImage)((GComponent)this).GetChild("n115");
	}
}
