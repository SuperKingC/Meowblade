using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOEMBonus3;

public class UI_com_FormulaForgeResult : GComponent
{
	public GImage n191;

	public GImage n206;

	public GImage titleDes;

	public GList Amps;

	public UI_btn_ConfirmBtn Confirm;

	public const string URL = "ui://h3bpjkt7t0zv63";

	public static string Name = "UI_com_FormulaForgeResult";

	public static string GetURL()
	{
		return "ui://h3bpjkt7t0zv63";
	}

	public static UI_com_FormulaForgeResult CreateInstance()
	{
		return (UI_com_FormulaForgeResult)(object)UIPackage.CreateObject("GvGOEMBonus3", "com_FormulaForgeResult");
	}

	public static UI_com_FormulaForgeResult CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FormulaForgeResult).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h3bpjkt7t0zv63", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n191 = (GImage)((GComponent)this).GetChild("n191");
		n206 = (GImage)((GComponent)this).GetChild("n206");
		titleDes = (GImage)((GComponent)this).GetChild("titleDes");
		Amps = (GList)((GComponent)this).GetChild("Amps");
		Confirm = (UI_btn_ConfirmBtn)(object)((GComponent)this).GetChild("Confirm");
	}
}
