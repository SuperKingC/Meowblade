using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_SpecialTalentsType1 : GComponent
{
	public Controller Status;

	public Controller OuterTechIsActive;

	public GImage n3;

	public GImage n4;

	public GImage n5;

	public GTextField Tip;

	public GTextField n6;

	public GList Specials;

	public GImage OuterTechMark;

	public Transition Appear;

	public const string URL = "ui://4r1llhd8qiao10";

	public static string Name = "UI_com_SpecialTalentsType1";

	public static string GetURL()
	{
		return "ui://4r1llhd8qiao10";
	}

	public static UI_com_SpecialTalentsType1 CreateInstance()
	{
		return (UI_com_SpecialTalentsType1)(object)UIPackage.CreateObject("GvGTalent", "com_SpecialTalentsType1");
	}

	public static UI_com_SpecialTalentsType1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpecialTalentsType1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8qiao10", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		OuterTechIsActive = ((GComponent)this).GetController("OuterTechIsActive");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://4r1llhd8qiao10".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		Specials = (GList)((GComponent)this).GetChild("Specials");
		OuterTechMark = (GImage)((GComponent)this).GetChild("OuterTechMark");
		Appear = ((GComponent)this).GetTransition("Appear");
	}
}
