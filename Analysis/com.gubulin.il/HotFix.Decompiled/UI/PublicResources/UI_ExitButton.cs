using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_ExitButton : GButton
{
	public Controller button;

	public GImage n7;

	public const string URL = "ui://kt6rg65og21r4jv50u";

	public static string Name = "UI_ExitButton";

	public static string GetURL()
	{
		return "ui://kt6rg65og21r4jv50u";
	}

	public static UI_ExitButton CreateInstance()
	{
		return (UI_ExitButton)(object)UIPackage.CreateObject("PublicResources", "ExitButton");
	}

	public static UI_ExitButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExitButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65og21r4jv50u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
