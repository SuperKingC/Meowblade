using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SplitBluePrint;

public class UI_btn_Enqueue : GButton
{
	public Controller button;

	public GImage n4;

	public GLoader n5;

	public const string URL = "ui://7uylntmmju1ul";

	public static string Name = "UI_btn_Enqueue";

	public static string GetURL()
	{
		return "ui://7uylntmmju1ul";
	}

	public static UI_btn_Enqueue CreateInstance()
	{
		return (UI_btn_Enqueue)(object)UIPackage.CreateObject("GvG3SplitBluePrint", "btn_Enqueue");
	}

	public static UI_btn_Enqueue CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Enqueue).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7uylntmmju1ul", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GLoader)((GComponent)this).GetChild("n5");
	}
}
