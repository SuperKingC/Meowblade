using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_aimLogo : GButton
{
	public Controller button;

	public GLoader aimIcon;

	public const string URL = "ui://zko5n3velkzgc";

	public static string Name = "UI_aimLogo";

	public static string GetURL()
	{
		return "ui://zko5n3velkzgc";
	}

	public static UI_aimLogo CreateInstance()
	{
		return (UI_aimLogo)(object)UIPackage.CreateObject("PrinceOfTheDevils", "aimLogo");
	}

	public static UI_aimLogo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_aimLogo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3velkzgc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		aimIcon = (GLoader)((GComponent)this).GetChild("aimIcon");
	}
}
