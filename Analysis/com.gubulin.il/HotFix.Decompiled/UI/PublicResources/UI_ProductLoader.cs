using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_ProductLoader : GComponent
{
	public GLoader iconb;

	public GLoader icon;

	public const string URL = "ui://kt6rg65om7wzun2";

	public static string Name = "UI_ProductLoader";

	public static string GetURL()
	{
		return "ui://kt6rg65om7wzun2";
	}

	public static UI_ProductLoader CreateInstance()
	{
		return (UI_ProductLoader)(object)UIPackage.CreateObject("PublicResources", "ProductLoader");
	}

	public static UI_ProductLoader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProductLoader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65om7wzun2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		iconb = (GLoader)((GComponent)this).GetChild("iconb");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
