using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_TalentInfoDialog : GComponent
{
	public Controller Status;

	public Controller Type;

	public Controller hasOuterTech;

	public Controller hasOuterTech2;

	public GImage n11;

	public GImage n21;

	public GImage n15;

	public GImage n12;

	public GTextField TalentName;

	public GTextField n2;

	public UI_com_TalentDesc TalentDesc;

	public GTextField TypeName;

	public GLoader ConsumeIcon;

	public GTextField Num;

	public UI_btn_UnlockTalent Unlock;

	public GImage n9;

	public GTextField n10;

	public GLoader TalentIcon;

	public GButton OuterTechBuff;

	public GLoader outerTechIcon;

	public UI_com_RechargeTip RechargeTip;

	public UI_btn_OpenDormantPopup RechargeTipSwitch;

	public Transition t0;

	public const string URL = "ui://4r1llhd8xohkk";

	public static string Name = "UI_com_TalentInfoDialog";

	public static string GetURL()
	{
		return "ui://4r1llhd8xohkk";
	}

	public static UI_com_TalentInfoDialog CreateInstance()
	{
		return (UI_com_TalentInfoDialog)(object)UIPackage.CreateObject("GvGTalent", "com_TalentInfoDialog");
	}

	public static UI_com_TalentInfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_TalentInfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8xohkk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Type = ((GComponent)this).GetController("Type");
		hasOuterTech = ((GComponent)this).GetController("hasOuterTech");
		hasOuterTech2 = ((GComponent)this).GetController("hasOuterTech2");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		TalentName = (GTextField)((GComponent)this).GetChild("TalentName");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://4r1llhd8xohkk".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		TalentDesc = (UI_com_TalentDesc)(object)((GComponent)this).GetChild("TalentDesc");
		TypeName = (GTextField)((GComponent)this).GetChild("TypeName");
		ConsumeIcon = (GLoader)((GComponent)this).GetChild("ConsumeIcon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		Unlock = (UI_btn_UnlockTalent)(object)((GComponent)this).GetChild("Unlock");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id2 = "ui://4r1llhd8xohkk".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id2);
		TalentIcon = (GLoader)((GComponent)this).GetChild("TalentIcon");
		OuterTechBuff = (GButton)((GComponent)this).GetChild("OuterTechBuff");
		outerTechIcon = (GLoader)((GComponent)this).GetChild("outerTechIcon");
		RechargeTip = (UI_com_RechargeTip)(object)((GComponent)this).GetChild("RechargeTip");
		RechargeTipSwitch = (UI_btn_OpenDormantPopup)(object)((GComponent)this).GetChild("RechargeTipSwitch");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
