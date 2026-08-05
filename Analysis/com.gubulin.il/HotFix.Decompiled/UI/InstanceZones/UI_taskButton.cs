using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_taskButton : GComponent
{
	public Controller button;

	public Controller CanPlay;

	public GImage n4;

	public GImage n3;

	public GTextField rewardInfo;

	public GTextField rewardNum;

	public GLoader rewardIcon;

	public GLoader difficultyIcon;

	public GGraph n9;

	public GTextField missionIndex;

	public GTextField missionName;

	public GTextField tip1st;

	public GTextField recommend;

	public GTextField combat;

	public GImage flashImage;

	public GImage cornerIcon1;

	public GImage cornerIcon3;

	public GImage cornerIcon2;

	public UI_assembledBtn assembledBtn;

	public GImage n19;

	public GImage n20;

	public GGraph n35;

	public GLoader rewardIcon0;

	public GTextField rewardNum0;

	public GGroup reward0;

	public GGraph n37;

	public GLoader rewardIcon1;

	public GTextField rewardNum1;

	public GGroup reward1;

	public GGraph n38;

	public GLoader rewardIcon2;

	public GTextField rewardNum2;

	public GGroup reward2;

	public GGraph n39;

	public GLoader rewardIcon3;

	public GTextField rewardNum3;

	public GGroup reward3;

	public GGraph mask;

	public const string URL = "ui://f4wr270rmm8ni";

	public static string Name = "UI_taskButton";

	public static string GetURL()
	{
		return "ui://f4wr270rmm8ni";
	}

	public static UI_taskButton CreateInstance()
	{
		return (UI_taskButton)(object)UIPackage.CreateObject("InstanceZones", "taskButton");
	}

	public static UI_taskButton CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_taskButton).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rmm8ni", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected O, but got Unknown
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected O, but got Unknown
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Expected O, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected O, but got Unknown
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected O, but got Unknown
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Expected O, but got Unknown
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected O, but got Unknown
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Expected O, but got Unknown
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Expected O, but got Unknown
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Expected O, but got Unknown
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Expected O, but got Unknown
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Expected O, but got Unknown
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Expected O, but got Unknown
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Expected O, but got Unknown
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Expected O, but got Unknown
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Expected O, but got Unknown
		//IL_0427: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Expected O, but got Unknown
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Expected O, but got Unknown
		//IL_0453: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Expected O, but got Unknown
		//IL_0469: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Expected O, but got Unknown
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Expected O, but got Unknown
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_049f: Expected O, but got Unknown
		//IL_04ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		CanPlay = ((GComponent)this).GetController("CanPlay");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		rewardInfo = (GTextField)((GComponent)this).GetChild("rewardInfo");
		string id = "ui://f4wr270rmm8ni".Replace("ui://", "") + "-" + ((GObject)rewardInfo).id;
		((GObject)rewardInfo).text = LanguagesManager.GetDesc(id);
		rewardNum = (GTextField)((GComponent)this).GetChild("rewardNum");
		string id2 = "ui://f4wr270rmm8ni".Replace("ui://", "") + "-" + ((GObject)rewardNum).id;
		((GObject)rewardNum).text = LanguagesManager.GetDesc(id2);
		rewardIcon = (GLoader)((GComponent)this).GetChild("rewardIcon");
		difficultyIcon = (GLoader)((GComponent)this).GetChild("difficultyIcon");
		n9 = (GGraph)((GComponent)this).GetChild("n9");
		missionIndex = (GTextField)((GComponent)this).GetChild("missionIndex");
		string id3 = "ui://f4wr270rmm8ni".Replace("ui://", "") + "-" + ((GObject)missionIndex).id;
		((GObject)missionIndex).text = LanguagesManager.GetDesc(id3);
		missionName = (GTextField)((GComponent)this).GetChild("missionName");
		string id4 = "ui://f4wr270rmm8ni".Replace("ui://", "") + "-" + ((GObject)missionName).id;
		((GObject)missionName).text = LanguagesManager.GetDesc(id4);
		tip1st = (GTextField)((GComponent)this).GetChild("tip1st");
		recommend = (GTextField)((GComponent)this).GetChild("recommend");
		string id5 = "ui://f4wr270rmm8ni".Replace("ui://", "") + "-" + ((GObject)recommend).id;
		((GObject)recommend).text = LanguagesManager.GetDesc(id5);
		combat = (GTextField)((GComponent)this).GetChild("combat");
		string id6 = "ui://f4wr270rmm8ni".Replace("ui://", "") + "-" + ((GObject)combat).id;
		((GObject)combat).text = LanguagesManager.GetDesc(id6);
		flashImage = (GImage)((GComponent)this).GetChild("flashImage");
		cornerIcon1 = (GImage)((GComponent)this).GetChild("cornerIcon1");
		cornerIcon3 = (GImage)((GComponent)this).GetChild("cornerIcon3");
		cornerIcon2 = (GImage)((GComponent)this).GetChild("cornerIcon2");
		assembledBtn = (UI_assembledBtn)(object)((GComponent)this).GetChild("assembledBtn");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n35 = (GGraph)((GComponent)this).GetChild("n35");
		rewardIcon0 = (GLoader)((GComponent)this).GetChild("rewardIcon0");
		rewardNum0 = (GTextField)((GComponent)this).GetChild("rewardNum0");
		reward0 = (GGroup)((GComponent)this).GetChild("reward0");
		n37 = (GGraph)((GComponent)this).GetChild("n37");
		rewardIcon1 = (GLoader)((GComponent)this).GetChild("rewardIcon1");
		rewardNum1 = (GTextField)((GComponent)this).GetChild("rewardNum1");
		reward1 = (GGroup)((GComponent)this).GetChild("reward1");
		n38 = (GGraph)((GComponent)this).GetChild("n38");
		rewardIcon2 = (GLoader)((GComponent)this).GetChild("rewardIcon2");
		rewardNum2 = (GTextField)((GComponent)this).GetChild("rewardNum2");
		reward2 = (GGroup)((GComponent)this).GetChild("reward2");
		n39 = (GGraph)((GComponent)this).GetChild("n39");
		rewardIcon3 = (GLoader)((GComponent)this).GetChild("rewardIcon3");
		rewardNum3 = (GTextField)((GComponent)this).GetChild("rewardNum3");
		reward3 = (GGroup)((GComponent)this).GetChild("reward3");
		mask = (GGraph)((GComponent)this).GetChild("mask");
	}
}
