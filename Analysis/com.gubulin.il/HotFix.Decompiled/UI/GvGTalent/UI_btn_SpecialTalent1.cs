using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_btn_SpecialTalent1 : GButton
{
	public Controller button;

	public Controller Status;

	public Controller Lv;

	public Controller OuterTechIsActive;

	public GImage n4;

	public GImage n5;

	public GLoader Icon;

	public GImage n6;

	public GImage n7;

	public GTextField TalentName;

	public UI_dec_TalentNoActive n12;

	public UI_dec_TalentOn n10;

	public UI_com_SpecialTalentInfo1 Desc;

	public GTextField Point;

	public const string URL = "ui://4r1llhd8qiaos";

	public static string Name = "UI_btn_SpecialTalent1";

	public static string GetURL()
	{
		return "ui://4r1llhd8qiaos";
	}

	public static UI_btn_SpecialTalent1 CreateInstance()
	{
		return (UI_btn_SpecialTalent1)(object)UIPackage.CreateObject("GvGTalent", "btn_SpecialTalent1");
	}

	public static UI_btn_SpecialTalent1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SpecialTalent1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8qiaos", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		Lv = ((GComponent)this).GetController("Lv");
		OuterTechIsActive = ((GComponent)this).GetController("OuterTechIsActive");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		TalentName = (GTextField)((GComponent)this).GetChild("TalentName");
		n12 = (UI_dec_TalentNoActive)(object)((GComponent)this).GetChild("n12");
		n10 = (UI_dec_TalentOn)(object)((GComponent)this).GetChild("n10");
		Desc = (UI_com_SpecialTalentInfo1)(object)((GComponent)this).GetChild("Desc");
		Point = (GTextField)((GComponent)this).GetChild("Point");
	}
}
