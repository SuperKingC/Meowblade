using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SplitBluePrint;

public class UI_com_ContentBottom : GComponent
{
	public Controller button;

	public GGraph n0;

	public const string URL = "ui://7uylntmmkq2d1a";

	public static string Name = "UI_com_ContentBottom";

	public static string GetURL()
	{
		return "ui://7uylntmmkq2d1a";
	}

	public static UI_com_ContentBottom CreateInstance()
	{
		return (UI_com_ContentBottom)(object)UIPackage.CreateObject("GvG3SplitBluePrint", "com_ContentBottom");
	}

	public static UI_com_ContentBottom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ContentBottom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7uylntmmkq2d1a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GGraph)((GComponent)this).GetChild("n0");
	}
}
