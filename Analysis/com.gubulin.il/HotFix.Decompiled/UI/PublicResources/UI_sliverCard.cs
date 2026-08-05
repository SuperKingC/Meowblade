using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_sliverCard : GButton
{
	public Controller button;

	public UI_sliverCardBack1 specialCardBack;

	public UI_sliverCardLight specialCardLight;

	public const string URL = "ui://kt6rg65ovecst9t";

	public static string Name = "UI_sliverCard";

	public static string GetURL()
	{
		return "ui://kt6rg65ovecst9t";
	}

	public static UI_sliverCard CreateInstance()
	{
		return (UI_sliverCard)(object)UIPackage.CreateObject("PublicResources", "sliverCard");
	}

	public static UI_sliverCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_sliverCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovecst9t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		specialCardBack = (UI_sliverCardBack1)(object)((GComponent)this).GetChild("specialCardBack");
		specialCardLight = (UI_sliverCardLight)(object)((GComponent)this).GetChild("specialCardLight");
	}
}
