using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_GoToDrawSoldier : GButton
{
	public Controller button;

	public GImage n6;

	public GImage n12;

	public const string URL = "ui://kozswd8hruzr1p";

	public static string Name = "UI_GoToDrawSoldier";

	public static string GetURL()
	{
		return "ui://kozswd8hruzr1p";
	}

	public static UI_GoToDrawSoldier CreateInstance()
	{
		return (UI_GoToDrawSoldier)(object)UIPackage.CreateObject("SpecialActivity", "GoToDrawSoldier");
	}

	public static UI_GoToDrawSoldier CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GoToDrawSoldier).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hruzr1p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n12 = (GImage)((GComponent)this).GetChild("n12");
	}
}
