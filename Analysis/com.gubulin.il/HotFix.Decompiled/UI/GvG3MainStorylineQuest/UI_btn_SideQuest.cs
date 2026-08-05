using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3MainStorylineQuest;

public class UI_btn_SideQuest : GButton
{
	public Controller Status;

	public Controller Selected;

	public Controller Type;

	public GImage n16;

	public GImage n5;

	public GTextField QuestDesc;

	public GTextField n1;

	public GLoader EnergyIcon;

	public GTextField AddCampEnergy;

	public GTextField n4;

	public GImage n19;

	public GLoader RewardIcon;

	public GImage n8;

	public GMovieClip n20;

	public GTextField n10;

	public GTextField n11;

	public UI_SideQuestBar Progress;

	public GTextField BonusNumber;

	public GImage n9;

	public GImage n18;

	public const string URL = "ui://249h3k3dvihg20";

	public static string Name = "UI_btn_SideQuest";

	public static string GetURL()
	{
		return "ui://249h3k3dvihg20";
	}

	public static UI_btn_SideQuest CreateInstance()
	{
		return (UI_btn_SideQuest)(object)UIPackage.CreateObject("GvG3MainStorylineQuest", "btn_SideQuest");
	}

	public static UI_btn_SideQuest CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SideQuest).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://249h3k3dvihg20", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Selected = ((GComponent)this).GetController("Selected");
		Type = ((GComponent)this).GetController("Type");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		QuestDesc = (GTextField)((GComponent)this).GetChild("QuestDesc");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://249h3k3dvihg20".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		EnergyIcon = (GLoader)((GComponent)this).GetChild("EnergyIcon");
		AddCampEnergy = (GTextField)((GComponent)this).GetChild("AddCampEnergy");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://249h3k3dvihg20".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		n19 = (GImage)((GComponent)this).GetChild("n19");
		RewardIcon = (GLoader)((GComponent)this).GetChild("RewardIcon");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n20 = (GMovieClip)((GComponent)this).GetChild("n20");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id3 = "ui://249h3k3dvihg20".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id3);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id4 = "ui://249h3k3dvihg20".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id4);
		Progress = (UI_SideQuestBar)(object)((GComponent)this).GetChild("Progress");
		BonusNumber = (GTextField)((GComponent)this).GetChild("BonusNumber");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n18 = (GImage)((GComponent)this).GetChild("n18");
	}
}
