using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipPopup;

public class UI_BuildConfirmDialog : GComponent
{
	public Controller ConsumptionListSize;

	public Controller hasOuterTech;

	public Controller isFastBuild;

	public GImage tipBack;

	public GImage n40;

	public GTextField n19;

	public UI_CloseBtn CloseBtn;

	public GTextField ShipName;

	public GTextField RaceName;

	public GTextField ConsumptionTitle;

	public GImage n39;

	public UI_AddWorker AddWorker;

	public UI_ReduceWorker ReduceWorker;

	public GList WorkersBackList;

	public GList WorkersList;

	public GLoader outerTechicon;

	public GImage OuterTechMark;

	public GGroup n88;

	public GTextField BuildTimeTitle;

	public GTextField BuildTime;

	public GGroup n44;

	public GImage n56;

	public GTextField BuildTimeTitle2;

	public GTextField BuildTime2;

	public GGroup n55;

	public GGroup n57;

	public GGroup BuildTimeGroup;

	public UI_ConfirmBtn ConfirmBtn;

	public GGraph SpineLoader;

	public UI_btn_CheckBox fastBuildCheckBox;

	public GTextField fastBuildTitle;

	public GImage n66;

	public UI_goodItemConsume cost1;

	public UI_goodItemConsume cost2;

	public UI_goodItemConsume cost3;

	public GTextField curPrice;

	public GLoader outerTechicon2;

	public GGroup n87;

	public GGroup n80;

	public GMovieClip n82;

	public GMovieClip n84;

	public Transition t1;

	public const string URL = "ui://pwrbvhpvlb9h3a";

	public static string Name = "UI_BuildConfirmDialog";

	public static string GetURL()
	{
		return "ui://pwrbvhpvlb9h3a";
	}

	public static UI_BuildConfirmDialog CreateInstance()
	{
		return (UI_BuildConfirmDialog)(object)UIPackage.CreateObject("GvGShipPopup", "BuildConfirmDialog");
	}

	public static UI_BuildConfirmDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BuildConfirmDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pwrbvhpvlb9h3a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected O, but got Unknown
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Expected O, but got Unknown
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Expected O, but got Unknown
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Expected O, but got Unknown
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Expected O, but got Unknown
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Expected O, but got Unknown
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Expected O, but got Unknown
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ConsumptionListSize = ((GComponent)this).GetController("ConsumptionListSize");
		hasOuterTech = ((GComponent)this).GetController("hasOuterTech");
		isFastBuild = ((GComponent)this).GetController("isFastBuild");
		tipBack = (GImage)((GComponent)this).GetChild("tipBack");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id = "ui://pwrbvhpvlb9h3a".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id);
		CloseBtn = (UI_CloseBtn)(object)((GComponent)this).GetChild("CloseBtn");
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
		RaceName = (GTextField)((GComponent)this).GetChild("RaceName");
		ConsumptionTitle = (GTextField)((GComponent)this).GetChild("ConsumptionTitle");
		string id2 = "ui://pwrbvhpvlb9h3a".Replace("ui://", "") + "-" + ((GObject)ConsumptionTitle).id;
		((GObject)ConsumptionTitle).text = LanguagesManager.GetDesc(id2);
		n39 = (GImage)((GComponent)this).GetChild("n39");
		AddWorker = (UI_AddWorker)(object)((GComponent)this).GetChild("AddWorker");
		ReduceWorker = (UI_ReduceWorker)(object)((GComponent)this).GetChild("ReduceWorker");
		WorkersBackList = (GList)((GComponent)this).GetChild("WorkersBackList");
		WorkersList = (GList)((GComponent)this).GetChild("WorkersList");
		outerTechicon = (GLoader)((GComponent)this).GetChild("outerTechicon");
		OuterTechMark = (GImage)((GComponent)this).GetChild("OuterTechMark");
		n88 = (GGroup)((GComponent)this).GetChild("n88");
		BuildTimeTitle = (GTextField)((GComponent)this).GetChild("BuildTimeTitle");
		string id3 = "ui://pwrbvhpvlb9h3a".Replace("ui://", "") + "-" + ((GObject)BuildTimeTitle).id;
		((GObject)BuildTimeTitle).text = LanguagesManager.GetDesc(id3);
		BuildTime = (GTextField)((GComponent)this).GetChild("BuildTime");
		n44 = (GGroup)((GComponent)this).GetChild("n44");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		BuildTimeTitle2 = (GTextField)((GComponent)this).GetChild("BuildTimeTitle2");
		string id4 = "ui://pwrbvhpvlb9h3a".Replace("ui://", "") + "-" + ((GObject)BuildTimeTitle2).id;
		((GObject)BuildTimeTitle2).text = LanguagesManager.GetDesc(id4);
		BuildTime2 = (GTextField)((GComponent)this).GetChild("BuildTime2");
		n55 = (GGroup)((GComponent)this).GetChild("n55");
		n57 = (GGroup)((GComponent)this).GetChild("n57");
		BuildTimeGroup = (GGroup)((GComponent)this).GetChild("BuildTimeGroup");
		ConfirmBtn = (UI_ConfirmBtn)(object)((GComponent)this).GetChild("ConfirmBtn");
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
		fastBuildCheckBox = (UI_btn_CheckBox)(object)((GComponent)this).GetChild("fastBuildCheckBox");
		fastBuildTitle = (GTextField)((GComponent)this).GetChild("fastBuildTitle");
		string id5 = "ui://pwrbvhpvlb9h3a".Replace("ui://", "") + "-" + ((GObject)fastBuildTitle).id;
		((GObject)fastBuildTitle).text = LanguagesManager.GetDesc(id5);
		n66 = (GImage)((GComponent)this).GetChild("n66");
		cost1 = (UI_goodItemConsume)(object)((GComponent)this).GetChild("cost1");
		cost2 = (UI_goodItemConsume)(object)((GComponent)this).GetChild("cost2");
		cost3 = (UI_goodItemConsume)(object)((GComponent)this).GetChild("cost3");
		curPrice = (GTextField)((GComponent)this).GetChild("curPrice");
		outerTechicon2 = (GLoader)((GComponent)this).GetChild("outerTechicon2");
		n87 = (GGroup)((GComponent)this).GetChild("n87");
		n80 = (GGroup)((GComponent)this).GetChild("n80");
		n82 = (GMovieClip)((GComponent)this).GetChild("n82");
		n84 = (GMovieClip)((GComponent)this).GetChild("n84");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
