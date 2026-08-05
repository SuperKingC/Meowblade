using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_general_yellow_b : GButton
{
	public Controller button;

	public GImage n8;

	public GLoader icon;

	public const string URL = "ui://kt6rg65opt5ov4v4";

	public static string Name = "UI_general_yellow_b";

	public static string GetURL()
	{
		return "ui://kt6rg65opt5ov4v4";
	}

	public static UI_general_yellow_b CreateInstance()
	{
		return (UI_general_yellow_b)(object)UIPackage.CreateObject("PublicResources", "general_yellow_b");
	}

	public static UI_general_yellow_b CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_general_yellow_b).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65opt5ov4v4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GImage)((GComponent)this).GetChild("n8");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
