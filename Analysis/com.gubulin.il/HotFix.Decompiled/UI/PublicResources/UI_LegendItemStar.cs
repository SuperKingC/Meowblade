using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_LegendItemStar : GComponent
{
	public Controller ClassController;

	public GLoader ClassIcon;

	public const string URL = "ui://kt6rg65onhmtvb8";

	public static string Name = "UI_LegendItemStar";

	public static string GetURL()
	{
		return "ui://kt6rg65onhmtvb8";
	}

	public static UI_LegendItemStar CreateInstance()
	{
		return (UI_LegendItemStar)(object)UIPackage.CreateObject("PublicResources", "LegendItemStar");
	}

	public static UI_LegendItemStar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemStar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65onhmtvb8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ClassController = ((GComponent)this).GetController("ClassController");
		ClassIcon = (GLoader)((GComponent)this).GetChild("ClassIcon");
	}
}
