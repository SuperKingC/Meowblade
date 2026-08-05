using FairyGUI;

namespace UI.UpGrade;

public class UpGradeBinder
{
	public static void BindAll()
	{
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hc01eb", typeof(UI_UpgradeDialog));
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hheurc", typeof(UI_increase));
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hheurd", typeof(UI_reduce));
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hheure", typeof(UI_workerBackItem));
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hheurf", typeof(UI_workerItem));
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hm4fq3g", typeof(UI_Main_UpGradePanel));
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hm4fq3h", typeof(UI_Main_UpgradeDialog));
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hm4fq5h", typeof(UI_exitBtn));
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hm4fq5m", typeof(UI_btn_01));
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hm4fq5n", typeof(UI_btn_02));
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hqp160", typeof(UI_UpGradePanel));
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hqp165", typeof(UI_Upgrade));
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hxfax5o", typeof(UI_com_goodItemConsume));
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hxfax5p", typeof(UI_com_consumptionText));
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hxfax5q", typeof(UI_jobSschedule));
	}
}
