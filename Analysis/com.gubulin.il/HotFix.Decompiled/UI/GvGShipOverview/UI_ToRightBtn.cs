using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_ToRightBtn : GButton
{
	public GImage n123;

	public const string URL = "ui://7ymaonxtaa6p2f";

	public static string Name = "UI_ToRightBtn";

	public static string GetURL()
	{
		return "ui://7ymaonxtaa6p2f";
	}

	public static UI_ToRightBtn CreateInstance()
	{
		return (UI_ToRightBtn)(object)UIPackage.CreateObject("GvGShipOverview", "ToRightBtn");
	}

	public static UI_ToRightBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ToRightBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtaa6p2f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n123 = (GImage)((GComponent)this).GetChild("n123");
	}
}
