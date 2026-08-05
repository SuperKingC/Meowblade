using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_SpecilaTalentDialogInfo : GComponent
{
	public Controller Status;

	public Controller OuterTechIsActive;

	public GTextField Desc;

	public UI_dec_TalentNoActive n6;

	public UI_dec_TalentOn n4;

	public GTextField Point;

	public const string URL = "ui://4r1llhd8k0rxq";

	public static string Name = "UI_com_SpecilaTalentDialogInfo";

	public static string GetURL()
	{
		return "ui://4r1llhd8k0rxq";
	}

	public static UI_com_SpecilaTalentDialogInfo CreateInstance()
	{
		return (UI_com_SpecilaTalentDialogInfo)(object)UIPackage.CreateObject("GvGTalent", "com_SpecilaTalentDialogInfo");
	}

	public static UI_com_SpecilaTalentDialogInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpecilaTalentDialogInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8k0rxq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		OuterTechIsActive = ((GComponent)this).GetController("OuterTechIsActive");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		n6 = (UI_dec_TalentNoActive)(object)((GComponent)this).GetChild("n6");
		n4 = (UI_dec_TalentOn)(object)((GComponent)this).GetChild("n4");
		Point = (GTextField)((GComponent)this).GetChild("Point");
	}
}
