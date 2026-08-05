using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_general_green_t : GButton
{
	public Controller button;

	public GImage n9;

	public GTextField title;

	public const string URL = "ui://kt6rg65okrdr4jv503";

	public static string Name = "UI_general_green_t";

	public static string GetURL()
	{
		return "ui://kt6rg65okrdr4jv503";
	}

	public static UI_general_green_t CreateInstance()
	{
		return (UI_general_green_t)(object)UIPackage.CreateObject("PublicResources", "general_green_t");
	}

	public static UI_general_green_t CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_general_green_t).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65okrdr4jv503", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n9 = (GImage)((GComponent)this).GetChild("n9");
		title = (GTextField)((GComponent)this).GetChild("title");
	}
}
