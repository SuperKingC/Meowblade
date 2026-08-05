using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_SpecialTalentInfo4 : GComponent
{
	public GImage n8;

	public GTextField TalentName;

	public GTextField Desc;

	public GImage n11;

	public const string URL = "ui://4r1llhd8qiaou";

	public static string Name = "UI_com_SpecialTalentInfo4";

	public static string GetURL()
	{
		return "ui://4r1llhd8qiaou";
	}

	public static UI_com_SpecialTalentInfo4 CreateInstance()
	{
		return (UI_com_SpecialTalentInfo4)(object)UIPackage.CreateObject("GvGTalent", "com_SpecialTalentInfo4");
	}

	public static UI_com_SpecialTalentInfo4 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpecialTalentInfo4).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8qiaou", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n8 = (GImage)((GComponent)this).GetChild("n8");
		TalentName = (GTextField)((GComponent)this).GetChild("TalentName");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		n11 = (GImage)((GComponent)this).GetChild("n11");
	}
}
