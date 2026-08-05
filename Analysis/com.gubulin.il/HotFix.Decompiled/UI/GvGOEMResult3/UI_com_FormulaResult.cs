using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOEMResult3;

public class UI_com_FormulaResult : GComponent
{
	public Controller HasExtraBonus;

	public GImage n191;

	public GImage n232;

	public UI_btn_ConfirmBtn Confirm;

	public GImage n204;

	public GTextField n211;

	public GList resultDetail;

	public GImage n234;

	public GImage n219;

	public GComponent formulaIcon;

	public GTextField formulaName;

	public GTextField remainUseTimesDes;

	public GTextField remainUseTimes;

	public GTextField hasReturn;

	public GTextField TotalCount;

	public GTextField n216;

	public GLoader TotalIcon;

	public GGroup n228;

	public GImage n233;

	public GImage n220;

	public GImage n226;

	public GTextField n227;

	public GList extraReward;

	public GGroup additionGroup;

	public const string URL = "ui://5k1s1pjxt0zv5w";

	public static string Name = "UI_com_FormulaResult";

	public static string GetURL()
	{
		return "ui://5k1s1pjxt0zv5w";
	}

	public static UI_com_FormulaResult CreateInstance()
	{
		return (UI_com_FormulaResult)(object)UIPackage.CreateObject("GvGOEMResult3", "com_FormulaResult");
	}

	public static UI_com_FormulaResult CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FormulaResult).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://5k1s1pjxt0zv5w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Expected O, but got Unknown
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected O, but got Unknown
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Expected O, but got Unknown
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Expected O, but got Unknown
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Expected O, but got Unknown
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasExtraBonus = ((GComponent)this).GetController("HasExtraBonus");
		n191 = (GImage)((GComponent)this).GetChild("n191");
		n232 = (GImage)((GComponent)this).GetChild("n232");
		Confirm = (UI_btn_ConfirmBtn)(object)((GComponent)this).GetChild("Confirm");
		n204 = (GImage)((GComponent)this).GetChild("n204");
		n211 = (GTextField)((GComponent)this).GetChild("n211");
		string id = "ui://5k1s1pjxt0zv5w".Replace("ui://", "") + "-" + ((GObject)n211).id;
		((GObject)n211).text = LanguagesManager.GetDesc(id);
		resultDetail = (GList)((GComponent)this).GetChild("resultDetail");
		n234 = (GImage)((GComponent)this).GetChild("n234");
		n219 = (GImage)((GComponent)this).GetChild("n219");
		formulaIcon = (GComponent)((GComponent)this).GetChild("formulaIcon");
		formulaName = (GTextField)((GComponent)this).GetChild("formulaName");
		string id2 = "ui://5k1s1pjxt0zv5w".Replace("ui://", "") + "-" + ((GObject)formulaName).id;
		((GObject)formulaName).text = LanguagesManager.GetDesc(id2);
		remainUseTimesDes = (GTextField)((GComponent)this).GetChild("remainUseTimesDes");
		string id3 = "ui://5k1s1pjxt0zv5w".Replace("ui://", "") + "-" + ((GObject)remainUseTimesDes).id;
		((GObject)remainUseTimesDes).text = LanguagesManager.GetDesc(id3);
		remainUseTimes = (GTextField)((GComponent)this).GetChild("remainUseTimes");
		string id4 = "ui://5k1s1pjxt0zv5w".Replace("ui://", "") + "-" + ((GObject)remainUseTimes).id;
		((GObject)remainUseTimes).text = LanguagesManager.GetDesc(id4);
		hasReturn = (GTextField)((GComponent)this).GetChild("hasReturn");
		string id5 = "ui://5k1s1pjxt0zv5w".Replace("ui://", "") + "-" + ((GObject)hasReturn).id;
		((GObject)hasReturn).text = LanguagesManager.GetDesc(id5);
		TotalCount = (GTextField)((GComponent)this).GetChild("TotalCount");
		n216 = (GTextField)((GComponent)this).GetChild("n216");
		string id6 = "ui://5k1s1pjxt0zv5w".Replace("ui://", "") + "-" + ((GObject)n216).id;
		((GObject)n216).text = LanguagesManager.GetDesc(id6);
		TotalIcon = (GLoader)((GComponent)this).GetChild("TotalIcon");
		n228 = (GGroup)((GComponent)this).GetChild("n228");
		n233 = (GImage)((GComponent)this).GetChild("n233");
		n220 = (GImage)((GComponent)this).GetChild("n220");
		n226 = (GImage)((GComponent)this).GetChild("n226");
		n227 = (GTextField)((GComponent)this).GetChild("n227");
		string id7 = "ui://5k1s1pjxt0zv5w".Replace("ui://", "") + "-" + ((GObject)n227).id;
		((GObject)n227).text = LanguagesManager.GetDesc(id7);
		extraReward = (GList)((GComponent)this).GetChild("extraReward");
		additionGroup = (GGroup)((GComponent)this).GetChild("additionGroup");
	}
}
