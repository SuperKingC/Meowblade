using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_Confirm : GButton
{
	public Controller button;

	public GImage n4;

	public const string URL = "ui://k2sprg26uctj82";

	public static string Name = "UI_Confirm";

	public static string GetURL()
	{
		return "ui://k2sprg26uctj82";
	}

	public static UI_Confirm CreateInstance()
	{
		return (UI_Confirm)(object)UIPackage.CreateObject("IslandComeAgain", "Confirm");
	}

	public static UI_Confirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Confirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26uctj82", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
