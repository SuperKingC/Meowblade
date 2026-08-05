using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_btn_SpecialTalent4 : GButton
{
	public Controller button;

	public Controller Status;

	public Controller Lv;

	public Controller OuterTechIsActive;

	public GImage n14;

	public GImage n15;

	public GLoader Icon;

	public GImage n17;

	public GImage n18;

	public GTextField TalentName;

	public UI_dec_TalentNoActive n23;

	public UI_dec_TalentOn n21;

	public GTextField Point;

	public UI_com_SpecialTalentInfo4 Desc;

	public const string URL = "ui://4r1llhd8qiaov";

	public static string Name = "UI_btn_SpecialTalent4";

	public static string GetURL()
	{
		return "ui://4r1llhd8qiaov";
	}

	public static UI_btn_SpecialTalent4 CreateInstance()
	{
		return (UI_btn_SpecialTalent4)(object)UIPackage.CreateObject("GvGTalent", "btn_SpecialTalent4");
	}

	public static UI_btn_SpecialTalent4 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SpecialTalent4).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8qiaov", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		Lv = ((GComponent)this).GetController("Lv");
		OuterTechIsActive = ((GComponent)this).GetController("OuterTechIsActive");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		TalentName = (GTextField)((GComponent)this).GetChild("TalentName");
		n23 = (UI_dec_TalentNoActive)(object)((GComponent)this).GetChild("n23");
		n21 = (UI_dec_TalentOn)(object)((GComponent)this).GetChild("n21");
		Point = (GTextField)((GComponent)this).GetChild("Point");
		Desc = (UI_com_SpecialTalentInfo4)(object)((GComponent)this).GetChild("Desc");
	}
}
