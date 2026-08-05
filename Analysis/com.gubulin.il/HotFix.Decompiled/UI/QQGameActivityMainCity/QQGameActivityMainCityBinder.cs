using FairyGUI;

namespace UI.QQGameActivityMainCity;

public class QQGameActivityMainCityBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://z947bpf8iianv45o", typeof(UI_QQGameBigPlayerCom));
		UIObjectFactory.SetPackageItemExtension("ui://z947bpf8k09cv45u", typeof(UI_AgreementCom));
		UIObjectFactory.SetPackageItemExtension("ui://z947bpf8mzr9v45p", typeof(UI_QQGameGiftBtn));
		UIObjectFactory.SetPackageItemExtension("ui://z947bpf8mzr9v45r", typeof(UI_QQGameBigPlayerBtn));
		UIObjectFactory.SetPackageItemExtension("ui://z947bpf8rbbwv45w", typeof(UI_btn_01));
		UIObjectFactory.SetPackageItemExtension("ui://z947bpf8rbbwv45x", typeof(UI_btn_02));
		UIObjectFactory.SetPackageItemExtension("ui://z947bpf8rbbwv45y", typeof(UI_btn_03));
	}
}
