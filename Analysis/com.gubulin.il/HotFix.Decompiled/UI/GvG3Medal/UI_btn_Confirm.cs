using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Medal;

public class UI_btn_Confirm : GButton
{
	public Controller button;

	public GImage n4;

	public GImage n3;

	public const string URL = "ui://g5hi1peon4czn";

	public static string Name = "UI_btn_Confirm";

	public static string GetURL()
	{
		return "ui://g5hi1peon4czn";
	}

	public static UI_btn_Confirm CreateInstance()
	{
		return (UI_btn_Confirm)(object)UIPackage.CreateObject("GvG3Medal", "btn_Confirm");
	}

	public static UI_btn_Confirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Confirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://g5hi1peon4czn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
