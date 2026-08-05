using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItems;

public class UI_ScrollBarA_grip : GButton
{
	public Controller button;

	public GImage n2;

	public const string URL = "ui://l6qef30plud89";

	public static string Name = "UI_ScrollBarA_grip";

	public static string GetURL()
	{
		return "ui://l6qef30plud89";
	}

	public static UI_ScrollBarA_grip CreateInstance()
	{
		return (UI_ScrollBarA_grip)(object)UIPackage.CreateObject("LegendItems", "ScrollBarA_grip");
	}

	public static UI_ScrollBarA_grip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScrollBarA_grip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://l6qef30plud89", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n2 = (GImage)((GComponent)this).GetChild("n2");
	}
}
