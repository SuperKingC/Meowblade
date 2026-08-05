using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpGrade;

public class UI_UpgradeDialog : GComponent
{
	public Controller StateController;

	public GImage tipBack;

	public GGraph n40;

	public GButton exit;

	public GLoader frame;

	public GLoader icon;

	public GTextField title;

	public GTextField level;

	public GGraph consumptionBack;

	public GTextField consumption;

	public UI_Upgrade upGradeButton;

	public GImage gradeTitle;

	public GImage ConsumptionTitle;

	public GList consumptionList;

	public GGroup consumptionGroup;

	public GTextField description1;

	public GTextField description2;

	public GTextField descriptionNum;

	public GTextField Describe_Next1;

	public GTextField Describe_NextNum;

	public GTextField Describe_Next2;

	public GGroup oldTextsGroup;

	public GTextField size;

	public GProgressBar jobSschedule;

	public GImage n39;

	public UI_increase increaseBtn;

	public UI_reduce reduceBtn;

	public GList workersBackList;

	public GList workersList;

	public GTextField buildTime;

	public GGroup buildTimeGroup;

	public GTextField buildingSlotName;

	public GImage nextLevel;

	public GLoader buildSLotIcon;

	public GTextField slotNum;

	public GGroup nextLevelEffectGroup;

	public GTextField maxLevelTip;

	public GButton ExclamationMarkBtn;

	public Transition t0;

	public const string URL = "ui://lrjfe94hc01eb";

	public static string Name = "UI_UpgradeDialog";

	public static string GetURL()
	{
		return "ui://lrjfe94hc01eb";
	}

	public static UI_UpgradeDialog CreateInstance()
	{
		return (UI_UpgradeDialog)(object)UIPackage.CreateObject("UpGrade", "UpgradeDialog");
	}

	public static UI_UpgradeDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UpgradeDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hc01eb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Expected O, but got Unknown
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Expected O, but got Unknown
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Expected O, but got Unknown
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Expected O, but got Unknown
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Expected O, but got Unknown
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Expected O, but got Unknown
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StateController = ((GComponent)this).GetController("StateController");
		tipBack = (GImage)((GComponent)this).GetChild("tipBack");
		n40 = (GGraph)((GComponent)this).GetChild("n40");
		exit = (GButton)((GComponent)this).GetChild("exit");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://lrjfe94hc01eb".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		level = (GTextField)((GComponent)this).GetChild("level");
		string id2 = "ui://lrjfe94hc01eb".Replace("ui://", "") + "-" + ((GObject)level).id;
		((GObject)level).text = LanguagesManager.GetDesc(id2);
		consumptionBack = (GGraph)((GComponent)this).GetChild("consumptionBack");
		consumption = (GTextField)((GComponent)this).GetChild("consumption");
		upGradeButton = (UI_Upgrade)(object)((GComponent)this).GetChild("upGradeButton");
		gradeTitle = (GImage)((GComponent)this).GetChild("gradeTitle");
		ConsumptionTitle = (GImage)((GComponent)this).GetChild("ConsumptionTitle");
		consumptionList = (GList)((GComponent)this).GetChild("consumptionList");
		consumptionGroup = (GGroup)((GComponent)this).GetChild("consumptionGroup");
		description1 = (GTextField)((GComponent)this).GetChild("description1");
		description2 = (GTextField)((GComponent)this).GetChild("description2");
		descriptionNum = (GTextField)((GComponent)this).GetChild("descriptionNum");
		Describe_Next1 = (GTextField)((GComponent)this).GetChild("Describe_Next1");
		Describe_NextNum = (GTextField)((GComponent)this).GetChild("Describe_NextNum");
		Describe_Next2 = (GTextField)((GComponent)this).GetChild("Describe_Next2");
		oldTextsGroup = (GGroup)((GComponent)this).GetChild("oldTextsGroup");
		size = (GTextField)((GComponent)this).GetChild("size");
		string id3 = "ui://lrjfe94hc01eb".Replace("ui://", "") + "-" + ((GObject)size).id;
		((GObject)size).text = LanguagesManager.GetDesc(id3);
		jobSschedule = (GProgressBar)((GComponent)this).GetChild("jobSschedule");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		increaseBtn = (UI_increase)(object)((GComponent)this).GetChild("increaseBtn");
		reduceBtn = (UI_reduce)(object)((GComponent)this).GetChild("reduceBtn");
		workersBackList = (GList)((GComponent)this).GetChild("workersBackList");
		workersList = (GList)((GComponent)this).GetChild("workersList");
		buildTime = (GTextField)((GComponent)this).GetChild("buildTime");
		string id4 = "ui://lrjfe94hc01eb".Replace("ui://", "") + "-" + ((GObject)buildTime).id;
		((GObject)buildTime).text = LanguagesManager.GetDesc(id4);
		buildTimeGroup = (GGroup)((GComponent)this).GetChild("buildTimeGroup");
		buildingSlotName = (GTextField)((GComponent)this).GetChild("buildingSlotName");
		string id5 = "ui://lrjfe94hc01eb".Replace("ui://", "") + "-" + ((GObject)buildingSlotName).id;
		((GObject)buildingSlotName).text = LanguagesManager.GetDesc(id5);
		nextLevel = (GImage)((GComponent)this).GetChild("nextLevel");
		buildSLotIcon = (GLoader)((GComponent)this).GetChild("buildSLotIcon");
		slotNum = (GTextField)((GComponent)this).GetChild("slotNum");
		string id6 = "ui://lrjfe94hc01eb".Replace("ui://", "") + "-" + ((GObject)slotNum).id;
		((GObject)slotNum).text = LanguagesManager.GetDesc(id6);
		nextLevelEffectGroup = (GGroup)((GComponent)this).GetChild("nextLevelEffectGroup");
		maxLevelTip = (GTextField)((GComponent)this).GetChild("maxLevelTip");
		string id7 = "ui://lrjfe94hc01eb".Replace("ui://", "") + "-" + ((GObject)maxLevelTip).id;
		((GObject)maxLevelTip).text = LanguagesManager.GetDesc(id7);
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
