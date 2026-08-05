using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_btn_SpecialTalent8 : GButton
{
	public Controller button;

	public Controller Status;

	public Controller Lv;

	public Controller OuterTechIsActive;

	public GImage n5;

	public GImage n6;

	public GLoader Icon;

	public GImage n8;

	public GImage n9;

	public GTextField TalentName;

	public UI_dec_TalentNoActive n14;

	public UI_dec_TalentOn n12;

	public GTextField Point;

	public UI_com_SpecialTalentInfo8 Desc;

	public const string URL = "ui://4r1llhd8qiaoz";

	public static string Name = "UI_btn_SpecialTalent8";

	public static string GetURL()
	{
		return "ui://4r1llhd8qiaoz";
	}

	public static UI_btn_SpecialTalent8 CreateInstance()
	{
		return (UI_btn_SpecialTalent8)(object)UIPackage.CreateObject("GvGTalent", "btn_SpecialTalent8");
	}

	public static UI_btn_SpecialTalent8 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SpecialTalent8).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8qiaoz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		TalentName = (GTextField)((GComponent)this).GetChild("TalentName");
		n14 = (UI_dec_TalentNoActive)(object)((GComponent)this).GetChild("n14");
		n12 = (UI_dec_TalentOn)(object)((GComponent)this).GetChild("n12");
		Point = (GTextField)((GComponent)this).GetChild("Point");
		Desc = (UI_com_SpecialTalentInfo8)(object)((GComponent)this).GetChild("Desc");
	}
}
