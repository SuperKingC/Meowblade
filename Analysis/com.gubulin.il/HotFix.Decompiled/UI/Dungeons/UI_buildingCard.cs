using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Dungeons;

public class UI_buildingCard : GComponent
{
	public Controller button;

	public GImage background;

	public GImage n65;

	public GImage n66;

	public GLoader buildingBack;

	public GLoader buildingIcon;

	public GGraph textBack;

	public GGraph rightBack;

	public GGraph leftBack;

	public GTextField title;

	public GTextField buildingLevel;

	public GTextField cueLevel;

	public GTextField description;

	public GTextField noneSlot;

	public GTextField maxLevelTip;

	public GImage n44;

	public GGroup maxLevelGroup;

	public GTextField upgradeDemand;

	public UI_upgradeBtn upgradeBtn;

	public UI_acceptanceBtn acceptanceBtn;

	public UI_repairBtn repairBtn;

	public GGroup buttonGroup;

	public GProgressBar jobSschedule;

	public GTextField n7;

	public GTextField nextTitle;

	public GLoader nextSlotIcon;

	public GTextField nextSlot;

	public GGroup nextSlotGroup;

	public GTextField Left_;

	public GGroup LeftContent;

	public GTextField n8;

	public GTextField lastTitle;

	public GLoader lastSlotIcon;

	public GTextField lastSlot;

	public GGroup lastSlotGroup;

	public GTextField Right_;

	public GGroup RightContent;

	public GImage n67;

	public GImage n68;

	public const string URL = "ui://e3srq2g9t0xvd";

	public static string Name = "UI_buildingCard";

	public static string GetURL()
	{
		return "ui://e3srq2g9t0xvd";
	}

	public static UI_buildingCard CreateInstance()
	{
		return (UI_buildingCard)(object)UIPackage.CreateObject("Dungeons", "buildingCard");
	}

	public static UI_buildingCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_buildingCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://e3srq2g9t0xvd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected O, but got Unknown
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Expected O, but got Unknown
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Expected O, but got Unknown
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Expected O, but got Unknown
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Expected O, but got Unknown
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Expected O, but got Unknown
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Expected O, but got Unknown
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Expected O, but got Unknown
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Expected O, but got Unknown
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Expected O, but got Unknown
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f6: Expected O, but got Unknown
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_050c: Expected O, but got Unknown
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Expected O, but got Unknown
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Expected O, but got Unknown
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		n66 = (GImage)((GComponent)this).GetChild("n66");
		buildingBack = (GLoader)((GComponent)this).GetChild("buildingBack");
		buildingIcon = (GLoader)((GComponent)this).GetChild("buildingIcon");
		textBack = (GGraph)((GComponent)this).GetChild("textBack");
		rightBack = (GGraph)((GComponent)this).GetChild("rightBack");
		leftBack = (GGraph)((GComponent)this).GetChild("leftBack");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://e3srq2g9t0xvd".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		buildingLevel = (GTextField)((GComponent)this).GetChild("buildingLevel");
		string id2 = "ui://e3srq2g9t0xvd".Replace("ui://", "") + "-" + ((GObject)buildingLevel).id;
		((GObject)buildingLevel).text = LanguagesManager.GetDesc(id2);
		cueLevel = (GTextField)((GComponent)this).GetChild("cueLevel");
		string id3 = "ui://e3srq2g9t0xvd".Replace("ui://", "") + "-" + ((GObject)cueLevel).id;
		((GObject)cueLevel).text = LanguagesManager.GetDesc(id3);
		description = (GTextField)((GComponent)this).GetChild("description");
		noneSlot = (GTextField)((GComponent)this).GetChild("noneSlot");
		maxLevelTip = (GTextField)((GComponent)this).GetChild("maxLevelTip");
		string id4 = "ui://e3srq2g9t0xvd".Replace("ui://", "") + "-" + ((GObject)maxLevelTip).id;
		((GObject)maxLevelTip).text = LanguagesManager.GetDesc(id4);
		n44 = (GImage)((GComponent)this).GetChild("n44");
		maxLevelGroup = (GGroup)((GComponent)this).GetChild("maxLevelGroup");
		upgradeDemand = (GTextField)((GComponent)this).GetChild("upgradeDemand");
		upgradeBtn = (UI_upgradeBtn)(object)((GComponent)this).GetChild("upgradeBtn");
		acceptanceBtn = (UI_acceptanceBtn)(object)((GComponent)this).GetChild("acceptanceBtn");
		repairBtn = (UI_repairBtn)(object)((GComponent)this).GetChild("repairBtn");
		buttonGroup = (GGroup)((GComponent)this).GetChild("buttonGroup");
		jobSschedule = (GProgressBar)((GComponent)this).GetChild("jobSschedule");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id5 = "ui://e3srq2g9t0xvd".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id5);
		nextTitle = (GTextField)((GComponent)this).GetChild("nextTitle");
		string id6 = "ui://e3srq2g9t0xvd".Replace("ui://", "") + "-" + ((GObject)nextTitle).id;
		((GObject)nextTitle).text = LanguagesManager.GetDesc(id6);
		nextSlotIcon = (GLoader)((GComponent)this).GetChild("nextSlotIcon");
		nextSlot = (GTextField)((GComponent)this).GetChild("nextSlot");
		nextSlotGroup = (GGroup)((GComponent)this).GetChild("nextSlotGroup");
		Left_ = (GTextField)((GComponent)this).GetChild("Left-");
		LeftContent = (GGroup)((GComponent)this).GetChild("LeftContent");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id7 = "ui://e3srq2g9t0xvd".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id7);
		lastTitle = (GTextField)((GComponent)this).GetChild("lastTitle");
		string id8 = "ui://e3srq2g9t0xvd".Replace("ui://", "") + "-" + ((GObject)lastTitle).id;
		((GObject)lastTitle).text = LanguagesManager.GetDesc(id8);
		lastSlotIcon = (GLoader)((GComponent)this).GetChild("lastSlotIcon");
		lastSlot = (GTextField)((GComponent)this).GetChild("lastSlot");
		lastSlotGroup = (GGroup)((GComponent)this).GetChild("lastSlotGroup");
		Right_ = (GTextField)((GComponent)this).GetChild("Right-");
		RightContent = (GGroup)((GComponent)this).GetChild("RightContent");
		n67 = (GImage)((GComponent)this).GetChild("n67");
		n68 = (GImage)((GComponent)this).GetChild("n68");
	}
}
