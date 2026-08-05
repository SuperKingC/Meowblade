using FairyGUI;
using FairyGUI.Utils;

namespace UI.GiftBag;

public class UI_PageItemBack : GButton
{
	public Controller button;

	public GImage n6;

	public const string URL = "ui://4fqsd8h6ay0l1j";

	public static string Name = "UI_PageItemBack";

	public static string GetURL()
	{
		return "ui://4fqsd8h6ay0l1j";
	}

	public static UI_PageItemBack CreateInstance()
	{
		return (UI_PageItemBack)(object)UIPackage.CreateObject("GiftBag", "PageItemBack");
	}

	public static UI_PageItemBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PageItemBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6ay0l1j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
