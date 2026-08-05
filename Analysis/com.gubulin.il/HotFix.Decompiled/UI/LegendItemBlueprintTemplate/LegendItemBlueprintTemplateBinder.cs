using FairyGUI;

namespace UI.LegendItemBlueprintTemplate;

public class LegendItemBlueprintTemplateBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://se4hok019gdek", typeof(UI_com_RandomLegendItem));
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01fevsr", typeof(UI_btn_Lock));
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnf0", typeof(UI_main_LegendItemBlueprintTemplatePanel));
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnf1", typeof(UI_com_InfoDialog));
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnf3", typeof(UI_com_Content));
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnf4", typeof(UI_com_PreviewContent));
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnf5", typeof(UI_com_Entries));
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnf6", typeof(UI_com_Entry));
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnf7", typeof(UI_com_AllFx));
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnf8", typeof(UI_com_Propetry));
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnfc", typeof(UI_com_CostContent));
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnfg", typeof(UI_com_ContentBottom));
		UIObjectFactory.SetPackageItemExtension("ui://se4hok01wrnfj", typeof(UI_com_Scroll));
	}
}
