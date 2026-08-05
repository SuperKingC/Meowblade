using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_Com_NeutralLevelCard : GComponent
{
	public GImage n46;

	public GTextField missionName;

	public UI_assembledBtn assembledBtn;

	public GImage flashImage;

	public GTextField curPower;

	public GTextField combat;

	public UI_PropetryLock quickBtn;

	public GImage n31;

	public GImage n32;

	public GImage n33;

	public GImage n47;

	public GLoader rewardIcon0;

	public GTextField rewardNum0;

	public GGroup reward0;

	public GImage n48;

	public GLoader rewardIcon1;

	public GTextField rewardNum1;

	public GGroup reward1;

	public const string URL = "ui://f4wr270rgq2l80";

	public static string Name = "UI_Com_NeutralLevelCard";

	public static string GetURL()
	{
		return "ui://f4wr270rgq2l80";
	}

	public static UI_Com_NeutralLevelCard CreateInstance()
	{
		return (UI_Com_NeutralLevelCard)(object)UIPackage.CreateObject("InstanceZones", "Com_NeutralLevelCard");
	}

	public static UI_Com_NeutralLevelCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Com_NeutralLevelCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rgq2l80", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n46 = (GImage)((GComponent)this).GetChild("n46");
		missionName = (GTextField)((GComponent)this).GetChild("missionName");
		assembledBtn = (UI_assembledBtn)(object)((GComponent)this).GetChild("assembledBtn");
		flashImage = (GImage)((GComponent)this).GetChild("flashImage");
		curPower = (GTextField)((GComponent)this).GetChild("curPower");
		string id = "ui://f4wr270rgq2l80".Replace("ui://", "") + "-" + ((GObject)curPower).id;
		((GObject)curPower).text = LanguagesManager.GetDesc(id);
		combat = (GTextField)((GComponent)this).GetChild("combat");
		string id2 = "ui://f4wr270rgq2l80".Replace("ui://", "") + "-" + ((GObject)combat).id;
		((GObject)combat).text = LanguagesManager.GetDesc(id2);
		quickBtn = (UI_PropetryLock)(object)((GComponent)this).GetChild("quickBtn");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		rewardIcon0 = (GLoader)((GComponent)this).GetChild("rewardIcon0");
		rewardNum0 = (GTextField)((GComponent)this).GetChild("rewardNum0");
		reward0 = (GGroup)((GComponent)this).GetChild("reward0");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		rewardIcon1 = (GLoader)((GComponent)this).GetChild("rewardIcon1");
		rewardNum1 = (GTextField)((GComponent)this).GetChild("rewardNum1");
		reward1 = (GGroup)((GComponent)this).GetChild("reward1");
	}
}
