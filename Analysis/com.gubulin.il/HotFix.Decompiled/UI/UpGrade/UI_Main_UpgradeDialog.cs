using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpGrade;

public class UI_Main_UpgradeDialog : GComponent
{
	public Controller StateController;

	public GImage n2;

	public GImage n3;

	public GImage frame;

	public GLoader icon;

	public GLoader nextBuildingImage;

	public GTextField title;

	public GLoader n11;

	public GTextField buildingDesc;

	public GImage n15;

	public GImage n16;

	public GTextField gradeTitle;

	public GTextField n47;

	public GLoader buildSLotIcon;

	public GTextField buildingSlotName;

	public GTextField slotNum;

	public GTextField n22;

	public GGroup nextLevelEffectGroup;

	public GTextField level;

	public GTextField n25;

	public GTextField n26;

	public GImage n48;

	public GTextField n49;

	public GImage n45;

	public GTextField consumption;

	public GImage n29;

	public GTextField n30;

	public GTextField n31;

	public GList consumptionList;

	public GButton ExclamationMarkBtn;

	public UI_com_consumptionText consumptionText;

	public GImage n37;

	public UI_increase increaseBtn;

	public UI_reduce reduceBtn;

	public GList workersBackList;

	public GList workersList;

	public GTextField buildTime;

	public GGroup buildTimeGroup;

	public GButton upGradeButton;

	public UI_btn_01 fixButton;

	public UI_btn_02 acceptButton;

	public UI_exitBtn exit;

	public UI_jobSschedule jobSschedule;

	public Transition t0;

	public const string URL = "ui://lrjfe94hm4fq3h";

	public static string Name = "UI_Main_UpgradeDialog";

	public static string GetURL()
	{
		return "ui://lrjfe94hm4fq3h";
	}

	public static UI_Main_UpgradeDialog CreateInstance()
	{
		return (UI_Main_UpgradeDialog)(object)UIPackage.CreateObject("UpGrade", "Main_UpgradeDialog");
	}

	public static UI_Main_UpgradeDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Main_UpgradeDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrjfe94hm4fq3h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected O, but got Unknown
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Expected O, but got Unknown
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Expected O, but got Unknown
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Expected O, but got Unknown
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected O, but got Unknown
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected O, but got Unknown
		//IL_0491: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Expected O, but got Unknown
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Expected O, but got Unknown
		//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0506: Expected O, but got Unknown
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_0532: Expected O, but got Unknown
		//IL_056a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Expected O, but got Unknown
		//IL_0580: Unknown result type (might be due to invalid IL or missing references)
		//IL_058a: Expected O, but got Unknown
		//IL_0596: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a0: Expected O, but got Unknown
		//IL_05eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f5: Expected O, but got Unknown
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		//IL_060b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StateController = ((GComponent)this).GetController("StateController");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		frame = (GImage)((GComponent)this).GetChild("frame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		nextBuildingImage = (GLoader)((GComponent)this).GetChild("nextBuildingImage");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://lrjfe94hm4fq3h".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n11 = (GLoader)((GComponent)this).GetChild("n11");
		buildingDesc = (GTextField)((GComponent)this).GetChild("buildingDesc");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		gradeTitle = (GTextField)((GComponent)this).GetChild("gradeTitle");
		string id2 = "ui://lrjfe94hm4fq3h".Replace("ui://", "") + "-" + ((GObject)gradeTitle).id;
		((GObject)gradeTitle).text = LanguagesManager.GetDesc(id2);
		n47 = (GTextField)((GComponent)this).GetChild("n47");
		string id3 = "ui://lrjfe94hm4fq3h".Replace("ui://", "") + "-" + ((GObject)n47).id;
		((GObject)n47).text = LanguagesManager.GetDesc(id3);
		buildSLotIcon = (GLoader)((GComponent)this).GetChild("buildSLotIcon");
		buildingSlotName = (GTextField)((GComponent)this).GetChild("buildingSlotName");
		slotNum = (GTextField)((GComponent)this).GetChild("slotNum");
		n22 = (GTextField)((GComponent)this).GetChild("n22");
		string id4 = "ui://lrjfe94hm4fq3h".Replace("ui://", "") + "-" + ((GObject)n22).id;
		((GObject)n22).text = LanguagesManager.GetDesc(id4);
		nextLevelEffectGroup = (GGroup)((GComponent)this).GetChild("nextLevelEffectGroup");
		level = (GTextField)((GComponent)this).GetChild("level");
		n25 = (GTextField)((GComponent)this).GetChild("n25");
		string id5 = "ui://lrjfe94hm4fq3h".Replace("ui://", "") + "-" + ((GObject)n25).id;
		((GObject)n25).text = LanguagesManager.GetDesc(id5);
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id6 = "ui://lrjfe94hm4fq3h".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id6);
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n49 = (GTextField)((GComponent)this).GetChild("n49");
		string id7 = "ui://lrjfe94hm4fq3h".Replace("ui://", "") + "-" + ((GObject)n49).id;
		((GObject)n49).text = LanguagesManager.GetDesc(id7);
		n45 = (GImage)((GComponent)this).GetChild("n45");
		consumption = (GTextField)((GComponent)this).GetChild("consumption");
		string id8 = "ui://lrjfe94hm4fq3h".Replace("ui://", "") + "-" + ((GObject)consumption).id;
		((GObject)consumption).text = LanguagesManager.GetDesc(id8);
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n30 = (GTextField)((GComponent)this).GetChild("n30");
		string id9 = "ui://lrjfe94hm4fq3h".Replace("ui://", "") + "-" + ((GObject)n30).id;
		((GObject)n30).text = LanguagesManager.GetDesc(id9);
		n31 = (GTextField)((GComponent)this).GetChild("n31");
		string id10 = "ui://lrjfe94hm4fq3h".Replace("ui://", "") + "-" + ((GObject)n31).id;
		((GObject)n31).text = LanguagesManager.GetDesc(id10);
		consumptionList = (GList)((GComponent)this).GetChild("consumptionList");
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
		consumptionText = (UI_com_consumptionText)(object)((GComponent)this).GetChild("consumptionText");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		increaseBtn = (UI_increase)(object)((GComponent)this).GetChild("increaseBtn");
		reduceBtn = (UI_reduce)(object)((GComponent)this).GetChild("reduceBtn");
		workersBackList = (GList)((GComponent)this).GetChild("workersBackList");
		workersList = (GList)((GComponent)this).GetChild("workersList");
		buildTime = (GTextField)((GComponent)this).GetChild("buildTime");
		string id11 = "ui://lrjfe94hm4fq3h".Replace("ui://", "") + "-" + ((GObject)buildTime).id;
		((GObject)buildTime).text = LanguagesManager.GetDesc(id11);
		buildTimeGroup = (GGroup)((GComponent)this).GetChild("buildTimeGroup");
		upGradeButton = (GButton)((GComponent)this).GetChild("upGradeButton");
		fixButton = (UI_btn_01)(object)((GComponent)this).GetChild("fixButton");
		acceptButton = (UI_btn_02)(object)((GComponent)this).GetChild("acceptButton");
		exit = (UI_exitBtn)(object)((GComponent)this).GetChild("exit");
		jobSschedule = (UI_jobSschedule)(object)((GComponent)this).GetChild("jobSschedule");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
