using FairyGUI;

namespace UI.Certification;

public class CertificationBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqjbid3", typeof(UI_certificationBtn));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqjbid4", typeof(UI_CertificationPanel));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqjbid5", typeof(UI_CertificationTipDialog));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqjbid6", typeof(UI_goToCertificationBtn));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqjbid7", typeof(UI_CertificationWarningPanel));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqjbid8", typeof(UI_CertificationWarningDialog));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13tb", typeof(UI_CertificationNoticePanel));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13tc", typeof(UI_CertificationNoticeDialog));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13td", typeof(UI_CertificationMainPanel));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13te", typeof(UI_CertificationMainDialog));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13tf", typeof(UI_NoticeBtn));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13tg", typeof(UI_ConfirmBtn));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13tj", typeof(UI_CertificationTipPopup));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13tk", typeof(UI_CertificationDialog));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13tt", typeof(UI_Experience));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13tu", typeof(UI_GoToConfirmBtn));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqm13tv", typeof(UI_ExperienceBar));
		UIObjectFactory.SetPackageItemExtension("ui://56q48tcqqy9ww", typeof(UI_exchangeBtn));
	}
}
