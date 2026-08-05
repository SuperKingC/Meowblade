using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SplitBluePrint;

public class UI_btn_Dequeue : GButton
{
	public Controller button;

	public GImage n5;

	public GLoader n6;

	public const string URL = "ui://7uylntmmju1um";

	public static string Name = "UI_btn_Dequeue";

	public static string GetURL()
	{
		return "ui://7uylntmmju1um";
	}

	public static UI_btn_Dequeue CreateInstance()
	{
		return (UI_btn_Dequeue)(object)UIPackage.CreateObject("GvG3SplitBluePrint", "btn_Dequeue");
	}

	public static UI_btn_Dequeue CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Dequeue).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7uylntmmju1um", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GLoader)((GComponent)this).GetChild("n6");
	}
}
