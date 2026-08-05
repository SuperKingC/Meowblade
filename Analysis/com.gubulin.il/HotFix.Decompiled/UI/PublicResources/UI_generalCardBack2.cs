using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_generalCardBack2 : GButton
{
	public Controller button;

	public GImage n10;

	public const string URL = "ui://kt6rg65ot1tzfz";

	public static string Name = "UI_generalCardBack2";

	public static string GetURL()
	{
		return "ui://kt6rg65ot1tzfz";
	}

	public static UI_generalCardBack2 CreateInstance()
	{
		return (UI_generalCardBack2)(object)UIPackage.CreateObject("PublicResources", "generalCardBack2");
	}

	public static UI_generalCardBack2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_generalCardBack2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ot1tzfz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
