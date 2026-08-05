using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_com_SpecialTalentInfo8 : GComponent
{
	public GImage n4;

	public GTextField TalentName;

	public GTextField Desc;

	public GImage n7;

	public const string URL = "ui://4r1llhd8qiaoy";

	public static string Name = "UI_com_SpecialTalentInfo8";

	public static string GetURL()
	{
		return "ui://4r1llhd8qiaoy";
	}

	public static UI_com_SpecialTalentInfo8 CreateInstance()
	{
		return (UI_com_SpecialTalentInfo8)(object)UIPackage.CreateObject("GvGTalent", "com_SpecialTalentInfo8");
	}

	public static UI_com_SpecialTalentInfo8 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpecialTalentInfo8).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8qiaoy", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n4 = (GImage)((GComponent)this).GetChild("n4");
		TalentName = (GTextField)((GComponent)this).GetChild("TalentName");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
