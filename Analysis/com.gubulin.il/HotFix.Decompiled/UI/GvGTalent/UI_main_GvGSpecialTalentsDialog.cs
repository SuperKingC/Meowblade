using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_main_GvGSpecialTalentsDialog : GComponent
{
	public GGraph Mask;

	public UI_com_SpecialTalentsType1 Type1;

	public UI_com_SpecialTalentsType4 Type4;

	public UI_com_SpecialTalentsType2 Type2;

	public UI_com_SpecialTalentsType8 Type8;

	public const string URL = "ui://4r1llhd8v3mdr";

	public static string Name = "UI_main_GvGSpecialTalentsDialog";

	public static string GetURL()
	{
		return "ui://4r1llhd8v3mdr";
	}

	public static UI_main_GvGSpecialTalentsDialog CreateInstance()
	{
		return (UI_main_GvGSpecialTalentsDialog)(object)UIPackage.CreateObject("GvGTalent", "main_GvGSpecialTalentsDialog");
	}

	public static UI_main_GvGSpecialTalentsDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GvGSpecialTalentsDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8v3mdr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Type1 = (UI_com_SpecialTalentsType1)(object)((GComponent)this).GetChild("Type1");
		Type4 = (UI_com_SpecialTalentsType4)(object)((GComponent)this).GetChild("Type4");
		Type2 = (UI_com_SpecialTalentsType2)(object)((GComponent)this).GetChild("Type2");
		Type8 = (UI_com_SpecialTalentsType8)(object)((GComponent)this).GetChild("Type8");
	}
}
