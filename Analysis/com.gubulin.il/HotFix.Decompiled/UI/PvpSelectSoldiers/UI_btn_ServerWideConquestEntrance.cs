using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_btn_ServerWideConquestEntrance : GComponent
{
	public Controller ConquestRound;

	public Controller PlayerRankState;

	public Controller HasRewardToGet;

	public GImage CardFrame;

	public GLoader CardPicture;

	public GLoader TitleName;

	public GTextField EventDuration;

	public GLoader PlayerRankPanel;

	public GImage DevilRibbon;

	public GTextField PlayerRankText;

	public GTextField PlayerRankNumber;

	public GMovieClip RemindReward;

	public GImage n25;

	public GTextField ShortlistStatus;

	public GGroup ShortlistStatusGroup;

	public GGroup PlayerRankGroup;

	public GImage n17;

	public GTextField SecondInfoTitle;

	public GTextField SecondInfoContent;

	public GGroup SecondInfoGroup;

	public GImage n21;

	public GTextField StateText;

	public GGroup StateGroup;

	public GButton LadderTournamentButton;

	public GGroup CardGroup;

	public Transition t0;

	public const string URL = "ui://82mo10n5ooqpdou";

	public static string Name = "UI_btn_ServerWideConquestEntrance";

	public static string GetURL()
	{
		return "ui://82mo10n5ooqpdou";
	}

	public static UI_btn_ServerWideConquestEntrance CreateInstance()
	{
		return (UI_btn_ServerWideConquestEntrance)(object)UIPackage.CreateObject("PvpSelectSoldiers", "btn_ServerWideConquestEntrance");
	}

	public static UI_btn_ServerWideConquestEntrance CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ServerWideConquestEntrance).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5ooqpdou", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ConquestRound = ((GComponent)this).GetController("ConquestRound");
		PlayerRankState = ((GComponent)this).GetController("PlayerRankState");
		HasRewardToGet = ((GComponent)this).GetController("HasRewardToGet");
		CardFrame = (GImage)((GComponent)this).GetChild("CardFrame");
		CardPicture = (GLoader)((GComponent)this).GetChild("CardPicture");
		TitleName = (GLoader)((GComponent)this).GetChild("TitleName");
		EventDuration = (GTextField)((GComponent)this).GetChild("EventDuration");
		PlayerRankPanel = (GLoader)((GComponent)this).GetChild("PlayerRankPanel");
		DevilRibbon = (GImage)((GComponent)this).GetChild("DevilRibbon");
		PlayerRankText = (GTextField)((GComponent)this).GetChild("PlayerRankText");
		string id = "ui://82mo10n5ooqpdou".Replace("ui://", "") + "-" + ((GObject)PlayerRankText).id;
		((GObject)PlayerRankText).text = LanguagesManager.GetDesc(id);
		PlayerRankNumber = (GTextField)((GComponent)this).GetChild("PlayerRankNumber");
		RemindReward = (GMovieClip)((GComponent)this).GetChild("RemindReward");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		ShortlistStatus = (GTextField)((GComponent)this).GetChild("ShortlistStatus");
		string id2 = "ui://82mo10n5ooqpdou".Replace("ui://", "") + "-" + ((GObject)ShortlistStatus).id;
		((GObject)ShortlistStatus).text = LanguagesManager.GetDesc(id2);
		ShortlistStatusGroup = (GGroup)((GComponent)this).GetChild("ShortlistStatusGroup");
		PlayerRankGroup = (GGroup)((GComponent)this).GetChild("PlayerRankGroup");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		SecondInfoTitle = (GTextField)((GComponent)this).GetChild("SecondInfoTitle");
		string id3 = "ui://82mo10n5ooqpdou".Replace("ui://", "") + "-" + ((GObject)SecondInfoTitle).id;
		((GObject)SecondInfoTitle).text = LanguagesManager.GetDesc(id3);
		SecondInfoContent = (GTextField)((GComponent)this).GetChild("SecondInfoContent");
		SecondInfoGroup = (GGroup)((GComponent)this).GetChild("SecondInfoGroup");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		StateText = (GTextField)((GComponent)this).GetChild("StateText");
		string id4 = "ui://82mo10n5ooqpdou".Replace("ui://", "") + "-" + ((GObject)StateText).id;
		((GObject)StateText).text = LanguagesManager.GetDesc(id4);
		StateGroup = (GGroup)((GComponent)this).GetChild("StateGroup");
		LadderTournamentButton = (GButton)((GComponent)this).GetChild("LadderTournamentButton");
		CardGroup = (GGroup)((GComponent)this).GetChild("CardGroup");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
