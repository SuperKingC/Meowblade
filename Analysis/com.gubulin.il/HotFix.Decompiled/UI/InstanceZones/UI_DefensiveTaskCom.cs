using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_DefensiveTaskCom : GComponent
{
	public Controller CanPlay;

	public Controller Difficulty;

	public Controller CombatPower;

	public GImage n46;

	public GImage n57;

	public GLoader difficultyIcon;

	public GTextField missionIndex;

	public GTextField missionName;

	public GImage flashImage;

	public GTextField tip1st;

	public GTextField recommend;

	public GTextField combat;

	public GImage n48;

	public GGraph n16;

	public GLoader rewardIcon0;

	public GTextField rewardNum0;

	public GGroup reward0;

	public GGraph n19;

	public GLoader rewardIcon1;

	public GTextField rewardNum1;

	public GGroup reward1;

	public GGraph n49;

	public GLoader rewardIcon2;

	public GTextField rewardNum2;

	public GGroup reward2;

	public GGraph n53;

	public GLoader rewardIcon3;

	public GTextField rewardNum3;

	public GGroup reward3;

	public GGraph n25;

	public GLoader rewardIcon5;

	public GTextField rewardNum5;

	public GGroup reward5;

	public UI_PropetryLock quickBtn;

	public UI_assembledBtn assembledBtn;

	public GGraph mask;

	public GLoader n47;

	public const string URL = "ui://f4wr270rjgrl2i";

	public static string Name = "UI_DefensiveTaskCom";

	public static string GetURL()
	{
		return "ui://f4wr270rjgrl2i";
	}

	public static UI_DefensiveTaskCom CreateInstance()
	{
		return (UI_DefensiveTaskCom)(object)UIPackage.CreateObject("InstanceZones", "DefensiveTaskCom");
	}

	public static UI_DefensiveTaskCom CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DefensiveTaskCom).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rjgrl2i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected O, but got Unknown
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected O, but got Unknown
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Expected O, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Expected O, but got Unknown
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CanPlay = ((GComponent)this).GetController("CanPlay");
		Difficulty = ((GComponent)this).GetController("Difficulty");
		CombatPower = ((GComponent)this).GetController("CombatPower");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		difficultyIcon = (GLoader)((GComponent)this).GetChild("difficultyIcon");
		missionIndex = (GTextField)((GComponent)this).GetChild("missionIndex");
		string id = "ui://f4wr270rjgrl2i".Replace("ui://", "") + "-" + ((GObject)missionIndex).id;
		((GObject)missionIndex).text = LanguagesManager.GetDesc(id);
		missionName = (GTextField)((GComponent)this).GetChild("missionName");
		string id2 = "ui://f4wr270rjgrl2i".Replace("ui://", "") + "-" + ((GObject)missionName).id;
		((GObject)missionName).text = LanguagesManager.GetDesc(id2);
		flashImage = (GImage)((GComponent)this).GetChild("flashImage");
		tip1st = (GTextField)((GComponent)this).GetChild("tip1st");
		recommend = (GTextField)((GComponent)this).GetChild("recommend");
		string id3 = "ui://f4wr270rjgrl2i".Replace("ui://", "") + "-" + ((GObject)recommend).id;
		((GObject)recommend).text = LanguagesManager.GetDesc(id3);
		combat = (GTextField)((GComponent)this).GetChild("combat");
		string id4 = "ui://f4wr270rjgrl2i".Replace("ui://", "") + "-" + ((GObject)combat).id;
		((GObject)combat).text = LanguagesManager.GetDesc(id4);
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n16 = (GGraph)((GComponent)this).GetChild("n16");
		rewardIcon0 = (GLoader)((GComponent)this).GetChild("rewardIcon0");
		rewardNum0 = (GTextField)((GComponent)this).GetChild("rewardNum0");
		reward0 = (GGroup)((GComponent)this).GetChild("reward0");
		n19 = (GGraph)((GComponent)this).GetChild("n19");
		rewardIcon1 = (GLoader)((GComponent)this).GetChild("rewardIcon1");
		rewardNum1 = (GTextField)((GComponent)this).GetChild("rewardNum1");
		reward1 = (GGroup)((GComponent)this).GetChild("reward1");
		n49 = (GGraph)((GComponent)this).GetChild("n49");
		rewardIcon2 = (GLoader)((GComponent)this).GetChild("rewardIcon2");
		rewardNum2 = (GTextField)((GComponent)this).GetChild("rewardNum2");
		reward2 = (GGroup)((GComponent)this).GetChild("reward2");
		n53 = (GGraph)((GComponent)this).GetChild("n53");
		rewardIcon3 = (GLoader)((GComponent)this).GetChild("rewardIcon3");
		rewardNum3 = (GTextField)((GComponent)this).GetChild("rewardNum3");
		reward3 = (GGroup)((GComponent)this).GetChild("reward3");
		n25 = (GGraph)((GComponent)this).GetChild("n25");
		rewardIcon5 = (GLoader)((GComponent)this).GetChild("rewardIcon5");
		rewardNum5 = (GTextField)((GComponent)this).GetChild("rewardNum5");
		reward5 = (GGroup)((GComponent)this).GetChild("reward5");
		quickBtn = (UI_PropetryLock)(object)((GComponent)this).GetChild("quickBtn");
		assembledBtn = (UI_assembledBtn)(object)((GComponent)this).GetChild("assembledBtn");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		n47 = (GLoader)((GComponent)this).GetChild("n47");
	}
}
