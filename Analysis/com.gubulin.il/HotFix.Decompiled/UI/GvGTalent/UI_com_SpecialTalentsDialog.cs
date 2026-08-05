using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_SpecialTalentsDialog : GComponent
{
	public Controller Type;

	public Controller OuterTechIsActive;

	public GImage back;

	public GImage n9;

	public GImage n8;

	public GList Info;

	public GTextField SpecialTalentName;

	public GImage n10;

	public GImage n11;

	public GImage n12;

	public GImage n13;

	public UI_com_OuterTechI67602 n14;

	public const string URL = "ui://4r1llhd8k0rxp";

	public static string Name = "UI_com_SpecialTalentsDialog";

	public static string GetURL()
	{
		return "ui://4r1llhd8k0rxp";
	}

	public static UI_com_SpecialTalentsDialog CreateInstance()
	{
		return (UI_com_SpecialTalentsDialog)(object)UIPackage.CreateObject("GvGTalent", "com_SpecialTalentsDialog");
	}

	public static UI_com_SpecialTalentsDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpecialTalentsDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8k0rxp", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		OuterTechIsActive = ((GComponent)this).GetController("OuterTechIsActive");
		back = (GImage)((GComponent)this).GetChild("back");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		Info = (GList)((GComponent)this).GetChild("Info");
		SpecialTalentName = (GTextField)((GComponent)this).GetChild("SpecialTalentName");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (UI_com_OuterTechI67602)(object)((GComponent)this).GetChild("n14");
	}
}
