using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_Exchange : GComponent
{
	public Controller PageController;

	public GImage Background;

	public UI_com_FlagshipReq FlagshipReq;

	public UI_com_CampOEMMissions OEMMissions;

	public UI_com_FormulaOemMissions FormulaOemMissions;

	public UI_com_PostedFormulaOemMission PostFormulaMissions;

	public UI_com_PostOEMMission PostOEMMission;

	public UI_btn_FlagshipRequirement FlagshipReqTab;

	public UI_btn_Outsourcing OutsourcingTab;

	public UI_btn_FormulaOem FormulaOem;

	public GImage n10;

	public GImage n7;

	public GTextField n8;

	public UI_ExitAdvancedBtn Close;

	public GTextField n12;

	public UI_main_FormulaOemFilter FormulaMissionsFilter;

	public const string URL = "ui://tt2iq07odwxt2";

	public static string Name = "UI_com_Exchange";

	public static string GetURL()
	{
		return "ui://tt2iq07odwxt2";
	}

	public static UI_com_Exchange CreateInstance()
	{
		return (UI_com_Exchange)(object)UIPackage.CreateObject("GvGExchange3", "com_Exchange");
	}

	public static UI_com_Exchange CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Exchange).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odwxt2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		Background = (GImage)((GComponent)this).GetChild("Background");
		FlagshipReq = (UI_com_FlagshipReq)(object)((GComponent)this).GetChild("FlagshipReq");
		OEMMissions = (UI_com_CampOEMMissions)(object)((GComponent)this).GetChild("OEMMissions");
		FormulaOemMissions = (UI_com_FormulaOemMissions)(object)((GComponent)this).GetChild("FormulaOemMissions");
		PostFormulaMissions = (UI_com_PostedFormulaOemMission)(object)((GComponent)this).GetChild("PostFormulaMissions");
		PostOEMMission = (UI_com_PostOEMMission)(object)((GComponent)this).GetChild("PostOEMMission");
		FlagshipReqTab = (UI_btn_FlagshipRequirement)(object)((GComponent)this).GetChild("FlagshipReqTab");
		OutsourcingTab = (UI_btn_Outsourcing)(object)((GComponent)this).GetChild("OutsourcingTab");
		FormulaOem = (UI_btn_FormulaOem)(object)((GComponent)this).GetChild("FormulaOem");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id = "ui://tt2iq07odwxt2".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id);
		Close = (UI_ExitAdvancedBtn)(object)((GComponent)this).GetChild("Close");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id2 = "ui://tt2iq07odwxt2".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id2);
		FormulaMissionsFilter = (UI_main_FormulaOemFilter)(object)((GComponent)this).GetChild("FormulaMissionsFilter");
	}
}
