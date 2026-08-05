using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_RewardAndChoose : GComponent
{
	public Controller PageController;

	public GImage back;

	public UI_DungeonLevel experienceBar;

	public UI_DevilsIconBtn DevilsIcon;

	public GTextField nameText;

	public GTextField levelText;

	public GGraph levelSfxBack;

	public GTextField experienceIncrement;

	public GGraph line;

	public GGroup DevilsLevelGroup;

	public GTextField IntrinsicRewards;

	public GTextField MyChoice;

	public UI_TreasureHuntBossLevelBox TreasureHuntBossLevelBox;

	public GList StaticRewards;

	public UI_DropStart choose;

	public UI_MainReward MainReward;

	public GTextField IncomeText;

	public GLoader pointsIcon;

	public UI_IncomeBtn IncomeBtn;

	public GTextField ExtraScoreText;

	public GLoader ExtraScoreIcon;

	public GGroup ExtraScoreGroup;

	public Transition ShowPoints;

	public Transition ShowIncome;

	public Transition ShowTreasureHuntBossLevelBonus;

	public const string URL = "ui://hda5vzklvv0u2o";

	public static string Name = "UI_RewardAndChoose";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://hda5vzklvv0u2o".Replace("ui://", ""), ((GObject)IntrinsicRewards).id, PageController.selectedIndex);
		((GObject)IntrinsicRewards).text = LanguagesManager.GetDesc(id);
		string id2 = string.Format("{0}-{1}-{2}", "ui://hda5vzklvv0u2o".Replace("ui://", ""), ((GObject)MyChoice).id, PageController.selectedIndex);
		((GObject)MyChoice).text = LanguagesManager.GetDesc(id2);
	}

	public static string GetURL()
	{
		return "ui://hda5vzklvv0u2o";
	}

	public static UI_RewardAndChoose CreateInstance()
	{
		return (UI_RewardAndChoose)(object)UIPackage.CreateObject("GameEndPanels", "RewardAndChoose");
	}

	public static UI_RewardAndChoose CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RewardAndChoose).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklvv0u2o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		back = (GImage)((GComponent)this).GetChild("back");
		experienceBar = (UI_DungeonLevel)(object)((GComponent)this).GetChild("experienceBar");
		DevilsIcon = (UI_DevilsIconBtn)(object)((GComponent)this).GetChild("DevilsIcon");
		nameText = (GTextField)((GComponent)this).GetChild("nameText");
		levelText = (GTextField)((GComponent)this).GetChild("levelText");
		levelSfxBack = (GGraph)((GComponent)this).GetChild("levelSfxBack");
		experienceIncrement = (GTextField)((GComponent)this).GetChild("experienceIncrement");
		string id = "ui://hda5vzklvv0u2o".Replace("ui://", "") + "-" + ((GObject)experienceIncrement).id;
		((GObject)experienceIncrement).text = LanguagesManager.GetDesc(id);
		line = (GGraph)((GComponent)this).GetChild("line");
		DevilsLevelGroup = (GGroup)((GComponent)this).GetChild("DevilsLevelGroup");
		IntrinsicRewards = (GTextField)((GComponent)this).GetChild("IntrinsicRewards");
		string id2 = "ui://hda5vzklvv0u2o".Replace("ui://", "") + "-" + ((GObject)IntrinsicRewards).id;
		((GObject)IntrinsicRewards).text = LanguagesManager.GetDesc(id2);
		MyChoice = (GTextField)((GComponent)this).GetChild("MyChoice");
		string id3 = "ui://hda5vzklvv0u2o".Replace("ui://", "") + "-" + ((GObject)MyChoice).id;
		((GObject)MyChoice).text = LanguagesManager.GetDesc(id3);
		TreasureHuntBossLevelBox = (UI_TreasureHuntBossLevelBox)(object)((GComponent)this).GetChild("TreasureHuntBossLevelBox");
		StaticRewards = (GList)((GComponent)this).GetChild("StaticRewards");
		choose = (UI_DropStart)(object)((GComponent)this).GetChild("choose");
		MainReward = (UI_MainReward)(object)((GComponent)this).GetChild("MainReward");
		IncomeText = (GTextField)((GComponent)this).GetChild("IncomeText");
		pointsIcon = (GLoader)((GComponent)this).GetChild("pointsIcon");
		IncomeBtn = (UI_IncomeBtn)(object)((GComponent)this).GetChild("IncomeBtn");
		ExtraScoreText = (GTextField)((GComponent)this).GetChild("ExtraScoreText");
		ExtraScoreIcon = (GLoader)((GComponent)this).GetChild("ExtraScoreIcon");
		ExtraScoreGroup = (GGroup)((GComponent)this).GetChild("ExtraScoreGroup");
		ShowPoints = ((GComponent)this).GetTransition("ShowPoints");
		ShowIncome = ((GComponent)this).GetTransition("ShowIncome");
		ShowTreasureHuntBossLevelBonus = ((GComponent)this).GetTransition("ShowTreasureHuntBossLevelBonus");
	}
}
