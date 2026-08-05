using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOEMResult3;

public class UI_com_FormulaResultItem : GComponent
{
	public Controller hasDebuff;

	public GGraph n223;

	public GGraph n224;

	public GList Bonus;

	public GList amplifiers;

	public GList extraRewards;

	public GTextField completeTime;

	public GComponent ProfileDisplay;

	public UI_btn_01 debuffBtn;

	public const string URL = "ui://5k1s1pjxt0zv5y";

	public static string Name = "UI_com_FormulaResultItem";

	public static string GetURL()
	{
		return "ui://5k1s1pjxt0zv5y";
	}

	public static UI_com_FormulaResultItem CreateInstance()
	{
		return (UI_com_FormulaResultItem)(object)UIPackage.CreateObject("GvGOEMResult3", "com_FormulaResultItem");
	}

	public static UI_com_FormulaResultItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FormulaResultItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5k1s1pjxt0zv5y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		hasDebuff = ((GComponent)this).GetController("hasDebuff");
		n223 = (GGraph)((GComponent)this).GetChild("n223");
		n224 = (GGraph)((GComponent)this).GetChild("n224");
		Bonus = (GList)((GComponent)this).GetChild("Bonus");
		amplifiers = (GList)((GComponent)this).GetChild("amplifiers");
		extraRewards = (GList)((GComponent)this).GetChild("extraRewards");
		completeTime = (GTextField)((GComponent)this).GetChild("completeTime");
		string id = "ui://5k1s1pjxt0zv5y".Replace("ui://", "") + "-" + ((GObject)completeTime).id;
		((GObject)completeTime).text = LanguagesManager.GetDesc(id);
		ProfileDisplay = (GComponent)((GComponent)this).GetChild("ProfileDisplay");
		debuffBtn = (UI_btn_01)(object)((GComponent)this).GetChild("debuffBtn");
	}
}
