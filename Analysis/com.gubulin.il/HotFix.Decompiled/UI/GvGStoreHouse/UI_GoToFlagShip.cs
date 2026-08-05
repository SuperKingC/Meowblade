using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGStoreHouse;

public class UI_GoToFlagShip : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n4;

	public const string URL = "ui://6ym14r0de8zud";

	public static string Name = "UI_GoToFlagShip";

	public static string GetURL()
	{
		return "ui://6ym14r0de8zud";
	}

	public static UI_GoToFlagShip CreateInstance()
	{
		return (UI_GoToFlagShip)(object)UIPackage.CreateObject("GvGStoreHouse", "GoToFlagShip");
	}

	public static UI_GoToFlagShip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GoToFlagShip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://6ym14r0de8zud", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
