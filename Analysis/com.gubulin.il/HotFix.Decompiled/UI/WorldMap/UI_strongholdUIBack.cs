using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_strongholdUIBack : GButton
{
	public Controller button;

	public Controller pageController;

	public Controller rewardType;

	public GImage n27;

	public GLoader soldierIconFrame;

	public GLoader soldierIcon;

	public GLoader goodIcon;

	public GTextField outputTitle;

	public GTextField outputNum;

	public GProgressBar ProgressBarForUi;

	public GImage modifierBack;

	public GTextField modifierText;

	public GGroup modifierGroup;

	public GImage MaxIcon;

	public GImage note;

	public GGroup group1;

	public GImage single;

	public GImage multiple;

	public GList BonusList;

	public GLoader guideReward5;

	public Transition showSelf;

	public const string URL = "ui://c9n2h0ksomji7";

	public static string Name = "UI_strongholdUIBack";

	public static string GetURL()
	{
		return "ui://c9n2h0ksomji7";
	}

	public static UI_strongholdUIBack CreateInstance()
	{
		return (UI_strongholdUIBack)(object)UIPackage.CreateObject("WorldMap", "strongholdUIBack");
	}

	public static UI_strongholdUIBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_strongholdUIBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksomji7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		pageController = ((GComponent)this).GetController("pageController");
		rewardType = ((GComponent)this).GetController("rewardType");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		soldierIconFrame = (GLoader)((GComponent)this).GetChild("soldierIconFrame");
		soldierIcon = (GLoader)((GComponent)this).GetChild("soldierIcon");
		goodIcon = (GLoader)((GComponent)this).GetChild("goodIcon");
		outputTitle = (GTextField)((GComponent)this).GetChild("outputTitle");
		string id = "ui://c9n2h0ksomji7".Replace("ui://", "") + "-" + ((GObject)outputTitle).id;
		((GObject)outputTitle).text = LanguagesManager.GetDesc(id);
		outputNum = (GTextField)((GComponent)this).GetChild("outputNum");
		string id2 = "ui://c9n2h0ksomji7".Replace("ui://", "") + "-" + ((GObject)outputNum).id;
		((GObject)outputNum).text = LanguagesManager.GetDesc(id2);
		ProgressBarForUi = (GProgressBar)((GComponent)this).GetChild("ProgressBarForUi");
		modifierBack = (GImage)((GComponent)this).GetChild("modifierBack");
		modifierText = (GTextField)((GComponent)this).GetChild("modifierText");
		string id3 = "ui://c9n2h0ksomji7".Replace("ui://", "") + "-" + ((GObject)modifierText).id;
		((GObject)modifierText).text = LanguagesManager.GetDesc(id3);
		modifierGroup = (GGroup)((GComponent)this).GetChild("modifierGroup");
		MaxIcon = (GImage)((GComponent)this).GetChild("MaxIcon");
		note = (GImage)((GComponent)this).GetChild("note");
		group1 = (GGroup)((GComponent)this).GetChild("group1");
		single = (GImage)((GComponent)this).GetChild("single");
		multiple = (GImage)((GComponent)this).GetChild("multiple");
		BonusList = (GList)((GComponent)this).GetChild("BonusList");
		guideReward5 = (GLoader)((GComponent)this).GetChild("guideReward5");
		showSelf = ((GComponent)this).GetTransition("showSelf");
	}
}
