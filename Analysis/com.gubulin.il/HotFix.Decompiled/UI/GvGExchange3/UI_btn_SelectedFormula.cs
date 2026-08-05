using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_SelectedFormula : GButton
{
	public Controller Selected;

	public GImage n4;

	public GTextField n5;

	public GComponent Formula;

	public UI_com_FormulaName FormulaName;

	public const string URL = "ui://tt2iq07odip34s";

	public static string Name = "UI_btn_SelectedFormula";

	public static string GetURL()
	{
		return "ui://tt2iq07odip34s";
	}

	public static UI_btn_SelectedFormula CreateInstance()
	{
		return (UI_btn_SelectedFormula)(object)UIPackage.CreateObject("GvGExchange3", "btn_SelectedFormula");
	}

	public static UI_btn_SelectedFormula CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SelectedFormula).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odip34s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Selected = ((GComponent)this).GetController("Selected");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://tt2iq07odip34s".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		Formula = (GComponent)((GComponent)this).GetChild("Formula");
		FormulaName = (UI_com_FormulaName)(object)((GComponent)this).GetChild("FormulaName");
	}
}
