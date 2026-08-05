using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_LevelCard : GComponent
{
	public Controller Type;

	public GImage n29;

	public GTextField missionName;

	public GTextField advanceMissionName;

	public GGraph back2;

	public UI_assembledBtn assembledBtn;

	public GGraph n8;

	public GLoader rewardIcon0;

	public GTextField rewardNum0;

	public GGroup reward0;

	public GGraph n42;

	public GLoader rewardIcon1;

	public GTextField rewardNum1;

	public GGroup reward1;

	public GGraph n38;

	public GLoader rewardIcon2;

	public GTextField rewardNum2;

	public GGroup reward2;

	public GGraph n34;

	public GLoader rewardIcon3;

	public GTextField rewardNum3;

	public GGroup reward3;

	public GImage flashImage;

	public GTextField curPower;

	public GTextField combat;

	public GTextField n26;

	public GTextField n27;

	public UI_PropetryLock quickBtn;

	public GImage n31;

	public GImage n32;

	public GImage n33;

	public const string URL = "ui://f4wr270rdpf03v";

	public static string Name = "UI_LevelCard";

	public static string GetURL()
	{
		return "ui://f4wr270rdpf03v";
	}

	public static UI_LevelCard CreateInstance()
	{
		return (UI_LevelCard)(object)UIPackage.CreateObject("InstanceZones", "LevelCard");
	}

	public static UI_LevelCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LevelCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rdpf03v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
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
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Expected O, but got Unknown
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Expected O, but got Unknown
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Expected O, but got Unknown
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		missionName = (GTextField)((GComponent)this).GetChild("missionName");
		string id = "ui://f4wr270rdpf03v".Replace("ui://", "") + "-" + ((GObject)missionName).id;
		((GObject)missionName).text = LanguagesManager.GetDesc(id);
		advanceMissionName = (GTextField)((GComponent)this).GetChild("advanceMissionName");
		string id2 = "ui://f4wr270rdpf03v".Replace("ui://", "") + "-" + ((GObject)advanceMissionName).id;
		((GObject)advanceMissionName).text = LanguagesManager.GetDesc(id2);
		back2 = (GGraph)((GComponent)this).GetChild("back2");
		assembledBtn = (UI_assembledBtn)(object)((GComponent)this).GetChild("assembledBtn");
		n8 = (GGraph)((GComponent)this).GetChild("n8");
		rewardIcon0 = (GLoader)((GComponent)this).GetChild("rewardIcon0");
		rewardNum0 = (GTextField)((GComponent)this).GetChild("rewardNum0");
		reward0 = (GGroup)((GComponent)this).GetChild("reward0");
		n42 = (GGraph)((GComponent)this).GetChild("n42");
		rewardIcon1 = (GLoader)((GComponent)this).GetChild("rewardIcon1");
		rewardNum1 = (GTextField)((GComponent)this).GetChild("rewardNum1");
		reward1 = (GGroup)((GComponent)this).GetChild("reward1");
		n38 = (GGraph)((GComponent)this).GetChild("n38");
		rewardIcon2 = (GLoader)((GComponent)this).GetChild("rewardIcon2");
		rewardNum2 = (GTextField)((GComponent)this).GetChild("rewardNum2");
		reward2 = (GGroup)((GComponent)this).GetChild("reward2");
		n34 = (GGraph)((GComponent)this).GetChild("n34");
		rewardIcon3 = (GLoader)((GComponent)this).GetChild("rewardIcon3");
		rewardNum3 = (GTextField)((GComponent)this).GetChild("rewardNum3");
		reward3 = (GGroup)((GComponent)this).GetChild("reward3");
		flashImage = (GImage)((GComponent)this).GetChild("flashImage");
		curPower = (GTextField)((GComponent)this).GetChild("curPower");
		string id3 = "ui://f4wr270rdpf03v".Replace("ui://", "") + "-" + ((GObject)curPower).id;
		((GObject)curPower).text = LanguagesManager.GetDesc(id3);
		combat = (GTextField)((GComponent)this).GetChild("combat");
		string id4 = "ui://f4wr270rdpf03v".Replace("ui://", "") + "-" + ((GObject)combat).id;
		((GObject)combat).text = LanguagesManager.GetDesc(id4);
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id5 = "ui://f4wr270rdpf03v".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id5);
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id6 = "ui://f4wr270rdpf03v".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id6);
		quickBtn = (UI_PropetryLock)(object)((GComponent)this).GetChild("quickBtn");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n33 = (GImage)((GComponent)this).GetChild("n33");
	}
}
