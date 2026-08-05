using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_specialCard : GButton
{
	public Controller button;

	public UI_specialCardBack1 specialCardBack;

	public UI_specialCardLight specialCardLight;

	public const string URL = "ui://kt6rg65ovv0uf5";

	public static string Name = "UI_specialCard";

	public static string GetURL()
	{
		return "ui://kt6rg65ovv0uf5";
	}

	public static UI_specialCard CreateInstance()
	{
		return (UI_specialCard)(object)UIPackage.CreateObject("PublicResources", "specialCard");
	}

	public static UI_specialCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_specialCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovv0uf5", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		specialCardBack = (UI_specialCardBack1)(object)((GComponent)this).GetChild("specialCardBack");
		specialCardLight = (UI_specialCardLight)(object)((GComponent)this).GetChild("specialCardLight");
	}
}
