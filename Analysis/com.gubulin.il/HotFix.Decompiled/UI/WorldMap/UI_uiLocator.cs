using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_uiLocator : GButton
{
	public Controller button;

	public GGraph n3;

	public const string URL = "ui://c9n2h0ksm7wz9i";

	public static string Name = "UI_uiLocator";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz9i";
	}

	public static UI_uiLocator CreateInstance()
	{
		return (UI_uiLocator)(object)UIPackage.CreateObject("WorldMap", "uiLocator");
	}

	public static UI_uiLocator CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_uiLocator).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz9i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GGraph)((GComponent)this).GetChild("n3");
	}
}
