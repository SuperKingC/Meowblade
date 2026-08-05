using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_generalCardBack1 : GButton
{
	public Controller button;

	public GImage n14;

	public GImage n15;

	public const string URL = "ui://kt6rg65ovv0uej";

	public static string Name = "UI_generalCardBack1";

	public static string GetURL()
	{
		return "ui://kt6rg65ovv0uej";
	}

	public static UI_generalCardBack1 CreateInstance()
	{
		return (UI_generalCardBack1)(object)UIPackage.CreateObject("PublicResources", "generalCardBack1");
	}

	public static UI_generalCardBack1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_generalCardBack1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovv0uej", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
	}
}
