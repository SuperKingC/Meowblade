using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_ScrollBarA_grip : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://zko5n3velkzgk";

	public static string Name = "UI_ScrollBarA_grip";

	public static string GetURL()
	{
		return "ui://zko5n3velkzgk";
	}

	public static UI_ScrollBarA_grip CreateInstance()
	{
		return (UI_ScrollBarA_grip)(object)UIPackage.CreateObject("PrinceOfTheDevils", "ScrollBarA_grip");
	}

	public static UI_ScrollBarA_grip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScrollBarA_grip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3velkzgk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
