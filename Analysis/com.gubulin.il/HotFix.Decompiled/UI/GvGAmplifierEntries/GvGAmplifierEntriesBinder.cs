using FairyGUI;

namespace UI.GvGAmplifierEntries;

public class GvGAmplifierEntriesBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://f1wmtifub4va0", typeof(UI_GvGAmplifierEntriesPanel));
		UIObjectFactory.SetPackageItemExtension("ui://f1wmtifub4va1", typeof(UI_com_Title));
		UIObjectFactory.SetPackageItemExtension("ui://f1wmtifub4va13", typeof(UI_btn_StorageEntry));
		UIObjectFactory.SetPackageItemExtension("ui://f1wmtifub4va14", typeof(UI_btn_ForgeEntry));
		UIObjectFactory.SetPackageItemExtension("ui://f1wmtifuir181f", typeof(UI_dec_Particleeffect));
		UIObjectFactory.SetPackageItemExtension("ui://f1wmtifuir181h", typeof(UI_dec_Particleeffect2));
	}
}
