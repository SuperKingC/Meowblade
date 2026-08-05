using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_GotoIslandRecord : GButton
{
	public Controller button;

	public Controller Status;

	public GImage n3;

	public const string URL = "ui://hozu168rk7me4x";

	public static string Name = "UI_btn_GotoIslandRecord";

	public static string GetURL()
	{
		return "ui://hozu168rk7me4x";
	}

	public static UI_btn_GotoIslandRecord CreateInstance()
	{
		return (UI_btn_GotoIslandRecord)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_GotoIslandRecord");
	}

	public static UI_btn_GotoIslandRecord CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_GotoIslandRecord).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rk7me4x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
