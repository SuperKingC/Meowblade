using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_SelectPeakBattleArrayDialog : GComponent
{
	public Controller SoldiersStatus;

	public Controller IsInTopTournament;

	public Controller TabType;

	public GImage back;

	public GGraph n63;

	public GGraph n64;

	public GImage n75;

	public GTextField title;

	public GTextField title2;

	public GTextField title3;

	public GImage n76;

	public GGroup n83;

	public GGraph n49;

	public UI_btn_PeakBattleTab DailyTab;

	public UI_btn_PeakBattleTab WeekendTab;

	public UI_PeakBattleSketchMap FormationSketchMap;

	public GGraph n62;

	public GImage flashImage;

	public GTextField OurCombat;

	public GTextField n47;

	public GGroup PowerMine;

	public GImage SoldiersListBack;

	public UI_OpenSoliders SoldiersSwitch;

	public GList Soliders;

	public GButton ConfirmBtn;

	public UI_SeasonBuffLabel SeasonBuffLabel;

	public GImage n58;

	public GTextField n59;

	public GTextField n61;

	public GTextField n65;

	public GTextField n66;

	public GButton exitBtn;

	public UI_CurPeakFormation n52;

	public const string URL = "ui://82mo10n5x1jlddk";

	public static string Name = "UI_SelectPeakBattleArrayDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5x1jlddk";
	}

	public static UI_SelectPeakBattleArrayDialog CreateInstance()
	{
		return (UI_SelectPeakBattleArrayDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "SelectPeakBattleArrayDialog");
	}

	public static UI_SelectPeakBattleArrayDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SelectPeakBattleArrayDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5x1jlddk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Expected O, but got Unknown
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Expected O, but got Unknown
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Expected O, but got Unknown
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SoldiersStatus = ((GComponent)this).GetController("SoldiersStatus");
		IsInTopTournament = ((GComponent)this).GetController("IsInTopTournament");
		TabType = ((GComponent)this).GetController("TabType");
		back = (GImage)((GComponent)this).GetChild("back");
		n63 = (GGraph)((GComponent)this).GetChild("n63");
		n64 = (GGraph)((GComponent)this).GetChild("n64");
		n75 = (GImage)((GComponent)this).GetChild("n75");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://82mo10n5x1jlddk".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		title2 = (GTextField)((GComponent)this).GetChild("title2");
		string id2 = "ui://82mo10n5x1jlddk".Replace("ui://", "") + "-" + ((GObject)title2).id;
		((GObject)title2).text = LanguagesManager.GetDesc(id2);
		title3 = (GTextField)((GComponent)this).GetChild("title3");
		string id3 = "ui://82mo10n5x1jlddk".Replace("ui://", "") + "-" + ((GObject)title3).id;
		((GObject)title3).text = LanguagesManager.GetDesc(id3);
		n76 = (GImage)((GComponent)this).GetChild("n76");
		n83 = (GGroup)((GComponent)this).GetChild("n83");
		n49 = (GGraph)((GComponent)this).GetChild("n49");
		DailyTab = (UI_btn_PeakBattleTab)(object)((GComponent)this).GetChild("DailyTab");
		WeekendTab = (UI_btn_PeakBattleTab)(object)((GComponent)this).GetChild("WeekendTab");
		FormationSketchMap = (UI_PeakBattleSketchMap)(object)((GComponent)this).GetChild("FormationSketchMap");
		n62 = (GGraph)((GComponent)this).GetChild("n62");
		flashImage = (GImage)((GComponent)this).GetChild("flashImage");
		OurCombat = (GTextField)((GComponent)this).GetChild("OurCombat");
		n47 = (GTextField)((GComponent)this).GetChild("n47");
		string id4 = "ui://82mo10n5x1jlddk".Replace("ui://", "") + "-" + ((GObject)n47).id;
		((GObject)n47).text = LanguagesManager.GetDesc(id4);
		PowerMine = (GGroup)((GComponent)this).GetChild("PowerMine");
		SoldiersListBack = (GImage)((GComponent)this).GetChild("SoldiersListBack");
		SoldiersSwitch = (UI_OpenSoliders)(object)((GComponent)this).GetChild("SoldiersSwitch");
		Soliders = (GList)((GComponent)this).GetChild("Soliders");
		ConfirmBtn = (GButton)((GComponent)this).GetChild("ConfirmBtn");
		SeasonBuffLabel = (UI_SeasonBuffLabel)(object)((GComponent)this).GetChild("SeasonBuffLabel");
		n58 = (GImage)((GComponent)this).GetChild("n58");
		n59 = (GTextField)((GComponent)this).GetChild("n59");
		string id5 = "ui://82mo10n5x1jlddk".Replace("ui://", "") + "-" + ((GObject)n59).id;
		((GObject)n59).text = LanguagesManager.GetDesc(id5);
		n61 = (GTextField)((GComponent)this).GetChild("n61");
		string id6 = "ui://82mo10n5x1jlddk".Replace("ui://", "") + "-" + ((GObject)n61).id;
		((GObject)n61).text = LanguagesManager.GetDesc(id6);
		n65 = (GTextField)((GComponent)this).GetChild("n65");
		string id7 = "ui://82mo10n5x1jlddk".Replace("ui://", "") + "-" + ((GObject)n65).id;
		((GObject)n65).text = LanguagesManager.GetDesc(id7);
		n66 = (GTextField)((GComponent)this).GetChild("n66");
		string id8 = "ui://82mo10n5x1jlddk".Replace("ui://", "") + "-" + ((GObject)n66).id;
		((GObject)n66).text = LanguagesManager.GetDesc(id8);
		exitBtn = (GButton)((GComponent)this).GetChild("exitBtn");
		n52 = (UI_CurPeakFormation)(object)((GComponent)this).GetChild("n52");
	}
}
