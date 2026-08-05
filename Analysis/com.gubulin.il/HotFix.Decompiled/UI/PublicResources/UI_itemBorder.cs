using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_itemBorder : GButton
{
	public Controller button;

	public GImage n10;

	public const string URL = "ui://kt6rg65oh7oslp";

	public static string Name = "UI_itemBorder";

	public static string GetURL()
	{
		return "ui://kt6rg65oh7oslp";
	}

	public static UI_itemBorder CreateInstance()
	{
		return (UI_itemBorder)(object)UIPackage.CreateObject("PublicResources", "itemBorder");
	}

	public static UI_itemBorder CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_itemBorder).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oh7oslp", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
