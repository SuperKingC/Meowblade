using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_ScrollBar1_grip : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://edr57v33oipil";

	public static string Name = "UI_ScrollBar1_grip";

	public static string GetURL()
	{
		return "ui://edr57v33oipil";
	}

	public static UI_ScrollBar1_grip CreateInstance()
	{
		return (UI_ScrollBar1_grip)(object)UIPackage.CreateObject("Mail", "ScrollBar1_grip");
	}

	public static UI_ScrollBar1_grip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScrollBar1_grip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33oipil", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
