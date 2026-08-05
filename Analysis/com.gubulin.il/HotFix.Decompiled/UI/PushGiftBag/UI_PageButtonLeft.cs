using FairyGUI;
using FairyGUI.Utils;

namespace UI.PushGiftBag;

public class UI_PageButtonLeft : GButton
{
	public Controller button;

	public GImage n3;

	public GGraph n4;

	public const string URL = "ui://ume49e0adecw9";

	public static string Name = "UI_PageButtonLeft";

	public static string GetURL()
	{
		return "ui://ume49e0adecw9";
	}

	public static UI_PageButtonLeft CreateInstance()
	{
		return (UI_PageButtonLeft)(object)UIPackage.CreateObject("PushGiftBag", "PageButtonLeft");
	}

	public static UI_PageButtonLeft CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PageButtonLeft).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ume49e0adecw9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
