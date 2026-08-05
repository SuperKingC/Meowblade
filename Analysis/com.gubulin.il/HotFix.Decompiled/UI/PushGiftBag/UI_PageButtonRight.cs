using FairyGUI;
using FairyGUI.Utils;

namespace UI.PushGiftBag;

public class UI_PageButtonRight : GButton
{
	public Controller button;

	public GImage n3;

	public GGraph n4;

	public const string URL = "ui://ume49e0adecwa";

	public static string Name = "UI_PageButtonRight";

	public static string GetURL()
	{
		return "ui://ume49e0adecwa";
	}

	public static UI_PageButtonRight CreateInstance()
	{
		return (UI_PageButtonRight)(object)UIPackage.CreateObject("PushGiftBag", "PageButtonRight");
	}

	public static UI_PageButtonRight CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PageButtonRight).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ume49e0adecwa", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GGraph)((GComponent)this).GetChild("n4");
	}
}
