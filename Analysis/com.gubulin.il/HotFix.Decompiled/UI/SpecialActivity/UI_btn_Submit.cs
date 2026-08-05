using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_btn_Submit : GButton
{
	public Controller button;

	public GImage back;

	public GImage n6;

	public const string URL = "ui://kozswd8hpl78f3t";

	public static string Name = "UI_btn_Submit";

	public static string GetURL()
	{
		return "ui://kozswd8hpl78f3t";
	}

	public static UI_btn_Submit CreateInstance()
	{
		return (UI_btn_Submit)(object)UIPackage.CreateObject("SpecialActivity", "btn_Submit");
	}

	public static UI_btn_Submit CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Submit).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hpl78f3t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GImage)((GComponent)this).GetChild("back");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
